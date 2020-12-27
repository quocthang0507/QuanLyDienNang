using Business.Classes;
using Business.Helper;
using System;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_DienNangTieuThu : Form
	{
		private Funcs_KH_DNTT funcs = new Funcs_KH_DNTT();

		public FormKH_DienNangTieuThu()
		{
			InitializeComponent();
		}

		private void FormKH_DienNangTieuThu_Load(object sender, EventArgs e)
		{
			dgvDienNangTieuThu.DataSource = DienNangTieuThu.LoadTable();
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
