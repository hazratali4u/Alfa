using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Reports;

/// <summary>
/// Form For Sale Tax Return on Sale Report
/// </summary>
public partial class Forms_RptSalesTaxReturn : System.Web.UI.Page
{
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
            this.LoadRoute();
            this.LoadCustomer();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtFromDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtToDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        drpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1);
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        DrpLocation.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, 0, 2);
    }

    /// <summary>
    /// Loads Routes To Route Combo
    /// </summary>
    private void LoadRoute()
    {
        if (DrpLocation.Items.Count > 0)
        {
            DrpRoute.Items.Clear();
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(DrpLocation.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            DrpRoute.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }

    /// <summary>
    /// Loads Customers To Customer Combo
    /// </summary>
    private void LoadCustomer()
    {
        DrpCustomer.Items.Clear();
        DrpCustomer.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        if (DrpLocation.Items.Count > 0 && DrpRoute.Items.Count > 0 && DrpRoute.SelectedValue != Constants.IntNullValue.ToString())
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectAllCustomer(int.Parse(DrpLocation.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Constants.IntNullValue);
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, dt, 0, 3, false);

        }
    }

    /// <summary>
    /// Shows Sale Tax Return on Sale Either in PDF or In Excel
    /// </summary>
    /// <param name="p_ReportType">Type</param>
    private void ShowReport(int p_ReportType)
    {
        int p_Registered = Constants.IntNullValue;
        int p_ReportFor = Constants.IntNullValue;
        int p_Route_ID = Constants.IntNullValue;
        int p_Customer_ID = Constants.IntNullValue;

        DocumentPrintController DPrint = new DocumentPrintController();
        RptAccountController RptAccountCtl = new RptAccountController();


        if (rblCustomerType.SelectedIndex > 0)
        {
            if (!(rbIndividual.Checked && DrpCustomer.SelectedValue != Constants.IntNullValue.ToString()))
            {
                p_Registered = Convert.ToInt32(rblCustomerType.SelectedValue);
            }
        }
        if (rbDetail.Checked)
        {
            p_ReportFor = 0;
        }
        else if (rbSummary.Checked)
        {
            p_ReportFor = 1;
        }
        else if(rbIndividual.Checked)
        {
            p_ReportFor = 2;
            p_Route_ID = Convert.ToInt32(DrpRoute.SelectedValue);
            p_Customer_ID = Convert.ToInt32(DrpCustomer.SelectedValue);
        }

        DataSet ds = RptAccountCtl.SelectRptSaleTaxReport(int.Parse(DrpLocation.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()),
                     DateTime.Parse(txtFromDate.Text + " 00:00:00"), DateTime.Parse(txtToDate.Text + " 23:59:59"), p_ReportFor, p_Registered, p_Route_ID, p_Customer_ID);

        DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));
        CrystalDecisions.CrystalReports.Engine.ReportDocument CrpReport;

        if (rbDetail.Checked)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSaletaxDetail();
        }
        else if (rbSummary.Checked)
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSaletaxSummary();
        }
        else
        {
            CrpReport = new SAMSBusinessLayer.Reports.CrpSaletaxCustomerWise();
        }
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Branch", DrpLocation.SelectedItem.Text);
        CrpReport.SetParameterValue("From_date", DateTime.Parse(txtFromDate.Text));
        CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtToDate.Text));
        CrpReport.SetParameterValue("Principal", drpPrincipal.SelectedItem.Text);
        if (rbIndividual.Checked && DrpCustomer.SelectedValue != Constants.IntNullValue.ToString())
        {
            CrpReport.SetParameterValue("CustomerType", "Individual Customer");
        }
        else
        {
            CrpReport.SetParameterValue("CustomerType", rblCustomerType.SelectedItem.Text);
        }

        CrpReport.SetParameterValue("Company_name", dt.Rows[0]["COMPANY_NAME"].ToString());

        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", p_ReportType);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }

    /// <summary>
    /// Shows Sale Tax Return on Sale in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows Sale Tax Return on Sale in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }

    /// <summary>
    /// Loads Customers
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomer();
    }

    /// <summary>
    /// Loads Routes
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRoute();
    }
}
