using Business.Classes;
using Business.Helper;
using System;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_NguoiQuanLy : Form
	{
		public Form_NguoiQuanLy()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_NguoiQuanLy_Shown(object sender, EventArgs e)
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
			if (Common.IsNullOrWhiteSpace(ten, dc))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (Common.ShowQuestionDialog())
			{
				var ok = NguoiQuanLy.Insert(new NguoiQuanLy()
				{
					TenQuanLy = ten,
					SoDienThoai = sdt,
					DiaChi = dc,
					Email = email
				});
				if (ok)
				{
					MessageBox.Show(STRINGS.SUCCESS_INSERT_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadTable();
				}
				else
				{
					MessageBox.Show(STRINGS.ERROR_INSERT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnCapNhat_Click(object sender, System.EventArgs e)
		{
			string ma = tbxMaNQL.Text;
			string ten = tbxTenNQL.Text;
			string sdt = tbxSoDT.Text;
			string dc = tbxDiaChi.Text;
			string email = tbxEmail.Text;
			if (Common.IsNullOrWhiteSpace(ten, dc))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (Common.ShowQuestionDialog())
			{
				var ok = NguoiQuanLy.Update(new NguoiQuanLy()
				{
					MaQuanLy = ma,
					TenQuanLy = ten,
					SoDienThoai = sdt,
					DiaChi = dc,
					Email = email
				});
				if (ok)
				{
					MessageBox.Show(STRINGS.SUCCESS_UPDATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadTable();
				}
				else
				{
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public void btnXoa_Click(object sender, System.EventArgs e)
		{
			string ma = tbxMaNQL.Text;
			if (Common.ShowQuestionDialog())
			{
				var ok = NguoiQuanLy.Delete(ma);
				if (ok)
				{
					MessageBox.Show(STRINGS.SUCCESS_DELETE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadTable();
				}
				else
				{
					MessageBox.Show(STRINGS.ERROR_DELETE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvNguoiQuanLy.ClearSelection();
			dgvNguoiQuanLy.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvNguoiQuanLy.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvNguoiQuanLy.SelectedRows[0].Index;
			if (index < dgvNguoiQuanLy.Rows.Count - 1)
			{
				index++;
				GoToIndex(index);
			}
		}

		public void GoToFirst()
		{
			GoToIndex(0);
		}

		public void GoToEnd()
		{
			GoToIndex(dgvNguoiQuanLy.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvNguoiQuanLy.SelectedRows.Count > 0)
			{
				var row = dgvNguoiQuanLy.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				builder.Append(row.Cells[0].Value.ToString() + '\t');
				builder.Append(row.Cells[1].Value.ToString() + '\t');
				builder.Append(row.Cells[2].Value.ToString() + '\t');
				builder.Append(row.Cells[3].Value.ToString() + '\t');
				builder.Append(row.Cells[4].Value.ToString() + '\t');
				return builder.ToString();
			}
			return string.Empty;
		}

		private void LoadTable()
		{
			var data = NguoiQuanLy.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvNguoiQuanLy.DataSource = data;
		}
		#endregion

	}
}
