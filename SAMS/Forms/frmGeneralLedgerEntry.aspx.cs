using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;
    
public partial class Forms_frmGeneralLedgerEntry : System.Web.UI.Page
{
    DataTable dtVoucher;
    private static int RowId;
    private void LoadAccountHead()
    {
        SAMSCommon.Classes.Configuration.GetAccountHead();
        if (DrpVoucherType.SelectedIndex == 0)
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMSCommon.Classes.Configuration.CashDefaultType));
            clsWebFormUtil.FillDropDownList(drpBanks, dt, 0, 4, true);
        }
        else if (DrpVoucherType.SelectedIndex == 1)
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMSCommon.Classes.Configuration.BankDefaultType));
            clsWebFormUtil.FillDropDownList(drpBanks, dt, 0, 4, true);
        }
        else
        {
            drpBanks.Items.Clear();
            drpBanks.Items.Add(new ListItem("N/A", Constants.IntNullValue.ToString()));        
        }
    }
    private void CreatTable()
    {
        dtVoucher = new DataTable();
        dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
        dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        dtVoucher.Columns.Add("Account_Code", typeof(string));
        dtVoucher.Columns.Add("Account_Name", typeof(string));
        dtVoucher.Columns.Add("Debit", typeof(decimal));
        dtVoucher.Columns.Add("Credit", typeof(decimal));
        dtVoucher.Columns.Add("Remarks", typeof(string));
        dtVoucher.Columns.Add("InvoiceNo", typeof(string));
        this.Session.Add("dtVoucher", dtVoucher);

    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Entry",Constants.IntNullValue.ToString()));       
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadTreeView()
    {

        AppMaster myMaster;
        TreeView tr;
        Label lblUserId;
        Label lblCurrentWorkDate;

        myMaster = (AppMaster)this.Master;
        tr = myMaster.FindControl("tr") as TreeView;
        lblUserId = myMaster.FindControl("Label1") as Label;
        lblUserId.Text = this.Session["UserName"].ToString();
        lblCurrentWorkDate = myMaster.FindControl("lblCurrentWorkDate") as Label;
        lblCurrentWorkDate.Text = "Working Date " + ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy"); 

        tr.Nodes.Clear();
        TreeNode trMaster = (TreeNode)this.Session["trMaster"];
        tr.Nodes.Add(trMaster);
        tr.CollapseAll();
        if (Session["TreeViewState"] == null)
        {
            // Record the TreeView's current expand/collapse state.
            Dictionary<string, bool> SelectedNode = new Dictionary<string, bool>();
            SaveTreeViewState(tr.Nodes, SelectedNode);
            Session["TreeViewState"] = SelectedNode;
        }
        else
        {
            // Apply the recorded expand/collapse state to the TreeView.
            Dictionary<string, bool> SelectedNode = (Dictionary<string, bool>)Session["TreeViewState"];
            RestoreTreeViewState(tr.Nodes, SelectedNode);
        }
    }
    private void SaveTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        // Recursivley record all expanded nodes in the List.
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                if (node.Expanded.HasValue && node.Expanded == true && !String.IsNullOrEmpty(node.Text))
                    SelectedNode.Add(node.Text, true);
                else
                    SelectedNode.Add(node.Text, false);
                SaveTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
    private void RestoreTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        foreach (TreeNode node in nodes)
        {
            if (Session["SelectedNode"].ToString() == node.ValuePath)
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry_down.gif";
                node.Selected = true;
            }
            else
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry.gif";
            }

            // Restore the state of one node.
            foreach (KeyValuePair<string, bool> pair in SelectedNode)
            {
                if (pair.Key == node.Text && pair.Value == true)
                {
                    node.Expand();
                }
                else if (pair.Key == node.Text && pair.Value == false)
                {
                    node.Collapse();
                }
                if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                    RestoreTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2,true);
    }
    private void LoadAccountDetail()
    {
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId,Constants.LongNullValue);
        clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
        this.Session.Add("dtHead", dtHead);   
        
    }
    private void ClearAll()
    {
        txtTotalCredit.Text = "0";
        txtTotalDebit.Text = "0";
        txtRemarks.Text = "";
        txtAccountCode.Text = "";
        txtAccountName.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = ""; 
        txtDebitAmount.Text = "";
        txtCreditAmount.Text = "";
        GrdOrder.DataSource = null;
        GrdOrder.DataBind();
        this.Session.Remove("dtVoucher");
        this.CreatTable();
        btnDone.Text = "Save";
        txtpayeesName.Text = "";
        drpDistributor.Enabled = true;
        DrpVoucherType.Enabled = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountDetail();
            this.LoadPrincipal(); 
            this.LoadTreeView();
            this.CreatTable();
            this.LoadAccountHead();
            txtVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy") ;
            txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnddate.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            btnSave.Attributes.Add("onclick", "return ValidateForm();");
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;
        }
    }
    protected void DrpAccountDetailType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAccountDetail(); 
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
            if (btnSave.Text == "Add")
            {
                DataRow dr = dtVoucher.NewRow();
                dr["Ledger_ID"] = Constants.LongNullValue.ToString();   
                dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                dr["REMARKS"] = txtRemarks.Text;
                dtVoucher.Rows.Add(dr);
                
            }
            else
            {
                DataRow dr = dtVoucher.Rows[RowId];
                dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                dr["REMARKS"] = txtRemarks.Text;
                
            }
        }
        
        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit  += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());     
        }
        txtTotalDebit.Text = decimal.Round(TotalDebit,0).ToString();
        txtTotalCredit.Text = decimal.Round(TotalCredit,0).ToString();

        #endregion

        #region Clear Txtbox
        
        txtAccountCode.Text = "";
        txtAccountName.Text = "";
        txtDebitAmount.Text = "";
        txtCreditAmount.Text = "";
        btnSave.Text = "Add"; 

        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        this.Session.Add("dtVoucher", dtVoucher);
        ScriptManager.GetCurrent(Page).SetFocus(txtAccountCode);
    }
    protected void GrdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = txtTotalDebit.Text;
            e.Row.Cells[4].Text = txtTotalCredit.Text;  
        }
        
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        LedgerController mLController = new LedgerController();
        DataControl dc = new DataControl(); 
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        DataTable dtHead = (DataTable)this.Session["dtHead"];

          

        if(drpBanks.Items.Count > 0 )
        {
            decimal TotalDebit = 0;
            decimal TotalCredit = 0;

                #region Set Total

                    foreach (DataRow dr in dtVoucher.Rows)
                    {
                        TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                        TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
                    } 
                #endregion

            decimal differnceAmt = TotalDebit - TotalCredit;

            if(differnceAmt > 0)
            {
                DataRow dr1 = dtVoucher.NewRow();
                DataRow[] foundSubRows = dtHead.Select("ACCOUNT_HEAD_ID  = " + drpBanks.SelectedValue.ToString());
                dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                dr1["ACCOUNT_HEAD_ID"] = foundSubRows[0]["ACCOUNT_HEAD_ID"];
                dr1["ACCOUNT_CODE"] = foundSubRows[0]["ACCOUNT_CODE"];
                dr1["ACCOUNT_NAME"] = foundSubRows[0]["ACCOUNT_NAME"];
                dr1["REMARKS"] = txtRemarks.Text;
                dr1["CREDIT"] = differnceAmt;
                dr1["DEBIT"] = 0;
                dtVoucher.Rows.Add(dr1);
                           
            }
            else if(differnceAmt < 0)
            {
                DataRow dr1 = dtVoucher.NewRow();
                DataRow[] foundSubRows = dtHead.Select("ACCOUNT_HEAD_ID  = " + drpBanks.SelectedValue.ToString());
                dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                dr1["ACCOUNT_HEAD_ID"] = foundSubRows[0]["ACCOUNT_HEAD_ID"];
                dr1["ACCOUNT_CODE"] = foundSubRows[0]["ACCOUNT_CODE"];
                dr1["ACCOUNT_NAME"] = foundSubRows[0]["ACCOUNT_NAME"];
                dr1["REMARKS"] = txtRemarks.Text;
                dr1["CREDIT"] = 0;
                dr1["DEBIT"] = -(differnceAmt);
                dtVoucher.Rows.Add(dr1);
            }
        }     
         
            DateTime ChequeDate;
            string Voucherdate;
            if (txtVoucherDate.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter Voucher Date');", true);
                return;
            }
            else
            {
                Voucherdate = ConvertDate.British_To_American(txtVoucherDate.Text);
            }

            if (txtChequeDate.Text.Length == 10)
            {
                ChequeDate = DateTime.Parse(ConvertDate.British_To_American(txtChequeDate.Text));

            }
            else
            {
                ChequeDate = Constants.DateNullValue;  
            }
            dtVoucher = (DataTable)this.Session["dtVoucher"];
            
            string  MaxDocumentId = mLController.SelectLedgerMaxDocumentId(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()));
            
            foreach (DataRow dr in dtVoucher.Rows)
            {
                mLController.PostingCash_Bank_Account(int.Parse(DrpVoucherType.SelectedValue.ToString()),long.Parse(MaxDocumentId),
                long.Parse(dr["Account_Head_id"].ToString()),int.Parse(drpDistributor.SelectedValue.ToString()),
                decimal.Parse(dr["Debit"].ToString()), decimal.Parse(dr["Credit"].ToString()),DateTime.Parse(Voucherdate),
                txtRemarks.Text,DateTime.Now, Constants.IntNullValue, int.Parse(DrpPrincipal.SelectedValue.ToString()),
                txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dc.chkNull_0(dr["InvoiceNo"].ToString())),null, Constants.IntNullValue, null,ChequeDate,int.Parse(DrpPaymentMode.SelectedValue.ToString()),txtpayeesName.Text);
            }
            this.ClearAll();
            
        }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        txtAccountCode.Text = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        txtAccountName.Text = GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        txtDebitAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        txtCreditAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[4].Text;
        btnSave.Text = "Update"; 
              
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
        txtTotalDebit.Text = TotalDebit.ToString();
        txtTotalCredit.Text = TotalCredit.ToString();

        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
    }
    protected void DrpVoucherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearAll(); 
        this.LoadAccountHead();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
         DateTime fromDate;
         DateTime toDate;
            if (txtStartDate.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter Start Date');", true);
                return;
            }
            else
            {
                fromDate = DateTime.Parse(ConvertDate.British_To_American(txtStartDate.Text));
            }
            if (txtEnddate.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter End Date');", true);
                return;
            }
            else
            {
                toDate = DateTime.Parse(ConvertDate.British_To_American(txtEnddate.Text));
            }
            
        LedgerController mController = new LedgerController();
        DataTable dt  =  mController.SelectPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), fromDate, toDate, Constants.LongNullValue);
        GrdPendingInvoice.DataSource = dt;
        GrdPendingInvoice.DataBind();  
    }
    protected void btnAddVoucher_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;

        DataControl dc = new DataControl();
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        foreach (GridViewRow dr1 in GrdPendingInvoice.Rows)
        {
            CheckBox ChbInvoice = (CheckBox)dr1.FindControl("ChbInvoice");
            if (ChbInvoice.Checked == true)
            {
               
                DataTable dtHead = (DataTable)this.Session["dtHead"];
                DataRow[] foundRows = dtHead.Select("ACCOUNT_HEAD_ID  = 88");
                if (foundRows.Length > 0)
                {
                    DataRow dr = dtVoucher.NewRow();
                    dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                    dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                    dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                    dr["DEBIT"] = Decimal.Parse(dr1.Cells[4].Text);
                    dr["CREDIT"] = 0;
                    dr["REMARKS"] = txtRemarks.Text;
                    dr["InvoiceNo"] = dr1.Cells[1].Text;
                    dtVoucher.Rows.Add(dr);
                }
            }

        }

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        txtTotalDebit.Text = decimal.Round(TotalDebit, 0).ToString();
        txtTotalCredit.Text = decimal.Round(TotalCredit, 0).ToString();

        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        this.Session.Add("dtVoucher", dtVoucher);
        ScriptManager.GetCurrent(Page).SetFocus(txtAccountCode);

     }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DateTime fromDate;
        DateTime toDate;
        if (txtStartDate.Text.Length < 10)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter Start Date');", true);
            return;
        }
        else
        {
            fromDate = DateTime.Parse(ConvertDate.British_To_American(txtStartDate.Text));
        }
        if (txtEnddate.Text.Length < 10)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter End Date');", true);
            return;
        }
        else
        {
            toDate = DateTime.Parse(ConvertDate.British_To_American(txtEnddate.Text ));
        }

        LedgerController mController = new LedgerController();
        DataTable dt = mController.SelectPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), fromDate, toDate, Constants.LongNullValue);
        GrdPendingInvoice.DataSource = dt;
        GrdPendingInvoice.DataBind();
        Panel2.Visible = true;
    }
}
