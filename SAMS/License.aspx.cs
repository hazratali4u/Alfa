using System;
using System.Data;
using System.Web.UI;
using System.IO;
using SAMSBusinessLayer.Classes;

public partial class License : System.Web.UI.Page
{
    readonly DistributorController mDist = new DistributorController();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuLicense.HasFile)
        {
            string fileExt =System.IO.Path.GetExtension(fuLicense.FileName);
            string strKey = string.Empty;
            if (fileExt == ".txt" || fileExt == ".TXT")
            {
                StreamReader reader = new StreamReader(fuLicense.FileContent);
                do
                {
                    strKey = reader.ReadToEnd();

                }
                while (reader.Peek() != -1);
                reader.Close();               

                if (strKey.Length > 0)
                {
                    strKey = SAMSCommon.Classes.Cryptography.Decrypt(strKey, "b0tin@74");
                    string[] strDec = strKey.Split('|');

                    DataTable dtLicenseData = mDist.GetLicenseData();
                    bool flag = true;

                    foreach (DataRow dr in dtLicenseData.Rows)
                    {
                        if (dr["LICENSE"].ToString() == strDec[2].ToString())
                        {
                            flag = false;                            
                            break;
                        }
                    }

                    if (flag)
                    {
                        try
                        {                            
                            Convert.ToDateTime(strDec[1]);//Check Date Format

                            if (strDec.Length == 4)
                            {
                                if (strDec[0].ToString() != dtLicenseData.Rows[0]["CompanyName"].ToString())
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Incorrect License format!')", true);
                                }
                                else if (strDec[3].ToString() != "www.fastservices.pk")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Incorrect License format!')", true);
                                }
                                else
                                {
                                    if (mDist.InsertLicense(0, strDec[2].ToString(), Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"))) == "Record Inserted")
                                    {
                                        Response.Redirect("Login.aspx");
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Somer error occured!')", true);
                                    }
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Incorrect License format!')", true);
                            }

                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Incorrect License format!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('This is license is expired!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Only .txt files allowed!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Incorrect License format!!')", true);                
            }
        }
        else
        {            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Browse License file!')", true);
        }
    }
}