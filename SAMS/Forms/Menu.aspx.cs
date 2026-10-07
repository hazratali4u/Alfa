using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class Forms_Menu : System.Web.UI.Page
{
    MenuController MenuCtl = new MenuController();
    RoleManagementController ObjRole = new RoleManagementController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["mode"] != null)
            {
                DataTable dtLevel = MenuCtl.GetMenuLevel(Convert.ToInt32(Request.QueryString["LevelID"]), Constants.IntNullValue, Constants.IntNullValue);
                if (dtLevel.Rows.Count > 0)
                {
                    txtMenu.Text = dtLevel.Rows[0]["MODULE_DESCRIPTION"].ToString();
                    hfModuleID.Value = dtLevel.Rows[0]["MODULE_ID"].ToString();
                    lblTitle.Text = "Edit Level";
                }

                if (Request.QueryString["LevelType"].ToString() == "2")
                {
                    //Load Main Grid
                    this.gvMain.Visible = true;
                    lblFormTitle.Visible = true;
                    int RoleID = (int)Session["RoleID"];
                    LoadMainMenu(RoleID, 2, Constants.IntNullValue);
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["mode"] != null)
        {
            EditLevel();
        }
        else
        {
            AddLevel();
        }
    }

    private void AddLevel()
    {
        int ParentID = 1;//For Main Level
        int ModuleType = 12;//For Main Level

        if (Request.QueryString["LevelID"] != null)
        {
            ParentID = Convert.ToInt32(Request.QueryString["LevelID"]);//For Inner Level
            ModuleType = 13;//For Inner Level
        }

        if (MenuCtl.InsertMenuLevel(txtMenu.Text, ParentID, ModuleType))
        {
            if (Request.QueryString["LevelID"] != null)
            {
                Response.Redirect("Menu.aspx?LevelID=" + Request.QueryString["LevelID"] + "&LevelType=" + Request.QueryString["LevelType"]);
            }
            else
            {
                Response.Redirect("Menu.aspx?");
            }
        }
        else
        {
            lblError.Text = "Some error occured. Level not saved.";
        }
    }

    private void EditLevel()
    {
        if(MenuCtl.UpdateMenuLevel(Convert.ToInt32(hfModuleID.Value),txtMenu.Text,Constants.IntNullValue,Constants.IntNullValue))
        {
            foreach (GridViewRow rowMain in gvMain.Rows)
            {
                GridView gvSubMenu = (GridView)rowMain.FindControl("gvSubMenu");
                {
                    foreach (GridViewRow rowSubMenu in gvSubMenu.Rows)
                    {
                        GridView gvForm = (GridView)rowSubMenu.FindControl("gvForms");
                        {
                            foreach (GridViewRow rowForm in gvForm.Rows)
                            {
                                //Retrieve the state of the CheckBox
                                CheckBox cb = (CheckBox)rowForm.FindControl("cbModule");
                                if (cb.Checked)
                                {
                                    HiddenField hfID = (HiddenField)rowForm.FindControl("hfMODULE_ID");
                                    MenuCtl.UpdateMenuLevel(Convert.ToInt32(hfID.Value), null, Convert.ToInt32(hfModuleID.Value), Constants.IntNullValue);
                                }
                            }
                        }
                    }
                    
                }
            }

            Response.Redirect("Menu.aspx?mode=edit&LevelID=" + Request.QueryString["LevelID"] + "&LevelType=" + Request.QueryString["LevelType"]);
        }
        else
        {
            lblError.Text = "Some error occured. Level not updated.";
        }
    }
    
    protected void gvMain_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvSubMenu = (GridView)e.Row.FindControl("gvSubMenu");
            {
                int RoleID = (int)Session["RoleID"];
                int ModuleID =  Convert.ToInt32(((GridView)sender).DataKeys[e.Row.RowIndex].Value);
                DataTable dtSubMenu = ObjRole.SelectRoleWiseModule(RoleID, 3, ModuleID);
                if (dtSubMenu != null)
                {
                    gvSubMenu.DataSource = dtSubMenu;
                    gvSubMenu.DataBind();
                }

            }
        }
    }

    private void LoadMainMenu(int RoleID, int TypeID, int ModuleID)
    {
        RoleManagementController ObjRole = new RoleManagementController();
        DataTable dtParent = ObjRole.SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (dtParent != null)
        {
            gvMain.DataSource = dtParent;
            gvMain.DataBind();
        }
    }

    protected void gvSubMenu_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvForms = (GridView)e.Row.FindControl("gvForms");
            {
                int RoleID = (int)Session["RoleID"];
                int ModuleID = Convert.ToInt32(((GridView)sender).DataKeys[e.Row.RowIndex].Value);
                DataTable dtForms = MenuCtl.GetMenuItem(ModuleID);
                if (dtForms != null)
                {
                    gvForms.DataSource = dtForms;
                    gvForms.DataBind();
                }
            }
        }
    }

    protected void gvForms_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cb = (CheckBox)e.Row.FindControl("cbModule");
            HiddenField hf = (HiddenField)e.Row.FindControl("hfParentID");

            if (hf.Value == Request.QueryString["LevelID"].ToString())
            {
                cb.Checked = true;
                cb.Enabled = false;
            }
        }
    }
}