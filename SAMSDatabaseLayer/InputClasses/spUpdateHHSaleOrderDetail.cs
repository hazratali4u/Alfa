using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes 
{
	public class spUpdateHHSaleOrderDetail
	{
		#region Private Members
		private string sp_Name = " spUpdateHHSaleOrderDetail" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_SALE_INVOICE_DETAIL_ID;
		private long m_HHSaleOrderDetailId;
		private long m_HHSaleOrderId;
		private long m_SALE_ORDER_DETAIL_ID;
		private bool m_IS_ACTIVE;
		private string m_GSTOn;
		private DateTime m_IMPORT_DATE;
		private DateTime m_TIME_STAMP;
		private DateTime m_LASTUPDATE_DATE;
		private double  m_GSTRate;
		private double  m_StdDiscountPercent;
		private double  m_SchDiscountPercent;
		private int m_DISTRIBUTOR_ID;
		private int m_IMPORT_BATCH_NO;
		private int m_SKUId;
		private int m_QuantityUnit;
		private int m_DEVICE_ID;
		private decimal m_SchDiscountAmount;
		private decimal m_GSTAmount;
		private decimal m_Amount;
		private decimal m_NetAmount;
		private decimal m_StdDiscountAmount;
		private decimal m_TradePriceUnit;
		private decimal m_RetailPriceUnit;
		private decimal m_TaxPriceUnit;
		private string m_SKUCode;
		private string m_SKUName;
		private string m_BatchNumber;
		#endregion


		#region Public Properties
		public long SALE_INVOICE_DETAIL_ID
		{
			set
			{
				m_SALE_INVOICE_DETAIL_ID = value ;
			}
			get
			{
				return m_SALE_INVOICE_DETAIL_ID;
			}
		}


		public long HHSaleOrderDetailId
		{
			set
			{
				m_HHSaleOrderDetailId = value ;
			}
			get
			{
				return m_HHSaleOrderDetailId;
			}
		}


		public long HHSaleOrderId
		{
			set
			{
				m_HHSaleOrderId = value ;
			}
			get
			{
				return m_HHSaleOrderId;
			}
		}


		public long SALE_ORDER_DETAIL_ID
		{
			set
			{
				m_SALE_ORDER_DETAIL_ID = value ;
			}
			get
			{
				return m_SALE_ORDER_DETAIL_ID;
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


		public string GSTOn
		{
			set
			{
				m_GSTOn = value ;
			}
			get
			{
				return m_GSTOn;
			}
		}


		public DateTime IMPORT_DATE
		{
			set
			{
				m_IMPORT_DATE = value ;
			}
			get
			{
				return m_IMPORT_DATE;
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


		public double GSTRate
		{
			set
			{
				m_GSTRate = value ;
			}
			get
			{
				return m_GSTRate;
			}
		}


		public double StdDiscountPercent
		{
			set
			{
				m_StdDiscountPercent = value ;
			}
			get
			{
				return m_StdDiscountPercent;
			}
		}


		public double SchDiscountPercent
		{
			set
			{
				m_SchDiscountPercent = value ;
			}
			get
			{
				return m_SchDiscountPercent;
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


		public int IMPORT_BATCH_NO
		{
			set
			{
				m_IMPORT_BATCH_NO = value ;
			}
			get
			{
				return m_IMPORT_BATCH_NO;
			}
		}


		public int SKUId
		{
			set
			{
				m_SKUId = value ;
			}
			get
			{
				return m_SKUId;
			}
		}


		public int QuantityUnit
		{
			set
			{
				m_QuantityUnit = value ;
			}
			get
			{
				return m_QuantityUnit;
			}
		}


		public int DEVICE_ID
		{
			set
			{
				m_DEVICE_ID = value ;
			}
			get
			{
				return m_DEVICE_ID;
			}
		}


		public decimal  SchDiscountAmount
		{
			set
			{
				m_SchDiscountAmount = value ;
			}
			get
			{
				return m_SchDiscountAmount;
			}
		}


		public decimal  GSTAmount
		{
			set
			{
				m_GSTAmount = value ;
			}
			get
			{
				return m_GSTAmount;
			}
		}


		public decimal  Amount
		{
			set
			{
				m_Amount = value ;
			}
			get
			{
				return m_Amount;
			}
		}


		public decimal  NetAmount
		{
			set
			{
				m_NetAmount = value ;
			}
			get
			{
				return m_NetAmount;
			}
		}


		public decimal  StdDiscountAmount
		{
			set
			{
				m_StdDiscountAmount = value ;
			}
			get
			{
				return m_StdDiscountAmount;
			}
		}


		public decimal  TradePriceUnit
		{
			set
			{
				m_TradePriceUnit = value ;
			}
			get
			{
				return m_TradePriceUnit;
			}
		}


		public decimal  RetailPriceUnit
		{
			set
			{
				m_RetailPriceUnit = value ;
			}
			get
			{
				return m_RetailPriceUnit;
			}
		}


		public decimal  TaxPriceUnit
		{
			set
			{
				m_TaxPriceUnit = value ;
			}
			get
			{
				return m_TaxPriceUnit;
			}
		}


		public  string SKUCode
		{
			set
			{
				m_SKUCode = value ;
			}
			get
			{
				return m_SKUCode;
			}
		}


		public  string SKUName
		{
			set
			{
				m_SKUName = value ;
			}
			get
			{
				return m_SKUName;
			}
		}


		public  string BatchNumber
		{
			set
			{
				m_BatchNumber = value ;
			}
			get
			{
				return m_BatchNumber;
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
		public spUpdateHHSaleOrderDetail()
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
				cmd.CommandText = "spUpdateHHSaleOrderDetail";
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
				command.CommandText = "spUpdateHHSaleOrderDetail";
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
				command.CommandText = "spUpdateHHSaleOrderDetail";
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
				command.CommandText = "spUpdateHHSaleOrderDetail";
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
					m_SALE_INVOICE_DETAIL_ID=Convert.ToInt64(dr["SALE_INVOICE_DETAIL_ID"]);
					m_HHSaleOrderDetailId=Convert.ToInt64(dr["HHSaleOrderDetailId"]);
					m_HHSaleOrderId=Convert.ToInt64(dr["HHSaleOrderId"]);
					m_SALE_ORDER_DETAIL_ID=Convert.ToInt64(dr["SALE_ORDER_DETAIL_ID"]);
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_GSTOn= Convert.ToString(dr["GSTOn"]);
					m_IMPORT_DATE= Convert.ToDateTime(dr["IMPORT_DATE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
					m_GSTRate= Convert.ToDouble(dr["GSTRate"]);
					m_StdDiscountPercent= Convert.ToDouble(dr["StdDiscountPercent"]);
					m_SchDiscountPercent= Convert.ToDouble(dr["SchDiscountPercent"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_IMPORT_BATCH_NO= Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
					m_SKUId= Convert.ToInt32(dr["SKUId"]);
					m_QuantityUnit= Convert.ToInt32(dr["QuantityUnit"]);
					m_DEVICE_ID= Convert.ToInt32(dr["DEVICE_ID"]);
					m_SchDiscountAmount= Convert.ToDecimal(dr["SchDiscountAmount"]);
					m_GSTAmount= Convert.ToDecimal(dr["GSTAmount"]);
					m_Amount= Convert.ToDecimal(dr["Amount"]);
					m_NetAmount= Convert.ToDecimal(dr["NetAmount"]);
					m_StdDiscountAmount= Convert.ToDecimal(dr["StdDiscountAmount"]);
					m_TradePriceUnit= Convert.ToDecimal(dr["TradePriceUnit"]);
					m_RetailPriceUnit= Convert.ToDecimal(dr["RetailPriceUnit"]);
					m_TaxPriceUnit= Convert.ToDecimal(dr["TaxPriceUnit"]);
					m_SKUCode= Convert.ToString(dr["SKUCode"]);
					m_SKUName= Convert.ToString(dr["SKUName"]);
					m_BatchNumber= Convert.ToString(dr["BatchNumber"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_INVOICE_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_INVOICE_DETAIL_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_INVOICE_DETAIL_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@HHSaleOrderDetailId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_HHSaleOrderDetailId==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_HHSaleOrderDetailId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@HHSaleOrderId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_HHSaleOrderId==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_HHSaleOrderId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_ORDER_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_ORDER_DETAIL_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_ORDER_DETAIL_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@GSTOn" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Char);
			if(m_GSTOn==null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GSTOn;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IMPORT_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_IMPORT_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IMPORT_DATE;
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
			parameter.ParameterName = "@GSTRate" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_GSTRate==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GSTRate;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@StdDiscountPercent" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_StdDiscountPercent==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_StdDiscountPercent;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SchDiscountPercent" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_SchDiscountPercent==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SchDiscountPercent;
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
			parameter.ParameterName = "@IMPORT_BATCH_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_IMPORT_BATCH_NO==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IMPORT_BATCH_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKUId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SKUId==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKUId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@QuantityUnit" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_QuantityUnit==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_QuantityUnit;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DEVICE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DEVICE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DEVICE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SchDiscountAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_SchDiscountAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SchDiscountAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@GSTAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_GSTAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GSTAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Amount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_Amount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Amount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@NetAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_NetAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_NetAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@StdDiscountAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_StdDiscountAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_StdDiscountAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TradePriceUnit" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TradePriceUnit==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TradePriceUnit;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RetailPriceUnit" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_RetailPriceUnit==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RetailPriceUnit;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TaxPriceUnit" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TaxPriceUnit==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TaxPriceUnit;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKUCode" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SKUCode== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKUCode;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKUName" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SKUName== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKUName;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BatchNumber" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BatchNumber== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BatchNumber;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
