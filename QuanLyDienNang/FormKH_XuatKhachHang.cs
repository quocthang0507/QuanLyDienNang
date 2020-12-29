using Business.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_XuatKhachHang : Form
	{
		private Funcs_XuatKhachHang funcs = new Funcs_XuatKhachHang();

		public FormKH_XuatKhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_XuatKhachHang_Load(object sender, System.EventArgs e)
		{
			LoadBangGia();
			LoadTramQuanLy();
			LoadDanhSachNganHang();
		}

		private void rbtnXuatHet_CheckedChanged(object sender, System.EventArgs e)
		{
			panelXuatDieuKien.Enabled = false;
		}

		private void rbtnXuatDieuKien_CheckedChanged(object sender, System.EventArgs e)
		{
			panelXuatDieuKien.Enabled = true;
		}

		private void btnTimKiem_Click(object sender, System.EventArgs e)
		{
			if (rbtnXuatHet.Checked)
				dgvKhachHang.DataSource = KhachHang.All();
			else
			{
				string maBangGia, maTram;
				maBangGia = (cbxBangGia.SelectedItem as BangGia).MaBangGia;
				maTram = (cbxTenTram.SelectedItem as TramBienAp).MaTram;
				dgvKhachHang.DataSource = funcs.FilterTable(tbxDiaChi.Text, maBangGia, maTram, cbxNganHang.Text);
			}
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{

		}
#endregion

		#region Methods
		private void LoadTramQuanLy()
		{
			var data = TramBienAp.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxTenTram.DataSource = data;

		}

		private void LoadBangGia()
		{
			var data = BangGia.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxBangGia.DataSource = data;
		}

		private void LoadDanhSachNganHang()
		{
			cbxNganHang.DataSource = KhachHang.All().Select(khach => khach.TenNganHang).Distinct().ToList();
		}
#endregion
	}
}
