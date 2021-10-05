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
using DevExpress.XtraLayout;
using System.IO;
using System.Data.Entity.Core.Objects;
using PropertyManagement.Model.proModel;
using PropertyManagement.Model.tblModel;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;

namespace PropertyManagement
{
    public partial class frmCustomerRegisteration : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        //BindingList<kinModel> kinModelBindList = new BindingList<kinModel>();
        List<tbl_Projects> projectList;
        bool isnew = false;
        byte[] customerImage = null, cnicFImage = null, cnicBImage = null;
        public frmCustomerRegisteration()
        {
            InitializeComponent();
            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);
            RefreshSources();
            //gridControl2.DataSource = kinModelBindList;
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
            gridControl1.DataSource = db1.tbl_CustomerRegM.ToList();
            projectList = db1.tbl_Projects.ToList();
            if (gridView1.RowCount > 0)
            {
                tbl_CustomerRegM cut_reg = (tbl_CustomerRegM)gridView1.GetRow(gridView1.FocusedRowHandle);
                var test = projectList.Where(x => x.Main_Sub.Equals((cut_reg.SubProjID == null ? "Main" : "Sub"), StringComparison.OrdinalIgnoreCase)).Count();
                searchLookUpEdit1.Properties.DataSource = projectList.Where(x => x.Main_Sub.Equals((cut_reg.SubProjID == null ? "Main" : "Sub"), StringComparison.OrdinalIgnoreCase)).ToList();
                setFields(cut_reg);
            }
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
                else if (cont is SimpleButton)
                {
                    ((SimpleButton)cont).Enabled = !isActive;
                }

            }
            gridControl2.Enabled = !isActive;
            //layoutControlGroup2.Enabled = !isActive;
        }
        private List<kinModel> getkinListFromGrid()
        {
            List<kinModel> kin_list = new List<kinModel>();
            int rowHandle = 0;
            while (gridView_kin.IsValidRowHandle(rowHandle))
            {
                kin_list.Add((kinModel)gridView_kin.GetRow(rowHandle));
                //bool isSelected = gridView1.IsRowSelected(rowHandle);
                rowHandle++;
            }

            return kin_list;
        }

        private void setkinGrid(List<kinModel> _kinmodel)
        {
            gridControl2.DataSource = _kinmodel;
        }
        private string getNullOnEmptyString(string str)
        {
            return str == "" ? null : str;
        }
        private void setFields(tbl_CustomerRegM _tbl_CustomerRegM)
        {
            radioGroup1.EditValue = _tbl_CustomerRegM.SubProjID == null ? "Main" : "Sub";
            searchLookUpEdit1.EditValue = _tbl_CustomerRegM.fkProjectID;
            //searchLookUpEdit2.EditValue = _tbl_CustomerRegM.SubProjID;


            txt_customerName.Tag = _tbl_CustomerRegM.CustomerID;
            txt_customerName.Text = _tbl_CustomerRegM.CustomerName;
            txt_fatherName.Text = _tbl_CustomerRegM.FatherName;
            txt_cnic.Text = _tbl_CustomerRegM.CNIC;
            txt_mobile.Text = _tbl_CustomerRegM.Mobile;
            txt_phoneNo.Text = _tbl_CustomerRegM.OfficeNumber;
            memo_presentAddress.Text = _tbl_CustomerRegM.PresentAddress;
            memo_permanentAddress.Text = _tbl_CustomerRegM.PermAddress;
            customerImage = _tbl_CustomerRegM.CustIMG;
            isDealer.Checked = _tbl_CustomerRegM.DealerYN.Equals("Y", StringComparison.OrdinalIgnoreCase) ? true : false;
            isActive.Checked = _tbl_CustomerRegM.ActiveYN.Equals("Y", StringComparison.OrdinalIgnoreCase) ? true : false;
            pic_photo.Image = customerImage == null ? null : Image.FromStream(new MemoryStream(customerImage));
            cnicFImage = _tbl_CustomerRegM.CNICFrontIMG;
            pic_cnicFront.Image = cnicFImage == null ? null : Image.FromStream(new MemoryStream(cnicFImage));
            cnicBImage = _tbl_CustomerRegM.CNICBackIMG;
            pic_cnicBack.Image = cnicBImage == null ? null : Image.FromStream(new MemoryStream(cnicBImage));
            setkinGrid(getKinListByCustomerId(_tbl_CustomerRegM.CustomerID));
        }
        private void frmCustomerRegisteration_Load(object sender, EventArgs e)
        {

        }
        

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            XtraMessageBox.Show(t.Exception.Message);
            //Exception handling...
        }
        private List<kinModel> getKinListByCustomerId(long customerId)
        {
            PropertyEntities db1 = new PropertyEntities();
            return db1.tbl_CustomerKin.Where(x => x.fkCustomerId == customerId).Select(x => new kinModel()
            {
                CustomerKinId = x.CustomerKinId,
                KinName = x.KinName,
                KinMobile = x.KinMobile,
                KinCNIC = x.KinCNIC,
                KinRelation = x.KinRelation,
                fkCustomerId = x.fkCustomerId,
                ActiveYN = x.ActiveYN == "Y" ? true : false,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy
            }).ToList();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
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
                pic_photo.Image = myBitmap;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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
                pic_cnicFront.Image = myBitmap;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
                pic_cnicBack.Image = myBitmap;
            }
        }

        private void btn_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //radioGroup1.SelectedIndex = 0;
            isnew = true;
            txt_customerName.Tag = null;
            clearfields();
            makereadonly(false);
        }

        private void btn_update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            makereadonly(false);
        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (isnew)
            {
                try
                {

                    tbl_Projects proj = (tbl_Projects)searchLookUpEdit1View.GetRow(searchLookUpEdit1View.FocusedRowHandle);
                    if (proj == null)
                    {
                        XtraMessageBox.Show("Please Select Project");
                        return;
                    }
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    ObjectParameter PARAM_New_CustomerID = new ObjectParameter("PARAM_New_CustomerID", typeof(string));
                    List<kinModel> kin_list = getkinListFromGrid();


                    db.Pro_IDU_CustomerRegM("insert", null,
                               proj.ProjectID,
                               proj.ParentID, null, txt_customerName.Text, txt_fatherName.Text, txt_cnic.Text, txt_mobile.Text, memo_presentAddress.Text, memo_permanentAddress.Text, txt_phoneNo.Text
                               , customerImage, cnicFImage, cnicBImage, isDealer.Checked ? "Y" : "N", isActive.Checked ? "Y" : "N", loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, "", null, pARM_ERROR_MESSAGE, PARAM_New_CustomerID);

                    if (PARAM_New_CustomerID.Value != null)
                    {
                        foreach (var item in kin_list)
                        {
                            db.Pro_IDU_CustomerKin("insert", null, Convert.ToInt64(PARAM_New_CustomerID.Value), item.KinName, item.KinCNIC, item.KinMobile,
                                item.KinRelation, item.ActiveYN ? "Y" : "N", loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE);
                        }
                        XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());
                    }
                    else
                    {
                        XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());
                    }

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
                if (!string.IsNullOrEmpty(txt_customerName.Tag.ToString()))
                {
                    DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to Update?"), "Update", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        tbl_Projects proj = projectList.FirstOrDefault(x => x.ProjectID == searchLookUpEdit1.EditValue.ToString());
                        ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                        ObjectParameter PARAM_New_CustomerID = new ObjectParameter("PARAM_New_CustomerID", typeof(string));
                        db.Pro_IDU_CustomerRegM("update", Convert.ToInt64(txt_customerName.Tag),
                            proj.ProjectID,
                            proj.ParentID, null, txt_customerName.Text, txt_fatherName.Text, txt_cnic.Text, txt_mobile.Text, memo_presentAddress.Text, memo_permanentAddress.Text, txt_phoneNo.Text
                            , customerImage, cnicFImage, cnicBImage, isDealer.Checked ? "Y" : "N", isActive.Checked ? "Y" : "N", loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE, PARAM_New_CustomerID);
                        List<kinModel> kin_list = getkinListFromGrid();


                        

                        if (pARM_ERROR_MESSAGE.Value.ToString().Contains("success"))
                        {
                            foreach (var item in kin_list)
                            {
                                db.Pro_IDU_CustomerKin("update", item.CustomerKinId,item.fkCustomerId, item.KinName, item.KinCNIC, item.KinMobile,
                                    item.KinRelation, item.ActiveYN ? "Y" : "N", loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, pARM_ERROR_MESSAGE);
                            }
                            XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());
                        }
                        else
                        {
                            XtraMessageBox.Show(pARM_ERROR_MESSAGE.Value.ToString());
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
            }
            isnew = false;
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {

            //searchLookUpEdit1.Enabled = radioGroup1.EditValue.ToString() == "Main" ? true : false;
            //gridControl1.DataSource = db1.tbl_CustomerRegM.ToList();
            searchLookUpEdit1.Properties.DataSource = projectList.Where(x => x.Main_Sub == radioGroup1.EditValue.ToString()).ToList();
        }

        private void btn_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_customerName.Tag.ToString()))
            {
                DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to delete {0}?", txt_customerName.Text), "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //tbl_Projects proj = (tbl_Projects)searchLookUpEdit1View.GetRow(searchLookUpEdit1View.FocusedRowHandle);
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));
                    ObjectParameter PARAM_New_CustomerID = new ObjectParameter("PARAM_New_CustomerID", typeof(string));
                    db.Pro_IDU_CustomerRegM("delete", Convert.ToInt64(txt_customerName.Tag),
                        null,
                        null, null, txt_customerName.Text, txt_fatherName.Text, txt_cnic.Text, txt_mobile.Text, memo_presentAddress.Text, memo_permanentAddress.Text, "offc"
                        , customerImage, cnicFImage, cnicBImage, isDealer.Checked ? "Y" : "N", isActive.Checked ? "Y" : "N", loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, "", null, pARM_ERROR_MESSAGE, PARAM_New_CustomerID);
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

        private void gridView_kin_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //view.SetRowCellValue(e.RowHandle, view.Columns[0], 1);
            //view.SetRowCellValue(e.RowHandle, view.Columns[1], 2);
            //view.SetRowCellValue(e.RowHandle, view.Columns[2], 3);
        }




        private void repositoryItemButtonEdit1_Click_1(object sender, EventArgs e)
        {
            var kinModel = (kinModel)gridView_kin.GetRow(gridView_kin.FocusedRowHandle);
            if (kinModel.CustomerKinId > 0)
            {
                DialogResult dr = XtraMessageBox.Show(string.Format("Are you sure you want to delete {0}?", kinModel.CustomerKinId.ToString()), "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //tbl_Projects proj = (tbl_Projects)searchLookUpEdit1View.GetRow(searchLookUpEdit1View.FocusedRowHandle);
                    ObjectParameter pARM_ERROR_MESSAGE = new ObjectParameter("pARM_ERROR_MESSAGE", typeof(string));

                    db.Pro_IDU_CustomerKin("delete", null, Convert.ToInt64(kinModel.fkCustomerId), kinModel.KinName, kinModel.KinCNIC, kinModel.KinMobile,
                                       kinModel.KinRelation, kinModel.ActiveYN ? "Y" : "N", loginModel.PARM_USER_ID.Value.ToString(), DateTime.Now, null, null, pARM_ERROR_MESSAGE);
                    gridView_kin.DeleteRow(gridView_kin.FocusedRowHandle);

                }


            }
            else
            {

                return;

            }

        }

        private void btn_newKin_Click(object sender, EventArgs e)
        {
            //gridControl2.Focus();
            //kinModelBindList.Add(new kinModel() { });
            //gridControl2.Refresh();
            gridView_kin.AddNewRow();
            //this.gridView_kin.FocusedRowHandle = this.gridView_kin.RowCount - 1;
            //this.gridView_kin.TopRowIndex = this.gridView_kin.RowCount - 1;
            this.gridView_kin.ShowPopupEditForm();
            //gridView_kin.SetFocusedRowCellValue("KinName", "My Field Value");
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var _customerlist = (tbl_CustomerRegM)gridView1.GetRow(e.RowHandle);
            setFields(_customerlist);
            makereadonly(true);
        }
    }
}