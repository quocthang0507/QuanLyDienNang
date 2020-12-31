using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Classes
{
	[Table("ChiTietBangGia")]
	public class ChiTietBangGia
	{
		[Key]
		[DisplayName("ID")]
		public int ID { get; set; }

		[DisplayName("Mã bảng giá")]
		[StringLength(5)]
		[Required]
		public string MaBangGia { get; set; }

		[DisplayName("Bắt đầu")]
		[Required]
		public int BatDau { get; set; }

		[DisplayName("Kết thúc")]
		[Required]
		public int KetThuc { get; set; }

		[DisplayName("Giá trước VAT")]
		[Required]
		public int GiaTruocVAT { get; set; }

		[DisplayName("Giá sau VAT")]
		[Required]
		public float VAT { get; set; }

		[DisplayName("Giá sau VAT")]
		public int GiaSauVAT { get; set; }

		[DisplayName("Mô tả")]
		[StringLength(200)]
		public string MoTa { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public ChiTietBangGia()
		{

		}

		public static List<ChiTietBangGia> GetAll()
			=> CBO.FillCollection<ChiTietBangGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_ChiTietBangGia"));

		public static bool Insert(ChiTietBangGia chiTietBangGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_ChiTietBangGia", chiTietBangGia.MaBangGia, chiTietBangGia.BatDau, chiTietBangGia.KetThuc, chiTietBangGia.GiaTruocVAT, chiTietBangGia.VAT, chiTietBangGia.MoTa);
			return result > 0;
		}

		public static bool Update(ChiTietBangGia chiTietBangGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_ChiTietBangGia", chiTietBangGia.ID, chiTietBangGia.MaBangGia, chiTietBangGia.BatDau, chiTietBangGia.KetThuc, chiTietBangGia.GiaTruocVAT, chiTietBangGia.VAT, chiTietBangGia.MoTa);
			return result > 0;
		}

		public static bool Delete(int id)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_ChiTietBangGia", id);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

	}
}
