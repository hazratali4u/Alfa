<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmGiftSKU.aspx.cs" Inherits="Forms_frmGiftSKU" Title="SAMS: Gift SKU Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">

        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtskuName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select SKU Name');
                return false;
            }
            str = document.getElementById('<%=txtQuantity.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Quantity');
                return false;
            }

            return true;
        }
        function SearcSKUList() {
            var l = document.getElementById('<%= lstCode.ClientID %>');
            var tb = document.getElementById('<%= txtskuCode.ClientID %>');

            if (tb.value == "") {
                ClearSelection(l);
            }
            else {
                for (var i = 0; i < l.options.length; i++) {
                    if (l.options[i].value.toLowerCase().match(tb.value.toLowerCase())) {
                        l.options[i].selected = true;
                        return false;
                    }
                    else {
                        ClearSelection(l);
                    }
                }
            }
        }


        function SearchSKUCode() {
            var str = document.getElementById("<%= lstCode.ClientID %>").value;
            var stroption = document.getElementById("<%= txtskuCode.ClientID %>").value;

            if (str.length > 0) {
                document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
                document.getElementById("<%= txtskuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));
                document.getElementById("<%= txtUnitRate.ClientID %>").value = str.substring(str.indexOf(':') + 1);

            }
            ClearSelection(document.getElementById('<%= lstCode.ClientID %>'));

        }
        function SelectSkuCode(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                var str = document.getElementById("<%= lstCode.ClientID %>").value;
                document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
                document.getElementById("<%= txtskuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));
                document.getElementById("<%= txtUnitRate.ClientID %>").value = str.substring(str.indexOf(':') + 1);
                document.getElementById("<%= txtQuantity.ClientID %>").focus();
            }
        }

        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }
 
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 477px; width: 100px; position: absolute; top: 229px;
                        height: 100px">
                        &nbsp;<asp:Panel ID="Panel21" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="23px" />
                                    Wait Update
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td valign="top" align="left">
                                            <strong>
                                                <asp:Label ID="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td valign="top" align="left" colspan="2">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="280px" CssClass="DropList"
                                                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 17px" valign="top" align="left">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="94px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 17px" valign="top" align="left" colspan="2">
                                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="280px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 17px" valign="top" align="left">
                                            Sale Force
                                        </td>
                                        <td style="height: 17px" valign="top" align="left" colspan="2">
                                            <asp:DropDownList ID="DrpSaleForce" runat="server" Width="280px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpSaleForce_SelectedIndexChanged" AutoPostBack="True"
                                                __designer:wfdid="w1">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 17px" valign="top" align="left">
                                            <strong>
                                                <asp:Label ID="lblDocumentNo" runat="server" Width="79px" Text="Invoice No" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 17px" valign="top" align="left" colspan="2">
                                            <asp:DropDownList ID="drpDocumentNo" runat="server" Width="280px" CssClass="DropList"
                                                OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="94px" Text="Customer Code" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:TextBox ID="txtOutletCode" onkeyup="SearchList()" runat="server" Width="76px"
                                                CssClass="txtBox " ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtOutletName" onfocus="SearchedCode()" runat="server" Width="196px"
                                                CssClass="txtBox " ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 64px" valign="top" align="left" colspan="3">
                                            <asp:ListBox ID="lstCode" onkeydown="SelectSkuCode(event)" runat="server" Width="378px"
                                                Height="132%" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;&nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <strong>
                        <asp:CheckBox ID="ChbAllTax" runat="server" Checked="True" Text="Is Apply All Tax" /></strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="height: 16px">
                                            <asp:Label ID="lblskuCode" runat="server" Width="74px" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="  SKU Code" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:Label ID="lblskuname" runat="server" Width="187px" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="   SKU Name" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:Label ID="Label3" runat="server" Width="61px" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="Quantity" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:Label ID="lblquantity" runat="server" Width="62px" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="Unit Price" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                        <td style="height: 16px" align="center">
                                            <asp:Label ID="Label7" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="GST Rate" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:Label ID="Label2" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="Amount" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:Label ID="Label4" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                Font-Bold="True" Text="Add SKU" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px">
                                            <asp:TextBox ID="txtskuCode" onkeyup="SearcSKUList()" runat="server" Width="72px"
                                                CssClass="txtBox"></asp:TextBox>
                                        </td>
                                        <td style="height: 21px">
                                            <asp:TextBox ID="txtskuName" runat="server" Width="185px" Font-Bold="True" CssClass="txtBox"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="height: 21px">
                                            <asp:TextBox ID="txtQuantity" onfocus="SearchSKUCode()" runat="server" Width="59px"
                                                CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td style="height: 21px">
                                            <asp:TextBox ID="txtUnitRate" runat="server" Width="60px" CssClass="txtBox" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="height: 21px">
                                            <asp:TextBox ID="txtBatchNo" onfocus="SearchSKUCode()" runat="server" Width="62px"
                                                CssClass="txtBoxnNum"></asp:TextBox>
                                        </td>
                                        <td style="height: 21px">
                                            <asp:TextBox ID="TextBox1" onfocus="SearchSKUCode()" runat="server" Width="72px"
                                                CssClass="txtBoxnNum" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="height: 21px">
                                            <asp:Button AccessKey="A" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="100px"
                                                Font-Size="8pt" Text="Add Sku" ValidationGroup="vg" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="7">
                                            <asp:Panel ID="Panel2" runat="server" Width="640px" Height="130px" ScrollBars="Vertical"
                                                BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                <asp:GridView ID="GrdPurchase" runat="server" ForeColor="SteelBlue" CssClass="gridRow2"
                                                    BackColor="White" BorderColor="White" ShowHeader="False" OnRowDeleting="GrdPurchase_RowDeleting"
                                                    HorizontalAlign="Center" AutoGenerateColumns="False">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <RowStyle ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="SALE_INVOICE_PROMOTION_ID" HeaderText="SALE_INVOICE_PROMOTION_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="75px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QUANTITY_UNIT" HeaderText="Quantity">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                Width="65px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UNIT_PRICE" DataFormatString="{0:F4}" HeaderText="PRICE">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                Width="65px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="GST_RATE" HeaderText="GST Rate">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="70px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Amount" DataFormatString="{0:F4}" HeaderText="Amount">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                Width="80px" />
                                                        </asp:BoundField>
                                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                    Text="Delete"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="45px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" />
                                                    <PagerStyle BackColor="Transparent" />
                                                    <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                        VerticalAlign="Middle" />
                                                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
