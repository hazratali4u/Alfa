using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
using CrystalDecisions.Shared;

/// <summary>
/// Form For Customer Classification Report
/// </summary>
public partial class Forms_RptCustomerClassficationReport : System.Web.UI.Page
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
            this.LoadCustomerTable();
            this.LoadChannelType();
            this.Populate_drpSKUDivisions();
            this.Populate_drpSKUCategory();
            this.Populate_drpSKUBrand();
            this.LoadSKUS();

            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtFromDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtToDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
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
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    
    /// <summary>
    /// Loads Divisions To Division Combo
    /// </summary>
    private void Populate_drpSKUDivisions()
    {
        if (DrpPrincipal.Items.Count > 0)
        {
            SkuHierarchyController mHer_Controller = new SkuHierarchyController();
            string strSKUCompanyID = this.DrpPrincipal.SelectedItem.Value;
           
            ddskuDivision.Items.Clear();
   
            if (int.Parse(strSKUCompanyID) > 0)
            {
                DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue, int.Parse(strSKUCompanyID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                ddskuDivision.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuDivision, m_dt, 0, 3);
            }
        }
    }

    /// <summary>
    /// Loads Categories To Category Combo
    /// </summary>
    private void Populate_drpSKUCategory()
    {
        if (ddskuDivision.Items.Count > 0)
        {
            SkuHierarchyController mHer_Controller = new SkuHierarchyController();
            string strSKUDivisionID = this.ddskuDivision.SelectedItem.Value;
            ddskuCategory.Items.Clear();
            if (int.Parse(strSKUDivisionID) > 0)
            {
                DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(strSKUDivisionID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                ddskuCategory.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuCategory, m_dt, 0, 3);
            }
            else
            {
                ddskuCategory.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            }
        }
    }

    /// <summary>
    /// Loads Brands To Brand Combo
    /// </summary>
    private void Populate_drpSKUBrand()
    {
        if (ddskuCategory.Items.Count > 0)
        {
            SkuHierarchyController mHer_Controller = new SkuHierarchyController();
            string strSKUCategoryID = this.ddskuCategory.SelectedItem.Value;
            ddskuBrand.Items.Clear();

            if (int.Parse(strSKUCategoryID) > 0)
            {
                DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, int.Parse(strSKUCategoryID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                ddskuBrand.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuBrand, m_dt, 0, 3);
            }
            else
            {
                ddskuBrand.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            }
        }
    }

    /// <summary>
    /// Loads SKUS To SKU Combo
    /// </summary>
    private void LoadSKUS()
    {
        if (ddskuBrand.Items.Count > 0)
        {
            ddskuName.Items.Clear();
   
            if (ddskuBrand.SelectedValue.ToString() != Constants.IntNullValue.ToString())
            {
                SkuController mSKUController = new SkuController();
                int compid = int.Parse(DrpPrincipal.SelectedItem.Value);
                int divid = int.Parse(ddskuDivision.SelectedItem.Value);
                int catid = int.Parse(ddskuCategory.SelectedItem.Value);
                int barandid = int.Parse(ddskuBrand.SelectedItem.Value);
                int varid = Constants.IntNullValue;

                DataTable m_dt = mSKUController.SelectSkuInfo(compid, divid, catid, barandid, varid);

                clsWebFormUtil.FillDropDownList(this.ddskuName, m_dt, 0, 18);
            }
            else
            {
                ddskuName.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            }
        }
    }

    /// <summary>
    /// Loads Custmers To Customer Grid
    /// </summary>
    private void LoadCustomerTable()
    {
        DataTable  CustomerRange = new DataTable();
        CustomerRange.Columns.Add("SerialNo", typeof(int));
        
        for (int i = 1; i <= 5; i++)
        {
            DataRow dr = CustomerRange.NewRow();
            dr["SerialNo"] = i.ToString();
            CustomerRange.Rows.Add(dr);   
        }
        GrdCustomerRange.DataSource = CustomerRange;
        GrdCustomerRange.DataBind();  
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
    /// Shows Customer Classification Report in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        string QueryValue = "";
        DataControl dc = new DataControl();

        DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
        RptCustomerController RptCustomerCtl = new RptCustomerController();

        for (int i = 0; i < GrdCustomerRange.Rows.Count; i++)
        {
            TextBox txtFrom = (TextBox)GrdCustomerRange.Rows[i].FindControl("txtFromRange");
            TextBox txtTo = (TextBox)GrdCustomerRange.Rows[i].FindControl("txttoRange");
           

            if (decimal.Parse(dc.chkNull_0(txtFrom.Text)) > 0 || decimal.Parse(dc.chkNull_0(txtTo.Text)) > 0)
            {
                if (RBReportType.SelectedIndex == 0)
                {
                    if (RbList.SelectedIndex == 0)
                    {
                        QueryValue += "select " + txtFrom.Text + " as Value,'" + txtFrom.Text + "-" + txtTo.Text + "' as Range,  isnull(count(sold_to),0) as TotalCust,isnull(sum(ctn),0) as TotalCtn from customertemp" +
                                         " where ctn between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";
                    }
                    else
                    {
                        QueryValue += "select " + txtFrom.Text + " as Value, '" + txtFrom.Text + "-" + txtTo.Text + "' as Range,  isnull(count(sold_to),0) as TotalCust,isnull(sum(GSALED),0) as TotalCtn from customertemp" +
                                                            " where GSALED between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";
                    }
                }
                else
                {
                    if (RbList.SelectedIndex == 0)
                    {
                        QueryValue += "select " + txtFrom.Text + " as value,' " + txtFrom.Text + "-" + txtTo.Text + "' as Range, d.distributor_name,CUSTOMER_CODE,CUSTOMER_NAME,Area_name,ctn as TotalCust" +
                       " from customertemp ct inner join" +
                       " customer c on ct.sold_to  = c.customer_id and ct.distributor_id  = c.distributor_id inner join" +
                       " distributor d on d.distributor_id  = c.distributor_id inner join" +
                       " distributor_area da on da.area_id  = c.area_id  and da.distributor_id  = c.distributor_id " +
                       " where ctn between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";

                        
                    }
                    else
                    {
                        QueryValue += "select " + txtFrom.Text + " as value,' " + txtFrom.Text + "-" + txtTo.Text + "' as Range, d.distributor_name,CUSTOMER_CODE,CUSTOMER_NAME,Area_name,GSALED as TotalCust" +
                        " from customertemp ct inner join" +
                        " customer c on ct.sold_to  = c.customer_id and ct.distributor_id  = c.distributor_id inner join" +
                        " distributor d on d.distributor_id  = c.distributor_id inner join" +
                        " distributor_area da on da.area_id  = c.area_id  and da.distributor_id  = c.distributor_id " +
                        " where GSALED between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";
                                                                              
                    }
                }
            }
        }
        
        QueryValue = QueryValue.Substring(0, QueryValue.Length - 6) + " order by value";

        if (RBReportType.SelectedIndex == 0)
        {
            DataSet ds = RptCustomerCtl.GetCustomerClassfication(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text + " 00:00:00"), DateTime.Parse(txtToDate.Text + " 23:59:59"), QueryValue, int.Parse(drpChannelType.SelectedValue.ToString()),
                int.Parse(ddskuDivision.SelectedValue.ToString()), int.Parse(ddskuCategory.SelectedValue.ToString()), int.Parse(ddskuBrand.SelectedValue.ToString()), int.Parse(ddskuName.SelectedValue.ToString()));

            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));

            SAMSBusinessLayer.Reports.CrpCustomerClassfication CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerClassfication();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("RType", RbList.SelectedItem.Text);
            CrpReport.SetParameterValue("Distributor", DrpLocation.SelectedItem.Text);
            CrpReport.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtFromDate.Text));
            CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtToDate.Text));
            CrpReport.SetParameterValue("Category", ddskuCategory.SelectedItem.Text);
            CrpReport.SetParameterValue("Brand", ddskuBrand.SelectedItem.Text);
            CrpReport.SetParameterValue("SKU", ddskuName.SelectedItem.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script); 
        }
        else
        {
            DataSet ds = RptCustomerCtl.GetCustomerClassficationDetail(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text + " 00:00:00"), DateTime.Parse(txtToDate.Text + " 23:59:59"), QueryValue, int.Parse(drpChannelType.SelectedValue.ToString()),
                           int.Parse(ddskuDivision.SelectedValue.ToString()), int.Parse(ddskuCategory.SelectedValue.ToString()), int.Parse(ddskuBrand.SelectedValue.ToString()), int.Parse(ddskuName.SelectedValue.ToString()));
            
            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));

            SAMSBusinessLayer.Reports.CrpCustomerClassificationDetail CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerClassificationDetail();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("RType", RbList.SelectedItem.Text);
            CrpReport.SetParameterValue("Distributor", DrpLocation.SelectedItem.Text);
            CrpReport.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtFromDate.Text));
            CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtToDate.Text));
            CrpReport.SetParameterValue("Category", ddskuCategory.SelectedItem.Text);
            CrpReport.SetParameterValue("Brand", ddskuBrand.SelectedItem.Text);
            CrpReport.SetParameterValue("SKU", ddskuName.SelectedItem.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script); 
        }
        
    }

    /// <summary>
    /// Shows Customer Classification Report in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        string QueryValue = "";
        DataControl dc = new DataControl();
        DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
        RptCustomerController RptCustomerCtl = new RptCustomerController();

        for (int i = 0; i < GrdCustomerRange.Rows.Count; i++)
        {
            TextBox txtFrom = (TextBox)GrdCustomerRange.Rows[i].FindControl("txtFromRange");
            TextBox txtTo = (TextBox)GrdCustomerRange.Rows[i].FindControl("txttoRange");


            if (decimal.Parse(dc.chkNull_0(txtFrom.Text)) > 0 || decimal.Parse(dc.chkNull_0(txtTo.Text)) > 0)
            {
                if (RBReportType.SelectedIndex == 0)
                {
                    if (RbList.SelectedIndex == 0)
                    {
                        QueryValue += "select " + txtFrom.Text + " as Value,'" + txtFrom.Text + "-" + txtTo.Text + "' as Range,  isnull(count(sold_to),0) as TotalCust,isnull(sum(ctn),0) as TotalCtn from customertemp" +
                                         " where ctn between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";
                    }
                    else
                    {
                        QueryValue += "select " + txtFrom.Text + " as Value, '" + txtFrom.Text + "-" + txtTo.Text + "' as Range,  isnull(count(sold_to),0) as TotalCust,isnull(sum(GSALED),0) as TotalCtn from customertemp" +
                                                            " where GSALED between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";
                    }
                }
                else
                {
                    if (RbList.SelectedIndex == 0)
                    {
                        QueryValue += "select " + txtFrom.Text + " as value,' " + txtFrom.Text + "-" + txtTo.Text + "' as Range, d.distributor_name,CUSTOMER_CODE,CUSTOMER_NAME,Area_name,ctn as TotalCust" +
                       " from customertemp ct inner join" +
                       " customer c on ct.sold_to  = c.customer_id and ct.distributor_id  = c.distributor_id inner join" +
                       " distributor d on d.distributor_id  = c.distributor_id inner join" +
                       " distributor_area da on da.area_id  = c.area_id  and da.distributor_id  = c.distributor_id " +
                       " where ctn between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";


                    }
                    else
                    {
                        QueryValue += "select " + txtFrom.Text + " as value,' " + txtFrom.Text + "-" + txtTo.Text + "' as Range, d.distributor_name,CUSTOMER_CODE,CUSTOMER_NAME,Area_name,GSALED as TotalCust" +
                        " from customertemp ct inner join" +
                        " customer c on ct.sold_to  = c.customer_id and ct.distributor_id  = c.distributor_id inner join" +
                        " distributor d on d.distributor_id  = c.distributor_id inner join" +
                        " distributor_area da on da.area_id  = c.area_id  and da.distributor_id  = c.distributor_id " +
                        " where GSALED between " + txtFrom.Text + " AND " + txtTo.Text + " Union ";

                    }
                }
            }
        }

        QueryValue = QueryValue.Substring(0, QueryValue.Length - 6) + " order by value";

        
        if (RBReportType.SelectedIndex == 0)
        {
            DataSet ds = RptCustomerCtl.GetCustomerClassfication(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text + " 00:00:00"), DateTime.Parse(txtToDate.Text + " 23:59:59"), QueryValue, int.Parse(drpChannelType.SelectedValue.ToString()),
                int.Parse(ddskuDivision.SelectedValue.ToString()), int.Parse(ddskuCategory.SelectedValue.ToString()), int.Parse(ddskuBrand.SelectedValue.ToString()), int.Parse(ddskuName.SelectedValue.ToString()));

            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));

            SAMSBusinessLayer.Reports.CrpCustomerClassfication CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerClassfication();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("RType", RbList.SelectedItem.Text);
            CrpReport.SetParameterValue("Distributor", DrpLocation.SelectedItem.Text);
            CrpReport.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtFromDate.Text));
            CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtToDate.Text));
            CrpReport.SetParameterValue("Category", ddskuCategory.SelectedItem.Text);
            CrpReport.SetParameterValue("Brand", ddskuBrand.SelectedItem.Text);
            CrpReport.SetParameterValue("SKU", ddskuName.SelectedItem.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            string path = SAMSCommon.Classes.Configuration.GetAppInstallationPath() + "\\ChartOfAccount.xls";

            CrpReport.SetDatabaseLogon("sa", "Laislabonitamac2065");

            CrpReport.ExportToDisk(ExportFormatType.Excel, path);

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
        else
        {
            DataSet ds = RptCustomerCtl.GetCustomerClassficationDetail(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text + " 00:00:00"), DateTime.Parse(txtToDate.Text + " 23:59:59"), QueryValue, int.Parse(drpChannelType.SelectedValue.ToString()),
                           int.Parse(ddskuDivision.SelectedValue.ToString()), int.Parse(ddskuCategory.SelectedValue.ToString()), int.Parse(ddskuBrand.SelectedValue.ToString()), int.Parse(ddskuName.SelectedValue.ToString()));

            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));

            SAMSBusinessLayer.Reports.CrpCustomerClassificationDetail CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerClassificationDetail();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("RType", RbList.SelectedItem.Text);
            CrpReport.SetParameterValue("Distributor", DrpLocation.SelectedItem.Text);
            CrpReport.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtFromDate.Text));
            CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtToDate.Text));
            CrpReport.SetParameterValue("Category", ddskuCategory.SelectedItem.Text);
            CrpReport.SetParameterValue("Brand", ddskuBrand.SelectedItem.Text);
            CrpReport.SetParameterValue("SKU", ddskuName.SelectedItem.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            string path = SAMSCommon.Classes.Configuration.GetAppInstallationPath() + "\\ChartOfAccount.xls";

            CrpReport.SetDatabaseLogon("sa", "Laislabonitamac2065");

            CrpReport.ExportToDisk(ExportFormatType.Excel, path);
            
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

    /// <summary>
    /// Loads Divisions, Categories, Brands and SKUS
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUDivisions();
        this.Populate_drpSKUCategory();
        this.Populate_drpSKUBrand();
        this.LoadSKUS();
    }

    /// <summary>
    /// Loads Categories
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddskuDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUCategory();
        
    }

    /// <summary>
    /// Loads Brands and SKUS
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddskuCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUBrand();
        this.LoadSKUS();
    }

    /// <summary>
    /// Loads SKUS
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddskuBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUS();
    }
}
