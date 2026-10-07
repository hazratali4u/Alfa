using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For SKU Group Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert SKU Group
    /// </item>
    /// <term>
    /// Update SKU Group
    /// </term>
    /// <item>
    /// Get SKU Group
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class SKUGroupController
	{		
		#region Constructors

        /// <summary>
        /// Constructor For SKUGroupController
        /// </summary>
		public SKUGroupController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
		
		#region Public Methods

        #region Select

        /// <summary>
        /// Gets SKU Group Data
        /// </summary>
        /// <remarks>
        /// Returns SKU Group Data as Datatable
        /// </remarks>
        /// <param name="p_Sku_Group_Id">SKUGroup</param>
        /// <param name="p_Sku_Group_Name">Name</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKU Group Data as Datatable</returns>
        public DataTable SelectSKUGroup(int p_Sku_Group_Id, string p_Sku_Group_Name, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_GROUP mSkus = new spSelectSKU_GROUP();
					
				mSkus.Connection = mConnection;   
				mSkus.SKU_GROUP_ID = p_Sku_Group_Id;
				mSkus.GROUP_NAME = p_Sku_Group_Name ;
                mSkus.COMPANY_ID = Companyid;   
                DataTable dt = mSkus.ExecuteTable();
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
        /// Gets SKU Group Detail
        /// </summary>
        /// <remarks>
        /// Returns SKU Group Detail Data as Datatable
        /// </remarks>
        /// <param name="Companyid">Company</param>
        /// <returns>SKU Group Detail Data as Datatable</returns>
        public DataTable GET_SKUGroupDetail(int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetGroup_Detail ObjSelect = new UspGetGroup_Detail();
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = Companyid;
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
        /// Get SKU Groups
        /// </summary>
        /// <remarks>
        /// Returns SKU Groups as Datatable
        /// </remarks>
        /// <param name="Companyid">Company</param>
        /// <returns>SKU Groups as Datatable</returns>
        public DataTable GET_Group_ID(int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetGroup_ID ObjSelect = new UspGetGroup_ID();
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = Companyid;
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
        /// Gets SKU Group Name
        /// </summary>
        /// <remarks>
        /// Returns SKU Group Name as Datatable
        /// </remarks>
        /// <param name="p_SKU_GROUP_ID">SKUGroup</param>
        /// <param name="p_GROUP_NAME">Name</param>
        /// <param name="p_TIMESTAMP">CreatedOn</param>
        /// <param name="p_ISACTIVE">IsActive</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="Companyid">Company</param>
        /// <returns>All SKU Group Names as Datatable</returns>
        public DataTable GET_UniqueGroupName(int p_SKU_GROUP_ID, string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE, int p_UserId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKU_GROUP ObjSelect = new spSelectSKU_GROUP();
                ObjSelect.Connection = mConnection;
                ObjSelect.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjSelect.GROUP_NAME = p_GROUP_NAME;
                ObjSelect.COMPANY_ID = p_UserId;
                ObjSelect.USER_ID = Companyid;
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
        /// Checks SKU in A SKU Group
        /// </summary>
        /// <remarks>
        /// Returns Ture If SKU Exists In Group And False If SKU Exists In Group
        /// </remarks>
        /// <param name="p_Sku_Grp_Detail_Id">GroupDetail</param>
        /// <param name="p_Sku_Grp_Id">Group</param>
        /// <param name="p_Sku_Id">SKU</param>
        /// <returns>Ture If SKU Exists In Group And False If SKU Exists In Group</returns>
        public bool ExistsInGroup(int p_Sku_Grp_Detail_Id, int p_Sku_Grp_Id, int p_Sku_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKU_GROUP_DETAIL mSkus = new spSelectSKU_GROUP_DETAIL();

                mSkus.Connection = mConnection;
                mSkus.SKU_GROUP_DETAIL_ID = p_Sku_Grp_Detail_Id;
                mSkus.SKU_GROUP_ID = p_Sku_Grp_Id;
                mSkus.SKU_ID = p_Sku_Id;
                DataTable dt = mSkus.ExecuteTable();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        #region Insert, Update

        /// <summary>
        /// Inserts SKU Group
        /// </summary>
        /// <remarks>
        /// Returns Inserted SKU Group ID as String
        /// </remarks>
        /// <param name="p_GROUP_NAME">Name</param>
        /// <param name="p_TIMESTAMP">CreatedOn</param>
        /// <param name="p_ISACTIVE">IsActive</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Inserted SKU Group ID as String</returns>
        public string Insert_SKUGroup(string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE, int p_UserId, int p_PrincipalId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertSKU_GROUP ObjInsert = new spInsertSKU_GROUP();
                ObjInsert.Connection = mConnection;
                ObjInsert.GROUP_NAME = p_GROUP_NAME;
                ObjInsert.TIME_STAMP = p_TIMESTAMP;
                ObjInsert.COMPANY_ID = Companyid;
                ObjInsert.USER_ID = p_UserId;
                ObjInsert.LASTUPDATE_DATE = System.DateTime.Now;
                ObjInsert.PRINCIPAL_ID = p_PrincipalId;
                ObjInsert.ExecuteQuery();
                return ObjInsert.SKU_GROUP_ID.ToString();
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
        /// Inserts SKU Group Detail
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_SKU_GROUP_ID">SkUGroup</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Insert_SKU_GroupDetail(int p_SKU_GROUP_ID, int p_SKU_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertSKU_GROUP_DETAIL ObjInsert = new spInsertSKU_GROUP_DETAIL();

                ObjInsert.Connection = mConnection;
                ObjInsert.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjInsert.SKU_ID = p_SKU_ID;

                bool Bvalue = ObjInsert.ExecuteQuery();
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

        /// <summary>
        /// Updates SKU Group
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_SKU_GROUP_ID">SKUGroup</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_GROUP_NAME">Name</param>
        /// <param name="p_ISACTIVE">IsActive</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UpdateSKUinGroup(int p_SKU_GROUP_ID, int p_SKU_ID, string p_GROUP_NAME, bool p_ISACTIVE, int p_PrincipalId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspUpdateSKUinGroup ObjInsert = new UspUpdateSKUinGroup();

                ObjInsert.Connection = mConnection;
                ObjInsert.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjInsert.SKU_ID = p_SKU_ID;
                ObjInsert.GROUP_NAME = p_GROUP_NAME;
                ObjInsert.ISACTIVE = p_ISACTIVE;
                ObjInsert.PRINCIPAL_ID = p_PrincipalId;
                bool Bvalue = ObjInsert.ExecuteQuery();
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

        /// <summary>
        /// Updates SKU Group Detail
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_SKU_GROUP_ID">SKUGroup</param>
        /// <param name="p_SKU_GROUP_DETAIL_ID">SKUGroupDetail</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_GROUP_NAME">Name</param>
        /// <param name="p_TIMESTAMP">CreatedOn</param>
        /// <param name="p_ISACTIVE">IsActive</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Update_SKU_GroupandGroupDetail(int p_SKU_GROUP_ID, int p_SKU_GROUP_DETAIL_ID, int p_SKU_ID, string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspUpdateGroupandGroupDetail ObjUpdate = new UspUpdateGroupandGroupDetail();

                ObjUpdate.Connection = mConnection;
                ObjUpdate.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjUpdate.SKU_GROUP_DETAIL_ID = p_SKU_GROUP_DETAIL_ID;
                ObjUpdate.SKU_ID = p_SKU_ID;
                ObjUpdate.GROUP_NAME = p_GROUP_NAME;
                ObjUpdate.TIMESTAMP = p_TIMESTAMP;
                ObjUpdate.ISACTIVE = p_ISACTIVE;

                bool Bvalue = ObjUpdate.ExecuteQuery();
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
    }
}
