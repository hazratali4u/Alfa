using System;
using System.Data;
using System.Text;
using SAMSBusinessLayer.Classes;

public partial class Forms_PageMaster : System.Web.UI.MasterPage
{
    DistributorController CtlDist = new DistributorController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BreadCum.Text = GetBreadCrumb(0);
        }
    }

    private string GetBreadCrumb(int ModuleID)
    {
        StringBuilder strBreadCrumb = new StringBuilder();
        if (Request.QueryString["LevelID"] != null)
        {
            DataTable dtBreadCrumb = CtlDist.GetBreadCrumb(Convert.ToInt32(Request.QueryString["LevelID"]));

            strBreadCrumb.Append("<div>");
            strBreadCrumb.Append("<a href=\"" + "Home.aspx" + "\">");
            strBreadCrumb.Append("Home");
            strBreadCrumb.Append("</a>");
            if (dtBreadCrumb != null && dtBreadCrumb.Rows.Count > 0)
            {
                if (dtBreadCrumb.Rows[0]["ID2"].ToString() != "")
                {
                    if (dtBreadCrumb.Rows[0]["TYPE_ID2"].ToString() != "11")
                    {
                        if (dtBreadCrumb.Rows[0]["TYPE_ID2"].ToString() == "12")
                        {
                            strBreadCrumb.Append("<a href=\"" + "Level.aspx" + "?LevelID=" + dtBreadCrumb.Rows[0]["ID2"] + "&LevelType=1" + "\">");

                        }
                        else if (dtBreadCrumb.Rows[0]["TYPE_ID2"].ToString() == "14")
                        {
                            strBreadCrumb.Append("<a href=\"" + dtBreadCrumb.Rows[0]["KEY2"] + "?LevelID=" + dtBreadCrumb.Rows[0]["ID2"] + "&LevelType=3" + "\">");

                        }
                        else
                        {
                            strBreadCrumb.Append("<a href=\"" + "Level2.aspx" + "?LevelID=" + dtBreadCrumb.Rows[0]["ID4"] + "&LevelType=2" + "\">");
                        }
                        strBreadCrumb.Append(dtBreadCrumb.Rows[0]["DESCRIPTION2"].ToString());
                        strBreadCrumb.Append("</a>");
                    }
                }

                if (dtBreadCrumb.Rows[0]["ID3"].ToString() != "")
                {
                    if (dtBreadCrumb.Rows[0]["TYPE_ID3"].ToString() != "11")
                    {
                        if (dtBreadCrumb.Rows[0]["TYPE_ID3"].ToString() == "12")
                        {
                            strBreadCrumb.Append("<a href=\"" + "Level.aspx" + "?LevelID=" + dtBreadCrumb.Rows[0]["ID3"] + "&LevelType=1" + "\">");

                        }
                        else if (dtBreadCrumb.Rows[0]["TYPE_ID3"].ToString() == "14")
                        {
                            strBreadCrumb.Append("<a href=\"" + dtBreadCrumb.Rows[0]["KEY3"] + "?LevelID=" + dtBreadCrumb.Rows[0]["ID3"] + "&LevelType=3" + "\">");

                        }
                        else
                        {
                            strBreadCrumb.Append("<a href=\"" + "Level2.aspx" + "?LevelID=" + dtBreadCrumb.Rows[0]["ID3"] + "&LevelType=2" + "\">");
                        }
                        strBreadCrumb.Append(dtBreadCrumb.Rows[0]["DESCRIPTION3"].ToString());
                        strBreadCrumb.Append("</a>");
                    }
                }

                if (dtBreadCrumb.Rows[0]["ID4"].ToString() != "")
                {
                    if (dtBreadCrumb.Rows[0]["TYPE_ID4"].ToString() != "11")
                    {
                        if (dtBreadCrumb.Rows[0]["TYPE_ID4"].ToString() == "12")
                        {
                            strBreadCrumb.Append("<a href=\"" + "Level.aspx" + "?LevelID=" + dtBreadCrumb.Rows[0]["ID4"] + "&LevelType=1" + "\">");

                        }
                        else if (dtBreadCrumb.Rows[0]["TYPE_ID4"].ToString() == "14")
                        {
                            strBreadCrumb.Append("<a href=\"" + dtBreadCrumb.Rows[0]["KEY4"] + "?LevelID=" + dtBreadCrumb.Rows[0]["ID4"] + "&LevelType=3" + "\">");

                        }
                        else
                        {
                            strBreadCrumb.Append("<a href=\"" + "Level2.aspx" + "?LevelID=" + dtBreadCrumb.Rows[0]["ID4"] + "&LevelType=2" + "\">");
                        }
                        strBreadCrumb.Append(dtBreadCrumb.Rows[0]["DESCRIPTION4"]);
                        strBreadCrumb.Append("</a>");
                    }
                }

            }
            strBreadCrumb.Append("</div>");
        }
        return strBreadCrumb.ToString();
    }
}
