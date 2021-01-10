using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Tables
{
	[Table("BangDienApGia")]
	public class BangDienApGia
	{
		[DisplayName("Mã chi tiết bảng giá")]
		public string MaChiTiet { get; set; }

		[DisplayName("Mã bảng giá")]
		public string MaBangGia { get; set; }

		[DisplayName("Tỷ lệ (0..1)")]
		public float TyLe { get; set; }

		[DisplayName("Tên bảng điện áp gía")]
		public string TenBangDien { get; set; }

		public BangDienApGia()
		{

		}
	}
}
