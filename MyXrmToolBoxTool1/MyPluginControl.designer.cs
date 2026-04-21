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
            this.tssSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportCsv = new System.Windows.Forms.ToolStripButton();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.gbFlows = new System.Windows.Forms.GroupBox();
            this.clbFlows = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllFlows = new System.Windows.Forms.CheckBox();
            this.gbFlowFilters = new System.Windows.Forms.GroupBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cbxFlowStatusDraft = new System.Windows.Forms.CheckBox();
            this.cbxFlowStatusActivated = new System.Windows.Forms.CheckBox();
            this.gbSolution = new System.Windows.Forms.GroupBox();
            this.cbSolutions = new System.Windows.Forms.ComboBox();
            this.gbFlowRuns = new System.Windows.Forms.GroupBox();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cbxPageSize = new System.Windows.Forms.ComboBox();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.dgvFlowRuns = new System.Windows.Forms.DataGridView();
            this.FlowRunFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowRunUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FlowRunError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRunFilters = new System.Windows.Forms.GroupBox();
            this.btnGetRuns = new System.Windows.Forms.Button();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.gbFlows.SuspendLayout();
            this.gbFlowFilters.SuspendLayout();
            this.gbSolution.SuspendLayout();
            this.gbFlowRuns.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlowRuns)).BeginInit();
            this.gbRunFilters.SuspendLayout();
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
            this.tsbRefresh,
            this.tssSeparator3,
            this.tsbExportCsv});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(978, 31);
            this.toolStripMenu.TabIndex = 0;
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(49, 28);
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
            this.tsbConnectFlowApi.Size = new System.Drawing.Size(225, 28);
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
            this.tsbRefresh.Size = new System.Drawing.Size(97, 28);
            this.tsbRefresh.Text = "Refresh Runs";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tssSeparator3
            // 
            this.tssSeparator3.Name = "tssSeparator3";
            this.tssSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbExportCsv
            // 
            this.tsbExportCsv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExportCsv.Name = "tsbExportCsv";
            this.tsbExportCsv.Size = new System.Drawing.Size(97, 28);
            this.tsbExportCsv.Text = "Export to CSV";
            this.tsbExportCsv.Click += new System.EventHandler(this.tsbExportCsv_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 31);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gbFlows);
            this.splitContainerMain.Panel1.Controls.Add(this.gbFlowFilters);
            this.splitContainerMain.Panel1.Controls.Add(this.gbSolution);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.gbFlowRuns);
            this.splitContainerMain.Panel2.Controls.Add(this.gbRunFilters);
            this.splitContainerMain.Size = new System.Drawing.Size(978, 449);
            this.splitContainerMain.SplitterDistance = 266;
            this.splitContainerMain.TabIndex = 1;
            // 
            // gbFlows
            // 
            this.gbFlows.Controls.Add(this.clbFlows);
            this.gbFlows.Controls.Add(this.cbSelectAllFlows);
            this.gbFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFlows.Location = new System.Drawing.Point(0, 128);
            this.gbFlows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlows.Name = "gbFlows";
            this.gbFlows.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbFlows.Size = new System.Drawing.Size(266, 321);
            this.gbFlows.TabIndex = 2;
            this.gbFlows.TabStop = false;
            this.gbFlows.Text = "Flows";
            // 
            // clbFlows
            // 
            this.clbFlows.CheckOnClick = true;
            this.clbFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbFlows.FormattingEnabled = true;
            this.clbFlows.Location = new System.Drawing.Point(7, 46);
            this.clbFlows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbFlows.Name = "clbFlows";
            this.clbFlows.Size = new System.Drawing.Size(252, 269);
            this.clbFlows.TabIndex = 1;
            this.clbFlows.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFlows_ItemCheck);
            // 
            // cbSelectAllFlows
            // 
            this.cbSelectAllFlows.AutoSize = true;
            this.cbSelectAllFlows.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSelectAllFlows.Location = new System.Drawing.Point(7, 21);
            this.cbSelectAllFlows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSelectAllFlows.Name = "cbSelectAllFlows";
            this.cbSelectAllFlows.Padding = new System.Windows.Forms.Padding(4, 2, 0, 3);
            this.cbSelectAllFlows.Size = new System.Drawing.Size(252, 25);
            this.cbSelectAllFlows.TabIndex = 0;
            this.cbSelectAllFlows.Text = "Select All";
            this.cbSelectAllFlows.CheckedChanged += new System.EventHandler(this.cbSelectAllFlows_CheckedChanged);
            // 
            // gbFlowFilters
            // 
            this.gbFlowFilters.Controls.Add(this.tbSearch);
            this.gbFlowFilters.Controls.Add(this.lblSearch);
            this.gbFlowFilters.Controls.Add(this.cbxFlowStatusDraft);
            this.gbFlowFilters.Controls.Add(this.cbxFlowStatusActivated);
            this.gbFlowFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFlowFilters.Location = new System.Drawing.Point(0, 48);
            this.gbFlowFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlowFilters.Name = "gbFlowFilters";
            this.gbFlowFilters.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbFlowFilters.Size = new System.Drawing.Size(266, 80);
            this.gbFlowFilters.TabIndex = 1;
            this.gbFlowFilters.TabStop = false;
            this.gbFlowFilters.Text = "Flow Filters";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(64, 44);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(191, 22);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(11, 46);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 16);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // cbxFlowStatusDraft
            // 
            this.cbxFlowStatusDraft.AutoSize = true;
            this.cbxFlowStatusDraft.Location = new System.Drawing.Point(98, 20);
            this.cbxFlowStatusDraft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxFlowStatusDraft.Name = "cbxFlowStatusDraft";
            this.cbxFlowStatusDraft.Size = new System.Drawing.Size(57, 20);
            this.cbxFlowStatusDraft.TabIndex = 1;
            this.cbxFlowStatusDraft.Text = "Draft";
            this.cbxFlowStatusDraft.CheckedChanged += new System.EventHandler(this.cbxFlowStatusDraft_CheckedChanged);
            // 
            // cbxFlowStatusActivated
            // 
            this.cbxFlowStatusActivated.AutoSize = true;
            this.cbxFlowStatusActivated.Checked = true;
            this.cbxFlowStatusActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxFlowStatusActivated.Location = new System.Drawing.Point(11, 20);
            this.cbxFlowStatusActivated.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxFlowStatusActivated.Name = "cbxFlowStatusActivated";
            this.cbxFlowStatusActivated.Size = new System.Drawing.Size(85, 20);
            this.cbxFlowStatusActivated.TabIndex = 0;
            this.cbxFlowStatusActivated.Text = "Activated";
            this.cbxFlowStatusActivated.CheckedChanged += new System.EventHandler(this.cbxFlowStatusActivated_CheckedChanged);
            // 
            // gbSolution
            // 
            this.gbSolution.Controls.Add(this.cbSolutions);
            this.gbSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSolution.Location = new System.Drawing.Point(0, 0);
            this.gbSolution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolution.Name = "gbSolution";
            this.gbSolution.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbSolution.Size = new System.Drawing.Size(266, 48);
            this.gbSolution.TabIndex = 0;
            this.gbSolution.TabStop = false;
            this.gbSolution.Text = "Solution";
            // 
            // cbSolutions
            // 
            this.cbSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSolutions.FormattingEnabled = true;
            this.cbSolutions.Location = new System.Drawing.Point(7, 21);
            this.cbSolutions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSolutions.Name = "cbSolutions";
            this.cbSolutions.Size = new System.Drawing.Size(252, 24);
            this.cbSolutions.TabIndex = 0;
            this.cbSolutions.SelectedIndexChanged += new System.EventHandler(this.cbSolutions_SelectedIndexChanged);
            // 
            // gbFlowRuns
            // 
            this.gbFlowRuns.Controls.Add(this.dgvFlowRuns);
            this.gbFlowRuns.Controls.Add(this.pnlPagination);
            this.gbFlowRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFlowRuns.Location = new System.Drawing.Point(0, 56);
            this.gbFlowRuns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFlowRuns.Name = "gbFlowRuns";
            this.gbFlowRuns.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbFlowRuns.Size = new System.Drawing.Size(708, 393);
            this.gbFlowRuns.TabIndex = 1;
            this.gbFlowRuns.TabStop = false;
            this.gbFlowRuns.Text = "Flow Runs";
            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.lblPageSize);
            this.pnlPagination.Controls.Add(this.cbxPageSize);
            this.pnlPagination.Controls.Add(this.btnPrevPage);
            this.pnlPagination.Controls.Add(this.lblPageInfo);
            this.pnlPagination.Controls.Add(this.btnNextPage);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(7, 339);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(694, 30);
            this.pnlPagination.TabIndex = 1;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(0, 7);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(65, 16);
            this.lblPageSize.TabIndex = 0;
            this.lblPageSize.Text = "Rows/page:";
            // 
            // cbxPageSize
            // 
            this.cbxPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPageSize.FormattingEnabled = true;
            this.cbxPageSize.Items.AddRange(new object[] { "25", "50", "100", "200" });
            this.cbxPageSize.Location = new System.Drawing.Point(70, 3);
            this.cbxPageSize.Name = "cbxPageSize";
            this.cbxPageSize.Size = new System.Drawing.Size(65, 24);
            this.cbxPageSize.TabIndex = 1;
            this.cbxPageSize.SelectedIndexChanged += new System.EventHandler(this.cbxPageSize_SelectedIndexChanged);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(150, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(75, 24);
            this.btnPrevPage.TabIndex = 2;
            this.btnPrevPage.Text = "◀ Prev";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(232, 7);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(80, 16);
            this.lblPageInfo.TabIndex = 3;
            this.lblPageInfo.Text = "Page 1 of 1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(320, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 24);
            this.btnNextPage.TabIndex = 4;
            this.btnNextPage.Text = "Next ▶";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
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
            this.dgvFlowRuns.Location = new System.Drawing.Point(7, 21);
            this.dgvFlowRuns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFlowRuns.Name = "dgvFlowRuns";
            this.dgvFlowRuns.ReadOnly = true;
            this.dgvFlowRuns.RowHeadersVisible = false;
            this.dgvFlowRuns.RowHeadersWidth = 51;
            this.dgvFlowRuns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlowRuns.Size = new System.Drawing.Size(694, 330);
            this.dgvFlowRuns.TabIndex = 0;
            this.dgvFlowRuns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlowRuns_CellClick);
            this.dgvFlowRuns.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlowRuns_CellFormatting);
            // 
            // FlowRunFlow
            // 
            this.FlowRunFlow.DataPropertyName = "Flow";
            this.FlowRunFlow.FillWeight = 120F;
            this.FlowRunFlow.HeaderText = "Flow";
            this.FlowRunFlow.MinimumWidth = 6;
            this.FlowRunFlow.Name = "FlowRunFlow";
            this.FlowRunFlow.ReadOnly = true;
            // 
            // FlowRunStatus
            // 
            this.FlowRunStatus.DataPropertyName = "Status";
            this.FlowRunStatus.FillWeight = 60F;
            this.FlowRunStatus.HeaderText = "Status";
            this.FlowRunStatus.MinimumWidth = 6;
            this.FlowRunStatus.Name = "FlowRunStatus";
            this.FlowRunStatus.ReadOnly = true;
            // 
            // FlowRunStartDate
            // 
            this.FlowRunStartDate.DataPropertyName = "StartDate";
            this.FlowRunStartDate.HeaderText = "Start Date";
            this.FlowRunStartDate.MinimumWidth = 6;
            this.FlowRunStartDate.Name = "FlowRunStartDate";
            this.FlowRunStartDate.ReadOnly = true;
            // 
            // FlowRunEndDate
            // 
            this.FlowRunEndDate.DataPropertyName = "EndDate";
            this.FlowRunEndDate.HeaderText = "End Date";
            this.FlowRunEndDate.MinimumWidth = 6;
            this.FlowRunEndDate.Name = "FlowRunEndDate";
            this.FlowRunEndDate.ReadOnly = true;
            // 
            // FlowRunDuration
            // 
            this.FlowRunDuration.DataPropertyName = "FormattedDuration";
            this.FlowRunDuration.FillWeight = 70F;
            this.FlowRunDuration.HeaderText = "Duration";
            this.FlowRunDuration.MinimumWidth = 6;
            this.FlowRunDuration.Name = "FlowRunDuration";
            this.FlowRunDuration.ReadOnly = true;
            // 
            // FlowRunUrl
            // 
            this.FlowRunUrl.DataPropertyName = "Url";
            this.FlowRunUrl.FillWeight = 50F;
            this.FlowRunUrl.HeaderText = "Run URL";
            this.FlowRunUrl.MinimumWidth = 6;
            this.FlowRunUrl.Name = "FlowRunUrl";
            this.FlowRunUrl.ReadOnly = true;
            this.FlowRunUrl.Text = "Open";
            this.FlowRunUrl.UseColumnTextForLinkValue = true;
            // 
            // FlowRunError
            // 
            this.FlowRunError.DataPropertyName = "ErrorDetails";
            this.FlowRunError.HeaderText = "Error";
            this.FlowRunError.MinimumWidth = 6;
            this.FlowRunError.Name = "FlowRunError";
            this.FlowRunError.ReadOnly = true;
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
            this.gbRunFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbRunFilters.Name = "gbRunFilters";
            this.gbRunFilters.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbRunFilters.Size = new System.Drawing.Size(708, 56);
            this.gbRunFilters.TabIndex = 0;
            this.gbRunFilters.TabStop = false;
            this.gbRunFilters.Text = "Run Filters";
            // 
            // btnGetRuns
            // 
            this.btnGetRuns.Location = new System.Drawing.Point(604, 19);
            this.btnGetRuns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetRuns.Name = "btnGetRuns";
            this.btnGetRuns.Size = new System.Drawing.Size(89, 26);
            this.btnGetRuns.TabIndex = 6;
            this.btnGetRuns.Text = "Get Runs";
            this.btnGetRuns.UseVisualStyleBackColor = true;
            this.btnGetRuns.Click += new System.EventHandler(this.btnGetRuns_Click);
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
            this.cbxStatus.Location = new System.Drawing.Point(483, 22);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(107, 24);
            this.cbxStatus.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(431, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(256, 22);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(160, 22);
            this.dtpDateTo.TabIndex = 3;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(227, 24);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(27, 16);
            this.lblDateTo.TabIndex = 2;
            this.lblDateTo.Text = "To:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(55, 22);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(160, 22);
            this.dtpDateFrom.TabIndex = 1;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(11, 24);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(41, 16);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "From:";
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(978, 480);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.gbFlows.ResumeLayout(false);
            this.gbFlows.PerformLayout();
            this.gbFlowFilters.ResumeLayout(false);
            this.gbFlowFilters.PerformLayout();
            this.gbSolution.ResumeLayout(false);
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.gbFlowRuns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlowRuns)).EndInit();
            this.gbRunFilters.ResumeLayout(false);
            this.gbRunFilters.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator tssSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExportCsv;

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
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cbxPageSize;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;

        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunDuration;
        private System.Windows.Forms.DataGridViewLinkColumn FlowRunUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowRunError;
    }
}
