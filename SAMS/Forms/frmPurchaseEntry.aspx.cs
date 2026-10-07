using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// From For Purchase, TranferOut, Purchase Return, TranferIn And Damage
/// </summary>
public partial class Forms_frmPurchaseEntry : System.Web.UI.Page
{
    private SKUPriceDetailController PController = new SKUPriceDetailController();
    private DataControl dc = new DataControl();
    private static int RowNo;
    private static int PrivouseQty, FreePrivousQty;
    private DataTable PurchaseSKU;

    /// <summary>
    /// Page_Load Function Populates All Combos On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail();
            this.CreatTable();
            this.GetDocumentNo();
            btnSave.Attributes.Add("onclick", "return ValidateForm();");
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime) this.Session["CurrentWorkDate"];
            DrpDocumentType_SelectedIndexChanged(null, null);
        }
    }

    /// <summary>
    /// Creats Datatable For Document
    /// </summary>
    private void CreatTable()
    {
        PurchaseSKU = new DataTable();
        PurchaseSKU.Columns.Add("PURCHASE_DETAIL_ID", typeof (long));
        PurchaseSKU.Columns.Add("SKU_ID", typeof (int));
        PurchaseSKU.Columns.Add("SKU_Code", typeof (string));
        PurchaseSKU.Columns.Add("SKU_Name", typeof (string));

        PurchaseSKU.Columns.Add("BATCH_NO", typeof (string));
        PurchaseSKU.Columns.Add("PRICE", typeof (decimal));
        PurchaseSKU.Columns.Add("Quantity", typeof (int));
        //by safdar
        PurchaseSKU.Columns.Add("QuantityUnit", typeof (int));
        PurchaseSKU.Columns.Add("UNITS_IN_CASE", typeof (int));
        PurchaseSKU.Columns.Add("Total_Unit", typeof (int));
        //
        PurchaseSKU.Columns.Add("FREE_SKU", typeof (int));
        PurchaseSKU.Columns.Add("TDAMAGE", typeof (int));
        PurchaseSKU.Columns.Add("AMOUNT", typeof (decimal));
        this.Session.Add("PurchaseSKU", PurchaseSKU);

    }

    /// <summary>
    /// Sets Form Controls According To Selected Document Type
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpDocumentType.SelectedValue == "2") //0 purchase
        {
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Purchase For";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedValue == "5") //1 Transfer Out
        {
            lblfromLocation.Text = "Transfer From";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            LoadToDistributor();
            this.DrpTransferFor.Visible = true;
            Label4.Visible = true;
            Label4.Text = "Transfer To";
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedValue == "3") //2 Purchase REturn
        {
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Return From";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedValue == "4") //3 Transfer In
        {
            lblfromLocation.Text = "Transfer to";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            LoadToDistributor();
            this.DrpTransferFor.Visible = true;
            Label4.Visible = true;
            Label4.Text = "Transfer From";
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedValue == "6") //4 Damage(Replace)
        {
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Location";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedValue == "10") // Damage (return)
        {
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Location";
            LoadDamageDetail();
            this.DrpTransferFor.Visible = true;
            Label4.Visible = true;
            Label4.Text = "Damage Detail";
            this.GetDocumentNo();
            //txtTransitDamage.Enabled = false;
            ChbFreeSKU.Enabled = false;
        }
        else
        {
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Location";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
    }

    private void LoadDamageDetail()
    {
        DrpTransferFor.Items.Clear();
        DrpTransferFor.Items.Add(new ListItem("Market Damage", "0"));
        DrpTransferFor.Items.Add(new ListItem("Warehouse Damage", "1"));
        DrpTransferFor.Items.Add(new ListItem("Transit Damage", "2"));

    }

    /// <summary>
    /// Gets Document Nos For Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </summary>
    private void GetDocumentNo()
    {
        drpDocumentNo.Items.Clear();
        DateTime MWorkDate = System.DateTime.Now;
        PurchaseController mPurchase = new PurchaseController();
        DataTable dt = mPurchase.SelectPurchaseDocumentNo(int.Parse(DrpDocumentType.SelectedValue.ToString()),
                                                          Constants.IntNullValue, Constants.LongNullValue,
                                                          int.Parse(this.Session["UserId"].ToString()), 0);
        drpDocumentNo.Items.Add(new clsListItems("New", Constants.LongNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDocumentNo, dt, 0, 0);
    }

    /// <summary>
    /// Loads Document Detail Data To Document Detail Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
        {
            this.CreatTable();

            this.Session.Add("PurchaseSKU", PurchaseSKU);
            LoadGird();
            this.ClearAll();
            drpPrincipal.Enabled = true;
            drpDistributor.Enabled = true;
            DrpDocumentType.Enabled = true;
        }
        else
        {
            txtBuiltyNo.Text = "";
            txtDocumentNo.Text = "";
            drpPrincipal.Enabled = false;
            drpDistributor.Enabled = false;
            DrpDocumentType.Enabled = false;
            this.LoadDocumentDetail();
            this.LoadSKUDetail();
        }
    }

    /// <summary>
    /// Loads Principals To Principal Comb
    /// </summary>
    private void LoadPrincipal()
    {
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue,
                                                     Constants.IntNullValue, Constants.IntNullValue,
                                                     Constants.IntNullValue,
                                                     int.Parse(this.Session["UserId"].ToString()),
                                                     Constants.IntNullValue, 0,
                                                     DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1, true);
    }

    /// <summary>
    /// Loads Document Detail To Document Detail Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }

    /// <summary>
    /// Loads Locations To Location From Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue,
                                                         int.Parse(this.Session["UserId"].ToString()),
                                                         int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Locations To Location To Combo
    /// </summary>
    private void LoadToDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, Constants.IntNullValue,
                                                         int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpTransferFor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Document Detail Data To Document Detail Grid
    /// </summary>
    private void LoadDocumentDetail()
    {
        DateTime MWorkDate = System.DateTime.Now;
        PurchaseController mPurchase = new PurchaseController();
        DataTable dt = mPurchase.SelectPurchaseDocumentNo(Constants.IntNullValue, Constants.IntNullValue,
                                                          long.Parse(drpDocumentNo.SelectedValue.ToString()),
                                                          Constants.IntNullValue, Constants.IntNullValue);
        if (dt.Rows.Count > 0)
        {
            if (DrpDocumentType.SelectedValue == "10")// damage
            {
                drpPrincipal.SelectedValue = dt.Rows[0]["PRINCIPAL_ID"].ToString();
                drpDistributor.SelectedValue = dt.Rows[0]["SOLD_to"].ToString();
                txtDocumentNo.Text = dt.Rows[0][2].ToString();
                txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
            }
            else if (DrpDocumentType.SelectedValue == "2" )//purchase
            {
                drpDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                drpPrincipal.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                txtDocumentNo.Text = dt.Rows[0][2].ToString();
                txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
            }
            else if (DrpDocumentType.SelectedValue == "5")//transfer out
            {
                drpDistributor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                DrpTransferFor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                txtDocumentNo.Text = dt.Rows[0][2].ToString();
                txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
            }
            else if (DrpDocumentType.SelectedValue == "3")// purchase return
            {
                drpPrincipal.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                drpDistributor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                txtDocumentNo.Text = dt.Rows[0][2].ToString();
                txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
            }
           
            else
            {
                DrpTransferFor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                drpDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                txtDocumentNo.Text = dt.Rows[0][2].ToString();
                txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
            }
            PurchaseSKU = mPurchase.SelectPurchaseDetailstock(Constants.IntNullValue,
                                                              long.Parse(dt.Rows[0][0].ToString()));
            this.Session.Add("PurchaseSKU", PurchaseSKU);
            LoadGird();
        }
    }

    /// <summary>
    /// Loads Document Detail Data To Document Detail Grid
    /// </summary>
    private void LoadGird()
    {
        int TotalValue = 0;
        int TotalCtn = 0;
        int TotalTDamage = 0;
        PurchaseSKU = (DataTable) this.Session["PurchaseSKU"];
        GrdPurchase.DataSource = PurchaseSKU;
        GrdPurchase.DataBind();
        foreach (DataRow dr in PurchaseSKU.Rows)
        {
            TotalValue += int.Parse(dr["QuantityUnit"].ToString());
            TotalCtn += int.Parse(dr["Quantity"].ToString());
            TotalTDamage += int.Parse(dr["TDAMAGE"].ToString());
        }
        txtTotalQuantity.Text = TotalValue.ToString();
        txtTotalQuantityCtn.Text = TotalCtn.ToString();
        txtTotalTDamage.Text = TotalTDamage.ToString();
    }

    /// <summary>
    /// Sets Dcoment Detail Data For Edit. This Function Runs When An Existing Document Detail Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowNo = e.NewEditIndex;
        ddlSKuCde .SelectedValue  = GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text;
      //  txtskuName.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtQuantity.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        txtUnit.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        PrivouseQty = int.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text);
        FreePrivousQty = int.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text);
        txtFreeSKU.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        txtTransitDamage.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[6].Text;
        ddlSKuCde .Enabled = false;
        txtQuantity.Focus();
        btnSave.Text = "Update Sku";

    }

    /// <summary>
    /// Deletes A Document Detail
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PurchaseSKU = (DataTable) this.Session["PurchaseSKU"];
        if (PurchaseSKU.Rows.Count > 0)
        {
            PurchaseSKU.Rows.RemoveAt(e.RowIndex);
            this.Session.Add("PurchaseSKU", PurchaseSKU);
            this.LoadGird();
        }
    }

    /// <summary>
    /// Loads SKU Prices
    /// </summary>
    private void LoadSKUDetail()
    {
        if (drpPrincipal.Items.Count > 0)
        {
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(drpPrincipal.SelectedValue.ToString()),
                                                                Constants.IntNullValue, Constants.IntNullValue,
                                                                Constants.IntNullValue,
                                                                int.Parse(drpDistributor.SelectedValue.ToString()),
                                                                int.Parse(this.Session["UserId"].ToString()),
                                                                Constants.IntNullValue, 1,
                                                                DateTime.Parse(
                                                                    this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillDropDownList(ddlSKuCde, Dtsku_Price, 0,16, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }

    /// <summary>
    /// Enables/Disables Batch No TextBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbBatchNo_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbBatchNo.Checked == true)
        {
            //lblFreeSku.Enabled = true;
            txtBatchNo.Enabled = true;
        }
        else
        {
            txtBatchNo.Text = "N/A";
            // lblFreeSku.Enabled = false;
            txtBatchNo.Enabled = false;
        }
    }

    /// <summary>
    /// Enables/Disables Apply Free SKU TextBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbFreeSKU_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbFreeSKU.Checked == true)
        {
            lblUnits.Enabled = true;
            txtFreeSKU.Enabled = true;
        }
        else
        {
            txtFreeSKU.Text = "0";
            lblUnits.Enabled = false;
            txtFreeSKU.Enabled = false;
        }
    }

    /// <summary>
    /// Adds Document Detail To Document Detail Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        DataTable Dtsku_Price = (DataTable) this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable) this.Session["PurchaseSKU"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + ddlSKuCde.SelectedValue + "'");
        if (foundRows.Length > 0)
        {
            decimal mStdDiscount = decimal.Parse(dc.chkNull_0(foundRows[0]["DISTRIBUTOR_DISCOUNT"].ToString()));
            decimal mGSTRate = decimal.Parse(dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString()));
            int CurrentStock = CheckStockStatus(int.Parse(dc.chkNull_0(foundRows[0]["SKU_ID"].ToString())));

            if (btnSave.Text == "Add Sku")
            {
                if (CheckDublicateSKU())
                {
                    if (CurrentStock == -1)
                    {
                        DataRow dr = PurchaseSKU.NewRow();
                        dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                        dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                        dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                        dr["UNITS_IN_CASE"] = foundRows[0]["UNITS_IN_CASE"];
                        // lblquantity.Text = dr["UNITS_IN_CASE"].ToString();
                        dr["BATCH_NO"] = txtBatchNo.Text;
                        dr["FREE_SKU"] = int.Parse(dc.chkNull_0(txtFreeSKU.Text));
                        dr["PRICE"] = foundRows[0]["TRADE_PRICE"];
                        dr["Quantity"] = int.Parse(dc.chkNull_0(txtQuantity.Text));
                        dr["QuantityUnit"] = int.Parse(dc.chkNull_0(txtUnit.Text));
                        dr["TDAMAGE"] = int.Parse(dc.chkNull_0(txtTransitDamage.Text));
                        decimal TotalUnit = (decimal.Parse(dr["QuantityUnit"].ToString())) +
                                            ((decimal.Parse(dr["Quantity"].ToString()))*
                                             (decimal.Parse(dr["UNITS_IN_CASE"].ToString())));
                        dr["Total_Unit"] = TotalUnit;
                        //  dr["AMOUNT"] = decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                        dr["AMOUNT"] = decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString())*TotalUnit;

                        PurchaseSKU.Rows.Add(dr);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                            "alert('  " + ddlSKuCde.SelectedItem.Text +
                                                            " Current closing Stock is " + CurrentStock.ToString() +
                                                            "');", true);
                        ddlSKuCde.SelectedValue = foundRows[0]["SKU_ID"].ToString();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                        "alert('  " + ddlSKuCde.SelectedItem.Text +
                                                        " Already Exists ');", true);
                    ddlSKuCde.SelectedValue = foundRows[0]["SKU_ID"].ToString();
                    return;
                }
            }
            else if (btnSave.Text == "Update Sku")
            {
                if (CurrentStock == -1)
                {
                    DataRow dr = PurchaseSKU.Rows[RowNo];
                    dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                    dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                    dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                    dr["UNITS_IN_CASE"] = foundRows[0]["UNITS_IN_CASE"];
                    dr["BATCH_NO"] = txtBatchNo.Text;
                    dr["PRICE"] = foundRows[0]["TRADE_PRICE"];
                    dr["Quantity"] = int.Parse(txtQuantity.Text);
                    dr["QuantityUnit"] = int.Parse(dc.chkNull_0(txtUnit.Text));
                    dr["FREE_SKU"] = int.Parse(dc.chkNull_0(txtFreeSKU.Text));
                    dr["TDAMAGE"] = int.Parse(dc.chkNull_0(txtTransitDamage.Text));
                    decimal TotalUnit = (decimal.Parse(dr["QuantityUnit"].ToString())) +
                                        ((decimal.Parse(dr["Quantity"].ToString()))*
                                         (decimal.Parse(dr["UNITS_IN_CASE"].ToString())));
                    dr["Total_Unit"] = TotalUnit;
                    // dr["AMOUNT"] = decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                    dr["AMOUNT"] = decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString())*TotalUnit;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                        "alert('  " + ddlSKuCde.SelectedValue +
                                                        "Current closing Stock is " + CurrentStock.ToString() + "');",
                                                        true);
                    ddlSKuCde.SelectedValue = foundRows[0]["SKU_ID"].ToString();
                    return;
                }
            }
            this.Session.Add("PurchaseSKU", PurchaseSKU);
            this.ClearAll();
            this.LoadGird();
            DisAbaleOption(true);
            ScriptManager.GetCurrent(Page).SetFocus(ddlSKuCde);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Wrong SKU Select');", true);

        }
    }

    /// <summary>
    /// Saves All Document Detail Grid Data
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSaveDocument_Click(object sender, EventArgs e)
    {
        SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime) this.Session["CurrentWorkDate"];
        if (DrpDocumentType.SelectedValue == "3"|| DrpDocumentType.SelectedValue == "4")
        {// 3 MEAN purchase return and 4 transter in
            if (drpDistributor.SelectedValue.ToString() == DrpTransferFor.SelectedValue.ToString())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                                                    "alert(' Transfer to Location must be different ');", true);
                return;
            }
        }
        PurchaseSKU = (DataTable) this.Session["PurchaseSKU"];
        if (PurchaseSKU.Rows.Count > 0)
        {
            DistributorController mDayClose = new DistributorController();
            DataTable dt = mDayClose.SelectMaxDayClose(Constants.IntNullValue,
                                                       int.Parse(drpDistributor.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                if (IsDayClosed())
                {
                    UserController UserCtl = new UserController();

                    UserCtl.InsertUserLogoutTime(Convert.ToInt32(Session["User_Log_ID"]),
                                                 Convert.ToInt32(Session["UserID"]));
                    this.Session.Clear();
                    System.Web.Security.FormsAuthentication.SignOut();
                    Response.Redirect("../Login.aspx");
                }
                else
                {

                    if (CalculatePurchase(DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString())))
                    {
                        PurchaseSKU = (DataTable) this.Session["PurchaseSKU"];
                        PurchaseSKU.Rows.Clear();
                        this.Session.Add("PurchaseSKU", PurchaseSKU);
                        this.LoadGird();
                        this.GetDocumentNo();
                        drpDistributor.Enabled = true;
                        drpPrincipal.Enabled = true;
                        DrpDocumentType.Enabled = true;
                        this.ClearAll();
                        txtBuiltyNo.Text = "";
                        txtDocumentNo.Text = "";
                        txtDocumentNo.Text = "";
                        DisAbaleOption(false);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Wrong Location');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' At least one SKU must enter');",
                                                true);

        }
    }

    /// <summary>
    /// Resets Form Controls
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DisAbaleOption(false);
        this.CreatTable();
        this.LoadGird();
        this.ClearAll();
        txtDocumentNo.Text = "";
        txtBuiltyNo.Text = "";
        txtDocumentNo.Text = "";
    }

    /// <summary>
    /// Checkes Duplicate SKUS in Document Detail Grid
    /// </summary>
    /// <returns>bool</returns>
    private bool CheckDublicateSKU()
    {
        DataControl dc = new DataControl();
        DataTable Dtsku_Price = (DataTable) this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable) this.Session["PurchaseSKU"];
        DataRow[] foundRows = PurchaseSKU.Select("SKU_ID  = '" + ddlSKuCde.SelectedValue + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Save Document Detail Grid Data
    /// </summary>
    /// <param name="MWorkDate">Date</param>
    /// <returns>bool</returns>
    private bool CalculatePurchase(DateTime MWorkDate)
    {
        decimal mTotalAmount = 0;

        PurchaseController mController = new PurchaseController();
        DataTable dtPurchaseDetail = (DataTable) this.Session["PurchaseSKU"];
        foreach (DataRow dr in dtPurchaseDetail.Rows)
        {
            mTotalAmount += decimal.Parse(dr["AMOUNT"].ToString());

        }
        if (DrpDocumentType.SelectedValue == "2")//purchase
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult =
                    mController.InsertPurchaseDocumentStock(int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            txtDocumentNo.Text,
                                                            int.Parse(DrpDocumentType.SelectedValue.ToString())
                                                            , MWorkDate,
                                                            int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()),
                                                            mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                                                            int.Parse(this.Session["UserId"].ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocumentStock(
                    int.Parse(drpDocumentNo.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text,
                    int.Parse(DrpDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()),
                    int.Parse(drpPrincipal.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0,
                    txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()),
                    int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedValue == "5")//Transfer OUt
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult =
                    mController.InsertPurchaseDocumentStock(int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            txtDocumentNo.Text,
                                                            int.Parse(DrpDocumentType.SelectedValue.ToString())
                                                            , MWorkDate,
                                                            int.Parse(DrpTransferFor.SelectedValue.ToString()),
                                                            int.Parse(drpDistributor.SelectedValue.ToString())
                                                            , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                                                            int.Parse(this.Session["UserId"].ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocumentStock(
                    int.Parse(drpDocumentNo.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text,
                    int.Parse(DrpDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(DrpTransferFor.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                    int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedValue == "3")//Purchase REturn
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult =
                    mController.InsertPurchaseDocumentStock(int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            txtDocumentNo.Text,
                                                            int.Parse(DrpDocumentType.SelectedValue.ToString())
                                                            , MWorkDate,
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()),
                                                            int.Parse(drpDistributor.SelectedValue.ToString())
                                                            , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                                                            int.Parse(this.Session["UserId"].ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocumentStock(
                    int.Parse(drpDocumentNo.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text,
                    int.Parse(DrpDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(drpPrincipal.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                    int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedValue == "4")//Transfer IN
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult =
                    mController.InsertPurchaseDocumentStock(int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            txtDocumentNo.Text,
                                                            int.Parse(DrpDocumentType.SelectedValue.ToString())
                                                            , MWorkDate,
                                                            int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            int.Parse(DrpTransferFor.SelectedValue.ToString())
                                                            , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                                                            int.Parse(this.Session["UserId"].ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocumentStock(
                    int.Parse(drpDocumentNo.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text,
                    int.Parse(DrpDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()),
                    int.Parse(DrpTransferFor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                    int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedValue == "6")// Down
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult =
                    mController.InsertPurchaseDocumentStock(int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            txtDocumentNo.Text,
                                                            int.Parse(DrpDocumentType.SelectedValue.ToString())
                                                            , MWorkDate,
                                                            int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString())
                                                            , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                                                            int.Parse(this.Session["UserId"].ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocumentStock(
                    int.Parse(drpDocumentNo.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text,
                    int.Parse(DrpDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()),
                    int.Parse(drpPrincipal.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                    int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else //For Damage Stock Return
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult =
                    mController.InsertPurchaseDocumentStock(int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            txtDocumentNo.Text,
                                                            int.Parse(DrpDocumentType.SelectedValue.ToString())
                                                            , MWorkDate,
                                                            int.Parse(drpDistributor.SelectedValue.ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString())
                                                            , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                                                            int.Parse(this.Session["UserId"].ToString()),
                                                            int.Parse(drpPrincipal.SelectedValue.ToString()),
                                                            int.Parse(DrpTransferFor.SelectedValue));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocumentStock(
                    int.Parse(drpDocumentNo.SelectedValue.ToString()),
                    int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text,
                    int.Parse(DrpDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()),
                    int.Parse(drpPrincipal.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text,
                    int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()),
                    int.Parse(DrpTransferFor.SelectedValue));
                return mResult;
            }
        }
    }

    /// <summary>
    /// Checks SKU Stock
    /// </summary>
    /// <param name="SKU_ID">SKU</param>
    /// <returns>SKU Stock as Integer</returns>
    private int CheckStockStatus(int SKU_ID)
    {
        if (DrpDocumentType.SelectedValue == "2" || DrpDocumentType.SelectedValue == "4")
        {//purchase and transfer in
            return -1;
        }
        else
        {
            PhaysicalStockController mController = new PhaysicalStockController();
            DataTable dt = mController.SelectSKUClosingStock(int.Parse(drpDistributor.SelectedValue.ToString()), SKU_ID,
                                                             txtBatchNo.Text,
                                                             DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0][0].ToString()) + PrivouseQty + FreePrivousQty >= int.Parse(txtQuantity.Text))
                {
                    return -1;
                }
                else
                {
                    return int.Parse(dt.Rows[0][0].ToString()) + PrivouseQty + FreePrivousQty;
                }
            }
        }

        return 0;
    }

    /// <summary>
    /// Enables/Disables Controls
    /// </summary>
    /// <param name="IsDisable">bool</param>
    private void DisAbaleOption(bool IsDisable)
    {
        if (IsDisable == true)
        {
            DrpDocumentType.Enabled = false;
            drpPrincipal.Enabled = false;
            drpDistributor.Enabled = false;
            drpDocumentNo.Enabled = false;
        }
        else
        {
            DrpDocumentType.Enabled = true;
            drpPrincipal.Enabled = true;
            drpDistributor.Enabled = true;
            drpDocumentNo.Enabled = true;
            drpDocumentNo.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// Clears Form Controls
    /// </summary>
    private void ClearAll()
    {
        ddlSKuCde.SelectedIndex = 0;
        txtQuantity.Text = "";
        txtFreeSKU.Text = "0";
        txtBatchNo.Text = "N/A";

        txtUnit.Text = "";
        ddlSKuCde.Enabled = true;
        btnSave.Text = "Add Sku";
        PrivouseQty = 0;
        FreePrivousQty = 0;
        txtTransitDamage.Text = "";
    }

    private bool IsDayClosed()
    {
        bool flag = false;
        DistributorController DistrCtl = new DistributorController();
        DataTable dtDayClose = DistrCtl.MaxDayClose(Convert.ToInt32(drpDistributor.SelectedValue), 3);
        if (Convert.ToDateTime(Session["CurrentWorkDate"]) == Convert.ToDateTime(dtDayClose.Rows[0]["DayClose"]))
        {
            flag = false;
        }
        else
        {
            flag = true;
        }

        return flag;
    }
}