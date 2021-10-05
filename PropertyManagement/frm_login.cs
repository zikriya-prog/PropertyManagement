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
using System.Threading;

namespace PropertyManagement
{
    public partial class frm_login : DevExpress.XtraEditors.XtraForm
    {
        PropertyEntities db = new PropertyEntities();
        public frm_login()
        {
            InitializeComponent();
            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);
        }
       

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            XtraMessageBox.Show(t.Exception.Message);
            //Exception handling...
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            
            db.Pro_CheckLogin(txt_userName.Text,txt_password.Text,
                loginModel.PARM_USER_ID, loginModel.PARM_FULL_USER_NAME, loginModel.PARM_USER_ROLE, loginModel.PARM_ERROR_MESSAGE);
            if (loginModel.PARM_ERROR_MESSAGE.Value.ToString() == "Login Successfully!")
            {
                int roleId = Convert.ToInt32(loginModel.PARM_USER_ROLE.Value);
                loginModel.userMenus = db.tbl_userMenu.Where(x => x.fkRoleID == roleId).ToList();
                frmMain _frmMain = new frmMain(this);
                _frmMain.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show(loginModel.PARM_ERROR_MESSAGE.Value.ToString());
            }
        }
        
        private void frm_login_Validating(object sender, CancelEventArgs e)
        {
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }
    }
}