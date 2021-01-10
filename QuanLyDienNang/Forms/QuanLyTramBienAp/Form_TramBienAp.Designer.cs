
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
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvTramBienAp = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.nudHeSoNhan = new System.Windows.Forms.NumericUpDown();
			this.btnThem = new System.Windows.Forms.Button();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.tbxTenTram = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxMaSoCongTo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbxNguoiPhuTrach = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxMaTram = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTramBienAp)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHeSoNhan)).BeginInit();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.dgvTramBienAp, 0, 2);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 3;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
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
			this.dgvTramBienAp.Location = new System.Drawing.Point(3, 173);
			this.dgvTramBienAp.MultiSelect = false;
			this.dgvTramBienAp.Name = "dgvTramBienAp";
			this.dgvTramBienAp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTramBienAp.Size = new System.Drawing.Size(978, 385);
			this.dgvTramBienAp.TabIndex = 1;
			this.dgvTramBienAp.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTramBienAp_CellValueChanged);
			this.dgvTramBienAp.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTramBienAp_DataError);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.nudHeSoNhan);
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.tbxDiaChi);
			this.panel1.Controls.Add(this.tbxTenTram);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
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
			this.panel1.Size = new System.Drawing.Size(978, 134);
			this.panel1.TabIndex = 2;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label10.ForeColor = System.Drawing.Color.Red;
			this.label10.Location = new System.Drawing.Point(717, 77);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(23, 19);
			this.label10.TabIndex = 11;
			this.label10.Text = "(*)";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(464, 42);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(23, 19);
			this.label9.TabIndex = 10;
			this.label9.Text = "(*)";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(274, 11);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(23, 19);
			this.label8.TabIndex = 9;
			this.label8.Text = "(*)";
			// 
			// nudHeSoNhan
			// 
			this.nudHeSoNhan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.nudHeSoNhan.Location = new System.Drawing.Point(626, 72);
			this.nudHeSoNhan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudHeSoNhan.Name = "nudHeSoNhan";
			this.nudHeSoNhan.Size = new System.Drawing.Size(85, 25);
			this.nudHeSoNhan.TabIndex = 6;
			this.nudHeSoNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudHeSoNhan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(842, 50);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 40);
			this.btnThem.TabIndex = 8;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDiaChi.Location = new System.Drawing.Point(99, 71);
			this.tbxDiaChi.MaxLength = 200;
			this.tbxDiaChi.Multiline = true;
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(359, 50);
			this.tbxDiaChi.TabIndex = 3;
			// 
			// tbxTenTram
			// 
			this.tbxTenTram.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxTenTram.Location = new System.Drawing.Point(99, 39);
			this.tbxTenTram.MaxLength = 100;
			this.tbxTenTram.Name = "tbxTenTram";
			this.tbxTenTram.Size = new System.Drawing.Size(359, 25);
			this.tbxTenTram.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(40, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "Địa chỉ:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên trạm:";
			// 
			// tbxMaSoCongTo
			// 
			this.tbxMaSoCongTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaSoCongTo.Location = new System.Drawing.Point(626, 42);
			this.tbxMaSoCongTo.MaxLength = 20;
			this.tbxMaSoCongTo.Name = "tbxMaSoCongTo";
			this.tbxMaSoCongTo.Size = new System.Drawing.Size(169, 25);
			this.tbxMaSoCongTo.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(538, 77);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(82, 19);
			this.label7.TabIndex = 0;
			this.label7.Text = "Hệ số nhân:";
			// 
			// tbxNguoiPhuTrach
			// 
			this.tbxNguoiPhuTrach.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxNguoiPhuTrach.Location = new System.Drawing.Point(626, 11);
			this.tbxNguoiPhuTrach.MaxLength = 100;
			this.tbxNguoiPhuTrach.Name = "tbxNguoiPhuTrach";
			this.tbxNguoiPhuTrach.Size = new System.Drawing.Size(314, 25);
			this.tbxNguoiPhuTrach.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(519, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(101, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "Mã số công tơ:";
			// 
			// tbxMaTram
			// 
			this.tbxMaTram.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaTram.Location = new System.Drawing.Point(99, 8);
			this.tbxMaTram.MaxLength = 10;
			this.tbxMaTram.Name = "tbxMaTram";
			this.tbxMaTram.Size = new System.Drawing.Size(169, 25);
			this.tbxMaTram.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(508, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "Người phụ trách:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã trạm:";
			// 
			// Form_TramBienAp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_TramBienAp";
			this.Text = "Quản Lý Trạm Biến Áp";
			this.Shown += new System.EventHandler(this.Form_TramBienAp_Shown);
			this.tableParent.ResumeLayout(false);
			this.tableParent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTramBienAp)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHeSoNhan)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvTramBienAp;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbxDiaChi;
		private System.Windows.Forms.TextBox tbxTenTram;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxMaTram;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxMaSoCongTo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbxNguoiPhuTrach;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.NumericUpDown nudHeSoNhan;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
	}
}