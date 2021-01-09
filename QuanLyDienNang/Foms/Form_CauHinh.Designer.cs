
namespace QuanLyDienNang.Forms
{
	partial class Form_CauHinh
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CauHinh));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxServers = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxChungThuc = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxTenCSDL = new System.Windows.Forms.TextBox();
			this.gbxChungThuc = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbxMatKhau = new System.Windows.Forms.TextBox();
			this.tbxTenDangNhap = new System.Windows.Forms.TextBox();
			this.btnKiemTra = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.gbxChungThuc.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(534, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "CẤU HÌNH KẾT NỐI MÁY CHỦ SQL SERVER";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(94, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tên SQL Server:";
			// 
			// cbxServers
			// 
			this.cbxServers.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxServers.FormattingEnabled = true;
			this.cbxServers.Location = new System.Drawing.Point(204, 45);
			this.cbxServers.Name = "cbxServers";
			this.cbxServers.Size = new System.Drawing.Size(219, 25);
			this.cbxServers.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(69, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "Chế độ chứng thực:";
			// 
			// cbxChungThuc
			// 
			this.cbxChungThuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxChungThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxChungThuc.FormattingEnabled = true;
			this.cbxChungThuc.Items.AddRange(new object[] {
			"Windows Authentication",
			"SQL Server Authentication"});
			this.cbxChungThuc.Location = new System.Drawing.Point(204, 75);
			this.cbxChungThuc.Name = "cbxChungThuc";
			this.cbxChungThuc.Size = new System.Drawing.Size(219, 25);
			this.cbxChungThuc.TabIndex = 2;
			this.cbxChungThuc.SelectedIndexChanged += new System.EventHandler(this.cbxChungThuc_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(81, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Tên Cơ sở dữ liệu:";
			// 
			// tbxTenCSDL
			// 
			this.tbxTenCSDL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxTenCSDL.Location = new System.Drawing.Point(204, 105);
			this.tbxTenCSDL.MaxLength = 200;
			this.tbxTenCSDL.Name = "tbxTenCSDL";
			this.tbxTenCSDL.Size = new System.Drawing.Size(219, 25);
			this.tbxTenCSDL.TabIndex = 3;
			// 
			// gbxChungThuc
			// 
			this.gbxChungThuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gbxChungThuc.Controls.Add(this.label6);
			this.gbxChungThuc.Controls.Add(this.label5);
			this.gbxChungThuc.Controls.Add(this.tbxMatKhau);
			this.gbxChungThuc.Controls.Add(this.tbxTenDangNhap);
			this.gbxChungThuc.Location = new System.Drawing.Point(51, 141);
			this.gbxChungThuc.Name = "gbxChungThuc";
			this.gbxChungThuc.Size = new System.Drawing.Size(412, 107);
			this.gbxChungThuc.TabIndex = 4;
			this.gbxChungThuc.TabStop = false;
			this.gbxChungThuc.Text = "SQL Server Authentication";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(78, 66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 19);
			this.label6.TabIndex = 1;
			this.label6.Text = "Mật khẩu:";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(44, 33);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Tên đăng nhập:";
			// 
			// tbxMatKhau
			// 
			this.tbxMatKhau.Location = new System.Drawing.Point(155, 63);
			this.tbxMatKhau.MaxLength = 200;
			this.tbxMatKhau.Name = "tbxMatKhau";
			this.tbxMatKhau.Size = new System.Drawing.Size(219, 25);
			this.tbxMatKhau.TabIndex = 5;
			this.tbxMatKhau.UseSystemPasswordChar = true;
			// 
			// tbxTenDangNhap
			// 
			this.tbxTenDangNhap.Location = new System.Drawing.Point(155, 30);
			this.tbxTenDangNhap.MaxLength = 200;
			this.tbxTenDangNhap.Name = "tbxTenDangNhap";
			this.tbxTenDangNhap.Size = new System.Drawing.Size(219, 25);
			this.tbxTenDangNhap.TabIndex = 4;
			// 
			// btnKiemTra
			// 
			this.btnKiemTra.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnKiemTra.Image = global::QuanLyDienNang.Properties.Resources.Refresh;
			this.btnKiemTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnKiemTra.Location = new System.Drawing.Point(121, 299);
			this.btnKiemTra.Name = "btnKiemTra";
			this.btnKiemTra.Size = new System.Drawing.Size(144, 40);
			this.btnKiemTra.TabIndex = 6;
			this.btnKiemTra.Text = "Kiểm tra kết nối";
			this.btnKiemTra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnKiemTra.UseVisualStyleBackColor = true;
			this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
			// 
			// btnLuu
			// 
			this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLuu.Enabled = false;
			this.btnLuu.Image = global::QuanLyDienNang.Properties.Resources.Save1;
			this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuu.Location = new System.Drawing.Point(271, 299);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(125, 40);
			this.btnLuu.TabIndex = 7;
			this.btnLuu.Text = "Lưu kết nối";
			this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.progressBar.Location = new System.Drawing.Point(85, 261);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(345, 23);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(429, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(23, 19);
			this.label7.TabIndex = 9;
			this.label7.Text = "(*)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(429, 108);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(23, 19);
			this.label8.TabIndex = 9;
			this.label8.Text = "(*)";
			// 
			// Form_CauHinh
			// 
			this.AcceptButton = this.btnLuu;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 361);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnLuu);
			this.Controls.Add(this.btnKiemTra);
			this.Controls.Add(this.gbxChungThuc);
			this.Controls.Add(this.tbxTenCSDL);
			this.Controls.Add(this.cbxChungThuc);
			this.Controls.Add(this.cbxServers);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_CauHinh";
			this.Text = "Cấu hình SQL Server";
			this.Shown += new System.EventHandler(this.Form_CauHinh_Shown);
			this.gbxChungThuc.ResumeLayout(false);
			this.gbxChungThuc.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxServers;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxChungThuc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxTenCSDL;
		private System.Windows.Forms.GroupBox gbxChungThuc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbxTenDangNhap;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbxMatKhau;
		private System.Windows.Forms.Button btnKiemTra;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
	}
}