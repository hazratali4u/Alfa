using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class Forms_Level : System.Web.UI.Page
{
    RoleManagementController ObjRole = new RoleManagementController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMainGrid();
        }
    }

    private void LoadMainGrid()
    {
        int RoleID = (int)Session["RoleID"];
        DataTable dtMenu = ObjRole.SelectRoleWiseModule(RoleID, 3, Convert.ToInt32(Request.QueryString["LevelID"]));
        gvMain.DataSource = dtMenu;
        gvMain.DataBind();
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvForms = (GridView)e.Row.FindControl("gvForms");
            {
                int RoleID = (int)Session["RoleID"];
                int a = int.Parse(((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString());
                DataTable dtFroms = ObjRole.SelectRoleWiseModule(RoleID, 4,a);
                if (dtFroms != null && dtFroms.Rows.Count > 0)
                {
                    gvForms.DataSource = dtFroms;
                    gvForms.DataBind();
                }
            }
        }
    }
}