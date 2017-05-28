namespace ManageSCOMOleDbQueryMonitor
{
    partial class ManageOleDBQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageOleDBQuery));
            this.kryptonRibbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.contabManage = new ComponentFactory.Krypton.Ribbon.KryptonRibbonContext();
            this.tabManage = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.krpActions = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.krgBtnConnection = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krpBtnConnection = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krpBtnAddNew = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.cmdAddQuery = new ComponentFactory.Krypton.Toolkit.KryptonCommand();
            this.btnRemove = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupLines2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.kryptonRibbonGroupLabel1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.txtFilter = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnRefresh = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.tblOleDBQueries = new BrightIdeasSoftware.ObjectListView();
            this.clnInstance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnQueryName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnStartDay = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnEndDay = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnDaysOfWeekMask = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnQuery = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnGroupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnDirection = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnSamples = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnThreshold = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clnUniqueID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelFill = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOleDBQueries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).BeginInit();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonRibbon
            // 
            this.kryptonRibbon.InDesignHelperMode = true;
            this.kryptonRibbon.Name = "kryptonRibbon";
            this.kryptonRibbon.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonRibbon.RibbonAppButton.AppButtonBaseColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(162)))), ((int)(((byte)(9)))));
            this.kryptonRibbon.RibbonAppButton.AppButtonBaseColorLight = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.kryptonRibbon.RibbonAppButton.AppButtonVisible = false;
            this.kryptonRibbon.RibbonContexts.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonContext[] {
            this.contabManage});
            this.kryptonRibbon.RibbonStyles.GroupButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Form;
            this.kryptonRibbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.tabManage});
            this.kryptonRibbon.SelectedContext = "Manage";
            this.kryptonRibbon.SelectedTab = this.tabManage;
            this.kryptonRibbon.ShowMinimizeButton = false;
            this.kryptonRibbon.Size = new System.Drawing.Size(784, 115);
            this.kryptonRibbon.TabIndex = 0;
            // 
            // contabManage
            // 
            this.contabManage.ContextColor = System.Drawing.Color.Linen;
            this.contabManage.ContextName = "Manage";
            this.contabManage.ContextTitle = "Manage";
            // 
            // tabManage
            // 
            this.tabManage.ContextName = "Manage";
            this.tabManage.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.krpActions});
            this.tabManage.Text = "Manage";
            // 
            // krpActions
            // 
            this.krpActions.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.krgBtnConnection,
            this.kryptonRibbonGroupSeparator1,
            this.kryptonRibbonGroupLines2,
            this.kryptonRibbonGroupTriple1});
            this.krpActions.TextLine1 = "Actions";
            // 
            // krgBtnConnection
            // 
            this.krgBtnConnection.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krpBtnConnection,
            this.krpBtnAddNew,
            this.btnRemove});
            // 
            // krpBtnConnection
            // 
            this.krpBtnConnection.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krpBtnConnection.ImageLarge")));
            this.krpBtnConnection.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krpBtnConnection.ImageSmall")));
            this.krpBtnConnection.TextLine1 = "Connect";
            this.krpBtnConnection.TextLine2 = "SCOM";
            this.krpBtnConnection.Click += new System.EventHandler(this.krpBtnConnection_Click);
            // 
            // krpBtnAddNew
            // 
            this.krpBtnAddNew.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krpBtnAddNew.ImageLarge")));
            this.krpBtnAddNew.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krpBtnAddNew.ImageSmall")));
            this.krpBtnAddNew.KryptonCommand = this.cmdAddQuery;
            this.krpBtnAddNew.TextLine1 = "Add";
            // 
            // cmdAddQuery
            // 
            this.cmdAddQuery.ExtraText = "Add";
            this.cmdAddQuery.ImageLarge = ((System.Drawing.Image)(resources.GetObject("cmdAddQuery.ImageLarge")));
            this.cmdAddQuery.ImageSmall = ((System.Drawing.Image)(resources.GetObject("cmdAddQuery.ImageSmall")));
            this.cmdAddQuery.TextLine1 = "Add";
            this.cmdAddQuery.TextLine2 = "Query";
            this.cmdAddQuery.Execute += new System.EventHandler(this.cmdAddQuery_Execute);
            // 
            // btnRemove
            // 
            this.btnRemove.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageLarge")));
            this.btnRemove.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageSmall")));
            this.btnRemove.TextLine1 = "Remove";
            this.btnRemove.TextLine2 = "Query";
            this.btnRemove.Visible = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // kryptonRibbonGroupLines2
            // 
            this.kryptonRibbonGroupLines2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupLabel1,
            this.txtFilter});
            // 
            // kryptonRibbonGroupLabel1
            // 
            this.kryptonRibbonGroupLabel1.TextLine1 = "Filter:";
            // 
            // txtFilter
            // 
            this.txtFilter.Text = "";
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnRefresh});
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageLarge")));
            this.btnRefresh.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageSmall")));
            this.btnRefresh.TextLine1 = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(782, 22);
            this.miniToolStrip.TabIndex = 0;
            // 
            // tblOleDBQueries
            // 
            this.tblOleDBQueries.AllColumns.Add(this.clnInstance);
            this.tblOleDBQueries.AllColumns.Add(this.clnQueryName);
            this.tblOleDBQueries.AllColumns.Add(this.clnStartDay);
            this.tblOleDBQueries.AllColumns.Add(this.clnEndDay);
            this.tblOleDBQueries.AllColumns.Add(this.clnDaysOfWeekMask);
            this.tblOleDBQueries.AllColumns.Add(this.clnQuery);
            this.tblOleDBQueries.AllColumns.Add(this.clnGroupName);
            this.tblOleDBQueries.AllColumns.Add(this.clnDirection);
            this.tblOleDBQueries.AllColumns.Add(this.clnSamples);
            this.tblOleDBQueries.AllColumns.Add(this.clnThreshold);
            this.tblOleDBQueries.AllColumns.Add(this.clnUniqueID);
            this.tblOleDBQueries.AllowColumnReorder = true;
            this.tblOleDBQueries.CellEditUseWholeCell = false;
            this.tblOleDBQueries.CheckBoxes = true;
            this.tblOleDBQueries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnInstance,
            this.clnQueryName,
            this.clnStartDay,
            this.clnEndDay,
            this.clnDaysOfWeekMask,
            this.clnQuery,
            this.clnGroupName,
            this.clnDirection,
            this.clnSamples,
            this.clnThreshold});
            this.tblOleDBQueries.Cursor = System.Windows.Forms.Cursors.Default;
            this.tblOleDBQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOleDBQueries.HeaderWordWrap = true;
            this.tblOleDBQueries.HideSelection = false;
            this.tblOleDBQueries.IncludeColumnHeadersInCopy = true;
            this.tblOleDBQueries.Location = new System.Drawing.Point(0, 0);
            this.tblOleDBQueries.Name = "tblOleDBQueries";
            this.tblOleDBQueries.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.tblOleDBQueries.ShowCommandMenuOnRightClick = true;
            this.tblOleDBQueries.ShowGroups = false;
            this.tblOleDBQueries.ShowHeaderInAllViews = false;
            this.tblOleDBQueries.ShowItemToolTips = true;
            this.tblOleDBQueries.Size = new System.Drawing.Size(784, 447);
            this.tblOleDBQueries.SortGroupItemsByPrimaryColumn = false;
            this.tblOleDBQueries.TabIndex = 1;
            this.tblOleDBQueries.TriStateCheckBoxes = true;
            this.tblOleDBQueries.UseAlternatingBackColors = true;
            this.tblOleDBQueries.UseCellFormatEvents = true;
            this.tblOleDBQueries.UseCompatibleStateImageBehavior = false;
            this.tblOleDBQueries.UseFilterIndicator = true;
            this.tblOleDBQueries.UseFiltering = true;
            this.tblOleDBQueries.UseHotItem = true;
            this.tblOleDBQueries.View = System.Windows.Forms.View.Details;
            this.tblOleDBQueries.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.tblOleDBQueries_ItemsChanged);
            this.tblOleDBQueries.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.tblOleDBQueries_ItemChecked);
            // 
            // clnInstance
            // 
            this.clnInstance.AspectName = "Instance";
            this.clnInstance.Text = "Instance";
            // 
            // clnQueryName
            // 
            this.clnQueryName.AspectName = "QueryName";
            this.clnQueryName.Text = "Name";
            // 
            // clnStartDay
            // 
            this.clnStartDay.AspectName = "StartDay";
            this.clnStartDay.Text = "Start Day";
            // 
            // clnEndDay
            // 
            this.clnEndDay.AspectName = "EndDay";
            this.clnEndDay.Text = "End Day";
            // 
            // clnDaysOfWeekMask
            // 
            this.clnDaysOfWeekMask.AspectName = "DaysOfWeekMask";
            this.clnDaysOfWeekMask.Text = "Days Of Week Mask";
            this.clnDaysOfWeekMask.Width = 122;
            // 
            // clnQuery
            // 
            this.clnQuery.AspectName = "Query";
            this.clnQuery.Text = "Query";
            // 
            // clnGroupName
            // 
            this.clnGroupName.AspectName = "GroupName";
            this.clnGroupName.Text = "Group Name";
            // 
            // clnDirection
            // 
            this.clnDirection.AspectName = "Direction";
            this.clnDirection.Text = "Direction";
            // 
            // clnSamples
            // 
            this.clnSamples.AspectName = "Samples";
            this.clnSamples.Text = "Samples";
            // 
            // clnThreshold
            // 
            this.clnThreshold.AspectName = "Threshold";
            this.clnThreshold.Text = "Threshold";
            // 
            // clnUniqueID
            // 
            this.clnUniqueID.AspectName = "UniqueID";
            this.clnUniqueID.IsVisible = false;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tblOleDBQueries);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 115);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(784, 447);
            this.panelFill.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ManageOleDBQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.kryptonRibbon);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageOleDBQuery";
            this.StateCommon.Header.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.StateCommon.Header.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.Text = "Manage Ole DB Query Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOleDBQueries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).EndInit();
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Ribbon.KryptonRibbon kryptonRibbon;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab tabManage;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup krpActions;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple krgBtnConnection;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton krpBtnConnection;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton krpBtnAddNew;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private BrightIdeasSoftware.ObjectListView tblOleDBQueries;
        private BrightIdeasSoftware.OLVColumn clnInstance;
        private BrightIdeasSoftware.OLVColumn clnQueryName;
        private BrightIdeasSoftware.OLVColumn clnStartDay;
        private BrightIdeasSoftware.OLVColumn clnEndDay;
        private BrightIdeasSoftware.OLVColumn clnDaysOfWeekMask;
        private BrightIdeasSoftware.OLVColumn clnQuery;
        private BrightIdeasSoftware.OLVColumn clnGroupName;
        private BrightIdeasSoftware.OLVColumn clnDirection;
        private BrightIdeasSoftware.OLVColumn clnSamples;
        private BrightIdeasSoftware.OLVColumn clnThreshold;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelFill;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonCommand cmdAddQuery;
        private BrightIdeasSoftware.OLVColumn clnUniqueID;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnRemove;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonContext contabManage;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines kryptonRibbonGroupLines2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox txtFilter;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnRefresh;
    }
}