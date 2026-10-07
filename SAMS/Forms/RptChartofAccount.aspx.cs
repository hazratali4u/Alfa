using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Reports;

/// <summary>
/// Form For Chart of Account Report
/// </summary>
public partial class Forms_RptChartofAccount : System.Web.UI.Page
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
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetDetailAccountType();
        }
    }

    /// <summary>
    /// Loads Account Types To AccountType Combo
    /// </summary>
    private void GetAccountType()
    {
        DrpMainType.Items.Clear();
  
        AccountHeadController MController = new AccountHeadController();
        DataTable dt = MController.GetAccountHead(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, DrpAccountCategory.SelectedIndex, Constants.AC_MainTypeId);          
        DrpMainType.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));        
        clsWebFormUtil.FillDropDownList(DrpMainType, dt, 0, 1);
    }

    /// <summary>
    /// Loads Account Sub Types To SubType Combo
    /// </summary>
    private void GetSubAccountType()
    {
        DrpSubType.Items.Clear();
   
        AccountHeadController MController = new AccountHeadController();
        if (DrpMainType.Items.Count > 0)
        {
            DataTable dt = MController.GetAccountHead(int.Parse(DrpMainType.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, DrpAccountCategory.SelectedIndex, Constants.AC_SubTypeId);
            DrpSubType.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpSubType, dt, 0, 1);
        }
    }

    /// <summary>
    /// Loads Account Detail Types To Detail Type Combo
    /// </summary>
    private void GetDetailAccountType()
    {
        DrpDetailType.Items.Clear();
   
        AccountHeadController MController = new AccountHeadController();
        if (DrpSubType.Items.Count > 0)
        {
            DataTable dt = MController.GetAccountHead(int.Parse(DrpMainType.SelectedValue.ToString()), int.Parse(DrpSubType.SelectedValue.ToString()), Constants.IntNullValue, DrpAccountCategory.SelectedIndex, Constants.AC_DetailTypeId);
            DrpDetailType.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpDetailType, dt, 0, 1);
        }
    }

    /// <summary>
    /// Shows Chart of Account in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        RptAccountController RptAccountCtl = new RptAccountController();

        DataSet ds = RptAccountCtl.SelectRptChartofAccount(DrpAccountCategory.SelectedIndex, int.Parse(DrpMainType.SelectedValue.ToString()), int.Parse(DrpSubType.SelectedValue.ToString()), int.Parse(DrpDetailType.SelectedValue.ToString()));
        DataTable  dt = DPrint.SelectReportTitle(Constants.IntNullValue);

        SAMSBusinessLayer.Reports.CrpchartOfAccunt CrpReport = new SAMSBusinessLayer.Reports.CrpchartOfAccunt();
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());

        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }

    /// <summary>
    /// Loads Account Sub Types And Detail Types
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSubAccountType();
        this.GetDetailAccountType(); 
    }

    /// <summary>
    /// Loads Account Detail Types
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDetailAccountType(); 
    }

    /// <summary>
    /// Shows Chart of Account in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        RptAccountController RptAccountCtl = new RptAccountController();

        DataSet ds = RptAccountCtl.SelectRptChartofAccount(DrpAccountCategory.SelectedIndex ,int.Parse(DrpMainType.SelectedValue.ToString()),int.Parse(DrpSubType.SelectedValue.ToString()),int.Parse(DrpDetailType.SelectedValue.ToString()));
        DataSetToExcel dsexcel = new DataSetToExcel();
        DataControl dc = new DataControl();
        
        string path = SAMSCommon.Classes.Configuration.GetAppInstallationPath() + "\\ChartOfAccount.xls";

        DataSetToExcel.exportToExcel(ds, path, "Account_Head_View");

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

    /// <summary>
    /// Loads Account Types, Sub Types And Detail Types
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpAccountCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetAccountType();
        this.GetSubAccountType();
        this.GetDetailAccountType(); 
    }
}
