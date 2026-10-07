using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Classes;
using SAMSBusinessLayer.Reports;  
using System.IO;

/// <summary>
/// Form To Import Vouchers
/// </summary>
public partial class Forms_frmMakeVoucher : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.VoucherType();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Voucher Types To VoucherType Combo
    /// </summary>
    private void VoucherType()
    {
        LedgerController LController = new LedgerController();
        DataTable dt = LController.SelectVoucherType(int.Parse(this.Session["UserId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpVoucherType, dt, 0, 1, true);
    }
    
    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Entry", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }

    /// <summary>
    /// Imports Vouchers From ExcelFile
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LedgerController LController = new LedgerController();
        int  IsSave = 0;
 
        if (RbdList.SelectedIndex == 1)
        {
            if (!Directory.Exists(Constants.fldOtherDataFolder))
            {
                Directory.CreateDirectory(Constants.fldOtherDataFolder);
            }

            string path = txtFile.PostedFile.FileName;
            string filename = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));

            if (File.Exists(Constants.fldOtherDataFolder + filename))
            {
                lblErrorMessage.Text = "File already Exist in folder. Save file with other name";
                return;
            }
            else
            {
                DateTime ChequeDate;
                DateTime Voucherdate;

                if (txtStartDate.Text.Length < 10)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter Voucher Date');", true);
                    return;
                }
                else
                {
                    Voucherdate = DateTime.Parse(txtStartDate.Text);
                }

                if (txtEndDate.Text.Length == 10)
                {
                    ChequeDate = DateTime.Parse(txtEndDate.Text);

                }
                else
                {
                    ChequeDate = Constants.DateNullValue;
                }
                string MaxDocumentId = LController.SelectMaxVoucherId(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text));

                txtFile.PostedFile.SaveAs(Constants.fldOtherDataFolder + filename);
                path = Constants.fldOtherDataFolder + filename;

                IsSave = LController.Import_Voucher(int.Parse(DrpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), MaxDocumentId, int.Parse(DrpVoucherType.SelectedValue.ToString()), Voucherdate,ChequeDate,
                     22, null, txtAccountDes.Text, path, int.Parse(this.Session["UserId"].ToString()));
                                      
            }
            if (IsSave == 0)
            {
                DataTable dt = LController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()),int.Parse(DrpPrincipal.SelectedValue.ToString()),false, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtStartDate.Text + " 23:59:59"),1);
                GrdLedger.DataSource = dt;
                GrdLedger.DataBind();
            }
            else if (IsSave > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Som Error in Line No " + IsSave.ToString() + " ');", true);
            }
        }
        else
        {
            DateTime Fromdate;
            DateTime Todate;

            Fromdate = DateTime.Parse(txtStartDate.Text);
            Todate = DateTime.Parse(txtEndDate.Text);
            DistributorController mDayClose = new DistributorController();
            int TotalDays = Todate.Day - Fromdate.Day;

            while (TotalDays >= 0)
            {
                mDayClose.PostCashDeposit(Fromdate, int.Parse(DrpDistributor.SelectedValue.ToString()), 1, Constants.IntNullValue, Constants.Bank_Deposit);
                mDayClose.PostCashDeposit(Fromdate, int.Parse(DrpDistributor.SelectedValue.ToString()), 1, Constants.IntNullValue, Constants.Cheque_Relization);
                Fromdate = Fromdate.AddDays(1);
                TotalDays = TotalDays - 1;                
            }
            DataTable dt = LController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()),int.Parse(DrpPrincipal.SelectedValue.ToString()),false, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),1);
            GrdLedger.DataSource = dt;
            GrdLedger.DataBind();
        }        
    }

    /// <summary>
    /// Stores Variables In Session And Redirect To Voucher Editing Form
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdLedger_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.Session.Add("VoucherNo", GrdLedger.Rows[e.RowIndex].Cells[1].Text);
        this.Session.Add("DistributorId", DrpDistributor.SelectedValue.ToString());
        this.Session.Add("VoucherTypeId", DrpVoucherType.SelectedValue.ToString());
        Response.Redirect("~/Forms/frmVoucherEditing.aspx?Status=" + false);        
    }

    /// <summary>
    /// Shows Vouchers in Crystal Report For Print Purpose
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdLedger_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        RptAccountController RptAccountCtl = new RptAccountController();
        SAMSBusinessLayer.Reports.crpVoucherView CrpReport = new SAMSBusinessLayer.Reports.crpVoucherView();

        DataSet ds = null;
        DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpDistributor.SelectedValue.ToString()));
        ds = RptAccountCtl.SelectUnpostVoucherForPrint(int.Parse(DrpDistributor.SelectedValue.ToString()), GrdLedger.Rows[e.NewEditIndex].Cells[1].Text, int.Parse(DrpVoucherType.SelectedValue.ToString()));
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());
        CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }

    /// <summary>
    /// Cancels Voucher Posting
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LedgerController lController = new LedgerController();
        foreach (GridViewRow dr in GrdLedger.Rows)
        {
            CheckBox ChbSelect = (CheckBox)dr.Cells[0].FindControl("ChbSelect");
            if (ChbSelect.Checked == true)
            {
                lController.PostSelectVoucher(int.Parse(DrpDistributor.SelectedValue.ToString()), dr.Cells[1].Text, int.Parse(dr.Cells[4].Text), 1, DateTime.Parse(dr.Cells[5].Text));
            }
        }
        
        DataTable dt = lController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()),int.Parse(DrpPrincipal.SelectedValue.ToString()), false, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),1);
        GrdLedger.DataSource = dt;
        GrdLedger.DataBind();
    }

    /// <summary>
    /// Loads Vouchers To Voucher Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnView_Click(object sender, EventArgs e)
    {
        LedgerController mController = new LedgerController();
        DataTable dt = mController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()),int.Parse(DrpPrincipal.SelectedValue.ToString()), false, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),1);
        GrdLedger.DataSource = dt;
        GrdLedger.DataBind();  
    }

    /// <summary>
    /// Checks All Vouchers in Voucher Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbSelect_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in GrdLedger.Rows)
        {
            CheckBox ChbSelect = (CheckBox)dr.Cells[0].FindControl("ChbSelect");
            ChbSelect.Checked = true;
        }
    }

    /// <summary>
    /// Sets Labels For Voucher Import And Voucher Post
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void RbdList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RbdList.SelectedIndex == 1)
        {   
            Label6.Text = "Cheque Date";
            Label2.Text = "Voucher Date";
        }
        else
        {
            Label2.Text = "From Date";
            Label6.Text = "To Date";            
        }
    }   
}
