using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form For Sales Purchase Register Report
/// </summary>
public partial class Forms_RptSalesPurchaseRegister : System.Web.UI.Page
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
            txtMonth.Text = System.DateTime.Now.ToString("MMM-yyyy");
           
            this.LoadPrincipal();
            this.LoadDistributor();
        }
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        //DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        this.drpDistributor.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }

    /// <summary>
    /// Shows Sales Purchase Register in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        DateTime dtMonth = DateTime.Parse(txtMonth.Text);
        DateTime dtFrom = new DateTime(dtMonth.Year, dtMonth.Month, 1);
        DateTime dtTo = new DateTime(dtMonth.Year, dtMonth.Month, 1);
        dtTo = dtTo.AddMonths(1).AddDays(-1);
        DocumentPrintController mController = new DocumentPrintController();
        RptAccountController RptAccountCtl = new RptAccountController();
        DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
        DataSet ds = RptAccountCtl.SelectSalesPurchaseRegister(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), rblReportType.SelectedIndex, dtFrom, dtTo, int.Parse(this.Session["UserId"].ToString()));

        CrystalDecisions.CrystalReports.Engine.ReportDocument CrpReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();


        if (rblReportType.SelectedIndex == 0)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseTaxableRegister();
        }
        else if (rblReportType.SelectedIndex == 1)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseIIIScheduledRegister();
        }
        else if (rblReportType.SelectedIndex == 2)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseExemptedRegister();
        }
        else if (rblReportType.SelectedIndex == 3)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseTaxablePurchaseRegister();
        }
        else if (rblReportType.SelectedIndex == 4)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseIIIShedulePurchaseRegister();
        }
        else if (rblReportType.SelectedIndex == 5)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseExemptPurchaseRegister();
        }
        else if (rblReportType.SelectedIndex == 6)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSalesPurchaseStockRegister();
        }

        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();
        CrpReport.SetParameterValue("Month", DateTime.Parse(txtMonth.Text));
        CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
        CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
        CrpReport.SetParameterValue("Location", drpDistributor.SelectedItem.Text);
        if (rblReportType.SelectedIndex != 6)
        {
            CrpReport.SetParameterValue("TAXREGISTERATION_NO", dt.Rows[0]["GST_NUMBER"].ToString());
        }
        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }

    /// <summary>
    /// Shows Sales Purchase Register in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        RptAccountController RptAccountCtl = new RptAccountController();
        DateTime dtMonth = DateTime.Parse(txtMonth.Text);
        DateTime dtFrom = new DateTime(dtMonth.Year, dtMonth.Month, 1);
        DateTime dtTo = new DateTime(dtMonth.Year, dtMonth.Month, 1);
        dtTo = dtTo.AddMonths(1).AddDays(-1);
        string path = SAMSCommon.Classes.Configuration.GetAppInstallationPath() + "\\RouteEfficiencyReport.xls";
       
        DataSet ds = RptAccountCtl.SelectSalesPurchaseRegister(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), rblReportType.SelectedIndex, dtFrom, dtTo, int.Parse(this.Session["UserId"].ToString()));

        if (rblReportType.SelectedIndex == 6)
        {
            DataSetToExcel.exportToExcel(ds, path, "SalesPurchaseStockRegister");
        }
        else
        {
            DataSetToExcel.exportToExcel(ds, path, "SalesPurchaseTaxableRegister");
        }
        
        System.IO.FileInfo file = new System.IO.FileInfo(path);

        if (file.Exists)
        {
            Response.Clear();

            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

            Response.AddHeader("Content-Length", file.Length.ToString());

            Response.ContentType = "application/octet-stream";

            Response.WriteFile(file.FullName);

            Response.End();

        }
        else
        {
            Response.Write("This file does not exist.");
        }
    }
}
