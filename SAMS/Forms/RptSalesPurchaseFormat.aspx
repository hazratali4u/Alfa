<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptSalesPurchaseFormat.aspx.cs" Inherits="Forms_RptSalesPurchaseFormat" Title="SAMS: Sales Purchase Format" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
<div id="right_data">
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE cellSpacing=4><TBODY><TR><TD style="WIDTH: 40%" align=left colSpan=2>
<strong><asp:Label id="Label30" runat="server" Width="60px" Text="Report For" CssClass="lblbox" __designer:wfdid="w47"></asp:Label></strong></TD><TD style="WIDTH: 60%" align=left><asp:DropDownList id="DrpReportType" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w48"><asp:ListItem Value="0">Sales Format</asp:ListItem>
<asp:ListItem Value="1">Purchase Format</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" align=left>
<strong><asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox" __designer:wfdid="w49"></asp:Label></strong> </TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 75%" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w50"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 20%" align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox" __designer:wfdid="w51"></asp:Label></strong> </TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 75%" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w52" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 36px" align=left>
<strong><asp:Label id="Label3" runat="server" Width="60px" Text="GST Type" CssClass="lblbox" __designer:wfdid="w53"></asp:Label></strong></TD><TD style="WIDTH: 5%; HEIGHT: 36px"></TD><TD style="WIDTH: 75%; HEIGHT: 36px" align=left><asp:RadioButtonList id="rblCustomerType" runat="server" RepeatDirection="Horizontal" __designer:wfdid="w54">
    <asp:ListItem Selected="True" Value="-1">All</asp:ListItem>
    <asp:ListItem Value="1">Registered</asp:ListItem>
    <asp:ListItem Value="0">Unregistered</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD style="WIDTH: 20%" align=left>
<strong><asp:Label id="Label1" runat="server" Width="59px" Text="Date From" CssClass="lblbox" __designer:wfdid="w55"></asp:Label></strong> </TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 75%" align=left><asp:TextBox id="txtFromDate" runat="server" Width="100px" CssClass="txtBox" __designer:wfdid="w56" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromCalc" runat="server" __designer:wfdid="w57" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton> </TD></TR><TR><TD style="WIDTH: 20%" align=left>
<strong><asp:Label id="Label4" runat="server" Width="59px" Text="Date To" CssClass="lblbox" __designer:wfdid="w58"></asp:Label></strong> </TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 75%" align=left><asp:TextBox id="txtToDate" runat="server" Width="100px" CssClass="txtBox" __designer:wfdid="w59" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntToCalc" runat="server" __designer:wfdid="w60" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton> </TD></TR><TR><TD style="WIDTH: 100%" colSpan=3><cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w61" EnableViewState="False" Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate"></cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w62" EnableViewState="False" Format="dd-MMM-yyyy" PopupButtonID="ImgBntToCalc" TargetControlID="txtToDate"></cc1:CalendarExtender> </TD></TR></TBODY></TABLE>
</contenttemplate>
                    
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button id="btnViewPDF" onclick="btnViewPDF_Click" runat="server" Width="90"  CssClass="Button" Text="View PDF"></asp:Button> 
                <asp:Button id="btnViewExcel" onclick="btnViewExcel_Click" runat="server" Width="90" CssClass="Button" Text="View Excel"></asp:Button> 

            </td>
        </tr>    
    </table>
    </div>      
</asp:Content>
