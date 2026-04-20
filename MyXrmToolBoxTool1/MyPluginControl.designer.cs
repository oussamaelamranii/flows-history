namespace MyXrmToolBoxTool1
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConnectFlowApi = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();

            this.splitContainerMain = new System.Windows.Forms.SplitContainer();

            // Left panel controls
            this.gbSolution = new System.Windows.Forms.GroupBox();
            this.cbSolutions = new System.Windows.Forms.ComboBox();

            this.gbFlowFilters = new System.Windows.Forms.GroupBox();
            this.cbxFlowStatusActivated = new System.Windows.Forms.CheckBox();
            this.cbxFlowStatusDraft = new System.Windows.Forms.CheckBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();

            this.gbFlows = new System.Windows.Forms.GroupBox();
            this.clbFlows = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllFlows = new System.Windows.Forms.CheckBox();

            // Right panel controls
            this.gbRunFilters = new System.Windows.Forms.GroupBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.btnGetRuns = new System.Windows.Forms.Button();

            this.gbFlowRuns = new System.Windows.Forms.GroupBox();
            this.dgvFlowRuns = new System.Windows.Forms.DataGridView();

            // DataGridView columns
            this.FlowRunFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FlowRunError = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.gbSolution.SuspendLayout();
            this.gbFlowFilters.SuspendLayout();
            this.gbFlows.SuspendLayout();
            this.gbRunFilters.SuspendLayout();
            this.gbFlowRuns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlowRuns)).BeginInit();
            this.SuspendLayout();

            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsbClose,
                this.tssSeparator1,
                this.tsbConnectFlowApi,
                this.tssSeparator2,
                this.tsbRefresh});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1100, 31);
            this.toolStripMenu.TabIndex = 0;

            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);

            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);

            // 
            // tsbConnectFlowApi
            // 
            this.tsbConnectFlowApi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnectFlowApi.Name = "tsbConnectFlowApi";
            this.tsbConnectFlowApi.Size = new System.Drawing.Size(160, 28);
            this.tsbConnectFlowApi.Text = "Connect to Power Automate API";
            this.tsbConnectFlowApi.Click += new System.EventHandler(this.tsbConnectFlowApi_Click);

            // 
            // tssSeparator2
            // 
            this.tssSeparator2.Name = "tssSeparator2";
            this.tssSeparator2.Size = new System.Drawing.Size(6, 31);

            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(86, 28);
            this.tsbRefresh.Text = "Refresh Runs";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);

            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 31);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Size = new System.Drawing.Size(1100, 569);
            this.splitContainerMain.SplitterDistance = 300;
            this.splitContainerMain.TabIndex = 1;

            // 
            // splitContainerMain.Panel1 (Left - Solutions & Flows)
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gbFlows);
            this.splitContainerMain.Panel1.Controls.Add(this.gbFlowFilters);
            this.splitContainerMain.Panel1.Controls.Add(this.gbSolution);

            // 
            // splitContainerMain.Panel2 (Right - Filters & Runs Grid)
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.gbFlowRuns);
            this.splitContainerMain.Panel2.Controls.Add(this.gbRunFilters);

            // =====================
            // LEFT PANEL CONTROLS
            // =====================

            // 
            // gbSolution
            // 
            this.gbSolution.Controls.Add(this.cbSolutions);
            this.gbSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSolution.Location = new System.Drawing.Point(0, 0);
            this.gbSolution.Name = "gbSolution";
            this.gbSolution.Padding = new System.Windows.Forms.Padding(8);
            this.gbSolution.Size = new System.Drawing.Size(300, 60);
            this.gbSolution.TabIndex = 0;
            this.gbSolution.TabStop = false;
            this.gbSolution.Text = "Solution";

            // 
            // cbSolutions
            // 
            this.cbSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSolutions.FormattingEnabled = true;
            this.cbSolutions.Location = new System.Drawing.Point(8, 24);
            this.cbSolutions.Name = "cbSolutions";
            this.cbSolutions.Size = new System.Drawing.Size(284, 28);
            this.cbSolutions.TabIndex = 0;
            this.cbSolutions.SelectedIndexChanged += new System.EventHandler(this.cbSolutions_SelectedIndexChanged);

            // 
            // gbFlowFilters
            // 
            this.gbFlowFilters.Controls.Add(this.tbSearch);
            this.gbFlowFilters.Controls.Add(this.lblSearch);
            this.gbFlowFilters.Controls.Add(this.cbxFlowStatusDraft);
            this.gbFlowFilters.Controls.Add(this.cbxFlowStatusActivated);
            this.gbFlowFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFlowFilters.Location = new System.Drawing.Point(0, 60);
            this.gbFlowFilters.Name = "gbFlowFilters";
            this.gbFlowFilters.Padding = new System.Windows.Forms.Padding(8);
            this.gbFlowFilters.Size = new System.Drawing.Size(300, 100);
            this.gbFlowFilters.TabIndex = 1;
            this.gbFlowFilters.TabStop = false;
            this.gbFlowFilters.Text = "Flow Filters";

            // 
            // cbxFlowStatusActivated
            // 
            this.cbxFlowStatusActivated.AutoSize = true;
            this.cbxFlowStatusActivated.Checked = true;
            this.cbxFlowStatusActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxFlowStatusActivated.Location = new System.Drawing.Point(12, 25);
            this.cbxFlowStatusActivated.Name = "cbxFlowStatusActivated";
            this.cbxFlowStatusActivated.Size = new System.Drawing.Size(90, 24);
            this.cbxFlowStatusActivated.TabIndex = 0;
            this.cbxFlowStatusActivated.Text = "Activated";
            this.cbxFlowStatusActivated.CheckedChanged += new System.EventHandler(this.cbxFlowStatusActivated_CheckedChanged);

            // 
            // cbxFlowStatusDraft
            // 
            this.cbxFlowStatusDraft.AutoSize = true;
            this.cbxFlowStatusDraft.Location = new System.Drawing.Point(110, 25);
            this.cbxFlowStatusDraft.Name = "cbxFlowStatusDraft";
            this.cbxFlowStatusDraft.Size = new System.Drawing.Size(65, 24);
            this.cbxFlowStatusDraft.TabIndex = 1;
            this.cbxFlowStatusDraft.Text = "Draft";
            this.cbxFlowStatusDraft.CheckedChanged += new System.EventHandler(this.cbxFlowStatusDraft_CheckedChanged);

            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 58);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 20);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";

            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(72, 55);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(216, 26);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);

            // 
            // gbFlows
            // 
            this.gbFlows.Controls.Add(this.clbFlows);
            this.gbFlows.Controls.Add(this.cbSelectAllFlows);
            this.gbFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFlows.Location = new System.Drawing.Point(0, 160);
            this.gbFlows.Name = "gbFlows";
            this.gbFlows.Padding = new System.Windows.Forms.Padding(8);
            this.gbFlows.Size = new System.Drawing.Size(300, 409);
            this.gbFlows.TabIndex = 2;
            this.gbFlows.TabStop = false;
            this.gbFlows.Text = "Flows";

            // 
            // cbSelectAllFlows
            // 
            this.cbSelectAllFlows.AutoSize = true;
            this.cbSelectAllFlows.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSelectAllFlows.Location = new System.Drawing.Point(8, 24);
            this.cbSelectAllFlows.Name = "cbSelectAllFlows";
            this.cbSelectAllFlows.Padding = new System.Windows.Forms.Padding(4, 2, 0, 4);
            this.cbSelectAllFlows.Size = new System.Drawing.Size(284, 30);
            this.cbSelectAllFlows.TabIndex = 0;
            this.cbSelectAllFlows.Text = "Select All";
            this.cbSelectAllFlows.CheckedChanged += new System.EventHandler(this.cbSelectAllFlows_CheckedChanged);

            // 
            // clbFlows
            // 
            this.clbFlows.CheckOnClick = true;
            this.clbFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbFlows.FormattingEnabled = true;
            this.clbFlows.Location = new System.Drawing.Point(8, 54);
            this.clbFlows.Name = "clbFlows";
            this.clbFlows.Size = new System.Drawing.Size(284, 347);
            this.clbFlows.TabIndex = 1;
            this.clbFlows.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFlows_ItemCheck);

            // =====================
            // RIGHT PANEL CONTROLS
            // =====================

            // 
            // gbRunFilters
            // 
            this.gbRunFilters.Controls.Add(this.btnGetRuns);
            this.gbRunFilters.Controls.Add(this.cbxStatus);
            this.gbRunFilters.Controls.Add(this.lblStatus);
            this.gbRunFilters.Controls.Add(this.dtpDateTo);
            this.gbRunFilters.Controls.Add(this.lblDateTo);
            this.gbRunFilters.Controls.Add(this.dtpDateFrom);
            this.gbRunFilters.Controls.Add(this.lblDateFrom);
            this.gbRunFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRunFilters.Location = new System.Drawing.Point(0, 0);
            this.gbRunFilters.Name = "gbRunFilters";
            this.gbRunFilters.Padding = new System.Windows.Forms.Padding(8);
            this.gbRunFilters.Size = new System.Drawing.Size(796, 70);
            this.gbRunFilters.TabIndex = 0;
            this.gbRunFilters.TabStop = false;
            this.gbRunFilters.Text = "Run Filters";

            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(12, 30);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(44, 20);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "From:";

            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(62, 27);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(180, 26);
            this.dtpDateFrom.TabIndex = 1;

            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(255, 30);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(27, 20);
            this.lblDateTo.TabIndex = 2;
            this.lblDateTo.Text = "To:";

            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(288, 27);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(180, 26);
            this.dtpDateTo.TabIndex = 3;

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(485, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";

            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
                "All",
                "Succeeded",
                "Failed",
                "Cancelled",
                "Running"});
            this.cbxStatus.Location = new System.Drawing.Point(543, 27);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(120, 28);
            this.cbxStatus.TabIndex = 5;

            // 
            // btnGetRuns
            // 
            this.btnGetRuns.Location = new System.Drawing.Point(680, 24);
            this.btnGetRuns.Name = "btnGetRuns";
            this.btnGetRuns.Size = new System.Drawing.Size(100, 32);
            this.btnGetRuns.TabIndex = 6;
            this.btnGetRuns.Text = "Get Runs";
            this.btnGetRuns.UseVisualStyleBackColor = true;
            this.btnGetRuns.Click += new System.EventHandler(this.btnGetRuns_Click);

            // 
            // gbFlowRuns
            // 
            this.gbFlowRuns.Controls.Add(this.dgvFlowRuns);
            this.gbFlowRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFlowRuns.Location = new System.Drawing.Point(0, 70);
            this.gbFlowRuns.Name = "gbFlowRuns";
            this.gbFlowRuns.Padding = new System.Windows.Forms.Padding(8);
            this.gbFlowRuns.Size = new System.Drawing.Size(796, 499);
            this.gbFlowRuns.TabIndex = 1;
            this.gbFlowRuns.TabStop = false;
            this.gbFlowRuns.Text = "Flow Runs";

            // 
            // dgvFlowRuns
            // 
            this.dgvFlowRuns.AllowUserToAddRows = false;
            this.dgvFlowRuns.AllowUserToDeleteRows = false;
            this.dgvFlowRuns.AllowUserToOrderColumns = true;
            this.dgvFlowRuns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlowRuns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlowRuns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.FlowRunFlow,
                this.FlowRunStatus,
                this.FlowRunStartDate,
                this.FlowRunEndDate,
                this.FlowRunDuration,
                this.FlowRunUrl,
                this.FlowRunError});
            this.dgvFlowRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlowRuns.Location = new System.Drawing.Point(8, 24);
            this.dgvFlowRuns.Name = "dgvFlowRuns";
            this.dgvFlowRuns.ReadOnly = true;
            this.dgvFlowRuns.RowHeadersVisible = false;
            this.dgvFlowRuns.RowHeadersWidth = 51;
            this.dgvFlowRuns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlowRuns.Size = new System.Drawing.Size(780, 467);
            this.dgvFlowRuns.TabIndex = 0;
            this.dgvFlowRuns.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlowRuns_CellFormatting);
            this.dgvFlowRuns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlowRuns_CellClick);

            // 
            // FlowRunFlow
            // 
            this.FlowRunFlow.DataPropertyName = "Flow";
            this.FlowRunFlow.HeaderText = "Flow";
            this.FlowRunFlow.Name = "FlowRunFlow";
            this.FlowRunFlow.ReadOnly = true;
            this.FlowRunFlow.FillWeight = 120;

            // 
            // FlowRunStatus
            // 
            this.FlowRunStatus.DataPropertyName = "Status";
            this.FlowRunStatus.HeaderText = "Status";
            this.FlowRunStatus.Name = "FlowRunStatus";
            this.FlowRunStatus.ReadOnly = true;
            this.FlowRunStatus.FillWeight = 60;

            // 
            // FlowRunStartDate
            // 
            this.FlowRunStartDate.DataPropertyName = "StartDate";
            this.FlowRunStartDate.HeaderText = "Start Date";
            this.FlowRunStartDate.Name = "FlowRunStartDate";
            this.FlowRunStartDate.ReadOnly = true;
            this.FlowRunStartDate.FillWeight = 100;

            // 
            // FlowRunEndDate
            // 
            this.FlowRunEndDate.DataPropertyName = "EndDate";
            this.FlowRunEndDate.HeaderText = "End Date";
            this.FlowRunEndDate.Name = "FlowRunEndDate";
            this.FlowRunEndDate.ReadOnly = true;
            this.FlowRunEndDate.FillWeight = 100;

            // 
            // FlowRunDuration
            // 
            this.FlowRunDuration.DataPropertyName = "FormattedDuration";
            this.FlowRunDuration.HeaderText = "Duration";
            this.FlowRunDuration.Name = "FlowRunDuration";
            this.FlowRunDuration.ReadOnly = true;
            this.FlowRunDuration.FillWeight = 70;

            // 
            // FlowRunUrl
            // 
            this.FlowRunUrl.DataPropertyName = "Url";
            this.FlowRunUrl.HeaderText = "Run URL";
            this.FlowRunUrl.Name = "FlowRunUrl";
            this.FlowRunUrl.ReadOnly = true;
            this.FlowRunUrl.FillWeight = 50;
            this.FlowRunUrl.Text = "Open";
            this.FlowRunUrl.UseColumnTextForLinkValue = true;

            // 
            // FlowRunError
            // 
            this.FlowRunError.DataPropertyName = "ErrorDetails";
            this.FlowRunError.HeaderText = "Error";
            this.FlowRunError.Name = "FlowRunError";
            this.FlowRunError.ReadOnly = true;
            this.FlowRunError.FillWeight = 100;

            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1100, 600);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.gbSolution.ResumeLayout(false);
            this.gbFlowFilters.ResumeLayout(false);
            this.gbFlowFilters.PerformLayout();
            this.gbFlows.ResumeLayout(false);
            this.gbFlows.PerformLayout();
            this.gbRunFilters.ResumeLayout(false);
            this.gbRunFilters.PerformLayout();
            this.gbFlowRuns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlowRuns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton tsbConnectFlowApi;
        private System.Windows.Forms.ToolStripSeparator tssSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRefresh;

        private System.Windows.Forms.SplitContainer splitContainerMain;

        // Left panel
        private System.Windows.Forms.GroupBox gbSolution;
        private System.Windows.Forms.ComboBox cbSolutions;

        private System.Windows.Forms.GroupBox gbFlowFilters;
        private System.Windows.Forms.CheckBox cbxFlowStatusActivated;
        private System.Windows.Forms.CheckBox cbxFlowStatusDraft;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;

        private System.Windows.Forms.GroupBox gbFlows;
        private System.Windows.Forms.CheckedListBox clbFlows;
        private System.Windows.Forms.CheckBox cbSelectAllFlows;

        // Right panel
        private System.Windows.Forms.GroupBox gbRunFilters;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Button btnGetRuns;

        private System.Windows.Forms.GroupBox gbFlowRuns;
        private System.Windows.Forms.DataGridView dgvFlowRuns;

        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunDuration;
        private System.Windows.Forms.DataGridViewLinkColumn FlowRunUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunError;
    }
}
