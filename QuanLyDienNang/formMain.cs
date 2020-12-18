using System;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormMain : Form
	{
		private Form SplashScreen;

		public FormMain()
		{
			InitializeComponent();
		}

		public FormMain(Form form)
		{
			this.SplashScreen = form;
			InitializeComponent();
			if(this.SplashScreen!=null)
			{
				this.SplashScreen.Close();
				this.SplashScreen = null;
			}	
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

		/// <summary>
		/// Đóng form bên trong panel, trường hợp không đóng được do form đó chưa hoàn tất công việc
		/// </summary>
		/// <returns>True/False: Đã đóng hết các form hay chưa</returns>
		private bool CloseAllFormsInPanel()
		{
			foreach (var control in panelParent.Controls)
			{
				if (control is Form)
				{
					var form = control as Form;
					form.Close();
				}
			}
			if (panelParent.Controls.Count > 0)
				return false;
			return true;
		}

		/// <summary>
		/// Kiểm tra panel còn form nào hay không, nếu không có thì chèn form mới vào
		/// </summary>
		/// <param name="form"></param>
		private void AddFormToPanel(Form form)
		{
			form.FormBorderStyle = FormBorderStyle.None;
			form.TopLevel = false;
			form.Dock = DockStyle.Fill;
			if (!CloseAllFormsInPanel())
				return;
			panelParent.Controls.Add(form);
			form.Show();
		}
	}
}
