using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class AppMaster : System.Web.UI.MasterPage
{

    MenuController MenuCtl = new MenuController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int RoleID = (int)Session["RoleID"];
            lblUser.Text = Session["UserName"].ToString();
            lblWorkingDate.Text = ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
            if (Request.QueryString["LevelType"] == null)
            {
                LoadMainMenu(RoleID, 2, Constants.IntNullValue);
            }
            else
            {
                if (Request.QueryString["LevelType"].ToString() == "1")
                {
                    gvMain.DataSource = null;
                    gvMain.DataBind();

                    gvSubMenu2.DataSource = null;
                    gvSubMenu2.DataBind();

                    LoadSubMenu1(RoleID, 3, Convert.ToInt32(Request.QueryString["LevelID"]));
                }
                else if (Request.QueryString["LevelType"].ToString() == "2")
                {
                    imgAddMenu.Visible = false;

                    gvMain.DataSource = null;
                    gvMain.DataBind();

                    gvSubMenu1.DataSource = null;
                    gvSubMenu1.DataBind();

                    LoadSubMenu2(RoleID, 4, Convert.ToInt32(Request.QueryString["LevelID"]));
                }
                else if (Request.QueryString["LevelType"].ToString() == "3")
                {
                    
                    imgAddMenu.Visible = false;

                    gvMain.DataSource = null;
                    gvMain.DataBind();

                    RoleManagementController ObjRole = new RoleManagementController();
                    gvSubMenu1.DataSource = null;
                    gvSubMenu1.DataBind();

                    DataTable dtSubMenu2 = ObjRole.SelectRoleWiseModule(RoleID, 5, Convert.ToInt32(Request.QueryString["LevelID"]));
                    if (dtSubMenu2 != null)
                    {
                        if (dtSubMenu2.Rows.Count > 0 )
                        {
                            int TrdLayerId = Convert.ToInt32(dtSubMenu2.Rows[0]["TrdLayerId"].ToString());

                            LoadSubMenu2(RoleID, 4, TrdLayerId);
                        }
                    }
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

    private void LoadSubMenu1(int RoleID, int TypeID, int ModuleID)
    {
        RoleManagementController ObjRole = new RoleManagementController();
        DataTable dtSubMenu1 = ObjRole.SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (dtSubMenu1 != null)
        {
            gvSubMenu1.DataSource = dtSubMenu1;
            gvSubMenu1.DataBind();
        }
    }

    private void LoadSubMenu2(int RoleID, int TypeID, int ModuleID)
    {
        RoleManagementController ObjRole = new RoleManagementController();
        DataTable dtSubMenu2 = ObjRole.SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (dtSubMenu2 != null)
        {
            gvSubMenu2.DataSource = dtSubMenu2;
            gvSubMenu2.DataBind();
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int RoleID = (int)Session["RoleID"];
            LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
            LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
            LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
            if (RoleID != 1)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnView.Visible = false;
                imgAddMenu.Visible = false;
            }
        }
    }

    protected void gvSubMenu1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int RoleID = (int)Session["RoleID"];
            LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
            LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
            LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
            if (RoleID != 1)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnView.Visible = false;
                imgAddMenu.Visible = false;
            }
        }
    }

    protected void gvSubMenu2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int RoleID = (int)Session["RoleID"];
            LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
            LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
            if (RoleID != 1)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                imgAddMenu.Visible = false;
            }
        }
    }

    protected void imgAddMenu_Click(object sender, EventArgs e)
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

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("Menu.aspx?mode=edit&LevelID=" + e.CommandArgument.ToString() + "&LevelType=1");
        }
        else if (e.CommandName == "view")
        {
            Response.Redirect("Level.aspx?LevelID=" + e.CommandArgument.ToString() + "&LevelType=1");
        }
        else if (e.CommandName == "delete")
        {
            DataTable dtDelete = MenuCtl.DeleteMenuLevel(Convert.ToInt32(e.CommandArgument));
            if (dtDelete.Rows[0]["Message"].ToString() != "NO")
            {
                Response.Redirect("Home.aspx?");
            }
            else
            {
                Session.Add("Message", "Can not be deleted. This level has child levels.");
                Response.Redirect("Home.aspx?");
            }
        }
    }

    protected void gvSubMenu1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("Menu.aspx?mode=edit&LevelID=" + e.CommandArgument.ToString() + "&LevelType=2");
        }
        else if (e.CommandName == "view")
        {
            Response.Redirect("Level2.aspx?LevelID=" + e.CommandArgument.ToString() + "&LevelType=2");
        }
        else if (e.CommandName == "delete")
        {
            DataTable dtDelete = MenuCtl.DeleteMenuLevel(Convert.ToInt32(e.CommandArgument));
            if (dtDelete.Rows[0]["Message"].ToString() != "NO")
            {
                if (Request.QueryString["LevelID"] != null)
                {
                    Response.Redirect("Home.aspx?LevelID=" + dtDelete.Rows[0]["Message"].ToString() + "&LevelType=" + Request.QueryString["LevelType"]);
                }
                else
                {
                    Response.Redirect("Home.aspx?");
                }
            }
            else
            {
                Session.Add("Message", "Can not be deleted. This level has child levels.");
                if (Request.QueryString["LevelID"] != null)
                {
                    Response.Redirect("Home.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"]);
                }
                else
                {
                    Response.Redirect("Home.aspx?");
                }
            }
        }
    }

    protected void gvSubMenu2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("Menu.aspx?mode=edit&LevelID=" + e.CommandArgument.ToString() + "&LevelType=3");
        }
        else if (e.CommandName == "view")
        {
            GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int rowIndex = row.RowIndex;
            Response.Redirect(gvSubMenu2.DataKeys[rowIndex]["MODULE_ID"].ToString() + "?LevelType=3&LevelID=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "delete")
        {
            DataTable dtDelete = MenuCtl.DeleteMenuLevel(Convert.ToInt32(e.CommandArgument));
            if (dtDelete.Rows[0]["Message"].ToString() != "NO")
            {
                if (Request.QueryString["LevelID"] != null)
                {
                    Response.Redirect("Home.aspx?LevelID=" + dtDelete.Rows[0]["Message"].ToString() + "&LevelType=" + Request.QueryString["LevelType"]);
                }
                else
                {
                    Response.Redirect("Home.aspx?");
                }
            }
            else
            {
                Session.Add("Message", "Can not be deleted. This level has child levels.");

                if (Request.QueryString["LevelID"] != null)
                {
                    Response.Redirect("Home.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"]);
                }
                else
                {
                    Response.Redirect("Home.aspx?");
                }
            }
        }
    }
}
