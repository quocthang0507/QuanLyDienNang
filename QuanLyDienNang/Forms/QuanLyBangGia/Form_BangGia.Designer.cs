
namespace QuanLyDienNang.Forms
{
	partial class Form_BangGia
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BangGia));
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvBangGia = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkApGia = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxThue = new System.Windows.Forms.TextBox();
			this.tbxMaBangGia = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnThem = new System.Windows.Forms.Button();
			this.tbxTenBangGia = new System.Windows.Forms.TextBox();
			this.btnXemApGia = new System.Windows.Forms.Button();
			this.btnXemChiTiet = new System.Windows.Forms.Button();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBangGia)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.dgvBangGia, 0, 2);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 3;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(978, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "BẢNG GIÁ ĐIỆN";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvBangGia
			// 
			this.dgvBangGia.AllowUserToAddRows = false;
			this.dgvBangGia.AllowUserToDeleteRows = false;
			this.dgvBangGia.AllowUserToResizeRows = false;
			this.dgvBangGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvBangGia.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.dgvBangGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBangGia.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBangGia.Location = new System.Drawing.Point(3, 153);
			this.dgvBangGia.MultiSelect = false;
			this.dgvBangGia.Name = "dgvBangGia";
			this.dgvBangGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvBangGia.Size = new System.Drawing.Size(978, 405);
			this.dgvBangGia.TabIndex = 1;
			this.dgvBangGia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangGia_CellValueChanged);
			this.dgvBangGia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBangGia_DataError);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.btnXemApGia);
			this.panel1.Controls.Add(this.btnXemChiTiet);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 114);
			this.panel1.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.chkApGia);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbxThue);
			this.groupBox1.Controls.Add(this.tbxMaBangGia);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnThem);
			this.groupBox1.Controls.Add(this.tbxTenBangGia);
			this.groupBox1.Location = new System.Drawing.Point(9, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(679, 108);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thêm bảng giá";
			// 
			// chkApGia
			// 
			this.chkApGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkApGia.AutoSize = true;
			this.chkApGia.Location = new System.Drawing.Point(424, 23);
			this.chkApGia.Name = "chkApGia";
			this.chkApGia.Size = new System.Drawing.Size(82, 23);
			this.chkApGia.TabIndex = 3;
			this.chkApGia.Text = "Áp giá %";
			this.chkApGia.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(383, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(23, 19);
			this.label8.TabIndex = 6;
			this.label8.Text = "(*)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(224, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(23, 19);
			this.label7.TabIndex = 6;
			this.label7.Text = "(*)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label6.ForeColor = System.Drawing.Color.Red;
			this.label6.Location = new System.Drawing.Point(521, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(23, 19);
			this.label6.TabIndex = 6;
			this.label6.Text = "(*)";
			// 
			// tbxThue
			// 
			this.tbxThue.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxThue.Location = new System.Drawing.Point(301, 21);
			this.tbxThue.MaxLength = 10;
			this.tbxThue.Name = "tbxThue";
			this.tbxThue.Size = new System.Drawing.Size(76, 25);
			this.tbxThue.TabIndex = 2;
			this.tbxThue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxThue_KeyPress);
			// 
			// tbxMaBangGia
			// 
			this.tbxMaBangGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaBangGia.Location = new System.Drawing.Point(101, 21);
			this.tbxMaBangGia.MaxLength = 30;
			this.tbxMaBangGia.Name = "tbxMaBangGia";
			this.tbxMaBangGia.Size = new System.Drawing.Size(122, 25);
			this.tbxMaBangGia.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(253, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "Thuế:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã bảng giá:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên bảng giá:";
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(559, 42);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 40);
			this.btnThem.TabIndex = 5;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// tbxTenBangGia
			// 
			this.tbxTenBangGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxTenBangGia.Location = new System.Drawing.Point(101, 51);
			this.tbxTenBangGia.MaxLength = 150;
			this.tbxTenBangGia.Multiline = true;
			this.tbxTenBangGia.Name = "tbxTenBangGia";
			this.tbxTenBangGia.Size = new System.Drawing.Size(414, 50);
			this.tbxTenBangGia.TabIndex = 4;
			// 
			// btnXemApGia
			// 
			this.btnXemApGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXemApGia.Image = global::QuanLyDienNang.Properties.Resources.percent;
			this.btnXemApGia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXemApGia.Location = new System.Drawing.Point(838, 45);
			this.btnXemApGia.Name = "btnXemApGia";
			this.btnXemApGia.Size = new System.Drawing.Size(131, 40);
			this.btnXemApGia.TabIndex = 7;
			this.btnXemApGia.Text = "Xem % áp giá";
			this.btnXemApGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXemApGia.UseVisualStyleBackColor = true;
			this.btnXemApGia.Click += new System.EventHandler(this.btnXemApGia_Click);
			// 
			// btnXemChiTiet
			// 
			this.btnXemChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXemChiTiet.Image = global::QuanLyDienNang.Properties.Resources.Preview;
			this.btnXemChiTiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXemChiTiet.Location = new System.Drawing.Point(707, 45);
			this.btnXemChiTiet.Name = "btnXemChiTiet";
			this.btnXemChiTiet.Size = new System.Drawing.Size(125, 40);
			this.btnXemChiTiet.TabIndex = 6;
			this.btnXemChiTiet.Text = "Xem chi tiết";
			this.btnXemChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXemChiTiet.UseVisualStyleBackColor = true;
			this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "xlsx";
			this.saveDialog.FileName = "Danh sách Bảng giá";
			this.saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
			this.saveDialog.RestoreDirectory = true;
			this.saveDialog.Title = "Lưu danh sách bảng giá điện";
			// 
			// Form_BangGia
			// 
			this.AcceptButton = this.btnXemChiTiet;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_BangGia";
			this.Text = "Quản Lý Bảng Giá";
			this.Shown += new System.EventHandler(this.Form_BangGia_Shown);
			this.tableParent.ResumeLayout(false);
			this.tableParent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBangGia)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvBangGia;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbxMaBangGia;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.TextBox tbxTenBangGia;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnXemChiTiet;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbxThue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.SaveFileDialog saveDialog;
		private System.Windows.Forms.Button btnXemApGia;
		private System.Windows.Forms.CheckBox chkApGia;
	}
}