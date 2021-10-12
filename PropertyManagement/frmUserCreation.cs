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
using PropertyManagement.Model.proModel;
using System.Data.Entity.Core.Objects;

namespace PropertyManagement
{
    public partial class frmUserCreation : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        List<View_user_with_role> _View_user_with_role;
        bool isnew = false;
        public frmUserCreation()
        {
            InitializeComponent();
            cmb_role.Properties.DataSource = db.tbl_UserRole.ToList();
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
               // btn_cancel.Visibility = menu.CHST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            }
        }
        private void RefreshSources()
        {
            PropertyEntities db1 = new PropertyEntities();
            //searchLookUpEdit1.Enabled = radioGroup1.EditValue.ToString() == "Main" ? true : false;
            _View_user_with_role = db1.View_user_with_role.ToList();
            //cmb_type.Properties.Items.AddRange(_tbl_List.Select(x => x.Type).Distinct().ToList());
            //cmb_type.Properties.DisplayMember = "Type";
            //cmb_type.Properties.ValueMember = "Type";

            gridControl1.DataSource = _View_user_with_role;

            if (gridView1.RowCount > 0)
            {
                View_user_with_role idu = (View_user_with_role)gridView1.GetRow(gridView1.FocusedRowHandle);
                //cmb_type.EditValue = idu.Type;
                setFields(idu);
            }
            makereadonly(true);

            //searchLookUpEdit2.Properties.DataSource = db.tbl_Projects.Where(x => x.Main_Sub == "Sub").ToList();
        }
        private void setFields(View_user_with_role uwr)
        {
            cmb_role.EditValue = uwr.fkRoleID;
             txt_name.EditValue = uwr.NAME;
            txt_name.Tag = uwr.UserID;
            txt_userName.EditValue = uwr.UserName;
            txt_password.EditValue = uwr.PWD;
            txt_cPassword.EditValue = uwr.CPWD;
            chk_active.EditValue = uwr.ActiveYN.Equals("1", StringComparison.OrdinalIgnoreCase) ? true : false;
            txt_remark.EditValue = uwr.RMKS;
        }
        private void clearfields()
        {
            cmb_role.EditValue = "";
            txt_name.EditValue = "";
            txt_name.Tag = null;
            txt_userName.EditValue = "";
            txt_password.EditValue = "";
            txt_cPassword.EditValue = "";
            txt_remark.EditValue = "";
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
        private void frmUserCreation_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            View_user_with_role uwr = (View_user_with_role)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (uwr != null)
            {

                setFields(uwr);
                makereadonly(true);
            }
        }

        private void btn_create_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = true;
            txt_name.Tag = null;
            clearfields();
            makereadonly(false);
        }

        private void btn_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            makereadonly(false);
        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!txt_password.Text.Equals(txt_cPassword.Text))
            {
                XtraMessageBox.Show("Confirm password is not match!");
                return;
            }
            if (isnew)
            {
                try
                {


                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));



                    db.Pro_IDU_UserLogin("insert", null,cmb_role.EditValue.ToString(),txt_name.Text,txt_remark.Text,txt_userName.Text,
                        txt_password.Text,txt_cPassword.Text, chk_active.Checked ? "1" : "0",pARM_ERROR_MESSAGE);


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
                        db.Pro_IDU_UserLogin("update", txt_name.Tag.ToString(), cmb_role.EditValue.ToString(), txt_name.Text, txt_remark.Text, txt_userName.Text,
                        txt_password.Text, txt_cPassword.Text, chk_active.Checked ? "1" : "0", pARM_ERROR_MESSAGE);


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
                        db.Pro_IDU_UserLogin("delete", txt_name.Tag.ToString(), cmb_role.EditValue.ToString(), txt_name.Text, txt_remark.Text, txt_userName.Text,
                        txt_password.Text, txt_cPassword.Text, chk_active.Checked ? "1" : "0", pARM_ERROR_MESSAGE);


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

        private void cmb_role_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}