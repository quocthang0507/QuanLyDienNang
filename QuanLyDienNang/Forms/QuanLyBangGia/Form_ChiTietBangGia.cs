using Business.Classes;
using Business.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_ChiTietBangGia : Form
	{
		private readonly BangGia bangGia;

		public Form_ChiTietBangGia(BangGia bangGia)
		{
			InitializeComponent();
			this.bangGia = bangGia;
			UpdateLabels();
		}

		#region Events
		private void Form_ChiTietBangGia_Shown(object sender, EventArgs e)
		{
			LoadTableByMaBangGia();
			UpdateColumnFormat();
		}

		private void tbxBatDau_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}

		private void tbxKetThuc_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}

		private void tbxDonGia_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			string maChiTiet = tbxMaChiTiet.Text;
			string maBangGia = tbxMaBangGia.Text;
			string moTa = tbxMoTa.Text;
			string donGia = tbxDonGia.Text;
			string batDau = tbxBatDau.Text;
			string ketThuc = tbxKetThuc.Text;
			if (Common.IsNullOrWhiteSpace(maChiTiet, maBangGia, batDau, ketThuc, donGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				ChiTietBangGia.Insert(new ChiTietBangGia()
				{
					MaChiTiet = maChiTiet,
					MaBangGia = maBangGia,
					MoTa = moTa,
					DonGia = int.Parse(donGia),
					BatDau = int.Parse(batDau),
					KetThuc = int.Parse(ketThuc)
				});
			}
		}

		private void dgvChiTietGia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int changedRowIndex = e.RowIndex;
			DataGridViewRow changedRow = dgvChiTietGia.Rows[changedRowIndex];
			string maChiTiet = changedRow.Cells[0].Value.ToString();
			string maBangGia = changedRow.Cells[1].Value.ToString();
			string batDau = changedRow.Cells[2].Value.ToString();
			string ketThuc = changedRow.Cells[3].Value.ToString();
			string donGia = changedRow.Cells[4].Value.ToString();
			string moTa = changedRow.Cells[5].Value.ToString();
			bool kichHoat = (bool)changedRow.Cells[6].Value;
			if (Common.IsNullOrWhiteSpace(maBangGia, batDau, ketThuc, donGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = ChiTietBangGia.Update(new ChiTietBangGia()
				{
					MaChiTiet = maChiTiet,
					MaBangGia = maBangGia,
					MoTa = moTa,
					DonGia = int.Parse(donGia),
					BatDau = int.Parse(batDau),
					KetThuc = int.Parse(ketThuc),
					KichHoat = kichHoat
				});
				if (!ok)
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvChiTietGia_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(STRINGS.ERROR_COMMIT_DATAGRIDVIEW_MESSAGE + e.Context.ToString(), STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void dgvChiTietGia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvChiTietGia.AutoResizeColumns();
		}

		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvChiTietGia.ClearSelection();
			dgvChiTietGia.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			int index = dgvChiTietGia.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvChiTietGia.SelectedRows[0].Index;
			if (index < dgvChiTietGia.Rows.Count - 1)
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
			GoToIndex(dgvChiTietGia.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvChiTietGia.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvChiTietGia.SelectedRows[0];
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
			byte[] bytes = Excel.ExportToExcel(dgvChiTietGia.DataSource, "Danh sách Chi tiết Bảng giá");
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

		private void LoadTableByMaBangGia()
		{
			List<ChiTietBangGia> data = ChiTietBangGia.GetByBangGia(bangGia.MaBangGia);
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvChiTietGia.DataSource = data;
		}

		private void UpdateLabels()
		{
			TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
			Text = "Chi Tiết Bảng Giá " + textInfo.ToTitleCase(bangGia.TenBangGia);
			lblTitle.Text = "CHI TIẾT BẢNG GIÁ " + bangGia.TenBangGia.ToUpper();
		}

		private void UpdateColumnFormat()
		{
			dgvChiTietGia.Columns[0].ReadOnly = true;
			dgvChiTietGia.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion
	}
}
