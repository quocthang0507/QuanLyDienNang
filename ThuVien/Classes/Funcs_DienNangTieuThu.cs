using Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace ThuVien.Classes
{
	public class Funcs_DienNangTieuThu
	{
		public static IDataReader LoadTable()
		{
			try
			{
				return DataProvider.Instance.ExecuteReader();
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi thực hiện truy vấn đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	}
}
