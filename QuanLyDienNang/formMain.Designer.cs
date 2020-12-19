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
			this.panelParent = new System.Windows.Forms.Panel();
			this.menuBar.SuspendLayout();
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
			// panelParent
			// 
			this.panelParent.BackColor = System.Drawing.Color.Transparent;
			this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelParent.Location = new System.Drawing.Point(0, 24);
			this.panelParent.Name = "panelParent";
			this.panelParent.Size = new System.Drawing.Size(984, 537);
			this.panelParent.TabIndex = 1;
			// 
			// FormMain
			// 
			this.BackgroundImage = global::QuanLyDienNang.Properties.Resources.anh_nen_1;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelParent);
			this.Controls.Add(this.menuBar);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "Chương Trình Quản Lý Điện Năng";
			this.menuBar.ResumeLayout(false);
			this.menuBar.PerformLayout();
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
		private System.Windows.Forms.Panel panelParent;
		private System.Windows.Forms.ToolStripMenuItem đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem;
	}
}

