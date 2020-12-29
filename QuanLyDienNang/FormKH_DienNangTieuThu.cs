using Business.Classes;
using Business.Helper;
using System;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_DienNangTieuThu : Form
	{
		public FormKH_DienNangTieuThu()
		{
			InitializeComponent();
		}

		private void FormKH_DienNangTieuThu_Load(object sender, EventArgs e)
		{
			var data = DienNangTieuThu.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvDienNangTieuThu.DataSource = data;
		}

		private void tbxSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{

		}
	}
}
