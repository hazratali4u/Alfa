using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spInsertDTINVOICE_BILLTY_DETAIL
	{
		#region Private Members
		private string sp_Name = " spInsertDTINVOICE_BILLTY_DETAIL" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_DISTRIBUTOR_ID;
		private int m_TRANSPOTER_NO;
		private decimal m_TOTAL_EXPENCESS;
		private long m_SALE_INVOICE_NO;
		private string m_BILTY_NO;
		private string m_DELIVERY_CHALLAN_NO;
		#endregion


		#region Public Properties
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


		public int TRANSPOTER_NO
		{
			set
			{
				m_TRANSPOTER_NO = value ;
			}
			get
			{
				return m_TRANSPOTER_NO;
			}
		}


		public decimal TOTAL_EXPENCESS
		{
			set
			{
				m_TOTAL_EXPENCESS = value ;
			}
			get
			{
				return m_TOTAL_EXPENCESS;
			}
		}


		public long SALE_INVOICE_NO
		{
			set
			{
				m_SALE_INVOICE_NO = value ;
			}
			get
			{
				return m_SALE_INVOICE_NO;
			}
		}


		public  string BILTY_NO
		{
			set
			{
				m_BILTY_NO = value ;
			}
			get
			{
				return m_BILTY_NO;
			}
		}


		public  string DELIVERY_CHALLAN_NO
		{
			set
			{
				m_DELIVERY_CHALLAN_NO = value ;
			}
			get
			{
				return m_DELIVERY_CHALLAN_NO;
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
		public spInsertDTINVOICE_BILLTY_DETAIL()
		{
		m_DISTRIBUTOR_ID = Constants.IntNullValue;
		m_TRANSPOTER_NO = Constants.IntNullValue;
		m_TOTAL_EXPENCESS = Constants.DecimalNullValue;
		m_SALE_INVOICE_NO =  Constants.LongNullValue;
		m_BILTY_NO = null;
		m_DELIVERY_CHALLAN_NO = null;
		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "spInsertDTINVOICE_BILLTY_DETAIL";
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
				command.CommandText = "spInsertDTINVOICE_BILLTY_DETAIL";
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
				command.CommandText = "spInsertDTINVOICE_BILLTY_DETAIL";
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
				command.CommandText = "spInsertDTINVOICE_BILLTY_DETAIL";
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
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_TRANSPOTER_NO= Convert.ToInt32(dr["TRANSPOTER_NO"]);
					m_TOTAL_EXPENCESS= Convert.ToDecimal(dr["TOTAL_EXPENCESS"]);
					m_SALE_INVOICE_NO=Convert.ToInt64(dr["SALE_INVOICE_NO"]);
					m_BILTY_NO= Convert.ToString(dr["BILTY_NO"]);
					m_DELIVERY_CHALLAN_NO= Convert.ToString(dr["DELIVERY_CHALLAN_NO"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
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
			parameter.ParameterName = "@TRANSPOTER_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TRANSPOTER_NO==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSPOTER_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TOTAL_EXPENCESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_TOTAL_EXPENCESS==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TOTAL_EXPENCESS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_INVOICE_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_INVOICE_NO==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_INVOICE_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BILTY_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BILTY_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BILTY_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DELIVERY_CHALLAN_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_DELIVERY_CHALLAN_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DELIVERY_CHALLAN_NO;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
