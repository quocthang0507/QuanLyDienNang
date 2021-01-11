using Business.Classes;
using Business.Helper;
using Business.Tables;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_BangDienApGia : Form
	{
		private readonly ChiTietBangGia chiTietBangGia;

		public Form_BangDienApGia(ChiTietBangGia chiTietBangGia)
		{
			InitializeComponent();
			this.chiTietBangGia = chiTietBangGia;
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
			string maBangGia = changedRow.Cells[0].Value.ToString();
			string maChiTiet = changedRow.Cells[1].Value.ToString();
			string tyLe = changedRow.Cells[3].Value.ToString();
			bool kichHoat = (bool)changedRow.Cells[4].Value;
			if (Common.IsNullOrWhiteSpace(tyLe))
			{
				MessageBox.Show(STRINGS.WARNING_MISS_FIELDS_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				var ok = BangDienApGia.Update(new BangDienApGia()
				{
					MaBangGia = maBangGia,
					MaChiTiet = maChiTiet,
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
		private void LoadTable()
		{
			BangDienApGia.Create(chiTietBangGia.MaChiTiet);
			List<BangDienApGia> data = BangDienApGia.GetAll(chiTietBangGia.MaChiTiet);
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
