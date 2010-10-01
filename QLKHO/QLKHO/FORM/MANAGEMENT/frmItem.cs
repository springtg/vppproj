using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;
using QLKHO.BUSOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmItem : COREBASE.FORM.BASEFORM
    {
        private const string l_Str_Unit = "Unit";
        private const string l_Str_Group = "Group";
        private const string l_Str_Item = "Item";
         public frmItem(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            Initdata(l_Str_Group, 0);
     
            Initdata(l_Str_Unit, 0);
            
        //    Initdata(l_Str_UnitStyle, 0);
            Initdata(l_Str_Item, 0);
        }

        private void Initdata(string p_Type,int p_idsupplier)
        {
            switch (p_Type)
            {
                case l_Str_Group:
                    lookUpGroup.DataSource = GroupItemDao.GetList(_ConfigItem);
                    break;
                case l_Str_Unit:
                    lookUpUnit.DataSource = UnitDao.GetList(_ConfigItem);
                    break;
                case l_Str_Item:
                    grdItem.DataSource = ItemDao.GetList(_ConfigItem);
                    break;
                default:
                    break;
            }

        }
      
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(grdItem.DataSource);
                for (int i = 0; i < Tmp.Rows.Count; i++)
                {
                    DataRow dr = Tmp.Rows[i];
                    if (isModifedRow(dr))
                    {
                       ItemDao.Update(_ConfigItem,dr);
                    }
                    if (isNewRow(dr))
                    {
                        ItemDao.Insert(_ConfigItem, dr);
                    }
                    if (isDeletedRow(dr))
                    {
                        ItemDao.Delete(_ConfigItem, (int)GetOriginalItemData(dr, "Id"));
                    }
                }
                Initdata(l_Str_Item, 0);
            }
            catch (Exception ex)
            {
                AppDebug(ex);
                ShowMessageBox("ITEM_I_003", COREBASE.COMMAND.MessageUtils.MessageType.ERROR);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(System.Windows.Forms.Keys.Delete))
            {
                object l_Item_Name = string.Empty;
                try
                {
                    int[] _IndexRowSelected = gridView1.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grdItem.DataSource;
                    l_Item_Name = tmp.Rows[_CurIndexRow]["Name"];
                    if (ItemDao.Delete(_ConfigItem, CnvToInt32(tmp.Rows[_CurIndexRow]["Id"])))
                    {
                        Initdata(l_Str_Item, 0);
                    }
                }
                catch (Exception ex)
                {
                    AppDebug(ex);
                    ShowMessageBox("ITEM_E_004", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, l_Item_Name);
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

        }
    }
}