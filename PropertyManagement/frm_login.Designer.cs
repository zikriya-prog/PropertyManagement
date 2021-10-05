namespace PropertyManagement
{
    partial class frm_login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_userName = new DevExpress.XtraEditors.TextEdit();
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_userName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_userName);
            this.layoutControl1.Controls.Add(this.txt_password);
            this.layoutControl1.Controls.Add(this.btn_login);
            this.layoutControl1.Controls.Add(this.btn_cancel);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            // 
            // txt_userName
            // 
            resources.ApplyResources(this.txt_userName, "txt_userName");
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txt_userName.Properties.Appearance.Font")));
            this.txt_userName.Properties.Appearance.Options.UseFont = true;
            this.txt_userName.StyleController = this.layoutControl1;
            this.txt_userName.Tag = "User Name";
            // 
            // txt_password
            // 
            resources.ApplyResources(this.txt_password, "txt_password");
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txt_password.Properties.Appearance.Font")));
            this.txt_password.Properties.Appearance.Options.UseFont = true;
            this.txt_password.Properties.PasswordChar = '*';
            this.txt_password.StyleController = this.layoutControl1;
            this.txt_password.Tag = "Password";
            // 
            // btn_login
            // 
            this.btn_login.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btn_login.Appearance.Font")));
            this.btn_login.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btn_login, "btn_login");
            this.btn_login.Name = "btn_login";
            this.btn_login.StyleController = this.layoutControl1;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btn_cancel.Appearance.Font")));
            this.btn_cancel.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btn_cancel, "btn_cancel");
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.StyleController = this.layoutControl1;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem4,
            this.emptySpaceItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(357, 151);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlItem1.AppearanceItemCaption.Font")));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_userName;
            this.layoutControlItem1.Location = new System.Drawing.Point(10, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(317, 45);
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlItem2.AppearanceItemCaption.Font")));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_password;
            this.layoutControlItem2.Location = new System.Drawing.Point(10, 45);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(317, 45);
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_login;
            this.layoutControlItem3.Location = new System.Drawing.Point(158, 104);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(83, 27);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_cancel;
            this.layoutControlItem4.Location = new System.Drawing.Point(241, 104);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(86, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(10, 104);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(148, 27);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(10, 90);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(317, 14);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(327, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 131);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 131);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frm_login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frm_login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_login_FormClosing);
            this.Load += new System.EventHandler(this.frm_login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_login_KeyDown);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.frm_login_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_userName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_password;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        public DevExpress.XtraEditors.TextEdit txt_userName;
    }
}