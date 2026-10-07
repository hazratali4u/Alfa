using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Market Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Market
    /// </item>
    /// <term>
    /// Update Market
    /// </term>
    /// <item>
    /// Get Market
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class DistributorRouteController
	{
		#region Constructor
		
        /// <summary>
        /// Constructor for DistributorRouteController
        /// </summary>
        public DistributorRouteController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
        #endregion

        #region Public Methods
        
        /// <summary>
        /// Gets Location Markets
        /// </summary>
        /// <remarks>
        /// Returns Location Routes As Datatable
        /// </remarks>
        /// <param name="p_ROUTE_ID">Market</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <returns>Location Routes As Datatable</returns>
        public DataTable SelectDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID,int p_TOWN_ID,long p_AREA_ID) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_ROUTE mDistributor = new spSelectDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mDistributor.AREA_ID = p_AREA_ID;
                mDistributor.TOWN_ID = p_TOWN_ID;  
				mDistributor.ROUTE_ID = p_ROUTE_ID;
                mDistributor.IS_ACTIVE = true;                 
				DataTable dt = mDistributor.ExecuteTable();
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
        /// Inserts Location Market
        /// </summary>
        /// <remarks>
        /// Returns "Record Inserted" on Success And Null on Failure
        /// </remarks>
        /// <param name="p_ROUTE_ID">Market</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_ROUTE_CODE">Code</param>
        /// <param name="p_ROUTE_NAME">Name</param>
        /// <param name="P_IS_ACTIVE">IsActive</param>
        /// <returns>"Record Inserted" on Success And Null on Failure</returns>
		public string InsertDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID,int p_TOWN_ID,long p_AREA_ID,string p_ROUTE_CODE,string p_ROUTE_NAME,bool P_IS_ACTIVE) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_ROUTE mDistributor = new spInsertDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mDistributor.AREA_ID = p_AREA_ID;
                mDistributor.ROUTE_ID = p_ROUTE_ID;
                mDistributor.TOWN_ID = p_TOWN_ID;
                mDistributor.ROUTE_CODE = p_ROUTE_CODE;
				mDistributor.ROUTE_NAME = p_ROUTE_NAME;
                mDistributor.IS_ACTIVE = P_IS_ACTIVE;
                mDistributor.TIME_STAMP = System.DateTime.Today;
                mDistributor.LASTUPDATE_DATE = System.DateTime.Today;                   
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
        /// Updates Location Market
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" on Success And Null on Failure
        /// </remarks>
        /// <param name="p_ROUTE_ID">Market</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_TOWNID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_ROUTE_CODE">Code</param>
        /// <param name="p_ROUTE_NAME">Name</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <returns>"Record Updated" on Success And Null on Failure</returns>
		public string UpdateDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID,int p_TOWNID,long p_AREA_ID,string p_ROUTE_CODE,string p_ROUTE_NAME,bool p_IsActive) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_ROUTE mDistributor = new spUpdateDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;

                mDistributor.ROUTE_ID = p_ROUTE_ID;
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mDistributor.AREA_ID = p_AREA_ID;
                mDistributor.TOWN_ID = p_TOWNID;
                mDistributor.LASTUPDATE_DATE = System.DateTime.Today;   
				mDistributor.ROUTE_CODE = p_ROUTE_CODE;
				mDistributor.ROUTE_NAME = p_ROUTE_NAME;
                mDistributor.IS_ACTIVE = p_IsActive;  
               
				mDistributor.ExecuteQuery();
				return "Record Updated";
				
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
        /// Inserts Markets From Excel File
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_TownId">Town</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="pFileName">ExcelFile</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool ImportMarket(int p_TownId, int p_DistributorId, string pFileName, int p_UserId)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;
            int counter = 1;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";

                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);

                    spInsertDISTRIBUTOR_ROUTE mDistRoute = new spInsertDISTRIBUTOR_ROUTE();
                    mDistRoute.Transaction = mTransaction;
                    mDistRoute.Connection = mConnection;
                    mDistRoute.DISTRIBUTOR_ID = p_DistributorId;
                    mDistRoute.AREA_ID = int.Parse(ParametersArr[0].ToString());
                    mDistRoute.ROUTE_ID = long.Parse(ParametersArr[1].ToString());
                    mDistRoute.ROUTE_CODE = ParametersArr[2].ToString();
                    mDistRoute.ROUTE_NAME = ParametersArr[3].ToString();
                    mDistRoute.TOWN_ID = p_TownId;
                    mDistRoute.LASTUPDATE_DATE = System.DateTime.Now;
                    mDistRoute.TIME_STAMP = System.DateTime.Now;
                    mDistRoute.IS_ACTIVE = true;
                    mDistRoute.ExecuteQuery();
                    counter++;
                }
                mTransaction.Commit();
                return true;

            }

            catch (Exception excp)
            {
                mTransaction.Rollback();
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException("Data Import Error at Row No:" + counter.ToString());
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }
        }

        #endregion
    }
}
