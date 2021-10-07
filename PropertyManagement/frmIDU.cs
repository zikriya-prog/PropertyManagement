using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PropertyManagement.Model;
using System.Data.Entity.Core.Objects;
using PropertyManagement.Model.proModel;

namespace PropertyManagement
{
    public partial class frmIDU : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        List<tbl_List> _tbl_List;
        bool isnew = false;
        public frmIDU()
        {
            InitializeComponent();
            RefreshSources();
            loadUserRights(this.Tag.ToString());
        }
        private void loadUserRights(string tag)
        {
            tbl_userMenu menu = loginModel.userMenus.FirstOrDefault(x => x.fkMenuID == tag);
            if (menu != null)
            {
                btn_create.Visibility = menu.INST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btn_update.Visibility = menu.UPST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btn_delete.Visibility = menu.DLST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btn_save.Visibility = menu.INST == "1" || menu.UPST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                //btn_cancel.Visibility = menu.CHST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            }
        }
        private void RefreshSources()
        {
            PropertyEntities db1 = new PropertyEntities();
            //searchLookUpEdit1.Enabled = radioGroup1.EditValue.ToString() == "Main" ? true : false;
            _tbl_List = db.tbl_List.ToList();
            cmb_type.Properties.Items.AddRange(_tbl_List.Select(x=>x.Type).Distinct().ToList());
            //cmb_type.Properties.DisplayMember = "Type";
            //cmb_type.Properties.ValueMember = "Type";

            gridControl1.DataSource = _tbl_List;
            
            if (gridView1.RowCount > 0)
            {
                tbl_List idu = (tbl_List)gridView1.GetRow(gridView1.FocusedRowHandle);
                //cmb_type.EditValue = idu.Type;
                setFields(idu);
            }
            makereadonly(true);

            //searchLookUpEdit2.Properties.DataSource = db.tbl_Projects.Where(x => x.Main_Sub == "Sub").ToList();
        }
        private void setFields(tbl_List list)
        {
            cmb_type.EditValue = list.Type;
            txt_name.EditValue = list.Name;
            txt_name.Tag = list.id;
            txt_desc.EditValue = list.Description;
            chk_active.EditValue = list.ActiveYN.Equals("Y", StringComparison.OrdinalIgnoreCase) ? true : false;

        }
        private void clearfields()
        {
            cmb_type.SelectedIndex = 0;
            txt_name.EditValue = "";
            txt_desc.EditValue = "";
            chk_active.EditValue = true;
        }
        private void makereadonly(bool isActive)
        {

            foreach (var cont in layoutControl1.Controls)
            {
                if (cont is TextEdit)
                {
                    ((TextEdit)cont).ReadOnly = isActive;
                }
                else if (cont is CheckEdit)
                {
                    ((CheckEdit)cont).ReadOnly = isActive;
                }
                else if (cont is RadioGroup)
                {
                    ((RadioGroup)cont).ReadOnly = isActive;
                }


            }

        }
        private void frmIDU_Load(object sender, EventArgs e)
        {

        }

        private void btn_create_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = true;
            txt_name.Tag = null;
            clearfields();
            makereadonly(false);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            tbl_List idu = (tbl_List)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (idu != null)
            {
                
                setFields(idu);
                makereadonly(true);
            }
        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isnew)
            {
                try
                {

                    
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));



                    db.Pro_IDU_List("insert", null,txt_name.Text,txt_desc.Text,cmb_type.Text,chk_active.Checked?"Y":"N",
                               loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE);


                    XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());


                    RefreshSources();
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_name.Tag.ToString()))
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to Update?"), "Update", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        //tbl_Projects proj = projectList.FirstOrDefault(x => x.ProjectID == searchLookUpEdit1.EditValue.ToString());
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        db.Pro_IDU_List("update", Convert.ToInt32(txt_name.Tag), txt_name.Text, txt_desc.Text, cmb_type.Text, chk_active.Checked ? "Y" : "N",
                               loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE);


                        XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());



                        clearfields();
                    }

                    makereadonly(true);
                }
                else
                {

                    return;

                }
                RefreshSources();
            }
            isnew = false;
        }

        private void btn_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_name.Tag.ToString()))
            {
                DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to delete {0}?", txt_name.Text), "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    try
                    {
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        db.Pro_IDU_List("delete", Convert.ToInt32(txt_name.Tag),txt_name.Text,txt_desc.Text,cmb_type.Text, chk_active.Checked ? "Y" : "N",
                               loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE);


                        XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show(ex.InnerException.ToString());
                    }

                    clearfields();
                }

                makereadonly(true);
            }
            else
            {

                return;

            }
            RefreshSources();
            isnew = false;
        }

        private void btn_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            makereadonly(false);
        }
    }
}