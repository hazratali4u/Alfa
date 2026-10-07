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
public partial class Forms_frmLoadPass : System.Web.UI.Page
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
            
            btnAddSku.Attributes.Add("onclick", "return ValidateForm();");
            btnSaveOrder.Attributes.Add("onclick", "return ValidateSaveOrder();");
           
            txtUnitsInCase.Style.Add("display", "none");
            ddlSKuCde_SelectedIndexChanged(null, null);
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

            clsWebFormUtil.FillDropDownList( this.ddlSKuCde , Dtsku_Price,0,9, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }

  
 
    private void LoadGird()
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        GrdPurchase.DataSource = PurchaseSKU;
        GrdPurchase.DataBind();
    }

    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        ddlSKuCde.SelectedValue = GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text;
        ddlSKuCde.Enabled = false;
        btnAddSku.Text = "Update SKU";
        btnCalculate.Enabled = false;
        btnSaveOrder.Enabled = false;
        //txtskuName.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtPacking.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        txtTP.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        txtIssueCtn.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        txtIssueUnits.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[6].Text;
        txtReturnCTN.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[7].Text;
        txtReturnUnits.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[8].Text;
        txtReturnEmpty.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[9].Text;
        txtGrossSaleUnits.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[10].Text;
        txtDamegeUnits.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[11].Text;
        txtActualDamageUnit.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[12].Text;
        txtSchemeUnits.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[13].Text;
        txtNetSaleCTN.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[14].Text;
        txtNetSaleUnits.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[15].Text;
        txtNetValue.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[16].Text;
        txtUnitsInCase.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[19].Text;

        PreIssuedUnits = int.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text) * int.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[19].Text);

    }
    

    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        PurchaseSKU.Rows.RemoveAt(e.RowIndex);
        this.Session.Add("PurchaseSKU", PurchaseSKU);
        this.LoadGird();
        btnCalculate.Enabled = true;
        btnSaveOrder.Enabled = false;
    }
  
    private void ClearAll()
    {
        ddlSKuCde.SelectedIndex = 0;
       // txtskuName.Text = "";
        txtPacking.Text = "";
        txtTP.Text = "";
        txtIssueCtn.Text = "";
        txtReturnCTN.Text = "";
        txtIssueUnits.Text = "";
        txtReturnUnits.Text = "";
        txtGrossSaleUnits.Text = "";
        txtDamegeUnits.Text = "";
        txtSchemeUnits.Text = "";
        txtNetSaleUnits.Text = "";
        txtNetSaleCTN.Text = "";
        txtNetAmount.Text = "";
        txtNetValue.Text = "";
        txtReturnEmpty.Text = "";
        btnAddSku.Text = "Add Sku";
        btnSaveOrder.Enabled = false;
        btnCalculate.Enabled = true;
        ddlSKuCde .Enabled = true;
        txtActualDamageUnit.Text = "";
        ScriptManager.GetCurrent(Page).SetFocus(ddlSKuCde );
    }

    /// <summary>
    /// Clears All Controls
    /// </summary>
    private void ClearMasterALL()
    {
        EnableDisableController(true);
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
    protected void btnAddSku_Click(object sender, EventArgs e)
    {
        DataControl dc = new DataControl();
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + ddlSKuCde .SelectedValue + "'");
        decimal mTradePrice = decimal.Parse(dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString()));
        int mPackSize = int.Parse(dc.chkNull_0(foundRows[0]["UNITS_IN_CASE"].ToString()));
        //packsize use in txtissuectn textchange event
        packsize = mPackSize;
        #region Btn text Add Sku
        
        if (btnAddSku.Text == "Add Sku")
        {
            if (CheckDublicateSku())
            {

                #region Stock Check 
                
                    var mController = new PhaysicalStockController();
                    DataTable dtstock = mController.SelectSKUClosingStock(int.Parse(drpDistributor.SelectedValue), int.Parse(foundRows[0]["SKU_ID"].ToString()), "", DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                    if (dtstock != null && dtstock.Rows.Count > 0)
                    {
                        if (int.Parse(dtstock.Rows[0][0].ToString()) < int.Parse(dc.chkNull_0(txtIssueUnits.Text)) +(int.Parse(dc.chkNull_0(txtIssueCtn.Text)) * int.Parse(foundRows[0]["UNITS_IN_CASE"].ToString())))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + foundRows[0]["SKU_NAME"] + " Current Stock is " + int.Parse(dtstock.Rows[0][0].ToString()) / int.Parse(foundRows[0]["UNITS_IN_CASE"].ToString()) + " CTN');", true);
                            return;
                        }
                        //else if (Convert.ToDecimal(dtstock.Rows[0][1]) != Convert.ToDecimal(dr["UNIT_PRICE"]))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + dr["SKU_Code"].ToString() + " Order Rate is " + dr["UNIT_PRICE"].ToString() + " and Current Rate is " + dtstock.Rows[0][1].ToString() + "');", true);
                        //    return;
                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' + " + foundRows[0]["SKU_NAME"] + "No Stock Found');", true);
                        return;
                    }
                

                #endregion

                DataRow dr = PurchaseSKU.NewRow();
                dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                dr["PACKING"] = foundRows[0]["PACKSIZE"];
                dr["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                dr["SKU_Weight"] = foundRows[0]["SKU_Weight"];
                dr["UNITS_IN_CASE"] = foundRows[0]["UNITS_IN_CASE"];

                dr["GST_RATE"] = foundRows[0]["GST_RATE_TP"];

                dr["ISSUE_CTN"] = int.Parse(dc.chkNull_0(txtIssueCtn.Text));
                dr["ISSUE_UNITS"] = int.Parse(dc.chkNull_0(txtIssueUnits.Text));
                dr["RETURN_CTN"] = int.Parse(dc.chkNull_0(txtReturnCTN.Text));
                dr["RETURN_UNITS"] = int.Parse(dc.chkNull_0(txtReturnUnits.Text));
                dr["RETURN_EMPTY_UNITS"] = int.Parse(dc.chkNull_0(txtReturnEmpty.Text));
                dr["GROSS_UNITS"] = (int.Parse(dr["ISSUE_CTN"].ToString()) * packsize) + int.Parse(dr["ISSUE_UNITS"].ToString()) - int.Parse(dr["RETURN_UNITS"].ToString()) - (int.Parse(dr["RETURN_CTN"].ToString()) * packsize);
                dr["DAMAGE_UNITS"] = int.Parse(dc.chkNull_0(txtDamegeUnits.Text));
                dr["Actual_DAMAGE_UNITS"] = int.Parse(dc.chkNull_0(txtActualDamageUnit.Text));
                dr["SCHEME_UNITS"] = int.Parse(dc.chkNull_0(txtSchemeUnits.Text));
                decimal TotalSale = int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dr["DAMAGE_UNITS"].ToString()) - int.Parse(dr["SCHEME_UNITS"].ToString()) - int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());
               
                //dr["NET_SALE"] = int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dr["DAMAGE_UNITS"].ToString()) - int.Parse(dr["SCHEME_UNITS"].ToString());

                dr["NET_SALE_CTN"] =Math.Floor( TotalSale / mPackSize);
                dr["NET_SALE"] = TotalSale % mPackSize;
                

                dr["NET_VALUE"] = TotalSale * decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString());
                #region GST


                if (foundRows[0]["GST_ON"].ToString().Trim() == "T")
                {   
                    dr["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                    dr["TST_AMOUNT"] = 0;
                    dr["BATCH_NO"] = "T";

                }
                else if (foundRows[0]["GST_ON"].ToString().Trim() == "R")
                {
                 // dr["TST_AMOUNT"] = decimal.Parse(foundRows[0]["GST_RATE_TP"].ToString()) * decimal.Parse(dr["NET_SALE"].ToString());
                    dr["TST_AMOUNT"] = decimal.Parse(foundRows[0]["GST_RATE_TP"].ToString()) * TotalSale;
                    dr["GST_RATE"] = 0;
                    dr["BATCH_NO"] = "R";

                }
                else
                {
                    dr["TST_AMOUNT"] = 0;
                    dr["GST_RATE"] = 0;
                    dr["BATCH_NO"] = "E";
                }
                #endregion

                if (int.Parse(dc.chkNull_0(txtDamegeUnits.Text)) > 0)
                {
                    IsDamage = true;
                }
                PurchaseSKU.Rows.Add(dr);
               
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('SKU Already Exists')", true);
            }
        }
        #endregion
        #region btn update Sku
        else
        {
            #region Stock Check

            var mController = new PhaysicalStockController();
            var dtstock = mController.SelectSKUClosingStock(int.Parse(drpDistributor.SelectedValue), int.Parse(foundRows[0]["SKU_ID"].ToString()), "", DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            if (dtstock != null && dtstock.Rows.Count > 0)
            {
                if (int.Parse(dtstock.Rows[0][0].ToString()) + PreIssuedUnits < int.Parse(dc.chkNull_0(txtIssueUnits.Text))+(int.Parse(dc.chkNull_0(txtIssueCtn.Text)) * int.Parse(foundRows[0]["UNITS_IN_CASE"].ToString())))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + foundRows[0]["SKU_NAME"].ToString() + " Current Stock is " + ((int.Parse(dtstock.Rows[0][0].ToString()) + PreIssuedUnits) / int.Parse(foundRows[0]["UNITS_IN_CASE"].ToString())).ToString() + " CTN');", true);
                    return;
                }
                //else if (Convert.ToDecimal(dtstock.Rows[0][1]) != Convert.ToDecimal(dr["UNIT_PRICE"]))
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + dr["SKU_Code"].ToString() + " Order Rate is " + dr["UNIT_PRICE"].ToString() + " and Current Rate is " + dtstock.Rows[0][1].ToString() + "');", true);
                //    return;
                //}
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' + " + foundRows[0]["SKU_NAME"] + "No Stock Found');", true);
                return;
            }


            #endregion




            DataRow dr = PurchaseSKU.Rows[RowId];
            dr["SKU_ID"] = foundRows[0]["SKU_ID"];
            dr["SKU_CODE"] = foundRows[0]["SKU_CODE"];
            dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
            dr["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
            dr["SKU_Weight"] = foundRows[0]["SKU_Weight"];
            dr["UNITS_IN_CASE"] = foundRows[0]["UNITS_IN_CASE"];
            dr["ISSUE_CTN"] = int.Parse(dc.chkNull_0(txtIssueCtn.Text));
            dr["ISSUE_UNITS"] = int.Parse(dc.chkNull_0(txtIssueUnits.Text));
            
            dr["RETURN_CTN"] = int.Parse(dc.chkNull_0(txtReturnCTN.Text));
            dr["RETURN_UNITS"] =int.Parse(dc.chkNull_0(txtReturnUnits.Text));
              
            dr["RETURN_EMPTY_UNITS"] = int.Parse(dc.chkNull_0(txtReturnEmpty.Text));

            dr["GROSS_UNITS"] = (int.Parse(dr["ISSUE_CTN"].ToString()) * packsize) + int.Parse(dr["ISSUE_UNITS"].ToString()) - int.Parse(dr["RETURN_UNITS"].ToString()) - (int.Parse(dr["RETURN_CTN"].ToString()) * packsize);
            dr["DAMAGE_UNITS"] = int.Parse(dc.chkNull_0(txtDamegeUnits.Text));
            dr["Actual_DAMAGE_UNITS"] = int.Parse(dc.chkNull_0(txtActualDamageUnit.Text));
            dr["SCHEME_UNITS"] = int.Parse(dc.chkNull_0(txtSchemeUnits.Text));
         
           // dr["NET_SALE"] = int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dr["DAMAGE_UNITS"].ToString()) - int.Parse(dr["SCHEME_UNITS"].ToString());
            decimal totalSale = int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dr["DAMAGE_UNITS"].ToString()) - int.Parse(dr["SCHEME_UNITS"].ToString()) - int.Parse(dr["Actual_DAMAGE_UNITS"].ToString());

            //dr["NET_SALE"] = int.Parse(dr["GROSS_UNITS"].ToString()) - int.Parse(dr["DAMAGE_UNITS"].ToString()) - int.Parse(dr["SCHEME_UNITS"].ToString());

            dr["NET_SALE_CTN"] =Math.Floor(totalSale / mPackSize);
            dr["NET_SALE"] = totalSale % mPackSize;



            dr["NET_VALUE"] = totalSale * decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString());
             
  



            #region GST
            if (foundRows[0]["GST_ON"].ToString().Trim() == "T")
            {
                dr["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                //  dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());
                dr["TST_AMOUNT"] = 0;
                dr["BATCH_NO"] = "T";

            }
            else if (foundRows[0]["GST_ON"].ToString().Trim() == "R")
            {
                //  dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());
                dr["TST_AMOUNT"] = decimal.Parse(foundRows[0]["GST_RATE_TP"].ToString()) * totalSale;
                dr["GST_RATE"] = 0;
                dr["BATCH_NO"] = "R";

            }
            else
            {
                //  dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());
                dr["TST_AMOUNT"] = 0;
                dr["GST_RATE"] = 0;
                dr["BATCH_NO"] = "E";
            }
            #endregion

            if (int.Parse(dc.chkNull_0(txtDamegeUnits.Text)) > 0)
            {
                IsDamage = true;
            }
        }
