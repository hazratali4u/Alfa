<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmMakeVoucher.aspx.cs" Inherits="Forms_frmMakeVoucher" Title="SAMS: Import Voucher" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
<div id="right_data">
    <div >
        <table width="100%">
            <tr>
                <td >
                    <div style="z-index: 101; left: 551px; width: 100px; position: absolute; top: 347px;
                        height: 100px">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                    Width="22px" />
                                Record Update
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE><TBODY>
    <tr>
        <td align="left" style="height: 25px" colspan="2">
            <asp:RadioButtonList ID="RbdList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RbdList_SelectedIndexChanged"
                RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">Post Branch Deposit</asp:ListItem>
                <asp:ListItem Value="0">Import Voucher</asp:ListItem>
            </asp:RadioButtonList></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong> <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Voucher Type" Width="99px"></asp:Label></strong></td>
        <td align="left">
            <asp:DropDownList id="DrpVoucherType" runat="server" Width="235px" CssClass="DropList">
            </asp:DropDownList></td>
        <td style="height: 10px">
        </td>
    </tr>
    <TR><TD style="HEIGHT: 25px; width: 59px;" align="left">
    
    <strong><asp:Label id="Label1" runat="server" Width="58px" Text="Locaton" CssClass="lblbox"></asp:Label></strong></TD><TD align="left"><asp:DropDownList id="DrpDistributor" runat="server" Width="235px" CssClass="DropList"></asp:DropDownList></TD><TD style="HEIGHT: 10px"></TD></TR>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Principal" Width="46px"></asp:Label></strong></td>
        <td align="left">
            <asp:DropDownList id="DrpPrincipal" runat="server" Width="236px" CssClass="DropList">
            </asp:DropDownList></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="Narration" Width="85px"></asp:Label></strong></td>
        <td align="left">
            <asp:TextBox ID="txtAccountDes" runat="server" CssClass="txtBox " onfocus="SearchedCode();"
                Width="230px"></asp:TextBox></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Cheque No" Width="85px"></asp:Label></strong></td>
        <td align="left">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox " onfocus="SearchedCode();"
                Width="180px"></asp:TextBox></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label2" runat="server" Height="13px" Text="From Date" Width="96px"></asp:Label></strong></td>
        <td align="left">
            <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10" onkeyup="BlockStartDateKeyPress()"
                Width="180px"></asp:TextBox>
            <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label6" runat="server" Height="13px" Text="To Date" Width="80px"></asp:Label></strong></td>
        <td align="left">
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10" onkeyup="BlockEndDateKeyPress()"
                Width="180px"></asp:TextBox>
            <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="height: 25px">
            <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                TargetControlID="txtStartDate">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                TargetControlID="txtEndDate">
            </cc1:CalendarExtender>
            <strong><asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Width="175px"></asp:Label></strong></td>
        <td style="height: 10px">
        </td>
    </tr>
</TBODY></TABLE>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
            <asp:FileUpload ID="txtFile" runat="server" Width="339px" /><br />
            <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Import Voucher" CssClass="Button"
                ValidationGroup="vg" Width="131px" /></td>
            </tr>
        </table>
      
       
        </div>
    <div >
        <table width="100%">
            <tr>
                <td align="left" style="width: 100px; height: 173px" valign="top">
                    <table width="300">
                        <tr>
                            <td style="width: 100px">
                                <asp:CheckBox ID="ChbSelect" runat="server" AutoPostBack="True" OnCheckedChanged="ChbSelect_CheckedChanged"
                                    Text="All Select" Width="115px" /></td>
                            <td style="width: 100px">
                                <asp:Button ID="btnView" runat="server" Font-Size="8pt" OnClick="btnView_Click" Text="View" CssClass="Button"
                                    Width="107px" /></td>
                            <td style="width: 100px">
                                </td>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" Font-Size="8pt" OnClick="btnDelete_Click" CssClass="Button"
                                    Text="Cancel Voucher" Width="108px" /></td>
                        </tr>
                    </table>
                    <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                        width: 650px; border-bottom: silver thin inset; height: 251px">
                        <tbody>
                            <tr>
                                <td align="left" colspan="5" valign="top">
                                    <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="750px">
                                        <asp:GridView ID="GrdLedger" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                            OnRowDeleting="GrdLedger_RowDeleting" OnRowEditing="GrdLedger_RowEditing" Width="728px">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Voucher">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChbSelect" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="VOUCHER_NO" HeaderText="Voucher No">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Ledger_date" HeaderText="Voucher Date">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VOUCHER_TYPE_ID" HeaderText="VOUCHER_TYPE_ID">
                                                    <HeaderStyle CssClass="HidePanel" />
                                                    <ItemStyle CssClass="HidePanel" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VOUCHER_DATE" HeaderText="VOUCHER_DATE">
                                                    <HeaderStyle CssClass="HidePanel" />
                                                    <ItemStyle CssClass="HidePanel" />
                                                </asp:BoundField>
                                                <asp:CommandField EditText="Print" HeaderText="Print" ShowEditButton="True">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Edit?');return false;"
                                                            Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="tblhead" HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
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

