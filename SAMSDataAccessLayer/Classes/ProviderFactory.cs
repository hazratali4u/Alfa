using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Text;
using System.Collections;

namespace SAMSDataAccessLayer.Classes
{
	public enum EnumProviders
	{
		ODBC,
		SQLClient,
		OLEDB
	}

	public enum EnumDBTypes
	{	
		BigInt,
		Bit,
		Char,
		DateTime,
		Decimal,
		Float,
		Int,
		Money,
		NChar,
		NVarChar,
		SmallInt,
		TinyInt,
		UniqueIdentifier,
		VarChar
	}

	public struct ParamStruct
	{
		public string ParamName;
		public DbType DataType;
		public object value;
		public ParameterDirection direction;
		public string sourceColumn;
		public Int16 size;
	}

	public class ProviderFactory
	{

		// Should not be instantiated. So that is always shared
		private ProviderFactory()
		{
		}


		#region "Command"
		public static IDbCommand GetCommand(EnumProviders provider)
		{

			switch (provider) 
			{
				case EnumProviders.ODBC:
					return new OdbcCommand();
				case EnumProviders.SQLClient:
					return new SqlCommand();
				case EnumProviders.OLEDB:
					return new OleDbCommand();
				default:
					return null;
			}

		}


		public static IDbCommand GetCommand(string strCmdText, CommandType cmdType, int cmdTimeout, ParamStruct[] ParameterArray, EnumProviders provider)
		{
			IDbCommand cmd = GetCommand(provider);
			Int16 i;

			if ((ParameterArray != null))
			{
				for (i = 0; i <= ParameterArray.Length - 1; i++) 
				{
					ParamStruct ps = ParameterArray[i];
					IDbDataParameter pm = GetParameter(ps.ParamName, ps.direction, ps.value, ps.DataType, ps.sourceColumn, ps.size, provider);
					cmd.Parameters.Add(pm);
				}
			}
			cmd.CommandType = cmdType;
			cmd.CommandText = strCmdText;
			return cmd;
		}

		#endregion

		#region "Connection"
		public static IDbConnection GetConnection(EnumProviders provider)
		{

			switch (provider) 
			{
				case EnumProviders.ODBC:
					return new OdbcConnection();
				case EnumProviders.SQLClient:
					return new SqlConnection();
				case EnumProviders.OLEDB:
					return new OleDbConnection();
				default:
					return null;

			}

		}

		public static IDbConnection GetConnection(string strConnString, EnumProviders provider)
		{

			IDbConnection con = GetConnection(provider);
			if (strConnString == "")
			{
				strConnString = GetConnectionString;
			}
			strConnString = strConnString + ";App=" + provider.ToString() + " Provider";
			//strConnString = "Server=online; Database=SAMS_SERVER_FG; User Id=sa; password= 123 ";

			con.ConnectionString = strConnString;
			return con;

		}
		#endregion

		#region "DB Types"
		public static DbType GetDBType(EnumProviders provider, EnumDBTypes type)
		{

			switch (provider) 
			{
				case EnumProviders.ODBC:
					return (DbType)OdbcType.BigInt;
				case EnumProviders.SQLClient:
					if(type == EnumDBTypes.BigInt)
					{
						return (DbType)DbType.Int64;
					}
					else if(type == EnumDBTypes.Bit)
					{
						return (DbType)DbType.Boolean;
					}
					else if(type == EnumDBTypes.Char)
					{
						return (DbType)DbType.String;
					}
					else if(type == EnumDBTypes.DateTime)
					{
						return (DbType)DbType.DateTime;
					}
					else if(type == EnumDBTypes.Decimal)
					{
						return (DbType)DbType.Decimal;
					}
					else if(type == EnumDBTypes.Float)
					{
						return (DbType)DbType.Single;
					}
					else if(type == EnumDBTypes.Int)
					{
						return (DbType)DbType.Int32;
					}
					else if(type == EnumDBTypes.Money)
					{
						return (DbType)DbType.Decimal;
					}
					else if(type == EnumDBTypes.NChar)
					{
						return (DbType)DbType.String;
					}
					else if(type == EnumDBTypes.NVarChar)
					{
						return (DbType)DbType.String;
					}
					else if(type == EnumDBTypes.SmallInt)
					{
						return (DbType)DbType.Int16;
					}
					else if(type == EnumDBTypes.TinyInt)
					{
						return (DbType)DbType.Byte;
					}
					else if(type == EnumDBTypes.UniqueIdentifier)
					{
						return (DbType)DbType.String;
					}
					else if(type == EnumDBTypes.VarChar)
					{
						return (DbType)DbType.String;
					}
					else
					{
						return (DbType)DbType.String;
					}

				case EnumProviders.OLEDB:
					return (DbType)OleDbType.BigInt;
				default:
					return (DbType)OleDbType.BigInt;

			}

		}

		

		#endregion

		#region "Data Adapter"
		public static IDbDataAdapter GetAdapter(EnumProviders provider)
		{

			switch (provider) 
			{
				case EnumProviders.ODBC:
					return new OdbcDataAdapter();
				case EnumProviders.SQLClient:
					return new SqlDataAdapter();
				case EnumProviders.OLEDB:
					return new OleDbDataAdapter();
				default:
					return null;
			}

		}

		#endregion

		#region "Parameters"

		public static IDbDataParameter GetParameter(EnumProviders provider)
		{
			switch (provider) 
			{
				case EnumProviders.ODBC:
					return new OdbcParameter();
				case EnumProviders.SQLClient:
					return new SqlParameter();
				case EnumProviders.OLEDB:
					return new OleDbParameter();
				default:
					return null;
			}
		}

		public static IDbDataParameter GetParameter(string paramName, ParameterDirection paramDirection, object paramValue, DbType paramtype, string sourceColumn, Int16 size, EnumProviders provider)
		{
			IDbDataParameter param = GetParameter(provider);
			param.ParameterName = paramName;
			param.DbType = paramtype;
			if (size > 0)
			{
				param.Size = size;
			}
			if ((paramValue != null))
			{
				param.Value = paramValue;
			}
			param.Direction = paramDirection;
			if (!(sourceColumn == ""))
			{
				param.SourceColumn = sourceColumn;
			}
			return param;
		}

		#endregion

		#region "Transaction"

		public static IDbTransaction GetTransaction(IDbConnection conn, IsolationLevel transisolationLevel)
		{
			return conn.BeginTransaction(transisolationLevel);
		}

		public static IDbTransaction GetTransaction(IDbConnection conn)
		{
			return conn.BeginTransaction();
		}


		#endregion

		#region "CommandBuilder"
		public static object GetCommandBuilder(EnumProviders provider)
		{
			switch (provider) 
			{
				case EnumProviders.ODBC:
					return new OdbcCommandBuilder();
				case EnumProviders.SQLClient:
					return new SqlCommandBuilder();
				case EnumProviders.OLEDB:
					return new OleDbCommandBuilder();
					default:
					return null;

			}
		}


		#endregion

		// Get the configuration settings
		#region "Settings"
		public static string GetConnectionString 
		{
			get { return ConfigurationSettings.AppSettings.Get("ConnectionString"); }
		}
		public static EnumProviders GetProvider 
		{
			get 
			{ 
				//return (EnumProviders)ConfigurationSettings.AppSettings.Get("Provider"); 
				return EnumProviders.SQLClient;
			}
		}

		#endregion

	}
}
