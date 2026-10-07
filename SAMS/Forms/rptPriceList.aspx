<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="rptPriceList.aspx.cs" Inherits="Forms_rptPriceList" Title="SAMS: SKU Price List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 273px; HEIGHT: 68px" id="TABLE1" onclick="return TABLE1_onclick()"><TBODY><TR><TD style="HEIGHT: 15px" align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 1px; HEIGHT: 15px" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD></TR><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 29px" align=left>
    <strong><asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" Text="Location"
        Width="60px"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left>
    <asp:DropDownList ID="DrpDistributor" runat="server" AutoPostBack="True" CssClass="DropList" Width="200px">
    </asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR>
    <tr>
        <td align="left" style="width: 1px; height: 25px">
        </td>
        <td align="left" style="width: 29px; height: 25px">
            <strong><asp:Label id="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox"></asp:Label></strong></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
        <td align="left" style="width: 203px; height: 25px">
            <asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged">
</asp:DropDownList></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
    <strong><asp:Label id="Label1" runat="server" Width="59px" Text="Catagory" CssClass="lblbox"></asp:Label></strong><br />
</TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpCatagory" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE>&nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>                 &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" Text="View Excel" CssClass="Button"
                        OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>

