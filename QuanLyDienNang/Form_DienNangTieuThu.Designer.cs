namespace QuanLyDienNang
{
    partial class Form_DienNangTieuThu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DienNangTieuThu));
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvDienNangTieuThu = new System.Windows.Forms.DataGridView();
			this.tableTop = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkConNo = new System.Windows.Forms.CheckBox();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxBangGia = new System.Windows.Forms.ComboBox();
			this.cbxTramBienAp = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nudNam = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nudThang = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.dtpNgayHoaDon = new System.Windows.Forms.DateTimePicker();
			this.btnNhapExcel = new System.Windows.Forms.Button();
			this.btnXuatExcel = new System.Windows.Forms.Button();
			this.btnCapNhatKy = new System.Windows.Forms.Button();
			this.btnLapHoaDon = new System.Windows.Forms.Button();
			this.btnTimKiemTatCa = new System.Windows.Forms.Button();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).BeginInit();
			this.tableTop.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudNam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudThang)).BeginInit();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.dgvDienNangTieuThu, 0, 2);
			this.tableParent.Controls.Add(this.tableTop, 0, 1);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 3;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(1084, 661);
			this.tableParent.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(297, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(490, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "NHẬP CHỈ SỐ ĐIỆN NĂNG TIÊU THỤ VÀ IN HÓA ĐƠN";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvDienNangTieuThu
			// 
			this.dgvDienNangTieuThu.AllowUserToAddRows = false;
			this.dgvDienNangTieuThu.AllowUserToDeleteRows = false;
			this.dgvDienNangTieuThu.AllowUserToResizeRows = false;
			this.dgvDienNangTieuThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDienNangTieuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDienNangTieuThu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDienNangTieuThu.Location = new System.Drawing.Point(3, 223);
			this.dgvDienNangTieuThu.MultiSelect = false;
			this.dgvDienNangTieuThu.Name = "dgvDienNangTieuThu";
			this.dgvDienNangTieuThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDienNangTieuThu.Size = new System.Drawing.Size(1078, 435);
			this.dgvDienNangTieuThu.TabIndex = 1;
			// 
			// tableTop
			// 
			this.tableTop.ColumnCount = 2;
			this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableTop.Controls.Add(this.groupBox1, 1, 0);
			this.tableTop.Controls.Add(this.groupBox2, 0, 0);
			this.tableTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableTop.Location = new System.Drawing.Point(3, 33);
			this.tableTop.Name = "tableTop";
			this.tableTop.RowCount = 1;
			this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableTop.Size = new System.Drawing.Size(1078, 184);
			this.tableTop.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtpNgayHoaDon);
			this.groupBox1.Controls.Add(this.btnNhapExcel);
			this.groupBox1.Controls.Add(this.btnXuatExcel);
			this.groupBox1.Controls.Add(this.btnCapNhatKy);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.btnLapHoaDon);
			this.groupBox1.Controls.Add(this.dtpKetThuc);
			this.groupBox1.Controls.Add(this.dtpBatDau);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(434, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(641, 178);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin về chu kỳ";
			// 
			// dtpBatDau
			// 
			this.dtpBatDau.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpBatDau.CustomFormat = "dd/MM/yyyy";
			this.dtpBatDau.Location = new System.Drawing.Point(75, 26);
			this.dtpBatDau.Name = "dtpBatDau";
			this.dtpBatDau.Size = new System.Drawing.Size(180, 25);
			this.dtpBatDau.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "Từ ngày:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkConNo);
			this.groupBox2.Controls.Add(this.btnTimKiemTatCa);
			this.groupBox2.Controls.Add(this.btnTimKiem);
			this.groupBox2.Controls.Add(this.tbxDiaChi);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.cbxBangGia);
			this.groupBox2.Controls.Add(this.cbxTramBienAp);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.nudNam);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.nudThang);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(425, 178);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin tìm kiếm";
			// 
			// chkConNo
			// 
			this.chkConNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkConNo.AutoSize = true;
			this.chkConNo.Location = new System.Drawing.Point(81, 149);
			this.chkConNo.Name = "chkConNo";
			this.chkConNo.Size = new System.Drawing.Size(73, 23);
			this.chkConNo.TabIndex = 6;
			this.chkConNo.Text = "Còn nợ";
			this.chkConNo.UseVisualStyleBackColor = true;
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDiaChi.Location = new System.Drawing.Point(81, 87);
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(223, 25);
			this.tbxDiaChi.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Địa chỉ:";
			// 
			// cbxBangGia
			// 
			this.cbxBangGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxBangGia.FormattingEnabled = true;
			this.cbxBangGia.Location = new System.Drawing.Point(81, 120);
			this.cbxBangGia.Name = "cbxBangGia";
			this.cbxBangGia.Size = new System.Drawing.Size(223, 25);
			this.cbxBangGia.TabIndex = 5;
			// 
			// cbxTramBienAp
			// 
			this.cbxTramBienAp.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxTramBienAp.FormattingEnabled = true;
			this.cbxTramBienAp.Location = new System.Drawing.Point(81, 55);
			this.cbxTramBienAp.Name = "cbxTramBienAp";
			this.cbxTramBienAp.Size = new System.Drawing.Size(223, 25);
			this.cbxTramBienAp.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 151);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(73, 19);
			this.label7.TabIndex = 1;
			this.label7.Text = "Trạng thái:";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 123);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Bảng giá:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "Trạm:";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(148, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 19);
			this.label6.TabIndex = 1;
			this.label6.Text = "Năm:";
			// 
			// nudNam
			// 
			this.nudNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.nudNam.Location = new System.Drawing.Point(195, 24);
			this.nudNam.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
			this.nudNam.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
			this.nudNam.Name = "nudNam";
			this.nudNam.Size = new System.Drawing.Size(79, 25);
			this.nudNam.TabIndex = 2;
			this.nudNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudNam.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tháng:";
			// 
			// nudThang
			// 
			this.nudThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.nudThang.Location = new System.Drawing.Point(81, 24);
			this.nudThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.nudThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudThang.Name = "nudThang";
			this.nudThang.Size = new System.Drawing.Size(61, 25);
			this.nudThang.TabIndex = 1;
			this.nudThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudThang.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(267, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 19);
			this.label9.TabIndex = 0;
			this.label9.Text = "Đến ngày:";
			// 
			// dtpKetThuc
			// 
			this.dtpKetThuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpKetThuc.CustomFormat = "dd/MM/yyyy";
			this.dtpKetThuc.Location = new System.Drawing.Point(344, 26);
			this.dtpKetThuc.Name = "dtpKetThuc";
			this.dtpKetThuc.Size = new System.Drawing.Size(180, 25);
			this.dtpKetThuc.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(140, 61);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(99, 19);
			this.label10.TabIndex = 0;
			this.label10.Text = "Ngày hóa đơn:";
			// 
			// dtpNgayHoaDon
			// 
			this.dtpNgayHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpNgayHoaDon.CustomFormat = "dd/MM/yyyy";
			this.dtpNgayHoaDon.Location = new System.Drawing.Point(245, 59);
			this.dtpNgayHoaDon.Name = "dtpNgayHoaDon";
			this.dtpNgayHoaDon.Size = new System.Drawing.Size(180, 25);
			this.dtpNgayHoaDon.TabIndex = 11;
			// 
			// btnNhapExcel
			// 
			this.btnNhapExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnNhapExcel.Image = global::QuanLyDienNang.Properties.Resources.Import;
			this.btnNhapExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhapExcel.Location = new System.Drawing.Point(336, 102);
			this.btnNhapExcel.Name = "btnNhapExcel";
			this.btnNhapExcel.Size = new System.Drawing.Size(145, 40);
			this.btnNhapExcel.TabIndex = 15;
			this.btnNhapExcel.Text = "Nhập từ Excel";
			this.btnNhapExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhapExcel.UseVisualStyleBackColor = true;
			// 
			// btnXuatExcel
			// 
			this.btnXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXuatExcel.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuatExcel.Location = new System.Drawing.Point(487, 102);
			this.btnXuatExcel.Name = "btnXuatExcel";
			this.btnXuatExcel.Size = new System.Drawing.Size(122, 40);
			this.btnXuatExcel.TabIndex = 16;
			this.btnXuatExcel.Text = "Xuất Excel";
			this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuatExcel.UseVisualStyleBackColor = true;
			// 
			// btnCapNhatKy
			// 
			this.btnCapNhatKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCapNhatKy.Image = global::QuanLyDienNang.Properties.Resources.Refresh;
			this.btnCapNhatKy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCapNhatKy.Location = new System.Drawing.Point(540, 26);
			this.btnCapNhatKy.Name = "btnCapNhatKy";
			this.btnCapNhatKy.Size = new System.Drawing.Size(95, 60);
			this.btnCapNhatKy.TabIndex = 12;
			this.btnCapNhatKy.Text = "Cập nhật kỳ";
			this.btnCapNhatKy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCapNhatKy.UseVisualStyleBackColor = true;
			// 
			// btnLapHoaDon
			// 
			this.btnLapHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLapHoaDon.Image = global::QuanLyDienNang.Properties.Resources.Modify;
			this.btnLapHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLapHoaDon.Location = new System.Drawing.Point(208, 102);
			this.btnLapHoaDon.Name = "btnLapHoaDon";
			this.btnLapHoaDon.Size = new System.Drawing.Size(122, 40);
			this.btnLapHoaDon.TabIndex = 14;
			this.btnLapHoaDon.Text = "Lập hóa đơn";
			this.btnLapHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLapHoaDon.UseVisualStyleBackColor = true;
			// 
			// btnTimKiemTatCa
			// 
			this.btnTimKiemTatCa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnTimKiemTatCa.Image = global::QuanLyDienNang.Properties.Resources.Search1;
			this.btnTimKiemTatCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTimKiemTatCa.Location = new System.Drawing.Point(310, 102);
			this.btnTimKiemTatCa.Name = "btnTimKiemTatCa";
			this.btnTimKiemTatCa.Size = new System.Drawing.Size(106, 40);
			this.btnTimKiemTatCa.TabIndex = 8;
			this.btnTimKiemTatCa.Text = "TK tất cả";
			this.btnTimKiemTatCa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimKiemTatCa.UseVisualStyleBackColor = true;
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnTimKiem.Image = global::QuanLyDienNang.Properties.Resources.Search;
			this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTimKiem.Location = new System.Drawing.Point(310, 56);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(106, 40);
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimKiem.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.Image = global::QuanLyDienNang.Properties.Resources.Save;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(69, 102);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(133, 40);
			this.button1.TabIndex = 13;
			this.button1.Text = "Lưu thông tin";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// Form_DienNangTieuThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 661);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form_DienNangTieuThu";
			this.Text = "Thông Tin Điện Năng Tiêu Thụ Của Khách Hàng";
			this.Shown += new System.EventHandler(this.FormKH_DienNangTieuThu_Shown);
			this.tableParent.ResumeLayout(false);
			this.tableParent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).EndInit();
			this.tableTop.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudNam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudThang)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvDienNangTieuThu;
		private System.Windows.Forms.TableLayoutPanel tableTop;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudThang;
		private System.Windows.Forms.ComboBox cbxTramBienAp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxDiaChi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbxBangGia;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.Button btnLapHoaDon;
		private System.Windows.Forms.CheckBox chkConNo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nudNam;
		private System.Windows.Forms.Button btnTimKiemTatCa;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtpBatDau;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtpNgayHoaDon;
		private System.Windows.Forms.DateTimePicker dtpKetThuc;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnNhapExcel;
		private System.Windows.Forms.Button btnXuatExcel;
		private System.Windows.Forms.Button btnCapNhatKy;
		private System.Windows.Forms.Button button1;
	}
}