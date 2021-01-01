using System;

namespace Business.Helper
{
	/// <summary>
	/// Hàm đọc số thành chữ:
	/// 123 => một trăm hai ba đồng,
	/// 1.123.000 => một triệu một trăm hai ba nghìn đồng,
	/// 1.123.345.000 => một tỉ một trăm hai ba triệu ba trăm bốn lăm ngàn đồng
	/// </summary>
	public class VietnameseNumber2Text
	{
		private string[] Digit = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
		private long Number;

		public VietnameseNumber2Text(long number)
		{
			Number = number;
		}

		/// <summary>
		/// Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
		/// </summary>
		/// <param name="number"></param>
		/// <param name="full"></param>
		/// <returns></returns>
		private string ReadTens(long number, bool full)
		{
			string str = "";
			// Hàm để lấy số hàng chục ví dụ 21/10 = 2
			long tens = Convert.ToInt64(Math.Floor((double)(number / 10)));
			// Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
			long ones = number % 10;
			// Nếu số hàng chục tồn tại tức >=20
			if (tens > 1)
			{
				str = " " + Digit[tens] + " mươi";
				if (ones == 1)
				{
					str += " mốt";
				}
			}
			else if (tens == 1)
			{
				// Số hàng chục từ 10-19
				str = " mười";
				if (ones == 1)
				{
					str += " một";
				}
			}
			else if (full && ones > 0)
			{
				// Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
				str = " lẻ";
			}
			if (ones == 5 && tens >= 1)
			{
				// Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
				str += " lăm";
			}
			else if (ones > 1 || (ones == 1 && tens == 0))
			{
				str += " " + Digit[ones];
			}
			return str;
		}

		/// <summary>
		/// Đọc hàng trăm
		/// </summary>
		/// <param name="number"></param>
		/// <param name="full"></param>
		/// <returns></returns>
		private string ReadHundreds(long number, bool full)
		{
			// Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
			long hundreds = Convert.ToInt64(Math.Floor((double)number / 100));
			// Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
			number %= 100;
			string str;
			if (full || hundreds > 0)
			{
				str = " " + Digit[hundreds] + " trăm";
				str += ReadTens(number, true);
			}
			else
			{
				str = ReadTens(number, false);
			}
			return str;
		}

		/// <summary>
		/// Đọc hàng triệu
		/// </summary>
		/// <param name="number"></param>
		/// <param name="full"></param>
		/// <returns></returns>
		private string ReadMillions(long number, bool full)
		{
			string str = "";
			// Lấy số hàng triệu
			long millions = Convert.ToInt64(Math.Floor((double)number / 1000000));
			// Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
			number %= 1000000;
			if (millions > 0)
			{
				str = ReadHundreds(millions, full) + " triệu";
				full = true;
			}
			// Lấy số hàng nghìn
			long thousands = Convert.ToInt64(Math.Floor((double)number / 1000));
			// Lấy phần dư sau số hàng nghin 
			number %= 1000;
			if (thousands > 0)
			{
				str += ReadHundreds(thousands, full) + " nghìn";
				full = true;
			}
			if (number > 0)
			{
				str += ReadHundreds(number, full);
			}
			return str;
		}

		private string ConvertNumber2Text(long number)
		{
			if (number == 0)
				return Digit[0];
			string str = "", postfix = "";
			long billions;
			do
			{
				// Lấy số hàng tỷ
				billions = Convert.ToInt64(Math.Floor((double)number / 1000000000));
				// Lấy phần dư sau số hàng tỷ
				number %= 1000000000;
				if (billions > 0)
				{
					str = ReadMillions(number, true) + postfix + str;
				}
				else
				{
					str = ReadMillions(number, false) + postfix + str;
				}
				postfix = " tỷ";
			} while (billions > 0);
			return str + " đồng";
		}

		public override string ToString()
		{
			return ConvertNumber2Text(Number);
		}
	}
}
