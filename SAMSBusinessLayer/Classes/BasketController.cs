using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Basket And Basket Detail Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Basket and Basket Detail
    /// </item>
    /// <term>
    /// Update Basket and Basket Detail
    /// </term>
    /// <item>
    /// Get Basket and Basket Detail
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class BasketController
	{		
		#region Constructors

        /// <summary>
        /// Constructor for BasketController
        /// </summary>
		public BasketController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
				
		#region public Methods

        #region Select

        /// <summary>
        /// Gets Basket Data
        /// <remarks>
        /// Returns Basket Data as Datatable
        /// </remarks>
        /// </summary>
        /// <param name="p_Basket_ID">Basket</param>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Is_Basket">IsBasket</param>
        /// <param name="p_Is_And">IsAnd</param>
        /// <param name="p_Is_Multiple">IsMultiple</param>
        /// <param name="p_Basket_On">BasketOn</param>
        /// <param name="p_Basket_Selection">BasketSelection</param>
        /// <returns>Basket Data as Datatable</returns>
        public DataTable SelectBasket(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectBASKET_MASTER mBasket = new spSelectBASKET_MASTER();
                mBasket.Connection = mConnection;

                mBasket.BASKET_ID = p_Basket_ID;
                mBasket.PROMOTION_ID = p_Promotion_ID;
                mBasket.SCHEME_ID = p_Scheme_ID;
                mBasket.DISTRIBUTOR_ID = p_Dist_ID;
                mBasket.IS_BASKET = p_Is_Basket;
                mBasket.IS_AND = p_Is_And;
                mBasket.IS_MULTIPLE = p_Is_Multiple;
                mBasket.BASKET_ON = p_Basket_On;
                mBasket.BASKET_SELECTION = p_Basket_Selection;

                DataTable dt = mBasket.ExecuteTable();
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
        /// Gets Basket Detail Data
        /// <remarks>
        /// Returns Basket Detail Data as Datatable
        /// </remarks>
        /// </summary>
        /// <param name="p_BasketDetail_ID">BasketDetail</param>
        /// <param name="p_Basket_ID">Basket</param>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Min_Val">MinumumValue</param>
        /// <param name="p_Max_Val">MaximumValue</param>
        /// <param name="p_Multiple_Of">MultipleOf</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_SKUBrand_ID">SKUBrand</param>
        /// <param name="p_SKUDiv_ID">SKUDivision</param>
        /// <param name="p_SKUCatg_ID">SKUCategory</param>
        /// <param name="p_SKUVariant_ID">SKUVariant</param>
        /// <param name="p_SKUGroup_ID">SKUGroup</param>
        /// <param name="p_UOM_ID">UOM</param>
        /// <param name="p_SKUCompany_ID">Company</param>
        /// <returns>Basket Detail Data as Datatable</returns>
        public DataTable SelectBasketDetail(long p_BasketDetail_ID, long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID, int p_SKUCompany_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spUpdateBASKET_DETAIL mBasket = new spUpdateBASKET_DETAIL();
                mBasket.Connection = mConnection;

                mBasket.BASKET_DETAIL_ID = p_BasketDetail_ID;
                mBasket.DISTRIBUTOR_ID = p_Dist_ID;
                mBasket.BASKET_ID = p_Basket_ID;
                mBasket.PROMOTION_ID = p_Promotion_ID;
                mBasket.CATEGORY_ID = p_SKUCatg_ID;
                mBasket.SKU_GROUP_ID = p_SKUGroup_ID;
                mBasket.UOM_ID = p_UOM_ID;
                mBasket.DIVISION_ID = p_SKUDiv_ID;
                mBasket.VARIANT_ID = p_SKUVariant_ID;
                mBasket.BRAND_ID = p_SKUBrand_ID;
                mBasket.SCHEME_ID = p_Scheme_ID;
                mBasket.MULTIPLE_OF = p_Multiple_Of;
                mBasket.SKU_ID = p_SKU_ID;
                mBasket.MIN_VAL = p_Min_Val;
                mBasket.MAX_VAL = p_Max_Val;
                mBasket.COMPANY_ID = p_SKUCompany_ID;
                DataTable dt = mBasket.ExecuteTable();
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
        /// Gets Basket Master Of Promotion
        /// </summary>
        /// <remarks>
        /// Returns Basket Master Data as Datatable
        /// </remarks>
        /// <param name="PromotionId">Promotion</param>
        /// <returns>Basket Master Data as Datatable</returns>
        public DataTable GetBasketMaster(long PromotionId)
        {
            IDbConnection mconnection = null;
            try
            {
                mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mconnection.Open();

                spSelectBASKET_MASTER01 BasMaster = new spSelectBASKET_MASTER01();
                BasMaster.Connection = mconnection;

                BasMaster.BASKET_ID = Constants.LongNullValue;
                BasMaster.SCHEME_ID = Constants.IntNullValue;
                BasMaster.DISTRIBUTOR_ID = Configuration.DistributorId;
                BasMaster.PROMOTION_ID = PromotionId;

                DataTable dt = BasMaster.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
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

        /// <summary>
        /// Gets Basket Detail
        /// </summary>
        /// <remarks>
        /// Returns Basket Detail Data as Datatable
        /// </remarks>
        /// <param name="Basket_ID">Basket</param>
        /// <returns>Basket Detail Data as Datatable</returns>
        public DataTable GetBasketDetailForSlab(int Basket_ID)
        {
            IDbConnection mconnection = null;
            try
            {
                mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mconnection.Open();
                USPGETSLABPROMOTION BasketDetail = new USPGETSLABPROMOTION();
                BasketDetail.Connection = mconnection;

                BasketDetail.BasketId_ID = Basket_ID;

                DataTable dt = BasketDetail.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
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

        #endregion

        #region Insert, Update

        /// <summary>
        /// Inserts Basket
        /// </summary>
        /// <remarks>
        /// Returns Inserted Basket ID as String
        /// </remarks>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Is_Basket">IsBasket</param>
        /// <param name="p_Is_And">IsAnd</param>
        /// <param name="p_Is_Multiple">IsMultiple</param>
        /// <param name="p_Basket_On">BasketOn</param>
        /// <param name="p_Basket_Selection">BasketSelection</param>
        /// <returns>Inserted Basket ID as String</returns>
		public string InsertBasket(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertBASKET_MASTER mBasket = new spInsertBASKET_MASTER();
				mBasket.Connection = mConnection;

				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.IS_BASKET = p_Is_Basket;
				mBasket.IS_AND = p_Is_And;
				mBasket.IS_MULTIPLE = p_Is_Multiple;
				mBasket.BASKET_ON = p_Basket_On;
				mBasket.BASKET_SELECTION = p_Basket_Selection;

				mBasket.ExecuteQuery();
				return mBasket.BASKET_ID.ToString() ;
				
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
        /// Updates Basket
        /// </summary>
        /// <remarks>
        /// Returns On Success "Record Updated" And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_Basket_ID">Basket</param>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Shceme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Is_Basket">IsBasket</param>
        /// <param name="p_Is_And">IsAnd</param>
        /// <param name="p_Is_Multiple">IsMultiple</param>
        /// <param name="p_Basket_On">BasketOn</param>
        /// <param name="p_Basket_Selection">BasketSelection</param>
        /// <returns>On Success "Record Updated" And Exception.Message On Failure</returns>
		public string UpdateBasket(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				spUpdateBASKET_MASTER mBasket = new spUpdateBASKET_MASTER();
				mBasket.Connection = mConnection;

				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.IS_BASKET = p_Is_Basket;
				mBasket.IS_AND = p_Is_And;
				mBasket.IS_MULTIPLE = p_Is_Multiple;
				mBasket.BASKET_ON = p_Basket_On;
				mBasket.BASKET_SELECTION = p_Basket_Selection;
							
				mBasket.ExecuteQuery();
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
        /// Inserts Basket Detail
        /// </summary>
        /// <remarks>
        /// Returns Inserted Basket Detail ID as String
        /// </remarks>
        /// <param name="p_Basket_ID">Basket</param>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Min_Val">MinimumValue</param>
        /// <param name="p_Max_Val">MaximumValue</param>
        /// <param name="p_Multiple_Of">MultipleOf</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_SKUBrand_ID">SKUBrand</param>
        /// <param name="p_SKUDiv_ID">SKUDivision</param>
        /// <param name="p_SKUCatg_ID">SKUCategory</param>
        /// <param name="p_SKUVariant_ID">SKUVariant</param>
        /// <param name="p_SKUGroup_ID">SKUGroup</param>
        /// <param name="p_UOM_ID">UOM</param>
        /// <param name="p_CompanyID">Company</param>
        /// <returns>Inserted Basket Detail ID as String</returns>
		public string InsertBasketDetail(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID, int p_CompanyID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertBASKET_DETAIL mBasket = new spInsertBASKET_DETAIL();
				mBasket.Connection = mConnection;
                
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.CATEGORY_ID = p_SKUCatg_ID ;
				mBasket.SKU_GROUP_ID = p_SKUGroup_ID;
				mBasket.UOM_ID = p_UOM_ID;
				mBasket.DIVISION_ID = p_SKUDiv_ID;
				mBasket.VARIANT_ID = p_SKUVariant_ID;
				mBasket.COMPANY_ID = p_CompanyID;
				mBasket.BRAND_ID = p_SKUBrand_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.MULTIPLE_OF = p_Multiple_Of;
				mBasket.SKU_ID = p_SKU_ID;
				mBasket.MIN_VAL = p_Min_Val;
				mBasket.MAX_VAL = p_Max_Val;				

				mBasket.ExecuteQuery();
				return mBasket.BASKET_DETAIL_ID.ToString() ;
				
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
        /// Updates Basket Detail
        /// </summary>
        /// <remarks>
        /// Returns On Success "Record Updated" And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_BasketDetail_ID">BasketDetail</param>
        /// <param name="p_Basket_ID">Basket</param>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Min_Val">MinimumValue</param>
        /// <param name="p_Max_Val">MaximumValue</param>
        /// <param name="p_Multiple_Of">MultipleOf</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_SKUBrand_ID">SKUBrand</param>
        /// <param name="p_SKUDiv_ID">SKUDivision</param>
        /// <param name="p_SKUCatg_ID">SKUCategory</param>
        /// <param name="p_SKUVariant_ID">SKUVariant</param>
        /// <param name="p_SKUGroup_ID">SKUGroup</param>
        /// <param name="p_UOM_ID">UOM</param>
        /// <param name="p_SKUCompany_ID">Company</param>
        /// <returns>On Success "Record Updated" And Exception.Message On Failure</returns>
		public string UpdateBasketDetail(long p_BasketDetail_ID, long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID , int p_SKUCompany_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				spUpdateBASKET_DETAIL mBasket = new spUpdateBASKET_DETAIL();
				mBasket.Connection = mConnection;

				mBasket.BASKET_DETAIL_ID = p_BasketDetail_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.CATEGORY_ID = p_SKUCatg_ID ;
				mBasket.SKU_GROUP_ID = p_SKUGroup_ID;
				mBasket.UOM_ID = p_UOM_ID;
				mBasket.DIVISION_ID = p_SKUDiv_ID;
				mBasket.BRAND_ID = p_SKUBrand_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.MULTIPLE_OF = p_Multiple_Of;
				mBasket.SKU_ID = p_SKU_ID;
				mBasket.VARIANT_ID = p_SKUVariant_ID;  
				mBasket.MIN_VAL = p_Min_Val;
				mBasket.MAX_VAL = p_Max_Val;
				mBasket.COMPANY_ID = p_SKUCompany_ID;

			
				mBasket.ExecuteQuery();
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
