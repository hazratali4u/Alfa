<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptInvestmentCash.aspx.cs" Inherits="Forms_RptInvestmentCash" Title="SAMS: Investment & Cash Flow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR>

<TR>
<TD align=left></TD>
<TD align=left>
<strong><asp:Label id="lblLocation" runat="server" Width="76px" Height="13px" Text="Location"></asp:Label></strong></TD>
<TD align=left></TD>
<TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></TD>
</TR>
<TR>
<TD align=left></TD>
<TD align=left>
<strong><asp:Label id="lblPrincipal" runat="server" Width="76px" Height="13px" Text="Principal"></asp:Label></strong></TD>
<TD align=left></TD>
<TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></TD>
</TR>
<TR>
<TD align=left></TD>
<TD align=left>
<strong><asp:Label id="Label3" runat="server" Width="76px" Height="13px" Text="From Date"></asp:Label></strong></TD>
<TD align=left></TD>
<TD style="HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD>
</TR>
<TR><TD align=left></TD><TD align=left>
<strong><asp:Label id="Label4" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px" CssClass="txtBox " MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD align=left></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %><cc1:CalendarExtender id="CEStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> </TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>

                    <asp:Button ID="btnPDF" runat="server" Text="View PDF" CssClass="Button" Width="90" OnClick="btnPDF_Click"/>
                    <asp:Button ID="btnExcel" runat="server" Text="View Excel" CssClass="Button" Width="90" OnClick="btnExcel_Click"/>
                </td>
            </tr>
        </table>
         &nbsp;
        
           </div>
</asp:Content>

