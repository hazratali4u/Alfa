using System;
using System.Data;
using SAMSDataAccessLayer.Classes;
using SAMSCommon.Classes;



namespace SAMSDatabaseLayer.Classes
{
	public class spUpdateDTSKU_STOCK_REGISTER
	{
		#region Private Members
		private string sp_Name = " spUpdateDTSKU_STOCK_REGISTER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private DateTime m_STOCK_DATE;
		private int m_SHORT;
		private int m_EXCESS;
		private int m_INITIAL;
		private int m_SALE_RETURN;
		private int m_FREE_STOCK;
		private int m_DISPOSED;
		private int m_SALED;
		private int m_PURCHASE_RETURN;
		private int m_PURCHASED;
		private int m_DAMAGED_STOCK;
		private int m_DAMAGED_STOCK_RETURN;
		private int m_CLOSING_STOCK;
		private int m_SKU_ID;
		private int m_DISTRIBUTOR_ID;
		private int m_OPENING_STOCK;
		private decimal m_RateDifference;
		private decimal m_TRADE_PRICE;
		private decimal m_RETAIL_PRICE;
		private decimal m_TAX_PRICE;
		#endregion


		#region Public Properties
		public DateTime STOCK_DATE
		{
			set
			{
				m_STOCK_DATE = value ;
			}
			get
			{
				return m_STOCK_DATE;
			}
		}


		public int SHORT
		{
			set
			{
				m_SHORT = value ;
			}
			get
			{
				return m_SHORT;
			}
		}


		public int EXCESS
		{
			set
			{
				m_EXCESS = value ;
			}
			get
			{
				return m_EXCESS;
			}
		}


		public int INITIAL
		{
			set
			{
				m_INITIAL = value ;
			}
			get
			{
				return m_INITIAL;
			}
		}


		public int SALE_RETURN
		{
			set
			{
				m_SALE_RETURN = value ;
			}
			get
			{
				return m_SALE_RETURN;
			}
		}


		public int FREE_STOCK
		{
			set
			{
				m_FREE_STOCK = value ;
			}
			get
			{
				return m_FREE_STOCK;
			}
		}


		public int DISPOSED
		{
			set
			{
				m_DISPOSED = value ;
			}
			get
			{
				return m_DISPOSED;
			}
		}


		public int SALED
		{
			set
			{
				m_SALED = value ;
			}
			get
			{
				return m_SALED;
			}
		}


		public int PURCHASE_RETURN
		{
			set
			{
				m_PURCHASE_RETURN = value ;
			}
			get
			{
				return m_PURCHASE_RETURN;
			}
		}


		public int PURCHASED
		{
			set
			{
				m_PURCHASED = value ;
			}
			get
			{
				return m_PURCHASED;
			}
		}


		public int DAMAGED_STOCK
		{
			set
			{
				m_DAMAGED_STOCK = value ;
			}
			get
			{
				return m_DAMAGED_STOCK;
			}
		}


		public int DAMAGED_STOCK_RETURN
		{
			set
			{
				m_DAMAGED_STOCK_RETURN = value ;
			}
			get
			{
				return m_DAMAGED_STOCK_RETURN;
			}
		}


		public int CLOSING_STOCK
		{
			set
			{
				m_CLOSING_STOCK = value ;
			}
			get
			{
				return m_CLOSING_STOCK;
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


		public int OPENING_STOCK
		{
			set
			{
				m_OPENING_STOCK = value ;
			}
			get
			{
				return m_OPENING_STOCK;
			}
		}


		public decimal  RateDifference
		{
			set
			{
				m_RateDifference = value ;
			}
			get
			{
				return m_RateDifference;
			}
		}


		public decimal  TRADE_PRICE
		{
			set
			{
				m_TRADE_PRICE = value ;
			}
			get
			{
				return m_TRADE_PRICE;
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


		public decimal  TAX_PRICE
		{
			set
			{
				m_TAX_PRICE = value ;
			}
			get
			{
				return m_TAX_PRICE;
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
		public spUpdateDTSKU_STOCK_REGISTER()
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
				cmd.CommandText = "spUpdateDTSKU_STOCK_REGISTER";
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
				command.CommandText = "spUpdateDTSKU_STOCK_REGISTER";
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
				command.CommandText = "spUpdateDTSKU_STOCK_REGISTER";
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
				command.CommandText = "spUpdateDTSKU_STOCK_REGISTER";
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
					m_STOCK_DATE= Convert.ToDateTime(dr["STOCK_DATE"]);
					m_SHORT= Convert.ToInt32(dr["SHORT"]);
					m_EXCESS= Convert.ToInt32(dr["EXCESS"]);
					m_INITIAL= Convert.ToInt32(dr["INITIAL"]);
					m_SALE_RETURN= Convert.ToInt32(dr["SALE_RETURN"]);
					m_FREE_STOCK= Convert.ToInt32(dr["FREE_STOCK"]);
					m_DISPOSED= Convert.ToInt32(dr["DISPOSED"]);
					m_SALED= Convert.ToInt32(dr["SALED"]);
					m_PURCHASE_RETURN= Convert.ToInt32(dr["PURCHASE_RETURN"]);
					m_PURCHASED= Convert.ToInt32(dr["PURCHASED"]);
					m_DAMAGED_STOCK= Convert.ToInt32(dr["DAMAGED_STOCK"]);
					m_DAMAGED_STOCK_RETURN= Convert.ToInt32(dr["DAMAGED_STOCK_RETURN"]);
					m_CLOSING_STOCK= Convert.ToInt32(dr["CLOSING_STOCK"]);
					m_SKU_ID= Convert.ToInt32(dr["SKU_ID"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_OPENING_STOCK= Convert.ToInt32(dr["OPENING_STOCK"]);
					m_RateDifference= Convert.ToDecimal(dr["RateDifference"]);
					m_TRADE_PRICE= Convert.ToDecimal(dr["TRADE_PRICE"]);
					m_RETAIL_PRICE= Convert.ToDecimal(dr["RETAIL_PRICE"]);
					m_TAX_PRICE= Convert.ToDecimal(dr["TAX_PRICE"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@STOCK_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_STOCK_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_STOCK_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SHORT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SHORT==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SHORT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EXCESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_EXCESS==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EXCESS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@INITIAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_INITIAL==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_INITIAL;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_RETURN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SALE_RETURN==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_RETURN;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_STOCK" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FREE_STOCK==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_STOCK;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISPOSED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DISPOSED==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISPOSED;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SALED==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALED;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PURCHASE_RETURN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PURCHASE_RETURN==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PURCHASE_RETURN;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PURCHASED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PURCHASED==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PURCHASED;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DAMAGED_STOCK" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DAMAGED_STOCK==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DAMAGED_STOCK;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DAMAGED_STOCK_RETURN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DAMAGED_STOCK_RETURN==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DAMAGED_STOCK_RETURN;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CLOSING_STOCK" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CLOSING_STOCK==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CLOSING_STOCK;
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
			parameter.ParameterName = "@OPENING_STOCK" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_OPENING_STOCK==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_OPENING_STOCK;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RateDifference" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_RateDifference==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RateDifference;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRADE_PRICE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TRADE_PRICE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRADE_PRICE;
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
			parameter.ParameterName = "@TAX_PRICE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TAX_PRICE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TAX_PRICE;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
