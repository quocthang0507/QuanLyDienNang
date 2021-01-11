using Business.Classes;
using Business.Helper;
using System;
using System.Globalization;
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
			string maBangGia = tbxMaBangGia.Text;
			string moTa = tbxMoTa.Text;
			string donGia = tbxDonGia.Text;
			string batDau = tbxBatDau.Text;
			string ketThuc = tbxKetThuc.Text;
			bool apGia = chkApGia.Checked;
			if (Common.IsNullOrWhiteSpace(maBangGia, batDau, ketThuc, donGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				ChiTietBangGia.Insert(new ChiTietBangGia()
				{
					MaBangGia = maBangGia,
					MoTa = moTa,
					DonGia = int.Parse(donGia),
					BatDau = int.Parse(batDau),
					KetThuc = int.Parse(ketThuc),
					ApGia = apGia
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
			bool apGia = (bool)changedRow.Cells[6].Value;
			bool kichHoat = (bool)changedRow.Cells[7].Value;
			if (Common.IsNullOrWhiteSpace(maBangGia, batDau, ketThuc, donGia))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				ChiTietBangGia.Update(new ChiTietBangGia()
				{
					MaChiTiet = maChiTiet,
					MaBangGia = maBangGia,
					MoTa = moTa,
					DonGia = int.Parse(donGia),
					BatDau = int.Parse(batDau),
					KetThuc = int.Parse(ketThuc),
					ApGia = apGia,
					KichHoat = kichHoat
				});
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

		private void btnBangDienApGia_Click(object sender, EventArgs e)
		{
			DataGridViewRow selectedRow = dgvChiTietGia.SelectedRows[0];
			ChiTietBangGia chiTietBangGia = selectedRow.DataBoundItem as ChiTietBangGia;
			if (chiTietBangGia.ApGia)
			{
				Form frmBangDienApGia = new Form_BangDienApGia(chiTietBangGia);
				frmBangDienApGia.ShowDialog();
			}
			else
			{
				MessageBox.Show(STRINGS.WARNING_NO_PERCENT_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		#endregion

		#region Methods
		private void LoadTableByMaBangGia()
		{
			System.Collections.Generic.List<ChiTietBangGia> data = ChiTietBangGia.GetByBangGia(bangGia.MaBangGia);
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
		#endregion

	}
}
