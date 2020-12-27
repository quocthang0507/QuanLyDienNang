﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

		public static BindingSource LoadTable()
		{
			try
			{
				var binding = new BindingSource();
				var list = All();
				binding.DataSource = list;
				return binding;
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	}
}
