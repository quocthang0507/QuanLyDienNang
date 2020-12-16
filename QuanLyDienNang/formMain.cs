using QuanLyDienNang.Classes;
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

		private void btnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		} // nút Thoát

		private void btnThongTinDoanhNghiep_Click(object sender, EventArgs e) // Thông Tin Doanh Nghiệp
		{
			formThongTinDoanhNghiep tt = new formThongTinDoanhNghiep();
			tt.ShowDialog();
		}

		private void btnPhanQuyenQuanLy_Click(object sender, EventArgs e)
		{
			formPhanQuyenQuanLy pq = new formPhanQuyenQuanLy();

			pq.ShowDialog();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			Functions.Connect();
		}

		private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
		{
			formQuanLyKhachHang frm = new formQuanLyKhachHang();
			frm.ShowDialog();
		}

		private void btnNhapExcel_Click(object sender, EventArgs e)
		{
			formNhapKhachHang frm = new formNhapKhachHang();
			frm.ShowDialog();
		}
	}
}
