using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Business.Helper
{
	public class Configuration
	{
		private readonly string Path;
		private static Configuration Singleton;

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string section, string key, string @default, StringBuilder @return, int size, string filePath);

		public static Configuration Instance
		{
			get
			{
				if (Singleton == null)
					Singleton = new Configuration();
				return Singleton;
			}
		}

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
