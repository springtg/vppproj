namespace QLKHO.FORM.MANAGEMENT
{
    partial class frmUnitStyle
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
            this.grdUnitStyle = new DevExpress.XtraGrid.GridControl();
            this.grvUnitStyle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Unit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Supplier = new DevExpress.XtraEditors.LookUpEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUnitStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Supplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUnitStyle
            // 
            this.grdUnitStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUnitStyle.Location = new System.Drawing.Point(0, 84);
            this.grdUnitStyle.MainView = this.grvUnitStyle;
            this.grdUnitStyle.Name = "grdUnitStyle";
            this.grdUnitStyle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Unit});
            this.grdUnitStyle.Size = new System.Drawing.Size(1043, 682);
            this.grdUnitStyle.TabIndex = 5;
            this.grdUnitStyle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUnitStyle});
            // 
            // grvUnitStyle
            // 
            this.grvUnitStyle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3});
            this.grvUnitStyle.GridControl = this.grdUnitStyle;
            this.grvUnitStyle.Name = "grvUnitStyle";
            this.grvUnitStyle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUnitStyle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUnitStyle.OptionsBehavior.AllowIncrementalSearch = true;
            this.grvUnitStyle.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUnitStyle.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUnitStyle.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvUnitStyle.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvUnitStyle.OptionsView.ShowGroupPanel = false;
            this.grvUnitStyle.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvUnitStyle_CellValueChanged);
            this.grvUnitStyle.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvUnitStyle_InvalidRowException);
            this.grvUnitStyle.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvUnitStyle_ValidateRow);
            this.grvUnitStyle.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grvUnitStyle_RowUpdated);
            this.grvUnitStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvUnitStyle_KeyDown);
            this.grvUnitStyle.DataSourceChanged += new System.EventHandler(this.grvUnitStyle_DataSourceChanged);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đơn Vị Nhập";
            this.gridColumn5.ColumnEdit = this.repositoryItemLookUpEdit_Unit;
            this.gridColumn5.FieldName = "Unit_In_Pk";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 89;
            // 
            // repositoryItemLookUpEdit_Unit
            // 
            this.repositoryItemLookUpEdit_Unit.AutoHeight = false;
            this.repositoryItemLookUpEdit_Unit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Unit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã Đơn Vị", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên Đơn Vị")});
            this.repositoryItemLookUpEdit_Unit.DisplayMember = "Name_Unit";
            this.repositoryItemLookUpEdit_Unit.Name = "repositoryItemLookUpEdit_Unit";
            this.repositoryItemLookUpEdit_Unit.NullText = "[Chọn Đơn Vị]";
            this.repositoryItemLookUpEdit_Unit.ValueMember = "Id";
            this.repositoryItemLookUpEdit_Unit.EditValueChanged += new System.EventHandler(this.repositoryItemLookUpEdit_Unit_EditValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Đơn Vị Xuất";
            this.gridColumn6.ColumnEdit = this.repositoryItemLookUpEdit_Unit;
            this.gridColumn6.FieldName = "Unit_Out_Pk";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 97;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Quy Cách";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 136;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "SL Quy Đổi";
            this.gridColumn4.FieldName = "Num";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 83;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.FieldName = "Remark";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 307;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Nhà Cung Cấp";
            // 
            // lookUpEdit_Supplier
            // 
            this.lookUpEdit_Supplier.Location = new System.Drawing.Point(83, 53);
            this.lookUpEdit_Supplier.Name = "lookUpEdit_Supplier";
            this.lookUpEdit_Supplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Supplier.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEdit_Supplier.Properties.DisplayMember = "Name";
            this.lookUpEdit_Supplier.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.lookUpEdit_Supplier.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lookUpEdit_Supplier.Properties.ImmediatePopup = true;
            this.lookUpEdit_Supplier.Properties.NullText = "--Chọn Nhà Cung Cấp--";
            this.lookUpEdit_Supplier.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Supplier.Properties.ValueMember = "Id";
            this.lookUpEdit_Supplier.Size = new System.Drawing.Size(202, 20);
            this.lookUpEdit_Supplier.TabIndex = 10;
            this.lookUpEdit_Supplier.EditValueChanged += new System.EventHandler(this.lookUpEdit_Supplier_EditValueChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 42);
            this.barDockControlTop.Size = new System.Drawing.Size(1043, 42);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSearch,
            this.btnDelete});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(677, 157);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawSizeGrip = true;
            this.bar2.OptionsBar.Hidden = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnSearch.Caption = "Nạp lại";
            this.btnSearch.Glyph = global::QLKHO.Properties.Resources.Search_2_icon32x32;
            this.btnSearch.Id = 0;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Glyph = global::QLKHO.Properties.Resources.edit_delete_icon32x32;
            this.btnDelete.Id = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(1043, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 766);
            this.barDockControlBottom.Size = new System.Drawing.Size(1043, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 724);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1043, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 724);
            // 
            // frmUnitStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1043, 766);
            this.Controls.Add(this.lookUpEdit_Supplier);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdUnitStyle);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControl1);
            this.Name = "frmUnitStyle";
            this.Text = "Quy Cách Chuyển Đổi";
            this.Load += new System.EventHandler(this.frmUnitStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUnitStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Supplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUnitStyle;
        public DevExpress.XtraGrid.Views.Grid.GridView grvUnitStyle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Unit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Supplier;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
    }
}
