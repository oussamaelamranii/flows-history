namespace MyXrmToolBoxTool1
{
    partial class RunDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblRunId = new System.Windows.Forms.Label();
            this.lblFlowName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTrigger = new System.Windows.Forms.TabPage();
            this.rtbTrigger = new System.Windows.Forms.RichTextBox();
            this.tabSteps = new System.Windows.Forms.TabPage();
            this.splitSteps = new System.Windows.Forms.SplitContainer();
            this.dgvActions = new System.Windows.Forms.DataGridView();
            this.colActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlIo = new System.Windows.Forms.Panel();
            this.splitIo = new System.Windows.Forms.SplitContainer();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.lblInputs = new System.Windows.Forms.Label();
            this.rtbInputs = new System.Windows.Forms.RichTextBox();
            this.pnlOutputs = new System.Windows.Forms.Panel();
            this.lblOutputs = new System.Windows.Forms.Label();
            this.rtbOutputs = new System.Windows.Forms.RichTextBox();
            this.tabError = new System.Windows.Forms.TabPage();
            this.pnlError = new System.Windows.Forms.Panel();
            this.lblErrorCode = new System.Windows.Forms.Label();
            this.lblErrorCodeVal = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.rtbErrorMessage = new System.Windows.Forms.RichTextBox();
            this.lblErrorDetails = new System.Windows.Forms.Label();
            this.rtbErrorDetails = new System.Windows.Forms.RichTextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabTrigger.SuspendLayout();
            this.tabSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSteps)).BeginInit();
            this.splitSteps.Panel1.SuspendLayout();
            this.splitSteps.Panel2.SuspendLayout();
            this.splitSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
            this.pnlIo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitIo)).BeginInit();
            this.splitIo.Panel1.SuspendLayout();
            this.splitIo.Panel2.SuspendLayout();
            this.splitIo.SuspendLayout();
            this.pnlInputs.SuspendLayout();
            this.pnlOutputs.SuspendLayout();
            this.tabError.SuspendLayout();
            this.pnlError.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblRunId);
            this.pnlHeader.Controls.Add(this.lblFlowName);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.lblDuration);
            this.pnlHeader.Controls.Add(this.lblStartDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);

            // lblFlowName
            this.lblFlowName.AutoSize = false;
            this.lblFlowName.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblFlowName.ForeColor = System.Drawing.Color.White;
            this.lblFlowName.Location = new System.Drawing.Point(16, 10);
            this.lblFlowName.Size = new System.Drawing.Size(700, 28);
            this.lblFlowName.Name = "lblFlowName";
            this.lblFlowName.Text = "Flow Name";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(16, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "● Status";

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDuration.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDuration.Location = new System.Drawing.Point(16, 63);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Text = "Duration: —";

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblStartDate.Location = new System.Drawing.Point(200, 63);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Text = "Started: —";

            // lblRunId
            this.lblRunId.AutoSize = true;
            this.lblRunId.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.lblRunId.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRunId.Location = new System.Drawing.Point(400, 63);
            this.lblRunId.Name = "lblRunId";
            this.lblRunId.Text = "Run ID: —";

            // tabControl
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Controls.Add(this.tabTrigger);
            this.tabControl.Controls.Add(this.tabSteps);
            this.tabControl.Controls.Add(this.tabError);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;

            // tabTrigger
            this.tabTrigger.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.tabTrigger.Controls.Add(this.rtbTrigger);
            this.tabTrigger.Name = "tabTrigger";
            this.tabTrigger.Padding = new System.Windows.Forms.Padding(6);
            this.tabTrigger.Text = "⚡ Trigger";

            // rtbTrigger
            this.rtbTrigger.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.rtbTrigger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTrigger.Font = new System.Drawing.Font("Consolas", 10f);
            this.rtbTrigger.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rtbTrigger.Name = "rtbTrigger";
            this.rtbTrigger.ReadOnly = true;
            this.rtbTrigger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbTrigger.WordWrap = false;

            // tabSteps
            this.tabSteps.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.tabSteps.Controls.Add(this.splitSteps);
            this.tabSteps.Name = "tabSteps";
            this.tabSteps.Padding = new System.Windows.Forms.Padding(4);
            this.tabSteps.Text = "📋 Steps";

            // splitSteps
            this.splitSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSteps.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitSteps.SplitterDistance = 220;
            this.splitSteps.Name = "splitSteps";
            this.splitSteps.Panel1.Controls.Add(this.dgvActions);
            this.splitSteps.Panel2.Controls.Add(this.pnlIo);

            // dgvActions
            this.dgvActions.AllowUserToAddRows = false;
            this.dgvActions.AllowUserToDeleteRows = false;
            this.dgvActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colActionName, this.colActionStatus, this.colActionStart, this.colActionDuration });
            this.dgvActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActions.Name = "dgvActions";
            this.dgvActions.ReadOnly = true;
            this.dgvActions.RowHeadersVisible = false;
            this.dgvActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActions.MultiSelect = false;

            // colActionName
            this.colActionName.DataPropertyName = "Name";
            this.colActionName.FillWeight = 200f;
            this.colActionName.HeaderText = "Action";
            this.colActionName.Name = "colActionName";
            this.colActionName.ReadOnly = true;

            // colActionStatus
            this.colActionStatus.DataPropertyName = "Status";
            this.colActionStatus.FillWeight = 70f;
            this.colActionStatus.HeaderText = "Status";
            this.colActionStatus.Name = "colActionStatus";
            this.colActionStatus.ReadOnly = true;

            // colActionStart
            this.colActionStart.DataPropertyName = "StartTime";
            this.colActionStart.FillWeight = 110f;
            this.colActionStart.HeaderText = "Start Time";
            this.colActionStart.Name = "colActionStart";
            this.colActionStart.ReadOnly = true;

            // colActionDuration
            this.colActionDuration.DataPropertyName = "FormattedDuration";
            this.colActionDuration.FillWeight = 70f;
            this.colActionDuration.HeaderText = "Duration";
            this.colActionDuration.Name = "colActionDuration";
            this.colActionDuration.ReadOnly = true;

            // pnlIo
            this.pnlIo.Controls.Add(this.splitIo);
            this.pnlIo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIo.Name = "pnlIo";

            // splitIo
            this.splitIo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitIo.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitIo.Name = "splitIo";
            this.splitIo.Panel1.Controls.Add(this.pnlInputs);
            this.splitIo.Panel2.Controls.Add(this.pnlOutputs);

            // pnlInputs
            this.pnlInputs.Controls.Add(this.rtbInputs);
            this.pnlInputs.Controls.Add(this.lblInputs);
            this.pnlInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputs.Name = "pnlInputs";

            // lblInputs
            this.lblInputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInputs.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblInputs.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblInputs.Height = 22;
            this.lblInputs.Name = "lblInputs";
            this.lblInputs.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.lblInputs.Text = "INPUTS";

            // rtbInputs
            this.rtbInputs.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.rtbInputs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInputs.Font = new System.Drawing.Font("Consolas", 9.5f);
            this.rtbInputs.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rtbInputs.Name = "rtbInputs";
            this.rtbInputs.ReadOnly = true;
            this.rtbInputs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbInputs.WordWrap = false;

            // pnlOutputs
            this.pnlOutputs.Controls.Add(this.rtbOutputs);
            this.pnlOutputs.Controls.Add(this.lblOutputs);
            this.pnlOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutputs.Name = "pnlOutputs";

            // lblOutputs
            this.lblOutputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOutputs.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblOutputs.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblOutputs.Height = 22;
            this.lblOutputs.Name = "lblOutputs";
            this.lblOutputs.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.lblOutputs.Text = "OUTPUTS";

            // rtbOutputs
            this.rtbOutputs.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.rtbOutputs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutputs.Font = new System.Drawing.Font("Consolas", 9.5f);
            this.rtbOutputs.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rtbOutputs.Name = "rtbOutputs";
            this.rtbOutputs.ReadOnly = true;
            this.rtbOutputs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbOutputs.WordWrap = false;

            // tabError
            this.tabError.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.tabError.Controls.Add(this.pnlError);
            this.tabError.Name = "tabError";
            this.tabError.Padding = new System.Windows.Forms.Padding(10);
            this.tabError.Text = "❌ Error";

            // pnlError
            this.pnlError.Controls.Add(this.rtbErrorDetails);
            this.pnlError.Controls.Add(this.lblErrorDetails);
            this.pnlError.Controls.Add(this.rtbErrorMessage);
            this.pnlError.Controls.Add(this.lblErrorMessage);
            this.pnlError.Controls.Add(this.lblErrorCodeVal);
            this.pnlError.Controls.Add(this.lblErrorCode);
            this.pnlError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlError.Name = "pnlError";
            this.pnlError.Padding = new System.Windows.Forms.Padding(10);

            // lblErrorCode
            this.lblErrorCode.AutoSize = true;
            this.lblErrorCode.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblErrorCode.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblErrorCode.Location = new System.Drawing.Point(10, 10);
            this.lblErrorCode.Name = "lblErrorCode";
            this.lblErrorCode.Text = "ERROR CODE";

            // lblErrorCodeVal
            this.lblErrorCodeVal.AutoSize = true;
            this.lblErrorCodeVal.Font = new System.Drawing.Font("Consolas", 10f, System.Drawing.FontStyle.Bold);
            this.lblErrorCodeVal.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblErrorCodeVal.Location = new System.Drawing.Point(10, 30);
            this.lblErrorCodeVal.Name = "lblErrorCodeVal";
            this.lblErrorCodeVal.Text = "—";

            // lblErrorMessage
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblErrorMessage.Location = new System.Drawing.Point(10, 60);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Text = "MESSAGE";

            // rtbErrorMessage
            this.rtbErrorMessage.BackColor = System.Drawing.Color.FromArgb(255, 243, 243);
            this.rtbErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbErrorMessage.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.rtbErrorMessage.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.rtbErrorMessage.Location = new System.Drawing.Point(10, 80);
            this.rtbErrorMessage.Name = "rtbErrorMessage";
            this.rtbErrorMessage.ReadOnly = true;
            this.rtbErrorMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbErrorMessage.Size = new System.Drawing.Size(860, 60);
            this.rtbErrorMessage.WordWrap = true;

            // lblErrorDetails
            this.lblErrorDetails.AutoSize = true;
            this.lblErrorDetails.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblErrorDetails.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblErrorDetails.Location = new System.Drawing.Point(10, 155);
            this.lblErrorDetails.Name = "lblErrorDetails";
            this.lblErrorDetails.Text = "FULL DETAILS / STACK TRACE";

            // rtbErrorDetails
            this.rtbErrorDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.rtbErrorDetails.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.rtbErrorDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbErrorDetails.Font = new System.Drawing.Font("Consolas", 9.5f);
            this.rtbErrorDetails.ForeColor = System.Drawing.Color.FromArgb(252, 165, 165);
            this.rtbErrorDetails.Location = new System.Drawing.Point(10, 175);
            this.rtbErrorDetails.Name = "rtbErrorDetails";
            this.rtbErrorDetails.ReadOnly = true;
            this.rtbErrorDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbErrorDetails.Size = new System.Drawing.Size(860, 280);
            this.rtbErrorDetails.WordWrap = false;

            // pnlBottom
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 46;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 7, 12, 7);

            // btnClose
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(838, 7);
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "Close";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // RunDetailsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "RunDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run Details";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabTrigger.ResumeLayout(false);
            this.tabSteps.ResumeLayout(false);
            this.splitSteps.Panel1.ResumeLayout(false);
            this.splitSteps.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSteps)).EndInit();
            this.splitSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
            this.pnlIo.ResumeLayout(false);
            this.splitIo.Panel1.ResumeLayout(false);
            this.splitIo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitIo)).EndInit();
            this.splitIo.ResumeLayout(false);
            this.pnlInputs.ResumeLayout(false);
            this.pnlOutputs.ResumeLayout(false);
            this.tabError.ResumeLayout(false);
            this.pnlError.ResumeLayout(false);
            this.pnlError.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFlowName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblRunId;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTrigger;
        private System.Windows.Forms.RichTextBox rtbTrigger;

        private System.Windows.Forms.TabPage tabSteps;
        private System.Windows.Forms.SplitContainer splitSteps;
        private System.Windows.Forms.DataGridView dgvActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionDuration;
        private System.Windows.Forms.Panel pnlIo;
        private System.Windows.Forms.SplitContainer splitIo;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblInputs;
        private System.Windows.Forms.RichTextBox rtbInputs;
        private System.Windows.Forms.Panel pnlOutputs;
        private System.Windows.Forms.Label lblOutputs;
        private System.Windows.Forms.RichTextBox rtbOutputs;

        private System.Windows.Forms.TabPage tabError;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Label lblErrorCode;
        private System.Windows.Forms.Label lblErrorCodeVal;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.RichTextBox rtbErrorMessage;
        private System.Windows.Forms.Label lblErrorDetails;
        private System.Windows.Forms.RichTextBox rtbErrorDetails;

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnClose;
    }
}
