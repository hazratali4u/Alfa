using System;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form To Take Order, Invoice And Sale Return(Step2)
/// </summary>
public partial class Forms_frmLoadPassReturn : System.Web.UI.Page
{
    #region Variables

    DataTable PurchaseSKU;
    static DataTable PurchaseSKU1;
    DataTable dtFreeSKU;
    private static int mCustomerTypeId;
    private static int mCustomerVolClassId;
    private int mTownId;
    private static int RowId;
    private static int UnitType;
    private static int OrderNo;
    private static int packsize;
   private static bool IsDamage = false;
   private static int PreIssuedUnits = 0;

    #endregion

    /// <summary>
    /// Page_Load Function Populates All Combos, Grids And ListBox On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    PurchaseController mPurchase = new PurchaseController();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnSaveOrder.Enabled = false;
            
            if (int.Parse(this.Session["SaleInvoiceID"].ToString()) != -1)
            {
                btnSaveOrder.Text = "UPDATE";
                int SaleInvoiceID = int.Parse(this.Session["SaleInvoiceID"].ToString());
                 //this.Session.Add("SaleOrderID", SaleOrderID);
                #region SALE Order MATER
                DataControl dc = new DataControl();
                DataTable dt = mPurchase.SelectPurchaseOrderDocumentNo2(Constants.LongNullValue, Constants.IntNullValue, 0, SaleInvoiceID);
                clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 1, 2, true);
                clsWebFormUtil.FillDropDownList(this.DrpPrincipal, dt, 5, 6, true);
                clsWebFormUtil.FillDropDownList(this.DrpRoute, dt,3, 4, true);
                clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, dt, 7, 8, true);
                clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, dt, 9, 10, true);
                
                txtnumGrossSale.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["TOTAL_AMOUNT"].ToString())),4).ToString();
                txtUnclaimAbleDiscount.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["UNCLAIMABLE_AMOUNT"].ToString())), 4).ToString();
                txtWholeSaleDiscount.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["WHOLESALE_DISCOUNT"].ToString())), 4).ToString();
                txtGSTAmount.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["GST_AMOUNT"].ToString())), 4).ToString();
                txtTSTAmount.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["TST_AMOUNT"].ToString())), 4).ToString();
                txtNetAmount.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["TOTAL_NET_VALUE"].ToString())), 4).ToString();
                txtBRD.Text = Math.Round(Convert.ToDecimal(dc.chkNull(dt.Rows[0]["BRD"].ToString())), 4).ToString();
                txtFuel.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["FUEL"].ToString())), 4).ToString();
                txtVisit.Text = dc.chkNull_0 (dt.Rows[0]["VISIT"].ToString());
                txtProductiveCall.Text = dc.chkNull_0 (dt.Rows[0]["PRODUCTIVE_CALL"].ToString());
                txtOpeningReading.Text = dc.chkNull_0 (dt.Rows[0]["OPENING_READING"].ToString());
                txtCloseReading.Text = dc.chkNull_0 (dt.Rows[0]["CLOSING_READING"].ToString());
                txtBillNoFrom.Text = dc.chkNull_0 (dt.Rows[0]["BILL_NO_FROM"].ToString());
                txtBillNoTo.Text = dc.chkNull_0 (dt.Rows[0]["BILL_NO_TO"].ToString());
                txtOtherDiscounts.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["OTHER_DISCOUNT"].ToString())), 4).ToString();
                txtTradeOffers.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["TRADE_OFFER"].ToString())), 4).ToString();
                txtFuel.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0 (dt.Rows[0]["FUEL"].ToString())), 4).ToString();
                txtClaimableDiscounts.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0(dt.Rows[0]["CLAIMABLE_DISCOUNT"].ToString())), 4).ToString();

                txtIncentive.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0(dt.Rows[0]["INCENTIVE"].ToString())), 4).ToString();
                txtRental.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0(dt.Rows[0]["RENTAL"].ToString())), 4).ToString();
                txtDisplay.Text = Math.Round(Convert.ToDecimal(dc.chkNull_0(dt.Rows[0]["DISPLAY"].ToString())), 4).ToString();
                drpDistributor.Enabled = false;
                DrpPrincipal.Enabled = false;
                DrpOrderBooker.Enabled = false;
                DrpDeliveryMan.Enabled = false;
                DrpRoute.Enabled = false;
                //txtVisit.Enabled = false;
                //txtProductiveCall.Enabled = false;
                //txtOpeningReading.Enabled = false;
                //txtCloseReading.Enabled = false;
                //txtBillNoFrom.Enabled = true;
                //txtBillNoTo.Enabled = true;


                #endregion
                #region Sale Order Detail
                this.CreatTable();
                DataTable  dt1 = mPurchase.SelectPurchaseOrderDetail2(SaleInvoiceID);
                Session.Add("PurchaseSKU", dt1);
                this.LoadGird();
                this.LoadSKUDetail();
                btnCalculate.Enabled = true;

                decimal TotalDamageValue = 0;
                decimal TotalActualDamageValue = 0;
                decimal TotalSchemeValue = 0;
                decimal TotalWeight = 0;
                foreach (DataRow dr in dt1.Rows)
                {
                    TotalDamageValue += ((decimal.Parse(dc.chkNull_0(dr["DAMAGE_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
                    TotalActualDamageValue += ((decimal.Parse(dc.chkNull_0(dr["Actual_DAMAGE_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
                    TotalSchemeValue += ((decimal.Parse(dc.chkNull_0(dr["SCHEME_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
                    TotalWeight += ((decimal.Parse(dc.chkNull_0(dr["GROSS_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["SKU_Weight"].ToString()))));
                    if (decimal.Parse(dc.chkNull_0(dr["DAMAGE_UNITS"].ToString())) > 0)
                    {
                        IsDamage = true;
                    }
                }
              
                #endregion
                txtTotalDamageValue.Text = Math.Round(TotalDamageValue, 4).ToString();
                txtTotalActualDamageValue.Text = Math.Round(TotalActualDamageValue, 4).ToString();
                txtTotalSchemeValue.Text = Math.Round(TotalSchemeValue, 4).ToString();
                txtNumGrossWeight.Text =Math.Round(TotalWeight/1000, 2).ToString();
               
            }
            else
            {
             this.LoadDistributor();
             this.LoadPrincipal();
             this.LoadArea();
             this.LoadOrderBooker();
             this.LoadDeliveryman();
             this.LoadSKUDetail();
             this.CreatTable();
            }

            ReadOnlyControlls();
            
           
            btnSaveOrder.Attributes.Add("onclick", "return ValidateSaveOrder();");
           
           
        }
      //  btnSaveOrder.Enabled = false;
    }
    private void ReadOnlyControlls()
    {
        txtNumGrossWeight.Attributes.Add("ReadOnly", "ReadOnly");
        txtnumGrossSale.Attributes.Add("ReadOnly", "ReadOnly");
        txtTotalDamageValue.Attributes.Add("ReadOnly", "ReadOnly");
        txtTotalSchemeValue.Attributes.Add("ReadOnly", "ReadOnly");
        txtClaimableDiscounts.Attributes .Add("ReadOnly", "ReadOnly");
        txtGSTAmount.Attributes.Add("ReadOnly", "ReadOnly");
        txtTSTAmount.Attributes.Add("ReadOnly", "ReadOnly");
        txtNetAmount.Attributes.Add("ReadOnly", "ReadOnly");

    }
    private void LoadDistributor()
    {
        int x = int.Parse(this.Session["CompanyId"].ToString());
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);

    }
    private void LoadPrincipal()
    {

        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadArea()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0 && DrpPrincipal.Items.Count > 0)
        {
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()), Convert.ToInt32(DrpPrincipal.SelectedValue));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 3, true);
        }
        else
        {
            DrpOrderBooker.Items.Clear();
        }
    }
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
        }
    }


    private void CreatTable()
    {
        PurchaseSKU = new DataTable();
        PurchaseSKU.Columns.Add("SALE_ORDER_DETAIL_ID", typeof(long));
        PurchaseSKU.Columns.Add("DistributorId", typeof(int));
        PurchaseSKU.Columns.Add("SALE_ORDER_ID", typeof(int));
        PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
        PurchaseSKU.Columns.Add("SKU_CODE", typeof(string));
        PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        PurchaseSKU.Columns.Add("BATCH_NO", typeof(string));
        PurchaseSKU.Columns.Add("UNIT_PRICE", typeof(decimal));

        PurchaseSKU.Columns.Add("ISSUE_CTN", typeof(int));
        PurchaseSKU.Columns.Add("ISSUE_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("RETURN_CTN", typeof(int));
        PurchaseSKU.Columns.Add("RETURN_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("GROSS_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("DAMAGE_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("Actual_DAMAGE_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("SCHEME_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("NET_SALE_CTN", typeof(int));
        PurchaseSKU.Columns.Add("NET_SALE", typeof(int));
        PurchaseSKU.Columns.Add("NET_VALUE", typeof(decimal));
        PurchaseSKU.Columns.Add("TOTAL_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("PACKING", typeof(string));
        PurchaseSKU.Columns.Add("RETURN_EMPTY_UNITS", typeof(int));
        PurchaseSKU.Columns.Add("FUEL", typeof(decimal));
        PurchaseSKU.Columns.Add("GST_RATE_TP", typeof(decimal));
        
        PurchaseSKU.Columns.Add("UNITS_IN_CASE", typeof(int));
        PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("STANDARD_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("STANDARD_DISCOUNT_PER", typeof(decimal));
        PurchaseSKU.Columns.Add("EXTRA_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("RETAIL_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("GST_RATE", typeof(decimal));
        PurchaseSKU.Columns.Add("GST_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("TST_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("CLAIM_EXTRA_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("CLAIM_STANDARD_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("CLAIM_PER", typeof(decimal));
        PurchaseSKU.Columns.Add("SED_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("NET_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("QUANTITY_CTN", typeof(decimal));
        PurchaseSKU.Columns.Add("IS_DELETED", typeof(bool));

        PurchaseSKU.Columns.Add("TOTAL_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("UNCLAIMABLE_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("WHOLESALE_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("BRD", typeof(decimal));
        PurchaseSKU.Columns.Add("TRADE_OFFERS", typeof(decimal));
        PurchaseSKU.Columns.Add("OTHER_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("CLAIMABLE_DISCOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("SKU_Weight", typeof(decimal));
        this.Session.Add("PurchaseSKU", PurchaseSKU);

        PurchaseSKU1 = new DataTable();
        PurchaseSKU1.Columns.Add("SKU_CODE", typeof(string));
        this.Session.Add("PurchaseSKU1", PurchaseSKU1);
    }

    private void CreateFreeSKU()
    {
        dtFreeSKU = new DataTable();
        dtFreeSKU.Columns.Add("SKU_ID", typeof(int));
        dtFreeSKU.Columns.Add("SKU_Code", typeof(string));
        dtFreeSKU.Columns.Add("SKU_Name", typeof(string));
        dtFreeSKU.Columns.Add("UNIT_PRICE", typeof(decimal));
        dtFreeSKU.Columns.Add("Quantity", typeof(int));
        dtFreeSKU.Columns.Add("AMOUNT", typeof(decimal));
        dtFreeSKU.Columns.Add("GST_RATE", typeof(decimal));
        dtFreeSKU.Columns.Add("GST_AMOUNT", typeof(decimal));
        dtFreeSKU.Columns.Add("TST_AMOUNT", typeof(decimal));
        dtFreeSKU.Columns.Add("PROMOTION_ID", typeof(int));
        dtFreeSKU.Columns.Add("BASKET_ID", typeof(int));
        dtFreeSKU.Columns.Add("BASKET_DETAIL_ID", typeof(int));
        dtFreeSKU.Columns.Add("PROMOTION_OFFER_ID", typeof(int));
        this.Session.Add("dtFreeSKU", dtFreeSKU);
    }

    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (int.Parse(DrpPrincipal.SelectedValue.ToString()) > 0)
        {
            int x = int.Parse(DrpPrincipal.SelectedValue.ToString());
            int y = int.Parse(drpDistributor.SelectedValue.ToString());
            int z = int.Parse(this.Session["UserId"].ToString());
            DateTime d = DateTime.Parse(this.Session["CurrentWorkDate"].ToString());
            //   DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(this.Session["PrincipalId"].ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["DistributorId"].ToString()), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            DataTable Dtsku_Price = PController.SelectDataPrice2(int.Parse(DrpPrincipal.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));

           // clsWebFormUtil.FillDropDownList( this.ddlSKuCde , Dtsku_Price,0,9, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }

  
 
    private void LoadGird()
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        GrdPurchase.DataSource = PurchaseSKU;
        GrdPurchase.DataBind();
    }

    
    


   

    private void ClearAll()
    {
        txtNetAmount.Text = "";
        btnSaveOrder.Enabled = false;
        btnCalculate.Enabled = true;
    }

    /// <summary>
    /// Clears All Controls
    /// </summary>
    private void ClearMasterALL()
    {
      
        this.Session.Remove("PurchaseSKU");
        this.Session.Remove("dtFreeSKU");
        this.CreatTable();
        this.CreateFreeSKU();
        this.LoadGird();
        
        txtGrossAmount.Text = "";
        txtnumGrossSale.Text = "";
        txtUnclaimAbleDiscount.Text = "";
        txtWholeSaleDiscount.Text = "";
        txtBRD.Text = "";
        txtTradeOffers.Text = "";
        txtOtherDiscounts.Text = "";
        txtClaimableDiscounts.Text = "";
        txtIncentive.Text = "";
        txtRental.Text = "";
        txtDisplay.Text = "";
        txtGSTAmount.Text = "";
        txtTSTAmount.Text = "";
        txtNetAmount.Text = "";
        txtVisit.Text = "";
        txtProductiveCall.Text = "";
        txtOpeningReading.Text = "";
        txtCloseReading.Text = "";
        txtBillNoFrom.Text = "";
        txtBillNoTo.Text = "";
        btnSaveOrder.Enabled = false;
        txtTotalActualDamageValue.Text = "";
        numtxtTotalExtraDiscnt.Text = "";
        numTxtTotalStndrdDiscnt.Text = "";
        numTxtTotalGST.Text = "";
        numTxtTotlAmnt.Text = "";
        numTxtTotalSED.Text = "";
        numTxtTotalTST.Text = "";
        numTxtTotalSED.Text = "";
        txtTotalDamageValue.Text = "";
        txtTotalSchemeValue.Text = "";
        txtNumGrossWeight.Text = "";
        txtFuel.Text = "";
        numtxtUnClaimabledist.Text = "";
        RowId = 0;
        mCustomerTypeId = 0;
        mCustomerVolClassId = 0;
        txtCashReceived.Text = "";
        this.Session.Remove("SaleInvoiceID");
        ScriptManager.GetCurrent(Page).SetFocus(txtVisit);
        
    }

    private bool IsDayClosed()
    {
        bool flag = false;
        DistributorController DistrCtl = new DistributorController();
        DataTable dtDayClose = DistrCtl.MaxDayClose(int.Parse(drpDistributor.SelectedValue.ToString()), 3);
        return flag = Convert.ToDateTime(Session["CurrentWorkDate"]) != Convert.ToDateTime(dtDayClose.Rows[0]["DayClose"]);

       
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadOrderBooker();
        this.LoadDeliveryman();
        this.LoadSKUDetail();
        this.Session.Add("DistributorId", int.Parse(drpDistributor.SelectedValue.ToString()));
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
        this.Session.Add("PrincipalId", int.Parse(DrpPrincipal.SelectedValue.ToString()));
        this.LoadSKUDetail();
        this.LoadDeliveryman();
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Session.Add("Route", DrpRoute.SelectedItem.Text);
        this.LoadOrderBooker();
        this.LoadDeliveryman();
    }
    protected void DrpOrderBooker_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Session.Add("OrderBookerId", int.Parse(DrpOrderBooker.SelectedValue.ToString()));
    }
   
    protected void DrpDeliveryMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Session.Add("DeliveryManId", int.Parse(DrpDeliveryMan.SelectedValue));
    }

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        btnCalculate_Click(null, null);
        var pc = new PurchaseController();
      var loadpass=  pc.selectLoadPassDocumentNo( int.Parse(drpDistributor.SelectedValue),int.Parse(DrpRoute.SelectedValue), long.Parse(DrpRoute.SelectedValue), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpOrderBooker.SelectedValue.ToString()), Constants .IntNullValue,DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        var Sale_Order_ID = Constants.LongNullValue;
        if (IsDayClosed())
        {
            var userCtl = new UserController();

            userCtl.InsertUserLogoutTime(int.Parse(drpDistributor.SelectedValue), Convert.ToInt32(Session["UserID"]));
            this.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../Login.aspx");
        }
        
        else
        {
            
            string manualId = null;
           
            var dc = new DataControl();
            PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
            dtFreeSKU = (DataTable)this.Session["dtFreeSKU"];
            var mOrderController = new OrderEntryController();
            if (btnSaveOrder.Text == "Save")
            {



                if (loadpass.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                        "alert('Load Pass Already Exist against this Delivery Man');",
                                                        true);

                }
                else
                {
                    #region Sale Invoice Portion

                    /////////////////////////////////////////////////////////////////// Invoice Portion///////////////////////// 


                    #region Stock Check

                    // Placed to Add Sku Btn

                    //foreach (DataRow dr in PurchaseSKU.Rows)
                    //{
                    //    PhaysicalStockController mController = new PhaysicalStockController();
                    //    DataTable dtstock = mController.SelectSKUClosingStock(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(dr["SKU_ID"].ToString()), "", DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                    //    if (dtstock.Rows.Count > 0)
                    //    {
                    //        if (int.Parse(dtstock.Rows[0][0].ToString()) < int.Parse(dr["ISSUE_UNITS"].ToString()))
                    //        {
                    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + dr["SKU_Code"].ToString() + " Current Stock is " + dtstock.Rows[0][0].ToString() + "');", true);
                    //            return;
                    //        }
                    //        //else if (Convert.ToDecimal(dtstock.Rows[0][1]) != Convert.ToDecimal(dr["UNIT_PRICE"]))
                    //        //{
                    //        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + dr["SKU_Code"].ToString() + " Order Rate is " + dr["UNIT_PRICE"].ToString() + " and Current Rate is " + dtstock.Rows[0][1].ToString() + "');", true);
                    //        //    return;
                    //        //}
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' + " + dr["SKU_Code"].ToString() + "No Stock Found');", true);
                    //        return;
                    //    }
                    //}

                    #endregion

                    //bool IsValidInsert1 = mOrderController.Add_Invoice(int.Parse(drpDistributor.SelectedValue.ToString()), ManualID, int.Parse(DrpRoute.SelectedValue.ToString()), long.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), 0, 0, int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()), 0,
                    //           decimal.Parse(DC.chkNull_0(txtnumGrossSale.Text)), decimal.Parse(DC.chkNull_0(txtUnclaimAbleDiscount.Text)), decimal.Parse(DC.chkNull_0(txtWholeSaleDiscount.Text)), decimal.Parse(DC.chkNull_0(txtBRD.Text)), decimal.Parse(DC.chkNull_0(txtGSTAmount.Text)), decimal.Parse(DC.chkNull_0(txtNetAmount.Text)), decimal.Parse(DC.chkNull_0(txtOtherDiscounts.Text)), Constants.Order_Pending_Id, PurchaseSKU, dtFreeSKU, int.Parse(this.Session["UserId"].ToString()), decimal.Parse(DC.chkNull_0(txtCashReceived.Text)), DateTime.Parse(this.Session["OrderDate"].ToString()), decimal.Parse(DC.chkNull_0(txtTradeOffers.Text)), decimal.Parse(DC.chkNull_0(txtTSTAmount.Text)));

                    var isValidInsert1 = mOrderController.Add_Invoice1(int.Parse(drpDistributor.SelectedValue), manualId,
                                                                       int.Parse(DrpRoute.SelectedValue.ToString()),
                                                                       long.Parse(DrpRoute.SelectedValue.ToString()),
                                                                       int.Parse(DrpPrincipal.SelectedValue.ToString()),
                                                                       0, 0,
                                                                       int.Parse(DrpOrderBooker.SelectedValue.ToString()),
                                                                       int.Parse(DrpDeliveryMan.SelectedValue.ToString()),
                                                                       0,
                                                                       decimal.Parse(dc.chkNull_0(txtnumGrossSale.Text)),
                                                                       decimal.Parse(
                                                                           dc.chkNull_0(txtUnclaimAbleDiscount.Text)),
                                                                       decimal.Parse(
                                                                           dc.chkNull_0(txtClaimableDiscounts.Text)),
                                                                       decimal.Parse(dc.chkNull_0(txtBRD.Text)),
                                                                       decimal.Parse(dc.chkNull_0(txtGSTAmount.Text)),
                                                                       decimal.Parse(dc.chkNull_0(txtNetAmount.Text)),
                                                                       decimal.Parse(dc.chkNull_0(txtOtherDiscounts.Text)),
                                                                       Constants.Order_Posted_Id, PurchaseSKU, dtFreeSKU,
                                                                       int.Parse(this.Session["UserId"].ToString()), 0,
                                                                       DateTime.Parse(
                                                                           this.Session["CurrentWorkDate"].ToString()),
                                                                       decimal.Parse(dc.chkNull_0(txtTradeOffers.Text)),
                                                                       decimal.Parse(dc.chkNull_0(txtTSTAmount.Text)),
                                                                       int.Parse(dc.chkNull_0(txtVisit.Text)),
                                                                       int.Parse(dc.chkNull_0(txtProductiveCall.Text)),
                                                                       int.Parse(dc.chkNull_0(txtOpeningReading.Text)),
                                                                       int.Parse(dc.chkNull_0(txtCloseReading.Text)),
                                                                       int.Parse(dc.chkNull_0(txtBillNoFrom.Text)),
                                                                       int.Parse(dc.chkNull_0(txtBillNoTo.Text)),
                                                                       decimal.Parse(dc.chkNull_0(txtFuel.Text)),
                                                                       decimal.Parse(
                                                                           dc.chkNull_0(txtWholeSaleDiscount.Text)),
                                                                       decimal.Parse(
                                                                           dc.chkNull_0(txtTotalDamageValue.Text)),
                                                                       IsDamage,
                                                                       decimal.Parse(
                                                                           dc.chkNull_0(txtTotalActualDamageValue.Text))
                                                                            , decimal.Parse(dc.chkNull_0(txtIncentive.Text)), decimal.Parse(dc.chkNull_0(txtRental.Text))
                   , decimal.Parse(dc.chkNull_0(txtDisplay.Text))
                                                                           );



                    if (isValidInsert1)
                    {
                        this.ClearMasterALL();
                        try
                        {
                            Response.Redirect("~/Forms/frmLoadPassEntry.aspx?Status=" + false + "&LevelType=3&LevelID=" +
                                              Request.QueryString["LevelID"].ToString());
                        }
                        catch (Exception ex)
                        {
                            //   Response.Redirect("Forms/Home.aspx");

                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                            "alert('Please Try Again !');",
                                                            true);     
                    }
                

                    #endregion
                }



            }
            else
            {
                if (btnSaveOrder.Text == "UPDATE")
                {
                    #region saleInvoice Master/detail Updation
                    var isValidInsert1 = mOrderController.Update_Invoice(long.Parse(this.Session["SaleInvoiceID"].ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), manualId, int.Parse(DrpRoute.SelectedValue.ToString()), long.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), 0, 0, int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()), Sale_Order_ID,
                   decimal.Parse(dc.chkNull_0(txtnumGrossSale.Text)), decimal.Parse(dc.chkNull_0(txtUnclaimAbleDiscount.Text)), decimal.Parse(dc.chkNull_0(txtClaimableDiscounts.Text)), decimal.Parse(dc.chkNull_0(txtBRD.Text)), decimal.Parse(dc.chkNull_0(txtGSTAmount.Text)), decimal.Parse(dc.chkNull_0(txtNetAmount.Text)), decimal.Parse(dc.chkNull_0(txtOtherDiscounts.Text)), Constants.Order_Posted_Id, PurchaseSKU, dtFreeSKU, int.Parse(this.Session["UserId"].ToString()), Constants.DecimalNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), decimal.Parse(dc.chkNull_0(txtTradeOffers.Text)), decimal.Parse(dc.chkNull_0(txtTSTAmount.Text)), int.Parse(dc.chkNull_0(txtVisit.Text)), int.Parse(dc.chkNull_0(txtProductiveCall.Text)), int.Parse(dc.chkNull_0(txtOpeningReading.Text)), int.Parse(dc.chkNull_0(txtCloseReading.Text)), int.Parse(dc.chkNull_0(txtBillNoFrom.Text)), int.Parse(dc.chkNull_0(txtBillNoTo.Text)), decimal.Parse(dc.chkNull_0(txtFuel.Text)), decimal.Parse(dc.chkNull_0(txtWholeSaleDiscount.Text)), decimal.Parse(dc.chkNull_0(txtTotalDamageValue.Text)), IsDamage, decimal.Parse(dc.chkNull_0(txtTotalActualDamageValue.Text))
                   , decimal.Parse(dc.chkNull_0(txtIncentive.Text)), decimal.Parse(dc.chkNull_0(txtRental.Text))
                   , decimal.Parse(dc.chkNull_0(txtDisplay.Text))
                   );
                    if (isValidInsert1)
                    {

                        this.ClearMasterALL();

                        try
                        {
                            Response.Redirect("~/Forms/frmLoadPassEntry.aspx?Status=" + false + "&LevelType=3&LevelID=" +
                                              Request.QueryString["LevelID"].ToString(CultureInfo.InvariantCulture));
                        }
                        catch (Exception ex)
                        {
                           // Response.Redirect("Forms/Home.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                            "alert('Please Try Again !');",
                                                            true);
                    }
                    #endregion
                }
            }
       }

    }
    
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        decimal ObjTotalWeight = 0;
        decimal ObjGrossSales = 0;
        decimal ObjTotalDamageValue = 0;
        decimal ObjTotalActualDamageValue = 0;
        decimal ObjTotalSchemeValue = 0;
        decimal ObjTotalGST = 0;
        decimal ObjTotalTST = 0;
        DataControl dc = new DataControl();
        DataTable dt = (DataTable)this.Session["PurchaseSKU"];
        foreach (DataRow dr in dt.Rows)
        {
            foreach (GridViewRow drw in GrdPurchase.Rows)
            {
                if (dr["SKU_ID"].ToString() == drw.Cells[0].Text)
                {
                    #region Update Table
                    TextBox txtReturnCtn = (TextBox)drw.Cells[7].FindControl("txtReturnCtn");
                    TextBox txtReturnUnits = (TextBox)drw.Cells[8].FindControl("txtReturnUnits");
                    TextBox txtGrossUnits = (TextBox)drw.Cells[9].FindControl("txtGrossUnits");
                    TextBox txtDamageUnits = (TextBox)drw.Cells[10].FindControl("txtDamageUnits");
                    TextBox txtActDamageUnits = (TextBox)drw.Cells[11].FindControl("txtActDamageUnits");
                    TextBox txtSchemeUnits = (TextBox)drw.Cells[12].FindControl("txtSchemeUnits");
                    TextBox txtNetSaleCtn = (TextBox)drw.Cells[13].FindControl("txtNetSaleCtn");
                    TextBox txtNetSale = (TextBox)drw.Cells[14].FindControl("txtNetSale");
                    TextBox txtNetValue = (TextBox)drw.Cells[15].FindControl("txtNetValue");

                    int UIC = int.Parse(dr["UNITS_IN_CASE"].ToString());
                    decimal TP = decimal.Parse(dr["UNIT_PRICE"].ToString());
                    int IssueCtn = int.Parse(dr["ISSUE_CTN"].ToString());
                    int IssueUnits = int.Parse(dr["ISSUE_UNITS"].ToString());
                    dr["RETURN_CTN"] = txtReturnCtn.Text;
                    dr["RETURN_UNITS"] = txtReturnUnits.Text;
                    dr["GROSS_UNITS"] = (((IssueCtn * UIC) + IssueUnits) - (int.Parse(dc.chkNull_0(txtReturnCtn.Text)) * UIC + int.Parse(dc.chkNull_0(txtReturnUnits.Text)))).ToString();
                    dr["DAMAGE_UNITS"] = txtDamageUnits.Text;
                    dr["Actual_DAMAGE_UNITS"] = txtActDamageUnits.Text;
                    dr["SCHEME_UNITS"] = txtSchemeUnits.Text;
                    dr["NET_SALE_CTN"] = ((int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dc.chkNull_0(txtDamageUnits.Text)) - int.Parse(dc.chkNull_0(txtActDamageUnits.Text)) - int.Parse(dc.chkNull_0(txtSchemeUnits.Text))) / UIC).ToString();
                    dr["NET_SALE"] = ((int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dc.chkNull_0(txtDamageUnits.Text)) - int.Parse(dc.chkNull_0(txtActDamageUnits.Text)) - int.Parse(dc.chkNull_0(txtSchemeUnits.Text))) % UIC).ToString();
                    dr["NET_VALUE"] = ((int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dc.chkNull_0(txtDamageUnits.Text)) - int.Parse(dc.chkNull_0(txtActDamageUnits.Text)) - int.Parse(dc.chkNull_0(txtSchemeUnits.Text))) * TP).ToString();


                    #endregion
                }
            }

        }
        foreach (DataRow dr in dt.Rows)
        {
            ObjGrossSales += ((decimal.Parse(dc.chkNull_0(dr["GROSS_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
            ObjTotalDamageValue += ((decimal.Parse(dc.chkNull_0(dr["DAMAGE_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
            ObjTotalActualDamageValue += ((decimal.Parse(dc.chkNull_0(dr["Actual_DAMAGE_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
            ObjTotalSchemeValue += ((decimal.Parse(dc.chkNull_0(dr["SCHEME_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["UNIT_PRICE"].ToString()))));
            ObjTotalWeight += ((decimal.Parse(dc.chkNull_0(dr["GROSS_UNITS"].ToString()))) * (decimal.Parse(dc.chkNull_0(dr["SKU_Weight"].ToString()))));
            #region GST Calculation
            decimal TempAmount = 0;


            TempAmount = decimal.Parse(dc.chkNull_0(dr["NET_VALUE"].ToString()));

            dr["GST_AMOUNT"] = (TempAmount) * decimal.Parse(dc.chkNull_0(dr["GST_RATE"].ToString())) / 100;
            ObjTotalTST += decimal.Parse(dc.chkNull_0(dr["TST_AMOUNT"].ToString()));
            ObjTotalGST += decimal.Parse(dc.chkNull_0(dr["GST_AMOUNT"].ToString()));

            #endregion
            if (decimal.Parse(dc.chkNull_0(dr["DAMAGE_UNITS"].ToString())) > 0)
            {
                IsDamage = true;
            }
        }
        txtNumGrossWeight.Text = Math.Round(ObjTotalWeight/1000, 2).ToString();// Devided by 1000 to show in Ltr
        txtnumGrossSale.Text =Math .Round (ObjGrossSales,4).ToString();
        txtGSTAmount.Text = Convert.ToString(Math.Round(ObjTotalGST, 4));
        txtTSTAmount.Text = Convert.ToString(Math.Round(ObjTotalTST, 4));
        txtTotalDamageValue.Text = Convert.ToString(Math.Round(ObjTotalDamageValue, 4));
        txtTotalSchemeValue.Text = Convert.ToString(Math.Round(ObjTotalSchemeValue, 4));
        txtTotalActualDamageValue.Text = Convert.ToString(Math.Round(ObjTotalActualDamageValue, 4));
        txtClaimableDiscounts.Text = Math.Round(decimal.Parse(dc.chkNull_0(txtWholeSaleDiscount.Text)) + decimal.Parse(dc.chkNull_0(txtBRD.Text)) + decimal.Parse(dc.chkNull_0(txtTradeOffers.Text)) + decimal.Parse(dc.chkNull_0(txtOtherDiscounts.Text)) + decimal.Parse(dc.chkNull_0(txtIncentive.Text)) + decimal.Parse(dc.chkNull_0(txtRental.Text)) + decimal.Parse(dc.chkNull_0(txtDisplay.Text)), 4).ToString();
        txtNetAmount.Text = Math.Round(decimal.Parse(dc.chkNull_0(txtnumGrossSale.Text)) - decimal.Parse(dc.chkNull_0(txtUnclaimAbleDiscount.Text)) - decimal.Parse(dc.chkNull_0(txtClaimableDiscounts.Text)) + decimal.Parse(dc.chkNull_0(txtGSTAmount.Text)) + decimal.Parse(dc.chkNull_0(txtTSTAmount.Text)) - decimal.Parse(dc.chkNull_0(txtFuel.Text)) - decimal.Parse(dc.chkNull_0(txtTotalDamageValue.Text)) - decimal.Parse(dc.chkNull_0(txtTotalActualDamageValue.Text)) - decimal.Parse(dc.chkNull_0(txtTotalSchemeValue.Text)), 4).ToString();
        btnSaveOrder.Enabled = true;
        this.Session.Add("PurchaseSKU", dt);
        LoadGird();
    }
   
}




   