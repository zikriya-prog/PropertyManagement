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

namespace PropertyManagement
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void spreadsheetControl1_Click(object sender, EventArgs e)
        {

        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
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
    }
}