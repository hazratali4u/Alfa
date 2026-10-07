<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmPromotionStep2.aspx.cs" inherits="Forms_frmPromotionStep2" title="SAMS: Promotion Wizard Step 1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{
			var str;
			
			str = document.getElementById('<%=txtStartDate.ClientID%>').value;
			if(str == null || str.length == 0)
			{
				alert('Must select Start Date');
				return false;
			}
			str = document.getElementById('<%=txtEndDate.ClientID%>').value;
			if(str == null || str.length == 0)
			{
				alert('Must select End Date');
				return false;
			}
			str = document.getElementById('<%=txtPromotionName.ClientID%>').value;
			if(str == null || str.length == 0)
			{
				alert('Must enter Promotion Name');
				return false;
			}
		return true;	  		
	}
	function BlockEndDateKeyPress()
	{
	    document.getElementById('<%=txtEndDate.ClientID%>').value = '';
	    alert('Click Clender Button Select Date');
	}
	function BlockStartDateKeyPress()
	{
	    document.getElementById('<%=txtStartDate.ClientID%>').value = '';
	    alert('Click Clender Button Select Date');
	}
    </script>
    <div id="right_data">
    <table width="100%">
        <tr>
        <td>
        <h2>Promotion Wizard Step 1</h2>
        </td>
        </tr>
        <tr>
            <td>
              
<TABLE><TBODY><TR><TD style="WIDTH: 121px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 121px; HEIGHT: 22px" align=left>
    <asp:RadioButton ID="rBtnExisting" runat="server" AutoPostBack="True" Checked="True"
        Font-Names="Verdana" Font-Size="8pt" OnCheckedChanged="rBtnExisting_CheckedChanged"
        Text="Existing" Width="72px" /></TD><TD align="left"><asp:DropDownList id="drpExisting" runat="server" Width="254px" CssClass="DropList">
                            </asp:DropDownList></TD><TD></TD></TR>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
            <asp:RadioButton ID="rBtnNew" runat="server" AutoPostBack="True" Font-Names="Verdana"
                Font-Size="8pt" OnCheckedChanged="rBtnNew_CheckedChanged" Text="New" Width="72px" /></td>
        <td align="left">
            <asp:TextBox ID="txtNew" runat="server" CssClass="txtBox" Enabled="False"
                Width="250px" MaxLength="50"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
           <strong> <asp:Label ID="Label4" runat="server" Height="13px" Text="Promotion For" Width="112px"></asp:Label></strong></td>
        <td align="left">
            <asp:RadioButtonList ID="rdbbtncheck" runat="server" Font-Names="Verdana" Font-Size="9pt"
                RepeatDirection="Horizontal" Width="231px">
                <asp:ListItem Value="0                                              ">Primary Sale                                                </asp:ListItem>
                <asp:ListItem Selected="True" Value="1">Secondary Sale</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
            <strong><asp:Label ID="Label5" runat="server" Height="13px" Text="Principal" Width="112px"></asp:Label></strong></td>
        <td align="left">
            <asp:DropDownList id="DrpPrincipal" runat="server" Width="254px" CssClass="DropList">
            </asp:DropDownList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
            <strong><asp:Label ID="Label3" runat="server" Height="13px" Text="Promotion" Width="90px"></asp:Label></strong></td>
        <td align="left">
            <asp:TextBox ID="txtPromotionName" runat="server" CssClass="txtBox" Width="250px" MaxLength="50"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
        </td>
        <td align="left">
            <asp:TextBox ID="txtPromotionDescription" runat="server" CssClass="txtBox " Height="64px"
                MaxLength="255" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
            </td>
        <td align="left">
            <asp:CheckBox ID="chkClaimable" runat="server" Font-Names="Verdana" Font-Size="8pt"
                Text="Is Claimable Discount" Width="172px" /></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 121px; height: 22px">
            </td>
        <td align="left" colspan="2">
            <asp:RadioButtonList ID="chkScheme" runat="server" Font-Names="Verdana" Font-Size="9pt"
                RepeatDirection="Horizontal" Width="250px">
                <asp:ListItem Selected="True" Value="0">Standard Discount</asp:ListItem>
                <asp:ListItem Value="1">Scheme</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <TR><TD align=left style="width: 121px">
    <strong><asp:Label id="c" runat="server" Width="90px" Height="13px" Text="From Date"></asp:Label></strong></TD><TD align=left>
        &nbsp;<asp:TextBox ID="txtStartDate" runat="server" onkeyup  = "BlockStartDateKeyPress()" CssClass="txtBox" MaxLength="10"
            Width="150px"></asp:TextBox>
        <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" Width="16px" /></TD><TD>
        </TD></TR><TR><TD align=left style="width: 121px">
        <strong><asp:Label id="Label2" runat="server" Width="90px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD align=left>
        &nbsp;<asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " onkeyup = "BlockEndDateKeyPress()" MaxLength="10" Width="150px"></asp:TextBox>
        <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" Width="16px" /></TD><TD>
        </TD></TR><TR><TD style="WIDTH: 121px"></TD><TD style="WIDTH: 100px">
        <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
            TargetControlID="txtStartDate">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
            TargetControlID="txtEndDate">
        </cc1:CalendarExtender>
    </TD><TD style="WIDTH: 100px"></TD></TR><TR><TD align=left colSpan=3>&nbsp;
    <asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="90" Text="Cancel" CssClass="Button" /> 
    <asp:Button id="btnNext" runat="server" Width="90" Text="Next" OnClick="btnNext_Click" CssClass="Button" /> </TD></TR></TBODY></TABLE>
            </td>
        </tr>
    </table>
    </div> 
</asp:Content>

