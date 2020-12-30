﻿using Business.Helper;

namespace Business.Classes
{
	/// <summary>
	/// Lớp chức năng cho form nhập chỉ số điện
	/// </summary>
	public class Funcs_NhapChiSoDien
	{
		private readonly string SECTION_OCR_INI = "DocChiSoDien";
		private readonly string KEY_IMAGEFOLDER_INI = "DuongDanThuMuc";

		/// <summary>
		/// Lấy đường dẫn thư mục hình ảnh đã lưu từ trước
		/// </summary>
		/// <returns></returns>
		public string GetSavedImageFolderPath()
		{
			return Configuration.Instance.Read(KEY_IMAGEFOLDER_INI, SECTION_OCR_INI);
		}

		/// <summary>
		/// Lưu đường dẫn thư mục hình ảnh vào tập tin INI
		/// </summary>
		/// <param name="path"></param>
		public void SaveImageFolderPath(string path)
		{
			Configuration.Instance.Write(KEY_IMAGEFOLDER_INI, path, SECTION_OCR_INI);
		}

	}
}
