<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptChequeDetailReport.aspx.cs" Inherits="Forms_RptChequeDetailReport" Title="SAMS: Cheque Detail Report" %>
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
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 25px" align=center colSpan=4><asp:RadioButtonList id="rblReportFor" runat="server" Width="250px" __designer:wfdid="w1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblReportFor_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="0">Cheque Detail</asp:ListItem>
<asp:ListItem Value="1">Customer Credit</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD align=left></TD><TD align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="73px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="WIDTH: 258px; HEIGHT: 25px" align=left>&nbsp; <asp:DropDownList id="drpDistributor" runat="server" Width="240px" CssClass="DropList" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList> </TD></TR><TR><TD align=left></TD><TD align=left>
    <strong><asp:Label id="Label6" runat="server" Width="78px" Text="Principal" __designer:wfdid="w1" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="WIDTH: 258px; HEIGHT: 25px" align=left>&nbsp; <asp:DropDownList id="DrpPrincipal" runat="server" Width="240px" __designer:wfdid="w2" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD colSpan=4><DIV id="divDetail" runat="server"><TABLE><TBODY><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="lblfromLocation" runat="server" Width="94px" Text="Customer Route" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpRoute" runat="server" Width="240px" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="lblNickName" runat="server" Width="79px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpChannelType" runat="server" Width="240px" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label1" runat="server" Width="79px" Text="Customer" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpCustomer" runat="server" Width="240px" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label10" runat="server" Width="80px" Text="Status" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpStatus" runat="server" Width="240px" CssClass="DropList"></asp:DropDownList></TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label3" runat="server" Width="75px" Height="13px" Text="From Date"></asp:Label></strong></TD><TD align=left></TD><TD style="WIDTH: 258px; HEIGHT: 25px" align=left>&nbsp;&nbsp;<asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="Label4" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD align=left></TD><TD style="WIDTH: 258px; HEIGHT: 25px" align=left>&nbsp;&nbsp;<asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px" CssClass="txtBox " MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD align=left>&nbsp;
            <strong><asp:Label id="Label2" runat="server" Width="73px" Text="Search On"></asp:Label></strong></TD><TD align=left>&nbsp;&nbsp;</TD><TD style="WIDTH: 258px" align=left><asp:RadioButtonList id="RbReportFilter" runat="server" Width="250px"><asp:ListItem Selected="True">Recevied Date</asp:ListItem>
<asp:ListItem>Deposit Date</asp:ListItem>
<asp:ListItem>Realized Date</asp:ListItem>
<asp:ListItem>Due Date </asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD align=left></TD><TD align=left></TD><TD align=left></TD><TD style="WIDTH: 258px; HEIGHT: 25px" align=left><%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<cc1:CalendarExtender id="CEStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> </TD></TR></TBODY></TABLE>
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
