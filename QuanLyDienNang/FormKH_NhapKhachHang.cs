using Business.Classes;
using Business.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_NhapKhachHang : Form
	{
		private const string ERROR = "Lỗi";
		private const string SUCCESS = "Thành công";
		private const string WARNING = "Cảnh báo";
		private const string ERROR_QUERY_MESSAGE = "Lỗi thực hiện truy vấn đến cơ sở dữ liệu";
		private const string ERROR_IMPORT_EXCEL = "Lỗi đọc dữ liệu từ tập tin Excel";
		private const string ERROR_NOT_FOUND_MESSAGE = "Không tìm thấy tập tin theo yêu cầu";
		private const string SAMPLE_PATH = "/Templates/NhapThongTinKhachHang_Sample.xlsx";
		private const string ERROR_INSERT_MESSAGE = "Thêm vào CSDL không thành công, vui lòng kiểm tra dữ liệu hợp lệ";
		private const string SUCCESS_INSERT_MESSAGE = "Thêm vào CSDL thành công";
		private const string WARNING_MISS_DGV_MESSAGE = "Không thể thực hiện hành động này vì DataGridView đang trống";
		private const string WARNING_MISS_FILE_MESSAGE = "Phải chọn tập tin trước khi thực hiện hành động này";
		private readonly Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_NhapKhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_NhapKhachHang_Shown(object sender, EventArgs e)
		{
			tbxDuongDan.Text = funcs.GetSavedExcelPathForImporting();
			LoadNguoiQuanLy();
			LoadSheet(tbxDuongDan.Text);
		}

		private void btnChonTapTin_Click(object sender, System.EventArgs e)
		{
			var result = openDialog.ShowDialog();
			if (result != DialogResult.OK || string.IsNullOrWhiteSpace(openDialog.FileName))
				return;
			var path = openDialog.FileName;
			tbxDuongDan.Text = path;
			funcs.SaveExcelPathForImporting(path);
			LoadSheet(path);
		}

		private void btnLoadNoiDung_Click(object sender, System.EventArgs e)
		{
			thread = new Thread(() =>
			  {
				  dgvKhachHang.Invoke((MethodInvoker)delegate
				  {
					  if (string.IsNullOrWhiteSpace(tbxDuongDan.Text))
					  {
						  MessageBox.Show(WARNING_MISS_FILE_MESSAGE, WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						  return;
					  }
					  var data = funcs.ReadExcelForInserting(tbxDuongDan.Text, cbxSheet.Text);
					  if (data == null)
						  MessageBox.Show(ERROR_IMPORT_EXCEL, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show(WARNING_MISS_DGV_MESSAGE, WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var maQL = (cbxNguoiNhap.SelectedItem as NguoiQuanLy).MaQuanLy;
			var data = funcs.UpdateListForInserting(dgvKhachHang.DataSource as List<KhachHang>, maQL);
			var ok = funcs.TryInsertingDataTableToSQL(data);
			if (ok)
			{
				funcs.InsertSQL(dgvKhachHang.DataSource as List<KhachHang>);
				MessageBox.Show(SUCCESS_INSERT_MESSAGE, SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(ERROR_INSERT_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXemMau_Click(object sender, System.EventArgs e)
		{
			string filepath = AppDomain.CurrentDomain.BaseDirectory + SAMPLE_PATH;
			if (File.Exists(filepath))
				Process.Start(filepath);
			else
				MessageBox.Show(ERROR_NOT_FOUND_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#endregion

		#region Methods
		private void LoadSheet(string path)
		{
			var data = funcs.GetSheetNamesOnExcel(path);
			if (data == null)
				MessageBox.Show(ERROR_IMPORT_EXCEL, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxSheet.DataSource = data;
		}

		private void LoadNguoiQuanLy()
		{
			var data = NguoiQuanLy.GetAll();
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxNguoiNhap.DataSource = data;
		}

		public void GoToIndex(int index)
		{
			dgvKhachHang.ClearSelection();
			dgvKhachHang.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvKhachHang.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvKhachHang.SelectedRows[0].Index;
			if (index < dgvKhachHang.Rows.Count - 1)
			{
				index++;
				GoToIndex(index);
			}
		}

		public void GoToFirst()
		{
			GoToIndex(0);
		}

		public void GoToEnd()
		{
			GoToIndex(dgvKhachHang.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvKhachHang.SelectedRows.Count > 0)
			{
				var row = dgvKhachHang.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < row.Cells.Count; i++)
				{
					builder.Append(row.Cells[i].Value.ToString() + '\t');
				}
				return builder.ToString();
			}
			return string.Empty;
		}
		#endregion

	}
}
