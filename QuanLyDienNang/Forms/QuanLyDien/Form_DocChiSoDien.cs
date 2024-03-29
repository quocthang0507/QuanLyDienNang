﻿using Business;
using Business.Forms;
using Business.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang.Forms
{
	public partial class Form_DocChiSoDien : Form
	{
		private Thread runAllThread;
		private Thread runOneThread;
		private readonly Funcs_NhapChiSoDien funcs = new Funcs_NhapChiSoDien();

		public Form_DocChiSoDien()
		{
			InitializeComponent();
			lbxHinhAnh.DisplayMember = "DuongDan";
			lbxHinhAnh.ValueMember = "DuongDan";
		}

		#region Events
		private void FormKH_DocChiSoDien_Shown(object sender, EventArgs e)
		{
			tbxDuongDan.Text = funcs.GetSavedImageFolderPath();
		}

		private void btnMoThuMuc_Click(object sender, EventArgs e)
		{
			string path = tbxDuongDan.Text;
			if (Common.IsNullOrWhiteSpace(tbxDuongDan.Text))
			{
				DialogResult result = folderDialog.ShowDialog();
				if (result != DialogResult.OK || Common.IsNullOrWhiteSpace(folderDialog.SelectedPath))
				{
					return;
				}

				path = folderDialog.SelectedPath;
			}
			System.Collections.Generic.IEnumerable<ImageResult> files = FileUtils.LoadImagesFromDirectory(path);
			if (files == null || files.Count() == 0)
			{
				MessageBox.Show(STRINGS.ERROR_PATH_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			funcs.SaveImageFolderPath(path);
			lbxHinhAnh.Items.AddRange(files.ToArray());
		}

		private void btnChayServer_Click(object sender, EventArgs e)
		{

		}

		private void lbxHinhAnh_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				ImageResult selected = lbxHinhAnh.SelectedItem as ImageResult;
				pbxHinhAnh.Image = Image.FromFile(selected.DuongDan);
				tbxChiSoDien.Text = selected.ChiSoDien;
				tbxMaKhachHang.Text = selected.MaKhachHang;
			}
			catch (Exception)
			{
			}
		}

		private void tbxChiSoDien_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}

		private void btnNhanDien_Click(object sender, EventArgs e)
		{
			ImageResult selected = lbxHinhAnh.SelectedItem as ImageResult;
			runOneThread = new Thread(() => ProcessOne(selected, true));
			runOneThread.Start();
		}

		private void btnNhanDienTatCa_Click(object sender, EventArgs e)
		{
			if (CheckAnotherRunning())
			{
				return;
			}

			runAllThread = new Thread(ProcessAll);
			runAllThread.Start();
		}

		private void btnDung_Click(object sender, EventArgs e)
		{
			if (runAllThread != null && runAllThread.IsAlive)
			{
				runAllThread.Abort();
				runAllThread = null;
			}
			if (runOneThread != null && runOneThread.IsAlive)
			{
				runOneThread.Abort();
				runOneThread = null;
			}
		}
		#endregion

		#region Methods
		private void UpdateListView(ImageResult imageResult)
		{
			int id = lbxHinhAnh.FindString(imageResult.DuongDan);
			if (id > 0)
			{
				lbxHinhAnh.Invoke((MethodInvoker)delegate
				{
					lbxHinhAnh.Items[id] = imageResult;
				});
			}
		}

		private void ProcessAll()
		{
			foreach (ImageResult selected in lbxHinhAnh.Items)
			{
				ProcessOne(selected);
			}
		}

		private void ProcessOne(ImageResult selected, bool onlyOne = false)
		{
			string result = selected.ProcessDigitInImage();
			if (!onlyOne)
			{
				if (!Common.IsNullOrWhiteSpace(result))
				{
					selected.ChiSoDien = result;
					UpdateListView(selected);
				}
			}
			else
			{
				if (Common.IsNullOrWhiteSpace(result))
				{
					MessageBox.Show(STRINGS.ERROR_OCR_MESSAGE, STRINGS.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				tbxChiSoDien.Invoke((MethodInvoker)delegate
				{
					tbxChiSoDien.Text = result;
				});
				selected.ChiSoDien = result;
				UpdateListView(selected);
			}
		}

		private bool CheckAnotherRunning()
		{
			if (runOneThread != null && runOneThread.IsAlive || runAllThread != null && runAllThread.IsAlive)
			{
				MessageBox.Show(STRINGS.WARNING_THREAD_MESSAGE, STRINGS.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return true;
			}
			return false;
		}
		#endregion

	}
}
