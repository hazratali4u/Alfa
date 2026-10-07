using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spUpdateDTSALE_INVOICE_PROMOTION
	{
		#region Private Members
		private string sp_Name = " spUpdateDTSALE_INVOICE_PROMOTION" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_SALE_INVOICE_PROMOTION_ID;
		private long m_SALE_INVOICE_DETAIL_ID;
		private long m_SALE_INVOICE_MASTER_ID;
		private bool m_IS_SCHEME;
		private decimal m_DISC_RATE;
		private decimal m_DISC_AMOUNT;
		private float  m_GST_RATE;
		private int m_QUANTITY;
		private int m_SALE_ORDER_PROMOTION_ID;
		private int m_SKU_ID;
		private int m_PROMOTION_ID;
		private int m_SCHEME_ID;
		private int m_BASKET_DETAIL_ID;
		private int m_DISTRIBUTOR_ID;
		private int m_PROMOTION_OFFER_ID;
		private int m_BASKET_ID;
		private decimal m_CLAIM_AMOUNT;
		private decimal m_UNIT_PRICE;
		private decimal m_RETAIL_PRICE;
		private decimal m_GST_AMOUNT;
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


		public long SALE_INVOICE_MASTER_ID
		{
			set
			{
				m_SALE_INVOICE_MASTER_ID = value ;
			}
			get
			{
				return m_SALE_INVOICE_MASTER_ID;
			}
		}


		public bool IS_SCHEME
		{
			set
			{
				m_IS_SCHEME = value ;
			}
			get
			{
				return m_IS_SCHEME;
			}
		}


		public decimal DISC_RATE
		{
			set
			{
				m_DISC_RATE = value ;
			}
			get
			{
				return m_DISC_RATE;
			}
		}


		public decimal DISC_AMOUNT
		{
			set
			{
				m_DISC_AMOUNT = value ;
			}
			get
			{
				return m_DISC_AMOUNT;
			}
		}


		public float GST_RATE
		{
			set
			{
				m_GST_RATE = value ;
			}
			get
			{
				return m_GST_RATE;
			}
		}


		public int QUANTITY
		{
			set
			{
				m_QUANTITY = value ;
			}
			get
			{
				return m_QUANTITY;
			}
		}


		public int SALE_ORDER_PROMOTION_ID
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


		public int SKU_ID
		{
			set
			{
				m_SKU_ID = value ;
			}
			get
			{
				return m_SKU_ID;
			}
		}


		public int PROMOTION_ID
		{
			set
			{
				m_PROMOTION_ID = value ;
			}
			get
			{
				return m_PROMOTION_ID;
			}
		}


		public int SCHEME_ID
		{
			set
			{
				m_SCHEME_ID = value ;
			}
			get
			{
				return m_SCHEME_ID;
			}
		}


		public int BASKET_DETAIL_ID
		{
			set
			{
				m_BASKET_DETAIL_ID = value ;
			}
			get
			{
				return m_BASKET_DETAIL_ID;
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


		public int PROMOTION_OFFER_ID
		{
			set
			{
				m_PROMOTION_OFFER_ID = value ;
			}
			get
			{
				return m_PROMOTION_OFFER_ID;
			}
		}


		public int BASKET_ID
		{
			set
			{
				m_BASKET_ID = value ;
			}
			get
			{
				return m_BASKET_ID;
			}
		}


		public decimal  CLAIM_AMOUNT
		{
			set
			{
				m_CLAIM_AMOUNT = value ;
			}
			get
			{
				return m_CLAIM_AMOUNT;
			}
		}


		public decimal  UNIT_PRICE
		{
			set
			{
				m_UNIT_PRICE = value ;
			}
			get
			{
				return m_UNIT_PRICE;
			}
		}


		public decimal  RETAIL_PRICE
		{
			set
			{
				m_RETAIL_PRICE = value ;
			}
			get
			{
				return m_RETAIL_PRICE;
			}
		}


		public decimal  GST_AMOUNT
		{
			set
			{
				m_GST_AMOUNT = value ;
			}
			get
			{
				return m_GST_AMOUNT;
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
		public spUpdateDTSALE_INVOICE_PROMOTION()
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
				cmd.CommandText = "spUpdateDTSALE_INVOICE_PROMOTION";
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
				command.CommandText = "spUpdateDTSALE_INVOICE_PROMOTION";
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
				command.CommandText = "spUpdateDTSALE_INVOICE_PROMOTION";
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
				command.CommandText = "spUpdateDTSALE_INVOICE_PROMOTION";
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
					m_SALE_INVOICE_DETAIL_ID=Convert.ToInt64(dr["SALE_INVOICE_DETAIL_ID"]);
					m_SALE_INVOICE_MASTER_ID=Convert.ToInt64(dr["SALE_INVOICE_MASTER_ID"]);
					m_IS_SCHEME=Convert.ToBoolean(dr["IS_SCHEME"]);
					m_DISC_RATE= Convert.ToDecimal(dr["DISC_RATE"]);
					m_DISC_AMOUNT= Convert.ToDecimal(dr["DISC_AMOUNT"]);
					m_GST_RATE= float.Parse(dr["GST_RATE"].ToString());
					m_QUANTITY= Convert.ToInt32(dr["QUANTITY"]);
					m_SALE_ORDER_PROMOTION_ID= Convert.ToInt32(dr["SALE_ORDER_PROMOTION_ID"]);
					m_SKU_ID= Convert.ToInt32(dr["SKU_ID"]);
					m_PROMOTION_ID= Convert.ToInt32(dr["PROMOTION_ID"]);
					m_SCHEME_ID= Convert.ToInt32(dr["SCHEME_ID"]);
					m_BASKET_DETAIL_ID= Convert.ToInt32(dr["BASKET_DETAIL_ID"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_PROMOTION_OFFER_ID= Convert.ToInt32(dr["PROMOTION_OFFER_ID"]);
					m_BASKET_ID= Convert.ToInt32(dr["BASKET_ID"]);
					m_CLAIM_AMOUNT= Convert.ToDecimal(dr["CLAIM_AMOUNT"]);
					m_UNIT_PRICE= Convert.ToDecimal(dr["UNIT_PRICE"]);
					m_RETAIL_PRICE= Convert.ToDecimal(dr["RETAIL_PRICE"]);
					m_GST_AMOUNT= Convert.ToDecimal(dr["GST_AMOUNT"]);
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
			parameter.ParameterName = "@SALE_INVOICE_MASTER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_INVOICE_MASTER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_INVOICE_MASTER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_SCHEME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_SCHEME;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISC_RATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_DISC_RATE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISC_RATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISC_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_DISC_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISC_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@GST_RATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_GST_RATE==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GST_RATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@QUANTITY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_QUANTITY==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_QUANTITY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_ORDER_PROMOTION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SALE_ORDER_PROMOTION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_ORDER_PROMOTION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKU_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SKU_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKU_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PROMOTION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PROMOTION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PROMOTION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SCHEME_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SCHEME_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SCHEME_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BASKET_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_BASKET_DETAIL_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BASKET_DETAIL_ID;
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
			parameter.ParameterName = "@PROMOTION_OFFER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PROMOTION_OFFER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PROMOTION_OFFER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BASKET_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_BASKET_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BASKET_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CLAIM_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_CLAIM_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CLAIM_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@UNIT_PRICE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_UNIT_PRICE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_UNIT_PRICE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RETAIL_PRICE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_RETAIL_PRICE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RETAIL_PRICE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@GST_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_GST_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GST_AMOUNT;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
