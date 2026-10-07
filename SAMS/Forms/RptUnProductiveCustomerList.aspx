<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptUnProductiveCustomerList.aspx.cs" Inherits="Forms_RptUnProductiveCustomerList" Title="SAMS: Non Productive Customer List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
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
<strong> <asp:Label id="lbltoLocation" runat="server" Width="61px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
    <strong><asp:Label id="Label2" runat="server" Width="48px" Text="Town" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpTown" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label1" runat="server" Width="52px" Text="Route" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpRoute" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left><strong><asp:Label id="Label6" runat="server" Width="100px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpChannelType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left><strong><asp:Label id="Label3" runat="server" Width="100px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left><strong><asp:Label id="Label4" runat="server" Width="70px" Height="13px" Text="From Date" __designer:wfdid="w3"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10" __designer:wfdid="w4"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif" __designer:wfdid="w5"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label5" runat="server" Width="80px" Height="13px" Text="To Date" __designer:wfdid="w6"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px" CssClass="txtBox " MaxLength="10" __designer:wfdid="w7"></asp:TextBox> <asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif" __designer:wfdid="w8"></asp:ImageButton></TD></TR></TBODY></TABLE>&nbsp; <cc1:CalendarExtender id="CEStartDate" runat="server" __designer:wfdid="w27" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate" TargetControlID="txtStartDate">
            </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" __designer:wfdid="w26" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate" TargetControlID="txtEndDate">
            </cc1:CalendarExtender>
</contenttemplate>
                    </asp:UpdatePanel>
        <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    
            <asp:Button ID="btnViewExcel" runat="server" CssClass="Button"
                Text="View Excel" Width="90" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>

