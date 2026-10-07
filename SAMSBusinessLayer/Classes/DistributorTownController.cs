using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Town Assignment Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Inserts Town Assignment
    /// </item>
    /// <term>
    /// Deletes Town Assignment
    /// </term>
    /// <item>
    /// Get Town Assignment
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class DistributorTownController
	{		
		#region Constructors

        /// <summary>
        /// Constructor for DistributorTownController
        /// </summary>
		public DistributorTownController()
		{
			
		}

		#endregion
				
		#region Private Variables
		
		#endregion

		#region public Properties
		
		#endregion
		
		#region public static Methods
		#endregion

		#region Private Methods
		#endregion
		
		#region public Methods

        /// <summary>
        /// Inserts Town Assignment
        /// </summary>
        /// <remarks>
        /// Returns "Record Inserted" on Success And Null On Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Town_Id">Town</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="p_AREA_Id">Area</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>"Record Inserted" on Success And Null On Failure</returns>
        public string InsertDistributorTown(int p_Distributor_Id, int p_Town_Id, bool p_Is_Active, int p_AREA_Id, string p_Ip_Address, int p_UserId) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_TOWN mDistributor = new spInsertDISTRIBUTOR_TOWN();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TOWN_ID = p_Town_Id;
				mDistributor.IS_ACTIVE = p_Is_Active;
				mDistributor.USER_ID = p_UserId;
                mDistributor.TIME_STAMP = System.DateTime.Now ;
				mDistributor.LASTUPDATE_DATE = System.DateTime.Now ;
				mDistributor.IP_ADDRESS = p_Ip_Address;
                
				mDistributor.ExecuteQuery();
				return "Record Inserted";
				
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
        /// Deletes Town Assignment
        /// </summary>
        /// <remarks>
        /// Returns "Record Deleted." on Success And Null on Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Town_Id">Town</param>
        /// <returns>"Record Deleted." on Success And Null on Failure</returns>
	    public string DeletedDistributorTown(int p_Distributor_Id, int p_Town_Id)
		{			
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDISTRIBUTOR_TOWN mDistributor = new spDeleteDISTRIBUTOR_TOWN ();
				mDistributor.Connection = mConnection;

				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TOWN_ID = p_Town_Id;
                
				mDistributor.ExecuteQuery();
				return "Record Deleted.";
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
        /// Gets Town Data
        /// </summary>
        /// <param name="p_PARAENT_ID">Territory</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="TypeId">Type</param>
        /// <returns>Town Data As Datatable</returns>
        public DataTable SelectAssignTown(int p_PARAENT_ID, int p_DISTRIBUTOR_ID, int TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetAssignTown mGeoHierarchy = new UspGetAssignTown();
                mGeoHierarchy.Connection = mConnection;
                mGeoHierarchy.PARENT_ID = p_PARAENT_ID;
                mGeoHierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mGeoHierarchy.TYPE = TypeId;
                DataTable dt = mGeoHierarchy.ExecuteTable();
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
	}
}
