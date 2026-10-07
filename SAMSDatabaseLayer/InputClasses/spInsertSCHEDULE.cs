using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;



namespace SAMSDatabaseLayer.Classes
{
	public class spInsertSCHEDULE
	{
		#region Private Members
		private string sp_Name = " spInsertSCHEDULE" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_IS_ACTIVE;
		private DateTime m_EXECUTION_TIME;
		private DateTime m_TIME_STAMP;
		private DateTime m_LAST_UPDATE_DATE;
		private int m_USER_ID;
		private int m_SCHEDULE_ID;
		private int m_EXECUTION_OPTION;
		private int m_REPORT_ID;
		private int m_REPORT_FORMAT_ID;
		private int m_DATA_FROM_DAY;
		private int m_DATA_TO_MONTH;
		private int m_DATA_TO_DAY;
		private int m_FREQUENCY_ID;
		private int m_EXECUTION_DAY;
		private int m_DATA_FROM_MONTH;
		private string m_SCHEDULE_CODE;
		private string m_SCHEDULE_NAME;
		#endregion


		#region Public Properties
		public bool IS_ACTIVE
		{
			set
			{
				m_IS_ACTIVE = value ;
			}
			get
			{
				return m_IS_ACTIVE;
			}
		}


		public DateTime EXECUTION_TIME
		{
			set
			{
				m_EXECUTION_TIME = value ;
			}
			get
			{
				return m_EXECUTION_TIME;
			}
		}


		public DateTime TIME_STAMP
		{
			set
			{
				m_TIME_STAMP = value ;
			}
			get
			{
				return m_TIME_STAMP;
			}
		}


		public DateTime LAST_UPDATE_DATE
		{
			set
			{
				m_LAST_UPDATE_DATE = value ;
			}
			get
			{
				return m_LAST_UPDATE_DATE;
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


		public int SCHEDULE_ID
		{
			get
			{
				return m_SCHEDULE_ID;
			}
		}


		public int EXECUTION_OPTION
		{
			set
			{
				m_EXECUTION_OPTION = value ;
			}
			get
			{
				return m_EXECUTION_OPTION;
			}
		}


		public int REPORT_ID
		{
			set
			{
				m_REPORT_ID = value ;
			}
			get
			{
				return m_REPORT_ID;
			}
		}


		public int REPORT_FORMAT_ID
		{
			set
			{
				m_REPORT_FORMAT_ID = value ;
			}
			get
			{
				return m_REPORT_FORMAT_ID;
			}
		}


		public int DATA_FROM_DAY
		{
			set
			{
				m_DATA_FROM_DAY = value ;
			}
			get
			{
				return m_DATA_FROM_DAY;
			}
		}


		public int DATA_TO_MONTH
		{
			set
			{
				m_DATA_TO_MONTH = value ;
			}
			get
			{
				return m_DATA_TO_MONTH;
			}
		}


		public int DATA_TO_DAY
		{
			set
			{
				m_DATA_TO_DAY = value ;
			}
			get
			{
				return m_DATA_TO_DAY;
			}
		}


		public int FREQUENCY_ID
		{
			set
			{
				m_FREQUENCY_ID = value ;
			}
			get
			{
				return m_FREQUENCY_ID;
			}
		}


		public int EXECUTION_DAY
		{
			set
			{
				m_EXECUTION_DAY = value ;
			}
			get
			{
				return m_EXECUTION_DAY;
			}
		}


		public int DATA_FROM_MONTH
		{
			set
			{
				m_DATA_FROM_MONTH = value ;
			}
			get
			{
				return m_DATA_FROM_MONTH;
			}
		}


		public  string SCHEDULE_CODE
		{
			set
			{
				m_SCHEDULE_CODE = value ;
			}
			get
			{
				return m_SCHEDULE_CODE;
			}
		}


		public  string SCHEDULE_NAME
		{
			set
			{
				m_SCHEDULE_NAME = value ;
			}
			get
			{
				return m_SCHEDULE_NAME;
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
		public spInsertSCHEDULE()
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
				cmd.CommandText = "spInsertSCHEDULE";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_SCHEDULE_ID = (int)((IDataParameter)(cmd.Parameters["@SCHEDULE_ID"])).Value;
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
				command.CommandText = "spInsertSCHEDULE";
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
				command.CommandText = "spInsertSCHEDULE";
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
				command.CommandText = "spInsertSCHEDULE";
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
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_EXECUTION_TIME= Convert.ToDateTime(dr["EXECUTION_TIME"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LAST_UPDATE_DATE= Convert.ToDateTime(dr["LAST_UPDATE_DATE"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_SCHEDULE_ID= Convert.ToInt32(dr["SCHEDULE_ID"]);
					m_EXECUTION_OPTION= Convert.ToInt32(dr["EXECUTION_OPTION"]);
					m_REPORT_ID= Convert.ToInt32(dr["REPORT_ID"]);
					m_REPORT_FORMAT_ID= Convert.ToInt32(dr["REPORT_FORMAT_ID"]);
					m_DATA_FROM_DAY= Convert.ToInt32(dr["DATA_FROM_DAY"]);
					m_DATA_TO_MONTH= Convert.ToInt32(dr["DATA_TO_MONTH"]);
					m_DATA_TO_DAY= Convert.ToInt32(dr["DATA_TO_DAY"]);
					m_FREQUENCY_ID= Convert.ToInt32(dr["FREQUENCY_ID"]);
					m_EXECUTION_DAY= Convert.ToInt32(dr["EXECUTION_DAY"]);
					m_DATA_FROM_MONTH= Convert.ToInt32(dr["DATA_FROM_MONTH"]);
					m_SCHEDULE_CODE= Convert.ToString(dr["SCHEDULE_CODE"]);
					m_SCHEDULE_NAME= Convert.ToString(dr["SCHEDULE_NAME"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EXECUTION_TIME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_EXECUTION_TIME==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EXECUTION_TIME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TIME_STAMP" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TIME_STAMP==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TIME_STAMP;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LAST_UPDATE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_LAST_UPDATE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LAST_UPDATE_DATE;
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
			parameter.ParameterName = "@SCHEDULE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EXECUTION_OPTION" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_EXECUTION_OPTION==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EXECUTION_OPTION;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REPORT_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_REPORT_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REPORT_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REPORT_FORMAT_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_REPORT_FORMAT_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REPORT_FORMAT_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DATA_FROM_DAY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DATA_FROM_DAY==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DATA_FROM_DAY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DATA_TO_MONTH" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DATA_TO_MONTH==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DATA_TO_MONTH;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DATA_TO_DAY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DATA_TO_DAY==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DATA_TO_DAY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREQUENCY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FREQUENCY_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREQUENCY_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EXECUTION_DAY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_EXECUTION_DAY==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EXECUTION_DAY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DATA_FROM_MONTH" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DATA_FROM_MONTH==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DATA_FROM_MONTH;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SCHEDULE_CODE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SCHEDULE_CODE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SCHEDULE_CODE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SCHEDULE_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SCHEDULE_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SCHEDULE_NAME;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
