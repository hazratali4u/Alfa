using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form For Customer Credit Limit And Principal Assignment
/// </summary>
public partial class Forms_frmCustomerCreditLimit : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos And Grids On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadChannelType();
            this.LoadBusinessType();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
        }
    }

    /// <summary>
    /// Loads Customers To Customer Grid
    /// </summary>
    private void LoadCustomer()
    {
        if (DrpDistributor.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.UspSelectCustomer(int.Parse(DrpDistributor.SelectedValue.ToString()), ddSearchType.SelectedValue.ToString(), txtSeach.Text);
            this.Grid_users.DataSource = dt;
            this.Grid_users.DataBind();
        }
    }
    
    /// <summary>
    /// Loads Channel Types To Channel Type Combo Inside Principal Grid
    /// </summary>
    private void LoadChannelType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, bool.Parse("True"));
        foreach (GridViewRow dr in GrdCreditLimit.Rows)
        {
            DropDownList DrpChannel = (DropDownList)dr.FindControl("drpChannelType");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DrpChannel.Items.Add(new ListItem(dt.Rows[i][2].ToString(), dt.Rows[i][0].ToString()));
            }
        }
    }
    
    /// <summary>
    /// Loads Principals To Principal Grid
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        GrdCreditLimit.DataSource = m_dt;
        GrdCreditLimit.DataBind();
    }
    
    /// <summary>
    /// Loads Business Types To Business Type Combo Inside Principal Grid
    /// </summary>
    private void LoadBusinessType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerTypeBusiness, null, Constants.IntNullValue, bool.Parse("True"));

        foreach (GridViewRow dr in GrdCreditLimit.Rows)
        {
            DropDownList DrpChannel = (DropDownList)dr.FindControl("DrpBusinessType");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DrpChannel.Items.Add(new ListItem(dt.Rows[i][2].ToString(), dt.Rows[i][0].ToString()));
            }
        }
    }
    
    /// <summary>
    /// Load Locations To Location Comb
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpDistributor, dt, 0, 2, true);
    }
        
    /// <summary>
    /// Inserts Customer Credit Limit And Assigns Customer To Principal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController mCustomer = new CustomerDataController();
        DataControl dc = new DataControl();
        
        for (int i = 0; i < GrdCreditLimit.Rows.Count; i++)
        {
            TextBox txtCLimit = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
            TextBox txtCRDays = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
            CheckBox ChIsAssign = (CheckBox)GrdCreditLimit.Rows[i].FindControl("ChbSelect");
            DropDownList DrpChannel = (DropDownList)GrdCreditLimit.Rows[i].FindControl("drpChannelType");
            DropDownList DrpBusinessType = (DropDownList)GrdCreditLimit.Rows[i].FindControl("DrpBusinessType");
            DropDownList DrpVolumeClass = (DropDownList)GrdCreditLimit.Rows[i].FindControl("DrpVolumeClass");
            DropDownList DrpType = (DropDownList)GrdCreditLimit.Rows[i].FindControl("DrpType");

            mCustomer.InsertCustomerCreditLimit(int.Parse(DrpDistributor.SelectedValue.ToString()), long.Parse(this.Session["CustomerId"].ToString())  ,
                    int.Parse(GrdCreditLimit.Rows[i].Cells[0].Text), decimal.Parse(dc.chkNull_0(txtCLimit.Text)), int.Parse(dc.chkNull(txtCRDays.Text)),
                        int.Parse(DrpChannel.SelectedValue.ToString()),int.Parse(DrpBusinessType.SelectedValue.ToString())
                        ,DrpVolumeClass.SelectedItem.Text,DrpType.SelectedItem.Text,ChIsAssign.Checked);
            
        }
        this.SetTableSorter();
    }

    /// <summary>
    /// Sets Customer Credit Limit For Edit. This Function Runs When An Existing Customer Credit Limit Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CustomerDataController mCustomer = new CustomerDataController();

        this.Session.Add("CustomerId", Grid_users.Rows[e.NewEditIndex].Cells[0].Text); 
      
        for (int i = 0; i < GrdCreditLimit.Rows.Count; i++)
        {
            DataTable dtCLimit = mCustomer.SelectCustomerCreditLimit(int.Parse(DrpDistributor.SelectedValue.ToString()), long.Parse(this.Session["CustomerId"].ToString()), int.Parse(GrdCreditLimit.Rows[i].Cells[0].Text));
            if (dtCLimit.Rows.Count > 0)
            {
                TextBox txtCLimit = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
                TextBox txtCRDays = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
                CheckBox ChIsAssign = (CheckBox)GrdCreditLimit.Rows[i].FindControl("ChbSelect");
                DropDownList DrpChannel = (DropDownList)GrdCreditLimit.Rows[i].FindControl("drpChannelType");
                DropDownList DrpBusinessType = (DropDownList)GrdCreditLimit.Rows[i].FindControl("DrpBusinessType");
                DropDownList DrpVolumeClass = (DropDownList)GrdCreditLimit.Rows[i].FindControl("DrpVolumeClass");
                DropDownList DrpType = (DropDownList)GrdCreditLimit.Rows[i].FindControl("DrpType");

                txtCLimit.Text = dtCLimit.Rows[0]["CREDITLIMIT_VALUE"].ToString();
                txtCRDays.Text = dtCLimit.Rows[0]["CREDIT_DAYS"].ToString();


                DrpChannel.SelectedValue = dtCLimit.Rows[0]["CHANNEL_TYPE_ID"].ToString();
                DrpBusinessType.SelectedValue = dtCLimit.Rows[0]["BUSINESS_TYPE_ID"].ToString();

                DrpVolumeClass.SelectedItem.Text = dtCLimit.Rows[0]["CLASSFICATION"].ToString();
                DrpType.SelectedValue = dtCLimit.Rows[0]["CUSTOMER_TYPE"].ToString();

                ChIsAssign.Checked = true;
            }
            else
            {
                TextBox txtCLimit = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
                TextBox txtCRDays = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
                CheckBox ChIsAssign = (CheckBox)GrdCreditLimit.Rows[i].FindControl("ChbSelect");

                txtCLimit.Text = "0";
                txtCRDays.Text = "0";
                ChIsAssign.Checked = false;
            }
            this.SetTableSorter();
        }
    }

    /// <summary>
    /// Set Customer Grid Fro JQuery Sorting
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
    /// Searches And Loads Customers To Customer Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.LoadCustomer();
        this.SetTableSorter();
    }
}
