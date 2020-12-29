using System.Collections.Generic;
using System.Linq;

namespace Business.Classes
{
	public class Funcs_XuatKhachHang
	{
		public List<KhachHang> FilterTable(string diaChi, string maBangGia, string maTram, string tenNganHang)
		{
			List<KhachHang> list = KhachHang.All();
			if (!string.IsNullOrWhiteSpace(diaChi))
				list = list.Where(khach => khach.DiaChi.Contains(diaChi)).ToList();
			if (!string.IsNullOrWhiteSpace(maBangGia))
				list = list.Where(khach => khach.MaBangGia.Equals(maBangGia)).ToList();
			if (!string.IsNullOrWhiteSpace(maTram))
				list = list.Where(khach => khach.MaTram.Equals(maTram)).ToList();
			if (!string.IsNullOrWhiteSpace(tenNganHang))
				list = list.Where(khach => khach.TenNganHang.Contains(tenNganHang)).ToList();
			return list;
		}
	}
}
