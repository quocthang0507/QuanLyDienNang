using Business.Classes;
using Business.Forms;
using Business.Helper;
using KGySoft.ComponentModel;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_KhachHang : Form
	{
		private readonly Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public Form_KhachHang()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_KhachHang_Shown(object sender, EventArgs e)
		{
			dgvKhachHang.AutoSizeColumnsMode = Form_Main.Instance.ColumnSizeMode;
			tbxDuongDan.Text = funcs.GetSavedExcelPathForImporting();
			LoadNguoiQuanLy();
			LoadSheet(tbxDuongDan.Text);
		}

		private void dgvKhachHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(STRINGS.ERROR_COMMIT_DATAGRIDVIEW_MESSAGE + e.Context.ToString(), STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void dgvKhachHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			UpdateColumnFormat();
		}

		private void btnChonTapTin_Click(object sender, EventArgs e)
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

		private void btnLoadNoiDung_Click(object sender, EventArgs e)
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

		private void btnLayDanhSach_Click(object sender, EventArgs e)
		{
			SortableBindingList<KhachHang> data = KhachHang.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				//dgvKhachHang.DataSource = data;
				funcs.PopulateDataGridView(ref dgvKhachHang, data);
			}
		}

		private void btnXemMau_Click(object sender, EventArgs e)
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

		private void btnLuuCSDL_Click(object sender, EventArgs e)
		{
			if (dgvKhachHang.DataSource == null)
			{
				MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (Common.ShowQuestionDialog())
			{
				string maQuanLy = (cbxNguoiThucHien.SelectedItem as NguoiQuanLy).MaQuanLy;
				SortableBindingList<KhachHang> data = funcs.UpdateListForInserting(dgvKhachHang.DataSource as SortableBindingList<KhachHang>, maQuanLy);
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
		}

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			if (dgvKhachHang.DataSource == null)
			{
				MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (Common.ShowQuestionDialog())
			{
				string maQuanLy = (cbxNguoiThucHien.SelectedItem as NguoiQuanLy).MaQuanLy;
				SortableBindingList<KhachHang> data = funcs.ConvertDataSource(dgvKhachHang, maQuanLy);
				//SortableBindingList<KhachHang> data = funcs.UpdateListForUpdating(list, maQuanLy);
				bool ok = funcs.TryUpdatingDataTableToSQL(data);
				if (ok)
				{
					funcs.UpdateSQL(dgvKhachHang.DataSource as SortableBindingList<KhachHang>);
					MessageBox.Show(STRINGS.SUCCESS_UPDATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{

		}

		private void btnXoa_Click(object sender, EventArgs e)
		{

		}
		#endregion

		#region Methods
		public void UpdateColumnSizeMode()
		{
			dgvKhachHang.AutoSizeColumnsMode = Form_Main.Instance.ColumnSizeMode;
			dgvKhachHang.Refresh();
			dgvKhachHang.Update();
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

		public void ExportToExcel()
		{
			Form_Main frmMain = Form_Main.Instance;
			frmMain.xuấtThôngTinToolStripMenuItem_Click(this, null);
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
				cbxNguoiThucHien.DataSource = data;
				cbxNguoiThucHien.DisplayMember = nameof(NguoiQuanLy.TenQuanLy);
				cbxNguoiThucHien.ValueMember = nameof(NguoiQuanLy.TenQuanLy);
			}
		}

		private void LoadSheet(string path)
		{
			SortableBindingList<string> data = funcs.GetSheetNamesOnExcel(path);
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_IMPORT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				cbxSheet.DataSource = data;
			}
		}

		private void UpdateColumnFormat()
		{
			dgvKhachHang.Columns[0].ReadOnly = true;
			dgvKhachHang.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion

	}
}
