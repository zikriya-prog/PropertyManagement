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
using System.IO;

namespace PropertyManagement
{
    public partial class frmProject : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        bool isnew = false;
        byte[] mapImage = null;
        public frmProject()
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
                btn_cancel.Visibility = menu.CHST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            }
        }
        private void RefreshSources()
        {
            PropertyEntities db1 = new PropertyEntities();
            //searchLookUpEdit1.Enabled = radioGroup1.EditValue.ToString() == "Main" ? true : false;
            gridControl1.DataSource = db1.tbl_Projects.ToList();
            searchLookUpEdit1.Properties.DataSource = db1.tbl_Projects.Where(x => x.Main_Sub == "Main").ToList();
            if (gridView1.RowCount > 0)
                setFields((tbl_Projects)gridView1.GetRow(gridView1.FocusedRowHandle));
            makereadonly(true);

            //searchLookUpEdit2.Properties.DataSource = db.tbl_Projects.Where(x => x.Main_Sub == "Sub").ToList();
        }
        private void clearfields()
        {
            foreach (var cont in layoutControl1.Controls)
            {
                if (cont is TextEdit)
                {

                    ((TextEdit)cont).ResetText();
                }
                else if (cont is CheckEdit)
                {

                    ((CheckEdit)cont).Checked = false;
                }
                else if (cont is PictureEdit)
                {

                    ((PictureEdit)cont).Image = null;
                }
            }

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
            btn_chooseFile.Enabled = !isActive;
        }

        private void setFields(tbl_Projects _tbl_Projects)
        {
            searchLookUpEdit1.EditValue = _tbl_Projects.ParentID;
            txt_projectName.Tag = _tbl_Projects.ProjectID;
            txt_projectName.Text = _tbl_Projects.ProjectName;
            cmb_areaType.Text = _tbl_Projects.AreaType;
            txt_totalArea.Text = _tbl_Projects.TotalArea.ToString();
            cmb_projectType.Text = _tbl_Projects.ProjectType;
            mapImage = _tbl_Projects.MapIMG;

            pic_map.Image = mapImage == null ? null : Image.FromStream(new MemoryStream(mapImage));
            memo_projectAddress.Text = _tbl_Projects.ProjectAddress;
            radioGroup1.EditValue = _tbl_Projects.Main_Sub;
        }
        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmProject_Load(object sender, EventArgs e)
        {

        }

        private void btn_create_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
            isnew = true;
            txt_projectName.Tag = null;
            pic_map.Tag = null;
            clearfields();
            makereadonly(false);
        }
        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            searchLookUpEdit1.Enabled = radioGroup1.EditValue.ToString() == "Main" ? false : true;
        }
        private string getNullOnEmptyString(string str)
        {
            return str == "" ? null : str;
        }


        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isnew)
            {
                if (radioGroup1.EditValue.ToString() == "Sub" && searchLookUpEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Please Select Project");
                    return;
                }
                ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                db.Pro_IDU_Projects("insert",
                    getNullOnEmptyString(radioGroup1.EditValue.ToString() == "Main" ? "" : searchLookUpEdit1.EditValue.ToString()),
                    getNullOnEmptyString(""),

                    txt_projectName.Text, memo_projectAddress.Text,
                cmb_areaType.Text, txt_totalArea.Text, mapImage, cmb_projectType.Text,
                radioGroup1.EditValue.ToString(), "1", loginModel.PARM_USER_ID.Value.ToString(),
                DateTime.Now, getNullOnEmptyString(""), null, pARM_ERROR_MESSAGE);
                XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());
                RefreshSources();
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_projectName.Tag.ToString()))
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to Update?"), "Update", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        db.Pro_IDU_Projects("update",
                        getNullOnEmptyString(txt_projectName.Tag.ToString()),
                        getNullOnEmptyString(""),

                        txt_projectName.Text, memo_projectAddress.Text,
                        cmb_areaType.Text, txt_totalArea.Text, mapImage, cmb_projectType.Text,
                        radioGroup1.EditValue.ToString(), "1", loginModel.PARM_USER_ID.Value.ToString(),
                        DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE);
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

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var _projectslist = (tbl_Projects)gridView1.GetRow(e.RowHandle);
            setFields(_projectslist);
            makereadonly(true);
        }

        private void btn_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_projectName.Tag.ToString()))
            {
                DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to delete {0}?", txt_projectName.Text), "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    db.Pro_IDU_Projects("delete",
                    getNullOnEmptyString(txt_projectName.Tag.ToString()),
                    getNullOnEmptyString(""),

                    txt_projectName.Text, memo_projectAddress.Text,
                    cmb_areaType.Text, txt_totalArea.Text, mapImage, cmb_projectType.Text,
                    radioGroup1.EditValue.ToString(), "1", loginModel.PARM_USER_ID.Value.ToString(),
                    DateTime.Now, getNullOnEmptyString(""), null, pARM_ERROR_MESSAGE);
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
            isnew = false;
        }

        private void memo_projectAddress_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            makereadonly(false);
        }

        private void btn_cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = false;
            // makereadonly(false);
            RefreshSources();
        }

        private void btn_chooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Image Files",
                Filter = "Image files (*.png)|*.png",

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap myBitmap = new Bitmap(openFileDialog1.FileName);
                pic_map.Image = myBitmap;

                mapImage = File.ReadAllBytes(openFileDialog1.FileName);

                pic_map.Tag = openFileDialog1.FileName;
            }
        }
    }
}