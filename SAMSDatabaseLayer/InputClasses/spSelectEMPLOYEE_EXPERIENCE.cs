using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spSelectEMPLOYEE_EXPERIENCE
	{
		#region Private Members
		private string sp_Name = " spSelectEMPLOYEE_EXPERIENCE" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_EMPLOYEE_ID;
		private decimal m_SALARY;
		private string m_ORGANIZATION;
		private string m_FROM_DATE;
		private string m_TO_DATE;
		private string m_DESIGNATION;
		private string m_PHONE;
		private string m_BUSINESS_TYPE;
		#endregion


		#region Public Properties
		public int EMPLOYEE_ID
		{
			set
			{
				m_EMPLOYEE_ID = value ;
			}
			get
			{
				return m_EMPLOYEE_ID;
			}
		}


		public decimal SALARY
		{
			set
			{
				m_SALARY = value ;
			}
			get
			{
				return m_SALARY;
			}
		}


		public  string ORGANIZATION
		{
			set
			{
				m_ORGANIZATION = value ;
			}
			get
			{
				return m_ORGANIZATION;
			}
		}


		public  string FROM_DATE
		{
			set
			{
				m_FROM_DATE = value ;
			}
			get
			{
				return m_FROM_DATE;
			}
		}


		public  string TO_DATE
		{
			set
			{
				m_TO_DATE = value ;
			}
			get
			{
				return m_TO_DATE;
			}
		}


		public  string DESIGNATION
		{
			set
			{
				m_DESIGNATION = value ;
			}
			get
			{
				return m_DESIGNATION;
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


		public  string BUSINESS_TYPE
		{
			set
			{
				m_BUSINESS_TYPE = value ;
			}
			get
			{
				return m_BUSINESS_TYPE;
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
		public spSelectEMPLOYEE_EXPERIENCE()
		{
	        m_EMPLOYEE_ID = Constants.IntNullValue;
		    m_SALARY = Constants.DecimalNullValue;
		    m_ORGANIZATION = null;
		    m_FROM_DATE = null;
		    m_TO_DATE = null;
		    m_DESIGNATION = null;
		    m_PHONE = null;
		    m_BUSINESS_TYPE = null;

		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "spSelectEMPLOYEE_EXPERIENCE";
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
				command.CommandText = "spSelectEMPLOYEE_EXPERIENCE";
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
				command.CommandText = "spSelectEMPLOYEE_EXPERIENCE";
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
				command.CommandText = "spSelectEMPLOYEE_EXPERIENCE";
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
					m_EMPLOYEE_ID= Convert.ToInt32(dr["EMPLOYEE_ID"]);
					m_SALARY= Convert.ToDecimal(dr["SALARY"]);
					m_ORGANIZATION= Convert.ToString(dr["ORGANIZATION"]);
					m_FROM_DATE= Convert.ToString(dr["FROM_DATE"]);
					m_TO_DATE= Convert.ToString(dr["TO_DATE"]);
					m_DESIGNATION= Convert.ToString(dr["DESIGNATION"]);
					m_PHONE= Convert.ToString(dr["PHONE"]);
					m_BUSINESS_TYPE= Convert.ToString(dr["BUSINESS_TYPE"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EMPLOYEE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_EMPLOYEE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EMPLOYEE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALARY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_SALARY==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALARY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ORGANIZATION" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ORGANIZATION== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ORGANIZATION;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FROM_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FROM_DATE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FROM_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TO_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_TO_DATE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TO_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DESIGNATION" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_DESIGNATION== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DESIGNATION;
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
			parameter.ParameterName = "@BUSINESS_TYPE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BUSINESS_TYPE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BUSINESS_TYPE;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
