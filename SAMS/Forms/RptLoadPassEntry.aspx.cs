using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class Forms_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadArea();
            this.LoadOrderBooker();
            this.LoadDeliveryman();
       //     this.txtFromDate.Text = System.DateTime.Today.ToString("dd-MMM-yyyy");
            this.txtFromDate.Text = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).ToString("dd-MMM-yyyy");
        }
       
    }
    private void LoadDistributor()
    {
        int x = int.Parse(this.Session["CompanyId"].ToString());
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);

    }
    private void LoadPrincipal()
    {

        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
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
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0 && DrpPrincipal.Items.Count > 0)
        {
            DrpOrderBooker.Items.Clear();
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()), Convert.ToInt32(DrpPrincipal.SelectedValue));
            DrpOrderBooker.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 3);
        }
        else
        {
            DrpOrderBooker.Items.Clear();
        }
    }
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
        }
    }
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        try
        {
            SAMSBusinessLayer.Classes.DocumentPrintController DPrint = new SAMSBusinessLayer.Classes.DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            string FromDate = null;
       
            DataSet ds = null;

            DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
            FromDate = parsed_date_fromdate.ToShortDateString();
         

          ds = RptSaleCtl.LoadPassEntry2(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()));
            
            SAMSBusinessLayer.Reports.CrpLoadPassEntry CrpReport = new SAMSBusinessLayer.Reports.CrpLoadPassEntry();
            CrpReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            //CrpReport.SetParameterValue("DISTRIBUTOR_ID", this.drpDistributor.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("PRINCIPAL_ID", this.DrpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Rout_ID", this.DrpRoute.SelectedItem.Text);
            CrpReport.SetParameterValue("OrderBooker", this.DrpOrderBooker.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("PRINCIPAL_ID", this.DrpPrincipal.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("FROM_DATE", this.txtFromDate.Text);
            //CrpReport.SetParameterValue("ORDERBOOKER_ID", this.DrpOrderBooker.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("DELIVERY_MAN_ID", this.DrpDeliveryMan.SelectedItem.Text.ToString());

          

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
            
            //else
            //{
                //ds = RptSaleCtl.OrderBookerSheet(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(FromDate + " 00:00:00"), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
                //SAMSBusinessLayer.Reports.CrpOrderBookerSheet CrpReport1 = new SAMSBusinessLayer.Reports.CrpOrderBookerSheet();
                //CrpReport1.SetDataSource(ds);
                //CrpReport1.Refresh();

                //CrpReport1.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text.ToString());
                //CrpReport1.SetParameterValue("Location", this.DrpRoute.SelectedItem.Text.ToString());
                //CrpReport1.SetParameterValue("OrderBooker", this.DrpOrderBooker.SelectedItem.Text.ToString());
                //CrpReport1.SetParameterValue("From_Date", this.txtFromDate.Text);
                //CrpReport1.SetParameterValue("To_Date", this.txtToDate.Text);
                //CrpReport1.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                //this.Session.Add("CrpReport", CrpReport);
                //this.Session.Add("ReportType", 0);
                //string url = "'Default.aspx'";
                //string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                //Type cstype = this.GetType();
                //ClientScriptManager cs = Page.ClientScript;
                //cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void DrpDeliveryMan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDeliveryman();
        this.LoadOrderBooker();
        this.LoadArea();
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDeliveryman();
        this.LoadOrderBooker();
    }
    protected void DrpOrderBooker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        try
        {
            SAMSBusinessLayer.Classes.DocumentPrintController DPrint = new SAMSBusinessLayer.Classes.DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            string FromDate = null;
            //  string ToDate = null;

            DataSet ds = null;

            DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
            FromDate = parsed_date_fromdate.ToShortDateString();



            ds = RptSaleCtl.LoadPassEntry2(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()));



            SAMSBusinessLayer.Reports.CrpLoadPassEntry CrpReport = new SAMSBusinessLayer.Reports.CrpLoadPassEntry();
            CrpReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            //CrpReport.SetParameterValue("DISTRIBUTOR_ID", this.drpDistributor.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("PRINCIPAL_ID", this.DrpPrincipal.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("ROUTE_ID", this.DrpRoute.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("PRINCIPAL_ID", this.DrpPrincipal.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("FROM_DATE", this.txtFromDate.Text);
            //CrpReport.SetParameterValue("ORDERBOOKER_ID", this.DrpOrderBooker.SelectedItem.Text.ToString());
            //CrpReport.SetParameterValue("DELIVERY_MAN_ID", this.DrpDeliveryMan.SelectedItem.Text.ToString());



            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 1);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);

            //else
            //{
            //ds = RptSaleCtl.OrderBookerSheet(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(FromDate + " 00:00:00"), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
            //SAMSBusinessLayer.Reports.CrpOrderBookerSheet CrpReport1 = new SAMSBusinessLayer.Reports.CrpOrderBookerSheet();
            //CrpReport1.SetDataSource(ds);
            //CrpReport1.Refresh();

            //CrpReport1.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text.ToString());
            //CrpReport1.SetParameterValue("Location", this.DrpRoute.SelectedItem.Text.ToString());
            //CrpReport1.SetParameterValue("OrderBooker", this.DrpOrderBooker.SelectedItem.Text.ToString());
            //CrpReport1.SetParameterValue("From_Date", this.txtFromDate.Text);
            //CrpReport1.SetParameterValue("To_Date", this.txtToDate.Text);
            //CrpReport1.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            //this.Session.Add("CrpReport", CrpReport);
            //this.Session.Add("ReportType", 0);
            //string url = "'Default.aspx'";
            //string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            //Type cstype = this.GetType();
            //ClientScriptManager cs = Page.ClientScript;
            //cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}