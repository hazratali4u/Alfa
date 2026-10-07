using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Reports;
using CrystalDecisions.CrystalReports.Engine;

/// <summary>
/// Form For Sales Purchase Format Report
/// </summary>
public partial class Forms_RptSalesPurchaseFormat : System.Web.UI.Page
{
    RptAccountController RptAccountCtl = new RptAccountController();

    /// <summary>
    /// Page_Load Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadLocation();
            this.txtFromDate.Text = System.DateTime.Today.ToString("dd-MMM-yyyy");
            this.txtToDate.Text = System.DateTime.Today.ToString("dd-MMM-yyyy");

        }
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    protected void LoadPrincipal()
    {
        try
        {
            drpPrincipal.Items.Clear();

            if (DrpReportType.SelectedValue == "0")
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, "Company_Id", "Company_Name");
            }
            else
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                this.drpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, "Company_Id", "Company_Name");
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    protected void LoadLocation()
    {
        try
        {
            DrpLocation.Items.Clear();

            if (DrpReportType.SelectedValue == "0")
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, "DISTRIBUTOR_ID", "DISTRIBUTOR_NAME");
            }
            else
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                this.DrpLocation.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, "DISTRIBUTOR_ID", "DISTRIBUTOR_NAME");
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    /// <summary>
    /// Shows Sales Purchase Format in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        try
        {
            SAMSBusinessLayer.Classes.DocumentPrintController DPrint = new SAMSBusinessLayer.Classes.DocumentPrintController();

            string FromDate = null;
            int CustmerType = Constants.IntNullValue;
            if (rblCustomerType.SelectedValue != "-1")
            {
                CustmerType = Convert.ToInt32(rblCustomerType.SelectedValue);
            }

            ReportClass CrpReport = new ReportClass();
            if (DrpReportType.SelectedValue == "0")
            {
                CrpReport = new SAMSBusinessLayer.Reports.CrpSalesFormat();
            }
            else
            {
                CrpReport = new SAMSBusinessLayer.Reports.CrpPurchaseFormat();
            }
            DataSet ds = null;

            DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));

            ds = RptAccountCtl.GetSalesPurchaseFormat(int.Parse(DrpLocation.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()), Convert.ToDateTime(txtFromDate.Text + " 00:00:00"), Convert.ToDateTime(txtToDate.Text + " 23:59:59"),CustmerType, Convert.ToInt32(DrpReportType.SelectedValue));

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Location", this.DrpLocation.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
            CrpReport.SetParameterValue("ToDate", this.txtToDate.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("GSTType", DrpReportType.SelectedItem.Text);

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    /// <summary>
    /// Shows Sales Purchase Format in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        string path = SAMSCommon.Classes.Configuration.GetAppInstallationPath() + "\\SalesPurchaseFormat.xls";
        int CustmerType = Constants.IntNullValue;
        if (rblCustomerType.SelectedValue != "-1")
        {
            CustmerType = Convert.ToInt32(rblCustomerType.SelectedValue);
        }

        DataSet ds = RptAccountCtl.GetSalesPurchaseFormat(int.Parse(DrpLocation.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()), Convert.ToDateTime(txtFromDate.Text + " 00:00:00"), Convert.ToDateTime(txtToDate.Text + " 23:59:59"),CustmerType, Convert.ToInt32(DrpReportType.SelectedValue));
        
        if (DrpReportType.SelectedValue == "0")
        {
            DataSetToExcel.exportToExcel(ds, path, "uspGetSalesFormat");
        }
        else
        {
            DataSetToExcel.exportToExcel(ds, path, "uspGetPurchaseFormat");
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
