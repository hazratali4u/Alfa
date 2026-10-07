using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;

namespace SAMSDatabaseLayer.Classes
{
	public class spInsertDTROLE_DETAIL
	{
		#region Private Members
		private string sp_Name = " spInsertDTROLE_DETAIL" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_CAN_DELETE;
		private bool m_CAN_VIEW;
		private bool m_CAN_ADD;
		private bool m_CAN_UPDATE;
		private int m_ROLE_ID;
		private int m_MODULE_ID;
		private int m_ROLE_DETAIL_ID;
		#endregion


		#region Public Properties
		public bool CAN_DELETE
		{
			set
			{
				m_CAN_DELETE = value ;
			}
			get
			{
				return m_CAN_DELETE;
			}
		}


		public bool CAN_VIEW
		{
			set
			{
				m_CAN_VIEW = value ;
			}
			get
			{
				return m_CAN_VIEW;
			}
		}


		public bool CAN_ADD
		{
			set
			{
				m_CAN_ADD = value ;
			}
			get
			{
				return m_CAN_ADD;
			}
		}


		public bool CAN_UPDATE
		{
			set
			{
				m_CAN_UPDATE = value ;
			}
			get
			{
				return m_CAN_UPDATE;
			}
		}


		public int ROLE_ID
		{
			set
			{
				m_ROLE_ID = value ;
			}
			get
			{
				return m_ROLE_ID;
			}
		}


		public int MODULE_ID
		{
			set
			{
				m_MODULE_ID = value ;
			}
			get
			{
				return m_MODULE_ID;
			}
		}


		public int ROLE_DETAIL_ID
		{
			set
			{
				m_ROLE_DETAIL_ID = value ;
			}
			get
			{
				return m_ROLE_DETAIL_ID;
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
		public spInsertDTROLE_DETAIL()
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
				cmd.CommandText = "spInsertDTROLE_DETAIL";
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
				if(e.Message.StartsWith("Violation of PRIMARY KEY constraint"))
				{
					return false;
				}
				else 
				{
					throw e;
				}
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
				command.CommandText = "spInsertDTROLE_DETAIL";
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
				command.CommandText = "spInsertDTROLE_DETAIL";
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
				command.CommandText = "spInsertDTROLE_DETAIL";
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
					m_CAN_DELETE=Convert.ToBoolean(dr["CAN_DELETE"]);
					m_CAN_VIEW=Convert.ToBoolean(dr["CAN_VIEW"]);
					m_CAN_ADD=Convert.ToBoolean(dr["CAN_ADD"]);
					m_CAN_UPDATE=Convert.ToBoolean(dr["CAN_UPDATE"]);
					m_ROLE_ID= Convert.ToInt32(dr["ROLE_ID"]);
					m_MODULE_ID= Convert.ToInt32(dr["MODULE_ID"]);
					m_ROLE_DETAIL_ID= Convert.ToInt32(dr["ROLE_DETAIL_ID"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CAN_DELETE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_CAN_DELETE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CAN_VIEW" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_CAN_VIEW;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CAN_ADD" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_CAN_ADD;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CAN_UPDATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_CAN_UPDATE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ROLE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ROLE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ROLE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MODULE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_MODULE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MODULE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ROLE_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ROLE_DETAIL_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ROLE_DETAIL_ID;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
