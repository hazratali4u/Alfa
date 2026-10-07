using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;    
using SAMSBusinessLayer.Reports;
using System.Collections.Generic;
/// <summary>
/// Form For Sale Person DSR Report
/// </summary>
public partial class Forms_frmSchemeDiscountReport : System.Web.UI.Page
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
            LoadArea();
            LoadOrderBooker();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
           
        }
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    /// 


    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0 && DrpPrincipal.Items.Count > 0)
        {
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()), Convert.ToInt32(DrpPrincipal.SelectedValue));
            clsWebFormUtil.FillListBox (this.ChbOrderBookerList, m_dt, 0, 3, true);
        }
        else
        {
            ChbOrderBookerList.Items.Clear();
        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All",Constants.IntNullValue.ToString()));       
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
    /// Shows Sale Person DSR in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows Sale Person DSR in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }

    /// <summary>
    /// Gets Sale Person DSR And Shows Either in Excel or PDF
    /// </summary>
    /// <param name="p_ReportType">Type</param>
    private void ShowReport(int p_ReprotType)
    {
        if (RbReportType.SelectedIndex == 0)
        {
            DocumentPrintController DPrint = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = null;

             List <Int32 > OrderBookerList= new List<Int32> ();

            string OrderBooker="";
            string OrderBookerNAme = "";
            for (int i = 0; i < ChbOrderBookerList.Items.Count; i++)
            {
                if (ChbOrderBookerList.Items[i].Selected == true)
                {
                   // OrderBookerList.Add (ChbOrderBookerList .Items [i].Selected) 
                    OrderBooker = OrderBooker + ChbOrderBookerList.Items[i].Value.ToString() + ",";
                    OrderBookerNAme = OrderBookerNAme + ChbOrderBookerList.Items[i].Text + ",";
                }
            }
            var dc = new DataControl();
            ds = RptSaleCtl.GetSchemeDiscountReport(int.Parse(drpDistributor.SelectedValue.ToString()),int.Parse( DrpPrincipal .SelectedValue) ,
                DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(DrpRoute.SelectedValue), OrderBooker);

            var crpReport = new CrpSchemeDiscountReport();


            crpReport.SetDataSource(ds);
            crpReport.Refresh();
            crpReport.SetParameterValue("Distributor_Name", drpDistributor.SelectedItem.Text);
            crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            crpReport.SetParameterValue("Principal",DrpPrincipal .SelectedItem .Text);
            crpReport.SetParameterValue("Route", DrpRoute.SelectedItem.Text);
            crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            crpReport.SetParameterValue("OrderBookerName",OrderBookerNAme );

            this.Session.Add("CrpReport", crpReport);
            this.Session.Add("ReportType", p_ReprotType);
            string url = "'Default.aspx'";                                      
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        else if (RbReportType.SelectedIndex == 1)
        {

            DocumentPrintController DPrint = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = null;

            DataControl dc = new DataControl();
            ds = RptSaleCtl.GetSchemeDiscountReport(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()),Constants .IntNullValue ,"");

            SAMSBusinessLayer.Reports.CrpSchemeDiscountReport CrpReport = new SAMSBusinessLayer.Reports.CrpSchemeDiscountReport();


            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Distributor_Name", drpDistributor.SelectedItem.Text);
            CrpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("Route", DrpPrincipal .SelectedItem .Text );
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", p_ReprotType);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        
    }

   
    protected void RbReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RbReportType.SelectedIndex == 0)
        {
            DrpPrincipal.Enabled = false;
            DrpRoute.Enabled = true;

        }
        else
        {
            DrpRoute.Enabled = false;
            DrpPrincipal.Enabled = true;
        }

    }
   
   
    
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbSelectAll.Checked = false;

        this.LoadOrderBooker();

    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbSelectAll.Checked = false;
        this.LoadArea();
        this.LoadOrderBooker();

    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbSelectAll.Checked = false;
        this.LoadPrincipal();
        this.LoadArea();
        this.LoadOrderBooker();
    }
}
