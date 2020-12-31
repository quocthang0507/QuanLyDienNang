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
			this.dtpNgayHoaDon = new System.Windows.Forms.DateTimePicker();
			this.btnNhapExcel = new System.Windows.Forms.Button();
			this.btnXuatExcel = new System.Windows.Forms.Button();
			this.btnCapNhatKy = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnLapHoaDon = new System.Windows.Forms.Button();
			this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
			this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkConNo = new System.Windows.Forms.CheckBox();
			this.btnTimKiemTatCa = new System.Windows.Forms.Button();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxBangGia = new System.Windows.Forms.ComboBox();
			this.cbxTenTram = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nudNam = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nudThang = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLeftTop = new System.Windows.Forms.TableLayoutPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tableRightTop = new System.Windows.Forms.TableLayoutPanel();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).BeginInit();
			this.tableTop.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudNam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudThang)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLeftTop.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tableRightTop.SuspendLayout();
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
			this.groupBox1.Controls.Add(this.tableRightTop);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(434, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(641, 178);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin về chu kỳ";
			// 
			// dtpNgayHoaDon
			// 
			this.dtpNgayHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.dtpNgayHoaDon.CustomFormat = "dd/MM/yyyy";
			this.dtpNgayHoaDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpNgayHoaDon.Location = new System.Drawing.Point(269, 49);
			this.dtpNgayHoaDon.Name = "dtpNgayHoaDon";
			this.dtpNgayHoaDon.Size = new System.Drawing.Size(140, 25);
			this.dtpNgayHoaDon.TabIndex = 11;
			// 
			// btnNhapExcel
			// 
			this.btnNhapExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.btnNhapExcel.Image = global::QuanLyDienNang.Properties.Resources.Import;
			this.btnNhapExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhapExcel.Location = new System.Drawing.Point(313, 7);
			this.btnNhapExcel.Name = "btnNhapExcel";
			this.btnNhapExcel.Size = new System.Drawing.Size(145, 40);
			this.btnNhapExcel.TabIndex = 15;
			this.btnNhapExcel.Text = "Nhập từ Excel";
			this.btnNhapExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhapExcel.UseVisualStyleBackColor = true;
			// 
			// btnXuatExcel
			// 
			this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.btnXuatExcel.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuatExcel.Location = new System.Drawing.Point(464, 7);
			this.btnXuatExcel.Name = "btnXuatExcel";
			this.btnXuatExcel.Size = new System.Drawing.Size(122, 40);
			this.btnXuatExcel.TabIndex = 16;
			this.btnXuatExcel.Text = "Xuất Excel";
			this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuatExcel.UseVisualStyleBackColor = true;
			// 
			// btnCapNhatKy
			// 
			this.btnCapNhatKy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCapNhatKy.Image = global::QuanLyDienNang.Properties.Resources.Refresh;
			this.btnCapNhatKy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCapNhatKy.Location = new System.Drawing.Point(502, 12);
			this.btnCapNhatKy.Name = "btnCapNhatKy";
			this.btnCapNhatKy.Size = new System.Drawing.Size(95, 60);
			this.btnCapNhatKy.TabIndex = 12;
			this.btnCapNhatKy.Text = "Cập nhật kỳ";
			this.btnCapNhatKy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCapNhatKy.UseVisualStyleBackColor = true;
			this.btnCapNhatKy.Click += new System.EventHandler(this.btnCapNhatKy_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.button1.Image = global::QuanLyDienNang.Properties.Resources.Save;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(46, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(133, 40);
			this.button1.TabIndex = 13;
			this.button1.Text = "Lưu thông tin";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnLapHoaDon
			// 
			this.btnLapHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.btnLapHoaDon.Image = global::QuanLyDienNang.Properties.Resources.Modify;
			this.btnLapHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLapHoaDon.Location = new System.Drawing.Point(185, 7);
			this.btnLapHoaDon.Name = "btnLapHoaDon";
			this.btnLapHoaDon.Size = new System.Drawing.Size(122, 40);
			this.btnLapHoaDon.TabIndex = 14;
			this.btnLapHoaDon.Text = "Lập hóa đơn";
			this.btnLapHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLapHoaDon.UseVisualStyleBackColor = true;
			// 
			// dtpKetThuc
			// 
			this.dtpKetThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.dtpKetThuc.CustomFormat = "dd/MM/yyyy";
			this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpKetThuc.Location = new System.Drawing.Point(346, 12);
			this.dtpKetThuc.Name = "dtpKetThuc";
			this.dtpKetThuc.Size = new System.Drawing.Size(140, 25);
			this.dtpKetThuc.TabIndex = 10;
			// 
			// dtpBatDau
			// 
			this.dtpBatDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.dtpBatDau.CustomFormat = "dd/MM/yyyy";
			this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpBatDau.Location = new System.Drawing.Point(123, 12);
			this.dtpBatDau.Name = "dtpBatDau";
			this.dtpBatDau.Size = new System.Drawing.Size(140, 25);
			this.dtpBatDau.TabIndex = 9;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(164, 51);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(99, 19);
			this.label10.TabIndex = 0;
			this.label10.Text = "Ngày hóa đơn:";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(269, 18);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 19);
			this.label9.TabIndex = 0;
			this.label9.Text = "Đến ngày:";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(56, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "Từ ngày:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tableLeftTop);
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
			this.chkConNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkConNo.AutoSize = true;
			this.chkConNo.Location = new System.Drawing.Point(81, 125);
			this.chkConNo.Name = "chkConNo";
			this.chkConNo.Size = new System.Drawing.Size(73, 23);
			this.chkConNo.TabIndex = 6;
			this.chkConNo.Text = "Còn nợ";
			this.chkConNo.UseVisualStyleBackColor = true;
			// 
			// btnTimKiemTatCa
			// 
			this.btnTimKiemTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTimKiemTatCa.Image = global::QuanLyDienNang.Properties.Resources.Search1;
			this.btnTimKiemTatCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTimKiemTatCa.Location = new System.Drawing.Point(7, 77);
			this.btnTimKiemTatCa.Name = "btnTimKiemTatCa";
			this.btnTimKiemTatCa.Size = new System.Drawing.Size(106, 43);
			this.btnTimKiemTatCa.TabIndex = 8;
			this.btnTimKiemTatCa.Text = "TK tất cả";
			this.btnTimKiemTatCa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimKiemTatCa.UseVisualStyleBackColor = true;
			this.btnTimKiemTatCa.Click += new System.EventHandler(this.btnTimKiemTatCa_Click);
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTimKiem.Image = global::QuanLyDienNang.Properties.Resources.Search;
			this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTimKiem.Location = new System.Drawing.Point(7, 30);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(106, 41);
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimKiem.UseVisualStyleBackColor = true;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbxDiaChi.Location = new System.Drawing.Point(81, 64);
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(193, 25);
			this.tbxDiaChi.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Địa chỉ:";
			// 
			// cbxBangGia
			// 
			this.cbxBangGia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxBangGia.DisplayMember = "TenBangGia";
			this.cbxBangGia.FormattingEnabled = true;
			this.cbxBangGia.Location = new System.Drawing.Point(81, 95);
			this.cbxBangGia.Name = "cbxBangGia";
			this.cbxBangGia.Size = new System.Drawing.Size(193, 25);
			this.cbxBangGia.TabIndex = 5;
			this.cbxBangGia.ValueMember = "TenBangGia";
			// 
			// cbxTenTram
			// 
			this.cbxTenTram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxTenTram.DisplayMember = "TenTram";
			this.cbxTenTram.FormattingEnabled = true;
			this.cbxTenTram.Location = new System.Drawing.Point(81, 33);
			this.cbxTenTram.Name = "cbxTenTram";
			this.cbxTenTram.Size = new System.Drawing.Size(193, 25);
			this.cbxTenTram.TabIndex = 3;
			this.cbxTenTram.ValueMember = "TenTram";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 123);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(73, 19);
			this.label7.TabIndex = 1;
			this.label7.Text = "Trạng thái:";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 98);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Bảng giá:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "Trạm:";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(148, 6);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 19);
			this.label6.TabIndex = 1;
			this.label6.Text = "Năm:";
			// 
			// nudNam
			// 
			this.nudNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.nudNam.Location = new System.Drawing.Point(195, 4);
			this.nudNam.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
			this.nudNam.Minimum = new decimal(new int[] {
            1,
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
			this.label2.Location = new System.Drawing.Point(26, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tháng:";
			// 
			// nudThang
			// 
			this.nudThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.nudThang.Location = new System.Drawing.Point(81, 4);
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
			// panel1
			// 
			this.panel1.Controls.Add(this.chkConNo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.nudThang);
			this.panel1.Controls.Add(this.nudNam);
			this.panel1.Controls.Add(this.tbxDiaChi);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbxBangGia);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.cbxTenTram);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(287, 148);
			this.panel1.TabIndex = 17;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnTimKiemTatCa);
			this.panel2.Controls.Add(this.btnTimKiem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(296, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(120, 148);
			this.panel2.TabIndex = 18;
			// 
			// tableLeftTop
			// 
			this.tableLeftTop.ColumnCount = 2;
			this.tableLeftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLeftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLeftTop.Controls.Add(this.panel2, 1, 0);
			this.tableLeftTop.Controls.Add(this.panel1, 0, 0);
			this.tableLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLeftTop.Location = new System.Drawing.Point(3, 21);
			this.tableLeftTop.Name = "tableLeftTop";
			this.tableLeftTop.RowCount = 1;
			this.tableLeftTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLeftTop.Size = new System.Drawing.Size(419, 154);
			this.tableLeftTop.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnXuatExcel);
			this.panel3.Controls.Add(this.btnLapHoaDon);
			this.panel3.Controls.Add(this.btnNhapExcel);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 95);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(629, 56);
			this.panel3.TabIndex = 17;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dtpBatDau);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.dtpNgayHoaDon);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.btnCapNhatKy);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Controls.Add(this.dtpKetThuc);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(629, 86);
			this.panel4.TabIndex = 18;
			// 
			// tableRightTop
			// 
			this.tableRightTop.ColumnCount = 1;
			this.tableRightTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableRightTop.Controls.Add(this.panel4, 0, 0);
			this.tableRightTop.Controls.Add(this.panel3, 0, 1);
			this.tableRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableRightTop.Location = new System.Drawing.Point(3, 21);
			this.tableRightTop.Name = "tableRightTop";
			this.tableRightTop.RowCount = 2;
			this.tableRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableRightTop.Size = new System.Drawing.Size(635, 154);
			this.tableRightTop.TabIndex = 19;
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
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudNam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudThang)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tableLeftTop.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.tableRightTop.ResumeLayout(false);
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
		private System.Windows.Forms.ComboBox cbxTenTram;
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
		private System.Windows.Forms.TableLayoutPanel tableLeftTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableRightTop;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
	}
}