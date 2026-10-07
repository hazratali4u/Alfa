using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Slash Codes Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Slash Codes
    /// </item>
    /// <term>
    /// Update Slash Codes
    /// </term>
    /// <item>
    /// Get Slash Codes
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class SLASHCodesController
	{	
		#region Constructors

        /// <summary>
        /// Constructor for SLASHCodesController
        /// </summary>
		public SLASHCodesController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
				
		#region public Methods

        #region Select

        /// <summary>
        /// Gets Slash Codes
        /// </summary>
        /// <remarks>
        /// Returns Slash Codes as Datatable
        /// </remarks>
        /// <param name="p_RefID">SlashCode</param>
        /// <param name="p_SlashCode">Code</param>
        /// <param name="p_Parent_Ref_ID">Parent</param>
        /// <param name="p_SlashDesc">Description</param>
        /// <param name="p_Status">Status</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <returns>Slash Codes as Datatable</returns>
        public DataTable SelectSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCODES mSlashCodes = new spSelectCODES();
                mSlashCodes.Connection = mConnection;
                mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
                mSlashCodes.SLASH_CODE = p_SlashCode;
                mSlashCodes.SLASH_DESC = p_SlashDesc;
                mSlashCodes.TIME_STAMP = Constants.DateNullValue;
                mSlashCodes.STATUS = p_Status;
                mSlashCodes.REF_ID = p_RefID;
                mSlashCodes.IS_ACTIVE = p_IsActive;
                DataTable dt = mSlashCodes.ExecuteTable();
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

        #region Insert, Update

        /// <summary>
        /// Inserts Slash Code
        /// </summary>
        /// <remarks>
        /// Returns "Record Inserted" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_SlashCode">SlashCode</param>
        /// <param name="p_Parent_Ref_ID">Parent</param>
        /// <param name="p_SlashDesc">Desctiption</param>
        /// <param name="p_Status">Status</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <returns>"Record Inserted" On Success And Exception.Message On Failure</returns>
        public string InsertSlashCodes(string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
				spInsertCODES mSlashCodes = new spInsertCODES();
				mSlashCodes.Connection = mConnection;
				mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
				mSlashCodes.SLASH_CODE = p_SlashCode;
				mSlashCodes.SLASH_DESC = p_SlashDesc;
				mSlashCodes.TIME_STAMP = DateTime.Now;
				mSlashCodes.STATUS = p_Status;
				mSlashCodes.IS_ACTIVE = p_IsActive;
				mSlashCodes.ExecuteQuery();
				return "Record Inserted";
				
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

        /// <summary>
        /// Updates Slash Code
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_RefID">SlashCode</param>
        /// <param name="p_SlashCode">Code</param>
        /// <param name="p_Parent_Ref_ID">Parent</param>
        /// <param name="p_SlashDesc">Description</param>
        /// <param name="p_Status">Status</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <returns>"Record Updated" On Success And Exception.Message On Failure</returns>
		public string UpdateSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive, DateTime p_Time_Stamp)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateCODES mSlashCodes = new spUpdateCODES();
				mSlashCodes.Connection = mConnection;
				mSlashCodes.REF_ID = p_RefID;
				mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
				mSlashCodes.SLASH_CODE = p_SlashCode;
				mSlashCodes.SLASH_DESC = p_SlashDesc;
				mSlashCodes.TIME_STAMP = p_Time_Stamp;
				mSlashCodes.STATUS = p_Status;
				mSlashCodes.IS_ACTIVE = p_IsActive;

				mSlashCodes.ExecuteQuery();
				
				return "Record Updated";
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
