<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptSalesTaxReturn.aspx.cs" Inherits="Forms_RptSalesTaxReturn" Title="SAMS: Sale Tax Return on Sale" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ID" runat="server" ContentPlaceHolderID="cphPage">
<script type="text/javascript">
 jQuery(document).ready(function() {
   $('#<%=rbDetail.ClientID %>').click(function()
  {
    jQuery(".divCustomer").hide(800);
    jQuery(".divCustomerType").show(800);
  });
  $('#<%=rbSummary.ClientID %>').click(function()
  {
    jQuery(".divCustomer").hide(800);
    jQuery(".divCustomerType").show(800);
  });
});
        
        
        function pageLoad() {
        var selectedVal = $('#<%=DrpCustomer.ClientID%> option:selected').attr('value');
            
            if(parseInt(selectedVal) < 0)
            {
                jQuery(".divCustomerType").show(800);
            }
            else
            {
                jQuery(".divCustomerType").hide(800);
            }
            
            var rbIndividual = $('#<%=rbIndividual.ClientID %>');
	    if(rbIndividual.attr("checked") != "undefined" && rbIndividual.attr("checked") == "checked")
	    {
	        jQuery(".divCustomer").show();
	    }
	    else
	    {
	       jQuery(".divCustomer").hide();
	    }
	    
		    $('#<%=DrpCustomer.ClientID%>').change(function() {
            var selectedVal = $('#<%=DrpCustomer.ClientID%> option:selected').attr('value');
            
            if(parseInt(selectedVal) < 0)
            {
                jQuery(".divCustomerType").show(800);
            }
            else
            {
                jQuery(".divCustomerType").hide(800);
            }
        });

        $('#<%=rbIndividual.ClientID %>').click(function()
          {
            var selectedVal = $('#<%=DrpCustomer.ClientID%> option:selected').attr('value');
            
            if(parseInt(selectedVal) < 0)
            {
                jQuery(".divCustomerType").show(800);
            }
            else
            {
                jQuery(".divCustomerType").hide(800);
            }
            jQuery(".divCustomer").show(800);
          });
          
        }
        
    </script>    
    
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                        <table>
                            <tr>
                                <td >&nbsp;</td>
                                <td>
                                    <DIV id="divReportType" class="container2"><asp:RadioButton id="rbDetail" runat="server" Text="Detail Report" GroupName="ReportType" Checked="True"></asp:RadioButton> <asp:RadioButton id="rbSummary" runat="server" Text="Summary Report" GroupName="ReportType"></asp:RadioButton> <asp:RadioButton id="rbIndividual" runat="server" Text="Individual Customer" GroupName="ReportType"></asp:RadioButton> </DIV>
                                </td>
                                <td></td>
                            </tr>
                        </table>                    
                </td>
            </tr>
            <tr>
                <td >
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 90px" align=left>
<strong> <asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox" __designer:wfdid="w37"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w38"></asp:DropDownList> </TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD><TD style="WIDTH: 90px; HEIGHT: 2px" align=left>
<strong><asp:Label id="Label4" runat="server" Width="48px" Text="Principal" CssClass="lblbox" __designer:wfdid="w39"></asp:Label></strong> </TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 2px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w40"></asp:DropDownList> </TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD></TR><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 90px" align=left>
<strong><asp:Label id="Label1" runat="server" Width="59px" Height="9px" Text="From Date" CssClass="lblbox" __designer:wfdid="w41"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10" __designer:wfdid="w42"></asp:TextBox> <asp:ImageButton id="ImgBntFromDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" __designer:wfdid="w43"></asp:ImageButton> </TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 90px; HEIGHT: 25px" align=left>
<strong><asp:Label id="Label3" runat="server" Width="55px" Text="To Date" CssClass="lblbox" __designer:wfdid="w44"></asp:Label></strong> </TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:TextBox id="txtToDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10" __designer:wfdid="w45"></asp:TextBox> <asp:ImageButton id="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" __designer:wfdid="w46"></asp:ImageButton> </TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD align=left colSpan=5>
<DIV id="divCustomer" class="divCustomer"><TABLE width="100%"><TBODY><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
<strong><asp:Label id="lblRoute" runat="server" Width="78px" Font-Size="8pt" Text="Route" CssClass="lblbox" __designer:wfdid="w47"></asp:Label></strong> </TD><TD style="WIDTH: 1px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpRoute" runat="server" Width="200px" Font-Size="8pt" CssClass="DropList" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w48"></asp:DropDownList> </TD></TR><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
<strong><asp:Label id="lblCustomer" runat="server" Width="78px" Font-Size="8pt" Text="Customer" CssClass="lblbox" __designer:wfdid="w49"></asp:Label></strong> </TD><TD style="WIDTH: 1px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px">
<asp:DropDownList id="DrpCustomer" runat="server" Width="200px" Font-Size="8pt" CssClass="DropList" __designer:wfdid="w50"></asp:DropDownList> 
</TD>
</TR>
</TBODY>
</TABLE>
</DIV>

</TD></TR><TR><TD align=left colSpan=5><DIV id="divFilter" class="divCustomerType"><TABLE width="100%"><TBODY><TR><TD align=left><asp:RadioButtonList id="rblCustomerType" runat="server" Width="300px" RepeatDirection="Horizontal" __designer:wfdid="w51"><asp:ListItem Selected="True" Value="-1">All</asp:ListItem>
<asp:ListItem Value="1">Registered</asp:ListItem>
<asp:ListItem Value="0">Unregistered</asp:ListItem>
</asp:RadioButtonList></TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtFromDate" PopupButtonID="ImgBntFromDate" EnableViewState="False" Format="dd-MMM-yyyy" __designer:wfdid="w52"></cc1:CalendarExtender><cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txtToDate" PopupButtonID="ImgBntToDate" EnableViewState="False" Format="dd-MMM-yyyy" __designer:wfdid="w53"></cc1:CalendarExtender> &nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="btnViewPDF" runat="server"  CssClass="Button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button" Text="View Excel"
                        Width="90" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
        
           </div>
</asp:Content>




