<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptTrialBalance.aspx.cs" Inherits="Forms_RptTrialBalance" Title="SAMS: Trial Balance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    
    <script language="JavaScript" type="text/javascript">
    
    function ShowListFrom()
    {
        var strFromCode  = document.getElementById('<%= txtFromAccount.ClientID %>').value;
        if (strFromCode.length  == 0)
        {
            document.getElementById("<%= Panel3.ClientID %>").className = "ShowPanel";
            document.getElementById("<%= LstAccountHead.ClientID %>").focus();
        }
    }
	function ShowListTo()
    {
        var strFromCode  = document.getElementById('<%= txttoAccount.ClientID %>').value;
     
        if (strFromCode.length == 0)
        {
            document.getElementById("<%= Panel3.ClientID %>").className = "ShowPanel";
            document.getElementById("<%= LstAccountHead.ClientID %>").focus();
        }
    }
    function SelectCode(e)
    {
      if(e.keyCode == 13)
      {
        var StrValue = document.getElementById("<%= txtFromAccount.ClientID %>").value;
        if (StrValue.length == 0)
        {
            var str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
            document.getElementById("<%= txtFromAccount.ClientID %>").value =  str;
            document.getElementById("<%= Panel3.ClientID %>").className = "HidePanel";
            document.getElementById("<%= txttoAccount.ClientID %>").focus();
        }
        else 
        {
            var str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
            document.getElementById("<%= txttoAccount.ClientID %>").value =  str;
            document.getElementById("<%= Panel3.ClientID %>").className = "HidePanel";
            document.getElementById("<%= txttoAccount.ClientID %>").focus();
        }
      }
    }
    </script>
    
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD>
</TR>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <asp:CheckBox ID="ChbSelectAll" runat="server" Height="27px" 
                Text="All Accounts" Width="100px" AutoPostBack="True" Checked="True" OnCheckedChanged="ChbSelectAll_CheckedChanged" /></td>
        <td align="left">
        </td>
        <td align="left" style="width: 224px; height: 25px">
            <asp:RadioButtonList ID="rbPosted" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0" Selected="True">Un Posted Ledger</asp:ListItem>
                <asp:ListItem Value="1">Posted Ledger</asp:ListItem>                
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
        <strong> <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="73px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px; width: 224px;">
            <asp:DropDownList id="drpDistributor" runat="server" Width="223px" CssClass="DropList">
    </asp:DropDownList></td>
    </tr>
    <TR><TD align=left style="height: 25px"></TD>
    <td align="left" style="height: 25px">
       <strong><asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Principal" Width="78px"></asp:Label></strong></td>
    <td align="left" style="height: 25px">
    </td>
    <TD style="HEIGHT: 25px; width: 224px;" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="222px" CssClass="DropList">
    </asp:DropDownList></TD>
</TR>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong> <asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="Level" Width="78px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px; width: 224px;">
            <asp:DropDownList id="DrpLevel" runat="server" Width="222px" CssClass="DropList">
                <asp:ListItem Value="4">Level4</asp:ListItem>
                <asp:ListItem Value="3">Level3</asp:ListItem>
                <asp:ListItem Value="2">Level2</asp:ListItem>
                <asp:ListItem Value="1">Level1</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Main Account" Width="78px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="width: 224px; height: 25px">
            <asp:DropDownList id="DrpMainAccount" runat="server" Width="222px" CssClass="DropList">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong> <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="From Account Head"
                Width="108px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="width: 224px; height: 25px">
            <asp:TextBox ID="txtFromAccount" runat="server" CssClass="txtBox" onBlur = "ShowListFrom()"
                Width="215px" MaxLength="10" ReadOnly="True">0000000000</asp:TextBox></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
           <strong> <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="To Account Head" Width="112px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="width: 224px; height: 25px">
            <asp:TextBox ID="txttoAccount" runat="server" CssClass="txtBox" onBlur = "ShowListTo()" 
                Width="215px" MaxLength="10" ReadOnly="True">9999999999</asp:TextBox></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
           <strong> <asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="90px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px; width: 224px;">
            &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10"
                onkeyup="BlockStartDateKeyPress()" Width="150px"></asp:TextBox><asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong> <asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px; width: 224px;">
            &nbsp;<asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10"
                onkeyup="BlockEndDateKeyPress()" Width="150px"></asp:TextBox><asp:ImageButton ID="ibnEndDate"
                    runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" Width="16px" /></td>
    </tr>
    <tr>
        <td align="left">
            </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px; width: 224px;">
            <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
            <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                TargetControlID="txtStartDate">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                TargetControlID="txtEndDate">
            </cc1:CalendarExtender>
            </td>
    </tr>
</TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                    <div style="left: 437px; width: 352px; position: absolute; top: 152px; height: 221px">
                        <asp:Panel ID="Panel3" runat="server" BackColor="Silver" BorderColor="White" BorderStyle="Inset"
                            BorderWidth="1px" CssClass="HidePanel" Height="262px" Width="349px">
                            <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="2" style="border-bottom: black thin solid">
                                            &nbsp;Select A<strong>ccount Head from List</strong></td>
                                        <td align="right" style="border-bottom: black thin solid" valign="top">
                                            &nbsp;<asp:Button ID="Button5" runat="server" BorderStyle="Groove" BorderWidth="1px" Font-Size="8pt"
                                                Height="16px" Text="X" Width="21px" /></td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:ListBox ID="LstAccountHead" runat="server" CssClass="DropList" Height="232px"
                                onkeyup="SelectCode(event)" Width="346px"></asp:ListBox></asp:Panel>
                        &nbsp; &nbsp;&nbsp;
                    </div>
        <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" Width="90" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button"
                Text="View Excel" Width="90" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
         &nbsp;
        
           </div>
</asp:Content>
