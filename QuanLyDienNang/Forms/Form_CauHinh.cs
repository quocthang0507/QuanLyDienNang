using Business.Forms;
using Business.Helper;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_CauHinh : Form
	{
		private readonly Funcs_CauHinh funcs = new Funcs_CauHinh();
		private Thread thread;

		public Form_CauHinh()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_CauHinh_Shown(object sender, EventArgs e)
		{
			cbxServers.DataSource = Funcs_CauHinh.GetServers();
			cbxChungThuc.SelectedIndex = 0;
			LoadSavedConnectionString();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			// Tạo một thread mới để kiểm tra và lưu chuỗi kết nối
			thread = new Thread(() =>
			{
				// Ủy quyền xử lý cho thread chính
				btnLuu.Invoke((MethodInvoker)delegate
				{
					var connectable = TestConnection();
					if (connectable != null && connectable.Value)
					{
						funcs.SaveConnectionString();
						MessageBox.Show(STRINGS.SUCCESS_SAVE_CNNSTR_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show(STRINGS.ERROR_SAVE_CNNSTR_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				});
			});
			thread.Start();
		}

		private void btnKiemTra_Click(object sender, EventArgs e)
		{
			// Tạo một thread mới kiểm tra kết nối
			thread = new Thread(() =>
			{
				// Ủy quyền xử lý cho thread chính
				btnKiemTra.Invoke((MethodInvoker)delegate
				{
					progressBar.Style = ProgressBarStyle.Marquee;
					var connectable = TestConnection();
					{
						if (connectable == null)
						{
							MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
							btnLuu.Enabled = false;
						}
						else if (connectable.Value)
						{
							MessageBox.Show(STRINGS.SUCCESS_CNNSTR_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
							btnLuu.Enabled = true;
						}
						else
						{
							MessageBox.Show(STRINGS.ERROR_CNNSTR_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
							btnLuu.Enabled = false;
						}
					}
					progressBar.Style = ProgressBarStyle.Continuous;
				});
			});
			thread.Start();
		}

		private void cbxChungThuc_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxChungThuc.SelectedIndex == 0)
				gbxChungThuc.Enabled = false;
			else
				gbxChungThuc.Enabled = true;
		}
		#endregion

		#region Methods
		private bool? TestConnection()
		{
			// Lấy thông tin từ textbox
			string server = cbxServers.Text;
			string database = tbxTenCSDL.Text;
			string username = tbxTenDangNhap.Text;
			string password = tbxMatKhau.Text;
			// Kiểm tra các textbox có null không
			if (Common.IsNullOrWhiteSpace(server, database))
			{
				return null;
			}
			// Bắt đầu kiểm tra kết nối
			if (cbxChungThuc.SelectedIndex == 0)
			{
				return funcs.TestConnectionString(server, database);
			}
			else
			{
				if (Common.IsNullOrWhiteSpace(username, password))
				{
					return null;
				}
				return funcs.TestConnectionString(server, database, username, password);
			}
		}

		private void LoadSavedConnectionString()
		{
			string server = "", database = "", username = "", password = "";
			funcs.GetSavedConnectionString(ref server, ref database, ref username, ref password);
			cbxServers.Text = server;
			tbxTenCSDL.Text = database;
			tbxTenDangNhap.Text = username;
			tbxMatKhau.Text = password;
		}

		#endregion

	}
}
