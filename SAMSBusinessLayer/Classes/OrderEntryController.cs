using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDatabaseLayer.Classes;
using System.Data.SqlTypes ;
using System.Data.SqlClient;
using System.Collections;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.InputClasses;
 
namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Order/Invoice/Sale Return Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Order/Invoice/Sale Return
    /// </item>
    /// <term>
    /// Update Order/Invoice/Sale Return
    /// </term>
    /// <item>
    /// Get Order/Invoice/Sale Return
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class OrderEntryController
    {
        #region Constructor

        /// <summary>
        /// Constructor for OrderEntryController
        /// </summary>
        public OrderEntryController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Select

        /// <summary>
        /// Gets Promotions
        /// </summary>
        /// <remarks>
        /// Returns Promotions as PromotionCollections_Controller
        /// </remarks>
        /// <param name="p_DistId">Location</param>
        /// <param name="Princpal_Id">Principal</param>
        /// <param name="pCurrentDate">Date</param>
        /// <returns>Promotions as PromotionCollections_Controller</returns>
        public PromotionCollections_Controller LoadSchemes(int p_DistId, int Princpal_Id, DateTime pCurrentDate)
        {
            IDbConnection m_Connection = null;
            DataControl dc = new DataControl();
            PromotionCollections_Controller pcc = new PromotionCollections_Controller();
            DataTable dt = null, dt2 = null, dt3 = null, dt4 = null, dt5 = null;

            try
            {

                m_Connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                m_Connection.Open();

                #region Load Scheme Promotion c0llection

                uspSelectPROMOTIONS mSP = new uspSelectPROMOTIONS();
                mSP.Connection = m_Connection;
                mSP.DISTRIBUTOR_ID = p_DistId;
                mSP.PROMOTION_TYPE = Princpal_Id;
                mSP.IS_ACTIVE = true;
                mSP.START_DATE = DateTime.Parse(pCurrentDate.ToShortDateString() + " 00:00:00");
                mSP.END_DATE = DateTime.Parse(pCurrentDate.ToShortDateString() + " 23:59:59");//System.DateTime.Now ;
                dt2 = mSP.ExecuteTable();

                for (int j = 0; j <= dt2.Rows.Count - 1; j++)
                {	// this loop will get all active promotions against the scheme id and distributor id
                    Promotion_Collection pc = new Promotion_Collection();
                    pc.ObjBasketCol_Cntrl = new BasketCollection_Controller();
                    pc.ObjPromotionCustTypeCol_Cntrl = new PromotionCustTypeColl_Controller();
                    pc.ObjPromotionForCol_Cntrl = new PromotionForCollection_Controller();
                    pc.ObjPromotionVolClassCol_Cntrl = new PromotionCustVolclassColl_Controller();

                    pc.Dist_ID = int.Parse(dt2.Rows[j]["Distributor_ID"].ToString());
                    pc.Promotion_Code = dt2.Rows[j]["PROMOTION_CODE"].ToString();
                    pc.Promotion_Date = DateTime.Parse(dt2.Rows[j]["Promo_Date"].ToString());
                    pc.Promotion_Desc = dt2.Rows[j]["Promotion_Description"].ToString();
                    pc.Promotion_ID = long.Parse(dt2.Rows[j]["Promotion_ID"].ToString());
                    if (dt2.Rows[j]["Promotion_Selection"].ToString() != "")
                    { pc.Promotion_Selection = int.Parse(dt2.Rows[j]["Promotion_Selection"].ToString()); }
                    else
                    { pc.Promotion_Selection = -1; }
                    if (dt2.Rows[j]["Promotion_Type"].ToString() != "")
                    { pc.Promotion_Type = int.Parse(dt2.Rows[j]["Promotion_Type"].ToString()); }
                    else
                    { pc.Promotion_Type = -1; }
                    pc.Scheme_ID = int.Parse(dt2.Rows[j]["Scheme_ID"].ToString());
                    pc.Start_Date = DateTime.Parse(dt2.Rows[j]["Start_Date"].ToString());
                    pc.End_Date = DateTime.Parse(dt2.Rows[j]["End_Date"].ToString());
                    pc.Claimable = bool.Parse(dt2.Rows[j]["Claimable"].ToString());
                    pc.Is_Scheme = bool.Parse(dt2.Rows[j]["IS_SCHEME"].ToString());
                    // this loop will get basket data against the scheme id,PromotionID and distributor id

                    #region Basket Collection

                    uspSelectBASKET_MASTER_dt mBM = new uspSelectBASKET_MASTER_dt();
                    mBM.Connection = m_Connection;
                    mBM.DISTRIBUTOR_ID = pc.Dist_ID; //Configuration.DistributorId ;//System .Convert .ToInt32 (sc.Dist_ID) ;
                    mBM.SCHEME_ID = System.Convert.ToInt32(pc.Scheme_ID);
                    mBM.PROMOTION_ID = System.Convert.ToInt32(pc.Promotion_ID);
                    dt3 = mBM.ExecuteTable();

                    for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                    {
                        Basket_Collection bc = new Basket_Collection();
                        bc.ObjBasketDtlCol_Cntrlr = new BasketDetailCollection_Controller();


                        bc.Basket_ID = long.Parse(dt3.Rows[k]["Basket_ID"].ToString());
                        bc.Basket_On = int.Parse(dt3.Rows[k]["Basket_On"].ToString());
                        if (dt3.Rows[k]["Basket_Selection"].ToString() != "")
                        { bc.Basket_Selection = int.Parse(dt3.Rows[k]["Basket_Selection"].ToString()); }
                        else
                        { bc.Basket_Selection = 0; }
                        bc.Dist_ID = int.Parse(dt3.Rows[k]["Distributor_ID"].ToString());
                        bc.Is_And = bool.Parse(dt3.Rows[k]["IS_AND"].ToString());
                        bc.Is_Basket = bool.Parse(dt3.Rows[k]["IS_Basket"].ToString());
                        bc.Is_Multiple = bool.Parse(dt3.Rows[k]["IS_Multiple"].ToString());
                        bc.Promotion_ID = long.Parse(dt3.Rows[k]["Promotion_ID"].ToString());
                        bc.Scheme_ID = int.Parse(dt2.Rows[j]["Scheme_ID"].ToString());
                        // this loop will get basketDetail data against the BasketID, scheme id,PromotionID and distributor id

                        #region Basket Detail
                        uspSelectBASKET_DETAIL_dt mBD = new uspSelectBASKET_DETAIL_dt();
                        mBD.Connection = m_Connection;
                        mBD.BASKET_ID = System.Convert.ToInt32(bc.Basket_ID);
                        mBD.DISTRIBUTOR_ID = bc.Dist_ID; ///Configuration.DistributorId ;//System .Convert .ToInt32 (sc.Dist_ID) ;
                        mBD.SCHEME_ID = System.Convert.ToInt32(pc.Scheme_ID);
                        mBD.PROMOTION_ID = System.Convert.ToInt32(pc.Promotion_ID);
                        dt4 = mBD.ExecuteTable();

                        for (int l = 0; l <= dt4.Rows.Count - 1; l++)
                        {
                            Basket_Detail_Collection bdc = new Basket_Detail_Collection();
                            bdc.ObjPromotionOfferCol_Cntrl = new PromotionOfferColl_Controller();

                            bdc.Basket_ID = long.Parse(dt4.Rows[l]["Basket_ID"].ToString());
                            bdc.BasketDetail_ID = long.Parse(dt4.Rows[l]["Basket_Detail_ID"].ToString());
                            bdc.Dist_ID = int.Parse(dt4.Rows[l]["Distributor_ID"].ToString());
                            bdc.Max_Val = decimal.Parse(dt4.Rows[l]["Max_Val"].ToString());
                            bdc.Min_Val = decimal.Parse(dt4.Rows[l]["Min_Val"].ToString());
                            bdc.Multiple_Of = int.Parse(dc.chkNull(dt4.Rows[l]["Multiple_of"].ToString()));
                            bdc.Promotion_ID = long.Parse(dt4.Rows[l]["Promotion_ID"].ToString());
                            bdc.Scheme_ID = int.Parse(dt4.Rows[l]["Scheme_ID"].ToString());
                            bdc.SKU_ID = int.Parse(dc.chkNull(dt4.Rows[l]["SKU_ID"].ToString()));
                            bdc.SKUBrand_ID = int.Parse(dc.chkNull(dt4.Rows[l]["Brand_ID"].ToString()));
                            bdc.SKUCatg_ID = int.Parse(dc.chkNull(dt4.Rows[l]["Category_ID"].ToString()));
                            bdc.SKUDiv_ID = int.Parse(dc.chkNull(dt4.Rows[l]["Division_ID"].ToString()));
                            bdc.SKUGroup_ID = int.Parse(dc.chkNull(dt4.Rows[l]["SKU_Group_ID"].ToString()));
                            bdc.SKUProductLine_ID = int.Parse(dc.chkNull(dt4.Rows[l]["Variant_ID"].ToString()));
                            bdc.UOM_ID = int.Parse(dc.chkNull(dt4.Rows[l]["UOM_ID"].ToString()));
                            bdc.SKUCompany_ID = int.Parse(dc.chkNull(dt4.Rows[l]["Company_ID"].ToString()));
                            bc.ObjBasketDtlCol_Cntrlr.Add(bdc);

                            #region Basket Promotion Offer Collection
                            /////////////////////////////////////////////
                            ///
                            // This loop will get Promotion Offer data against the BasketID, scheme id,
                            // PromotionID,basketDetail ID and distributor id
                            uspSelectPROMOTION_OFFER_dt mPO = new uspSelectPROMOTION_OFFER_dt();

                            mPO.Connection = m_Connection;
                            mPO.BASKET_ID = System.Convert.ToInt32(bc.Basket_ID);
                            mPO.DISTRIBUTOR_ID = bc.Dist_ID;//System .Convert .ToInt32 (sc.Dist_ID) ;
                            mPO.SCHEME_ID = System.Convert.ToInt32(pc.Scheme_ID);
                            mPO.PROMOTION_ID = System.Convert.ToInt32(pc.Promotion_ID);
                            mPO.BASKET_DETAIL_ID = System.Convert.ToInt32(bdc.BasketDetail_ID);
                            dt5 = null;		// no need to keep old values in dt4
                            dt5 = mPO.ExecuteTable();
                            for (int m = 0; m <= dt5.Rows.Count - 1; m++)
                            {
                                #region to avoid null values
                                string mDiscount = dt5.Rows[m]["Discount"].ToString();
                                string mOfferValue = dt5.Rows[m]["Offer_Value"].ToString();
                                string mQty = dt5.Rows[m]["Quantity"].ToString();
                                if ((mDiscount == "") || (mDiscount == null))
                                { mDiscount = "0"; }
                                if ((mOfferValue == "") || (mOfferValue == null))
                                { mOfferValue = "0"; }
                                if ((mQty == "") || (mQty == null))
                                { mQty = "0"; }
                                #endregion

                                PromotionOffer_Collection poc = new PromotionOffer_Collection();

                                poc.Basket_ID = long.Parse(dt5.Rows[m]["Basket_ID"].ToString());
                                poc.BasketDetail_ID = long.Parse(dt5.Rows[m]["Basket_Detail_ID"].ToString());
                                poc.Discount = float.Parse(mDiscount);
                                poc.Dist_ID = int.Parse(dt5.Rows[m]["Distributor_ID"].ToString());
                                poc.Is_And = bool.Parse(dt5.Rows[m]["Is_And"].ToString());
                                poc.Offer_Value = decimal.Parse(mOfferValue);
                                poc.Promotion_ID = long.Parse(dt5.Rows[m]["Promotion_ID"].ToString());
                                poc.Promotion_Offer_ID = long.Parse(dt5.Rows[m]["Promotion_Offer_ID"].ToString());
                                poc.Quantity = int.Parse(mQty);
                                poc.Scheme_ID = int.Parse(dt5.Rows[m]["Scheme_ID"].ToString());
                                poc.SKU_ID = int.Parse(dc.chkNull(dt5.Rows[m]["SKU_ID"].ToString()));
                                poc.UOM_ID = int.Parse(dc.chkNull(dt5.Rows[m]["UOM_ID"].ToString()));

                                bdc.ObjPromotionOfferCol_Cntrl.Add(poc);
                            }
                            #endregion

                        }
                        #endregion
                        pc.ObjBasketCol_Cntrl.Add(bc);
                    }
                    #endregion
                    ////////////////////////////////////////	
                    // this loop will get Promotion_For data against the scheme id,PromotionID and distributor id					
                    #region Promotion_For Collection
                    dt3 = null;
                    uspSelectPROMOTION_FOR_dt mPF = new uspSelectPROMOTION_FOR_dt();
                    mPF.Connection = m_Connection;
                    mPF.PROMOTION_FOR_ID = Constants.LongNullValue;
                    mPF.DISTRIBUTOR_ID = pc.Dist_ID;//System .Convert .ToInt32 (sc.Dist_ID) ;
                    mPF.ASSIGNED_DISTRIBUTOR_ID = Configuration.DistributorId;
                    mPF.SCHEME_ID = System.Convert.ToInt32(pc.Scheme_ID);
                    mPF.PROMOTION_ID = System.Convert.ToInt32(pc.Promotion_ID);
                    dt3 = mPF.ExecuteTable();

                    for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                    {
                        PromotionFor_Collection pfc = new PromotionFor_Collection();
                        pfc.Dist_ID = int.Parse(dt3.Rows[k]["Distributor_ID"].ToString());
                        pfc.Assigned_Dist_ID = int.Parse(dt3.Rows[k]["Assigned_Distributor_ID"].ToString());
                        pfc.Promotion_For_ID = long.Parse(dt3.Rows[k]["Promotion_For_ID"].ToString());
                        pfc.Promotion_ID = long.Parse(dt3.Rows[k]["Promotion_ID"].ToString());
                        pfc.Scheme_ID = int.Parse(dt3.Rows[k]["Scheme_ID"].ToString());
                        pc.ObjPromotionForCol_Cntrl.Add(pfc);
                    }

                    #endregion
                    ////////////////////////////////////////
                    ///// this loop will get Promotion_For_Customer_VolClass data against the scheme id,PromotionID and distributor id					
                    #region Promotion_For_VOLUMECLASS Collection
                    dt3 = null;
                    spSelectPROMOTION_CUSTOMER_VOLUMECLASS mPFC = new spSelectPROMOTION_CUSTOMER_VOLUMECLASS();
                    mPFC.Connection = m_Connection;
                    mPFC.DISTRIBUTOR_ID = pc.Dist_ID;
                    mPFC.SCHEME_ID = System.Convert.ToInt32(pc.Scheme_ID);
                    mPFC.PROMOTION_ID = System.Convert.ToInt32(pc.Promotion_ID);
                    dt3 = mPFC.ExecuteTable();

                    for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                    {
                        PromotionCustomerVolClass_Collection pfcc = new PromotionCustomerVolClass_Collection();
                        pfcc.Dist_ID = int.Parse(dt3.Rows[k]["Distributor_ID"].ToString());
                        pfcc.Promotion_ID = long.Parse(dt3.Rows[k]["Promotion_ID"].ToString());
                        pfcc.Scheme_ID = int.Parse(dt3.Rows[k]["Scheme_ID"].ToString());
                        pfcc.Customer_VolClass_ID = int.Parse(dt3.Rows[k]["CUSTOMER_VOLUMECLASS_ID"].ToString());
                        pc.ObjPromotionVolClassCol_Cntrl.Add(pfcc);
                    }

                    #endregion
                    ////////////////////////////////////////
                    //////// this loop will get Promotion_Customer_type data against the scheme id,PromotionID and distributor id					
                    #region Promotion_Customer_Type Collection
                    dt3 = null;
                    uspSelectPROMOTION_CUSTOMER_TYPE_dt mPCT = new uspSelectPROMOTION_CUSTOMER_TYPE_dt();
                    mPCT.Connection = m_Connection;
                    mPCT.DISTRIBUTOR_ID = pc.Dist_ID; // Configuration.DistributorId ;//System .Convert .ToInt32 (sc.Dist_ID) ;
                    mPCT.SCHEME_ID = System.Convert.ToInt32(pc.Scheme_ID);
                    mPCT.PROMOTION_ID = System.Convert.ToInt32(pc.Promotion_ID);
                    dt3 = mPCT.ExecuteTable();

                    for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                    {
                        PromotionCustomerType_Collection pctc = new PromotionCustomerType_Collection();
                        pctc.Dist_ID = int.Parse(dt3.Rows[k]["Distributor_ID"].ToString());
                        pctc.Customer_Type_ID = int.Parse(dt3.Rows[k]["Customer_Type_ID"].ToString());
                        pctc.Promotion_Cust_Type_ID = long.Parse(dt3.Rows[k]["Promotion_Customer_Type_ID"].ToString());
                        pctc.Promotion_ID = long.Parse(dt3.Rows[k]["Promotion_ID"].ToString());
                        pctc.Scheme_ID = int.Parse(dt3.Rows[k]["Scheme_ID"].ToString());
                        pc.ObjPromotionCustTypeCol_Cntrl.Add(pctc);
                    }

                    #endregion
                    ////////////////////////////////////////
                    pcc.Add_PCol(pc);

                }
                #endregion

                return pcc;


            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
                return null;
            }
            finally
            {
                if (m_Connection != null && m_Connection.State != ConnectionState.Open)
                {
                    m_Connection.Close();
                }
            }
        }
        
        /// <summary>
        /// Gets Promotion Offers
        /// </summary>
        /// <remarks>
        /// Returns Promotion Offers as ArrayList
        /// </remarks>
        /// <param name="pc">PromotionCollections_Controller</param>
        /// <param name="p_CustomerVoldClass">PromotionClass</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_OrderDetail">OrderDetailDatatable</param>
        /// <param name="p_IsScheme">IsScheme</param>
        /// <returns>Promotion Offers as ArrayList</returns>
        public ArrayList GetPromotionOffers(PromotionCollections_Controller pc, int p_CustomerVoldClass, int p_CustomerId, DataTable p_OrderDetail, bool p_IsScheme)
        {

            int PromotionIdx = 0;
            DataRow drOrderDetail = null;

            PromoOffersCol_Controller POffersCol_Cntrlr = new PromoOffersCol_Controller();
            SKUGroupController GroupCtl = new SKUGroupController();

            ArrayList arrPromotionOffers = new ArrayList();



            while (PromotionIdx < pc.Count)
            {


                bool IsValidCustomerTypeId = false;
                bool IsValidCustomerVolCla = false;

                DataTable dtGroup = new DataTable();
                dtGroup.Columns.Add("GroupId", typeof(long));

                for (int j = 0; j < pc.Get_PCol(PromotionIdx).ObjPromotionCustTypeCol_Cntrl.Count; j++)
                {
                    if (pc.Get_PCol(PromotionIdx).ObjPromotionCustTypeCol_Cntrl.Get(j).Customer_Type_ID == p_CustomerId)
                    {
                        IsValidCustomerTypeId = true;
                        break;
                    }
                }

                for (int j = 0; j < pc.Get_PCol(PromotionIdx).ObjPromotionVolClassCol_Cntrl.Count; j++)
                {
                    if (pc.Get_PCol(PromotionIdx).ObjPromotionVolClassCol_Cntrl.Get(j).Customer_VolClass_ID == p_CustomerVoldClass)
                    {
                        IsValidCustomerVolCla = true;
                        break;
                    }
                }
                if (IsValidCustomerTypeId == true && IsValidCustomerVolCla == true)
                {

                    for (int idxOrderDetail = 0; idxOrderDetail < p_OrderDetail.Rows.Count; idxOrderDetail++)
                    {


                        drOrderDetail = p_OrderDetail.Rows[idxOrderDetail];


                        #region Slab

                       BasketCollection_Controller ObjBasket = pc.Get_PCol(PromotionIdx).ObjBasketCol_Cntrl;

                        for (int i = 0; i < ObjBasket.Count; i++)
                        {
                            bool Applygroup = false;
                            decimal dValueToCompare = 0;
                            int dMultipalGroupItem = 0;

                            BasketDetailCollection_Controller objBasketDetail = ObjBasket.Get(i).ObjBasketDtlCol_Cntrlr;

                            for (int j = 0; j < objBasketDetail.Count; j++)
                            {

                                if (objBasketDetail.Get(j).SKU_ID > 0)
                                {
                                    #region Single SKU
                                    //If SLAB applied at single SKU

                                    if (objBasketDetail.Get(j).SKU_ID == int.Parse(drOrderDetail["SKU_ID"].ToString()))
                                    {
                                        //Check at Amount or Quantity SLAB is Applied
                                        if (ObjBasket.Get(i).Basket_On == Constants.Basket_On_Amount)
                                        {
                                            dValueToCompare = decimal.Parse(drOrderDetail["Amount"].ToString());
                                        }
                                        else if (ObjBasket.Get(i).Basket_On == Constants.Basket_On_Quantity)
                                        {
                                            dValueToCompare = decimal.Parse(drOrderDetail["QUANTITY"].ToString());
                                        }

                                        //Check if SLAB is applicable

                                        if (dValueToCompare >= objBasketDetail.Get(j).Min_Val && (dValueToCompare <= objBasketDetail.Get(j).Max_Val || objBasketDetail.Get(j).Max_Val == 0))
                                        {

                                            //Add applied Promotion offer in array										

                                            PromotionOfferColl_Controller objPromotionOffer = objBasketDetail.Get(j).ObjPromotionOfferCol_Cntrl;
                                            PromoOffers_Collection AppProCol = new PromoOffers_Collection();

                                            if (dValueToCompare > objBasketDetail.Get(j).Multiple_Of && objBasketDetail.Get(j).Multiple_Of > 0)
                                            {
                                                int iMultiply = Convert.ToInt32(Math.Floor(Convert.ToDouble(dValueToCompare / objBasketDetail.Get(j).Multiple_Of)));
                                                AppProCol.Quantity = objPromotionOffer.Get(j).Quantity * iMultiply;
                                                AppProCol.Offer_Value = objPromotionOffer.Get(j).Offer_Value * iMultiply;

                                            }
                                            else
                                            {
                                                AppProCol.Quantity = objPromotionOffer.Get(j).Quantity;
                                                AppProCol.Offer_Value = objPromotionOffer.Get(j).Offer_Value;

                                            }

                                            AppProCol.SKU_ID = int.Parse(drOrderDetail["SKU_ID"].ToString());
                                            AppProCol.Group_ID = Constants.IntNullValue;
                                            AppProCol.Promotion_ID = int.Parse(objPromotionOffer.Get(j).Promotion_ID.ToString());
                                            AppProCol.Scheme_ID = objPromotionOffer.Get(j).Scheme_ID;
                                            AppProCol.Basket_ID = objPromotionOffer.Get(j).Basket_ID;
                                            AppProCol.BasketDetail_ID = objPromotionOffer.Get(j).BasketDetail_ID;
                                            AppProCol.Free_SKU_ID = objPromotionOffer.Get(j).SKU_ID;
                                            AppProCol.Discount = objPromotionOffer.Get(j).Discount;
                                            AppProCol.Is_And = pc.Get_PCol(PromotionIdx).Is_Scheme;
                                            AppProCol.Is_Claimable = pc.Get_PCol(PromotionIdx).Claimable;

                                            arrPromotionOffers.Add(AppProCol);

                                        }


                                    }
                                    #endregion
                                }
                                else if (objBasketDetail.Get(j).SKUGroup_ID > 0)
                                {
                                    SKUGroupController mGroup = new SKUGroupController();

                                    //check if Already Apply Group then return 

                                    foreach (DataRow drGroup in dtGroup.Rows)
                                    {
                                        if (drGroup[0].ToString() == objBasketDetail.Get(j).SKUGroup_ID.ToString())
                                        {
                                            Applygroup = true;
                                        }
                                    }
                                        #region Group
                                    if (Applygroup == false)
                                    {
                                        dValueToCompare = 0;
                                        dMultipalGroupItem = 0;

                                        if (ObjBasket.Get(i).Basket_On == Constants.Basket_On_Amount)
                                        {
                                            foreach (DataRow dg in p_OrderDetail.Rows)
                                            {
                                                if (GroupCtl.ExistsInGroup(Constants.IntNullValue, objBasketDetail.Get(j).SKUGroup_ID, int.Parse(dg["SKU_ID"].ToString())))
                                                {
                                                    dValueToCompare += decimal.Parse(dg["AMOUNT"].ToString());
                                                    dMultipalGroupItem += 1;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            foreach (DataRow dg in p_OrderDetail.Rows)
                                            {
                                                if (GroupCtl.ExistsInGroup(Constants.IntNullValue, objBasketDetail.Get(j).SKUGroup_ID, int.Parse(dg["SKU_ID"].ToString())))
                                                {
                                                    dValueToCompare += decimal.Parse(dg["QUANTITY"].ToString());
                                                    dMultipalGroupItem += 1;
                                                }
                                            }
                                        }

                                        if (dValueToCompare >= objBasketDetail.Get(j).Min_Val && (dValueToCompare <= objBasketDetail.Get(j).Max_Val || objBasketDetail.Get(j).Max_Val == 0))
                                        {

                                            //Add applied Promotion offer in array										

                                            PromotionOfferColl_Controller objPromotionOffer = objBasketDetail.Get(j).ObjPromotionOfferCol_Cntrl;
                                            PromoOffers_Collection AppProCol = new PromoOffers_Collection();

                                            if (dValueToCompare > objBasketDetail.Get(j).Multiple_Of && objBasketDetail.Get(j).Multiple_Of > 0)
                                            {
                                                int iMultiply = Convert.ToInt32(Math.Floor(Convert.ToDouble(dValueToCompare / objBasketDetail.Get(j).Multiple_Of)));
                                                AppProCol.Quantity = (objPromotionOffer.Get(j).Quantity * iMultiply);
                                                AppProCol.Offer_Value = (objPromotionOffer.Get(j).Offer_Value * iMultiply) / dMultipalGroupItem;

                                            }
                                            else
                                            {
                                                AppProCol.Quantity = objPromotionOffer.Get(j).Quantity;
                                                AppProCol.Offer_Value = objPromotionOffer.Get(j).Offer_Value / dMultipalGroupItem;

                                            }

                                            AppProCol.SKU_ID = objBasketDetail.Get(j).SKU_ID;
                                            AppProCol.Group_ID = objBasketDetail.Get(j).SKUGroup_ID;
                                            AppProCol.Promotion_ID = int.Parse(objPromotionOffer.Get(j).Promotion_ID.ToString());
                                            AppProCol.Scheme_ID = objPromotionOffer.Get(j).Scheme_ID;
                                            AppProCol.Basket_ID = objPromotionOffer.Get(j).Basket_ID;
                                            AppProCol.BasketDetail_ID = objPromotionOffer.Get(j).BasketDetail_ID;
                                            AppProCol.Free_SKU_ID = objPromotionOffer.Get(j).SKU_ID;
                                            AppProCol.Discount = objPromotionOffer.Get(j).Discount;
                                            AppProCol.Is_And = pc.Get_PCol(PromotionIdx).Is_Scheme;
                                            AppProCol.Is_Claimable = pc.Get_PCol(PromotionIdx).Claimable;
                                            arrPromotionOffers.Add(AppProCol);


                                            DataRow drNewGroup = dtGroup.NewRow();
                                            drNewGroup[0] = AppProCol.Group_ID.ToString();
                                            dtGroup.Rows.Add(drNewGroup);

                                        }
                                    #endregion
                                    }
                                }

                            }
                        }
                        #endregion
                    }
                }
                PromotionIdx++;
            }
            return arrPromotionOffers;
        }
        
        /// <summary>
        /// Gets Pending Orders
        /// </summary>
        /// <param name="p_Distributor_Id">Loation</param>
        /// <param name="p_Area_Id">Route</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Order_Booker">OrderBooker</param>
        /// <param name="p_DeliveryMan_Id">DeliveryMan</param>
        /// <param name="p_OrderStatus">Status</param>
        /// <param name="p_Ordertype">Type</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <returns>Pending Orders as Datatable</returns>
        public DataTable SelectPendingOrder(int p_Distributor_Id, int p_Area_Id, int p_Principal_Id, int p_Order_Booker, int p_DeliveryMan_Id, int p_OrderStatus, int p_Ordertype, int p_UserId, DateTime p_DOCUMENT_DATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPendingOrder mOrder = new UspSelectPendingOrder();
                mOrder.Connection = mConnection;
                mOrder.DISTRIBUTOR_ID = p_Distributor_Id;
                mOrder.AREA_ID = p_Area_Id;
                mOrder.ORDERBOOKER_ID = p_Order_Booker;
                mOrder.DELIVERYMAN_ID = p_DeliveryMan_Id;
                mOrder.USER_ID = p_UserId;
                mOrder.PRINCIPAL_ID = p_Principal_Id;
                mOrder.STATUS_ID = p_OrderStatus;
                mOrder.ORDER_TYPE_ID = p_Ordertype;
                mOrder.DOCUMENT_DATE = p_DOCUMENT_DATE;
                DataTable dt = mOrder.ExecuteTable();
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
        /// Gets Order Detail
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleOrder_Id">Order</param>
        /// <returns>Order Detail as Datatable</returns>
        public DataTable SelectOrderDetail(int p_Distributor_Id, long p_SaleOrder_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALE_ORDER_DETAIL mOrderDetail = new spSelectSALE_ORDER_DETAIL();
                mOrderDetail.Connection = mConnection;
                mOrderDetail.DISTRIBUTOR_ID = p_Distributor_Id;
                mOrderDetail.SALE_ORDER_ID = p_SaleOrder_Id;
                mOrderDetail.IS_DELETED = false;
                DataTable dt = mOrderDetail.ExecuteTable();
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
        /// Gets Promotions Of Order
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleOrder_Id">Order</param>
        /// <returns>Promotion Of Order as Datatable</returns>
        public DataTable SelectOrderPromotion(int p_Distributor_Id, long p_SaleOrder_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALE_ORDER_PROMOTION mOrderDetail = new spSelectSALE_ORDER_PROMOTION();
                mOrderDetail.Connection = mConnection;
                mOrderDetail.DISTRIBUTOR_ID = p_Distributor_Id;
                mOrderDetail.SALE_ORDER_ID = p_SaleOrder_Id;
                DataTable dt = mOrderDetail.ExecuteTable();
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
        /// Gets Promotions Of Invoice
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleInvoice_Id">Invoice</param>
        /// <returns>Promotion Of Invoice as Datatable</returns>
        public DataTable SelectInvoicePromotion(int p_Distributor_Id, long p_SaleInvoice_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALE_INVOICE_PROMOTION mOrderDetail = new spSelectSALE_INVOICE_PROMOTION();
                mOrderDetail.Connection = mConnection;
                mOrderDetail.DISTRIBUTOR_ID = p_Distributor_Id;
                mOrderDetail.SALE_INVOICE_ID = p_SaleInvoice_Id;
                DataTable dt = mOrderDetail.ExecuteTable();
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
        /// Gets Legend
        /// </summary>
        /// <returns>Legend as Datatable</returns>
        public DataTable SelectLegend()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectLEGEND mOrderDetail = new spSelectLEGEND();
                mOrderDetail.Connection = mConnection;
                mOrderDetail.LEGEND_ID = Constants.IntNullValue;
                mOrderDetail.LEGEND_TYPE_ID = Constants.IntNullValue;
                mOrderDetail.TIMESTAMP = Constants.DateNullValue;
                mOrderDetail.LAST_UPDATE_DATE = Constants.DateNullValue;
                mOrderDetail.LEGEND_DESCRIPTION = null;
                mOrderDetail.LEGEND_NAME = null;
                mOrderDetail.IS_ACTIVE = true;
                mOrderDetail.USER_ID = Constants.IntNullValue;
                DataTable dt = mOrderDetail.ExecuteTable();
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
        /// Gets Tranporter
        /// </summary>
        /// <returns>Transporter as Datatable</returns>
        public DataTable SelectTranspoter()
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
        
        /// <summary>
        /// Gets Transporter Invoices
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_type">Type</param>
        /// <returns>Transporter Invoices as Datatable</returns>
        public DataTable SelectTranspoterInvoice(int p_Distributor_id, long p_CustomerId, int p_type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectTranspoterInvoice mInvoice = new UspSelectTranspoterInvoice();
                mInvoice.Connection = mConnection;
                mInvoice.DISTRIBUTOR_ID = p_Distributor_id;
                mInvoice.CUSTOMER_ID = p_CustomerId;
                mInvoice.TypeId = p_type;
                DataTable dt = mInvoice.ExecuteTable();
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
        /// Converts Orders To Invoices
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_MANUAL_ORDER_ID">ManualInvocie</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_SaleOrder_Id">Order</param>
        /// <param name="p_Document_Date">Date</param>
        /// <param name="p_GrossSale">Sale</param>
        /// <param name="p_Discount">Discount</param>
        /// <param name="p_scheme">Scheme</param>
        /// <param name="p_GstAmt">GST</param>
        /// <param name="p_Net_Amount">NetAmount</param>
        /// <param name="p_OrderStatus">Status</param>
        /// <param name="p_OrderTypeId">Type</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_PayeesName">Payee</param>
        /// <returns></returns>
        public DataTable ConvertOrder_to_Invoice(int p_Distributor_Id, string p_MANUAL_ORDER_ID, long p_Customer_Id, int p_Principal_Id,
            long p_SaleOrder_Id, DateTime p_Document_Date, decimal p_GrossSale, decimal p_Discount, decimal p_scheme,
            decimal p_GstAmt, decimal p_Net_Amount, int p_OrderStatus, int p_OrderTypeId, int p_UserId, string p_PayeesName)
        {
            #region variables
            IDbTransaction mTransaction = null;
            IDbConnection mConnection = null;
            #endregion

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspConvertOrdertoInvoice mOrder = new UspConvertOrdertoInvoice();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                mOrder.Connection = mConnection;
                mOrder.Transaction = mTransaction;
                mOrder.DISTRIBUTOR_ID = p_Distributor_Id;
                mOrder.PRINCIPAL_ID = p_Principal_Id;
                mOrder.CUSTOMER_ID = p_Customer_Id;
                mOrder.DOCUMENT_DATE = p_Document_Date;
                mOrder.SALE_ORDER_ID = p_SaleOrder_Id;

                if (p_OrderTypeId == Constants.Credit_Order_Id)
                {
                    mOrder.NET_AMOUNT = p_Net_Amount;
                }
                else
                {
                    mOrder.NET_AMOUNT = 0;
                }
                mOrder.ORDER_STATUS = p_OrderStatus;
                mOrder.USER_ID = p_UserId;
                
                DataTable dt = mOrder.ExecuteTable();
                if (dt.Columns.Count > 1)
                {
                    mTransaction.Rollback();
                    return dt;
                }

                #region Account Posting

                LedgerController LController = new LedgerController();
                Configuration.GetAccountHead();
                string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_Id);

                if (p_OrderTypeId == Constants.Advance_PaymentOrder_id)
                {
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0, p_GrossSale, p_Document_Date, "Gross Sale Value", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_PayeesName);
                    if (p_Discount > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleDiscount), p_Distributor_Id, p_Discount, 0, p_Document_Date, "Standard Discount", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_PayeesName);
                    }
                    if (p_scheme > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleScheme), p_Distributor_Id, p_scheme, 0, p_Document_Date, "Extra Discount", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_PayeesName);
                    }
                    if (p_GstAmt > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.GSTAccount), p_Distributor_Id, 0, p_GstAmt, p_Document_Date, "GST Tax", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_PayeesName);
                    }

                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, p_Net_Amount, 0, p_Document_Date, "Recevieable from Customer", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_PayeesName);

                }
                else if (p_OrderTypeId == Constants.Credit_Order_Id)
                {

                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, p_Net_Amount, 0, p_Document_Date, "Credit Sale Default", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_PayeesName);
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0, p_Net_Amount, p_Document_Date, "Credit Sale Default", DateTime.Now, p_Principal_Id, int.Parse(p_Customer_Id.ToString()), long.Parse(dt.Rows[0][0].ToString()), p_MANUAL_ORDER_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_PayeesName);
                }
                #endregion

                mTransaction.Commit();
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
        /// Gets Orders And Invoices Summary
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Areaid">Market</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="FromDocNo">DateFrom</param>
        /// <param name="ToDocNo">DateTo</param>
        /// <param name="DocumentTypeId">Type</param>
        /// <param name="p_IS_REGISTERED">IsRegistered</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <returns>Orders And Invoices Summary as Datatable</returns>
        public DataTable SelectDocumentforView(int p_Distributor_ID, int p_Areaid, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo, int DocumentTypeId, int p_IS_REGISTERED, int p_DELIVERYMAN_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDocumentView ObjPrint = new UspDocumentView();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
                ObjPrint.AREA_ID = p_Areaid;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = FromDocNo;
                ObjPrint.TO_DATE = ToDocNo;
                ObjPrint.TYPE_ID = DocumentTypeId;
                ObjPrint.IS_REGISTERED = p_IS_REGISTERED;
                ObjPrint.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                DataTable dt = ObjPrint.ExecuteTable();
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
        
        #region Rollback

        /// <summary>
        /// Gets Rollback Data For Order, Invoice And Sale Return
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Order_Booker">OrderBooker</param>
        /// <param name="p_TypeId">Type</param>
        /// <param name="p_DocumentDate">Date</param>
        /// <returns>Rollback Data For Order, Invoice And Sale Return as Datatable</returns>
        public DataTable SelectRollBackDocument(int p_Distributor_Id, int p_Principal_Id, int p_Order_Booker, int p_TypeId, DateTime p_DocumentDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectRollBackDocument mOrder = new UspSelectRollBackDocument();
                mOrder.Connection = mConnection;
                mOrder.DISTRIBUTOR_ID = p_Distributor_Id;
                mOrder.DOCUMENT_TYPE = p_TypeId;
                mOrder.PRINCIPAL_ID = p_Principal_Id;
                mOrder.ORDERBOOKER_ID = p_Order_Booker;
                mOrder.DOCUMENT_DATE = p_DocumentDate;
                DataTable dt = mOrder.ExecuteTable();
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

        #region Added By Hazrat Ali

        /// <summary>
        /// Checks Manual Order No And Manual Invoice No
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_MANUAL_ORDER_ID">ManualOrder</param>
        /// <param name="p_TYPE">Type</param>
        /// <returns>Manual Order No And Manual Invoice No as Datatable</returns>
        public DataTable SelectBillBookNo(int p_Distributor_Id, string p_MANUAL_ORDER_ID, int p_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspIsBillBookNoExist mBillBookNo = new uspIsBillBookNoExist();
                mBillBookNo.Connection = mConnection;
                mBillBookNo.DISTRIBUTOR_ID = p_Distributor_Id;
                mBillBookNo.MANUAL_ID = p_MANUAL_ORDER_ID;
                mBillBookNo.TYPE = p_TYPE;
                DataTable dt = mBillBookNo.ExecuteTable();
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

     #region Insert, Update, Deleted
            
        /// <summary>
        /// Inserts Order
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_MANUAL_ORDER_ID">ManualOrder</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_SOLD_TO">Customer</param>
        /// <param name="p_SHIP_TO">ShipTo</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_OrderTypeId">Type</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_EXTRA_DISCOUNT_AMOUNT">ExtraDiscount</param>
        /// <param name="p_STANDARD_DISCOUNT_AMOUNT">StandardDiscount</param>
        /// <param name="p_GST_AMOUNT">GST</param>
        /// <param name="p_TOTAL_NET_AMOUNT">NetAmount</param>
        /// <param name="p_SCHEME_AMOUNT">SchemeAmount</param>
        /// <param name="p_STATUS_ID">Status</param>
        /// <param name="dtOrderDetail">OrderDetailDatatable</param>
        /// <param name="dtFreeSKU">FreeSKUDatatable</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_Document_Date">Date</param>
        /// <param name="p_SEDAmount">SEDAmount</param>
        /// <param name="p_TSTAmount">TSTAmount</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Add_Order(int p_Distributor_id,string p_MANUAL_ORDER_ID,int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID,int p_OrderTypeId,
            decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int p_STATUS_ID, DataTable dtOrderDetail, DataTable dtFreeSKU,int p_UserId,DateTime p_Document_Date,decimal p_SEDAmount,decimal p_TSTAmount)
        {
           
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertSALE_ORDER_MASTER mISom = new spInsertSALE_ORDER_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtOrderDetail.Rows.Count > 0)  
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.MANUAL_ORDER_ID = p_MANUAL_ORDER_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;  
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_Document_Date;
                    mISom.SHIP_TO = p_SHIP_TO;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;  
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;  
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.STATUS_ID = p_STATUS_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;  
                    mISom.ORDER_TYPE_ID = p_OrderTypeId;  
                    mISom.TIME_STAMP = DateTime.Now;   
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.ExecuteQuery();
                    

                    //----------------Insert into sale order detail-------------
                    spInsertSALE_ORDER_DETAIL mSaleOrderDetail = new spInsertSALE_ORDER_DETAIL();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach(DataRow dr in dtOrderDetail.Rows)   
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID  = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO  = dr["BATCH_NO"].ToString();
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["QUANTITY"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                        mSaleOrderDetail.EXTRA_DISCOUNT = decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        mSaleOrderDetail.STANDARD_DISCOUNT = decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = decimal.Parse(dr["SED_AMOUNT"].ToString());
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_Document_Date;
                        TotalAmt +=  decimal.Parse(dr["AMOUNT"].ToString());
                        ExtraDiscount += decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        DiscountAmount += decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        GSTAmount  += decimal.Parse(dr["GST_AMOUNT"].ToString());
                        TotalNetAmt  += decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.ExecuteQuery();
                        
                       

                    }
                    foreach (DataRow df in dtFreeSKU.Rows)
                    {
                        //----------------Insert into sale order Promotion-------------
                        spInsertSALE_ORDER_PROMOTION mSaleOrderPromo = new spInsertSALE_ORDER_PROMOTION();
                        mSaleOrderPromo.Connection = mConnection;
                        mSaleOrderPromo.Transaction = mTransaction;

                        mSaleOrderPromo.BASKET_DETAIL_ID = int.Parse(df["BASKET_DETAIL_ID"].ToString());
                        mSaleOrderPromo.BASKET_ID = int.Parse(df["BASKET_ID"].ToString());
                        mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderPromo.GST_AMOUNT = decimal.Parse(df["GST_AMOUNT"].ToString());
                        mSaleOrderPromo.GST_RATE = float.Parse(df["GST_RATE"].ToString());
                        mSaleOrderPromo.PROMOTION_ID = int.Parse(df["PROMOTION_ID"].ToString());
                        mSaleOrderPromo.PROMOTION_OFFER_ID = int.Parse(df["PROMOTION_OFFER_ID"].ToString());
                        mSaleOrderPromo.QUANTITY = int.Parse(df["Quantity"].ToString());
                        mSaleOrderPromo.SKU_ID = int.Parse(df["SKU_ID"].ToString());
                        mSaleOrderPromo.UNIT_PRICE = decimal.Parse(df["UNIT_PRICE"].ToString());
                        mSaleOrderPromo.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                        mSaleOrderPromo.AMOUNT = decimal.Parse(df["AMOUNT"].ToString());
                        mSaleOrderPromo.TST_AMOUNT = decimal.Parse(df["TST_AMOUNT"].ToString());
                        mSaleOrderPromo.SED_AMOUNT = 0;
                        mSaleOrderPromo.ExecuteQuery();
                    }
                     
                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }


        public bool Update_Order( long p_Sale_Order_ID,int p_Distributor_id, string p_MANUAL_ORDER_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, int p_OrderTypeId,
            decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int p_STATUS_ID, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, DateTime p_Document_Date, decimal p_SEDAmount, decimal p_TSTAmount)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spUpdateSALE_ORDER_MASTER mISom = new spUpdateSALE_ORDER_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.SALE_ORDER_ID = p_Sale_Order_ID;
                    mISom.MANUAL_ORDER_ID = p_MANUAL_ORDER_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_Document_Date;
                    mISom.SHIP_TO = p_SHIP_TO;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.STATUS_ID = p_STATUS_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;
                    mISom.ORDER_TYPE_ID = p_OrderTypeId;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.ExecuteQuery();

                    DeleteOrderDetail(p_Sale_Order_ID);
                    DeleteOrderDetailPromotion(p_Sale_Order_ID);
                    //----------------Insert into sale order detail-------------
                    spInsertSALE_ORDER_DETAIL mSaleOrderDetail = new spInsertSALE_ORDER_DETAIL();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["QUANTITY"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                        mSaleOrderDetail.EXTRA_DISCOUNT = decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        mSaleOrderDetail.STANDARD_DISCOUNT = decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = decimal.Parse(dr["SED_AMOUNT"].ToString());
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_Document_Date;
                        TotalAmt += decimal.Parse(dr["AMOUNT"].ToString());
                        ExtraDiscount += decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        DiscountAmount += decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        GSTAmount += decimal.Parse(dr["GST_AMOUNT"].ToString());
                        TotalNetAmt += decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.ExecuteQuery();



                    }
                    foreach (DataRow df in dtFreeSKU.Rows)
                    {
                        //----------------Insert into sale order Promotion-------------
                        spInsertSALE_ORDER_PROMOTION mSaleOrderPromo = new spInsertSALE_ORDER_PROMOTION();
                        mSaleOrderPromo.Connection = mConnection;
                        mSaleOrderPromo.Transaction = mTransaction;

                        mSaleOrderPromo.BASKET_DETAIL_ID = int.Parse(df["BASKET_DETAIL_ID"].ToString());
                        mSaleOrderPromo.BASKET_ID = int.Parse(df["BASKET_ID"].ToString());
                        mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderPromo.GST_AMOUNT = decimal.Parse(df["GST_AMOUNT"].ToString());
                        mSaleOrderPromo.GST_RATE = float.Parse(df["GST_RATE"].ToString());
                        mSaleOrderPromo.PROMOTION_ID = int.Parse(df["PROMOTION_ID"].ToString());
                        mSaleOrderPromo.PROMOTION_OFFER_ID = int.Parse(df["PROMOTION_OFFER_ID"].ToString());
                        mSaleOrderPromo.QUANTITY = int.Parse(df["Quantity"].ToString());
                        mSaleOrderPromo.SKU_ID = int.Parse(df["SKU_ID"].ToString());
                        mSaleOrderPromo.UNIT_PRICE = decimal.Parse(df["UNIT_PRICE"].ToString());
                        mSaleOrderPromo.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                        mSaleOrderPromo.AMOUNT = decimal.Parse(df["AMOUNT"].ToString());
                        mSaleOrderPromo.TST_AMOUNT = decimal.Parse(df["TST_AMOUNT"].ToString());
                        mSaleOrderPromo.SED_AMOUNT = 0;
                        mSaleOrderPromo.ExecuteQuery();
                    }

                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }



        public long Add_Order1(int p_Distributor_id, string p_MANUAL_ORDER_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, int p_OrderTypeId,
       decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT,decimal p_BRD, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int p_STATUS_ID, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, DateTime p_Document_Date, decimal p_SEDAmount, decimal p_TSTAmount,int p_Visit, int p_Productive_call, int p_Opening_reading, int p_Closing_Reading,int p_Bill_No_From, int p_Bill_No_To)
        {
            long  Sale_Order_ID = Constants.LongNullValue ;
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertSALE_ORDER_MASTER1 mISom = new spInsertSALE_ORDER_MASTER1();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.MANUAL_ORDER_ID = p_MANUAL_ORDER_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_Document_Date;
                    mISom.SHIP_TO = p_SHIP_TO;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.STATUS_ID = p_STATUS_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;
                    mISom.ORDER_TYPE_ID = p_OrderTypeId;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.BRD = p_BRD;
                    mISom .VISIT =p_Visit;
                    mISom .PRODUCTIVE_CALL =p_Productive_call;
                    mISom.OPENING_READING=p_Opening_reading;
                    mISom.CLOSING_READING=p_Closing_Reading;
                    mISom.BILL_NO_FROM=p_Bill_No_From;
                    mISom.BILL_NO_TO=p_Bill_No_To ;
                    mISom.ExecuteQuery();


                    //----------------Insert into sale order detail-------------
                  
                    spInsertSALE_ORDER_DETAIL1 mSaleOrderDetail = new spInsertSALE_ORDER_DETAIL1();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_ORDER_ID = mISom.SALE_ORDER_ID;

                        Sale_Order_ID = mISom.SALE_ORDER_ID;
                       
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["ISSUE_UNITS"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.RETURN_UNIT = int.Parse(dr["RETURN_UNITS"].ToString());
                        mSaleOrderDetail.EMPTY_UNIT = int.Parse(dr["RETURN_EMPTY_UNITS"].ToString());
                        mSaleOrderDetail.DAMAGE_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString());
                        mSaleOrderDetail.SCHEME_UNIT = int.Parse(dr["SCHEME_UNITS"].ToString());

                       // mSaleOrderDetail.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.GST_RATE = 0;
                       //mSaleOrderDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                        mSaleOrderDetail.AMOUNT = 0;
                      //mSaleOrderDetail.EXTRA_DISCOUNT = decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        mSaleOrderDetail.EXTRA_DISCOUNT = 0;
                      //mSaleOrderDetail.STANDARD_DISCOUNT = decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        mSaleOrderDetail.STANDARD_DISCOUNT = 0;
                        //mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.GST_AMOUNT = 0;
                       // mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = 0;
                     // mSaleOrderDetail.SED_AMOUNT = decimal.Parse(dr["SED_AMOUNT"].ToString());
                        
                        mSaleOrderDetail.SED_AMOUNT = 0;
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_Document_Date;
                        //TotalAmt += decimal.Parse(dr["AMOUNT"].ToString());
                        //ExtraDiscount += decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        //DiscountAmount += decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        //GSTAmount += decimal.Parse(dr["GST_AMOUNT"].ToString());
                        //TotalNetAmt += decimal.Parse(dr["NET_AMOUNT"].ToString());
                        TotalAmt += 0;
                        ExtraDiscount += 0;
                        DiscountAmount += 0;
                        GSTAmount += 0;
                        TotalNetAmt += decimal.Parse(dr["NET_VALUE"].ToString());



                        mSaleOrderDetail.ExecuteQuery();



                    }
                    //foreach (DataRow df in dtFreeSKU.Rows)
                    //{
                    //    //----------------Insert into sale order Promotion-------------
                    //    spInsertSALE_ORDER_PROMOTION mSaleOrderPromo = new spInsertSALE_ORDER_PROMOTION();
                    //    mSaleOrderPromo.Connection = mConnection;
                    //    mSaleOrderPromo.Transaction = mTransaction;

                    //    mSaleOrderPromo.BASKET_DETAIL_ID = int.Parse(df["BASKET_DETAIL_ID"].ToString());
                    //    mSaleOrderPromo.BASKET_ID = int.Parse(df["BASKET_ID"].ToString());
                    //    mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                    //    mSaleOrderPromo.GST_AMOUNT = decimal.Parse(df["GST_AMOUNT"].ToString());
                    //    mSaleOrderPromo.GST_RATE = float.Parse(df["GST_RATE"].ToString());
                    //    mSaleOrderPromo.PROMOTION_ID = int.Parse(df["PROMOTION_ID"].ToString());
                    //    mSaleOrderPromo.PROMOTION_OFFER_ID = int.Parse(df["PROMOTION_OFFER_ID"].ToString());
                    //    mSaleOrderPromo.QUANTITY = int.Parse(df["Quantity"].ToString());
                    //    mSaleOrderPromo.SKU_ID = int.Parse(df["SKU_ID"].ToString());
                    //    mSaleOrderPromo.UNIT_PRICE = decimal.Parse(df["UNIT_PRICE"].ToString());
                    //    mSaleOrderPromo.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                    //    mSaleOrderPromo.AMOUNT = decimal.Parse(df["AMOUNT"].ToString());
                    //    mSaleOrderPromo.TST_AMOUNT = decimal.Parse(df["TST_AMOUNT"].ToString());
                    //    mSaleOrderPromo.SED_AMOUNT = 0;
                    //    mSaleOrderPromo.ExecuteQuery();
                    //}

                    mTransaction.Commit();
                    return Sale_Order_ID ; 
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return Sale_Order_ID;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return Sale_Order_ID;
        }


        //long p_SALE_ORDER_ID ,int p_DISTRIBUTOR_ID, string p_MANUAL_ORDER_ID,int p_TOWN_ID,long p_AREA_ID ,int p_PRINCIPAL_ID,long p_SOLD_TO, long p_SHIP_TO,int p_ORDERBOOKER_ID,int p_DELIVERYMAN_ID ,int p_STATUS_ID, DateTime p_DOCUMENT_DATE, decimal p_TOTAL_AMOUNT,decimal p_EXTRA_DISCOUNT_AMOUNT,decimal p_STANDARD_DISCOUNT_AMOUNT ,decimal p_GST_AMOUNT ,decimal p_TOTAL_NET_AMOUN, decimal p_SCHEME_AMOUNT,decimal p_BRD ,DateTime p_TIME_STAMP ,DateTime p_LASTUPDATE_DATE ,long p_LEGEND_ID,long p_ORDER_TYPE_ID ,long p_USER_ID,decimal p_TST_AMOUNT, decimal p_SED_AMOUNT ,long p_VISIT ,long p_PRODUCTIVE_CALL,long p_OPENING_READING ,long p_CLOSING_READING,long p_BILL_NO_FROM,long p_BILL_NO_TO

        public bool Update_Order(long p_SALE_ORDER_ID,int p_Distributor_id, string p_MANUAL_ORDER_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_OrderTypeId,
       decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_BRD, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int p_STATUS_ID, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, DateTime p_Document_Date, decimal p_SEDAmount, decimal p_TSTAmount, int p_Visit, int p_Productive_call, int p_Opening_reading, int p_Closing_Reading, int p_Bill_No_From, int p_Bill_No_To)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                DeleteOrderDetail(p_SALE_ORDER_ID);
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                // the origional name of procedure is spUpdateSALE_ORDER_MASTER2
                spUpdateSALE_ORDER_MASTER02 mISom = new spUpdateSALE_ORDER_MASTER02();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.SALE_ORDER_ID = p_SALE_ORDER_ID;
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.MANUAL_ORDER_ID = p_MANUAL_ORDER_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_Document_Date;
                    mISom.SHIP_TO = p_SHIP_TO;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.STATUS_ID = p_STATUS_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;
                    mISom.ORDER_TYPE_ID = p_OrderTypeId;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.BRD = p_BRD;
                    mISom.VISIT = p_Visit;
                    mISom.PRODUCTIVE_CALL = p_Productive_call;
                    mISom.OPENING_READING = p_Opening_reading;
                    mISom.CLOSING_READING = p_Closing_Reading;
                    mISom.BILL_NO_FROM = p_Bill_No_From;
                    mISom.BILL_NO_TO = p_Bill_No_To;
                    mISom.ExecuteQuery();


                    //----------------DELETE sale order detail-------------

                    //spDeleteSALE_ORDER_DETAIL mSaleOrderDETAILDELETE = new spDeleteSALE_ORDER_DETAIL();
                    //mSaleOrderDETAILDELETE.Connection = mConnection;
                    //mSaleOrderDETAILDELETE.Transaction = mTransaction;
                    //mSaleOrderDETAILDELETE.SALE_ORDER_ID = p_SALE_ORDER_ID;
                    //mSaleOrderDETAILDELETE.SALE_ORDER_DETAIL_ID = Constants.IntNullValue;

                    //mSaleOrderDETAILDELETE.ExecuteQuery();

                    //----------------Insert into sale order detail-------------




                    spInsertSALE_ORDER_DETAIL1 mSaleOrderDetail = new spInsertSALE_ORDER_DETAIL1();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = "";
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["ISSUE_UNITS"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());

                        mSaleOrderDetail.RETURN_UNIT = int.Parse(dr["RETURN_UNITS"].ToString());
                        mSaleOrderDetail.EMPTY_UNIT = int.Parse(dr["RETURN_EMPTY_UNITS"].ToString());
                        mSaleOrderDetail.DAMAGE_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString());
                        mSaleOrderDetail.SCHEME_UNIT = int.Parse(dr["SCHEME_UNITS"].ToString());



                        // mSaleOrderDetail.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.GST_RATE = 0;
                        //mSaleOrderDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                        mSaleOrderDetail.AMOUNT = 0;
                        //mSaleOrderDetail.EXTRA_DISCOUNT = decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        mSaleOrderDetail.EXTRA_DISCOUNT = 0;
                        //mSaleOrderDetail.STANDARD_DISCOUNT = decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        mSaleOrderDetail.STANDARD_DISCOUNT = 0;
                        //mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.GST_AMOUNT = 0;
                        // mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = 0;
                        // mSaleOrderDetail.SED_AMOUNT = decimal.Parse(dr["SED_AMOUNT"].ToString());

                        mSaleOrderDetail.SED_AMOUNT = 0;
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_Document_Date;
                        //TotalAmt += decimal.Parse(dr["AMOUNT"].ToString());
                        //ExtraDiscount += decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        //DiscountAmount += decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        //GSTAmount += decimal.Parse(dr["GST_AMOUNT"].ToString());
                        //TotalNetAmt += decimal.Parse(dr["NET_AMOUNT"].ToString());
                        TotalAmt += 0;
                        ExtraDiscount += 0;
                        DiscountAmount += 0;
                        GSTAmount += 0;
                        TotalNetAmt += decimal.Parse(dr["NET_VALUE"].ToString());



                        mSaleOrderDetail.ExecuteQuery();

                    }

                    
                    //foreach (DataRow df in dtFreeSKU.Rows)
                    //{
                    //    //----------------Insert into sale order Promotion-------------
                    //    spInsertSALE_ORDER_PROMOTION mSaleOrderPromo = new spInsertSALE_ORDER_PROMOTION();
                    //    mSaleOrderPromo.Connection = mConnection;
                    //    mSaleOrderPromo.Transaction = mTransaction;

                    //    mSaleOrderPromo.BASKET_DETAIL_ID = int.Parse(df["BASKET_DETAIL_ID"].ToString());
                    //    mSaleOrderPromo.BASKET_ID = int.Parse(df["BASKET_ID"].ToString());
                    //    mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                    //    mSaleOrderPromo.GST_AMOUNT = decimal.Parse(df["GST_AMOUNT"].ToString());
                    //    mSaleOrderPromo.GST_RATE = float.Parse(df["GST_RATE"].ToString());
                    //    mSaleOrderPromo.PROMOTION_ID = int.Parse(df["PROMOTION_ID"].ToString());
                    //    mSaleOrderPromo.PROMOTION_OFFER_ID = int.Parse(df["PROMOTION_OFFER_ID"].ToString());
                    //    mSaleOrderPromo.QUANTITY = int.Parse(df["Quantity"].ToString());
                    //    mSaleOrderPromo.SKU_ID = int.Parse(df["SKU_ID"].ToString());
                    //    mSaleOrderPromo.UNIT_PRICE = decimal.Parse(df["UNIT_PRICE"].ToString());
                    //    mSaleOrderPromo.SALE_ORDER_ID = mISom.SALE_ORDER_ID;
                    //    mSaleOrderPromo.AMOUNT = decimal.Parse(df["AMOUNT"].ToString());
                    //    mSaleOrderPromo.TST_AMOUNT = decimal.Parse(df["TST_AMOUNT"].ToString());
                    //    mSaleOrderPromo.SED_AMOUNT = 0;
                    //    mSaleOrderPromo.ExecuteQuery();
                    //}
            }

                    mTransaction.Commit();
                    return true;
                }
            
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }
      


        /// <summary>
        /// Inserts Invoice
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_MANUAL_INVOICE_ID">ManualInvoice</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_SOLD_TO">Customer</param>
        /// <param name="p_SHIP_TO">ShipTo</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Orderid">Order</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_EXTRA_DISCOUNT_AMOUNT">ExtraDiscount</param>
        /// <param name="p_STANDARD_DISCOUNT_AMOUNT">Discount</param>
        /// <param name="p_GST_AMOUNT">GST</param>
        /// <param name="p_TOTAL_NET_AMOUNT">NetAmount</param>
        /// <param name="p_SCHEME_AMOUNT">SchemeAmount</param>
        /// <param name="InvoiceTypeId">Type</param>
        /// <param name="dtOrderDetail">OrderDetailDatatable</param>
        /// <param name="dtFreeSKU">FreeSKUDatatable</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_CashReceived">Cash</param>
        /// <param name="p_DocumentDate">Date</param>
        /// <param name="p_TSTAmount">TSTAmount</param>
        /// <param name="p_SEDAmount">SEDAmount</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Add_Invoice(int p_Distributor_id,string p_MANUAL_INVOICE_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long  p_Orderid,
         decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId,decimal p_CashReceived,DateTime p_DocumentDate,decimal p_TSTAmount,decimal p_SEDAmount)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertSALE_INVOICE_MASTER mISom = new spInsertSALE_INVOICE_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.MANUAL_INVOICE_ID = p_MANUAL_INVOICE_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_DocumentDate;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.IS_DELETED = false;  
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    if (InvoiceTypeId == Constants.Credit_Order_Id)
                    {
                        mISom.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                        mISom.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                    }
                    else
                    {
                        mISom.CREDIT_AMOUNT = 0;
                        mISom.CURRENT_CREDIT_AMOUNT = 0;
                    }
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.SALE_ORDER_ID  = p_Orderid;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;  
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.IS_DELETED = false;
                    mISom.POSTING = 0; 
                    mISom.ExecuteQuery();

                    //------------------Ledger Posting--------------------------\\

                     

                    //----------------Insert into sale order detail-------------
                    spInsertSALE_INVOICE_DETAIL mSaleOrderDetail = new spInsertSALE_INVOICE_DETAIL();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_INVOICE_ID  = mISom.SALE_INVOICE_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO  = dr["BATCH_NO"].ToString(); 
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["QUANTITY"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                        mSaleOrderDetail.EXTRA_DISCOUNT = decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        mSaleOrderDetail.STANDARD_DISCOUNT = decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = decimal.Parse(dr["SED_AMOUNT"].ToString()); 
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_DocumentDate;
                        TotalAmt += decimal.Parse(dr["AMOUNT"].ToString());
                        ExtraDiscount += decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        DiscountAmount += decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        GSTAmount += decimal.Parse(dr["GST_AMOUNT"].ToString());
                        TotalNetAmt += decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.ExecuteQuery();

                        UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                        mStockUpdate.Connection = mConnection;
                        mStockUpdate.Transaction = mTransaction;
                        mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                        mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        mStockUpdate.STOCK_DATE = p_DocumentDate;
                        mStockUpdate.SKU_ID = mSaleOrderDetail.SKU_ID;
                        mStockUpdate.BATCHNO = mSaleOrderDetail.BATCH_NO;
                        mStockUpdate.STOCK_QTY = mSaleOrderDetail.QUANTITY_UNIT;
                        mStockUpdate.FREE_QTY = 0;
                        mStockUpdate.ExecuteQuery(); 

                       

                    }
                    foreach (DataRow df in dtFreeSKU.Rows)
                    {
                        //----------------Insert into sale order Promotion-------------
                        spInsertSALE_INVOICE_PROMOTION mSaleOrderPromo = new spInsertSALE_INVOICE_PROMOTION();
                        mSaleOrderPromo.Connection = mConnection;
                        mSaleOrderPromo.Transaction = mTransaction;

                        mSaleOrderPromo.BASKET_DETAIL_ID = int.Parse(df["BASKET_DETAIL_ID"].ToString());
                        mSaleOrderPromo.BASKET_ID = int.Parse(df["BASKET_ID"].ToString());
                        mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderPromo.GST_AMOUNT = decimal.Parse(df["GST_AMOUNT"].ToString());
                        mSaleOrderPromo.GST_RATE = float.Parse(df["GST_RATE"].ToString());
                        mSaleOrderPromo.PROMOTION_ID = int.Parse(df["PROMOTION_ID"].ToString());
                        mSaleOrderPromo.PROMOTION_OFFER_ID = int.Parse(df["PROMOTION_OFFER_ID"].ToString());
                        mSaleOrderPromo.QUANTITY = int.Parse(df["Quantity"].ToString());
                        mSaleOrderPromo.SKU_ID = int.Parse(df["SKU_ID"].ToString());
                        mSaleOrderPromo.UNIT_PRICE = decimal.Parse(df["UNIT_PRICE"].ToString());
                        mSaleOrderPromo.TST_AMOUNT = decimal.Parse(df["TST_AMOUNT"].ToString());
                        mSaleOrderPromo.SED_AMOUNT = 0; 
                        mSaleOrderPromo.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        mSaleOrderPromo.AMOUNT = decimal.Parse(df["AMOUNT"].ToString());
                        mSaleOrderPromo.ExecuteQuery();

                        UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                        mStockUpdate.Connection = mConnection;
                        mStockUpdate.Transaction = mTransaction;
                        mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                        mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        mStockUpdate.STOCK_DATE = p_DocumentDate;
                        mStockUpdate.SKU_ID = mSaleOrderPromo.SKU_ID;
                        mStockUpdate.BATCHNO = "N/A"; 
                        mStockUpdate.STOCK_QTY = 0;
                        mStockUpdate.FREE_QTY = mSaleOrderPromo.QUANTITY; 
                        mStockUpdate.ExecuteQuery(); 
                    }

                    #region Account Posting
                    LedgerController LController = new LedgerController();
                    Configuration.GetAccountHead();
                    DistributorController  Dcontroller = new DistributorController();
                   
                    
                    string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);

                    if (InvoiceTypeId == Constants.Advance_PaymentOrder_id)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_AMOUNT, mISom.DOCUMENT_DATE, "Gross Sale Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID,mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                        if (p_STANDARD_DISCOUNT_AMOUNT > 0)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleDiscount), p_Distributor_id, p_STANDARD_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Commision/Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                        }
                        if (p_EXTRA_DISCOUNT_AMOUNT > 0)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleScheme), p_Distributor_id, p_EXTRA_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                        }
                        if (p_GST_AMOUNT + p_TSTAmount > 0)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.GSTAccount), p_Distributor_id, 0, p_GST_AMOUNT + p_TSTAmount, mISom.DOCUMENT_DATE, "Sales Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                        }
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                    }
                    else if (InvoiceTypeId == Constants.Credit_Order_Id)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT - p_CashReceived, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT - p_CashReceived, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());
                        
                    }
                    #endregion

                    #region Update Pending Order

                    spUpdateSALE_ORDER_MASTER mOrderUpdate = new spUpdateSALE_ORDER_MASTER();
                    mOrderUpdate.Connection = mConnection;
                    mOrderUpdate.Transaction = mTransaction;
                    mOrderUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                    mOrderUpdate.SALE_ORDER_ID = p_Orderid;
                    mOrderUpdate.STATUS_ID = Constants.Order_Posted_Id;
                    mOrderUpdate.ExecuteQuery();
                    
                    #endregion

                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }


        // by safdar to use in load pass entry from
        public bool Add_Invoice1(int p_Distributor_id, string p_MANUAL_INVOICE_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Sale_Order_ID,
         decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_BRD, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, decimal p_CashReceived, DateTime p_DocumentDate, decimal p_SEDAmount, decimal p_TSTAmount, int p_Visit, int p_Productive_call, int p_Opening_reading, int p_Closing_Reading, int p_Bill_No_From, int p_Bill_No_To, decimal p_Fuel, decimal p_Whole_sale_discount, decimal p_Total_damage_value, bool IsDamage ,decimal p_Total_Actual_Damage)
        {
            //by safdar to use in Load pass form
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                       
                    #region insert sale invoice master
                spInsertSALE_INVOICE_MASTER3 mISom = new spInsertSALE_INVOICE_MASTER3();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale invoice Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.MANUAL_INVOICE_ID = p_MANUAL_INVOICE_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_DocumentDate;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.FUEL = p_Fuel;
                    mISom.WHOLE_SALE_DOSCOINT = p_Whole_sale_discount;
                    mISom.IS_DELETED = false;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    if (InvoiceTypeId == Constants.Credit_Order_Id)
                    {
                        mISom.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                        mISom.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                    }
                    else
                    {
                        mISom.CREDIT_AMOUNT = 0;
                        mISom.CURRENT_CREDIT_AMOUNT = 0;
                    }
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.SALE_ORDER_ID = p_Sale_Order_ID;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;
                    mISom.BRD = p_BRD;
                    mISom.VISIT = p_Visit;
                    mISom.PRODUCTIVE_CALL = p_Productive_call;
                    mISom.OPENING_READING = p_Opening_reading;
                    mISom.CLOSING_READING = p_Closing_Reading;
                    mISom.BILL_NO_FROM = p_Bill_No_From;
                    mISom.BILL_NO_TO = p_Bill_No_To;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.IS_DELETED = false;
                    mISom.POSTING = 0;
                    mISom.ExecuteQuery();
                #endregion
                       
                    #region Insert Damage Unit in Sale Return
                    spInsertSALES_RETURN_MASTER mISonRetun = new spInsertSALES_RETURN_MASTER();
                        mISonRetun.Connection = mConnection;
                        mISonRetun.Transaction = mTransaction;

                        //------------Insert into Sale Return Master----------

                        if (dtOrderDetail.Rows.Count > 0)
                        {
                            mISonRetun.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                            mISonRetun.DISTRIBUTOR_ID = p_Distributor_id;
                            mISonRetun.PRINCIPAL_ID = p_PRINCIPAL_ID;
                            mISonRetun.AREA_ID = int.Parse(p_AREA_ID.ToString());
                            mISonRetun.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                            mISonRetun.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                            mISonRetun.DOCUMENT_DATE = p_DocumentDate;
                            mISonRetun.CUSTOMER_ID = p_SOLD_TO;
                            mISonRetun.TOTAL_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                            mISonRetun.EXTRA_DISCOUNT_AMOUNT = 0;
                            mISonRetun.STANDARD_DISCOUNT_AMOUNT = 0;
                            mISonRetun.GST_AMOUNT = 0;
                            mISonRetun.TOTAL_NET_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                            mISonRetun.TOWN_ID = p_TOWN_ID;
                            mISonRetun.TIME_STAMP = DateTime.Now;
                            mISonRetun.LASTUPDATE_DATE = System.DateTime.Now;
                            mISonRetun.TST_AMOUNT = 0;
                            mISonRetun.SED_AMOUNT = 0;
                            mISonRetun.IS_DELETED = false;
                            mISonRetun.POSTING = 0;
                            mISonRetun.ExecuteQuery();

                            //----------------Insert into sales return detail-------------
                            spInsertSALES_RETURN_DETAIL mSaleReturnDetail = new spInsertSALES_RETURN_DETAIL();
                            mSaleReturnDetail.Connection = mConnection;
                            mSaleReturnDetail.Transaction = mTransaction;

                            foreach (DataRow dr in dtOrderDetail.Rows)
                            {
                                mSaleReturnDetail.SALES_RETURN_ID = mISonRetun.SALES_RETURN_ID;
                                mSaleReturnDetail.DISTRIBUTOR_ID = p_Distributor_id;
                                mSaleReturnDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                                mSaleReturnDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                                mSaleReturnDetail.QUANTITY_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString()) + int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                                mSaleReturnDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                                mSaleReturnDetail.GST_RATE = 0;
                                mSaleReturnDetail.AMOUNT = ((decimal.Parse(dr["DAMAGE_UNITS"].ToString()) + decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString())) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                                mSaleReturnDetail.EXTRA_DISCOUNT = 0;
                                mSaleReturnDetail.STANDARD_DISCOUNT = 0;
                                mSaleReturnDetail.GST_AMOUNT = 0;
                                mSaleReturnDetail.TST_AMOUNT = 0;
                                mSaleReturnDetail.SED_AMOUNT = 0;
                                mSaleReturnDetail.NET_AMOUNT = 0;
                                mSaleReturnDetail.TIME_STAMP = p_DocumentDate;
                                mSaleReturnDetail.ExecuteQuery();

                            }
                        }
                   
                    #endregion
 
                    #region Insert Actual Damage Unit in Sale Return
                        //spInsertSALES_RETURN_MASTER mISonDamage = new spInsertSALES_RETURN_MASTER();
                        //mISonDamage.Connection = mConnection;
                        //mISonDamage.Transaction = mTransaction;

                        ////------------Insert into Sale Return Master----------

                        //if (dtOrderDetail.Rows.Count > 0)
                        //{
                        //    mISonDamage.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        //    mISonDamage.DISTRIBUTOR_ID = p_Distributor_id;
                        //    mISonDamage.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        //    mISonDamage.AREA_ID = int.Parse(p_AREA_ID.ToString());
                        //    mISonDamage.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                        //    mISonDamage.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                        //    mISonDamage.DOCUMENT_DATE = p_DocumentDate;
                        //    mISonDamage.CUSTOMER_ID = p_SOLD_TO;
                        //    mISonDamage.TOTAL_AMOUNT = p_Total_Actual_Damage;
                        //    mISonDamage.EXTRA_DISCOUNT_AMOUNT = 0;
                        //    mISonDamage.STANDARD_DISCOUNT_AMOUNT = 0;
                        //    mISonDamage.GST_AMOUNT = 0;
                        //    mISonDamage.TOTAL_NET_AMOUNT = p_Total_Actual_Damage;
                        //    mISonDamage.TOWN_ID = p_TOWN_ID;
                        //    mISonDamage.TIME_STAMP = DateTime.Now;
                        //    mISonDamage.LASTUPDATE_DATE = System.DateTime.Now;
                        //    mISonDamage.TST_AMOUNT = 0;
                        //    mISonDamage.SED_AMOUNT = 0;
                        //    mISonDamage.IS_DELETED = false;
                        //    mISonDamage.POSTING = 0;
                        //    mISonRetun.ExecuteQuery();

                        //    //----------------Insert into sales return detail-------------
                        //    spInsertSALES_RETURN_DETAIL mSaleDamage = new spInsertSALES_RETURN_DETAIL();
                        //    mSaleDamage.Connection = mConnection;
                        //    mSaleDamage.Transaction = mTransaction;

                        //    foreach (DataRow dr in dtOrderDetail.Rows)
                        //    {
                        //        mSaleDamage.SALES_RETURN_ID = mISonDamage.SALES_RETURN_ID;
                        //        mSaleDamage.DISTRIBUTOR_ID = p_Distributor_id;
                        //        mSaleDamage.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        //        mSaleDamage.BATCH_NO = dr["BATCH_NO"].ToString();
                        //        mSaleDamage.QUANTITY_UNIT = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                        //        mSaleDamage.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        //        mSaleDamage.GST_RATE = 0;
                        //        mSaleDamage.AMOUNT = (decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                        //        mSaleDamage.EXTRA_DISCOUNT = 0;
                        //        mSaleDamage.STANDARD_DISCOUNT = 0;
                        //        mSaleDamage.GST_AMOUNT = 0;
                        //        mSaleDamage.TST_AMOUNT = 0;
                        //        mSaleDamage.SED_AMOUNT = 0;
                        //        mSaleDamage.NET_AMOUNT = 0;
                        //        mSaleDamage.TIME_STAMP = p_DocumentDate;
                        //        mSaleDamage.ExecuteQuery();

                        //    }
                      //  }

                        #endregion
 
                    #region Insert Actual Damage in Purchase Master Detail
                        
                        spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                        mPurchaseMaster.Connection = mConnection;
                        mPurchaseMaster.Transaction = mTransaction;
                        mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_id;
                        mPurchaseMaster.TYPE_ID = 10;// Damage Return
                        mPurchaseMaster.ORDER_NUMBER = mISom.SALE_INVOICE_ID.ToString();
                        mPurchaseMaster.SOLD_FROM = p_PRINCIPAL_ID;
                        mPurchaseMaster.DOCUMENT_DATE = p_DocumentDate;
                        mPurchaseMaster.SOLD_TO = p_Distributor_id  ;
                        mPurchaseMaster.TOTAL_AMOUNT = p_Total_Actual_Damage;
                        mPurchaseMaster.USER_ID = p_UserId;
                        mPurchaseMaster.TIME_STAMP = DateTime.Now;
                        mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                        mPurchaseMaster.POSTING = 0;
                        mPurchaseMaster.BUILTY_NO = "";
                        mPurchaseMaster.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mPurchaseMaster.DAMAGE_TYPE = 0;// Market Damage
                        mPurchaseMaster.DOCUMENT_ID = mISom.SALE_INVOICE_ID;
                        mPurchaseMaster.ExecuteQuery();

                        spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                        mPurchaseDetail.Connection = mConnection;
                        mPurchaseDetail.Transaction = mTransaction;

                        foreach (DataRow dr in dtOrderDetail.Rows)
                        {
                            mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                            mPurchaseDetail.DISTRIBUTOR_ID = p_Distributor_id;
                            mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                            mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                            mPurchaseDetail.PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                            mPurchaseDetail.QUANTITY = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                            mPurchaseDetail.FREE_SKU = 0;
                            mPurchaseDetail.AMOUNT = (decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                            mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                            mPurchaseDetail.TIME_STAMP = p_DocumentDate;
                            mPurchaseDetail.TDAMAGE = 0;
                            mPurchaseDetail.ExecuteQuery();

                            UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                            mStockUpdate.Connection = mConnection;
                            mStockUpdate.Transaction = mTransaction;
                            mStockUpdate.PRINCIPAL_ID = p_PRINCIPAL_ID;
                            mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                            mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                            mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                            mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                            mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                            mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                            mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                            mStockUpdate.ExecuteQuery();
                        }

                        #endregion

                    #region insert sale invoice detail


                        ////----------------Insert into sale order detail-------------
                    spInsertSALE_INVOICE_DETAIL2 mSaleOrderDetail = new spInsertSALE_INVOICE_DETAIL2();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                        mSaleOrderDetail.ISSUE_UNIT = int.Parse(dr["ISSUE_UNITS"].ToString()) + int.Parse(dr["ISSUE_CTN"].ToString()) * int.Parse(dr["UNITS_IN_CASE"].ToString());
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["GROSS_UNITS"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.RETURN_UNIT = int.Parse(dr["RETURN_UNITS"].ToString()) + int.Parse(dr["RETURN_CTN"].ToString()) * int.Parse(dr["UNITS_IN_CASE"].ToString());
                        mSaleOrderDetail.EMPTY_RETURN_UNIT = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());// Use as DAmage instead of Empty Return
                        mSaleOrderDetail.DAMAGE_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString());
                        mSaleOrderDetail.SCHEME_UNIT = int.Parse(dr["SCHEME_UNITS"].ToString());
                        mSaleOrderDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT= mSaleOrderDetail.QUANTITY_UNIT *   mSaleOrderDetail.UNIT_PRICE ;
                        mSaleOrderDetail.EXTRA_DISCOUNT = 0;
                        mSaleOrderDetail.STANDARD_DISCOUNT = 0;
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = 0; 
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_DocumentDate;
                        TotalAmt += 0;
                        ExtraDiscount += 0;
                        DiscountAmount += 0;
                        GSTAmount += 0;
                        TotalNetAmt += decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.ExecuteQuery();

                    #endregion
                       
                    #region insert sale_invoice_Promotion

                      
                            //----------------Insert into sale order Promotion-------------

                            decimal x = decimal.Parse(dr["SCHEME_UNITS"].ToString());
                            decimal y = decimal.Parse(dr["UNIT_PRICE"].ToString());

                            spInsertSALE_INVOICE_PROMOTION2 mSaleOrderPromo = new spInsertSALE_INVOICE_PROMOTION2();
                            mSaleOrderPromo.Connection = mConnection;
                            mSaleOrderPromo.Transaction = mTransaction;
                            mSaleOrderPromo.BASKET_DETAIL_ID = -1;
                            mSaleOrderPromo.BASKET_ID = -1;
                            mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                            mSaleOrderPromo.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                            mSaleOrderPromo.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                            mSaleOrderPromo.PROMOTION_ID = -1;
                            mSaleOrderPromo.PROMOTION_OFFER_ID = -1;
                            mSaleOrderPromo.QUANTITY = int.Parse(dr["SCHEME_UNITS"].ToString());
                            mSaleOrderPromo.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                            mSaleOrderPromo.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                            mSaleOrderPromo.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                            mSaleOrderPromo.AMOUNT = x * y;
                            mSaleOrderPromo.SED_AMOUNT = 0;
                            mSaleOrderPromo.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                            mSaleOrderPromo.ExecuteQuery();

                            #region Update Sku_Stock_register
                            UspProcessStockRegister mStockFree = new UspProcessStockRegister();
                            mStockFree.Connection = mConnection;
                            mStockFree.Transaction = mTransaction;
                            mStockFree.TYPE_ID = Constants.Document_Transfer_Out;
                            mStockFree.DISTRIBUTOR_ID = p_Distributor_id;
                            mStockFree.STOCK_DATE = p_DocumentDate;
                            mStockFree.SKU_ID = mSaleOrderDetail.SKU_ID;
                            mStockFree.BATCHNO = mSaleOrderDetail.BATCH_NO;
                            mStockFree.STOCK_QTY = 0;   // Quantity_unit = Gross unit ,
                            mStockFree.FREE_QTY = mSaleOrderDetail.SCHEME_UNIT;
                            mStockFree.ExecuteQuery();
                            #endregion
                      

                        #endregion

                    #region Update Sku_Stock_register
                        UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                        mStockUpdate.Connection = mConnection;
                        mStockUpdate.Transaction = mTransaction;
                        mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                        mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        mStockUpdate.STOCK_DATE = p_DocumentDate;
                        mStockUpdate.SKU_ID = mSaleOrderDetail.SKU_ID;
                        mStockUpdate.BATCHNO = mSaleOrderDetail.BATCH_NO;
                        mStockUpdate.STOCK_QTY = mSaleOrderDetail.QUANTITY_UNIT ;
                        mStockUpdate.FREE_QTY = 0;
                        mStockUpdate.ExecuteQuery();
                        #endregion

                    #region Account Posting
                        LedgerController LController = new LedgerController();
                        Configuration.GetAccountHead();
                        DistributorController Dcontroller = new DistributorController();


                        string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);

                        if (InvoiceTypeId == Constants.Advance_PaymentOrder_id)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_AMOUNT, mISom.DOCUMENT_DATE, "Gross Sale Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                            if (p_STANDARD_DISCOUNT_AMOUNT > 0)
                            {
                                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleDiscount), p_Distributor_id, p_STANDARD_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Commision/Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                            }
                            if (p_EXTRA_DISCOUNT_AMOUNT > 0)
                            {
                                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleScheme), p_Distributor_id, p_EXTRA_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                            }
                            if (p_GST_AMOUNT + p_TSTAmount > 0)
                            {
                                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.GSTAccount), p_Distributor_id, 0, p_GST_AMOUNT + p_TSTAmount, mISom.DOCUMENT_DATE, "Sales Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                            }
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                        }
                        else if (InvoiceTypeId == Constants.Credit_Order_Id)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT - p_CashReceived, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT - p_CashReceived, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());

                        }
                        #endregion

                    #region Update Pending Order

                        //spUpdateSALE_ORDER_MASTER mOrderUpdate = new spUpdateSALE_ORDER_MASTER();
                        //mOrderUpdate.Connection = mConnection;
                        //mOrderUpdate.Transaction = mTransaction;
                        //mOrderUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        //mOrderUpdate.SALE_ORDER_ID = p_Orderid;
                        //mOrderUpdate.STATUS_ID = Constants.Order_Posted_Id;
                        //mOrderUpdate.ExecuteQuery();

                       #endregion

                       
                    }
                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }


        public bool Add_Invoice1(int p_Distributor_id, string p_MANUAL_INVOICE_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Sale_Order_ID,
       decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_BRD, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, decimal p_CashReceived, DateTime p_DocumentDate, decimal p_SEDAmount, decimal p_TSTAmount, int p_Visit, int p_Productive_call, int p_Opening_reading, int p_Closing_Reading, int p_Bill_No_From, int p_Bill_No_To, decimal p_Fuel, decimal p_Whole_sale_discount, decimal p_Total_damage_value, bool IsDamage, decimal p_Total_Actual_Damage,decimal p_incentive, decimal p_Rental,decimal p_Display)
        {
            //by safdar to use in Load pass form
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                #region insert sale invoice master
                spInsertSALE_INVOICE_MASTER3 mISom = new spInsertSALE_INVOICE_MASTER3();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale invoice Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.MANUAL_INVOICE_ID = p_MANUAL_INVOICE_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_DocumentDate;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.FUEL = p_Fuel;
                    mISom.WHOLE_SALE_DOSCOINT = p_Whole_sale_discount;
                    mISom.IS_DELETED = false;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    if (InvoiceTypeId == Constants.Credit_Order_Id)
                    {
                        mISom.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                        mISom.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                    }
                    else
                    {
                        mISom.CREDIT_AMOUNT = 0;
                        mISom.CURRENT_CREDIT_AMOUNT = 0;
                    }
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.SALE_ORDER_ID = p_Sale_Order_ID;
                    mISom.TST_AMOUNT = p_TSTAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;
                    mISom.BRD = p_BRD;
                    mISom.VISIT = p_Visit;
                    mISom.PRODUCTIVE_CALL = p_Productive_call;
                    mISom.OPENING_READING = p_Opening_reading;
                    mISom.CLOSING_READING = p_Closing_Reading;
                    mISom.BILL_NO_FROM = p_Bill_No_From;
                    mISom.BILL_NO_TO = p_Bill_No_To;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.IS_DELETED = false;
                    mISom.POSTING = 0;
                    mISom.INCENTIVE = p_incentive;
                    mISom.RENTAL = p_Rental;
                    mISom.DISPLAY = p_Display;
                    mISom.ExecuteQuery();
                    #endregion

                    #region Insert Damage Unit in Sale Return
                    spInsertSALES_RETURN_MASTER mISonRetun = new spInsertSALES_RETURN_MASTER();
                    mISonRetun.Connection = mConnection;
                    mISonRetun.Transaction = mTransaction;

                    //------------Insert into Sale Return Master----------

                    if (dtOrderDetail.Rows.Count > 0)
                    {
                        mISonRetun.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        mISonRetun.DISTRIBUTOR_ID = p_Distributor_id;
                        mISonRetun.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mISonRetun.AREA_ID = int.Parse(p_AREA_ID.ToString());
                        mISonRetun.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                        mISonRetun.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                        mISonRetun.DOCUMENT_DATE = p_DocumentDate;
                        mISonRetun.CUSTOMER_ID = p_SOLD_TO;
                        mISonRetun.TOTAL_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                        mISonRetun.EXTRA_DISCOUNT_AMOUNT = 0;
                        mISonRetun.STANDARD_DISCOUNT_AMOUNT = 0;
                        mISonRetun.GST_AMOUNT = 0;
                        mISonRetun.TOTAL_NET_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                        mISonRetun.TOWN_ID = p_TOWN_ID;
                        mISonRetun.TIME_STAMP = DateTime.Now;
                        mISonRetun.LASTUPDATE_DATE = System.DateTime.Now;
                        mISonRetun.TST_AMOUNT = 0;
                        mISonRetun.SED_AMOUNT = 0;
                        mISonRetun.IS_DELETED = false;
                        mISonRetun.POSTING = 0;
                        mISonRetun.ExecuteQuery();

                        //----------------Insert into sales return detail-------------
                        spInsertSALES_RETURN_DETAIL mSaleReturnDetail = new spInsertSALES_RETURN_DETAIL();
                        mSaleReturnDetail.Connection = mConnection;
                        mSaleReturnDetail.Transaction = mTransaction;

                        foreach (DataRow dr in dtOrderDetail.Rows)
                        {
                            mSaleReturnDetail.SALES_RETURN_ID = mISonRetun.SALES_RETURN_ID;
                            mSaleReturnDetail.DISTRIBUTOR_ID = p_Distributor_id;
                            mSaleReturnDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                            mSaleReturnDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                            mSaleReturnDetail.QUANTITY_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString()) + int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                            mSaleReturnDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                            mSaleReturnDetail.GST_RATE = 0;
                            mSaleReturnDetail.AMOUNT = ((decimal.Parse(dr["DAMAGE_UNITS"].ToString()) + decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString())) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                            mSaleReturnDetail.EXTRA_DISCOUNT = 0;
                            mSaleReturnDetail.STANDARD_DISCOUNT = 0;
                            mSaleReturnDetail.GST_AMOUNT = 0;
                            mSaleReturnDetail.TST_AMOUNT = 0;
                            mSaleReturnDetail.SED_AMOUNT = 0;
                            mSaleReturnDetail.NET_AMOUNT = 0;
                            mSaleReturnDetail.TIME_STAMP = p_DocumentDate;
                            mSaleReturnDetail.ExecuteQuery();

                        }
                    }

                    #endregion

                    #region Insert Actual Damage Unit in Sale Return
                    //spInsertSALES_RETURN_MASTER mISonDamage = new spInsertSALES_RETURN_MASTER();
                    //mISonDamage.Connection = mConnection;
                    //mISonDamage.Transaction = mTransaction;

                    ////------------Insert into Sale Return Master----------

                    //if (dtOrderDetail.Rows.Count > 0)
                    //{
                    //    mISonDamage.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                    //    mISonDamage.DISTRIBUTOR_ID = p_Distributor_id;
                    //    mISonDamage.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    //    mISonDamage.AREA_ID = int.Parse(p_AREA_ID.ToString());
                    //    mISonDamage.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    //    mISonDamage.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    //    mISonDamage.DOCUMENT_DATE = p_DocumentDate;
                    //    mISonDamage.CUSTOMER_ID = p_SOLD_TO;
                    //    mISonDamage.TOTAL_AMOUNT = p_Total_Actual_Damage;
                    //    mISonDamage.EXTRA_DISCOUNT_AMOUNT = 0;
                    //    mISonDamage.STANDARD_DISCOUNT_AMOUNT = 0;
                    //    mISonDamage.GST_AMOUNT = 0;
                    //    mISonDamage.TOTAL_NET_AMOUNT = p_Total_Actual_Damage;
                    //    mISonDamage.TOWN_ID = p_TOWN_ID;
                    //    mISonDamage.TIME_STAMP = DateTime.Now;
                    //    mISonDamage.LASTUPDATE_DATE = System.DateTime.Now;
                    //    mISonDamage.TST_AMOUNT = 0;
                    //    mISonDamage.SED_AMOUNT = 0;
                    //    mISonDamage.IS_DELETED = false;
                    //    mISonDamage.POSTING = 0;
                    //    mISonRetun.ExecuteQuery();

                    //    //----------------Insert into sales return detail-------------
                    //    spInsertSALES_RETURN_DETAIL mSaleDamage = new spInsertSALES_RETURN_DETAIL();
                    //    mSaleDamage.Connection = mConnection;
                    //    mSaleDamage.Transaction = mTransaction;

                    //    foreach (DataRow dr in dtOrderDetail.Rows)
                    //    {
                    //        mSaleDamage.SALES_RETURN_ID = mISonDamage.SALES_RETURN_ID;
                    //        mSaleDamage.DISTRIBUTOR_ID = p_Distributor_id;
                    //        mSaleDamage.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    //        mSaleDamage.BATCH_NO = dr["BATCH_NO"].ToString();
                    //        mSaleDamage.QUANTITY_UNIT = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                    //        mSaleDamage.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                    //        mSaleDamage.GST_RATE = 0;
                    //        mSaleDamage.AMOUNT = (decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                    //        mSaleDamage.EXTRA_DISCOUNT = 0;
                    //        mSaleDamage.STANDARD_DISCOUNT = 0;
                    //        mSaleDamage.GST_AMOUNT = 0;
                    //        mSaleDamage.TST_AMOUNT = 0;
                    //        mSaleDamage.SED_AMOUNT = 0;
                    //        mSaleDamage.NET_AMOUNT = 0;
                    //        mSaleDamage.TIME_STAMP = p_DocumentDate;
                    //        mSaleDamage.ExecuteQuery();

                    //    }
                    //  }

                    #endregion

                    #region Insert Actual Damage in Purchase Master Detail

                    spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                    mPurchaseMaster.Connection = mConnection;
                    mPurchaseMaster.Transaction = mTransaction;
                    mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_id;
                    mPurchaseMaster.TYPE_ID = 10;// Damage Return
                    mPurchaseMaster.ORDER_NUMBER = mISom.SALE_INVOICE_ID.ToString();
                    mPurchaseMaster.SOLD_FROM = p_PRINCIPAL_ID;
                    mPurchaseMaster.DOCUMENT_DATE = p_DocumentDate;
                    mPurchaseMaster.SOLD_TO = p_Distributor_id;
                    mPurchaseMaster.TOTAL_AMOUNT = p_Total_Actual_Damage;
                    mPurchaseMaster.USER_ID = p_UserId;
                    mPurchaseMaster.TIME_STAMP = DateTime.Now;
                    mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                    mPurchaseMaster.POSTING = 0;
                    mPurchaseMaster.BUILTY_NO = "";
                    mPurchaseMaster.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mPurchaseMaster.DAMAGE_TYPE = 0;// Market Damage
                    mPurchaseMaster.DOCUMENT_ID = mISom.SALE_INVOICE_ID;
                    mPurchaseMaster.ExecuteQuery();

                    spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                    mPurchaseDetail.Connection = mConnection;
                    mPurchaseDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                        mPurchaseDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                        mPurchaseDetail.PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mPurchaseDetail.QUANTITY = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                        mPurchaseDetail.FREE_SKU = 0;
                        mPurchaseDetail.AMOUNT = (decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                        mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                        mPurchaseDetail.TIME_STAMP = p_DocumentDate;
                        mPurchaseDetail.TDAMAGE = 0;
                        mPurchaseDetail.ExecuteQuery();

                        UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                        mStockUpdate.Connection = mConnection;
                        mStockUpdate.Transaction = mTransaction;
                        mStockUpdate.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                        mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                        mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                        mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                        mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                        mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                        mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                        mStockUpdate.ExecuteQuery();
                    }

                    #endregion

                    #region insert sale invoice detail


                    ////----------------Insert into sale order detail-------------
                    spInsertSALE_INVOICE_DETAIL2 mSaleOrderDetail = new spInsertSALE_INVOICE_DETAIL2();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                        mSaleOrderDetail.ISSUE_UNIT = int.Parse(dr["ISSUE_UNITS"].ToString()) + int.Parse(dr["ISSUE_CTN"].ToString()) * int.Parse(dr["UNITS_IN_CASE"].ToString());
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["GROSS_UNITS"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.RETURN_UNIT = int.Parse(dr["RETURN_UNITS"].ToString()) + int.Parse(dr["RETURN_CTN"].ToString()) * int.Parse(dr["UNITS_IN_CASE"].ToString());
                        mSaleOrderDetail.EMPTY_RETURN_UNIT = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());// Use as DAmage instead of Empty Return
                        mSaleOrderDetail.DAMAGE_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString());
                        mSaleOrderDetail.SCHEME_UNIT = int.Parse(dr["SCHEME_UNITS"].ToString());
                        mSaleOrderDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT = mSaleOrderDetail.QUANTITY_UNIT * mSaleOrderDetail.UNIT_PRICE;
                        mSaleOrderDetail.EXTRA_DISCOUNT = 0;
                        mSaleOrderDetail.STANDARD_DISCOUNT = 0;
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = 0;
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_DocumentDate;
                        TotalAmt += 0;
                        ExtraDiscount += 0;
                        DiscountAmount += 0;
                        GSTAmount += 0;
                        TotalNetAmt += decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.ExecuteQuery();

                        #endregion

                        #region insert sale_invoice_Promotion


                        //----------------Insert into sale order Promotion-------------

                        decimal x = decimal.Parse(dr["SCHEME_UNITS"].ToString());
                        decimal y = decimal.Parse(dr["UNIT_PRICE"].ToString());

                        spInsertSALE_INVOICE_PROMOTION2 mSaleOrderPromo = new spInsertSALE_INVOICE_PROMOTION2();
                        mSaleOrderPromo.Connection = mConnection;
                        mSaleOrderPromo.Transaction = mTransaction;
                        mSaleOrderPromo.BASKET_DETAIL_ID = -1;
                        mSaleOrderPromo.BASKET_ID = -1;
                        mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderPromo.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderPromo.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderPromo.PROMOTION_ID = -1;
                        mSaleOrderPromo.PROMOTION_OFFER_ID = -1;
                        mSaleOrderPromo.QUANTITY = int.Parse(dr["SCHEME_UNITS"].ToString());
                        mSaleOrderPromo.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderPromo.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderPromo.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        mSaleOrderPromo.AMOUNT = x * y;
                        mSaleOrderPromo.SED_AMOUNT = 0;
                        mSaleOrderPromo.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderPromo.ExecuteQuery();

                        #region Update Sku_Stock_register
                        UspProcessStockRegister mStockFree = new UspProcessStockRegister();
                        mStockFree.Connection = mConnection;
                        mStockFree.Transaction = mTransaction;
                        mStockFree.TYPE_ID = Constants.Document_Transfer_Out;
                        mStockFree.DISTRIBUTOR_ID = p_Distributor_id;
                        mStockFree.STOCK_DATE = p_DocumentDate;
                        mStockFree.SKU_ID = mSaleOrderDetail.SKU_ID;
                        mStockFree.BATCHNO = mSaleOrderDetail.BATCH_NO;
                        mStockFree.STOCK_QTY = 0;   // Quantity_unit = Gross unit ,
                        mStockFree.FREE_QTY = mSaleOrderDetail.SCHEME_UNIT;
                        mStockFree.ExecuteQuery();
                        #endregion


                        #endregion

                        #region Update Sku_Stock_register
                        UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                        mStockUpdate.Connection = mConnection;
                        mStockUpdate.Transaction = mTransaction;
                        mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                        mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        mStockUpdate.STOCK_DATE = p_DocumentDate;
                        mStockUpdate.SKU_ID = mSaleOrderDetail.SKU_ID;
                        mStockUpdate.BATCHNO = mSaleOrderDetail.BATCH_NO;
                        mStockUpdate.STOCK_QTY = mSaleOrderDetail.QUANTITY_UNIT;
                        mStockUpdate.FREE_QTY = 0;
                        mStockUpdate.ExecuteQuery();
                        #endregion

                        #region Account Posting
                        LedgerController LController = new LedgerController();
                        Configuration.GetAccountHead();
                        DistributorController Dcontroller = new DistributorController();


                        string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);

                        if (InvoiceTypeId == Constants.Advance_PaymentOrder_id)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_AMOUNT, mISom.DOCUMENT_DATE, "Gross Sale Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                            if (p_STANDARD_DISCOUNT_AMOUNT > 0)
                            {
                                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleDiscount), p_Distributor_id, p_STANDARD_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Commision/Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                            }
                            if (p_EXTRA_DISCOUNT_AMOUNT > 0)
                            {
                                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleScheme), p_Distributor_id, p_EXTRA_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                            }
                            if (p_GST_AMOUNT + p_TSTAmount > 0)
                            {
                                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.GSTAccount), p_Distributor_id, 0, p_GST_AMOUNT + p_TSTAmount, mISom.DOCUMENT_DATE, "Sales Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                            }
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                        }
                        else if (InvoiceTypeId == Constants.Credit_Order_Id)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT - p_CashReceived, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT - p_CashReceived, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());

                        }
                        #endregion

                        #region Update Pending Order

                        //spUpdateSALE_ORDER_MASTER mOrderUpdate = new spUpdateSALE_ORDER_MASTER();
                        //mOrderUpdate.Connection = mConnection;
                        //mOrderUpdate.Transaction = mTransaction;
                        //mOrderUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        //mOrderUpdate.SALE_ORDER_ID = p_Orderid;
                        //mOrderUpdate.STATUS_ID = Constants.Order_Posted_Id;
                        //mOrderUpdate.ExecuteQuery();

                        #endregion


                    }
                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }


        // by safdar to use in load pass entry form
        public bool Update_Invoice(long Sale_Invoice_ID, int p_Distributor_id, string p_MANUAL_INVOICE_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Orderid,
       decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_BRD, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, decimal p_CashReceived, DateTime p_DocumentDate, decimal p_SEDAmount, decimal p_TSTAmount, int p_Visit, int p_Productive_call, int p_Opening_reading, int p_Closing_Reading, int p_Bill_No_From, int p_Bill_No_To, decimal p_FUEL, decimal p_Whole_sale_discount, decimal p_Total_damage_value, bool IsDamage, decimal p_Total_Actual_Damage)
        {

            #region delete sale invoice detail


         //   DeleteInvoiceDetail(Sale_Invoice_ID);

            #endregion
        
            
            //by safdar to use in Load pass form
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                #region insert sale invoice master
                spUpdateSALE_INVOICE_MASTER3 mISom = new spUpdateSALE_INVOICE_MASTER3();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale invoice Master----------

                
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.SALE_INVOICE_ID = Sale_Invoice_ID;
                 //   mISom.MANUAL_INVOICE_ID = p_MANUAL_INVOICE_ID;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = p_AREA_ID;
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_DocumentDate;
                    mISom.SOLD_TO = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                    mISom.FUEL = p_FUEL;
                    mISom.WHOLE_SALE_DISCOUNT = p_Whole_sale_discount;
                    mISom.IS_DELETED = false;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    if (InvoiceTypeId == Constants.Credit_Order_Id)
                    {
                        mISom.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                        mISom.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                    }
                    else
                    {
                        mISom.CREDIT_AMOUNT = 0;
                        mISom.CURRENT_CREDIT_AMOUNT = 0;
                    }
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.USER_ID = p_UserId;
                    mISom.SALE_ORDER_ID = p_Orderid;

                     mISom.TST_AMOUNT = p_TSTAmount;
                     mISom.SED_AMOUNT = p_SEDAmount;
                      mISom.BRD = p_BRD;
                    mISom.VISIT = p_Visit;
                    mISom.PRODUCTIVE_CALL = p_Productive_call;
                    mISom.OPENING_READING = p_Opening_reading;
                    mISom.CLOSING_READING = p_Closing_Reading;
                    mISom.BILL_NO_FROM = p_Bill_No_From;
                    mISom.BILL_NO_TO = p_Bill_No_To;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.IS_DELETED = false;
                   // mISom.POSTING = 0;
                    mISom.ExecuteQuery();

                

                #endregion
               
                #region Delete Sale Invoice Detail
                spDeleteSALE_INVOICE_DETAIL mSaleINVOICEDETAILDELETE = new spDeleteSALE_INVOICE_DETAIL();
                mSaleINVOICEDETAILDELETE.Connection = mConnection;
                mSaleINVOICEDETAILDELETE.Transaction = mTransaction;
                mSaleINVOICEDETAILDELETE.SALE_INVOICE_ID = Sale_Invoice_ID;
                mSaleINVOICEDETAILDELETE.SALE_INVOICE_DETAIL_ID = Constants.LongNullValue;
                mSaleINVOICEDETAILDELETE.ExecuteQuery();
                #endregion

                #region Insert Damage Unit in Sale Return

                spUpdateSALES_RETURN_MASTER2 mISonRetun = new spUpdateSALES_RETURN_MASTER2();
                    mISonRetun.Connection = mConnection;
                    mISonRetun.Transaction = mTransaction;

                    //------------Insert into Sale Return Master----------

                    
                        mISonRetun.SALE_INVOICE_ID = Sale_Invoice_ID;
                        mISonRetun.DISTRIBUTOR_ID = p_Distributor_id;
                        // mISonRetun.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mISonRetun.AREA_ID = int.Parse(p_AREA_ID.ToString());
                        mISonRetun.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                        mISonRetun.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                        mISonRetun.DOCUMENT_DATE = p_DocumentDate;
                        mISonRetun.CUSTOMER_ID = p_SOLD_TO;
                        mISonRetun.TOTAL_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                        mISonRetun.EXTRA_DISCOUNT_AMOUNT = 0;
                        mISonRetun.STANDARD_DISCOUNT_AMOUNT = 0;
                        mISonRetun.GST_AMOUNT = 0;
                        mISonRetun.TOTAL_NET_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                        mISonRetun.TOWN_ID = p_TOWN_ID;
                        mISonRetun.TIME_STAMP = DateTime.Now;
                        mISonRetun.LASTUPDATE_DATE = System.DateTime.Now;
                       
                        mISonRetun.ExecuteQuery();

                       



                        spInsertSALES_RETURN_DETAIL mSaleReturnDetail = new spInsertSALES_RETURN_DETAIL();
                        mSaleReturnDetail.Connection = mConnection;
                        mSaleReturnDetail.Transaction = mTransaction;

                        foreach (DataRow dr in dtOrderDetail.Rows)
                        {
                            mSaleReturnDetail.SALES_RETURN_ID = mISonRetun.SALES_RETURN_ID;
                            mSaleReturnDetail.DISTRIBUTOR_ID = p_Distributor_id;
                            mSaleReturnDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                            mSaleReturnDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                            mSaleReturnDetail.QUANTITY_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString()) + int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                            mSaleReturnDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                            mSaleReturnDetail.GST_RATE = 0;
                            mSaleReturnDetail.AMOUNT = ((decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString())+decimal.Parse(dr["DAMAGE_UNITS"].ToString())) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                            mSaleReturnDetail.EXTRA_DISCOUNT = 0;
                            mSaleReturnDetail.STANDARD_DISCOUNT = 0;
                            mSaleReturnDetail.GST_AMOUNT = 0;
                            mSaleReturnDetail.TST_AMOUNT = 0;
                            mSaleReturnDetail.SED_AMOUNT = 0;
                            mSaleReturnDetail.NET_AMOUNT = 0;
                            mSaleReturnDetail.TIME_STAMP = p_DocumentDate;
                            mSaleReturnDetail.ExecuteQuery();

                        }
                    
                
                #endregion

                #region Insert Actual damage in Purchase Master Detail

                        spUpdatePURCHASE_MASTER2 mPurchaseMaster = new spUpdatePURCHASE_MASTER2();
                        mPurchaseMaster.Connection = mConnection;
                        mPurchaseMaster.Transaction = mTransaction;
                      //  mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                        mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_id;
                        mPurchaseMaster.TYPE_ID = 10;
                        mPurchaseMaster.ORDER_NUMBER = Sale_Invoice_ID.ToString();
                        mPurchaseMaster.SOLD_FROM = p_PRINCIPAL_ID;
                        mPurchaseMaster.DOCUMENT_DATE = p_DocumentDate;
                        mPurchaseMaster.SOLD_TO = p_Distributor_id;
                        mPurchaseMaster.TOTAL_AMOUNT = p_Total_Actual_Damage;
                        mPurchaseMaster.USER_ID = p_UserId;
                        mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                        mPurchaseMaster.POSTING = 0;
                        mPurchaseMaster.BUILTY_NO = "";
                        mPurchaseMaster.DAMAGE_TYPE = 0;
                        mPurchaseMaster.DOCUMENT_ID = Sale_Invoice_ID;
                        mPurchaseMaster.ExecuteQuery();

                        //Get Privouse Update Purchase Detail and Rollback
                        //LedgerController LController = new LedgerController();

                        //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                        //DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                        //foreach (DataRow dr in dt.Rows)
                        //{
                        //    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                        //    mPurchaseStock.Connection = mConnection;
                        //    mPurchaseStock.Transaction = mTransaction;
                        //    mPurchaseStock.TYPEID = p_TYPE_ID;
                        //    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                        //    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                        //    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                        //    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                        //    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        //    mPurchaseStock.ExecuteQuery();
                        //}

                        spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                        mPurchaseDetail.Connection = mConnection;
                        mPurchaseDetail.Transaction = mTransaction;

                        foreach (DataRow dr in dtOrderDetail.Rows)
                        {
                            mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                            mPurchaseDetail.DISTRIBUTOR_ID = p_Distributor_id;
                            mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                            mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                            mPurchaseDetail.PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                            mPurchaseDetail.QUANTITY = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                            mPurchaseDetail.FREE_SKU = 0;
                            mPurchaseDetail.AMOUNT = (decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                            mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                            mPurchaseDetail.TIME_STAMP = p_DocumentDate;
                            mPurchaseDetail.TDAMAGE = 0;
                            mPurchaseDetail.ExecuteQuery();

                            UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                            mStockUpdate.Connection = mConnection;
                            mStockUpdate.Transaction = mTransaction;
                            mStockUpdate.PRINCIPAL_ID = p_PRINCIPAL_ID;
                            mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                            mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                            mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                            mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                            mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                            mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                            mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                            mStockUpdate.ExecuteQuery();
                        }

                        #endregion

                #region insert sale invoice detail


                        ////----------------Insert into sale order detail-------------
                    spInsertSALE_INVOICE_DETAIL2 mSaleOrderDetail = new spInsertSALE_INVOICE_DETAIL2();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                        mSaleOrderDetail.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = "";
                        mSaleOrderDetail.ISSUE_UNIT = int.Parse(dr["ISSUE_UNITS"].ToString()) + int.Parse(dr["ISSUE_CTN"].ToString()) * int.Parse(dr["UNITS_IN_CASE"].ToString());
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["GROSS_UNITS"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.RETURN_UNIT = int.Parse(dr["RETURN_UNITS"].ToString()) + (int.Parse(dr["RETURN_CTN"].ToString()) * int.Parse(dr["Units_In_Case"].ToString()));
                        mSaleOrderDetail.EMPTY_RETURN_UNIT = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                        mSaleOrderDetail.DAMAGE_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString());
                        mSaleOrderDetail.SCHEME_UNIT = int.Parse(dr["SCHEME_UNITS"].ToString());
                        mSaleOrderDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT = mSaleOrderDetail.QUANTITY_UNIT * mSaleOrderDetail.UNIT_PRICE;
                        mSaleOrderDetail.EXTRA_DISCOUNT = 0;
                        mSaleOrderDetail.STANDARD_DISCOUNT = 0;
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = 0;
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.IS_DELETED = false;
                        mSaleOrderDetail.TIME_STAMP = p_DocumentDate;
                        TotalAmt += 0;
                        ExtraDiscount += 0;
                        DiscountAmount += 0;
                        GSTAmount += 0;
                        TotalNetAmt += decimal.Parse(dr["NET_VALUE"].ToString());
                        mSaleOrderDetail.ExecuteQuery();
                        #region insert sale invoice promotion
                       

                            //----------------Insert into sale order Promotion-------------

                            decimal x = decimal.Parse(dr["SCHEME_UNITS"].ToString());
                            decimal y = decimal.Parse(dr["UNIT_PRICE"].ToString());

                            spInsertSALE_INVOICE_PROMOTION2 mSaleOrderPromo = new spInsertSALE_INVOICE_PROMOTION2();
                            mSaleOrderPromo.Connection = mConnection;
                            mSaleOrderPromo.Transaction = mTransaction;
                            mSaleOrderPromo.BASKET_DETAIL_ID = -1;
                            mSaleOrderPromo.BASKET_ID = -1;
                            mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                            mSaleOrderPromo.GST_AMOUNT = 0;
                            mSaleOrderPromo.GST_RATE = 0;
                            mSaleOrderPromo.PROMOTION_ID = -1;
                            mSaleOrderPromo.PROMOTION_OFFER_ID = -1;
                            mSaleOrderPromo.QUANTITY = int.Parse(dr["SCHEME_UNITS"].ToString());
                            mSaleOrderPromo.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                            mSaleOrderPromo.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                            mSaleOrderPromo.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                            mSaleOrderPromo.AMOUNT = x * y;
                            mSaleOrderPromo.SED_AMOUNT = 0;
                            mSaleOrderPromo.TST_AMOUNT = 0;
                            mSaleOrderPromo.ExecuteQuery();

                        #endregion
                        #region Update Sku_Stock_register
                            UspProcessStockRegister mStockFree = new UspProcessStockRegister();
                            mStockFree.Connection = mConnection;
                            mStockFree.Transaction = mTransaction;
                            mStockFree.TYPE_ID = Constants.Document_Transfer_Out;
                            mStockFree.DISTRIBUTOR_ID = p_Distributor_id;
                            mStockFree.STOCK_DATE = p_DocumentDate;
                            mStockFree.SKU_ID = mSaleOrderDetail.SKU_ID;
                            mStockFree.BATCHNO = mSaleOrderDetail.BATCH_NO;
                            mStockFree.STOCK_QTY = 0;   // Quantity_unit = Gross unit ,
                            mStockFree.FREE_QTY = mSaleOrderDetail.SCHEME_UNIT;
                            mStockFree.ExecuteQuery();
                            #endregion
                        


               
                        #endregion

                #region Update Sku_Stock_register
                        UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                        mStockUpdate.Connection = mConnection;
                        mStockUpdate.Transaction = mTransaction;
                        mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                        mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                        mStockUpdate.STOCK_DATE = p_DocumentDate;
                        mStockUpdate.SKU_ID = mSaleOrderDetail.SKU_ID;
                        mStockUpdate.BATCHNO = mSaleOrderDetail.BATCH_NO;
                        mStockUpdate.STOCK_QTY = mSaleOrderDetail.QUANTITY_UNIT;
                        mStockUpdate.FREE_QTY = 0;
                        mStockUpdate.ExecuteQuery();

                    }
                 #endregion
                 
                #region Account Posting
                    LedgerController LController = new LedgerController();
                    Configuration.GetAccountHead();
                    DistributorController Dcontroller = new DistributorController();


                    string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);

                    if (InvoiceTypeId == Constants.Advance_PaymentOrder_id)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_AMOUNT, mISom.DOCUMENT_DATE, "Gross Sale Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID,"", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                        if (p_STANDARD_DISCOUNT_AMOUNT > 0)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleDiscount), p_Distributor_id, p_STANDARD_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Commision/Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                        }
                        if (p_EXTRA_DISCOUNT_AMOUNT > 0)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleScheme), p_Distributor_id, p_EXTRA_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                        }
                        if (p_GST_AMOUNT + p_TSTAmount > 0)
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.GSTAccount), p_Distributor_id, 0, p_GST_AMOUNT + p_TSTAmount, mISom.DOCUMENT_DATE, "Sales Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID,"", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                        }
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID,"", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                    }
                    else if (InvoiceTypeId == Constants.Credit_Order_Id)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT - p_CashReceived, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID,"", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT - p_CashReceived, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());

                    }
                        #endregion
                
                
                
                        mTransaction.Commit();
                        return true;
                    
           }
            
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }

        public bool Update_Invoice(long Sale_Invoice_ID, int p_Distributor_id, string p_MANUAL_INVOICE_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Orderid,
   decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_BRD, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId, decimal p_CashReceived, DateTime p_DocumentDate, decimal p_SEDAmount, decimal p_TSTAmount, int p_Visit, int p_Productive_call, int p_Opening_reading, int p_Closing_Reading, int p_Bill_No_From, int p_Bill_No_To, decimal p_FUEL, decimal p_Whole_sale_discount, decimal p_Total_damage_value, bool IsDamage, decimal p_Total_Actual_Damage, decimal p_incentive, decimal p_Rental, decimal p_Display)
        {

            #region delete sale invoice detail


            //   DeleteInvoiceDetail(Sale_Invoice_ID);

            #endregion


            //by safdar to use in Load pass form
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            decimal TotalAmt = 0, DiscountAmount = 0, ExtraDiscount = 0, GSTAmount = 0, TotalNetAmt = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                #region insert sale invoice master
                spUpdateSALE_INVOICE_MASTER3 mISom = new spUpdateSALE_INVOICE_MASTER3();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale invoice Master----------


                mISom.DISTRIBUTOR_ID = p_Distributor_id;
                mISom.SALE_INVOICE_ID = Sale_Invoice_ID;
                //   mISom.MANUAL_INVOICE_ID = p_MANUAL_INVOICE_ID;
                mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mISom.AREA_ID = p_AREA_ID;
                mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                mISom.DOCUMENT_DATE = p_DocumentDate;
                mISom.SOLD_TO = p_SOLD_TO;
                mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                mISom.GST_AMOUNT = p_GST_AMOUNT;
                mISom.SCHEME_AMOUNT = p_SCHEME_AMOUNT;
                mISom.FUEL = p_FUEL;
                mISom.WHOLE_SALE_DISCOUNT = p_Whole_sale_discount;
                mISom.IS_DELETED = false;
                mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                if (InvoiceTypeId == Constants.Credit_Order_Id)
                {
                    mISom.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                    mISom.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT - p_CashReceived;
                }
                else
                {
                    mISom.CREDIT_AMOUNT = 0;
                    mISom.CURRENT_CREDIT_AMOUNT = 0;
                }
                mISom.TOWN_ID = p_TOWN_ID;
                mISom.USER_ID = p_UserId;
                mISom.SALE_ORDER_ID = p_Orderid;

                mISom.TST_AMOUNT = p_TSTAmount;
                mISom.SED_AMOUNT = p_SEDAmount;
                mISom.BRD = p_BRD;
                mISom.VISIT = p_Visit;
                mISom.PRODUCTIVE_CALL = p_Productive_call;
                mISom.OPENING_READING = p_Opening_reading;
                mISom.CLOSING_READING = p_Closing_Reading;
                mISom.BILL_NO_FROM = p_Bill_No_From;
                mISom.BILL_NO_TO = p_Bill_No_To;
                mISom.TIME_STAMP = DateTime.Now;
                mISom.LASTUPDATE_DATE = System.DateTime.Now;
                mISom.IS_DELETED = false;
                mISom.INCENTIVE = p_incentive;
                mISom.RENTAL = p_Rental;
                mISom.DISPLAY = p_Display;
                // mISom.POSTING = 0;
                mISom.ExecuteQuery();



                #endregion

                #region Delete Sale Invoice Detail
                spDeleteSALE_INVOICE_DETAIL mSaleINVOICEDETAILDELETE = new spDeleteSALE_INVOICE_DETAIL();
                mSaleINVOICEDETAILDELETE.Connection = mConnection;
                mSaleINVOICEDETAILDELETE.Transaction = mTransaction;
                mSaleINVOICEDETAILDELETE.SALE_INVOICE_ID = Sale_Invoice_ID;
                mSaleINVOICEDETAILDELETE.SALE_INVOICE_DETAIL_ID = Constants.LongNullValue;
                mSaleINVOICEDETAILDELETE.ExecuteQuery();
                #endregion

                #region Insert Damage Unit in Sale Return

                spUpdateSALES_RETURN_MASTER2 mISonRetun = new spUpdateSALES_RETURN_MASTER2();
                mISonRetun.Connection = mConnection;
                mISonRetun.Transaction = mTransaction;

                //------------Insert into Sale Return Master----------


                mISonRetun.SALE_INVOICE_ID = Sale_Invoice_ID;
                mISonRetun.DISTRIBUTOR_ID = p_Distributor_id;
                // mISonRetun.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mISonRetun.AREA_ID = int.Parse(p_AREA_ID.ToString());
                mISonRetun.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mISonRetun.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                mISonRetun.DOCUMENT_DATE = p_DocumentDate;
                mISonRetun.CUSTOMER_ID = p_SOLD_TO;
                mISonRetun.TOTAL_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                mISonRetun.EXTRA_DISCOUNT_AMOUNT = 0;
                mISonRetun.STANDARD_DISCOUNT_AMOUNT = 0;
                mISonRetun.GST_AMOUNT = 0;
                mISonRetun.TOTAL_NET_AMOUNT = p_Total_damage_value + p_Total_Actual_Damage;
                mISonRetun.TOWN_ID = p_TOWN_ID;
                mISonRetun.TIME_STAMP = DateTime.Now;
                mISonRetun.LASTUPDATE_DATE = System.DateTime.Now;

                mISonRetun.ExecuteQuery();





                spInsertSALES_RETURN_DETAIL mSaleReturnDetail = new spInsertSALES_RETURN_DETAIL();
                mSaleReturnDetail.Connection = mConnection;
                mSaleReturnDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtOrderDetail.Rows)
                {
                    mSaleReturnDetail.SALES_RETURN_ID = mISonRetun.SALES_RETURN_ID;
                    mSaleReturnDetail.DISTRIBUTOR_ID = p_Distributor_id;
                    mSaleReturnDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mSaleReturnDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mSaleReturnDetail.QUANTITY_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString()) + int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                    mSaleReturnDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                    mSaleReturnDetail.GST_RATE = 0;
                    mSaleReturnDetail.AMOUNT = ((decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) + decimal.Parse(dr["DAMAGE_UNITS"].ToString())) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                    mSaleReturnDetail.EXTRA_DISCOUNT = 0;
                    mSaleReturnDetail.STANDARD_DISCOUNT = 0;
                    mSaleReturnDetail.GST_AMOUNT = 0;
                    mSaleReturnDetail.TST_AMOUNT = 0;
                    mSaleReturnDetail.SED_AMOUNT = 0;
                    mSaleReturnDetail.NET_AMOUNT = 0;
                    mSaleReturnDetail.TIME_STAMP = p_DocumentDate;
                    mSaleReturnDetail.ExecuteQuery();

                }


                #endregion

                #region Insert Actual damage in Purchase Master Detail

                spUpdatePURCHASE_MASTER2 mPurchaseMaster = new spUpdatePURCHASE_MASTER2();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                //  mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_id;
                mPurchaseMaster.TYPE_ID = 10;
                mPurchaseMaster.ORDER_NUMBER = Sale_Invoice_ID.ToString();
                mPurchaseMaster.SOLD_FROM = p_PRINCIPAL_ID;
                mPurchaseMaster.DOCUMENT_DATE = p_DocumentDate;
                mPurchaseMaster.SOLD_TO = p_Distributor_id;
                mPurchaseMaster.TOTAL_AMOUNT = p_Total_Actual_Damage;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = 0;
                mPurchaseMaster.BUILTY_NO = "";
                mPurchaseMaster.DAMAGE_TYPE = 0;
                mPurchaseMaster.DOCUMENT_ID = Sale_Invoice_ID;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                //DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                //foreach (DataRow dr in dt.Rows)
                //{
                //    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                //    mPurchaseStock.Connection = mConnection;
                //    mPurchaseStock.Transaction = mTransaction;
                //    mPurchaseStock.TYPEID = p_TYPE_ID;
                //    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                //    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                //    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                //    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                //    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                //    mPurchaseStock.ExecuteQuery();
                //}

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtOrderDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_Distributor_id;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                    mPurchaseDetail.FREE_SKU = 0;
                    mPurchaseDetail.AMOUNT = (decimal.Parse(dr["Actual_DAMAGE_UNITS"].ToString()) * decimal.Parse(dr["UNIT_PRICE"].ToString()));
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DocumentDate;
                    mPurchaseDetail.TDAMAGE = 0;
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }

                #endregion

                #region insert sale invoice detail


                ////----------------Insert into sale order detail-------------
                spInsertSALE_INVOICE_DETAIL2 mSaleOrderDetail = new spInsertSALE_INVOICE_DETAIL2();
                mSaleOrderDetail.Connection = mConnection;
                mSaleOrderDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtOrderDetail.Rows)
                {
                    //SaleOrderDetail_Collection mSod_Col=new SaleOrderDetail_Collection ();
                    mSaleOrderDetail.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                    mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                    mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mSaleOrderDetail.BATCH_NO = "";
                    mSaleOrderDetail.ISSUE_UNIT = int.Parse(dr["ISSUE_UNITS"].ToString()) + int.Parse(dr["ISSUE_CTN"].ToString()) * int.Parse(dr["UNITS_IN_CASE"].ToString());
                    mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["GROSS_UNITS"].ToString());
                    mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                    mSaleOrderDetail.RETURN_UNIT = int.Parse(dr["RETURN_UNITS"].ToString()) + (int.Parse(dr["RETURN_CTN"].ToString()) * int.Parse(dr["Units_In_Case"].ToString()));
                    mSaleOrderDetail.EMPTY_RETURN_UNIT = int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
                    mSaleOrderDetail.DAMAGE_UNIT = int.Parse(dr["DAMAGE_UNITS"].ToString());
                    mSaleOrderDetail.SCHEME_UNIT = int.Parse(dr["SCHEME_UNITS"].ToString());
                    mSaleOrderDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());
                    mSaleOrderDetail.AMOUNT = mSaleOrderDetail.QUANTITY_UNIT * mSaleOrderDetail.UNIT_PRICE;
                    mSaleOrderDetail.EXTRA_DISCOUNT = 0;
                    mSaleOrderDetail.STANDARD_DISCOUNT = 0;
                    mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                    mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                    mSaleOrderDetail.SED_AMOUNT = 0;
                    mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_VALUE"].ToString());
                    mSaleOrderDetail.IS_DELETED = false;
                    mSaleOrderDetail.TIME_STAMP = p_DocumentDate;
                    TotalAmt += 0;
                    ExtraDiscount += 0;
                    DiscountAmount += 0;
                    GSTAmount += 0;
                    TotalNetAmt += decimal.Parse(dr["NET_VALUE"].ToString());
                    mSaleOrderDetail.ExecuteQuery();
                    #region insert sale invoice promotion


                    //----------------Insert into sale order Promotion-------------

                    decimal x = decimal.Parse(dr["SCHEME_UNITS"].ToString());
                    decimal y = decimal.Parse(dr["UNIT_PRICE"].ToString());

                    spInsertSALE_INVOICE_PROMOTION2 mSaleOrderPromo = new spInsertSALE_INVOICE_PROMOTION2();
                    mSaleOrderPromo.Connection = mConnection;
                    mSaleOrderPromo.Transaction = mTransaction;
                    mSaleOrderPromo.BASKET_DETAIL_ID = -1;
                    mSaleOrderPromo.BASKET_ID = -1;
                    mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                    mSaleOrderPromo.GST_AMOUNT = 0;
                    mSaleOrderPromo.GST_RATE = 0;
                    mSaleOrderPromo.PROMOTION_ID = -1;
                    mSaleOrderPromo.PROMOTION_OFFER_ID = -1;
                    mSaleOrderPromo.QUANTITY = int.Parse(dr["SCHEME_UNITS"].ToString());
                    mSaleOrderPromo.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mSaleOrderPromo.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                    mSaleOrderPromo.SALE_INVOICE_ID = mISom.SALE_INVOICE_ID;
                    mSaleOrderPromo.AMOUNT = x * y;
                    mSaleOrderPromo.SED_AMOUNT = 0;
                    mSaleOrderPromo.TST_AMOUNT = 0;
                    mSaleOrderPromo.ExecuteQuery();

                    #endregion
                    #region Update Sku_Stock_register
                    UspProcessStockRegister mStockFree = new UspProcessStockRegister();
                    mStockFree.Connection = mConnection;
                    mStockFree.Transaction = mTransaction;
                    mStockFree.TYPE_ID = Constants.Document_Transfer_Out;
                    mStockFree.DISTRIBUTOR_ID = p_Distributor_id;
                    mStockFree.STOCK_DATE = p_DocumentDate;
                    mStockFree.SKU_ID = mSaleOrderDetail.SKU_ID;
                    mStockFree.BATCHNO = mSaleOrderDetail.BATCH_NO;
                    mStockFree.STOCK_QTY = 0;   // Quantity_unit = Gross unit ,
                    mStockFree.FREE_QTY = mSaleOrderDetail.SCHEME_UNIT;
                    mStockFree.ExecuteQuery();
                    #endregion




                    #endregion

                    #region Update Sku_Stock_register
                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                    mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                    mStockUpdate.STOCK_DATE = p_DocumentDate;
                    mStockUpdate.SKU_ID = mSaleOrderDetail.SKU_ID;
                    mStockUpdate.BATCHNO = mSaleOrderDetail.BATCH_NO;
                    mStockUpdate.STOCK_QTY = mSaleOrderDetail.QUANTITY_UNIT;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.ExecuteQuery();

                }
                #endregion

                #region Account Posting
                LedgerController LController = new LedgerController();
                Configuration.GetAccountHead();
                DistributorController Dcontroller = new DistributorController();


                string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);

                if (InvoiceTypeId == Constants.Advance_PaymentOrder_id)
                {
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_AMOUNT, mISom.DOCUMENT_DATE, "Gross Sale Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                    if (p_STANDARD_DISCOUNT_AMOUNT > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleDiscount), p_Distributor_id, p_STANDARD_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Commision/Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                    }
                    if (p_EXTRA_DISCOUNT_AMOUNT > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleScheme), p_Distributor_id, p_EXTRA_DISCOUNT_AMOUNT, 0, mISom.DOCUMENT_DATE, "Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                    }
                    if (p_GST_AMOUNT + p_TSTAmount > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.GSTAccount), p_Distributor_id, 0, p_GST_AMOUNT + p_TSTAmount, mISom.DOCUMENT_DATE, "Sales Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());
                    }
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.Cash_Advance, p_DELIVERYMAN_ID.ToString());

                }
                else if (InvoiceTypeId == Constants.Credit_Order_Id)
                {
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT - p_CashReceived, 0, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT - p_CashReceived, mISom.DOCUMENT_DATE, "Credit Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, "", Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, Constants.CreditSale, p_DELIVERYMAN_ID.ToString());

                }
                #endregion



                mTransaction.Commit();
                return true;

            }

            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }



        public DataTable SelectPrivousePurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, IDbConnection PConnection, IDbTransaction PTransaction)
        {
            try
            {
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = PConnection;
                mPurchaseDetail.Transaction = PTransaction;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
        }






        /// <summary>
        /// Inserts Sale Returns
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Market</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_SOLD_TO">Customer</param>
        /// <param name="p_SHIP_TO">ShipTo</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Orderid">Order</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_EXTRA_DISCOUNT_AMOUNT">ExtraDiscount</param>
        /// <param name="p_STANDARD_DISCOUNT_AMOUNT">Discount</param>
        /// <param name="p_GST_AMOUNT">GST</param>
        /// <param name="p_TOTAL_NET_AMOUNT">NetAmount</param>
        /// <param name="p_SCHEME_AMOUNT">Scheme</param>
        /// <param name="InvoiceTypeId">Type</param>
        /// <param name="dtOrderDetail">OrderDetailDatatable</param>
        /// <param name="dtFreeSKU">FreeSKUDatatable</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_DocumentDate">Date</param>
        /// <param name="p_TstAmount">TSTAmount</param>
        /// <param name="p_SEDAmount">SEDAmount</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Add_SaleReturn(int p_Distributor_id, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, long p_Orderid,
        decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int InvoiceTypeId, DataTable dtOrderDetail, DataTable dtFreeSKU, int p_UserId,DateTime p_DocumentDate,decimal p_TstAmount, decimal p_SEDAmount)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertSALES_RETURN_MASTER mISom = new spInsertSALES_RETURN_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Return Master----------

                if (dtOrderDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.AREA_ID = int.Parse(p_AREA_ID.ToString());
                    mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                    mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                    mISom.DOCUMENT_DATE = p_DocumentDate;
                    mISom.CUSTOMER_ID = p_SOLD_TO;
                    mISom.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                    mISom.EXTRA_DISCOUNT_AMOUNT = p_EXTRA_DISCOUNT_AMOUNT;
                    mISom.STANDARD_DISCOUNT_AMOUNT = p_STANDARD_DISCOUNT_AMOUNT;
                    mISom.GST_AMOUNT = p_GST_AMOUNT;
                    mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                    mISom.TOWN_ID = p_TOWN_ID;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.LASTUPDATE_DATE = System.DateTime.Now;
                    mISom.TST_AMOUNT = p_TstAmount;
                    mISom.SED_AMOUNT = p_SEDAmount;
                    mISom.IS_DELETED = false;
                    mISom.POSTING = 0;
                    mISom.ExecuteQuery();

                    //----------------Insert into sales return detail-------------
                    spInsertSALES_RETURN_DETAIL mSaleOrderDetail = new spInsertSALES_RETURN_DETAIL();
                    mSaleOrderDetail.Connection = mConnection;
                    mSaleOrderDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtOrderDetail.Rows)
                    {
                        mSaleOrderDetail.SALES_RETURN_ID = mISom.SALES_RETURN_ID;
                        mSaleOrderDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mSaleOrderDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                        mSaleOrderDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                        mSaleOrderDetail.QUANTITY_UNIT = int.Parse(dr["QUANTITY"].ToString());
                        mSaleOrderDetail.UNIT_PRICE = decimal.Parse(dr["UNIT_PRICE"].ToString());
                        mSaleOrderDetail.GST_RATE = float.Parse(dr["GST_RATE"].ToString());
                        mSaleOrderDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                        mSaleOrderDetail.EXTRA_DISCOUNT = decimal.Parse(dr["EXTRA_DISCOUNT"].ToString());
                        mSaleOrderDetail.STANDARD_DISCOUNT = decimal.Parse(dr["STANDARD_DISCOUNT"].ToString());
                        mSaleOrderDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                        mSaleOrderDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                        mSaleOrderDetail.SED_AMOUNT = decimal.Parse(dr["SED_AMOUNT"].ToString());
                        mSaleOrderDetail.NET_AMOUNT = decimal.Parse(dr["NET_AMOUNT"].ToString());
                        mSaleOrderDetail.TIME_STAMP = p_DocumentDate;
                        mSaleOrderDetail.ExecuteQuery();

                    }

                    #region Account Posting
                    LedgerController LController = new LedgerController();
                    Configuration.GetAccountHead();
                    DistributorController Dcontroller = new DistributorController();


                    string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);

                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleReturnAccount), p_Distributor_id, p_TOTAL_AMOUNT, 0, mISom.DOCUMENT_DATE, "Sales Return Value", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALES_RETURN_ID, mISom.SALES_RETURN_ID.ToString(), Constants.Document_Sale_Return, p_UserId, mTransaction, mConnection, Constants.CashSaleReturn, p_DELIVERYMAN_ID.ToString());

                    if (p_STANDARD_DISCOUNT_AMOUNT > 0 || p_EXTRA_DISCOUNT_AMOUNT > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleReturnDiscount), p_Distributor_id, 0, p_STANDARD_DISCOUNT_AMOUNT + p_EXTRA_DISCOUNT_AMOUNT, mISom.DOCUMENT_DATE, "Sales Return Discount/Extra Discount", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALES_RETURN_ID, mISom.SALES_RETURN_ID.ToString(), Constants.CashSaleReturn, p_UserId, mTransaction, mConnection, Constants.Document_Sale_Return, p_DELIVERYMAN_ID.ToString());
                    }
                    if (p_GST_AMOUNT + p_TstAmount > 0)
                    {
                        LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleReturnGST), p_Distributor_id, p_GST_AMOUNT + p_TstAmount, 0, mISom.DOCUMENT_DATE, "Sales Return Tax", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALES_RETURN_ID, mISom.SALES_RETURN_ID.ToString(), Constants.Document_Sale_Return, p_UserId, mTransaction, mConnection, Constants.CashSaleReturn, p_DELIVERYMAN_ID.ToString());
                    }
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT, mISom.DOCUMENT_DATE, "Sales Return Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALES_RETURN_ID, mISom.SALES_RETURN_ID.ToString(), Constants.Document_Sale_Return, p_UserId, mTransaction, mConnection, Constants.CashSaleReturn, p_DELIVERYMAN_ID.ToString());

                    #endregion

                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();  
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }
        
        /// <summary>
        /// Delets Free SKU Form Invoice
        /// </summary>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Invoice_Id">Invoice</param>
        /// <param name="p_SalePromotionId">Promotion</param>
        /// <param name="p_SKU_id">SKU</param>
        /// <param name="p_Qty">Quantity</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool DeleteFreeSKUFromInvoice(int p_Distributor_Id, long  p_Invoice_Id, long p_SalePromotionId, int p_SKU_id,int p_Qty)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDeleteFreeSKUOut mOrder = new UspDeleteFreeSKUOut();
                mOrder.Connection = mConnection;
                mOrder.Distributor_id = p_Distributor_Id;
                mOrder.InvoiceNo  = p_Invoice_Id;
                mOrder.SALE_INVOICE_PROMOTION_ID  = p_SalePromotionId;
                mOrder.SKU_id = p_SKU_id;
                mOrder.Qty = p_Qty;
                mOrder.ExecuteQuery();
                return true;
                
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
        /// Inserts Transport Expenses
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_SaleInvoiceId">Invoice</param>
        /// <param name="p_Transport_ID">Transport</param>
        /// <param name="p_Bilty_no">Builty</param>
        /// <param name="p_DilveryChallan">DeliveryChalan</param>
        /// <param name="p_Exp">Expenses</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PostTranspoterExp(int p_Distributor_id,long p_SaleInvoiceId, int p_Transport_ID, string p_Bilty_no,string p_DilveryChallan,decimal  p_Exp)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertDTINVOICE_BILLTY_DETAIL InsertExp = new spInsertDTINVOICE_BILLTY_DETAIL();
                InsertExp.Connection = mConnection;
                
                InsertExp.DISTRIBUTOR_ID = p_Distributor_id;
                InsertExp.SALE_INVOICE_NO = p_SaleInvoiceId;  
                InsertExp.TRANSPOTER_NO = p_Transport_ID;
                InsertExp.BILTY_NO = p_Bilty_no;
                InsertExp.DELIVERY_CHALLAN_NO = p_DilveryChallan;
                InsertExp.TOTAL_EXPENCESS = p_Exp;
                return InsertExp.ExecuteQuery();  
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Inserts Free SKU
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_SaleInvoiceId">Invoice</param>
        /// <param name="p_sku_ID">SKU</param>
        /// <param name="p_QUANTITY">Quantitiy</param>
        /// <param name="p_UNIT_PRICE">Price</param>
        /// <param name="p_AMOUNT">Amount</param>
        /// <param name="p_GST_RATE">GSTRate</param>
        /// <param name="p_GST_AMOUNT">GSTAmount</param>
        /// <param name="p_DocumentDate">Date</param>
        /// <param name="p_TstAmount">TSTAmount</param>
        /// <param name="p_SedAmount">SEDAmount</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool InsertFreeSKU(int p_Distributor_id, long p_SaleInvoiceId, int p_sku_ID, int p_QUANTITY, decimal p_UNIT_PRICE, decimal p_AMOUNT, float  p_GST_RATE, decimal p_GST_AMOUNT,DateTime p_DocumentDate,decimal p_TstAmount,decimal p_SedAmount)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                //----------------Insert into sale order Promotion-------------
                spInsertManualSALE_INVOICE_PROMOTION mSaleOrderPromo = new spInsertManualSALE_INVOICE_PROMOTION();
                mSaleOrderPromo.Connection = mConnection;
                mSaleOrderPromo.BASKET_DETAIL_ID = -1;
                mSaleOrderPromo.BASKET_ID = -1;
                mSaleOrderPromo.DISTRIBUTOR_ID = p_Distributor_id;
                mSaleOrderPromo.GST_AMOUNT = p_GST_AMOUNT ;
                mSaleOrderPromo.GST_RATE = p_GST_RATE;
                mSaleOrderPromo.PROMOTION_ID = -1;
                mSaleOrderPromo.PROMOTION_OFFER_ID = -1;
                mSaleOrderPromo.QUANTITY = p_QUANTITY ;
                mSaleOrderPromo.SKU_ID = p_sku_ID ;
                mSaleOrderPromo.UNIT_PRICE = p_UNIT_PRICE ;
                mSaleOrderPromo.SALE_INVOICE_ID = p_SaleInvoiceId;
                mSaleOrderPromo.AMOUNT = p_AMOUNT;
                mSaleOrderPromo.SED_AMOUNT = p_SedAmount;
                mSaleOrderPromo.TST_AMOUNT = p_TstAmount;  
                mSaleOrderPromo.ExecuteQuery();

                UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                mStockUpdate.Connection = mConnection;
                mStockUpdate.TYPE_ID = Constants.Document_Invoice;
                mStockUpdate.DISTRIBUTOR_ID = p_Distributor_id;
                mStockUpdate.STOCK_DATE = p_DocumentDate;
                mStockUpdate.SKU_ID = mSaleOrderPromo.SKU_ID;
                mStockUpdate.BATCHNO = "N/A";
                mStockUpdate.STOCK_QTY = 0;
                mStockUpdate.FREE_QTY = p_QUANTITY;
                mStockUpdate.ExecuteQuery();
              
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }

        #region Rollback

        /// <summary>
        /// Rollbacks Order, Invoice And Sale Return
        /// </summary>
        /// <param name="p_DocumentId">Document</param>
        /// <param name="p_Type_Id">Type</param>
        /// <param name="p_LegendId">Legend</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UpdateRollBackDocument(long p_DocumentId, int p_Type_Id, int p_LegendId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRollBackDocument mOrder = new UspRollBackDocument();
                mOrder.Connection = mConnection;
                mOrder.DOCUMENT_ID = p_DocumentId;
                mOrder.DOCUMENT_TYPE = p_Type_Id;
                mOrder.LEGEND_ID = p_LegendId;
                mOrder.ExecuteQuery();
                return true;

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

        public bool DeleteOrderDetail(long p_SALE_ORDER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
               



                spDeleteSALE_ORDER_DETAIL mSaleOrderDETAILDELETE = new spDeleteSALE_ORDER_DETAIL();
                mSaleOrderDETAILDELETE.Connection = mConnection;
               // mSaleOrderDETAILDELETE.Transaction = mTransaction;
                mSaleOrderDETAILDELETE.SALE_ORDER_ID = p_SALE_ORDER_ID;
               // mSaleOrderDETAILDELETE.SALE_ORDER_DETAIL_ID = Constants.LongNullValue;

                mSaleOrderDETAILDELETE.ExecuteQuery();

                return true;

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


        public bool DeleteInvoiceDetail(long p_SALE_INVOICE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                spDeleteSALE_INVOICE_DETAIL mSaleINVOICEDETAILDELETE = new spDeleteSALE_INVOICE_DETAIL();
                mSaleINVOICEDETAILDELETE.Connection = mConnection;
               //  mSaleOrderDETAILDELETE.Transaction = mTransaction;
                mSaleINVOICEDETAILDELETE.SALE_INVOICE_ID = p_SALE_INVOICE_ID;
               mSaleINVOICEDETAILDELETE.SALE_INVOICE_DETAIL_ID = Constants.LongNullValue;
             
                mSaleINVOICEDETAILDELETE.ExecuteQuery();

                return true;

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

        public bool DeleteOrderDetailPromotion(long p_SALE_ORDER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                
                spDeleteSALE_ORDER_PROMOTION mSaleOrderDETAILDELETE = new spDeleteSALE_ORDER_PROMOTION();
                mSaleOrderDETAILDELETE.Connection = mConnection;
                // mSaleOrderDETAILDELETE.Transaction = mTransaction;
                mSaleOrderDETAILDELETE.SALE_ORDER_ID = p_SALE_ORDER_ID;

                mSaleOrderDETAILDELETE.ExecuteQuery();

                return true;

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
    }

}

