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
using System.IO;
using PropertyManagement.Model.proModel;

namespace PropertyManagement
{
    public partial class frmInstallmentPlan : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        bool isnew = false;
        List<View_CustomerFileBooking> customerList;
        List<tbl_List> _tbl_list;
        public frmInstallmentPlan()
        {
            InitializeComponent();
            RefreshSources();
            _tbl_list = db.tbl_List.ToList();
            //"G:\\FreeLance\\PropertyManagement\\PropertyManagement\\bin\\Debug\\mylayout"
            //if(File.Exists("mylayout"))
            //layoutControl1.RestoreLayoutFromXml("mylayout");Custom Time
            
            cmb_instType.Properties.DataSource = _tbl_list.Where(x => x.Type == "Instalment Type").ToList();
            
            cmb_customTime.Properties.DataSource = _tbl_list.Where(x => x.Type == "Instalment Type").ToList();
            
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
            //cmb_plotCat.Properties.DataSource = db.tbl_List.Where(x => x.Type == "PlotCat").ToList();
            //cmb_plotCat.Properties.DisplayMember = "Name";
            //cmb_plotCat.Properties.ValueMember = "Description";

             gridControl1.DataSource = db1.tbl_InstMaster.ToList();
             //searchLookUpEdit_file.Properties.DataSource = fileList = db1.tbl_Files.ToList();
             searchLookUpEdit_customerfile.Properties.DataSource = customerList = db1.View_CustomerFileBooking.ToList();
             vGridControl1.DataSource = customerList.Take(1).ToList();
            
            if (gridView1.RowCount > 0)
            {
                tbl_InstMaster FileBook = (tbl_InstMaster)gridView1.GetRow(gridView1.FocusedRowHandle);
                setFields(FileBook);
            }
            makereadonly(true);
        }
        private void setFields(tbl_InstMaster _tbl_InstMaster)
        {
            searchLookUpEdit_customerfile.EditValue = _tbl_InstMaster.fkFileID;
            txt_customAmount.EditValue = _tbl_InstMaster.CustomAmount;
            txt_customPeriod.EditValue = _tbl_InstMaster.CustomPeriod;
            cmb_customTime.EditValue = _tbl_InstMaster.CustomTime;
            cmb_instType.EditValue = _tbl_InstMaster.Type;
            dateEdit_instDate.EditValue = _tbl_InstMaster.DateOfInst;
            txt_instAmount.EditValue = _tbl_InstMaster.InstAmount;
            radioGroup_instNature.EditValue = _tbl_InstMaster.Nature;
            txt_noOfinst.EditValue = _tbl_InstMaster.NoOfInst;
            txt_noOfinst.Tag = _tbl_InstMaster.InstMId;
            
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
        private void frmInstallmentPlan_Load(object sender, EventArgs e)
        {

        }

        private void btn_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = true;
            //txt_fileNumber.Tag = null;
            clearfields();
            makereadonly(false);
            radioGroup_instNature.EditValue = "Duration";
            radioselection(true);
        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isnew)
            {
                try
                {
                   // Convert.ToInt32(txt_noOfinst.EditValue)

                    View_CustomerFileBooking cfb = (View_CustomerFileBooking)gridView_customerfile.GetRow(gridView_customerfile.FocusedRowHandle);

                   


                    if (cfb == null)
                    {
                        XtraMessageBox.Show("Please Select Customer File");
                        return;
                    }

                    if(dateEdit_instDate.DateTime.Day > 28)
                    {
                        XtraMessageBox.Show("Please Select Valid Date");
                        return;
                    }
                    if (cmb_customTime.EditValue == null)
                    {
                        XtraMessageBox.Show("Please Select Custom Time");
                        return;
                    }
                    if (cmb_instType.EditValue == null)
                    {
                        XtraMessageBox.Show("Please Select Installment Type");
                        return;
                    }
                    long plotvalue = cfb.Price.Value - cfb.DownPayment.Value-cfb.ConfirmationAmount.Value-cfb.DiscountAmount.Value;
                    long instprice = plotvalue - ((Convert.ToInt32(txt_noOfinst.Text) / Convert.ToInt32(cmb_customTime.EditValue)) * Convert.ToInt64(txt_customAmount.Text));
                    instprice = instprice / Convert.ToInt32(txt_noOfinst.Text);

                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    ObjectParameter pARAM_New_InstMId = new ObjectParameter("pARAM_New_InstMId", typeof(string));
                    ObjectParameter pARAM_New_instDID = new ObjectParameter("pARAM_New_instDID", typeof(string));



                    db.Pro_IDU_InstMaster("insert", null, cfb.fkFileID, cmb_instType.Text, dateEdit_instDate.DateTime, radioGroup_instNature.EditValue.ToString(),
                        Convert.ToInt32(txt_noOfinst.EditValue), instprice, Convert.ToInt32(txt_customPeriod.EditValue),
                        Convert.ToInt64(txt_customAmount.EditValue), cmb_customTime.Text,
                               loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE, pARAM_New_InstMId);
                    if (pARAM_New_InstMId.Value != null)
                    {
                        DateTime dueDate = dateEdit_instDate.DateTime;
                        int noofinst = 0;
                        Int32.TryParse(txt_noOfinst.EditValue.ToString(), out noofinst);
                        int customamount = 0;
                        for (int i = 1; i <= noofinst; i++)
                        {
                            if (i % Convert.ToInt32(cmb_customTime.EditValue) == 0)
                                customamount = Convert.ToInt32(txt_customAmount.EditValue);
                            else
                                customamount = 0;

                            db.Pro_IDU_InstDetail("insert", null, Convert.ToInt64(pARAM_New_InstMId.Value), i, instprice + customamount,
                                instprice, customamount, dueDate, cmb_instType.Text,
                                   loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE, pARAM_New_instDID);
                            dueDate = dueDate.AddMonths(1);
                        }

                    }

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
                if (!string.IsNullOrEmpty(txt_noOfinst.Tag.ToString()))
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to Update?"), "Update", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        //tbl_Projects proj = projectList.FirstOrDefault(x => x.ProjectID == searchLookUpEdit1.EditValue.ToString());
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        //db.Pro_IDU_Files("update", Convert.ToInt32(txt_fileNumber.Tag),
                        //       txt_fileNumber.Text, searchLookUpEdit1.EditValue.ToString(), txt_block.Text, cmb_plotCat.Text, txt_plotFactor.Text, txt_plotno.Text,
                        //       Convert.ToDouble(txt_plotSize.EditValue), Convert.ToInt64(txt_confimationFees.EditValue), txt_autoPlotNo.Text,
                        //       Convert.ToDouble(txt_plotRate.EditValue), Convert.ToInt64(txt_totalPlotValue.EditValue), cmb_plotCat.EditValue.ToString(),
                        //       txt_plotStatus.Text, Convert.ToInt64(txt_plotValue.EditValue), Convert.ToInt32(txt_plotExtCharges.EditValue), txt_unitStatus.Text,
                        //       loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE);


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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var _instMaster = (tbl_InstMaster)gridView1.GetRow(e.RowHandle);
            setFields(_instMaster);
            makereadonly(true);
        }

        private void frmInstallmentPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //layoutControl1.SaveLayoutToXml("mylayout");
        }

