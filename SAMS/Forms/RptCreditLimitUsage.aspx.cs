using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form For Stock Reconciliation Report
/// </summary>
public partial class Forms_RptCreditLimitUsage : System.Web.UI.Page
{
    readonly SKUPriceDetailController _pController = new SKUPriceDetailController();
    /// <summary>
    /// Page_Load Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        LoadDistributor();
        LoadPrincipal();
       Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
        txtStartDate.Text =Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        
        var mDt = _pController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString(CultureInfo.InvariantCulture)));       
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, mDt, 0, 1);
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        var dController = new DistributorController();
        var dt = dController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        drpDistributor.Items.Add(new ListItem("All", Constants.IntNullValue.ToString(CultureInfo.InvariantCulture)));       
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }

    /// <summary>
    /// Shows Stock Reconciliation in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        var mController = new DocumentPrintController();
        var rptInventoryCtl = new RptInventoryController();
        var crpReport = new SAMSBusinessLayer.Reports.CrpCreditLimit();
        DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue));
        DataSet ds = rptInventoryCtl.SelectCreditLimitUsage(int.Parse(drpDistributor.SelectedValue), int.Parse(DrpPrincipal.SelectedValue), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), int.Parse(ddlType.SelectedValue), int.Parse(ddlType.SelectedValue));
        crpReport.SetDataSource(ds);
        crpReport.Refresh();


        crpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
        crpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
        crpReport.SetParameterValue("fromdate", txtStartDate.Text);
        crpReport.SetParameterValue("todate", txtEndDate.Text);
        crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
        //crpReport.SetParameterValue("Price", rblRate.SelectedItem.Text);
        crpReport.SetParameterValue("ReportType", "Credit Limit Usage Report ( " + ddlType.SelectedItem.Text + " )");

        this.Session.Add("CrpReport", crpReport);
        this.Session.Add("ReportType", 0);
        const string url = "'Default.aspx'";
        const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        var cstype = this.GetType();
        var cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);            
    }

    /// <summary>
    /// Shows Stock Reconciliation in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        var mController = new DocumentPrintController();
        var rptInventoryCtl = new RptInventoryController();
        var crpReport = new SAMSBusinessLayer.Reports.CrpCreditLimit();
        DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue));
        DataSet ds = rptInventoryCtl.SelectCreditLimitUsage(int.Parse(drpDistributor.SelectedValue), int.Parse(DrpPrincipal.SelectedValue), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), int.Parse(ddlType.SelectedValue), int.Parse(ddlType.SelectedValue));
        crpReport.SetDataSource(ds);
        crpReport.Refresh();


        crpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
        crpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
        crpReport.SetParameterValue("fromdate", txtStartDate.Text);
        crpReport.SetParameterValue("todate", txtEndDate.Text);
        crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
        //crpReport.SetParameterValue("Price", rblRate.SelectedItem.Text);
        crpReport.SetParameterValue("ReportType", "Credit Limit Usage Report ( " + ddlType.SelectedItem.Text + " )");

        this.Session.Add("CrpReport", crpReport);
        this.Session.Add("ReportType", 1);
        const string url = "'Default.aspx'";
        const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        var cstype = this.GetType();
        var cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);           
    }
}
