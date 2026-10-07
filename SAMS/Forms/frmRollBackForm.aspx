<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmRollBackForm.aspx.cs" Inherits="Forms_frmRollBackForm" Title="SAMS: Rollback Transaction" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
     <div >
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 534px; width: 100px; position: absolute; top: 256px;
                        height: 100px">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="27px" />
                                    Wait Update.......
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                </td>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TR><TD align=left>
<strong><asp:Label id="Label2" runat="server" Width="104px" Text="Transaction Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpDocumentType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpDocumentType_SelectedIndexChanged"><asp:ListItem Value="0">Order Entry</asp:ListItem>
<asp:ListItem Value="1">Sale Invoice</asp:ListItem>
    <asp:ListItem Value="2">Sale Return</asp:ListItem>
    <asp:ListItem Value="3">Realized Cheque</asp:ListItem>
</asp:DropDownList>&nbsp;</TD></TR><TR><TD align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left>
<strong><asp:Label id="Label1" runat="server" Width="94px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left style="height: 25px">
<strong><asp:Label id="Label6" runat="server" Width="94px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpOrderBooker" runat="server" Width="200px" CssClass="DropList"></asp:DropDownList></TD></TR>
    <tr>
        <td align="left">
            <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Legend" Width="94px"></asp:Label></strong></td>
        <td align="left" style="height: 25px"><asp:DropDownList id="DrpLenged" runat="server" Width="200px" CssClass="DropList">
        </asp:DropDownList></td>
    </tr>
    <TR><TD align=right><asp:Button id="btnGetOrder" onclick="btnGetOrder_Click" runat="server" Width="100px" Font-Size="8pt" Text="Get Data" CssClass="Button" /></TD><TD style="HEIGHT: 25px" align=left>
                                        <asp:Button ID="btnPost" runat="server" Font-Size="8pt" Text="Rollback"
                                            Width="128px" OnClick="btnPost_Click" CssClass="Button" /></TD></TR>
    <tr>
        <td align="right" colspan="2">
            &nbsp;</td>
    </tr>
</TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
            </tr>
        </table>
        
           </div>
    <div >
    <table width="100%">
        <tr>
            <td >
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <ContentTemplate>
<TABLE style="BORDER-RIGHT: silver thin inset; BORDER-TOP: silver thin inset; BORDER-LEFT: silver thin inset; WIDTH: 650px; BORDER-BOTTOM: silver thin inset"><TBODY><TR><TD style="HEIGHT: 21px" align=left colSpan=5><asp:Panel id="Panel1" runat="server" Width="710px" Height="250px" ScrollBars="Vertical"><asp:GridView id="GrdOrder" runat="server" Width="700px" ForeColor="SteelBlue" CssClass="gridRow2" DataKeyNames="Document_ID" HorizontalAlign="Center" BorderColor="White" BackColor="White" AutoGenerateColumns="False">
                                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                    PreviousPageText="Previous" />
                                                <Columns>
                                                    <asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
                                                        <HeaderStyle CssClass="HidePanel" />
                                                        <ItemStyle CssClass="HidePanel" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChbInvoice" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MANUAL_INVOICE_ID" HeaderText="Document Id">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Document Date">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TOTAL_AMOUNT" DataFormatString="{0:F2}" HeaderText="Gross Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DISCOUNT_AMOUNT" DataFormatString="{0:F2}" HeaderText="Discount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SCHEME_AMOUNT" DataFormatString="{0:F2}" HeaderText="Scheme">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GST_AMOUNT" DataFormatString="{0:F2}" HeaderText="GST Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TOTAL_NET_AMOUNT" DataFormatString="{0:F2}" HeaderText="Net Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <HeaderStyle CssClass="tblhead" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:GridView><asp:GridView id="GrdCheque" runat="server" Visible="False" Width="700px" ForeColor="SteelBlue" CssClass="gridRow2" HorizontalAlign="Center" BorderColor="White" BackColor="White" AutoGenerateColumns="False">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="CHEQUE_PROCESS_ID" HeaderText="CHEQUE_PROCESS_ID">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select"><ItemTemplate>
                                                            <asp:CheckBox ID="ChbInvoice" runat="server" />
                                                        
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Voucher_No" HeaderText="Voucher No" Visible="False">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CHEQUE_NO" HeaderText="Cheque No">
<ItemStyle HorizontalAlign="Center" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CHEQUE_DATE" HeaderText="Cheque Date">
<ItemStyle HorizontalAlign="Center" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CHEQUE_AMOUNT" DataFormatString="{0:F2}" HeaderText="Cheque Amount">
<ItemStyle HorizontalAlign="Center" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
</Columns>
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead"></HeaderStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>  
   </div>
</asp:Content>

