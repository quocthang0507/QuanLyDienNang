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
			string maQuanLy = changedRow.Cells[nameof(NguoiQuanLy.MaQuanLy)].Value.ToString();
			string tenQuanLy = changedRow.Cells[nameof(NguoiQuanLy.TenQuanLy)].Value.ToString();
			string soDienThoai = changedRow.Cells[nameof(NguoiQuanLy.SoDienThoai)].Value.ToString();
			string diaChi = changedRow.Cells[nameof(NguoiQuanLy.DiaChi)].Value.ToString();
			string email = changedRow.Cells[nameof(NguoiQuanLy.Email)].Value.ToString();
			bool kichHoat = (bool)changedRow.Cells[nameof(NguoiQuanLy.KichHoat)].Value;
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
					Email = email,
					KichHoat = kichHoat
				});
				if (!ok)
				{
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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
			byte[] bytes = Excel.ExportToExcel(dgvNguoiQuanLy.DataSource, "Danh sách Người quản lý");
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
			SortableBindingList<NguoiQuanLy> data = NguoiQuanLy.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				dgvNguoiQuanLy.DataSource = data;
			}
		}

		private void UpdateColumnFormat()
		{
			dgvNguoiQuanLy.Columns[0].ReadOnly = true;
			dgvNguoiQuanLy.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion

	}
}
