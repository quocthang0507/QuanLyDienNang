using Business.Helper;

namespace Business.Classes
{
	public class Funcs_NhapChiSoDien
	{
		private readonly string SECTION_OCR_INI = "DocChiSoDien";
		private readonly string KEY_IMAGEFOLDER_INI = "DuongDanThuMuc";

		public string GetSavedImageFolderPath()
		{
			return Configuration.Instance.Read(KEY_IMAGEFOLDER_INI, SECTION_OCR_INI);
		}

		public void Save_ImageFolderPath(string path)
		{
			Configuration.Instance.Write(KEY_IMAGEFOLDER_INI, path, SECTION_OCR_INI);
		}

	}
}
