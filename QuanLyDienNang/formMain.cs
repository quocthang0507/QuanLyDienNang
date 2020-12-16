using System;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void btnThongTinDoanhNghiep_Click(object sender, EventArgs e) // Thông Tin Doanh Nghiệp
		{
			FormThongTinDoanhNghiep tt = new FormThongTinDoanhNghiep();
			tt.ShowDialog();
		}

		private void btnPhanQuyenQuanLy_Click(object sender, EventArgs e)
		{
			FormPhanQuyenQuanLy pq = new FormPhanQuyenQuanLy();
			pq.ShowDialog();
		}

		private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
		{
			FormQuanLyKhachHang frm = new FormQuanLyKhachHang();
			frm.ShowDialog();
		}

		private void btnNhapExcel_Click(object sender, EventArgs e)
		{
			FormNhapKhachHang frm = new FormNhapKhachHang();
			frm.ShowDialog();
		}
	}
}
