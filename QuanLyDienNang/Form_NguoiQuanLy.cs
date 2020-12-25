using Business.Classes;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class Form_NguoiQuanLy : Form
	{
		private Funcs_NguoiQuanLy funcs = new Funcs_NguoiQuanLy();

		public Form_NguoiQuanLy()
		{
			InitializeComponent();
		}

		private void Form_NguoiQuanLy_Load(object sender, System.EventArgs e)
		{
			LoadTable();
		}

		private void dgvNguoiQuanLy_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if (dgvNguoiQuanLy.SelectedRows.Count > 0)
			{
				var row = dgvNguoiQuanLy.SelectedRows[0];
				tbxMaNQL.Text = row.Cells[0].Value.ToString();
				tbxTenNQL.Text = row.Cells[1].Value.ToString();
				tbxSoDT.Text = row.Cells[2].Value.ToString();
				tbxDiaChi.Text = row.Cells[3].Value.ToString();
				tbxEmail.Text = row.Cells[4].Value.ToString();
			}
		}

		private void btnThem_Click(object sender, System.EventArgs e)
		{
			string ten = tbxTenNQL.Text;
			string sdt = tbxSoDT.Text;
			string dc = tbxDiaChi.Text;
			string email = tbxEmail.Text;
			if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(dc))
			{
				MessageBox.Show("Không được để trống các trường bắt buộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var ok = funcs.Insert(ten, sdt, dc, email);
			if (ok)
			{
				MessageBox.Show("Thêm dữ liệu mới vào thành công", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadTable();
			}
			else
			{
				MessageBox.Show("Thêm dữ liệu mới vào không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCapNhat_Click(object sender, System.EventArgs e)
		{
			string ma = tbxMaNQL.Text;
			string ten = tbxTenNQL.Text;
			string sdt = tbxSoDT.Text;
			string dc = tbxDiaChi.Text;
			string email = tbxEmail.Text;
			if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(dc))
			{
				MessageBox.Show("Không được để trống các trường bắt buộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var ok = funcs.Update(ma, ten, sdt, dc, email);
			if (ok)
			{
				MessageBox.Show("Cập nhật dữ liệu thành công", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadTable();
			}
			else
			{
				MessageBox.Show("Cập nhật dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXoa_Click(object sender, System.EventArgs e)
		{
			string ma = tbxMaNQL.Text;
			var ok = funcs.Delete(ma);
			if (ok)
			{
				MessageBox.Show("Xóa dữ liệu thành công", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadTable();
			}
			else
			{
				MessageBox.Show("Xóa dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void GoUp()
		{
			var index = dgvNguoiQuanLy.SelectedRows[0].Index;
			if (index > 0)
			{
				dgvNguoiQuanLy.ClearSelection();
				index--;
				dgvNguoiQuanLy.Rows[index].Selected = true;
			}
		}

		public void GoDown()
		{
			var index = dgvNguoiQuanLy.SelectedRows[0].Index;
			if (index < dgvNguoiQuanLy.Rows.Count - 1)
			{
				dgvNguoiQuanLy.ClearSelection();
				index++;
				dgvNguoiQuanLy.Rows[index].Selected = true;
			}
		}

		private void LoadTable()
		{
			var data = funcs.LoadTable();
			if (data == null)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dgvNguoiQuanLy.DataSource = data;
		}

	}
}
