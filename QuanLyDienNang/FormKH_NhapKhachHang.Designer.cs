namespace QuanLyDienNang
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
			this.btnNhapExcel = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxSheet = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tableParent.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbxDuongDan
			// 
			this.tbxDuongDan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tbxDuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbxDuongDan.Location = new System.Drawing.Point(209, 9);
			this.tbxDuongDan.Margin = new System.Windows.Forms.Padding(4);
			this.tbxDuongDan.Name = "tbxDuongDan";
			this.tbxDuongDan.Size = new System.Drawing.Size(621, 23);
			this.tbxDuongDan.TabIndex = 3;
			// 
			// btnNhapExcel
			// 
			this.btnNhapExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnNhapExcel.Image = global::QuanLyDienNang.Properties.Resources.Loading;
			this.btnNhapExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNhapExcel.Location = new System.Drawing.Point(348, 1);
			this.btnNhapExcel.Name = "btnNhapExcel";
			this.btnNhapExcel.Size = new System.Drawing.Size(143, 40);
			this.btnNhapExcel.TabIndex = 7;
			this.btnNhapExcel.Text = "Nhập từ Excel";
			this.btnNhapExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNhapExcel.UseVisualStyleBackColor = true;
			// 
			// btnLuu
			// 
			this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLuu.Image = global::QuanLyDienNang.Properties.Resources.Save;
			this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuu.Location = new System.Drawing.Point(497, 3);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(100, 40);
			this.btnLuu.TabIndex = 7;
			this.btnLuu.Text = "Lưu lại";
			this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnLuu.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(106, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Đường dẫn:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(106, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Chọn sheet:";
			// 
			// cbxSheet
			// 
			this.cbxSheet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cbxSheet.FormattingEnabled = true;
			this.cbxSheet.Location = new System.Drawing.Point(209, 36);
			this.cbxSheet.Name = "cbxSheet";
			this.cbxSheet.Size = new System.Drawing.Size(324, 24);
			this.cbxSheet.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbxSheet);
			this.panel1.Controls.Add(this.tbxDuongDan);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 83);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 74);
			this.panel1.TabIndex = 10;
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.Controls.Add(this.panel1, 0, 2);
			this.tableParent.Controls.Add(this.panel2, 0, 1);
			this.tableParent.Controls.Add(this.label3, 0, 0);
			this.tableParent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableParent.Location = new System.Drawing.Point(0, 0);
			this.tableParent.Name = "tableParent";
			this.tableParent.RowCount = 4;
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableParent.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableParent.Size = new System.Drawing.Size(984, 561);
			this.tableParent.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnLuu);
			this.panel2.Controls.Add(this.btnNhapExcel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 33);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 44);
			this.panel2.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(978, 30);
			this.label3.TabIndex = 12;
			this.label3.Text = "NHẬP THÔNG TIN KHÁCH HÀNG";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormKH_NhapKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormKH_NhapKhachHang";
			this.Text = "Nhập Thông Tin Khách Hàng Từ Excel";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableParent.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbxDuongDan;
		private System.Windows.Forms.Button btnNhapExcel;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxSheet;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
	}
}