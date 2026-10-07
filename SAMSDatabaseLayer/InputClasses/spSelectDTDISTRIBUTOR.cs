using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spSelectDTDISTRIBUTOR
	{
		#region Private Members
		private string sp_Name = " spSelectDTDISTRIBUTOR" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_ISDELETED;
		private DateTime m_TIME_STAMP;
		private DateTime m_LASTUPDATE_DATE;
		private int m_USER_ID;
		private int m_SUBZONE_ID;
		private int m_DIVISION_ID;
		private int m_DIST_CLASS_ID;
		private int m_DISTRIBUTOR_ID;
		private int m_REGION_ID;
		private int m_ZONE_ID;
		private string m_CONTACT_NUMBER;
		private string m_GST_NUMBER;
		private string m_IP_ADDRESS;
		private string m_ADDRESS1;
		private string m_ADDRESS2;
		private string m_CONTACT_PERSON;
		private string m_DISTRIBUTOR_CODE;
		private string m_DISTRIBUTOR_NAME;
		private string m_PASSWORD;
		#endregion


		#region Public Properties
		public bool ISDELETED
		{
			set
			{
				m_ISDELETED = value ;
			}
			get
			{
				return m_ISDELETED;
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


		public int DIST_CLASS_ID
		{
			set
			{
				m_DIST_CLASS_ID = value ;
			}
			get
			{
				return m_DIST_CLASS_ID;
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


		public  string CONTACT_NUMBER
		{
			set
			{
				m_CONTACT_NUMBER = value ;
			}
			get
			{
				return m_CONTACT_NUMBER;
			}
		}


		public  string GST_NUMBER
		{
			set
			{
				m_GST_NUMBER = value ;
			}
			get
			{
				return m_GST_NUMBER;
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


		public  string CONTACT_PERSON
		{
			set
			{
				m_CONTACT_PERSON = value ;
			}
			get
			{
				return m_CONTACT_PERSON;
			}
		}


		public  string DISTRIBUTOR_CODE
		{
			set
			{
				m_DISTRIBUTOR_CODE = value ;
			}
			get
			{
				return m_DISTRIBUTOR_CODE;
			}
		}


		public  string DISTRIBUTOR_NAME
		{
			set
			{
				m_DISTRIBUTOR_NAME = value ;
			}
			get
			{
				return m_DISTRIBUTOR_NAME;
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
		public spSelectDTDISTRIBUTOR()
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
				cmd.CommandText = "spSelectDTDISTRIBUTOR";
				cmd.Connection =   m_connection;
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
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
				command.CommandText = "spSelectDTDISTRIBUTOR";
				command.Connection = m_connection;
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
			{
				return null;
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
				command.CommandText = "spSelectDTDISTRIBUTOR";
				command.Connection = m_connection;
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
				command.CommandText = "spSelectDTDISTRIBUTOR";
				command.Connection = m_connection;
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


////			public void FirstReader(IDataReader dr)
////			{
////				if(dr.HasRows == true)
////				{
////					DataRow first_row = dr[0];
////					m_ISDELETED=Convert.ToBoolean(first_row["ISDELETED"]);
////					m_TIME_STAMP= Convert.ToDateTime(first_row["TIME_STAMP"]);
////					m_LASTUPDATE_DATE= Convert.ToDateTime(first_row["LASTUPDATE_DATE"]);
////					m_USER_ID= Convert.ToInt32(first_row["USER_ID"]);
////					m_SUBZONE_ID= Convert.ToInt32(first_row["SUBZONE_ID"]);
////					m_DIVISION_ID= Convert.ToInt32(first_row["DIVISION_ID"]);
////					m_DIST_CLASS_ID= Convert.ToInt32(first_row["DIST_CLASS_ID"]);
////					m_DISTRIBUTOR_ID= Convert.ToInt32(first_row["DISTRIBUTOR_ID"]);
////					m_REGION_ID= Convert.ToInt32(first_row["REGION_ID"]);
////					m_ZONE_ID= Convert.ToInt32(first_row["ZONE_ID"]);
////					m_CONTACT_NUMBER= Convert.ToString(first_row["CONTACT_NUMBER"]);
////					m_GST_NUMBER= Convert.ToString(first_row["GST_NUMBER"]);
////					m_IP_ADDRESS= Convert.ToString(first_row["IP_ADDRESS"]);
////					m_ADDRESS1= Convert.ToString(first_row["ADDRESS1"]);
////					m_ADDRESS2= Convert.ToString(first_row["ADDRESS2"]);
////					m_CONTACT_PERSON= Convert.ToString(first_row["CONTACT_PERSON"]);
////					m_DISTRIBUTOR_CODE= Convert.ToString(first_row["DISTRIBUTOR_CODE"]);
////					m_DISTRIBUTOR_NAME= Convert.ToString(first_row["DISTRIBUTOR_NAME"]);
////					m_PASSWORD= Convert.ToString(first_row["PASSWORD"]);
////				}
//			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISDELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISDELETED;
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
			parameter.ParameterName = "@DIST_CLASS_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DIST_CLASS_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DIST_CLASS_ID;
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
			parameter.ParameterName = "@CONTACT_NUMBER" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CONTACT_NUMBER== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CONTACT_NUMBER;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@GST_NUMBER" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_GST_NUMBER== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GST_NUMBER;
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
			parameter.ParameterName = "@CONTACT_PERSON" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CONTACT_PERSON== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CONTACT_PERSON;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISTRIBUTOR_CODE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_DISTRIBUTOR_CODE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_CODE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISTRIBUTOR_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_DISTRIBUTOR_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_NAME;
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


		}
		#endregion
	}
}
