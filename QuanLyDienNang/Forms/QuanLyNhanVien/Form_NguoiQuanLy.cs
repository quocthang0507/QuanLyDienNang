using Business.Classes;
using Business.Helper;
using System;
using System.Drawing;
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
			UpdateColumnFormat();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			string maQuanLy = tbxMaNQL.Text;
			string tenQuanLy = tbxTenNQL.Text;
			string soDienThoai = tbxSoDT.Text;
			string diaChi = tbxDiaChi.Text;
			string email = tbxEmail.Text;
			if (Common.IsNullOrWhiteSpace(maQuanLy, tenQuanLy, diaChi))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (Common.ShowQuestionDialog())
			{
				bool ok = NguoiQuanLy.Insert(new NguoiQuanLy()
				{
					MaQuanLy = maQuanLy,
					TenQuanLy = tenQuanLy,
					SoDienThoai = soDienThoai,
					DiaChi = diaChi,
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

		private void dgvNguoiQuanLy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int changedRowIndex = e.RowIndex;
			DataGridViewRow changedRow = dgvNguoiQuanLy.Rows[changedRowIndex];
			string maQuanLy = changedRow.Cells[0].Value.ToString();
			string tenQuanLy = changedRow.Cells[1].Value.ToString();
			string soDienThoai = changedRow.Cells[2].Value.ToString();
			string diaChi = changedRow.Cells[3].Value.ToString();
			string email = changedRow.Cells[4].Value.ToString();
			if (Common.IsNullOrWhiteSpace(maQuanLy, tenQuanLy, diaChi))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = NguoiQuanLy.Update(new NguoiQuanLy()
				{
					MaQuanLy = maQuanLy,
					TenQuanLy = tenQuanLy,
					SoDienThoai = soDienThoai,
					DiaChi = diaChi,
					Email = email
				});
				if (!ok)
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvNguoiQuanLy_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(STRINGS.ERROR_COMMIT_DATAGRIDVIEW_MESSAGE + e.Context.ToString(), STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void dgvNguoiQuanLy_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvNguoiQuanLy.AutoResizeColumns();
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
			int index = dgvNguoiQuanLy.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvNguoiQuanLy.SelectedRows[0].Index;
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
				DataGridViewRow row = dgvNguoiQuanLy.SelectedRows[0];
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
			System.Collections.Generic.List<NguoiQuanLy> data = NguoiQuanLy.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvNguoiQuanLy.DataSource = data;
		}

		private void UpdateColumnFormat()
		{
			dgvNguoiQuanLy.Columns[0].ReadOnly = true;
			dgvNguoiQuanLy.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion

	}
}
