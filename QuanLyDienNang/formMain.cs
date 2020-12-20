using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			Thread thread = new Thread(ShowSplashScreen);
			thread.Start();
			Thread.Sleep(2000);
			InitializeComponent();
			thread.Abort();
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
			AddFormToPanel(frmNhap);
		}

		private void xuấtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmXuat = new FormKH_XuatKhachHang();
			AddFormToPanel(frmXuat);
		}

		private void cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmDNTT = new FormKH_DienNangTieuThu();
			AddFormToPanel(frmDNTT);
		}

		private void đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmOCR = new FormKH_DocChiSoDien();
			AddFormToPanel(frmOCR);
		}

		private void menuDong_Click(object sender, EventArgs e)
		{
			var tab = tabForms.SelectedTab;
			if (tab.Name == "tabMain")
				return;
			var form = tab.Controls[0] as Form;
			form.Close();
			tabForms.TabPages.Remove(tab);
		}

		/// <summary>
		/// Kiểm tra panel còn form nào hay không, nếu không có thì chèn form mới vào
		/// </summary>
		/// <param name="form"></param>
		private void AddFormToPanel(Form form)
		{
			// Chỉnh sửa form trước khi thêm vào tab
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			// Tạo một tabPage và thêm form vào tab
			TabPage newTab = new TabPage();
			newTab.Text = form.Text;
			newTab.Controls.Add(form);
			newTab.ContextMenuStrip = contextTabMenu;
			tabForms.TabPages.Add(newTab);
			// Hiển thị form và kích hoạt tab
			form.Show();
		}

		private void ShowSplashScreen()
		{
			Application.Run(new FormWelcome());
		}

		private void btnDongForm_Click(object sender, EventArgs e)
		{
			menuDong.PerformClick();
		}
	}
}
