using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form To Shift Customer Between Locations, Routes And Markets
/// </summary>
public partial class Forms_frmCustomerShifting : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos And CheckedListBox On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadfromArea();
            this.LoadtoArea();
            this.LoadFromMarket();
            this.LoadToMarket();
            this.LoadCustomer();
        }
    }
    
    /// <summary>
    /// Loads Locations To All Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpfromDistributor, dt, 0, 2, true);
        clsWebFormUtil.FillDropDownList(this.DrptoDistributor, dt, 0, 2, true);
    }
    
    /// <summary>
    /// Loads Routes To From Route Combo
    /// </summary>
    private void LoadfromArea()
    {
        if (drpfromDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpfromDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpfromRoute, dt, 0, 6, true);
        }
        else
        {
            DrpfromRoute.Items.Clear();
        }
    }
    
    /// <summary>
    /// Loads Routes To To Route Comb
    /// </summary>
    private void LoadtoArea()
    {
        if (DrptoDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(DrptoDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(drptoRoute, dt, 0, 6, true);
        }
        else
        {
            drptoRoute.Items.Clear();
        }
    }
    
    /// <summary>
    /// Loads Customers To Customer CheckedBoxList
    /// </summary>
    private void LoadCustomer()
    {
        if (drpfromDistributor.Items.Count > 0 && DrpfromRoute.Items.Count > 0 && DrpFromMarket.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectPrincipalCustomer(int.Parse(drpfromDistributor.SelectedValue.ToString()), int.Parse(DrpfromRoute.SelectedValue.ToString()), Convert.ToInt32(DrpFromMarket.SelectedValue), Constants.IntNullValue);
            clsWebFormUtil.FillListBox(ChbAreaList, dt, 0, 4, true);
        }
        else
        {
            ChbAreaList.Items.Clear();
        }
    }

    /// <summary>
    /// Loads Markets To From Market Combo
    /// </summary>
    private void LoadFromMarket()
    {
        if (drpfromDistributor.Items.Count > 0 && DrpfromRoute.Items.Count > 0)
        {
            DistributorRouteController gController = new DistributorRouteController();
            DataTable dt = gController.SelectDistributorRoute(Constants.LongNullValue, int.Parse(drpfromDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpfromRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpFromMarket, dt, 0, 8, true);

        }
        else
        {
            DrpFromMarket.Items.Clear();
        }
    }

    /// <summary>
    /// Loads Markets To To Market Combo
    /// </summary>
    private void LoadToMarket()
    {
        if (DrptoDistributor.Items.Count > 0 && drptoRoute.Items.Count > 0)
        {
            DistributorRouteController gController = new DistributorRouteController();
            DataTable dt = gController.SelectDistributorRoute(Constants.LongNullValue, int.Parse(DrptoDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(drptoRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpToMarket, dt, 0, 8, true);

        }
        else
        {
            DrpToMarket.Items.Clear();
        }
    }
        
    /// <summary>
    /// Loads Routes To From Route Combo, Markets To From Market Combo And Customers To Customer CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpfromDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadfromArea();
        this.LoadFromMarket();
        this.LoadCustomer();
        this.UncheckSelectAll();
    }

    /// <summary>
    /// Loads Routes To To Route Combo And Markets To To Market Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrptoDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadtoArea();
        this.LoadToMarket();
        this.UncheckSelectAll();
    }

    /// <summary>
    /// Loads Markets To From Market Combo And Customers To Customer CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpfromRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadFromMarket();
        this.LoadCustomer();
        this.UncheckSelectAll();
    }
    
    /// <summary>
    /// Shifts Customer
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController cd = new CustomerDataController();
        foreach (ListItem item in ChbAreaList.Items)
        {
            if (item.Selected == true)
            {
                cd.CustomerShifting(int.Parse(drpfromDistributor.SelectedValue.ToString()), int.Parse(DrptoDistributor.SelectedValue.ToString()),
                    int.Parse(DrpfromRoute.SelectedValue.ToString()), int.Parse(drptoRoute.SelectedValue.ToString()), Convert.ToInt32(DrpFromMarket.SelectedValue), Convert.ToInt32(DrpToMarket.SelectedValue), int.Parse(item.Value)); 
            }
        }
        this.LoadCustomer();
        this.UncheckSelectAll();
    }

    /// <summary>
    /// UnChecks "Select All" CheckBox
    /// </summary>
    private void UncheckSelectAll()
    {
        ChbSelectAll.Checked = false;
    }

    /// <summary>
    /// Loads Markets To To Market Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drptoRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadToMarket();
        this.UncheckSelectAll();
    }

    /// <summary>
    /// Loads Customers To Customer CheckedBoxList
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpFromMarket_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer();
        this.UncheckSelectAll();
    }
}
