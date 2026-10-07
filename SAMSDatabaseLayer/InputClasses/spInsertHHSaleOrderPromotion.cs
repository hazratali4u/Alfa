using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes 
{
	public class spInsertHHSaleOrderPromotion
	{
		#region Private Members
		private string sp_Name = " spInsertHHSaleOrderPromotion" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_SALE_INVOICE_PROMOTION_ID;
		private long m_HHSaleOrderId;
		private long m_HHSaleOrderDetailId;
		private long m_SALE_ORDER_PROMOTION_ID;
		private bool m_IsScheme;
		private bool m_IS_ACTIVE;
		private DateTime m_IMPORT_DATE;
		private DateTime m_TIME_STAMP;
		private DateTime m_LASTUPDATE_DATE;
		private double  m_GSTRate;
		private double  m_DiscountPercent;
		private int m_IMPORT_BATCH_NO;
		private int m_FreeQuantity;
		private int m_DEVICE_ID;
		private int m_DISTRIBUTOR_ID;
		private int m_HHSaleOrderPromotionId;
		private int m_PromotionOfferId;
		private int m_FreeSKUId;
		private decimal m_DiscountAmount;
		private decimal m_ClaimAmount;
		private decimal m_TradePriceUnit;
		private decimal m_RetailPriceUnit;
		private decimal m_GSTAmount;
		private string m_FreeSKUCode;
		private string m_FreeSKUName;
		#endregion


		#region Public Properties
		public long SALE_INVOICE_PROMOTION_ID
		{
			set
			{
				m_SALE_INVOICE_PROMOTION_ID = value ;
			}
			get
			{
				return m_SALE_INVOICE_PROMOTION_ID;
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


		public long SALE_ORDER_PROMOTION_ID
		{
			set
			{
				m_SALE_ORDER_PROMOTION_ID = value ;
			}
			get
			{
				return m_SALE_ORDER_PROMOTION_ID;
			}
		}


		public bool IsScheme
		{
			set
			{
				m_IsScheme = value ;
			}
			get
			{
				return m_IsScheme;
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


		public double DiscountPercent
		{
			set
			{
				m_DiscountPercent = value ;
			}
			get
			{
				return m_DiscountPercent;
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


		public int FreeQuantity
		{
			set
			{
				m_FreeQuantity = value ;
			}
			get
			{
				return m_FreeQuantity;
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


		public int HHSaleOrderPromotionId
		{
			set
			{
				m_HHSaleOrderPromotionId = value ;
			}
			get
			{
				return m_HHSaleOrderPromotionId;
			}
		}


		public int PromotionOfferId
		{
			set
			{
				m_PromotionOfferId = value ;
			}
			get
			{
				return m_PromotionOfferId;
			}
		}


		public int FreeSKUId
		{
			set
			{
				m_FreeSKUId = value ;
			}
			get
			{
				return m_FreeSKUId;
			}
		}


		public decimal  DiscountAmount
		{
			set
			{
				m_DiscountAmount = value ;
			}
			get
			{
				return m_DiscountAmount;
			}
		}


		public decimal  ClaimAmount
		{
			set
			{
				m_ClaimAmount = value ;
			}
			get
			{
				return m_ClaimAmount;
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


		public  string FreeSKUCode
		{
			set
			{
				m_FreeSKUCode = value ;
			}
			get
			{
				return m_FreeSKUCode;
			}
		}


		public  string FreeSKUName
		{
			set
			{
				m_FreeSKUName = value ;
			}
			get
			{
				return m_FreeSKUName;
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
		public spInsertHHSaleOrderPromotion()
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
				cmd.CommandText = "spInsertHHSaleOrderPromotion";
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
				command.CommandText = "spInsertHHSaleOrderPromotion";
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
				command.CommandText = "spInsertHHSaleOrderPromotion";
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
				command.CommandText = "spInsertHHSaleOrderPromotion";
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
					m_SALE_INVOICE_PROMOTION_ID=Convert.ToInt64(dr["SALE_INVOICE_PROMOTION_ID"]);
					m_HHSaleOrderId=Convert.ToInt64(dr["HHSaleOrderId"]);
					m_HHSaleOrderDetailId=Convert.ToInt64(dr["HHSaleOrderDetailId"]);
					m_SALE_ORDER_PROMOTION_ID=Convert.ToInt64(dr["SALE_ORDER_PROMOTION_ID"]);
					m_IsScheme=Convert.ToBoolean(dr["IsScheme"]);
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_IMPORT_DATE= Convert.ToDateTime(dr["IMPORT_DATE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
					m_GSTRate= Convert.ToDouble(dr["GSTRate"]);
					m_DiscountPercent= Convert.ToDouble(dr["DiscountPercent"]);
					m_IMPORT_BATCH_NO= Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
					m_FreeQuantity= Convert.ToInt32(dr["FreeQuantity"]);
					m_DEVICE_ID= Convert.ToInt32(dr["DEVICE_ID"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_HHSaleOrderPromotionId= Convert.ToInt32(dr["HHSaleOrderPromotionId"]);
					m_PromotionOfferId= Convert.ToInt32(dr["PromotionOfferId"]);
					m_FreeSKUId= Convert.ToInt32(dr["FreeSKUId"]);
					m_DiscountAmount= Convert.ToDecimal(dr["DiscountAmount"]);
					m_ClaimAmount= Convert.ToDecimal(dr["ClaimAmount"]);
					m_TradePriceUnit= Convert.ToDecimal(dr["TradePriceUnit"]);
					m_RetailPriceUnit= Convert.ToDecimal(dr["RetailPriceUnit"]);
					m_GSTAmount= Convert.ToDecimal(dr["GSTAmount"]);
					m_FreeSKUCode= Convert.ToString(dr["FreeSKUCode"]);
					m_FreeSKUName= Convert.ToString(dr["FreeSKUName"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_INVOICE_PROMOTION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_INVOICE_PROMOTION_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_INVOICE_PROMOTION_ID;
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
			parameter.ParameterName = "@SALE_ORDER_PROMOTION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_ORDER_PROMOTION_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_ORDER_PROMOTION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IsScheme" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IsScheme;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
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
			parameter.ParameterName = "@DiscountPercent" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_DiscountPercent==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DiscountPercent;
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
			parameter.ParameterName = "@FreeQuantity" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FreeQuantity==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FreeQuantity;
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
			parameter.ParameterName = "@HHSaleOrderPromotionId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_HHSaleOrderPromotionId==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_HHSaleOrderPromotionId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PromotionOfferId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PromotionOfferId==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PromotionOfferId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FreeSKUId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FreeSKUId==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FreeSKUId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DiscountAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_DiscountAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DiscountAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ClaimAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_ClaimAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ClaimAmount;
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
			parameter.ParameterName = "@FreeSKUCode" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FreeSKUCode== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FreeSKUCode;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FreeSKUName" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FreeSKUName== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FreeSKUName;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
