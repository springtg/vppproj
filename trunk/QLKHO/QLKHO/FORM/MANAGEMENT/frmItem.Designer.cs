namespace QLKHO.FORM.MANAGEMENT
{
    partial class frmItem
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
            this.grdItem = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpSupplier = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.LookUpUnitStyle = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpUnitStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // grdItem
            // 
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Location = new System.Drawing.Point(0, 0);
            this.grdItem.MainView = this.gridView1;
            this.grdItem.Name = "grdItem";
            this.grdItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookUpGroup,
            this.lookUpUnit,
            this.lookUpSupplier,
            this.LookUpUnitStyle,
            this.repositoryItemCheckedComboBoxEdit1});
            this.grdItem.Size = new System.Drawing.Size(827, 423);
            this.grdItem.TabIndex = 4;
            this.grdItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.GridControl = this.grdItem;
            this.gridView1.GroupPanelText = "Kéo và thả cột vào đây để nhóm hiển thị";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Click vào đây để thêm dòng mới";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gridColumn1.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridColumn1.AppearanceCell.BorderColor = System.Drawing.Color.Indigo;
            this.gridColumn1.AppearanceCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.AppearanceCell.Options.UseBorderColor = true;
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "Id_Dis";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên hàng hóa";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nhóm hàng hóa";
            this.gridColumn3.ColumnEdit = this.lookUpGroup;
            this.gridColumn3.FieldName = "Group_Pk";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 103;
            // 
            // lookUpGroup
            // 
            this.lookUpGroup.AutoHeight = false;
            this.lookUpGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGroup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.lookUpGroup.DisplayMember = "Name";
            this.lookUpGroup.Name = "lookUpGroup";
            this.lookUpGroup.NullText = "---Chọn giá trị---";
            this.lookUpGroup.ValueMember = "Id";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nhà cung cấp";
            this.gridColumn5.ColumnEdit = this.lookUpSupplier;
            this.gridColumn5.FieldName = "supplier_pk";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 103;
            // 
            // lookUpSupplier
            // 
            this.lookUpSupplier.AutoHeight = false;
            this.lookUpSupplier.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSupplier.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.lookUpSupplier.DisplayMember = "Name";
            this.lookUpSupplier.Name = "lookUpSupplier";
            this.lookUpSupplier.NullText = "---Chọn giá trị---";
            this.lookUpSupplier.ValueMember = "Id";
            this.lookUpSupplier.EditValueChanged += new System.EventHandler(this.lookUpSupplier_EditValueChanged);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Quy Cách";
            this.gridColumn9.ColumnEdit = this.repositoryItemCheckedComboBoxEdit1;
            this.gridColumn9.FieldName = "styleGroup";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 103;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.DisplayMember = "Name";
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            this.repositoryItemCheckedComboBoxEdit1.SelectAllItemVisible = false;
            this.repositoryItemCheckedComboBoxEdit1.ValueMember = "Name";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "SL DVT";
            this.gridColumn4.FieldName = "Num";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ngày tạo";
            this.gridColumn6.DisplayFormat.FormatString = "d";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "Crt_Dt";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 103;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ghi chú";
            this.gridColumn7.FieldName = "Remark";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 103;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SL Tồn";
            this.gridColumn8.FieldName = "slton";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 113;
            // 
            // lookUpUnit
            // 
            this.lookUpUnit.AutoHeight = false;
            this.lookUpUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpUnit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.lookUpUnit.DisplayMember = "Name";
            this.lookUpUnit.Name = "lookUpUnit";
            this.lookUpUnit.NullText = "---Chọn giá trị---";
            this.lookUpUnit.ValueMember = "Id";
            // 
            // LookUpUnitStyle
            // 
            this.LookUpUnitStyle.AutoHeight = false;
            this.LookUpUnitStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpUnitStyle.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Num", "SLDVT")});
            this.LookUpUnitStyle.DisplayMember = "Name";
            this.LookUpUnitStyle.Name = "LookUpUnitStyle";
            this.LookUpUnitStyle.ValueMember = "Id";
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 423);
            this.Controls.Add(this.grdItem);
            this.Name = "frmItem";
            this.Text = "Hàng Hóa";
            this.Load += new System.EventHandler(this.frmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpUnitStyle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpUnitStyle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;

    }
}