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
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;

public partial class Forms_frmEmployee : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, 0, 2, true);
    }
    private void LoadDepoartment()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Depoartment_Id, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(this.DrpDepartment, dt, 0, 2, true);
    }
    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Designation_Id, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(this.DrpDesignation, dt, 0, 2, true);
        
    }
    private void LoadEmployeeType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Type_Id, null, Constants.IntNullValue, bool.Parse("True"));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            RbdList.Items.Add(new ListItem(dt.Rows[i][2].ToString(),dt.Rows[i][0].ToString()));      
        }
        RbdList.SelectedIndex = 0; 
    }
    private void LoadEmployeeRole()
    {
        EmployeController mController = new EmployeController();
        DataTable dt = mController.SelectEmployeerole(); 
        clsWebFormUtil.FillDropDownList(this.DrpSalaryRole, dt, 0, 1, true);
    }
    private void LoadEmployeeQulification(int p_EmployeeId)
    {
        DataTable  dtQulification = new DataTable();
        EmployeController mController  = new EmployeController();
        dtQulification.Columns.Add("SERIALNO", typeof(int));

        for (int i = 0; i < 9; i++)
        {
            DataRow dr = dtQulification.NewRow();
            dr[0] = i.ToString();
            dtQulification.Rows.Add(dr);
        }
        GrdQulificaton.DataSource = dtQulification;
        GrdQulificaton.DataBind();

        if (p_EmployeeId > 0)
        {
            DataTable dt = mController.SelectEmployeeQulification(p_EmployeeId);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox txtInstituteName = (TextBox)GrdQulificaton.Rows[i].FindControl("txtInstituteName");
                TextBox txtFromDate = (TextBox)GrdQulificaton.Rows[i].FindControl("txtFromDate");
                TextBox txtToDate = (TextBox)GrdQulificaton.Rows[i].FindControl("txttodate");
                TextBox txtDivision = (TextBox)GrdQulificaton.Rows[i].FindControl("txtDivsion");
                DropDownList drpAchivement = (DropDownList)GrdQulificaton.Rows[i].FindControl("DrpAchivement");
                TextBox txtMajorSubject = (TextBox)GrdQulificaton.Rows[i].FindControl("txtMajorSubject");

                txtInstituteName.Text = dt.Rows[i]["INSTUTITION_NAME"].ToString();
                txtFromDate.Text = dt.Rows[i]["FROM_DATE"].ToString();
                txtToDate.Text = dt.Rows[i]["TO_DATE"].ToString();
                txtDivision.Text = dt.Rows[i]["DEVISION"].ToString();
                drpAchivement.SelectedItem.Text = dt.Rows[i]["EDUCATION_ACHIVEMENT"].ToString();
                txtMajorSubject.Text = dt.Rows[i]["MAJ_SUBJECT"].ToString();
            }
        }
        //else
        //{
        //    for (int i = 0; i < GrdQulificaton.Rows.Count; i++)
        //    {
        //        TextBox txtInstituteName = (TextBox)GrdQulificaton.Rows[i].FindControl("txtInstituteName");
        //        TextBox txtFromDate = (TextBox)GrdQulificaton.Rows[i].FindControl("txtFromDate");
        //        TextBox txtToDate = (TextBox)GrdQulificaton.Rows[i].FindControl("txttodate");
        //        TextBox txtDivision = (TextBox)GrdQulificaton.Rows[i].FindControl("txtDivsion");
        //        DropDownList drpAchivement = (DropDownList)GrdQulificaton.Rows[i].FindControl("DrpAchivement");
        //        TextBox txtMajorSubject = (TextBox)GrdQulificaton.Rows[i].FindControl("txtMajorSubject");

        //        txtInstituteName.Text = "NA";
        //        txtFromDate.Text = "NA";
        //        txtToDate.Text = "NA";
        //        txtDivision.Text = "NA";
        //        //drpAchivement.SelectedItem.Text = dt.Rows[i]["EDUCATION_ACHIVEMENT"].ToString();
        //        txtMajorSubject.Text = "NA";

        //    }
        //}
     }
    private void LoadEmployeeExperience(int p_EmployeeId)
    {
        DataTable dtExperence = new DataTable();
        EmployeController mController = new EmployeController();
        dtExperence.Columns.Add("SERIALNO", typeof(int));
        for (int i = 0; i < 9; i++)
        {
            DataRow dr = dtExperence.NewRow();
            dr[0] = i.ToString();
            dtExperence.Rows.Add(dr);
        }
        GrdExperience.DataSource = dtExperence;
        GrdExperience.DataBind();

        DataTable dt = mController.SelectEmployeeExperience(p_EmployeeId);
        if (p_EmployeeId > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox txtOrganization = (TextBox)GrdExperience.Rows[i].FindControl("txtOrganization");
                TextBox txtEFromDate = (TextBox)GrdExperience.Rows[i].FindControl("txtEFromDate");
                TextBox txtEtodate = (TextBox)GrdExperience.Rows[i].FindControl("txtEtodate");
                TextBox txtEDesignation = (TextBox)GrdExperience.Rows[i].FindControl("txtEDesignation");
                TextBox txtSalary = (TextBox)GrdExperience.Rows[i].FindControl("txtSalary");
                TextBox txtEPhone = (TextBox)GrdExperience.Rows[i].FindControl("txtEPhone");
                TextBox txtbusinesstype = (TextBox)GrdExperience.Rows[i].FindControl("txtbusinesstype");

                txtOrganization.Text = dt.Rows[i]["ORGANIZATION"].ToString();
                txtEFromDate.Text = dt.Rows[i]["FROM_DATE"].ToString();
                txtEtodate.Text = dt.Rows[i]["TO_DATE"].ToString();
                txtEDesignation.Text = dt.Rows[i]["DESIGNATION"].ToString();
                txtSalary.Text = dt.Rows[i]["SALARY"].ToString();
                txtEPhone.Text = dt.Rows[i]["PHONE"].ToString();
                txtbusinesstype.Text = dt.Rows[i]["BUSINESS_TYPE"].ToString();
            }
        }
    }
    private void LoadEmployeeReference(int p_EmployeeId)
    {
        DataTable dtReference = new DataTable();
        EmployeController mController = new EmployeController();
        dtReference.Columns.Add("SERIALNO", typeof(int));
        for (int i = 0; i < 9; i++)
        {
            DataRow dr = dtReference.NewRow();
            dr[0] = i.ToString();
            dtReference.Rows.Add(dr);
        }
        GrdReference.DataSource = dtReference;
        GrdReference.DataBind();
        if (p_EmployeeId > 0)
        {
            DataTable dt = mController.SelectEmployeeReference(p_EmployeeId);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox txtReference = (TextBox)GrdReference.Rows[i].FindControl("txtReference");
                TextBox txtCompanyName = (TextBox)GrdReference.Rows[i].FindControl("txtCompanyName");
                TextBox txtAddress = (TextBox)GrdReference.Rows[i].FindControl("txtAddress");
                TextBox txtRelition = (TextBox)GrdReference.Rows[i].FindControl("txtRelition");
                TextBox txtcontact = (TextBox)GrdReference.Rows[i].FindControl("txtContact");
                TextBox txtDuration = (TextBox)GrdReference.Rows[i].FindControl("txtDuration");

                txtReference.Text = dt.Rows[i]["REFERENCE_NAME"].ToString();
                txtCompanyName.Text = dt.Rows[i]["COMPANY_NAME"].ToString();
                txtAddress.Text = dt.Rows[i]["ADDRESS"].ToString();
                txtcontact.Text = dt.Rows[i]["CONTACT"].ToString();
                txtRelition.Text = dt.Rows[i]["RELATION"].ToString();
                txtDuration.Text = dt.Rows[i]["DURATION"].ToString();
            }
        }
       
    }
    protected void LoadTown()
    {
        if (DrpLocation.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue);
            Drptown.Items.Add(new ListItem("None", "0"));
            clsWebFormUtil.FillDropDownList(Drptown, dt, 0, 1);
        }
    }
    private void LoadArea()
    {
        if (Drptown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, Constants.IntNullValue  , int.Parse(Drptown.SelectedValue.ToString()), null, null);
            DrpArea.Items.Clear();
            DrpArea.Items.Add(new ListItem("None", "0"));    
            clsWebFormUtil.FillDropDownList(DrpArea, dt, 0, 6);

        }
    }
    private void LoadTreeView()
    {

        AppMaster myMaster;
        TreeView tr;
        Label lblUserId;
        Label lblBrandId;
        Label lblCurrentWorkDate;

        myMaster = (AppMaster)this.Master;
        tr = myMaster.FindControl("tr") as TreeView;
        lblUserId = myMaster.FindControl("Label1") as Label;
        lblUserId.Text = this.Session["UserName"].ToString();
        lblCurrentWorkDate = myMaster.FindControl("lblCurrentWorkDate") as Label;
        lblCurrentWorkDate.Text = "Working Date " + ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");

        tr.Nodes.Clear();
        TreeNode trMaster = (TreeNode)this.Session["trMaster"];
        tr.Nodes.Add(trMaster);
        tr.CollapseAll();
        if (Session["TreeViewState"] == null)
        {
            // Record the TreeView's current expand/collapse state.
            Dictionary<string, bool> SelectedNode = new Dictionary<string, bool>();
            SaveTreeViewState(tr.Nodes, SelectedNode);
            Session["TreeViewState"] = SelectedNode;
        }
        else
        {
            // Apply the recorded expand/collapse state to the TreeView.
            Dictionary<string, bool> SelectedNode = (Dictionary<string, bool>)Session["TreeViewState"];
            RestoreTreeViewState(tr.Nodes, SelectedNode);
        }
    }
    private void SaveTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        // Recursivley record all expanded nodes in the List.
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                if (node.Expanded.HasValue && node.Expanded == true && !String.IsNullOrEmpty(node.Text))
                    SelectedNode.Add(node.Text, true);
                else
                    SelectedNode.Add(node.Text, false);
                SaveTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
    private void RestoreTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        foreach (TreeNode node in nodes)
        {
            if (Session["SelectedNode"].ToString() == node.ValuePath)
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry_down.gif";
                node.Selected = true;
            }
            else
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry.gif";
            }

            // Restore the state of one node.
            foreach (KeyValuePair<string, bool> pair in SelectedNode)
            {
                if (pair.Key == node.Text && pair.Value == true)
                {
                    node.Expand();
                }
                else if (pair.Key == node.Text && pair.Value == false)
                {
                    node.Collapse();
                }
                if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                    RestoreTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
    private void ClearAll()
    {
        txtAccountNo.Text = "";
        txtBankName.Text = "";
        txtBirthDate.Text = "";
        txtbranchname.Text = "";
        txtcellno.Text = "";
        txtemail.Text = "";
        txtempCode.Text = "";
        txtempfhname.Text = "";
        txtempname.Text = "";
        txtNationalty.Text = "";
        txtJoinDate.Text = "";
        txtNicno.Text = "";
        txtpermentaddress.Text = "";
        txtphone.Text = "";
        txtregion.Text = "";
        txttemAddress.Text = "";
        txtBasicSalary.Text = "0";
        this.LoadEmployeeQulification(-1);
        this.LoadEmployeeExperience(-1);
        this.LoadEmployeeReference(-1);
        btnSave.Text = "Save";
 
    }
    private DataTable GetQulification()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("InstituteName", typeof(string));
        dt.Columns.Add("FromDate", typeof(string));
        dt.Columns.Add("ToDate", typeof(string));
        dt.Columns.Add("Maj_Subject", typeof(string));
        dt.Columns.Add("Division", typeof(string));
        dt.Columns.Add("Education_Achivement", typeof(string));

        for (int i = 0; i < GrdQulificaton.Rows.Count; i++)
        {
            TextBox txtInstituteName = (TextBox)GrdQulificaton.Rows[i].FindControl("txtInstituteName");
            if (txtInstituteName.Text.Trim().Length > 0)
            {
                TextBox txtFromDate = (TextBox)GrdQulificaton.Rows[i].FindControl("txtFromDate");
                TextBox txtToDate = (TextBox)GrdQulificaton.Rows[i].FindControl("txttodate");
                TextBox txtDivision = (TextBox)GrdQulificaton.Rows[i].FindControl("txtDivsion");
                DropDownList drpAchivement = (DropDownList)GrdQulificaton.Rows[i].FindControl("DrpAchivement");
                TextBox txtMajorSubject = (TextBox)GrdQulificaton.Rows[i].FindControl("txtMajorSubject");

                DataRow dr = dt.NewRow();
                dr["InstituteName"] = txtInstituteName.Text;
                dr["FromDate"] = txtFromDate.Text;
                dr["ToDate"] = txtToDate.Text;
                dr["Maj_Subject"] = txtMajorSubject.Text;
                dr["Division"] = txtDivision.Text;
                dr["Education_Achivement"] = drpAchivement.SelectedItem.Text;
                dt.Rows.Add(dr);

            }
  
        }
        return dt;
    }
    private DataTable GetExperience()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ORGANIZATION", typeof(string));
        dt.Columns.Add("FromDate", typeof(string));
        dt.Columns.Add("ToDate", typeof(string));
        dt.Columns.Add("DESIGNATION", typeof(string));
        dt.Columns.Add("SALARY", typeof(string));
        dt.Columns.Add("PHONE", typeof(string));
        dt.Columns.Add("BUSINESS_TYPE", typeof(string));
        DataControl dc = new DataControl(); 

        for (int i = 0; i < GrdExperience.Rows.Count; i++)
        {
            TextBox txtOrganization = (TextBox)GrdExperience.Rows[i].FindControl("txtOrganization");
            if (txtOrganization.Text.Trim().Length > 0)
            {
                TextBox txtEFromDate = (TextBox)GrdExperience.Rows[i].FindControl("txtEFromDate");
                TextBox txtEtodate = (TextBox)GrdExperience.Rows[i].FindControl("txtEtodate");
                TextBox txtEDesignation = (TextBox)GrdExperience.Rows[i].FindControl("txtEDesignation");
                TextBox txtSalary = (TextBox)GrdExperience.Rows[i].FindControl("txtSalary");
                TextBox txtEPhone = (TextBox)GrdExperience.Rows[i].FindControl("txtEPhone");
                TextBox txtbusinesstype = (TextBox)GrdExperience.Rows[i].FindControl("txtbusinesstype");
                //CheckBox ChbIsCertificate = (CheckBox)GrdExperience.Rows[i].FindControl("ChbIsCertificate");

                DataRow dr = dt.NewRow();
                dr["ORGANIZATION"] = txtOrganization.Text;
                dr["FromDate"] = txtEFromDate.Text;
                dr["ToDate"] = txtEtodate.Text;
                dr["DESIGNATION"] = txtEDesignation.Text;
                dr["SALARY"] = dc.chkNull_0(txtSalary.Text);
                dr["PHONE"] = txtEPhone.Text;
                dr["BUSINESS_TYPE"] = txtbusinesstype.Text;
                dt.Rows.Add(dr);
                
                txtOrganization.Text = "";
                txtEFromDate.Text = "";
                txtEtodate.Text = "";
                txtEDesignation.Text = "";
                txtSalary.Text = "";
                txtEPhone.Text = "";
                txtbusinesstype.Text = "";
            }
        }
        return dt;
    }
    private DataTable GetReference()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("REFERENCE_NAME", typeof(string));
        dt.Columns.Add("COMPANY_NAME", typeof(string));
        dt.Columns.Add("ADDRESS", typeof(string));
        dt.Columns.Add("CONTACT", typeof(string));
        dt.Columns.Add("RELATION", typeof(string));
        dt.Columns.Add("DURATION", typeof(string));
      
        for (int i = 0; i < GrdReference.Rows.Count; i++)
        {
            TextBox txtReference = (TextBox)GrdReference.Rows[i].FindControl("txtReference");
            if (txtReference.Text.Trim().Length > 0)
            {
                TextBox txtCompanyName = (TextBox)GrdReference.Rows[i].FindControl("txtCompanyName");
                TextBox txtContact = (TextBox)GrdReference.Rows[i].FindControl("txtContact");
                TextBox txtRelition = (TextBox)GrdReference.Rows[i].FindControl("txtRelition");
                TextBox txtDuration = (TextBox)GrdReference.Rows[i].FindControl("txtDuration");
                TextBox txtAddress = (TextBox)GrdReference.Rows[i].FindControl("txtAddress");
                

                DataRow dr = dt.NewRow();
                dr["REFERENCE_NAME"] = txtReference.Text;
                dr["COMPANY_NAME"] = txtCompanyName.Text;
                dr["ADDRESS"] = txtAddress.Text;
                dr["CONTACT"] = txtContact.Text;
                dr["RELATION"] = txtRelition.Text;
                dr["DURATION"] = txtDuration.Text;
                dt.Rows.Add(dr);

                txtReference.Text = "";
                txtCompanyName.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtRelition.Text = "";
                txtDuration.Text = "";
            }
        }
        return dt;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDepoartment();
            this.LoadDesignation();
            this.LoadEmployeeType();
            this.LoadDistributor();
            this.LoadEmployeeRole(); 
            this.LoadTreeView();
            this.LoadTown();
            this.LoadArea();
            if (int.Parse(this.Session["EmployeeId"].ToString()) > 0)
            {
                txtempCode.Text = this.Session["EmployeeId"].ToString();
                this.Session.Remove("EmployeeId");
                EmployeController mController = new EmployeController();
                DataTable DtEmployee = mController.UspSelectEmployee(Constants.IntNullValue, "EMPLOYEE_ID", txtempCode.Text);
                txtempname.Text = DtEmployee.Rows[0]["EMPLOYEE_NAME"].ToString();
                txtempfhname.Text = DtEmployee.Rows[0]["FATHER_NAME"].ToString();
                txtAccountNo.Text = DtEmployee.Rows[0]["ACCOUNT_NO"].ToString();
                txtBankName.Text = DtEmployee.Rows[0]["BANK_NAME"].ToString();
                txtbranchname.Text = DtEmployee.Rows[0]["BRANCH"].ToString();
                txtNicno.Text = DtEmployee.Rows[0]["NIC_NO"].ToString();
                txtNationalty.Text = DtEmployee.Rows[0]["NATIONALTY"].ToString();
                txtregion.Text = DtEmployee.Rows[0]["RELIGION"].ToString();
                txttemAddress.Text = DtEmployee.Rows[0]["PRESENT_ADDRESS"].ToString();
                txtpermentaddress.Text = DtEmployee.Rows[0]["PERMANENT_ADDRESS"].ToString();
                txtphone.Text = DtEmployee.Rows[0]["PHONE_NO"].ToString();
                txtcellno.Text = DtEmployee.Rows[0]["CELL_NO"].ToString();
                txtemail.Text = DtEmployee.Rows[0]["EMAIL_ADDRESS"].ToString();
                DrpLocation.SelectedValue = DtEmployee.Rows[0]["LOCATION_ID"].ToString();
                DrpDesignation.SelectedValue = DtEmployee.Rows[0]["DESIGNATION_ID"].ToString();
                DrpDepartment.SelectedValue = DtEmployee.Rows[0]["DEPARTMENT_ID"].ToString();
                RbdList.SelectedValue = DtEmployee.Rows[0]["EMPLOYEE_TYPE_ID"].ToString();
                txtBirthDate.Text = DateTime.Parse(DtEmployee.Rows[0]["DATE_BIRTH"].ToString()).ToString("dd/MM/yyyy");
                txtJoinDate.Text = DateTime.Parse(DtEmployee.Rows[0]["DATE_JOIN"].ToString()).ToString("dd/MM/yyyy");
                DrpGender.SelectedItem.Text = DtEmployee.Rows[0]["GENDER"].ToString();
                DrpMetailStaus.SelectedItem.Text = DtEmployee.Rows[0]["MATRIAL_STATUS"].ToString();
                DrpBloodGroup.SelectedItem.Text = DtEmployee.Rows[0]["BLOOD_GROUP"].ToString();
                txtBasicSalary.Text = DtEmployee.Rows[0]["BASIC_SALARY"].ToString();
                DrpSalaryRole.SelectedValue = DtEmployee.Rows[0]["EMPLOYEE_NORMS_ID"].ToString();
                this.LoadEmployeeQulification(int.Parse(txtempCode.Text));
                this.LoadEmployeeExperience(int.Parse(txtempCode.Text));
                this.LoadEmployeeReference(int.Parse(txtempCode.Text));
                this.btnSave.Text = "Update";
                this.Session.Remove("EmployeeId");  
            }
            else
            {
                this.LoadEmployeeQulification(-1);
                this.LoadEmployeeExperience(-1);
                this.LoadEmployeeReference(-1);
            }
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;
            btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
        
    }
      
    protected void Drptown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea(); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EmployeController ECcontroller = new EmployeController();
        DataTable dtQulification = GetQulification();
        DataTable dtExperience = GetExperience();
        DataTable dtReference = GetReference();
        int EmpId = 0;
        if (btnSave.Text == "Save")
        {
            EmpId = ECcontroller.InsertEmployee(txtempname.Text, txtempfhname.Text, txtAccountNo.Text, txtBankName.Text, txtbranchname.Text, int.Parse(DrpLocation.SelectedValue.ToString()),
                        int.Parse(DrpDepartment.SelectedValue.ToString()), int.Parse(DrpDesignation.SelectedValue.ToString()), int.Parse(RbdList.SelectedValue.ToString()), txtNicno.Text
                        , txtNationalty.Text, txtregion.Text, DateTime.Parse(txtBirthDate.Text), DateTime.Parse(txtJoinDate.Text), DrpGender.SelectedItem.Text, DrpMetailStaus.SelectedItem.Text, DrpBloodGroup.SelectedItem.Text,
                        txttemAddress.Text, txtpermentaddress.Text, int.Parse(Drptown.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), txtphone.Text, txtcellno.Text, txtemail.Text, dtQulification, dtExperience, dtReference,decimal.Parse(txtBasicSalary.Text),int.Parse(DrpSalaryRole.SelectedValue.ToString()));

        }
        else
        {
            EmpId = ECcontroller.UpdatedEmployee(int.Parse(txtempCode.Text), txtempname.Text, txtempfhname.Text, txtAccountNo.Text, txtBankName.Text, txtbranchname.Text, int.Parse(DrpLocation.SelectedValue.ToString()),
                                   int.Parse(DrpDepartment.SelectedValue.ToString()), int.Parse(DrpDesignation.SelectedValue.ToString()), int.Parse(RbdList.SelectedValue.ToString()), txtNicno.Text
                                   ,txtNationalty.Text, txtregion.Text, DateTime.Parse(txtBirthDate.Text), DateTime.Parse(txtJoinDate.Text), DrpGender.SelectedItem.Text, DrpMetailStaus.SelectedItem.Text, DrpBloodGroup.SelectedItem.Text,
                                   txttemAddress.Text, txtpermentaddress.Text, int.Parse(Drptown.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), txtphone.Text, txtcellno.Text, txtemail.Text, dtQulification, dtExperience, dtReference, decimal.Parse(txtBasicSalary.Text), int.Parse(DrpSalaryRole.SelectedValue.ToString()));
        }
        if (EmpId <= 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some Error Record not Updated');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Update');", true);
            this.ClearAll();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        this.ClearAll(); 
    }
}
