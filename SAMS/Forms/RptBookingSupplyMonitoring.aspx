<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptBookingSupplyMonitoring.aspx.cs" Inherits="Forms_RptBookingSupplyMonitoring" MasterPageFile ="~/Forms/PageMaster.master" Title="SAMS: Booking vs Execution" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
    
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 89px" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 19px; HEIGHT: 5px" align=left rowSpan=1></TD><TD style="WIDTH: 19px; HEIGHT: 5px" align=left rowSpan=1>
<strong><asp:Label id="lblType" runat="server" Width="70px" Text="Report Type" __designer:wfdid="w2" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 19px; HEIGHT: 5px" align=left rowSpan=1></TD><TD style="WIDTH: 19px; HEIGHT: 5px" align=left rowSpan=1><asp:DropDownList id="DrpReportType" runat="server" Width="210px" __designer:wfdid="w3" CssClass="DropList" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0">Date Wise</asp:ListItem>
<asp:ListItem Value="1">SKU Wise (Units)</asp:ListItem>
<asp:ListItem Value="2">SKU Wise (Cartons)</asp:ListItem>
<asp:ListItem Value="3">SKU Wise (Values)</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 19px; HEIGHT: 5px" align=left rowSpan=1></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 19px; HEIGHT: 1px" align=left></TD><TD style="HEIGHT: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 89px; HEIGHT: 1px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 19px; HEIGHT: 1px" align=left>
<strong><asp:Label id="Label2" runat="server" Width="70px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 1px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="210px" CssClass="DropList" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 89px; HEIGHT: 1px" align=left></TD></TR><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 19px" align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="70px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="210px" CssClass="DropList" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList></TD><TD style="WIDTH: 89px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 19px; HEIGHT: 25px" align=left>
<strong><asp:Label id="lblSaleForce" runat="server" Width="70px" Text="Orderbooker" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="drpSaleForce" runat="server" Width="210px" CssClass="DropList"></asp:DropDownList></TD><TD style="WIDTH: 89px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 19px; HEIGHT: 25px" align=left>
<strong><asp:Label id="lblDM" runat="server" Width="70px" Text="Sale Force" __designer:wfdid="w1" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpDeliveryMan" runat="server" Width="210px" __designer:wfdid="w3" CssClass="DropList"></asp:DropDownList></TD><TD style="WIDTH: 89px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 19px; HEIGHT: 25px" align=left>
<strong><asp:Label id="Label1" runat="server" Width="70px" Text="From Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 89px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 19px; HEIGHT: 25px" align=left>
<strong><asp:Label id="Label3" runat="server" Width="70px" Text="To  Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtToDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 89px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtFromDate" PopupButtonID="ImgBntFromCalc" Format="dd-MMM-yyyy" EnableViewState="False">
                            </cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txtToDate" PopupButtonID="ImgToDate" Format="dd-MMM-yyyy" EnableViewState="False">
                            </cc1:CalendarExtender> 
</contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="Button" Text="View Excel"
                        Width="90" OnClick="btnViewExcel" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>