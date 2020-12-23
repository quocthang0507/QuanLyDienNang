using System;
using System.Threading;
using System.Windows.Forms;
using ThuVien.Classes;

namespace QuanLyDienNang
{
	public partial class Form_CauHinh : Form
	{
		private Funcs_CauHinh funcs = new Funcs_CauHinh();
		private Thread threadTest;
		private bool connectable = false;

		public Form_CauHinh()
		{
			InitializeComponent();
		}

		private void Form_CauHinh_Load(object sender, EventArgs e)
		{
			cbxServers.DataSource = Funcs_CauHinh.GetServers();
			cbxChungThuc.SelectedIndex = 0;
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{

		}

		private void btnKiemTra_Click(object sender, EventArgs e)
		{
			threadTest = new Thread(() =>
			{
				// Ủy quyền xử lý cho thread chính
				progressBar.Invoke((MethodInvoker)delegate
				{
					progressBar.MarqueeAnimationSpeed = 100;
					connectable = TestConnection();
					{
						if (connectable)
						{
							MessageBox.Show("Kết nối đến cơ sở dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
							btnLuu.Enabled = true;
						}
						else
						{
							MessageBox.Show("Kết nối đến cơ sở dữ liệu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
							btnLuu.Enabled = false;
						}
						progressBar.MarqueeAnimationSpeed = 0;
					}
				});
			});
			threadTest.Start();
		}

		private void cbxChungThuc_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxChungThuc.SelectedIndex == 0)
				gbxChungThuc.Enabled = false;
			else
				gbxChungThuc.Enabled = true;
		}

		private bool TestConnection()
		{
			// Lấy thông tin từ textbox
			string server = cbxServers.Text;
			string database = tbxTenCSDL.Text;
			string username = tbxTenDangNhap.Text;
			string password = tbxMatKhau.Text;
			// Kiểm tra các textbox có null không
			if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database))
			{
				MessageBox.Show("Không được để trống hai trường bắt buộc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			// Bắt đầu kiểm tra kết nối
			if (cbxChungThuc.SelectedIndex == 0)
			{
				return funcs.TestConnectionString(server, database);
			}
			else
			{
				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				{
					MessageBox.Show("Không được để trống thông tin đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
				return funcs.TestConnectionString(server, database, username, password);
			}
		}
	}
}
