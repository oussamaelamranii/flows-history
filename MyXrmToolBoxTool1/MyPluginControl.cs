using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyXrmToolBoxTool1.Enums;
using MyXrmToolBoxTool1.Extensions;
using MyXrmToolBoxTool1.Helpers;
using MyXrmToolBoxTool1.Models;
using MyXrmToolBoxTool1.Services;
using Newtonsoft.Json;
using XrmToolBox.Extensibility;
using Microsoft.Identity.Client;

namespace MyXrmToolBoxTool1
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;

        private AccessTokenResponse _flowAccessToken;

        public List<FlowRun> FlowRuns = new List<FlowRun>();
        public List<Flow> Flows = new List<Flow>();
        public List<Solution> Solutions = new List<Solution>();

        private FlowClient flowClient;
        private DataverseClient dataverseClient;
        private OrganizationGeo Geo;

        // Pagination state
        private int _currentPage = 1;
        private int _pageSize = 50;
        private List<FlowRun> _sortedFlowRuns = new List<FlowRun>();

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            // Set default dates
            var today = DateTime.Now;
            dtpDateFrom.Value = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            dtpDateTo.Value = dtpDateFrom.Value.AddDays(1);

            // Set default status
            cbxStatus.SelectedIndex = 0; // "All"

            // Init page size combo
            cbxPageSize.SelectedIndex = 1; // default to 50

            // Show connect button only if no client secret configured
            if (string.IsNullOrWhiteSpace(ConnectionDetail?.S2SClientSecret))
            {
                ShowInfoNotification(
                    "Connect to the Power Automate API using the toolbar button, or configure Client ID/Secret for automatic connection.",
                    new Uri("https://learn.microsoft.com/en-us/power-platform/admin/manage-application-users#create-an-application-user"));
            }

            // Context Menu for canceling runs
            var cms = new ContextMenuStrip();
            var cancelItem = new ToolStripMenuItem("Cancel Selected Running Runs");
            cancelItem.Click += CancelItem_Click;
            cms.Items.Add(cancelItem);
            dgvFlowRuns.ContextMenuStrip = cms;
            
            ApplyModernStyles();
        }

        #region UI Styling
        
        private void ApplyModernStyles()
        {
            // Set global font
            var mainFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            this.Font = mainFont;
            this.BackColor = Color.White;

            // Style DataGridView
            dgvFlowRuns.BackgroundColor = Color.White;
            dgvFlowRuns.BorderStyle = BorderStyle.None;
            dgvFlowRuns.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFlowRuns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFlowRuns.RowHeadersVisible = false;
            
            // Alternating rows
            dgvFlowRuns.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvFlowRuns.RowsDefaultCellStyle.BackColor = Color.White;
            dgvFlowRuns.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Modern blue
            dgvFlowRuns.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Column Headers
            dgvFlowRuns.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvFlowRuns.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvFlowRuns.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvFlowRuns.EnableHeadersVisualStyles = false;

            // Style Main Button
            btnGetRuns.FlatStyle = FlatStyle.Flat;
            btnGetRuns.FlatAppearance.BorderSize = 0;
            btnGetRuns.BackColor = Color.FromArgb(0, 120, 215); // Modern blue
            btnGetRuns.ForeColor = Color.White;
            btnGetRuns.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnGetRuns.Cursor = Cursors.Hand;
            
            // Set Split container colors
            splitContainerMain.BackColor = Color.FromArgb(230, 230, 230); // Makes the splitter visible
            splitContainerMain.Panel1.BackColor = Color.White;
            splitContainerMain.Panel2.BackColor = Color.White;

            // CheckedListBox
            clbFlows.BorderStyle = BorderStyle.None;
            
            // TextBoxes and ComboBoxes
            tbSearch.BorderStyle = BorderStyle.FixedSingle;
            cbSolutions.FlatStyle = FlatStyle.Flat;
            cbxStatus.FlatStyle = FlatStyle.Flat;
            cbxPageSize.FlatStyle = FlatStyle.Flat;

            // Pagination panel
            pnlPagination.BackColor = Color.FromArgb(245, 245, 245);

            // Pagination buttons
            foreach (var btn in new[] { btnPrevPage, btnNextPage })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
                btn.FlatAppearance.BorderSize = 1;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(0, 120, 215);
                btn.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                btn.Cursor = Cursors.Hand;
            }

            lblPageInfo.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            lblPageInfo.ForeColor = Color.FromArgb(80, 80, 80);
            lblPageSize.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            lblPageSize.ForeColor = Color.FromArgb(80, 80, 80);
        }

        #endregion

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        #region Connection & Auth

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail,
            string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            Geo = detail.GetGeo();
            dataverseClient = new DataverseClient(newService);

            // Reset flow client when connection changes
            flowClient = null;
            _flowAccessToken = null;

            // Auto-enable if client secret is available
            var hasClientSecret = !string.IsNullOrWhiteSpace(detail.S2SClientSecret);
            gbRunFilters.Enabled = hasClientSecret;
            tsbConnectFlowApi.Visible = !hasClientSecret;
            tsbRefresh.Visible = hasClientSecret;

            ExecuteMethod(LoadFlows);
            ExecuteMethod(LoadSolutions);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private async void tsbConnectFlowApi_Click(object sender, EventArgs e)
        {
            var clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";
            var redirectUri = "app://58145B91-0C36-4500-8554-080854F2AC97";
            var audienceUrl = FlowEndpointHelper.GetAudienceUrl(Geo);
            var scopes = new[] { $"{audienceUrl}/.default" };

            if (ConnectionDetail.TenantId == Guid.Empty)
            {
                MessageBox.Show(
                    "You are using the deprecated connection method. Please use OAuth/MFA or Client ID/Secret method.",
                    "Deprecated Connection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var tenantId = ConnectionDetail.TenantId.ToString("D");
            var app = PublicClientApplicationBuilder.Create(clientId).WithRedirectUri(redirectUri).Build();

            AuthenticationResult authResult;

            try
            {
                var accounts = await app.GetAccountsAsync();
                var account = accounts.FirstOrDefault();

                authResult = await app
                    .AcquireTokenSilent(scopes, account)
                    .WithTenantId(tenantId)
                    .ExecuteAsync();

                _flowAccessToken = new AccessTokenResponse
                {
                    access_token = authResult.AccessToken,
                    token_type = authResult.TokenType,
                };

                gbRunFilters.Enabled = true;
                tsbRefresh.Visible = true;
                HideNotification();
            }
            catch (MsalUiRequiredException)
            {
                try
                {
                    authResult = await app
                        .AcquireTokenInteractive(scopes)
                        .WithTenantId(tenantId)
                        .ExecuteAsync();

                    _flowAccessToken = new AccessTokenResponse
                    {
                        access_token = authResult.AccessToken,
                        token_type = authResult.TokenType,
                    };

                    gbRunFilters.Enabled = true;
                    tsbRefresh.Visible = true;
                    HideNotification();
                }
                catch (MsalClientException ex)
                {
                    if (ex.ErrorCode == "authentication_canceled")
                    {
                        return;
                    }
                    MessageBox.Show(ex.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Load Solutions

        private void LoadSolutions()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting solutions...",
                Work = (worker, args) =>
                {
                    var solutions = dataverseClient.GetSolutions();
                    args.Result = solutions;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error.InnerException ?? args.Error);
                        return;
                    }

                    if (!(args.Result is List<Solution> solutions)) { return; }

                    // 1. Prepare your list
                    var allSolutions = new Solution
                    {
                        Id = Guid.Empty,
                        Name = "<All Solutions>"
                    };
                    solutions.Insert(0, allSolutions);

                    // 2. FIX: Reset the DataSource to null first
                    cbSolutions.DataSource = null;

                    // 3. Clear items (Optional, usually nulling the DataSource is enough)
                    cbSolutions.Items.Clear();

                    // 4. Re-bind the new list
                    cbSolutions.DataSource = solutions;

                    // 5. Ensure DisplayMember and ValueMember are set if needed
                    cbSolutions.DisplayMember = "Name"; // Adjust based on your Solution model
                    cbSolutions.ValueMember = "Id";
                }
            });
        }

        private void cbSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbFlows.Enabled = false;

            if (cbSolutions.SelectedIndex == -1) { return; }

            var selectedSolution = (Solution)cbSolutions.SelectedItem;

            if (selectedSolution.Id != Guid.Empty && selectedSolution.FlowIds == null)
            {
                // Lazy-load solution components
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Getting solution flows...",
                    Work = (worker, args) =>
                    {
                        var flowIds = dataverseClient.GetSolutionComponents(selectedSolution.Id);
                        args.Result = flowIds;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            ShowErrorDialog(args.Error);
                            return;
                        }

                        selectedSolution.FlowIds = args.Result as List<Guid>;
                        FilterFlows();
                    }
                });
            }
            else
            {
                FilterFlows();
            }
        }

        #endregion

        #region Load & Filter Flows

        private void LoadFlows()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting flows...",
                Work = (worker, args) =>
                {
                    var entities = dataverseClient.GetFlows();
                    var fetchedFlows = new List<Flow>();

                    foreach (var f in entities)
                    {
                        var flowId = ((Guid)f["workflowidunique"]).ToString("D");
                        var flowName = (string)f["name"];
                        var flowStatus = (FlowStatus)((OptionSetValue)f["statecode"]).Value;
                        var clientDataJson = (string)f["clientdata"];
                        var isManaged = (bool)f["ismanaged"];

                        var clientData = JsonConvert.DeserializeObject<FlowClientData>(clientDataJson);
                        var triggerType = clientData?.properties?.definition?.triggers?.FirstOrDefault().Value?.type ?? "Unknown";

                        var flow = new Flow
                        {
                            Id = flowId,
                            Name = flowName,
                            ClientData = clientData,
                            Status = flowStatus,
                            TriggerType = triggerType,
                            IsManaged = isManaged,
                            WorkflowId = f.Id
                        };

                        fetchedFlows.Add(flow);
                    }

                    args.Result = fetchedFlows.OrderBy(f => f.Name).ToList();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                        return;
                    }

                    if (!(args.Result is List<Flow> flows)) { return; }

                    Flows = flows;
                    FilterFlows();
                }
            });
        }

        private void FilterFlows()
        {
            var searchText = tbSearch.Text.ToLower();
            var showActivated = cbxFlowStatusActivated.Checked;
            var showDraft = cbxFlowStatusDraft.Checked;

            var selectedSolution = cbSolutions.SelectedItem as Solution;

            var filteredFlows = Flows
                .Where(f =>
                    (f.Status == FlowStatus.Activated && showActivated)
                    || (f.Status == FlowStatus.Draft && showDraft))
                .Where(f =>
                    string.IsNullOrWhiteSpace(searchText) ||
                    f.Name.ToLowerInvariant().Contains(searchText.ToLowerInvariant()))
                .ToList();

            if (selectedSolution != null && selectedSolution.Id != Guid.Empty && selectedSolution.FlowIds != null)
            {
                filteredFlows = filteredFlows
                    .Where(f => selectedSolution.FlowIds.Contains(f.WorkflowId))
                    .ToList();
            }

            gbFlows.Text = $"Flows ({filteredFlows.Count})";

            clbFlows.DataSource = filteredFlows;

            clbFlows.ItemCheck -= clbFlows_ItemCheck;

            for (var i = 0; i < clbFlows.Items.Count; i++)
            {
                var flow = (Flow)clbFlows.Items[i];
                clbFlows.SetItemChecked(i, flow.IsSelected);
            }

            clbFlows.ItemCheck += clbFlows_ItemCheck;

            gbFlows.Enabled = true;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            FilterFlows();
        }

        private void cbxFlowStatusActivated_CheckedChanged(object sender, EventArgs e)
        {
            FilterFlows();
        }

        private void cbxFlowStatusDraft_CheckedChanged(object sender, EventArgs e)
        {
            FilterFlows();
        }

        private void clbFlows_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedFlow = (Flow)clbFlows.Items[e.Index];
            selectedFlow.IsSelected = e.NewValue == CheckState.Checked;
        }

        private void cbSelectAllFlows_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = cbSelectAllFlows.Checked;

            clbFlows.ItemCheck -= clbFlows_ItemCheck;

            for (var i = 0; i < clbFlows.Items.Count; i++)
            {
                var flow = (Flow)clbFlows.Items[i];
                clbFlows.SetItemChecked(i, isChecked);
                flow.IsSelected = isChecked;
            }

            clbFlows.ItemCheck += clbFlows_ItemCheck;
        }

        #endregion

        #region Get Flow Runs

        private void btnGetRuns_Click(object sender, EventArgs e)
        {
            GetFlowRuns();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            GetFlowRuns();
        }

        private void GetFlowRuns()
        {
            var selectedFlows = Flows.Where(f => f.IsSelected).ToList();

            if (!selectedFlows.Any())
            {
                dgvFlowRuns.DataSource = null;
                gbFlowRuns.Text = "Flow Runs";
                MessageBox.Show("Please select at least one flow.", "No Flows Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dateFrom = (DateTimeOffset)dtpDateFrom.Value;
            var dateTo = (DateTimeOffset)dtpDateTo.Value;
            var status = cbxStatus.Text;

            gbFlows.Enabled = false;
            gbRunFilters.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting flow runs...",
                Work = (worker, args) =>
                {
                    _flowAccessToken = _flowAccessToken ?? ConnectionDetail.GetPowerAutomateAccessToken(Geo);

                    flowClient = flowClient ?? new FlowClient(
                        ConnectionDetail.EnvironmentId,
                        _flowAccessToken.access_token,
                        Geo);

                    var allRuns = new List<FlowRun>();

                    foreach (var f in selectedFlows)
                    {
                        var runs = flowClient.GetFlowRuns(f, status, dateFrom, dateTo);
                        f.FlowRuns = runs;
                        allRuns.AddRange(runs);
                    }

                    args.Result = allRuns;
                },
                PostWorkCallBack = (args) =>
                {
                    gbFlows.Enabled = true;
                    gbRunFilters.Enabled = true;

                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error.InnerException ?? args.Error);
                        return;
                    }

                    if (!(args.Result is List<FlowRun> runs)) { return; }

                    FlowRuns = runs;

                    // Sort by start date descending and store
                    _sortedFlowRuns = runs.OrderByDescending(r => r.StartDate).ToList();
                    _currentPage = 1;

                    // Show flow column only if multiple flows selected
                    dgvFlowRuns.Columns["FlowRunFlow"].Visible = selectedFlows.Count > 1;

                    gbFlowRuns.Text = $"Flow Runs ({runs.Count})";
                    RefreshGrid();
                }
            });
        }

        #endregion

        #region Pagination

        private void RefreshGrid()
        {
            if (_sortedFlowRuns == null) return;

            var totalRows = _sortedFlowRuns.Count;
            var totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRows / _pageSize));

            // Clamp current page
            if (_currentPage < 1) _currentPage = 1;
            if (_currentPage > totalPages) _currentPage = totalPages;

            var pageRows = _sortedFlowRuns
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            dgvFlowRuns.DataSource = new BindingList<FlowRun>(pageRows);

            UpdatePaginationControls(totalRows, totalPages);
        }

        private void UpdatePaginationControls(int totalRows, int totalPages)
        {
            lblPageInfo.Text = $"Page {_currentPage} of {totalPages}  ({totalRows} total)";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < totalPages;
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                RefreshGrid();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            var totalPages = Math.Max(1, (int)Math.Ceiling((double)_sortedFlowRuns.Count / _pageSize));
            if (_currentPage < totalPages)
            {
                _currentPage++;
                RefreshGrid();
            }
        }

        private void cbxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbxPageSize.SelectedItem?.ToString(), out var newSize))
            {
                _pageSize = newSize;
                _currentPage = 1;
                RefreshGrid();
            }
        }

        #endregion

        #region DataGridView Events

        private void dgvFlowRuns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var flowRun = dgvFlowRuns.Rows[e.RowIndex].DataBoundItem as FlowRun;
            if (flowRun == null) return;

            var columnName = dgvFlowRuns.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "FlowRunStatus":
                    switch (flowRun.Status)
                    {
                        case "Succeeded":
                            e.CellStyle.BackColor = Color.FromArgb(40, 167, 69);
                            e.CellStyle.ForeColor = Color.White;
                            break;
                        case "Failed":
                            e.CellStyle.BackColor = Color.FromArgb(220, 53, 69);
                            e.CellStyle.ForeColor = Color.White;
                            break;
                        case "Cancelled":
                            e.CellStyle.BackColor = Color.FromArgb(255, 193, 7);
                            e.CellStyle.ForeColor = Color.Black;
                            break;
                        case "Running":
                            e.CellStyle.BackColor = Color.FromArgb(0, 123, 255);
                            e.CellStyle.ForeColor = Color.White;
                            break;
                    }
                    break;

                case "FlowRunFlow":
                    e.Value = flowRun.Flow?.Name ?? string.Empty;
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void dgvFlowRuns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            var columnName = dgvFlowRuns.Columns[e.ColumnIndex].Name;

            if (columnName == "FlowRunUrl")
            {
                var flowRun = (FlowRun)dgvFlowRuns.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(flowRun.Url))
                {
                    try
                    {
                        Process.Start(flowRun.Url);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not open URL: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Export

        private void tsbExportCsv_Click(object sender, EventArgs e)
        {
            if (FlowRuns == null || !FlowRuns.Any())
            {
                MessageBox.Show("There are no flow runs to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = $"FlowRuns_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    WorkAsync(new WorkAsyncInfo
                    {
                        Message = "Exporting to CSV...",
                        Work = (worker, args) =>
                        {
                            var sb = new System.Text.StringBuilder();
                            sb.AppendLine("Flow Name,Run ID,Status,Start Date,End Date,Duration,Correlation ID,Error Details,Run URL");

                            foreach (var run in FlowRuns)
                            {
                                var flowName = EscapeCsv(run.Flow?.Name);
                                var runId = EscapeCsv(run.Id);
                                var status = EscapeCsv(run.Status);
                                var startDate = EscapeCsv(run.StartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                                var endDate = EscapeCsv(run.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                                var duration = EscapeCsv(run.FormattedDuration);
                                var corrId = EscapeCsv(run.CorrelationId);
                                var error = EscapeCsv(run.ErrorDetails);
                                var url = EscapeCsv(run.Url);

                                sb.AppendLine($"{flowName},{runId},{status},{startDate},{endDate},{duration},{corrId},{error},{url}");
                            }

                            System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                        },
                        PostWorkCallBack = (args) =>
                        {
                            if (args.Error != null)
                            {
                                ShowErrorDialog(args.Error);
                            }
                            else
                            {
                                MessageBox.Show("Successfully exported flow runs.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    });
                }
            }
        }

        private string EscapeCsv(string field)
        {
            if (string.IsNullOrEmpty(field))
                return "";

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }

            return field;
        }

        #endregion

        #region Cancel Run
        
        private void CancelItem_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvFlowRuns.SelectedRows;
            if (selectedRows.Count == 0) return;

            var runsToCancel = new List<FlowRun>();
            foreach (DataGridViewRow row in selectedRows)
            {
                var run = row.DataBoundItem as FlowRun;
                if (run != null && run.Status == Enums.FlowRunStatus.Running)
                {
                    runsToCancel.Add(run);
                }
            }

            if (runsToCancel.Count == 0)
            {
                MessageBox.Show("No running flows selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to cancel {runsToCancel.Count} running flow(s)?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Canceling flow runs...",
                Work = (worker, args) =>
                {
                    var successCount = 0;
                    var failCount = 0;
                    foreach (var run in runsToCancel)
                    {
                        try
                        {
                            var success = flowClient.CancelFlowRun(run);
                            if (success) successCount++;
                            else failCount++;
                        }
                        catch
                        {
                            failCount++;
                        }
                    }
                    args.Result = new { Success = successCount, Fail = failCount };
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    else
                    {
                        dynamic res = args.Result;
                        MessageBox.Show($"Canceled: {res.Success}, Failed to cancel: {res.Fail}.", "Cancel Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetFlowRuns();
                    }
                }
            });
        }

        #endregion

        #region Close & Save

        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        #endregion
    }
}
