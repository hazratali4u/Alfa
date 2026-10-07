using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Reports;

/// <summary>
/// Form For  SKU Price History Report
/// </summary>
public partial class Forms_rptSKUPriceHistory : System.Web.UI.Page
{
    SKUPriceDetailController PController = new SKUPriceDetailController();

    /// <summary>
    /// Page_Load Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);

        this.LoadCategory();
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }

    /// <summary>
    /// Shows SKU Price History in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows SKU Price History in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }

    /// <summary>
    /// Shows SKU Price History Report in Excel Or PDF
    /// </summary>
    /// <param name="p_Report_Type">ReportType</param>
    private void ShowReport(int p_Report_Type)
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        RptSaleController RptSaleCtl = new RptSaleController();

        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
        DataSet ds = RptSaleCtl.GetSKUPriceHistory(int.Parse(DrpSKU.SelectedValue), int.Parse(DrpPrincipal.SelectedValue),int.Parse(DrpCategory.SelectedValue), int.Parse(drpDistributor.SelectedValue), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpPrices.SelectedValue));

        if (int.Parse(DrpPrices.SelectedValue) == 0)
        {

            SAMSBusinessLayer.Reports.CrpSKUPriceHistory CrpReport = new SAMSBusinessLayer.Reports.CrpSKUPriceHistory();

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Location", drpDistributor.SelectedItem.Text);
            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("SKU", DrpSKU.SelectedItem.Text);
            CrpReport.SetParameterValue("Price", DrpPrices.SelectedItem.Text);
            this.Session.Add("ReportType", p_Report_Type);
            this.Session.Add("CrpReport", CrpReport);
        }
        else
        {
            SAMSBusinessLayer.Reports.CrpSKUPriceHistory2 CrpReport = new SAMSBusinessLayer.Reports.CrpSKUPriceHistory2();

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Location", drpDistributor.SelectedItem.Text);
            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("SKU", DrpSKU.SelectedItem.Text);
            CrpReport.SetParameterValue("Price", DrpPrices.SelectedItem.Text);
            CrpReport.SetParameterValue("ReportType", int.Parse(DrpPrices.SelectedValue));
            this.Session.Add("ReportType", p_Report_Type);
            this.Session.Add("CrpReport", CrpReport);
        }
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }

    /// <summary>
    /// Loads SKU Categories
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategory();
    }

    /// <summary>
    /// Loads SKUS To SKU Combo
    /// </summary>
    private void LoadSKUDetail()
    {
        if (DrpCategory.Items.Count > 0)
        {
            DrpSKU.Items.Clear();
            SkuController mContoller = new SkuController();
            DataTable dt = mContoller.SelectSkuInfo(int.Parse(DrpPrincipal.SelectedValue), Constants.IntNullValue, int.Parse(DrpCategory.SelectedValue), Constants.IntNullValue, Constants.IntNullValue);              
            DrpSKU.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSKU, dt, 0, 18, false);
        }
    }

    /// <summary>
    /// Loads SKU Categories To Category Combo
    /// </summary>
    private void LoadCategory()
    {
        if (DrpPrincipal.Items.Count > 0)
        {
            DrpCategory.Items.Clear();

            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSKUCategories(int.Parse(DrpPrincipal.SelectedValue.ToString()), true);
            
            DrpCategory.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpCategory, dt, 0, 3, false);
            this.LoadSKUDetail();
        }
    }

    /// <summary>
    /// Loads SKUS
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }
}