#endregion
        this.Session.Add("PurchaseSKU", PurchaseSKU);
       
        this.LoadGird();
        this.ClearAll();
        EnableDisableController(false);
        ScriptManager.GetCurrent(Page).SetFocus(ddlSKuCde );
      
    }

    private void EnableDisableController(bool CValue)
    {

        if (CValue == true)
        {
            DrpDeliveryMan.Enabled = true;
            drpDistributor.Enabled = true;
            DrpRoute.Enabled = true;
            DrpOrderBooker.Enabled = true;
            DrpPrincipal.Enabled = true;
        }
        else
        {
            DrpDeliveryMan.Enabled = false;
            drpDistributor.Enabled = false;
            DrpRoute.Enabled = false;
            DrpOrderBooker.Enabled = false;
            DrpPrincipal.Enabled = false;
        }
    }

    private bool CheckDublicateSku()
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        var foundRows = PurchaseSKU.Select("SKU_ID  = '" + ddlSKuCde .SelectedValue  + "'");
        return foundRows.Length == 0;
    }

    protected void DrpDeliveryMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Session.Add("DeliveryManId", int.Parse(DrpDeliveryMan.SelectedValue));
        this.LoadSKUDetail();
    }

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        var pc = new PurchaseController();
        var loadpass = pc.selectLoadPassDocumentNo(int.Parse(drpDistributor.SelectedValue), int.Parse(DrpRoute.SelectedValue), long.Parse(DrpRoute.SelectedValue), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
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
                #region Sale Invoice Portion

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
                                                                       dc.chkNull_0(txtTotalActualDamageValue.Text)), decimal.Parse(
                                                                       dc.chkNull_0(txtIncentive.Text))
                                                                       , decimal.Parse(
                                                                       dc.chkNull_0(txtRental.Text))
                                                                       , decimal.Parse(
                                                                       dc.chkNull_0(txtDisplay.Text))
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
            else if (btnSaveOrder.Text == "UPDATE")
            {
                #region saleInvoice Master/detail Updation
                var isValidInsert1 = mOrderController.Update_Invoice(long.Parse(this.Session["SaleInvoiceID"].ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), manualId, int.Parse(DrpRoute.SelectedValue.ToString()), long.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), 0, 0, int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()), Sale_Order_ID,
               decimal.Parse(dc.chkNull_0(txtnumGrossSale.Text)), decimal.Parse(dc.chkNull_0(txtUnclaimAbleDiscount.Text)), decimal.Parse(dc.chkNull_0(txtClaimableDiscounts.Text)), decimal.Parse(dc.chkNull_0(txtBRD.Text)), decimal.Parse(dc.chkNull_0(txtGSTAmount.Text)), decimal.Parse(dc.chkNull_0(txtNetAmount.Text)), decimal.Parse(dc.chkNull_0(txtOtherDiscounts.Text)), Constants.Order_Posted_Id, PurchaseSKU, dtFreeSKU, int.Parse(this.Session["UserId"].ToString()), Constants.DecimalNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), decimal.Parse(dc.chkNull_0(txtTradeOffers.Text)), decimal.Parse(dc.chkNull_0(txtTSTAmount.Text)), int.Parse(dc.chkNull_0(txtVisit.Text)), int.Parse(dc.chkNull_0(txtProductiveCall.Text)), int.Parse(dc.chkNull_0(txtOpeningReading.Text)), int.Parse(dc.chkNull_0(txtCloseReading.Text)), int.Parse(dc.chkNull_0(txtBillNoFrom.Text)), int.Parse(dc.chkNull_0(txtBillNoTo.Text)), decimal.Parse(dc.chkNull_0(txtFuel.Text)), decimal.Parse(dc.chkNull_0(txtWholeSaleDiscount.Text)), decimal.Parse(dc.chkNull_0(txtTotalDamageValue.Text)), IsDamage, decimal.Parse(dc.chkNull_0(txtTotalActualDamageValue.Text)), decimal.Parse(
                                                                       dc.chkNull_0(txtIncentive.Text))
                                                                       , decimal.Parse(
                                                                       dc.chkNull_0(txtRental.Text))
                                                                       , decimal.Parse(
                                                                       dc.chkNull_0(txtDisplay.Text)));
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
        }
        txtNumGrossWeight.Text = Math.Round(ObjTotalWeight / 1000, 2).ToString();// Devided by 1000 to show in Ltr
        txtnumGrossSale.Text = Math.Round(ObjGrossSales, 4).ToString();
        txtGSTAmount.Text = Convert.ToString(Math.Round(ObjTotalGST, 4));
        txtTSTAmount.Text = Convert.ToString(Math.Round(ObjTotalTST, 4));
        txtTotalDamageValue.Text = Convert.ToString(Math.Round(ObjTotalDamageValue, 4));
        txtTotalSchemeValue.Text = Convert.ToString(Math.Round(ObjTotalSchemeValue, 4));
        txtTotalActualDamageValue.Text = Convert.ToString(Math.Round(ObjTotalActualDamageValue, 4));
        txtClaimableDiscounts.Text = Math.Round(decimal.Parse(dc.chkNull_0(txtWholeSaleDiscount.Text)) + decimal.Parse(dc.chkNull_0(txtBRD.Text)) + decimal.Parse(dc.chkNull_0(txtTradeOffers.Text)) + decimal.Parse(dc.chkNull_0(txtOtherDiscounts.Text)) + decimal.Parse(dc.chkNull_0(txtIncentive.Text)) + decimal.Parse(dc.chkNull_0(txtRental.Text)) + decimal.Parse(dc.chkNull_0(txtDisplay.Text)), 4).ToString();
        txtNetAmount.Text = Math.Round(decimal.Parse(dc.chkNull_0(txtnumGrossSale.Text)) - decimal.Parse(dc.chkNull_0(txtUnclaimAbleDiscount.Text)) - decimal.Parse(dc.chkNull_0(txtClaimableDiscounts.Text)) + decimal.Parse(dc.chkNull_0(txtGSTAmount.Text)) + decimal.Parse(dc.chkNull_0(txtTSTAmount.Text)) - decimal.Parse(dc.chkNull_0(txtFuel.Text)) - decimal.Parse(dc.chkNull_0(txtTotalDamageValue.Text)) - decimal.Parse(dc.chkNull_0(txtTotalActualDamageValue.Text)) - decimal.Parse(dc.chkNull_0(txtTotalSchemeValue.Text)), 4).ToString();
        btnSaveOrder.Enabled = true;

    }
    protected void ddlSKuCde_SelectedIndexChanged(object sender, EventArgs e)
    {
        var dc = new DataControl();
        var dtskuPrice = (DataTable)this.Session["Dtsku_Price"];
        if (dtskuPrice != null)
        {
            if (dtskuPrice.Rows.Count > 0)
            {
                var foundRows = dtskuPrice.Select("SKU_ID  = '" + ddlSKuCde.SelectedValue + "'");
                var mTradePrice = decimal.Parse(dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString()));

                var mPacking = (dc.chkNull_0(foundRows[0]["PACKSIZE"].ToString()));
                var mUnitInCase = (dc.chkNull_0(foundRows[0]["UNITS_IN_CASE"].ToString()));
                txtTP.Text = mTradePrice.ToString(CultureInfo.InvariantCulture);
                txtPacking.Text = mPacking.ToString(CultureInfo.InvariantCulture);
                txtUnitsInCase.Text = mUnitInCase.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}




   