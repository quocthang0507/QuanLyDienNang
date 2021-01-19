using Business.Classes;
using Business.Forms;
using Business.Helper;
using KGySoft.ComponentModel;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
				PopulateDataGridView(data);
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
				SortableBindingList<KhachHang> data = ConvertDataSource(maQuanLy);
				//SortableBindingList<KhachHang> data = funcs.UpdateListForUpdating(list, maQuanLy);
				bool ok = funcs.TryUpdatingDataTableToSQL(data);
				if (ok)
				{
					funcs.UpdateSQL(data);
					MessageBox.Show(STRINGS.SUCCESS_UPDATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection selectedRows = dgvKhachHang.SelectedRows;
			foreach (DataGridViewRow row in selectedRows)
			{
				string maKhachHang = row.Cells[0].Value.ToString();
				KhachHang.Delete(maKhachHang);
			}
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

		private SortableBindingList<KhachHang> ConvertDataSource(string maQuanLy)
		{
			SortableBindingList<KhachHang> list = new SortableBindingList<KhachHang>();
			foreach (DataGridViewRow row in dgvKhachHang.Rows)
			{
				string maKhachHang = row.Cells[nameof(KhachHang.MaKhachHang)].Value.ToString();
				string hoVaTen = row.Cells[nameof(KhachHang.HoVaTen)].Value.ToString();
				string diaChi = row.Cells[nameof(KhachHang.DiaChi)].Value.ToString();
				string maBangGia = BangGia.GetByName(row.Cells[nameof(BangGia.TenBangGia)].Value.ToString()).MaBangGia;
				string maTram = TramBienAp.GetByName(row.Cells[nameof(TramBienAp.TenTram)].Value.ToString()).MaTram;
				string soHo = row.Cells[nameof(KhachHang.SoHo)].Value.ToString();
				string heSoNhan = row.Cells[nameof(KhachHang.HeSoNhan)].Value.ToString();
				string maSoThue = row.Cells[nameof(KhachHang.MaSoThue)].Value.ToString();
				string soDienThoai = row.Cells[nameof(KhachHang.SoDienThoai)].Value.ToString();
				string email = row.Cells[nameof(KhachHang.Email)].Value.ToString();
				string ngayTao = row.Cells[nameof(KhachHang.NgayTao)].Value.ToString();
				string nguoiTao = row.Cells[nameof(KhachHang.NguoiTao)].Value.ToString();
				string maSoHopDong = row.Cells[nameof(KhachHang.MaSoHopDong)].Value.ToString();
				string ngayHopDong = row.Cells[nameof(KhachHang.NgayHopDong)].Value.ToString();
				string maCongTo = row.Cells[nameof(KhachHang.MaCongTo)].Value.ToString();
				string soNganHang = row.Cells[nameof(KhachHang.SoNganHang)].Value.ToString();
				string tenNganHang = row.Cells[nameof(KhachHang.TenNganHang)].Value.ToString();
				bool kichHoat = (bool)row.Cells[nameof(KhachHang.KichHoat)].Value;
				KhachHang khachHang = new KhachHang()
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
					NguoiCapNhat = maQuanLy,
					MaSoHopDong = maSoHopDong,
					NgayHopDong = DateTime.Parse(ngayHopDong),
					MaCongTo = maCongTo,
					SoNganHang = soNganHang,
					TenNganHang = tenNganHang,
					KichHoat = kichHoat
				};
				list.Add(khachHang);
			}
			return list;
		}

		private void PopulateDataGridView(SortableBindingList<KhachHang> data)
		{
			// Xóa hết các cột nếu đã có trước
			dgvKhachHang.Columns.Clear();
			// Đổ dữ liệu vào
			dgvKhachHang.DataSource = data;
			dgvKhachHang.AllowUserToAddRows = false;
			// Khai báo cột có dạng comboBox
			DataGridViewComboBoxColumn cbxBangGia = new DataGridViewComboBoxColumn();
			DataGridViewComboBoxColumn cbxTram = new DataGridViewComboBoxColumn();
			// Gán thuộc tính
			cbxBangGia.HeaderText = DisplayNameHelper.GetDisplayName(typeof(BangGia), nameof(BangGia.TenBangGia));
			cbxTram.HeaderText = DisplayNameHelper.GetDisplayName(typeof(TramBienAp), nameof(TramBienAp.TenTram));
			cbxBangGia.Name = nameof(BangGia.TenBangGia);
			cbxTram.Name = nameof(TramBienAp.TenTram);
			// Lấy thứ tự của cột mã và thêm cột mới vào
			int iBangGia = dgvKhachHang.Columns[nameof(KhachHang.MaBangGia)].Index;
			dgvKhachHang.Columns.Insert(iBangGia, cbxBangGia);
			int iTram = dgvKhachHang.Columns[nameof(KhachHang.MaTram)].Index;
			dgvKhachHang.Columns.Insert(iTram, cbxTram);
			// Gán giá trị tương ứng của comboBox theo mã
			foreach (DataGridViewRow row in dgvKhachHang.Rows)
			{
				// Lấy ô comboBox
				DataGridViewComboBoxCell cbxBangGiaCell = (row.Cells[iBangGia] as DataGridViewComboBoxCell);
				DataGridViewComboBoxCell cbxTramCell = (row.Cells[iTram] as DataGridViewComboBoxCell);
				// Lấy danh sách các bảng ngoại
				SortableBindingList<BangGia> bangGias = BangGia.GetAll();
				SortableBindingList<TramBienAp> tramBienAps = TramBienAp.GetAll();
				// Đưa vào comboBox
				cbxBangGiaCell.DataSource = bangGias;
				cbxTramCell.DataSource = tramBienAps;
				// Đặt giá trị hiển thị
				cbxBangGiaCell.DisplayMember = nameof(BangGia.TenBangGia);
				cbxTramCell.DisplayMember = nameof(TramBienAp.TenTram);
				// Tìm khách hàng
				KhachHang khachHang = KhachHang.GetByID(row.Cells[0].Value.ToString());
				// Tìm tên tương ứng với mã
				cbxBangGiaCell.Value = bangGias.Where(bangGia => bangGia.MaBangGia.Equals(khachHang.MaBangGia)).First().TenBangGia;
				cbxTramCell.Value = tramBienAps.Where(tram => tram.MaTram.Equals(khachHang.MaTram)).First().TenTram;
			}
			// Bỏ cột mã đi
			dgvKhachHang.Columns.RemoveAt(++iBangGia);
			dgvKhachHang.Columns.RemoveAt(iTram);
		}
		#endregion

	}
}
