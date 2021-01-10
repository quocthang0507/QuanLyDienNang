using Business.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_TramBienAp : Form
	{
		public Form_TramBienAp()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_TramBienAp_Shown(object sender, EventArgs e)
		{
			LoadTable();
			UpdateColumnFormat();
		}

		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvTramBienAp.ClearSelection();
			dgvTramBienAp.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvTramBienAp.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvTramBienAp.SelectedRows[0].Index;
			if (index < dgvTramBienAp.Rows.Count - 1)
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
			GoToIndex(dgvTramBienAp.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvTramBienAp.SelectedRows.Count > 0)
			{
				var row = dgvTramBienAp.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				builder.Append(row.Cells[0].Value.ToString() + '\t');
				builder.Append(row.Cells[1].Value.ToString() + '\t');
				builder.Append(row.Cells[3].Value.ToString() + '\t');
				builder.Append(row.Cells[4].Value.ToString() + '\t');
				builder.Append(row.Cells[5].Value.ToString() + '\t');
				builder.Append(row.Cells[6].Value.ToString() + '\t');
				return builder.ToString();
			}
			return string.Empty;
		}

		private void LoadTable()
		{
			var data = TramBienAp.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvTramBienAp.DataSource = data;
		}

		private void UpdateColumnFormat()
		{
			dgvTramBienAp.Columns[0].ReadOnly = true;
			dgvTramBienAp.Columns[0].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
		}
		#endregion

	}
}
