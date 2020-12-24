
namespace QuanLyDienNang
{
	partial class Form_NguoiQuanLy
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NguoiQuanLy));
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvNguoiQuanLy = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxMaNQL = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxTenNQL = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxSoDT = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxEmail = new System.Windows.Forms.TextBox();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnCapNhat = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvNguoiQuanLy)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.dgvNguoiQuanLy, 0, 2);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 3;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(978, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "THÔNG TIN NGƯỜI QUẢN LÝ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvNguoiQuanLy
			// 
			this.dgvNguoiQuanLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNguoiQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvNguoiQuanLy.Location = new System.Drawing.Point(3, 233);
			this.dgvNguoiQuanLy.Name = "dgvNguoiQuanLy";
			this.dgvNguoiQuanLy.Size = new System.Drawing.Size(978, 325);
			this.dgvNguoiQuanLy.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnXoa);
			this.panel1.Controls.Add(this.btnCapNhat);
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.tbxEmail);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.tbxTenNQL);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbxSoDT);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tbxMaNQL);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 194);
			this.panel1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(346, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã người quản lý:";
			// 
			// tbxMaNQL
			// 
			this.tbxMaNQL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaNQL.Location = new System.Drawing.Point(485, 25);
			this.tbxMaNQL.MaxLength = 20;
			this.tbxMaNQL.Name = "tbxMaNQL";
			this.tbxMaNQL.ReadOnly = true;
			this.tbxMaNQL.Size = new System.Drawing.Size(159, 25);
			this.tbxMaNQL.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(49, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên người quản lý:";
			// 
			// tbxTenNQL
			// 
			this.tbxTenNQL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxTenNQL.Location = new System.Drawing.Point(178, 59);
			this.tbxTenNQL.MaxLength = 200;
			this.tbxTenNQL.Name = "tbxTenNQL";
			this.tbxTenNQL.Size = new System.Drawing.Size(290, 25);
			this.tbxTenNQL.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(78, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "Số điện thoại:";
			// 
			// tbxSoDT
			// 
			this.tbxSoDT.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxSoDT.Location = new System.Drawing.Point(178, 90);
			this.tbxSoDT.MaxLength = 20;
			this.tbxSoDT.Name = "tbxSoDT";
			this.tbxSoDT.Size = new System.Drawing.Size(153, 25);
			this.tbxSoDT.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(493, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "Địa chỉ:";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox2.Location = new System.Drawing.Point(552, 59);
			this.textBox2.MaxLength = 2000;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(373, 25);
			this.textBox2.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(502, 90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "Email:";
			// 
			// tbxEmail
			// 
			this.tbxEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxEmail.Location = new System.Drawing.Point(552, 87);
			this.tbxEmail.MaxLength = 100;
			this.tbxEmail.Name = "tbxEmail";
			this.tbxEmail.Size = new System.Drawing.Size(373, 25);
			this.tbxEmail.TabIndex = 5;
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(315, 140);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(95, 40);
			this.btnThem.TabIndex = 6;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// btnCapNhat
			// 
			this.btnCapNhat.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCapNhat.Image = global::QuanLyDienNang.Properties.Resources.Rename;
			this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCapNhat.Location = new System.Drawing.Point(434, 140);
			this.btnCapNhat.Name = "btnCapNhat";
			this.btnCapNhat.Size = new System.Drawing.Size(112, 40);
			this.btnCapNhat.TabIndex = 7;
			this.btnCapNhat.Text = "Cập nhật";
			this.btnCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCapNhat.UseVisualStyleBackColor = true;
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXoa.Image = global::QuanLyDienNang.Properties.Resources.Delete1;
			this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXoa.Location = new System.Drawing.Point(569, 140);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(87, 40);
			this.btnXoa.TabIndex = 8;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// Form_NguoiQuanLy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_NguoiQuanLy";
			this.Text = "DANH SÁCH NGƯỜI QUẢN LÝ";
			this.tableParent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvNguoiQuanLy)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvNguoiQuanLy;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox tbxTenNQL;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxSoDT;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxMaNQL;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxEmail;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnCapNhat;
		private System.Windows.Forms.Button btnThem;
	}
}