using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Business.Classes
{
	[Table("KhachHang")]
	public class KhachHang
	{
		[Key]
		[DisplayName("Mã khách hàng")]
		[StringLength(9)]
		public string MaKhachHang { get; set; }

		[DisplayName("Họ và tên")]
		[StringLength(150)]
		[Required]
		public string HoVaTen { get; set; }

		[DisplayName("Địa chỉ")]
		[StringLength(200)]
		[Required]
		public string DiaChi { get; set; }

		[DisplayName("Mã bảng giá")]
		[StringLength(5)]
		[Required]
		public string MaBangGia { get; set; }

		[DisplayName("Mã trạm biến áp")]
		[StringLength(5)]
		[Required]
		public string MaTram { get; set; }

		[DisplayName("Số hộ")]
		[DefaultValue(1)]
		[Required]
		public byte SoHo { get; set; }

		[DisplayName("Hệ số nhân")]
		[DefaultValue(1)]
		[Required]
		public byte HeSoNhan { get; set; }

		[DisplayName("Mã số thuế")]
		[StringLength(20)]
		public string MaSoThue { get; set; }

		[DisplayName("Số điện thoại")]
		[StringLength(20)]
		public string SoDienThoai { get; set; }

		[DisplayName("Email")]
		[StringLength(100)]
		public string Email { get; set; }

		[DisplayName("Ngày tạo")]
		[Required]
		public DateTime NgayTao { get; set; }

		[DisplayName("Người tạo")]
		[StringLength(5)]
		[Required]
		public string NguoiTao { get; set; }

		[DisplayName("Ngày cập nhật")]
		[Required]
		public DateTime NgayCapNhat { get; set; }

		[DisplayName("Người cập nhật")]
		[StringLength(5)]
		[Required]
		public string NguoiCapNhat { get; set; }

		[DisplayName("Mã số hợp đồng")]
		[StringLength(20)]
		public string MaSoHopDong { get; set; }

		[DisplayName("Ngày hợp đồng")]
		public DateTime NgayHopDong { get; set; }

		[DisplayName("Mã công tơ")]
		[StringLength(20)]
		public string MaCongTo { get; set; }

		[DisplayName("Số ngân hàng")]
		[StringLength(20)]
		public string SoNganHang { get; set; }

		[DisplayName("Tên ngân hàng")]
		[StringLength(100)]
		public string TenNganHang { get; set; }

		[DisplayName("Đã xóa")]
		public bool DaXoa { get; set; }

		public KhachHang()
		{

		}

		public KhachHang(string maKhachHang, string hoVaTen, string diaChi, string maBangGia, string maTram, byte soHo, byte heSoNhan, string maSoThue, string soDienThoai, string email, DateTime ngayTao, string nguoiTao, DateTime ngayCapNhat, string nguoiCapNhat, string maSoHopDong, DateTime ngayHopDong, string maCongTo, string soNganHang, string tenNganHang, bool daXoa)
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
			DaXoa = daXoa;
		}

		public static List<KhachHang> GetAll()
			=> CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("proc_GetAll_KhachHang"));

		public static bool Add(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_KhachHang", khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool TryAdding(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_KhachHang_Test", khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool Update(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_KhachHang", khachHang.MaKhachHang, khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool TryUpdating(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_KhachHang_Test", khachHang.MaKhachHang, khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
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

		public static List<KhachHang> Filter(string diaChi, string maBangGia, string maTram, string tenNganHang)
		{
			List<KhachHang> list = GetAll();
			if (!string.IsNullOrWhiteSpace(diaChi))
				list = list.Where(khach => khach.DiaChi.Contains(diaChi)).ToList();
			if (!string.IsNullOrWhiteSpace(maBangGia))
				list = list.Where(khach => khach.MaBangGia.Equals(maBangGia)).ToList();
			if (!string.IsNullOrWhiteSpace(maTram))
				list = list.Where(khach => khach.MaTram.Equals(maTram)).ToList();
			if (!string.IsNullOrWhiteSpace(tenNganHang))
				list = list.Where(khach => khach.TenNganHang.Contains(tenNganHang)).ToList();
			return list;
		}
	}
}
