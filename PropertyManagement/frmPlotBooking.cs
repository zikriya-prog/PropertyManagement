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
using System.IO;
using PropertyManagement.Reports;
using DevExpress.XtraReports.UI;

namespace PropertyManagement
{
    public partial class frmPlotBooking : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        bool isnew = false;
        List<tbl_Files> fileList;
        List<tbl_CustomerRegM> customerList;
        tbl_CustomerRegM customer;
        public frmPlotBooking()
        {
            InitializeComponent();
            RefreshSources();
            cmb_paymentMethod.Properties.Items.AddRange(db.tbl_List.Where(x => x.Type == "PayMode" && x.ActiveYN.Equals("Y", StringComparison.OrdinalIgnoreCase)).Select(x => x.Name).ToList());
            cmb_paymentMethod.SelectedIndex = 0;

            cmb_areaType.Properties.Items.AddRange(db.tbl_List.Where(x => x.Type == "AreaType" && x.ActiveYN.Equals("Y", StringComparison.OrdinalIgnoreCase)).Select(x => x.Name).ToList());
            cmb_areaType.SelectedIndex = 0;

            cmb_bookingStatus.Properties.Items.AddRange(db.tbl_List.Where(x => x.Type == "BookStatus" && x.ActiveYN.Equals("Y", StringComparison.OrdinalIgnoreCase)).Select(x => x.Name).ToList());
            cmb_bookingStatus.SelectedIndex = 0;
            //txt_areaSize.EditValue = 12;
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

            gridControl1.DataSource = db1.tbl_CustomerFileBook.ToList();
            searchLookUpEdit_file.Properties.DataSource = fileList = db1.tbl_Files.ToList();
            searchLookUpEdit_customer.Properties.DataSource = customerList = db1.tbl_CustomerRegM.Where(x => x.ActiveYN.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();

            if (gridView1.RowCount > 0)
            {
                tbl_CustomerFileBook FileBook = (tbl_CustomerFileBook)gridView1.GetRow(gridView1.FocusedRowHandle);
                setFields(FileBook);
            }
            makereadonly(true);
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
                else if (cont is PictureEdit)
                {

                    ((PictureEdit)cont).Image = null;
                }
            }
            cmb_paymentMethod.SelectedIndex = 0;
            cmb_areaType.SelectedIndex = 0;
            cmb_bookingStatus.SelectedIndex = 0;
        }
        private void makereadonly(bool isActive)
        {

            foreach (var cont in layoutControl1.Controls)
            {
                if (cont is TextEdit)
                {
                    //TextEdit tx = ((TextEdit)cont);
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
        private void setFields(tbl_CustomerFileBook _tbl_CustomerFileBook)
        {
            searchLookUpEdit_customer.EditValue = _tbl_CustomerFileBook.fkCustomerID;
            searchLookUpEdit_file.EditValue = _tbl_CustomerFileBook.fkFileID;
            txt_areaSize.EditValue = _tbl_CustomerFileBook.Area;
            cmb_areaType.EditValue = _tbl_CustomerFileBook.AreaType;
            txt_membershipNo.Text = _tbl_CustomerFileBook.MemberShipNo;
            txt_membershipNo.Tag = _tbl_CustomerFileBook.FileBookID;
            txt_price.EditValue = _tbl_CustomerFileBook.Price;
            cmb_paymentMethod.EditValue = _tbl_CustomerFileBook.PayMethod;
            txt_downPayment.EditValue = _tbl_CustomerFileBook.DownPayment;
            dateEdit_confirmation.EditValue = _tbl_CustomerFileBook.ConfirmationFeeDate;
            txt_confirmationFees.EditValue = _tbl_CustomerFileBook.ConfirmationAmount;
            txt_registrationFees.EditValue = _tbl_CustomerFileBook.RegistrationAmount;
            cmb_bookingStatus.EditValue = _tbl_CustomerFileBook.BookingStatus;
            txt_disc_price.EditValue = _tbl_CustomerFileBook.DiscountAmount;
            pic_profileImage.Image = Image.FromStream(new MemoryStream(_tbl_CustomerFileBook.tbl_CustomerRegM.CustIMG));
        }
        private void searchLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmPlotBooking_Load(object sender, EventArgs e)
        {

        }

        private void btn_create_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = true;
            // txt_fileNumber.Tag = null;
            clearfields();
            makereadonly(false);
        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isnew)
            {
                try
                {


                    customer = customerList.FirstOrDefault(x => x.CustomerID == (searchLookUpEdit_customer.EditValue != "" ? Convert.ToInt64(searchLookUpEdit_customer.EditValue) : 0));
                    tbl_Files file = fileList.FirstOrDefault(x => x.FileID == (searchLookUpEdit_file.EditValue != "" ? Convert.ToInt64(searchLookUpEdit_file.EditValue) : 0));
                    if (customer == null)
                    {
                        XtraMessageBox.Show("Please Select Customer");
                        return;
                    }

                    if (file == null)
                    {
                        XtraMessageBox.Show("Please Select File");
                        return;
                    }
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    ObjectParameter pARAM_New_FileBookID = new ObjectParameter("pARAM_New_FileBookID", typeof(string));
                    db.Pro_IDU_CustomerFileBook("insert", null, Convert.ToInt64(searchLookUpEdit_customer.EditValue), file.FileID,
                        txt_membershipNo.Text, cmb_areaType.EditValue.ToString(), Convert.ToDouble(txt_areaSize.Text), Convert.ToInt64(txt_price.Text), Convert.ToInt64(txt_downPayment.Text),
                        Convert.ToInt64(txt_confirmationFees.Text), dateEdit_confirmation.DateTime, cmb_paymentMethod.EditValue.ToString(), Convert.ToInt64(txt_registrationFees.Text), Convert.ToInt64(txt_disc_price.EditValue), cmb_bookingStatus.Text,
                        loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE, pARAM_New_FileBookID);


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
                if (!string.IsNullOrEmpty(txt_membershipNo.Tag.ToString()))
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to Update?"), "Update", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        customer = customerList.FirstOrDefault(x => x.CustomerID == (searchLookUpEdit_customer.EditValue != "" ? Convert.ToInt64(searchLookUpEdit_customer.EditValue) : 0));
                        tbl_Files file = fileList.FirstOrDefault(x => x.FileID == (searchLookUpEdit_file.EditValue != "" ? Convert.ToInt64(searchLookUpEdit_file.EditValue) : 0));
                        if (customer == null)
                        {
                            XtraMessageBox.Show("Please Select Customer");
                            return;
                        }

                        if (file == null)
                        {
                            XtraMessageBox.Show("Please Select File");
                            return;
                        }
                        //tbl_Projects proj = projectList.FirstOrDefault(x => x.ProjectID == searchLookUpEdit1.EditValue.ToString());
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        ObjectParameter pARAM_New_FileBookID = new ObjectParameter("pARAM_New_FileBookID", typeof(string));
                        db.Pro_IDU_CustomerFileBook("update", Convert.ToInt32(txt_membershipNo.Tag), Convert.ToInt64(searchLookUpEdit_customer.EditValue), file.FileID,
                            txt_membershipNo.Text, cmb_areaType.EditValue.ToString(), Convert.ToDouble(txt_areaSize.Text), Convert.ToInt64(txt_price.Text), Convert.ToInt64(txt_downPayment.Text),
                            Convert.ToInt64(txt_confirmationFees.Text), dateEdit_confirmation.DateTime, cmb_paymentMethod.EditValue.ToString(), Convert.ToInt64(txt_registrationFees.Text), Convert.ToInt64(txt_disc_price.EditValue), cmb_bookingStatus.Text,
                            loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE, pARAM_New_FileBookID);


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

        private void searchLookUpEdit_customer_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit_customer.EditValue != null)
            {
                customer = customerList.FirstOrDefault(x => x.CustomerID == (searchLookUpEdit_customer.EditValue.ToString() != "" ? Convert.ToInt64(searchLookUpEdit_customer.EditValue) : 0));
                if (customer != null)
                {
                    lbl_customerName.Text = customer.CustomerName;
                    lbl_fatherName.Text = customer.FatherName;
                    lbl_mobile.Text = customer.Mobile;
                    pic_profileImage.Image = customer.CustIMG == null ? null : Image.FromStream(new MemoryStream(customer.CustIMG));
                }
            }

        }

        private void btn_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_membershipNo.Tag.ToString()))
            {
                DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to delete {0}?", txt_membershipNo.Text), "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    customer = customerList.FirstOrDefault(x => x.CustomerID == (searchLookUpEdit_customer.EditValue != "" ? Convert.ToInt64(searchLookUpEdit_customer.EditValue) : 0));
                    tbl_Files file = fileList.FirstOrDefault(x => x.FileID == (searchLookUpEdit_file.EditValue != "" ? Convert.ToInt64(searchLookUpEdit_file.EditValue) : 0));
                    if (customer == null)
                    {
                        XtraMessageBox.Show("Please Select Customer");
                        return;
                    }

                    if (file == null)
                    {
                        XtraMessageBox.Show("Please Select File");
                        return;
                    }
                    //tbl_Projects proj = projectList.FirstOrDefault(x => x.ProjectID == searchLookUpEdit1.EditValue.ToString());
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    ObjectParameter pARAM_New_FileBookID = new ObjectParameter("pARAM_New_FileBookID", typeof(string));
                    db.Pro_IDU_CustomerFileBook("delete", Convert.ToInt32(txt_membershipNo.Tag), Convert.ToInt64(searchLookUpEdit_customer.EditValue), file.FileID,
                        txt_membershipNo.Text, cmb_areaType.EditValue.ToString(), Convert.ToDouble(txt_areaSize.Text), Convert.ToInt64(txt_price.Text), Convert.ToInt64(txt_price.Text),
                        Convert.ToInt64(txt_price.Text), dateEdit_confirmation.DateTime, cmb_paymentMethod.EditValue.ToString(), Convert.ToInt64(txt_registrationFees.Text), Convert.ToInt64(txt_disc_price.EditValue), cmb_bookingStatus.Text,
                        loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE, pARAM_New_FileBookID);


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

        private void btn_cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = false;
            // makereadonly(false);
            RefreshSources();
            customer = null;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var _customerfile = (tbl_CustomerFileBook)gridView1.GetRow(e.RowHandle);
            setFields(_customerfile);
            makereadonly(true);
        }

