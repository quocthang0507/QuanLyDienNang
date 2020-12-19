using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVien.Classes;

namespace ThuVien
{
	public static class Common
	{
		public static void IsDigitEvent(ref KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
				e.Handled = true;
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
					image.Save((Stream)memory, image.RawFormat);
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
	}
}
