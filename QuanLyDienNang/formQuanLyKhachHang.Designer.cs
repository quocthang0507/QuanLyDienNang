namespace QuanLyDienNang
{
    partial class FormQuanLyKhachHang
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLyKhachHang));
			this.label1 = new System.Windows.Forms.Label();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnChiTiet = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxTenKhachHang = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxMaKhachHang = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(978, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "QUẢN LÝ KHÁCH HÀNG";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(125, 0);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(109, 40);
			this.btnThem.TabIndex = 3;
			this.btnThem.Text = "Thêm mới";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// btnSua
			// 
			this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnSua.Image = global::QuanLyDienNang.Properties.Resources.Rename;
			this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSua.Location = new System.Drawing.Point(240, 0);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(109, 40);
			this.btnSua.TabIndex = 3;
			this.btnSua.Text = "Sửa";
			this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSua.UseVisualStyleBackColor = true;
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLoad.Image = global::QuanLyDienNang.Properties.Resources.Synchronize;
			this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLoad.Location = new System.Drawing.Point(355, 0);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(131, 40);
			this.btnLoad.TabIndex = 3;
			this.btnLoad.Text = "Load dữ liệu";
			this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLoad.UseVisualStyleBackColor = true;
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXoa.Image = global::QuanLyDienNang.Properties.Resources.Remove;
			this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXoa.Location = new System.Drawing.Point(493, 0);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(103, 40);
			this.btnXoa.TabIndex = 3;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// btnChiTiet
			// 
			this.btnChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnChiTiet.Image = global::QuanLyDienNang.Properties.Resources.Info;
			this.btnChiTiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChiTiet.Location = new System.Drawing.Point(602, 0);
			this.btnChiTiet.Name = "btnChiTiet";
			this.btnChiTiet.Size = new System.Drawing.Size(103, 40);
			this.btnChiTiet.TabIndex = 3;
			this.btnChiTiet.Text = "Chi tiết";
			this.btnChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChiTiet.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(69, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tìm tên khách hàng:";
			// 
			// tbxTenKhachHang
			// 
			this.tbxTenKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxTenKhachHang.Location = new System.Drawing.Point(212, 9);
			this.tbxTenKhachHang.Name = "tbxTenKhachHang";
			this.tbxTenKhachHang.Size = new System.Drawing.Size(211, 23);
			this.tbxTenKhachHang.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(444, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Mã khách hàng:";
			// 
			// tbxMaKhachHang
			// 
			this.tbxMaKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaKhachHang.Location = new System.Drawing.Point(559, 10);
			this.tbxMaKhachHang.Name = "tbxMaKhachHang";
			this.tbxMaKhachHang.Size = new System.Drawing.Size(189, 23);
			this.tbxMaKhachHang.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(711, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 40);
			this.button1.TabIndex = 3;
			this.button1.Text = "Xuất Excel";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 561);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 133);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(978, 425);
			this.dataGridView1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnChiTiet);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.btnSua);
			this.panel1.Controls.Add(this.btnLoad);
			this.panel1.Controls.Add(this.btnXoa);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 44);
			this.panel1.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.tbxTenKhachHang);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.tbxMaKhachHang);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 83);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 44);
			this.panel2.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button2.Image = global::QuanLyDienNang.Properties.Resources.Search;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(754, 1);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 40);
			this.button2.TabIndex = 7;
			this.button2.Text = "Tìm kiếm";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// FormQuanLyKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FormQuanLyKhachHang";
			this.Text = "Quản Lý Khách Hàng";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnChiTiet;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxTenKhachHang;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxMaKhachHang;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button2;
	}
}