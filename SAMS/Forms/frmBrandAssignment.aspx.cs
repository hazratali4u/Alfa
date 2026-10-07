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

public partial class Forms_frmBrandAssignment : System.Web.UI.Page
{
    
    private void LoadUser()
    {
        UserController mUserController = new UserController();
        DataTable dt = mUserController.SelectSlashUser(null, null); 
        clsWebFormUtil.FillDropDownList(ddRole, dt, 0, 4, true);
    }
    private void UnAssignBrand()
    {
       
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectBrandAssignment(0, int.Parse(ddRole.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(lstUnAssignBrand, dt, 0, 1, true);
        
    }
    private void AssignBrand()
    {
        
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectBrandAssignment(1, int.Parse(ddRole.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(lstAssignBrand, dt, 0, 1, true);
            
            DataTable dtAssignBrand = sController.GetBrandAssignment(Convert.ToInt32(ddRole.SelectedValue));
            if (dtAssignBrand.Rows.Count > 0)
            {
                for (int i = 0; i < lstAssignBrand.Items.Count; i++)
                {
                    for (int j = 0; j < dtAssignBrand.Rows.Count; j++)
                    {
                        if (lstAssignBrand.Items[i].Value == dtAssignBrand.Rows[j]["PRINCIPAL_ID"].ToString() && dtAssignBrand.Rows[j]["Is_ManualDiscount"].ToString() == "True")
                        {
                            lstAssignBrand.Items[i].Selected = true;
                            break;
                        }
                    }
                }
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
            this.LoadUser(); 
            this.UnAssignBrand();
            this.AssignBrand();

            this.LoadTreeView();
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;

        }
    }
    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstUnAssignBrand.Items.Count; i++)
        {
            if (lstUnAssignBrand.Items[i].Selected == true && ddRole.Items.Count > 0)
            {
                sController.InsertAssignBrand(int.Parse(lstUnAssignBrand.SelectedValue.ToString()), int.Parse(ddRole.SelectedValue.ToString()));           
            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstUnAssignBrand.Items.Count; i++)
        {
            if (ddRole.Items.Count > 0)
            {
                sController.InsertAssignBrand(int.Parse(lstUnAssignBrand.Items[i].Value.ToString()),int.Parse(ddRole.SelectedValue.ToString()));           
                    
            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (ddRole.Items.Count > 0)
            {
                sController.DeleteAssignBrand(int.Parse(lstAssignBrand.Items[i].Value.ToString()), int.Parse(ddRole.SelectedValue.ToString()));

            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (lstAssignBrand.Items[i].Selected == true && ddRole.Items.Count > 0)
            {
                sController.DeleteAssignBrand(int.Parse(lstAssignBrand.Items[i].Value.ToString()), int.Parse(ddRole.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (ddRole.Items.Count > 0)
            {
                sController.UpdateBrandAssignment(int.Parse(ddRole.SelectedValue.ToString()), int.Parse(lstAssignBrand.Items[i].Value), lstAssignBrand.Items[i].Selected);
            }
        }
    }
}
