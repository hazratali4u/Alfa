using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spUpdateSCH_RECIPIENT
	{
		#region Private Members
		private string sp_Name = " spUpdateSCH_RECIPIENT" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_IS_ACTIVE;
		private DateTime m_TIME_STAMP;
		private DateTime m_LAST_UPDATE_DATE;
		private int m_SCH_RECIPIENT_ID;
		private int m_SCHEDULE_ID;
		private int m_USER_ID;
		private string m_RECIPIENT_BCC;
		private string m_MESSAGE_TEXT;
		private string m_MESSAGE_SUBJECT;
		private string m_RECIPIENT_NAME;
		private string m_RECIPIENT_TO;
		private string m_RECIPIENT_CC;
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


		public int SCH_RECIPIENT_ID
		{
			set
			{
				m_SCH_RECIPIENT_ID = value ;
			}
			get
			{
				return m_SCH_RECIPIENT_ID;
			}
		}


		public int SCHEDULE_ID
		{
			set
			{
				m_SCHEDULE_ID = value ;
			}
			get
			{
				return m_SCHEDULE_ID;
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


		public  string RECIPIENT_BCC
		{
			set
			{
				m_RECIPIENT_BCC = value ;
			}
			get
			{
				return m_RECIPIENT_BCC;
			}
		}


		public  string MESSAGE_TEXT
		{
			set
			{
				m_MESSAGE_TEXT = value ;
			}
			get
			{
				return m_MESSAGE_TEXT;
			}
		}


		public  string MESSAGE_SUBJECT
		{
			set
			{
				m_MESSAGE_SUBJECT = value ;
			}
			get
			{
				return m_MESSAGE_SUBJECT;
			}
		}


		public  string RECIPIENT_NAME
		{
			set
			{
				m_RECIPIENT_NAME = value ;
			}
			get
			{
				return m_RECIPIENT_NAME;
			}
		}


		public  string RECIPIENT_TO
		{
			set
			{
				m_RECIPIENT_TO = value ;
			}
			get
			{
				return m_RECIPIENT_TO;
			}
		}


		public  string RECIPIENT_CC
		{
			set
			{
				m_RECIPIENT_CC = value ;
			}
			get
			{
				return m_RECIPIENT_CC;
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
		public spUpdateSCH_RECIPIENT()
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
				cmd.CommandText = "spUpdateSCH_RECIPIENT";
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
				command.CommandText = "spUpdateSCH_RECIPIENT";
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
				command.CommandText = "spUpdateSCH_RECIPIENT";
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
				command.CommandText = "spUpdateSCH_RECIPIENT";
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
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LAST_UPDATE_DATE= Convert.ToDateTime(dr["LAST_UPDATE_DATE"]);
					m_SCH_RECIPIENT_ID= Convert.ToInt32(dr["SCH_RECIPIENT_ID"]);
					m_SCHEDULE_ID= Convert.ToInt32(dr["SCHEDULE_ID"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_RECIPIENT_BCC= Convert.ToString(dr["RECIPIENT_BCC"]);
					m_MESSAGE_TEXT= Convert.ToString(dr["MESSAGE_TEXT"]);
					m_MESSAGE_SUBJECT= Convert.ToString(dr["MESSAGE_SUBJECT"]);
					m_RECIPIENT_NAME= Convert.ToString(dr["RECIPIENT_NAME"]);
					m_RECIPIENT_TO= Convert.ToString(dr["RECIPIENT_TO"]);
					m_RECIPIENT_CC= Convert.ToString(dr["RECIPIENT_CC"]);
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
			parameter.ParameterName = "@SCH_RECIPIENT_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SCH_RECIPIENT_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SCH_RECIPIENT_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SCHEDULE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SCHEDULE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SCHEDULE_ID;
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
			parameter.ParameterName = "@RECIPIENT_BCC" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_RECIPIENT_BCC== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RECIPIENT_BCC;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MESSAGE_TEXT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MESSAGE_TEXT== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MESSAGE_TEXT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MESSAGE_SUBJECT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MESSAGE_SUBJECT== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MESSAGE_SUBJECT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RECIPIENT_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_RECIPIENT_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RECIPIENT_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RECIPIENT_TO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_RECIPIENT_TO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RECIPIENT_TO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RECIPIENT_CC" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_RECIPIENT_CC== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RECIPIENT_CC;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
