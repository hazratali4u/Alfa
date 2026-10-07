using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes; 
   
public partial class frmGeoHierarchy : System.Web.UI.Page
{
    #region Private Variable

    GeoHierarchyController gController = new GeoHierarchyController();
    RoleManagementController mController = new RoleManagementController();
    DataControl dc = new DataControl();
    static int Idx;

    #endregion

    #region Private Method
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
    protected void LoadRegion()
    {
        DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, false, Constants.IntNullValue, Constants.Region, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        dt.DefaultView.Sort = "GEO_ID";
        ddRegion.DataSource = dt.DefaultView;
        ddRegion.DataTextField = "GEO_NAME";
        ddRegion.DataValueField = "GEO_ID";
        ddRegion.DataBind();
    }
    protected void LoadZone()
    {
        if (ddRegion.Items.Count > 0)
        {
            DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(ddRegion.SelectedValue.ToString()), null, null, false, Constants.IntNullValue, Constants.Zone, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            ddZone.DataSource = dt;
            ddZone.DataTextField = "GEO_NAME";
            ddZone.DataValueField = "GEO_ID";
            ddZone.DataBind();
        }
    }
    protected void LoadTerritory()
    {
        if (ddZone.Items.Count > 0)
        {
            DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(ddZone.SelectedValue.ToString()), null, null, false, Constants.IntNullValue, Constants.Territory, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            ddTerritory.DataSource = dt;
            ddTerritory.DataTextField = "GEO_NAME";
            ddTerritory.DataValueField = "GEO_ID";
            ddTerritory.DataBind();
        }
        else
        {
            this.ddTerritory.Items.Clear();
        }
    }
    private void LoadData()
    {
        DataTable dtGeo = gController.SelectGeoHierarchyData(int.Parse(this.Session["CompanyId"].ToString()), 1);
        this.Session.Add("dtGeo", dtGeo);  
    }
    protected void LoadGrid()
    {
        DataTable  dtGeo = (DataTable)this.Session["dtGeo"];

        switch (ddSearchType.SelectedIndex)
        {

            case 1:
                dtGeo.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 2:
                dtGeo.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 3:
                dtGeo.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
                    
            default:
                 dtGeo.DefaultView.RowFilter = "town_name" + " like '%" + "" + "%'";
                break;
        }
        Grid_Hierarchy.DataSource = dtGeo.DefaultView ;
        Grid_Hierarchy.DataBind();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            this.LoadTreeView();
            LoadRegion();
            LoadZone();
            LoadTerritory();
            LoadData();
            LoadGrid();
            btnRegion.Attributes.Add("onclick", "return ValidatRegion()");
            btnZone.Attributes.Add("onclick", "return ValidatZone()");
            btnTerritory.Attributes.Add("onclick", "return ValidateTerritory()");
            btnSave.Attributes.Add("onclick", "return ValidateTown()");

            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;
        }
    }
 
    protected void btnRegion_Click(object sender, EventArgs e)
    {
        if (btnRegion.Text == "New Region" || btnRegion.Text == "Save")
        {
            if (this.btnRegion.Text == "New Region")
            {
                this.ddRegion.Visible = false;
                this.txtRegion.Visible = true;
                this.btnRegion.Text = "Save";
                this.btnZone.Enabled = false;
                this.btnTerritory.Enabled = false;
                this.btnSave.Enabled = false;  
                this.txtRegion.Focus();
                this.txtRegion.Text = "";
                ScriptManager.GetCurrent(Page).SetFocus(txtRegion);  
            }
            else
            {
                if (this.txtRegion.Text == "")
                {
                    lblErrorMsg.Text = "Enter Region";
                    txtRegion.Focus();                      
                }
                else
                {

                    string InsertValue = gController.InsertHierarchy(Constants.IntNullValue, "N/A", txtRegion.Text, true, false, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Region, int.Parse(this.Session["UserId"].ToString()), SAMSCommon.Classes.Configuration.DistributorId, null);                
                    this.lblErrorMsg.Text = InsertValue;
                    this.StartState();  
                    LoadRegion();
                }
            }
        }
        else
        {
            if (btnRegion.Text == "Update")
            {
                gController.UpdateHierarchy(int.Parse(ddRegion.SelectedValue.ToString()),Constants.IntNullValue, "NA", txtRegion.Text , true, false,Constants.IntNullValue,int.Parse(this.Session["CompanyId"].ToString()),Constants.Region, int.Parse(this.Session["UserId"].ToString()),SAMSCommon.Classes.Configuration.DistributorId,null);

                this.StartState();  
                LoadRegion();
                LoadGrid();
                ddRegion.SelectedIndex = Idx; 
                return;
            }
            if (btnRegion.Text == "Edit")
            {
                Idx = ddRegion.SelectedIndex;  
                txtRegion.Text = ddRegion.SelectedItem.Text;     
                ddRegion.Visible = false;
                txtRegion.Visible = true;
                btnRegion.Text = "Update";
                this.btnZone.Enabled = false;
                this.btnTerritory.Enabled = false;
                this.btnSave.Enabled = false;  
                
            }
        }
    }
    protected void btnZone_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        if (btnZone.Text == "New Zone" || btnZone.Text == "Save")
        {
            if (this.btnZone.Text == "New Zone")
            {
                this.ddZone.Visible = false;
                this.txtZone.Visible = true;
                this.btnRegion.Enabled = false;
                this.btnTerritory.Enabled = false;
                this.btnSave.Enabled = false;  
                this.btnZone.Text = "Save";
                this.txtZone.Text = ""; 
                this.txtZone.Focus();
                ScriptManager.GetCurrent(Page).SetFocus(txtZone);  
            }
            else
            {
                if (ddRegion.Items.Count > 0)
                {
                    if (txtZone.Text == "")
                    {
                        lblErrorMsg.Text = "Enter Zone";
                                                
                    }
                    else
                    {
                        string InsertValue = gController.InsertHierarchy(int.Parse(ddRegion.SelectedValue.ToString()), "N/A", txtZone.Text, true, false, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Zone, int.Parse(this.Session["UserId"].ToString()), SAMSCommon.Classes.Configuration.DistributorId, null);
                        this.StartState();
                        this.LoadZone();
                    }
                }
            }
        }
        else
        {
            if (this.btnZone.Text == "Update")
            {
                string ID = (string)ViewState["Zone_ID"];
                gController.UpdateHierarchy(Convert.ToInt32(ddZone.SelectedValue.ToString()),int.Parse(ddRegion.SelectedValue.ToString()),"NA",txtZone.Text, true, false,Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()),Constants.Zone, int.Parse(this.Session["UserId"].ToString()),SAMSCommon.Classes.Configuration.DistributorId,null);
                this.StartState(); 
                this.LoadZone();
                this.LoadGrid();
                return;
            }
            if (this.btnZone.Text == "Edit")
            {
                txtZone.Text = ddZone.SelectedItem.Text; 
                this.ddZone.Visible = false;
                this.txtZone.Visible = true;
                this.btnZone.Text = "Update";
                this.btnRegion.Enabled = false;
                this.btnTerritory.Enabled = false;
                this.btnSave.Enabled = false;  
            }
        }
    }
    protected void ddRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadZone();
        LoadTerritory();
    }
    protected void btnTerritory_Click(object sender, EventArgs e)
    {
        if (btnTerritory.Text == "New Territory" || btnTerritory.Text == "Save")
        {
            if (this.btnTerritory.Text == "New Territory")
            {
                this.ddTerritory.Visible = false;
                this.txtterritory.Visible = true;
                this.btnTerritory.Text = "Save";
                this.btnRegion.Enabled = false;
                this.btnZone.Enabled = false;
                this.btnSave.Enabled = false;
                this.txtterritory.Text = ""; 
                this.txtterritory.Focus();
                ScriptManager.GetCurrent(Page).SetFocus(txtterritory);
            }
            else
            {
                //if (int.Parse(dc.chkNull_0(this.ddRegion.SelectedValue.ToString())) > 0)
                if (ddZone.Items.Count > 0)
                {
                    if (txtterritory.Text == "")
                    {
                        lblErrorMsg.Text = "Enter Territory";
                                                
                    }
                    else
                    {
                        string InsertValue = gController.InsertHierarchy(int.Parse(ddZone.SelectedValue.ToString()), "N/A", txtterritory.Text, true, false, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Territory, int.Parse(this.Session["UserId"].ToString()), SAMSCommon.Classes.Configuration.DistributorId, null);
                        this.StartState(); 
                        LoadTerritory();
                    }
                }
            }
        }
        else
        {
            if (this.btnTerritory.Text == "Update")
            {
                string ID = (string)ViewState["Territory_ID"];
                gController.UpdateHierarchy(Convert.ToInt32(ddTerritory.SelectedValue.ToString()), int.Parse(ddZone.SelectedValue.ToString()), "NA", txtterritory.Text, true, false, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Territory, int.Parse(this.Session["UserId"].ToString()), SAMSCommon.Classes.Configuration.DistributorId, null);
                this.LoadTerritory();
                this.LoadGrid();
                this.StartState(); 
                return;
            }
            if (this.btnTerritory.Text == "Edit")
            {
                this.txtterritory.Text = ddTerritory.SelectedItem.Text;  
                this.ddTerritory.Visible = false;
                this.txtterritory.Visible = true;
                this.btnRegion.Enabled = false;
                this.btnZone.Enabled = false;
                this.btnSave.Enabled = false;  
                this.btnTerritory.Text = "Update";
            }
        }
    }
    protected void ddZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTerritory();
        
    }
    protected void ddTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadTown();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
          if (btnSave.Text == "Save Town")
            {
                if (txtRoute.Text == "")
                {
                    lblErrorMsg.Text = "Enter Town";
                }
                else
                {
                    string InsertValue = gController.InsertHierarchy(int.Parse(ddTerritory.SelectedValue.ToString()), "N/A", txtRoute.Text, true, false, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Town, Constants.IntNullValue, SAMSCommon.Classes.Configuration.DistributorId, null);                
                    this.lblErrorMsg.Text = "";
                    txtRoute.Text = null;
                }
            }
            else
            {
                string ID = (string)ViewState["Town_ID"];
                gController.UpdateHierarchy(Convert.ToInt32(ID), int.Parse(ddTerritory.SelectedValue.ToString()), "NA", txtRoute.Text, true, false, Constants.IntNullValue,int.Parse(this.Session["CompanyId"].ToString()), Constants.Town, Constants.IntNullValue,SAMSCommon.Classes.Configuration.DistributorId, null);
               
            }
        
        System.Threading.Thread.Sleep(500);
        StartState();
        LoadData();
        LoadGrid();
    }
    protected void Grid_Brand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Grid_Hierarchy.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void Grid_Hierarchy_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow gvr = this.Grid_Hierarchy.Rows[e.NewEditIndex];
      
        
        for (int i = 0; i < this.ddRegion.Items.Count; i++)
        {
            if (this.ddRegion.Items[i].Value == gvr.Cells[0].Text)
            {
                this.ddRegion.SelectedIndex = i;
                break;
            }
        }
        LoadZone();
        for (int i = 0; i < this.ddZone.Items.Count; i++)
        {
            if (this.ddZone.Items[i].Value == gvr.Cells[2].Text)
            {
                this.ddZone.SelectedIndex = i;
                break;
            }
        }
        LoadTerritory();
        for (int i = 0; i < this.ddTerritory.Items.Count; i++)
        {
            if (this.ddTerritory.Items[i].Value == gvr.Cells[4].Text)
            {
                this.ddTerritory.SelectedIndex = i;
                break;
            }
        }

        btnRegion.Text = "Edit";
        txtRegion.Text = gvr.Cells[1].Text;
        btnZone.Text = "Edit";
        txtZone.Text = gvr.Cells[3].Text;
        btnTerritory.Text = "Edit";
        txtterritory.Text = gvr.Cells[5].Text;
        txtRoute.Text = gvr.Cells[7].Text;
        if (gvr.Cells[8].Text == "True")
        {
            IsActive.Checked = true;
        }
        else
        {
            IsActive.Checked = false;
        }
        btnSave.Text = "Update";

        ViewState["Zone_ID"] = gvr.Cells[2].Text;
        ViewState["Territory_ID"] = gvr.Cells[4].Text;
        ViewState["Town_ID"] = gvr.Cells[6].Text;
       
    }
    protected void StartState()
    {

        btnRegion.Text = "New Region";
        btnZone.Text = "New Zone";
        btnTerritory.Text = "New Territory";
        btnSave.Text = "Save Town";

        ddRegion.Visible = true;
        txtRegion.Visible = false;
        ddZone.Visible = true;
        txtZone.Visible = false;
        ddTerritory.Visible = true;
        txtterritory.Visible = false;
        
        btnZone.Enabled = true;
        btnTerritory.Enabled = true;
        btnSave.Enabled = true;
        btnRegion.Enabled = true;
        
        txtRoute.Text = null;
        txtRegion.Text = null;
        txtZone.Text = null;
        txtterritory.Text = null;
        
        lblErrorMsg.Text = "";

    }

    protected void Grid_Hierarchy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID  = Grid_Hierarchy.Rows[e.RowIndex].Cells[6].Text;
        gController.UpdateHierarchy(Convert.ToInt32(ID),Constants.IntNullValue,null,null,true,true, Constants.IntNullValue, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, SAMSCommon.Classes.Configuration.DistributorId, null);
        this.LoadData(); 
        this.LoadGrid(); 
    }
    protected void Grid_Hierarchy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
                  
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        StartState();
        this.LoadGrid(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.StartState();     
    }
}
