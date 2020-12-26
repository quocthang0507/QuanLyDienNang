using DataAccess;

namespace Business.Classes
{
	public class Funcs_Main
	{
		public bool CheckConnectionString()
		{
			if (string.IsNullOrWhiteSpace(DataProvider.ConnectionString))
			{
				Funcs_ConnectionString funcs = new Funcs_ConnectionString();
				if (funcs.sqlConnectionString != null)
				{
					DataProvider.ConnectionString = funcs.sqlConnectionString.ConnectionString;
					return true;
				}
				return false;
			}
			return true;
		}

		public string GetSQLServerName()
		{
			Funcs_ConnectionString funcs = new Funcs_ConnectionString();
			if (funcs.sqlConnectionString != null)
				return funcs.sqlConnectionString.ServerName;
			return null;
		}

		public string GetDatabase()
		{
			Funcs_ConnectionString funcs = new Funcs_ConnectionString();
			if (funcs.sqlConnectionString != null)
				return funcs.sqlConnectionString.Database;
			return null;
		}
	}
}
