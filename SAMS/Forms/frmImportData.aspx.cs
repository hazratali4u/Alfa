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
using System.IO;

/// <summary>
/// Form To Import Route, Market,  Customer, SKU And SKU Price Data From Text Files
/// </summary>
public partial class Forms_frmImportData : System.Web.UI.Page
{
    CustomerDataController mCustomer = new CustomerDataController();

    /// <summary>
    /// Page_Load Function Populates All Combos On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadTown();
            this.LoadDistributor();
            this.LoadPrincipal();
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Towns To Town Combo
    /// </summary>
    private void LoadTown()
    {
        GeoHierarchyController GControler = new GeoHierarchyController();
        DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpTown, dt, 0, 4, true);
    }    
        
    /// <summary>
    /// Loads Principals To Principal Comb
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
        
    /// <summary>
    /// Imports File Data To Database
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region FileValidation
        if (txtFile.PostedFile.ContentLength == 0)
        {
            lblErrorMessage.Text = "Please select a file and then upload";
            return;
        }
        else if (txtFile.PostedFile.ContentType != "text/plain")
        {
            lblErrorMessage.Text = "Only text file are supported";
            return;
        }
        #endregion

        try
        {
            if (!Directory.Exists(Constants.fldOtherDataFolder))
            {
                Directory.CreateDirectory(Constants.fldOtherDataFolder);
            }

            string path = System.IO.Path.GetFullPath(txtFile.PostedFile.FileName);
            string filename = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
            if (File.Exists(Constants.fldOtherDataFolder + filename))
            {
                lblErrorMessage.Text = "File already Exist in folder. Save file with other name";
                cboFileTypes.SelectedIndex = 0;
                return;
            }
            else
            {
                txtFile.PostedFile.SaveAs(Constants.fldOtherDataFolder + filename);
                path = Constants.fldOtherDataFolder + filename;
                int index = cboFileTypes.SelectedIndex;
                this.lblErrorMessage.Text = "";
                bool insert = false;
                if (cboFileTypes.SelectedIndex == 0)
                {
                    DistributorAreaController DistAreaCntl = new DistributorAreaController();
                  insert=  DistAreaCntl.ImportRoute(int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(this.Session["UserId"].ToString()));
                }
                else if (cboFileTypes.SelectedIndex == 1)
                {
                    DistributorRouteController DistRouteCtl = new DistributorRouteController();
                    insert = DistRouteCtl.ImportMarket(int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(this.Session["UserId"].ToString()));
                }
                else if (cboFileTypes.SelectedIndex == 2)
                {
                    insert = mCustomer.ImportCustomer(int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), path);
                }
                else if (cboFileTypes.SelectedIndex == 4)
                {
                    SKUPriceDetailController SKUPriceCtl = new SKUPriceDetailController();
                    insert = SKUPriceCtl.ImportSKUPrices(int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(DrpPrincipal.SelectedValue.ToString()));
                }
                if (insert)
                {
                    this.lblErrorMessage.Text = "Record Inserted !";
                }
                else
                { this.lblErrorMessage.Text = "Some Error !"; }
            }
        }
        catch (Exception excp)
        {
            lblErrorMessage.Text = excp.ToString();
            cboFileTypes.SelectedIndex = 0;
            return;
        }
    }
}
