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
    public partial class frmFiles : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        List<tbl_Projects> projectList;
        bool isnew = false;
        public frmFiles()
        {
            InitializeComponent();
            RefreshSources();
            cmb_plotCategory.Properties.Items.AddRange(db.tbl_List.Where(x => x.Type == "PlotCat").Select(x=>x.Name).ToList());
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
            
            
            gridControl1.DataSource = db1.tbl_Files.ToList();
            projectList = db1.tbl_Projects.ToList();
            if (gridView2.RowCount > 0)
            {
                tbl_Files file = (tbl_Files)gridView2.GetRow(gridView2.FocusedRowHandle);
                var proj = projectList.FirstOrDefault(x=>x.ProjectID == file.fkProjectId);
                searchLookUpEdit1.Properties.DataSource = projectList.Where(x => x.Main_Sub.Equals(proj.Main_Sub, StringComparison.OrdinalIgnoreCase)).ToList();
                setFields(file, proj);
            }
            makereadonly(true);

            //searchLookUpEdit2.Properties.DataSource = db.tbl_Projects.Where(x => x.Main_Sub == "Sub").ToList();
        }
        private void setFields(tbl_Files _tbl_Files,tbl_Projects _tbl_Projects)
        {
            radioGroup1.EditValue = _tbl_Projects.Main_Sub;

            searchLookUpEdit1.EditValue = _tbl_Files.fkProjectId;
            txt_fileNumber.Tag = _tbl_Files.FileID;
            txt_fileNumber.Text = _tbl_Files.FileNumber;
            txt_block.Text = _tbl_Files.Block;
            cmb_plotCategory.EditValue = _tbl_Files.PlotCat;
            txt_plotFactor.Text = _tbl_Files.Plot_Factor;
            txt_plotno.Text = _tbl_Files.PlotNo;
            txt_plotSize.EditValue = _tbl_Files.PlotSize;
            txt_confimationFees.EditValue = _tbl_Files.ConfirmationFee;
            txt_plotRate.EditValue = _tbl_Files.PlotRate;
            txt_autoPlotNo.Text = _tbl_Files.AutoPlotNo;
            txt_plotRate.EditValue = _tbl_Files.PlotRate;
            txt_totalPlotValue.EditValue = _tbl_Files.TotalPloValue;
            //txt_plotStatus.EditValue = _tbl_Files.FileStatus;
            txt_plotValue.Text = _tbl_Files.PlotValue;
            txt_plotExtCharges.EditValue = _tbl_Files.PlotExtChargs;
            txt_unitStatus.Text = _tbl_Files.UnitStatus;
        }
        private void clearfields()
        {
            foreach (var cont in layoutControl1.Controls)
            {
                if (cont is TextEdit)
                {

                    ((TextEdit)cont).EditValue = null;
                }
                else if (cont is CheckEdit)
                {

                    ((CheckEdit)cont).Checked = false;
                }
            }
            //gridControl2.DataSource = null;
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
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.DataSource = projectList.Where(x => x.Main_Sub == radioGroup1.EditValue.ToString()).ToList();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var _file = (tbl_Files)gridView2.GetRow(e.RowHandle);
            var proj = projectList.FirstOrDefault(x => x.ProjectID == _file.fkProjectId);
            setFields(_file, proj);
            makereadonly(true);
        }

        private void btn_create_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = true;
            txt_fileNumber.Tag = null;
            clearfields();
            makereadonly(false);
        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isnew)
            {
                try
                {

                    //tbl_Projects proj = (tbl_Projects)searchLookUpEdit1View.GetRow(searchLookUpEdit1View.FocusedRowHandle);
                    if (searchLookUpEdit1.EditValue == null)
                    {
                        XtraMessageBox.Show("Please Select Project");
                        return;
                    }
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));



                    db.Pro_IDU_Files("insert", null,
                               txt_fileNumber.Text, searchLookUpEdit1.EditValue.ToString(), txt_block.Text, cmb_plotCategory.Text, txt_plotFactor.Text, txt_plotno.Text,
                               Convert.ToDouble(txt_plotSize.EditValue), Convert.ToInt64(txt_confimationFees.EditValue), txt_autoPlotNo.Text,
                               Convert.ToDouble(txt_plotRate.EditValue), Convert.ToInt64(txt_totalPlotValue.EditValue), cmb_plotCategory.EditValue.ToString(), 
                               txt_plotStatus.Text, Convert.ToInt64(txt_plotValue.EditValue), Convert.ToInt32(txt_plotExtCharges.EditValue), txt_unitStatus.Text, 
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
                if (!string.IsNullOrEmpty(txt_fileNumber.Tag.ToString()))
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to Update?"), "Update", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        //tbl_Projects proj = projectList.FirstOrDefault(x => x.ProjectID == searchLookUpEdit1.EditValue.ToString());
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        db.Pro_IDU_Files("update", Convert.ToInt32(txt_fileNumber.Tag),
                               txt_fileNumber.Text, searchLookUpEdit1.EditValue.ToString(), txt_block.Text, cmb_plotCategory.Text, txt_plotFactor.Text, txt_plotno.Text,
                               Convert.ToDouble(txt_plotSize.EditValue), Convert.ToInt64(txt_confimationFees.EditValue), txt_autoPlotNo.Text,
                               Convert.ToDouble(txt_plotRate.EditValue), Convert.ToInt64(txt_totalPlotValue.EditValue), cmb_plotCategory.EditValue.ToString(),
                               txt_plotStatus.Text, Convert.ToInt64(txt_plotValue.EditValue), Convert.ToInt32(txt_plotExtCharges.EditValue), txt_unitStatus.Text,
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            makereadonly(false);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_fileNumber.Tag.ToString()))
            {
                DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to delete {0}?", txt_fileNumber.Text), "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    try
                    {
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        db.Pro_IDU_Files("delete", Convert.ToInt32(txt_fileNumber.Tag),
                               null, searchLookUpEdit1.EditValue.ToString(), txt_block.Text, cmb_plotCategory.Text, txt_plotFactor.Text, txt_plotno.Text,
                               Convert.ToDouble(txt_plotSize.EditValue), Convert.ToInt64(txt_confimationFees.EditValue), txt_autoPlotNo.Text,
                               Convert.ToDouble(txt_plotRate.EditValue), Convert.ToInt64(txt_totalPlotValue.EditValue), cmb_plotCategory.EditValue.ToString(),
                               txt_plotStatus.Text, Convert.ToInt64(txt_plotValue.EditValue), Convert.ToInt32(txt_plotExtCharges.EditValue), txt_unitStatus.Text,
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

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = false;
            // makereadonly(false);
            RefreshSources();
        }

        private void frmFiles_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}