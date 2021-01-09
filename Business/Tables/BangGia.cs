using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Classes
{
	[Table("BangGia")]
	public class BangGia
	{
		[Key]
		[DisplayName("Mã bảng giá")]
		[StringLength(10)]
		public string MaBangGia { get; set; }

		[DisplayName("Tên bảng giá")]
		[StringLength(100)]
		[Required]
		public string TenBangGia { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public BangGia()
		{

		}

		public static List<BangGia> GetAll()
			=> CBO.FillCollection<BangGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_BangGia"));

		public static bool IsDuplicatedMaBangGia(string MaBangGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_IsDuplicated_MaBangGia", MaBangGia);
			return result == 1;
		}

		public static bool Insert(BangGia bangGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_BangGia", bangGia.MaBangGia, bangGia.TenBangGia);
			return result > 0;
		}

		public static bool Update(BangGia bangGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_BangGia", bangGia.MaBangGia, bangGia.TenBangGia);
			return result > 0;
		}

		public static bool Delete(string id)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_BangGia", id);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
