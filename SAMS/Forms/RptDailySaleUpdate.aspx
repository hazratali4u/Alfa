<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptDailySaleUpdate.aspx.cs" Inherits="Forms_RptDailySaleUpdate" Title="SAMS: Daily Sale Update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">

    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="4">
                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="width: 1px" align="left" colspan="1"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left"></td>
                                        <td style="width: 92px; height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="65px" Text="Region" CssClass="lblbox"></asp:Label></strong></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpRegion" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="DrpRegion_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                    </tr>
                                    <tr>
                                        <td align="left"></td>
                                        <td style="width: 92px" align="left">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="65px" Text="Zone" CssClass="lblbox"></asp:Label></strong></td>
                                        <td style="width: 1px" align="left"></td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpZone" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="DrpZone_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                    </tr>
                                    <tr>
                                        <td align="left"></td>
                                        <td style="width: 92px" align="left">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="65px" Text="Territory" CssClass="lblbox"></asp:Label></strong></td>
                                        <td style="width: 1px" align="left"></td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpTerritory" runat="server" Width="200px" CssClass="DropList">
                                            </asp:DropDownList></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                    </tr>
                                    <tr>
                                        <td align="left"></td>
                                        <td style="width: 92px" align="left">
                                            <strong>
                                                <asp:Label ID="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox"></asp:Label></strong></td>
                                        <td style="width: 1px" align="left"></td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left"></td>
                                        <td style="width: 92px; height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" Width="75px" Text="Report Type" CssClass="lblbox"></asp:Label></strong></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:RadioButtonList ID="RbUnitType" runat="server" Width="159px" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">Units</asp:ListItem>
                                                <asp:ListItem>Carton</asp:ListItem>
                                                <asp:ListItem>Kg</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left"></td>
                                        <td style="width: 92px; height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="48px" Text="Date" CssClass="lblbox"></asp:Label></strong></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:TextBox ID="txtDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></td>
                                        <td style="width: 1px; height: 25px" align="left"></td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgBntFromCalc" TargetControlID="txtdate"></cc1:CalendarExtender>
                            &nbsp;&nbsp; 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" Width="90" Text="View PDF" OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" OnClick="btnViewExcel_Click" Width="90" Text="View Excel" CssClass="Button" /></td>
            </tr>
        </table>

    </div>
</asp:Content>

