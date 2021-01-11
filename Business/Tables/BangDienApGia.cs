using DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Tables
{
	[Table("BangDienApGia")]
	public class BangDienApGia
	{
		[Key]
		[DisplayName("Mã chi tiết bảng giá")]
		[Required]
		public string MaChiTiet { get; set; }

		[Key]
		[DisplayName("Mã bảng giá")]
		[Required]
		public string MaBangGia { get; set; }

		/// <summary>
		/// Tên bảng giá tương ứng với mã bảng giá ở trên, lưu ý cột này không có trong bảng BangDienApGia
		/// </summary>
		[DisplayName("Tên bảng giá")]
		[StringLength(150)]
		public string TenBangGia { get; set; }

		[DisplayName("Tỷ lệ (0..1)")]
		[DefaultValue(0f)]
		[Required]
		public float TyLe { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public BangDienApGia()
		{

		}

		public static void Create(string maChiTiet)
		{
			DataProvider.Instance.ExecuteNonQuery("proc_CreateNew_BangDienApGia", maChiTiet);
		}

		public static List<BangDienApGia> GetAll(string maChiTiet)
		{
			return CBO.FillCollection<BangDienApGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_BangDienApGia", maChiTiet));
		}

		public static bool Update(BangDienApGia bangDienApGia)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_BangDienApGia", bangDienApGia.MaChiTiet, bangDienApGia.MaBangGia, bangDienApGia.TyLe, bangDienApGia.KichHoat);
			return result > 0;
		}
	}
}
