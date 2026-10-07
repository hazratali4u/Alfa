using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using System.Threading; 

/// <summary>
/// From to Add, Edit Employee
/// </summary>
public partial class Forms_frmSaleForce : System.Web.UI.Page
{
    Distributor_UserController UController = new Distributor_UserController();
    static int UserId;

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
            this.LoadDesignation();
            this.LoadGrid();
            btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }

        Response.Expires = 0;
        Response.Cache.SetNoStore();
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDISTRIBUTOR()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributorUser(Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), int.Parse(this.Session["UserId"].ToString()));
        ddDistributorId.DataSource = dtDistributor;
        ddDistributorId.DataTextField = "DISTRIBUTOR_NAME";
        ddDistributorId.DataValueField = "DISTRIBUTOR_ID";
        ddDistributorId.DataBind();
    }

    /// <summary>
    /// Loads Designations To Designation Combo
    /// </summary>
    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable m_dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.SaleForce, null, Constants.IntNullValue, true);
        ddDesignation.DataSource = m_dt;
        ddDesignation.DataTextField = "SLASH_DESC";
        ddDesignation.DataValueField = "REF_ID";
        ddDesignation.DataBind();
    }
    
    /// <summary>
    /// Loads Active Employees To Employee Grid
    /// </summary>
    protected void LoadGrid()
    {
        if (ddDistributorId.Items.Count > 0)
        {
            DataTable dt = UController.SelectDistributorUser(Constants.IntNullValue, int.Parse(ddDistributorId.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            this.Grid_users.DataSource = dt;
            this.Grid_users.DataBind();
        }
    }

    /// <summary>
    /// Loads Employees To Employee Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddDistributorId_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    /// <summary>
    /// Sets Employee Data For Edit. This Function Runs When An Existing Employee Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridViewRow gvr = this.Grid_users.Rows[e.NewEditIndex];
            UserId  = int.Parse(gvr.Cells[0].Text);
            
            if (gvr.Cells[2].Text == "&nbsp;")
            {
                txtUserName.Text = null;
            }
            else
            {
                this.txtUserName.Text = gvr.Cells[2].Text;
            }
            if (gvr.Cells[3].Text == "&nbsp;")
            {
                txtNICNo.Text = null;
            }
            else
            {
                this.txtNICNo.Text = gvr.Cells[3].Text;
            }

            if (gvr.Cells[4].Text == "&nbsp;")
            {
                txtPhoneNo.Text = null;
            }
            else
            {
                this.txtPhoneNo.Text = gvr.Cells[4].Text;
            }
            if (gvr.Cells[5].Text == "&nbsp;")
            {
                txtMobileNo.Text = null;
            }
            else
            {
                this.txtMobileNo.Text = gvr.Cells[5].Text;
            }
            if (gvr.Cells[6].Text == "&nbsp;")
            {
                txtEmail.Text = null;
            }
            else
            {
                this.txtEmail.Text = gvr.Cells[6].Text;
            }
            if (gvr.Cells[7].Text == "&nbsp;")
            {
                txtAddress1.Text = null;
            }
            else
            {
                this.txtAddress1.Text = gvr.Cells[7].Text;
            }
            if (gvr.Cells[8].Text == "&nbsp;")
            {
                txtAddress2.Text = null;
            }
            else
            {
                this.txtAddress2.Text = gvr.Cells[8].Text;
            }

            this.chkIsActive.Checked = bool.Parse(gvr.Cells[10].Text);
            ddDesignation.SelectedValue = gvr.Cells[11].Text;

            try
            {
                if (gvr.Cells[13].Text == "&nbsp;")
                {
                    txtCreditLimit.Text = null;
                }
                else
                {
                    this.txtCreditLimit.Text =Math.Round(decimal.Parse(gvr.Cells[13].Text),2).ToString();
                }


                if (gvr.Cells[14].Text == "&nbsp;")
                {
                    txtCreditDays.Text = null;
                }
                else
                {
                    this.txtCreditDays.Text = int.Parse(gvr.Cells[14].Text).ToString();
                }
            }
            catch (Exception ex)
            {
            }

          

            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }

    /// <summary>
    /// Sets PageIndex Of Employee Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void Grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_users.PageIndex = e.NewPageIndex;
        this.LoadGrid(); 
    }

    /// <summary>
    /// Saves Or Updates An Employee.
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataControl dc = new  DataControl();
            if (btnSave.Text == "Save")
            {
                SETTINGS_TABLE_Controller mAutoCode = new SETTINGS_TABLE_Controller();

                string strcode = "";
                UserId = int.Parse(mAutoCode.GetAutoCustomerCode("EM", 0, Constants.LongNullValue).ToString());

                if (UserId.ToString().Length == 1)
                {
                    strcode = "EM" + "000" + UserId.ToString();
                }
                else if (UserId.ToString().Length == 2)
                {
                    strcode = "EM" + "00" + UserId.ToString();
                }
                else if (UserId.ToString().Length == 3)
                {
                    strcode = "EM" + "0" + UserId.ToString();
                }
                else
                {
                    strcode = "EM" + UserId.ToString();
                }

                string SaleForceId = UController.InsertDistributor_User(int.Parse(this.Session["CompanyId"].ToString()), txtNICNo.Text, true, System.DateTime.Now, System.DateTime.Now, int.Parse(ddDesignation.SelectedValue.ToString()),
                    int.Parse(ddDistributorId.SelectedValue.ToString()), Constants.IntNullValue, txtEmail.Text, txtAddress1.Text, txtAddress2.Text, txtLoginId.Text, txtpassword.Text
                    , txtMobileNo.Text, strcode, txtUserName.Text, txtPhoneNo.Text,decimal.Parse(dc.chkNull_0(txtCreditLimit.Text)),int.Parse(dc.chkNull_0(txtCreditDays.Text)));

                mAutoCode.GetAutoCustomerCode("EM", 1, long.Parse(UserId.ToString()));
            }
            else if (btnSave.Text == "Update")
            {
                UController.UpdateDistributor_User(UserId, int.Parse(this.Session["CompanyId"].ToString()), txtNICNo.Text, chkIsActive.Checked, System.DateTime.Now, System.DateTime.Now, int.Parse(ddDesignation.SelectedValue.ToString()),
                    int.Parse(ddDistributorId.SelectedValue.ToString()), Constants.IntNullValue, txtEmail.Text, txtAddress1.Text, txtAddress2.Text, txtLoginId.Text, txtpassword.Text
                    , txtMobileNo.Text, null, txtUserName.Text, txtPhoneNo.Text, decimal.Parse(dc.chkNull_0(txtCreditLimit.Text)), int.Parse(dc.chkNull_0(txtCreditDays.Text)));
            }
            LoadGrid();
            ClearControls();
            btnSave.Text = "Save";
        }

        catch (Exception ex)
        {

        }
    }

    /// <summary>
    /// Cancels Save Or Update Transaction
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        LoadGrid();
        ClearControls();
        btnSave.Text = "Save";
    }

    /// <summary>
    /// Clears Form Controls
    /// </summary>
    protected void ClearControls()
    {
        try
        {
            txtCreditDays.Text = null;
            txtCreditLimit.Text = null;
            txtUserName.Text = null;
            txtPhoneNo.Text = null;
            txtMobileNo.Text = null;
            txtAddress1.Text = null;
            txtAddress2.Text = null;
            txtEmail.Text = null;
            txtLoginId.Text = null;
            txtpassword.Text = null;
            txtNICNo.Text = null;
            lblErrorMsg.Text = null;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}
