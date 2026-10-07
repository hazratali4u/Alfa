<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptChartofAccount.aspx.cs" Inherits="Forms_RptChartofAccount" Title="SAMS: Chart of Account" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 273px; HEIGHT: 68px" id="TABLE1" onclick="return TABLE1_onclick()"><TBODY><TR><TD style="HEIGHT: 15px" align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 1px; HEIGHT: 15px" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD></TR><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 29px" align=left>
    <strong><asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" Text="Account Category"
        Width="114px"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left>
            <asp:DropDownList ID="DrpAccountCategory" runat="server" AutoPostBack="True" CssClass="DropList"
                OnSelectedIndexChanged="DrpAccountCategory_SelectedIndexChanged" Width="265px">
                <asp:ListItem>Balance Sheet Account</asp:ListItem>
                <asp:ListItem>Income Statment Account</asp:ListItem>
            </asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR>
    <tr>
        <td align="left" style="width: 1px; height: 25px">
        </td>
        <td align="left" style="width: 29px; height: 25px">
            <strong><asp:Label id="lbltoLocation" runat="server" Width="114px" Text="Account Type" CssClass="lblbox"></asp:Label></strong></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
        <td align="left" style="width: 203px; height: 25px">
            <asp:DropDownList id="DrpMainType" runat="server" Width="265px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged">
</asp:DropDownList></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
    <strong><asp:Label id="Label1" runat="server" Width="117px" Text="Account Sub Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpSubType" runat="server" Width="266px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpSubType_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR>
    <tr>
        <td align="left" style="width: 1px; height: 25px">
        </td>
        <td align="left" style="width: 29px; height: 25px">
            <strong><asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Account Detail Type"
                Width="116px"></asp:Label></strong></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
        <td align="left" style="width: 203px; height: 25px">
            <asp:DropDownList id="DrpDetailType" runat="server" Width="265px" CssClass="DropList" AutoPostBack="True">
            </asp:DropDownList></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE>&nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button" Text="View Excel"
                        Width="90" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>

