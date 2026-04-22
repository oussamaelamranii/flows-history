using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyXrmToolBoxTool1.Models;

namespace MyXrmToolBoxTool1
{
    public partial class RunDetailsForm : Form
    {
        private readonly FlowRun _run;

        // JSON syntax colors (dark theme)
        private static readonly Color ColorKey     = Color.FromArgb(147, 197, 253); // blue
        private static readonly Color ColorString  = Color.FromArgb(134, 239, 172); // green
        private static readonly Color ColorNumber  = Color.FromArgb(251, 191, 36);  // amber
        private static readonly Color ColorBool    = Color.FromArgb(196, 181, 253); // purple
        private static readonly Color ColorNull    = Color.FromArgb(148, 163, 184); // slate
        private static readonly Color ColorDefault = Color.FromArgb(226, 232, 240); // light

        public RunDetailsForm(FlowRun run)
        {
            _run = run ?? throw new ArgumentNullException(nameof(run));
            InitializeComponent();
            PopulateHeader();
            PopulateTriggerTab();
            PopulateStepsTab();
            PopulateErrorTab();
            StyleGrid();
        }

        #region Header

        private void PopulateHeader()
        {
            lblFlowName.Text = _run.Flow?.Name ?? "Unknown Flow";
            lblRunId.Text    = $"Run ID: {_run.Id}";
            lblDuration.Text = $"⏱  {_run.FormattedDuration}";
            lblStartDate.Text = $"🕐  {_run.StartDate:yyyy-MM-dd HH:mm:ss}";

            // Status pill
            string statusText;
            Color statusColor;
            switch (_run.Status)
            {
                case "Succeeded":
                    statusText  = "✔  Succeeded";
                    statusColor = Color.FromArgb(34, 197, 94);
                    break;
                case "Failed":
                    statusText  = "✖  Failed";
                    statusColor = Color.FromArgb(239, 68, 68);
                    break;
                case "Cancelled":
                    statusText  = "⊘  Cancelled";
                    statusColor = Color.FromArgb(234, 179, 8);
                    break;
                case "Running":
                    statusText  = "↻  Running";
                    statusColor = Color.FromArgb(59, 130, 246);
                    break;
                default:
                    statusText  = _run.Status;
                    statusColor = Color.FromArgb(148, 163, 184);
                    break;
            }
            lblStatus.Text      = statusText;
            lblStatus.ForeColor = statusColor;

            // Switch to Error tab automatically for failed runs
            if (_run.Status == "Failed")
            {
                tabControl.SelectedTab = tabError;
                // Mark the tab with red text
                tabError.Text = "❌ Error  ◄";
            }
        }

        #endregion

        #region Trigger Tab

        private void PopulateTriggerTab()
        {
            var json = _run.TriggerInputsJson;
            if (string.IsNullOrWhiteSpace(json))
            {
                rtbTrigger.ForeColor = Color.FromArgb(100, 116, 139);
                rtbTrigger.Text = "(No trigger input data available — trigger may not expose outputs, or the run is still active.)";
                return;
            }
            ApplyJsonHighlighting(rtbTrigger, json);
        }

        #endregion

        #region Steps Tab

        private void PopulateStepsTab()
        {
            var actions = _run.Actions;
            if (actions == null || actions.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "(No action data available)",
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 9.5f),
                    ForeColor = Color.FromArgb(100, 116, 139),
                    Padding = new Padding(10)
                };
                splitSteps.Panel1.Controls.Add(lbl);
                return;
            }

            dgvActions.DataSource = new BindingSource(actions, null);
            dgvActions.SelectionChanged += DgvActions_SelectionChanged;

