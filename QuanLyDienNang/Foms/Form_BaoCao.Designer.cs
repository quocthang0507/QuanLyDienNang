
namespace QuanLyDienNang.Forms
{
	partial class Form_BaoCao
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BaoCao));
			this.crystalViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.hoaDonTienDien = new QuanLyDienNang.Reports.HoaDonTienDien();
			this.SuspendLayout();
			// 
			// crystalViewer
			// 
			this.crystalViewer.ActiveViewIndex = -1;
			this.crystalViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalViewer.Cursor = System.Windows.Forms.Cursors.Default;
			this.crystalViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalViewer.Location = new System.Drawing.Point(0, 0);
			this.crystalViewer.Name = "crystalViewer";
			this.crystalViewer.Size = new System.Drawing.Size(984, 561);
			this.crystalViewer.TabIndex = 0;
			// 
			// Form_BaoCao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.crystalViewer);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form_BaoCao";
			this.Text = "Xuất báo cáo";
			this.Load += new System.EventHandler(this.Form_BaoCao_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalViewer;
		private Reports.HoaDonTienDien hoaDonTienDien;
	}
}