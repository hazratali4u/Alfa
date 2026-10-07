<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptsaleforceWiseAging.aspx.cs" 
Inherits="Forms_RptsaleforceWiseAging" Title="SAMS: Sales Force Credit Aging" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
     <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{
		return true;	  		
	}

    </script>
 <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR><TR><TD align=left></TD><TD style="WIDTH: 82px" vAlign=middle align=left>
<strong><asp:Label id="Label1" runat="server" Width="80px" Text="Report Type" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:RadioButtonList id="RadioButtonList1" runat="server">
                <asp:ListItem Selected="True">Invoice Date Wise</asp:ListItem>
                <asp:ListItem>Due Date Wise</asp:ListItem>
            </asp:RadioButtonList></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>
            <strong><asp:Label id="lbltoLocation" runat="server" Width="80px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
    </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>
    <strong><asp:Label id="Label6" runat="server" Width="78px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></TD></TR>
            <TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>
            <strong><asp:Label id="Label4" runat="server" Width="79px" Text="Sale Force"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="ddlSaleForce" runat="server" Width="200px">
            </asp:DropDownList></TD></TR>
            
            <TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>
            <strong><asp:Label id="Label5" runat="server" Width="79px" Text="Order Booker" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpOrderBooker" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></TD></TR>
            
            <TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>
            <strong><asp:Label id="lblNickName" runat="server" Width="79px" Text="Channel Type" CssClass="lblbox" __designer:wfdid="w2"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpChannelType" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w1"></asp:DropDownList></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>&nbsp;
            <strong><asp:Label id="Label3" runat="server" Width="70px" Height="13px" Text="Up to"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:TextBox id="txtDocmentDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox><asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 82px" align=left>
            <strong><asp:Label id="Label2" runat="server" Width="65px" Height="13px" Text="Days"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:TextBox id="txtDays" runat="server" Width="150px" CssClass="txtBox"></asp:TextBox></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CEStartDate" runat="server" TargetControlID="txtDocmentDate" PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
                            </cc1:CalendarExtender> 
</contenttemplate>
                    </asp:UpdatePanel>
                
        <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button"
                Text="View Excel" Width="90" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
         &nbsp;
        
           </div>
</asp:Content>

