using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class Forms_frmVoucherEditing : System.Web.UI.Page
{
    DataTable dtVoucher;
    private static int RowId = -1;

    private void CreatTable()
    {
        dtVoucher = new DataTable();
        dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        dtVoucher.Columns.Add("Account_Code", typeof(string));
        dtVoucher.Columns.Add("Account_Name", typeof(string));
        dtVoucher.Columns.Add("Debit", typeof(decimal));
        dtVoucher.Columns.Add("Credit", typeof(decimal));
        dtVoucher.Columns.Add("Remarks", typeof(string));
        dtVoucher.Columns.Add("Principal_Id", typeof(string));
        dtVoucher.Columns.Add("Principal", typeof(string));
        this.Session.Add("dtVoucher", dtVoucher);

    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Entry", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadAccountDetail()
    {
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
        clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
        this.Session.Add("dtHead", dtHead);

    }
    private void LoadEditVoucher()
    {
        LedgerController LController = new LedgerController();
        DataTable dtVoucher = (DataTable)this.Session["dtVoucher"];

        DataTable dt = LController.SelectVoucherNo(Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), lblVoucherNo.Text);
        if (dt.Rows.Count > 0)
        {
            //DrpPrincipal.SelectedValue = dt.Rows[0]["PRINCIPAL_ID"].ToString();
            drpDistributor.SelectedValue = dt.Rows[0]["DISTRIBUTOR_ID"].ToString();
            DrpVoucherType.SelectedValue = dt.Rows[0]["VOUCHER_TYPE_ID"].ToString();
            DrpPaymentMode.SelectedValue = dt.Rows[0]["PAYMENT_MODE"].ToString();
            txtVoucherDate.Text = DateTime.Parse(dt.Rows[0]["VOUCHER_DATE"].ToString()).ToString("dd/MM/yyyy");
            
            if (dt.Rows[0]["CHEQUE_DATE"].ToString().Length > 10)
            {
                txtChequeDate.Text = DateTime.Parse(dt.Rows[0]["CHEQUE_DATE"].ToString()).ToString("dd/MM/yyyy");
            }
            if (dt.Rows[0]["DUE_DATE"].ToString().Length > 10)
            {
                txtDueDate.Text = DateTime.Parse(dt.Rows[0]["DUE_DATE"].ToString()).ToString("dd/MM/yyyy");
            }
            txtChequeNo.Text = dt.Rows[0]["CHEQUE_NO"].ToString();
            txtRemarks.Text = dt.Rows[0]["REMARKS"].ToString();
            txtpayeesName.Text = dt.Rows[0]["PAYEES_NAME"].ToString();

            dtVoucher = LController.SelectVoucherDetail(int.Parse(drpDistributor.SelectedValue.ToString()),lblVoucherNo.Text,int.Parse(DrpVoucherType.SelectedValue.ToString()));

            this.Session.Add("dtVoucher", dtVoucher);
            GrdOrder.DataSource = dtVoucher;
            GrdOrder.DataBind();
                        
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountDetail();
            this.LoadPrincipal();
            this.CreatTable();
            this.lblVoucherNo.Text = this.Session["VoucherNo"].ToString();
            this.drpDistributor.SelectedValue = this.Session["DistributorId"].ToString();
            this.DrpVoucherType.SelectedValue = this.Session["VoucherTypeId"].ToString();
            if (int.Parse(this.DrpVoucherType.SelectedValue.ToString()) == Constants.Journal_Voucher)
            {
                lblChequeNo.Text = "Invoice No";
                lblChequedate.Text = "Invoice Date"; 
            }

            this.LoadEditVoucher();

            btnSave.Attributes.Add("onclick", "return ValidateForm();");
            RowId = -1;
            this.Session.Remove("VoucherNo");
            this.Session.Remove("DistributorId");
            this.Session.Remove("VoucherTypeId");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;

        DataControl dc = new DataControl();
        DataTable dtHead = (DataTable)this.Session["dtHead"];
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        DataRow[] foundRows = dtHead.Select("ACCOUNT_CODE  = '" + txtAccountCode.Text + "'");
        if (foundRows.Length > 0)
        {
            if (RowId >= 0)
            {
                DataRow dr = dtVoucher.Rows[RowId];
                dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                dr["REMARKS"] = txtAccountDes.Text;
                dr["Principal"] = DrpPrincipal.SelectedItem.Text;
                dr["Principal_id"] = DrpPrincipal.SelectedItem.Value;


            }
            else
            {
                DataRow dr = dtVoucher.NewRow();
                dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                dr["REMARKS"] = txtAccountDes.Text;
                dtVoucher.Rows.Add(dr);
                dr["Principal"] = DrpPrincipal.SelectedItem.Text;
                dr["Principal_id"] = DrpPrincipal.SelectedItem.Value;

            }
        }

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        txtTotalDebit.Text = decimal.Round(TotalDebit, 2).ToString();
        txtTotalCredit.Text = decimal.Round(TotalCredit, 2).ToString();

        #endregion

        #region Clear Txtbox

        txtAccountCode.Text = "";
        txtAccountName.Text = "";
        txtDebitAmount.Text = "";
        txtCreditAmount.Text = "";
        RowId = -1;

        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        this.Session.Add("dtVoucher", dtVoucher);
        ScriptManager.GetCurrent(Page).SetFocus(txtAccountCode);


    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        dtVoucher.Rows.RemoveAt(e.RowIndex);

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        txtTotalDebit.Text = decimal.Round(TotalDebit, 2).ToString();
        txtTotalCredit.Text = decimal.Round(TotalCredit, 2).ToString();


        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        RowId = -1;
    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        txtAccountCode.Text = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        txtAccountName.Text = GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        txtAccountDes.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        txtDebitAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        txtCreditAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        DrpPrincipal.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[7].Text;
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;
        dtVoucher = (DataTable)this.Session["dtVoucher"];

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        #endregion

        if (TotalDebit == TotalCredit)
        {
            LedgerController mLController = new LedgerController();
            DataControl dc = new DataControl();
            DateTime ChequeDate;
            DateTime Voucherdate;
            DateTime DueDate;

            Voucherdate = DateTime.Parse(ConvertDate.British_To_American(txtVoucherDate.Text));

            if (txtChequeDate.Text.Length == 10)
            {
                ChequeDate = DateTime.Parse(ConvertDate.British_To_American(txtChequeDate.Text));

            }
            else
            {
                ChequeDate = Constants.DateNullValue;
            }

            if (txtDueDate.Text.Length == 10)
            {
                DueDate = DateTime.Parse(ConvertDate.British_To_American(txtDueDate.Text));

            }
            else
            {
                DueDate = Constants.DateNullValue;
            }

            dtVoucher = (DataTable)this.Session["dtVoucher"];

            string MaxDocumentId = lblVoucherNo.Text;

            bool MResualt  = mLController.Add_Voucher(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), MaxDocumentId, int.Parse(DrpVoucherType.SelectedValue.ToString()),
                   Voucherdate, int.Parse(DrpPaymentMode.SelectedValue.ToString()), txtpayeesName.Text, txtRemarks.Text, ChequeDate, txtChequeNo.Text, dtVoucher, int.Parse(this.Session["UserId"].ToString()), null,DueDate);

            if (MResualt == true)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Updated');", true); 
                Response.Write("<script language='javascript'> { window.close();}</script>");

            }
            else
            { 
               ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some Error Occure');", true); 
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Debit Must Equal To Credit Balance');", true);
        }

    }
    protected void GrdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[6].Text = txtTotalDebit.Text;
            e.Row.Cells[7].Text = txtTotalCredit.Text;
        }
    }
    
}
