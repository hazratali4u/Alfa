using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;
using System.Collections;


namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Location Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Location
    /// </item>
    /// <term>
    /// Update Location
    /// </term>
    /// <item>
    /// Get Location
    /// </item>
    /// <item>
    /// DayClose
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class DistributorController
	{	
		#region Constructors

        /// <summary>
        /// Constructor for DistributorController
        /// </summary>
		public DistributorController()
		{
			//
			// TODO: Add constructor logic here
			//
			 
		}
		#endregion					
		
		#region Public Static Methods

        /// <summary>
        ///  Static Function Gets Transpoter Data
        /// </summary>
        /// <remarks>
        /// Returns Transpoter Data as Datatable
        /// </remarks>
        /// <returns>Transpoter Data as Datatable</returns>
        public static DataTable SelectTranspoter()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectTRANSPOTER mTranspoter = new spSelectTRANSPOTER();
                mTranspoter.Connection = mConnection;
                DataTable dt = mTranspoter.ExecuteTable();
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
		
		#region public Methods

        #region Select

        /// <summary>
        /// Gets Location Data
        /// </summary>
        /// <remarks>
        /// Returns Location Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Location Data as Datatable</returns>
        public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistributorInfo mDistributorInfo = new uspSelectDistributorInfo();
				mDistributorInfo.Connection = mConnection;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_ID;
                mDistributorInfo.USER_ID = p_User_Id;
                mDistributorInfo.COMPANY_ID = Companyid;   
                
				DataTable dt = mDistributorInfo.ExecuteTable();
				return dt;
				
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
        /// Gets Location Data
        /// </summary>
        /// <remarks>
        /// Returns Location Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_DistributorType">Type</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Location Data as Datatable</returns>
        public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int p_DistributorType, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDistributorInfo mDistributorInfo = new uspSelectDistributorInfo();
                mDistributorInfo.Connection = mConnection;
                mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_ID;
                mDistributorInfo.USER_ID = p_User_Id;
                mDistributorInfo.DISTRIBUTOR_TYPE = p_DistributorType;
                mDistributorInfo.COMPANY_ID = Companyid;
                DataTable dt = mDistributorInfo.ExecuteTable();
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
        /// Gets Location Type Data
        /// </summary>
        /// <remarks>
        /// Returns Location Data Type as Datatable
        /// </remarks>
        /// <param name="p_DistributorType_ID">Type</param>
        /// <returns>Location Type Data as Datatable</returns>
        public DataTable SelectDistributorTypeInfo(int  p_DistributorType_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_TYPE mDistributorType = new spSelectDISTRIBUTOR_TYPE();
				mDistributorType.Connection = mConnection;
				
				mDistributorType.DISTRIBUTOR_TYPE_ID = p_DistributorType_ID;
				DataTable dt = mDistributorType.ExecuteTable();
				return dt;
				
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
        /// Gets Location Data
        /// </summary>
        /// <remarks>
        /// Returns Location Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <returns>Location Data as Datatable</returns>
        public DataTable SelectDistributor(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
				mDistributorInfo.ISDELETED = false;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;
				mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
				mDistributorInfo.USER_ID = Constants.IntNullValue;
				mDistributorInfo.REGION_ID = Constants.IntNullValue;
				mDistributorInfo.ZONE_ID = Constants.IntNullValue;
				mDistributorInfo.SUBZONE_ID = Constants.IntNullValue;
				mDistributorInfo.CONTACT_PERSON = null;
				mDistributorInfo.CONTACT_NUMBER = null;
				mDistributorInfo.GST_NUMBER = null;
				mDistributorInfo.PASSWORD = null;
				mDistributorInfo.ADDRESS1 = null;
				mDistributorInfo.ADDRESS2 = null;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = null;
				mDistributorInfo.DISTRIBUTOR_NAME = null;
				mDistributorInfo.IP_ADDRESS = null;
                //mDistributorInfo.IS_REGISTERED = Constants.IntNullValue;
				DataTable dt = mDistributorInfo.ExecuteTable();
				return dt;
				
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
        /// Gets Location Data
        /// </summary>
        /// <remarks>
        /// Returns Location Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_distributor_type">Type</param>
        /// <param name="p_Company_Id">Company</param>
        /// <returns>Location Data as Datatable</returns>
        public DataTable SelectDistributor(int p_Distributor_Id,int p_distributor_type,int p_Company_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				 
				mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
				mDistributorInfo.ISDELETED = false;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;
				mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
				mDistributorInfo.USER_ID = Constants.IntNullValue;
				mDistributorInfo.REGION_ID = Constants.IntNullValue;
				mDistributorInfo.ZONE_ID = Constants.IntNullValue;
				mDistributorInfo.SUBZONE_ID = p_distributor_type;
				mDistributorInfo.CONTACT_PERSON = null;
				mDistributorInfo.CONTACT_NUMBER = null;
				mDistributorInfo.GST_NUMBER = null;
				mDistributorInfo.PASSWORD = null;
				mDistributorInfo.ADDRESS1 = null;
				mDistributorInfo.ADDRESS2 = null;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = null;
				mDistributorInfo.DISTRIBUTOR_NAME = null;
				mDistributorInfo.IP_ADDRESS = null;
				mDistributorInfo.IS_REGISTERED = true;
                mDistributorInfo.COMPANY_ID = p_Company_Id; 
				DataTable dt = mDistributorInfo.ExecuteTable();
				return dt;
				
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

        public DataTable SelectDistributorUser(int p_Distributor_Id, int p_distributor_type, int p_Company_Id, int p_User_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
                mDistributorInfo.Connection = mConnection;


                mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
                mDistributorInfo.ISDELETED = false;
                mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
                mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;
                mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
                mDistributorInfo.USER_ID = Constants.IntNullValue;
                mDistributorInfo.REGION_ID = Constants.IntNullValue;
                mDistributorInfo.ZONE_ID = Constants.IntNullValue;
                mDistributorInfo.SUBZONE_ID = p_distributor_type;
                mDistributorInfo.CONTACT_PERSON = null;
                mDistributorInfo.CONTACT_NUMBER = null;
                mDistributorInfo.GST_NUMBER = null;
                mDistributorInfo.PASSWORD = null;
                mDistributorInfo.ADDRESS1 = null;
                mDistributorInfo.ADDRESS2 = null;
                mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistributorInfo.DISTRIBUTOR_CODE = null;
                mDistributorInfo.DISTRIBUTOR_NAME = null;
                mDistributorInfo.IP_ADDRESS = null;
                mDistributorInfo.IS_REGISTERED = true;
                mDistributorInfo.COMPANY_ID = p_Company_Id;
                mDistributorInfo.USER_ID = p_User_ID;
                DataTable dt = mDistributorInfo.ExecuteTable();
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
        /// Gets Max DayClose
        /// </summary>
        /// <remarks>
        /// Returns Max DayClose as Datatable
        /// </remarks>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Status">Status</param>
        /// <returns>Max DayClose as Datatable</returns>
        public DataTable MaxDayClose(int p_Distributor_ID, int p_Status)
        {
            DataTable dt = new DataTable();

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectMaxDayCloseDistributor obj = new UspSelectMaxDayCloseDistributor();
                obj.Connection = mConnection;
                obj.DISTRIBUTOR_ID = p_Distributor_ID;
                obj.STATUS = p_Status;
                dt = obj.ExecuteTable();
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
        /// Gets Max DayClose
        /// </summary>
        /// <remarks>
        /// Returns Max DayClose as Datatable
        /// </remarks>
        /// <param name="UserId">InsertedBy</param>
        /// <param name="Distributor_id">Location</param>
        /// <returns>Max DayClose as Datatable</returns>
        public DataTable SelectMaxDayClose(int UserId, int Distributor_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectMaxDayClose mMaxClose = new uspSelectMaxDayClose();
                mMaxClose.Connection = mConnection;
                mMaxClose.USER_ID = UserId;
                mMaxClose.DISTRIBUTOR_ID = Distributor_id;
                DataTable mLastClose = mMaxClose.ExecuteTable();
                return mLastClose;
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

        public DataTable GetDistributorHierarchy(int pDistributorId)
        {
            IDbConnection mconnection = null;
            DataTable mDistHierarchy = new DataTable();

            try
            {
                mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mconnection.Open();

                usp_GetDistributorHierarchy mGetDistHierarchy = new usp_GetDistributorHierarchy();
                mGetDistHierarchy.Connection = mconnection;
                mGetDistHierarchy.DistributorId = pDistributorId;
                mGetDistHierarchy.ExecuteTable();
                mDistHierarchy = mGetDistHierarchy.ExecuteTable();
                return mDistHierarchy;
            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
                return null;
            }
            finally
            {
                if (mconnection != null && mconnection.State == ConnectionState.Open)
                {
                    mconnection.Close();
                }
            }
        }
        
        #region Added By Hazrat Ali        

        /// <summary>
        /// Gets Location Data
        /// </summary>
        /// <remarks>
        /// Returns Location Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_distributor_type">Type</param>
        /// <param name="p_Company_Id">Company</param>
        /// <returns>Location Data as Datatable</returns>
        public DataTable SelectAllDistributors(int p_Distributor_Id, int p_distributor_type, int p_Company_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectAllDISTRIBUTOR mDistributorInfo = new uspSelectAllDISTRIBUTOR();
                mDistributorInfo.Connection = mConnection;


                mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
                mDistributorInfo.ISDELETED = false;
                mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
                mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;
                mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
                mDistributorInfo.USER_ID = Constants.IntNullValue;
                mDistributorInfo.REGION_ID = Constants.IntNullValue;
                mDistributorInfo.ZONE_ID = Constants.IntNullValue;
                mDistributorInfo.SUBZONE_ID = p_distributor_type;
                mDistributorInfo.CONTACT_PERSON = null;
                mDistributorInfo.CONTACT_NUMBER = null;
                mDistributorInfo.GST_NUMBER = null;
                mDistributorInfo.PASSWORD = null;
                mDistributorInfo.ADDRESS1 = null;
                mDistributorInfo.ADDRESS2 = null;
                mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistributorInfo.DISTRIBUTOR_CODE = null;
                mDistributorInfo.DISTRIBUTOR_NAME = null;
                mDistributorInfo.IP_ADDRESS = null;
                mDistributorInfo.IS_REGISTERED = true;
                mDistributorInfo.COMPANY_ID = p_Company_Id;
                DataTable dt = mDistributorInfo.ExecuteTable();
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
        /// Gets Menu Hierarchy For Bread Crumb
        /// </summary>
        /// <param name="p_MODULE_ID">ModuleID</param>
        /// <returns>Menu Hierarchy as Datatable</returns>
        public DataTable GetBreadCrumb(int p_MODULE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spGetBreadCrumb mBreadCrumb = new spGetBreadCrumb();
                mBreadCrumb.Connection = mConnection;


                mBreadCrumb.MODULE_ID = p_MODULE_ID;

                DataTable dt = mBreadCrumb.ExecuteTable();
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

        #region Insert, Update, And Delete

        /// <summary>
        /// Inserts Location
        /// </summary>
        /// <remarks>
        /// Returns Inserted Location ID as String
        /// </remarks>
        /// <param name="p_Company">Company</param>
        /// <param name="p_Dist_Class_Id">Class</param>
        /// <param name="p_IsDeleted">IsDeleted</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_LastUpdate_Date">LastUpdateDate</param>
        /// <param name="p_Division_Id">Division</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Region_Id">Region</param>
        /// <param name="p_Zone_Id">Zone</param>
        /// <param name="p_SubZone_Id">SubZone</param>
        /// <param name="p_Contact_Person">ContactPerson</param>
        /// <param name="p_Contact_Number">ContactNo</param>
        /// <param name="p_Gst_Number">GSTNo</param>
        /// <param name="p_Password">Password</param>
        /// <param name="p_Address1">Address1</param>
        /// <param name="p_Address2">Address2</param>
        /// <param name="p_Distributor_Code">Code</param>
        /// <param name="p_Distributor_Name">Name</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_Is_Registered">IsRegistered</param>
        /// <param name="p_CREDIT_LEVEL">CreditLevel</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>Inserted Location ID as String</returns>
        public string InsertDistributor(int p_Company, int p_Dist_Class_Id, bool p_IsDeleted, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered, int p_CREDIT_LEVEL, int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR mDistributorInfo = new spInsertDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
                mDistributorInfo.COMPANY_ID = p_Company;
                mDistributorInfo.USER_ID = p_UserId;   
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
                mDistributorInfo.TIME_STAMP = p_Time_Stamp;
				mDistributorInfo.LASTUPDATE_DATE = p_LastUpdate_Date;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CREDIT_LEVEL = p_CREDIT_LEVEL;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
                mDistributorInfo.USER_ID = p_UserId;   
				mDistributorInfo.IP_ADDRESS = p_Ip_Address;
                mDistributorInfo.ISDELETED = p_IsDeleted;
                mDistributorInfo.IS_REGISTERED = p_Is_Registered;  
                mDistributorInfo.ExecuteQuery();
				
				return mDistributorInfo.DISTRIBUTOR_ID.ToString();
				
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
        /// Updates Location
        /// </summary>
        /// <remarks>
        /// Returns Inserted Location ID as String
        /// </remarks>
        /// <param name="p_CompanyId">Company</param>
        /// <param name="p_Dist_Class_Id">Class</param>
        /// <param name="p_IsDeleted">IsDeleted</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_LastUpdate_Date">LastUpdateDate</param>
        /// <param name="p_Division_Id">Division</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Region_Id">Region</param>
        /// <param name="p_Zone_Id">Zone</param>
        /// <param name="p_SubZone_Id">SubZone</param>
        /// <param name="p_Contact_Person">ContactPerson</param>
        /// <param name="p_Contact_Number">ContactNo</param>
        /// <param name="p_Gst_Number">GSTNo</param>
        /// <param name="p_Password">Password</param>
        /// <param name="p_Address1">Address1</param>
        /// <param name="p_Address2">Address2</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Distributor_Code">Code</param>
        /// <param name="p_Distributor_Name">Name</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_Is_Registered">IsRegistered</param>
        /// <param name="p_CREDIT_LEVEL">CreditLevel</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>"Record Updated." On Success and Exception.Message on Failure</returns>
		public string UpdateDistributor(int p_CompanyId,int p_Dist_Class_Id, bool p_IsDeleted, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered,int p_CREDIT_LEVEL,int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR mDistributorInfo = new spUpdateDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
                mDistributorInfo.COMPANY_ID = p_CompanyId; 
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				mDistributorInfo.TIME_STAMP = p_Time_Stamp;
				mDistributorInfo.LASTUPDATE_DATE = p_LastUpdate_Date;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CREDIT_LEVEL = p_CREDIT_LEVEL;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = p_Ip_Address;
                mDistributorInfo.IS_REGISTERED = p_Is_Registered;
                mDistributorInfo.USER_ID = p_UserId;
                mDistributorInfo.ISDELETED = p_IsDeleted;
                mDistributorInfo.ExecuteQuery();
				return "Record Updated.";
				
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
        /// Closes Day Transactions And Insert Relevant Data To GL
        /// </summary>
        /// <remarks>
        /// This Function Performs Following Tasks
        /// <list type="bullet">
        /// <item>
        /// Closes Day Transactions
        /// </item>
        /// <item>
        /// Inserts Cash Data To GL Through PostCashDeposit() Function
        /// </item>
        /// <item>
        /// Inserts Cheques Data To GL Through PostCashDeposit() Function
        /// </item>
        /// <item>
        /// Inserts Expenses Data To GL Through PettyDeposit() Function
        /// </item>
        /// <item>
        /// Inserts Sales And Sales Return Data To GL Through PostSaleVoucher() Function
        /// </item>
        /// <iterm>
        /// Inserts Purchase Data To GL Through PostPurchaseVoucher() Function
        /// </iterm>
        /// <item>
        /// Inserts Purchase Return Data To GL Through PostPurchaseReturnVoucher() Function
        /// </item>
        /// <item>
        /// Inserts Rate Difference Data To GL Through PostRateDifferenceVoucher() Function
        /// </item>
        /// </list>
        /// </remarks>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="Distributor_id">Location</param>
        /// <param name="UserId">InsertedBy</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UspDayClose(DateTime p_DayClose, int Distributor_id, int UserId)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                UspDayClosing mMaxClose = new UspDayClosing();
                mMaxClose.Connection = mConnection;
                mMaxClose.Transaction = mTransaction;
                mMaxClose.DAYCLOSE = p_DayClose;
                mMaxClose.DISTRIBUTOR_ID = Distributor_id;
                mMaxClose.USER_ID = UserId;
                bool mLastClose = mMaxClose.ExecuteQuery();
                if (mLastClose == true)
                {
                    mTransaction.Commit();
                    bool PostCashTrans = PostCashDeposit(p_DayClose, Distributor_id, UserId, Constants.IntNullValue, Constants.Bank_Deposit);
                    bool PostChequeTrans = PostCashDeposit(p_DayClose, Distributor_id, UserId, Constants.IntNullValue, Constants.Cheque_Relization);
                    bool PostExpTrans = PettyDeposit(p_DayClose, Distributor_id, UserId, Constants.IntNullValue, Constants.Document_Petty_Cash);
                    bool PostSaleTrans = PostSaleVoucher(p_DayClose, Distributor_id, UserId);
                    PostPurchaseVoucher(p_DayClose, Distributor_id, UserId);
                    bool PostPurchaseReturnTrans = PostPurchaseReturnVoucher(p_DayClose, Distributor_id, UserId);
                    bool PostRateDiffTrans = PostRateDifferenceVoucher(p_DayClose, Distributor_id, UserId);
                }
                else
                {
                    mTransaction.Rollback();
                }
                return mLastClose;
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
        /// Inserts Cash And Cheques To GL
        /// </summary>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="Distributor_id">Location</param>
        /// <param name="UserId">InsertedBy</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_TransTypeID">TransactionType</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PostCashDeposit(DateTime p_DayClose, int Distributor_id, int UserId, int p_PrincipalId, int p_TransTypeID)
        {
            LedgerController mLController = new LedgerController();
            SAMSCommon.Classes.Configuration.GetAccountHead();
            bool IsSaveVoucher = false;

            try
            {
                DataTable dt = mLController.SelectBankDeposit(p_TransTypeID, Distributor_id, Constants.IntNullValue, p_DayClose);
                foreach (DataRow row in dt.Rows)
                {

                    string remarks = "N/A";
                    DataTable dtVoucher = new DataTable();
                    dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
                    dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
                    dtVoucher.Columns.Add("Debit", typeof(decimal));
                    dtVoucher.Columns.Add("Credit", typeof(decimal));
                    dtVoucher.Columns.Add("Remarks", typeof(string));
                    dtVoucher.Columns.Add("Principal_Id", typeof(string));

                    DataRow dr = dtVoucher.NewRow();
                    dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                    if (p_TransTypeID == 22)
                    {
                        dr["ACCOUNT_HEAD_ID"] = row["ACCOUNT_HEAD_ID"];
                        remarks = "Cash Deposit For " + row["Principal"].ToString();
                    }
                    else if (p_TransTypeID == 27)
                    {
                        dr["ACCOUNT_HEAD_ID"] = row["ACCOUNT_HEAD_ID"];
                        remarks = "Petty Cash Transfer from NCS : For " + row["Principal"].ToString();
                    }
                    else
                    {
                        dr["ACCOUNT_HEAD_ID"] = row["ACCOUNT_HEAD_ID"];
                        remarks = "Cheque Deposit For " + row["Principal"].ToString();
                    }
                    dr["REMARKS"] = remarks;
                    dr["DEBIT"] = decimal.Parse(row["cheque_Deposit"].ToString());
                    dr["CREDIT"] = 0;
                    dr["Principal_Id"] = row["Principal_id"].ToString();
                    dtVoucher.Rows.Add(dr);
                    ///Credit Side Entry
                    DataRow dr1 = dtVoucher.NewRow();
                    dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr1["ACCOUNT_HEAD_ID"] = SAMSCommon.Classes.Configuration.MainCashSaled_Head;
                    dr1["DEBIT"] = 0;
                    dr1["CREDIT"] = decimal.Parse(row["cheque_Deposit"].ToString());
                    dr1["Principal_Id"] = row["Principal_id"].ToString();
                    dr1["REMARKS"] = remarks;
                    dtVoucher.Rows.Add(dr1);
                    if (p_TransTypeID == 27)
                    {
                        string MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, Distributor_id, p_DayClose);

                        IsSaveVoucher = mLController.Add_Voucher(Distributor_id, int.Parse(row["Principal_id"].ToString()), MaxDocumentId, Constants.Journal_Voucher, p_DayClose, Constants.CashPayment, "N/A", "Defualt Petty Cash Transfer", Constants.DateNullValue, null, dtVoucher, UserId, null, Constants.DateNullValue);
                    }
                    else
                    {
                        string MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Bank_Voucher, Distributor_id, p_DayClose);

                        IsSaveVoucher = mLController.Add_Voucher(Distributor_id, int.Parse(row["Principal_id"].ToString()), MaxDocumentId, Constants.Bank_Voucher, p_DayClose, Constants.Bank_Deposit, "N/A", "Defualt Bank Deposit Voucher", DateTime.Parse(row["CHQUE_DATE"].ToString()), row["cheque_No"].ToString(), dtVoucher, UserId, row["SLIP_NO"].ToString(), Constants.DateNullValue);
                    }
                }
                return IsSaveVoucher;
            }


            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }

        }

        /// <summary>
        /// Inserts Expenses To GL
        /// </summary>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="Distributor_id">Location</param>
        /// <param name="UserId">InsertedBy</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_TransTypeID">TransactionType</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PettyDeposit(DateTime p_DayClose, int Distributor_id, int UserId, int p_PrincipalId, int p_TransTypeID)
        {
            LedgerController mLController = new LedgerController();
            SAMSCommon.Classes.Configuration.GetAccountHead();
            bool IsSaveVoucher = false;

            try
            {
                DataTable dt = mLController.SelectBankDeposit(p_TransTypeID, Distributor_id, Constants.IntNullValue, p_DayClose);
                decimal p_Debit = 0;
                decimal p_Credit = 0;
                DataTable dtVoucher = new DataTable();
                dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
                dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
                dtVoucher.Columns.Add("Debit", typeof(decimal));
                dtVoucher.Columns.Add("Credit", typeof(decimal));
                dtVoucher.Columns.Add("Remarks", typeof(string));
                dtVoucher.Columns.Add("Principal_Id", typeof(string));

                foreach (DataRow row in dt.Rows)
                {

                    DataRow dr = dtVoucher.NewRow();
                    dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr["ACCOUNT_HEAD_ID"] = row["ACCOUNT_HEAD_ID"];
                    dr["REMARKS"] = "Cash Transfer from NCS : For " + row["Principal"].ToString();
                    dr["DEBIT"] = decimal.Parse(row["DEBIT"].ToString());
                    dr["CREDIT"] = decimal.Parse(row["CREDIT"].ToString());
                    dr["Principal_Id"] = row["PRINCIPAL_ID"].ToString();
                    p_Debit += decimal.Parse(row["DEBIT"].ToString());
                    p_Credit += decimal.Parse(row["CREDIT"].ToString());
                    dtVoucher.Rows.Add(dr);
                }

                DataRow dr1 = dtVoucher.NewRow();
                dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                dr1["ACCOUNT_HEAD_ID"] = SAMSCommon.Classes.Configuration.MainCashSaled_Head;
                dr1["DEBIT"] = p_Credit;
                dr1["CREDIT"] = p_Debit;
                dr1["Principal_Id"] = "0";
                dr1["REMARKS"] = "Cash Transfer from NCS : For General";
                dtVoucher.Rows.Add(dr1);

                string MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, Distributor_id, p_DayClose);

                IsSaveVoucher = mLController.Add_Voucher(Distributor_id, 0, MaxDocumentId, Constants.Journal_Voucher, p_DayClose, Constants.CashPayment, "N/A", "Defualt Petty Cash Transfer", Constants.DateNullValue, null, dtVoucher, UserId, null, Constants.DateNullValue);

                return IsSaveVoucher;
            }


            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }

        }

        /// <summary>
        /// Inserts Sales And Sales Return To GL
        /// </summary>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="Distributor_id">Location</param>
        /// <param name="UserId">InsertedBy</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PostSaleVoucher(DateTime p_DayClose, int Distributor_id, int UserId)
        {
            LedgerController mLController = new LedgerController();
            IDbConnection mConnection = null;
            bool IsSaveVoucher = false;
            DataTable dt = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspMakeDailySaleJVForPost ObjGetJV = new UspMakeDailySaleJVForPost();
                ObjGetJV.Connection = mConnection;
                ObjGetJV.DISTRIBUTOR_ID = Distributor_id;
                ObjGetJV.DAY_CLOSED = p_DayClose;
                dt = ObjGetJV.ExecuteTable();

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                //return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

            try
            {

                DataTable dtVoucher = new DataTable();
                dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
                dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
                dtVoucher.Columns.Add("Debit", typeof(decimal));
                dtVoucher.Columns.Add("Credit", typeof(decimal));
                dtVoucher.Columns.Add("Remarks", typeof(string));
                dtVoucher.Columns.Add("Principal_Id", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    DataRow dr = dtVoucher.NewRow();
                    dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr["ACCOUNT_HEAD_ID"] = row["ACCOUNT_HEAD_ID"];
                    dr["REMARKS"] = row["REMARKS"];
                    dr["DEBIT"] = decimal.Parse(row["DebitAmount"].ToString());
                    dr["CREDIT"] = decimal.Parse(row["CreditAmount"].ToString());
                    dr["Principal_Id"] = row["Principal_id"].ToString();
                    dtVoucher.Rows.Add(dr);
                }


                string MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, Distributor_id, p_DayClose);

                IsSaveVoucher = mLController.Add_Voucher(Distributor_id, 0, MaxDocumentId, Constants.Journal_Voucher, p_DayClose, Constants.CashPayment, "N/A", "Default Sales Voucher", Constants.DateNullValue, null, dtVoucher, UserId, null, Constants.DateNullValue);

                return IsSaveVoucher;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }

        }

        /// <summary>
        /// Inserts Purchases To GL
        /// </summary>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="Distributor_id">Location</param>
        /// <param name="UserId">InsertedBy</param>
        public void PostPurchaseVoucher(DateTime p_DayClose, int Distributor_id, int UserId)
        {
            LedgerController mLController = new LedgerController();
            IDbConnection mConnection = null;
            DataTable dt = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                PurchaseController mPurchase = new PurchaseController();
                DataTable PurchaseDocumentNo = mPurchase.SelectPurchaseDocumentNo(Constants.Document_Purchase, Distributor_id, p_DayClose);
                foreach (DataRow drP in PurchaseDocumentNo.Rows)
                {
                    MakePurchaseJV ObjGetJV = new MakePurchaseJV();
                    ObjGetJV.Connection = mConnection;
                    ObjGetJV.DISTRIBUTOR_ID = Distributor_id;
                    ObjGetJV.DOCUMENT_DATE = p_DayClose;
                    ObjGetJV.PURCHASE_MASTER_ID = int.Parse(drP["PURCHASE_MASTER_ID"].ToString());
                    ObjGetJV.TYPE_ID = Constants.Document_Purchase;
                    dt = ObjGetJV.ExecuteTable();

                    DataTable dtVoucher = new DataTable();
                    dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
                    dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
                    dtVoucher.Columns.Add("Debit", typeof(decimal));
                    dtVoucher.Columns.Add("Credit", typeof(decimal));
                    dtVoucher.Columns.Add("Remarks", typeof(string));
                    dtVoucher.Columns.Add("Principal_Id", typeof(string));

                    Decimal TOTALCREDITAMOUNT = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (decimal.Parse(row["DebitAmount"].ToString()) > 0 || decimal.Parse(row["CreditAmount"].ToString()) > 0)
                        {
                            AccountHeadController ah = new AccountHeadController();

                            DataTable dtAccountHead = ah.SelectAccountInterFaceCode(int.Parse(row["ACCOUNT_HEAD_ID"].ToString()));

                            DataRow dr = dtVoucher.NewRow();
                            dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                            dr["ACCOUNT_HEAD_ID"] = dtAccountHead.Rows[0]["ACCOUNT_HEAD_ID"].ToString();
                            dr["REMARKS"] = "Default Purchase Voucher";
                            dr["DEBIT"] = decimal.Parse(row["DebitAmount"].ToString());
                            dr["CREDIT"] = decimal.Parse(row["CreditAmount"].ToString());
                            dr["Principal_Id"] = row["Principal_id"].ToString();
                            TOTALCREDITAMOUNT += decimal.Parse(row["DebitAmount"].ToString());
                            dtVoucher.Rows.Add(dr);
                        }
                    }

                    DataRow dr1 = dtVoucher.NewRow();
                    dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr1["ACCOUNT_HEAD_ID"] = "88";
                    dr1["REMARKS"] = "Default Purchase Voucher";
                    dr1["DEBIT"] = 0;
                    dr1["CREDIT"] = TOTALCREDITAMOUNT.ToString();
                    dr1["Principal_Id"] = drP["SOLD_FROM"].ToString();
                    dtVoucher.Rows.Add(dr1);

                    string MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, Distributor_id, p_DayClose);

                    mLController.Add_Voucher(Distributor_id, int.Parse(drP["SOLD_FROM"].ToString()), MaxDocumentId, Constants.Journal_Voucher, p_DayClose, Constants.CashPayment, "N/A", "Default Purchase Voucher", Constants.DateNullValue, drP["ORDER_NUMBER"].ToString(), dtVoucher, UserId, null, Constants.DateNullValue);


                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);

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
        /// Inserts Rate Differences To GL
        /// </summary>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="UserId">InsertedBy</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PostRateDifferenceVoucher(DateTime p_DayClose, int p_Distributor_ID, int UserId)
        {
            LedgerController mLController = new LedgerController();
            IDbConnection mConnection = null;
            bool IsSaveVoucher = false;
            DataTable dt = null;
            ArrayList alPrincipalIDs = new ArrayList();

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspGetGLRateDifferencePrincipals objRateDifferencePrinciapl = new uspGetGLRateDifferencePrincipals();
                objRateDifferencePrinciapl.Connection = mConnection;
                objRateDifferencePrinciapl.DISTRIBUTOR_ID = p_Distributor_ID;
                objRateDifferencePrinciapl.DAY_CLOSE = p_DayClose;
                DataTable dtPrincipals = objRateDifferencePrinciapl.ExecuteTable();

                foreach (DataRow drPrincipal in dtPrincipals.Rows)
                {
                    uspGetGLRateDifference objRateDifference = new uspGetGLRateDifference();
                    objRateDifference.Connection = mConnection;
                    objRateDifference.DISTRIBUTOR_ID = p_Distributor_ID;
                    objRateDifference.DAY_CLOSE = p_DayClose;
                    objRateDifference.PRINCIPAL_ID = int.Parse(drPrincipal["PRINCIPAL_ID"].ToString());
                    dt = objRateDifference.ExecuteTable();

                    DataTable dtVoucher = new DataTable();
                    dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
                    dtVoucher.Columns.Add("Debit", typeof(decimal));
                    dtVoucher.Columns.Add("Credit", typeof(decimal));
                    dtVoucher.Columns.Add("Remarks", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        AccountHeadController ah = new AccountHeadController();

                        DataTable dtAccountHead = ah.SelectAccountInterFaceCode(int.Parse(row["ACCOUNT_HEAD_ID"].ToString()));

                        DataRow dr = dtVoucher.NewRow();
                        dr["ACCOUNT_HEAD_ID"] = dtAccountHead.Rows[0]["ACCOUNT_HEAD_ID"].ToString();
                        dr["REMARKS"] = "Rate Difference Voucher";
                        dr["DEBIT"] = decimal.Parse(row["DebitAmount"].ToString());
                        dr["CREDIT"] = decimal.Parse(row["CreditAmount"].ToString());
                        dtVoucher.Rows.Add(dr);
                    }
                    string MaxDocumentID = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, p_Distributor_ID, p_DayClose);
                    IsSaveVoucher = mLController.Add_RateDifference_Voucher(p_Distributor_ID, int.Parse(drPrincipal["Principal_ID"].ToString()), MaxDocumentID, Constants.Journal_Voucher, p_DayClose, Constants.CashPayment, "N/A", "Rate Difference Voucher", Constants.DateNullValue, "N/A", dtVoucher, UserId, null);
                }
                return IsSaveVoucher;
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
        /// Inserts Purchase Return To GL
        /// </summary>
        /// <param name="p_DayClose">ClosingDate</param>
        /// <param name="Distributor_id">Location</param>
        /// <param name="UserId">InsertedBy</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PostPurchaseReturnVoucher(DateTime p_DayClose, int Distributor_id, int UserId)
        {
            LedgerController mLController = new LedgerController();
            IDbConnection mConnection = null;
            DataTable dt = null;
            bool IsSaveVoucher = false;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                PurchaseController mPurchase = new PurchaseController();
                DataTable PurchaseDocumentNo = mPurchase.SelectPurchaseDocumentNo(Constants.Document_Purchase_Return, Distributor_id, p_DayClose);
                foreach (DataRow drP in PurchaseDocumentNo.Rows)
                {
                    MakePurchaseJV ObjGetJV = new MakePurchaseJV();
                    ObjGetJV.Connection = mConnection;
                    ObjGetJV.DISTRIBUTOR_ID = Distributor_id;
                    ObjGetJV.DOCUMENT_DATE = p_DayClose;
                    ObjGetJV.PURCHASE_MASTER_ID = int.Parse(drP["PURCHASE_MASTER_ID"].ToString());
                    ObjGetJV.TYPE_ID = Constants.Document_Purchase_Return;
                    dt = ObjGetJV.ExecuteTable();

                    DataTable dtVoucher = new DataTable();
                    dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
                    dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
                    dtVoucher.Columns.Add("Debit", typeof(decimal));
                    dtVoucher.Columns.Add("Credit", typeof(decimal));
                    dtVoucher.Columns.Add("Remarks", typeof(string));
                    dtVoucher.Columns.Add("Principal_Id", typeof(string));

                    Decimal TOTALCREDITAMOUNT = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (decimal.Parse(row["DebitAmount"].ToString()) > 0 || decimal.Parse(row["CreditAmount"].ToString()) > 0)
                        {
                            AccountHeadController ah = new AccountHeadController();

                            DataTable dtAccountHead = ah.SelectAccountInterFaceCode(int.Parse(row["ACCOUNT_HEAD_ID"].ToString()));

                            DataRow dr = dtVoucher.NewRow();
                            dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                            dr["ACCOUNT_HEAD_ID"] = dtAccountHead.Rows[0]["ACCOUNT_HEAD_ID"].ToString();
                            dr["REMARKS"] = "Default Purchase Voucher";
                            dr["DEBIT"] = decimal.Parse(row["CreditAmount"].ToString());
                            dr["CREDIT"] = decimal.Parse(row["DebitAmount"].ToString());
                            dr["Principal_Id"] = row["Principal_id"].ToString();
                            TOTALCREDITAMOUNT += decimal.Parse(row["DebitAmount"].ToString());
                            dtVoucher.Rows.Add(dr);


                        }
                    }

                    DataRow dr1 = dtVoucher.NewRow();
                    dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr1["ACCOUNT_HEAD_ID"] = "88";
                    dr1["REMARKS"] = "Default Purchase Return Voucher";
                    dr1["DEBIT"] = TOTALCREDITAMOUNT.ToString();
                    dr1["CREDIT"] = 0;
                    dr1["Principal_Id"] = drP["PRINCIPAL_ID"].ToString();
                    dtVoucher.Rows.Add(dr1);

                    string MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, Distributor_id, p_DayClose);

                    IsSaveVoucher = mLController.Add_Voucher(Distributor_id, int.Parse(drP["PRINCIPAL_ID"].ToString()), MaxDocumentId, Constants.Journal_Voucher, p_DayClose, Constants.CashPayment, "N/A", "Default Purchase Return Voucher", Constants.DateNullValue, drP["ORDER_NUMBER"].ToString(), dtVoucher, UserId, null, Constants.DateNullValue);
                }
                return IsSaveVoucher;
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

        #region licence
        public DataTable GetLicenseData()
        {
            DataTable dt = new DataTable();

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspGetLicenseData obj = new uspGetLicenseData();
                obj.Connection = mConnection;
                dt = obj.ExecuteTable();
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

        public string InsertLicense(int p_DAYS, string p_LICENSE, DateTime p_TRANSACTION_DATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspInsertLicense mLicense = new uspInsertLicense();
                mLicense.Connection = mConnection;
                mLicense.DAYS = p_DAYS;
                mLicense.LICENSE = p_LICENSE;
                mLicense.TRANSACTION_DATE = p_TRANSACTION_DATE;

                mLicense.ExecuteQuery();

                return "Record Inserted";

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
    }
}
