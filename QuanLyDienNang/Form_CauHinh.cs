using System;
using System.Threading;
using System.Windows.Forms;
using ThuVien.Classes;

namespace QuanLyDienNang
{
	public partial class Form_CauHinh : Form
	{
		private Funcs_CauHinh funcs = new Funcs_CauHinh();
		private Thread thread;

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
						MessageBox.Show("Lưu thành công chuỗi kết nối", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Không thể lưu chuỗi kết nối, vui lòng kiểm tra lại các thông tin cho hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
							MessageBox.Show("Không được để trống các trường bắt buộc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							btnLuu.Enabled = false;
						}
						else if (connectable.Value)
						{
							MessageBox.Show("Kết nối đến cơ sở dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
							btnLuu.Enabled = true;
						}
						else
						{
							MessageBox.Show("Kết nối đến cơ sở dữ liệu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private bool? TestConnection()
		{
			// Lấy thông tin từ textbox
			string server = cbxServers.Text;
			string database = tbxTenCSDL.Text;
			string username = tbxTenDangNhap.Text;
			string password = tbxMatKhau.Text;
			// Kiểm tra các textbox có null không
			if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database))
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
				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				{
					return null;
				}
				return funcs.TestConnectionString(server, database, username, password);
			}
		}
	}
}
