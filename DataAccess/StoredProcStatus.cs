using System;

namespace DataAccess
{
	public class StoredProcStatus
	{
		public Exception ReturnMessage(int status)
		{
			switch (status)
			{
				case -1:
					return new Exception("Missing object");
				case -2:
					return new Exception("Datatype error");
				case -3:
					return new Exception("Process was chosen as deadlock victim");
				case -4:
					return new Exception("Permission error");
				case -5:
					return new Exception("Syntax error");
				case -6:
					return new Exception("Miscellaneous user error");
				case -7:
					return new Exception("Resource error, such as out of space");
				case -8:
					return new Exception("Nonfatal internal problem");
				case -9:
					return new Exception("System limit was reached");
				case -10:
					return new Exception("Fatal internal inconsistency");
				case -11:
					return new Exception("Fatal internal inconsistency");
				case -12:
					return new Exception("Table or index is corrupt");
				case -13:
					return new Exception("Database is corrupt");
				case -14:
					return new Exception("Hardware error");
				default:
					return new Exception();
			}
		}
	}
}
