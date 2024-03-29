﻿using DataAccess;
using KGySoft.ComponentModel;
using System;
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
		[StringLength(30)]
		public string MaTram { get; set; }

		[DisplayName("Tên trạm biến áp")]
		[StringLength(150)]
		[Required]
		public string TenTram { get; set; }

		[DisplayName("Địa chỉ")]
		[StringLength(250)]
		public string DiaChi { get; set; }

		[DisplayName("Người phụ trách")]
		[StringLength(100)]
		public string NguoiPhuTrach { get; set; }

		[DisplayName("Mã số công tơ")]
		[StringLength(30)]
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

		public static bool IsDuplicatedMaTram(string maTram)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_IsDuplicated_MaTram", maTram);
			return result == 1;
		}

		public static SortableBindingList<TramBienAp> GetAll()
		{
			return CBO.FillInBindingList<TramBienAp>(DataProvider.Instance.ExecuteReader("proc_GetAll_TramBienAp"));
		}

		public static TramBienAp GetByName(string tenTram)
		{
			try
			{
				return CBO.FillObject<TramBienAp>(DataProvider.Instance.ExecuteReader("proc_GetByName_TramBienAp", tenTram));
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static bool Insert(TramBienAp tramBienAp)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Insert_TramBienAp", tramBienAp.MaTram, tramBienAp.TenTram, tramBienAp.DiaChi, tramBienAp.NguoiPhuTrach, tramBienAp.MaSoCongTo, tramBienAp.HeSoNhan);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Update(TramBienAp tramBienAp)
		{
			try
			{
				int result = DataProvider.Instance.ExecuteNonQuery("proc_Update_TramBienAp", tramBienAp.MaTram, tramBienAp.TenTram, tramBienAp.DiaChi, tramBienAp.NguoiPhuTrach, tramBienAp.MaSoCongTo, tramBienAp.HeSoNhan, tramBienAp.KichHoat);
				return result > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Delete(string id)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("proc_Delete_TramBienAp", id);
			return result > 0;
		}
	}
}
