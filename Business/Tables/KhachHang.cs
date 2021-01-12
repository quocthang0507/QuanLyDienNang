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
		[StringLength(10)]
		public string MaKhachHang { get; set; }

		[DisplayName("Họ và tên")]
		[StringLength(100)]
		[Required]
		public string HoVaTen { get; set; }

		[DisplayName("Địa chỉ")]
		[StringLength(250)]
		[Required]
		public string DiaChi { get; set; }

		[DisplayName("Mã bảng giá")]
		[StringLength(30)]
		[Required]
		public string MaBangGia { get; set; }

		[DisplayName("Mã trạm biến áp")]
		[StringLength(30)]
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
		[StringLength(30)]
		public string MaSoThue { get; set; }

		[DisplayName("Số điện thoại")]
		[StringLength(30)]
		public string SoDienThoai { get; set; }

		[DisplayName("Email")]
		[StringLength(100)]
		public string Email { get; set; }

		[DisplayName("Ngày tạo")]
		[Required]
		public DateTime NgayTao { get; set; }

		[DisplayName("Người tạo")]
		[StringLength(30)]
		[Required]
		public string NguoiTao { get; set; }

		[DisplayName("Ngày cập nhật")]
		[Required]
		public DateTime NgayCapNhat { get; set; }

		[DisplayName("Người cập nhật")]
		[StringLength(30)]
		[Required]
		public string NguoiCapNhat { get; set; }

		[DisplayName("Mã số hợp đồng")]
		[StringLength(30)]
		public string MaSoHopDong { get; set; }

		[DisplayName("Ngày hợp đồng")]
		public DateTime NgayHopDong { get; set; }

		[DisplayName("Mã công tơ")]
		[StringLength(30)]
		public string MaCongTo { get; set; }

		[DisplayName("Số ngân hàng")]
		[StringLength(30)]
		public string SoNganHang { get; set; }

		[DisplayName("Tên ngân hàng")]
		[StringLength(150)]
		public string TenNganHang { get; set; }

		[DisplayName("Đã xóa")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public KhachHang()
		{

		}

		public static List<KhachHang> GetAll()
		{
			return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("proc_GetAll_KhachHang"));
		}

		public static bool Insert(KhachHang khachHang)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_KhachHang", khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool TryInserting(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_KhachHang_Test", khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool Update(KhachHang khachHang)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_KhachHang", khachHang.MaKhachHang, khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool TryUpdating(KhachHang khachHang)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_KhachHang_Test", khachHang.MaKhachHang, khachHang.HoVaTen, khachHang.DiaChi, khachHang.MaBangGia, khachHang.MaTram, khachHang.SoHo, khachHang.HeSoNhan, khachHang.MaSoThue, khachHang.SoDienThoai, khachHang.Email, khachHang.NgayTao, khachHang.NguoiTao, khachHang.NgayCapNhat, khachHang.NguoiCapNhat, khachHang.MaSoHopDong, khachHang.NgayHopDong, khachHang.MaCongTo, khachHang.SoNganHang, khachHang.TenNganHang);
			return result > 0;
		}

		public static bool Delete(string id)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_KhachHang", id);
			return result > 0;
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
