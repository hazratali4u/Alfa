<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application.Clear();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        try
        {
            if (Session["UserID"] != null)
            {
                SAMSBusinessLayer.Classes.UserController UserCtl = new SAMSBusinessLayer.Classes.UserController();

                UserCtl.InsertUserLogoutTime(Convert.ToInt32(Session["User_Log_ID"]), Convert.ToInt32(Session["UserID"]));

                Session.Clear();
                System.Web.Security.FormsAuthentication.SignOut();
                Response.Redirect("~/Login.aspx");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
        finally
        {
            if (Session["UserID"] != null)
            {
                Session.Clear();
            }
        }

    }
       
</script>
