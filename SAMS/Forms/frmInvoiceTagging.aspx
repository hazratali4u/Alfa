<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmInvoiceTagging.aspx.cs" Inherits="Forms_frmInvoiceTagging" Title="SAMS: Credit Tagging Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="lbltoLocation" runat="server" Width="67px" Text="Location" CssClass="lblbox"></asp:Label></strong> </td>
                                            <td style="width: 100px">
                                                <asp:DropDownList ID="drpDistributor" runat="server" Width="250px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged"></asp:DropDownList></td>
                                            <td style="height: 25px"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" valign="middle" align="left">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Width="67px" Text="Principal" CssClass="lblbox"></asp:Label></strong> </td>
                                            <td style="width: 100px" align="left">
                                                <asp:DropDownList ID="DrpPrincipal" runat="server" Width="250px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td style="height: 25px" align="left"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 12px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="58px" Text="Route      " CssClass="lblbox" __designer:wfdid="w1"></asp:Label></strong> </td>
                                            <td style="width: 100px; height: 12px" align="left">
                                                <asp:DropDownList ID="DrpRoute" runat="server" Width="249px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" __designer:wfdid="w2"></asp:DropDownList></td>
                                            <td style="height: 25px" align="left"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 12px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Width="55px" Text="Customer" CssClass="lblbox"></asp:Label></strong> </td>
                                            <td style="width: 100px; height: 12px" align="left">
                                                <asp:DropDownList ID="DrpCustomer" runat="server" Width="250px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpCustomer_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td style="height: 25px" align="left"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 12px" valign="top" align="left"></td>
                                            <td style="width: 100px; height: 12px" align="left">
                                                <asp:Button ID="btnView" OnClick="btnView_Click" runat="server" Width="107px" Font-Size="8pt" Text="Save" CssClass="Button" />
                                            </td>
                                            <td style="height: 25px" align="left"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>

        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset; width: 650px; border-bottom: silver thin inset; height: 251px;">
                            <tbody>
                                <tr>
                                    <td align="left" colspan="5" style="height: 21px">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel1" runat="server" Width="712px" Height="250px" ScrollBars="Vertical">
                                                    <asp:GridView ID="GrdCredit" runat="server" Width="98%" ForeColor="SteelBlue" CssClass="gridRow2" HorizontalAlign="Center" BorderColor="White" BackColor="White" AutoGenerateColumns="False" DataKeyNames="SALE_INVOICE_ID">
                                                        <PagerSettings PreviousPageText="Previous" Mode="NextPrevious" LastPageText="" FirstPageText="" NextPageText="Next"></PagerSettings>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Select">
                                                                <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChbIsAssigned" runat="server" Width="41px" __designer:wfdid="w1"></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="MANUAL_INVOICE_ID" HeaderText="Invoice No">
                                                                <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Invoice Date">
                                                                <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataFormatString="{0:F2}" DataField="CURRENT_CREDIT_AMOUNT" HeaderText="Credit Amount">
                                                                <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Credit Type">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="DrpCreditType" runat="server" Width="130px">
                                                                        <%--<asp:ListItem Value="600">Normal Credit</asp:ListItem>--%>
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
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtAmount" runat="server" Width="100px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remarks">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" Width="169px" CssClass="txtBox" __designer:wfdid="w1"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="tblhead" VerticalAlign="Middle"></HeaderStyle>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
