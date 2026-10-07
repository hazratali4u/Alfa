using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using System.Collections.Generic;

/// <summary>
/// From To Add, Edit Customer
/// </summary>
public partial class Forms_frmDistributorCustomer : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    DataTable BankInfo;
    private static int RowId;

    DataControl dc = new DataControl();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadTown();
            this.LoadRoute();
            this.LoadMarket();
            this.LoadChannelType();
            this.LoadBusinessType();
            this.LoadVolumeType();
            this.CreatTable();
            btnSave.Attributes.Add("onclick", "return ValidateForm()");
            btnAddBank.Attributes .Add ("onclick","return ValidateBank()");
            btnSearch.Attributes.Add("onclick", "return SearchRecord()");
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtRegdate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Towns To Town Combo, Routes To Routes Comb And Markets To Market Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadRoute();
        this.LoadMarket();
        this.SetTableSorter();
     
    }

    /// <summary>
    /// Loads Towns To Town Combo
    /// </summary>
    protected void LoadTown()
    {
        if (DrpDistributor.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectGeoHierarchy(int.Parse(DrpDistributor.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpTown, dt, 0, 1, true);
        }
    }

    /// <summary>
    /// Loads Routes To Routes Comb And Markets To Market Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRoute();
        this.LoadMarket();
        this.SetTableSorter();
    }

    /// <summary>
    /// Loads Routes To Route Combo
    /// </summary>
    private void LoadRoute()
    {
        if (DrpDistributor.Items.Count > 0 && DrpTown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(DrpDistributor.SelectedValue.ToString()), int.Parse(DrpTown.SelectedValue.ToString()), null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
    }

    /// <summary>
    /// Loads Markets To Market Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMarket();
        this.SetTableSorter();
    }

    /// <summary>
    /// Loads Markets To Market Combo
    /// </summary>
    private void LoadMarket()
    {
        if (DrpDistributor.Items.Count > 0 && DrpTown.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            DistributorRouteController gController = new DistributorRouteController();
            DataTable dt = gController.SelectDistributorRoute(Constants.LongNullValue, int.Parse(DrpDistributor.SelectedValue.ToString()), int.Parse(DrpTown.SelectedValue.ToString()), long.Parse(DrpRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpMarket, dt, 0, 8, true);
        }
        else
        {
            DrpMarket.Items.Clear();
        }
    }

    /// <summary>
    /// Loads Channel Types To Channel Type Combo
    /// </summary>
    private void LoadChannelType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(drpChannelType, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Business Types To Business Type Combo
    /// </summary>
    private void LoadBusinessType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerTypeBusiness, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(DrpBusinessType, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Promotion Classess To Promotion Class Combo
    /// </summary>
    private void LoadVolumeType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerVolumeClassType, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(DrpVolumeClass, dt, 0, 2, true);
        this.DrpVolumeClass.SelectedValue = "88";
    }

    /// <summary>
    /// Loads Customers To Customer Grid
    /// </summary>
    private void LoadCustomer()
    {
        if (DrpDistributor.Items.Count > 0 && DrpTown.Items.Count > 0 && DrpRoute.Items.Count > 0 && DrpMarket.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.UspSelectCustomer(int.Parse(DrpDistributor.SelectedValue.ToString()), ddSearchType.SelectedValue.ToString(), txtSeach.Text);
            this.Grid_users.DataSource = dt;
            this.Grid_users.DataBind();
            
        }
    }

    /// <summary>
    /// Sets Customer Data For Edit. This Function Runs When An Existing Customer Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {

        this.Session.Add("CustomerId", long.Parse(Grid_users.Rows[e.NewEditIndex].Cells[0].Text));
        hdnCustomerID.Value = long.Parse(Grid_users.Rows[e.NewEditIndex].Cells[0].Text).ToString();

        btnSave.Text = "Update";
        DrpDistributor.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[1].Text;
        DrpBusinessType.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[2].Text;
        DrpVolumeClass.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[3].Text;
        drpChannelType.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[4].Text;
        this.LoadTown();
        DrpTown.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[5].Text;
        this.LoadRoute();
        DrpRoute.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[6].Text;
        this.LoadMarket();
        DrpMarket.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[7].Text;
       // txtCustomerCode.Text = Grid_users.Rows[e.NewEditIndex].Cells[8].Text;
        txtCustomerName.Text = Grid_users.Rows[e.NewEditIndex].Cells[9].Text.Replace("amp;", "");
        txtContactPerson.Text = Grid_users.Rows[e.NewEditIndex].Cells[10].Text.Replace("&nbsp;", "");
        txtPhoneNo.Text = Grid_users.Rows[e.NewEditIndex].Cells[11].Text.Replace("&nbsp;", "");
        txtAddress.Text = Grid_users.Rows[e.NewEditIndex].Cells[13].Text.Replace("&nbsp;", "");
        txtIsRegister.Text = Grid_users.Rows[e.NewEditIndex].Cells[14].Text.Replace("&nbsp;", "");
        if (Grid_users.Rows[e.NewEditIndex].Cells[14].Text.Trim() == "&nbsp;")
        {
            txtIsRegister.Text = "";
            ChbIsRegister.Checked = false;
        }
        else
        {
            ChbIsRegister.Checked = true;
            txtIsRegister.Text = Grid_users.Rows[e.NewEditIndex].Cells[14].Text;
        }
        chkIsActive.Checked = bool.Parse(Grid_users.Rows[e.NewEditIndex].Cells[26].Text);
        txtRegdate.Text = Grid_users.Rows[e.NewEditIndex].Cells[20].Text.Replace("&nbsp;", "");
        txtCNIC.Text = Grid_users.Rows[e.NewEditIndex].Cells[23].Text.Replace("&nbsp;", "");
        txtNTN.Text = Grid_users.Rows[e.NewEditIndex].Cells[24].Text.Replace("&nbsp;", "");
        txtWHTax.Text = Grid_users.Rows[e.NewEditIndex].Cells[25].Text.Replace("&nbsp;", "0");
        
        try
        {
            ddlClassification.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[27].Text.Replace("&nbsp;", "0");
        }
        catch
        {
            ddlClassification.SelectedIndex = 0;
        }
        DrpCustomerType.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[28].Text;
        this.SetTableSorter();

        #region bankdetail


        CustomerDataController mController = new CustomerDataController();
        var dtBankInfo = mController.UspSelectCustomerBank(long.Parse(Grid_users.Rows[e.NewEditIndex].Cells[0].Text), int.Parse(Grid_users.Rows[e.NewEditIndex].Cells[1].Text));
        if (dtBankInfo == null) return;
        GrdBankInfo.DataSource = dtBankInfo;
        GrdBankInfo.DataBind();
        Session.Add("BankInfo", dtBankInfo);



        #endregion



    }

    /// <summary>
    /// Sets PageIndex Of Customer Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void Grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_users.PageIndex = e.NewPageIndex;
        this.LoadCustomer();
        this.SetTableSorter();
    }

    /// <summary>
    /// Enables GST No TextBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbIsRegister_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbIsRegister.Checked == true)
        {
            txtIsRegister.Text = "";
            txtIsRegister.Enabled = true;
        }
        else
        {
            txtIsRegister.Text = "";
            txtIsRegister.Enabled = false;
        }
        this.SetTableSorter();
    }

    /// <summary>
    /// Save Or Updates a Customer
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController mController = new CustomerDataController();

        BankInfo = (DataTable)this.Session["BankInfo"];
        if (btnSave.Text == "Save")
        {
            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("CUSTOMER", "CUSTOMER_ID", int.Parse(DrpDistributor.SelectedValue.ToString()));
           
                if (dtSettingsTable.Rows.Count > 0)
                {

                long CustomerId = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                string StrCode = "";

                #region Customer Code
                if (CustomerId.ToString().Length == 1)
                {
                    StrCode = "OT0000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 2)
                {
                    StrCode = "OT000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 3)
                {
                    StrCode = "OT00" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 4)
                {
                    StrCode = "OT0" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 5)
                {
                    StrCode = "OT" + CustomerId.ToString();
                }
                #endregion

                mController.InsertCustomer(CustomerId, ChbIsRegister.Checked, chkIsActive.Checked,
                int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpVolumeClass.SelectedValue.ToString()),
                int.Parse(DrpBusinessType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpMarket.SelectedValue.ToString()),
                int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), txtIsRegister.Text, txtContactPerson.Text,
                txtPhoneNo.Text, "", StrCode, txtCustomerName.Text, txtAddress.Text, DateTime.Parse(txtRegdate.Text), 1, 1, txtCNIC.Text, txtNTN.Text, BankInfo, decimal.Parse(dc.chkNull_0(txtWHTax.Text)), Constants.DecimalNullValue,
                Constants.IntNullValue, int.Parse(ddlClassification.SelectedValue),int.Parse(DrpCustomerType.SelectedValue));
                this.Session.Add("CustomerId", CustomerId);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Insert');", true);
                this.ClearAll();
                }
                
        }
        else
        {
                mController.UpdateCustomer(long.Parse(hdnCustomerID.Value), ChbIsRegister.Checked, chkIsActive.Checked,
                int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpVolumeClass.SelectedValue.ToString()),
                int.Parse(DrpBusinessType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpMarket.SelectedValue.ToString()),
                int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), txtIsRegister.Text, txtContactPerson.Text,
                txtPhoneNo.Text, "", null, txtCustomerName.Text, txtAddress.Text, Constants.DateNullValue, 1, 1, 
                txtCNIC.Text, txtNTN.Text, BankInfo, decimal.Parse(dc.chkNull_0 ( txtWHTax.Text)), Constants.DecimalNullValue, Constants.IntNullValue, int.Parse(ddlClassification.SelectedValue), int.Parse(DrpCustomerType .SelectedValue));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Update');", true);
                this.ClearAll();
           
        }
        
    }

    /// <summary>
    /// Clears All Controls Through ClearAll() Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }

    /// <summary>
    /// Filters Customer From Customer Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.LoadCustomer();
        this.SetTableSorter();
    }

    /// <summary>
    /// Set Customer Grid For JQuery Sorting
    /// </summary>
    private void SetTableSorter()
    {
        if (Grid_users.Rows.Count > 1)
        {
            Grid_users.UseAccessibleHeader = true;
            Grid_users.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    /// <summary>
    /// Clears All  Constrols
    /// </summary>
    private void ClearAll()
    {
        txtCustomerName.Text = "";
        txtContactPerson.Text = "";
        txtAddress.Text = "";
        txtPhoneNo.Text = "";
        txtSeach.Text = "";
        txtIsRegister.Text = "";
       
        txtWHTax.Text = "";
        txtNTN.Text = string.Empty;
        txtCNIC.Text = string.Empty;
        btnSave.Text = "Save";
        Grid_users.DataSource = null;
        Grid_users.DataBind();
        GrdBankInfo.DataSource = null;
        GrdBankInfo.DataBind();
        this.Session.Remove("BankInfo");
        btnAddBank.Text = "Add Bank";
        
    }


    private bool GetCustomerCode(string CustomerCode)
    {

        
        CustomerDataController mController = new CustomerDataController();
       // DataTable dt = mController.SelectPrincipalCustomer(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
        DataTable dt = mController.SelectAllCustomer(int.Parse(DrpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
       // clsWebFormUtil.FillListBox(ChbAreaList, dt, 0, 4, true);
        //
        List<string> lstCustomerCode = new List<string>();
        foreach (DataRow dr in dt.Rows)
        {
            if (CustomerCode == dr[2].ToString())
            {
                return false;
            }
        }
      
        return true;
    }
    private bool GetCustomerCodeUpdate(string CustomerCode,long Customer_ID)
    {


        CustomerDataController mController = new CustomerDataController();
        // DataTable dt = mController.SelectPrincipalCustomer(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
        DataTable dt = mController.SelectAllCustomer(int.Parse(DrpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
        // clsWebFormUtil.FillListBox(ChbAreaList, dt, 0, 4, true);
        //
        List<string> lstCustomerCode = new List<string>();
        foreach (DataRow dr in dt.Rows)
        {
            if (CustomerCode == dr[2].ToString() && long .Parse (dr[0].ToString())!= Customer_ID)
            {
                return false;
            }
        }

        return true;
    }

    private void CreatTable()
    {

        BankInfo = new DataTable();


        BankInfo.Columns.Add("Bank_Name", typeof(string));
        BankInfo.Columns.Add("Account_No", typeof(string));
        BankInfo.Columns.Add("BANK_ID", typeof(int));


        Session.Add("BankInfo", BankInfo);


    }
    protected void btnAddBank_Click(object sender, EventArgs e)
    {
        BankInfo = (DataTable)this.Session["BankInfo"];
        if (btnAddBank.Text == "Add Bank")
        {
            DataRow dr1 = BankInfo.NewRow();

            dr1["Bank_Name"] = txtBankName.Text;
            dr1["Account_No"] = txtAccountNo.Text;
            dr1["BANK_ID"] = 0;
            BankInfo.Rows.Add(dr1);

        }
        else 
        {

                DataRow dr1 = BankInfo.Rows[RowId];
                dr1["Bank_Name"] = txtBankName.Text;
                dr1["Account_No"] = txtAccountNo.Text;
                dr1["BANK_ID"] = lblBankId.Text;
            
        }
        this.Session.Add("BankInfo", BankInfo);
        this.LoadGird();
        btnSave.Enabled = true;
        
    }
    private void LoadGird()
    {
        BankInfo = (DataTable)this.Session["BankInfo"];
        GrdBankInfo.DataSource = BankInfo;
        GrdBankInfo.DataBind();
        txtBankName.Text = "";
        txtAccountNo.Text = "";
        txtBankName.Focus();
        btnAddBank.Text = "Add Bank";
    }


    protected void GrdBankInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BankInfo  = (DataTable)this.Session["BankInfo"];
        lblBankId.Text = GrdBankInfo.Rows[e.RowIndex].Cells[2].Text;
        BankInfo.Rows.RemoveAt(e.RowIndex);
        this.Session.Add("BankInfo", BankInfo);
        this.LoadGird();

        // delete bank from DB by safdar
        //CustomerDataController mController = new CustomerDataController();
        //mController.UpdateCustomerBank(long.Parse(lblBankId.Text),Constants .LongNullValue ,"","" , false, 1);




        //  btnCalculate.Enabled = true;
        //  btnSave.Enabled = false;
    }
    protected void GrdBankInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        txtBankName.Text = GrdBankInfo.Rows[e.NewEditIndex].Cells[0].Text;
        txtAccountNo.Text = GrdBankInfo.Rows[e.NewEditIndex].Cells[1].Text;
        lblBankId.Text = GrdBankInfo.Rows[e.NewEditIndex].Cells[2].Text;
        
        btnAddBank .Text = "Update Bank";
       
        btnSave.Enabled = false;

    }





}
