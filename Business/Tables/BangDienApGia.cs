using DataAccess;
using KGySoft.ComponentModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Tables
{
	[Table("BangDienApGia")]
	public class BangDienApGia
	{
		[Key]
		[DisplayName("Mã áp giá")]
		[StringLength(30)]
		[Required]
		public string MaApGia { get; set; }

		[Key]
		[DisplayName("Mã bảng giá")]
		[StringLength(30)]
		[Required]
		public string MaBangGia { get; set; }

		/// <summary>
		/// Tên bảng giá tương ứng với mã bảng giá ở trên, lưu ý cột này không có trong bảng BangDienApGia
		/// </summary>
		[DisplayName("Tên bảng giá")]
		[StringLength(150)]
		public string TenBangGia { get; set; }

		[DisplayName("Tỷ lệ (0..1)")]
		[DefaultValue(0.0)]
		[Required]
		public decimal TyLe { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public BangDienApGia()
		{

		}

		public static void Create(string maBangGia)
		{
			DataProvider.Instance.ExecuteNonQuery("proc_CreateNew_BangDienApGia", maBangGia);
		}

		public static SortableBindingList<BangDienApGia> GetAll(string maApGia)
		{
			return CBO.FillInBindingList<BangDienApGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_BangDienApGia", maApGia));
		}

		public static bool Update(BangDienApGia bangDienApGia)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_BangDienApGia", bangDienApGia.MaApGia, bangDienApGia.MaBangGia, bangDienApGia.TyLe, bangDienApGia.KichHoat);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
