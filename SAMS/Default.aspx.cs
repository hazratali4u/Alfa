using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["UserID"]) > 0)
            {
                Response.Redirect("Forms/Home.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }
}