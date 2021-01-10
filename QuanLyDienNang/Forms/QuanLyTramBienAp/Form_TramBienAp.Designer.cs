
namespace QuanLyDienNang.Forms
{
	partial class Form_TramBienAp
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TramBienAp));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvTramBienAp = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxMaTram = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxTenTram = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbDiaChi = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbxNguoiPhuTrach = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxMaSoCongTo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbxHeSoNhan = new System.Windows.Forms.TextBox();
			this.chkKichHoat = new System.Windows.Forms.CheckBox();
			this.btnThem = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTramBienAp)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvTramBienAp, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 561);
			this.tableLayoutPanel1.TabIndex = 0;
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
			this.label1.Text = "QUẢN LÝ TRẠM BIẾN ÁP";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvTramBienAp
			// 
			this.dgvTramBienAp.AllowUserToAddRows = false;
			this.dgvTramBienAp.AllowUserToDeleteRows = false;
			this.dgvTramBienAp.AllowUserToResizeRows = false;
			this.dgvTramBienAp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvTramBienAp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTramBienAp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTramBienAp.Location = new System.Drawing.Point(3, 183);
			this.dgvTramBienAp.MultiSelect = false;
			this.dgvTramBienAp.Name = "dgvTramBienAp";
			this.dgvTramBienAp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTramBienAp.Size = new System.Drawing.Size(978, 375);
			this.dgvTramBienAp.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.chkKichHoat);
			this.panel1.Controls.Add(this.tbDiaChi);
			this.panel1.Controls.Add(this.tbxTenTram);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbxHeSoNhan);
			this.panel1.Controls.Add(this.tbxMaSoCongTo);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.tbxNguoiPhuTrach);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.tbxMaTram);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 144);
			this.panel1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã trạm:";
			// 
			// tbxMaTram
			// 
			this.tbxMaTram.Location = new System.Drawing.Point(99, 13);
			this.tbxMaTram.MaxLength = 10;
			this.tbxMaTram.Name = "tbxMaTram";
			this.tbxMaTram.Size = new System.Drawing.Size(169, 25);
			this.tbxMaTram.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên trạm:";
			// 
			// tbxTenTram
			// 
			this.tbxTenTram.Location = new System.Drawing.Point(99, 44);
			this.tbxTenTram.MaxLength = 100;
			this.tbxTenTram.Name = "tbxTenTram";
			this.tbxTenTram.Size = new System.Drawing.Size(268, 25);
			this.tbxTenTram.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(40, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "Địa chỉ:";
			// 
			// tbDiaChi
			// 
			this.tbDiaChi.Location = new System.Drawing.Point(99, 76);
			this.tbDiaChi.MaxLength = 200;
			this.tbDiaChi.Multiline = true;
			this.tbDiaChi.Name = "tbDiaChi";
			this.tbDiaChi.Size = new System.Drawing.Size(268, 50);
			this.tbDiaChi.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(398, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "Người phụ trách:";
			// 
			// tbxNguoiPhuTrach
			// 
			this.tbxNguoiPhuTrach.Location = new System.Drawing.Point(516, 13);
			this.tbxNguoiPhuTrach.MaxLength = 100;
			this.tbxNguoiPhuTrach.Name = "tbxNguoiPhuTrach";
			this.tbxNguoiPhuTrach.Size = new System.Drawing.Size(169, 25);
			this.tbxNguoiPhuTrach.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(409, 47);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(101, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "Mã số công tơ:";
			// 
			// tbxMaSoCongTo
			// 
			this.tbxMaSoCongTo.Location = new System.Drawing.Point(516, 44);
			this.tbxMaSoCongTo.MaxLength = 20;
			this.tbxMaSoCongTo.Name = "tbxMaSoCongTo";
			this.tbxMaSoCongTo.Size = new System.Drawing.Size(169, 25);
			this.tbxMaSoCongTo.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(428, 79);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(82, 19);
			this.label7.TabIndex = 0;
			this.label7.Text = "Hệ số nhân:";
			// 
			// tbxHeSoNhan
			// 
			this.tbxHeSoNhan.Location = new System.Drawing.Point(516, 73);
			this.tbxHeSoNhan.MaxLength = 10;
			this.tbxHeSoNhan.Name = "tbxHeSoNhan";
			this.tbxHeSoNhan.Size = new System.Drawing.Size(169, 25);
			this.tbxHeSoNhan.TabIndex = 1;
			// 
			// chkKichHoat
			// 
			this.chkKichHoat.AutoSize = true;
			this.chkKichHoat.Location = new System.Drawing.Point(516, 104);
			this.chkKichHoat.Name = "chkKichHoat";
			this.chkKichHoat.Size = new System.Drawing.Size(85, 23);
			this.chkKichHoat.TabIndex = 2;
			this.chkKichHoat.Text = "Kích hoạt";
			this.chkKichHoat.UseVisualStyleBackColor = true;
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(824, 35);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 40);
			this.btnThem.TabIndex = 6;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// Form_TramBienAp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_TramBienAp";
			this.Text = "Quản Lý Trạm Biến Áp";
			this.Shown += new System.EventHandler(this.Form_TramBienAp_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTramBienAp)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvTramBienAp;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbDiaChi;
		private System.Windows.Forms.TextBox tbxTenTram;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxMaTram;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkKichHoat;
		private System.Windows.Forms.TextBox tbxHeSoNhan;
		private System.Windows.Forms.TextBox tbxMaSoCongTo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbxNguoiPhuTrach;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnThem;
	}
}