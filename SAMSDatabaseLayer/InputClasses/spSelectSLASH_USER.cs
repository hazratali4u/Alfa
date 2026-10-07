using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spSelectSLASH_USER
	{
		#region Private Members
		private string sp_Name = " spSelectSLASH_USER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_IS_ACTIVE;
		private bool m_IS_DELETED;
		private int m_IS_DEFAULT;
		private int m_IS_SERVER_LOGIN;
		private int m_IS_DISTRIBUTOR_LOGIN;
		private int m_IS_PPC_LOGIN;
		private DateTime m_TIME_STAMP;
		private DateTime m_LASTUPDATE_DATE;
		private int m_C_USER_ID;
		private int m_TERRITORY_ID;
		private int m_USER_TYPE_ID;
		private int m_TOWN_ID;
		private int m_ROLE_ID;
		private int m_REGION_ID;
		private int m_ZONE_ID;
		private int m_USER_ID;
		private int m_DISTRIBUTOR_ID;
		private int m_DESIGNATION_ID;
		private string m_EMAIL_ADDRESS;
		private string m_IP_ADDRESS;
		private string m_ADDRESS2;
		private string m_LOGIN_ID;
		private string m_PASSWORD;
		private string m_FAX;
		private string m_MOBILE;
		private string m_ADDRESS1;
		private string m_USER_CODE;
		private string m_USER_NAME;
		private string m_PHONE;
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


		public bool IS_DELETED
		{
			set
			{
				m_IS_DELETED = value ;
			}
			get
			{
				return m_IS_DELETED;
			}
		}


		public int IS_DEFAULT
		{
			set
			{
				m_IS_DEFAULT = value ;
			}
			get
			{
				return m_IS_DEFAULT;
			}
		}


		public int IS_SERVER_LOGIN
		{
			set
			{
				m_IS_SERVER_LOGIN = value ;
			}
			get
			{
				return m_IS_SERVER_LOGIN;
			}
		}


		public int IS_DISTRIBUTOR_LOGIN
		{
			set
			{
				m_IS_DISTRIBUTOR_LOGIN = value ;
			}
			get
			{
				return m_IS_DISTRIBUTOR_LOGIN;
			}
		}


		public int IS_PPC_LOGIN
		{
			set
			{
				m_IS_PPC_LOGIN = value ;
			}
			get
			{
				return m_IS_PPC_LOGIN;
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


		public DateTime LASTUPDATE_DATE
		{
			set
			{
				m_LASTUPDATE_DATE = value ;
			}
			get
			{
				return m_LASTUPDATE_DATE;
			}
		}


		public int C_USER_ID
		{
			set
			{
				m_C_USER_ID = value ;
			}
			get
			{
				return m_C_USER_ID;
			}
		}


		public int TERRITORY_ID
		{
			set
			{
				m_TERRITORY_ID = value ;
			}
			get
			{
				return m_TERRITORY_ID;
			}
		}


		public int USER_TYPE_ID
		{
			set
			{
				m_USER_TYPE_ID = value ;
			}
			get
			{
				return m_USER_TYPE_ID;
			}
		}


		public int TOWN_ID
		{
			set
			{
				m_TOWN_ID = value ;
			}
			get
			{
				return m_TOWN_ID;
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


		public int REGION_ID
		{
			set
			{
				m_REGION_ID = value ;
			}
			get
			{
				return m_REGION_ID;
			}
		}


		public int ZONE_ID
		{
			set
			{
				m_ZONE_ID = value ;
			}
			get
			{
				return m_ZONE_ID;
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


		public int DISTRIBUTOR_ID
		{
			set
			{
				m_DISTRIBUTOR_ID = value ;
			}
			get
			{
				return m_DISTRIBUTOR_ID;
			}
		}


		public int DESIGNATION_ID
		{
			set
			{
				m_DESIGNATION_ID = value ;
			}
			get
			{
				return m_DESIGNATION_ID;
			}
		}


		public  string EMAIL_ADDRESS
		{
			set
			{
				m_EMAIL_ADDRESS = value ;
			}
			get
			{
				return m_EMAIL_ADDRESS;
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


		public  string ADDRESS2
		{
			set
			{
				m_ADDRESS2 = value ;
			}
			get
			{
				return m_ADDRESS2;
			}
		}


		public  string LOGIN_ID
		{
			set
			{
				m_LOGIN_ID = value ;
			}
			get
			{
				return m_LOGIN_ID;
			}
		}


		public  string PASSWORD
		{
			set
			{
				m_PASSWORD = value ;
			}
			get
			{
				return m_PASSWORD;
			}
		}


		public  string FAX
		{
			set
			{
				m_FAX = value ;
			}
			get
			{
				return m_FAX;
			}
		}


		public  string MOBILE
		{
			set
			{
				m_MOBILE = value ;
			}
			get
			{
				return m_MOBILE;
			}
		}


		public  string ADDRESS1
		{
			set
			{
				m_ADDRESS1 = value ;
			}
			get
			{
				return m_ADDRESS1;
			}
		}


		public  string USER_CODE
		{
			set
			{
				m_USER_CODE = value ;
			}
			get
			{
				return m_USER_CODE;
			}
		}


		public  string USER_NAME
		{
			set
			{
				m_USER_NAME = value ;
			}
			get
			{
				return m_USER_NAME;
			}
		}


		public  string PHONE
		{
			set
			{
				m_PHONE = value ;
			}
			get
			{
				return m_PHONE;
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
		public spSelectSLASH_USER()
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
				cmd.CommandText = "spSelectSLASH_USER";
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
				command.CommandText = "spSelectSLASH_USER";
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
				command.CommandText = "spSelectSLASH_USER";
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
				command.CommandText = "spSelectSLASH_USER";
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
					m_IS_DELETED=Convert.ToBoolean(dr["IS_DELETED"]);
					m_IS_DEFAULT=Convert.ToInt32(dr["IS_DEFAULT"]);
					m_IS_SERVER_LOGIN=Convert.ToInt32(dr["IS_SERVER_LOGIN"]);
					m_IS_DISTRIBUTOR_LOGIN=Convert.ToInt32(dr["IS_DISTRIBUTOR_LOGIN"]);
					m_IS_PPC_LOGIN=Convert.ToInt32(dr["IS_PPC_LOGIN"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
					m_C_USER_ID= Convert.ToInt32(dr["C_USER_ID"]);
					m_TERRITORY_ID= Convert.ToInt32(dr["TERRITORY_ID"]);
					m_USER_TYPE_ID= Convert.ToInt32(dr["USER_TYPE_ID"]);
					m_TOWN_ID= Convert.ToInt32(dr["TOWN_ID"]);
					m_ROLE_ID= Convert.ToInt32(dr["ROLE_ID"]);
					m_REGION_ID= Convert.ToInt32(dr["REGION_ID"]);
					m_ZONE_ID= Convert.ToInt32(dr["ZONE_ID"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_DESIGNATION_ID= Convert.ToInt32(dr["DESIGNATION_ID"]);
					m_EMAIL_ADDRESS= Convert.ToString(dr["EMAIL_ADDRESS"]);
					m_IP_ADDRESS= Convert.ToString(dr["IP_ADDRESS"]);
					m_ADDRESS2= Convert.ToString(dr["ADDRESS2"]);
					m_LOGIN_ID= Convert.ToString(dr["LOGIN_ID"]);
					m_PASSWORD= Convert.ToString(dr["PASSWORD"]);
					m_FAX= Convert.ToString(dr["FAX"]);
					m_MOBILE= Convert.ToString(dr["MOBILE"]);
					m_ADDRESS1= Convert.ToString(dr["ADDRESS1"]);
					m_USER_CODE= Convert.ToString(dr["USER_CODE"]);
					m_USER_NAME= Convert.ToString(dr["USER_NAME"]);
					m_PHONE= Convert.ToString(dr["PHONE"]);
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
			parameter.ParameterName = "@IS_DELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_DELETED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_DEFAULT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				if( m_IS_DEFAULT == Constants.IntNullValue )
				{
					parameter.Value = DBNull.Value;
			
				}
				else 
				if( m_IS_DEFAULT == 1 )
				{
					parameter.Value = true;
			
				}
				else if( m_IS_DEFAULT == 0)
				{
					parameter.Value = false;
				}
				
				
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_SERVER_LOGIN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				if( m_IS_SERVER_LOGIN == Constants.IntNullValue )
				{
					parameter.Value = DBNull.Value;
			
				}
				else if( m_IS_SERVER_LOGIN == 1) 
				{
					parameter.Value = true;
				
				}
				else if( m_IS_SERVER_LOGIN == 0)
				{
					parameter.Value = false;
				}

			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_DISTRIBUTOR_LOGIN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				if( m_IS_DISTRIBUTOR_LOGIN == Constants.IntNullValue )
				{
					parameter.Value = DBNull.Value;
				}	
				else if( m_IS_DISTRIBUTOR_LOGIN == 1)
				{
					parameter.Value = true;
				}
				else if( m_IS_DISTRIBUTOR_LOGIN == 0)
				{
					parameter.Value = false;
				}
				
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_PPC_LOGIN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				if( m_IS_PPC_LOGIN == Constants.IntNullValue )
				{
					parameter.Value = DBNull.Value;
				}
				else if( m_IS_PPC_LOGIN == 1 )
				{
					parameter.Value = true ;
				}
				else if( m_IS_PPC_LOGIN == 0 )
				{
					parameter.Value = false;
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
			parameter.ParameterName = "@LASTUPDATE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_LASTUPDATE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LASTUPDATE_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@C_USER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_C_USER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_C_USER_ID;
			}
			pparams.Add(parameter);


//			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
//			parameter.ParameterName = "@TERRITORY_ID" ; 
//			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
//			if(m_TERRITORY_ID==Constants.IntNullValue)
//			{
//				parameter.Value = DBNull.Value;
//			}
//			else
//			{
//				parameter.Value = m_TERRITORY_ID;
//			}
//			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_USER_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_USER_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TOWN_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TOWN_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TOWN_ID;
			}
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
			parameter.ParameterName = "@REGION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_REGION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REGION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ZONE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ZONE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ZONE_ID;
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
			parameter.ParameterName = "@DISTRIBUTOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DISTRIBUTOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DESIGNATION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DESIGNATION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DESIGNATION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EMAIL_ADDRESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_EMAIL_ADDRESS== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EMAIL_ADDRESS;
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
			parameter.ParameterName = "@ADDRESS2" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ADDRESS2== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ADDRESS2;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LOGIN_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_LOGIN_ID== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LOGIN_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PASSWORD" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_PASSWORD== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PASSWORD;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FAX" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FAX== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FAX;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MOBILE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MOBILE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MOBILE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ADDRESS1" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ADDRESS1== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ADDRESS1;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_CODE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_USER_CODE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_USER_CODE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_USER_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_USER_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PHONE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_PHONE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PHONE;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
