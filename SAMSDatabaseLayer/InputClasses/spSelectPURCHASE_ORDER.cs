using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
namespace SAMSDatabaseLayer.InputClasses
{
    public class spSelectPURCHASE_ORDER
    {

        #region Private Members
        private string sp_Name = "spSelectPURCHASE_ORDER";
        private IDbConnection m_connection;
        private IDbTransaction m_transaction;
        
        private DateTime m_DOCUMENT_DATE;
        private int m_SALE_ORDER_ID;
        #endregion
        #region Public Properties
       
        public DateTime DOCUMENT_DATE
        {
            set { m_DOCUMENT_DATE = value; }
            get { return m_DOCUMENT_DATE; }
        }
        public int SALE_ORDER_ID
        {
            set
            {
                m_SALE_ORDER_ID = value;
            }
            get
            {
                return m_SALE_ORDER_ID;
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
        public spSelectPURCHASE_ORDER()
        {
            m_DOCUMENT_DATE = Constants.DateNullValue;
            m_SALE_ORDER_ID = Constants.IntNullValue;
            //m_TYPE_ID = Constants.IntNullValue;
            //m_PURCHASE_ORDER_ID = Constants.LongNullValue;
            //m_DISTRIBUTOR_ID = Constants.IntNullValue;
        }
        #endregion
        #region public Methods
        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp_Name;
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
                command.CommandText = sp_Name;
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
                command.CommandText = sp_Name;
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
                command.CommandText = sp_Name;
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
               
            }
        }
        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection pparams = cmd.Parameters;
            IDataParameter parameter;
            //parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            //parameter.ParameterName = "@DISTRIBUTOR_ID";
            //parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            //if (m_DISTRIBUTOR_ID == Constants.IntNullValue)
            //{
            //    parameter.Value = DBNull.Value;
            //}
            //else
            //{
            //    parameter.Value = m_DISTRIBUTOR_ID;
            //}
            //pparams.Add(parameter);


            //parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            //parameter.ParameterName = "@TYPE_ID";
            //parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            //if (m_TYPE_ID == Constants.IntNullValue)
            //{
            //    parameter.Value = DBNull.Value;
            //}
            //else
            //{
            //    parameter.Value = m_TYPE_ID;
            //}
            //pparams.Add(parameter);

            //parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            //parameter.ParameterName = "@PRINCIPAL_ID";
            //parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            //if (m_PRINCIPAL_ID == Constants.IntNullValue)
            //{
            //    parameter.Value = DBNull.Value;
            //}
            //else
            //{
            //    parameter.Value = m_PRINCIPAL_ID;
            //}
            //pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SALE_ORDER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (m_SALE_ORDER_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_SALE_ORDER_ID;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DOCUMENT_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_DOCUMENT_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_DOCUMENT_DATE;
            }
            pparams.Add(parameter);


        }
        #endregion


    }
}
