using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Classes;

/// <summary>
/// (Promotion Step2) Define Location Type, Locations, Channel Types And Volume Classess For Promotion
/// </summary>
public partial class Forms_frmPromotionStep3 : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All CheckedListBox On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // lblErrorMessage.Text = "";
        if (!Page.IsPostBack)
        {
            this.GetDistributorType();
            this.Populate_VolumeClass();
            this.Populate_CustomerType();
            string flow = (string)this.Session["Flow"];
            bool IsEditing = (bool)this.Session["IsEdit"];

            if (IsEditing == true)
            {

                if (flow == "f")
                {
                    this.FillPromotionInfo();
                }
                else if (flow == "b")
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

    /// <summary>
    /// Loads Volume Classes To Volumen Class CheckedListBox
    /// </summary>
    private void Populate_VolumeClass()
    {
        SLASHCodesController Slash_Codes = new SLASHCodesController();
        DataTable dtSlashCodes = Slash_Codes.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerVolumeClassType, null, Constants.IntNullValue, true);
        clsWebFormUtil.FillListBox(this.ChbVolumClass, dtSlashCodes, 0, 2);

    }

    /// <summary>
    /// Checks All Items in Volume Class CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbAllVolumeClass_CheckedChanged(object sender, EventArgs e)
    {
        bool AllChecked = (ChbAllVolumeClass.Checked) ? true : false;

        foreach (ListItem item in this.ChbVolumClass.Items)
        {
            item.Selected = AllChecked;
        }
    }

    /// <summary>
    /// Loads Channel Types To Channel Type CheckedListBox
    /// </summary>
    private void Populate_CustomerType()
    {
        SLASHCodesController Slash_Codes = new SLASHCodesController();
        DataTable dtSlashCodes = Slash_Codes.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType,null, Constants.IntNullValue, true);
        clsWebFormUtil.FillListBox(this.chklCustomerType, dtSlashCodes, 0, 2);
    }

    /// <summary>
    /// Checks All Items in Channel Type CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void chkSelectAllCustomerType_CheckedChanged(object sender, EventArgs e)
    {
        bool AllChecked = (chkSelectAllCustomerType.Checked) ? true : false;

        foreach (ListItem item in this.chklCustomerType.Items)
        {
            item.Selected = AllChecked;
        }
    }

    /// <summary>
    /// Loads Distributors To Distributor CheckedListBox
    /// </summary>
    private void GetDistributor()
    {
        chklDistributors.Items.Clear();
        DistributorController mController = new DistributorController();
        foreach (ListItem item in this.ChbDistributorType.Items)
        {
            if (item.Selected && int.Parse(item.Value.ToString()) > 0)
            {
                DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(item.Value.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillListBox(this.chklDistributors, dt, 0, 2);
            }
        }
    }

    /// <summary>
    /// Checks All Items in Location CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void chkSelectAllDistributors_CheckedChanged(object sender, EventArgs e)
    {
        bool AllChecked = (chkSelectAllDistributors.Checked) ? true : false;

        foreach (ListItem item in chklDistributors.Items)
        {
            item.Selected = AllChecked;
        }
    }

    /// <summary>
    /// Loads Distributor Types To Distributor Type CheckedListBox
    /// </summary>
    private void GetDistributorType()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorTypeInfo(Constants.IntNullValue);
        clsWebFormUtil.FillListBox(this.ChbDistributorType, dt, 0, 2);
    }

    /// <summary>
    /// Loads Distributors To Distributor CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDistributor();
    }

    /// <summary>
    /// Checks All Items in Location Type CheckedListBox
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
    {
        bool AllChecked = (ChbAllLocationType.Checked) ? true : false;

        foreach (ListItem item in ChbDistributorType.Items)
        {
            item.Selected = AllChecked;
            this.GetDistributor();
        }
    }

    /// <summary>
    /// Loads Promotion Collection
    /// </summary>
    private void FillPromotionInfo()
    {

        #region datatable for Distributor Info

        DataTable dtDistHirerchy = new DataTable();
               
        dtDistHirerchy.Columns.Add("distributor_id", System.Type.GetType("System.String"));
        dtDistHirerchy.Columns.Add("subzone_id", System.Type.GetType("System.String"));

        #endregion

        #region Fill Datatable of Distributor Info

        string PromotionId = (string)this.Session["PromotionId"];

        PromotionController mPromotionCtrl = new PromotionController();
        DistributorController mDistCtl = new DistributorController();
        DataTable dtDist = mPromotionCtrl.GetPromotionDistributors(long.Parse(PromotionId));
        for (int nCount = 0; nCount < dtDist.Rows.Count; nCount++)
        {
            int AssignDistId = int.Parse(dtDist.Rows[nCount]["ASSIGNED_DISTRIBUTOR_ID"].ToString());
            DataTable dtDistHierarchy = mDistCtl.GetDistributorHierarchy(AssignDistId);
            for (int nRow = 0; nRow < dtDistHierarchy.Rows.Count; nRow++)
            {
                DataRow dr = dtDistHirerchy.NewRow();
                        
                dr["subzone_id"] = dtDistHierarchy.Rows[nRow]["subzone_id"].ToString();
                dr["distributor_id"] = dtDistHierarchy.Rows[nRow]["distributor_id"].ToString();
                dtDistHirerchy.Rows.Add(dr);
            }
        }
               
        #endregion

        #region Load Customer Type

        DataTable dt = mPromotionCtrl.GetPromotionCustomerType(long.Parse(PromotionId));

        for (int nOuter = 0; nOuter < dt.Rows.Count; nOuter++)
        {
            int Customer_Type_Id = int.Parse(dt.Rows[nOuter]["CUSTOMER_TYPE_ID"].ToString());

            for (int nInner = 0; nInner < this.chklCustomerType.Items.Count; nInner++)
            {
                if (int.Parse(chklCustomerType.Items[nInner].Value) == Customer_Type_Id)
                {
                    if (chklCustomerType.Items[nInner].Selected == false)
                    {
                        chklCustomerType.Items[nInner].Selected = true;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Load Customer Volume Class

        DataTable dtVolume = mPromotionCtrl.GetPromotionCustomerVolumeClass(long.Parse(PromotionId));

        for (int nOuter = 0; nOuter < dtVolume.Rows.Count; nOuter++)
        {
            int Customer_Type_Id = int.Parse(dtVolume.Rows[nOuter]["CUSTOMER_VOLUMECLASS_ID"].ToString());

            for (int nInner = 0; nInner < this.ChbVolumClass.Items.Count; nInner++)
            {
                if (int.Parse(ChbVolumClass.Items[nInner].Value) == Customer_Type_Id)
                {
                    if (ChbVolumClass.Items[nInner].Selected == false)
                    {
                        ChbVolumClass.Items[nInner].Selected = true;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Select Distributor Type

        for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
        {
            int distributor_type = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["subzone_id"].ToString());

            for (int Inner = 0; Inner < this.ChbDistributorType.Items.Count; Inner++)
            {
                if (int.Parse(ChbDistributorType.Items[Inner].Value) == distributor_type)
                {
                    if (ChbDistributorType.Items[Inner].Selected == false)
                    {
                        ChbDistributorType.Items[Inner].Selected = true;
                        ChbDistributorType_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
        }
        #endregion

        #region Select Distributors

        for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
        {
            int distributor_id = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["distributor_id"].ToString());

            for (int Inner = 0; Inner < this.chklDistributors.Items.Count; Inner++)
            {
                if (int.Parse(chklDistributors.Items[Inner].Value) == distributor_id)
                {
                    if (chklDistributors.Items[Inner].Selected == false)
                    {
                        chklDistributors.Items[Inner].Selected = true;
                        break;
                    }
                }
            }
        }
        #endregion

        #region Basket or Slab Promotion

        BasketController BCtl = new BasketController();
        DataTable dtBMaster = BCtl.GetBasketMaster(long.Parse(PromotionId));
        bool IsBasket = false;

        foreach (DataRow dr in dtBMaster.Rows)
        {
            IsBasket = bool.Parse(dr["IS_BASKET"].ToString());
        }
        if (IsBasket == true)
        {
            this.rBtnSlabPromotion.Checked = false;
            this.rBtnSlabPromotion.Enabled = false;
            this.rBtnBasketPromotion.Checked = true;
        }
        else if (IsBasket == false)
        {
            this.rBtnBasketPromotion.Checked = false;
            this.rBtnBasketPromotion.Enabled = false;
            this.rBtnSlabPromotion.Checked = true;

        }
        #endregion
    }

    /// <summary>
    /// Loads Promotion Collection From Session Variables For Nevigating Back From Forward Steps
    /// </summary>
    private void LoadPromotionCollection()
    {
        #region	Get Scheme Controller
        SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
        SchCtrl = (SchemeCollection_Controller)this.Session["SchCtrl"];
        #endregion
        
        #region datatable for Distributor Info

        DataTable dtDistHirerchy = new DataTable();
        dtDistHirerchy.Columns.Add("distributor_id", System.Type.GetType("System.String"));
        dtDistHirerchy.Columns.Add("subzone_id", System.Type.GetType("System.String"));

        #endregion
  
        #region Fill Datatable of Distributor Info

        DistributorController mDistCtl = new DistributorController();
        PromotionForCollection_Controller mPromotionForColl = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl;

        for (int nCount = 0; nCount < mPromotionForColl.Count; nCount++)
        {
            PromotionFor_Collection mPromotionforColl = mPromotionForColl.Get(nCount);
            int Distributor_Id = mPromotionforColl.Assigned_Dist_ID;
            DataTable dt = mDistCtl.GetDistributorHierarchy(Distributor_Id);
            if (dt.Rows.Count > 0)
            {
                for (int nItem = 0; nItem < dt.Rows.Count; nItem++)
                {
                    DataRow dr = dtDistHirerchy.NewRow();
                    dr["subzone_id"] = dt.Rows[nItem]["subzone_id"].ToString();
                    dr["distributor_id"] = dt.Rows[nItem]["distributor_id"].ToString();
                    dtDistHirerchy.Rows.Add(dr);
                }
            }
        }

        #endregion

        #region Load Customer Type

        PromotionCustTypeColl_Controller mPromotionCustTypeColl = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl;
        for (int nOuter = 0; nOuter < mPromotionCustTypeColl.Count; nOuter++)
        {
            PromotionCustomerType_Collection mPromotionCustType = mPromotionCustTypeColl.Get(nOuter);
            int CustomerTypeId = mPromotionCustType.Customer_Type_ID;
            for (int nInner = 0; nInner < this.chklCustomerType.Items.Count; nInner++)
            {
                if (int.Parse(chklCustomerType.Items[nInner].Value) == CustomerTypeId)
                {
                    chklCustomerType.Items[nInner].Selected = true;
                    break;
                }
            }
        }
        #endregion

        #region Load Customer Volum Class

        PromotionCustVolclassColl_Controller mPromotionVolClass = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionVolClassCol_Cntrl;
        for (int nOuter = 0; nOuter < mPromotionVolClass.Count; nOuter++)
        {
            PromotionCustomerVolClass_Collection mPromotionVolClassCollection = mPromotionVolClass.Get(nOuter);
            int CustomerVolClass = mPromotionVolClassCollection.Customer_VolClass_ID;
  
            for (int nInner = 0; nInner < this.chklCustomerType.Items.Count; nInner++)
            {
                if (int.Parse(ChbVolumClass.Items[nInner].Value) == CustomerVolClass)
                {
                    ChbVolumClass.Items[nInner].Selected = true;
                    break;
                }
            }
        }
         #endregion

        #region Select Distributor Type

        for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
        {
            int distributor_type = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["subzone_id"].ToString());

            for (int Inner = 0; Inner < this.ChbDistributorType.Items.Count; Inner++)
            {
                if (int.Parse(ChbDistributorType.Items[Inner].Value) == distributor_type)
                {
                    if (ChbDistributorType.Items[Inner].Selected == false)
                    {
                        ChbDistributorType.Items[Inner].Selected = true;
                        ChbDistributorType_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
        }
        #endregion

        #region Select Distributors

        for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
        {
            int distributor_id = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["distributor_id"].ToString());

            for (int Inner = 0; Inner < this.chklDistributors.Items.Count; Inner++)
            {
                if (int.Parse(chklDistributors.Items[Inner].Value) == distributor_id)
                {
                    if (chklDistributors.Items[Inner].Selected == false)
                    {
                        chklDistributors.Items[Inner].Selected = true;
                        break;
                    }
                }
            }
        }
        #endregion
     }
        
    /// <summary>
    /// Loads Promotion Collection To Session Variable And Redirects To Step3
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            SchCtrl = (SchemeCollection_Controller)this.Session["SchCtrl"];

            Promotion_Collection pc = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);

            // For Promotion For Distributor Collection
            pc.ObjPromotionForCol_Cntrl = new PromotionForCollection_Controller();

            for (int i = 0; i < this.chklDistributors.Items.Count; i++)
            {
                if (this.chklDistributors.Items[i].Selected)
                {
                    PromotionFor_Collection PForCollection = new PromotionFor_Collection();
                    PForCollection.Dist_ID =  Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
                    PForCollection.Assigned_Dist_ID = int.Parse(this.chklDistributors.Items[i].Value);
                    pc.ObjPromotionForCol_Cntrl.Add(PForCollection);
                }
            }
            if (pc.ObjPromotionForCol_Cntrl.Count == 0)
            {
                lblErrorMessage.Text = "Must Select at least one Distributors";
                return; 
            }

            // For Promotion For CustomerType Collecion 
            pc.ObjPromotionCustTypeCol_Cntrl = new PromotionCustTypeColl_Controller();
            for (int i = 0; i < this.chklCustomerType.Items.Count; i++)
            {
                if (this.chklCustomerType.Items[i].Selected)
                {
                    PromotionCustomerType_Collection PCustTypeColllection = new PromotionCustomerType_Collection();
                    PCustTypeColllection.Dist_ID  = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
                    PCustTypeColllection.Customer_Type_ID = int.Parse(this.chklCustomerType.Items[i].Value);
                    pc.ObjPromotionCustTypeCol_Cntrl.Add(PCustTypeColllection);
                }
            }
            if (pc.ObjPromotionCustTypeCol_Cntrl.Count == 0)
            {
                lblErrorMessage.Text = "Must select at one Customer Type";
                return; 
            }
            pc.ObjPromotionVolClassCol_Cntrl = new PromotionCustVolclassColl_Controller();
            for (int i = 0; i < this.ChbVolumClass.Items.Count; i++)
            {
                if (this.ChbVolumClass.Items[i].Selected)
                {
                    PromotionCustomerVolClass_Collection PVolClassColllection = new PromotionCustomerVolClass_Collection();
                    PVolClassColllection.Dist_ID  = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
                    PVolClassColllection.Customer_VolClass_ID  = int.Parse(this.ChbVolumClass.Items[i].Value);
                    pc.ObjPromotionVolClassCol_Cntrl.Add(PVolClassColllection);   
                    
                }
            }
            if (pc.ObjPromotionVolClassCol_Cntrl.Count == 0)
            {
                lblErrorMessage.Text = "Must select at one Customer Volume Class";
                return;
            }
            // For Promotion For Customer Collecion 
            pc.ObjPromotionForCustCol_Cntrl = new PromotionForCustColl_Controller();


            this.Session.Add("SchCtrl", SchCtrl);

            this.Session.Add("Flow", "f");

            if (rBtnBasketPromotion.Checked == true)
            {
                Response.Redirect("frmPromotionWizardStep3Basket.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
            }
            if (rBtnSlabPromotion.Checked == true)
            {
                Response.Redirect("frmPromotionWizardStep3Slab.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
            }

        }
        catch (Exception e1) { lblErrorMessage.Text = e1.Message; }
				
    }
    
    /// <summary>
    /// Redirects To Step1
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Session.Add("Flow", "b");
        Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
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
}
