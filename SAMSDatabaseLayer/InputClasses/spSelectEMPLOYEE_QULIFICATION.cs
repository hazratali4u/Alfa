using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spSelectEMPLOYEE_QULIFICATION
	{
		#region Private Members
		private string sp_Name = " spSelectEMPLOYEE_QULIFICATION" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_EMPLOYEE_ID;
		private string m_INSTUTITION_NAME;
		private string m_FROM_DATE;
		private string m_TO_DATE;
		private string m_EDUCATION_ACHIVEMENT;
		private string m_MAJ_SUBJECT;
		private char m_DEVISION;
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


		public  string INSTUTITION_NAME
		{
			set
			{
				m_INSTUTITION_NAME = value ;
			}
			get
			{
				return m_INSTUTITION_NAME;
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


		public  string EDUCATION_ACHIVEMENT
		{
			set
			{
				m_EDUCATION_ACHIVEMENT = value ;
			}
			get
			{
				return m_EDUCATION_ACHIVEMENT;
			}
		}


		public  string MAJ_SUBJECT
		{
			set
			{
				m_MAJ_SUBJECT = value ;
			}
			get
			{
				return m_MAJ_SUBJECT;
			}
		}


		public char DEVISION
		{
			set
			{
				m_DEVISION = value ;
			}
			get
			{
				return m_DEVISION;
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
		public spSelectEMPLOYEE_QULIFICATION()
		{
           m_EMPLOYEE_ID = Constants.IntNullValue ;
		   m_INSTUTITION_NAME = null;
		   m_FROM_DATE = null;
		   m_TO_DATE = null;
		   m_EDUCATION_ACHIVEMENT = null;
		   m_MAJ_SUBJECT = null;
		   m_DEVISION = Constants.CharNullValue;

		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "spSelectEMPLOYEE_QULIFICATION";
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
				command.CommandText = "spSelectEMPLOYEE_QULIFICATION";
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
				command.CommandText = "spSelectEMPLOYEE_QULIFICATION";
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
				command.CommandText = "spSelectEMPLOYEE_QULIFICATION";
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
					m_INSTUTITION_NAME= Convert.ToString(dr["INSTUTITION_NAME"]);
					m_FROM_DATE= Convert.ToString(dr["FROM_DATE"]);
					m_TO_DATE= Convert.ToString(dr["TO_DATE"]);
					m_EDUCATION_ACHIVEMENT= Convert.ToString(dr["EDUCATION_ACHIVEMENT"]);
					m_MAJ_SUBJECT= Convert.ToString(dr["MAJ_SUBJECT"]);
					m_DEVISION= Convert.ToChar(dr["DEVISION"]);
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
			parameter.ParameterName = "@INSTUTITION_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_INSTUTITION_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_INSTUTITION_NAME;
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
			parameter.ParameterName = "@EDUCATION_ACHIVEMENT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_EDUCATION_ACHIVEMENT== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EDUCATION_ACHIVEMENT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MAJ_SUBJECT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MAJ_SUBJECT== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MAJ_SUBJECT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DEVISION" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.NChar);
			if(m_DEVISION==null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DEVISION;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
