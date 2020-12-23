namespace Business.Classes
{
	public class ImageResult
	{
		public string DuongDan { get; set; }
		public string ChiSoDien { get; set; }
		public string MaKhachHang { get; set; }

		public ImageResult(string duongDan)
		{
			DuongDan = duongDan;
			ChiSoDien = string.Empty;
			MaKhachHang = string.Empty;
		}

		public ImageResult(string duongDan, string chiSoDien, string maKhachHang)
		{
			DuongDan = duongDan;
			ChiSoDien = chiSoDien;
			MaKhachHang = maKhachHang;
		}
	}
}
