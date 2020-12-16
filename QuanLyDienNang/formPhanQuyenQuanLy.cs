using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class formPhanQuyenQuanLy : Form
	{
		public formPhanQuyenQuanLy()
		{
			InitializeComponent();
		}
		DataTable tb_tba;
		private void Phanquyen_Load(object sender, EventArgs e)
		{
			tb_matram.Enabled = false;
			btn_boqua.Enabled = false;
			btn_Lưu.Enabled = false;
			btn_sua.Enabled = false;
			btn_xoa.Enabled = false;
			LoadDataGriview();


		}
		private void LoadDataGriview()
		{
			string sql;
			sql = "SELECT sott,Matram,tentram,congtotong,ten_Cb FROM trambienap";
			tb_tba = Functions.GetDataToTable(sql);
			dtg_tram.DataSource = tb_tba;
			dtg_tram.AllowUserToAddRows = false;  // không cho người dùng thêm dữ liệu trực tiếp vào gridview
			dtg_tram.EditMode = DataGridViewEditMode.EditProgrammatically; // ko cho sửa vào gridview
		}

		private void dtg_tram_Click(object sender, EventArgs e)
		{
			if (btn_them.Enabled == false)
			{
				MessageBox.Show("Đang Ở Chế Độ Thêm Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_cb.Text = "";
				tb_cb.Focus();
				tb_tram.Text = "";
				tb_tram.Focus();
				tb_congtotong.Text = "";
				tb_congtotong.Focus();


				return;
			}
			if (tb_tba.Rows.Count == 0)
			{
				MessageBox.Show("Không Có dữ Liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			tb_cb.Text = dtg_tram.CurrentRow.Cells["ten_cb"].Value.ToString();  // đưa dữ liệu lên textbox
			tb_tram.Text = dtg_tram.CurrentRow.Cells["tentram"].Value.ToString();// đưa dữ liệu lên textbox
			tb_congtotong.Text = dtg_tram.CurrentRow.Cells["congtotong"].Value.ToString();// đưa dữ liệu lên textbox
			tb_matram.Text = dtg_tram.CurrentRow.Cells["Matram"].Value.ToString();// đưa dữ liệu lên textbox
			btn_boqua.Enabled = true;
			btn_sua.Enabled = true;
			btn_xoa.Enabled = true;
			btn_Lưu.Enabled = true;

		}

		private void btn_them_Click(object sender, EventArgs e)
		{
			btn_sua.Enabled = false;
			btn_them.Enabled = false;
			btn_xoa.Enabled = false;
			btn_Lưu.Enabled = true;
			btn_boqua.Enabled = true;
			resetvalue();
		}
		private void resetvalue()
		{
			tb_cb.Text = "";
			tb_tram.Text = "";
			tb_congtotong.Text = "";


		}

		private void btn_Lưu_Click(object sender, EventArgs e)
		{
			string sql;
			if (tb_cb.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn Chưa Nhập Tên Cán Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_cb.Focus();
			}
			if (tb_tram.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn Chưa Nhập Tên trạm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_cb.Focus();
			}
			if (tb_congtotong.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn Chưa Nhập công tơ tổng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_cb.Focus();
			}
			sql = "select tentram from trambienap where tentram = N'" + tb_tram.Text.Trim() + "'";
			if (Functions.CheckKey(sql))
			{
				MessageBox.Show("Trạm đã có hãy nhập tên trạm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_tram.Focus();
				return;
			}
			sql = "insert into trambienap (ten_cb,tentram,congtotong) values (N'" + tb_cb.Text + "',N'" + tb_tram.Text + "',N'" + tb_congtotong.Text + "') ";
			Functions.RunSQL(sql);
			LoadDataGriview();
			resetvalue();
			btn_them.Enabled = true;


		}

		private void btn_sua_Click(object sender, EventArgs e)
		{
			string sql;
			if (tb_tba.Rows.Count == 0)
			{
				MessageBox.Show("Không Còn Dữ Liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (tb_cb.Text.Trim().Length == 0)
			{
				MessageBox.Show("Hãy nhập tên cán bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			if (tb_tram.Text.Trim().Length == 0)
			{
				MessageBox.Show("Hãy nhập tên trạm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			if (tb_congtotong.Text.Trim().Length == 0)
			{
				MessageBox.Show("Hãy nhập tên Trạm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			sql = "update trambienap set ten_cb =N'" + tb_cb.Text.ToString() + "',tentram = N'" + tb_tram.Text.ToString() + "',congtotong = N'" + tb_congtotong.Text.ToString() + "' where Matram = '" + tb_matram.Text + "' ";
			Functions.RunSQL(sql);
			LoadDataGriview();
			resetvalue();
			Phanquyen_Load(sender, e);

		}

		private void btn_xoa_Click(object sender, EventArgs e)
		{
			string sql;
			if (tb_tba.Rows.Count == 0)
			{
				MessageBox.Show("Hết dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (tb_cb.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show("Bạn chắc Chắn muốn Xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				sql = "delete trambienap where Matram = '" + tb_matram.Text + "'";
				Functions.RunSQL(sql);
				LoadDataGriview();
				resetvalue();

			}

		}

		private void btn_boqua_Click(object sender, EventArgs e)
		{
			resetvalue();
			Phanquyen_Load(sender, e);

		}

		private void btn_dong_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tb_cb_KeyUp(object sender, KeyEventArgs e)
		{



		}


	}
}
