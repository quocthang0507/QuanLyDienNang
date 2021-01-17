
namespace QuanLyDienNang.Forms
{
	partial class Form_KhachHang
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_KhachHang));
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvKhachHang = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLoadNoiDung = new System.Windows.Forms.Button();
			this.btnChonTapTin = new System.Windows.Forms.Button();
			this.cbxNguoiThucHien = new System.Windows.Forms.ComboBox();
			this.cbxSheet = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxDuongDan = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnLayDanhSach = new System.Windows.Forms.Button();
			this.btnXemMau = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnLuuCSDL = new System.Windows.Forms.Button();
			this.openDialog = new System.Windows.Forms.OpenFileDialog();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.dgvKhachHang, 0, 3);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Controls.Add(this.panel2, 0, 2);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 4;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(933, 588);
			this.tableParent.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(927, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "QUẢN LÝ KHÁCH HÀNG";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvKhachHang
			// 
			this.dgvKhachHang.AllowUserToDeleteRows = false;
			this.dgvKhachHang.AllowUserToResizeRows = false;
			this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvKhachHang.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKhachHang.Location = new System.Drawing.Point(3, 183);
			this.dgvKhachHang.MultiSelect = false;
			this.dgvKhachHang.Name = "dgvKhachHang";
			this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvKhachHang.Size = new System.Drawing.Size(927, 402);
			this.dgvKhachHang.TabIndex = 1;
			this.dgvKhachHang.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellValueChanged);
			this.dgvKhachHang.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvKhachHang_DataBindingComplete);
			this.dgvKhachHang.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvKhachHang_DataError);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnLoadNoiDung);
			this.panel1.Controls.Add(this.btnChonTapTin);
			this.panel1.Controls.Add(this.cbxNguoiThucHien);
			this.panel1.Controls.Add(this.cbxSheet);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tbxDuongDan);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(927, 94);
			this.panel1.TabIndex = 2;
			// 
			// btnLoadNoiDung
			// 
			this.btnLoadNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLoadNoiDung.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.btnLoadNoiDung.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnLoadNoiDung.Location = new System.Drawing.Point(839, 8);
			this.btnLoadNoiDung.Name = "btnLoadNoiDung";
			this.btnLoadNoiDung.Size = new System.Drawing.Size(78, 74);
			this.btnLoadNoiDung.TabIndex = 5;
			this.btnLoadNoiDung.Text = "Load nội dung";
			this.btnLoadNoiDung.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnLoadNoiDung.UseVisualStyleBackColor = true;
			this.btnLoadNoiDung.Click += new System.EventHandler(this.btnLoadNoiDung_Click);
			// 
			// btnChonTapTin
			// 
			this.btnChonTapTin.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnChonTapTin.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnChonTapTin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChonTapTin.Location = new System.Drawing.Point(712, 8);
			this.btnChonTapTin.Name = "btnChonTapTin";
			this.btnChonTapTin.Size = new System.Drawing.Size(122, 40);
			this.btnChonTapTin.TabIndex = 2;
			this.btnChonTapTin.Text = "Chọn tập tin";
			this.btnChonTapTin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChonTapTin.UseVisualStyleBackColor = true;
			this.btnChonTapTin.Click += new System.EventHandler(this.btnChonTapTin_Click);
			// 
			// cbxNguoiThucHien
			// 
			this.cbxNguoiThucHien.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxNguoiThucHien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxNguoiThucHien.FormattingEnabled = true;
			this.cbxNguoiThucHien.Location = new System.Drawing.Point(549, 53);
			this.cbxNguoiThucHien.Name = "cbxNguoiThucHien";
			this.cbxNguoiThucHien.Size = new System.Drawing.Size(284, 25);
			this.cbxNguoiThucHien.TabIndex = 4;
			// 
			// cbxSheet
			// 
			this.cbxSheet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSheet.FormattingEnabled = true;
			this.cbxSheet.Location = new System.Drawing.Point(99, 53);
			this.cbxSheet.Name = "cbxSheet";
			this.cbxSheet.Size = new System.Drawing.Size(284, 25);
			this.cbxSheet.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(423, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 19);
			this.label4.TabIndex = 13;
			this.label4.Text = "Người thực hiện:";
			// 
			// tbxDuongDan
			// 
			this.tbxDuongDan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxDuongDan.Location = new System.Drawing.Point(99, 18);
			this.tbxDuongDan.Margin = new System.Windows.Forms.Padding(4);
			this.tbxDuongDan.Name = "tbxDuongDan";
			this.tbxDuongDan.Size = new System.Drawing.Size(606, 23);
			this.tbxDuongDan.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 19);
			this.label2.TabIndex = 14;
			this.label2.Text = "Chọn sheet:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 19);
			this.label3.TabIndex = 15;
			this.label3.Text = "Đường dẫn:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnLayDanhSach);
			this.panel2.Controls.Add(this.btnXemMau);
			this.panel2.Controls.Add(this.btnXoa);
			this.panel2.Controls.Add(this.btnThem);
			this.panel2.Controls.Add(this.btnLuuCSDL);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 133);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(927, 44);
			this.panel2.TabIndex = 3;
			// 
			// btnLayDanhSach
			// 
			this.btnLayDanhSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLayDanhSach.Image = global::QuanLyDienNang.Properties.Resources.User;
			this.btnLayDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLayDanhSach.Location = new System.Drawing.Point(160, 1);
			this.btnLayDanhSach.Name = "btnLayDanhSach";
			this.btnLayDanhSach.Size = new System.Drawing.Size(170, 42);
			this.btnLayDanhSach.TabIndex = 6;
			this.btnLayDanhSach.Text = "Lấy tất cả danh sách";
			this.btnLayDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLayDanhSach.UseVisualStyleBackColor = true;
			this.btnLayDanhSach.Click += new System.EventHandler(this.btnLayDanhSach_Click);
			// 
			// btnXemMau
			// 
			this.btnXemMau.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXemMau.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnXemMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXemMau.Location = new System.Drawing.Point(336, 1);
			this.btnXemMau.Name = "btnXemMau";
			this.btnXemMau.Size = new System.Drawing.Size(107, 42);
			this.btnXemMau.TabIndex = 7;
			this.btnXemMau.Text = "Xem mẫu";
			this.btnXemMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXemMau.UseVisualStyleBackColor = true;
			this.btnXemMau.Click += new System.EventHandler(this.btnXemMau_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXoa.Image = global::QuanLyDienNang.Properties.Resources.delete;
			this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXoa.Location = new System.Drawing.Point(693, 2);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(73, 40);
			this.btnXoa.TabIndex = 10;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(600, 2);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(85, 40);
			this.btnThem.TabIndex = 9;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// btnLuuCSDL
			// 
			this.btnLuuCSDL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLuuCSDL.Image = global::QuanLyDienNang.Properties.Resources.Import;
			this.btnLuuCSDL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuuCSDL.Location = new System.Drawing.Point(449, 2);
			this.btnLuuCSDL.Name = "btnLuuCSDL";
			this.btnLuuCSDL.Size = new System.Drawing.Size(145, 40);
			this.btnLuuCSDL.TabIndex = 8;
			this.btnLuuCSDL.Text = "Nhập vào CSDL";
			this.btnLuuCSDL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLuuCSDL.UseVisualStyleBackColor = true;
			this.btnLuuCSDL.Click += new System.EventHandler(this.btnLuuCSDL_Click);
			// 
			// openDialog
			// 
			this.openDialog.Filter = "Excel Workbook (.xlsx)|*.xlsx|Excel 97-2003 Workbook (.xls)|*.xls";
			// 
			// Form_KhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(933, 588);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_KhachHang";
			this.Text = "Quản Lý Khách Hàng";
			this.Shown += new System.EventHandler(this.Form_KhachHang_Shown);
			this.tableParent.ResumeLayout(false);
			this.tableParent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvKhachHang;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnChonTapTin;
		private System.Windows.Forms.ComboBox cbxNguoiThucHien;
		private System.Windows.Forms.ComboBox cbxSheet;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxDuongDan;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLoadNoiDung;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnLuuCSDL;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnXemMau;
		private System.Windows.Forms.OpenFileDialog openDialog;
		private System.Windows.Forms.Button btnLayDanhSach;
	}
}