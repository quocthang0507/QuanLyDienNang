using Business.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class Form_Main : Form
	{
		private const string ERROR_COPY_MESSAGE = "Đã có lỗi khi sao chép dòng này";
		private const string ERROR = "Lỗi";
		private const string SUCCESS_COPY_MESSAGE = "Sao chép dòng vào bảng tạm thành công";
		private const string SUCCESS = "Thành công";
		private const string QUESTION = "Xác nhận";
		private const string QUESTION_QUIT_MESSAGE = "Bạn có muốn thoát khỏi chương trình không?";
		private const string WARNING = "Cảnh báo";
		private const string WARNING_NO_SQL_CONNECTION_MESSAGE = "Bạn không thiết lập kết nối đến máy chủ SQL nên chương trình sẽ thoát tại đây!";
		private bool EXIT_WITHOUT_DIALOG = false;
		private dynamic DynamicForm;
		private Form frmCauHinh = new Form_CauHinh();

		// Ủy quyền xử lý từ form main sang các form con
		private delegate void MyDelegate();
		MyDelegate GoUp, GoDown, GoToFirst, GoToEnd, Delete;

		private readonly Funcs_Main funcs = new Funcs_Main();

		public Form_Main()
		{
			Thread thread = new Thread(ShowSplashScreen);
			thread.Start();
			InitializeComponent();
			thread.Abort();
			toolBar.Visible = false;
		}

		#region Events
		private void Form_Main_Shown(object sender, EventArgs e)
		{
			frmCauHinh.FormClosing += FrmCauHinh_FormClosing;
			if (!funcs.CheckConnectionString())
			{
				frmCauHinh.ShowDialog();
			}
			UpdateStatusBar();
			this.Activate();
		}

		private void FrmCauHinh_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!funcs.CheckConnectionString())
			{
				MessageBox.Show(WARNING_NO_SQL_CONNECTION_MESSAGE, WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				EXIT_WITHOUT_DIALOG = true;
				thoátToolStripMenuItem.PerformClick();
			}
		}

		private void cấuHìnhSQLStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCauHinh.ShowDialog();
		}

		private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmGioiThieu = new Form_GioiThieu_New();
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
			Form frmDNTT = new Form_DienNangTieuThu();
			AddFormToTabPage(frmDNTT);
		}

		private void đọcChỉSốĐiệnNăngTiêuThụToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmOCR = new Form_DocChiSoDien();
			AddFormToTabPage(frmOCR);
		}

		private void quảnLýNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Form frmNQL = new Form_NguoiQuanLy();
			AddFormToTabPage(frmNQL);
		}

		private void cậpNhậtThôngTinTừExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frmCapNhatKH = new FormKH_CapNhatKhachHang();
			AddFormToTabPage(frmCapNhatKH);
		}

		private void btnLen_Click(object sender, EventArgs e)
		{
			GoUp.Invoke();
		}

		private void btnXuong_Click(object sender, EventArgs e)
		{
			GoDown.Invoke();
		}

		private void btnTrenCung_Click(object sender, EventArgs e)
		{
			GoToFirst.Invoke();
		}

		private void btnDuoiCung_Click(object sender, EventArgs e)
		{
			GoToEnd.Invoke();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			Delete.Invoke();
		}

		private void btnSaoChep_Click(object sender, EventArgs e)
		{
			try
			{
				string selected = DynamicForm.ToString();
				Clipboard.SetText(selected);
			}
			catch (Exception)
			{
				MessageBox.Show(ERROR_COPY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			MessageBox.Show(SUCCESS_COPY_MESSAGE, SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			{
				toolBar.Visible = true;
				SwitchFormObject();
			}
		}

		private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!EXIT_WITHOUT_DIALOG)
			{
				DialogResult dialog = MessageBox.Show(QUESTION_QUIT_MESSAGE, QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialog == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
			Form frmBaoCao = new Form_BaoCao();
			frmBaoCao.ShowDialog();
		}

		private void btnIn_Click(object sender, EventArgs e)
		{

		}

		#endregion

		#region Methods
		/// <summary>
		/// Kiểm tra panel còn form nào hay không, nếu không có thì chèn form mới vào
		/// </summary>
		/// <param name="form"></param>
		private void AddFormToTabPage(Form form)
		{
			// Kiểm tra form có nằm trong tabControl trước đó hay không
			foreach (TabPage tabPage in tabForms.TabPages)
			{
				if (tabPage.Controls.Count > 0 && tabPage.Controls[0] is Form)
				{
					var existedForm = tabPage.Controls[0] as Form;
					if (form.Text == existedForm.Text)
					{
						tabForms.SelectedTab = tabPage;
						return;
					}
				}
			}
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

		private void UpdateStatusBar()
		{
			lblServer.Text = "Tên máy chủ SQL: " + funcs.GetSQLServerName();
			lblCSDL.Text = "Tên cơ sở dữ liệu: " + funcs.GetDatabase();
			lblComputerName.Text = "Tên máy tính: " + Environment.MachineName;
		}

		private void SwitchFormObject()
		{
			if (tabForms.SelectedTab.Controls[0] is Form_NguoiQuanLy)
			{
				DynamicForm = tabForms.SelectedTab.Controls[0] as Form_NguoiQuanLy;
			}
			else if (tabForms.SelectedTab.Controls[0] is Form_DienNangTieuThu)
			{
				DynamicForm = tabForms.SelectedTab.Controls[0] as Form_DienNangTieuThu;
			}
			else if (tabForms.SelectedTab.Controls[0] is FormKH_CapNhatKhachHang)
			{
				DynamicForm = tabForms.SelectedTab.Controls[0] as FormKH_CapNhatKhachHang;
			}
			else if (tabForms.SelectedTab.Controls[0] is FormKH_XuatKhachHang)
			{
				DynamicForm = tabForms.SelectedTab.Controls[0] as FormKH_XuatKhachHang;
			}
			else if (tabForms.SelectedTab.Controls[0] is FormKH_NhapKhachHang)
			{
				DynamicForm = tabForms.SelectedTab.Controls[0] as FormKH_NhapKhachHang;
			}
			else return;
			GoUp = () => DynamicForm.GoUp();
			GoDown = () => DynamicForm.GoDown();
			GoToFirst = () => DynamicForm.GoToFirst();
			GoToEnd = () => DynamicForm.GoToEnd();
			Delete = () => DynamicForm.btnXoa_Click(null, null);
		}
		#endregion
	}
}
