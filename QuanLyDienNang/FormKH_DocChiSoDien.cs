using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ThuVien;
using ThuVien.Classes;

namespace QuanLyDienNang
{
	public partial class FormKH_DocChiSoDien : Form
	{
		private Thread runAllThread;
		private Thread runOneThread;

		public FormKH_DocChiSoDien()
		{
			InitializeComponent();
			lbxHinhAnh.DisplayMember = "DuongDan";
			lbxHinhAnh.ValueMember = "DuongDan";
		}

		private void btnMoThuMuc_Click(object sender, EventArgs e)
		{
			string path = tbxDuongDan.Text;
			if (string.IsNullOrEmpty(tbxDuongDan.Text))
			{
				var result = folderDialog.ShowDialog();
				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
					return;
				path = folderDialog.SelectedPath;
			}
			var files = FileUtils.LoadImagesFromDirectory(path);
			if (files == null || files.Count() == 0)
			{
				MessageBox.Show("Đường dẫn không hợp lệ hoặc không tìm thấy hình ảnh .jpg hay .png nào trong thư mục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
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
				return;
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
				if (!string.IsNullOrEmpty(result))
				{
					selected.ChiSoDien = result;
					UpdateListView(selected);
				}
			}
			else
			{
				if (string.IsNullOrEmpty(result))
				{
					MessageBox.Show("Lỗi khi nhận diện số trên hình ảnh!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show("Có một tiến trình tương tự đang chạy, bạn phải đợi cho tiến trình đó hoàn tất hoặc nhấn vào nút 'Dừng' và chạy lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return true;
			}
			return false;
		}
	}
}
