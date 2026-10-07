using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Class For Account Head Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Account Head
    /// </item>
    /// <term>
    /// Update Account Head
    /// </term>
    /// <item>
    /// Get Account Head
    /// </item>
    /// <item>
    /// Assigns/UnAssings Account Head To Principal
    /// </item>
    /// </list>
    /// </example>
	/// </summary>
	public class AccountHeadController
	{
		#region Constructor

        /// <summary>
        /// Constructor for AccountHeadController
        /// </summary>
		public AccountHeadController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods

        #region Select

        /// <summary>
        /// Gets Account Head Data
        /// </summary>
        /// <remarks>
        /// Returns Account Head Data as Datatable
        /// </remarks>
        /// <param name="p_Account_Type_Id">Type</param>
        /// <param name="p_Account_ParentId">Parent</param>
        /// <returns>Account Head Data as Datatable</returns>
        public DataTable SelectAccountHead(int p_Account_Type_Id, long p_Account_ParentId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectACCOUNT_HEAD mAccountHead = new spSelectACCOUNT_HEAD();
                mAccountHead.Connection = mConnection;
                mAccountHead.DISTRIBUTOR_ID = Constants.IntNullValue;
                mAccountHead.ACCOUNT_HEAD_ID = Constants.LongNullValue;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.COMPANY_ID = Constants.LongNullValue;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.IS_ACTIVE = true;
                mAccountHead.TIME_STAMP = Constants.DateNullValue;
                mAccountHead.LASTUPDATE_DATE = Constants.DateNullValue;
                mAccountHead.ACCOUNT_CATEGORY = Constants.IntNullValue;
                DataTable dt = mAccountHead.ExecuteTable();
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
        public DataTable SelectAccountHead2(int p_Account_Type_Id, string p_Account_ParentId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectACCOUNT_HEAD2 mAccountHead = new spSelectACCOUNT_HEAD2();
                mAccountHead.Connection = mConnection;
                mAccountHead.DISTRIBUTOR_ID = Constants.IntNullValue;
                mAccountHead.ACCOUNT_HEAD_ID = Constants.LongNullValue;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.COMPANY_ID = Constants.LongNullValue;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.IS_ACTIVE = true;
                mAccountHead.TIME_STAMP = Constants.DateNullValue;
                mAccountHead.LASTUPDATE_DATE = Constants.DateNullValue;
                mAccountHead.ACCOUNT_CATEGORY = Constants.IntNullValue;
                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets Account Head Data
        /// </summary>
        /// <remarks>
        /// Returns Account Head Data as Datatable
        /// </remarks>
        /// <param name="p_Account_Type_Id">Type</param>
        /// <param name="p_Account_ParentId">Parent</param>
        /// <param name="p_Category">Category</param>
        /// <returns>Account Head Data as Datatable</returns>
        public DataTable SelectAccountHead(int p_Account_Type_Id, long p_Account_ParentId, int p_Category)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectACCOUNT_HEAD mAccountHead = new spSelectACCOUNT_HEAD();
                mAccountHead.Connection = mConnection;
                mAccountHead.DISTRIBUTOR_ID = Constants.IntNullValue;
                mAccountHead.ACCOUNT_HEAD_ID = Constants.LongNullValue;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.COMPANY_ID = Constants.LongNullValue;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.IS_ACTIVE = true;
                mAccountHead.TIME_STAMP = Constants.DateNullValue;
                mAccountHead.LASTUPDATE_DATE = Constants.DateNullValue;
                mAccountHead.ACCOUNT_CATEGORY = p_Category;
                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets Account Head Data
        /// </summary>
        /// <remarks>
        /// Returns Account Head Data as Datatable
        /// </remarks>
        /// <param name="p_Account_MainType_Id">MainType</param>
        /// <param name="p_SubType_Id">SubType</param>
        /// <param name="p_DetailTypeId">DetailType</param>
        /// <param name="p_Category">Category</param>
        /// <param name="pType">Type</param>
        /// <returns>Account Head Data as Datatable</returns>
        public DataTable GetAccountHead(int p_Account_MainType_Id, int p_SubType_Id, int p_DetailTypeId, int p_Category, int pType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetACCOUNT_HEAD mAccountHead = new UspGetACCOUNT_HEAD();
                mAccountHead.Connection = mConnection;
                mAccountHead.ACCOUNT_HEAD_ID = Constants.LongNullValue;
                mAccountHead.Account_TypeId = p_Account_MainType_Id;
                mAccountHead.AccountSub_TypeId = p_SubType_Id;
                mAccountHead.AccountDetail_TypeId = p_DetailTypeId;
                mAccountHead.ACCOUNT_CATEGORY_ID = p_Category;
                mAccountHead.TypeId = pType;
                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets Claim Head Data
        /// </summary>
        /// <param name="p_Account_Type_Id">Type</param>
        /// <returns>Claim Head Data as Datatable</returns>
        public DataTable SelectClaimHead(int p_Account_Type_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                GetClaimHead mAccountHead = new GetClaimHead();
                mAccountHead.Connection = mConnection;
                mAccountHead.SUB_TYPE_ID = p_Account_Type_Id;

                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets General Ledger Data for Account Head ID
        /// </summary>
        /// <remarks>
        /// Returns General Ledger Data for Account Head ID as Datatable
        /// </remarks>
        /// <param name="p_Account_Head_Id">AccountHead</param>
        /// <returns>General Ledger Data for Account Head ID as Datable</returns>
        public DataTable SelectGlTranscton(long p_Account_Head_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCheckGLTransction mAccountHead = new UspCheckGLTransction();
                mAccountHead.Connection = mConnection;
                mAccountHead.Account_Head_id = p_Account_Head_Id;

                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets Account Head Data
        /// </summary>
        /// <remarks>
        /// Returns Account Head Data as Datatable
        /// </remarks>
        /// <param name="p_CompnayId">Company</param>
        /// <param name="p_Account_Head">AccountHead</param>
        /// <param name="p_Account_Type_Id">Type</param>
        /// <param name="p_Account_ParentId">Parent</param>        
        /// <returns>Account Head Data as Datatable</returns>
        public DataTable SelectAccountHead(int p_CompnayId, int p_Account_Head, int p_Account_Type_Id, int p_Account_ParentId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectAccountHead mAccountHead = new UspSelectAccountHead();
                mAccountHead.Connection = mConnection;
                mAccountHead.COMPANY_ID = p_CompnayId;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.ACCOUNT_HEAD_ID = p_Account_Head;
                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets Account InterFace
        /// </summary>
        /// <remarks>
        /// Returns Account InterFace Data as Datatable
        /// </remarks>
        /// <param name="p_SAMSCode">Account</param>
        /// <returns>Account InterFace Data as Datatable</returns>
        public DataTable SelectAccountInterFaceCode(int p_SAMSCode)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectACCOUNT_INTERFACE ObjLedger = new spSelectACCOUNT_INTERFACE();
                ObjLedger.Connection = mConnection;
                ObjLedger.SAME_CODE = p_SAMSCode;
                ObjLedger.DESCRIPTION = null;
                ObjLedger.ACCOUNT_HEAD_ID = Constants.IntNullValue;
                ObjLedger.AccountType = Constants.CharNullValue;
                ObjLedger.VType = Constants.CharNullValue;

                DataTable dt = ObjLedger.ExecuteTable();
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
        #region Added By Hazrat Ali

        /// <summary>
        /// Gets Assigned/UnAssigned Account Head To Principal
        /// <remarks>
        /// Returns Assigned/UnAssigned Account Head To Principal as Datatable
        /// </remarks>
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <returns>Assigned/UnAssigned Account Head To Principal as Datatable</returns>
        public DataTable GetAssign_UnAssign_AccountHead(int p_Principal_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                usp_GetAssign_UnAssign_AccountHead mAccountHead = new usp_GetAssign_UnAssign_AccountHead();
                mAccountHead.Connection = mConnection;
                mAccountHead.PRINCIPAL_ID = p_Principal_ID;

                DataTable dt = mAccountHead.ExecuteTable();
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

        /// <summary>
        /// Gets Assigned Account Heads To Principal
        /// </summary>
        /// <remarks>
        /// Returns Assigned Account Heads To Principal as Datatable
        /// </remarks>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_ACCOUNT_PARENT_ID">Parent</param>
        /// <returns>Assigned Account Heads To Principal as Datatable</returns>
        public DataTable GetAssignAccountHead(int p_Principal_ID, int p_ACCOUNT_PARENT_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                usp_GetAssign_AccountHead mAccountHead = new usp_GetAssign_AccountHead();
                mAccountHead.Connection = mConnection;
                mAccountHead.PRINCIPAL_ID = p_Principal_ID;
                mAccountHead.ACCOUNT_PARENT_ID = p_ACCOUNT_PARENT_ID;
                DataTable dt = mAccountHead.ExecuteTable();
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

        #endregion

        #region Insert, Update

        /// <summary>
        /// Inserts Account Head
        /// <remarks>
        /// Returns Inserted Account Head ID as String
        /// </remarks>
        /// </summary>
        /// <param name="p_Company_id">Company</param>
        /// <param name="p_Is_Active">Active/InActive</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Account_Type_Id">Type</param>
        /// <param name="p_Account_Parent_id">Parent</param>
        /// <param name="p_Account_Name">Name</param>
        /// <param name="p_Account_Code">Code</param>
        /// <param name="p_Index">Category</param>
        /// <returns>Inserted Account Head ID as String</returns>
      	public string InsertAccountHead(int p_Company_id,bool p_Is_Active,DateTime p_Time_Stamp,int p_Distributor_Id,int p_Account_Type_Id,long p_Account_Parent_id,string p_Account_Name,string p_Account_Code,int p_Index) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertACCOUNT_HEAD mAccountHead = new spInsertACCOUNT_HEAD();
				mAccountHead.Connection = mConnection;
                mAccountHead.COMPANY_ID = p_Company_id;
                mAccountHead.DISTRIBUTOR_ID = p_Distributor_Id;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_Parent_id;
                mAccountHead.ACCOUNT_NAME = p_Account_Name;
                mAccountHead.ACCOUNT_CODE = p_Account_Code; 
                mAccountHead.IS_ACTIVE = p_Is_Active;
				mAccountHead.TIME_STAMP = p_Time_Stamp;
                mAccountHead.ACCOUNT_CATEGORY = p_Index;
                mAccountHead.TIME_STAMP = DateTime.Now;
                mAccountHead.LASTUPDATE_DATE = DateTime.Now;
				mAccountHead.ExecuteQuery();
				return mAccountHead.ACCOUNT_HEAD_ID.ToString();
				
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
        /// Updates Account Head
        /// </summary>
        /// <remarks>
        /// Returns Updated Account Head ID as String
        /// </remarks>
        /// <param name="p_Account_Head_Id">AccountHead</param>
        /// <param name="p_Company_Id">Company</param>
        /// <param name="p_Is_Active">Active/InActive</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Account_Type_Id">Type</param>
        /// <param name="p_Account_ParentId">Parent</param>
        /// <param name="p_Account_Name">Name</param>
        /// <param name="p_Account_Code">Code</param>
        /// <param name="p_Index">Category</param>
        /// <returns>Updated Account Head ID as String</returns>
        public string UpdateAccountHead(long p_Account_Head_Id, long p_Company_Id, bool p_Is_Active, DateTime p_Time_Stamp, int p_Distributor_Id, int p_Account_Type_Id, long p_Account_ParentId, string p_Account_Name, string p_Account_Code, int p_Index) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateACCOUNT_HEAD mAccountHead = new spUpdateACCOUNT_HEAD();
				mAccountHead.Connection = mConnection;
				mAccountHead.ACCOUNT_HEAD_ID=p_Account_Head_Id;
				mAccountHead.ACCOUNT_NAME=p_Account_Name;
                mAccountHead.ACCOUNT_CODE = p_Account_Code;  
				mAccountHead.ACCOUNT_TYPE_ID=p_Account_Type_Id;
				mAccountHead.DISTRIBUTOR_ID=p_Distributor_Id;
                mAccountHead.COMPANY_ID = p_Company_Id;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.IS_ACTIVE = p_Is_Active;
				mAccountHead.TIME_STAMP = p_Time_Stamp;
                mAccountHead.LASTUPDATE_DATE = p_Time_Stamp;
                mAccountHead.ACCOUNT_CATEGORY = p_Index; 
				mAccountHead.ExecuteQuery();
				return mAccountHead.ACCOUNT_HEAD_ID.ToString();
				
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
        
        #region Added By Hazrat Ali

        /// <summary>
        /// Assigns/UnAssigns AccountHead To Principal
        /// </summary>
        /// <remarks>
        /// Returns bool
        /// </remarks>
        /// <param name="p_Account_Head_ID">AccountHead</param>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Is_Deleted">Assign/UnAssign</param>
        /// <returns>bool</returns>
        public bool Assign_UnAssign_AccountHead(int p_Account_Head_ID, int p_Principal_ID, bool p_Is_Deleted)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                usp_Assign_UnAssign_AccountHead_Principal mAccountHead = new usp_Assign_UnAssign_AccountHead_Principal();
                mAccountHead.Connection = mConnection;
                mAccountHead.ACCOUNT_HEAD_ID = p_Account_Head_ID;
                mAccountHead.PRINCIPAL_ID = p_Principal_ID;
                mAccountHead.IS_DELETED = p_Is_Deleted;

                bool Bvalue = mAccountHead.ExecuteQuery();
                return Bvalue;


            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
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

        #endregion

        #endregion
    }
}
