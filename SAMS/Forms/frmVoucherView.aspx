<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmVoucherView.aspx.cs" Inherits="Forms_frmVoucherView" Title="SAMS: Voucher View" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
<div id="right_data">
     <div>
        <table width="100%">
            <tr>
                <td>
                    <table>
                                <tr>
                                    <td align="left" style="width: 100px">
                                        <strong><asp:Label id="lbltoLocation" runat="server" Width="67px" Text="Location" CssClass="lblbox"></asp:Label></strong></td>
                                    <td style="width: 100px">
        <asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList"></asp:DropDownList></td>
                                    <td style="height: 25px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100px">
                                        <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Voucher Type" Width="104px"></asp:Label></strong></td>
                                    <td style="width: 100px">
                                        <asp:DropDownList id="DrpVoucherType" runat="server" Width="200px" CssClass="DropList">
                                        </asp:DropDownList></td>
                                    <td style="height: 25px;">
                                    </td>
                                </tr>
                        <tr>
                            <td align="left" style="width: 100px" valign="middle">
                                <strong><asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Principal" Width="104px"></asp:Label></strong></td>
                            <td align="left" style="width: 100px">
                                <asp:DropDownList ID="DrpPrincipal" runat="server" CssClass="DropList" Width="200px">
                                </asp:DropDownList></td>
                            <td align="left" style="height: 25px">
                            </td>
                        </tr>
                                <tr>
                                    <td align="left" style="width: 100px" valign="middle">
                                        <strong><asp:Label ID="Label4" runat="server" Height="13px" Text="From Date" Width="70px"></asp:Label></strong></td>
                                    <td style="width: 100px" align="left">
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10" onkeyup="BlockStartDateKeyPress()"
                                            Width="190px"></asp:TextBox></td>
                                    <td align="left" style="height: 25px;">
                                        <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                            Width="16px" /></td>
                                </tr>
                        <tr>
                            <td align="left" style="width: 100px" valign="middle">
                                <strong><asp:Label ID="Label5" runat="server" Height="13px" Text="To Date" Width="80px"></asp:Label></strong></td>
                            <td align="left" style="width: 100px">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10" onkeyup="BlockEndDateKeyPress()"
                                    Width="191px"></asp:TextBox></td>
                            <td align="left" style="height: 25px">
                                <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                    Width="16px" /></td>
                        </tr>
                                <tr>
                                    <td align="left" style="width: 100px; height: 12px;" valign="top">
                                        &nbsp;<strong><asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Status " Width="90px"></asp:Label></strong></td>
                                    <td style="width: 100px; height: 12px;" align="left">
                                        <asp:RadioButtonList ID="RbdList" runat="server" Width="150px" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="FALSE">Un Post Voucher</asp:ListItem>
                                            <asp:ListItem Value="TRUE">Post Voucher</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td align="left" style="height: 25px;">
                                    </td>
                                </tr>
                        <tr>
                            <td align="left" style="width: 100px; height: 12px" valign="top">
                            </td>
                            <td align="left" style="width: 100px; height: 12px">
                    <asp:Button ID="btnView" runat="server" CssClass="Button" OnClick="btnView_Click" Text="View"
                        Width="90" /></td>
                            <td align="left" style="height: 25px">
                            </td>
                        </tr>
                            </table>
                    <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                        TargetControlID="txtStartDate">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                        TargetControlID="txtEndDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
        </table>
        
           </div>
    <div >
    <table width="100%">
        <tr>
            <td>
                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                            width: 650px; border-bottom: silver thin inset; height: 251px;">
                            <tbody>
                                <tr>
                                    <td align="left" colspan="5" style="height: 21px">
                                        <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" Width="750px">
                                            <asp:GridView ID="GrdLedger" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                Width="728px" OnRowEditing="GrdLedger_RowEditing">
                                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                    PreviousPageText="Previous" />
                                                <Columns>
                                                    <asp:BoundField DataField="VOUCHER_NO" HeaderText="Voucher No">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Ledger_date" HeaderText="Voucher Date" >
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" >
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VOUCHER_TYPE_ID" HeaderText="VOUCHER_TYPE_ID" >
                                                        <HeaderStyle CssClass="HidePanel" />
                                                        <ItemStyle CssClass="HidePanel" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VOUCHER_DATE" HeaderText="VOUCHER_DATE">
                                                        <HeaderStyle CssClass="HidePanel" />
                                                        <ItemStyle CssClass="HidePanel" />
                                                    </asp:BoundField>
                                                    <asp:CommandField HeaderText="Print" ShowEditButton="True" EditText="Print">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:CommandField>
                                                </Columns>
                                                <HeaderStyle CssClass="tblhead" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>                
            </td>
        </tr>
    </table>
    </div>
    </div>
</asp:Content>
