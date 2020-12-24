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
			dgvNguoiQuanLy.DataSource = funcs.LoadTable();
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
	}
}
