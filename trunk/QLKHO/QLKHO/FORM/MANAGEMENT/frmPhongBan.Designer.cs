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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id_Dis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Crt_By = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Mod_Dt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Mod_By = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Is_Del = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(827, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 423);
            this.barDockControlBottom.Size = new System.Drawing.Size(827, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 399);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(827, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 399);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Add";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Update";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Delete";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(827, 399);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.Id_Dis,
            this.Name,
            this.Phone,
            this.Crt_By,
            this.Mod_Dt,
            this.Mod_By,
            this.Remark,
            this.Is_Del});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            // 
            // Id_Dis
            // 
            this.Id_Dis.Caption = "Mã";
            this.Id_Dis.FieldName = "Id_Dis";
            this.Id_Dis.Name = "Id_Dis";
            this.Id_Dis.Visible = true;
            this.Id_Dis.VisibleIndex = 1;
            // 
            // Name
            // 
            this.Name.Caption = "Tên Phòng";
            this.Name.FieldName = "Name";
            this.Name.Name = "Name";
            this.Name.Visible = true;
            this.Name.VisibleIndex = 2;
            // 
            // Crt_By
            // 
            this.Crt_By.Caption = "Tạo bởi";
            this.Crt_By.FieldName = "Crt_By";
            this.Crt_By.Name = "Crt_By";
            this.Crt_By.Visible = true;
            this.Crt_By.VisibleIndex = 4;
            // 
            // Mod_Dt
            // 
            this.Mod_Dt.Caption = "Ngày sửa";
            this.Mod_Dt.FieldName = "Mod_Dt";
            this.Mod_Dt.Name = "Mod_Dt";
            this.Mod_Dt.Visible = true;
            this.Mod_Dt.VisibleIndex = 5;
            // 
            // Mod_By
            // 
            this.Mod_By.Caption = "Sửa bởi";
            this.Mod_By.FieldName = "Mod_By";
            this.Mod_By.Name = "Mod_By";
            this.Mod_By.Visible = true;
            this.Mod_By.VisibleIndex = 6;
            // 
            // Is_Del
            // 
            this.Is_Del.Caption = "Đã xóa";
            this.Is_Del.FieldName = "Is_Del";
            this.Is_Del.Name = "Is_Del";
            this.Is_Del.Visible = true;
            this.Is_Del.VisibleIndex = 8;
            // 
            // Remark
            // 
            this.Remark.Caption = "Diễn giải";
            this.Remark.FieldName = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 7;
            // 
            // Phone
            // 
            this.Phone.Caption = "Điện thoại";
            this.Phone.FieldName = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.Visible = true;
            this.Phone.VisibleIndex = 3;
            // 
            // frmPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPhongBan";
            this.Text = "frmPhongBan";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn Id_Dis;
        private DevExpress.XtraGrid.Columns.GridColumn Name;
        private DevExpress.XtraGrid.Columns.GridColumn Phone;
        private DevExpress.XtraGrid.Columns.GridColumn Crt_By;
        private DevExpress.XtraGrid.Columns.GridColumn Mod_Dt;
        private DevExpress.XtraGrid.Columns.GridColumn Mod_By;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraGrid.Columns.GridColumn Is_Del;

    }
}