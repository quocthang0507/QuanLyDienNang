using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;

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

		public TramBienAp()
		{

		}

		public TramBienAp(string maTram, string tenTram)
		{
			MaTram = maTram;
			TenTram = tenTram;
		}

		public static List<TramBienAp> All()
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
