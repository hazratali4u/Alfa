using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;

/// <summary>
/// Form To Post HHT Orders
/// </summary>
public partial class Forms_frmHHPosting : System.Web.UI.Page
{
    HHPostingController postingController = new HHPostingController();
    GeoHierarchyController geoHeierarchycontroller = new GeoHierarchyController();
    SaleForceController distController = new SaleForceController();
    DataTable dt_SalesForce = new DataTable();

    /// <summary>
    /// Page_Load Function Populates All Combos On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.chkSelectAll.Visible = false;
            LoadSalesForce();
            LoadDilveryMan();

            this.GridSalesOrder.Attributes.Add("onclick", "document.getElementById('hiddenField').value = this.rowIndex;");
        }
    }

    /// <summary>
    /// Loads Sale Forces To Sale Force Combo
    /// </summary>
    public void LoadSalesForce()
    {
        int Distributor_ID = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
        dt_SalesForce = distController.SelectDistributorSalesForceType(Distributor_ID, 35,true);

        this.ddSalesForce.DataSource = dt_SalesForce;
        this.ddSalesForce.DataTextField = "USER_NAME";
        this.ddSalesForce.DataValueField = "USER_ID";
        this.ddSalesForce.DataBind();
    }
    
    /// <summary>
    /// Loads Delivermen To Deliverman Combo
    /// </summary>
    public void LoadDilveryMan()
    {
        DataTable DilveryMan = new DataTable();
        int Distributor_ID = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
        DilveryMan = distController.SelectDistributorSalesForceType(Distributor_ID, 36,true);
        this.ddDilverMan.DataSource = DilveryMan;
        this.ddDilverMan.DataTextField = "USER_NAME";
        this.ddDilverMan.DataValueField = "USER_ID";
        this.ddDilverMan.DataBind();
    }
    
    /// <summary>
    /// Loads HHT Orders To Grid
    /// </summary>
    public void GetOrders()
    {
        try
        {
            DataTable dt = postingController.GetOrders(Convert.ToInt32(ddSalesForce.SelectedValue.ToString()), 1);
            if (dt.Rows.Count > 0)
            {
                this.DivGrid.Visible = true;
                this.chkSelectAll.Visible = true;
                this.ddDilverMan.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnCancle.Enabled = true;
                
                this.GridSalesOrder.DataSource = dt;
                this.GridSalesOrder.DataBind();
            }
            else
            {
                this.DivGrid.Visible = false;
                this.GridSalesOrder.DataSource = null;
                this.GridSalesOrder.DataBind();
                this.chkSelectAll.Checked = false;
                this.chkSelectAll.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    
    /// <summary>
    /// Loads HHT Orders To Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnGetOrders_Click(object sender, EventArgs e)
    {
        GetOrders();
    }
    
    /// <summary>
    /// Post HHT Orders To Database
    /// </summary>
    protected void AssignDilveryMan()
    {
        try
        {
            DataTable dt = new DataTable();
            int hhSaleOrderID = 0;
            string UserID = this.Session["UserId"].ToString();

            for (int i = 0; i < GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                if (ChbSelect.Checked == true)
                {
                    hhSaleOrderID = Convert.ToInt32(GridSalesOrder.Rows[i].Cells[2].Text);
                    bool var = postingController.InsertSaleOrderMaster(hhSaleOrderID, Convert.ToInt32(ddSalesForce.SelectedValue.ToString()), Convert.ToInt32(ddDilverMan.SelectedValue.ToString()), SAMSCommon.Classes.Constants.Order_Pending_Id, Convert.ToInt32(UserID));
                }
            }

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    /// <summary>
    /// Checks/UnChecks HHT Orders In Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectAll.Checked == true)
        {
            for (int i = 0; i < this.GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                ChbSelect.Checked = true;

            }
        }
        if (chkSelectAll.Checked == false)
        {
            for (int i = 0; i < this.GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                ChbSelect.Checked = false;
            }
        }
    }

    /// <summary>
    /// Loads HHT Orders To Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnGetOrders_Click1(object sender, EventArgs e)
    {
       GetOrders();
    }

    /// <summary>
    /// Post HHT Orders To Database
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AssignDilveryMan();
        GetOrders();
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        CancleOrder();
        GetOrders();
    }
    protected void CancleOrder()
    {
        try
        {
            DataTable dt = new DataTable();
            int hhSaleOrderID = 0;
            string UserID = this.Session["UserId"].ToString();

            for (int i = 0; i < GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                if (ChbSelect.Checked == true)
                {
                    hhSaleOrderID = Convert.ToInt32(GridSalesOrder.Rows[i].Cells[2].Text);
                    bool var = postingController.InsertSaleOrderMaster(hhSaleOrderID, Convert.ToInt32(ddSalesForce.SelectedValue.ToString()), 0, -1, Convert.ToInt32(UserID));
                }
            }

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

}
