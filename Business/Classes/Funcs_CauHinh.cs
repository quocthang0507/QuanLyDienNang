﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace Business.Classes
{
	public class Funcs_CauHinh
	{
		private SQLConnectionString sqlConnection = new SQLConnectionString();

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

		public void GetSavedConnectionString(ref string server, ref string database, ref string username, ref string password)
		{
			sqlConnection = sqlConnection.GetSavedConnectionString();
			if (sqlConnection != null)
			{
				server = sqlConnection.ServerName;
				database = sqlConnection.Database;
				username = sqlConnection.Username;
				password = sqlConnection.Password;
			}
		}
	}
}
