<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptMonthlySales.aspx.cs" Inherits="Forms_RptMonthlySales" Title="SAMS: Customer Monthly Reports" %>
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
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR><TR><TD align=left></TD><TD align=left>
<strong><asp:Label id="Label2" runat="server" Width="82px" Text="Report Type"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpReportType" runat="server" Width="200px" CssClass="DropList">
            <asp:ListItem>Sale</asp:ListItem>
            <asp:ListItem>Sale Return</asp:ListItem>
            <asp:ListItem>Scheme</asp:ListItem>
        </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
        <strong><asp:Label id="lbltoLocation" runat="server" Width="73px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
    </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
    <strong><asp:Label id="Label6" runat="server" Width="78px" Text="Principal" CssClass="lblbox" __designer:wfdid="w1"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged" __designer:wfdid="w2">
            </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align=left></TD><TD style="HEIGHT: 25px" align=left>
            <strong><asp:Label id="lblfromLocation" runat="server" Width="94px" Text="Customer Route" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpRoute" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="lblOrderBooker" runat="server" Width="79px" Text="Order Booker" CssClass="lblbox" __designer:wfdid="w3"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpSaleForce" runat="server" Width="199px" CssClass="DropList" __designer:wfdid="w4"></asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label5" runat="server" Width="79px" Text="Category" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpCategory" runat="server" Width="199px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="lblSKU" runat="server" Width="79px" Text="SKU" CssClass="lblbox" __designer:wfdid="w5"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpSKU" runat="server" Width="199px" CssClass="DropList" __designer:wfdid="w6"></asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="lblNickName" runat="server" Width="79px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpChannelType" runat="server" Width="199px" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label3" runat="server" Width="70px" Height="13px" Text="From Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label4" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px" CssClass="txtBox " MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD align=left></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %><cc1:CalendarExtender id="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate" TargetControlID="txtStartDate">
            </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate" TargetControlID="txtEndDate">
            </cc1:CalendarExtender> </TD></TR></TBODY></TABLE>
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
