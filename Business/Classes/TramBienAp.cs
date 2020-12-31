using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Classes
{
	[Table("TramBienAp")]
	public class TramBienAp
	{
		[Key]
		[DisplayName("Mã trạm biến áp")]
		[StringLength(5)]
		public string MaTram { get; set; }

		[DisplayName("Tên trạm biến áp")]
		[StringLength(100)]
		[Required]
		public string TenTram { get; set; }

		[DisplayName("Địa chỉ")]
		[StringLength(200)]
		public string DiaChi { get; set; }

		[DisplayName("Người phụ trách")]
		[StringLength(100)]
		public string NguoiPhuTrach { get; set; }

		[DisplayName("Mã số công tơ")]
		[StringLength(20)]
		public string MaSoCongTo { get; set; }

		[DisplayName("Hệ số nhân")]
		[DefaultValue(1)]
		[Required]
		public int HeSoNhan { get; set; }

		[DisplayName("Kích hoạt")]
		[DefaultValue(true)]
		[Required]
		public bool KichHoat { get; set; }

		public TramBienAp()
		{

		}

		public static List<TramBienAp> GetAll()
			=> CBO.FillCollection<TramBienAp>(DataProvider.Instance.ExecuteReader("proc_GetAll_TramBienAp"));

		public static bool Add(TramBienAp tramBienAp)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_TramBienAp", tramBienAp.MaTram, tramBienAp.TenTram);
			return result > 0;
		}

		public static bool Update(TramBienAp tramBienAp)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_TramBienAp", tramBienAp.MaTram, tramBienAp.TenTram);
			return result > 0;
		}

		public static bool Delete(string id)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_TramBienAp", id);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
