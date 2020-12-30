using Business.Classes;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_CapNhatKhachHang : Form
	{
		private Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_CapNhatKhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_CapNhatKhachHang_Load(object sender, System.EventArgs e)
		{
			LoadNguoiQuanLy();
		}

		private void btnChonTapTin_Click(object sender, System.EventArgs e)
		{
			var result = openDialog.ShowDialog();
			if (result != DialogResult.OK || string.IsNullOrWhiteSpace(openDialog.FileName))
				return;
			var path = openDialog.FileName;
			tbxDuongDan.Text = path;
			LoadSheet(path);
		}

		private void btnLoadNoiDung_Click(object sender, System.EventArgs e)
		{
			thread = new Thread(() =>
			{
				dgvKhachHang.Invoke((MethodInvoker)delegate
				{
					var data = funcs.ReadExcelForInserting(tbxDuongDan.Text, cbxSheet.Text, (cbxNguoiCapNhat.SelectedItem as NguoiQuanLy).MaQuanLy);
					if (data == null)
						MessageBox.Show("Lỗi đọc dữ liệu từ tập tin Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
						dgvKhachHang.DataSource = data;
				});
			});
			thread.Start();
		}

		private void btnLuuCSDL_Click(object sender, System.EventArgs e)
		{
			if (dgvKhachHang.DataSource == null)
			{
				MessageBox.Show("Không thể thực hiện hành động này vì DataGridView đang trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var ok = funcs.TryUpdatingDataTableToSQL(dgvKhachHang.DataSource as List<KhachHang>);
			if (ok)
			{
				funcs.UpdateSQL(dgvKhachHang.DataSource as List<KhachHang>);
				MessageBox.Show("Thêm vào CSDL thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Thêm vào CSDL không thành công, vui lòng kiểm tra dữ liệu hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Methods
		private void LoadSheet(string path)
		{
			var data = funcs.GetSheetNamesOnExcel(path);
			if (data == null)
				MessageBox.Show("Lỗi đọc dữ liệu từ tập tin Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxSheet.DataSource = data;
		}

		private void LoadNguoiQuanLy()
		{
			var data = NguoiQuanLy.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxNguoiCapNhat.DataSource = data;
		}
		#endregion
	}
}
