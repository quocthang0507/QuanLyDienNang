using Business.Classes;
using Business.Forms;
using Business.Helper;
using KGySoft.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_DienNangTieuThu : Form
	{
		private readonly Funcs_DienNangTieuThu funcs = new Funcs_DienNangTieuThu();
		private Thread thread;

		public Form_DienNangTieuThu()
		{
			InitializeComponent();
		}

		#region Events
		private void FormKH_DienNangTieuThu_Shown(object sender, EventArgs e)
		{
			UpdateControls();
			LoadTramBienAp();
			LoadBangGia();
			LoadNguoiQuanLy();
		}

		private void tbxSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}

		private void btnXuatTatCa_Click(object sender, EventArgs e)
		{
			SortableBindingList<DienNangTieuThu> data = DienNangTieuThu.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				dgvDienNangTieuThu.DataSource = data;
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			SortableBindingList<DienNangTieuThu> data = DienNangTieuThu.Filter(dtpBatDau_TK.Value, dtpKetThuc_TK.Value, (cbxTenTram.SelectedItem as TramBienAp).MaTram, tbxDiaChi.Text, (cbxBangGia.SelectedItem as BangGia).MaBangGia, chkConNo.Checked);
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				dgvDienNangTieuThu.DataSource = data;
			}
		}

		private void btnLapDanhSach_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show(STRINGS.QUESTION_LAPDANHSACH_MESSAGE, STRINGS.QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.No)
			{
				return;
			}

			SortableBindingList<DienNangTieuThu> data = funcs.AddNewDNTTFromKH((cbxNguoiQuanLy.SelectedItem as NguoiQuanLy).MaQuanLy, dtpDauKy.Value, dtpCuoiKy.Value);
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			bool ok = funcs.TryInsertingListToSQL(data);
			if (ok)
			{
				funcs.InsertSQL(data);
				//dgvDienNangTieuThu.DataSource = data;
				btnLoadTheoKy.PerformClick();
				MessageBox.Show(STRINGS.SUCCESS_UPDATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnLoadTheoKy_Click(object sender, EventArgs e)
		{
			SortableBindingList<DienNangTieuThu> data = DienNangTieuThu.GetByPeriod(dtpCuoiKy.Value);
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				dgvDienNangTieuThu.DataSource = data;
			}
		}

		private void btnXuatExcel_Click(object sender, EventArgs e)
		{
			byte[] bytes = Excel.ExportToExcel(dgvDienNangTieuThu.DataSource);
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

		private void dtpCuoiKy_ValueChanged(object sender, EventArgs e)
		{
			dtpDauKy.Value = dtpCuoiKy.Value.AddMonths(-1);
		}

		private void btnNhapExcel_Click(object sender, EventArgs e)
		{
			DialogResult result = openDialog.ShowDialog();
			if (result != DialogResult.OK || Common.IsNullOrWhiteSpace(openDialog.FileName))
			{
				return;
			}

			string path = openDialog.FileName;
			// Đọc sheet đầu tiên
			DataTable dt = Excel.ReadExcelAsDataTable(path, "");
			SortableBindingList<DienNangTieuThu> data = funcs.ConvertDataTableToListForUpdating(dt);
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_IMPORT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			funcs.UpdateSQL(data);
			//dgvDienNangTieuThu.DataSource = data;
			btnLoadTheoKy.PerformClick();
		}

		private void btnLapHoaDon_Click(object sender, EventArgs e)
		{
			thread = new Thread(() =>
			  {
				  dgvDienNangTieuThu.Invoke((MethodInvoker)delegate
				  {
					  if (dgvDienNangTieuThu.DataSource == null)
					  {
						  MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						  return;
					  }
					  Cursor.Current = Cursors.WaitCursor;
					  bool ok = DienNangTieuThu.UpdateMoney(dtpDauKy.Value, dtpCuoiKy.Value, (cbxNguoiQuanLy.SelectedItem as NguoiQuanLy).MaQuanLy);
					  if (!ok)
					  {
						  MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
						  return;
					  }
					  btnLoadTheoKy.PerformClick();
					  //DataTable dt = funcs.ConvertListToDataTableForReporting(dgvDienNangTieuThu.DataSource as List<DienNangTieuThu>);
					  //Form form = new Form_BaoCao(dt);
					  //form.ShowDialog();
					  Cursor.Current = Cursors.Default;
				  });
			  });
			thread.Start();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			if (dgvDienNangTieuThu.DataSource == null)
			{
				MessageBox.Show(STRINGS.WARNING_MISS_DGV_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string maQL = (cbxNguoiQuanLy.SelectedItem as NguoiQuanLy).MaQuanLy;
			SortableBindingList<DienNangTieuThu> data = funcs.UpdateListForUpdating(dgvDienNangTieuThu.DataSource as SortableBindingList<DienNangTieuThu>, maQL);
			bool ok = funcs.TryUpdatingListToSQL(data);
			if (ok)
			{
				funcs.UpdateSQL(dgvDienNangTieuThu.DataSource as SortableBindingList<DienNangTieuThu>);
				MessageBox.Show(STRINGS.SUCCESS_UPDATE_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(STRINGS.ERROR_UPDATE_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnKyTruoc_Click(object sender, EventArgs e)
		{
			dtpCuoiKy.Value = dtpCuoiKy.Value.AddMonths(-1);
		}

		private void btnKySau_Click(object sender, EventArgs e)
		{
			dtpCuoiKy.Value = dtpCuoiKy.Value.AddMonths(1);
		}

		private void dgvDienNangTieuThu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvDienNangTieuThu.AutoResizeColumns();
		}
		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvDienNangTieuThu.ClearSelection();
			dgvDienNangTieuThu.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			int index = dgvDienNangTieuThu.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			int index = dgvDienNangTieuThu.SelectedRows[0].Index;
			if (index < dgvDienNangTieuThu.Rows.Count - 1)
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
			GoToIndex(dgvDienNangTieuThu.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvDienNangTieuThu.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvDienNangTieuThu.SelectedRows[0];
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
			btnXuatExcel.PerformClick();
		}

		private void LoadTramBienAp()
		{
			SortableBindingList<TramBienAp> data = TramBienAp.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				cbxTenTram.DataSource = data;
				cbxTenTram.DisplayMember = nameof(TramBienAp.TenTram);
				cbxTenTram.ValueMember = nameof(TramBienAp.TenTram);
			}
		}

		private void LoadBangGia()
		{
			SortableBindingList<BangGia> data = BangGia.GetAll();
			if (data == null)
			{
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				cbxBangGia.DataSource = data;
				cbxBangGia.DisplayMember = nameof(BangGia.TenBangGia);
				cbxBangGia.ValueMember = nameof(BangGia.TenBangGia);
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
				cbxNguoiQuanLy.DataSource = data;
				cbxNguoiQuanLy.DisplayMember = nameof(NguoiQuanLy.TenQuanLy);
				cbxNguoiQuanLy.ValueMember = nameof(NguoiQuanLy.TenQuanLy);
			}
		}

		private void UpdateControls()
		{
			dtpBatDau_TK.Value = DateTime.Now.AddMonths(-1);
			dtpCuoiKy.Value = DateTime.Now;
			dtpDauKy.Value = DateTime.Now.AddMonths(-1);
		}
		#endregion

	}
}
