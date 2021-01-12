using Business.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_Main : Form
	{
		private bool EXIT_WITHOUT_DIALOG = false;
		private dynamic DynamicForm;
		private readonly Form frmCauHinh = new Form_CauHinh();
		private static Form_Main Singleton;

		// Ủy quyền xử lý từ form main sang các form con
		private delegate void MyDelegate();
		private MyDelegate GoUp, GoDown, GoToFirst, GoToEnd, ExportToExcel;

		private readonly Funcs_Main funcs = new Funcs_Main();

		public static Form_Main Instance
		{
			get
			{
				if (Singleton == null)
					Singleton = new Form_Main();
				return Singleton;
			}
		}

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
				MessageBox.Show(STRINGS.WARNING_NO_SQL_CONNECTION_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private void btnSaoChep_Click(object sender, EventArgs e)
		{
			try
			{
				string selected = DynamicForm.ToString();
				Clipboard.SetText(selected);
			}
			catch (Exception)
			{
				MessageBox.Show(STRINGS.ERROR_COPY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			MessageBox.Show(STRINGS.SUCCESS_COPY_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void menuDong_Click(object sender, EventArgs e)
		{
			TabPage tab = tabForms.SelectedTab;
			if (tab.Name == "tabMain")
				return;
			Form form = tab.Controls[0] as Form;
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
				DialogResult dialog = MessageBox.Show(STRINGS.QUESTION_QUIT_MESSAGE, STRINGS.QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

		private void btnXuatExcel_Click(object sender, EventArgs e)
		{
			ExportToExcel.Invoke();
		}

		private void btnIn_Click(object sender, EventArgs e)
		{

		}

		private void quảnLýBảngGiáToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Form frmBangGia = new Form_BangGia();
			AddFormToTabPage(frmBangGia);
		}

		private void quảnLýTrạmBiếnÁpToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Form frmTramBienAp = new Form_TramBienAp();
			AddFormToTabPage(frmTramBienAp);
		}

		#endregion

		#region Methods
		/// <summary>
		/// Kiểm tra panel còn form nào hay không, nếu không có thì chèn form mới vào
		/// </summary>
		/// <param name="form"></param>
		public void AddFormToTabPage(Form form)
		{
			// Kiểm tra form có nằm trong tabControl trước đó hay không
			foreach (TabPage tabPage in tabForms.TabPages)
			{
				if (tabPage.Controls.Count > 0 && tabPage.Controls[0] is Form)
				{
					Form existedForm = tabPage.Controls[0] as Form;
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
			switch (tabForms.SelectedTab.Controls[0])
			{
				case Form_NguoiQuanLy _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as Form_NguoiQuanLy;
					break;
				case Form_DienNangTieuThu _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as Form_DienNangTieuThu;
					break;
				case FormKH_CapNhatKhachHang _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as FormKH_CapNhatKhachHang;
					break;
				case FormKH_XuatKhachHang _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as FormKH_XuatKhachHang;
					break;
				case FormKH_NhapKhachHang _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as FormKH_NhapKhachHang;
					break;
				case Form_BangGia _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as Form_BangGia;
					break;
				case Form_ChiTietBangGia _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as Form_ChiTietBangGia;
					break;
				case Form_BangDienApGia _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as Form_BangDienApGia;
					break;
				case Form_TramBienAp _:
					DynamicForm = tabForms.SelectedTab.Controls[0] as Form_TramBienAp;
					break;
				default:
					return;
			}
			GoUp = () => DynamicForm.GoUp();
			GoDown = () => DynamicForm.GoDown();
			GoToFirst = () => DynamicForm.GoToFirst();
			GoToEnd = () => DynamicForm.GoToEnd();
			ExportToExcel = () => DynamicForm.ExportToExcel();
		}
		#endregion
	}
}
