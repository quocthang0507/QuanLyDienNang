using Business.Classes;
using Business.Forms;
using Business.Helper;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_BangGia : Form
	{
		private Funcs_BangGia funcs = new Funcs_BangGia();

		public Form_BangGia()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_BangGia_Shown(object sender, EventArgs e)
		{
			LoadTable();
			UpdateColumnFormat();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			string maBangGia = tbxMaBangGia.Text;
			string tenBangGia = tbxTenBangGia.Text;
			if (string.IsNullOrWhiteSpace(maBangGia) || string.IsNullOrWhiteSpace(tenBangGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (BangGia.IsDuplicatedMaBangGia(maBangGia))
			{
				MessageBox.Show(STRINGS.WARNING_DUPLICATE_MABANGGIA, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (Common.ShowQuestionDialog())
			{
				var ok = BangGia.Insert(new BangGia()
				{
					MaBangGia = maBangGia,
					TenBangGia = tenBangGia,
					KichHoat = true
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

		private void btnXoa_Click(object sender, EventArgs e)
		{
			string maBangGia = tbxMaBangGia.Text;
			if (string.IsNullOrWhiteSpace(maBangGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = BangGia.Delete(maBangGia);
				if (ok)
				{
					MessageBox.Show(STRINGS.SUCCESS_DEACTIVATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadTable();
				}
				else
				{
					MessageBox.Show(STRINGS.ERROR_DEACTIVATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnXemChiTiet_Click(object sender, EventArgs e)
		{

		}

		private void dgvBangGia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			var changedRowIndex = e.RowIndex;
			var changedRow = dgvBangGia.Rows[changedRowIndex];
			string maBangGia = changedRow.Cells[0].Value.ToString();
			string tenBangGia = changedRow.Cells[1].Value.ToString();
			bool kichHoat = (bool)changedRow.Cells[2].Value;
			if (string.IsNullOrWhiteSpace(maBangGia) || string.IsNullOrWhiteSpace(tenBangGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				BangGia.Update(new BangGia()
				{
					MaBangGia = maBangGia,
					TenBangGia = tenBangGia,
					KichHoat = kichHoat
				});
			}

		}

		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvBangGia.ClearSelection();
			dgvBangGia.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvBangGia.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvBangGia.SelectedRows[0].Index;
			if (index < dgvBangGia.Rows.Count - 1)
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
			GoToIndex(dgvBangGia.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvBangGia.SelectedRows.Count > 0)
			{
				var row = dgvBangGia.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				builder.Append(row.Cells[0].Value.ToString() + '\t');
				builder.Append(row.Cells[1].Value.ToString() + '\t');
				builder.Append(row.Cells[2].Value.ToString() + '\t');
				return builder.ToString();
			}
			return string.Empty;
		}

		private void LoadTable()
		{
			var data = BangGia.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvBangGia.DataSource = data;
		}

		private void UpdateColumnFormat()
		{
			dgvBangGia.Columns[0].ReadOnly = true;
			dgvBangGia.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion

	}
}
