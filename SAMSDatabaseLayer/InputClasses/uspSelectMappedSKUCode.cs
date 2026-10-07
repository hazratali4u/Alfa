using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class uspSelectMappedSKUCode
	{
		#region Private Members
		
		private string sp_Name = " uspSelectMappedSKUCode" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_Brnd_Id;
		private int m_Cat_Id;
		private int m_Comp_Id;
		private int m_Prod_Id;
		private int m_Sku_ID;
		private int m_Dist_ID;
		private int m_Div_Id;
		#endregion

		#region Public Properties
		
		public int Brnd_Id
		{
			set
			{
				m_Brnd_Id = value ;
			}
			get
			{
				return m_Brnd_Id;
			}
		}


		public int Cat_Id
		{
			set
			{
				m_Cat_Id = value ;
			}
			get
			{
				return m_Cat_Id;
			}
		}


		public int Comp_Id
		{
			set
			{
				m_Comp_Id = value ;
			}
			get
			{
				return m_Comp_Id;
			}
		}


		public int Prod_Id
		{
			set
			{
				m_Prod_Id = value ;
			}
			get
			{
				return m_Prod_Id;
			}
		}


		public int Sku_ID
		{
			set
			{
				m_Sku_ID = value ;
			}
			get
			{
				return m_Sku_ID;
			}
		}


		public int Dist_ID
		{
			set
			{
				m_Dist_ID = value ;
			}
			get
			{
				return m_Dist_ID;
			}
		}


		public int Div_Id
		{
			set
			{
				m_Div_Id = value ;
			}
			get
			{
				return m_Div_Id;
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
		public uspSelectMappedSKUCode()
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
				cmd.CommandText = "uspSelectMappedSKUCode";
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
				command.CommandText = "uspSelectMappedSKUCode";
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
				command.CommandText = "uspSelectMappedSKUCode";
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
				command.CommandText = "uspSelectMappedSKUCode";
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
					m_Brnd_Id= Convert.ToInt32(dr["Brnd_Id"]);
					m_Cat_Id= Convert.ToInt32(dr["Cat_Id"]);
					m_Prod_Id= Convert.ToInt32(dr["Prod_Id"]);
					m_Sku_ID= Convert.ToInt32(dr["Sku_ID"]);
					m_Dist_ID= Convert.ToInt32(dr["Dist_ID"]);
					m_Div_Id= Convert.ToInt32(dr["Div_Id"]);
				}
			}


		public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Brnd_Id" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Brnd_Id==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Brnd_Id;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Cat_Id" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Cat_Id==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Cat_Id;
			}
			pparams.Add(parameter);


				parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
				parameter.ParameterName = "@Comp_Id" ; 
				parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
				if(m_Cat_Id==Constants.IntNullValue)
				{
					parameter.Value = DBNull.Value;
				}
				else
				{
					parameter.Value = m_Comp_Id;
				}
				pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Prod_Id" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Prod_Id==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Prod_Id;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Sku_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Sku_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Sku_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Dist_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Dist_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Dist_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Div_Id" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Div_Id==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Div_Id;
			}
			pparams.Add(parameter);


		}
		
		
		#endregion

	}
}
