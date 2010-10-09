namespace QLKHO.FORM.MANAGEMENT
{
    partial class frmPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongBan));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bntUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grdDepartment = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id_Dis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NamePB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkupUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupUser)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.bntUpdate,
            this.btnDelete});
            this.barManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bntUpdate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnAdd
            // 
            this.btnAdd.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnAdd.Caption = "Add";
            this.btnAdd.Glyph = global::QLKHO.Properties.Resources.New_icon16x16;
            this.btnAdd.Id = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // bntUpdate
            // 
            this.bntUpdate.Caption = "Update";
            this.bntUpdate.Glyph = global::QLKHO.Properties.Resources.Edit16x16;
            this.bntUpdate.Id = 2;
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bntUpdate_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Glyph = global::QLKHO.Properties.Resources.edit_delete_icon16x16;
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(827, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 464);
            this.barDockControlBottom.Size = new System.Drawing.Size(827, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 438);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(827, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 438);
            // 
            // grdDepartment
            // 
            this.grdDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDepartment.Location = new System.Drawing.Point(0, 26);
            this.grdDepartment.MainView = this.gridView1;
            this.grdDepartment.MenuManager = this.barManager1;
            this.grdDepartment.Name = "grdDepartment";
            this.grdDepartment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkupUser});
            this.grdDepartment.Size = new System.Drawing.Size(827, 438);
            this.grdDepartment.TabIndex = 4;
            this.grdDepartment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.Id_Dis,
            this.NamePB,
            this.gridColumn1,
            this.Phone,
            this.Remark});
            this.gridView1.GridControl = this.grdDepartment;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Nhấn vào đây để thêm dòng mới";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // Id_Dis
            // 
            this.Id_Dis.AppearanceCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Id_Dis.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Id_Dis.AppearanceCell.BorderColor = System.Drawing.Color.Indigo;
            this.Id_Dis.AppearanceCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Id_Dis.AppearanceCell.Options.UseBackColor = true;
            this.Id_Dis.AppearanceCell.Options.UseBorderColor = true;
            this.Id_Dis.Caption = "Mã";
            this.Id_Dis.FieldName = "Id_Dis";
            this.Id_Dis.Name = "Id_Dis";
            this.Id_Dis.OptionsColumn.AllowEdit = false;
            this.Id_Dis.OptionsColumn.AllowFocus = false;
            this.Id_Dis.OptionsColumn.ReadOnly = true;
            this.Id_Dis.Visible = true;
            this.Id_Dis.VisibleIndex = 0;
            // 
            // NamePB
            // 
            this.NamePB.Caption = "Tên Phòng";
            this.NamePB.FieldName = "Name";
            this.NamePB.Name = "NamePB";
            this.NamePB.Visible = true;
            this.NamePB.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Trưởng phòng";
            this.gridColumn1.ColumnEdit = this.lkupUser;
            this.gridColumn1.FieldName = "LeaderId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // lkupUser
            // 
            this.lkupUser.AutoHeight = false;
            this.lkupUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupUser.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Dis", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name_Dis", "Tên")});
            this.lkupUser.DisplayMember = "Name_Dis";
            this.lkupUser.Name = "lkupUser";
            this.lkupUser.ValueMember = "Id";
            // 
            // Phone
            // 
            this.Phone.Caption = "Điện thoại";
            this.Phone.FieldName = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.Visible = true;
            this.Phone.VisibleIndex = 3;
            // 
            // Remark
            // 
            this.Remark.Caption = "Diễn giải";
            this.Remark.FieldName = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 4;
            // 
            // frmPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 464);
            this.Controls.Add(this.grdDepartment);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPhongBan";
            this.Text = "Phòng Ban";
            this.Load += new System.EventHandler(this.frmPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem bntUpdate;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraGrid.GridControl grdDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn Id_Dis;
        private DevExpress.XtraGrid.Columns.GridColumn NamePB;
        private DevExpress.XtraGrid.Columns.GridColumn Phone;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkupUser;

    }
}