using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form To Add Targets
/// </summary>
public partial class Forms_frmTargetEntry : System.Web.UI.Page
{
    private static long TargetId;
    DataTable PurchaseSKU;
    private static int RowId;

    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadTargetForId();
            this.LoadPrincipal();
            this.LoadSKUDetail();
            this.CreatTable();
            btnTarget.Attributes.Add("onclick", "return ValidateForm();");
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtFromdate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("MMM-yyyy");
            this.LoadGird();
            pnlgrdSkuDetail.Visible = false;
            pnlskydetail.Visible = false;
            PnlGrdTargetView.Visible = false;
        }
    }

    /// <summary>
    /// Loads Sale Forces To TargetFor Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpTargetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTargetForId();
        this.LoadGird();
        LoadGrdSkuWiseTargetView();
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Sale Forces To TargetFor Combo And Targets To Target Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTargetForId();
        this.LoadGird();
        LoadSKUDetail();
        LoadGrdSkuWiseTargetView();
    }

    /// <summary>
    /// Loads Principals To Prinicpal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1, true);
    }

    /// <summary>
    /// Loads Targets To Target Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGird();
        this.LoadSKUDetail();
        LoadGrdSkuWiseTargetView();
    }

    /// <summary>
    /// Loads Sale Forces To TargetFor 
    /// </summary>
    /// 

    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (int.Parse(drpPrincipal .SelectedValue .ToString()) > 0)
        {
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(drpPrincipal .SelectedValue .ToString ()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor .SelectedValue .ToString()), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, Dtsku_Price, 10, 10, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }

    private void LoadTargetForId()
    {              
        if (DrpTargetType.SelectedIndex == 0)
        {
            if (drpDistributor.Items.Count > 0)
            {
                Distributor_UserController Du = new Distributor_UserController();
                DataTable dt = Du.SelectDistributorUser(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(DrpTargetFor, dt, 0, 6, true);
            }
        }
        else if (DrpTargetType.SelectedIndex == 1)
        {
            if (drpDistributor.Items.Count > 0)
            {

                Distributor_UserController Du = new Distributor_UserController();
                DataTable dt = Du.SelectDistributorUser(Constants.SALES_FORCE_SALESPERSON, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(DrpTargetFor, dt, 0, 6, true);
            }
        }
        else
        {
            if (drpDistributor.Items.Count > 0)
            {

                DistributorTownController gController = new DistributorTownController();
                DataTable dt = gController.SelectAssignTown(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), 1);
                clsWebFormUtil.FillDropDownList(DrpTargetFor, dt, 0, 1, true);
            }
        }
    }

    /// <summary>
    /// Loads Targets To Target Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpTargetFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGird();
        LoadGrdSkuWiseTargetView();
    }
    
    /// <summary>
    /// Loads Targets To Target Grid
    /// </summary>
    private void LoadGird()
    {
        if (txtFromdate.Text.Length > 1 && drpDistributor.Items.Count > 0 && DrpTargetFor.Items.Count > 0 && drpPrincipal.Items.Count > 0)
        {
            TargetController TG = new TargetController();
            DataTable dt = TG.SelectTarget(DateTime.Parse(txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()),int.Parse (RbTargetMode .SelectedValue .ToString ()));
            GrdPurchase.DataSource = dt;
            GrdPurchase.DataBind();
            if (RbTargetMode.SelectedIndex == 1)
            {
                for (int i = 0; i < GrdPurchase.Columns.Count; i++)
                {
                    if (GrdPurchase.Columns[i] is CommandField)
                    {
                        GrdPurchase.Columns[i].Visible = false;
                    }
                }


            }


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Some Selection is Wrong');", true); 
        }
    }

    private void LoadGrdSkuWiseTargetView()
    {


        if (txtFromdate.Text.Length > 1 && drpDistributor.Items.Count > 0 && DrpTargetFor.Items.Count > 0 && drpPrincipal.Items.Count > 0)
        {
            TargetController TG = new TargetController();
            DataTable dt = TG.SelectTarget(DateTime.Parse(txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(RbTargetMode.SelectedValue.ToString()));
            GrdTargetView.DataSource = dt;
            GrdTargetView.DataBind();
            if (RbTargetMode.SelectedIndex == 1)
            {
                //for (int i = 0; i < GrdPurchase.Columns.Count; i++)
                //{
                //    if (GrdPurchase.Columns[i] is CommandField)
                //    {
                //        GrdPurchase.Columns[i].Visible = false;
                //    }
                //}


            }


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Some Selection is Wrong');", true);
        }
    }

    private void loadgrdskudetail()
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        GrdSkuDetail.DataSource = PurchaseSKU;
        GrdSkuDetail.DataBind();


    }
    /// <summary>
    /// Deletes Target For Sale Froce
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TargetController TG = new TargetController();
        TG.UpdateTarget(long.Parse(GrdPurchase.Rows[e.RowIndex].Cells[0].Text), int.Parse(drpDistributor.SelectedValue.ToString()), Constants.DecimalNullValue, Constants.IntNullValue, false,int.Parse (RbTargetMode .SelectedValue .ToString ()));
        this.LoadGird();         
    }

    /// <summary>
    /// Sets Target For Edit. This Function Runs When An Existing Target Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (RbTargetMode.SelectedIndex == 0)
        {
            TargetId = long.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text);
            DrpTargetFor.SelectedValue = GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
            txttargetAmount.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
            btnTarget.Text = "Update";
            //DrpQuantityType.Enabled = false;
        }
        else if (RbTargetMode.SelectedIndex == 1)
        {
            TargetId = long.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text);
            DrpTargetFor.SelectedValue = GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
            txtSkuCode.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
            
            
            txtSkuAmount .Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
            btnTarget.Text = "Update";
            //DrpQuantityType.Enabled = false;
        }
        

     }
       
    /// <summary>
    /// Saves/Update Target
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnTarget_Click(object sender, EventArgs e)
    {
        TargetController TG = new TargetController();


        if (btnTarget.Text == "Save")
        {
            if (pnlskydetail.Visible == false)
            {
                string dt = TG.InsertTarget(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()), 0, decimal.Parse(txttargetAmount.Text), 0, int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
            }
            else if (pnlskydetail.Visible == true)
            {
                PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
                TG.InsertTarget(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()), 0, 0, 0, int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), PurchaseSKU);

            }
        }
        else
        {
                TG.UpdateTarget(TargetId, int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txttargetAmount.Text), 0, true, int.Parse(RbTargetMode.SelectedValue.ToString()));
            
        }
        if (pnlgrdSkuDetail.Visible == true)
        {
            LoadGrdSkuWiseTargetView();
        }
        else
        {
            this.LoadGird();
        }
        txtSkuAmount .Text = "0";
        btnTarget.Text = "Save";
        MasterClear();
       
    }
    protected void RbTargetMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RbTargetMode.SelectedIndex == 0)   // mean value wise
        {
            pnlskydetail.Visible = false;
            pnlgrdSkuDetail.Visible = false;
          //  lbltargetvalue.Visible = true;
            txttargetAmount.Enabled  = true;
            PnlGrdPurchase.Visible = true ;
            this.LoadGird();
        }
        if (RbTargetMode.SelectedIndex == 1)  // mean sky wise
        {
            txttargetAmount.Text = "";
            pnlskydetail.Visible = true;
          
            PnlGrdPurchase.Visible = false;
           
            pnlgrdSkuDetail.Visible = true ;
            PnlGrdTargetView.Visible = true;
            //lbltargetvalue.Visible = false;
            //txttargetAmount.Visible = false;
            txttargetAmount.Enabled = false;
        //    PnlGrdPurchase.Visible = false;
           // this.LoadGird();
            this.LoadGrdSkuWiseTargetView();
            btnTarget.Enabled = false;
        }
    }



    private void CreatTable()
    {
        PurchaseSKU = new DataTable();
        PurchaseSKU.Columns.Add("TARGET_ID", typeof(int));
        PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
        PurchaseSKU.Columns.Add("SKU_CODE", typeof(string));
        PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        PurchaseSKU.Columns.Add("UNIT_PRICE", typeof(decimal));
        PurchaseSKU.Columns.Add("QUANTITY", typeof(decimal));
        PurchaseSKU.Columns.Add("TOTAL_AMOUNT", typeof(decimal));
        this.Session.Add("PurchaseSKU", PurchaseSKU);

    }

    protected void btnAddSku_Click(object sender, EventArgs e)
    {
        DataControl dc = new DataControl();
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtSkuCode.Text + "'");
        
        #region add sku
        if (btnAddSku.Text == "Add Sku")
        {
            
            if (CheckDublicateSKU())
            {
                DataRow dr = PurchaseSKU.NewRow();
                dr["TARGET_ID"] = 0;
                dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                dr["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                dr["QUANTITY"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                dr["TOTAL_AMOUNT"] = decimal.Parse(dc.chkNull_0(txtSkuAmount.Text));
                PurchaseSKU.Rows.Add(dr);

            }

            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('SKU Already Exists')", true);
            }
        }
        #endregion
        #region btn update Sku
        else if (btnAddSku.Text == "Update SKU")
        {
            DataRow dr = PurchaseSKU.Rows[RowId];
            dr["TARGET_ID"] =0 ;
            dr["SKU_ID"] = foundRows[0]["SKU_ID"];
            dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
            dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
            dr["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
            dr["QUANTITY"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
            dr["TOTAL_AMOUNT"] = decimal.Parse(dc.chkNull_0(txtSkuAmount.Text));


        }
        #endregion
        #region Update Target
        else if (btnAddSku.Text == "Update Target")
        {
            TargetController TG = new TargetController();
            TG.UpdateTarget(long.Parse (lblerror.Text ), int.Parse(drpDistributor.SelectedValue.ToString()), DateTime .Parse (txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()),int.Parse (lblSkiId .Text ), decimal.Parse(txtSkuAmount.Text),int.Parse (txtQuantity .Text ), int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), int.Parse(RbTargetMode.SelectedValue.ToString()),true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Target Updated');", true);
           
           
           
        }
#endregion 
                                                          
        this.Session.Add("PurchaseSKU", PurchaseSKU);
        if (PnlGrdTargetView .Visible == true)
        {
            LoadGrdSkuWiseTargetView();
        }
        if (pnlgrdSkuDetail.Visible == true)
        {
            this.loadgrdskudetail();
        }
        
        clearall();
        btnTarget.Enabled = true;
    }

    private bool CheckDublicateSKU()
    {
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = PurchaseSKU.Select("SKU_CODE  = '" + txtSkuCode.Text + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void clearall()
    {
        btnAddSku.Text = "Add Sku";
        txtSkuCode.Text = "";
        txtSkuName.Text = "";
        txtSkuAmount.Text = "";
        txtQuantity.Text = "";
        txtTP.Text = "";
        lblerror.Text = "";
        lblSkiId.Text = "";
        txtSkuCode.Enabled = true;
    }

    private void MasterClear()
    {
        txtSkuCode.Text = "";
        txtSkuName.Text = "";
        txtSkuAmount.Text = "";
        txtQuantity.Text = "";
        txtTP.Text = "";
        Session.Remove("PurchaseSKU");
        GrdSkuDetail.DataSource = null;
        GrdSkuDetail.DataBind();
        this.LoadSKUDetail();
        this.CreatTable();
        this.LoadGird();

    }
    protected void GrdSkuDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        PurchaseSKU.Rows.RemoveAt(e.RowIndex);
        this.Session.Add("PurchaseSKU", PurchaseSKU);
        this.LoadGird();
        this.loadgrdskudetail ();
       
    }
    protected void GrdSkuDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdSkuDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        txtSkuCode.Text = GrdSkuDetail.Rows[e.NewEditIndex].Cells[1].Text;
        txtSkuName.Text = GrdSkuDetail.Rows[e.NewEditIndex].Cells[2].Text;
        txtQuantity.Text = GrdSkuDetail.Rows[e.NewEditIndex].Cells[3].Text;
        txtTP.Text = GrdSkuDetail.Rows[e.NewEditIndex].Cells[4].Text;
        txtSkuAmount.Text = GrdSkuDetail.Rows[e.NewEditIndex].Cells[5].Text;
    
        txtSkuCode.Enabled = false;
        btnAddSku.Text = "Update SKU";
        btnTarget .Enabled = false;

    }

    protected void GrdTargetView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        lblerror.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[0].Text;
        lblSkiId.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[1].Text;
        txtSkuCode.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[2].Text;
        txtSkuName.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[3].Text;
        txtQuantity.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[4].Text;
        txtTP.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[5].Text;
        txtSkuAmount.Text = GrdTargetView.Rows[e.NewEditIndex].Cells[6].Text;

        //drpDistributor.Enabled = false;
        //drpPrincipal.Enabled = false;
        //DrpTargetFor.Enabled = false;
        //DrpTargetType.Enabled = false;
        
        txtSkuCode.Enabled = false;
        btnAddSku.Text = "Update Target";
        btnTarget.Enabled = false;

    }
    protected void GrdTargetView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
        lblerror.Text = GrdTargetView.Rows[e.RowIndex].Cells[0].Text;
        TargetController TG = new TargetController();
        TG.UpdateTarget(long.Parse(lblerror.Text),int.Parse (drpDistributor .SelectedValue .ToString ()) , DateTime.Parse(txtFromdate .Text), Constants .IntNullValue,Constants.IntNullValue ,Constants .IntNullValue ,Constants .IntNullValue ,Constants .IntNullValue ,Constants .IntNullValue , Constants .IntNullValue ,Constants .IntNullValue ,false);
        LoadGrdSkuWiseTargetView();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Target Deleted');", true);
      

    }

}



