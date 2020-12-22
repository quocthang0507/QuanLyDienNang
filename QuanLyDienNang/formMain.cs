using System;
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
			InitializeComponent();
			thread.Abort();
			toolBar.Visible = false;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			UpdateComputerName();
			this.Activate();
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
			Form frmGioiThieu = new Form_GioiThieu();
			frmGioiThieu.ShowDialog();
		}

		private void nhậpThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmNhap = new FormKH_NhapKhachHang();
			AddFormToTabPage(frmNhap);
		}

		private void xuấtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmXuat = new FormKH_XuatKhachHang();
			AddFormToTabPage(frmXuat);
		}

		private void cậpNhậtĐiệnNăngTiêuThụToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmDNTT = new FormKH_DienNangTieuThu();
			AddFormToTabPage(frmDNTT);
		}

		private void đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmOCR = new FormKH_DocChiSoDien();
			AddFormToTabPage(frmOCR);
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

		private void btnDongForm_Click(object sender, EventArgs e)
		{
			menuDong.PerformClick();
		}

		private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabForms.SelectedIndex == 0)
				toolBar.Visible = false;
			else
				toolBar.Visible = true;
		}

		/// <summary>
		/// Kiểm tra panel còn form nào hay không, nếu không có thì chèn form mới vào
		/// </summary>
		/// <param name="form"></param>
		private void AddFormToTabPage(Form form)
		{
			// Chỉnh sửa form trước khi thêm vào tab
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			// Tạo một tabPage và thêm form vào tab
			TabPage newTab = new TabPage
			{
				Text = form.Text
			};
			newTab.Controls.Add(form);
			newTab.ContextMenuStrip = contextTabMenu;
			// Hiển thị form và kích hoạt tab
			tabForms.TabPages.Add(newTab);
			tabForms.SelectedTab = newTab;
			form.Show();
		}

		private void ShowSplashScreen()
		{
			Application.Run(new FormWelcome());
		}

		private void UpdateComputerName()
		{
			lblComputerName.Text = Environment.MachineName;
		}
	}
}
