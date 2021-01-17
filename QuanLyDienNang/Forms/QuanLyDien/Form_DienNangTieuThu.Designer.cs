namespace QuanLyDienNang.Forms
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
			this.tableRightTop = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnKySau = new System.Windows.Forms.Button();
			this.btnKyTruoc = new System.Windows.Forms.Button();
			this.cbxNguoiQuanLy = new System.Windows.Forms.ComboBox();
			this.dtpCuoiKy = new System.Windows.Forms.DateTimePicker();
			this.dtpDauKy = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.btnLapDanhSach = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.btnLoadTheoKy = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tableRightBottom = new System.Windows.Forms.TableLayoutPanel();
			this.btnXuatExcel = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnNhapExcel = new System.Windows.Forms.Button();
			this.btnLapHoaDon = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLeftTop = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnXuatTatCa = new System.Windows.Forms.Button();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkConNo = new System.Windows.Forms.CheckBox();
			this.dtpKetThuc_TK = new System.Windows.Forms.DateTimePicker();
			this.dtpBatDau_TK = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxBangGia = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbxTenTram = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.openDialog = new System.Windows.Forms.OpenFileDialog();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).BeginInit();
			this.tableTop.SuspendLayout();
			this.tableRightTop.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tableRightBottom.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLeftTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
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
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
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
			this.dgvDienNangTieuThu.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.dgvDienNangTieuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDienNangTieuThu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDienNangTieuThu.Location = new System.Drawing.Point(3, 253);
			this.dgvDienNangTieuThu.MultiSelect = false;
			this.dgvDienNangTieuThu.Name = "dgvDienNangTieuThu";
			this.dgvDienNangTieuThu.ReadOnly = true;
			this.dgvDienNangTieuThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDienNangTieuThu.Size = new System.Drawing.Size(1078, 435);
			this.dgvDienNangTieuThu.TabIndex = 1;
			// 
			// tableTop
			// 
			this.tableTop.ColumnCount = 2;
			this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
			this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
			this.tableTop.Controls.Add(this.tableRightTop, 1, 0);
			this.tableTop.Controls.Add(this.groupBox2, 0, 0);
			this.tableTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableTop.Location = new System.Drawing.Point(3, 33);
			this.tableTop.Name = "tableTop";
			this.tableTop.RowCount = 1;
			this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableTop.Size = new System.Drawing.Size(1078, 214);
			this.tableTop.TabIndex = 2;
			// 
			// tableRightTop
			// 
			this.tableRightTop.ColumnCount = 1;
			this.tableRightTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableRightTop.Controls.Add(this.groupBox1, 0, 0);
			this.tableRightTop.Controls.Add(this.groupBox3, 0, 1);
			this.tableRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableRightTop.Location = new System.Drawing.Point(488, 3);
			this.tableRightTop.Name = "tableRightTop";
			this.tableRightTop.RowCount = 2;
			this.tableRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tableRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tableRightTop.Size = new System.Drawing.Size(587, 208);
			this.tableRightTop.TabIndex = 19;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnKySau);
			this.groupBox1.Controls.Add(this.btnKyTruoc);
			this.groupBox1.Controls.Add(this.cbxNguoiQuanLy);
			this.groupBox1.Controls.Add(this.dtpCuoiKy);
			this.groupBox1.Controls.Add(this.dtpDauKy);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.btnLapDanhSach);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.btnLoadTheoKy);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(581, 129);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin về kỳ hiện tại";
			// 
			// btnKySau
			// 
			this.btnKySau.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnKySau.Location = new System.Drawing.Point(470, 83);
			this.btnKySau.Name = "btnKySau";
			this.btnKySau.Size = new System.Drawing.Size(104, 40);
			this.btnKySau.TabIndex = 16;
			this.btnKySau.Text = "Kỳ sau >";
			this.btnKySau.UseVisualStyleBackColor = true;
			this.btnKySau.Click += new System.EventHandler(this.btnKySau_Click);
			// 
			// btnKyTruoc
			// 
			this.btnKyTruoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnKyTruoc.Location = new System.Drawing.Point(10, 83);
			this.btnKyTruoc.Name = "btnKyTruoc";
			this.btnKyTruoc.Size = new System.Drawing.Size(104, 40);
			this.btnKyTruoc.TabIndex = 13;
			this.btnKyTruoc.Text = "< Kỳ trước";
			this.btnKyTruoc.UseVisualStyleBackColor = true;
			this.btnKyTruoc.Click += new System.EventHandler(this.btnKyTruoc_Click);
			// 
			// cbxNguoiQuanLy
			// 
			this.cbxNguoiQuanLy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxNguoiQuanLy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxNguoiQuanLy.FormattingEnabled = true;
			this.cbxNguoiQuanLy.Location = new System.Drawing.Point(213, 53);
			this.cbxNguoiQuanLy.Name = "cbxNguoiQuanLy";
			this.cbxNguoiQuanLy.Size = new System.Drawing.Size(245, 25);
			this.cbxNguoiQuanLy.TabIndex = 12;
			// 
			// dtpCuoiKy
			// 
			this.dtpCuoiKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpCuoiKy.CustomFormat = "dd/MM/yyyy";
			this.dtpCuoiKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpCuoiKy.Location = new System.Drawing.Point(387, 22);
			this.dtpCuoiKy.Name = "dtpCuoiKy";
			this.dtpCuoiKy.Size = new System.Drawing.Size(130, 25);
			this.dtpCuoiKy.TabIndex = 11;
			this.dtpCuoiKy.ValueChanged += new System.EventHandler(this.dtpCuoiKy_ValueChanged);
			// 
			// dtpDauKy
			// 
			this.dtpDauKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpDauKy.CustomFormat = "dd/MM/yyyy";
			this.dtpDauKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDauKy.Location = new System.Drawing.Point(156, 22);
			this.dtpDauKy.Name = "dtpDauKy";
			this.dtpDauKy.Size = new System.Drawing.Size(130, 25);
			this.dtpDauKy.TabIndex = 10;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(61, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(89, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "Ngày đầu kỳ:";
			// 
			// btnLapDanhSach
			// 
			this.btnLapDanhSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLapDanhSach.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.btnLapDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLapDanhSach.Location = new System.Drawing.Point(118, 83);
			this.btnLapDanhSach.Name = "btnLapDanhSach";
			this.btnLapDanhSach.Size = new System.Drawing.Size(162, 40);
			this.btnLapDanhSach.TabIndex = 14;
			this.btnLapDanhSach.Text = "Lập danh sách mới";
			this.btnLapDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLapDanhSach.UseVisualStyleBackColor = true;
			this.btnLapDanhSach.Click += new System.EventHandler(this.btnLapDanhSach_Click);
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(109, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(98, 19);
			this.label11.TabIndex = 0;
			this.label11.Text = "Người quản lý:";
			// 
			// btnLoadTheoKy
			// 
			this.btnLoadTheoKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLoadTheoKy.Image = global::QuanLyDienNang.Properties.Resources.Refresh;
			this.btnLoadTheoKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLoadTheoKy.Location = new System.Drawing.Point(285, 83);
			this.btnLoadTheoKy.Name = "btnLoadTheoKy";
			this.btnLoadTheoKy.Size = new System.Drawing.Size(180, 40);
			this.btnLoadTheoKy.TabIndex = 15;
			this.btnLoadTheoKy.Text = "Lấy danh sách theo kỳ";
			this.btnLoadTheoKy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLoadTheoKy.UseVisualStyleBackColor = true;
			this.btnLoadTheoKy.Click += new System.EventHandler(this.btnLoadTheoKy_Click);
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(290, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(91, 19);
			this.label9.TabIndex = 0;
			this.label9.Text = "Ngày cuối kỳ:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tableRightBottom);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 138);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(581, 67);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Chức năng chính";
			// 
			// tableRightBottom
			// 
			this.tableRightBottom.ColumnCount = 4;
			this.tableRightBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
			this.tableRightBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tableRightBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableRightBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
			this.tableRightBottom.Controls.Add(this.btnXuatExcel, 3, 0);
			this.tableRightBottom.Controls.Add(this.btnLuu, 0, 0);
			this.tableRightBottom.Controls.Add(this.btnNhapExcel, 2, 0);
			this.tableRightBottom.Controls.Add(this.btnLapHoaDon, 1, 0);
			this.tableRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableRightBottom.Location = new System.Drawing.Point(3, 21);
			this.tableRightBottom.Name = "tableRightBottom";
			this.tableRightBottom.RowCount = 1;
			this.tableRightBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableRightBottom.Size = new System.Drawing.Size(575, 43);
			this.tableRightBottom.TabIndex = 10;
			// 
			// btnXuatExcel
			// 
			this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnXuatExcel.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuatExcel.Location = new System.Drawing.Point(473, 3);
			this.btnXuatExcel.Name = "btnXuatExcel";
			this.btnXuatExcel.Size = new System.Drawing.Size(99, 37);
			this.btnXuatExcel.TabIndex = 20;
			this.btnXuatExcel.Text = "Xuất Excel";
			this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuatExcel.UseVisualStyleBackColor = true;
			this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
			// 
			// btnLuu
			// 
			this.btnLuu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLuu.Image = global::QuanLyDienNang.Properties.Resources.Save;
			this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuu.Location = new System.Drawing.Point(3, 3);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(120, 37);
			this.btnLuu.TabIndex = 17;
			this.btnLuu.Text = "Lưu thông tin";
			this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// btnNhapExcel
			// 
			this.btnNhapExcel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnNhapExcel.Image = global::QuanLyDienNang.Properties.Resources.Import;
			this.btnNhapExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhapExcel.Location = new System.Drawing.Point(330, 3);
			this.btnNhapExcel.Name = "btnNhapExcel";
			this.btnNhapExcel.Size = new System.Drawing.Size(137, 37);
			this.btnNhapExcel.TabIndex = 19;
			this.btnNhapExcel.Text = "Nhập từ Excel";
			this.btnNhapExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhapExcel.UseVisualStyleBackColor = true;
			this.btnNhapExcel.Click += new System.EventHandler(this.btnNhapExcel_Click);
			// 
			// btnLapHoaDon
			// 
			this.btnLapHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLapHoaDon.Image = global::QuanLyDienNang.Properties.Resources.Modify;
			this.btnLapHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLapHoaDon.Location = new System.Drawing.Point(129, 3);
			this.btnLapHoaDon.Name = "btnLapHoaDon";
			this.btnLapHoaDon.Size = new System.Drawing.Size(195, 37);
			this.btnLapHoaDon.TabIndex = 18;
			this.btnLapHoaDon.Text = "Tính tiền && Lập hóa đơn";
			this.btnLapHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLapHoaDon.UseVisualStyleBackColor = true;
			this.btnLapHoaDon.Click += new System.EventHandler(this.btnLapHoaDon_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tableLeftTop);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(479, 208);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tìm kiếm các kỳ trước";
			// 
			// tableLeftTop
			// 
			this.tableLeftTop.ColumnCount = 2;
			this.tableLeftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLeftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLeftTop.Controls.Add(this.panel2, 1, 0);
			this.tableLeftTop.Controls.Add(this.panel1, 0, 0);
			this.tableLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLeftTop.Location = new System.Drawing.Point(3, 21);
			this.tableLeftTop.Name = "tableLeftTop";
			this.tableLeftTop.RowCount = 1;
			this.tableLeftTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLeftTop.Size = new System.Drawing.Size(473, 184);
			this.tableLeftTop.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnXuatTatCa);
			this.panel2.Controls.Add(this.btnTimKiem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(381, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(89, 178);
			this.panel2.TabIndex = 18;
			// 
			// btnXuatTatCa
			// 
			this.btnXuatTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnXuatTatCa.Image = global::QuanLyDienNang.Properties.Resources.Search1;
			this.btnXuatTatCa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnXuatTatCa.Location = new System.Drawing.Point(5, 85);
			this.btnXuatTatCa.Name = "btnXuatTatCa";
			this.btnXuatTatCa.Size = new System.Drawing.Size(80, 77);
			this.btnXuatTatCa.TabIndex = 8;
			this.btnXuatTatCa.Text = "Xuất tất cả";
			this.btnXuatTatCa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnXuatTatCa.UseVisualStyleBackColor = true;
			this.btnXuatTatCa.Click += new System.EventHandler(this.btnXuatTatCa_Click);
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTimKiem.Image = global::QuanLyDienNang.Properties.Resources.Search;
			this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnTimKiem.Location = new System.Drawing.Point(5, 26);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(80, 53);
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnTimKiem.UseVisualStyleBackColor = true;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.chkConNo);
			this.panel1.Controls.Add(this.dtpKetThuc_TK);
			this.panel1.Controls.Add(this.dtpBatDau_TK);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.tbxDiaChi);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbxBangGia);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.cbxTenTram);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(372, 178);
			this.panel1.TabIndex = 17;
			// 
			// chkConNo
			// 
			this.chkConNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkConNo.AutoSize = true;
			this.chkConNo.Location = new System.Drawing.Point(85, 136);
			this.chkConNo.Name = "chkConNo";
			this.chkConNo.Size = new System.Drawing.Size(73, 23);
			this.chkConNo.TabIndex = 6;
			this.chkConNo.Text = "Còn nợ";
			this.chkConNo.UseVisualStyleBackColor = true;
			// 
			// dtpKetThuc_TK
			// 
			this.dtpKetThuc_TK.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpKetThuc_TK.CustomFormat = "MM/yyyy";
			this.dtpKetThuc_TK.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpKetThuc_TK.Location = new System.Drawing.Point(283, 16);
			this.dtpKetThuc_TK.Name = "dtpKetThuc_TK";
			this.dtpKetThuc_TK.Size = new System.Drawing.Size(80, 25);
			this.dtpKetThuc_TK.TabIndex = 9;
			// 
			// dtpBatDau_TK
			// 
			this.dtpBatDau_TK.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpBatDau_TK.CustomFormat = "MM/yyyy";
			this.dtpBatDau_TK.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpBatDau_TK.Location = new System.Drawing.Point(154, 16);
			this.dtpBatDau_TK.Name = "dtpBatDau_TK";
			this.dtpBatDau_TK.Size = new System.Drawing.Size(80, 25);
			this.dtpBatDau_TK.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(240, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "Đến:";
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbxDiaChi.Location = new System.Drawing.Point(85, 76);
			this.tbxDiaChi.MaxLength = 250;
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(278, 25);
			this.tbxDiaChi.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(121, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Từ:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(27, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Địa chỉ:";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(7, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(117, 19);
			this.label10.TabIndex = 1;
			this.label10.Text = "Khoảng thời gian:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "Trạm:";
			// 
			// cbxBangGia
			// 
			this.cbxBangGia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxBangGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxBangGia.FormattingEnabled = true;
			this.cbxBangGia.Location = new System.Drawing.Point(85, 105);
			this.cbxBangGia.Name = "cbxBangGia";
			this.cbxBangGia.Size = new System.Drawing.Size(278, 25);
			this.cbxBangGia.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 108);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Bảng giá:";
			// 
			// cbxTenTram
			// 
			this.cbxTenTram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxTenTram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxTenTram.FormattingEnabled = true;
			this.cbxTenTram.Location = new System.Drawing.Point(85, 47);
			this.cbxTenTram.Name = "cbxTenTram";
			this.cbxTenTram.Size = new System.Drawing.Size(278, 25);
			this.cbxTenTram.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(73, 19);
			this.label7.TabIndex = 1;
			this.label7.Text = "Trạng thái:";
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "xlsx";
			this.saveDialog.FileName = "Danh sách DNTT";
			this.saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
			this.saveDialog.RestoreDirectory = true;
			this.saveDialog.Title = "Lưu danh sách khách hàng cùng với điện năng tiêu thụ";
			// 
			// openDialog
			// 
			this.openDialog.Filter = "Excel Workbook (.xlsx)|*.xlsx|Excel 97-2003 Workbook (.xls)|*.xls";
			// 
			// Form_DienNangTieuThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
			this.tableRightTop.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.tableRightBottom.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tableLeftTop.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvDienNangTieuThu;
		private System.Windows.Forms.TableLayoutPanel tableTop;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbxTenTram;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxDiaChi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbxBangGia;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.Button btnLapHoaDon;
		private System.Windows.Forms.CheckBox chkConNo;
		private System.Windows.Forms.Button btnXuatTatCa;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtpBatDau_TK;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtpCuoiKy;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnNhapExcel;
		private System.Windows.Forms.Button btnXuatExcel;
		private System.Windows.Forms.Button btnLapDanhSach;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.TableLayoutPanel tableLeftTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableRightTop;
		private System.Windows.Forms.ComboBox cbxNguoiQuanLy;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DateTimePicker dtpDauKy;
		private System.Windows.Forms.DateTimePicker dtpKetThuc_TK;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.SaveFileDialog saveDialog;
		private System.Windows.Forms.Button btnLoadTheoKy;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.OpenFileDialog openDialog;
		private System.Windows.Forms.Button btnKySau;
		private System.Windows.Forms.Button btnKyTruoc;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TableLayoutPanel tableRightBottom;
	}
}