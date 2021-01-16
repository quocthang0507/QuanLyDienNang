using DataAccess;
using KGySoft.ComponentModel;
using System;
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
		[StringLength(30)]
		public string MaBangGia { get; set; }

		[DisplayName("Tên bảng giá")]
		[StringLength(150)]
		[Required]
		public string TenBangGia { get; set; }

		[DisplayName("Thuế VAT (0..1)")]
		[Required]
		[DefaultValue(0.1)]
		public decimal Thue { get; set; }

		[DisplayName("Áp giá phần trăm")]
		[Required]
		[DefaultValue(false)]
		public bool ApGia { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public BangGia()
		{

		}

		public static SortableBindingList<BangGia> GetAll()
		{
			return CBO.FillInBindingList<BangGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_BangGia"));
		}

		public static bool IsDuplicatedMaBangGia(string MaBangGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_IsDuplicated_MaBangGia", MaBangGia);
			return result == 1;
		}

		public static bool Insert(BangGia bangGia)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_BangGia", bangGia.MaBangGia, bangGia.TenBangGia, bangGia.Thue, bangGia.ApGia);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Update(BangGia bangGia)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_BangGia", bangGia.MaBangGia, bangGia.TenBangGia, bangGia.Thue, bangGia.ApGia, bangGia.KichHoat);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Delete(string id)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_BangGia", id);
			return result > 0;
		}
	}
}
