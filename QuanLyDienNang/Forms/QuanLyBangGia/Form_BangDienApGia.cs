using Business.Classes;
using Business.Helper;
using Business.Tables;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_BangDienApGia : Form
	{
		private readonly BangGia bangGia;

		public Form_BangDienApGia(BangGia bangGia)
		{
			InitializeComponent();
			this.bangGia = bangGia;
			lblTitle.Text = "BẢNG ĐIỆN ÁP GIÁ " + bangGia.TenBangGia.ToUpper();
		}

		#region Events
		private void Form_BangDienApGia_Shown(object sender, System.EventArgs e)
		{
			LoadTable();
			UpdateColumnFormat();
		}

		private void dgvBangDienApGia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvBangDienApGia.AutoResizeColumns();
		}

		private void dgvBangDienApGia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int changedRowIndex = e.RowIndex;
			DataGridViewRow changedRow = dgvBangDienApGia.Rows[changedRowIndex];
			string maApGia = changedRow.Cells[nameof(BangDienApGia.MaApGia)].Value.ToString();
			string maBangGia = changedRow.Cells[nameof(BangDienApGia.MaBangGia)].Value.ToString();
			string tyLe = changedRow.Cells[nameof(BangDienApGia.TyLe)].Value.ToString();
			bool kichHoat = (bool)changedRow.Cells[nameof(BangDienApGia.KichHoat)].Value;
			if (Common.IsNullOrWhiteSpace(tyLe))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = BangDienApGia.Update(new BangDienApGia()
				{
					MaApGia = maApGia,
					MaBangGia = maBangGia,
					TyLe = decimal.Parse(tyLe),
					KichHoat = kichHoat
				});
				if (!ok)
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvBangDienApGia_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(STRINGS.ERROR_COMMIT_DATAGRIDVIEW_MESSAGE + e.Context.ToString(), STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvBangDienApGia.ClearSelection();
			dgvBangDienApGia.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			int index = dgvBangDienApGia.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvBangDienApGia.SelectedRows[0].Index;
			if (index < dgvBangDienApGia.Rows.Count - 1)
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
			GoToIndex(dgvBangDienApGia.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvBangDienApGia.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvBangDienApGia.SelectedRows[0];
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
			byte[] bytes = Excel.ExportToExcel(dgvBangDienApGia.DataSource, "Danh sách Bảng áp giá");
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
			BangDienApGia.Create(bangGia.MaBangGia);
			List<BangDienApGia> data = BangDienApGia.GetAll(bangGia.MaBangGia);
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvBangDienApGia.DataSource = data;
		}

		private void UpdateColumnFormat()
		{
			dgvBangDienApGia.Columns[0].ReadOnly = true;
			dgvBangDienApGia.Columns[1].ReadOnly = true;
			dgvBangDienApGia.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
			dgvBangDienApGia.Columns[1].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion
	}
}
