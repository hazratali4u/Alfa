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

public partial class Forms_frmTransferIn : System.Web.UI.Page
{

    private void LoadDocumentNo()
    {
        if (DrpDistributor.Items.Count > 0 )
        {
            
            OrderEntryController OR = new OrderEntryController();
            DataControl dc = new DataControl(); 
            DataTable  dt = OR.SelectTranspoterInvoice(int.Parse(DrpDistributor.SelectedValue.ToString()), long.Parse(ListCustomer.SelectedValue.ToString()),1);
            GrdCreditLimit.DataSource = dt;
            GrdCreditLimit.DataBind();
            for(int i = 0;i<GrdCreditLimit.Rows.Count;i++)
            {
                DropDownList DrpTranspoter = (DropDownList)GrdCreditLimit.Rows[i].Cells[0].FindControl("DrpTranspoter");
                TextBox txtDCNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtDCno");
                TextBox txtBiltyNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtBiltyNo");
                TextBox txtExp = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtFreight");

                DataTable dtTranspoter = OR.SelectTranspoter(); 
                clsWebFormUtil.FillDropDownList(DrpTranspoter, dtTranspoter, 0, 1, true);
                if (int.Parse(dc.chkNull_0(dt.Rows[i]["TRANSPOTER_NO"].ToString())) > 0)
                {
                    DrpTranspoter.SelectedValue = dt.Rows[i]["TRANSPOTER_NO"].ToString();
                }
                if (dt.Rows[i]["BILTY_NO"].ToString().Length > 0)
                {
                    txtBiltyNo.Text  = dt.Rows[i]["BILTY_NO"].ToString();
                }
                if (dt.Rows[i]["DELIVERY_CHALLAN_NO"].ToString().Length > 0)
                {
                    txtDCNo.Text = dt.Rows[i]["DELIVERY_CHALLAN_NO"].ToString();
                }
                if (dt.Rows[i]["TOTAL_EXPENCESS"].ToString().Length > 0)
                {
                    txtExp.Text = dt.Rows[i]["TOTAL_EXPENCESS"].ToString();
                }
            }  
        }
    }
    private void LoadCustomer()
    {
        if (DrpDistributor.Items.Count > 0)
        {
            OrderEntryController OR = new OrderEntryController();
            DataTable dt = OR.SelectTranspoterInvoice(int.Parse(DrpDistributor.SelectedValue.ToString()),Constants.LongNullValue,0);
            clsWebFormUtil.FillListBox(this.ListCustomer, dt, "SOLD_TO", "CUSTOMER");   
        }
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpDistributor, dt, 0, 2, true);
    }
    private void LoadTreeView()
    {
        //AppMaster myMaster;
        //TreeView tr;
        //Label lblUserId;
        //myMaster = (AppMaster)this.Master;
        //tr = myMaster.FindControl("tr") as TreeView;
        //lblUserId = myMaster.FindControl("Label1") as Label;
        //lblUserId.Text = this.Session["UserName"].ToString();  
        //tr.Nodes.Clear();
        //TreeNode trMaster = (TreeNode)this.Session["trMaster"];
        //tr.Nodes.Add(trMaster);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadCustomer(); 
            //this.LoadDocumentNo();
            //this.LoadTreeView();
            //AppMaster master = new AppMaster();
            //master = (AppMaster)this.Master;
            //Panel panel = new Panel();
            //panel = master.FindControl("searchpanel") as Panel;
            //panel.Visible = true;
        }
    }
   
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer(); 
        //this.LoadDocumentNo();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GrdCreditLimit.Rows.Count; i++)
        {
            DropDownList DrpTranspoter = (DropDownList)GrdCreditLimit.Rows[i].Cells[0].FindControl("DrpTranspoter");
            TextBox txtDCNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtDCno");
            TextBox txtBiltyNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtBiltyNo");
            TextBox txtExp = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtFreight");

            if (txtBiltyNo.Text.Length > 0)
            {
                OrderEntryController or = new OrderEntryController();
                or.PostTranspoterExp(int.Parse(DrpDistributor.SelectedValue.ToString()), long.Parse(GrdCreditLimit.Rows[i].Cells[0].Text), int.Parse(DrpTranspoter.SelectedValue.ToString()), txtBiltyNo.Text, txtDCNo.Text, decimal.Parse(txtExp.Text));                   
            }
        }
    }
    protected void ListCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDocumentNo();
    }
}
