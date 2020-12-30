namespace QuanLyDienNang
{
    partial class Form_DienNangTieuThu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DienNangTieuThu));
			this.tableParent = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvDienNangTieuThu = new System.Windows.Forms.DataGridView();
			this.tableTop = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).BeginInit();
			this.tableTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableParent
			// 
			this.tableParent.ColumnCount = 1;
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableParent.Controls.Add(this.label1, 0, 0);
			this.tableParent.Controls.Add(this.dgvDienNangTieuThu, 0, 2);
			this.tableParent.Controls.Add(this.tableTop, 0, 1);
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
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(978, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "NHẬP CHỈ SỐ ĐIỆN NĂNG TIÊU THỤ VÀ IN HÓA ĐƠN";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvDienNangTieuThu
			// 
			this.dgvDienNangTieuThu.AllowUserToAddRows = false;
			this.dgvDienNangTieuThu.AllowUserToDeleteRows = false;
			this.dgvDienNangTieuThu.AllowUserToResizeRows = false;
			this.dgvDienNangTieuThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDienNangTieuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDienNangTieuThu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDienNangTieuThu.Location = new System.Drawing.Point(3, 233);
			this.dgvDienNangTieuThu.MultiSelect = false;
			this.dgvDienNangTieuThu.Name = "dgvDienNangTieuThu";
			this.dgvDienNangTieuThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDienNangTieuThu.Size = new System.Drawing.Size(978, 325);
			this.dgvDienNangTieuThu.TabIndex = 1;
			// 
			// tableTop
			// 
			this.tableTop.ColumnCount = 2;
			this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableTop.Controls.Add(this.groupBox1, 1, 0);
			this.tableTop.Controls.Add(this.groupBox2, 0, 0);
			this.tableTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableTop.Location = new System.Drawing.Point(3, 33);
			this.tableTop.Name = "tableTop";
			this.tableTop.RowCount = 1;
			this.tableTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableTop.Size = new System.Drawing.Size(978, 194);
			this.tableTop.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(296, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(679, 188);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin về chu kỳ";
			// 
			// groupBox2
			// 
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(287, 188);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin tìm kiếm";
			// 
			// Form_DienNangTieuThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tableParent);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form_DienNangTieuThu";
			this.Text = "Thông Tin Điện Năng Tiêu Thụ Của Khách Hàng";
			this.Shown += new System.EventHandler(this.FormKH_DienNangTieuThu_Shown);
			this.tableParent.ResumeLayout(false);
			this.tableParent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDienNangTieuThu)).EndInit();
			this.tableTop.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvDienNangTieuThu;
		private System.Windows.Forms.TableLayoutPanel tableTop;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}