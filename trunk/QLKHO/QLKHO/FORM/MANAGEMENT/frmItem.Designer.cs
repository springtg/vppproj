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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItem));
            this.grdItem = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUnit)).BeginInit();
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
            this.lookUpUnit});
            this.grdItem.Size = new System.Drawing.Size(827, 489);
            this.grdItem.TabIndex = 4;
            this.grdItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn7});
            this.gridView1.GridControl = this.grdItem;
            this.gridView1.GroupPanelText = "Kéo và thả cột vào đây để nhóm hiển thị";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Click vào đây để thêm dòng mới";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
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
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nhóm hàng hóa";
            this.gridColumn3.ColumnEdit = this.lookUpGroup;
            this.gridColumn3.FieldName = "Group_Pk";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên hàng hóa";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Đơn vị";
            this.gridColumn9.ColumnEdit = this.lookUpUnit;
            this.gridColumn9.FieldName = "Unit_Pk";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 103;
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
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ngày tạo";
            this.gridColumn6.DisplayFormat.FormatString = "d";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "Crt_Dt";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 103;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SL Tồn";
            this.gridColumn8.FieldName = "slton";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 113;
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
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 489);
            this.Controls.Add(this.grdItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItem";
            this.Text = "Hàng Hóa";
            this.Load += new System.EventHandler(this.frmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;

    }
}