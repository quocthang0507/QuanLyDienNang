using Business.Classes;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_XuatKhachHang : Form
	{
		public FormKH_XuatKhachHang()
		{
			InitializeComponent();
		}

		private void fbtnXuatHet_CheckedChanged(object sender, System.EventArgs e)
		{
			panelXuatDieuKien.Enabled = false;
		}

		private void rbtnXuatDieuKien_CheckedChanged(object sender, System.EventArgs e)
		{
			panelXuatDieuKien.Enabled = true;
		}

		private void btnTimKiem_Click(object sender, System.EventArgs e)
		{
			dgv KhachHang.All
		}
	}
}
