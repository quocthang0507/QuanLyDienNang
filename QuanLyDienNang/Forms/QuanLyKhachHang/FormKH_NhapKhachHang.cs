using Business.Classes;
using Business.Forms;
using Business.Helper;
using KGySoft.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class FormKH_NhapKhachHang : Form
	{
		private readonly Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_NhapKhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_NhapKhachHang_Shown(object sender, EventArgs e)
		{
			tbxDuongDan.Text = funcs.GetSavedExcelPathForImporting();
			LoadNguoiQuanLy();
			LoadSheet(tbxDuongDan.Text);
		}

		private void btnChonTapTin_Click(object sender, System.EventArgs e)
		{
			DialogResult result = openDialog.ShowDialog();
			if (result != DialogResult.OK || Common.IsNullOrWhiteSpace(openDialog.FileName))
			{
				return;
			}

			string path = openDialog.FileName;
			tbxDuongDan.Text = path;
			funcs.SaveExcelPathForImporting(path);
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
						  MessageBox.Show(STRINGS.WARNING_MISS_FILE_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						  return;
					  }
					  SortableBindingList<KhachHang> data = funcs.ReadExcelForInserting(tbxDuongDan.Text, cbxSheet.Text);
					  if (data == null)
					  {
						  MessageBox.Show(STRINGS.ERROR_IMPORT_EXCEL, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
					  }
					  else
					  {
						  dgvKhachHang.DataSource = data;
					  }
				  });
			  });
			thread.Start();
		}

		private void btnLuuCSDL_Click(object sender, System.EventArgs e)
		{
			if (dgvKhachHang.DataSource == null)
			{
				MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string maQL = (cbxNguoiNhap.SelectedItem as NguoiQuanLy).MaQuanLy;
			SortableBindingList<KhachHang> data = funcs.UpdateListForInserting(dgvKhachHang.DataSource as SortableBindingList<KhachHang>, maQL);
			bool ok = funcs.TryInsertingDataTableToSQL(data);
			if (ok)
			{
				funcs.InsertSQL(data);
				dgvKhachHang.DataSource = KhachHang.GetAll();
				MessageBox.Show(STRINGS.SUCCESS_INSERT_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(STRINGS.ERROR_INSERT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXemMau_Click(object sender, System.EventArgs e)
		{
			string filepath = AppDomain.CurrentDomain.BaseDirectory + STRINGS.SAMPLE_PATH;
			if (File.Exists(filepath))
			{
				Process.Start(filepath);
			}
			else
			{
				MessageBox.Show(STRINGS.ERROR_NOT_FOUND_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvKhachHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvKhachHang.AutoResizeColumns();
		}
		#endregion

		#region Methods
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

		public void ExportToExcel()
		{
			// Nothing to do
		}

		private void LoadSheet(string path)
		{
			if (!Common.IsNullOrWhiteSpace(path))
			{
				SortableBindingList<string> data = funcs.GetSheetNamesOnExcel(path);
				if (data == null)
				{
					MessageBox.Show(STRINGS.ERROR_IMPORT_EXCEL, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					cbxSheet.DataSource = data;
				}
			}
		}

		private void LoadNguoiQuanLy()
		{
			SortableBindingList<NguoiQuanLy> data = NguoiQuanLy.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				cbxNguoiNhap.DataSource = data;
			}
		}

		#endregion

	}
}
