namespace QuanLyDienNang
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.menuBar = new System.Windows.Forms.MenuStrip();
			this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nhậpThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xuấtThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextTabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDong = new System.Windows.Forms.ToolStripMenuItem();
			this.tabForms = new System.Windows.Forms.TabControl();
			this.tabMain = new System.Windows.Forms.TabPage();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolbar = new System.Windows.Forms.ToolStrip();
			this.btnDongForm = new System.Windows.Forms.ToolStripButton();
			this.menuBar.SuspendLayout();
			this.contextTabMenu.SuspendLayout();
			this.tabForms.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuBar
			// 
			this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem});
			this.menuBar.Location = new System.Drawing.Point(0, 0);
			this.menuBar.Name = "menuBar";
			this.menuBar.Size = new System.Drawing.Size(984, 24);
			this.menuBar.TabIndex = 0;
			this.menuBar.Text = "menuStrip1";
			// 
			// hệThốngToolStripMenuItem
			// 
			this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giớiThiệuToolStripMenuItem,
            this.thoátToolStripMenuItem});
			this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
			this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
			this.hệThốngToolStripMenuItem.Text = "Chương trình";
			// 
			// giớiThiệuToolStripMenuItem
			// 
			this.giớiThiệuToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Info1;
			this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
			this.giớiThiệuToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.giớiThiệuToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.giớiThiệuToolStripMenuItem.Text = "Giới thiệu";
			this.giớiThiệuToolStripMenuItem.Click += new System.EventHandler(this.giớiThiệuToolStripMenuItem_Click);
			// 
			// thoátToolStripMenuItem
			// 
			this.thoátToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Exit;
			this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			this.thoátToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.thoátToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.thoátToolStripMenuItem.Text = "Thoát";
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
			this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý Khách hàng";
			// 
			// nhậpThôngTinToolStripMenuItem
			// 
			this.nhậpThôngTinToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Add;
			this.nhậpThôngTinToolStripMenuItem.Name = "nhậpThôngTinToolStripMenuItem";
			this.nhậpThôngTinToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.nhậpThôngTinToolStripMenuItem.Text = "Nhập thông tin";
			this.nhậpThôngTinToolStripMenuItem.Click += new System.EventHandler(this.nhậpThôngTinToolStripMenuItem_Click);
			// 
			// xuấtThôngTinToolStripMenuItem
			// 
			this.xuấtThôngTinToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.xuấtThôngTinToolStripMenuItem.Name = "xuấtThôngTinToolStripMenuItem";
			this.xuấtThôngTinToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.xuấtThôngTinToolStripMenuItem.Text = "Xuất thông tin";
			this.xuấtThôngTinToolStripMenuItem.Click += new System.EventHandler(this.xuấtThôngTinToolStripMenuItem_Click);
			// 
			// cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem
			// 
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Modify;
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Name = "cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem";
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Text = "Cập nhật điện năng tiêu thụ";
			this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem_Click);
			// 
			// đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem
			// 
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Image = global::QuanLyDienNang.Properties.Resources.Picture;
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Name = "đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem";
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Text = "Đọc chỉ số điện năng tiêu thụ";
			this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem.Click += new System.EventHandler(this.đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem_Click);
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
			this.tabForms.Size = new System.Drawing.Size(984, 512);
			this.tabForms.TabIndex = 1;
			// 
			// tabMain
			// 
			this.tabMain.BackgroundImage = global::QuanLyDienNang.Properties.Resources.anh_nen_1;
			this.tabMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.tabMain.Location = new System.Drawing.Point(4, 25);
			this.tabMain.Name = "tabMain";
			this.tabMain.Size = new System.Drawing.Size(976, 483);
			this.tabMain.TabIndex = 0;
			this.tabMain.Text = "Chào mừng";
			this.tabMain.UseVisualStyleBackColor = true;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tabForms);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(984, 512);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(984, 537);
			this.toolStripContainer1.TabIndex = 4;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolbar);
			// 
			// toolbar
			// 
			this.toolbar.Dock = System.Windows.Forms.DockStyle.None;
			this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDongForm});
			this.toolbar.Location = new System.Drawing.Point(3, 0);
			this.toolbar.Name = "toolbar";
			this.toolbar.Size = new System.Drawing.Size(130, 25);
			this.toolbar.TabIndex = 3;
			this.toolbar.Text = "toolStrip1";
			// 
			// btnDongForm
			// 
			this.btnDongForm.Image = global::QuanLyDienNang.Properties.Resources.Delete;
			this.btnDongForm.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDongForm.Name = "btnDongForm";
			this.btnDongForm.Size = new System.Drawing.Size(87, 22);
			this.btnDongForm.Text = "Đóng Form";
			this.btnDongForm.ToolTipText = "Đóng Form hiện hành";
			this.btnDongForm.Click += new System.EventHandler(this.btnDongForm_Click);
			// 
			// FormMain
			// 
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.menuBar);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "Chương Trình Quản Lý Điện Năng";
			this.menuBar.ResumeLayout(false);
			this.menuBar.PerformLayout();
			this.contextTabMenu.ResumeLayout(false);
			this.tabForms.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolbar.ResumeLayout(false);
			this.toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuBar;
		private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
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
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolbar;
		private System.Windows.Forms.ToolStripButton btnDongForm;
	}
}

