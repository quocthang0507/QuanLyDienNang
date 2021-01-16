using Business.Classes;
using Business.Helper;
using KGySoft.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_TramBienAp : Form
	{
		public Form_TramBienAp()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_TramBienAp_Shown(object sender, EventArgs e)
		{
			LoadTable();
			UpdateColumnFormat();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			string maTram = tbxMaTram.Text;
			string tenTram = tbxTenTram.Text;
			string diaChi = tbxDiaChi.Text;
			string nguoiPhuTrach = tbxNguoiPhuTrach.Text;
			string maSoCongTo = tbxMaSoCongTo.Text;
			if (Common.IsNullOrWhiteSpace(maTram, tenTram))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (TramBienAp.IsDuplicatedMaTram(maTram))
			{
				MessageBox.Show(STRINGS.WARNING_DUPLICATE_MATRAM, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (Common.ShowQuestionDialog())
			{
				bool ok = TramBienAp.Insert(new TramBienAp()
				{
					MaTram = maTram,
					TenTram = tenTram,
					DiaChi = diaChi,
					NguoiPhuTrach = nguoiPhuTrach,
					MaSoCongTo = maSoCongTo,
					HeSoNhan = (int)nudHeSoNhan.Value
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

		private void dgvTramBienAp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int changedRowIndex = e.RowIndex;
			DataGridViewRow changedRow = dgvTramBienAp.Rows[changedRowIndex];
			string maTram = changedRow.Cells[0].Value.ToString();
			string tenTram = changedRow.Cells[1].Value.ToString();
			string diaChi = changedRow.Cells[2].Value.ToString();
			string nguoiPhuTrach = changedRow.Cells[3].Value.ToString();
			string maSoCongTo = changedRow.Cells[4].Value.ToString();
			string heSoNhan = changedRow.Cells[5].Value.ToString();
			bool kichHoat = (bool)changedRow.Cells[6].Value;
			if (Common.IsNullOrWhiteSpace(maTram, tenTram, heSoNhan))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = TramBienAp.Update(new TramBienAp()
				{
					MaTram = maTram,
					TenTram = tenTram,
					DiaChi = diaChi,
					NguoiPhuTrach = nguoiPhuTrach,
					MaSoCongTo = maSoCongTo,
					HeSoNhan = int.Parse(heSoNhan),
					KichHoat = kichHoat
				});
				if (!ok)
				{
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void dgvTramBienAp_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(STRINGS.ERROR_COMMIT_DATAGRIDVIEW_MESSAGE + e.Context.ToString(), STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void dgvTramBienAp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvTramBienAp.AutoResizeColumns();
		}
		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvTramBienAp.ClearSelection();
			dgvTramBienAp.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			int index = dgvTramBienAp.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvTramBienAp.SelectedRows[0].Index;
			if (index < dgvTramBienAp.Rows.Count - 1)
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
			GoToIndex(dgvTramBienAp.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvTramBienAp.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvTramBienAp.SelectedRows[0];
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
			byte[] bytes = Excel.ExportToExcel(dgvTramBienAp.DataSource, "Danh sách Trạm biến áp");
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
			SortableBindingList<TramBienAp> data = TramBienAp.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				dgvTramBienAp.DataSource = data;
			}
		}

		private void UpdateColumnFormat()
		{
			dgvTramBienAp.Columns[0].ReadOnly = true;
			dgvTramBienAp.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion

	}
}
