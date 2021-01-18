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
			string maQL = (cbxNguoiThucHien.SelectedItem as NguoiQuanLy).MaQuanLy;
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

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			if (dgvKhachHang.DataSource == null)
			{
				MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string maQL = (cbxNguoiThucHien.SelectedItem as NguoiQuanLy).MaQuanLy;
			SortableBindingList<KhachHang> data = funcs.UpdateListForUpdating(dgvKhachHang.DataSource as SortableBindingList<KhachHang>, maQL);
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

		private void btnThem_Click(object sender, EventArgs e)
		{

		}

		private void btnXoa_Click(object sender, EventArgs e)
		{

		}

		private void dgvKhachHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int changedRowIndex = e.RowIndex;
				DataGridViewRow changedRow = dgvKhachHang.Rows[changedRowIndex];
				string maKhachHang = changedRow.Cells[nameof(KhachHang.MaKhachHang)].Value.ToString();
				string hoVaTen = changedRow.Cells[nameof(KhachHang.HoVaTen)].Value.ToString();
				string diaChi = changedRow.Cells[nameof(KhachHang.DiaChi)].Value.ToString();
				string maBangGia = BangGia.GetByName(changedRow.Cells[nameof(BangGia.TenBangGia)].Value.ToString()).MaBangGia;
				string maTram = TramBienAp.GetByName(changedRow.Cells[nameof(TramBienAp.TenTram)].Value.ToString()).MaTram;
				string soHo = changedRow.Cells[nameof(KhachHang.SoHo)].Value.ToString();
				string heSoNhan = changedRow.Cells[nameof(KhachHang.HeSoNhan)].Value.ToString();
				string maSoThue = changedRow.Cells[nameof(KhachHang.MaSoThue)].Value.ToString();
				string soDienThoai = changedRow.Cells[nameof(KhachHang.SoDienThoai)].Value.ToString();
				string email = changedRow.Cells[nameof(KhachHang.Email)].Value.ToString();
				string ngayTao = changedRow.Cells[nameof(KhachHang.NgayTao)].Value.ToString();
				string nguoiTao = changedRow.Cells[nameof(KhachHang.NguoiTao)].Value.ToString();
				//string ngayCapNhat = changedRow.Cells[nameof(KhachHang.NgayCapNhat)].Value.ToString();
				string nguoiCapNhat = (cbxNguoiThucHien.SelectedItem as NguoiQuanLy).MaQuanLy;
				string maSoHopDong = changedRow.Cells[nameof(KhachHang.MaSoHopDong)].Value.ToString();
				string ngayHopDong = changedRow.Cells[nameof(KhachHang.NgayHopDong)].Value.ToString();
				string maCongTo = changedRow.Cells[nameof(KhachHang.MaCongTo)].Value.ToString();
				string soNganHang = changedRow.Cells[nameof(KhachHang.SoNganHang)].Value.ToString();
				string tenNganHang = changedRow.Cells[nameof(KhachHang.TenNganHang)].Value.ToString();
				bool kichHoat = (bool)changedRow.Cells[nameof(KhachHang.KichHoat)].Value;
				if (Common.IsNullOrWhiteSpace(maKhachHang, hoVaTen, diaChi, maBangGia, maTram, soHo, heSoNhan, ngayTao, nguoiTao, nguoiCapNhat))
				{
					MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					var ok = KhachHang.Update(new KhachHang()
					{
						MaKhachHang = maKhachHang,
						HoVaTen = hoVaTen,
						DiaChi = diaChi,
						MaBangGia = maBangGia,
						MaTram = maTram,
						SoHo = byte.Parse(soHo),
						HeSoNhan = byte.Parse(heSoNhan),
						MaSoThue = maSoThue,
						SoDienThoai = soDienThoai,
						Email = email,
						NgayTao = DateTime.Parse(ngayTao),
						NguoiTao = nguoiTao,
						NgayCapNhat = DateTime.Now,
						NguoiCapNhat = nguoiCapNhat,
						MaSoHopDong = maSoHopDong,
						NgayHopDong = DateTime.Parse(ngayHopDong),
						MaCongTo = maCongTo,
						SoNganHang = soNganHang,
						TenNganHang = tenNganHang,
						KichHoat = kichHoat
					});
					if (!ok)
					{
						MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception)
			{
				return;
				// Nothing to do, silence is gold
			}
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
