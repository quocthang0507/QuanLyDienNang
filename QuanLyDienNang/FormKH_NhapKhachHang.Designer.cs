﻿namespace QuanLyDienNang
{
    partial class FormKH_NhapKhachHang
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
			this.tbxDuongDan = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxSheet = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxNguoiNhap = new System.Windows.Forms.ComboBox();
			this.dgvDienNangTieuThu = new System.Windows.Forms.DataGridView();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnXemMau = new System.Windows.Forms.Button();
			this.btnLoadExcel = new System.Windows.Forms.Button();
			this.btnChonTapTin = new System.Windows.Forms.Button();
			this.fileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.tableParent.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).BeginInit();
			this.SuspendLayout();
			// 
			// tbxDuongDan
			// 
			this.tbxDuongDan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxDuongDan.Location = new System.Drawing.Point(104, 14);
			this.tbxDuongDan.Margin = new System.Windows.Forms.Padding(4);
			this.tbxDuongDan.Name = "tbxDuongDan";
			this.tbxDuongDan.Size = new System.Drawing.Size(544, 23);
			this.tbxDuongDan.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "Đường dẫn:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 19);
			this.label2.TabIndex = 8;
			this.label2.Text = "Chọn sheet:";
			// 
			// cbxSheet
			// 
			this.cbxSheet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSheet.FormattingEnabled = true;
			this.cbxSheet.Location = new System.Drawing.Point(105, 48);
			this.cbxSheet.Name = "cbxSheet";
			this.cbxSheet.Size = new System.Drawing.Size(284, 25);
			this.cbxSheet.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnChonTapTin);
			this.panel1.Controls.Add(this.cbxNguoiNhap);
			this.panel1.Controls.Add(this.cbxSheet);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tbxDuongDan);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(855, 84);
			this.panel1.TabIndex = 10;
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.panel2, 0, 2);
			this.tableParent.Controls.Add(this.label3, 0, 0);
			this.tableParent.Controls.Add(this.dgvDienNangTieuThu, 0, 3);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 4;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(861, 596);
			this.tableParent.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnLuu);
			this.panel2.Controls.Add(this.btnXemMau);
			this.panel2.Controls.Add(this.btnLoadExcel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 123);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(855, 44);
			this.panel2.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(855, 30);
			this.label3.TabIndex = 12;
			this.label3.Text = "NHẬP THÔNG TIN KHÁCH HÀNG SỬ DỤNG ĐIỆN";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(423, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Người nhập:";
			// 
			// cbxNguoiNhap
			// 
			this.cbxNguoiNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxNguoiNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxNguoiNhap.FormattingEnabled = true;
			this.cbxNguoiNhap.Location = new System.Drawing.Point(513, 49);
			this.cbxNguoiNhap.Name = "cbxNguoiNhap";
			this.cbxNguoiNhap.Size = new System.Drawing.Size(284, 25);
			this.cbxNguoiNhap.TabIndex = 4;
			// 
			// dgvDienNangTieuThu
			// 
			this.dgvDienNangTieuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDienNangTieuThu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDienNangTieuThu.Location = new System.Drawing.Point(3, 173);
			this.dgvDienNangTieuThu.Name = "dgvDienNangTieuThu";
			this.dgvDienNangTieuThu.Size = new System.Drawing.Size(855, 420);
			this.dgvDienNangTieuThu.TabIndex = 13;
			// 
			// btnLuu
			// 
			this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLuu.Image = global::QuanLyDienNang.Properties.Resources.Save;
			this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuu.Location = new System.Drawing.Point(501, 3);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(88, 42);
			this.btnLuu.TabIndex = 7;
			this.btnLuu.Text = "Lưu lại";
			this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLuu.UseVisualStyleBackColor = true;
			// 
			// btnXemMau
			// 
			this.btnXemMau.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXemMau.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnXemMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXemMau.Location = new System.Drawing.Point(251, 3);
			this.btnXemMau.Name = "btnXemMau";
			this.btnXemMau.Size = new System.Drawing.Size(119, 42);
			this.btnXemMau.TabIndex = 5;
			this.btnXemMau.Text = "Xem mẫu";
			this.btnXemMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXemMau.UseVisualStyleBackColor = true;
			// 
			// btnLoadExcel
			// 
			this.btnLoadExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLoadExcel.Image = global::QuanLyDienNang.Properties.Resources.Loading;
			this.btnLoadExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLoadExcel.Location = new System.Drawing.Point(376, 3);
			this.btnLoadExcel.Name = "btnLoadExcel";
			this.btnLoadExcel.Size = new System.Drawing.Size(119, 42);
			this.btnLoadExcel.TabIndex = 6;
			this.btnLoadExcel.Text = "Load Excel";
			this.btnLoadExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLoadExcel.UseVisualStyleBackColor = true;
			// 
			// btnChonTapTin
			// 
			this.btnChonTapTin.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnChonTapTin.Image = global::QuanLyDienNang.Properties.Resources.Xlsx;
			this.btnChonTapTin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnChonTapTin.Location = new System.Drawing.Point(655, 4);
			this.btnChonTapTin.Name = "btnChonTapTin";
			this.btnChonTapTin.Size = new System.Drawing.Size(143, 40);
			this.btnChonTapTin.TabIndex = 2;
			this.btnChonTapTin.Text = "Chọn tập tin";
			this.btnChonTapTin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChonTapTin.UseVisualStyleBackColor = true;
			this.btnChonTapTin.Click += new System.EventHandler(this.btnChonTapTin_Click);
			// 
			// fileDialog
			// 
			this.fileDialog.Filter = "Tập tin Excel 2007 (.xlsx)|*.xlsx|Tập tin Excel 2003 (.xls)|*.xls";
			// 
			// FormKH_NhapKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 596);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormKH_NhapKhachHang";
			this.Text = "Nhập Thông Tin Khách Hàng Từ Excel";
			this.Load += new System.EventHandler(this.FormKH_NhapKhachHang_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableParent.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbxDuongDan;
		private System.Windows.Forms.Button btnLoadExcel;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxSheet;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxNguoiNhap;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dgvDienNangTieuThu;
		private System.Windows.Forms.Button btnXemMau;
		private System.Windows.Forms.Button btnChonTapTin;
		private System.Windows.Forms.OpenFileDialog fileDialog;
	}
}