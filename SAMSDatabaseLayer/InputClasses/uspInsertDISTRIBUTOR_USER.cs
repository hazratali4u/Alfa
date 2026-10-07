using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class uspInsertDISTRIBUTOR_USER
	{
		#region Private Members
		private string sp_Name = " uspInsertDISTRIBUTOR_USER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_AREA_ID;
		private long m_ROUTE_ID;
		private bool m_IS_DELETED;
		private bool m_IS_DISTRIBUTOR_LOGIN;
		private bool m_IS_PPC_LOGIN;
		private bool m_IS_ACTIVE;
		private DateTime m_TIME_STAMP;
		private DateTime m_LASTUPDATE_DATE;
		private int m_USER_TYPE_ID;
		private int m_C_USER_ID;
		private int m_USER_ID;
		private int m_REGION_ID;
		private int m_ZONE_ID;
		private int m_SUBZONE_ID;
		private int m_DISTRIBUTOR_ID;
		private int m_DIVISION_ID;
		private int m_ROLE_ID;
		private string m_TYPE;
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
		public long AREA_ID
		{
			set
			{
				m_AREA_ID = value ;
			}
			get
			{
				return m_AREA_ID;
			}
		}


		public long ROUTE_ID
		{
			set
			{
				m_ROUTE_ID = value ;
			}
			get
			{
				return m_ROUTE_ID;
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


		public bool IS_DISTRIBUTOR_LOGIN
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


		public bool IS_PPC_LOGIN
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


		public int USER_ID
		{
			get
			{
				return m_USER_ID;
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


		public int SUBZONE_ID
		{
			set
			{
				m_SUBZONE_ID = value ;
			}
			get
			{
				return m_SUBZONE_ID;
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


		public int DIVISION_ID
		{
			set
			{
				m_DIVISION_ID = value ;
			}
			get
			{
				return m_DIVISION_ID;
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


		public  string TYPE
		{
			set
			{
				m_TYPE = value ;
			}
			get
			{
				return m_TYPE;
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
		public uspInsertDISTRIBUTOR_USER()
		{
		   m_AREA_ID = Constants.LongNullValue;
	       m_ROUTE_ID = Constants.LongNullValue;
		   m_IS_DELETED = false;
		   m_IS_DISTRIBUTOR_LOGIN = false;
	       m_IS_PPC_LOGIN = false;
	       m_IS_ACTIVE = false;
		   m_TIME_STAMP = Constants.DateNullValue;
		   m_LASTUPDATE_DATE = Constants.DateNullValue;
		   m_USER_TYPE_ID = Constants.IntNullValue;
		   m_C_USER_ID = Constants.IntNullValue;
		   m_USER_ID = Constants.IntNullValue;
	       m_REGION_ID = Constants.IntNullValue;
		   m_ZONE_ID = Constants.IntNullValue;
	       m_SUBZONE_ID = Constants.IntNullValue;
		   m_DISTRIBUTOR_ID = Constants.IntNullValue;
		   m_DIVISION_ID = Constants.IntNullValue;
	       m_ROLE_ID = Constants.IntNullValue;
           m_TYPE = null;
		   m_ADDRESS2 = null;
	       m_LOGIN_ID = null;
		   m_PASSWORD = null;
		   m_FAX = null;
	       m_MOBILE = null;
		   m_ADDRESS1= null;
           m_USER_CODE = null;
		   m_USER_NAME = null;
		   m_PHONE= null;


		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "uspInsertDISTRIBUTOR_USER";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_USER_ID = (int)((IDataParameter)(cmd.Parameters["@USER_ID"])).Value;
				return true;
			}
			catch(Exception e)
			{
		     	return false;

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
				command.CommandText = "uspInsertDISTRIBUTOR_USER";
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
				command.CommandText = "uspInsertDISTRIBUTOR_USER";
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
				command.CommandText = "uspInsertDISTRIBUTOR_USER";
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
					m_AREA_ID=Convert.ToInt64(dr["AREA_ID"]);
					m_ROUTE_ID=Convert.ToInt64(dr["ROUTE_ID"]);
					m_IS_DELETED=Convert.ToBoolean(dr["IS_DELETED"]);
					m_IS_DISTRIBUTOR_LOGIN=Convert.ToBoolean(dr["IS_DISTRIBUTOR_LOGIN"]);
					m_IS_PPC_LOGIN=Convert.ToBoolean(dr["IS_PPC_LOGIN"]);
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
					m_USER_TYPE_ID= Convert.ToInt32(dr["USER_TYPE_ID"]);
					m_C_USER_ID= Convert.ToInt32(dr["C_USER_ID"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_REGION_ID= Convert.ToInt32(dr["REGION_ID"]);
					m_ZONE_ID= Convert.ToInt32(dr["ZONE_ID"]);
					m_SUBZONE_ID= Convert.ToInt32(dr["SUBZONE_ID"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_DIVISION_ID= Convert.ToInt32(dr["DIVISION_ID"]);
					m_ROLE_ID= Convert.ToInt32(dr["ROLE_ID"]);
					m_TYPE= Convert.ToString(dr["TYPE"]);
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
			parameter.ParameterName = "@AREA_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_AREA_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_AREA_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ROUTE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_ROUTE_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ROUTE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_DELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_DELETED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_DISTRIBUTOR_LOGIN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_DISTRIBUTOR_LOGIN;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_PPC_LOGIN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_PPC_LOGIN;
			pparams.Add(parameter);


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


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
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
			parameter.ParameterName = "@SUBZONE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SUBZONE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SUBZONE_ID;
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
			parameter.ParameterName = "@DIVISION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DIVISION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DIVISION_ID;
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
			parameter.ParameterName = "@TYPE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_TYPE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TYPE;
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
