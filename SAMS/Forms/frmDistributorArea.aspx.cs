using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// From to Add And Update Routes And Markets Of Locations.
/// </summary>
public partial class Forms_frmDistributorArea : System.Web.UI.Page
{
    static long Area_Id;
    static long Route_id;
    static string strcode = "";

    /// <summary>
    /// Page_Load Function Populates All Combos and Grids On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadTown();
            this.LoadGrid();
            this.LoadMTown();
            this.LoadAREA();
            this.LoadMarketGrid();
            btnSaveRoute.Attributes.Add("onclick", "return ValidateArea()");
            btnSaveMarket.Attributes.Add("onclick", "return ValidateRoute()");

            this.SetTableSorter();
        }
    }
    
    #region Route Tab

    /// <summary>
    /// Loads Locations To Both Locations Combo Of Market And Route Tabs.
    /// </summary>
    private void LoadDISTRIBUTOR()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dtDistributor, 0, 2, true);
        clsWebFormUtil.FillDropDownList(drpMDistributor, dtDistributor, 0, 2, true);
    }

    /// <summary>
    /// Loads Towns To Town Combo On Route Tab
    /// </summary>
    private void LoadTown()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DistributorTownController gController = new DistributorTownController();
            DataTable dt = gController.SelectAssignTown(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(drpTown, dt, 0, 1, true);
        }
    }

    /// <summary>
    /// Loads Rotes To Route Grid On Route Tab
    /// </summary>
    private void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0 && drpTown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpTown.SelectedValue.ToString()), null, null);
            grdAreaData.DataSource = dt;
            grdAreaData.DataBind();
            this.SetTableSorter();
        }
    }

    /// <summary>
    /// Loads Town To Town Combo And Routes To Route Grid On Route Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Loads Routes To Route Grid On Route Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Sets Route Name For Edit. This Function Runs When An Existing Route Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void grdAreaData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Area_Id = long.Parse(grdAreaData.Rows[e.NewEditIndex].Cells[0].Text);
        int TownId = int.Parse(grdAreaData.Rows[e.NewEditIndex].Cells[2].Text);
        for (int i = 0; drpTown.Items.Count > 0; i++)
        {
            if (int.Parse(drpTown.Items[i].Value.ToString()) == TownId)
            {
                drpTown.Items[i].Selected = true;
                break;
            }
        }
        strcode = grdAreaData.Rows[e.NewEditIndex].Cells[5].Text;
        txtAreaName.Text = grdAreaData.Rows[e.NewEditIndex].Cells[6].Text;
        ChIsActive.Checked = bool.Parse(grdAreaData.Rows[e.NewEditIndex].Cells[7].Text);
        drpDistributor.Enabled = false;
        drpTown.Enabled = false;
        btnSaveRoute.Text = "Update";
        this.SetTableSorter();
    }

    /// <summary>
    /// Sets PageIndex Of Route Grid On Route Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void grdAreaData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAreaData.PageIndex = e.NewPageIndex;
        this.LoadGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Saves Or Updates A Route.
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSaveRoute_Click(object sender, EventArgs e)
    {
        DistributorAreaController mController = new DistributorAreaController();
        if (btnSaveRoute.Text == "Save")
        {
            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("DISTRIBUTOR_AREA", "AREA_ID", int.Parse(drpDistributor.SelectedValue.ToString()));

            if (dtSettingsTable.Rows.Count > 0)
            {
                Area_Id = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                if (Area_Id.ToString().Length == 1)
                {
                    strcode = "RT" + "00" + Area_Id.ToString();
                }
                else if (Area_Id.ToString().Length == 2)
                {
                    strcode = "RT" + "0" + Area_Id.ToString();
                }
                else if (Area_Id.ToString().Length == 3)
                {
                    strcode = "RT" + Area_Id.ToString();
                }

                mController.insertDisct_Area(long.Parse(Area_Id.ToString()), bool.Parse("true"), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpTown.SelectedValue.ToString()), txtAreaName.Text, strcode);

            }
        }
        else if (btnSaveRoute.Text == "Update")
        {
            mController.UpdateDisct_Area(Area_Id, ChIsActive.Checked, System.DateTime.Now, System.DateTime.Now, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpTown.SelectedValue.ToString()), txtAreaName.Text, strcode);

        }
        this.LoadAREA();
        this.LoadGrid();
        drpDistributor.Enabled = true;
        drpTown.Enabled = true;
        txtAreaName.Text = "";
        btnSaveRoute.Text = "Save";
        this.SetTableSorter();
    }

    #endregion

    #region Market Tab

    /// <summary>
    /// Loads Towns To Town Combo Of Market Tab
    /// </summary>
    private void LoadMTown()
    {
        if (drpMDistributor.Items.Count > 0)
        {
            DistributorTownController gController = new DistributorTownController();
            DataTable dt = gController.SelectAssignTown(Constants.IntNullValue, int.Parse(drpMDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(DrpMTown, dt, 0, 1, true);
        }
    }

    /// <summary>
    /// Routes To Route Combo On Market Tab
    /// </summary>
    private void LoadAREA()
    {
        if (drpMDistributor.Items.Count > 0 && DrpMTown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
    }

    /// <summary>
    /// Loads Market Grid On Market Grid
    /// </summary>
    private void LoadMarketGrid()
    {
        if (drpMDistributor.Items.Count > 0 && DrpMTown.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            DistributorRouteController mController = new DistributorRouteController();
            DataTable dt = mController.SelectDistributorRoute(Constants.LongNullValue, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), long.Parse(DrpRoute.SelectedValue.ToString()));
            grdRouteData.DataSource = dt;
            grdRouteData.DataBind();
            this.SetTableSorter();
        }
    }

    /// <summary>
    /// Loads Towns To Town Combo, Routes To Route Combo And Markets To Market Grid On Market Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpMDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMTown();
        this.LoadAREA();
        this.LoadMarketGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Loads Routes To Route Combo And Markets To Market Grid On Market Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpMTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAREA();
        this.LoadMarketGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Loads Markets To Market Grid On Market Tab
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMarketGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Sets Market Name For Edit. This Function Runs When An Existing Market Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void grdRouteData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Route_id = long.Parse(grdRouteData.Rows[e.NewEditIndex].Cells[0].Text);
        strcode = grdRouteData.Rows[e.NewEditIndex].Cells[7].Text;
        txtMarketName.Text = grdRouteData.Rows[e.NewEditIndex].Cells[8].Text;
        chMarkeIsActive.Checked = bool.Parse(grdRouteData.Rows[e.NewEditIndex].Cells[9].Text);
        drpMDistributor.Enabled = false;
        drpMDistributor.Enabled = false;
        DrpMTown.Enabled = false;
        DrpRoute.Enabled = false;
        btnSaveMarket.Text = "Update";
        this.SetTableSorter();
    }

    /// <summary>
    /// Sets PageIndex Of Market Grid On Market Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void grdRouteData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRouteData.PageIndex = e.NewPageIndex;
        this.LoadMarketGrid();
        this.SetTableSorter();
    }

    /// <summary>
    /// Saves Or Updates A Market.
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSaveMarket_Click(object sender, EventArgs e)
    {
        DistributorRouteController mController = new DistributorRouteController();
        if (btnSaveMarket.Text == "Save")
        {
            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("DISTRIBUTOR_ROUTE", "ROUTE_ID", int.Parse(drpMDistributor.SelectedValue.ToString()));

            if (dtSettingsTable.Rows.Count > 0)
            {
                Route_id = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                if (Route_id.ToString().Length == 1)
                {
                    strcode = "MR" + "00" + Route_id.ToString();
                }
                else if (Route_id.ToString().Length == 2)
                {
                    strcode = "MR" + "0" + Route_id.ToString();
                }
                else if (Route_id.ToString().Length == 3)
                {
                    strcode = "MR" + Route_id.ToString();
                }
                mController.InsertDistributorRoute(Route_id, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), strcode, txtMarketName.Text, true);

            }
        }
        else
        {
            mController.UpdateDistributorRoute(Route_id, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), strcode, txtMarketName.Text, chMarkeIsActive.Checked);

        }
        drpMDistributor.Enabled = true;
        drpMDistributor.Enabled = true;
        DrpMTown.Enabled = true;
        DrpRoute.Enabled = true;
        btnSaveMarket.Text = "Save";
        txtMarketName.Text = "";
        this.LoadMarketGrid();
        this.SetTableSorter();
    }

    #endregion

    /// <summary>
    /// Sets Grids Properties For JQuery Sorting.
    /// </summary>
    private void SetTableSorter()
    {
        if (grdAreaData.Rows.Count > 1)
        {
            grdAreaData.UseAccessibleHeader = true;
            grdAreaData.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (grdRouteData.Rows.Count > 1)
        {
            grdRouteData.UseAccessibleHeader = true;
            grdRouteData.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
      
    
    
    
    
    
    
    
        
    
    
    
    
    
}
