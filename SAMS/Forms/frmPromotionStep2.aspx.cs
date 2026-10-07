using System;
using System.Data;
using System.Web.UI;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

/// <summary>
/// (Promotion Step1), Define Name, Type, From Date, To Date For Promotion
/// </summary>
public partial class Forms_frmPromotionStep2 : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SchemeController mController = new SchemeController();
            DataTable dt = mController.SelectScheme(Constants.IntNullValue, Constants.IntNullValue, null, null, Constants.DateNullValue);
            clsListItems[] SchemeListItems = new clsListItems[dt.Rows.Count];
            btnNext.Attributes.Add("onclick", "return ValidateForm()");
            Populate_drpSKUCompany();
            if (dt.Rows.Count != 0)
            {
                drpExisting.DataSource = dt;
                drpExisting.DataTextField = "SCHEME_CODE";
                drpExisting.DataValueField = "SCHEME_ID";
                drpExisting.DataBind();
            }

            string flow = (string)this.Session["Flow"];
            if (this.Session["IsEdit"] != null)
            {
                bool IsEditing = (bool)this.Session["IsEdit"];
                if (IsEditing == true)
                {

                    if (flow == "f")
                    {
                        this.FillClonePromotion();
                    }
                    else
                        if (flow == "b")
                        {
                            this.LoadPromotionCollection();
                        }
                }
                else
                {
                    if (flow == "b")
                    {
                        this.LoadPromotionCollection();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Loads Promotion Collection From Session Variables For Nevigating Back From Forward Steps
    /// </summary>
    private void LoadPromotionCollection()
    {
        SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
        SchCtrl = (SchemeCollection_Controller)this.Session["SchCtrl"];

        this.txtPromotionName.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Code;
        this.txtPromotionDescription.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Desc;
        this.txtStartDate.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Start_Date.ToString("dd/MM/yyyy");
        this.txtEndDate.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).End_Date.ToString("dd/MM/yyyy");

        if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Is_Scheme == false)
        {
            this.chkScheme.Items[0].Selected = true;

        }
        else
            if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Is_Scheme == true)
            {
                this.chkScheme.Items[1].Selected = true;
            }
        if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Claimable == true)
        {
            this.chkClaimable.Checked = true;

        }
        else
            if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Claimable == false)
            {
                this.chkClaimable.Checked = false;

            }
        bool Promotion_For = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_For;

        if (Promotion_For == true)
        {

            this.rdbbtncheck.Items[1].Selected = true;
        }
        else
            if (Promotion_For == false)
            {

                this.rdbbtncheck.Items[0].Selected = true;
            }
        if (SchCtrl.Get(0).Scheme_ID == 0)
        {
            this.rBtnExisting.Checked = false;
            this.drpExisting.Enabled = false;
            this.rBtnNew.Checked = true;
            this.txtNew.Enabled = true;
            txtNew.CssClass = "txtBox";
            this.txtNew.Text = SchCtrl.Get(0).Scheme_Code;
        }

        else
        {
            string sch_code = SchCtrl.Get(0).Scheme_Code;

            this.txtNew.Enabled = false;
            txtNew.CssClass = "inputtxtDisable";
            this.rBtnNew.Checked = false;
            this.rBtnExisting.Checked = true;
            this.drpExisting.Enabled = true;

            for (int mItem = 0; mItem < drpExisting.Items.Count; mItem++)
            {
                if (drpExisting.Items[mItem].Value == sch_code)
                {
                    drpExisting.SelectedIndex = mItem;
                    break;
                }
            }
        }
    }
    
    /// <summary>
    /// Loads Promotion Collection
    /// </summary>
    private void FillClonePromotion()
    {
        rBtnNew.Checked = false;
        txtNew.Enabled = false;
        txtNew.CssClass = "inputtxtDisable";
        drpExisting.Enabled = true;
        rBtnExisting.Checked = true;

        string PromotionId = (string)this.Session["PromotionId"];
        PromotionController mPromotionContrl = new PromotionController();
        DataTable dtPromotion = mPromotionContrl.SelectPromotionWithSchemeInfo(int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(PromotionId));
        if (dtPromotion.Rows.Count > 0)
        {
            this.drpExisting.SelectedValue = dtPromotion.Rows[0]["SCHEME_ID"].ToString();
            this.txtPromotionName.Text = dtPromotion.Rows[0]["Promotion_code"].ToString();
            this.txtPromotionDescription.Text = dtPromotion.Rows[0]["Promotion_Desc"].ToString();
            this.txtStartDate.Text = DateTime.Parse(dtPromotion.Rows[0]["Start_Date"].ToString()).ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = DateTime.Parse(dtPromotion.Rows[0]["End_Date"].ToString()).ToString("dd-MMM-yyyy");
            for (int i = 0; i < this.DrpPrincipal.Items.Count; i++)
            {
                if (this.DrpPrincipal.Items[i].Value == dtPromotion.Rows[0]["PROMOTION_TYPE"].ToString())
                {
                    DrpPrincipal.Items[i].Selected = true;
                }
            }
            if (bool.Parse(dtPromotion.Rows[0]["is_Scheme"].ToString()) == false)
            {
                this.chkScheme.Items[0].Selected = true;
            }
            else
            {
                this.chkScheme.Items[1].Selected = true;
            }
            if (bool.Parse(dtPromotion.Rows[0]["CLAIMABLE"].ToString()) == true)
            {
                this.chkClaimable.Checked = true;
            }

            if (bool.Parse(dtPromotion.Rows[0]["PROMOTION_FOR"].ToString()) == true)
            {
                //this.rdbbtncheck.SelectedValue = "1";
                this.rdbbtncheck.Items[1].Selected = true;
            }
            else
                if (bool.Parse(dtPromotion.Rows[0]["PROMOTION_FOR"].ToString()) == false)
                {
                    //this.rdbbtncheck.SelectedValue = "0";
                    this.rdbbtncheck.Items[0].Selected = true;
                }

            for (int nItem = 0; nItem < drpExisting.Items.Count; nItem++)
            {
                if (drpExisting.Items[nItem].Value == dtPromotion.Rows[0]["Scheme_Code"].ToString())
                {
                    this.drpExisting.SelectedIndex = nItem;
                    break;
                }
            }
        }
    }
    
    /// <summary>
    /// Loads Step1 Data To Session Variables For Next Setps
    /// </summary>
    protected void Collection()
    {
        try
        {
            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            Scheme_Collection SchCollection = new Scheme_Collection();

            if (rBtnExisting.Checked == true)
            {
                clsListItems[] SchemeListItems = (clsListItems[])this.Session["SchemeListItems"];
                SchCollection.Scheme_ID = Convert.ToInt32(drpExisting.SelectedValue.ToString());
            }
            else
            {
                SchCollection.Scheme_ID = 0;
            }
            //SchCollection.Dist_ID = Configuration.DistributorId;
            if (rBtnExisting.Checked == true)
            {
                SchCollection.Scheme_Code = drpExisting.SelectedValue;
                SchCollection.Scheme_Desc = drpExisting.SelectedValue;
            }
            else if (rBtnNew.Checked == true)
            {
                SchCollection.Scheme_Code = txtNew.Text;
                SchCollection.Scheme_Desc = txtNew.Text;
            }
            SchCtrl.Add(SchCollection);

            Promotion_Collection PC = new Promotion_Collection();
            PC.Dist_ID = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]); 
            if (int.Parse(rdbbtncheck.SelectedItem.Value.ToString()) == 0)
            {
                PC.Promotion_For = false;
            }
            else if (int.Parse(rdbbtncheck.SelectedItem.Value.ToString()) == 1)
            {
                PC.Promotion_For = true;
            }

            PC.Promotion_Code = txtPromotionName.Text;
            PC.Promotion_Desc = txtPromotionDescription.Text;
            //PC.Promotion_Date On Promotion Insert
            PC.Claimable = chkClaimable.Checked;

            //PC.Start_Date = Convert.ToDateTime(this.txtStartDate.Text);
            PC.Start_Date = Convert.ToDateTime(txtStartDate.Text);
            if (txtEndDate.Text == "") 
            {
                PC.End_Date = DateTime.MaxValue;
            }
            else
            {
               PC.End_Date = Convert.ToDateTime(txtEndDate.Text);

            }
            PC.Is_Active = true;
            PC.Promotion_Type = int.Parse(DrpPrincipal.SelectedValue.ToString());   
                        
            if (this.chkScheme.SelectedIndex == 0)
            {
                PC.Is_Scheme = false;
            }
            else 
            {
                PC.Is_Scheme = true;
            }
            SchCollection.ObjPromotionCol_Cntrl = new PromotionCollections_Controller();
            SchCollection.ObjPromotionCol_Cntrl.Add_PCol(PC);

            this.Session.Add("SchCtrl", SchCtrl);
             
            this.Session.Add("flow", "f");

        }
        catch (Exception e1)
        {
            //lblErrorMessage.Text = e1.Message; 
        }
        string PrincipalId = DrpPrincipal.SelectedValue.ToString();
        this.Session.Add("PrincipalId", PrincipalId);     
        Response.Redirect("frmPromotionStep3.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
    }
    
    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void Populate_drpSKUCompany()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    
    /// <summary>
    /// Loads Step1 Data To Session Variables And Redirects To Step2
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        this.Collection();
    }
    
    /// <summary>
    /// Cancels Promotion Wizard And Redirects To Promotion Wizard Form
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPromotionStep1.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
    }
    
    /// <summary>
    /// Disables Promotion Name TextBox For Existing Promotion And Enables For New Promotion
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void rBtnExisting_CheckedChanged(object sender, EventArgs e)
    {
        if (rBtnExisting.Checked == true)
        {
            txtNew.Enabled = false;
            txtNew.Text = null;
            drpExisting.Enabled = true;
            this.rBtnNew.Checked = false;
        }
        else if (rBtnExisting.Checked == false)
        {
            txtNew.Enabled = true;
            drpExisting.Enabled = false;
        }
    }

    /// <summary>
    /// Enables Promotion Name TextBox For Existing Promotion And Disables For New Promotion
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void rBtnNew_CheckedChanged(object sender, EventArgs e)
    {
        if (rBtnNew.Checked == false)
        {
            txtNew.Enabled = false;
            drpExisting.Enabled = true;

        }
        else if (rBtnNew.Checked == true)
        {
            txtNew.Enabled = true;
            drpExisting.Enabled = false;
            this.rBtnExisting.Checked = false;
        }
    }
}
