using System;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class formThongTinDoanhNghiep : Form
	{
		public formThongTinDoanhNghiep()
		{
			InitializeComponent();
		}
		quanlydien_sqlDataContext ql = new quanlydien_sqlDataContext();

		private void tb_Tendn_TextChanged(object sender, EventArgs e)
		{

		}

		private void labelX2_Click(object sender, EventArgs e)
		{

		}

		private void textBoxX1_TextChanged(object sender, EventArgs e)
		{

		}

		private void labelX7_Click(object sender, EventArgs e)
		{

		}

		private void Thongtin_Load(object sender, EventArgs e)
		{
			tb_tk.DataBindings.Clear(); // xóa textbox
			tb_sodt.DataBindings.Clear();
			cb_nganhang.Text = "";
			tb_sodt.Text = "";
			tb_tk.Text = "";

			// TODO: This line of code loads data into the 'quanlydien_sqlDataSet.lienhe' table. You can move, or remove it, as needed.
			this.lienheTableAdapter.Fill(this.quanlydien_sqlDataSet.lienhe);
			// TODO: This line of code loads data into the 'quanlydien_sqlDataSet.thongtin' table. You can move, or remove it, as needed.
			this.thongtinTableAdapter.Fill(this.quanlydien_sqlDataSet.thongtin);


			//  xuất thông tin ngân hàng và số tk 
			cb_nganhang.DisplayMember = "nganhang";
			cb_nganhang.ValueMember = "so_tk";
			cb_nganhang.DataSource = ql.lienhe_selectall();  // xuất ra comboboxex
			tb_tk.DataBindings.Add("text", cb_nganhang.DataSource, "so_tk"); // xuất dữ liệu ra textbox
			tb_sodt.DataBindings.Add("text", cb_nganhang.DataSource, "so_dt");
		}

		private void cb_nganhang_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btn_luu_tt_Click(object sender, EventArgs e)
		{
			ql.thongtin_update(tb_Tendn.Text, tb_diachi.Text, tb_masothue.Text, tb_dkkd.Text, tb_nguoidaidien.Text, tb_chucvu.Text);
		}  // lưu lại thông tin doanh nghiệp

		private void btn_them_Click(object sender, EventArgs e)    //thêm mới
		{
			//cb_nganhang.Text = "";
			//cb_nganhang.Focus();
			//cb_nganhang.Enabled = true;
			//tb_tk.Text = "";
			//tb_tk.Focus();
			//tb_sodt.Text = "";
			//tb_sodt.Focus();
			//adl = true;
			ql.lienhe_insert(cb_nganhang.Text.Trim(), tb_tk.Text.Trim(), tb_sodt.Text.Trim());
			Thongtin_Load(sender, e);
		}

		private void btn_luu_tk_Click(object sender, EventArgs e)
		{

			ql.lienhe_update(cb_nganhang.Text, tb_tk.Text, tb_sodt.Text);
			Thongtin_Load(sender, e);
		}



		private void btn_xoa_Click(object sender, EventArgs e)
		{
			ql.lienhe_delete(cb_nganhang.Text);
			Thongtin_Load(sender, e);
		}

	}
}