        private void searchLookUpEdit_file_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit_file.EditValue != null)
            {
                tbl_Files fl = fileList.FirstOrDefault(x => x.FileID == (searchLookUpEdit_file.EditValue.ToString() != "" ? Convert.ToInt64(searchLookUpEdit_file.EditValue) : 0));
                if (fl != null)
                {

                    txt_areaSize.EditValue = fl.AreaSize;
                    cmb_areaType.EditValue = fl.AreaType;
                    txt_membershipNo.EditValue = fl.FileNumber;
                    txt_price.EditValue = fl.TotalPloValue;
                    txt_confirmationFees.EditValue = fl.ConfirmationAmount;
                    txt_downPayment.EditValue = fl.BookingAmount;
                    txt_registrationFees.EditValue = fl.DevelopmentCharges;
                }
            }
        }

        private void btn_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            makereadonly(false);
        }

        private void btn_Certificate_Click(object sender, EventArgs e)
        {
            if (txt_membershipNo.EditValue != null && searchLookUpEdit_customer.EditValue != null)
            {
                tbl_Files fl = fileList.FirstOrDefault(x => x.FileID == (searchLookUpEdit_file.EditValue.ToString() != "" ? Convert.ToInt64(searchLookUpEdit_file.EditValue) : 0));
                PROVISIONAL_ALLOTMENT_CERTIFICATE report = new PROVISIONAL_ALLOTMENT_CERTIFICATE();

                report.Parameters["parm_Name"].Value = customer.CustomerName;
                report.Parameters["parm_cnic"].Value = customer.CNIC;
                report.Parameters["parm_membership_no"].Value = txt_membershipNo.EditValue.ToString();
                report.Parameters["parm_project"].Value = fl.tbl_Projects.ProjectName;
                report.Parameters["parm_areatype"].Value = cmb_areaType.Text;
                report.Parameters["parm_areasize"].Value = txt_areaSize.Text;
                
                report.RequestParameters = false;
                ReportPrintTool pt = new ReportPrintTool(report);
                pt.AutoShowParametersPanel = false;

                pt.ShowPreviewDialog();
            }
        }
    }
}