using Business.Classes;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_NhapKhachHang : Form
	{
		Funcs_KH_DNTT funcs = new Funcs_KH_DNTT();

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
			cbxSheet.DataSource = funcs.GetSheetNamesOnExcel(tbxDuongDan.Text);
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
			cbxSheet.DataSource = funcs.GetSheetNamesOnExcel(path);
		}
	}
}
