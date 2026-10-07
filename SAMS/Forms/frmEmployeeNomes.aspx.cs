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

public partial class Forms_frmEmployeeNomes : System.Web.UI.Page
{
    private void LoadEmployeeRoles()
    {
        EmployeController eController = new EmployeController();
        DataTable dt = eController.SelectEmployeerole();
        clsWebFormUtil.FillDropDownList(DrpEmployeeGroup, dt, 0, 1, true);
    }
    private void LoadEmployeeNomes()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Norms_Id, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(DrpEmployeeNoams , dt, 0, 2, true);
    }
    private void LoadEmployeeNormsDetail()
    {
        EmployeController eController = new EmployeController();
        if (DrpEmployeeGroup.Items.Count > 0)
        {
            DataTable dt = eController.SelectEmployeeNormsDetail(int.Parse(DrpEmployeeGroup.SelectedValue.ToString()));
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
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
            this.LoadEmployeeRoles();
            this.LoadEmployeeNomes();
            this.LoadEmployeeNormsDetail();
            this.LoadTreeView();
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        EmployeController eController = new EmployeController();
        eController.InsertEmployeeNorms(int.Parse(DrpEmployeeGroup.SelectedValue.ToString()), int.Parse(DrpEmployeeNoams.SelectedValue.ToString()), ChbIsTaxable.Checked, decimal.Parse(txtAmount.Text));
        this.LoadEmployeeNormsDetail();
        txtAmount.Text = "";
        ChbIsTaxable.Checked = false;
         
    }
    protected void btnRole_Click(object sender, EventArgs e)
    {
        if (btnRole.Text == "New")
        {
            DrpEmployeeGroup.Visible = false;
            txtEmpGroup.Visible = true;
            ScriptManager.GetCurrent(Page).SetFocus(txtEmpGroup);
            btnRole.Text = "Save"; 
        }
        else
        {
            EmployeController eController = new EmployeController();
            eController.InsertEmployeerole(txtEmpGroup.Text);
            this.LoadEmployeeRoles();
            DrpEmployeeGroup.Visible = true;
            txtEmpGroup.Visible = false;
            txtEmpGroup.Text = ""; 
            btnRole.Text = "New";
    
        }
    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EmployeController eController = new EmployeController();
        eController.DeleteEmployeerole(int.Parse(DrpEmployeeGroup.SelectedValue.ToString()), int.Parse(GrdOrder.Rows[e.RowIndex].Cells[2].Text));
        this.LoadEmployeeNormsDetail();
    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DrpEmployeeNoams.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        txtAmount.Text   = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        ChbIsTaxable.Checked  = bool.Parse(GrdOrder.Rows[e.NewEditIndex].Cells[4].Text);
    }
    protected void btnnoams_Click(object sender, EventArgs e)
    {
        if (btnnoams.Text == "New")
        {
            DrpEmployeeNoams.Visible = false;
            txtnoams.Visible = true;
            ScriptManager.GetCurrent(Page).SetFocus(txtnoams);
            btnnoams.Text = "Save";
        }
        else
        {
            SLASHCodesController mController = new SLASHCodesController();
            mController.InsertSlashCodes("N/A", Constants.Employee_Norms_Id, txtnoams.Text, 1, true);
            this.LoadEmployeeNomes();
            DrpEmployeeNoams.Visible = true;
            txtnoams.Visible = false;
            txtnoams.Text = "";
            btnnoams.Text = "New";

        }
    }
    protected void DrpEmployeeGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadEmployeeNormsDetail(); 
    }
}
