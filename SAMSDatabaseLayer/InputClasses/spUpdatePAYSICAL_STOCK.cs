using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	
   public class spUpdatePAYSICAL_STOCK
        {
            #region Private Members
            private string sp_Name = " spUpdatePAYSICAL_STOCK";
            private IDbConnection m_connection;
            private IDbTransaction m_transaction;


            private int m_DISTRIBUTOR_ID;
            private int m_SKU_ID;
            private int m_PRINCIPAL_ID;
            private int m_SALEABLE_QUANTITY;
            private int m_UNSALEABLE_QUANTITY;
            private int m_POST;
            private decimal m_UNIT_RATE;
            private DateTime m_STOCK_DATE;
            #endregion


            #region Public Properties
            public int DISTRIBUTOR_ID
            {
                set
                {
                    m_DISTRIBUTOR_ID = value;
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
                    m_SKU_ID = value;
                }
                get
                {
                    return m_SKU_ID;
                }
            }


            public int PRINCIPAL_ID
            {
                set
                {
                    m_PRINCIPAL_ID = value;
                }
                get
                {
                    return m_PRINCIPAL_ID;
                }
            }


            public int SALEABLE_QUANTITY
            {
                set
                {
                    m_SALEABLE_QUANTITY = value;
                }
                get
                {
                    return m_SALEABLE_QUANTITY;
                }
            }


            public int UNSALEABLE_QUANTITY
            {
                set
                {
                    m_UNSALEABLE_QUANTITY = value;
                }
                get
                {
                    return m_UNSALEABLE_QUANTITY;
                }
            }


            public int POST
            {
                set
                {
                    m_POST = value;
                }
                get
                {
                    return m_POST;
                }
            }


            public decimal UNIT_RATE
            {
                set
                {
                    m_UNIT_RATE = value;
                }
                get
                {
                    return m_UNIT_RATE;
                }
            }


            public DateTime STOCK_DATE
            {
                set
                {
                    m_STOCK_DATE = value;
                }
                get
                {
                    return m_STOCK_DATE;
                }
            }




            public IDbConnection Connection
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
            public IDbTransaction Transaction
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
            public spUpdatePAYSICAL_STOCK()
            {


            }
            #endregion

            #region public Methods
            public bool ExecuteQuery()
            {
                try
                {
                    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdatePAYSICAL_STOCK";
                    cmd.Connection = m_connection;
                    if (m_transaction != null)
                    {
                        cmd.Transaction = m_transaction;
                    }
                    GetParameterCollection(ref cmd);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
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
                    command.CommandText = "spUpdatePAYSICAL_STOCK";
                    command.Connection = m_connection;
                    if (m_transaction != null)
                    {
                        command.Transaction = m_transaction;
                    }
                    GetParameterCollection(ref command);
                    IDataReader dr = command.ExecuteReader();
                    return dr;
                }
                catch (Exception exp)
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
                    command.CommandText = "spUpdatePAYSICAL_STOCK";
                    command.Connection = m_connection;
                    if (m_transaction != null)
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
                catch (Exception exp)
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
                    command.CommandText = "spUpdatePAYSICAL_STOCK";
                    command.Connection = m_connection;
                    if (m_transaction != null)
                    {
                        command.Transaction = m_transaction;
                    }
                    GetParameterCollection(ref command);
                    object o;
                    o = command.ExecuteScalar();


                    return o.ToString();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                finally
                {
                }
            }


            public void FirstReader(IDataReader dr)
            {
                if (dr.Read())
                {
                    m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                    m_SKU_ID = Convert.ToInt32(dr["SKU_ID"]);
                    m_PRINCIPAL_ID = Convert.ToInt32(dr["PRINCIPAL_ID"]);
                    m_SALEABLE_QUANTITY = Convert.ToInt32(dr["SALEABLE_QUANTITY"]);
                    m_UNSALEABLE_QUANTITY = Convert.ToInt32(dr["UNSALEABLE_QUANTITY"]);
                    m_POST = Convert.ToInt32(dr["POST"]);
                    m_UNIT_RATE = Convert.ToDecimal(dr["UNIT_RATE"]);
                    m_STOCK_DATE = Convert.ToDateTime(dr["STOCK_DATE"]);
                }
            }


            public void GetParameterCollection(ref IDbCommand cmd)
            {
                IDataParameterCollection pparams = cmd.Parameters;
                IDataParameter parameter;
                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@DISTRIBUTOR_ID";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (m_DISTRIBUTOR_ID == Constants.IntNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_DISTRIBUTOR_ID;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@SKU_ID";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (m_SKU_ID == Constants.IntNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_SKU_ID;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@PRINCIPAL_ID";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (m_PRINCIPAL_ID == Constants.IntNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_PRINCIPAL_ID;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@SALEABLE_QUANTITY";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (m_SALEABLE_QUANTITY == Constants.IntNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_SALEABLE_QUANTITY;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@UNSALEABLE_QUANTITY";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (m_UNSALEABLE_QUANTITY == Constants.IntNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_UNSALEABLE_QUANTITY;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@POST";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
                if (m_POST == Constants.IntNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_POST;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@UNIT_RATE";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
                if (m_UNIT_RATE == Constants.DecimalNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_UNIT_RATE;
                }
                pparams.Add(parameter);


                parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
                parameter.ParameterName = "@STOCK_DATE";
                parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
                if (m_STOCK_DATE == Constants.DateNullValue)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = m_STOCK_DATE;
                }
                pparams.Add(parameter);


            }
            #endregion
        }
	
}
