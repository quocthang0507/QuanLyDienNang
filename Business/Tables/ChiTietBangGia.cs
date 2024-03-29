﻿using DataAccess;
using KGySoft.ComponentModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Classes
{
	[Table("ChiTietBangGia")]
	public class ChiTietBangGia
	{
		[Key]
		[DisplayName("Mã chi tiết")]
		[StringLength(30)]
		public string MaChiTiet { get; set; }

		[DisplayName("Mã bảng giá")]
		[StringLength(30)]
		[Required]
		public string MaBangGia { get; set; }

		[DisplayName("Bắt đầu")]
		[Required]
		public int BatDau { get; set; }

		[DisplayName("Kết thúc")]
		[Required]
		public int KetThuc { get; set; }

		[DisplayName("Đơn giá")]
		[Required]
		public int DonGia { get; set; }

		[DisplayName("Mô tả")]
		[StringLength(250)]
		public string MoTa { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public ChiTietBangGia()
		{

		}

		public static SortableBindingList<ChiTietBangGia> GetAll()
		{
			return CBO.FillInBindingList<ChiTietBangGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_ChiTietBangGia"));
		}

		public static SortableBindingList<ChiTietBangGia> GetByBangGia(string maBangGia)
		{
			return CBO.FillInBindingList<ChiTietBangGia>(DataProvider.Instance.ExecuteReader("proc_GetByBangGia_ChiTietBangGia", maBangGia));
		}

		public static bool Insert(ChiTietBangGia chiTietBangGia)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_ChiTietBangGia", chiTietBangGia.MaBangGia, chiTietBangGia.BatDau, chiTietBangGia.KetThuc, chiTietBangGia.DonGia, chiTietBangGia.MoTa);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public static bool Update(ChiTietBangGia chiTietBangGia)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_ChiTietBangGia", chiTietBangGia.MaBangGia, chiTietBangGia.MaBangGia, chiTietBangGia.BatDau, chiTietBangGia.KetThuc, chiTietBangGia.DonGia, chiTietBangGia.MoTa, chiTietBangGia.KichHoat);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Delete(int id)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_ChiTietBangGia", id);
			return result > 0;
		}

	}
}
