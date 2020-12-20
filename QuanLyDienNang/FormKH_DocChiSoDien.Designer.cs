
namespace QuanLyDienNang
{
	partial class FormKH_DocChiSoDien
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
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnChayServer = new System.Windows.Forms.Button();
			this.btnMoThuMuc = new System.Windows.Forms.Button();
			this.tbxDuongDan = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tableParentBottom = new System.Windows.Forms.TableLayoutPanel();
			this.lbxHinhAnh = new System.Windows.Forms.ListBox();
			this.tableParentRight = new System.Windows.Forms.TableLayoutPanel();
			this.pbxHinhAnh = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tbxChiSoDien = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxMaKhachHang = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnLuuFile = new System.Windows.Forms.Button();
			this.btnDung = new System.Windows.Forms.Button();
			this.btnNhanDienTatCa = new System.Windows.Forms.Button();
			this.btnNhanDien = new System.Windows.Forms.Button();
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btnDong = new System.Windows.Forms.Button();
			this.tableParent.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableParentBottom.SuspendLayout();
			this.tableParentRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxHinhAnh)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Controls.Add(this.tableParentBottom, 0, 2);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Margin = new System.Windows.Forms.Padding(4);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 3;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(976, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "ĐỌC CHỈ SỐ ĐIỆN VÀ MÃ KHÁCH HÀNG TỪ HÌNH ẢNH";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnDong);
			this.panel1.Controls.Add(this.btnChayServer);
			this.panel1.Controls.Add(this.btnMoThuMuc);
			this.panel1.Controls.Add(this.tbxDuongDan);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 80);
			this.panel1.TabIndex = 1;
			// 
			// btnChayServer
			// 
			this.btnChayServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnChayServer.Image = global::QuanLyDienNang.Properties.Resources.Play;
			this.btnChayServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChayServer.Location = new System.Drawing.Point(422, 32);
			this.btnChayServer.Name = "btnChayServer";
			this.btnChayServer.Size = new System.Drawing.Size(177, 40);
			this.btnChayServer.TabIndex = 3;
			this.btnChayServer.Text = "Chạy server Python";
			this.btnChayServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChayServer.UseVisualStyleBackColor = true;
			this.btnChayServer.Click += new System.EventHandler(this.btnChayServer_Click);
			// 
			// btnMoThuMuc
			// 
			this.btnMoThuMuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnMoThuMuc.Image = global::QuanLyDienNang.Properties.Resources.Open;
			this.btnMoThuMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnMoThuMuc.Location = new System.Drawing.Point(273, 32);
			this.btnMoThuMuc.Name = "btnMoThuMuc";
			this.btnMoThuMuc.Size = new System.Drawing.Size(143, 40);
			this.btnMoThuMuc.TabIndex = 2;
			this.btnMoThuMuc.Text = "Chọn thư mục";
			this.btnMoThuMuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnMoThuMuc.UseVisualStyleBackColor = true;
			this.btnMoThuMuc.Click += new System.EventHandler(this.btnMoThuMuc_Click);
			// 
			// tbxDuongDan
			// 
			this.tbxDuongDan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDuongDan.Location = new System.Drawing.Point(322, 3);
			this.tbxDuongDan.Name = "tbxDuongDan";
			this.tbxDuongDan.Size = new System.Drawing.Size(563, 23);
			this.tbxDuongDan.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(93, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(223, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Đường dẫn đến thư mục hình ảnh:";
			// 
			// tableParentBottom
			// 
			this.tableParentBottom.ColumnCount = 2;
			this.tableParentBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableParentBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableParentBottom.Controls.Add(this.lbxHinhAnh, 0, 0);
			this.tableParentBottom.Controls.Add(this.tableParentRight, 1, 0);
			this.tableParentBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParentBottom.Location = new System.Drawing.Point(3, 126);
			this.tableParentBottom.Name = "tableParentBottom";
			this.tableParentBottom.RowCount = 1;
			this.tableParentBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableParentBottom.Size = new System.Drawing.Size(978, 432);
			this.tableParentBottom.TabIndex = 2;
			// 
			// lbxHinhAnh
			// 
			this.lbxHinhAnh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbxHinhAnh.FormattingEnabled = true;
			this.lbxHinhAnh.ItemHeight = 16;
			this.lbxHinhAnh.Location = new System.Drawing.Point(3, 3);
			this.lbxHinhAnh.Name = "lbxHinhAnh";
			this.lbxHinhAnh.Size = new System.Drawing.Size(483, 426);
			this.lbxHinhAnh.TabIndex = 0;
			this.lbxHinhAnh.SelectedIndexChanged += new System.EventHandler(this.lbxHinhAnh_SelectedIndexChanged);
			// 
			// tableParentRight
			// 
			this.tableParentRight.ColumnCount = 1;
			this.tableParentRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParentRight.Controls.Add(this.pbxHinhAnh, 0, 0);
			this.tableParentRight.Controls.Add(this.panel2, 0, 1);
			this.tableParentRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParentRight.Location = new System.Drawing.Point(492, 3);
			this.tableParentRight.Name = "tableParentRight";
			this.tableParentRight.RowCount = 2;
			this.tableParentRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableParentRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableParentRight.Size = new System.Drawing.Size(483, 426);
			this.tableParentRight.TabIndex = 1;
			// 
			// pbxHinhAnh
			// 
			this.pbxHinhAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pbxHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbxHinhAnh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbxHinhAnh.Location = new System.Drawing.Point(3, 3);
			this.pbxHinhAnh.Name = "pbxHinhAnh";
			this.pbxHinhAnh.Size = new System.Drawing.Size(477, 249);
			this.pbxHinhAnh.TabIndex = 0;
			this.pbxHinhAnh.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.tbxChiSoDien);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.tbxMaKhachHang);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.btnLuuFile);
			this.panel2.Controls.Add(this.btnDung);
			this.panel2.Controls.Add(this.btnNhanDienTatCa);
			this.panel2.Controls.Add(this.btnNhanDien);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 258);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(477, 165);
			this.panel2.TabIndex = 1;
			// 
			// tbxChiSoDien
			// 
			this.tbxChiSoDien.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxChiSoDien.Location = new System.Drawing.Point(360, 72);
			this.tbxChiSoDien.Name = "tbxChiSoDien";
			this.tbxChiSoDien.Size = new System.Drawing.Size(112, 23);
			this.tbxChiSoDien.TabIndex = 9;
			this.tbxChiSoDien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxChiSoDien_KeyPress);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(281, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Chỉ số điện:";
			// 
			// tbxMaKhachHang
			// 
			this.tbxMaKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaKhachHang.Location = new System.Drawing.Point(120, 72);
			this.tbxMaKhachHang.Name = "tbxMaKhachHang";
			this.tbxMaKhachHang.Size = new System.Drawing.Size(154, 23);
			this.tbxMaKhachHang.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "Mã khách hàng:";
			// 
			// btnLuuFile
			// 
			this.btnLuuFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLuuFile.Image = global::QuanLyDienNang.Properties.Resources.Save;
			this.btnLuuFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuuFile.Location = new System.Drawing.Point(171, 100);
			this.btnLuuFile.Name = "btnLuuFile";
			this.btnLuuFile.Size = new System.Drawing.Size(146, 40);
			this.btnLuuFile.TabIndex = 10;
			this.btnLuuFile.Text = "Lưu vào tập tin";
			this.btnLuuFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLuuFile.UseVisualStyleBackColor = true;
			// 
			// btnDung
			// 
			this.btnDung.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnDung.Image = global::QuanLyDienNang.Properties.Resources.Stop;
			this.btnDung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDung.Location = new System.Drawing.Point(318, 5);
			this.btnDung.Name = "btnDung";
			this.btnDung.Size = new System.Drawing.Size(99, 40);
			this.btnDung.TabIndex = 7;
			this.btnDung.Text = "Dừng lại";
			this.btnDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDung.UseVisualStyleBackColor = true;
			this.btnDung.Click += new System.EventHandler(this.btnDung_Click);
			// 
			// btnNhanDienTatCa
			// 
			this.btnNhanDienTatCa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnNhanDienTatCa.Image = global::QuanLyDienNang.Properties.Resources.Preview;
			this.btnNhanDienTatCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhanDienTatCa.Location = new System.Drawing.Point(164, 5);
			this.btnNhanDienTatCa.Name = "btnNhanDienTatCa";
			this.btnNhanDienTatCa.Size = new System.Drawing.Size(148, 40);
			this.btnNhanDienTatCa.TabIndex = 6;
			this.btnNhanDienTatCa.Text = "Nhận diện tất cả";
			this.btnNhanDienTatCa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhanDienTatCa.UseVisualStyleBackColor = true;
			this.btnNhanDienTatCa.Click += new System.EventHandler(this.btnNhanDienTatCa_Click);
			// 
			// btnNhanDien
			// 
			this.btnNhanDien.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnNhanDien.Image = global::QuanLyDienNang.Properties.Resources.Preview;
			this.btnNhanDien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhanDien.Location = new System.Drawing.Point(41, 5);
			this.btnNhanDien.Name = "btnNhanDien";
			this.btnNhanDien.Size = new System.Drawing.Size(117, 40);
			this.btnNhanDien.TabIndex = 5;
			this.btnNhanDien.Text = "Nhận diện";
			this.btnNhanDien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhanDien.UseVisualStyleBackColor = true;
			this.btnNhanDien.Click += new System.EventHandler(this.btnNhanDien_Click);
			// 
			// folderDialog
			// 
			this.folderDialog.Description = "Chọn thư mục hình ảnh";
			this.folderDialog.ShowNewFolderButton = false;
			// 
			// btnDong
			// 
			this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnDong.Image = global::QuanLyDienNang.Properties.Resources.Exit;
			this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDong.Location = new System.Drawing.Point(605, 32);
			this.btnDong.Name = "btnDong";
			this.btnDong.Size = new System.Drawing.Size(86, 40);
			this.btnDong.TabIndex = 4;
			this.btnDong.Text = "Đóng";
			this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDong.UseVisualStyleBackColor = true;
			this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
			// 
			// FormKH_DocChiSoDien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormKH_DocChiSoDien";
			this.Text = "Đọc Chỉ Số Điện Năng Tiêu Thụ";
			this.tableParent.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableParentBottom.ResumeLayout(false);
			this.tableParentRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbxHinhAnh)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnMoThuMuc;
		private System.Windows.Forms.TextBox tbxDuongDan;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnChayServer;
		private System.Windows.Forms.TableLayoutPanel tableParentBottom;
		private System.Windows.Forms.ListBox lbxHinhAnh;
		private System.Windows.Forms.TableLayoutPanel tableParentRight;
		private System.Windows.Forms.PictureBox pbxHinhAnh;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnDung;
		private System.Windows.Forms.Button btnNhanDienTatCa;
		private System.Windows.Forms.Button btnNhanDien;
		private System.Windows.Forms.TextBox tbxChiSoDien;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxMaKhachHang;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLuuFile;
		private System.Windows.Forms.FolderBrowserDialog folderDialog;
		private System.Windows.Forms.Button btnDong;
	}
}