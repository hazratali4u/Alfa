using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form For Stock Valuation Report
/// </summary>
public partial class Forms_RptStockReconcilation : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
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
        DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));       
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        drpDistributor.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));       
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }

    /// <summary>
    /// Shows Stock Valuation Report in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows Stock Valuation Report in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }

    /// <summary>
    /// Shows Stock Valuation Report in Either PDF Or in Excel
    /// </summary>
    /// <param name="p_Report_Type"></param>
    private void ShowReport(int p_Report_Type)
    {
        DocumentPrintController mController = new DocumentPrintController();
        RptInventoryController RptInventoryCtl = new RptInventoryController();
        DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
        DataSet ds = RptInventoryCtl.SelectStockValuation(DateTime.Parse(txtEndDate.Text), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(rblReportType.SelectedValue));

        if (rblReportType.SelectedValue == "0")
        {
            if (drpDistributor.SelectedItem.Text == "All")
            {
                SAMSBusinessLayer.Reports.CrpStockValuationDetailAllLocations CrpReportDetailAll = new SAMSBusinessLayer.Reports.CrpStockValuationDetailAllLocations();
                CrpReportDetailAll.SetDataSource(ds);
                CrpReportDetailAll.Refresh();
                CrpReportDetailAll.SetParameterValue("division", drpDistributor.SelectedItem.Text);
                CrpReportDetailAll.SetParameterValue("todate", txtEndDate.Text);
                CrpReportDetailAll.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportDetailAll.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                this.Session.Add("CrpReport", CrpReportDetailAll);
                this.Session.Add("ReportType", p_Report_Type);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }

            else
            {
                SAMSBusinessLayer.Reports.CrpStockValuationDetailSingleLocations CrpReportDetailSingle = new SAMSBusinessLayer.Reports.CrpStockValuationDetailSingleLocations();
                CrpReportDetailSingle.SetDataSource(ds);
                CrpReportDetailSingle.Refresh();
                CrpReportDetailSingle.SetParameterValue("division", drpDistributor.SelectedItem.Text);
                CrpReportDetailSingle.SetParameterValue("todate", txtEndDate.Text);
                CrpReportDetailSingle.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportDetailSingle.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                this.Session.Add("CrpReport", CrpReportDetailSingle);
                this.Session.Add("ReportType", p_Report_Type);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
        }
        else
        {
            SAMSBusinessLayer.Reports.CrpStockValuationSummary CrpReportStockValuationSummary = new SAMSBusinessLayer.Reports.CrpStockValuationSummary();
            CrpReportStockValuationSummary.SetDataSource(ds);
            CrpReportStockValuationSummary.Refresh();
            CrpReportStockValuationSummary.SetParameterValue("division", drpDistributor.SelectedItem.Text);
            CrpReportStockValuationSummary.SetParameterValue("todate", txtEndDate.Text);
            CrpReportStockValuationSummary.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            this.Session.Add("CrpReport", CrpReportStockValuationSummary);
            this.Session.Add("ReportType", p_Report_Type);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
    }
}
