namespace PropertyManagement
{
    partial class frmUserCreation
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.viewuserwithroleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfkRoleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRMKS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPWD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPWD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveYN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btn_create = new DevExpress.XtraBars.BarButtonItem();
            this.btn_update = new DevExpress.XtraBars.BarButtonItem();
            this.btn_delete = new DevExpress.XtraBars.BarButtonItem();
            this.btn_save = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txt_userName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_remark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmb_role = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tblUserRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chk_active = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_cPassword = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewuserwithroleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_userName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_remark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_role.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_active.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmb_role);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txt_userName);
            this.layoutControl1.Controls.Add(this.txt_name);
            this.layoutControl1.Controls.Add(this.txt_remark);
            this.layoutControl1.Controls.Add(this.txt_password);
            this.layoutControl1.Controls.Add(this.chk_active);
            this.layoutControl1.Controls.Add(this.txt_cPassword);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 27);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(886, 432);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.viewuserwithroleBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 179);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(862, 241);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // viewuserwithroleBindingSource
            // 
            this.viewuserwithroleBindingSource.DataSource = typeof(PropertyManagement.Model.View_user_with_role);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colfkRoleID,
            this.colNAME,
            this.colRMKS,
            this.colUserName,
            this.colPWD,
            this.colCPWD,
            this.colActiveYN,
            this.colLoginName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            // 
            // colfkRoleID
            // 
            this.colfkRoleID.FieldName = "fkRoleID";
            this.colfkRoleID.Name = "colfkRoleID";
            // 
            // colNAME
            // 
            this.colNAME.FieldName = "NAME";
            this.colNAME.Name = "colNAME";
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 0;
            // 
            // colRMKS
            // 
            this.colRMKS.FieldName = "RMKS";
            this.colRMKS.Name = "colRMKS";
            this.colRMKS.Visible = true;
            this.colRMKS.VisibleIndex = 1;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 2;
            // 
            // colPWD
            // 
            this.colPWD.FieldName = "PWD";
            this.colPWD.Name = "colPWD";
            this.colPWD.Visible = true;
            this.colPWD.VisibleIndex = 3;
            // 
            // colCPWD
            // 
            this.colCPWD.FieldName = "CPWD";
            this.colCPWD.Name = "colCPWD";
            this.colCPWD.Visible = true;
            this.colCPWD.VisibleIndex = 4;
            // 
            // colActiveYN
            // 
            this.colActiveYN.FieldName = "ActiveYN";
            this.colActiveYN.Name = "colActiveYN";
            this.colActiveYN.Visible = true;
            this.colActiveYN.VisibleIndex = 5;
            // 
            // colLoginName
            // 
            this.colLoginName.FieldName = "LoginName";
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.Visible = true;
            this.colLoginName.VisibleIndex = 6;
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
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(886, 432);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 167);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(866, 245);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_create,
            this.btn_update,
            this.btn_delete,
            this.btn_save});
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_create),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_update),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_delete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_save)});
            this.bar1.Text = "Tools";
            // 
            // btn_create
            // 
            this.btn_create.Caption = "New";
            this.btn_create.Id = 0;
            this.btn_create.Name = "btn_create";
            this.btn_create.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_create_ItemClick);
            // 
            // btn_update
            // 
            this.btn_update.Caption = "Update";
            this.btn_update.Id = 1;
            this.btn_update.Name = "btn_update";
            this.btn_update.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_update_ItemClick);
            // 
            // btn_delete
            // 
            this.btn_delete.Caption = "Delete";
            this.btn_delete.Id = 2;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_delete_ItemClick);
            // 
            // btn_save
            // 
            this.btn_save.Caption = "Save";
            this.btn_save.Id = 3;
            this.btn_save.Name = "btn_save";
            this.btn_save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_save_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(886, 27);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 459);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(886, 21);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 27);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 432);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(886, 27);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 432);
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(99, 12);
            this.txt_userName.MenuManager = this.barManager1;
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Properties.ReadOnly = true;
            this.txt_userName.Properties.UseReadOnlyAppearance = false;
            this.txt_userName.Size = new System.Drawing.Size(355, 20);
            this.txt_userName.StyleController = this.layoutControl1;
            this.txt_userName.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_userName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "User Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(84, 13);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(99, 36);
            this.txt_name.MenuManager = this.barManager1;
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.ReadOnly = true;
            this.txt_name.Properties.UseReadOnlyAppearance = false;
            this.txt_name.Size = new System.Drawing.Size(355, 20);
            this.txt_name.StyleController = this.layoutControl1;
            this.txt_name.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_name;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Name";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 13);
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(99, 60);
            this.txt_remark.MenuManager = this.barManager1;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Properties.ReadOnly = true;
            this.txt_remark.Properties.UseReadOnlyAppearance = false;
            this.txt_remark.Size = new System.Drawing.Size(355, 20);
            this.txt_remark.StyleController = this.layoutControl1;
            this.txt_remark.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_remark;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Remarks";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(84, 13);
            // 
            // cmb_role
            // 
            this.cmb_role.Location = new System.Drawing.Point(99, 84);
            this.cmb_role.MenuManager = this.barManager1;
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_role.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleID", "Role ID", 59, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmb_role.Properties.DataSource = this.tblUserRoleBindingSource;
            this.cmb_role.Properties.DisplayMember = "NAME";
            this.cmb_role.Properties.ReadOnly = true;
            this.cmb_role.Properties.UseReadOnlyAppearance = false;
            this.cmb_role.Properties.ValueMember = "RoleID";
            this.cmb_role.Size = new System.Drawing.Size(355, 20);
            this.cmb_role.StyleController = this.layoutControl1;
            this.cmb_role.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmb_role;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Role";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(84, 13);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(99, 108);
            this.txt_password.MenuManager = this.barManager1;
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.ReadOnly = true;
            this.txt_password.Properties.UseReadOnlyAppearance = false;
            this.txt_password.Size = new System.Drawing.Size(355, 20);
            this.txt_password.StyleController = this.layoutControl1;
            this.txt_password.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txt_password;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Password";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(84, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(446, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(420, 120);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(420, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(420, 167);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tblUserRoleBindingSource
            // 
            this.tblUserRoleBindingSource.DataSource = typeof(PropertyManagement.Model.tbl_UserRole);
            // 
            // chk_active
            // 
            this.chk_active.EditValue = true;
            this.chk_active.Location = new System.Drawing.Point(12, 156);
            this.chk_active.MenuManager = this.barManager1;
            this.chk_active.Name = "chk_active";
            this.chk_active.Properties.Caption = "Active";
            this.chk_active.Size = new System.Drawing.Size(442, 19);
            this.chk_active.StyleController = this.layoutControl1;
            this.chk_active.TabIndex = 10;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chk_active;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(446, 23);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(446, 23);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(446, 23);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // txt_cPassword
            // 
            this.txt_cPassword.Location = new System.Drawing.Point(99, 132);
            this.txt_cPassword.Name = "txt_cPassword";
            this.txt_cPassword.Properties.ReadOnly = true;
            this.txt_cPassword.Properties.UseReadOnlyAppearance = false;
            this.txt_cPassword.Size = new System.Drawing.Size(355, 20);
            this.txt_cPassword.StyleController = this.layoutControl1;
            this.txt_cPassword.TabIndex = 9;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txt_cPassword;
            this.layoutControlItem8.CustomizationFormText = "Password";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(446, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.OptionsPrint.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.layoutControlItem8.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "Confirm Password";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(84, 13);
            // 
            // frmUserCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 480);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUserCreation";
            this.Tag = "01";
            this.Text = "frmUserCreation";
            this.Load += new System.EventHandler(this.frmUserCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewuserwithroleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_userName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_remark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_role.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_active.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource viewuserwithroleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colfkRoleID;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colRMKS;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPWD;
        private DevExpress.XtraGrid.Columns.GridColumn colCPWD;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveYN;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginName;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btn_create;
        private DevExpress.XtraBars.BarButtonItem btn_update;
        private DevExpress.XtraBars.BarButtonItem btn_delete;
        private DevExpress.XtraBars.BarButtonItem btn_save;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LookUpEdit cmb_role;
        private DevExpress.XtraEditors.TextEdit txt_userName;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.TextEdit txt_remark;
        private DevExpress.XtraEditors.TextEdit txt_password;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource tblUserRoleBindingSource;
        private DevExpress.XtraEditors.CheckEdit chk_active;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit txt_cPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}