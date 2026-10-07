using System;
using SAMSDatabaseLayer.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSCommon.Classes;
using System.Data;
using SAMSBusinessLayer.Classes;    

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Geo Hierarchy Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Geo Hierarchy
    /// </item>
    /// <term>
    /// Update Geo Hierarchy
    /// </term>
    /// <item>
    /// Get Geo Hierarchy
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class GeoHierarchyController
    {
        /// <summary>
        /// Gets Different Type Of Geo Hierarical Data Like
        /// <remarks>
        /// <list type="bullet">
        /// <item>Regions</item>
        /// <item>Zones</item>
        /// <item>Territories</item>
        /// <item>Towns</item>
        /// </list>
        /// </remarks>
        /// </summary>
        /// <param name="p_geo_id">GeoHierarchy</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PARENT_GEO_ID">ParentGeoHierarchy</param>
        /// <param name="p_GEO_CODE">Code</param>
        /// <param name="p_GEO_NAME">Name</param>
        /// <param name="p_Is_Deleted">IsDeleted</param>
        /// <param name="p_STATUS">Status</param>
        /// <param name="p_GEO_TYPE_ID">Type</param>
        /// <param name="p_USER_ID">InsertedBy</param>
        /// <param name="p_TIME_STAMP">CreatedOn</param>
        /// <param name="p_LASTUPDATE_DATE">LastUpdateDate</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Geo Hierarical Data As Datatable</returns>
        public DataTable SelectGeoHierarchy(int p_geo_id, int p_DISTRIBUTOR_ID, int p_PARENT_GEO_ID, string p_GEO_CODE, string p_GEO_NAME, bool p_Is_Deleted, int p_STATUS, int p_GEO_TYPE_ID, int p_USER_ID, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectGEO_HIERARCHY mGeoHierarchy = new spSelectGEO_HIERARCHY();
                mGeoHierarchy.Connection = mConnection;
                mGeoHierarchy.GEO_ID = p_geo_id;
                mGeoHierarchy.PARENT_GEO_ID = p_PARENT_GEO_ID;
                mGeoHierarchy.GEO_CODE = p_GEO_CODE;
                mGeoHierarchy.GEO_NAME = p_GEO_NAME;
                mGeoHierarchy.COMPANY_ID = Companyid;   
                mGeoHierarchy.ISCURRENT = Constants.IntNullValue; 
                if (p_Is_Deleted == true)
                {
                    mGeoHierarchy.ISDELETED = 1;

                }
                else
                {
                  mGeoHierarchy.ISDELETED = 0;

                }
                mGeoHierarchy.STATUS = p_STATUS;
                mGeoHierarchy.COMPANY_ID = Companyid; 
                mGeoHierarchy.GEO_TYPE_ID = p_GEO_TYPE_ID;
                mGeoHierarchy.USER_ID = Constants.IntNullValue; 
                mGeoHierarchy.TIME_STAMP = Constants.DateNullValue;
                mGeoHierarchy.LASTUPDATE_DATE = Constants.DateNullValue;
                mGeoHierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mGeoHierarchy.IP_ADDRESS = null;

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

        /// <summary>
        /// Gets Different Type Of Geo Hierarical Data Like
        /// <remarks>
        /// <list type="bullet">
        /// <item>Regions</item>
        /// <item>Zones</item>
        /// <item>Territories</item>
        /// <item>Towns</item>
        /// </list>
        /// </remarks>
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <returns>Geo Hierarical Data As Datatable</returns>
        public DataTable SelectGeoHierarchy(int p_DISTRIBUTOR_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectDistributor_TOWN mGeoHierarchy = new spSelectDistributor_TOWN();
                mGeoHierarchy.Connection = mConnection;
                mGeoHierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;  
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

        /// <summary>
        /// Inserts Geo Hierarchy
        /// </summary>
        /// <param name="p_Parent_Geo_Id">GeoHierarchy</param>
        /// <param name="p_Geo_Code">Code</param>
        /// <param name="p_Geo_Name">Name</param>
        /// <param name="p_Is_Current">IsCurretn</param>
        /// <param name="p_Is_Deleted">IsDeleted</param>
        /// <param name="p_Status">Status</param>
        /// <param name="p_Company_Id">Company</param>
        /// <param name="p_Geo_Type_Id">Type</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <returns>On Success "Record Inserted" And Exception.Message On Failure.</returns>
        public string InsertHierarchy(int p_Parent_Geo_Id, string p_Geo_Code, string p_Geo_Name, bool p_Is_Current, bool p_Is_Deleted, int p_Status, int p_Company_Id, int p_Geo_Type_Id, int p_User_Id, int p_Distributor_Id, string p_Ip_Address)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertGEO_HIERARCHY mGeoHierarchy = new spInsertGEO_HIERARCHY();
                mGeoHierarchy.Connection = mConnection;

                mGeoHierarchy.PARENT_GEO_ID = p_Parent_Geo_Id;
                mGeoHierarchy.GEO_CODE = p_Geo_Code;
                mGeoHierarchy.GEO_NAME = p_Geo_Name;
                mGeoHierarchy.ISCURRENT = p_Is_Current;
                mGeoHierarchy.ISDELETED = p_Is_Deleted;
                mGeoHierarchy.STATUS = p_Status;
                mGeoHierarchy.COMPANY_ID = p_Company_Id;
                mGeoHierarchy.GEO_TYPE_ID = p_Geo_Type_Id;
                mGeoHierarchy.USER_ID = p_User_Id;
                mGeoHierarchy.TIME_STAMP = System.DateTime.Now;
                mGeoHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
                mGeoHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;
                mGeoHierarchy.IP_ADDRESS = p_Ip_Address;

                bool a = mGeoHierarchy.ExecuteQuery();
                if (a)
                {
                    return "Record Inserted";
                }
                else
                {
                    return "Record Inserted";
                }
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
        /// Gets Geo Hierarical Data
        /// </summary>
        /// <param name="p_Brand_id">Brand</param>
        /// <param name="p_sku_type_id">Type</param>
        /// <returns>Geo Hierarical Data AS Datatable</returns>
        public DataTable SelectGeoHierarchyData(int p_Brand_id , int p_sku_type_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetDataGeohierarchy ObjSelect = new UspGetDataGeohierarchy();
                ObjSelect.Connection = mConnection;  
                ObjSelect.Brand_id = p_Brand_id;
                ObjSelect.SKU_Hie_type_id = p_sku_type_id;

                DataTable dt = ObjSelect.ExecuteTable();
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
        /// Updates Geo Hierarchy
        /// </summary>
        /// <param name="p_Geo_Id">GeoHierarchy</param>
        /// <param name="p_Parent_Geo_Id">ParentGeoHierarchy</param>
        /// <param name="p_Geo_Code">Code</param>
        /// <param name="p_Geo_Name">Name</param>
        /// <param name="p_Is_Current">IsCurrent</param>
        /// <param name="p_Is_Deleted">IsDeleted</param>
        /// <param name="p_Status">Status</param>
        /// <param name="p_Company_Id">Company</param>
        /// <param name="p_Geo_Type_Id">Type</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <returns>On Success "Record Updated" And Exception.Message On Failure.</returns>
        public string UpdateHierarchy(int p_Geo_Id, int p_Parent_Geo_Id, string p_Geo_Code, string p_Geo_Name, bool p_Is_Current, bool p_Is_Deleted, int p_Status, int p_Company_Id, int p_Geo_Type_Id, int p_User_Id, int p_Distributor_Id, string p_Ip_Address)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateGEO_HIERARCHY mGeoHierarchy = new spUpdateGEO_HIERARCHY();
                mGeoHierarchy.Connection = mConnection;

                mGeoHierarchy.GEO_ID = p_Geo_Id;
                mGeoHierarchy.PARENT_GEO_ID = p_Parent_Geo_Id;
                mGeoHierarchy.GEO_CODE = p_Geo_Code;
                mGeoHierarchy.GEO_NAME = p_Geo_Name;
                mGeoHierarchy.ISCURRENT = p_Is_Current;
                mGeoHierarchy.ISDELETED = p_Is_Deleted;
                mGeoHierarchy.STATUS = p_Status;
                mGeoHierarchy.COMPANY_ID = p_Company_Id;
                mGeoHierarchy.GEO_TYPE_ID = p_Geo_Type_Id;
                mGeoHierarchy.USER_ID = p_User_Id;
                mGeoHierarchy.TIME_STAMP = System.DateTime.Now;
                mGeoHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
                mGeoHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;
                mGeoHierarchy.IP_ADDRESS = p_Ip_Address;

                mGeoHierarchy.ExecuteQuery();
                return "Record Updated";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Record Updated"; 
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
        /// Gets Assigned Regions, Zones, Territories And Towns  
        /// </summary>
        /// <param name="typeid">Type</param>
        /// <param name="Locationtype">Location</param>
        /// <param name="TownId">Town</param>
        /// <returns>Assigned Regions, Zones, Territories And Towns As Datatable</returns>
        public DataTable SelectDistributorHierachyWithType(int typeid, int Locationtype, string TownId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectView_GeoHIERARCHY Selectdata = new UspSelectView_GeoHIERARCHY();
                Selectdata.Connection = mConnection;
                Selectdata.type = typeid;
                Selectdata.Paraid = Locationtype;
                Selectdata.ZoneId = Constants.IntNullValue;
                Selectdata.TerritoryId = Constants.IntNullValue;
                Selectdata.TownId = TownId;
                DataTable dt = Selectdata.ExecuteTable();
                return dt;

            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        /// Gets Assigned Regions, Zones, Territories And Towns  
        /// </summary>
        /// <param name="typeid">Type</param>
        /// <param name="Locationtype">Location</param>
        /// <param name="TownId">Town</param>
        /// <returns>Assigned Regions, Zones, Territories And Towns As Datatable</returns>
        public DataTable SelectDistributorHierachyWithType(int typeid, int RegionId,int ZoneId,int TerritoryId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectView_GeoHIERARCHY Selectdata = new UspSelectView_GeoHIERARCHY();
                Selectdata.Connection = mConnection;
                Selectdata.type = typeid;
                Selectdata.Paraid = RegionId;
                Selectdata.ZoneId = ZoneId;
                Selectdata.TerritoryId = TerritoryId;
                Selectdata.TownId = null;
                DataTable dt = Selectdata.ExecuteTable();
                return dt;

            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
    }
}
