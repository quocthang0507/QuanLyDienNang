namespace QuanLyDienNang
{
    partial class FormKH_XuatKhachHang
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKH_XuatKhachHang));
			this.label1 = new System.Windows.Forms.Label();
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.dgvKhachHang = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelXuatDieuKien = new System.Windows.Forms.Panel();
			this.cbxTenTram = new System.Windows.Forms.ComboBox();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxBangGia = new System.Windows.Forms.ComboBox();
			this.cbxNganHang = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rbtnXuatHet = new System.Windows.Forms.RadioButton();
			this.rbtnXuatDieuKien = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnXuat = new System.Windows.Forms.Button();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panelXuatDieuKien.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(978, 26);
			this.label1.TabIndex = 2;
			this.label1.Text = "XUẤT THÔNG TIN KHÁCH HÀNG";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.dgvKhachHang, 0, 3);
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Controls.Add(this.panel2, 0, 2);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 4;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 8;
			// 
			// dgvKhachHang
			// 
			this.dgvKhachHang.AllowUserToAddRows = false;
			this.dgvKhachHang.AllowUserToDeleteRows = false;
			this.dgvKhachHang.AllowUserToOrderColumns = true;
			this.dgvKhachHang.AllowUserToResizeRows = false;
			this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKhachHang.Location = new System.Drawing.Point(3, 213);
			this.dgvKhachHang.MultiSelect = false;
			this.dgvKhachHang.Name = "dgvKhachHang";
			this.dgvKhachHang.ReadOnly = true;
			this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvKhachHang.Size = new System.Drawing.Size(978, 452);
			this.dgvKhachHang.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 124);
			this.panel1.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panelXuatDieuKien);
			this.groupBox1.Controls.Add(this.rbtnXuatHet);
			this.groupBox1.Controls.Add(this.rbtnXuatDieuKien);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(978, 124);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Điều kiện xuất";
			// 
			// panelXuatDieuKien
			// 
			this.panelXuatDieuKien.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panelXuatDieuKien.Controls.Add(this.cbxTenTram);
			this.panelXuatDieuKien.Controls.Add(this.tbxDiaChi);
			this.panelXuatDieuKien.Controls.Add(this.label4);
			this.panelXuatDieuKien.Controls.Add(this.label14);
			this.panelXuatDieuKien.Controls.Add(this.label3);
			this.panelXuatDieuKien.Controls.Add(this.cbxBangGia);
			this.panelXuatDieuKien.Controls.Add(this.cbxNganHang);
			this.panelXuatDieuKien.Controls.Add(this.label2);
			this.panelXuatDieuKien.Enabled = false;
			this.panelXuatDieuKien.Location = new System.Drawing.Point(9, 24);
			this.panelXuatDieuKien.Name = "panelXuatDieuKien";
			this.panelXuatDieuKien.Size = new System.Drawing.Size(960, 65);
			this.panelXuatDieuKien.TabIndex = 12;
			// 
			// cbxTenTram
			// 
			this.cbxTenTram.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxTenTram.DisplayMember = "TenTram";
			this.cbxTenTram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxTenTram.FormattingEnabled = true;
			this.cbxTenTram.Location = new System.Drawing.Point(584, 3);
			this.cbxTenTram.Name = "cbxTenTram";
			this.cbxTenTram.Size = new System.Drawing.Size(359, 25);
			this.cbxTenTram.TabIndex = 2;
			this.cbxTenTram.ValueMember = "TenTram";
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDiaChi.Location = new System.Drawing.Point(74, 3);
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(384, 25);
			this.tbxDiaChi.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(516, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Tên trạm:";
			// 
			// label14
			// 
			this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 4);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(53, 19);
			this.label14.TabIndex = 11;
			this.label14.Text = "Địa chỉ:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(481, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 19);
			this.label3.TabIndex = 8;
			this.label3.Text = "Tên ngân hàng:";
			// 
			// cbxBangGia
			// 
			this.cbxBangGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxBangGia.DisplayMember = "TenBangGia";
			this.cbxBangGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxBangGia.FormattingEnabled = true;
			this.cbxBangGia.Location = new System.Drawing.Point(74, 34);
			this.cbxBangGia.Name = "cbxBangGia";
			this.cbxBangGia.Size = new System.Drawing.Size(384, 25);
			this.cbxBangGia.TabIndex = 3;
			this.cbxBangGia.ValueMember = "TenBangGia";
			// 
			// cbxNganHang
			// 
			this.cbxNganHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxNganHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxNganHang.FormattingEnabled = true;
			this.cbxNganHang.Location = new System.Drawing.Point(584, 34);
			this.cbxNganHang.Name = "cbxNganHang";
			this.cbxNganHang.Size = new System.Drawing.Size(359, 25);
			this.cbxNganHang.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 19);
			this.label2.TabIndex = 8;
			this.label2.Text = "Bảng giá:";
			// 
			// rbtnXuatHet
			// 
			this.rbtnXuatHet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.rbtnXuatHet.AutoSize = true;
			this.rbtnXuatHet.Checked = true;
			this.rbtnXuatHet.Location = new System.Drawing.Point(529, 95);
			this.rbtnXuatHet.Name = "rbtnXuatHet";
			this.rbtnXuatHet.Size = new System.Drawing.Size(79, 23);
			this.rbtnXuatHet.TabIndex = 6;
			this.rbtnXuatHet.TabStop = true;
			this.rbtnXuatHet.Text = "Xuất hết";
			this.rbtnXuatHet.UseVisualStyleBackColor = true;
			this.rbtnXuatHet.CheckedChanged += new System.EventHandler(this.rbtnXuatHet_CheckedChanged);
			// 
			// rbtnXuatDieuKien
			// 
			this.rbtnXuatDieuKien.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.rbtnXuatDieuKien.AutoSize = true;
			this.rbtnXuatDieuKien.Location = new System.Drawing.Point(359, 95);
			this.rbtnXuatDieuKien.Name = "rbtnXuatDieuKien";
			this.rbtnXuatDieuKien.Size = new System.Drawing.Size(146, 23);
			this.rbtnXuatDieuKien.TabIndex = 5;
			this.rbtnXuatDieuKien.Text = "Xuất theo điều kiện";
			this.rbtnXuatDieuKien.UseVisualStyleBackColor = true;
			this.rbtnXuatDieuKien.CheckedChanged += new System.EventHandler(this.rbtnXuatDieuKien_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnXuat);
			this.panel2.Controls.Add(this.btnTimKiem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 163);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 44);
			this.panel2.TabIndex = 4;
			// 
			// btnXuat
			// 
			this.btnXuat.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXuat.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuat.Location = new System.Drawing.Point(491, 1);
			this.btnXuat.Name = "btnXuat";
			this.btnXuat.Size = new System.Drawing.Size(117, 42);
			this.btnXuat.TabIndex = 8;
			this.btnXuat.Text = "Xuất Excel";
			this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuat.UseVisualStyleBackColor = true;
			this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnTimKiem.Image = global::QuanLyDienNang.Properties.Resources.Search;
			this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTimKiem.Location = new System.Drawing.Point(387, 1);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(100, 42);
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimKiem.UseVisualStyleBackColor = true;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "xlsx";
			this.saveDialog.FileName = "Danh sách khách hàng.xlsx";
			this.saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
			this.saveDialog.RestoreDirectory = true;
			this.saveDialog.Title = "Lưu danh sách khách hàng";
			// 
			// FormKH_XuatKhachHang
			// 
			this.AcceptButton = this.btnTimKiem;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormKH_XuatKhachHang";
			this.Text = "Xuất Thông Tin Khách Hàng Ra Excel";
			this.Shown += new System.EventHandler(this.FormKH_XuatKhachHang_Shown);
			this.tableParent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panelXuatDieuKien.ResumeLayout(false);
			this.panelXuatDieuKien.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnXuat;
		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.DataGridView dgvKhachHang;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cbxTenTram;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxDiaChi;
		private System.Windows.Forms.ComboBox cbxBangGia;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbtnXuatHet;
		private System.Windows.Forms.RadioButton rbtnXuatDieuKien;
		private System.Windows.Forms.ComboBox cbxNganHang;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panelXuatDieuKien;
		private System.Windows.Forms.SaveFileDialog saveDialog;
	}
}