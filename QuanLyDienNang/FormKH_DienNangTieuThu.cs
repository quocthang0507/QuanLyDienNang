using Business.Classes;
using Business.Helper;
using System;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_DienNangTieuThu : Form
	{
		private Funcs_DienNangTieuThu funcs = new Funcs_DienNangTieuThu();

		public FormKH_DienNangTieuThu()
		{
			InitializeComponent();
		}

		private void FormKH_DienNangTieuThu_Load(object sender, EventArgs e)
		{
			dgvDienNangTieuThu.DataSource = funcs.LoadTable_DienNangTieuThu();
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
