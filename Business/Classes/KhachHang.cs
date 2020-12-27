using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Business.Classes
{
	public class KhachHang
	{
		public string MaKhachHang { get; set; }
		public string HoVaTen { get; set; }
		public string DiaChi { get; set; }
		public string MaBangGia { get; set; }
		public string MaTram { get; set; }
		public byte SoHo { get; set; }
		public byte HeSoNhan { get; set; }
		public string MaSoThue { get; set; }
		public string SoDienThoai { get; set; }
		public string Email { get; set; }
		public DateTime NgayTao { get; set; }
		public string NguoiTao { get; set; }
		public DateTime NgayCapNhat { get; set; }
		public string NguoiCapNhat { get; set; }
		public string MaSoHopDong { get; set; }
		public DateTime NgayHopDong { get; set; }
		public string MaCongTo { get; set; }
		public string SoNganHang { get; set; }
		public string TenNganHang { get; set; }

		public KhachHang()
		{

		}

		public KhachHang(string maKhachHang, string hoVaTen, string diaChi, string maBangGia, string maTram, byte soHo, byte heSoNhan, string maSoThue, string soDienThoai, string email, DateTime ngayTao, string nguoiTao, DateTime ngayCapNhat, string nguoiCapNhat, string maSoHopDong, DateTime ngayHopDong, string maCongTo, string soNganHang, string tenNganHang)
		{
			MaKhachHang = maKhachHang;
			HoVaTen = hoVaTen;
			DiaChi = diaChi;
			MaBangGia = maBangGia;
			MaTram = maTram;
			SoHo = soHo;
			HeSoNhan = heSoNhan;
			MaSoThue = maSoThue;
			SoDienThoai = soDienThoai;
			Email = email;
			NgayTao = ngayTao;
			NguoiTao = nguoiTao;
			NgayCapNhat = ngayCapNhat;
			NguoiCapNhat = nguoiCapNhat;
			MaSoHopDong = maSoHopDong;
			NgayHopDong = ngayHopDong;
			MaCongTo = maCongTo;
			SoNganHang = soNganHang;
			TenNganHang = tenNganHang;
		}

		public static List<KhachHang> All()
			=> CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("proc_GetAll_KhachHang"));

		public static bool Add(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_KhachHang", khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool Update(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_KhachHang", khachHang.MaKhachHang, khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool Delete(string id)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_KhachHang", id);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static BindingSource LoadTable()
		{
			try
			{
				var binding = new BindingSource();
				var list = All();
				binding.DataSource = list;
				return binding;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	}
}
