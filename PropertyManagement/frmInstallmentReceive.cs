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
    public partial class frmInstallmentReceive : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        bool isnew = false;
        List<View_CustomerFileBooking> customerList;
        View_Installment_Receive _View_Installment_Receive = null;
        List<tbl_List> _tbl_list;
        public frmInstallmentReceive()
        {
            InitializeComponent();
            RefreshSources(0);
            _tbl_list = db.tbl_List.ToList();
            //"G:\\FreeLance\\PropertyManagement\\PropertyManagement\\bin\\Debug\\mylayout"
            //if(File.Exists("mylayout"))
            //layoutControl1.RestoreLayoutFromXml("mylayout");
            cmb_paymentMethod.Properties.Items.AddRange(_tbl_list.Where(x => x.Type == "PayMode").Select(x => x.Name).ToList());
            loadUserRights(this.Tag.ToString());
        }
        private void loadUserRights(string tag)
        {
            tbl_userMenu menu = loginModel.userMenus.FirstOrDefault(x => x.fkMenuID == tag);
            if (menu != null)
            {
                btn_create.Visibility = menu.INST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                //btn_update.Visibility = menu.UPST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                //btn_delete.Visibility = menu.DLST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btn_save.Visibility = menu.INST == "1" || menu.UPST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                //btn_cancel.Visibility = menu.CHST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            }
        }
        private void RefreshSources(long filebookId)
        {
            PropertyEntities db1 = new PropertyEntities();
            //cmb_plotCat.Properties.DataSource = db.tbl_List.Where(x => x.Type == "PlotCat").ToList();
            //cmb_plotCat.Properties.DisplayMember = "Name";
            //cmb_plotCat.Properties.ValueMember = "Description";

            //gridControl1.DataSource = db1.tbl_InstMaster.ToList();
            //searchLookUpEdit_file.Properties.DataSource = fileList = db1.tbl_Files.ToList();
            searchLookUpEdit_customerfile.Properties.DataSource = customerList = db1.View_CustomerFileBooking.ToList();

            //vGridControl1.DataSource = customerList.Take(1).ToList();
            if (filebookId > 0)
            {
                gridControl1.DataSource = db1.View_Installment_Receive.Where(x => x.FileBookID == filebookId).ToList();
            }
            //makereadonly(true);
            //clearfields();
        }
        private void clearfields()
        {
            foreach (var cont in layoutControl1.Controls)
            {
                if (cont is TextEdit)
                {
                    TextEdit tx = ((TextEdit)cont);
                    if (tx.Properties.Tag == "n")
                        tx.Text = "0";
                    else if (tx.Name == "cmb_paymentMethod")
                    {

                    }
                    else
                    {
                        tx.ResetText();
                    }

                }
                else if (cont is CheckEdit)
                {

                    ((CheckEdit)cont).Checked = false;
                }
            }
            txt_disc.EditValue = 0.00;
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
        private void frmInstallmentReceive_Load(object sender, EventArgs e)
        {

        }
        private void setFields(View_Installment_Receive instRcv)
        {
            txt_amount.EditValue = instRcv.Total;
        }
        private void btn_create_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isnew = true;
            //txt_fileNumber.Tag = null;
            clearfields();
            //makereadonly(false);
        }

        private void searchLookUpEdit_customerfile_EditValueChanged(object sender, EventArgs e)
        {
            long filebookId = 0;
            if (Int64.TryParse(searchLookUpEdit_customerfile.EditValue.ToString(), out filebookId))
            {
                vGridControl1.DataSource = customerList.Where(x => x.FileBookID == filebookId).ToList();
                PropertyEntities db1 = new PropertyEntities();
                gridControl1.DataSource = db1.View_Installment_Receive.Where(x => x.FileBookID == filebookId).ToList();
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //var _View_Installment_Receive = (View_Installment_Receive)gridView3.GetRow(e.RowHandle);
            //if (_View_Installment_Receive != null)
            //{
            //    if(_View_Installment_Receive.InstRcvID != null)
            //    {
            //        XtraMessageBox.Show("Installment Already Received!");
            //    }
            //   // setFields(_View_Installment_Receive);
            //    makereadonly(true); 
            //}
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            _View_Installment_Receive = (View_Installment_Receive)gridView3.GetRow(gridView3.FocusedRowHandle);
            if (_View_Installment_Receive != null)
            {
                if (_View_Installment_Receive.InstRcvID != null)
                {
                    XtraMessageBox.Show("Installment Already Received!");
                }
                else
                {
                    setFields(_View_Installment_Receive);
                }
                // setFields(_View_Installment_Receive);
                // makereadonly(true);
            }
        }

        private void btn_receive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (isnew)
            //{
            try
            {


                if (searchLookUpEdit_customerfile.EditValue == "")
                {
                    XtraMessageBox.Show("Please Select File");
                    return;
                }

                if (_View_Installment_Receive == null)
                {
                    XtraMessageBox.Show("Please Select Installment");
                    return;
                }

                DialogResult dr = XtraMessageBox.Show("Are you sure you want to receive this installment?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    ObjectParameter pARAM_New_instRcvID = new ObjectParameter("pARAM_New_instRcvID", typeof(string));
                    db.Pro_IDU_InstReceived("insert", null, _View_Installment_Receive.fkFileID, _View_Installment_Receive.instDID, _View_Installment_Receive.srno, Convert.ToInt32(txt_total.EditValue), _View_Installment_Receive.Amount,
                        _View_Installment_Receive.CustomAmount, Convert.ToInt32(txt_disc.EditValue), Convert.ToInt32(txt_discAmount.EditValue), _View_Installment_Receive.InstType, cmb_paymentMethod.Text,
                        loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE, pARAM_New_instRcvID);


                    XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());


                    RefreshSources(_View_Installment_Receive.FileBookID);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
                return;
            }
            // }
        }

        private void txt_disc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txt_discAmount.EditValue = Convert.ToInt32(txt_amount.EditValue) * Convert.ToDouble(txt_disc.EditValue);
            //    txt_total.EditValue = Convert.ToInt32(txt_amount.EditValue) - (Convert.ToInt32(txt_amount.EditValue) * Convert.ToDouble(txt_disc.EditValue));
            //}
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            txt_discAmount.EditValue = Convert.ToInt32(txt_amount.EditValue) * Convert.ToDouble(txt_disc.EditValue);
            txt_total.EditValue = Convert.ToInt32(txt_amount.EditValue) - (Convert.ToInt32(txt_amount.EditValue) * Convert.ToDouble(txt_disc.EditValue));

        }
    }
}