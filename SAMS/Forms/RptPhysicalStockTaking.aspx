<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptPhysicalStockTaking.aspx.cs" Inherits="Forms_RptPhysicalStockTaking" Title="SAMS: Physical Stock Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
    
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 1px" align=left colSpan=1></TD></TR>
    <tr>
        <td align="left" style="width: 1px; height: 40px">
        </td>
        <td align="left" style="height: 40px">
            <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Report Type" Width="78px"></asp:Label></strong></td>
        <td align="left" style="width: 1px; height: 40px">
        </td>
        <td align="left" style="width: 203px; height: 40px">
            <asp:RadioButtonList ID="RblType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RblType_SelectedIndexChanged"
                RepeatDirection="Horizontal" Width="157px">
                <asp:ListItem Selected="True">SKU Wise</asp:ListItem>
                <asp:ListItem>Value Wise</asp:ListItem>
            </asp:RadioButtonList></td>
        <td align="left" style="width: 1px; height: 40px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 1px; HEIGHT: 30px" align=left></TD><TD style="HEIGHT: 30px" align=left>
    <strong><asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 30px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 30px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="210px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 30px" align=left></TD></TR><TR><TD style="WIDTH: 1px; height: 33px;" align=left></TD><TD style="height: 33px;" align=left>
    <strong><asp:Label id="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; height: 33px;" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 33px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="210px" CssClass="DropList" AutoPostBack="True">
</asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 33px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
<strong><asp:Label id="Label1" runat="server" Width="59px" Text="Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender1" runat="server" EnableViewState="False" Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate">
                            </cc1:CalendarExtender>&nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="btnViewPDF" runat="server"  CssClass="button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server"  CssClass="button" Text="View Excel"
                        Width="90" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>

