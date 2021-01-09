﻿using Business.Classes;
using Business.Forms;
using Business.Helper;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class FormKH_XuatKhachHang : Form
	{
		private readonly Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_XuatKhachHang()
		{
			InitializeComponent();
			saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		}

		#region Events
		private void FormKH_XuatKhachHang_Shown(object sender, EventArgs e)
		{
			thread = new Thread(() =>
			{
				dgvKhachHang.Invoke((MethodInvoker)delegate
				{
					LoadBangGia();
					LoadTramQuanLy();
					LoadDanhSachNganHang();
					btnTimKiem.PerformClick();
				});
			});
			thread.Start();
		}

		private void rbtnXuatHet_CheckedChanged(object sender, System.EventArgs e)
		{
			panelXuatDieuKien.Enabled = false;
		}

		private void rbtnXuatDieuKien_CheckedChanged(object sender, System.EventArgs e)
		{
			panelXuatDieuKien.Enabled = true;
		}

		private void btnTimKiem_Click(object sender, System.EventArgs e)
		{
			if (rbtnXuatHet.Checked)
				dgvKhachHang.DataSource = KhachHang.GetAll();
			else
			{
				string maBangGia, maTram;
				maBangGia = (cbxBangGia.SelectedItem as BangGia).MaBangGia;
				maTram = (cbxTenTram.SelectedItem as TramBienAp).MaTram;
				dgvKhachHang.DataSource = KhachHang.Filter(tbxDiaChi.Text, maBangGia, maTram, cbxNganHang.Text);
			}
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
			var bytes = Excel.ExportToExcel(dgvKhachHang.DataSource);
			if (bytes == null)
			{
				MessageBox.Show(STRINGS.ERROR_EXPORT_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var dialog = saveDialog.ShowDialog();
			if (dialog == DialogResult.OK)
			{
				string filepath = saveDialog.FileName;
				FileStream stream = File.Create(filepath);
				stream.Close();
				File.WriteAllBytes(filepath, bytes);
				MessageBox.Show(STRINGS.SUCCESS_EXPORT_MESSAGE, STRINGS.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion

		#region Methods
		private void LoadTramQuanLy()
		{
			var data = TramBienAp.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxTenTram.DataSource = data;
		}

		private void LoadBangGia()
		{
			var data = BangGia.GetAll();
			if (data == null)
				MessageBox.Show(STRINGS.ERROR_QUERY_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxBangGia.DataSource = data;
		}

		private void LoadDanhSachNganHang()
		{
			cbxNganHang.DataSource = KhachHang.GetAll().Select(khach => khach.TenNganHang).Distinct().ToList();
		}

		public void GoToIndex(int index)
		{
			dgvKhachHang.ClearSelection();
			dgvKhachHang.Rows[index].Selected = true;
		}

		public void GoUp()
		{
			var index = dgvKhachHang.SelectedRows[0].Index;
			if (index > 0)
			{
				index--;
				GoToIndex(index);
			}
		}

		public void GoDown()
		{
			var index = dgvKhachHang.SelectedRows[0].Index;
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
				var row = dgvKhachHang.SelectedRows[0];
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