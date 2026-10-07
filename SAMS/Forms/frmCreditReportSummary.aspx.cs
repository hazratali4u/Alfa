using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form For  Credit Report
/// </summary>
public partial class Forms_frmCreditReportSummary : System.Web.UI.Page
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
            this.LoadOrderBooker();            
            this.LoadChannelType();
            this.LoadArea();
            this.LoadSaleForce();
            this.LoadCreditCustomer();
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
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Order Bookers To OrderBooker Combo
    /// </summary>
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DrpOrderBooker.Items.Clear();
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectDistributorUser(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            DrpOrderBooker.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 6);
        }
    }

    /// <summary>
    /// Loads Deliverymen To Sale Force Combo
    /// </summary>
    private void LoadSaleForce()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            ddlSaleForce.Items.Clear();
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            ddlSaleForce.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.ddlSaleForce, m_dt, 0, 3);
        }        
    }

    /// <summary>
    /// Loads Routes To Route Combo
    /// </summary>
    private void LoadArea()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DrpRoute.Items.Clear();
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            DrpRoute.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }

    /// <summary>
    /// Loads Channel Types To ChannelType Combo
    /// </summary>
    private void LoadChannelType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, bool.Parse("True"));
        drpChannelType.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(drpChannelType, dt, 0, 2);

    }

    /// <summary>
    /// Loads Credit Customers To Customer Combo
    /// </summary>
    private void LoadCreditCustomer()
    {
        DrpCustomer.Items.Clear();
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            DrpCustomer.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, dt, 0, 4);
        }
        else
        {
            DrpCustomer.Items.Add(new ListItem("Customer Not Found", Constants.IntNullValue.ToString()));
        }
    }

    /// <summary>
    /// Shows Credit Report in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows Credit Report in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }
    
    /// <summary>
    /// Shows Credit Report Either in PDF Or in Excel
    /// </summary>
    /// <param name="p_Report_Type">ReportType</param>
    private void ShowReport(int p_Report_Type)
    
    {
        RptCustomerController RptCustomerCtl = new RptCustomerController();
        if (rbCreditReport.Checked)
        {
            DocumentPrintController mController = new DocumentPrintController();
            DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            if (DrpSort.SelectedValue == "0")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummary CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummary();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()),Convert.ToInt32(ddlTagType.SelectedValue),Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReport.SetDataSource(ds);


                CrpReport.Refresh();

                if (DrpSort.SelectedValue == "0")

                {
                    if (rbtSortOrder.SelectedIndex == 0)
                    {
                        CrpReport.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                    }
                    else
                    {
                        CrpReport.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                    }
                }

                CrpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReport.SetParameterValue("From_date", txtStartDate.Text);
                CrpReport.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReport.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
                CrpReport.SetParameterValue("LastDayClose", Convert.ToDateTime(dt.Rows[0]["LastDayClose"]));
                this.Session.Add("CrpReport", CrpReport);
            }
            else if (DrpSort.SelectedValue == "1")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryDate CrpReportDate = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryDate();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToInt32(ddlTagType.SelectedValue), Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReportDate.SetDataSource(ds);


                CrpReportDate.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReportDate.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReportDate.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }


                CrpReportDate.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReportDate.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReportDate.SetParameterValue("From_date", txtStartDate.Text);
                CrpReportDate.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReportDate.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportDate.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReportDate.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
                CrpReportDate.SetParameterValue("LastDayClose", Convert.ToDateTime(dt.Rows[0]["LastDayClose"]));
                this.Session.Add("CrpReport", CrpReportDate);
            }
            else if (DrpSort.SelectedValue == "2")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryClosingWise CrpReportClosingWise = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryClosingWise();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetailClosingWise(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()),Convert.ToInt32(ddlTagType.SelectedValue),Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReportClosingWise.SetDataSource(ds);


                CrpReportClosingWise.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReportClosingWise.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReportClosingWise.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }

                CrpReportClosingWise.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReportClosingWise.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReportClosingWise.SetParameterValue("From_date", txtStartDate.Text);
                CrpReportClosingWise.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReportClosingWise.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportClosingWise.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReportClosingWise.SetParameterValue("Area", DrpRoute.SelectedItem.Text);                
                this.Session.Add("CrpReport", CrpReportClosingWise);
            }
            else if (DrpSort.SelectedValue == "3")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryAllowDays CrpReportAllowDays = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryAllowDays();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToInt32(ddlTagType.SelectedValue), Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReportAllowDays.SetDataSource(ds);


                CrpReportAllowDays.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReportAllowDays.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReportAllowDays.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }

                CrpReportAllowDays.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReportAllowDays.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReportAllowDays.SetParameterValue("From_date", txtStartDate.Text);
                CrpReportAllowDays.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReportAllowDays.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportAllowDays.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReportAllowDays.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
                CrpReportAllowDays.SetParameterValue("LastDayClose", Convert.ToDateTime(dt.Rows[0]["LastDayClose"]));
                this.Session.Add("CrpReport", CrpReportAllowDays);
            }
            else if (DrpSort.SelectedValue == "4")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryCreditDays CrpReportCreditDays = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryCreditDays();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToInt32(ddlTagType.SelectedValue), Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReportCreditDays.SetDataSource(ds);


                CrpReportCreditDays.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReportCreditDays.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReportCreditDays.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }

                CrpReportCreditDays.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReportCreditDays.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReportCreditDays.SetParameterValue("From_date", txtStartDate.Text);
                CrpReportCreditDays.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReportCreditDays.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportCreditDays.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReportCreditDays.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
                CrpReportCreditDays.SetParameterValue("LastDayClose", Convert.ToDateTime(dt.Rows[0]["LastDayClose"]));
                this.Session.Add("CrpReport", CrpReportCreditDays);
            }
            else if (DrpSort.SelectedValue == "5")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryOverAgeDays CrpReportOverAgeDays = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryOverAgeDays();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToInt32(ddlTagType.SelectedValue), Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReportOverAgeDays.SetDataSource(ds);


                CrpReportOverAgeDays.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReportOverAgeDays.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReportOverAgeDays.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }

                CrpReportOverAgeDays.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReportOverAgeDays.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReportOverAgeDays.SetParameterValue("From_date", txtStartDate.Text);
                CrpReportOverAgeDays.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReportOverAgeDays.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportOverAgeDays.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReportOverAgeDays.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
                CrpReportOverAgeDays.SetParameterValue("LastDayClose", Convert.ToDateTime(dt.Rows[0]["LastDayClose"]));
                this.Session.Add("CrpReport", CrpReportOverAgeDays);
            }
            else if (DrpSort.SelectedValue == "6")
            {
                SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryOrderBooker CrpReportOrderBooker = new SAMSBusinessLayer.Reports.CrpCustomerCreditSummaryOrderBooker();

                DataSet ds = RptCustomerCtl.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(DrpSort.SelectedValue), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToInt32(ddlTagType.SelectedValue), Convert.ToInt32(ddlSaleForce.SelectedValue),Convert.ToInt32(ddlCreditType.SelectedValue));
                CrpReportOrderBooker.SetDataSource(ds);


                CrpReportOrderBooker.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReportOrderBooker.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReportOrderBooker.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }

                CrpReportOrderBooker.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
                CrpReportOrderBooker.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
                CrpReportOrderBooker.SetParameterValue("From_date", txtStartDate.Text);
                CrpReportOrderBooker.SetParameterValue("To_Date", txtEndDate.Text);
                CrpReportOrderBooker.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReportOrderBooker.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
                CrpReportOrderBooker.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
                CrpReportOrderBooker.SetParameterValue("LastDayClose", Convert.ToDateTime(dt.Rows[0]["LastDayClose"]));
                this.Session.Add("CrpReport", CrpReportOrderBooker);
            }

            this.Session.Add("ReportType", p_Report_Type);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        else
        {
            DocumentPrintController mController = new DocumentPrintController();
            SAMSBusinessLayer.Reports.CrpCustomerWiseSelling CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerWiseSelling();
            DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            string strCreditType = "0";
            if (ddlCreditType.SelectedValue != "0")
            {
                strCreditType = ddlCreditType.SelectedItem.Text;
            }

            DataSet ds = RptCustomerCtl.SelectCustomerCreditCeiling(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()),strCreditType);
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();
            CrpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("CreditType", ddlCreditType.SelectedItem.Text);

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", p_Report_Type);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
    }

    /// <summary>
    /// Loads Order Bookers, Routes And Customers
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
        this.LoadSaleForce();
        this.LoadArea();
        this.LoadCreditCustomer();
    }

    /// <summary>
    /// Loads Customers
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSaleForce();
        this.LoadCreditCustomer();
    }
    protected void rbCreditLimit_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void rbCreditReport_CheckedChanged(object sender, EventArgs e)
    {

    }
}
