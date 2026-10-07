using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Sheme Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Sheme
    /// </item>
    /// <item>
    /// Get Sheme
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class SchemeController
	{
		#region Constructors

        /// <summary>
        /// Constructor For SchemeController
        /// </summary>
		public SchemeController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
        #endregion
				
		#region public Methods

        #region Select

        /// <summary>
        /// Gets Schems
        /// </summary>
        /// <remarks>
        /// Returns Schemes Data as Datatable
        /// </remarks>
        /// <param name="p_Scheme_Id">Scheme</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Scheme_Code">Code</param>
        /// <param name="p_Scheme_Desc">Description</param>
        /// <param name="p_Scheme_Date">Date</param>
        /// <returns>Schemes Data as Datatable</returns>
        public DataTable SelectScheme(int p_Scheme_Id, int p_Distributor_Id, string p_Scheme_Code, string p_Scheme_Desc, DateTime p_Scheme_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectSCHEME mScheme = new spSelectSCHEME();
                mScheme.Connection = mConnection;

                mScheme.SCHEME_ID = p_Scheme_Id;
                mScheme.DISTRIBUTOR_ID = p_Distributor_Id;
                mScheme.SCHEME_CODE = p_Scheme_Code;
                mScheme.SCHEME_DESC = p_Scheme_Desc;
                mScheme.SCHEME_DATE = p_Scheme_Date;

                DataTable dt = mScheme.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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

        #region Insert

        /// <summary>
        /// Inserts Scheme
        /// </summary>
        /// <remarks>
        /// Returns Inserted Scheme ID as String
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Scheme_Code">Code</param>
        /// <param name="p_Scheme_Desc">Description</param>
        /// <param name="p_Scheme_Date">Date</param>
        /// <returns>Inserted Scheme ID as String</returns>
        public string InsertScheme(int p_Distributor_Id,string p_Scheme_Code,string p_Scheme_Desc,DateTime p_Scheme_Date)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertSCHEME mScheme = new spInsertSCHEME();
				mScheme.Connection = mConnection;

				mScheme.DISTRIBUTOR_ID = p_Distributor_Id;
				mScheme.SCHEME_CODE = p_Scheme_Code;
				mScheme.SCHEME_DESC = p_Scheme_Desc;
				mScheme.SCHEME_DATE = p_Scheme_Date;

				mScheme.ExecuteQuery();
				return mScheme.SCHEME_ID.ToString() ;
				
			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
        }

        #endregion

        #endregion
    }
}
