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

namespace PropertyManagement
{
    public partial class frmUserCreation : DevExpress.XtraEditors.XtraForm
    {
        public frmUserCreation()
        {
            InitializeComponent();
            loadUserRights(this.Tag.ToString());
        }
        private void loadUserRights(string tag)
        {
            //tbl_userMenu menu = loginModel.userMenus.FirstOrDefault(x => x.fkMenuID == tag);
            //if (menu != null)
            //{
            //    btn_create.Visibility = menu.INST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            //    btn_update.Visibility = menu.UPST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            //    btn_delete.Visibility = menu.DLST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            //    btn_save.Visibility = menu.INST == "1" || menu.UPST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            //    btn_cancel.Visibility = menu.CHST == "1" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            //}
        }

        private void frmUserCreation_Load(object sender, EventArgs e)
        {

        }
    }
}