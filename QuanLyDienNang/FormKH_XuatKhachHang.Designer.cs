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
			this.btnXuat = new System.Windows.Forms.Button();
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.cbxTenTram = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxDiaChi = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(978, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "XUẤT THÔNG TIN KHÁCH HÀNG";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnXuat
			// 
			this.btnXuat.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXuat.Image = global::QuanLyDienNang.Properties.Resources.Text_Document;
			this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuat.Location = new System.Drawing.Point(492, 1);
			this.btnXuat.Name = "btnXuat";
			this.btnXuat.Size = new System.Drawing.Size(134, 40);
			this.btnXuat.TabIndex = 3;
			this.btnXuat.Text = "Xuất Excel";
			this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnXuat.UseVisualStyleBackColor = true;
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.dataGridView1, 0, 3);
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.panel1, 0, 1);
			this.tableParent.Controls.Add(this.panel2, 0, 2);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 4;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 8;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 233);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(978, 425);
			this.dataGridView1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 144);
			this.panel1.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.cbxTenTram);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tbxDiaChi);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(978, 144);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Điều kiện xuất";
			// 
			// label14
			// 
			this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(91, 40);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(55, 17);
			this.label14.TabIndex = 11;
			this.label14.Text = "Địa chỉ:";
			// 
			// cbxTenTram
			// 
			this.cbxTenTram.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxTenTram.FormattingEnabled = true;
			this.cbxTenTram.Location = new System.Drawing.Point(584, 40);
			this.cbxTenTram.Name = "cbxTenTram";
			this.cbxTenTram.Size = new System.Drawing.Size(287, 24);
			this.cbxTenTram.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(496, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Tên trạm:";
			// 
			// tbxDiaChi
			// 
			this.tbxDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDiaChi.Location = new System.Drawing.Point(165, 40);
			this.tbxDiaChi.Name = "tbxDiaChi";
			this.tbxDiaChi.Size = new System.Drawing.Size(287, 23);
			this.tbxDiaChi.TabIndex = 9;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnXuat);
			this.panel2.Controls.Add(this.btnTimKiem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 183);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 44);
			this.panel2.TabIndex = 4;
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnTimKiem.Image = global::QuanLyDienNang.Properties.Resources.Search;
			this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTimKiem.Location = new System.Drawing.Point(372, 1);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(114, 40);
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimKiem.UseVisualStyleBackColor = true;
			// 
			// FormKH_XuatKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormKH_XuatKhachHang";
			this.Text = "Xuất Thông Tin Khách Hàng Ra Excel";
			this.tableParent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnXuat;
		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cbxTenTram;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxDiaChi;
	}
}