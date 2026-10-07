using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
    public class spUpdateEMPLOYEE_INFORMATION
    {
        #region Private Members
        private string sp_Name = " spUpdateEMPLOYEE_INFORMATION";
        private IDbConnection m_connection;
        private IDbTransaction m_transaction;


        private int m_EMPLOYEE_ID;
        private int m_LOCATION_ID;
        private int m_EMPLOYEE_TYPE_ID;
        private int m_DEPARTMENT_ID;
        private int m_DESIGNATION_ID;
        private int m_TOWN_ID;
        private int m_AREA_ID;
        private int m_EMPLOYEE_NORMS_ID;
        private DateTime m_DATE_BIRTH;
        private DateTime m_DATE_JOIN;
        private DateTime m_LASTUPDATED;
        private bool m_IS_ACTIVE;
        private decimal m_BASIC_SALARY;
        private string m_EMPLOYEE_NAME;
        private string m_FATHER_NAME;
        private string m_ACCOUNT_NO;
        private string m_BANK_NAME;
        private string m_BRANCH;
        private string m_NIC_NO;
        private string m_PERMANENT_ADDRESS;
        private string m_PHONE_NO;
        private string m_CELL_NO;
        private string m_EMAIL_ADDRESS;
        private string m_NATIONALTY;
        private string m_RELIGION;
        private string m_GENDER;
        private string m_MATRIAL_STATUS;
        private string m_BLOOD_GROUP;
        private string m_PRESENT_ADDRESS;
        #endregion


        #region Public Properties
        public int EMPLOYEE_ID
        {
            set
            {
                m_EMPLOYEE_ID = value;
            }
            get
            {
                return m_EMPLOYEE_ID;
            }
        }


        public int LOCATION_ID
        {
            set
            {
                m_LOCATION_ID = value;
            }
            get
            {
                return m_LOCATION_ID;
            }
        }


        public int EMPLOYEE_TYPE_ID
        {
            set
            {
                m_EMPLOYEE_TYPE_ID = value;
            }
            get
            {
                return m_EMPLOYEE_TYPE_ID;
            }
        }


        public int DEPARTMENT_ID
        {
            set
            {
                m_DEPARTMENT_ID = value;
            }
            get
            {
                return m_DEPARTMENT_ID;
            }
        }


        public int DESIGNATION_ID
        {
            set
            {
                m_DESIGNATION_ID = value;
            }
            get
            {
                return m_DESIGNATION_ID;
            }
        }


        public int TOWN_ID
        {
            set
            {
                m_TOWN_ID = value;
            }
            get
            {
                return m_TOWN_ID;
            }
        }


        public int AREA_ID
        {
            set
            {
                m_AREA_ID = value;
            }
            get
            {
                return m_AREA_ID;
            }
        }


        public int EMPLOYEE_NORMS_ID
        {
            set
            {
                m_EMPLOYEE_NORMS_ID = value;
            }
            get
            {
                return m_EMPLOYEE_NORMS_ID;
            }
        }


        public DateTime DATE_BIRTH
        {
            set
            {
                m_DATE_BIRTH = value;
            }
            get
            {
                return m_DATE_BIRTH;
            }
        }


        public DateTime DATE_JOIN
        {
            set
            {
                m_DATE_JOIN = value;
            }
            get
            {
                return m_DATE_JOIN;
            }
        }


        public DateTime LASTUPDATED
        {
            set
            {
                m_LASTUPDATED = value;
            }
            get
            {
                return m_LASTUPDATED;
            }
        }


        public bool IS_ACTIVE
        {
            set
            {
                m_IS_ACTIVE = value;
            }
            get
            {
                return m_IS_ACTIVE;
            }
        }


        public decimal BASIC_SALARY
        {
            set
            {
                m_BASIC_SALARY = value;
            }
            get
            {
                return m_BASIC_SALARY;
            }
        }


        public string EMPLOYEE_NAME
        {
            set
            {
                m_EMPLOYEE_NAME = value;
            }
            get
            {
                return m_EMPLOYEE_NAME;
            }
        }


        public string FATHER_NAME
        {
            set
            {
                m_FATHER_NAME = value;
            }
            get
            {
                return m_FATHER_NAME;
            }
        }


        public string ACCOUNT_NO
        {
            set
            {
                m_ACCOUNT_NO = value;
            }
            get
            {
                return m_ACCOUNT_NO;
            }
        }


        public string BANK_NAME
        {
            set
            {
                m_BANK_NAME = value;
            }
            get
            {
                return m_BANK_NAME;
            }
        }


        public string BRANCH
        {
            set
            {
                m_BRANCH = value;
            }
            get
            {
                return m_BRANCH;
            }
        }


        public string NIC_NO
        {
            set
            {
                m_NIC_NO = value;
            }
            get
            {
                return m_NIC_NO;
            }
        }


        public string PERMANENT_ADDRESS
        {
            set
            {
                m_PERMANENT_ADDRESS = value;
            }
            get
            {
                return m_PERMANENT_ADDRESS;
            }
        }


        public string PHONE_NO
        {
            set
            {
                m_PHONE_NO = value;
            }
            get
            {
                return m_PHONE_NO;
            }
        }


        public string CELL_NO
        {
            set
            {
                m_CELL_NO = value;
            }
            get
            {
                return m_CELL_NO;
            }
        }


        public string EMAIL_ADDRESS
        {
            set
            {
                m_EMAIL_ADDRESS = value;
            }
            get
            {
                return m_EMAIL_ADDRESS;
            }
        }


        public string NATIONALTY
        {
            set
            {
                m_NATIONALTY = value;
            }
            get
            {
                return m_NATIONALTY;
            }
        }


        public string RELIGION
        {
            set
            {
                m_RELIGION = value;
            }
            get
            {
                return m_RELIGION;
            }
        }


        public string GENDER
        {
            set
            {
                m_GENDER = value;
            }
            get
            {
                return m_GENDER;
            }
        }


        public string MATRIAL_STATUS
        {
            set
            {
                m_MATRIAL_STATUS = value;
            }
            get
            {
                return m_MATRIAL_STATUS;
            }
        }


        public string BLOOD_GROUP
        {
            set
            {
                m_BLOOD_GROUP = value;
            }
            get
            {
                return m_BLOOD_GROUP;
            }
        }


        public string PRESENT_ADDRESS
        {
            set
            {
                m_PRESENT_ADDRESS = value;
            }
            get
            {
                return m_PRESENT_ADDRESS;
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
        public spUpdateEMPLOYEE_INFORMATION()
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
                cmd.CommandText = "spUpdateEMPLOYEE_INFORMATION";
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
                command.CommandText = "spUpdateEMPLOYEE_INFORMATION";
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
                command.CommandText = "spUpdateEMPLOYEE_INFORMATION";
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
                command.CommandText = "spUpdateEMPLOYEE_INFORMATION";
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
                m_EMPLOYEE_ID = Convert.ToInt32(dr["EMPLOYEE_ID"]);
                m_LOCATION_ID = Convert.ToInt32(dr["LOCATION_ID"]);
                m_EMPLOYEE_TYPE_ID = Convert.ToInt32(dr["EMPLOYEE_TYPE_ID"]);
                m_DEPARTMENT_ID = Convert.ToInt32(dr["DEPARTMENT_ID"]);
                m_DESIGNATION_ID = Convert.ToInt32(dr["DESIGNATION_ID"]);
                m_TOWN_ID = Convert.ToInt32(dr["TOWN_ID"]);
                m_AREA_ID = Convert.ToInt32(dr["AREA_ID"]);
                m_EMPLOYEE_NORMS_ID = Convert.ToInt32(dr["EMPLOYEE_NORMS_ID"]);
                m_DATE_BIRTH = Convert.ToDateTime(dr["DATE_BIRTH"]);
                m_DATE_JOIN = Convert.ToDateTime(dr["DATE_JOIN"]);
                m_LASTUPDATED = Convert.ToDateTime(dr["LASTUPDATED"]);
                m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                m_BASIC_SALARY = Convert.ToDecimal(dr["BASIC_SALARY"]);
                m_EMPLOYEE_NAME = Convert.ToString(dr["EMPLOYEE_NAME"]);
                m_FATHER_NAME = Convert.ToString(dr["FATHER_NAME"]);
                m_ACCOUNT_NO = Convert.ToString(dr["ACCOUNT_NO"]);
                m_BANK_NAME = Convert.ToString(dr["BANK_NAME"]);
                m_BRANCH = Convert.ToString(dr["BRANCH"]);
                m_NIC_NO = Convert.ToString(dr["NIC_NO"]);
                m_PERMANENT_ADDRESS = Convert.ToString(dr["PERMANENT_ADDRESS"]);
                m_PHONE_NO = Convert.ToString(dr["PHONE_NO"]);
                m_CELL_NO = Convert.ToString(dr["CELL_NO"]);
                m_EMAIL_ADDRESS = Convert.ToString(dr["EMAIL_ADDRESS"]);
                m_NATIONALTY = Convert.ToString(dr["NATIONALTY"]);
                m_RELIGION = Convert.ToString(dr["RELIGION"]);
                m_GENDER = Convert.ToString(dr["GENDER"]);
                m_MATRIAL_STATUS = Convert.ToString(dr["MATRIAL_STATUS"]);
                m_BLOOD_GROUP = Convert.ToString(dr["BLOOD_GROUP"]);
                m_PRESENT_ADDRESS = Convert.ToString(dr["PRESENT_ADDRESS"]);
            }
        }


        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection pparams = cmd.Parameters;
            IDataParameter parameter;
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMPLOYEE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_EMPLOYEE_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_EMPLOYEE_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LOCATION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_LOCATION_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_LOCATION_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMPLOYEE_TYPE_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_EMPLOYEE_TYPE_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_EMPLOYEE_TYPE_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DEPARTMENT_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_DEPARTMENT_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_DEPARTMENT_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DESIGNATION_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_DESIGNATION_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_DESIGNATION_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TOWN_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_TOWN_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_TOWN_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@AREA_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_AREA_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_AREA_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMPLOYEE_NORMS_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_EMPLOYEE_NORMS_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_EMPLOYEE_NORMS_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DATE_BIRTH";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_DATE_BIRTH == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_DATE_BIRTH;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DATE_JOIN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_DATE_JOIN == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_DATE_JOIN;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LASTUPDATED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_LASTUPDATED == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_LASTUPDATED;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = m_IS_ACTIVE;
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BASIC_SALARY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (m_BASIC_SALARY == Constants.DecimalNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_BASIC_SALARY;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMPLOYEE_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_EMPLOYEE_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_EMPLOYEE_NAME;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FATHER_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_FATHER_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_FATHER_NAME;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ACCOUNT_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_ACCOUNT_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_ACCOUNT_NO;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BANK_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_BANK_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_BANK_NAME;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BRANCH";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_BRANCH == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_BRANCH;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@NIC_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_NIC_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_NIC_NO;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PERMANENT_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_PERMANENT_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_PERMANENT_ADDRESS;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PHONE_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_PHONE_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_PHONE_NO;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CELL_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_CELL_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CELL_NO;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMAIL_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_EMAIL_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_EMAIL_ADDRESS;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@NATIONALTY";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_NATIONALTY == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_NATIONALTY;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@RELIGION";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_RELIGION == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_RELIGION;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GENDER";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_GENDER == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_GENDER;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@MATRIAL_STATUS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_MATRIAL_STATUS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_MATRIAL_STATUS;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@BLOOD_GROUP";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_BLOOD_GROUP == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_BLOOD_GROUP;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@PRESENT_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_PRESENT_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_PRESENT_ADDRESS;
            }
            pparams.Add(parameter);


        }
        #endregion
    }
}
