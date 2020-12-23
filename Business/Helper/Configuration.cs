using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ThuVien.Helper
{
	public class Configuration
	{
		private string Path;

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		static extern int GetPrivateProfileString(string section, string key, string @default, StringBuilder @return, int size, string filePath);

		/// <summary>
		/// Khởi tạo tập tin cấu hình Settings.ini theo mặc định
		/// </summary>
		/// <param name="fullPath"></param>
		public Configuration(string fullPath = "Settings.ini")
		{
			Path = new FileInfo(fullPath).FullName;
		}

		public string Read(string key, string section)
		{
			var @return = new StringBuilder(255);
			GetPrivateProfileString(section, key, "", @return, 255, Path);
			return @return.ToString();
		}

		public void Write(string key, string value, string section)
		{
			WritePrivateProfileString(section, key, value, Path);
		}

		public void DeleteKey(string key, string section)
		{
			Write(key, null, section);
		}

		public void DeleteSection(string section)
		{
			Write(null, null, section);
		}

		public bool KeyExists(string key, string section)
		{
			return Read(key, section).Length > 0;
		}
	}
}
