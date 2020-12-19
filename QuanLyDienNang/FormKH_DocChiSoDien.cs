using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ThuVien;
using ThuVien.Classes;

namespace QuanLyDienNang
{
	public partial class FormKH_DocChiSoDien : Form
	{
		public FormKH_DocChiSoDien()
		{
			InitializeComponent();
			lbxHinhAnh.DisplayMember = "DuongDan";
			lbxHinhAnh.ValueMember = "DuongDan";
		}

		private void btnMoThuMuc_Click(object sender, EventArgs e)
		{
			var result = folderDialog.ShowDialog();
			if (result != DialogResult.OK || string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
				return;
			string path = folderDialog.SelectedPath;
			var files = FileUtils.LoadImagesFromDirectory(path);
			if (files.Count() == 0)
			{
				MessageBox.Show("Không tìm thấy hình ảnh .jpg hay .png nào trong thư mục", "Thư mục không thể chọn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			lbxHinhAnh.Items.AddRange(files.ToArray());
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

				throw;
			}
		}

		private void tbxChiSoDien_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.IsDigitEvent(ref e);
		}
	}
}
