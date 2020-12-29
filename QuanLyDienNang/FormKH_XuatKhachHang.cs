using Business.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyDienNang
{
	public partial class FormKH_XuatKhachHang : Form
	{
		private Funcs_KhachHang funcs = new Funcs_KhachHang();
		private Thread thread;

		public FormKH_XuatKhachHang()
		{
			InitializeComponent();
			saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		}

		#region Events
		private void FormKH_XuatKhachHang_Load(object sender, System.EventArgs e)
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
				dgvKhachHang.DataSource = KhachHang.All();
			else
			{
				string maBangGia, maTram;
				maBangGia = (cbxBangGia.SelectedItem as BangGia).MaBangGia;
				maTram = (cbxTenTram.SelectedItem as TramBienAp).MaTram;
				dgvKhachHang.DataSource = funcs.FilterTable(tbxDiaChi.Text, maBangGia, maTram, cbxNganHang.Text);
			}
		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
			try
			{
				var bytes = funcs.ExportToExcel(dgvKhachHang.DataSource as List<KhachHang>);
				var dialog = saveDialog.ShowDialog();
				if (dialog == DialogResult.OK)
				{
					string filepath = saveDialog.FileName;
					FileStream stream = File.Create(filepath);
					stream.Close();
					File.WriteAllBytes(filepath, bytes);
					MessageBox.Show("Xuất dữ liệu sang tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi khi xuất dữ liệu sang tập tin Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Methods
		private void LoadTramQuanLy()
		{
			var data = TramBienAp.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxTenTram.DataSource = data;
		}

		private void LoadBangGia()
		{
			var data = BangGia.All();
			if (data == null)
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				cbxBangGia.DataSource = data;
		}

		private void LoadDanhSachNganHang()
		{
			cbxNganHang.DataSource = KhachHang.All().Select(khach => khach.TenNganHang).Distinct().ToList();
		}
		#endregion

	}
}
