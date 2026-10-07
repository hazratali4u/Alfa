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
    /// Class For Route Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Route
    /// </item>
    /// <term>
    /// Update Route
    /// </term>
    /// <item>
    /// Get Route
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class DistributorAreaController
    {
        #region Constuctor

        /// <summary>
        /// Constructor For DistributorAreaController
        /// </summary>
        public DistributorAreaController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        /// <summary>
        /// Gets Route Data
        /// </summary>
        /// <remarks>
        /// Returns Route Data as Datatable
        /// </remarks>
        /// <param name="p_Area_Id">Route</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_LastUpdate_Date">LastUpdateDate</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Territory_Id">Territory</param>
        /// <param name="p_Area_Name">Name</param>
        /// <param name="p_Area_Code">Code</param>
        /// <returns>Route Data as Datatable</returns>
        public DataTable SelectDist_Area(long p_Area_Id, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectDISTRIBUTOR_AREA mDistArea = new spSelectDISTRIBUTOR_AREA();
                mDistArea.Connection = mConnection;
                mDistArea.AREA_CODE = p_Area_Code;
                mDistArea.AREA_ID = p_Area_Id;
                mDistArea.AREA_NAME = p_Area_Name;
                mDistArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistArea.LASTUPDATE_DATE = p_LastUpdate_Date;
                mDistArea.TOWN_ID = p_Territory_Id;

                DataTable dt = mDistArea.ExecuteTable();
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
        /// Inserts Route
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Area_Id">Route</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Territory_Id">Territory</param>
        /// <param name="p_Area_Name">Name</param>
        /// <param name="p_Area_Code">Code</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool insertDisct_Area(long p_Area_Id, bool p_IsActive, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_AREA mDistArea = new spInsertDISTRIBUTOR_AREA();
                mDistArea.Connection = mConnection;
                mDistArea.AREA_ID = p_Area_Id;
                mDistArea.AREA_CODE = p_Area_Code;
                mDistArea.AREA_NAME = p_Area_Name;
                mDistArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistArea.LASTUPDATE_DATE = System.DateTime.Today;
                mDistArea.TIME_STAMP = System.DateTime.Today;
                mDistArea.TOWN_ID = p_Territory_Id;
                mDistArea.IS_ACTIVE = p_IsActive;
                bool BValue = mDistArea.ExecuteQuery();
                return BValue;

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
        /// Updates Route
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Area_Id">Route</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_LastUpdate_Date">LastUpdateDate</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Territory_Id">Territory</param>
        /// <param name="p_Area_Name">Name</param>
        /// <param name="p_Area_Code">Code</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UpdateDisct_Area(long p_Area_Id, bool p_IsActive, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateDISTRIBUTOR_AREA mDistArea = new spUpdateDISTRIBUTOR_AREA();
                mDistArea.Connection = mConnection;
                mDistArea.AREA_ID = p_Area_Id;
                mDistArea.AREA_CODE = p_Area_Code;
                mDistArea.AREA_NAME = p_Area_Name;
                mDistArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistArea.LASTUPDATE_DATE = p_LastUpdate_Date;
                mDistArea.TOWN_ID = p_Territory_Id;
                mDistArea.IS_ACTIVE = p_IsActive;
                bool BValue = mDistArea.ExecuteQuery();
                return BValue;

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
        /// Inserts Routes From Excel File
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_TownId">Town</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="pFileName">ExcelFile</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool ImportRoute(int p_TownId, int p_DistributorId, string pFileName, int p_UserId)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            int counter = 1;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {
                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);

                    spInsertDISTRIBUTOR_AREA mDistRoute = new spInsertDISTRIBUTOR_AREA();

                    mDistRoute.Connection = mConnection;
                    mDistRoute.DISTRIBUTOR_ID = p_DistributorId;
                    mDistRoute.AREA_ID = int.Parse(ParametersArr[0].ToString());
                    mDistRoute.AREA_CODE = ParametersArr[1].ToString();
                    mDistRoute.AREA_NAME = ParametersArr[2].ToString();
                    mDistRoute.TOWN_ID = p_TownId;
                    mDistRoute.TIME_STAMP = DateTime.Now;
                    mDistRoute.LASTUPDATE_DATE = DateTime.Now;
                    mDistRoute.IS_ACTIVE = true;
                    mDistRoute.ExecuteQuery();
                    counter++;
                }
                return true;

            }

            catch (Exception excp)
            {
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
    }
}
