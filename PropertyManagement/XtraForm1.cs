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
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraSpreadsheet;
using System.Net;
using System.IO;
using PropertyManagement.Model.CustomModels;
using PropertyManagement.Reports;
using DevExpress.XtraReports.UI;

namespace PropertyManagement
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();

            List<TestClass> ts = new List<TestClass>();
            for (int i = 0; i < 20; i++)
            {
                ts.Add(new TestClass() { id = i, name= "name"+i.ToString(), subjects = new List<Subject> { new Subject{ id = 1, name = "sub" + i.ToString() },new Subject { id = 2, name = "sub" + i.ToString() } } });
            }

            gridControl1.DataSource = ts;
        }

        private void spreadsheetControl1_Click(object sender, EventArgs e)
        {

        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            var str = Application.StartupPath;
            //SpreadsheetControl workbook = new SpreadsheetControl();
            ////sp.LoadDocument("",)
            //workbook.LoadDocument(@"G:\FreeLance\PropertyManagement\PropertyManagement\bin\Debug\TestBook.xlsx", DocumentFormat.Xlsx);

            //Worksheet workSheet = workbook.Document.Worksheets[0];

            //Range usedRange = workSheet.GetUsedRange();
            //RangeDataSourceOptions rdop = new RangeDataSourceOptions();
            //rdop.UseFirstRowAsHeader = true;
            //usedRange.GetDataSource(rdop);
            //var dt = ExcelToDataTableByDevExpress(@"G:\FreeLance\PropertyManagement\PropertyManagement\bin\Debug\TestBook.xlsx");



        }
        public static DataTable ExcelToDataTableByDevExpress(string fullFilePath)
        {
            Workbook workbook = new Workbook();
            workbook.LoadDocument(fullFilePath, DocumentFormat.Xlsx);

            Worksheet workSheet = workbook.Worksheets[0];
            workbook.SaveDocument("",DocumentFormat.Xlsx);
            Range usedRange = workSheet.GetUsedRange();
            DataTable dataTable = workSheet.CreateDataTable(usedRange.CurrentRegion, true, true);
            //DataTable dataTable = workSheet.CreateDataTable(usedRange, true, true);

            for (int i = 1; i <= usedRange.RowCount - 1; i++)
            {
                DataRow newRow = dataTable.NewRow();
                for (int j = 0; j <= usedRange.CurrentRegion.ColumnCount - 1; j++)
                {
                    newRow[j] = workSheet.Cells[i, j].DisplayText;
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ExportToXlsx("abc");
            using (var webclient= new WebClient())
            {
                webclient.DownloadFile("file:///G:/FreeLance/PropertyManagement/PropertyManagement/bin/Debug/TestBook.xlsx","TestBook1.xlsx");
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tbl_Files fl = fileList.FirstOrDefault(x => x.FileID == (searchLookUpEdit_file.EditValue.ToString() != "" ? Convert.ToInt64(searchLookUpEdit_file.EditValue) : 0));
            InstalmentPlan report = new InstalmentPlan();

            //report.Parameters["parm_Name"].Value = customer.CustomerName;
            //report.Parameters["parm_cnic"].Value = customer.CNIC;
            //report.Parameters["parm_membership_no"].Value = txt_membershipNo.EditValue.ToString();
            //report.Parameters["parm_project"].Value = fl.tbl_Projects.ProjectName;
            //report.Parameters["parm_areatype"].Value = cmb_areaType.Text;
            //report.Parameters["parm_areasize"].Value = txt_areaSize.Text;
            List<VMInstallmentPlan> list = new List<VMInstallmentPlan>();
            
            for (int i =1;i<=100;i++)
            {
                VMInstallmentPlan obj = new VMInstallmentPlan();
                obj.DueDate = DateTime.Now;
                obj.paymentDescription = "Installment "+i.ToString();
                list.Add(obj);
            }
            report.DataSource = list;
            report.RequestParameters = false;
            ReportPrintTool pt = new ReportPrintTool(report);
            pt.AutoShowParametersPanel = false;

            pt.ShowPreviewDialog();
        }
    }
}