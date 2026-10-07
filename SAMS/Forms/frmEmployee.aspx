<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmEmployee.aspx.cs" Inherits="Forms_frmEmployee" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">
<script language="JavaScript" type="text/javascript">
       
       Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );

        function startRequest( sender, e )
        { 
            
            document.getElementById('<%=btnSave.ClientID%>').disabled = true;
            document.getElementById('<%=BtnClear.ClientID%>').disabled = true;
        }

        function endRequest( sender, e ) 
        { 
           
            document.getElementById('<%=btnSave.ClientID%>').disabled = false;
            document.getElementById('<%=BtnClear.ClientID%>').disabled = false;
        }
 
 
        function ValidateForm()
		{
			var str;
			str  = document.getElementById('<%=txtempname.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Employee Name');
				return false;
			}
			str  = document.getElementById('<%=txtempfhname.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Father Name');
				return false;
			}
			str  = document.getElementById('<%=txtAccountNo.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Account No');
				return false;
			}
			str  = document.getElementById('<%=txtBankName.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Bank Name');
				return false;
			}
		
			str  = document.getElementById('<%=txtbranchname.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Branch Name');
				return false;
			}
			str  = document.getElementById('<%=txtNicno.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter NIC No');
				return false;
			}
			str  = document.getElementById('<%=txtNicno.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter NIC No');
				return false;
			}
				str  = document.getElementById('<%=txttemAddress.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Address');
				return false;
			}
				str  = document.getElementById('<%=txtpermentaddress.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Address');
				return false;
			}
				str  = document.getElementById('<%=txtJoinDate.ClientID%>').value; 
			if(str == null || str.length < 9)
			{
				alert('Must enter Date of Join');
				return false;
			}
				str  = document.getElementById('<%=txtBirthDate.ClientID%>').value; 
			if(str == null || str.length < 9)
			{
				alert('Must enter Date of Birth');
				return false;
			}
				str  = document.getElementById('<%=txtregion.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Religion');
				return false;
			}
				str  = document.getElementById('<%=txtNationalty.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Nationalty');
				return false;
			}
				str  = document.getElementById('<%=txtBasicSalary.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Basic Salary');
				return false;
			}
			return true;		
		}
	
    </script>
 <div class="container" style="background-color: white">
        <h2>
            &nbsp; Employee Information Step 2</h2>
    </div>
     <div class="container">
         <table width="100%">
             <tr>
                 <td>
                 </td>
                 <td style="width: 100px" align="center">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                     <table width="100%">
                         <tr>
                             <td style="width: 100px" align="left">
                                 <asp:Label ID="Label1" runat="server" Text="Employee Code" Width="112px"></asp:Label></td>
                             <td style="width: 100px">
                                 <asp:TextBox ID="txtempCode" runat="server" CssClass="txtBox " Width="173px" Enabled="False"></asp:TextBox></td>
                             <td style="height: 25px;">
                                 &nbsp;
                             </td>
                             <td style="width: 100px" align="left">
                                 <asp:Label ID="Label4" runat="server" Text="Base Location" Width="108px"></asp:Label></td>
                             <td style="width: 100px">
                                 <asp:DropDownList ID="DrpLocation" runat="server" CssClass="DropList"
                                     Width="200px">
                                 </asp:DropDownList></td>
                             <td style="width: 100px">
                             </td>
                             <td style="width: 100px" rowspan="3">
                                 </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 20px;" align="left">
                                 <asp:Label ID="Label2" runat="server" Text="Employee Name" Width="112px"></asp:Label></td>
                             <td style="width: 100px; height: 20px;">
                                 <asp:TextBox ID="txtempname" runat="server" CssClass="txtBox " Width="173px"></asp:TextBox></td>
                             <td style="height: 25px;">
                                 &nbsp;&nbsp;
                             </td>
                             <td style="width: 100px; height: 20px;" align="left">
                                 <asp:Label ID="Label5" runat="server" Text="Designation" Width="112px"></asp:Label></td>
                             <td style="width: 100px; height: 20px;">
                                 <asp:DropDownList ID="DrpDesignation" runat="server" CssClass="DropList"
                                     Width="200px">
                                 </asp:DropDownList></td>
                             <td style="width: 100px; height: 20px">
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 17px" align="left">
                                 <asp:Label ID="Label3" runat="server" Text="Fther/Husb Name" Width="113px"></asp:Label></td>
                             <td style="width: 100px; height: 17px">
                                 <asp:TextBox ID="txtempfhname" runat="server" CssClass="txtBox " Width="173px"></asp:TextBox></td>
                             <td style="height: 25px">
                             </td>
                             <td style="width: 100px; height: 17px" align="left">
                                 <asp:Label ID="Label6" runat="server" Text="Department" Width="112px"></asp:Label></td>
                             <td style="width: 100px; height: 17px">
                                 <asp:DropDownList ID="DrpDepartment" runat="server" CssClass="DropList"
                                     Width="200px">
                                 </asp:DropDownList></td>
                             <td style="width: 100px; height: 17px">
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 17px" align="left">
                                 <asp:Label ID="Label28" runat="server" Text="Basic Salary" Width="93px"></asp:Label></td>
                             <td style="width: 100px; height: 17px">
                                 <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="txtBox " Width="173px"></asp:TextBox></td>
                             <td style="height: 25px">
                             </td>
                             <td style="width: 100px; height: 17px" align="left">
                                 <asp:Label ID="Label29" runat="server" Text="Salary Role" Width="108px"></asp:Label></td>
                             <td rowspan="1" style="width: 100px" valign="top">
                                 <asp:DropDownList ID="DrpSalaryRole" runat="server" CssClass="DropList"
                                     Width="200px">
                                 </asp:DropDownList></td>
                             <td style="width: 100px; height: 17px">
                             </td>
                             <td rowspan="1" style="width: 100px">
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 17px" align="left">
                                 <asp:Label ID="Label24" runat="server" Text="Account No" Width="82px"></asp:Label></td>
                             <td style="width: 100px; height: 17px">
                                 <asp:TextBox ID="txtAccountNo" runat="server" CssClass="txtBox " Width="173px"></asp:TextBox></td>
                             <td style="height: 25px">
                             </td>
                             <td style="width: 100px; height: 17px" align="left">
                                 <asp:Label ID="Label27" runat="server" Text="Employee Type" Width="113px"></asp:Label></td>
                             <td style="width: 100px;" rowspan="3" valign="top" align="left">
                                 <asp:RadioButtonList ID="RbdList" runat="server" Width="93px">
                                 </asp:RadioButtonList></td>
                             <td style="width: 100px; height: 17px">
                             </td>
                             <td rowspan="1" style="width: 100px">
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 23px" align="left">
                                 <asp:Label ID="Label25" runat="server" Text="Bank Name" Width="97px"></asp:Label></td>
                             <td style="width: 100px; height: 23px">
                                 <asp:TextBox ID="txtBankName" runat="server" CssClass="txtBox " Width="174px"></asp:TextBox></td>
                             <td style="height: 25px">
                             </td>
                             <td style="width: 100px; height: 23px">
                                 </td>
                             <td style="width: 100px; height: 23px">
                             </td>
                             <td rowspan="1" style="width: 100px; height: 23px">
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 23px" align="left">
                                 <asp:Label ID="Label26" runat="server" Text="Branch Name" Width="90px" Font-Size="XX-Small"></asp:Label></td>
                             <td style="width: 100px; height: 23px">
                                 <asp:TextBox ID="txtbranchname" runat="server" CssClass="txtBox " Width="173px"></asp:TextBox></td>
                             <td style="height: 25px">
                             </td>
                             <td style="width: 100px; height: 23px">
                             </td>
                             <td style="width: 100px; height: 23px">
                             </td>
                             <td rowspan="1" style="width: 100px; height: 23px">
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 100px; height: 23px">
                             </td>
                             <td colspan="2" style="height: 23px">
                                 <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click"
                                     Text="Save" Width="86px" />
                                 <asp:Button ID="BtnClear" runat="server" Font-Size="8pt"
                                     Text="Clear" Width="81px" OnClick="BtnClear_Click" /></td>
                             <td style="width: 100px; height: 23px">
                             </td>
                             <td rowspan="1" style="width: 100px" valign="top">
                             </td>
                             <td style="width: 100px; height: 23px">
                             </td>
                             <td rowspan="1" style="width: 100px; height: 23px">
                             </td>
                         </tr>
                     </table>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                 TargetControlID="txtBasicSalary" ValidChars="0123456789.">
                             </cc1:FilteredTextBoxExtender>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </td>
                 <td>
                 </td>
             </tr>
         </table>
     </div>
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px">
                </td>
                <td align="center">
                     <cc1:TabContainer ID="TabContainer1" runat="server"  Height="250px"
                         Width="742px" ActiveTabIndex="0">
                         <cc1:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    &nbsp;Personal
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>
                                         <table width="100%">
                                             <tr>
                                                 <td align="center" style="width: 100px; height: 211px" valign="top">
                                                     <asp:Panel ID="Panel1" runat="server" BorderColor="#E0E0E0" BorderStyle="Groove"
                                                         BorderWidth="2px" Width="350px" Font-Size="X-Small">
                                                         <table width="100%">
                                                             <tr>
                                                                 <td align="center" colspan="1">
                                                                 </td>
                                                                 <td colspan="2" style="height: 25px" align="center">
                                                     <asp:Label ID="Label9" runat="server" Text="General Information" Width="198px" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                     <asp:Label ID="l1" runat="server" Width="10px"></asp:Label></td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label7" runat="server" Text="NIC No" Width="108px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:TextBox ID="txtNicno" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label111" runat="server" Text="Nationality" Width="80px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:TextBox ID="txtNationalty" runat="server" CssClass="txtBox "
                                                         Width="200px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px; height: 18px;" align="left">
                                                     <asp:Label ID="Label12" runat="server" Text="Religion" Width="80px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:TextBox ID="txtregion" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label14" runat="server" Text="Date of Birth" Width="94px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:TextBox ID="txtBirthDate" runat="server" CssClass="txtBox" MaxLength="10" onkeyup="BlockStartDateKeyPress()"
                                                                         Width="150px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label13" runat="server" Text="Date of Joining" Width="83px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:TextBox ID="txtJoinDate" runat="server" CssClass="txtBox " MaxLength="10" onkeyup="BlockEndDateKeyPress()"
                                                                         Width="150px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label8" runat="server" Text="Blood Group" Width="93px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:DropDownList ID="DrpBloodGroup" runat="server" CssClass="DropList" Width="158px">
                                                         <asp:ListItem>A+</asp:ListItem>
                                                         <asp:ListItem>B+</asp:ListItem>
                                                         <asp:ListItem>AB+</asp:ListItem>
                                                         <asp:ListItem>O+</asp:ListItem>
                                                         <asp:ListItem>A-</asp:ListItem>
                                                         <asp:ListItem>B-</asp:ListItem>
                                                         <asp:ListItem>AB-</asp:ListItem>
                                                         <asp:ListItem>O-</asp:ListItem>
                                                     </asp:DropDownList></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label15" runat="server" Text="Gender" Width="81px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:DropDownList ID="DrpGender" runat="server" CssClass="DropList" Width="158px">
                                                         <asp:ListItem>Male</asp:ListItem>
                                                         <asp:ListItem>Female</asp:ListItem>
                                                         <asp:ListItem>Other</asp:ListItem>
                                                     </asp:DropDownList></td>
                                                             </tr>
                                                             <tr>
                                                                 <td>
                                                                 </td>
                                                                 <td style="width: 100px" align="left">
                                                     <asp:Label ID="Label16" runat="server" Text="Marital Status" Width="93px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:DropDownList ID="DrpMetailStaus" runat="server" CssClass="DropList" Width="158px">
                                                         <asp:ListItem>Married </asp:ListItem>
                                                         <asp:ListItem>Unmarried</asp:ListItem>
                                                     </asp:DropDownList></td>
                                                             </tr>
                                                         </table>
                                                     </asp:Panel>
                                                     &nbsp;
                                                 </td>
                                                 <td align="center" valign="top">
                                                     <asp:Panel ID="Panel2" runat="server" BorderColor="#E0E0E0" BorderStyle="Groove"
                                                         BorderWidth="2px" Width="350px" Font-Size="X-Small">
                                                         <table width="100%">
                                                             <tr>
                                                                 <td align="center" colspan="1" style="width: 10px">
                                                                 </td>
                                                                 <td colspan="2" style="height: 25px" align="center">
                                                     <asp:Label ID="Label17" runat="server" Text="Contact Information" Width="198px" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                     <asp:Label ID="l2" runat="server" Width="10px"></asp:Label></td>
                                                                 <td align="left">
                                                     <asp:Label ID="Label11" runat="server" Text="Permanent Address" Width="108px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:TextBox ID="txtpermentaddress" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td align="left">
                                                     <asp:Label ID="Label10" runat="server" Text="Present Address" Width="106px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                     <asp:TextBox ID="txttemAddress" runat="server" CssClass="txtBox "
                                                         Width="200px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td align="left">
                                                     <asp:Label ID="Label19" runat="server" Text="Country" Width="85px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:DropDownList ID="DrpCountry" runat="server" CssClass="DropList" Width="205px">
                                                                         <asp:ListItem>Pakistan</asp:ListItem>
                                                                         <asp:ListItem>Other</asp:ListItem>
                                                                     </asp:DropDownList></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td align="left">
                                                                     <asp:Label ID="Label18" runat="server" Text="Town" Width="85px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:DropDownList ID="Drptown" runat="server" CssClass="DropList" Width="205px" OnSelectedIndexChanged="Drptown_SelectedIndexChanged" AutoPostBack="True">
                                                                     </asp:DropDownList></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td style="width: 86px" align="left">
                                                                     <asp:Label ID="Label23" runat="server" Text="Area" Width="98px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:DropDownList ID="DrpArea" runat="server" CssClass="DropList" Width="205px">
                                                                     </asp:DropDownList></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td align="left">
                                                     <asp:Label ID="Label20" runat="server" Text="Phone No" Width="96px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:TextBox ID="txtphone" runat="server" CssClass="txtBox " Width="150px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td style="width: 86px" align="left">
                                                                     <asp:Label ID="Label21" runat="server" Text="Cell No" Width="100px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:TextBox ID="txtcellno" runat="server" CssClass="txtBox " Width="150px"></asp:TextBox></td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 10px">
                                                                 </td>
                                                                 <td style="width: 86px" align="left">
                                                                     <asp:Label ID="Label22" runat="server" Text="Email Id" Width="102px"></asp:Label></td>
                                                                 <td style="height: 25px;" align="left">
                                                                     <asp:TextBox ID="txtemail" runat="server" CssClass="txtBox " Width="150px"></asp:TextBox></td>
                                                             </tr>
                                                         </table>
                                                     </asp:Panel>
                                                 </td>
                                             </tr>
                                         </table>
                                         <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                             MaskType="Date" TargetControlID="txtBirthDate">
                                         </cc1:MaskedEditExtender>
                                         <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                             MaskType="Date" TargetControlID="txtJoinDate">
                                         </cc1:MaskedEditExtender>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel2" runat="server">
                             <HeaderTemplate>
                                 Qualification&nbsp;
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td align="center" style="width: 100px">
                                             <asp:Label ID="Label91" runat="server" Font-Bold="True" Font-Size="Small" Height="18px"
                                                 Text="Employee Qualification" Width="233px"></asp:Label>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                 <ContentTemplate>
                                             <asp:GridView ID="GrdQulificaton" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                 BorderColor="White" CssClass="gridRow2" Font-Size="X-Small" ForeColor="SteelBlue"
                                                 HorizontalAlign="Center" Width="93%">
                                                 <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                     PreviousPageText="Previous" />
                                                 <RowStyle ForeColor="Black" />
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="Institute Name">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtInstituteName" runat="server" CssClass="txtBox " Width="150px"></asp:TextBox>
                                                         </ItemTemplate>
                                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="From Date">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox " Width="80px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="To Date">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txttodate" runat="server" CssClass="txtBox " Width="80px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Division">
                                                         <ItemTemplate>
                                                             &nbsp;<asp:TextBox ID="txtDivsion" runat="server" CssClass="txtBox " Width="100px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Achievement">
                                                         <ItemTemplate>
                                                             <asp:DropDownList ID="DrpAchivement" runat="server" CssClass="DropList"
                                     Width="145px">
                                                                 <asp:ListItem>Matriculation</asp:ListItem>
                                                                 <asp:ListItem>Intermediate</asp:ListItem>
                                                                 <asp:ListItem>Graduation </asp:ListItem>
                                                                 <asp:ListItem>Post Graduation </asp:ListItem>
                                                                 <asp:ListItem>Master</asp:ListItem>
                                                             </asp:DropDownList>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Maj Subject">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtMajorSubject" runat="server" CssClass="txtBox " Width="133px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                 </Columns>
                                                 <FooterStyle BackColor="White" /><PagerStyle BackColor="Transparent" />
                                                 <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                     VerticalAlign="Middle" />
                                                 <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                             </asp:GridView>
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                     </tr>
                                 </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel3" runat="server">
                             <HeaderTemplate>
                                 Experience&nbsp;
                             </HeaderTemplate>
                             <ContentTemplate><table width="100%">
                                 <tr>
                                     <td align="center" style="width: 100px">
                                         <asp:Label ID="Label450" runat="server" Font-Bold="True" Font-Size="Small" Height="18px"
                                             Text="Employee Experience" Width="228px"></asp:Label>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                             <ContentTemplate>
                                         <asp:GridView ID="GrdExperience" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                 BorderColor="White" CssClass="gridRow2" Font-Size="X-Small" ForeColor="SteelBlue"
                                                 HorizontalAlign="Center" Width="100%">
                                             <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                             <Columns>
                                                 <asp:TemplateField HeaderText="Organization Name">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtOrganization" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="From Date">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtEFromDate" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="To Date">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtEtodate" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Designation">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtEDesignation" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Salary">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtSalary" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Phone">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtEPhone" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Business Type">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtbusinesstype" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                             </Columns>
                                             <FooterStyle BackColor="White" />
                                             <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                     VerticalAlign="Middle" />
                                             <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                     PreviousPageText="Previous" />
                                             <PagerStyle BackColor="Transparent" />
                                             <RowStyle ForeColor="Black" />
                                         </asp:GridView>
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                     </td>
                                 </tr>
                             </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                             <HeaderTemplate>
                                 Reference
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td align="center" style="width: 100px">
                                             <asp:Label ID="Label560" runat="server" Font-Bold="True" Font-Size="Small" Height="18px"
                                                 Text="Employee Reference" Width="205px"></asp:Label>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                 <ContentTemplate>
                                             <asp:GridView ID="GrdReference" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                 BorderColor="White" CssClass="gridRow2" Font-Size="X-Small" ForeColor="SteelBlue"
                                                 HorizontalAlign="Center" Width="78%">
                                                 <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                     PreviousPageText="Previous" />
                                                 <RowStyle ForeColor="Black" />
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="Reference Name">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtReference" runat="server" CssClass="txtBox " Width="112px"></asp:TextBox>
                                                         </ItemTemplate>
                                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Company Name">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtBox " Width="139px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Address">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox " Width="150px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Contact">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtContact" runat="server" CssClass="txtBox " Width="89px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Relation">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtRelition" runat="server" CssClass="txtBox " Width="93px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Duration">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtDuration" runat="server" CssClass="txtBox " Width="92px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                 </Columns>
                                                 <FooterStyle BackColor="White" />
                                                 <PagerStyle BackColor="Transparent" />
                                                 <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                     VerticalAlign="Middle" />
                                                 <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                             </asp:GridView>
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                     </tr>
                                 </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                     </cc1:TabContainer>&nbsp;</td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>