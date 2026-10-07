<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmPysicalStockteken.aspx.cs" Inherits="Forms_frmPysicalStockteken" Title="SAMS: Physical Stock Taking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">

        <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">

        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtQuantityCTN.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Quantity');
                return false;
            }

            return true;
        }
        function pageLoad() {
            $("select").searchable();
        }

        function isNumberKey(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }


    </script>
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
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label Width="74px" CssClass="lblbox" ID="lblDocumentNo" runat="server" Text="Location"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList CssClass="DropList" ID="drpDistributor" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="center" style="width: 316px" colspan="1" rowspan="2" valign="middle"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label CssClass="lblbox" ID="lbltoLocation" runat="server" Text="Principal" Width="73px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList AutoPostBack="True" CssClass="DropList" ID="drpPrincipal" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged"
                                                    runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            &nbsp;
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table border="0">
                                    <tr>
                                        <td style="height: 16px" colspan="2">
                                            <strong>
                                                <asp:Label ID="lblsku" runat="server" BackColor="#006699" CssClass="lblbox"
                                                    Font-Bold="True" ForeColor="White" Height="16px" Text="SKU" Width="100%"></asp:Label>
                                            </strong>
                                        </td>

                                        <td style="height: 16px" colspan="2">
                                            <strong>
                                                <asp:Label ID="lblquantity" runat="server" BackColor="#006699" CssClass="lblbox"
                                                    Font-Bold="True" ForeColor="White" Height="16px" Text="Sale Qty" Width="100%" Style="text-align: center"></asp:Label></strong>
                                        </td>

                                        <td style="height: 16px;" colspan="2">
                                            <strong>
                                                <asp:Label ID="lblFreeSKU" runat="server" BackColor="#006699" CssClass="lblbox" Font-Bold="True"
                                                    ForeColor="White" Height="16px" Text="Un Sale Qty" Width="100%" Style="text-align: center"></asp:Label></strong>
                                        </td>
                                        <td style="height: 16px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" BackColor="#006699" CssClass="lblbox" Font-Bold="True"
                                                    ForeColor="White" Height="16px" Text="Unit Rate" Width="100%"></asp:Label></strong>
                                        </td>
                                        <td style="height: 16px">
                                            <strong>
                                                <asp:Label ID="Label41" runat="server" BackColor="#006699" CssClass="lblbox" Font-Bold="True"
                                                    ForeColor="White" Height="16px" Text="Add SKU" Width="100%"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><strong>
                                            <asp:Label ID="lblskuCode0" runat="server" BackColor="#006699"
                                                CssClass="lblbox" Font-Bold="True" ForeColor="White" Height="16px"
                                                Text=" SKU Detail" Width="100%"></asp:Label>
                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label ID="lblSaleQtuCtn" runat="server" BackColor="#006699" CssClass="lblbox"
                                                    Font-Bold="True" ForeColor="White" Height="16px" Text="CTN" Width="100%"></asp:Label></strong>

                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" BackColor="#006699" CssClass="lblbox"
                                                    Font-Bold="True" ForeColor="White" Height="16px" Text="Units" Width="100%"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label ID="lblSaleQtyUnits" runat="server" BackColor="#006699" CssClass="lblbox"
                                                    Font-Bold="True" ForeColor="White" Height="16px" Text="CTN" Width="100%"></asp:Label></strong>


                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" BackColor="#006699" CssClass="lblbox"
                                                    Font-Bold="True" ForeColor="White" Height="16px" Text="Units" Width="100%"></asp:Label></strong></td>
                                        <td colspan="2">

                                            <asp:Label ID="Label4" runat="server" BackColor="#006699" CssClass="lblbox"
                                                Font-Bold="True" ForeColor="White" Height="16px" Text="" Width="100%"></asp:Label></strong>
                             
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 9px;" colspan="2">
                                            <asp:DropDownList ID="DrpSkuDetail" runat="server" Width="100%"></asp:DropDownList>
                                        </td>
                                        <td style="height: 9px">
                                            <asp:TextBox ID="txtQuantityCTN" runat="server" CssClass="txtBox " onfocus="SearchSKUCode()"
                                                Width="79px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="height: 9px;">
                                            <asp:TextBox ID="txtQuantityUnit" runat="server" CssClass="txtBox "
                                                Width="79px" onkeypress="return isNumberKey(event)"></asp:TextBox></td>

                                        <td style="height: 9px;">
                                            <asp:TextBox ID="txtusaleableqtyCTN" runat="server" CssClass="txtBox "
                                                Width="79px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="height: 9px;">
                                            <asp:TextBox ID="txtusaleableqtyUnit" runat="server" CssClass="txtBox "
                                                Width="79px" onkeypress="return isNumberKey(event)"></asp:TextBox></td>
                                        <td style="height: 9px">
                                            <asp:TextBox ID="txtUnitRate" runat="server" CssClass="txtBox" Width="75px" Enabled="false">0</asp:TextBox>
                                        </td>
                                        <td style="height: 9px" valign="middle">
                                            <asp:Button ID="btnSave" runat="server" AccessKey="A" Font-Size="8pt" OnClick="btnSave_Click"
                                                Text="Save" ValidationGroup="vg" Width="84px" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="8">
                                            <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                                Height="150px" ScrollBars="Vertical" Width="880px">
                                                <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                                    ShowHeader="False">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <RowStyle ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="90px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="365px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SALEABLE_QUANTITY" HeaderText="Quantity">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SALEABLE_QUANTITYUnit" HeaderText="Quantity" DataFormatString="{0:f2}">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                Width="100px" />
                                                        </asp:BoundField>


                                                        <asp:BoundField DataField="UNSALEABLE_QUANTITY" HeaderText="PRICE">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                Width="104px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="UNSALEABLE_QUANTITYUnit" HeaderText="PRICE" DataFormatString="{0:f0}">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                Width="104px" />
                                                        </asp:BoundField>



                                                        <asp:BoundField DataField="UNIT_RATE" HeaderText="UNIT_RATE" DataFormatString="{0:F4}">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="90px"
                                                                HorizontalAlign="Right" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="UNITS_IN_CASE" HeaderText="UNITS_IN_CASE">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="30px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                    Text="Delete"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="35px" />
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
                                </table>
                                &nbsp; &nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
