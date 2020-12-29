using Business.Classes;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_NhapKhachHang : Form
	{
		private Funcs_NhapKhachHang funcs = new Funcs_NhapKhachHang();
		private Thread thread;

		public FormKH_NhapKhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_NhapKhachHang_Load(object sender, System.EventArgs e)
		{
			tbxDuongDan.Text = funcs.GetSavedExcelPath();
			LoadNguoiQuanLy();
			LoadSheet(tbxDuongDan.Text);
		}

		private void btnChonTapTin_Click(object sender, System.EventArgs e)
		{
			string path = tbxDuongDan.Text;
			if (string.IsNullOrWhiteSpace(tbxDuongDan.Text))
			{
				var result = fileDialog.ShowDialog();
				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fileDialog.FileName))
					return;
				path = fileDialog.FileName;
			}
			tbxDuongDan.Text = path;
			funcs.Save_ExcelFilePath(path);
			LoadSheet(path);
		}

		private void btnLoadNoiDung_Click(object sender, System.EventArgs e)
		{
			thread = new Thread(() =>
			  {
				  dgvKhachHang.Invoke((MethodInvoker)delegate
				  {
					  var data = funcs.GetBindingSourceFromExcel(tbxDuongDan.Text, cbxSheet.Text, (cbxNguoiNhap.SelectedItem as NguoiQuanLy).MaQuanLy);
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
			var ok = funcs.TryAddingDataTableToSQL(dgvKhachHang.DataSource as List<KhachHang>);
			if (ok)
			{
				funcs.AddDataTableToSQL(dgvKhachHang.DataSource as List<KhachHang>);
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
			thread = new Thread(() =>
			{
				cbxSheet.Invoke((MethodInvoker)delegate
				{
					cbxSheet.DataSource = funcs.GetSheetNamesOnExcel(path);
				});
			});
			thread.Start();
		}

		private void LoadNguoiQuanLy()
		{
			var data = NguoiQuanLy.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxNguoiNhap.DataSource = data;
		}
		#endregion
	}
}
