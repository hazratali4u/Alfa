using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Gettting Max ID Or Code
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Gets Max ID Of Any Table
    /// </item>
    /// <term>
    /// Gets Max Code
    /// </term>
    /// </list>
    /// </example>
    /// </summary>
	public class SETTINGS_TABLE_Controller
	{
		#region Constructor
		
        /// <summary>
        /// Constructor for SETTINGS_TABLE_Controller
        /// </summary>
        public SETTINGS_TABLE_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
        #endregion

		#region Public Methods

        /// <summary>
        /// Gets Max ID for Any Table
        /// </summary>
        /// <remarks>
        /// Returns Max ID as Datatable
        /// </remarks>
        /// <param name="p_TableName">Table</param>
        /// <param name="FeildName">Column</param>
        /// <param name="DistributorId">Location</param>
        /// <returns>Max ID as Datatable</returns>
		public DataTable Select_SETTINGS_TABLE(string p_TableName,string FeildName,int DistributorId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSETTINGS_TABLE selectdata = new uspSelectSETTINGS_TABLE();
				selectdata.Connection = mConnection;
                selectdata.TableName = p_TableName;
                selectdata.FieldName = FeildName;
                selectdata.DistributorId = DistributorId;  
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();
				return dtSAMStransfermaster;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}
        
        /// <summary>
        /// Gets Max Code
        /// <remarks>
        /// Returns Code as String
        /// </remarks>
        /// </summary>
        /// <param name="p_code">Code</param>
        /// <param name="p_type">Type</param>
        /// <param name="p_value">Value</param>
        /// <returns>Code as String</returns>
		public string GetAutoCode(string p_code,int p_type,long p_value)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
				selectdata.Connection = mConnection;
				selectdata.Code = p_code;
				selectdata.type = p_type;
				selectdata.value =  p_value;
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

				long Current  = long.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
				string Code  = Current.ToString(); 
				
				if(Code.Length == 1)
				{
					Code   = "00" + Code;
				}
				else if(Code.Length == 2) 
				{
					Code   = "0" + Code;
				}
				else 
				{
					Code   =  Code;
				}
				return p_code + Code;	
				
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}
        
        /// <summary>
        /// Gets Max Customer Code
        /// </summary>
        /// <remarks>
        /// Returns Max Customer Code as Long
        /// </remarks>
        /// <param name="p_code">Code</param>
        /// <param name="p_type">Type</param>
        /// <param name="p_value">Value</param>
        /// <returns>Max Customer Code as Long</returns>
        public long GetAutoCustomerCode(string p_code, int p_type, long p_value)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
                selectdata.Connection = mConnection;
                selectdata.Code = p_code;
                selectdata.type = p_type;
                selectdata.value = p_value;
                DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

                return long.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
                 
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return -1;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
		
		#endregion
	}
}
