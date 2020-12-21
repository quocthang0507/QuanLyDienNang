using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ThuVien.Classes;

namespace ThuVien.Helper
{
	public class FileUtils
	{
		public static string GetAbsolutePath(Assembly assembly, string relativePath)
		{
			string assemblyFolderPath = new FileInfo(assembly.Location).Directory.FullName;
			return Path.GetFullPath(Path.Combine(assemblyFolderPath, relativePath));
		}

		public static IEnumerable<ImageResult> LoadImagesFromDirectory(string pathToImageFolder)
		{
			try
			{
				IEnumerable<string> imagesPaths = Directory.
					GetFiles(pathToImageFolder, "*", SearchOption.AllDirectories).
					Where(file => Path.GetExtension(file).Equals(".jpg", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(file).Equals(".png", StringComparison.OrdinalIgnoreCase)).
					OrderBy(file => Path.GetFileName(file));
				return imagesPaths.Select(path => new ImageResult(path));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
