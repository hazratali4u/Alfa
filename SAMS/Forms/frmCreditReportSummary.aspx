<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmCreditReportSummary.aspx.cs" Inherits="Forms_frmCreditReportSummary"
    Title="SAMS: Credit Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script type="text/javascript">

        jQuery(document).ready(function () {

            var CheckrbReport = $('#<%=rbCreditReport.ClientID %>');
            if (CheckrbReport.attr("checked") != "undefined" && CheckrbReport.attr("checked") == "checked") {
                jQuery(".container2").show();
            }
            else {
                jQuery(".container2").hide();
            }
            //toggle the componenet with class msg_body
            $('#<%=rbCreditReport.ClientID %>').click(function () {
                jQuery(".container2").show(800);
            });
            $('#<%=rbCreditLimit.ClientID %>').click(function () {
                jQuery(".container2").hide(800);
            });
        });
    </script>
    <div id="right_data">
        <table>
            <tr>
                <td>
                    <asp:RadioButton ID="rbCreditReport" runat="server" Text="Credit Report" Checked="True"
                        GroupName="ReportType" OnCheckedChanged="rbCreditReport_CheckedChanged"></asp:RadioButton>
                    <asp:RadioButton ID="rbCreditLimit" runat="server" Text="Credit Limit" GroupName="ReportType"
                        OnCheckedChanged="rbCreditLimit_CheckedChanged"></asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divUpdatePanel">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="drpDistributor" runat="server" Width="240px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblPrincipal" runat="server" Width="78px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpPrincipal" runat="server" Width="240px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblfromLocation" runat="server" Width="94px" Text="Customer Route"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpRoute" runat="server" Width="240px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <strong>
                                                    <asp:Label ID="lblOrderBooker" runat="server" Width="79px" Text="Order Booker" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpOrderBooker" runat="server" Width="240px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblSaleForce" runat="server" Width="79px" Text="Sale Force"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="ddlSaleForce" runat="server" Width="240px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblNickName" runat="server" Width="79px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="drpChannelType" runat="server" Width="240px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblCustomer" runat="server" Width="79px" Text="Customer" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpCustomer" runat="server" Width="240px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblTag" runat="server" Width="79px" Text="Credit Type"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="ddlCreditType" runat="server" Width="240px">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                    <asp:ListItem Value="1">Bill</asp:ListItem>
                                                    <asp:ListItem Value="2">Cheque</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="79px" Text="Tag Type"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="ddlTagType" runat="server" Width="240px">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                    <asp:ListItem Value="600">Normal Credit</asp:ListItem>
                                                    <asp:ListItem Value="601">Income Tax Challan</asp:ListItem>
                                                    <asp:ListItem Value="602">Shelf Rent</asp:ListItem>
                                                    <asp:ListItem Value="645">Disputed Credit</asp:ListItem>


                                                      <asp:ListItem Value="728">Wholesale Incentive</asp:ListItem>
                                                     <asp:ListItem Value="729">W/S Loyalty Program</asp:ListItem>
                                                     <asp:ListItem Value="730">Key Account Target Incentive</asp:ListItem>
                                                     <asp:ListItem Value="731">Retail Media Gold</asp:ListItem>
                                                     <asp:ListItem Value="732">Retail Media Sales</asp:ListItem>
                                                     <asp:ListItem Value="733">Retail Media Platinum</asp:ListItem>
                                                     <asp:ListItem Value="734">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblFromDate" runat="server" Width="76px" Height="13px" Text="From Date"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                &nbsp;
                                                <asp:TextBox ID="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server"
                                                    Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                                <asp:ImageButton ID="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                                </asp:ImageButton>
                                                <div style="z-index: 101; left: 284px; width: 100px; position: absolute; top: 245px;
                                                    height: 100px">
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                            <ProgressTemplate>
                                                                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Width="31px" Height="33px"
                                                                    ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </asp:Panel>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblDateTo" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                &nbsp;
                                                <asp:TextBox ID="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="150px"
                                                    CssClass="txtBox " MaxLength="10"></asp:TextBox>
                                                <asp:ImageButton ID="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                                </asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                                <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                                <cc1:CalendarExtender ID="CEStartDate" runat="server" TargetControlID="txtStartDate"
                                                    PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                                <cc1:CalendarExtender ID="CEEndDate" runat="server" TargetControlID="txtEndDate"
                                                    PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divFilter" class="container2">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label ID="lblSort" runat="server" Width="78px" Text="Sort By" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="DrpSort" runat="server" Width="240px" CssClass="DropList">
                                            <asp:ListItem Value="0">Customer</asp:ListItem>
                                            <asp:ListItem Value="1">Bill Date</asp:ListItem>
                                            <%--<asp:ListItem Value="2">Closing Credit</asp:ListItem>--%>
                                            <asp:ListItem Value="3">Allow Days</asp:ListItem>
                                            <asp:ListItem Value="4">Credit Days</asp:ListItem>
                                            <asp:ListItem Value="5">Over Age</asp:ListItem>
                                            <asp:ListItem Value="6">Sale Force</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label ID="lblSortOrder" runat="server" Width="78px" Text="Sort Order" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rbtSortOrder" runat="server" Width="192px" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Text="Ascending"></asp:ListItem>
                                            <asp:ListItem Text="Descending"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnPDF" runat="server" CssClass="Button" Text="View PDF" Width="90"
                        OnClick="btnPDF_Click" />
                    <asp:Button ID="btnExcel" runat="server" CssClass="Button" Text="View Excel" Width="90"
                        OnClick="btnExcel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
