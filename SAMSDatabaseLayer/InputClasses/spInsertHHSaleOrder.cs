using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes 
{
	public class spInsertHHSaleOrder
	{
		#region Private Members
		private string sp_Name = " spInsertHHSaleOrder" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_SALE_INVOICE_MASTER_ID;
		private long m_HHSaleOrderId;
		private long m_CustomerId;
		private long m_SALE_ORDER_MASTER_ID;
		private bool m_IsDeleted;
		private bool m_IS_ACTIVE;
		private DateTime m_LASTUPDATE_DATE;
		private DateTime m_DocumentDate;
		private DateTime m_IMPORT_DATE;
		private DateTime m_TIME_STAMP;
		private int m_DISTRIBUTOR_ID;
		private int m_IMPORT_BATCH_NO;
		private int m_ORDER_TYPE_ID;
		private int m_LEGEND_ID;
		private int m_DEVICE_ID;
		private int m_DeliveryManId;
		private int m_StatusId;
		private int m_ORDERBOOKER_ID;
		private decimal m_TotalClaimAmount;
		private decimal m_GSTAmount;
		private decimal m_TotalNetAmount;
		private decimal m_TotalAmount;
		private decimal m_SchDiscountAmount;
		private decimal m_StdDiscountAmount;
		private string m_SaleOrderNumber;
		#endregion


		#region Public Properties
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


		public long CustomerId
		{
			set
			{
				m_CustomerId = value ;
			}
			get
			{
				return m_CustomerId;
			}
		}


		public long SALE_ORDER_MASTER_ID
		{
			set
			{
				m_SALE_ORDER_MASTER_ID = value ;
			}
			get
			{
				return m_SALE_ORDER_MASTER_ID;
			}
		}


		public bool IsDeleted
		{
			set
			{
				m_IsDeleted = value ;
			}
			get
			{
				return m_IsDeleted;
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


		public DateTime DocumentDate
		{
			set
			{
				m_DocumentDate = value ;
			}
			get
			{
				return m_DocumentDate;
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


		public int ORDER_TYPE_ID
		{
			set
			{
				m_ORDER_TYPE_ID = value ;
			}
			get
			{
				return m_ORDER_TYPE_ID;
			}
		}


		public int LEGEND_ID
		{
			set
			{
				m_LEGEND_ID = value ;
			}
			get
			{
				return m_LEGEND_ID;
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


		public int DeliveryManId
		{
			set
			{
				m_DeliveryManId = value ;
			}
			get
			{
				return m_DeliveryManId;
			}
		}


		public int StatusId
		{
			set
			{
				m_StatusId = value ;
			}
			get
			{
				return m_StatusId;
			}
		}


		public int ORDERBOOKER_ID
		{
			set
			{
				m_ORDERBOOKER_ID = value ;
			}
			get
			{
				return m_ORDERBOOKER_ID;
			}
		}


		public decimal  TotalClaimAmount
		{
			set
			{
				m_TotalClaimAmount = value ;
			}
			get
			{
				return m_TotalClaimAmount;
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


		public decimal  TotalNetAmount
		{
			set
			{
				m_TotalNetAmount = value ;
			}
			get
			{
				return m_TotalNetAmount;
			}
		}


		public decimal  TotalAmount
		{
			set
			{
				m_TotalAmount = value ;
			}
			get
			{
				return m_TotalAmount;
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


		public string SaleOrderNumber
		{
			set
			{
				m_SaleOrderNumber = value ;
			}
			get
			{
				return m_SaleOrderNumber;
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
		public spInsertHHSaleOrder()
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
				cmd.CommandText = "spInsertHHSaleOrder";
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
				command.CommandText = "spInsertHHSaleOrder";
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
				command.CommandText = "spInsertHHSaleOrder";
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
				command.CommandText = "spInsertHHSaleOrder";
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
					m_SALE_INVOICE_MASTER_ID=Convert.ToInt64(dr["SALE_INVOICE_MASTER_ID"]);
					m_HHSaleOrderId=Convert.ToInt64(dr["HHSaleOrderId"]);
					m_CustomerId=Convert.ToInt64(dr["CustomerId"]);
					m_SALE_ORDER_MASTER_ID=Convert.ToInt64(dr["SALE_ORDER_MASTER_ID"]);
					m_IsDeleted=Convert.ToBoolean(dr["IsDeleted"]);
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
					m_DocumentDate= Convert.ToDateTime(dr["DocumentDate"]);
					m_IMPORT_DATE= Convert.ToDateTime(dr["IMPORT_DATE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_IMPORT_BATCH_NO= Convert.ToInt32(dr["IMPORT_BATCH_NO"]);
					m_ORDER_TYPE_ID= Convert.ToInt32(dr["ORDER_TYPE_ID"]);
					m_LEGEND_ID= Convert.ToInt32(dr["LEGEND_ID"]);
					m_DEVICE_ID= Convert.ToInt32(dr["DEVICE_ID"]);
					m_DeliveryManId= Convert.ToInt32(dr["DeliveryManId"]);
					m_StatusId= Convert.ToInt32(dr["StatusId"]);
					m_ORDERBOOKER_ID= Convert.ToInt32(dr["ORDERBOOKER_ID"]);
					m_TotalClaimAmount= Convert.ToDecimal(dr["TotalClaimAmount"]);
					m_GSTAmount= Convert.ToDecimal(dr["GSTAmount"]);
					m_TotalNetAmount= Convert.ToDecimal(dr["TotalNetAmount"]);
					m_TotalAmount= Convert.ToDecimal(dr["TotalAmount"]);
					m_SchDiscountAmount= Convert.ToDecimal(dr["SchDiscountAmount"]);
					m_StdDiscountAmount= Convert.ToDecimal(dr["StdDiscountAmount"]);
					m_SaleOrderNumber= Convert.ToString(dr["SaleOrderNumber"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
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
			parameter.ParameterName = "@CustomerId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_CustomerId==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CustomerId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_ORDER_MASTER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_ORDER_MASTER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_ORDER_MASTER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IsDeleted" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IsDeleted;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
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
			parameter.ParameterName = "@DocumentDate" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_DocumentDate==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DocumentDate;
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
			parameter.ParameterName = "@ORDER_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ORDER_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ORDER_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LEGEND_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_LEGEND_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LEGEND_ID;
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
			parameter.ParameterName = "@DeliveryManId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DeliveryManId==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DeliveryManId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@StatusId" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_StatusId==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_StatusId;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ORDERBOOKER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ORDERBOOKER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ORDERBOOKER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TotalClaimAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TotalClaimAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TotalClaimAmount;
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
			parameter.ParameterName = "@TotalNetAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TotalNetAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TotalNetAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TotalAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TotalAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TotalAmount;
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
			parameter.ParameterName = "@SaleOrderNumber" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.NVarChar);
			if(m_SaleOrderNumber== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SaleOrderNumber;
			}
			pparams.Add(parameter);			

		}
		#endregion
	}
}
