using Business.Classes;
using Business.Forms;
using Business.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class FormKH_CapNhatKhachHang : Form
	{
		private readonly Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_CapNhatKhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_CapNhatKhachHang_Shown(object sender, EventArgs e)
		{
			LoadNguoiQuanLy();
		}

		private void btnChonTapTin_Click(object sender, EventArgs e)
		{
			DialogResult result = openDialog.ShowDialog();
			if (result != DialogResult.OK || Common.IsNullOrWhiteSpace(openDialog.FileName))
				return;
			string path = openDialog.FileName;
			tbxDuongDan.Text = path;
			LoadSheet(path);
		}

		private void btnLoadNoiDung_Click(object sender, System.EventArgs e)
		{
			thread = new Thread(() =>
			{
				dgvKhachHang.Invoke((MethodInvoker)delegate
				{
					if (Common.IsNullOrWhiteSpace(tbxDuongDan.Text))
					{
						MessageBox.Show(STRINGS.WARNING_MISS_PATH_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					List<KhachHang> data = funcs.ReadExcelForUpdating(tbxDuongDan.Text, cbxSheet.Text);
					if (data == null)
						MessageBox.Show(STRINGS.ERROR_IMPORT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
						dgvKhachHang.DataSource = data;
				});
			});
			thread.Start();
		}

		private void btnCapNhat_Click(object sender, System.EventArgs e)
		{
			if (dgvKhachHang.DataSource == null)
			{
				MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string maQL = (cbxNguoiCapNhat.SelectedItem as NguoiQuanLy).MaQuanLy;
			List<KhachHang> data = funcs.UpdateListForUpdating(dgvKhachHang.DataSource as List<KhachHang>, maQL);
			bool ok = funcs.TryUpdatingDataTableToSQL(data);
			if (ok)
			{
				funcs.UpdateSQL(dgvKhachHang.DataSource as List<KhachHang>);
				MessageBox.Show(STRINGS.SUCCESS_UPDATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvKhachHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvKhachHang.AutoResizeColumns();
		}
		#endregion

		#region Methods
		private void LoadSheet(string path)
		{
			List<string> data = funcs.GetSheetNamesOnExcel(path);
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_IMPORT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxSheet.DataSource = data;
		}

		private void LoadNguoiQuanLy()
		{
			List<NguoiQuanLy> data = NguoiQuanLy.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxNguoiCapNhat.DataSource = data;
		}

		public void GoToIndex(int index)
		{
			dgvKhachHang.ClearSelection();
			dgvKhachHang.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			int index = dgvKhachHang.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvKhachHang.SelectedRows[0].Index;
			if (index < dgvKhachHang.Rows.Count - 1)
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
			GoToIndex(dgvKhachHang.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvKhachHang.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvKhachHang.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < row.Cells.Count; i++)
				{
					builder.Append(row.Cells[i].Value.ToString() + '\t');
				}
				return builder.ToString();
			}
			return string.Empty;
		}

		#endregion

	}
}
