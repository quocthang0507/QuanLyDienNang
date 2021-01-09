using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Business.Helper
{
	public static class Common
	{
		/// <summary>
		/// Kiểm tra phím vừa nhấn là số (số nguyên không dấu)
		/// </summary>
		/// <param name="e"></param>
		public static void IsDigitEvent(ref KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
				e.Handled = true;
		}

		/// <summary>
		/// Kiểm tra phím vừa nhấn là số (số thập phân)
		/// </summary>
		/// <param name="e"></param>
		/// <param name="sender"></param>
		public static void IsDecimalEvent(ref KeyPressEventArgs e, object sender = null)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
				e.Handled = true;

			// only allow one decimal point
			if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// Kiểm tra mỗi mảng các chuỗi có trống
		/// </summary>
		/// <param name="strings"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(string[] strings)
		{
			foreach (var str in strings)
			{
				if (string.IsNullOrWhiteSpace(str))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Đọc số điện trên hình ảnh bằng cách gửi yêu cầu lên server của Python và nhận phản hồi
		/// </summary>
		/// <param name="imageResult">Chỉ số điện hoặc null</param>
		/// <returns></returns>
		public static string ProcessDigitInImage(this ImageResult imageResult)
		{
			using (Image image = Image.FromFile(imageResult.DuongDan))
			{
				using (MemoryStream memory = new MemoryStream())
				{
					image.Save(memory, image.RawFormat);
					string base64 = Convert.ToBase64String(memory.ToArray());
					try
					{
						HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8000/mark");
						request.ContentType = "application/json";
						request.Method = "POST";
						using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
						{
							string str = "{\"frame\":\"" + base64 + "\"}";
							writer.WriteLine(str);
						}
						using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
						{
							string data = reader.ReadToEnd();
							if (data == "" || data == "E99")
								throw new Exception();
							return data;
						}
					}
					catch (Exception)
					{
						return null;
					}
				}
			}
		}

		public static bool ShowQuestionDialog(string text = "Xác nhận sự đồng ý của bạn để thực hiện hành động này.")
		{
			DialogResult dialog = MessageBox.Show(text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return dialog == DialogResult.Yes;
		}
	}
}
