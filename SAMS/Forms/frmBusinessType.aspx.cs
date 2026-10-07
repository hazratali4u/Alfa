using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// Form To Add, Edit, Delete Busines Type
/// </summary>
public partial class Forms_frmBusinessType : System.Web.UI.Page
{
    private static int RefId;

    /// <summary>
    /// Page_Load Function Populates All Grids On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadChannelType();
            this.LoadBusinessType();
            this.LoadVolumClass();
        }
    }

    #region Channel Type Tab

    /// <summary>
    /// Loads Channel Types To Channel Type Grid
    /// </summary>
    private void LoadChannelType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable  dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, bool.Parse("True"));
        grdChannelData.DataSource = dt.DefaultView;
        grdChannelData.DataBind();
     }

     /// <summary>
     /// Sets PageIndex Of Channel Type Grid
     /// </summary>
     /// <param name="sender">object</param>
     /// <param name="e">GridViewPageEventArgs</param>
    protected void grdChannelData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdChannelData.PageIndex = e.NewPageIndex;
        this.LoadChannelType();
    }

    /// <summary>
    /// Sets Channel Type For Edit. This Function Runs When An Existing Channel Type Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void grdChannelData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(grdChannelData.Rows[e.NewEditIndex].Cells[0].Text);
        txtChannelCode.Text = grdChannelData.Rows[e.NewEditIndex].Cells[1].Text;
        txtChannelName.Text = grdChannelData.Rows[e.NewEditIndex].Cells[2].Text;
        btnSaveChannelType.Text = "Update";
        txtChannelName.Enabled = true;
    }

    /// <summary>
    /// Deletes Channel Type
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void grdChannelData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        RefId = int.Parse(grdChannelData.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateSlashCodes(RefId, null, Constants.CustomerChannelType, null, 1, false, Constants.DateNullValue);
        this.LoadChannelType();

    }

    /// <summary>
    /// Save Or Updates a Channel Type
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSaveChannelType_Click(object sender, EventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        if (btnSaveChannelType.Text == "New")
        {
            txtChannelCode.Text = this.GetAutoCode("CH", 0, Constants.LongNullValue);
            txtChannelName.Enabled = true;
            txtChannelName.Focus();
            btnSaveChannelType.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtChannelName);
        }
        else if (btnSaveChannelType.Text == "Save")
        {
            if (txtChannelName.Text.Length == 0)
            {
                lblErrorMsg.Text = "Must Entry Channel Name";
                return;
            }
            mController.InsertSlashCodes(txtChannelCode.Text, Constants.CustomerChannelType, txtChannelName.Text, 1, true);
            this.GetAutoCode("CH", 1, long.Parse(txtChannelCode.Text.Substring(2)));
            this.LoadChannelType();
            txtChannelCode.Text = "";
            txtChannelName.Text = "";
            txtChannelName.Enabled = false;
            btnSaveChannelType.Text = "New";
            lblErrorMsg.Text = "";
        }
        else if (btnSaveChannelType.Text == "Update")
        {
            mController.UpdateSlashCodes(RefId, null, Constants.CustomerChannelType, txtChannelName.Text, 1, true, Constants.DateNullValue);
            this.LoadChannelType();
            txtChannelCode.Text = "";
            txtChannelName.Text = "";
            txtChannelName.Enabled = false;
            btnSaveChannelType.Text = "New";
        }
    }

    #endregion

    #region Business Type Tab

    /// <summary>
    /// Loads Business Types To Business Type Grid
    /// </summary>
    private void LoadBusinessType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerTypeBusiness, null, Constants.IntNullValue, bool.Parse("True"));
        GrdBusType.DataSource = dt.DefaultView;
        GrdBusType.DataBind();
    }

    /// <summary>
    /// Sets PageIndex Of Business Type Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void GrdBusType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdBusType.PageIndex = e.NewPageIndex;
        this.LoadBusinessType();
    }

    /// <summary>
    /// Sets Business Type For Edit. This Function Runs When An Existing Business Type Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdBusType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(GrdBusType.Rows[e.NewEditIndex].Cells[0].Text);
        txtbustypeCode.Text = GrdBusType.Rows[e.NewEditIndex].Cells[1].Text;
        txtbustypeName.Text = GrdBusType.Rows[e.NewEditIndex].Cells[2].Text;
        txtbustypeName.Enabled = true;
        btnSaveBusType.Text = "Update";

    }

    /// <summary>
    /// Deletes Business Type
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdBusType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();
        RefId = int.Parse(GrdBusType.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateSlashCodes(RefId, null, Constants.CustomerTypeBusiness, null, 1, false, Constants.DateNullValue);
        this.LoadBusinessType();
    }

    /// <summary>
    /// Save Or Updates a Business Type
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSaveBusType_Click(object sender, EventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        if (btnSaveBusType.Text == "New")
        {
            txtbustypeCode.Text = this.GetAutoCode("BS", 0, Constants.LongNullValue);
            txtbustypeName.Enabled = true;
            txtbustypeName.Focus();
            btnSaveBusType.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtbustypeName);
        }
        else if (btnSaveBusType.Text == "Save")
        {
            if (txtbustypeName.Text.Length == 0)
            {
                lblErrorMsgDivsion.Text = "Must Entry Business Type";
                return;
            }
            mController.InsertSlashCodes(txtbustypeCode.Text, Constants.CustomerTypeBusiness, txtbustypeName.Text, 1, true);
            this.GetAutoCode("BS", 1, long.Parse(txtbustypeCode.Text.Substring(2)));
            this.LoadBusinessType();
            txtbustypeCode.Text = "";
            txtbustypeName.Text = "";
            txtbustypeName.Enabled = false;
            btnSaveBusType.Text = "New";
        }
        else if (btnSaveBusType.Text == "Update")
        {
            mController.UpdateSlashCodes(RefId, null, Constants.CustomerTypeBusiness, txtbustypeName.Text, 1, true, Constants.DateNullValue);
            this.LoadBusinessType();
            txtbustypeCode.Text = "";
            txtbustypeName.Text = "";
            txtbustypeName.Enabled = false;
            btnSaveBusType.Text = "New";
        }
    }

    #endregion

    #region Promotion Class Tab

    /// <summary>
    /// Loads Promotion Classes To Promotion Class Grid
    /// </summary>
    private void LoadVolumClass()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerVolumeClassType, null, Constants.IntNullValue, bool.Parse("True"));
        GrdVolumeClass.DataSource = dt.DefaultView;
        GrdVolumeClass.DataBind();
    }

    /// <summary>
    /// Sets PageIndex Of Promotion Classes Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewPageEventArgs</param>
    protected void GrdVolumeClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdVolumeClass.PageIndex = e.NewPageIndex;
        this.LoadVolumClass();
    }

    /// <summary>
    /// Sets Promotion Classes For Edit. This Function Runs When An Existing Promotion Classes Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdVolumeClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();
        RefId = int.Parse(GrdVolumeClass.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateSlashCodes(RefId, null, Constants.CustomerVolumeClassType, null, 1, false, Constants.DateNullValue);
        this.LoadVolumClass();

    }

    /// <summary>
    /// Deletes Promotion Classes
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdVolumeClass_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(GrdVolumeClass.Rows[e.NewEditIndex].Cells[0].Text);
        txtCategoryCode.Text = GrdVolumeClass.Rows[e.NewEditIndex].Cells[1].Text;
        txtCategoryName.Text = GrdVolumeClass.Rows[e.NewEditIndex].Cells[2].Text;
        btnSaveCategory.Text = "Update";
        txtCategoryName.Enabled = true;
    }

    /// <summary>
    /// Save Or Updates a Promotion Classes
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        SLASHCodesController mController = new SLASHCodesController();

        if (btnSaveCategory.Text == "New")
        {
            txtCategoryCode.Text = this.GetAutoCode("VL", 0, Constants.LongNullValue);
            txtCategoryName.Enabled = true;
            txtCategoryName.Focus();
            btnSaveCategory.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtCategoryName);
        }
        else if (btnSaveCategory.Text == "Save")
        {
            if (txtCategoryName.Text.Length == 0)
            {
                lblErrorMsgCategory.Text = "Must Entry Volume Class";
                return;
            }
            mController.InsertSlashCodes(txtCategoryCode.Text, Constants.CustomerVolumeClassType, txtCategoryName.Text, 1, true);
            this.GetAutoCode("VL", 1, long.Parse(txtCategoryCode.Text.Substring(2)));
            this.LoadVolumClass();
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            btnSaveCategory.Text = "New";
        }
        else if (btnSaveCategory.Text == "Update")
        {
            mController.UpdateSlashCodes(RefId, null, Constants.CustomerVolumeClassType, txtCategoryName.Text, 1, true, Constants.DateNullValue);
            this.LoadVolumClass();
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            btnSaveCategory.Text = "New";
        }
    }

    #endregion

    /// <summary>
    /// Gets Code For Channel Type, Business Type And Promotion Class
    /// </summary>
    /// <remarks>
    /// Returns Code as String
    /// </remarks>
    /// <param name="PreeFix">Prefix</param>
    /// <param name="CodeType">Type</param>
    /// <param name="CValue">Value</param>
    /// <returns>Code as String</returns>
    private string GetAutoCode(string PreeFix, int CodeType,long CValue)
    {
        SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
        return AutoCode.GetAutoCode(PreeFix, CodeType, CValue);
    }    
}
