using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien.Classes
{
	public class Funcs_CauHinh
	{
		private SQLConnectionString sqlConnection;

		public static List<string> GetServers()
		{
			List<string> servers = new List<string>();
			string ComputerName = Environment.MachineName;
			RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
			using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
			{
				RegistryKey InstanceName = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
				if (InstanceName != null)
				{
					foreach (var instanceName in InstanceName.GetValueNames())
					{
						servers.Add(ComputerName + "\\" + instanceName);
					}
				}
			}
			return servers;
		}

		public bool TestConnectionString(string server, string database)
		{
			sqlConnection = new SQLConnectionString(server, database);
			return sqlConnection.TestConnection();
		}

		public bool TestConnectionString(string server, string database, string username, string password)
		{
			sqlConnection = new SQLConnectionString(server, database, username, password);
			return sqlConnection.TestConnection();
		}

		public void SaveConnectionString()
		{
			if (sqlConnection != null)
				sqlConnection.SaveConnectionString();
		}

		public string GetConnectionString()
		{
			if (sqlConnection != null)
				return sqlConnection.GetSavedConnectionString();
			return null;
		}
	}
}
