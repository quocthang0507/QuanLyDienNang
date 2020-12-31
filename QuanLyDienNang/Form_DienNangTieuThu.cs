using Business.Classes;
using Business.Forms;
using Business.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class Form_DienNangTieuThu : Form
	{
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

		private void btnTimKiemTatCa_Click(object sender, EventArgs e)
		{
			var data = DienNangTieuThu.GetAll();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvDienNangTieuThu.DataSource = data;
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			var data = DienNangTieuThu.Filter(dtpBatDau_TK.Value, dtpKetThuc_TK.Value, (cbxTenTram.SelectedItem as TramBienAp).MaTram, tbxDiaChi.Text, (cbxBangGia.SelectedItem as BangGia).MaBangGia, chkConNo.Checked);
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvDienNangTieuThu.DataSource = data;
		}

		private void btnCapNhatKy_Click(object sender, EventArgs e)
		{
			List<DienNangTieuThu> data = funcs.AddDienNangTieuThuFromKhachHang((cbxNguoiQuanLy.SelectedItem as NguoiQuanLy).MaQuanLy, dtpBatDau.Value, dtpKetThuc.Value);
			if (data == null)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var ok = funcs.TryInsertingListToSQL(data);
			if (ok)
			{
				funcs.InsertSQL(data);
				dgvDienNangTieuThu.DataSource = data;
				MessageBox.Show("Thêm vào CSDL thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Thêm vào CSDL không thành công, vui lòng kiểm tra dữ liệu hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		#endregion

		#region Methods
		private void LoadTramBienAp()
		{
			var data = TramBienAp.GetAll();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxTenTram.DataSource = data;
		}

		private void LoadBangGia()
		{
			var data = BangGia.GetAll();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxBangGia.DataSource = data;
		}

		private void LoadNguoiQuanLy()
		{
			var data = NguoiQuanLy.GetAll();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxNguoiQuanLy.DataSource = data;
		}

		private void UpdateControls()
		{
			dtpBatDau_TK.Value = DateTime.Now.AddMonths(-1);
			dtpKetThuc.Value = DateTime.Now;
			dtpBatDau.Value = DateTime.Now.AddMonths(-1);
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
