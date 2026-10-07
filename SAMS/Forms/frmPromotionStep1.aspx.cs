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

/// <summary>
/// Form To Add, Edit, Promotions
/// </summary>
public partial class Forms_frmPromotionStep1 : System.Web.UI.Page
{
    string[] cols = { "SCHEME_ID", "PROMOTION_ID", "SCHEME_DESC", "DISTRIBUTOR_ID", "PROMOTION_CODE", "PROMOTION_DESCRIPTION", "Principal", "START_DATE", "END_DATE", "IS_ACTIVE" };

    /// <summary>
    /// Page_Load Function Populates All Combos On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtFromdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
            txttoDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");

            this.LoadPrincipal();
            FillScheme();
            btnPromotion.Attributes.Add("onclick", "return ValidateForm()");
        }
    }

    /// <summary>
    /// Loads Schemes To Scheme Combo
    /// </summary>
    public void FillScheme()
    {
        SchemeController mSchemController = new SchemeController();
        DataTable dtScheme = mSchemController.SelectScheme(Constants.IntNullValue, SAMSCommon.Classes.Configuration.DistributorId, null, null, Constants.DateNullValue);
        drpScheme.Items.Clear();
        drpScheme.Items.Add(new clsListItems("ALL", "0"));
        drpScheme.DataSource = dtScheme;
        clsWebFormUtil.FillDropDownList(this.drpScheme, dtScheme, "SCHEME_ID", "SCHEME_CODE");
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }

    /// <summary>
    /// Loads Promotions To Promotion Grid
    /// </summary>
    private void LoadGrid()
    {
        DataTable dt = (DataTable)this.Session["dt"];

        if (ddSearchType.SelectedIndex == 2)
        {
            dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " =" + txtSeach.Text;
        }
        else
        {
            dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
        }

        DataView dw = dt.DefaultView;
        DataTable dt2 = dw.ToTable(true, cols);

        Grid_pricedetails.DataSource = dt2;
        Grid_pricedetails.DataBind();
    }

    /// <summary>
    /// Sets PageIndex Of Promotion Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void Grid_pricedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_pricedetails.PageIndex = e.NewPageIndex;
        LoadGrid();
    }

    /// <summary>
    /// Sets Promotion Data For Edit. This Function Runs When An Existing Promotion Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void Grid_pricedetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        bool IsEditing = true;
        string flow = "f";
        string PromotionId = Grid_pricedetails.Rows[e.NewEditIndex].Cells[1].Text;
        this.Session.Add("PromotionId", PromotionId);
        this.Session.Add("IsEdit", IsEditing);
        this.Session.Add("Flow", flow);
        Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
    }

    /// <summary>
    /// Deletes Promotion
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void Grid_pricedetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PromotionController mController = new PromotionController();
        
        int PromotionId = int.Parse(Grid_pricedetails.Rows[e.RowIndex].Cells[1].Text);
        int SchemeId = int.Parse(Grid_pricedetails.Rows[e.RowIndex].Cells[0].Text);

        mController.UpdatePromotion(PromotionId, SchemeId, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), null, null, Constants.DateNullValue, false, Constants.DateNullValue, Constants.DateNullValue, false, Constants.IntNullValue, Constants.IntNullValue);

        string FromDate = txtFromdate.Text + " 00:00:00";
        string ToDate = txttoDate.Text + " 23:59:59";

        DataTable dt = mController.SelectPromotion(FromDate, ToDate, Convert.ToInt32(this.DrpPrincipal.SelectedValue), int.Parse(this.Session["UserId"].ToString()), ChbActive.Checked);
        this.Session.Add("dt", dt);

        DataView dw = dt.DefaultView;
        DataTable dt2 = dw.ToTable(true, cols);

        Grid_pricedetails.DataSource = dt2;
        Grid_pricedetails.DataBind();
    }

    /// <summary>
    /// Gets Promotions From Datatabse And Loads To Promotion Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnPromotion_Click(object sender, EventArgs e)
    {
        PromotionController mController = new PromotionController();
        if (btnPromotion.Text == "Get Promotion")
        {
            string FromDate = txtFromdate.Text + " 00:00:00";
            string ToDate = txttoDate.Text + " 23:59:59";

            DataTable dt = mController.SelectPromotion(FromDate, ToDate, Convert.ToInt32(this.DrpPrincipal.SelectedValue), int.Parse(this.Session["UserId"].ToString()), ChbActive.Checked);
            this.Session.Add("dt", dt);

            DataView dw = dt.DefaultView;
            DataTable dt2 = dw.ToTable(true, cols);

            Grid_pricedetails.DataSource = dt2;
            Grid_pricedetails.DataBind();
        }
    }

    /// <summary>
    /// Redirects To Promotion Wizard Form.
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnNew_Click(object sender, EventArgs e)
    {
        this.Session.Add("IsEdit", false);
        Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
    }

    /// <summary>
    /// Filters Promotion Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if (txtSeach.Text.Length > 0)
        {
            LoadGrid();
        }
    }
}
