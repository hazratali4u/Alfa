using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class Forms_LoadPassEntry : System.Web.UI.Page
{

    PurchaseController mPurchase = new PurchaseController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillRepeater();
            this.Session.Add("SaleInvoiceID",-1);
            ltrAdd.Text = "<a href='frmLoadPass.aspx?Status=" + false + "&LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString() + "'>Add Load Pass</a>";
          
        }

    }
    protected void rPurchaseOrder_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Load")
        {
            long SALE_INVOICE_ID = Convert.ToInt64(e.CommandArgument);
           // long SALE_INVOICE_ID;
           // HiddenField HFSaleID = (HiddenField)e.Item.FindControl("hfSaleInvoiceId");
            this.Session.Add("SaleInvoiceID", SALE_INVOICE_ID);
           // this.Session.Add("SaleInvoiceID", HFSaleID.Value);
            Response.Redirect("~/Forms/frmLoadPass.aspx?Status=" + false + "&LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
           // if (mPurchase.UpdatePurchaseOrder(SALE_ORDER_ID, 1))//TypeID = 1 for Close
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('PO closed successfully.');", true);
            //    FillRepeater();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Some error occured.');", true);
            //}
        }
        else if (e.CommandName == "Delete")
        {
            long SALE_INVOICE_ID = Convert.ToInt64(e.CommandArgument);
            // long SALE_INVOICE_ID;
            // HiddenField HFSaleID = (HiddenField)e.Item.FindControl("hfSaleInvoiceId");
            //  this.Session.Add("SaleInvoiceID", SALE_INVOICE_ID);
            // this.Session.Add("SaleInvoiceID", HFSaleID.Value);
            //  Response.Redirect("~/Forms/frmLoadPass.aspx?Status=" + false + "&LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
             if (mPurchase.UpdateLoadPass(SALE_INVOICE_ID))//TypeID = 1 for Close
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Load Pass closed successfully.');", true);
                FillRepeater();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Some error occured.');", true);
            }
        }
        else if (e.CommandName == "Return")
        {
            long SALE_INVOICE_ID = Convert.ToInt64(e.CommandArgument);
            // long SALE_INVOICE_ID;
            // HiddenField HFSaleID = (HiddenField)e.Item.FindControl("hfSaleInvoiceId");
            this.Session.Add("SaleInvoiceID", SALE_INVOICE_ID);
            // this.Session.Add("SaleInvoiceID", HFSaleID.Value);
            Response.Redirect("~/Forms/frmLoadPassReturn.aspx?Status=" + false + "&LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
            // if (mPurchase.UpdatePurchaseOrder(SALE_ORDER_ID, 1))//TypeID = 1 for Close
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('PO closed successfully.');", true);
            //    FillRepeater();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Some error occured.');", true);
            //}
        }
    }

    private void FillRepeater()
    {
        rPurchaseOrder.DataSource = null;
        rPurchaseOrder.DataBind();
        lblTotalNoOfRecords.Text = "";
        lblCurrentPageNo.Text = "";
        lblTotalNoOfPages.Text = "";
        PagedDataSource PagedResults = new PagedDataSource();
        PagedResults.AllowPaging = true;
        PagedResults.PageSize = 20;

        DataTable dt = mPurchase.SelectPurchaseOrderDocumentNo4( int.Parse(this.Session["UserId"].ToString()), Convert.ToDateTime(Session["CurrentWorkDate"]));

        PagedResults.DataSource = dt.DefaultView;
        if (PagedResults.Count > 0)
        {
            PagedResults.CurrentPageIndex = CurrentPage;
            linkbtnnext.Enabled = !PagedResults.IsLastPage;
            linkbtnprev.Enabled = !PagedResults.IsFirstPage;
            rPurchaseOrder.DataSource = PagedResults;
            rPurchaseOrder.DataBind();

            linkbtnnext.Visible = true;
            linkbtnprev.Visible = true;
            lblTotalNoOfPages.Visible = true;
            lblCurrentPageNo.Visible = true;
            lblTotalNoOfRecords.Visible = true;
            lblDummy.Visible = true;
            lblOf.Visible = true;
            lblTotalNoOfRecords.Text = dt.Rows.Count.ToString();
            lblCurrentPageNo.Text = (CurrentPage + 1).ToString();
            lblTotalNoOfPages.Text = Convert.ToString(Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / Convert.ToDecimal(20)));

        }
        else if (PagedResults.Count == 0)
        {
            linkbtnnext.Visible = false;
            linkbtnprev.Visible = false;
            lblTotalNoOfPages.Visible = false;
            lblCurrentPageNo.Visible = false;
            lblTotalNoOfRecords.Visible = false;
            lblOf.Visible = false;
            lblDummy.Visible = false;
            lblTotalNoOfRecords.Text = "";
        }
    }

    public int CurrentPage
    {
        get
        {
            object objview = this.ViewState["_CurrentPage"];
            if (objview == null)
                return 0;
            else
                return (int)objview;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }
    }

    protected void linkbtnprev_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        FillRepeater();
    }

    protected void linkbtnnext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        FillRepeater();
    }
}