using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Reports;

public partial class Forms_RptDamageReport : System.Web.UI.Page
{
    readonly DocumentPrintController _dPrint = new DocumentPrintController();

    readonly RptInventoryController _rptInventoryCtl = new RptInventoryController();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Configuration.SystemCurrentDateTime = (DateTime) Session["CurrentWorkDate"];
            txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text =  Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
             LoadDistributor();
             LoadPrincipal();
            LoadDamageDetail();

        }
    }

    private void LoadDamageDetail()
    {
        
        ChbDamageList.Items.Add(new ListItem("Market Damage", "0"));
        ChbDamageList.Items.Add(new ListItem("Warehouse Damage", "1"));
        ChbDamageList.Items.Add(new ListItem("Transit Damage", "2"));

    }
    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse( Session["UserId"].ToString()), int.Parse( Session["CompanyId"].ToString()));
        drpDistributor.Items.Add(new ListItem("All", Constants.IntNullValue.ToString(CultureInfo.InvariantCulture)));
        clsWebFormUtil.FillDropDownList(drpDistributor, dtDistributor, 0, 2, true);

    }

    private void LoadPrincipal()
    {
        DrpPrincipal.Items.Clear();
        var pController = new SKUPriceDetailController();
        DataTable mDt = pController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse( Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse( Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString(CultureInfo.InvariantCulture)));
        clsWebFormUtil.FillDropDownList( DrpPrincipal, mDt, 0, 1, false );
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadPrincipal();
    }

 


    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        string damageType = null;
        for (int i = 0; i < ChbDamageList.Items.Count; i++)
        {
            if (ChbDamageList.Items[i].Selected)
            {
                damageType = damageType + i + ",";
            }
        }
        if (damageType != null)
        {
            DataTable dt = _dPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue));

           
            DataSet ds = _rptInventoryCtl.RptDamageDetial(int.Parse(drpDistributor.SelectedValue),
                                                          int.Parse(DrpPrincipal.SelectedValue),
                                                          DateTime.Parse(txtStartDate.Text + " 00:00:00"),
                                                          DateTime.Parse(txtEndDate.Text + " 23:59:59"), damageType,
                                                          Convert.ToInt32(rblRate.SelectedValue));

            var crpReport = new CrpDamagedDetailReport();
            crpReport.SetDataSource(ds);
            crpReport.Refresh();

            crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            crpReport.SetParameterValue("PRINCIPAL", DrpPrincipal.SelectedItem.Text);
            crpReport.SetParameterValue("LOCATION", drpDistributor.SelectedItem.Text);
            crpReport.SetParameterValue("ReportTitle", "Damage Detail Report");
            crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            crpReport.SetParameterValue("Price", rblRate.SelectedItem.Text);

             Session.Add("ReportType", 0);
             Session.Add("CrpReport", crpReport);
             const string url = "'Default.aspx'";
             const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url +
                            ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype =  GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
    }
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        string damageType = null;
        for (int i = 0; i < ChbDamageList.Items.Count; i++)
        {
            if (ChbDamageList.Items[i].Selected)
            {
                damageType = damageType + "," + ChbDamageList.SelectedValue;
            }
        }
        if (damageType != null)
        {
            DataTable dt = _dPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue));

            
            DataSet ds = _rptInventoryCtl.RptDamageDetial(int.Parse(drpDistributor.SelectedValue),
                                                          int.Parse(DrpPrincipal.SelectedValue),
                                                          DateTime.Parse(txtStartDate.Text + " 00:00:00"),
                                                          DateTime.Parse(txtEndDate.Text + " 23:59:59"), damageType,
                                                          Convert.ToInt32(rblRate.SelectedValue));

            var crpReport = new CrpDamagedDetailReport();
            crpReport.SetDataSource(ds);
            crpReport.Refresh();

            crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            crpReport.SetParameterValue("PRINCIPAL", DrpPrincipal.SelectedItem.Text);
            crpReport.SetParameterValue("LOCATION", drpDistributor.SelectedItem.Text);
            crpReport.SetParameterValue("ReportTitle", "Damage Detail Report");
            crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            crpReport.SetParameterValue("Price", rblRate.SelectedItem.Text);

             Session.Add("ReportType", 1);
             Session.Add("CrpReport", crpReport);
            const string url = "'Default.aspx'";
            const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url +
                            ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            var cstype =  GetType();
            var cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
       
    }
}
