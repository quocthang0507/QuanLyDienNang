﻿using Business.Classes;
using Business.Forms;
using Business.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class Form_DienNangTieuThu : Form
	{
		private const string ERROR_QUERY_MESSAGE = "Lỗi thực hiện truy vấn đến cơ sở dữ liệu";
		private const string ERROR = "Lỗi";
		private const string SUCCESS = "Thành công";
		private const string SUCCESS_INSERT_MESSAGE = "Thêm vào CSDL thành công";
		private const string ERROR_INSERT_MESSAGE = "Thêm vào CSDL không thành công, vui lòng kiểm tra dữ liệu hợp lệ";
		private const string ERROR_EXPORT_MESSAGE = "Lỗi khi xuất dữ liệu sang tập tin Excel";
		private const string SUCCESS_EXPORT_MESSAGE = "Xuất dữ liệu sang tập tin Excel thành công";
		private const string QUESTION = "Xác nhận";
		private Funcs_DienNangTieuThu funcs = new Funcs_DienNangTieuThu();

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
			var data = DienNangTieuThu.GetAll();
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvDienNangTieuThu.DataSource = data;
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			var data = DienNangTieuThu.Filter(dtpBatDau_TK.Value, dtpKetThuc_TK.Value, (cbxTenTram.SelectedItem as TramBienAp).MaTram, tbxDiaChi.Text, (cbxBangGia.SelectedItem as BangGia).MaBangGia, chkConNo.Checked);
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvDienNangTieuThu.DataSource = data;
		}

		private void btnLapDanhSach_Click(object sender, EventArgs e)
		{
			var dialog = MessageBox.Show("Chức năng này dùng để lập danh sách mới theo kỳ được xác định, dữ liệu lấy từ danh sách khách hàng. Bạn có muốn tiếp tục?", QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.No)
				return;
			List<DienNangTieuThu> data = funcs.AddNewDNTTFromKH((cbxNguoiQuanLy.SelectedItem as NguoiQuanLy).MaQuanLy, dtpDauKy.Value, dtpCuoiKy.Value);
			if (data == null)
			{
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var ok = funcs.TryInsertingListToSQL(data);
			if (ok)
			{
				funcs.InsertSQL(data);
				dgvDienNangTieuThu.DataSource = data;
				MessageBox.Show(SUCCESS_INSERT_MESSAGE, SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(ERROR_INSERT_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnLoadKyHienTai_Click(object sender, EventArgs e)
		{
			var dialog = MessageBox.Show("Chức năng này dùng để tải danh sách theo kỳ được xác định, nếu dữ liệu đã có từ trước. Bạn có muốn tiếp tục?", QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialog == DialogResult.No)
				return;
			var data = DienNangTieuThu.GetByDate(dtpCuoiKy.Value);
			if (data == null)
			{
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dgvDienNangTieuThu.DataSource = data;
		}

		private void btnXuatExcel_Click(object sender, EventArgs e)
		{
			var bytes = Excel.ExportToExcel(dgvDienNangTieuThu.DataSource);
			if (bytes == null)
			{
				MessageBox.Show(ERROR_EXPORT_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var dialog = saveDialog.ShowDialog();
			if (dialog == DialogResult.OK)
			{
				string filepath = saveDialog.FileName;
				FileStream stream = File.Create(filepath);
				stream.Close();
				File.WriteAllBytes(filepath, bytes);
				MessageBox.Show(SUCCESS_EXPORT_MESSAGE, SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		#endregion

		#region Methods
		private void LoadTramBienAp()
		{
			var data = TramBienAp.GetAll();
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxTenTram.DataSource = data;
		}

		private void LoadBangGia()
		{
			var data = BangGia.GetAll();
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxBangGia.DataSource = data;
		}

		private void LoadNguoiQuanLy()
		{
			var data = NguoiQuanLy.GetAll();
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxNguoiQuanLy.DataSource = data;
		}

		private void UpdateControls()
		{
			dtpBatDau_TK.Value = DateTime.Now.AddMonths(-1);
			dtpCuoiKy.Value = DateTime.Now;
			dtpDauKy.Value = DateTime.Now.AddMonths(-1);
		}

		public void GoToIndex(int index)
		{
			dgvDienNangTieuThu.ClearSelection();
			dgvDienNangTieuThu.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvDienNangTieuThu.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvDienNangTieuThu.SelectedRows[0].Index;
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
				var row = dgvDienNangTieuThu.SelectedRows[0];
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
