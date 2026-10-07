using System;
using System.Data;
using SAMSDatabaseLayer.Classes;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Promotion Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Promotion
    /// </item>
    /// <term>
    /// Update Promotion
    /// </term>
    /// <item>
    /// Get Promotion
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class PromotionController
	{
        #region Constructor

		public PromotionController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

		#region Public Methods

        #region Select

        /// <summary>
        /// Gets Promotion
        /// </summary>
        /// <remarks>
        /// Returns Promotion Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Promotion_Id">Promotion</param>
        /// <returns>Promotion Data as Datatable</returns>
        public DataTable SelectPromotionWithSchemeInfo(int p_Distributor_Id, int p_Promotion_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspSelectPromotionWithSchemes mPromotion = new uspSelectPromotionWithSchemes();
                mPromotion.Connection = mConnection;

                mPromotion.PROMOTION_ID = p_Promotion_Id;
                mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;

                DataTable dt = mPromotion.ExecuteTable();
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
        /// Gets Promotion
        /// </summary>
        /// <remarks>
        /// Retruns Promotion Data as Datatable
        /// </remarks>
        /// <param name="P_start">StartDate</param>
        /// <param name="P_end">EndDate</param>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="P_UserId">InsertedBy</param>
        /// <param name="p_PActive">IsActive</param>
        /// <returns>Promotion Data as Datatable</returns>
        public DataTable SelectPromotion(string P_start, string P_end, int p_Principal_ID, int P_UserId, bool p_PActive)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspSelectPromotionsScheme mspscheme = new uspSelectPromotionsScheme();
                mspscheme.Connection = mConnection;
                mspscheme.FromDate = DateTime.Parse(P_start);
                mspscheme.To_Date = DateTime.Parse(P_end);
                mspscheme.PRINCIPAL_ID = p_Principal_ID;
                mspscheme.USER_ID = P_UserId;
                mspscheme.IS_ACTIVE = p_PActive;
                DataTable dt = mspscheme.ExecuteTable();
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
        /// Gets Locations Which Promotion Is For
        /// </summary>
        /// <remarks>
        /// Returns Locations Which Promotion Is For as Datatable
        /// </remarks>
        /// <param name="p_promotionId">Promotion</param>
        /// <returns>Locations Which Promotion Is For as Datatable</returns>
        public DataTable GetPromotionDistributors(long p_promotionId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectPROMOTION_FOR mSelectPromotionFor = new spSelectPROMOTION_FOR();
                mSelectPromotionFor.ASSIGNED_DISTRIBUTOR_ID = Constants.IntNullValue;
                mSelectPromotionFor.Connection = mConnection;
                mSelectPromotionFor.DISTRIBUTOR_ID = Configuration.DistributorId;
                mSelectPromotionFor.PROMOTION_FOR_ID = Constants.LongNullValue;
                mSelectPromotionFor.PROMOTION_ID = p_promotionId;
                mSelectPromotionFor.SCHEME_ID = Constants.IntNullValue;
                DataTable dt = mSelectPromotionFor.ExecuteTable();
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
        /// Gets Channel Types Which Promotion Is For
        /// </summary>
        /// <remarks>
        /// Returns Channel Types Which Promotion Is For as Datatable
        /// </remarks>
        /// <param name="p_promotionId">Promotion</param>
        /// <returns>Channel Types Which Promotion Is For as Datatable</returns>
        public DataTable GetPromotionCustomerType(long p_promotionId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectPROMOTION_CUSTOMER_TYPE mPromotionCustomerType = new spSelectPROMOTION_CUSTOMER_TYPE();
                mPromotionCustomerType.Connection = mConnection;
                mPromotionCustomerType.CUSTOMER_TYPE_ID = Constants.IntNullValue;
                mPromotionCustomerType.DISTRIBUTOR_ID = Configuration.DistributorId;
                mPromotionCustomerType.PROMOTION_CUSTOMER_TYPE_ID = Constants.LongNullValue;
                mPromotionCustomerType.PROMOTION_ID = p_promotionId;
                mPromotionCustomerType.SCHEME_ID = Constants.IntNullValue;
                DataTable dt = mPromotionCustomerType.ExecuteTable();
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
        /// Gets Promotion Classess Which Promotion Is For
        /// </summary>
        /// <remarks>
        /// Returns Promotion Classess Which Promotion Is For as Datatable
        /// </remarks>
        /// <param name="p_promotionId">Promotion</param>
        /// <returns>Promotion Classes Which Promotion Is For as Datatable</returns>
        public DataTable GetPromotionCustomerVolumeClass(long p_promotionId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectPROMOTION_CUSTOMER_VOLUMECLASS mPromotionCustomerType = new spSelectPROMOTION_CUSTOMER_VOLUMECLASS();
                mPromotionCustomerType.Connection = mConnection;
                mPromotionCustomerType.PROMOTION_ID = p_promotionId;
                DataTable dt = mPromotionCustomerType.ExecuteTable();
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

        #region Insert, Update

        /// <summary>
        /// Inserts Promotion
        /// </summary>
        /// <remarks>
        /// Returns Inserted Promotion ID as String
        /// </remarks>
        /// <param name="p_Scheme_Id">Scheme</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Pro_Code">Code</param>
        /// <param name="p_Pro_Description">Description</param>
        /// <param name="p_Promo_Date">Date</param>
        /// <param name="p_Claimable">Claimable</param>
        /// <param name="p_Start_Date">StartDate</param>
        /// <param name="p_End_Date">EndDate</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="p_Promotion_Type">Type</param>
        /// <param name="p_Promotion_Selection">Selection</param>
        /// <param name="p_Is_Scheme">IsScheme</param>
        /// <param name="p_Promotion_For">For</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>Inserted Promotion ID as String</returns>
        public string InsertPromotion(int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection, bool p_Is_Scheme, bool p_Promotion_For, int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertPROMOTION mPromotion = new spInsertPROMOTION();
				mPromotion.Connection = mConnection;

				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.PROMOTION_CODE = p_Pro_Code;
				mPromotion.PROMOTION_DESCRIPTION = p_Pro_Description;
				mPromotion.PROMO_DATE = p_Promo_Date;
				mPromotion.CLAIMABLE = p_Claimable;
				mPromotion.START_DATE = DateTime.Parse(p_Start_Date.ToShortDateString() + " 00:00:00");
				mPromotion.END_DATE = DateTime.Parse(p_End_Date.ToShortDateString() + " 23:59:59");
				mPromotion.IS_ACTIVE = p_Is_Active;
				mPromotion.PROMOTION_TYPE = p_Promotion_Type;
				mPromotion.PROMOTION_SELECTION = p_Promotion_Selection;
				mPromotion.IS_SCHEME = p_Is_Scheme;
				mPromotion.PROMOTION_FOR = p_Promotion_For;
                mPromotion.USER_ID = p_UserId;  

				mPromotion.ExecuteQuery();
				return mPromotion.PROMOTION_ID.ToString() ;
				
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
        /// Updates Promotion
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated" On Success And Exception.Message On Failure
        /// </remarks>
        /// <param name="p_Promotion_Id">Promotion</param>
        /// <param name="p_Scheme_Id">Scheme</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Pro_Code">Code</param>
        /// <param name="p_Pro_Description">Description</param>
        /// <param name="p_Promo_Date">Date</param>
        /// <param name="p_Claimable">Claimable</param>
        /// <param name="p_Start_Date">StartDate</param>
        /// <param name="p_End_Date">EndDate</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="p_Promotion_Type">Type</param>
        /// <param name="p_Promotion_Selection">Selection</param>
        /// <returns>"Record Updated" On Success And Exception.Message On Failure</returns>
        public string UpdatePromotion(long p_Promotion_Id, int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdatePROMOTION mPromotion = new spUpdatePROMOTION();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_ID = p_Promotion_Id;
				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.PROMOTION_CODE = p_Pro_Code;
				mPromotion.PROMOTION_DESCRIPTION = p_Pro_Description;
				mPromotion.PROMO_DATE = p_Promo_Date;
				mPromotion.CLAIMABLE = p_Claimable;
				mPromotion.START_DATE = p_Start_Date;
				mPromotion.END_DATE = p_End_Date;
				mPromotion.IS_ACTIVE = p_Is_Active;
				mPromotion.PROMOTION_TYPE = p_Promotion_Type;
				mPromotion.PROMOTION_SELECTION = p_Promotion_Selection;

				mPromotion.ExecuteQuery();
				
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
        /// Inserts Promotion Locations
        /// </summary>
        /// <remarks>
        /// Returns Inserted Promotion Location ID as String
        /// </remarks>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Assigned_Dist_ID">AssignedLocation</param>
        /// <returns>Inserted Promotion Location ID as String</returns>
        public string InsertPromotionDist(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertPROMOTION_FOR mPromotion = new spInsertPROMOTION_FOR();
                mPromotion.Connection = mConnection;

                mPromotion.PROMOTION_ID = p_Promotion_ID;
                mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
                mPromotion.SCHEME_ID = p_Scheme_ID;
                mPromotion.ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID;

                mPromotion.ExecuteQuery();
                return mPromotion.PROMOTION_FOR_ID.ToString();

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
        /// Inserts Promotion Class
        /// </summary>
        /// <remarks>
        /// Returns Inserted Promotion Class ID as String
        /// </remarks>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_Customer_ID">Customer</param>
        /// <returns>Inserted Promotion Class ID as String</returns>
        public string InsertPromotionVolClass(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertPROMOTION_CUSTOMER_VOLUMECLASS mPromotion = new spInsertPROMOTION_CUSTOMER_VOLUMECLASS();
                mPromotion.Connection = mConnection;

                mPromotion.SCHEME_ID = p_Scheme_ID;
                mPromotion.PROMOTION_ID = p_Promotion_ID;
                mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
                mPromotion.CUSTOMER_VOLUMECLASS_ID = p_Customer_ID;
                mPromotion.ExecuteQuery();
                return mPromotion.PROMOTION_VOLUMECLASS_ID.ToString();

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
        /// Inserts Promotion Channel Type
        /// </summary>
        /// <remarks>
        /// Returns Inserted Promotion Channel Type ID as String
        /// </remarks>
        /// <param name="p_PROMOTION_ID">Promotion</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_SCHEME_ID">Scheme</param>
        /// <param name="p_CUSTOMER_TYPE_ID">ChannelType</param>
        /// <returns>Inserted Promotion Channel Type ID as String</returns>
        public string InsertPromotionCustType(long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertPROMOTION_CUSTOMER_TYPE mPromotion = new spInsertPROMOTION_CUSTOMER_TYPE();
                mPromotion.Connection = mConnection;

                mPromotion.PROMOTION_ID = p_PROMOTION_ID;
                mPromotion.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPromotion.SCHEME_ID = p_SCHEME_ID;
                mPromotion.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;

                mPromotion.ExecuteQuery();
                return mPromotion.PROMOTION_CUSTOMER_TYPE_ID.ToString();

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
        /// Inserts Promotio Offer
        /// </summary>
        /// <remarks>
        /// Returns Promotion Offer ID as String
        /// </remarks>
        /// <param name="p_Basket_ID">Basket</param>
        /// <param name="p_Promotion_ID">Promotion</param>
        /// <param name="p_Scheme_ID">Scheme</param>
        /// <param name="p_Dist_ID">Location</param>
        /// <param name="p_BasketDetail_ID">BasketDetail</param>
        /// <param name="p_Quantity">Quantity</param>
        /// <param name="p_Offer_Value">OfferValue</param>
        /// <param name="p_Discount">Discount</param>
        /// <param name="p_Is_And">IsAnd</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_UOM_ID">UOM</param>
        /// <returns>Promotion Offer ID as String</returns>
        public string InsertPromotionOffer(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, long p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertPROMOTION_OFFER mPromotion = new spInsertPROMOTION_OFFER();
                mPromotion.Connection = mConnection;

                mPromotion.IS_AND = p_Is_And;
                mPromotion.DISCOUNT = p_Discount;
                mPromotion.QUANTITY = p_Quantity;
                mPromotion.SKU_ID = p_SKU_ID;
                mPromotion.UOM_ID = p_UOM_ID;
                mPromotion.SCHEME_ID = p_Scheme_ID;
                mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
                mPromotion.BASKET_DETAIL_ID = p_BasketDetail_ID;
                mPromotion.BASKET_ID = p_Basket_ID;
                mPromotion.PROMOTION_ID = p_Promotion_ID;
                mPromotion.OFFER_VALUE = p_Offer_Value;

                mPromotion.ExecuteQuery();
                return mPromotion.PROMOTION_OFFER_ID.ToString();

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
    }
}
