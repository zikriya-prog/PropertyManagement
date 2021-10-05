﻿using DevExpress.Utils.CodedUISupport;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using PropertyManagement.Model.proModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertyManagement
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        frm_login _frmlogin;
        string permissionMsg = "You don't Have permission to access this!";
        public frmMain(frm_login frmLogin)
        {
            InitializeComponent();
            _frmlogin = frmLogin;
            loginUser_txt.Caption = _frmlogin.txt_userName.Text;
            userMenuVisibility();
        }
        private void userMenuVisibility()
        {
            foreach (var cont in accordionControl1.Elements)
            {
                if (cont.Tag != null)
                    cont.Visible = loginModel.userMenus.Any(x => x.fkMenuID == cont.Tag.ToString());
            }
        }
        private void customerRegistration_accordionControlElement_Click(object sender, EventArgs e)
        {
            frmCustomerRegisteration _frmCustomerRegisteration = new frmCustomerRegisteration();
            _frmCustomerRegisteration.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmCustomerRegisteration.Tag.ToString() && x.VST == "1"))
                _frmCustomerRegisteration.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }

        private void customerPlotBooking_accordionControlElement_Click(object sender, EventArgs e)
        {
            frmPlotBooking _frmPlotBooking = new frmPlotBooking();
            _frmPlotBooking.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmPlotBooking.Tag.ToString() && x.VST == "1"))
                _frmPlotBooking.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }

        private void installmentPlan_accordionControlElement_Click(object sender, EventArgs e)
        {
            frmInstallmentPlan _frmInstallmentPlan = new frmInstallmentPlan();
            _frmInstallmentPlan.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmInstallmentPlan.Tag.ToString() && x.VST == "1"))
                _frmInstallmentPlan.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }

        private void installmentReceive_accordionControlElement_Click(object sender, EventArgs e)
        {
            frmInstallmentReceive _frmInstallmentReceive = new frmInstallmentReceive();
            _frmInstallmentReceive.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmInstallmentReceive.Tag.ToString() && x.VST == "1"))
                _frmInstallmentReceive.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            accordionControl1.LookAndFeel.SkinName = LookAndFeel.ActiveLookAndFeel.SkinName;
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            accordionControl1.LookAndFeel.SkinName = LookAndFeel.ActiveLookAndFeel.SkinName;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmlogin.Show();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            frmProject _frmProject = new frmProject();
            _frmProject.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmProject.Tag.ToString() && x.VST == "1"))
                _frmProject.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }

        private void accordionControlElement_files_Click(object sender, EventArgs e)
        {
            frmFiles _frmFiles = new frmFiles();
            _frmFiles.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmFiles.Tag.ToString() && x.VST == "1"))
                _frmFiles.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            frmUserCreation _frmUserCreation = new frmUserCreation();
            _frmUserCreation.MdiParent = this;
            if (loginModel.userMenus.Any(x => x.fkMenuID == _frmUserCreation.Tag.ToString() && x.VST == "1"))
                _frmUserCreation.Show();
            else
                XtraMessageBox.Show(permissionMsg);
        }
    }
}
