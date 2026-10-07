<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="rptSKUPriceHistory.aspx.cs" Inherits="Forms_rptSKUPriceHistory" Title="SAMS: SKU Price History" %>
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
<TABLE><TBODY><TR><TD align=left colSpan=3><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR><TR><TD align=left colSpan=3></TD></TR><TR><TD style="WIDTH: 95px" align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="70px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList">
    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 95px" align=left>
    <strong><asp:Label id="Label6" runat="server" Width="78px" Text="Principal" CssClass="lblbox"></asp:Label></strong> </TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 95px" align=left>
    <strong><asp:Label id="lblCategory" runat="server" Width="78px" Text="Category" CssClass="lblbox"></asp:Label></strong> </TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpCategory" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 95px" align=left>
    <strong><asp:Label id="Label7" runat="server" Width="78px" Text="SKU" CssClass="lblbox"></asp:Label></strong> </TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpSKU" runat="server" Width="200px" CssClass="DropList"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 95px" align=left>
    <strong><asp:Label id="Label3" runat="server" Width="76px" Height="13px" Text="From Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 95px" align=left>
    <strong><asp:Label id="Label4" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px" CssClass="txtBox " MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 95px" align=left></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %><cc1:CalendarExtender id="CEStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> </TD></TR><TR><TD style="WIDTH: 95px" align=left>
<strong><asp:Label id="Label8" runat="server" Visible="False" Width="78px" Text="Prices" CssClass="lblbox"></asp:Label></strong> </TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrices" runat="server" Visible="False" Width="200px" CssClass="DropList"><asp:ListItem Value="0">All</asp:ListItem>
<asp:ListItem Value="1">Trade Price</asp:ListItem>
<asp:ListItem Value="2">Distributor Price</asp:ListItem>
</asp:DropDownList> </TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
        <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" Width="90" Text="View PDF" OnClick="btnViewPDF_Click" />
        <asp:Button ID="btnViewExcel" runat="server" Width="90" CssClass="Button" Text="View Excel" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
         &nbsp;
        
           </div>
</asp:Content>

