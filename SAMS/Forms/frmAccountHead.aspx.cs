using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form To Add, Edit Account Head
/// </summary>
public partial class Forms_frmAccountHead : System.Web.UI.Page
{
    #region Variables

    AccountHeadController MController = new AccountHeadController();
    private static long AccountTypeId;
    private static long AccountSubTypeId;
    private static long AccountDetailTypeId;
    private static long AccountHeadId;
    private static string strCode;

    #endregion

    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SAMSCommon.Classes.Configuration.DistributorId = 1;
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
        }
    }

    #region MainType Tab

    /// <summary>
    /// Loads All Combos And Grids On The Form
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpAccountCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetAccountType();
        this.GetSubAccountType();
        this.GetSubTypeForDetail();
        this.GetSubTypeForDetail();
        this.GetSubTypeForHead();
        this.GetDetailAccountType();
        this.GetDetailAccountTypeForHead();
        this.GetAccountHead();
    }

    /// <summary>
    /// Loads Account Main Types To MainType Grid On MainType Tab And All MainType Combos on The Form
    /// </summary>
    private void GetAccountType()
    {
        DataTable dt = MController.SelectAccountHead(Constants.AC_MainTypeId, Constants.LongNullValue, DrpAccountCategory.SelectedIndex);
        GrdMainType.DataSource = dt;
        GrdMainType.DataBind();
        clsWebFormUtil.FillDropDownList(ddAccountType1, dt, 0, 10, true);
        clsWebFormUtil.FillDropDownList(ddAccountType2, dt, 0, 10, true);
        clsWebFormUtil.FillDropDownList(ddAccountType3, dt, 0, 10, true);
    }

    /// <summary>
    /// Loads Account Sub Types To SubType Grid on SubType Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddAccountType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSubAccountType();
    }

    /// <summary>
    /// Loads Account Sub Types To SubType Combo And Detail Types To DetailType Grid on DetailType Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddAccountType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSubTypeForDetail();
        this.GetDetailAccountType();
    }

    /// <summary>
    /// Loads Account Sub Types To SubType Combo, Detail Types To DetailType Combo And Account Heads To AccountHead Grid on AccountHead Tab
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddAccountType3_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSubTypeForHead();
        this.GetDetailAccountTypeForHead();
        this.GetAccountHead();
    }

    /// <summary>
    /// Sets Account MainType For Edit. This Function Runs When An Existing Account MainType Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdMainType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AccountTypeId = long.Parse(GrdMainType.Rows[e.NewEditIndex].Cells[0].Text);
        txtAtypeCode.Text = GrdMainType.Rows[e.NewEditIndex].Cells[1].Text;
        txtAtypeName.Text = GrdMainType.Rows[e.NewEditIndex].Cells[2].Text.Replace("amp;", "");
        DrpAccountCategory.SelectedIndex = int.Parse(GrdMainType.Rows[e.NewEditIndex].Cells[3].Text);
        btnAccountType.Text = "Update";
    }

    /// <summary>
    /// Deletes Account MainType
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdMainType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, long.Parse(GrdMainType.Rows[e.RowIndex].Cells[0].Text));

        if (dt.Rows.Count == 0)
        {
            MController.UpdateAccountHead(long.Parse(GrdMainType.Rows[e.RowIndex].Cells[0].Text), int.Parse(this.Session["CompanyId"].ToString()), false, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, Constants.LongNullValue, null, null, 0);
            this.GetAccountType();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Transaction exists unable to delete');", true);
        }
    }

    /// <summary>
    /// Saves Or Updates Account MainType
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void btnAccountType_Click(object sender, EventArgs e)
    {
        if (btnAccountType.Text == "New Account Type")
        {
            btnAccountType.Text = "Save Account Type";
            txtAtypeCode.Text = this.GetAutoCode(Constants.AC_MainTypeId, Constants.LongNullValue);
            ScriptManager.GetCurrent(Page).SetFocus(txtAtypeCode);
        }
        else if (btnAccountType.Text == "Save Account Type")
        {
            MController.InsertAccountHead(1, true, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_MainTypeId, Constants.LongNullValue, txtAtypeName.Text, txtAtypeCode.Text, DrpAccountCategory.SelectedIndex);
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
            this.ClearAll();
        }
        else if (btnAccountType.Text == "Update")
        {
            MController.UpdateAccountHead(AccountTypeId, 1, true, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_MainTypeId, Constants.LongNullValue, txtAtypeName.Text, txtAtypeCode.Text, DrpAccountCategory.SelectedIndex);
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
            this.ClearAll();
        }
    }

    #endregion

    #region SubType Tab

    /// <summary>
    /// Loads Account SubTypes To SubType
    /// </summary>
    private void GetSubAccountType()
    {
        if (ddAccountType1.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(ddAccountType1.SelectedValue.ToString()), DrpAccountCategory.SelectedIndex);
            GrdSubType.DataSource = dt;
            GrdSubType.DataBind();
        }
    }

    /// <summary>
    /// Sets Account SubType For Edit. This Function Runs When An Existing Account SubType Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdSubType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AccountSubTypeId = long.Parse(GrdSubType.Rows[e.NewEditIndex].Cells[0].Text);
        txtASubTypeCode.Text = GrdSubType.Rows[e.NewEditIndex].Cells[1].Text;
        txtSubTypeName.Text = GrdSubType.Rows[e.NewEditIndex].Cells[2].Text.Replace("amp;", "");
        btnAccountSubType.Text = "Update";
    }

    /// <summary>
    /// Deletes Account SubType.
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdSubType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, long.Parse(GrdSubType.Rows[e.RowIndex].Cells[0].Text));

        if (dt.Rows.Count == 0)
        {
            MController.UpdateAccountHead(long.Parse(GrdSubType.Rows[e.RowIndex].Cells[0].Text), int.Parse(this.Session["CompanyId"].ToString()), false, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, Constants.LongNullValue, null, null, 0);
            this.GetSubAccountType();
            this.GetSubTypeForDetail();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Transaction exists unable to delete');", true);
        }
    }

    /// <summary>
    /// Saves Or Updates Account SubType
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void btnAccountSubType_Click(object sender, EventArgs e)
    {
        if (btnAccountSubType.Text == "New Sub Type")
        {
            btnAccountSubType.Text = "Save Sub Type";
            txtASubTypeCode.Text = this.GetAutoCode(Constants.AC_SubTypeId, long.Parse(ddAccountType1.SelectedValue.ToString()));
            ScriptManager.GetCurrent(Page).SetFocus(txtASubTypeCode);
        }
        else if (btnAccountSubType.Text == "Save Sub Type")
        {
            if (ddAccountType1.Items.Count > 0)
            {
                MController.InsertAccountHead(1, true, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, long.Parse(ddAccountType1.SelectedValue.ToString()), txtSubTypeName.Text, txtASubTypeCode.Text, DrpAccountCategory.SelectedIndex);
            }
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
            this.ClearAll();
        }
        else if (btnAccountSubType.Text == "Update")
        {
            MController.UpdateAccountHead(AccountSubTypeId, 1, true, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, long.Parse(ddAccountType1.SelectedValue.ToString()), txtSubTypeName.Text, txtASubTypeCode.Text, DrpAccountCategory.SelectedIndex);
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
            this.ClearAll();
        }
    }

    #endregion

    #region DetailType Tab

    /// <summary>
    /// Loads Account SubTypes To SubType Combo
    /// </summary>
    private void GetSubTypeForDetail()
    {
        if (ddAccountType2.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(ddAccountType2.SelectedValue.ToString()), DrpAccountCategory.SelectedIndex);
            clsWebFormUtil.FillDropDownList(ddAccountSubType1, dt, 0, 10, true);
        }
    }

    /// <summary>
    /// Loads Account DetailTypes To DetailType Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void ddAccountSubType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDetailAccountType();
    }

    /// <summary>
    /// Loads Account DetailTypes To DetailType Grid
    /// </summary>
    private void GetDetailAccountType()
    {
        if (ddAccountSubType1.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, int.Parse(ddAccountSubType1.SelectedValue.ToString()), DrpAccountCategory.SelectedIndex);
            GrdDetailType.DataSource = dt;
            GrdDetailType.DataBind();
        }
    }

    /// <summary>
    /// Sets Account DetailType For Edit. This Function Runs When An Existing Account DetailType Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdDetailType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AccountDetailTypeId = long.Parse(GrdDetailType.Rows[e.NewEditIndex].Cells[0].Text);
        txtADetailTypeCode.Text = GrdDetailType.Rows[e.NewEditIndex].Cells[1].Text;
        txtDetailTypeName.Text = GrdDetailType.Rows[e.NewEditIndex].Cells[2].Text.Replace("amp;", ""); ;
        btnAccountDetailType.Text = "Update";
    }

    /// <summary>
    /// Deletes Account DetailType
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdDetailType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = MController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(GrdDetailType.Rows[e.RowIndex].Cells[0].Text));

        if (dt.Rows.Count == 0)
        {
            MController.UpdateAccountHead(long.Parse(GrdDetailType.Rows[e.RowIndex].Cells[0].Text), int.Parse(this.Session["CompanyId"].ToString()), false, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, Constants.LongNullValue, null, null, 0);
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Transaction exists unable to delete');", true);
        }
    }

    /// <summary>
    /// Save Or Updates Account DetailType
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void btnAccountDetailType_Click(object sender, EventArgs e)
    {
        if (btnAccountDetailType.Text == "New Detail Type")
        {
            btnAccountDetailType.Text = "Save Detail Type";
            txtADetailTypeCode.Text = this.GetAutoCode(Constants.AC_DetailTypeId, long.Parse(ddAccountSubType1.SelectedValue.ToString()));
            ScriptManager.GetCurrent(Page).SetFocus(txtADetailTypeCode);
        }
        else if (btnAccountDetailType.Text == "Save Detail Type")
        {
            if (ddAccountType2.Items.Count > 0 && ddAccountSubType1.Items.Count > 0)
            {
                MController.InsertAccountHead(int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, long.Parse(ddAccountSubType1.SelectedValue.ToString()), txtDetailTypeName.Text, txtADetailTypeCode.Text, DrpAccountCategory.SelectedIndex);
                this.GetDetailAccountType();
                this.GetDetailAccountTypeForHead();
                this.GetAccountHead();
                this.ClearAll();
            }
        }
        else if (btnAccountDetailType.Text == "Update")
        {
            MController.UpdateAccountHead(AccountDetailTypeId, int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, long.Parse(ddAccountSubType1.SelectedValue.ToString()), txtDetailTypeName.Text, txtADetailTypeCode.Text, DrpAccountCategory.SelectedIndex);
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
            this.ClearAll();
        }
    }

    #endregion

    #region AccountHead Tab

    /// <summary>
    /// Loads Account SubTypes To SubType Combo
    /// </summary>
    private void GetSubTypeForHead()
    {
        if (ddAccountType3.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(ddAccountType3.SelectedValue.ToString()), DrpAccountCategory.SelectedIndex);
            clsWebFormUtil.FillDropDownList(ddAccountSubType2, dt, 0, 10, true);
        }
    }

    /// <summary>
    /// Loads Account DetailTypes To DetailType Combo And AccountHeads To AccountHead Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void ddAccountSubType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDetailAccountTypeForHead();
        this.GetAccountHead();
    }

    /// <summary>
    /// Loads Account DetailTypes To DetailType Combo
    /// </summary>
    private void GetDetailAccountTypeForHead()
    {
        if (ddAccountSubType2.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, int.Parse(ddAccountSubType2.SelectedValue.ToString()), DrpAccountCategory.SelectedIndex);
            clsWebFormUtil.FillDropDownList(drpAccountTypeDetail, dt, 0, 10, true);
        }
    }

    /// <summary>
    /// Loads Account Heads To AccountHead Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void drpAccountTypeDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetAccountHead();
    }

    /// <summary>
    /// Loads Account Heads To AccountHead Grid
    /// </summary>
    private void GetAccountHead()
    {
        if (drpAccountTypeDetail.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_AccountHeadId, int.Parse(drpAccountTypeDetail.SelectedValue.ToString()), DrpAccountCategory.SelectedIndex);
            GridAccountHead.DataSource = dt;
            GridAccountHead.DataBind();
        }
        else
        {
            GridAccountHead.DataSource = null;
            GridAccountHead.DataBind();
        }
    }

    /// <summary>
    /// Sets Account Head For Edit. This Function Runs When An Existing Account Head Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GridAccountHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AccountHeadId = long.Parse(GridAccountHead.Rows[e.NewEditIndex].Cells[0].Text);
        txtAccountCode.Text = GridAccountHead.Rows[e.NewEditIndex].Cells[1].Text.Substring(6);
        txtAccountHead.Text = GridAccountHead.Rows[e.NewEditIndex].Cells[2].Text.Replace("amp;", "");
        btnSave.Text = "Update";
    }

    /// <summary>
    /// Deletes Account Head
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GridAccountHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = MController.SelectGlTranscton(long.Parse(GridAccountHead.Rows[e.RowIndex].Cells[0].Text));

        if (dt.Rows.Count == 0)
        {
            MController.UpdateAccountHead(long.Parse(GridAccountHead.Rows[e.RowIndex].Cells[0].Text), int.Parse(this.Session["CompanyId"].ToString()), false, DateTime.Now, SAMSCommon.Classes.Configuration.DistributorId, Constants.AC_AccountHeadId, Constants.LongNullValue, null, null, 0);
            this.GetAccountHead();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Transaction exists unable to delete');", true);
        }
    }

    /// <summary>
    /// Saves Or Updates Account Head
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "New")
        {
            btnSave.Text = "Save";
            txtAccountCode.Text = this.GetAutoCode(Constants.AC_AccountHeadId, int.Parse(drpAccountTypeDetail.SelectedValue.ToString()));
            ScriptManager.GetCurrent(Page).SetFocus(txtAccountCode);
        }
        else if (btnSave.Text == "Save")
        {
            MController.InsertAccountHead(int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), Constants.AC_AccountHeadId, long.Parse(drpAccountTypeDetail.SelectedValue.ToString()), txtAccountHead.Text, ddAccountType3.SelectedItem.Text.Substring(0, 2) + ddAccountSubType2.SelectedItem.Text.Substring(0, 2) + drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2) + txtAccountCode.Text, DrpAccountCategory.SelectedIndex);
            this.GetAccountHead();
            this.ClearAll();
        }
        else
        {
            MController.UpdateAccountHead(AccountHeadId, int.Parse(this.Session["CompanyId"].ToString()), true, System.DateTime.Now, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), Constants.AC_AccountHeadId, int.Parse(drpAccountTypeDetail.SelectedValue.ToString()), txtAccountHead.Text, ddAccountType3.SelectedItem.Text.Substring(0, 2) + ddAccountSubType2.SelectedItem.Text.Substring(0, 2) + drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2) + txtAccountCode.Text, DrpAccountCategory.SelectedIndex);
            this.GetAccountHead();
            this.ClearAll();
        }
    }

    #endregion

    /// <summary>
    /// Gets Code For Account
    /// </summary>
    /// <param name="CodeType">Type</param>
    /// <param name="CValue">Value</param>
    /// <returns>Code as String</returns>
    private string GetAutoCode(int CodeType, long CValue)
    {
        DataTable dt = MController.SelectAccountHead(CodeType, CValue, DrpAccountCategory.SelectedIndex);
        DataView dv = new DataView(dt);
        dv.Sort = "ACCOUNT_CODE";
        dt = dv.ToTable();
        if (CodeType != Constants.AC_AccountHeadId)
        {
            if (dt.Rows.Count > 0)
            {
                int AccountCode = Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["ACCOUNT_CODE"].ToString()) + 1;
                if (AccountCode.ToString().Length == 1)
                {
                    return "0" + AccountCode.ToString();

                }
                else
                {
                    return AccountCode.ToString();
                }
            }
            else
            {
                return "01";
            }
        }
        else
        {
            if (dt.Rows.Count > 0)
            {
                int AccountCode = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["ACCOUNT_CODE"].ToString().Substring(6, 4)) + 1;
                if (AccountCode.ToString().Length == 1)
                {
                    return "000" + AccountCode.ToString();
                }
                else if (AccountCode.ToString().Length == 2)
                {
                    return "00" + AccountCode.ToString();
                }
                else if (AccountCode.ToString().Length == 3)
                {
                    return "0" + AccountCode.ToString();
                }
                else
                {
                    return AccountCode.ToString();
                }
            }
            else
            {
                return "0001";
            }
        }
    }

    /// <summary>
    /// Clears Form Controls
    /// </summary>
    private void ClearAll()
    {
        btnAccountType.Text = "New Account Type";
        btnAccountSubType.Text = "New Sub Type";
        btnAccountDetailType.Text = "New Detail Type";
        btnSave.Text = "New";
        txtAtypeName.Text = "";
        txtAtypeCode.Text = "";
        txtASubTypeCode.Text = "";
        txtSubTypeName.Text = "";
        txtADetailTypeCode.Text = "";
        txtDetailTypeName.Text = "";
        txtAccountHead.Text = "";
        txtADetailTypeCode.Text = "";
        txtAccountCode.Text = "";
    }
}
