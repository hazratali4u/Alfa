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
public partial class Forms_frmDistributorAssignment : System.Web.UI.Page
{
    private void DistributorType()
    {
        DistributorController dController = new DistributorController();
        DataTable dt = dController.SelectDistributorTypeInfo(Constants.IntNullValue);
        clsWebFormUtil.FillDropDownList(ddDistributorType, dt, 0, 2);
    }
    private void LoadUser()
    {
        UserController mUserController = new UserController();
        DataTable dt = mUserController.SelectSlashUser(null,null); 
        clsWebFormUtil.FillDropDownList(ddRole,dt,0,4, true);
    }
    private void LoadUnAssingned()
    {
        if (ddRole.Items.Count > 0 && ddDistributorType.Items.Count > 0 )
        {
            UserController mUserController = new UserController();
            DataTable dt = mUserController.SelectUserAssignment(int.Parse(ddRole.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), 0, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(lstUnAssignDistributor, dt, 0, 1, true);
        }
    }
    private void LoadAssingned()
    {
        if (ddRole.Items.Count > 0 && ddDistributorType.Items.Count > 0)
        {
            UserController mUserController = new UserController();
            DataTable dt = mUserController.SelectUserAssignment(int.Parse(ddRole.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), 1, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(lstAssignDistributor, dt, 0, 1, true);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadUser();
            this.DistributorType();
            this.LoadUnAssingned();
            this.LoadAssingned();           
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        UserController mUserController = new UserController();
        for (int i = 0; i < lstUnAssignDistributor.Items.Count; i++)
        {
            if (lstUnAssignDistributor.Items[i].Selected == true && ddRole.Items.Count > 0)
            {
                mUserController.InsertUserAssignment(int.Parse(ddRole.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), int.Parse(lstUnAssignDistributor.Items[i].Value.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            }
        }
        this.LoadUnAssingned();
        this.LoadAssingned();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        UserController mUserController = new UserController();
        for (int i = 0; i < lstAssignDistributor.Items.Count; i++)
        {
            if (lstAssignDistributor.Items[i].Selected == true && ddRole.Items.Count > 0)
            {
                mUserController.DeleteUserAssignment(int.Parse(ddRole.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), int.Parse(lstAssignDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            }
        }
        this.LoadUnAssingned();
        this.LoadAssingned();
    }
    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssingned();
        this.LoadAssingned(); 
    }
    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssingned();
        this.LoadAssingned(); 
    }
  
}
