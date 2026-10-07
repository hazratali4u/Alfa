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
public partial class Forms_frmLeaveSignature : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, 0, 2, true);
    }
    private void LoadEmployee()
    {
        EmployeController mController = new EmployeController();
        DataTable dt = mController.SelectEmployeebyLocation(int.Parse(DrpLocation.SelectedValue.ToString()), int.Parse(DrpDesignation.SelectedValue.ToString()), true);
        clsWebFormUtil.FillDropDownList(this.DrpEmployee, dt, 0, 2, true);
    }
    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Designation_Id, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(this.DrpDesignation, dt, 0, 2, true);

    }
    private void LoadGrid()
    {
        if (DrpEmployee.Items.Count > 0)
        {
            EmployeController Emp = new EmployeController();
            DataTable dt = Emp.SelectEmployeeLeaveDetail(int.Parse(DrpEmployee.SelectedValue.ToString()), RadioButtonList1.SelectedIndex, DateTime.Parse(txtFromdate.Text), DateTime.Parse(txttoDate.Text));
            this.GrdLedger.DataSource = dt;
            this.GrdLedger.DataBind();
        }
        else
        {
            this.GrdLedger.DataSource = null;
            GrdLedger.DataBind();
        }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadDesignation();
            this.LoadEmployee();
            this.LoadTreeView();
            
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;

            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtFromdate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txttoDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.LoadGrid();
        }
    }
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadEmployee();
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        EmployeController mController = new EmployeController(); 

        foreach (GridViewRow dr in GrdLedger.Rows)
        {
            CheckBox ChbSelect = (CheckBox)dr.Cells[1].FindControl("ChbSelect");
            if (ChbSelect.Checked == true)
            {
                mController.UpdateEmployeeLeave(long.Parse(dr.Cells[0].Text), true);     
            }
        }
        this.LoadGrid(); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.LoadGrid(); 
    }
    protected void DrpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadEmployee(); 
    }
    protected void DrpEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
