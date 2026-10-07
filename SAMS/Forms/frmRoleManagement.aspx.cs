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
using SAMSCommon.Classes;
using SAMSBusinessLayer.Classes;
using SAMSBusinessLayer.Reports;

/// <summary>
/// From to Assign, UnAssign Forms To Users
/// </summary>
public partial class frmRoleManagement : System.Web.UI.Page
{
    RoleManagementController mController = new RoleManagementController();
    DataControl dc = new DataControl();

    /// <summary>
    /// Page_Load Function Populates All Combos and ListBox On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            this.LoadRole();
            this.LoadMod1stLayer();
            this.LoadMod2ndtLayer();
            this.LoadMod3rdtLayer();
            int Role_Id = Convert.ToInt32(ddRole.SelectedValue.ToString());
            this.GetUnAssingModule(Role_Id);
            this.GetAssingModule(Role_Id);
        }
    }

    /// <summary>
    /// Loads Roles To Role Combo
    /// </summary>
    private void LoadRole()
    {
        DataTable dt = mController.SelectRoleMaster(0, null, System.DateTime.Today, System.DateTime.Today, true);
        ddRole.DataSource = dt;
        ddRole.DataTextField = "ROLE_NAME";
        ddRole.DataValueField = "ROLE_ID";
        ddRole.DataBind();
    }

    /// <summary>
    /// Loads First Layer Module To First Layer Module Combo
    /// </summary>
    private void LoadMod1stLayer()
    {
        DataTable dt = mController.SelectModule(Constants.IntNullValue, null, Constants.IntNullValue, Constants.Mod_1st_Layer, Constants.DateNullValue, true);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        DrpModule1stLayer.DataSource = dt.DefaultView;
        DrpModule1stLayer.DataTextField = "MODULE_DESCRIPTION";
        DrpModule1stLayer.DataValueField = "MODULE_ID";
        DrpModule1stLayer.DataBind();
    }
    
    /// <summary>
    /// Loads Second Layer Module To Second Layer Module Combo
    /// </summary>
    private void LoadMod2ndtLayer()
    {
        DataTable dt = mController.SelectModule(Constants.IntNullValue, null, int.Parse(dc.chkNull(DrpModule1stLayer.SelectedValue.ToString())), Constants.Mod_2nd_Layer, Constants.DateNullValue, true);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        DrpModule2ndLayer.DataSource = dt.DefaultView;
        DrpModule2ndLayer.DataTextField = "MODULE_DESCRIPTION";
        DrpModule2ndLayer.DataValueField = "MODULE_ID";
        DrpModule2ndLayer.DataBind();
    }
    
    /// <summary>
    /// Loads Third Layer Module To Third Layer Module Combo
    /// </summary>
    private void LoadMod3rdtLayer()
    {
        DataTable dt = mController.SelectModule(Constants.IntNullValue, null, int.Parse(dc.chkNull(DrpModule2ndLayer.SelectedValue.ToString())), Constants.Mod_3rd_Layer, Constants.DateNullValue, true);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        DrpModule3rdLayer.DataSource = dt.DefaultView;
        DrpModule3rdLayer.DataTextField = "MODULE_DESCRIPTION";
        DrpModule3rdLayer.DataValueField = "MODULE_ID";
        DrpModule3rdLayer.DataBind();
    }
    
    /// <summary>
    /// Loads Fourth Layers Modules Not Assigned To Role To ListBox
    /// </summary>
    /// <param name="RoleID"></param>
    private void GetUnAssingModule(int RoleID)
    {
        DataTable dt = mController.GetAssignUnAssignModule(RoleID, int.Parse(dc.chkNull(DrpModule3rdLayer.SelectedValue.ToString())), Constants.IntNullValue, 0);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        lstUnAssignModule.DataSource = dt.DefaultView;
        lstUnAssignModule.DataTextField = "MODULE_DESCRIPTION";
        lstUnAssignModule.DataValueField = "MODULE_ID";
        lstUnAssignModule.DataBind();
    }
    
    /// <summary>
    /// Loads Fourth Layers Modules Assigned To Role To ListBox
    /// </summary>
    /// <param name="RoleID"></param>
    private void GetAssingModule(int RoleID)
    {
        DataTable dt = mController.GetAssignUnAssignModule(RoleID, int.Parse(dc.chkNull(DrpModule3rdLayer.SelectedValue.ToString())), Constants.IntNullValue, 1);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        lstAssignModule.DataSource = dt.DefaultView;
        lstAssignModule.DataTextField = "MODULE_DESCRIPTION";
        lstAssignModule.DataValueField = "MODULE_ID";
        lstAssignModule.DataBind();
    }

    /// <summary>
    /// Loads Fourth Layers Modules Assigned To Role To ListBox And Fourth Layers Modules Not Assigned To Role To ListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
    }

    /// <summary>
    /// Loads Fourth Layers Modules Assigned To Role To ListBox,Fourth Layers Modules Not Assigned To Role To ListBox,
    /// Loads Second Layer Module To Second Layer Module Combo And Loads Third Layer Module To Third Layer Module Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpModule1stLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMod2ndtLayer();
        this.LoadMod3rdtLayer();
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
    }

    /// <summary>
    /// Loads Fourth Layers Modules Assigned To Role To ListBox,Fourth Layers Modules Not Assigned To Role To ListBox,
    /// And Loads Third Layer Module To Third Layer Module Combo
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpModule2ndLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMod3rdtLayer();
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
    }

    /// <summary>
    /// Loads Fourth Layers Modules Assigned To Role To ListBox And Fourth Layers Modules Not Assigned To Role To ListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpModule3rdLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
    }
    
    /// <summary>
    /// Shows Text Box To Add New Role 
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (this.btnNew.Text == "New")
        {
            this.ddRole.Visible = false;
            this.TextBox1.Text = null;
            this.TextBox1.Visible = true;
            this.TextBox1.Enabled = true;
            this.btnNew.Text = "Save";
        }
        else
        {
            if (this.TextBox1.Text == "")
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Enter Role.";
            }
            else
            {
                lblmsg.Visible = false;
                mController.InsertRoleMaster(this.TextBox1.Text, System.DateTime.Today, System.DateTime.Today,true);
                LoadRole();
                this.lblmsg.Visible = false;
            }
            this.btnNew.Text = "New";
            this.ddRole.Visible = true;
            this.TextBox1.Visible = false;
        }
    }

    /// <summary>
    /// Assigns Page To a Role
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        if (lstUnAssignModule.Items.Count > 0)
        {
            for (int i = 0; i < lstUnAssignModule.Items.Count; i++)
            {

                if (lstUnAssignModule.Items[i].Selected == true)
                {
                    mController.InsertRoleDetail(int.Parse(ddRole.SelectedValue.ToString()), Convert.ToInt32(lstUnAssignModule.SelectedValue.ToString()), 1);

                }
            }
            this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
            this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        }
    }
    
    /// <summary>
    /// UnAssigns Page To a Role
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnUnAssign_Click(object sender, EventArgs e)
    {
        int Role_Id = Convert.ToInt32(this.ddRole.SelectedValue.ToString());
        string Module_Id = lstAssignModule.SelectedValue.ToString();
        if (this.lstAssignModule.Items.Count > 0)
        {
            for (int i = 0; i < lstAssignModule.Items.Count; i++)
            {
                if (lstAssignModule.Items[i].Selected == true)
                {

                    mController.InsertRoleDetail(int.Parse(ddRole.SelectedValue.ToString()), Convert.ToInt32(lstAssignModule.SelectedValue.ToString()), 0);

                }
            }
            this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
            this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        }
    }
    
    /// <summary>
    /// Shows All Roles And Thier Assigned Pages
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnReport_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();

        DataSet ds = DPrint.SelectRoleManagmentReport(int.Parse(ddRole.SelectedValue.ToString()));
        DataTable dt = DPrint.SelectReportTitle(Constants.IntNullValue);

        SAMSBusinessLayer.Reports.CrpRoleManagement CrpReport = new SAMSBusinessLayer.Reports.CrpRoleManagement();
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());

        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }
}
