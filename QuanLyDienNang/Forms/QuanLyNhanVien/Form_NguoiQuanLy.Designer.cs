
namespace QuanLyDienNang.Forms
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
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnThem = new System.Windows.Forms.Button();
			this.tbxEmail = new System.Windows.Forms.TextBox();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxTenNQL = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxSoDT = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxMaNQL = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
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
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
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
			this.dgvNguoiQuanLy.AllowUserToAddRows = false;
			this.dgvNguoiQuanLy.AllowUserToDeleteRows = false;
			this.dgvNguoiQuanLy.AllowUserToResizeRows = false;
			this.dgvNguoiQuanLy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvNguoiQuanLy.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.dgvNguoiQuanLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNguoiQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvNguoiQuanLy.Location = new System.Drawing.Point(3, 193);
			this.dgvNguoiQuanLy.MultiSelect = false;
			this.dgvNguoiQuanLy.Name = "dgvNguoiQuanLy";
			this.dgvNguoiQuanLy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvNguoiQuanLy.Size = new System.Drawing.Size(978, 365);
			this.dgvNguoiQuanLy.TabIndex = 1;
			this.dgvNguoiQuanLy.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiQuanLy_CellValueChanged);
			this.dgvNguoiQuanLy.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvNguoiQuanLy_DataBindingComplete);
			this.dgvNguoiQuanLy.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvNguoiQuanLy_DataError);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Controls.Add(this.tbxEmail);
			this.panel1.Controls.Add(this.tbxDiaChi);
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
			this.panel1.Size = new System.Drawing.Size(978, 154);
			this.panel1.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(931, 39);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 17);
			this.label8.TabIndex = 9;
			this.label8.Text = "(*)";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(650, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(21, 17);
			this.label9.TabIndex = 9;
			this.label9.Text = "(*)";
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(464, 39);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 17);
			this.label7.TabIndex = 9;
			this.label7.Text = "(*)";
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnThem.Image = global::QuanLyDienNang.Properties.Resources.Add1;
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(698, 110);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(95, 40);
			this.btnThem.TabIndex = 6;
			this.btnThem.Text = "Thêm";
			this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// tbxEmail
			// 
			this.tbxEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxEmail.Location = new System.Drawing.Point(168, 101);
			this.tbxEmail.MaxLength = 100;
			this.tbxEmail.Name = "tbxEmail";
			this.tbxEmail.Size = new System.Drawing.Size(290, 25);
			this.tbxEmail.TabIndex = 4;
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDiaChi.Location = new System.Drawing.Point(552, 39);
			this.tbxDiaChi.MaxLength = 250;
			this.tbxDiaChi.Multiline = true;
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(373, 60);
			this.tbxDiaChi.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(116, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "Email:";
			// 
			// tbxTenNQL
			// 
			this.tbxTenNQL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxTenNQL.Location = new System.Drawing.Point(168, 42);
			this.tbxTenNQL.MaxLength = 100;
			this.tbxTenNQL.Name = "tbxTenNQL";
			this.tbxTenNQL.Size = new System.Drawing.Size(290, 25);
			this.tbxTenNQL.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(493, 42);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "Địa chỉ:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên người quản lý:";
			// 
			// tbxSoDT
			// 
			this.tbxSoDT.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxSoDT.Location = new System.Drawing.Point(168, 70);
			this.tbxSoDT.MaxLength = 30;
			this.tbxSoDT.Name = "tbxSoDT";
			this.tbxSoDT.Size = new System.Drawing.Size(153, 25);
			this.tbxSoDT.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(68, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "Số điện thoại:";
			// 
			// tbxMaNQL
			// 
			this.tbxMaNQL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxMaNQL.Location = new System.Drawing.Point(485, 5);
			this.tbxMaNQL.MaxLength = 30;
			this.tbxMaNQL.Name = "tbxMaNQL";
			this.tbxMaNQL.Size = new System.Drawing.Size(159, 25);
			this.tbxMaNQL.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(346, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã người quản lý:";
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "xlsx";
			this.saveDialog.FileName = "Danh sách Người quản lý";
			this.saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
			this.saveDialog.RestoreDirectory = true;
			this.saveDialog.Title = "Lưu danh sách người quản lý";
			// 
			// Form_NguoiQuanLy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_NguoiQuanLy";
			this.Text = "DANH SÁCH NGƯỜI QUẢN LÝ";
			this.Shown += new System.EventHandler(this.Form_NguoiQuanLy_Shown);
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
		private System.Windows.Forms.TextBox tbxDiaChi;
		private System.Windows.Forms.TextBox tbxTenNQL;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxSoDT;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxMaNQL;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxEmail;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.SaveFileDialog saveDialog;
	}
}