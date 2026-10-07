<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSchemeDiscountReport.aspx.cs" Inherits="Forms_frmSchemeDiscountReport"
    Title="SAMS: Scheme Discount Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function ChOrderBookerListSelect() {
            var chkBoxList = document.getElementById('<%= ChbOrderBookerList.ClientID %>');
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            if (chkBox.checked == true) {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = true;
                }
            }
            else {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = false;
                }
            }

        }

        function UnCheckOrderBookerAll() {
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            var chkBoxList = document.getElementById('<%= ChbOrderBookerList.ClientID %>');
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            var count = 0;
            for (var i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].checked == false) {
                    count += 1;
                }
            }
            if (count > 0) {
                chkBox.checked = false;
            }
            else {
                chkBox.checked = true;
            }
        }

    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Width="82px" Text="Scheme" Visible="false"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RbReportType" runat="server" OnSelectedIndexChanged="RbReportType_SelectedIndexChanged"
                                            AutoPostBack="True" RepeatDirection="Horizontal" Visible="false">
                                            <asp:ListItem Selected="True">Route Wise</asp:ListItem>
                                            <asp:ListItem>Outlet Wise</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </td>
                                        <td></td>
                                        <td></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="73px"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td style="height: 25px" align="left">
                                        <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack ="true" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="70px"></asp:Label></strong>
                                    </td>
                                    <td align="left" style="height: 25px">
                                        &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10"
                                            Width="150px"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                            Width="16px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Principal" Width="78px"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack ="true" OnSelectedIndexChanged ="DrpPrincipal_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="80px"></asp:Label></strong>
                                    </td>
                                    <td align="left" style="height: 25px">
                                        &nbsp;<asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10"
                                            Width="150px"></asp:TextBox>
                                        <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                            Width="16px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label ID="lblfromLocation" runat="server" Width="94px" Text="Customer Route"
                                                CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged ="DrpRoute_SelectedIndexChanged"
                                            CssClass="DropList">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    <td></td></td>
                                </tr>
                                <tr>
                                
                                
                                <td>
                                </td>
                                <td>  <strong>
                                            <asp:Label ID="Label2" runat="server" Width="94px" Text="Order booker"
                                                CssClass="lblbox"></asp:Label></strong></td>  <td></td>
                                 <td align="left" rowspan="1" style="width: 100px">
                                        <asp:CheckBox ID="ChbSelectAll" runat="server" CssClass="DropList" Font-Size="8pt"
                                            onclick="ChOrderBookerListSelect()" Text="Select All" Width="75px" />
                                    </td>
                                <td>
                                </td>
                                <td></td>
                                 <td>
                                </td>
                                <td></td>
                                
                                </tr>
                                <tr>
                                    <td>
                                    </td>  <td></td>  <td></td>
                                    <td rowspan="1" align="left">
                                        <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="200px" ScrollBars="Vertical" Width="200px" BackColor="White">
                                            <asp:CheckBoxList ID="ChbOrderBookerList" runat="server" onclick="UnCheckOrderBookerAll()">
                                            </asp:CheckBoxList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                        <script runat="server">

                                           
                                        </script>
                                        <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                                            TargetControlID="txtStartDate">
                                        </cc1:CalendarExtender>
                                        <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                                            TargetControlID="txtEndDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" Width="90" Text="View PDF"
                        OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" Width="90" Text="View Excel" OnClick="btnViewExcel_Click"
                        CssClass="Button" />
                </td>
            </tr>
        </table>
        &nbsp;
    </div>
</asp:Content>
