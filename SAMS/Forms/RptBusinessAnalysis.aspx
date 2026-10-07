<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptBusinessAnalysis.aspx.cs" Inherits="Forms_RptBusinessAnalysis" Title="SAMS: Business Analysis Report" %>
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
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR><TR><TD align=left></TD><TD style="WIDTH: 81px" align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="80px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList">
    </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 81px" align=left>
    <strong><asp:Label id="Label6" runat="server" Width="78px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 81px" align=left>
            <strong><asp:Label id="Label3" runat="server" Width="76px" Height="13px" Text="From Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 81px" align=left>
            <strong><asp:Label id="Label4" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px" CssClass="txtBox " MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 81px" align=left></TD><TD align=left></TD><TD style="HEIGHT: 25px" align=left><%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %><cc1:CalendarExtender id="CEStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
            </cc1:CalendarExtender> </TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                    
        <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" Width="90"
                Text="View PDF" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button" Width="90"
                Text="View Excel" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
         
           </div>
</asp:Content>
