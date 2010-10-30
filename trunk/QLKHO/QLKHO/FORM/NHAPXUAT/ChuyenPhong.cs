using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class ChuyenPhong : COREBASE.FORM.BASEFORM
    {
        DepartmentsDao Dao;
        ChuyenPBDao ChuyenPB;
        public ChuyenPhong(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem;
            Dao = new DepartmentsDao(_ConfigItem);
            ChuyenPB = new ChuyenPBDao(_ConfigItem);
        }
        private void LoadPB() {
            cmbPBChuyen.Properties.DataSource = Dao.GetList();
            lkPBTo.Properties.DataSource = Dao.GetList();
        }
     
        private void ChuyenPhong_Load(object sender, EventArgs e)
        {
            LoadPB();
        }

        private void cmbPBChuyen_EditValueChanged(object sender, EventArgs e)
        {
            txtSLTon.Text = "";
           int DepartmentFrom_pk = int.Parse( ((DataRowView)cmbPBChuyen.GetSelectedDataRow()).Row["Id"].ToString());
           lkHHFrom.Properties.DataSource = ChuyenPB.GetItembyPB(DepartmentFrom_pk);
        }

        private void bntChuyen_Click(object sender, EventArgs e)
        {
            object[] arr = new object[]{
              int.Parse( ((DataRowView)lkHHFrom.GetSelectedDataRow()).Row["Item_Pk"].ToString()),
               int.Parse( ((DataRowView)cmbPBChuyen.GetSelectedDataRow()).Row["Id"].ToString()),
             int.Parse(((DataRowView)lkPBTo.GetSelectedDataRow()).Row["Id"].ToString()),
             txtSLChuyen.Text
            };
            ChuyenPB.Insert(arr);
        }
        private void lkHHFrom_EditValueChanged(object sender, EventArgs e)
        {
            txtSLTon.Text = "";
            int DepartmentFrom_pk = int.Parse( ((DataRowView)cmbPBChuyen.GetSelectedDataRow()).Row["Id"].ToString());
            int Item_Pk = int.Parse( ((DataRowView)lkHHFrom.GetSelectedDataRow()).Row["Item_Pk"].ToString());
            int Num= int.Parse( ((DataRowView)lkHHFrom.GetSelectedDataRow()).Row["Num"].ToString());
            DataTable dtFrom= ChuyenPB.GetnumChuyenFrom(DepartmentFrom_pk, Item_Pk);
            DataTable dtTo= ChuyenPB.GetnumChuyenTo(DepartmentFrom_pk, Item_Pk);
            int numfrom=0;
            int numto=0;
            if (dtFrom.Rows.Count > 0)
            {
                try
                {
                    numfrom = int.Parse(dtFrom.Rows[0]["Num"].ToString());
                }
                catch (Exception ex) { }
            }
            if (dtTo.Rows.Count > 0)
            {
                try
                {
                    numto = int.Parse(dtTo.Rows[0]["Num"].ToString());
                }catch(Exception ex){}
            }
            txtSLTon.Text = (Num + numto - numfrom).ToString();
            txtUnit.Text = ((DataRowView)lkHHFrom.GetSelectedDataRow()).Row["NameUnit"].ToString();
        }

        private void lkPBTo_EditValueChanged(object sender, EventArgs e)
        {
            txtSLTonTo.Text = "";
            int DepartmentFrom_pk = int.Parse(((DataRowView)lkPBTo.GetSelectedDataRow()).Row["Id"].ToString());
            lkHHTo.Properties.DataSource = ChuyenPB.GetItembyPB(DepartmentFrom_pk);
        }

        private void lkHHTo_EditValueChanged(object sender, EventArgs e)
        {
            txtSLTonTo.Text = "";
            int DepartmentFrom_pk = int.Parse(((DataRowView)lkPBTo.GetSelectedDataRow()).Row["Id"].ToString());
            int Item_Pk = int.Parse(((DataRowView)lkHHTo.GetSelectedDataRow()).Row["Item_Pk"].ToString());
            int Num = int.Parse(((DataRowView)lkHHTo.GetSelectedDataRow()).Row["Num"].ToString());
            DataTable dtFrom = ChuyenPB.GetnumChuyenFrom(DepartmentFrom_pk, Item_Pk);
            DataTable dtTo = ChuyenPB.GetnumChuyenTo(DepartmentFrom_pk, Item_Pk);
            int numfrom = 0;
            int numto = 0;
            if (dtFrom.Rows.Count > 0)
            {
                try
                {
                    numfrom = int.Parse(dtFrom.Rows[0]["Num"].ToString());
                }
                catch (Exception ex) { }
            }
            if (dtTo.Rows.Count > 0)
            {
                try
                {
                    numto = int.Parse(dtTo.Rows[0]["Num"].ToString());
                }
                catch (Exception ex) { }
            }
            txtSLTonTo.Text = (Num + numto - numfrom).ToString();
        }

      
   
    }
}