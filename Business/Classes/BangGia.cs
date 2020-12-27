using DataAccess;
using System;
using System.Collections.Generic;

namespace Business.Classes
{
	public class BangGia
	{
		public string MaBangGia { get; set; }
		public string TenBangGia { get; set; }

		public BangGia()
		{

		}

		public BangGia(string maBangGia, string tenBangGia)
		{
			MaBangGia = maBangGia;
			TenBangGia = tenBangGia;
		}

		public static List<BangGia> All()
			=> CBO.FillCollection<BangGia>(DataProvider.Instance.ExecuteReader("proc_GetAll_BangGia"));

		public static bool Add(BangGia bangGia)
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