        private void searchLookUpEdit_customerfile_EditValueChanged(object sender, EventArgs e)
        {
            long filebookId = 0;
            if (searchLookUpEdit_customerfile.EditValue != null)
            {
                if (Int64.TryParse(searchLookUpEdit_customerfile.EditValue.ToString(), out filebookId))
                {
                    vGridControl1.DataSource = customerList.Where(x => x.FileBookID == filebookId).ToList();
                    PropertyEntities db1 = new PropertyEntities();
                    var cimg = db1.View_Installment_Receive.FirstOrDefault(x => x.FileBookID == filebookId);
                    if (cimg != null)
                        pictureEdit1.Image = Image.FromStream(new MemoryStream(cimg.CustIMG));
                } 
            }
        }

        private void btn_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            makereadonly(false);
        }

        private void radioGroup_instNature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_instAmount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_customAmount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_2(object sender, EventArgs e)
        {

        }

        private void btn_receive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void radioselection(bool enable)
        {
            txt_noOfinst.Enabled = enable;
            txt_instAmount.Enabled = !enable;
        }
        private void radioGroup_instNature_EditValueChanged(object sender, EventArgs e)
        {
            if(radioGroup_instNature.EditValue.ToString().Equals("Amount"))
            {
                radioselection(false);
            }
            else
            {
                radioselection(true);
            }
        }
    }
}