            // Select first row to populate I/O panels
            if (dgvActions.Rows.Count > 0)
                dgvActions.Rows[0].Selected = true;
        }

        private void DgvActions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActions.SelectedRows.Count == 0) return;

            var action = dgvActions.SelectedRows[0].DataBoundItem as FlowRunAction;
            if (action == null) return;

            // Inputs
            rtbInputs.Clear();
            if (!string.IsNullOrWhiteSpace(action.InputsJson))
                ApplyJsonHighlighting(rtbInputs, action.InputsJson);
            else
            {
                rtbInputs.ForeColor = Color.FromArgb(100, 116, 139);
                rtbInputs.Text = "(No inputs)";
            }

            // Outputs
            rtbOutputs.Clear();
            if (!string.IsNullOrWhiteSpace(action.OutputsJson))
                ApplyJsonHighlighting(rtbOutputs, action.OutputsJson);
            else
            {
                rtbOutputs.ForeColor = Color.FromArgb(100, 116, 139);
                rtbOutputs.Text = "(No outputs)";
            }
        }

        private void StyleGrid()
        {
            // Actions grid styling (dark code-editor feel)
            dgvActions.BackgroundColor            = Color.FromArgb(15, 23, 42);
            dgvActions.GridColor                  = Color.FromArgb(30, 41, 59);
            dgvActions.BorderStyle                = BorderStyle.None;
            dgvActions.CellBorderStyle            = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvActions.ColumnHeadersBorderStyle   = DataGridViewHeaderBorderStyle.None;

            dgvActions.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(30, 41, 59);
            dgvActions.ColumnHeadersDefaultCellStyle.ForeColor  = Color.FromArgb(148, 163, 184);
            dgvActions.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvActions.EnableHeadersVisualStyles = false;

            dgvActions.RowsDefaultCellStyle.BackColor          = Color.FromArgb(15, 23, 42);
            dgvActions.RowsDefaultCellStyle.ForeColor          = Color.FromArgb(226, 232, 240);
            dgvActions.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvActions.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvActions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 48);

            dgvActions.CellFormatting += DgvActions_CellFormatting;

            // IO label backgrounds
            pnlInputs.BackColor  = Color.FromArgb(20, 30, 48);
            pnlOutputs.BackColor = Color.FromArgb(20, 30, 48);
            lblInputs.BackColor  = Color.FromArgb(30, 41, 59);
            lblOutputs.BackColor = Color.FromArgb(30, 41, 59);
            lblInputs.ForeColor  = Color.FromArgb(148, 163, 184);
            lblOutputs.ForeColor = Color.FromArgb(148, 163, 184);

            // Tab control background
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.Padding   = new Point(12, 6);
        }

        private void DgvActions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var action = dgvActions.Rows[e.RowIndex].DataBoundItem as FlowRunAction;
            if (action == null) return;

            if (dgvActions.Columns[e.ColumnIndex].Name == "colActionStatus")
            {
                switch (action.Status)
                {
                    case "Succeeded":
                        e.CellStyle.ForeColor = Color.FromArgb(34, 197, 94);
                        break;
                    case "Failed":
                        e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68);
                        break;
                    case "Skipped":
                        e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184);
                        break;
                    case "Running":
                        e.CellStyle.ForeColor = Color.FromArgb(59, 130, 246);
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.FromArgb(234, 179, 8);
                        break;
                }
                e.FormattingApplied = true;
            }
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tab = tabControl.TabPages[e.Index];
            var bounds = tabControl.GetTabRect(e.Index);

            bool selected = e.Index == tabControl.SelectedIndex;
            var bgColor = selected ? Color.FromArgb(30, 41, 59) : Color.FromArgb(15, 23, 42);
            var fgColor = selected ? Color.White : Color.FromArgb(148, 163, 184);

            e.Graphics.FillRectangle(new SolidBrush(bgColor), bounds);

            TextRenderer.DrawText(e.Graphics, tab.Text, new Font("Segoe UI", 9.5f, selected ? FontStyle.Bold : FontStyle.Regular),
                bounds, fgColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        #endregion

        #region Error Tab

        private void PopulateErrorTab()
        {
            var hasError = _run.Error != null ||
                           !string.IsNullOrWhiteSpace(_run.ErrorDetails);

            if (!hasError)
            {
                lblErrorCodeVal.Text = "No error recorded for this run.";
                lblErrorCodeVal.ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }

            lblErrorCodeVal.Text = _run.Error?.Message ?? "—";

            rtbErrorMessage.Text = _run.Error?.Message ?? string.Empty;

            var details = _run.ErrorDetails ?? string.Empty;
            rtbErrorDetails.Text = details;
        }

        #endregion

        #region JSON Syntax Highlighting

        private static void ApplyJsonHighlighting(RichTextBox rtb, string json)
        {
            rtb.SuspendLayout();
            rtb.Clear();

            // Token pattern for JSON highlighting
            var tokenPattern = new Regex(
                @"(""(?:[^""\\]|\\.)*"")\s*:        # key
                | (""(?:[^""\\]|\\.)*"")            # string value
                | \b(true|false)\b                  # bool
                | \b(null)\b                        # null
                | (-?\d+(?:\.\d+)?(?:[eE][+-]?\d+)?) # number
                ",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

            int lastIndex = 0;

            foreach (Match m in tokenPattern.Matches(json))
            {
                // Append unmatched text before this token in default color
                if (m.Index > lastIndex)
                    AppendText(rtb, json.Substring(lastIndex, m.Index - lastIndex), ColorDefault);

                if (m.Groups[1].Success)      // key
                    AppendText(rtb, m.Value, ColorKey);
                else if (m.Groups[2].Success) // string value
                    AppendText(rtb, m.Value, ColorString);
                else if (m.Groups[3].Success) // bool
                    AppendText(rtb, m.Value, ColorBool);
                else if (m.Groups[4].Success) // null
                    AppendText(rtb, m.Value, ColorNull);
                else if (m.Groups[5].Success) // number
                    AppendText(rtb, m.Value, ColorNumber);
                else
                    AppendText(rtb, m.Value, ColorDefault);

                lastIndex = m.Index + m.Length;
            }

            // Append remaining text
            if (lastIndex < json.Length)
                AppendText(rtb, json.Substring(lastIndex), ColorDefault);

            rtb.ResumeLayout();
            rtb.SelectionStart = 0;
            rtb.ScrollToCaret();
        }

        private static void AppendText(RichTextBox rtb, string text, Color color)
        {
            rtb.SelectionStart  = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor  = color;
            rtb.AppendText(text);
            rtb.SelectionColor  = rtb.ForeColor;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
