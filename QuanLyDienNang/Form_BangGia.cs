﻿using Business.Classes;
using Business.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class Form_BangGia : Form
	{
		private const string ERROR = "Lỗi";
		private const string ERROR_QUERY_MESSAGE = "Lỗi thực hiện truy vấn đến cơ sở dữ liệu";
		private Funcs_BangGia funcs = new Funcs_BangGia();

		public Form_BangGia()
		{
			InitializeComponent();
		}

		#region Events
		private void Form_BangGia_Shown(object sender, EventArgs e)
		{
			LoadTable();
		}

		private void btnCapNhat_Click(object sender, EventArgs e)
		{

		}

		private void btnThem_Click(object sender, EventArgs e)
		{

		}

		private void btnXoa_Click(object sender, EventArgs e)
		{

		}

		private void btnXemChiTiet_Click(object sender, EventArgs e)
		{

		}
		#endregion

		#region Methods
		public void GoToIndex(int index)
		{
			dgvBangGia.ClearSelection();
			dgvBangGia.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvBangGia.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvBangGia.SelectedRows[0].Index;
			if (index < dgvBangGia.Rows.Count - 1)
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
			GoToIndex(dgvBangGia.Rows.Count - 1);
		}

		public override string ToString()
		{
			if (dgvBangGia.SelectedRows.Count > 0)
			{
				var row = dgvBangGia.SelectedRows[0];
				StringBuilder builder = new StringBuilder();
				builder.Append(row.Cells[0].Value.ToString() + '\t');
				builder.Append(row.Cells[1].Value.ToString() + '\t');
				builder.Append(row.Cells[2].Value.ToString() + '\t');
				return builder.ToString();
			}
			return string.Empty;
		}

		private void LoadTable()
		{
			var data = BangGia.GetAll();
			if (data == null)
				MessageBox.Show(ERROR_QUERY_MESSAGE, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				dgvBangGia.DataSource = data;
		}
		#endregion
	}
}
