using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Business.Helper
{
	/// <summary>
	/// INI là một định dạng tập tin lưu cấu hình của ứng dụng vào một tập tin trên máy tính
	/// </summary>
	public class Configuration
	{
		private readonly string Path;
		private static Configuration Singleton;

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string section, string key, string @default, StringBuilder @return, int size, string filePath);

		/// <summary>
		/// Sử dụng Singleton
		/// </summary>
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
		/// <param name="fullPath">Đường dẫn đến tập tin cấu hình. Mặc định lưu tại cùng thư mục với tập tin thực thi</param>
		public Configuration(string fullPath = "Settings.ini")
		{
			Path = new FileInfo(fullPath).FullName;
		}

		/// <summary>
		/// Đọc chuỗi theo key trong section
		/// </summary>
		/// <param name="key"></param>
		/// <param name="section"></param>
		/// <returns></returns>
		public string Read(string key, string section)
		{
			var @return = new StringBuilder(255);
			GetPrivateProfileString(section, key, "", @return, 255, Path);
			return @return.ToString();
		}

		/// <summary>
		/// Viết chuỗi có giá trị value tương ứng với key thuộc phạm vi của section
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="section"></param>
		public void Write(string key, string value, string section)
		{
			WritePrivateProfileString(section, key, value, Path);
		}

		/// <summary>
		/// Xóa giá trị theo key
		/// </summary>
		/// <param name="key"></param>
		/// <param name="section"></param>
		public void DeleteKey(string key, string section)
		{
			Write(key, null, section);
		}

		/// <summary>
		/// Xóa toàn bộ key và value trong section
		/// </summary>
		/// <param name="section"></param>
		public void DeleteSection(string section)
		{
			Write(null, null, section);
		}

		/// <summary>
		/// Kiểm tra có dữ liệu tương ứng với key trong section
		/// </summary>
		/// <param name="key"></param>
		/// <param name="section"></param>
		/// <returns></returns>
		public bool KeyExists(string key, string section)
		{
			return !string.IsNullOrWhiteSpace(Read(key, section));
		}
	}
}
