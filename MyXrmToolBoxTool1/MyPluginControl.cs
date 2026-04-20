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

            // Show connect button only if no client secret configured
            if (string.IsNullOrWhiteSpace(ConnectionDetail?.S2SClientSecret))
            {
                ShowInfoNotification(
                    "Connect to the Power Automate API using the toolbar button, or configure Client ID/Secret for automatic connection.",
                    new Uri("https://learn.microsoft.com/en-us/power-platform/admin/manage-application-users#create-an-application-user"));
            }
        }

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

                    // Insert "All Solutions" at the top
                    var allSolutions = new Solution
                    {
                        Id = Guid.Empty,
                        Name = "<All Solutions>"
                    };
                    solutions.Insert(0, allSolutions);

                    cbSolutions.Items.Clear();
                    cbSolutions.DataSource = solutions;
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

                    // Sort by start date descending
                    var sortedRuns = new BindingList<FlowRun>(
                        runs.OrderByDescending(r => r.StartDate).ToList());

                    dgvFlowRuns.DataSource = sortedRuns;

                    // Show flow column only if multiple flows selected
                    dgvFlowRuns.Columns["FlowRunFlow"].Visible = selectedFlows.Count > 1;

                    gbFlowRuns.Text = $"Flow Runs ({runs.Count})";
                }
            });
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

        #region Close & Save

        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        #endregion
    }
}