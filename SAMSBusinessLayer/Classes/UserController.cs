using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For User Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert User
    /// </item>
    /// <term>
    /// Update User
    /// </term>
    /// <item>
    /// Get User
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class UserController
	{		
		#region Constructors

        /// <summary>
        /// Constructor for UserController
        /// </summary>
        public UserController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
				
		#region public Methods

        #region Select

        /// <summary>
        /// Gets Login User Data
        /// </summary>
        /// Reutns Login User Data as Datatable
        /// <param name="p_LoginId">Login</param>
        /// <param name="p_Password">Password</param>
        /// <returns>Login User Data as Datatable</returns>
        public DataTable SelectSlashUser(string p_LoginId, string p_Password)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelect_USER mSlashUser = new spSelect_USER();
                mSlashUser.Connection = mConnection;
                mSlashUser.LOGIN_ID = p_LoginId;
                mSlashUser.PASSWORD = p_Password;
                mSlashUser.IS_ACTIVE = true;

                DataTable dt = mSlashUser.ExecuteTable();
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
        /// Gets User Data To Change Password
        /// </summary>
        /// Returns User Data as Datatable
        /// <param name="p_User_ID">User</param>
        /// <returns>User Data as Datatable</returns>
        public DataTable SelectSlashUser(int p_User_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelect_USER mSlashUser = new spSelect_USER();
                mSlashUser.Connection = mConnection;
                mSlashUser.USER_ID = p_User_ID;
                mSlashUser.IS_ACTIVE = true;

                DataTable dt = mSlashUser.ExecuteTable();
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
        /// Gets Locations Assigned To a User
        /// </summary>
        /// <remarks>
        /// Returns Locations Assigned To a User as Datatable
        /// </remarks>
        /// <param name="UserId">User</param>
        /// <param name="DistributorTypeid">LocationType</param>
        /// <param name="TypeiD">Type</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Locations Assigned To a User as Datatable</returns>
        public DataTable SelectUserAssignment(int UserId, int DistributorTypeid, int TypeiD, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectUnAssignDistributor mUserAssing = new UspSelectUnAssignDistributor();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.TYPE_ID = TypeiD;
                mUserAssing.COMPANY_ID = Companyid;
                DataTable dt = mUserAssing.ExecuteTable();
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
        /// Gets User Data
        /// </summary>
        /// <remarks>
        /// Returns User Data as Datatable
        /// </remarks>
        /// <returns>User Data as Datatable</returns>
        public DataTable SelectAllUser()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectAllUsers mUser = new uspSelectAllUsers();
                mUser.Connection = mConnection;

                DataTable dt = new DataTable();
                dt = mUser.ExecuteTable();

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

        #region Insert, Update, Delete

        /// <summary>
        /// Inserts User
        /// </summary>
        /// <remarks>
        /// Returns Inserted User ID as String
        /// </remarks>
        /// <param name="User_Id">User</param>
        /// <param name="p_CompanyId">Company</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_LoginId">Login</param>
        /// <param name="p_Password">Password</param>
        /// <param name="p_RoleId">Role</param>
        /// <returns>Inserted User ID as String</returns>
		public string InsertSlashUser(int User_Id,int p_CompanyId,int p_DistributorId,string p_LoginId , string p_Password, int p_RoleId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsert_USER mSlashUser = new spInsert_USER();
				mSlashUser.Connection = mConnection;
                mSlashUser.USER_ID = User_Id;  
				mSlashUser.DISTRIBUTOR_ID = p_DistributorId;
                mSlashUser.COMPANY_ID = p_CompanyId;  
				mSlashUser.LOGIN_ID = p_LoginId;
				mSlashUser.PASSWORD = p_Password;
                mSlashUser.ROLE_ID = p_RoleId;
				mSlashUser.LASTUPDATE_DATE =  System.DateTime.Today;
                mSlashUser.ExecuteQuery();
				return mSlashUser.USER_ID.ToString ();
				
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
        /// Inserts Locations Assigned To User
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="UserId">User</param>
        /// <param name="DistributorTypeid">LocationType</param>
        /// <param name="DistributorId">Location</param>
        /// <param name="Companyid">Company</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool InsertUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_ASSIGNMENT mUserAssing = new spInsertDISTRIBUTOR_ASSIGNMENT();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.DISTRIBUTOR_ID = DistributorId;
                mUserAssing.COMPANY_ID = Companyid;
                bool dt = mUserAssing.ExecuteQuery();
                return dt;
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

        /// <summary>
        /// Updates User
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message on Failure
        /// </remarks>
        /// <param name="p_UserId">User</param>
        /// <param name="p_CompanyId">Company</param>
        /// <param name="p_LoginId">Login</param>
        /// <param name="p_Password">Password</param>
        /// <param name="p_RoleId">Role</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <param name="p_DistributorID">Location</param>
        /// <returns>"Record Updated" On Success And Exception.Message on Failure</returns>
        public string UpdateUser(int p_UserId,int p_CompanyId,string p_LoginId , string p_Password, int p_RoleId, bool p_IsActive, int p_DistributorID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spUpdateUSER mSlashUser = new spUpdateUSER();
				mSlashUser.Connection = mConnection;
				
                mSlashUser.USER_ID = p_UserId;  
                mSlashUser.DISTRIBUTOR_ID = p_DistributorID;
                mSlashUser.COMPANY_ID = p_CompanyId;
                mSlashUser.LOGIN_ID = p_LoginId;
				mSlashUser.PASSWORD = p_Password;
				mSlashUser.ROLE_ID = p_RoleId;
				mSlashUser.IS_ACTIVE = p_IsActive;
                mSlashUser.LASTUPDATE_DATE =  System.DateTime.Today;
                mSlashUser.ExecuteQuery();
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
     
        /// <summary>
        /// Deletes Location Assignment To User
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="UserId">User</param>
        /// <param name="DistributorTypeid">LocationType</param>
        /// <param name="DistributorId">Location</param>
        /// <param name="Companyid">Company</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool DeleteUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spDeleteDISTRIBUTOR_ASSIGNMENT mUserAssing = new spDeleteDISTRIBUTOR_ASSIGNMENT();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.DISTRIBUTOR_ID = DistributorId;
                mUserAssing.COMPANY_ID = Companyid;   
                bool dt = mUserAssing.ExecuteQuery();
                return dt;
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
        
        #region Added By Hazrat Ali
        
        /// <summary>
        /// Inserts User Login Time
        /// </summary>
        /// <remarks>
        /// Returns Inserted User Login ID as Long
        /// </remarks>
        /// <param name="User_ID">User</param>
        /// <returns>Inserted User Login ID as Long</returns>
        public long InsertUserLoginTime(int User_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertUSER_LOG mSlashUserLog = new spInsertUSER_LOG();
                mSlashUserLog.Connection = mConnection;
                mSlashUserLog.User_ID = User_ID;
                string User_Log_ID = mSlashUserLog.ExecuteScalar();
                return Convert.ToInt64(User_Log_ID);

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return 0;
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
        /// Inserts User Logout Time
        /// </summary>
        /// <remarks>
        /// Returns "Logout Time Inserted" on Success And Exception.Message on Failure
        /// </remarks>
        /// <param name="p_User_Log_ID">UserLog</param>
        /// <param name="p_UserID">User</param>
        /// <returns>"Logout Time Inserted" on Success And Exception.Message on Failure</returns>
        public string InsertUserLogoutTime(long p_User_Log_ID,int p_UserID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spUpdateUSER_LOG mSlashUserLog = new spUpdateUSER_LOG();
                mSlashUserLog.Connection = mConnection;

                mSlashUserLog.User_Log_ID = p_User_Log_ID;
                mSlashUserLog.User_ID = p_UserID;
                mSlashUserLog.ExecuteQuery();
                return "Logout Time Inserted";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
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
        /// Inserts Page Visit History
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="p_MODULE_KEY">Page</param>
        /// <param name="p_SAMS_USER_ID">User</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool InsertViewLog(string p_MODULE_KEY, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspInsertViewHistory mViewHistory = new uspInsertViewHistory();
                mViewHistory.Connection = mConnection;
                mViewHistory.MODULE_KEY = p_MODULE_KEY;
                mViewHistory.USER_ID = p_USER_ID;
                return mViewHistory.ExecuteQuery();                

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
