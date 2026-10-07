using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For SKU Heirarchy Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert SKU Heirarchy
    /// </item>
    /// <term>
    /// Update SKU Heirarchy
    /// </term>
    /// <item>
    /// Get SKU Heirarchy
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class SkuHierarchyController
	{
		#region Contructors

        /// <summary>
        /// Constructor for SkuHierarchyController
        /// </summary>
		public SkuHierarchyController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
        
		#region Public Method

        #region Select

        /// <summary>
        /// Gets SKU Hierarchy
        /// </summary>
        /// Returns SKU Hierarchy Data as Datatable
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Sku_Hie_Id">Hierarchy</param>
        /// <param name="p_Parent_Sku_Hie_Id">Parent</param>
        /// <param name="p_Sku_Hie_Code">Code</param>
        /// <param name="p_Sku_Hie_Name">Name</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectSkuHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, bool p_Is_Active, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
				mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
				mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
				mSkuHierarchy.TIME_STAMP = Constants.DateNullValue ;
				mSkuHierarchy.LASTUPDATE_DATE = Constants .DateNullValue ;
				mSkuHierarchy.IP_ADDRESS = null ;
				mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;   
				

				DataTable dt = mSkuHierarchy.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_Sku_Type_Hie_Id">Hierarchy</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectSkuHierarchy(int p_Sku_Type_Hie_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Hie_Id;
                mSkuHierarchy.COMPANY_ID  = Companyid;   
				DataTable dt = mSkuHierarchy.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_Sku_Type_Id"></param>
        /// <param name="p_Parent_Sku_Hie_Id"></param>
        /// <param name="Companyid"></param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectSkuHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID=p_Parent_Sku_Hie_Id;
                mSkuHierarchy.COMPANY_ID = Companyid;    
				
				

				DataTable dt = mSkuHierarchy.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Parent_Sku_Hie_Id">Parent</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectDTSkuHierarchy(int p_Sku_Type_Id,int p_Parent_Sku_Hie_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID=p_Parent_Sku_Hie_Id;
				
				

				DataTable dt = mSkuHierarchy.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_type">Type</param>
        /// <param name="CompanyId">Company</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectSkuHierarchyView(int p_type,int CompanyId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				UspSelectView_SKUHIERARCHY mSkuHierarchyInfo = new UspSelectView_SKUHIERARCHY();
				mSkuHierarchyInfo.Connection = mConnection;
                mSkuHierarchyInfo.MCompany_id = CompanyId;   
				mSkuHierarchyInfo.type = p_type;
				
				DataTable dt = mSkuHierarchyInfo.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_type">Type</param>
        /// <param name="p_company">Company</param>
        /// <param name="p_division">Division</param>
        /// <param name="p_category">Category</param>
        /// <param name="p_brand">Brand</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectDTSkuHierarchy01(int p_type, int p_company, int p_division, int p_category, int p_brand, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectView_SKUHIERARCHY mSkuHierarchy = new UspSelectView_SKUHIERARCHY();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.type = p_type;
                mSkuHierarchy.Company_id = p_company;
                mSkuHierarchy.Division_id = p_division;
                mSkuHierarchy.Category_Id = p_category;
                mSkuHierarchy.Brand_Id = p_brand;
                mSkuHierarchy.MCompany_id = Companyid;
                DataTable dt = new DataTable();
                dt = mSkuHierarchy.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_type">Type</param>
        /// <param name="p_UserId">User</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectBrandAssignment(int p_type, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetBrandAssignment mSkuHierarchy = new UspGetBrandAssignment();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.TYPE_ID = p_type;
                mSkuHierarchy.USER_ID = p_UserId;
                DataTable dt = new DataTable();
                dt = mSkuHierarchy.ExecuteTable();
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
        /// Gets SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns SKU Hierarchy Data as Datatable
        /// </remarks>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <returns>SKU Hierarchy Data as Datatable</returns>
        public DataTable SelectSKUCategories(int p_Principal_ID, bool p_Is_Active)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetSKUCategories mSKUCategory = new uspGetSKUCategories();
                mSKUCategory.Connection = mConnection;
                mSKUCategory.PRINCIPAL_ID = p_Principal_ID;
                mSKUCategory.IS_ACTIVE = p_Is_Active;
                DataTable dt = mSKUCategory.ExecuteTable();
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
        /// Gets Principals
        /// </summary>
        /// <remarks>
        /// Returns Principal Data as Datatable
        /// </remarks>
        /// <param name="p_Sku_Type_Hie_Id">Type</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Principal Data as Datatable</returns>
        public DataTable SelectPrincipal(int p_Sku_Type_Hie_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPRINCIPAL mPRINCIPAL = new spSelectPRINCIPAL();
                mPRINCIPAL.Connection = mConnection;
                mPRINCIPAL.SKU_HIE_TYPE_ID = p_Sku_Type_Hie_Id;
                mPRINCIPAL.COMPANY_ID = Companyid;
                DataTable dt = mPRINCIPAL.ExecuteTable();
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
        /// Gets PromotionType For A User
        /// </summary>
        /// <remarks>
        /// Returns PromotionType IsManual or Auto For A User as Datatable
        /// </remarks>
        /// <param name="p_USER_ID">User</param>
        /// <returns>PromotionType IsManual or Auto For A User as Datatable</returns>
        public DataTable GetBrandAssignment(int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spGetBRAND_ASSIGNMENT mBrand = new spGetBRAND_ASSIGNMENT();
                mBrand.Connection = mConnection;
                mBrand.USER_ID = p_USER_ID;

                DataTable dt = mBrand.ExecuteTable();
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
        /// Insert SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns "Record Inserted" on Success And Exception.Message on Failure
        /// </remarks>
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Parent_Sku_Hie_Id">Hierarchy</param>
        /// <param name="p_Sku_Hie_Code">Code</param>
        /// <param name="p_Sku_Hie_Name">Name</param>
        /// <param name="p_Ip_Address">Address</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="Companyid">Company</param>
        /// <returns>"Record Inserted" on Success And Exception.Message on Failure</returns>
        public string InsertHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSKU_HIERARCHY mSkuHierarchy = new spInsertSKU_HIERARCHY();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;

                mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
                mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
                mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
                mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now; ;
                mSkuHierarchy.IP_ADDRESS = p_Ip_Address;
                mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = false;
                mSkuHierarchy.ExecuteQuery();
                return "Record Inserted";

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
        /// Updates SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Sku_Hie_Id">Hierarchy</param>
        /// <param name="p_Parent_Sku_Hie_Id">Parent</param>
        /// <param name="p_Sku_Hie_Code">Code</param>
        /// <param name="p_Sku_Hie_Name">Name</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="Companyid">Compay</param>
        /// <param name="p_IsManualDiscount">PromotionType</param>
        /// <returns>"Record Updated" On Success And Exception.Message On Failure</returns>
        public string UpdateHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid,bool p_IsManualDiscount)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSKU_HIERARCHY  mSkuHierarchy = new spUpdateSKU_HIERARCHY ();
				mSkuHierarchy.Connection = mConnection;
				
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
				mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
				mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;	
				mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
				mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now;;
				mSkuHierarchy.IP_ADDRESS = p_Ip_Address  ;
				mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = p_IsManualDiscount;  
                mSkuHierarchy.ExecuteQuery();
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
        /// Updates SKU Hierarchy
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Sku_Hie_Id">Hierarchy</param>
        /// <param name="p_Parent_Sku_Hie_Id">Parent</param>
        /// <param name="p_Sku_Hie_Code">Code</param>
        /// <param name="p_Sku_Hie_Name">Name</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="Companyid">Company</param>
        /// <returns>"Record Updated" On Success And Exception.Message On Failure</returns>
        public string UpdateHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSKU_HIERARCHY mSkuHierarchy = new spUpdateSKU_HIERARCHY();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
                mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
                mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
                mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
                mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
                mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now; ;
                mSkuHierarchy.IP_ADDRESS = p_Ip_Address;
                mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = false;
                mSkuHierarchy.ExecuteQuery();
                return "Record Updated";

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
        /// Deletes PromotionType For a User
        /// </summary>
        /// <param name="p_companyId">Company</param>
        /// <param name="p_UserId">User</param>
        public void DeleteAssignBrand(int p_companyId,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spDeleteBRAND_ASSIGNMENT mDeleteBrand = new spDeleteBRAND_ASSIGNMENT();
                mDeleteBrand.Connection = mConnection;
                mDeleteBrand.PRINCIPAL_ID = p_companyId;
                mDeleteBrand.USER_ID = p_UserId;
                mDeleteBrand.ExecuteQuery();
                
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                
            }
            finally
            {
            }
        }
        
        /// <summary>
        /// Inserts PromotionType Manual Or Auto For A User
        /// </summary>
        /// <param name="p_companyId">Company</param>
        /// <param name="p_UserId">User</param>
        public void InsertAssignBrand(int p_companyId,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertBRAND_ASSIGNMENT mInsertBrand = new spInsertBRAND_ASSIGNMENT();
                mInsertBrand.Connection = mConnection;
                mInsertBrand.PRINCIPAL_ID = p_companyId;
                mInsertBrand.USER_ID = p_UserId;
                mInsertBrand.ExecuteQuery();

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);

            }
            finally
            {
            }
        }

        #region Added By Hazrat Ali
                
        /// <summary>
        /// Inserts Principal
        /// </summary>
        /// <remarks>
        /// Returns "Record Inserted" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Parent_Sku_Hie_Id">Hierarchy</param>
        /// <param name="p_Sku_Hie_Code">Code</param>
        /// <param name="p_Sku_Hie_Name">Name</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="Companyid">Compnay</param>
        /// <param name="p_IsManualDiscount">PromotionType</param>
        /// <param name="p_Address">Address</param>
        /// <param name="p_NTN">NTN</param>
        /// <param name="p_STRN">STRN</param>
        /// <returns>"Record Inserted" On Success And Exception.Message On Failure</returns>
        public string InsertPrincipal(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid, bool p_IsManualDiscount, string p_Address, string p_NTN, string p_STRN)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertPRINCIPAL mPRINCIPAL = new spInsertPRINCIPAL();
                mPRINCIPAL.Connection = mConnection;

                mPRINCIPAL.SKU_HIE_TYPE_ID = p_Sku_Type_Id;

                mPRINCIPAL.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mPRINCIPAL.SKU_HIE_CODE = p_Sku_Hie_Code;
                mPRINCIPAL.SKU_HIE_NAME = p_Sku_Hie_Name;
                mPRINCIPAL.TIME_STAMP = System.DateTime.Now; ;
                mPRINCIPAL.LASTUPDATE_DATE = System.DateTime.Now; ;
                mPRINCIPAL.IP_ADDRESS = p_Ip_Address;
                mPRINCIPAL.IS_ACTIVE = p_Is_Active;
                mPRINCIPAL.COMPANY_ID = Companyid;
                mPRINCIPAL.IS_MANUALDISCOUNT = p_IsManualDiscount;
                mPRINCIPAL.ADDRESS = p_Address;
                mPRINCIPAL.NTN = p_NTN;
                mPRINCIPAL.STRN = p_STRN;
                mPRINCIPAL.ExecuteQuery();
                return "Record Inserted";

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
        /// Updates Principal
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_Sku_Type_Id">Type</param>
        /// <param name="p_Sku_Hie_Id">Hierarchy</param>
        /// <param name="p_Parent_Sku_Hie_Id">Parent</param>
        /// <param name="p_Sku_Hie_Code">Code</param>
        /// <param name="p_Sku_Hie_Name">Name</param>
        /// <param name="p_Ip_Address">IP</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="Companyid">Company</param>
        /// <param name="p_IsManualDiscount">PromotionType</param>
        /// <param name="p_Address">Address</param>
        /// <param name="p_NTN">NTN</param>
        /// <param name="p_STRN">STRN</param>
        /// <returns>"Record Updated" On Success And Exception.Message On Failure</returns>
        public string UpdatePrincipal(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid, bool p_IsManualDiscount, string p_Address, string p_NTN, string p_STRN)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdatePRINCIPAL mPRINCIPAL = new spUpdatePRINCIPAL();
                mPRINCIPAL.Connection = mConnection;

                mPRINCIPAL.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
                mPRINCIPAL.SKU_HIE_ID = p_Sku_Hie_Id;
                mPRINCIPAL.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mPRINCIPAL.SKU_HIE_CODE = p_Sku_Hie_Code;
                mPRINCIPAL.SKU_HIE_NAME = p_Sku_Hie_Name;
                mPRINCIPAL.TIME_STAMP = System.DateTime.Now; ;
                mPRINCIPAL.LASTUPDATE_DATE = System.DateTime.Now; ;
                mPRINCIPAL.IP_ADDRESS = p_Ip_Address;
                mPRINCIPAL.IS_ACTIVE = p_Is_Active;
                mPRINCIPAL.COMPANY_ID = Companyid;
                mPRINCIPAL.IS_MANUALDISCOUNT = p_IsManualDiscount;
                mPRINCIPAL.ADDRESS = p_Address;
                mPRINCIPAL.NTN = p_NTN;
                mPRINCIPAL.STRN = p_STRN;
                mPRINCIPAL.ExecuteQuery();
                return "Record Updated";

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
        /// Updates PromotionType For User
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_Is_ManualDiscount">PromotionType</param>
        /// <returns>"Record Updated" On Success And Exception.Message On Failure</returns>
        public string UpdateBrandAssignment(int p_USER_ID, int p_PRINCIPAL_ID, bool p_Is_ManualDiscount)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateBRAND_ASSIGNMENT mBrand = new spUpdateBRAND_ASSIGNMENT();
                mBrand.Connection = mConnection;
                mBrand.USER_ID = p_USER_ID;
                mBrand.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mBrand.Is_ManualDiscount = p_Is_ManualDiscount;
                mBrand.ExecuteQuery();
                return "Record Updated";

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
        
        #endregion

        #endregion

        #endregion
    }
}
