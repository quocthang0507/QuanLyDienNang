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

		private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void nhậpThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmNhap = new FormKH_NhapKhachHang();
			frmNhap.MdiParent = this;
			frmNhap.Show();
		}

		private void xuấtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmXuat = new FormKH_XuatKhachHang();
			frmXuat.MdiParent = this;
			frmXuat.Show();
		}

		private void cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmDNTT = new FormKH_DienNangTieuThu();
			frmDNTT.MdiParent = this;
			frmDNTT.Show();
		}
	}
}
