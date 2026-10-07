using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;


public partial class Forms_Level2 : System.Web.UI.Page
{
    RoleManagementController ObjRole = new RoleManagementController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadFormGrid();
        }
    }

    private void LoadFormGrid()
    {
        int RoleID = (int)Session["RoleID"];
        DataTable dtForm = ObjRole.SelectRoleWiseModule(RoleID, 4, Convert.ToInt32(Request.QueryString["LevelID"]));
        gvFrom.DataSource = dtForm;
        gvFrom.DataBind();
    }
}