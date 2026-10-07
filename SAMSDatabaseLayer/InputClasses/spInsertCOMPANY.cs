using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;

namespace SAMSDatabaseLayer.Classes
{
	public class spInsertCOMPANY
	{
		#region Private Members
		private string sp_Name = " spInsertCOMPANY" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_ISCURRENT;
		private bool m_ISDELETED;
		private int m_STATUS;
		private int m_COMPANY_ID;
		private string m_EMAIL_ADDRESS;
		private string m_PHONE;
		private string m_FAX;
		private string m_WEBSITE;
		private string m_COMPANY_NAME;
		private string m_ADDRESS1;
		private string m_ADDRESS2;
		#endregion


		#region Public Properties
		public bool ISCURRENT
		{
			set
			{
				m_ISCURRENT = value ;
			}
			get
			{
				return m_ISCURRENT;
			}
		}


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


		public int STATUS
		{
			set
			{
				m_STATUS = value ;
			}
			get
			{
				return m_STATUS;
			}
		}


		public int COMPANY_ID
		{
			get
			{
				return m_COMPANY_ID;
			}
			set
			{
				m_COMPANY_ID = value;
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


		public  string WEBSITE
		{
			set
			{
				m_WEBSITE = value ;
			}
			get
			{
				return m_WEBSITE;
			}
		}


		public  string COMPANY_NAME
		{
			set
			{
				m_COMPANY_NAME = value ;
			}
			get
			{
				return m_COMPANY_NAME;
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
		public spInsertCOMPANY()
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
				cmd.CommandText = "spInsertCOMPANY";
				cmd.Connection =   m_connection;
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_COMPANY_ID = (int)((IDataParameter)(cmd.Parameters["@COMPANY_ID"])).Value;
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
				command.CommandText = "spInsertCOMPANY";
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
				command.CommandText = "spInsertCOMPANY";
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
				command.CommandText = "spInsertCOMPANY";
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


			public void FirstReader(IDataReader dr)
			{
				if(dr.Read() == true)
				{
					DataRow first_row = (DataRow)dr[0];
					m_ISCURRENT=Convert.ToBoolean(first_row["ISCURRENT"]);
					m_ISDELETED=Convert.ToBoolean(first_row["ISDELETED"]);
					m_STATUS= Convert.ToInt32(first_row["STATUS"]);
					m_COMPANY_ID= Convert.ToInt32(first_row["COMPANY_ID"]);
					m_EMAIL_ADDRESS= Convert.ToString(first_row["EMAIL_ADDRESS"]);
					m_PHONE= Convert.ToString(first_row["PHONE"]);
					m_FAX= Convert.ToString(first_row["FAX"]);
					m_WEBSITE= Convert.ToString(first_row["WEBSITE"]);
					m_COMPANY_NAME= Convert.ToString(first_row["COMPANY_NAME"]);
					m_ADDRESS1= Convert.ToString(first_row["ADDRESS1"]);
					m_ADDRESS2= Convert.ToString(first_row["ADDRESS2"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISCURRENT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISCURRENT;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISDELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISDELETED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@STATUS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_STATUS==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_STATUS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@COMPANY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
			parameter.Value = DBNull.Value;
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
			parameter.ParameterName = "@WEBSITE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_WEBSITE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_WEBSITE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@COMPANY_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_COMPANY_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_COMPANY_NAME;
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


		}
		#endregion
	}
}
