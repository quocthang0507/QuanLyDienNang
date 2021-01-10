
namespace QuanLyDienNang.Forms
{
	partial class Form_ChiTietBangGia
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ChiTietBangGia));
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.dgvChiTietGia = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnThem = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbxKetThuc = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxBatDau = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbxDonGia = new System.Windows.Forms.TextBox();
			this.tbxMaBangGia = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxMoTa = new System.Windows.Forms.TextBox();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvChiTietGia)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.lblTitle, 0, 0);
			this.tableParent.Controls.Add(this.dgvChiTietGia, 0, 2);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 3;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(3, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(978, 30);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "CHI TIẾT BẢNG GIÁ ĐIỆN";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvChiTietGia
			// 
			this.dgvChiTietGia.AllowUserToAddRows = false;
			this.dgvChiTietGia.AllowUserToDeleteRows = false;
			this.dgvChiTietGia.AllowUserToResizeRows = false;
			this.dgvChiTietGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvChiTietGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvChiTietGia.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvChiTietGia.Location = new System.Drawing.Point(3, 183);
			this.dgvChiTietGia.MultiSelect = false;
			this.dgvChiTietGia.Name = "dgvChiTietGia";
			this.dgvChiTietGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvChiTietGia.Size = new System.Drawing.Size(978, 375);
			this.dgvChiTietGia.TabIndex = 1;
			this.dgvChiTietGia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietGia_CellValueChanged);
			this.dgvChiTietGia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvChiTietGia_DataError);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.tbxDonGia);
			this.panel1.Controls.Add(this.tbxMaBangGia);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbxMoTa);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 144);
			this.panel1.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(622, 12);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(23, 19);
			this.label9.TabIndex = 10;
			this.label9.Text = "(*)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(266, 12);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(23, 19);
			this.label7.TabIndex = 10;
			this.label7.Text = "(*)";
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(460, 100);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 40);
			this.btnThem.TabIndex = 6;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbxKetThuc);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tbxBatDau);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(9, 34);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(636, 64);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Phạm vi:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label6.ForeColor = System.Drawing.Color.Red;
			this.label6.Location = new System.Drawing.Point(539, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(23, 19);
			this.label6.TabIndex = 8;
			this.label6.Text = "(*)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(275, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 19);
			this.label1.TabIndex = 7;
			this.label1.Text = "(*)";
			// 
			// tbxKetThuc
			// 
			this.tbxKetThuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxKetThuc.Location = new System.Drawing.Point(413, 22);
			this.tbxKetThuc.MaxLength = 10;
			this.tbxKetThuc.Name = "tbxKetThuc";
			this.tbxKetThuc.Size = new System.Drawing.Size(120, 25);
			this.tbxKetThuc.TabIndex = 4;
			this.tbxKetThuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxKetThuc_KeyPress);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(43, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "Giá trị bắt đầu:";
			// 
			// tbxBatDau
			// 
			this.tbxBatDau.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxBatDau.Location = new System.Drawing.Point(149, 22);
			this.tbxBatDau.MaxLength = 10;
			this.tbxBatDau.Name = "tbxBatDau";
			this.tbxBatDau.Size = new System.Drawing.Size(120, 25);
			this.tbxBatDau.TabIndex = 3;
			this.tbxBatDau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBatDau_KeyPress);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(304, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 19);
			this.label5.TabIndex = 4;
			this.label5.Text = "Giá trị kết thúc:";
			// 
			// tbxDonGia
			// 
			this.tbxDonGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDonGia.Location = new System.Drawing.Point(496, 9);
			this.tbxDonGia.MaxLength = 10;
			this.tbxDonGia.Name = "tbxDonGia";
			this.tbxDonGia.Size = new System.Drawing.Size(120, 25);
			this.tbxDonGia.TabIndex = 2;
			this.tbxDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDonGia_KeyPress);
			// 
			// tbxMaBangGia
			// 
			this.tbxMaBangGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaBangGia.Location = new System.Drawing.Point(140, 9);
			this.tbxMaBangGia.MaxLength = 10;
			this.tbxMaBangGia.Name = "tbxMaBangGia";
			this.tbxMaBangGia.Size = new System.Drawing.Size(120, 25);
			this.tbxMaBangGia.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(430, 12);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 19);
			this.label8.TabIndex = 4;
			this.label8.Text = "Đơn giá:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Mã bảng giá:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(647, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "Mô tả:";
			// 
			// tbxMoTa
			// 
			this.tbxMoTa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMoTa.Location = new System.Drawing.Point(651, 34);
			this.tbxMoTa.MaxLength = 200;
			this.tbxMoTa.Multiline = true;
			this.tbxMoTa.Name = "tbxMoTa";
			this.tbxMoTa.Size = new System.Drawing.Size(318, 67);
			this.tbxMoTa.TabIndex = 5;
			// 
			// Form_ChiTietBangGia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_ChiTietBangGia";
			this.Text = "Chi Tiết Bảng Giá";
			this.Shown += new System.EventHandler(this.Form_ChiTietBangGia_Shown);
			this.tableParent.ResumeLayout(false);
			this.tableParent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvChiTietGia)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.DataGridView dgvChiTietGia;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbxMaBangGia;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxMoTa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbxKetThuc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxBatDau;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbxDonGia;
		private System.Windows.Forms.Label label8;
	}
}