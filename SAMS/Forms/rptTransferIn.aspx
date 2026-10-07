<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptTransferIn.aspx.cs" Inherits="Forms_rptTransferIn"  MasterPageFile ="~/Forms/PageMaster.master" Title="SAMS: Transfer In/Out Report"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
    
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 1px" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 1px" align=left><asp:RadioButtonList id="RbTransferType" runat="server" Width="199px" Height="20px" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="Transfer In">Transfer In</asp:ListItem>
<asp:ListItem>Transfer Out</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD></TR>
    <tr>
        <td align="left" style="width: 1px; height: 1px">
        </td>
        <td align="left" style="width: 29px; height: 1px">
            <strong> <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Report In" Width="70px"></asp:Label></strong></td>
        <td align="left" style="width: 1px; height: 1px">
        </td>
        <td align="left" style="width: 203px; height: 1px">
            <asp:DropDownList id="DrpReportType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpReportType_SelectedIndexChanged">
                <asp:ListItem>Quantity</asp:ListItem>
                <asp:ListItem>Carton</asp:ListItem>
                <asp:ListItem>Value</asp:ListItem>
            </asp:DropDownList></td>
        <td align="left" style="width: 1px; height: 1px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 29px" align=left>
    <strong><asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
    <strong><asp:Label id="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
    <strong><asp:Label id="Label1" runat="server" Width="59px" Text="From Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
    <strong><asp:Label id="Label3" runat="server" Width="54px" Text="To  Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtToDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate"></cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgToDate" TargetControlID="txtToDate"></cc1:CalendarExtender>&nbsp;&nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>                 
                    <br />
                    <asp:Button ID="btnViewPDF" runat="server" Width="90" Text="View PDF"  OnClick="btnViewPDF_Click" CssClass="button" />
                    <asp:Button ID="btnViewExcel" runat="server" Text="View Excel" Width="90" OnClick="btnViewExcel_Click" CssClass="button" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>
