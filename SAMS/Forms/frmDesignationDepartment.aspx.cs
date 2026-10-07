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
using SAMSCommon.Classes;
using SAMSBusinessLayer.Classes;  
public partial class Forms_frmDesignationDepartment : System.Web.UI.Page
{
    private static int RefId;
    private void LoadDepoartment()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Depoartment_Id, null, Constants.IntNullValue, bool.Parse("True"));
        grdDepartmentData.DataSource = dt.DefaultView;
        grdDepartmentData.DataBind();
    }
    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Designation_Id, null, Constants.IntNullValue, bool.Parse("True"));
        GrdDesignation.DataSource = dt.DefaultView;
        GrdDesignation.DataBind();
    }
    private void LoadEmployeeType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Type_Id, null, Constants.IntNullValue, bool.Parse("True"));
        GrdType.DataSource = dt.DefaultView;
        GrdType.DataBind();
    }
    private void LoadTreeView()
    {

        AppMaster myMaster;
        TreeView tr;
        Label lblUserId;
        Label lblBrandId;
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
    private string GetAutoCode(string PreeFix, int CodeType, long CValue)
    {
        SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
        return AutoCode.GetAutoCode(PreeFix, CodeType, CValue);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDepoartment();
            this.LoadDesignation();
            this.LoadEmployeeType();
            this.LoadTreeView();
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;
        }   
    }
    protected void btnSaveDepartment_Click(object sender, EventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        if (btnSaveDepartment.Text == "New")
        {
            txtChannelCode.Text = this.GetAutoCode("DP", 0, Constants.LongNullValue);
            txtChannelName.Enabled = true;
            txtChannelName.Focus();
            btnSaveDepartment.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtChannelName);
        }
        else if (btnSaveDepartment.Text == "Save")
        {
            if (txtChannelName.Text.Length == 0)
            {
                lblErrorMsg.Text = "Must Entry Department Name";
                return;
            }
            mController.InsertSlashCodes(txtChannelCode.Text, Constants.Employee_Depoartment_Id, txtChannelName.Text, 1, true);
            this.GetAutoCode("DP", 1, long.Parse(txtChannelCode.Text.Substring(2)));
            this.LoadDepoartment();
            txtChannelCode.Text = "";
            txtChannelName.Text = "";
            txtChannelName.Enabled = false;
            btnSaveDepartment.Text = "New";
            lblErrorMsg.Text = "";
        }
        else if (btnSaveDepartment.Text == "Update")
        {
            mController.UpdateSlashCodes(RefId, null, Constants.Employee_Depoartment_Id, txtChannelName.Text, 1, true, Constants.DateNullValue);
            this.LoadDepoartment();
            txtChannelCode.Text = "";
            txtChannelName.Text = "";
            txtChannelName.Enabled = false;
            btnSaveDepartment.Text = "New";
        }
    }
    protected void grdChannelData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        RefId = int.Parse(grdDepartmentData.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateSlashCodes(RefId, null, Constants.Employee_Depoartment_Id, null, 1, false, Constants.DateNullValue);
        this.LoadDepoartment(); 
    }
    protected void grdChannelData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(grdDepartmentData.Rows[e.NewEditIndex].Cells[0].Text);
        txtChannelCode.Text = grdDepartmentData.Rows[e.NewEditIndex].Cells[1].Text;
        txtChannelName.Text = grdDepartmentData.Rows[e.NewEditIndex].Cells[2].Text;
        btnSaveDepartment.Text = "Update";
        txtChannelName.Enabled = true;
    }
    protected void btnSaveBusType_Click(object sender, EventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        if (btnSaveBusType.Text == "New")
        {
            txtbustypeCode.Text = this.GetAutoCode("DS", 0, Constants.LongNullValue);
            txtbustypeName.Enabled = true;
            txtbustypeName.Focus();
            btnSaveBusType.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtbustypeName);
        }
        else if (btnSaveBusType.Text == "Save")
        {
            if (txtbustypeName.Text.Length == 0)
            {
                lblErrorMsgDivsion.Text = "Must Entry Designation";
                return;
            }
            mController.InsertSlashCodes(txtbustypeCode.Text, Constants.Employee_Designation_Id, txtbustypeName.Text, 1, true);
            this.GetAutoCode("BS", 1, long.Parse(txtbustypeCode.Text.Substring(2)));
            this.LoadDesignation();
            txtbustypeCode.Text = "";
            txtbustypeName.Text = "";
            txtbustypeName.Enabled = false;
            btnSaveBusType.Text = "New";
        }
        else if (btnSaveBusType.Text == "Update")
        {
            mController.UpdateSlashCodes(RefId, null, Constants.Employee_Designation_Id, txtbustypeName.Text, 1, true, Constants.DateNullValue);
            this.LoadDesignation();
            txtbustypeCode.Text = "";
            txtbustypeName.Text = "";
            txtbustypeName.Enabled = false;
            btnSaveBusType.Text = "New";
        }
    }
    protected void GrdBusType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(GrdDesignation.Rows[e.NewEditIndex].Cells[0].Text);
        txtbustypeCode.Text = GrdDesignation.Rows[e.NewEditIndex].Cells[1].Text;
        txtbustypeName.Text = GrdDesignation.Rows[e.NewEditIndex].Cells[2].Text;
        txtbustypeName.Enabled = true;
        btnSaveBusType.Text = "Update";

    }
    protected void GrdBusType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();
        RefId = int.Parse(GrdDesignation.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateSlashCodes(RefId, null, Constants.Employee_Designation_Id, null, 1, false, Constants.DateNullValue);
        this.LoadDesignation();
    }
    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        if (btnSaveCategory.Text == "New")
        {
            txtCategoryCode.Text = this.GetAutoCode("ET", 0, Constants.LongNullValue);
            txtCategoryName.Enabled = true;
            txtCategoryName.Focus();
            btnSaveCategory.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtCategoryName);
        }
        else if (btnSaveCategory.Text == "Save")
        {
            if (txtCategoryName.Text.Length == 0)
            {
                lblErrorMsgCategory.Text = "Must Entry Employee Type";
                return;
            }
            mController.InsertSlashCodes(txtCategoryCode.Text, Constants.Employee_Type_Id, txtCategoryName.Text, 1, true);
            this.GetAutoCode("ET", 1, long.Parse(txtCategoryCode.Text.Substring(2)));
            this.LoadEmployeeType();
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            btnSaveCategory.Text = "New";
        }
        else if (btnSaveCategory.Text == "Update")
        {
            mController.UpdateSlashCodes(RefId, null, Constants.Employee_Type_Id, txtCategoryName.Text, 1, true, Constants.DateNullValue);
            this.LoadEmployeeType();
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            btnSaveCategory.Text = "New";
        }
    }
    protected void GrdVolumeClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();
        RefId = int.Parse(GrdType.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateSlashCodes(RefId, null, Constants.Employee_Type_Id, null, 1, false, Constants.DateNullValue);
        this.LoadEmployeeType();

    }
    protected void GrdVolumeClass_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(GrdType.Rows[e.NewEditIndex].Cells[0].Text);
        txtCategoryCode.Text = GrdType.Rows[e.NewEditIndex].Cells[1].Text;
        txtCategoryName.Text = GrdType.Rows[e.NewEditIndex].Cells[2].Text;
        btnSaveCategory.Text = "Update";
        txtCategoryName.Enabled = true;
    }
}
