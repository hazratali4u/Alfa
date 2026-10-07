using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;

namespace SAMSDatabaseLayer.Classes
{
	public class UspCustomerShifting
	{
		#region Private Members
		private string sp_Name = " UspCustomerShifting" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_FROM_DISTRIBUTOR_ID;
		private int m_TO_DISTRIBUTOR_ID;
		private int m_TOWN_ID;
		private int m_FROM_AREA_ID;
		private int m_TO_AREA_ID;
		private int m_FROM_ROUTE_ID;
        private int m_TO_ROUTE_ID;
        private int m_CUSTOMER_ID;

		#endregion


		#region Public Properties
		public int FROM_DISTRIBUTOR_ID
		{
			set
			{
				m_FROM_DISTRIBUTOR_ID = value ;
			}
			get
			{
				return m_FROM_DISTRIBUTOR_ID;
			}
		}


		public int TO_DISTRIBUTOR_ID
		{
			set
			{
				m_TO_DISTRIBUTOR_ID = value ;
			}
			get
			{
				return m_TO_DISTRIBUTOR_ID;
			}
		}


		public int TOWN_ID
		{
			set
			{
				m_TOWN_ID = value ;
			}
			get
			{
				return m_TOWN_ID;
			}
		}


		public int FROM_AREA_ID
		{
			set
			{
				m_FROM_AREA_ID = value ;
			}
			get
			{
				return m_FROM_AREA_ID;
			}
		}


		public int TO_AREA_ID
		{
			set
			{
				m_TO_AREA_ID = value ;
			}
			get
			{
				return m_TO_AREA_ID;
			}
		}


		public int FROM_ROUTE_ID
		{
			set
			{
				m_FROM_ROUTE_ID = value ;
			}
			get
			{
				return m_FROM_ROUTE_ID;
			}
		}

        public int TO_ROUTE_ID
        {
            set
            {
                m_TO_ROUTE_ID = value;
            }
            get
            {
                return m_TO_ROUTE_ID;
            }
        }

        public int CUSTOMER_ID
        {
            set
            {
                m_CUSTOMER_ID = value;
            }
            get
            {
                return m_CUSTOMER_ID;
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
        public UspCustomerShifting()
        {
            m_FROM_DISTRIBUTOR_ID = Constants.IntNullValue;
            m_TO_DISTRIBUTOR_ID = Constants.IntNullValue;
            m_TOWN_ID = Constants.IntNullValue;
            m_FROM_AREA_ID = Constants.IntNullValue;
            m_TO_AREA_ID = Constants.IntNullValue;
            m_FROM_ROUTE_ID = Constants.IntNullValue;
            m_TO_ROUTE_ID = Constants.IntNullValue;
            m_CUSTOMER_ID = Constants.IntNullValue;
        }
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "UspCustomerShifting";
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
				command.CommandText = "UspCustomerShifting";
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
				command.CommandText = "UspCustomerShifting";
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
				command.CommandText = "UspCustomerShifting";
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
					m_FROM_DISTRIBUTOR_ID= Convert.ToInt32(dr["FROM_DISTRIBUTOR_ID"]);
					m_TO_DISTRIBUTOR_ID= Convert.ToInt32(dr["TO_DISTRIBUTOR_ID"]);
					m_TOWN_ID= Convert.ToInt32(dr["TOWN_ID"]);
					m_FROM_AREA_ID= Convert.ToInt32(dr["FROM_AREA_ID"]);
					m_TO_AREA_ID= Convert.ToInt32(dr["TO_AREA_ID"]);
					m_FROM_ROUTE_ID= Convert.ToInt32(dr["FROM_ROUTE_ID"]);
                    m_TO_ROUTE_ID = Convert.ToInt32(dr["TO_ROUTE_ID"]);
                    m_CUSTOMER_ID = Convert.ToInt32(dr["CUSTOMER_ID"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FROM_DISTRIBUTOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FROM_DISTRIBUTOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FROM_DISTRIBUTOR_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TO_DISTRIBUTOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TO_DISTRIBUTOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TO_DISTRIBUTOR_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TOWN_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TOWN_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TOWN_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FROM_AREA_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FROM_AREA_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FROM_AREA_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TO_AREA_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TO_AREA_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TO_AREA_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FROM_ROUTE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FROM_ROUTE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FROM_ROUTE_ID;
			}
			pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TO_ROUTE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_TO_ROUTE_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_TO_ROUTE_ID;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_CUSTOMER_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CUSTOMER_ID;
            }
            pparams.Add(parameter);


		}
		#endregion
	}
}
