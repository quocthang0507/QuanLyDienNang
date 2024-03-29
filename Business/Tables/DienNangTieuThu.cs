﻿using DataAccess;
using KGySoft.ComponentModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Business.Classes
{
	[Table("DienNangTieuThu")]
	public class DienNangTieuThu
	{
		[Key]
		[DisplayName("ID")]
		public int ID { get; set; }

		[DisplayName("Mã khách hàng")]
		[StringLength(10)]
		[Required]
		public string MaKhachHang { get; set; }

		/// <summary>
		/// Tên khách hàng từ mã khách hàng ở trên, lưu ý cột này không có trong bảng DienNangTieuThu
		/// </summary>
		[DisplayName("Tên khách hàng")]
		[StringLength(100)]
		public string HoVaTen { get; set; }

		/// <summary>
		/// Địa chỉ của khách hàng từ mã khách hàng ở trên, lưu ý cột này không có trong bảng DienNangTieuThu
		/// </summary>
		[DisplayName("Địa chỉ")]
		[StringLength(250)]
		public string DiaChi { get; set; }

		/// <summary>
		/// Mã trạm của khách hàng thuộc về, lưu ý cột này không có trong bảng DienNangTieuThu
		/// </summary>
		[DisplayName("Mã trạm")]
		[StringLength(30)]
		public string MaTram { get; set; }

		/// <summary>
		/// Mã bảng giá của khách hàng thuộc về, lưu ý cột này không có trong bảng DienNangTieuThu
		/// </summary>
		[DisplayName("Mã bảng giá")]
		[StringLength(30)]
		public string MaBangGia { get; set; }

		[DisplayName("Ngày ghi")]
		[Required]
		public DateTime NgayGhi { get; set; }

		[DisplayName("Người ghi")]
		[StringLength(30)]
		[Required]
		public string NguoiGhi { get; set; }

		[DisplayName("Ngày bắt đầu")]
		public DateTime NgayBatDau { get; set; }

		[DisplayName("Ngày kết thúc")]
		public DateTime NgayKetThuc { get; set; }

		[DisplayName("Ngày cập nhật")]
		[Required]
		public DateTime NgayCapNhat { get; set; }

		[DisplayName("Người cập nhật")]
		[StringLength(30)]
		[Required]
		public string NguoiCapNhat { get; set; }

		[DisplayName("Ngày hóa đơn")]
		public DateTime? NgayHoaDon { get; set; }

		[DisplayName("Ngày trả tiền")]
		public DateTime? NgayTraTien { get; set; }

		[DisplayName("Chỉ số mới")]
		[Required]
		[DefaultValue(0)]
		public int ChiSoMoi { get; set; }

		[DisplayName("Chỉ số cũ")]
		[Required]
		[DefaultValue(0)]
		public int ChiSoCu { get; set; }

		[DisplayName("Giờ thấp điểm")]
		[Required]
		[DefaultValue(0)]
		public int ThapDiem { get; set; }

		[DisplayName("Giờ cao điểm")]
		[Required]
		[DefaultValue(0)]
		public int CaoDiem { get; set; }

		[DisplayName("Giờ bình thường")]
		[Required]
		[DefaultValue(0)]
		public int BinhThuong { get; set; }

		[DisplayName("Tổng tiền trước VAT")]
		public int TongTienTruocVAT { get; set; }

		[DisplayName("Tổng tiền sau VAT")]
		public int TongTienSauVAT { get; set; }

		[DisplayName("Đã trả")]
		[DefaultValue(0)]
		public int DaTra { get; set; }

		[DisplayName("Còn lại")]
		public int ConLai { get; set; }

		public DienNangTieuThu()
		{

		}

		public static SortableBindingList<DienNangTieuThu> GetAll()
		{
			return CBO.FillInBindingList<DienNangTieuThu>(DataProvider.Instance.ExecuteReader("proc_GetAll_DienNangTieuThu"));
		}

		public static SortableBindingList<DienNangTieuThu> GetByPeriod(DateTime ngayCuoiKy)
		{
			return CBO.FillInBindingList<DienNangTieuThu>(DataProvider.Instance.ExecuteReader("proc_GetByDate_DienNangTieuThu", ngayCuoiKy.Month, ngayCuoiKy.Year));
		}

		public static bool Insert(DienNangTieuThu dienNangTieuThu)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_DienNangTieuThu", dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.NgayBatDau, dienNangTieuThu.NgayKetThuc, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.NgayHoaDon, dienNangTieuThu.NgayTraTien, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.ThapDiem, dienNangTieuThu.CaoDiem, dienNangTieuThu.BinhThuong, dienNangTieuThu.TongTienTruocVAT, dienNangTieuThu.TongTienSauVAT, dienNangTieuThu.DaTra, dienNangTieuThu.ConLai);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool TryInserting(DienNangTieuThu dienNangTieuThu)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_DienNangTieuThu_Test", dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.NgayBatDau, dienNangTieuThu.NgayKetThuc, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.NgayHoaDon, dienNangTieuThu.NgayTraTien, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.ThapDiem, dienNangTieuThu.CaoDiem, dienNangTieuThu.BinhThuong, dienNangTieuThu.TongTienTruocVAT, dienNangTieuThu.TongTienSauVAT, dienNangTieuThu.DaTra, dienNangTieuThu.ConLai);
			return result > 0;
		}

		public static bool Update(DienNangTieuThu dienNangTieuThu)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_DienNangTieuThu", dienNangTieuThu.ID, dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.NgayBatDau, dienNangTieuThu.NgayKetThuc, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.NgayHoaDon, dienNangTieuThu.NgayTraTien, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.ThapDiem, dienNangTieuThu.CaoDiem, dienNangTieuThu.BinhThuong, dienNangTieuThu.TongTienTruocVAT, dienNangTieuThu.TongTienSauVAT, dienNangTieuThu.DaTra, dienNangTieuThu.ConLai);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool TryUpdating(DienNangTieuThu dienNangTieuThu)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_DienNangTieuThu_Test", dienNangTieuThu.ID, dienNangTieuThu.MaKhachHang, dienNangTieuThu.NgayGhi, dienNangTieuThu.NguoiGhi, dienNangTieuThu.NgayBatDau, dienNangTieuThu.NgayKetThuc, dienNangTieuThu.NgayCapNhat, dienNangTieuThu.NguoiCapNhat, dienNangTieuThu.NgayHoaDon, dienNangTieuThu.NgayTraTien, dienNangTieuThu.ChiSoMoi, dienNangTieuThu.ChiSoCu, dienNangTieuThu.ThapDiem, dienNangTieuThu.CaoDiem, dienNangTieuThu.BinhThuong, dienNangTieuThu.TongTienTruocVAT, dienNangTieuThu.TongTienSauVAT, dienNangTieuThu.DaTra, dienNangTieuThu.ConLai);
			return result > 0;
		}

		public static bool Delete(int id)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_DienNangTieuThu", id);
			return result > 0;
		}

		public static SortableBindingList<DienNangTieuThu> Filter(DateTime batDau, DateTime ketThuc, string maTram, string diaChi, string maBangGia, bool conNo)
		{
			SortableBindingList<DienNangTieuThu> list = GetAll();
			var temp = list.Where(dntt => dntt.NgayBatDau.Month == batDau.Month && dntt.NgayKetThuc.Month == ketThuc.Month && dntt.NgayBatDau.Year == batDau.Year && dntt.NgayKetThuc.Year == ketThuc.Year);
			temp = temp.Where(dntt => dntt.MaTram == maTram && dntt.DiaChi.Contains(diaChi) && dntt.MaBangGia == maBangGia).ToList();
			if (conNo)
			{
				temp = temp.Where(dntt => dntt.ConLai > 0);
			}
			return new SortableBindingList<DienNangTieuThu>(temp.ToList());
		}

		public static bool UpdateMoney(DateTime ngayBatDau, DateTime ngayKetThuc, string maQuanLy)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_TinhTienDien_DienNangTieuThu", ngayBatDau.ToString("yyyy/MM/dd"), ngayKetThuc.ToString("yyyy/MM/dd"), maQuanLy);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
