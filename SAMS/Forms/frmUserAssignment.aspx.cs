using System;
using System.Data;
using System.Web.UI;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// From To Assign/UnAssign Location, Principals And VoucherTypes To Users
/// </summary>
public partial class Forms_frmUserAssignment : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos And ListBox On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadVoucherType();
            this.LoadUser();
            this.DistributorType();
            this.LoadUnAssingned();
            this.LoadAssingned();
            this.AssignBrand();
            this.UnAssignBrand();
            this.AssignVoucherType();
    
        }
    }

    /// <summary>
    /// Loads Users To User Combo
    /// </summary>
    private void LoadUser()
    {
        UserController mUserController = new UserController();
        DataTable dt = mUserController.SelectSlashUser(null, null);
        clsWebFormUtil.FillDropDownList(ddUser, dt, 0, 4, true);
    }

    /// <summary>
    /// Loads Data Tab Controls
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tbUserAssignment.ActiveTabIndex == 0)
        {
            this.LoadUnAssingned();
            this.LoadAssingned();
        }
        else if (tbUserAssignment.ActiveTabIndex == 1)
        {
            this.UnAssignBrand();
            this.AssignBrand();
        }
        else if (tbUserAssignment.ActiveTabIndex == 2)
        {
            this.AssignVoucherType();
        }
    }

    /// <summary>
    /// Loads Data Tab Controls Through ddUser_SelectedIndexChanged() Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void tbUserAssignment_ActiveTabChanged(object sender, EventArgs e)
    {
        ddUser_SelectedIndexChanged(null, null);
    }

    #region Location Tab

    /// <summary>
    /// Loads LocationTypes To LocationType Combo
    /// </summary>
    private void DistributorType()
    {
        DistributorController dController = new DistributorController();
        DataTable dt = dController.SelectDistributorTypeInfo(Constants.IntNullValue);
        clsWebFormUtil.FillDropDownList(ddDistributorType, dt, 0, 2);
    }

    /// <summary>
    /// Loads UnAssigned Locations To UnAssigned ListBox on Location Tab
    /// </summary>
    private void LoadUnAssingned()
    {
        if (ddUser.Items.Count > 0 && ddDistributorType.Items.Count > 0)
        {
            UserController mUserController = new UserController();
            DataTable dt = mUserController.SelectUserAssignment(int.Parse(ddUser.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), 0, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(lstUnAssignDistributor, dt, 0, 1, true);
        }
    }

    /// <summary>
    /// Loads Assigned Locations To Assigned ListBox on Location Tab
    /// </summary>
    private void LoadAssingned()
    {
        if (ddUser.Items.Count > 0 && ddDistributorType.Items.Count > 0)
        {
            UserController mUserController = new UserController();
            DataTable dt = mUserController.SelectUserAssignment(int.Parse(ddUser.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), 1, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(lstAssignDistributor, dt, 0, 1, true);
        }
    }

    /// <summary>
    /// Loads Assigned/UnAssigned Locations To Assigned/UnAssigned ListBox on Location Tab
    /// </summary>
    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    /// <summary>
    /// Inserts Location Assignment To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnAssignLocation_Click(object sender, EventArgs e)
    {
        UserController mUserController = new UserController();
        for (int i = 0; i < lstUnAssignDistributor.Items.Count; i++)
        {
            if (lstUnAssignDistributor.Items[i].Selected == true && ddUser.Items.Count > 0)
            {
                mUserController.InsertUserAssignment(int.Parse(ddUser.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), int.Parse(lstUnAssignDistributor.Items[i].Value.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            }
        }
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    /// <summary>
    /// Deletes Location Assignment To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnUnAssignLocation_Click(object sender, EventArgs e)
    {
        UserController mUserController = new UserController();
        for (int i = 0; i < lstAssignDistributor.Items.Count; i++)
        {
            if (lstAssignDistributor.Items[i].Selected == true && ddUser.Items.Count > 0)
            {
                mUserController.DeleteUserAssignment(int.Parse(ddUser.SelectedValue.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), int.Parse(lstAssignDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            }
        }
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    #endregion

    #region Principal Tab

    /// <summary>
    /// Loads UnAssigned Principals To User To UnAssigned Principal ListBox On Principal Combo
    /// </summary>
    private void UnAssignBrand()
    {

        SkuHierarchyController sController = new SkuHierarchyController();
        DataTable dt = sController.SelectBrandAssignment(0, int.Parse(ddUser.SelectedValue.ToString()));
        clsWebFormUtil.FillListBox(lstUnAssignBrand, dt, 0, 1, true);

    }

    /// <summary>
    /// Loads nAssigned Principals To User To nAssigned Principal ListBox On Principal Combo
    /// </summary>
    private void AssignBrand()
    {

        SkuHierarchyController sController = new SkuHierarchyController();
        DataTable dt = sController.SelectBrandAssignment(1, int.Parse(ddUser.SelectedValue.ToString()));
        clsWebFormUtil.FillListBox(lstAssignBrand, dt, 0, 1, true);

        DataTable dtAssignBrand = sController.GetBrandAssignment(Convert.ToInt32(ddUser.SelectedValue));
        if (dtAssignBrand.Rows.Count > 0)
        {
            for (int i = 0; i < lstAssignBrand.Items.Count; i++)
            {
                for (int j = 0; j < dtAssignBrand.Rows.Count; j++)
                {
                    if (lstAssignBrand.Items[i].Value == dtAssignBrand.Rows[j]["PRINCIPAL_ID"].ToString() && dtAssignBrand.Rows[j]["Is_ManualDiscount"].ToString() == "True")
                    {
                        lstAssignBrand.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Inserts One Principal Assignment To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnAssignPrincipal_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstUnAssignBrand.Items.Count; i++)
        {
            if (lstUnAssignBrand.Items[i].Selected == true && ddUser.Items.Count > 0)
            {
                sController.InsertAssignBrand(int.Parse(lstUnAssignBrand.SelectedValue.ToString()), int.Parse(ddUser.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    /// <summary>
    /// Inserts All Principal Assignment To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnAssignAllPrincipal_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstUnAssignBrand.Items.Count; i++)
        {
            if (ddUser.Items.Count > 0)
            {
                sController.InsertAssignBrand(int.Parse(lstUnAssignBrand.Items[i].Value.ToString()), int.Parse(ddUser.SelectedValue.ToString()));

            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    /// <summary>
    /// Deletes One Principal Assignment To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnUnAssignPrincipal_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (ddUser.Items.Count > 0)
            {
                sController.DeleteAssignBrand(int.Parse(lstAssignBrand.Items[i].Value.ToString()), int.Parse(ddUser.SelectedValue.ToString()));

            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    /// <summary>
    /// Deletes All Principal Assignment To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnUnAssignAllPrincipal_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (lstAssignBrand.Items[i].Selected == true && ddUser.Items.Count > 0)
            {
                sController.DeleteAssignBrand(int.Parse(lstAssignBrand.Items[i].Value.ToString()), int.Parse(ddUser.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    /// <summary>
    /// Updates Promotion For Principal To Manual Or Auto
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (ddUser.Items.Count > 0)
            {
                sController.UpdateBrandAssignment(int.Parse(ddUser.SelectedValue.ToString()), int.Parse(lstAssignBrand.Items[i].Value), lstAssignBrand.Items[i].Selected);
            }
        }
    }

    #endregion    

    #region VoucherType Tab

    /// <summary>
    /// Loads VoucherTypes To VoucherType ListBox on VoucherType Tab
    /// </summary>
    private void LoadVoucherType()
    {
        LedgerController LLedger = new LedgerController();
        DataTable dt = LLedger.SelectVoucherType(int.Parse(this.Session["UserId"].ToString()));
        clsWebFormUtil.FillListBox(this.cblVoucherType, dt, 0, 1);
    }

    /// <summary>
    /// Checks/UnChecks VoucherTypes Of VoucherType ListBox VoucherType Tab
    /// </summary>
    private void AssignVoucherType()
    {
        for (int cnt = 0; cnt < cblVoucherType.Items.Count; cnt++)
        {
            cblVoucherType.Items[cnt].Selected = false;
        }

        LedgerController LController = new LedgerController();
        if (ddUser.Items.Count > 0)
        {
            DataTable dtAssignVoucher = LController.GetAssignVoucherType(Convert.ToInt32(ddUser.SelectedValue));
            if (dtAssignVoucher.Rows.Count > 0)
            {
                for (int i = 0; i < cblVoucherType.Items.Count; i++)
                {
                    for (int j = 0; j < dtAssignVoucher.Rows.Count; j++)
                    {
                        if (cblVoucherType.Items[i].Value == dtAssignVoucher.Rows[j]["VOUCHER_TYPE_ID"].ToString())
                        {
                            cblVoucherType.Items[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Assigns/UnAssigns VoucherTypes To User
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        LedgerController LController = new LedgerController();
        for (int i = 0; i < cblVoucherType.Items.Count; i++)
        {
            if (ddUser.Items.Count > 0)
            {
                LController.Assign_UnAssign_VoucherType(int.Parse(cblVoucherType.Items[i].Value), Convert.ToInt32(ddUser.SelectedValue), !cblVoucherType.Items[i].Selected);
            }
        }
    }

    #endregion
}
