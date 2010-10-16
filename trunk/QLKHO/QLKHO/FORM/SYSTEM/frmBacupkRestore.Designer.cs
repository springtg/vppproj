namespace QLKHO.FORM.SYSTEM
{
    partial class frmBacupkRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBacupkRestore));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnEdit = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblStatus);
            this.groupControl1.Controls.Add(this.txtPath);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnBackup);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(471, 155);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Sao lưu dữ liệu";
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Location = new System.Drawing.Point(5, 136);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(69, 38);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(327, 20);
            this.txtPath.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nơi sao lưu:";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(69, 64);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "Sao Lưu";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnRestore);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.btnEdit);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 155);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(471, 162);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Phục hồi dữ liệu";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(81, 79);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Sao Lưu";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Nơi sao lưu:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(81, 44);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit.Size = new System.Drawing.Size(315, 20);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.EditValueChanged += new System.EventHandler(this.btnEdit_EditValueChanged);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmBacupkRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 317);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBacupkRestore";
            this.ShowInTaskbar = false;
            this.Text = "Sao Lưu & Phục Hồi";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.ButtonEdit btnEdit;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblStatus;




    }
}