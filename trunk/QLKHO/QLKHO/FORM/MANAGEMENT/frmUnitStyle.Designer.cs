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
            this.grdUnitStyle = new DevExpress.XtraGrid.GridControl();
            this.grvUnitStyle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Unit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Supplier = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Group = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_Catalog = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_Item = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUnitStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Supplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Group.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Catalog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Item.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUnitStyle
            // 
            this.grdUnitStyle.Location = new System.Drawing.Point(0, 47);
            this.grdUnitStyle.MainView = this.grvUnitStyle;
            this.grdUnitStyle.Name = "grdUnitStyle";
            this.grdUnitStyle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Unit,
            this.repositoryItemLookUpEdit_Supplier});
            this.grdUnitStyle.Size = new System.Drawing.Size(1043, 487);
            this.grdUnitStyle.TabIndex = 5;
            this.grdUnitStyle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUnitStyle});
            // 
            // grvUnitStyle
            // 
            this.grvUnitStyle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
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
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đơn Vị Nhập";
            this.gridColumn5.ColumnEdit = this.repositoryItemLookUpEdit_Unit;
            this.gridColumn5.FieldName = "Unit_In_Pk";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 63;
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
            this.gridColumn6.Width = 69;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Nhà Cung Cấp";
            this.gridColumn7.ColumnEdit = this.repositoryItemLookUpEdit_Supplier;
            this.gridColumn7.FieldName = "Supplier_Pk";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 158;
            // 
            // repositoryItemLookUpEdit_Supplier
            // 
            this.repositoryItemLookUpEdit_Supplier.AutoHeight = false;
            this.repositoryItemLookUpEdit_Supplier.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Supplier.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã Nhà Cung Cấp", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên Nhà Cung Cấp")});
            this.repositoryItemLookUpEdit_Supplier.DisplayMember = "Name_Dis";
            this.repositoryItemLookUpEdit_Supplier.Name = "repositoryItemLookUpEdit_Supplier";
            this.repositoryItemLookUpEdit_Supplier.ValueMember = "Id";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Quy Cách";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.UnboundExpression = "[]/[]";
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 96;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "SL Quy Đổi";
            this.gridColumn4.FieldName = "Num";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 59;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.FieldName = "Remark";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 216;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Danh Mục";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(255, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Nhóm Hàng Hóa";
            // 
            // lookUpEdit_Group
            // 
            this.lookUpEdit_Group.Location = new System.Drawing.Point(339, 12);
            this.lookUpEdit_Group.Name = "lookUpEdit_Group";
            this.lookUpEdit_Group.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Group.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã Nhóm", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 300, "Tên Nhóm")});
            this.lookUpEdit_Group.Properties.DisplayMember = "NAME_GROUP";
            this.lookUpEdit_Group.Properties.NullText = "--Chọn Nhóm Hàng Hóa--";
            this.lookUpEdit_Group.Properties.ValueMember = "Id";
            this.lookUpEdit_Group.Size = new System.Drawing.Size(185, 20);
            this.lookUpEdit_Group.TabIndex = 9;
            this.lookUpEdit_Group.EditValueChanged += new System.EventHandler(this.lookUpEdit_Group_EditValueChanged);
            // 
            // lookUpEdit_Catalog
            // 
            this.lookUpEdit_Catalog.Location = new System.Drawing.Point(76, 12);
            this.lookUpEdit_Catalog.Name = "lookUpEdit_Catalog";
            this.lookUpEdit_Catalog.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Catalog.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã Danh Mục", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên Danh Mục", 300, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEdit_Catalog.Properties.DisplayMember = "NAME_CAT";
            this.lookUpEdit_Catalog.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.lookUpEdit_Catalog.Properties.ImmediatePopup = true;
            this.lookUpEdit_Catalog.Properties.NullText = "--Chọn Danh Mục--";
            this.lookUpEdit_Catalog.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUpEdit_Catalog.Properties.ValueMember = "Id";
            this.lookUpEdit_Catalog.Size = new System.Drawing.Size(157, 20);
            this.lookUpEdit_Catalog.TabIndex = 10;
            this.lookUpEdit_Catalog.EditValueChanged += new System.EventHandler(this.lookUpEdit_Catalog_EditValueChanged);
            // 
            // lookUpEdit_Item
            // 
            this.lookUpEdit_Item.Location = new System.Drawing.Point(592, 12);
            this.lookUpEdit_Item.Name = "lookUpEdit_Item";
            this.lookUpEdit_Item.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Item.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã Hàng", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 300, "Tên Hàng")});
            this.lookUpEdit_Item.Properties.DisplayMember = "ITEM_NAME";
            this.lookUpEdit_Item.Properties.NullText = "--Chọn Hàng Hóa--";
            this.lookUpEdit_Item.Properties.ValueMember = "Id";
            this.lookUpEdit_Item.Size = new System.Drawing.Size(224, 20);
            this.lookUpEdit_Item.TabIndex = 11;
            this.lookUpEdit_Item.EditValueChanged += new System.EventHandler(this.lookUpEdit_Item_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(543, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Hàng Hóa";
            // 
            // frmUnitStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1043, 534);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpEdit_Item);
            this.Controls.Add(this.lookUpEdit_Catalog);
            this.Controls.Add(this.lookUpEdit_Group);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdUnitStyle);
            this.Name = "frmUnitStyle";
            this.Text = "Quy Cách Chuyển Đổi";
            this.Load += new System.EventHandler(this.frmUnitStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnitStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUnitStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Supplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Group.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Catalog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Item.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Unit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Supplier;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Group;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Catalog;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Item;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
