using Business.Classes;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_NhapKhachHang : Form
	{
		Funcs_KH_DNTT funcs = new Funcs_KH_DNTT();
		Thread thread;

		public FormKH_NhapKhachHang()
		{
			InitializeComponent();
			cbxNguoiNhap.DisplayMember = "TenQuanLy";
			cbxNguoiNhap.ValueMember = "TenQuanLy";
		}

		private void FormKH_NhapKhachHang_Load(object sender, System.EventArgs e)
		{
			tbxDuongDan.Text = funcs.GetSavedExcelPath();
			cbxNguoiNhap.DataSource = funcs.LoadTable_NguoiQuanLy();
			UpdateSheetCombobox(tbxDuongDan.Text);
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
			UpdateSheetCombobox(path);
		}

		private void btnLoadNoiDung_Click(object sender, System.EventArgs e)
		{
			dgvThongTinKhachHang.DataSource = funcs.GetDataTableFromExcel(tbxDuongDan.Text, cbxSheet.Text);
		}

		private void UpdateSheetCombobox(string path)
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

		private void LoadDataTableFromExcel(string path, string sheet)
		{
			thread = new Thread(() =>
			  {
				  dgvThongTinKhachHang.Invoke((MethodInvoker)delegate
				  {
					  dgvThongTinKhachHang.DataSource = funcs.GetDataTableFromExcel(path, sheet);
				  });
			  });
			thread.Start();
		}
	}
}
