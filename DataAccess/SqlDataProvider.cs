﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
	/// <summary>
	/// Lớp xử lý tham số truyền vào SQL theo kiểu C#
	/// </summary>
	public class SqlDataProvider : DataProvider
	{
		private readonly string connectionString;

		public SqlDataProvider(string connectionString)
		{
			this.connectionString = connectionString;
		}

		/// <summary>
		/// Gán từng tham số trong SQL thành các đối tượng tham số trong C#
		/// </summary>
		/// <param name="commandParameters"></param>
		/// <param name="parameterValues"></param>
		private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
		{
			if (commandParameters == null || parameterValues == null) return;
			if (commandParameters.Length != parameterValues.Length)
				throw new ArgumentException("Command parameters do not match parameter values!");
			for (int i = 0, j = commandParameters.Length; i < j; i++)
				commandParameters[i].Value = parameterValues[i];
		}

		public override DataSet ExecuteDataset(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteDataset(connectionString, spName, parameterValues);
		}

		public override int ExecuteNonQuery(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteNonQuery(connectionString, spName, parameterValues);
		}

		public override object ExecuteNonQueryWithOutput(string outputParam, string spName, params object[] parameterValues)
		{
			if (string.IsNullOrWhiteSpace(outputParam))
				throw new ArgumentException("OutputParam can't be null or empty!");
			SqlParameter[] parameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
			SqlParameter sqlParameter = null;
			foreach (SqlParameter item in parameters)
			{
				if (string.Compare(item.ParameterName, outputParam, true) == 0)
				{
					sqlParameter = item;
					break;
				}
			}
			if (sqlParameter == null)
				throw new Exception("Parameter not found!");
			AssignParameterValues(parameters, parameterValues);
			int result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, parameters);
			if (result > 0)
				return sqlParameter.Value;
			return null;
		}

		public override IDataReader ExecuteReader(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteReader(connectionString, spName, parameterValues);
		}

		public override object ExecuteScalar(string spName, params object[] parameterValues)
		{
			return SqlHelper.ExecuteScalar(connectionString, spName, parameterValues);
		}
	}
}