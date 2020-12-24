namespace QuanLyDienNang
{
    partial class Form_Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
			this.menuBar = new System.Windows.Forms.MenuStrip();
			this.chươngTrìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cấuHìnhSQLStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nhậpThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xuấtThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quảnLýNhânViênToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.contextTabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDong = new System.Windows.Forms.ToolStripMenuItem();
			this.tabForms = new System.Windows.Forms.TabControl();
			this.tabMain = new System.Windows.Forms.TabPage();
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.lblComputerName = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolBar = new System.Windows.Forms.ToolStrip();
			this.btnXuat = new System.Windows.Forms.ToolStripButton();
			this.btnIn = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnXoa = new System.Windows.Forms.ToolStripButton();
			this.btnSaoChep = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnTrenCung = new System.Windows.Forms.ToolStripButton();
			this.btnLen = new System.Windows.Forms.ToolStripButton();
			this.btnXuong = new System.Windows.Forms.ToolStripButton();
			this.btnDuoiCung = new System.Windows.Forms.ToolStripButton();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnDongForm = new System.Windows.Forms.ToolStripButton();
			this.menuBar.SuspendLayout();
			this.contextTabMenu.SuspendLayout();
			this.tabForms.SuspendLayout();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.toolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuBar
			// 
			this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chươngTrìnhToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem});
			this.menuBar.Location = new System.Drawing.Point(0, 0);
			this.menuBar.Name = "menuBar";
			this.menuBar.Size = new System.Drawing.Size(984, 24);
			this.menuBar.TabIndex = 0;
			this.menuBar.Text = "menuStrip1";
			// 
			// chươngTrìnhToolStripMenuItem
			// 
			this.chươngTrìnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cấuHìnhSQLStripMenuItem,
            this.giớiThiệuToolStripMenuItem,
            this.thoátToolStripMenuItem});
			this.chươngTrìnhToolStripMenuItem.Name = "chươngTrìnhToolStripMenuItem";
			this.chươngTrìnhToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
			this.chươngTrìnhToolStripMenuItem.Text = "&Chương trình";
			// 
			// cấuHìnhSQLStripMenuItem
			// 
			this.cấuHìnhSQLStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Configure;
			this.cấuHìnhSQLStripMenuItem.Name = "cấuHìnhSQLStripMenuItem";
			this.cấuHìnhSQLStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.cấuHìnhSQLStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.cấuHìnhSQLStripMenuItem.Text = "Cấu hình &SQL Server";
			this.cấuHìnhSQLStripMenuItem.Click += new System.EventHandler(this.cấuHìnhSQLStripMenuItem_Click);
			// 
			// giớiThiệuToolStripMenuItem
			// 
			this.giớiThiệuToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Info;
			this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
			this.giớiThiệuToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.giớiThiệuToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.giớiThiệuToolStripMenuItem.Text = "&Giới thiệu";
			this.giớiThiệuToolStripMenuItem.Click += new System.EventHandler(this.giớiThiệuToolStripMenuItem_Click);
			// 
			// thoátToolStripMenuItem
			// 
			this.thoátToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Exit;
			this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			this.thoátToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.thoátToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.thoátToolStripMenuItem.Text = "&Thoát";
			this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
			// 
			// quảnLýKháchHàngToolStripMenuItem
			// 
			this.quảnLýKháchHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpThôngTinToolStripMenuItem,
            this.xuấtThôngTinToolStripMenuItem,
            this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem,
            this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem});
			this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
			this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
			this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý &Khách hàng";
			// 
			// nhậpThôngTinToolStripMenuItem
			// 
			this.nhậpThôngTinToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.nhậpThôngTinToolStripMenuItem.Name = "nhậpThôngTinToolStripMenuItem";
			this.nhậpThôngTinToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.nhậpThôngTinToolStripMenuItem.Text = "&Nhập thông tin";
			this.nhậpThôngTinToolStripMenuItem.Click += new System.EventHandler(this.nhậpThôngTinToolStripMenuItem_Click);
			// 
			// xuấtThôngTinToolStripMenuItem
			// 
			this.xuấtThôngTinToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.xuấtThôngTinToolStripMenuItem.Name = "xuấtThôngTinToolStripMenuItem";
			this.xuấtThôngTinToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.xuấtThôngTinToolStripMenuItem.Text = "&Xuất thông tin";
			this.xuấtThôngTinToolStripMenuItem.Click += new System.EventHandler(this.xuấtThôngTinToolStripMenuItem_Click);
			// 
			// cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem
			// 
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Modify;
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Name = "cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem";
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Text = "&Cập nhật điện năng tiêu thụ";
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem_Click);
			// 
			// đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem
			// 
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Picture;
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Name = "đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem";
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Text = "Đọc chỉ số điện năng &tiêu thụ";
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Click += new System.EventHandler(this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem_Click);
			// 
			// quảnLýNhânViênToolStripMenuItem
			// 
			this.quảnLýNhânViênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem1});
			this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
			this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
			this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý &Nhân viên";
			// 
			// quảnLýNhânViênToolStripMenuItem1
			// 
			this.quảnLýNhânViênToolStripMenuItem1.Image = global::QuanLyDienNang.Properties.Resources.User;
			this.quảnLýNhânViênToolStripMenuItem1.Name = "quảnLýNhânViênToolStripMenuItem1";
			this.quảnLýNhânViênToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
			this.quảnLýNhânViênToolStripMenuItem1.Text = "&Quản lý Nhân viên";
			this.quảnLýNhânViênToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem1_Click);
			// 
			// contextTabMenu
			// 
			this.contextTabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDong});
			this.contextTabMenu.Name = "contextTabMenu";
			this.contextTabMenu.Size = new System.Drawing.Size(175, 26);
			// 
			// menuDong
			// 
			this.menuDong.Name = "menuDong";
			this.menuDong.Size = new System.Drawing.Size(174, 22);
			this.menuDong.Text = "Đóng tab đang mở";
			this.menuDong.Click += new System.EventHandler(this.menuDong_Click);
			// 
			// tabForms
			// 
			this.tabForms.Controls.Add(this.tabMain);
			this.tabForms.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabForms.Location = new System.Drawing.Point(0, 0);
			this.tabForms.Name = "tabForms";
			this.tabForms.SelectedIndex = 0;
			this.tabForms.Size = new System.Drawing.Size(984, 490);
			this.tabForms.TabIndex = 1;
			this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
			// 
			// tabMain
			// 
			this.tabMain.BackgroundImage = global::QuanLyDienNang.Properties.Resources.anh_nen_1;
			this.tabMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.tabMain.Location = new System.Drawing.Point(4, 26);
			this.tabMain.Name = "tabMain";
			this.tabMain.Size = new System.Drawing.Size(976, 460);
			this.tabMain.TabIndex = 0;
			this.tabMain.Text = "Chào mừng";
			this.tabMain.UseVisualStyleBackColor = true;
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.BottomToolStripPanel
			// 
			this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusBar);
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.tabForms);
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(984, 490);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.toolStripContainer.Location = new System.Drawing.Point(0, 24);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(984, 537);
			this.toolStripContainer.TabIndex = 4;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolBar);
			this.toolStripContainer.TopToolStripPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.toolStripContainer.TopToolStripPanel.Font = new System.Drawing.Font("Segoe UI", 10F);
			// 
			// statusBar
			// 
			this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblComputerName});
			this.statusBar.Location = new System.Drawing.Point(0, 0);
			this.statusBar.Name = "statusBar";
			this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.statusBar.Size = new System.Drawing.Size(984, 22);
			this.statusBar.TabIndex = 0;
			// 
			// lblComputerName
			// 
			this.lblComputerName.Name = "lblComputerName";
			this.lblComputerName.Size = new System.Drawing.Size(88, 17);
			this.lblComputerName.Text = "Your Computer";
			// 
			// toolBar
			// 
			this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnXuat,
            this.btnIn,
            this.separator1,
            this.btnXoa,
            this.btnSaoChep,
            this.separator2,
            this.btnTrenCung,
            this.btnLen,
            this.btnXuong,
            this.btnDuoiCung,
            this.separator3,
            this.btnDongForm});
			this.toolBar.Location = new System.Drawing.Point(3, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(916, 25);
			this.toolBar.TabIndex = 3;
			this.toolBar.Text = "Thanh công cụ";
			// 
			// btnXuat
			// 
			this.btnXuat.Image = global::QuanLyDienNang.Properties.Resources.Office;
			this.btnXuat.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnXuat.Name = "btnXuat";
			this.btnXuat.Size = new System.Drawing.Size(96, 22);
			this.btnXuat.Text = "Xuất báo cáo";
			// 
			// btnIn
			// 
			this.btnIn.Image = global::QuanLyDienNang.Properties.Resources.Print;
			this.btnIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnIn.Name = "btnIn";
			this.btnIn.Size = new System.Drawing.Size(37, 22);
			this.btnIn.Text = "In";
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnXoa
			// 
			this.btnXoa.Image = global::QuanLyDienNang.Properties.Resources.Delete2;
			this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(90, 22);
			this.btnXoa.Text = "Xóa bản ghi";
			// 
			// btnSaoChep
			// 
			this.btnSaoChep.Image = global::QuanLyDienNang.Properties.Resources.Copy;
			this.btnSaoChep.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaoChep.Name = "btnSaoChep";
			this.btnSaoChep.Size = new System.Drawing.Size(118, 22);
			this.btnSaoChep.Text = "Sao chép bản ghi";
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnTrenCung
			// 
			this.btnTrenCung.Image = global::QuanLyDienNang.Properties.Resources.Up;
			this.btnTrenCung.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTrenCung.Name = "btnTrenCung";
			this.btnTrenCung.Size = new System.Drawing.Size(110, 22);
			this.btnTrenCung.Text = "Dòng trên cùng";
			this.btnTrenCung.Click += new System.EventHandler(this.btnTrenCung_Click);
			// 
			// btnLen
			// 
			this.btnLen.Image = global::QuanLyDienNang.Properties.Resources.Stock_Index_Up;
			this.btnLen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLen.Name = "btnLen";
			this.btnLen.Size = new System.Drawing.Size(80, 22);
			this.btnLen.Text = "Dòng trên";
			this.btnLen.Click += new System.EventHandler(this.btnLen_Click);
			// 
			// btnXuong
			// 
			this.btnXuong.Image = global::QuanLyDienNang.Properties.Resources.Stock_Index_Down;
			this.btnXuong.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnXuong.Name = "btnXuong";
			this.btnXuong.Size = new System.Drawing.Size(83, 22);
			this.btnXuong.Text = "Dòng dưới";
			this.btnXuong.Click += new System.EventHandler(this.btnXuong_Click);
			// 
			// btnDuoiCung
			// 
			this.btnDuoiCung.Image = global::QuanLyDienNang.Properties.Resources.Down;
			this.btnDuoiCung.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDuoiCung.Name = "btnDuoiCung";
			this.btnDuoiCung.Size = new System.Drawing.Size(112, 22);
			this.btnDuoiCung.Text = "Dòng cuối cùng";
			this.btnDuoiCung.Click += new System.EventHandler(this.btnDuoiCung_Click);
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(6, 25);
			// 
			// btnDongForm
			// 
			this.btnDongForm.Image = global::QuanLyDienNang.Properties.Resources.Delete;
			this.btnDongForm.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDongForm.Name = "btnDongForm";
			this.btnDongForm.Size = new System.Drawing.Size(129, 22);
			this.btnDongForm.Text = "Đóng Form hiện tại";
			this.btnDongForm.ToolTipText = "Đóng Form hiện hành";
			this.btnDongForm.Click += new System.EventHandler(this.btnDongForm_Click);
			// 
			// Form_Main
			// 
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.toolStripContainer);
			this.Controls.Add(this.menuBar);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form_Main";
			this.Text = "ỨNG DỤNG QUẢN LÝ ĐIỆN NĂNG";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.menuBar.ResumeLayout(false);
			this.menuBar.PerformLayout();
			this.contextTabMenu.ResumeLayout(false);
			this.tabForms.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuBar;
		private System.Windows.Forms.ToolStripMenuItem chươngTrìnhToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem giớiThiệuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nhậpThôngTinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xuấtThôngTinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextTabMenu;
		private System.Windows.Forms.ToolStripMenuItem menuDong;
		private System.Windows.Forms.TabControl tabForms;
		private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.ToolStrip toolBar;
		private System.Windows.Forms.ToolStripButton btnDongForm;
		private System.Windows.Forms.ToolStripButton btnLen;
		private System.Windows.Forms.ToolStripButton btnXuong;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton btnSaoChep;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripButton btnIn;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripButton btnXoa;
		private System.Windows.Forms.ToolStripButton btnTrenCung;
		private System.Windows.Forms.ToolStripButton btnDuoiCung;
		private System.Windows.Forms.ToolStripButton btnXuat;
		private System.Windows.Forms.ToolStripStatusLabel lblComputerName;
		private System.Windows.Forms.ToolStripMenuItem cấuHìnhSQLStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem1;
	}
}

