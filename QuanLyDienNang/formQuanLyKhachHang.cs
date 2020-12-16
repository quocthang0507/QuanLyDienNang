using QuanLyDienNang.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormQuanLyKhachHang : Form
	{
		public FormQuanLyKhachHang()
		{
			InitializeComponent();
		}

		private void formQuanLyKhachHang_Load(object sender, EventArgs e)
		{
			btn_them.Enabled = true;
			btn_sua.Enabled = false;
			btn_chitiet.Enabled = false;
			btn_xoa.Enabled = false;
			btn_thoat.Enabled = true;
			tb_makh.Enabled = false;
			LoadDataGridView();
		}

		private void LoadDataGridView()
		{
			try
			{
				string query = "select * from QuanLyKhachHang ORDER BY SoTT ASC ";
				Common sql = new Common();
				var table = sql.ExecuteQuery(query);
				if (table == null)
					throw new Exception();
				dtg_kh.DataSource = table;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi lấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void dtg_kh_Click(object sender, EventArgs e)
		{
			tb_makh.Text = dtg_kh.CurrentRow.Cells["ma_kh"].Value.ToString();
			btn_sua.Enabled = true;
			btn_xoa.Enabled = true;
			//    btn_huy.Enabled = true;
			btn_chitiet.Enabled = true;

		}

		private void btn_sua_Click(object sender, EventArgs e)
		{
			//  this.Close();
			FormThongTinKhachHang fgm = new FormThongTinKhachHang(tb_makh.Text);
			if (fgm.ShowDialog() == DialogResult.Cancel)
			{
				LoadDataGridView();
			}
		}

		private void btn_them_Click(object sender, EventArgs e)
		{
			//  this.Close();
			FormThongTinKhachHang frm = new formThongTinKhachHang(i);
			if (frm.ShowDialog() == DialogResult.Cancel)
			{
				LoadDataGridView();
			}
			//  frm.ShowDialog();
		}
		private void btn_chitiet_Click(object sender, EventArgs e)
		{
			con.Open();
			this.Close();
			SqlDataAdapter da = new SqlDataAdapter("select *from khachhang", con);
			FormThongTinKhachHang frm = new FormThongTinKhachHang(tb_makh.Text);
			frm.ShowDialog();

		}

		private void btn_xoa_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				con.Open();
				SqlCommand cdf = new SqlCommand("delete from quanlykhachhang where ma_kh='" + tb_makh.Text + "' ", con);
				if (cdf.ExecuteNonQuery() > 0)
					MessageBox.Show("thành công");
				else
					MessageBox.Show("lỗi");

				con.Close();
				LoadDataGridView();
			}

		}

		private void buttonX2_Click(object sender, EventArgs e)
		{
			LoadDataGridView();
		}

		private void buttonX1_Click(object sender, EventArgs e)
		{
			Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
			Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
			Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
			worksheet = workbook.Sheets["Sheet1"];
			worksheet = workbook.ActiveSheet;
			app.Visible = true;
			worksheet.Cells[1, 3] = "Quản Lý Khách Hàng Điện";
			worksheet.Cells[3, 1] = "Số Thứ Tự";
			worksheet.Cells[3, 2] = "Mã Khách Hàng";
			worksheet.Cells[3, 3] = "Tên Khách Hàng";
			worksheet.Cells[3, 4] = "Địa Chỉ";
			worksheet.Cells[3, 5] = "Tên Trạm";
			worksheet.Cells[3, 6] = "Số Hộ";
			worksheet.Cells[3, 7] = "Bảng Giá ";
			worksheet.Cells[3, 8] = "Mã Số Thuế";
			worksheet.Cells[3, 9] = "Số Điện Thoại";
			worksheet.Cells[3, 10] = "Zalo";
			worksheet.Cells[3, 11] = "Email";
			worksheet.Cells[3, 12] = "Số Hợp Đồng";
			worksheet.Cells[3, 13] = "Số Công Tơ";
			worksheet.Cells[3, 14] = "Chỉ Số Đầu";
			worksheet.Cells[3, 15] = "Chỉ Số Cuối";
			worksheet.Cells[3, 16] = "Điện Tiêu Thụ";
			worksheet.Cells[3, 17] = "Thành Tiền";
			worksheet.Cells[3, 18] = "Thuế";
			worksheet.Cells[3, 19] = "Nợ";
			worksheet.Cells[3, 20] = "Tháng";
			for (int i = 0; i < dtg_kh.RowCount - 1; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					worksheet.Cells[i + 4, j + 1] = dtg_kh.Rows[i].Cells[j].Value;


				}


			}
		}

		private void tb_timkiem_TextChanged(object sender, EventArgs e)
		{
			dtg_kh.DataSource = dt.quanlykhachhangs.Where(x => x.ten_kh.Contains(tb_timkiem.Text)).ToList();


		}

		private void Quanlykhachhang_Enter(object sender, EventArgs e)
		{
			LoadDataGridView();
		}
	}
}
