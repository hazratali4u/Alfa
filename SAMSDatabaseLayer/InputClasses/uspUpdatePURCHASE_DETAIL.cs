using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class uspUpdatePURCHASE_DETAIL
	{
		#region Private Members
		private string sp_Name = " uspUpdatePURCHASE_DETAIL" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_PURCHASE_MASTER_ID;
		private DateTime m_EXPIRY_DATE;
		private DateTime m_FREE_EXPIRY_DATE;
		private float  m_TAX_RATE;
		private float  m_FREE_TAX_RATE;
		private int m_QUANTITY;
		private int m_FREE_QUANTITY;
		private int m_DISTRIBUTOR_ID;
		private int m_SKU_ID;
		private int m_FREE_SKU_ID;
		private decimal m_FREE_PRICE;
		private decimal m_TAX_VALUE;
		private decimal m_FREE_TAX_VALUE;
		private decimal m_AMOUNT;
		private decimal m_FREE_AMOUNT;
		private decimal m_PRICE;
		private string m_BATCH_NUMBER;
		private string m_FREE_BATCH_NUMBER;
		#endregion


		#region Public Properties
		public long PURCHASE_MASTER_ID
		{
			set
			{
				m_PURCHASE_MASTER_ID = value ;
			}
			get
			{
				return m_PURCHASE_MASTER_ID;
			}
		}


		public DateTime EXPIRY_DATE
		{
			set
			{
				m_EXPIRY_DATE = value ;
			}
			get
			{
				return m_EXPIRY_DATE;
			}
		}


		public DateTime FREE_EXPIRY_DATE
		{
			set
			{
				m_FREE_EXPIRY_DATE = value ;
			}
			get
			{
				return m_FREE_EXPIRY_DATE;
			}
		}


		public float TAX_RATE
		{
			set
			{
				m_TAX_RATE = value ;
			}
			get
			{
				return m_TAX_RATE;
			}
		}


		public float FREE_TAX_RATE
		{
			set
			{
				m_FREE_TAX_RATE = value ;
			}
			get
			{
				return m_FREE_TAX_RATE;
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


		public int FREE_QUANTITY
		{
			set
			{
				m_FREE_QUANTITY = value ;
			}
			get
			{
				return m_FREE_QUANTITY;
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


		public int FREE_SKU_ID
		{
			set
			{
				m_FREE_SKU_ID = value ;
			}
			get
			{
				return m_FREE_SKU_ID;
			}
		}


		public decimal  FREE_PRICE
		{
			set
			{
				m_FREE_PRICE = value ;
			}
			get
			{
				return m_FREE_PRICE;
			}
		}


		public decimal  TAX_VALUE
		{
			set
			{
				m_TAX_VALUE = value ;
			}
			get
			{
				return m_TAX_VALUE;
			}
		}


		public decimal  FREE_TAX_VALUE
		{
			set
			{
				m_FREE_TAX_VALUE = value ;
			}
			get
			{
				return m_FREE_TAX_VALUE;
			}
		}


		public decimal  AMOUNT
		{
			set
			{
				m_AMOUNT = value ;
			}
			get
			{
				return m_AMOUNT;
			}
		}


		public decimal  FREE_AMOUNT
		{
			set
			{
				m_FREE_AMOUNT = value ;
			}
			get
			{
				return m_FREE_AMOUNT;
			}
		}


		public decimal  PRICE
		{
			set
			{
				m_PRICE = value ;
			}
			get
			{
				return m_PRICE;
			}
		}


		public  string BATCH_NUMBER
		{
			set
			{
				m_BATCH_NUMBER = value ;
			}
			get
			{
				return m_BATCH_NUMBER;
			}
		}


		public  string FREE_BATCH_NUMBER
		{
			set
			{
				m_FREE_BATCH_NUMBER = value ;
			}
			get
			{
				return m_FREE_BATCH_NUMBER;
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
		public uspUpdatePURCHASE_DETAIL()
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
				cmd.CommandText = "uspUpdatePURCHASE_DETAIL";
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
				command.CommandText = "uspUpdatePURCHASE_DETAIL";
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
				command.CommandText = "uspUpdatePURCHASE_DETAIL";
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
				command.CommandText = "uspUpdatePURCHASE_DETAIL";
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
					m_PURCHASE_MASTER_ID=Convert.ToInt64(dr["PURCHASE_MASTER_ID"]);
					m_EXPIRY_DATE= Convert.ToDateTime(dr["EXPIRY_DATE"]);
					m_FREE_EXPIRY_DATE= Convert.ToDateTime(dr["FREE_EXPIRY_DATE"]);
					m_TAX_RATE= float.Parse(dr["TAX_RATE"].ToString());
					m_FREE_TAX_RATE= float.Parse(dr["FREE_TAX_RATE"].ToString());
					m_QUANTITY= Convert.ToInt32(dr["QUANTITY"]);
					m_FREE_QUANTITY= Convert.ToInt32(dr["FREE_QUANTITY"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_SKU_ID= Convert.ToInt32(dr["SKU_ID"]);
					m_FREE_SKU_ID= Convert.ToInt32(dr["FREE_SKU_ID"]);
					m_FREE_PRICE= Convert.ToDecimal(dr["FREE_PRICE"]);
					m_TAX_VALUE= Convert.ToDecimal(dr["TAX_VALUE"]);
					m_FREE_TAX_VALUE= Convert.ToDecimal(dr["FREE_TAX_VALUE"]);
					m_AMOUNT= Convert.ToDecimal(dr["AMOUNT"]);
					m_FREE_AMOUNT= Convert.ToDecimal(dr["FREE_AMOUNT"]);
					m_PRICE= Convert.ToDecimal(dr["PRICE"]);
					m_BATCH_NUMBER= Convert.ToString(dr["BATCH_NUMBER"]);
					m_FREE_BATCH_NUMBER= Convert.ToString(dr["FREE_BATCH_NUMBER"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PURCHASE_MASTER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_PURCHASE_MASTER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PURCHASE_MASTER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EXPIRY_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_EXPIRY_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EXPIRY_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_EXPIRY_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_FREE_EXPIRY_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_EXPIRY_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TAX_RATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_TAX_RATE==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TAX_RATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_TAX_RATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Float);
			if(m_FREE_TAX_RATE==Constants.FloatNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_TAX_RATE;
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
			parameter.ParameterName = "@FREE_QUANTITY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FREE_QUANTITY==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_QUANTITY;
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
			parameter.ParameterName = "@FREE_SKU_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FREE_SKU_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_SKU_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_PRICE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_FREE_PRICE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_PRICE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TAX_VALUE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TAX_VALUE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TAX_VALUE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_TAX_VALUE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_FREE_TAX_VALUE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_TAX_VALUE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_FREE_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PRICE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_PRICE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PRICE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BATCH_NUMBER" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BATCH_NUMBER== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BATCH_NUMBER;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FREE_BATCH_NUMBER" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FREE_BATCH_NUMBER== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FREE_BATCH_NUMBER;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
