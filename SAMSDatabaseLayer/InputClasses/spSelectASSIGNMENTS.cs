using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spSelectASSIGNMENTS
	{
		#region Private Members
		private string sp_Name = " spSelectASSIGNMENTS" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private DateTime m_ASSIGN_DATE;
		private int m_USER_ID;
		private int m_IS_ACCTIVE;
		private int m_ASSIGNMENTS_ID;
		private int m_ASSIGN_TO_ID;
		private int m_ASSIGN_LOCATION_ID;
		private string m_IP_ADDRESS;
		private string m_ASSIGN_LOCATION_CODE;
		private string m_ASSIGN_LOCATION_NAME;
		private string m_ASSIGN_TYPE;
		#endregion


		#region Public Properties
		public DateTime ASSIGN_DATE
		{
			set
			{
				m_ASSIGN_DATE = value ;
			}
			get
			{
				return m_ASSIGN_DATE;
			}
		}


		public int USER_ID
		{
			set
			{
				m_USER_ID = value ;
			}
			get
			{
				return m_USER_ID;
			}
		}


		public int IS_ACCTIVE
		{
			set
			{
				m_IS_ACCTIVE = value ;
			}
			get
			{
				return m_IS_ACCTIVE;
			}
		}


		public int ASSIGNMENTS_ID
		{
			set
			{
				m_ASSIGNMENTS_ID = value ;
			}
			get
			{
				return m_ASSIGNMENTS_ID;
			}
		}


		public int ASSIGN_TO_ID
		{
			set
			{
				m_ASSIGN_TO_ID = value ;
			}
			get
			{
				return m_ASSIGN_TO_ID;
			}
		}


		public int ASSIGN_LOCATION_ID
		{
			set
			{
				m_ASSIGN_LOCATION_ID = value ;
			}
			get
			{
				return m_ASSIGN_LOCATION_ID;
			}
		}


		public  string IP_ADDRESS
		{
			set
			{
				m_IP_ADDRESS = value ;
			}
			get
			{
				return m_IP_ADDRESS;
			}
		}


		public  string ASSIGN_LOCATION_CODE
		{
			set
			{
				m_ASSIGN_LOCATION_CODE = value ;
			}
			get
			{
				return m_ASSIGN_LOCATION_CODE;
			}
		}


		public  string ASSIGN_LOCATION_NAME
		{
			set
			{
				m_ASSIGN_LOCATION_NAME = value ;
			}
			get
			{
				return m_ASSIGN_LOCATION_NAME;
			}
		}


		public  string ASSIGN_TYPE
		{
			set
			{
				m_ASSIGN_TYPE = value ;
			}
			get
			{
				return m_ASSIGN_TYPE;
			}
		}




		public IDbConnection  Connection
		{
			set
			{
				m_connection = value;
			}
			get
			{
				return m_connection;
			}
		}
		public IDbTransaction  Transaction
		{
			set
			{
				m_transaction = value;
			}
			get
			{
				return m_transaction;
			}
		}
		#endregion


		#region Constructor
		public spSelectASSIGNMENTS()
		{


		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "spSelectASSIGNMENTS";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{


			}
		}


		public IDataReader ExecuteReader()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spSelectASSIGNMENTS";
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}


		public DataTable ExecuteTable()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spSelectASSIGNMENTS";
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDbDataAdapter da = ProviderFactory.GetAdapter(EnumProviders.SQLClient);
				da.SelectCommand = command;
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds.Tables[0];
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{


			}
		}


		public string ExecuteScalar()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spSelectASSIGNMENTS";
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				object o;
				o = command.ExecuteScalar();


				return o.ToString();
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}


			public void FirstReader(IDataReader dr)
			{
				if(dr.Read())
				{
					m_ASSIGN_DATE= Convert.ToDateTime(dr["ASSIGN_DATE"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_IS_ACCTIVE= Convert.ToInt32(dr["IS_ACCTIVE"]);
					m_ASSIGNMENTS_ID= Convert.ToInt32(dr["ASSIGNMENTS_ID"]);
					m_ASSIGN_TO_ID= Convert.ToInt32(dr["ASSIGN_TO_ID"]);
					m_ASSIGN_LOCATION_ID= Convert.ToInt32(dr["ASSIGN_LOCATION_ID"]);
					m_IP_ADDRESS= Convert.ToString(dr["IP_ADDRESS"]);
					m_ASSIGN_LOCATION_CODE= Convert.ToString(dr["ASSIGN_LOCATION_CODE"]);
					m_ASSIGN_LOCATION_NAME= Convert.ToString(dr["ASSIGN_LOCATION_NAME"]);
					m_ASSIGN_TYPE= Convert.ToString(dr["ASSIGN_TYPE"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGN_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_ASSIGN_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGN_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_USER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_USER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACCTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_IS_ACCTIVE==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IS_ACCTIVE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGNMENTS_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ASSIGNMENTS_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGNMENTS_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGN_TO_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ASSIGN_TO_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGN_TO_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGN_LOCATION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ASSIGN_LOCATION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGN_LOCATION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IP_ADDRESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_IP_ADDRESS== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IP_ADDRESS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGN_LOCATION_CODE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ASSIGN_LOCATION_CODE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGN_LOCATION_CODE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGN_LOCATION_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ASSIGN_LOCATION_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGN_LOCATION_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ASSIGN_TYPE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ASSIGN_TYPE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ASSIGN_TYPE;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
