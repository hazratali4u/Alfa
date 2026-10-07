using System;
using System.Web.UI;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Reports;
using CrystalDecisions.CrystalReports.Engine;


/// <summary>
/// Form For Stock Reconciliation Report
/// </summary>
public partial class Forms_RptDailySaleReport: Page
{
    readonly SKUPriceDetailController _pController = new SKUPriceDetailController();
    readonly DistributorController _dController = new DistributorController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDistributor();
            LoadPrincipal();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
 
    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
       
     var mDt = _pController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpPrincipal, mDt, 0, 1);
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        
        var dt = _dController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dt, 0, 2);
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

        ReportDocument crpReport = new CrpDailySaleReport();

        var dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue));
        var ds = rptInventoryCtl.SelectDailySaleReport(int.Parse(drpDistributor.SelectedValue), int.Parse(DrpPrincipal.SelectedValue), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), ddlType.SelectedIndex, Convert.ToInt32(rblRate.SelectedValue));
       
        var subReport = crpReport.OpenSubreport("SubreportRealization");
        var subReportCredit = crpReport.OpenSubreport("SubreportCredit");
        var subReportCheques = crpReport.OpenSubreport("subreportCheques");
        var subReportFuel = crpReport.OpenSubreport("SubreportFuel");
        var subReportExpenses = crpReport.OpenSubreport("SubreportExpenses");
        var subReportDiscount = crpReport.OpenSubreport("SubreportDiscount");
        var subReportComDiscount = crpReport.OpenSubreport("SubreportCommulativeDiscount");
        var subReportNote = crpReport.OpenSubreport("SubreportNote");
        crpReport.SetDataSource(ds);
        subReport.SetDataSource(ds);
        subReportCredit.SetDataSource(ds);
        subReportCheques.SetDataSource(ds);
        subReportFuel.SetDataSource(ds);
        subReportExpenses.SetDataSource(ds);
        subReportDiscount.SetDataSource(ds);
        subReportComDiscount.SetDataSource(ds);
        subReportNote.SetDataSource(ds);
        crpReport.Refresh();


        crpReport.SetParameterValue("division", drpDistributor.SelectedItem.Text);
        crpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
        crpReport.SetParameterValue("fromdate", txtStartDate.Text);
        crpReport.SetParameterValue("todate", txtEndDate.Text );
        crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
        crpReport.SetParameterValue("Price", rblRate.SelectedItem.Text);
        crpReport.SetParameterValue("ReportType", "Daily Sale Report");

        Session.Add("CrpReport", crpReport);
        Session.Add("ReportType", 0);  
        const string url = "'Default.aspx'";
        const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        var cstype = GetType();
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

        ReportDocument crpReport = new CrpDailySaleReport();

        var dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue));
        var ds = rptInventoryCtl.SelectDailySaleReport(int.Parse(drpDistributor.SelectedValue), int.Parse(DrpPrincipal.SelectedValue), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), ddlType.SelectedIndex, Convert.ToInt32(rblRate.SelectedValue));

        var subReport = crpReport.OpenSubreport("SubreportRealization");
        var subReportCredit = crpReport.OpenSubreport("SubreportCredit");
        var subReportCheques = crpReport.OpenSubreport("subreportCheques");
        var subReportFuel = crpReport.OpenSubreport("SubreportFuel");
        var subReportExpenses = crpReport.OpenSubreport("SubreportExpenses");
        var subReportDiscount = crpReport.OpenSubreport("SubreportDiscount");
        var subReportComDiscount = crpReport.OpenSubreport("SubreportCommulativeDiscount");
        var subReportNote = crpReport.OpenSubreport("SubreportNote");
        crpReport.SetDataSource(ds);
        subReport.SetDataSource(ds);
        subReportCredit.SetDataSource(ds);
        subReportCheques.SetDataSource(ds);
        subReportFuel.SetDataSource(ds);
        subReportExpenses.SetDataSource(ds);
        subReportDiscount.SetDataSource(ds);
        subReportComDiscount.SetDataSource(ds);
        subReportNote.SetDataSource(ds);
        crpReport.Refresh();


        crpReport.SetParameterValue("division", drpDistributor.SelectedItem.Text);
        crpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
        crpReport.SetParameterValue("fromdate", txtStartDate.Text);
        crpReport.SetParameterValue("todate", txtEndDate.Text);
        crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
        crpReport.SetParameterValue("Price", rblRate.SelectedItem.Text);
        crpReport.SetParameterValue("ReportType", "Daily Sale Report");

        Session.Add("CrpReport", crpReport);
        Session.Add("ReportType", 1);
        const string url = "'Default.aspx'";
        const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        var cstype = GetType();
        var cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);            
    }
}
