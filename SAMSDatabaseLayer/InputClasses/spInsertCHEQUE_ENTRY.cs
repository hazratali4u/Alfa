using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;

namespace SAMSDatabaseLayer.Classes
{
	public class spInsertCHEQUE_ENTRY
	{
		#region Private Members
		private string sp_Name = " spInsertCHEQUE_ENTRY" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_AREA_ID;
		private long m_CUSTOMER_ID;
		private long m_CHEQUE_ENTRY_ID;
		private bool m_IS_ACTIVE;
		private bool m_IS_ADJUSTED;
		private DateTime m_REALIZATION_DATE;
		private DateTime m_TIME_STAMP;
		private DateTime m_CHEQUE_DATE;
		private DateTime m_RECEIVED_DATE;
		private DateTime m_DEPOSIT_DATE;
		private int m_DISTRIBUTOR_ID;
		private int m_STATUS_ID;
		private decimal m_CHEQUE_AMOUNT;
		private decimal m_ADJUSTED_AMOUNT;
		private decimal m_REALIZATION_AMOUNT;
		private string m_DEPOSIT_SLIP_NO;
		private string m_CHEQUE_NO;
		private string m_BANKNAME;
		private string m_BRANCHNAME;
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


		public long CUSTOMER_ID
		{
			set
			{
				m_CUSTOMER_ID = value ;
			}
			get
			{
				return m_CUSTOMER_ID;
			}
		}


		public long CHEQUE_ENTRY_ID
		{
			get
			{
				return m_CHEQUE_ENTRY_ID;
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


		public bool IS_ADJUSTED
		{
			set
			{
				m_IS_ADJUSTED = value ;
			}
			get
			{
				return m_IS_ADJUSTED;
			}
		}


		public DateTime REALIZATION_DATE
		{
			set
			{
				m_REALIZATION_DATE = value ;
			}
			get
			{
				return m_REALIZATION_DATE;
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


		public DateTime CHEQUE_DATE
		{
			set
			{
				m_CHEQUE_DATE = value ;
			}
			get
			{
				return m_CHEQUE_DATE;
			}
		}


		public DateTime RECEIVED_DATE
		{
			set
			{
				m_RECEIVED_DATE = value ;
			}
			get
			{
				return m_RECEIVED_DATE;
			}
		}


		public DateTime DEPOSIT_DATE
		{
			set
			{
				m_DEPOSIT_DATE = value ;
			}
			get
			{
				return m_DEPOSIT_DATE;
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


		public int STATUS_ID
		{
			set
			{
				m_STATUS_ID = value ;
			}
			get
			{
				return m_STATUS_ID;
			}
		}


		public decimal  CHEQUE_AMOUNT
		{
			set
			{
				m_CHEQUE_AMOUNT = value ;
			}
			get
			{
				return m_CHEQUE_AMOUNT;
			}
		}


		public decimal  ADJUSTED_AMOUNT
		{
			set
			{
				m_ADJUSTED_AMOUNT = value ;
			}
			get
			{
				return m_ADJUSTED_AMOUNT;
			}
		}


		public decimal  REALIZATION_AMOUNT
		{
			set
			{
				m_REALIZATION_AMOUNT = value ;
			}
			get
			{
				return m_REALIZATION_AMOUNT;
			}
		}


		public  string DEPOSIT_SLIP_NO
		{
			set
			{
				m_DEPOSIT_SLIP_NO = value ;
			}
			get
			{
				return m_DEPOSIT_SLIP_NO;
			}
		}


		public  string CHEQUE_NO
		{
			set
			{
				m_CHEQUE_NO = value ;
			}
			get
			{
				return m_CHEQUE_NO;
			}
		}


		public  string BANKNAME
		{
			set
			{
				m_BANKNAME = value ;
			}
			get
			{
				return m_BANKNAME;
			}
		}


		public  string BRANCHNAME
		{
			set
			{
				m_BRANCHNAME = value ;
			}
			get
			{
				return m_BRANCHNAME;
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
		public spInsertCHEQUE_ENTRY()
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
				cmd.CommandText = "spInsertCHEQUE_ENTRY";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_CHEQUE_ENTRY_ID = (long)((IDataParameter)(cmd.Parameters["@CHEQUE_ENTRY_ID"])).Value;
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
				command.CommandText = "spInsertCHEQUE_ENTRY";
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
				command.CommandText = "spInsertCHEQUE_ENTRY";
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
				command.CommandText = "spInsertCHEQUE_ENTRY";
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
					m_CUSTOMER_ID=Convert.ToInt64(dr["CUSTOMER_ID"]);
					m_CHEQUE_ENTRY_ID=Convert.ToInt64(dr["CHEQUE_ENTRY_ID"]);
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_IS_ADJUSTED=Convert.ToBoolean(dr["IS_ADJUSTED"]);
					m_REALIZATION_DATE= Convert.ToDateTime(dr["REALIZATION_DATE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_CHEQUE_DATE= Convert.ToDateTime(dr["CHEQUE_DATE"]);
					m_RECEIVED_DATE= Convert.ToDateTime(dr["RECEIVED_DATE"]);
					m_DEPOSIT_DATE= Convert.ToDateTime(dr["DEPOSIT_DATE"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_STATUS_ID= Convert.ToInt32(dr["STATUS_ID"]);
					m_CHEQUE_AMOUNT= Convert.ToDecimal(dr["CHEQUE_AMOUNT"]);
					m_ADJUSTED_AMOUNT= Convert.ToDecimal(dr["ADJUSTED_AMOUNT"]);
					m_REALIZATION_AMOUNT= Convert.ToDecimal(dr["REALIZATION_AMOUNT"]);
					m_DEPOSIT_SLIP_NO= Convert.ToString(dr["DEPOSIT_SLIP_NO"]);
					m_CHEQUE_NO= Convert.ToString(dr["CHEQUE_NO"]);
					m_BANKNAME= Convert.ToString(dr["BANKNAME"]);
					m_BRANCHNAME= Convert.ToString(dr["BRANCHNAME"]);
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
			parameter.ParameterName = "@CUSTOMER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_CUSTOMER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CUSTOMER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CHEQUE_ENTRY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ADJUSTED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ADJUSTED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REALIZATION_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_REALIZATION_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REALIZATION_DATE;
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
			parameter.ParameterName = "@CHEQUE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_CHEQUE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CHEQUE_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RECEIVED_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_RECEIVED_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RECEIVED_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DEPOSIT_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_DEPOSIT_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DEPOSIT_DATE;
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
			parameter.ParameterName = "@STATUS_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_STATUS_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_STATUS_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CHEQUE_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_CHEQUE_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CHEQUE_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ADJUSTED_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_ADJUSTED_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ADJUSTED_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REALIZATION_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_REALIZATION_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REALIZATION_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DEPOSIT_SLIP_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_DEPOSIT_SLIP_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DEPOSIT_SLIP_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CHEQUE_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CHEQUE_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CHEQUE_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BANKNAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BANKNAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BANKNAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BRANCHNAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BRANCHNAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BRANCHNAME;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
