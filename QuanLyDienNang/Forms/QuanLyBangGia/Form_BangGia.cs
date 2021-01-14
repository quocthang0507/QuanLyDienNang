using Business.Classes;
using Business.Forms;
using Business.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_BangGia : Form
	{
		private readonly Funcs_BangGia funcs = new Funcs_BangGia();

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
			string thue = tbxThue.Text;
			if (Common.IsNullOrWhiteSpace(maBangGia, tenBangGia, thue))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (BangGia.IsDuplicatedMaBangGia(maBangGia))
			{
				MessageBox.Show(STRINGS.WARNING_DUPLICATE_MABANGGIA, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (Common.ShowQuestionDialog())
			{
				bool ok = BangGia.Insert(new BangGia()
				{
					MaBangGia = maBangGia,
					TenBangGia = tenBangGia,
					Thue = decimal.Parse(tbxThue.Text),
					ApGia = chkApGia.Checked
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

		private void btnXemChiTiet_Click(object sender, EventArgs e)
		{
			BangGia selected = (BangGia)dgvBangGia.SelectedRows[0].DataBoundItem;
			if (!selected.ApGia)
			{
				Form frmChiTiet = new Form_ChiTietBangGia(selected);
				Form_Main.Instance.AddFormToTabPage(frmChiTiet);
			}
			else
			{
				MessageBox.Show(STRINGS.WARNING_NO_APPLY_PERCENT_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void dgvBangGia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int changedRowIndex = e.RowIndex;
			DataGridViewRow changedRow = dgvBangGia.Rows[changedRowIndex];
			string maBangGia = changedRow.Cells[0].Value.ToString();
			string tenBangGia = changedRow.Cells[1].Value.ToString();
			string thue = changedRow.Cells[2].Value.ToString();
			bool apGia = (bool)changedRow.Cells[3].Value;
			bool kichHoat = (bool)changedRow.Cells[4].Value;
			if (Common.IsNullOrWhiteSpace(maBangGia, tenBangGia, thue))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = BangGia.Update(new BangGia()
				{
					MaBangGia = maBangGia,
					TenBangGia = tenBangGia,
					Thue = decimal.Parse(thue),
					ApGia = apGia,
					KichHoat = kichHoat
				});
				if (!ok)
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void tbxThue_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDecimalEvent(ref e, sender);
		}

		private void dgvBangGia_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(STRINGS.ERROR_COMMIT_DATAGRIDVIEW_MESSAGE + e.Context.ToString(), STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void dgvBangGia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvBangGia.AutoResizeColumns();
		}

		private void btnXemApGia_Click(object sender, EventArgs e)
		{
			DataGridViewRow selectedRow = dgvBangGia.SelectedRows[0];
			BangGia bangGia = selectedRow.DataBoundItem as BangGia;
			if (bangGia.ApGia)
			{
				Form frmBangDienApGia = new Form_BangDienApGia(bangGia);
				Form_Main.Instance.AddFormToTabPage(frmBangDienApGia);
			}
			else
			{
				MessageBox.Show(STRINGS.WARNING_NO_PERCENT_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
			int index = dgvBangGia.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvBangGia.SelectedRows[0].Index;
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
				DataGridViewRow row = dgvBangGia.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				foreach (DataGridViewCell cell in row.Cells)
				{
					builder.Append(cell.Value.ToString() + '\t');
				}
				return builder.ToString();
			}
			return string.Empty;
		}

		public void ExportToExcel()
		{
			byte[] bytes = Excel.ExportToExcel(dgvBangGia.DataSource, "Danh sách Bảng giá");
			if (bytes == null)
			{
				MessageBox.Show(STRINGS.ERROR_EXPORT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DialogResult dialog = saveDialog.ShowDialog();
			if (dialog == DialogResult.OK)
			{
				string filepath = saveDialog.FileName;
				FileStream stream = File.Create(filepath);
				stream.Close();
				File.WriteAllBytes(filepath, bytes);
				MessageBox.Show(STRINGS.SUCCESS_EXPORT_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
				Process.Start(Directory.GetParent(filepath).FullName);
			}
		}

		private void LoadTable()
		{
			List<BangGia> data = BangGia.GetAll();
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
