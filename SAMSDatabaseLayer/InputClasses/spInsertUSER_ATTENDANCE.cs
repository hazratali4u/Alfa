using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;



namespace SAMSDatabaseLayer.Classes
{
	public class spInsertUSER_ATTENDANCE
	{
		#region Private Members
		private string sp_Name = " spInsertUSER_ATTENDANCE" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_ATTENDANCE_ID;
		private bool m_O_S;
		private bool m_HOLIDAY;
		private bool m_IS_PRESENT;
		private bool m_L_C_A;
		private bool m_L_O_S;
		private DateTime m_ATTENDANCE_DATE;
		private DateTime m_TIME_IN;
		private DateTime m_TIME_OUT;
		private decimal m_MAINTENANCE;
		private int m_DISTRIBUTOR_ID;
		private int m_ATTENDANCE_MARKED_BY;
		private int m_ATTENDANCE_FOR;
		private decimal m_MILEAGE;
		#endregion


		#region Public Properties
		public long ATTENDANCE_ID
		{
			get
			{
				return m_ATTENDANCE_ID;
			}
			set
			{
				m_ATTENDANCE_ID=value;
			}

		}


		public bool O_S
		{
			set
			{
				m_O_S = value ;
			}
			get
			{
				return m_O_S;
			}
		}


		public bool HOLIDAY
		{
			set
			{
				m_HOLIDAY = value ;
			}
			get
			{
				return m_HOLIDAY;
			}
		}


		public bool IS_PRESENT
		{
			set
			{
				m_IS_PRESENT = value ;
			}
			get
			{
				return m_IS_PRESENT;
			}
		}


		public bool L_C_A
		{
			set
			{
				m_L_C_A = value ;
			}
			get
			{
				return m_L_C_A;
			}
		}


		public bool L_O_S
		{
			set
			{
				m_L_O_S = value ;
			}
			get
			{
				return m_L_O_S;
			}
		}


		public DateTime ATTENDANCE_DATE
		{
			set
			{
				m_ATTENDANCE_DATE = value ;
			}
			get
			{
				return m_ATTENDANCE_DATE;
			}
		}


		public DateTime TIME_IN
		{
			set
			{
				m_TIME_IN = value ;
			}
			get
			{
				return m_TIME_IN;
			}
		}


		public DateTime TIME_OUT
		{
			set
			{
				m_TIME_OUT = value ;
			}
			get
			{
				return m_TIME_OUT;
			}
		}


		public decimal MAINTENANCE
		{
			set
			{
				m_MAINTENANCE = value ;
			}
			get
			{
				return m_MAINTENANCE;
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


		public int ATTENDANCE_MARKED_BY
		{
			set
			{
				m_ATTENDANCE_MARKED_BY = value ;
			}
			get
			{
				return m_ATTENDANCE_MARKED_BY;
			}
		}


		public int ATTENDANCE_FOR
		{
			set
			{
				m_ATTENDANCE_FOR = value ;
			}
			get
			{
				return m_ATTENDANCE_FOR;
			}
		}


		public decimal MILEAGE
		{
			set
			{
				m_MILEAGE = value ;
			}
			get
			{
				return m_MILEAGE;
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
		public spInsertUSER_ATTENDANCE()
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
				cmd.CommandText = "spInsertUSER_ATTENDANCE";
				cmd.Connection =   m_connection;
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_ATTENDANCE_ID = (long)((IDataParameter)(cmd.Parameters["@ATTENDANCE_ID"])).Value;
				return true;
			}
			catch(Exception e)
			{
				return false;
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
				command.CommandText = "spInsertUSER_ATTENDANCE";
				command.Connection = m_connection;
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
			{
				return null;
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
				command.CommandText = "spInsertUSER_ATTENDANCE";
				command.Connection = m_connection;
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
				command.CommandText = "spInsertUSER_ATTENDANCE";
				command.Connection = m_connection;
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
				if(dr.Read() == true)
				{
					DataRow first_row = (DataRow)dr[0];
					m_ATTENDANCE_ID=Convert.ToInt64(first_row["ATTENDANCE_ID"]);
					m_O_S=Convert.ToBoolean(first_row["O_S"]);
					m_HOLIDAY=Convert.ToBoolean(first_row["HOLIDAY"]);
					m_IS_PRESENT=Convert.ToBoolean(first_row["IS_PRESENT"]);
					m_L_C_A=Convert.ToBoolean(first_row["L_C_A"]);
					m_L_O_S=Convert.ToBoolean(first_row["L_O_S"]);
					m_ATTENDANCE_DATE= Convert.ToDateTime(first_row["ATTENDANCE_DATE"]);
					m_TIME_IN= Convert.ToDateTime(first_row["TIME_IN"]);
					m_TIME_OUT= Convert.ToDateTime(first_row["TIME_OUT"]);
					m_MAINTENANCE= Convert.ToDecimal(first_row["MAINTENANCE"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(first_row["DISTRIBUTOR_ID"]);
					m_ATTENDANCE_MARKED_BY= Convert.ToInt32(first_row["ATTENDANCE_MARKED_BY"]);
					m_ATTENDANCE_FOR= Convert.ToInt32(first_row["ATTENDANCE_FOR"]);
					m_MILEAGE= Convert.ToDecimal(first_row["MILEAGE"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ATTENDANCE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@O_S" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_O_S;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@HOLIDAY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_HOLIDAY;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_PRESENT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_PRESENT;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@L_C_A" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_L_C_A;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@L_O_S" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_L_O_S;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ATTENDANCE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_ATTENDANCE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ATTENDANCE_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TIME_IN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TIME_IN==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TIME_IN;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TIME_OUT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TIME_OUT==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TIME_OUT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MAINTENANCE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_MAINTENANCE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MAINTENANCE;
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
			parameter.ParameterName = "@ATTENDANCE_MARKED_BY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ATTENDANCE_MARKED_BY==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ATTENDANCE_MARKED_BY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ATTENDANCE_FOR" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ATTENDANCE_FOR==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ATTENDANCE_FOR;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MILEAGE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_MILEAGE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MILEAGE;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
