<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmSKU_Price.aspx.cs" Inherits="SKU_Price" Title="SAMS: SKU Price" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;
            str = document.getElementById('<%=ddskuName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select SKU Name');
                return false;
            }
            str = document.getElementById('<%=txtFromdate.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select Price Efftive Date');
                return false;
            }
            str = document.getElementById('<%=txtTaxPrices.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Tax Price');
                return false;
            }
            str = document.getElementById('<%=txtTradePrice.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Trade Price');
                return false;
            }
            str = document.getElementById('<%=txtRetailPrice.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Retail Price');
                return false;
            }
            str = document.getElementById('<%=txtDistributorPrice.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Factory Pricet');
                return false;
            }
            return true;
        }
        function CheckBoxListSelect() {
            var chkBoxList = document.getElementById('<%= ChbDistributorList.ClientID %>');
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
    </script>
    <div id="right_data">
        <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" __designer:wfdid="w361"></asp:Label>
                                </td>
                                <td colspan="1">
                                </td>
                                <td colspan="1">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px; height: 18px" align="left">
                                    <strong>
                                        <asp:Label ID="Label1" runat="server" Width="103px" Text="Principal Name" __designer:wfdid="w362"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td style="width: 298px; height: 18px" align="left">
                                    <asp:DropDownList ID="ddskuPrincipal" runat="server" Width="200px" __designer:wfdid="w363"
                                        CssClass="DropList" OnSelectedIndexChanged="ddskuPrincipal_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 200px; border-right: darkgray 1px ridge; border-top: darkgray 1px ridge;
                                    border-left: darkgray 1px ridge; border-bottom: darkgray 1px ridge" align="left"
                                    rowspan="10">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td class="tblhead" width="200">
                                                    <strong>
                                                        <asp:Label ID="Label11" runat="server" Width="140px" ForeColor="White" Font-Bold="True"
                                                            Text="Location Name"></asp:Label></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="ChbSelectAll" onclick="CheckBoxListSelect()" runat="server" Width="75px"
                                                        Font-Size="8pt" Text="Select All"></asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="300">
                                                    <asp:Panel ID="Panel1" runat="server" Width="250px" Height="220px" ScrollBars="Vertical"
                                                        BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver" BackColor="White">
                                                        <asp:CheckBoxList ID="ChbDistributorList" runat="server" Width="174px" Font-Size="8pt"
                                                            __designer:wfdid="w368">
                                                        </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td style="height: 18px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px" align="left">
                                    <strong>
                                        <asp:Label ID="Label2" runat="server" Width="101px" Text="Division Name" __designer:wfdid="w369"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td style="width: 298px" align="left">
                                    <asp:DropDownList ID="ddskuDivision" runat="server" Width="200px" __designer:wfdid="w370"
                                        CssClass="DropList" OnSelectedIndexChanged="ddskuDivision_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px" align="left">
                                    <strong>
                                        <asp:Label ID="Label7" runat="server" Width="101px" Text="SKU Category" __designer:wfdid="w371"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddskuCategory" runat="server" Width="200px" __designer:wfdid="w372"
                                        CssClass="DropList" OnSelectedIndexChanged="ddskuCategory_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px" align="left">
                                    <strong>
                                        <asp:Label ID="Label9" runat="server" Width="101px" Text="SKU Brand" __designer:wfdid="w373"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddskuBrand" runat="server" Width="200px" __designer:wfdid="w374"
                                        CssClass="DropList" OnSelectedIndexChanged="ddskuBrand_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px; height: 20px" align="left">
                                    <strong>
                                        <asp:Label ID="Label6" runat="server" Width="100px" Text="SKU Name" __designer:wfdid="w375"></asp:Label></strong>
                                </td>
                                <td style="height: 20px" align="left">
                                    <asp:DropDownList ID="ddskuName" runat="server" Width="200px" __designer:wfdid="w376"
                                        CssClass="DropList" OnSelectedIndexChanged="ddskuName_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 201px; height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px" align="left">
                                    <strong>
                                        <asp:Label ID="Label8" runat="server" Width="100px" Text="Date Effected" __designer:wfdid="w377"></asp:Label></strong>
                                </td>
                                <td style="width: 298px" align="left">
                                    <asp:TextBox Style="text-align: justify" ID="txtFromdate" TabIndex="2" runat="server"
                                        Width="194px" __designer:wfdid="w378" CssClass="txtBox" ValidationGroup="MKE"
                                        MaxLength="1"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBntFromCalc" runat="server" __designer:wfdid="w379" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                        CausesValidation="False"></asp:ImageButton><cc1:CalendarExtender ID="CalendarExtender1"
                                            runat="server" __designer:wfdid="w380" Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc"
                                            TargetControlID="txtFromdate">
                                        </cc1:CalendarExtender>
                                </td>
                                <td style="width: 201px" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <strong>
                                        <asp:Label ID="Label10" runat="server" Width="90px" Text="Invoice Price" __designer:wfdid="w381"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td style="width: 298px" align="left">
                                    <asp:TextBox ID="txtDistributorPrice" runat="server" Width="193px" __designer:wfdid="w382"
                                        CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                </td>
                                <td style="width: 201px" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <strong>
                                        <asp:Label ID="Label3" runat="server" Width="101px" Text="Trade Price" __designer:wfdid="w383"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td style="width: 298px" align="left">
                                    <asp:TextBox ID="txtTradePrice" runat="server" Width="192px" __designer:wfdid="w384"
                                        CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                </td>
                                <td style="width: 201px" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px" align="left">
                                    <strong>
                                        <asp:Label ID="Label4" runat="server" Width="103px" Text="Retail Price" __designer:wfdid="w385"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRetailPrice" runat="server" Width="192px" __designer:wfdid="w386"
                                        CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                </td>
                                <td style="width: 201px" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px; height: 12px" align="left">
                                    <strong>
                                        <asp:Label ID="Label5" runat="server" Width="102px" Text="G.S.T (%)" __designer:wfdid="w387"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTaxPrices" runat="server" Width="192px" __designer:wfdid="w388"
                                        CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                </td>
                                <td style="width: 201px; height: 12px" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px; height: 12px" align="left">
                                    <strong>
                                        <asp:Label ID="Label14" runat="server" Width="102px" Text="S.E.D (%)" __designer:wfdid="w389"
                                            CssClass="lblbox"></asp:Label></strong>
                                </td>
                                <td style="width: 298px; height: 12px" align="left">
                                    <asp:TextBox ID="txtSADTax" runat="server" Width="192px" __designer:wfdid="w390"
                                        CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                </td>
                                <td style="width: 201px; height: 12px" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 106px">
                                </td>
                                <td style="width: 298px" align="left">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="90px" Font-Size="8pt"
                                        Text="Save" ValidationGroup="vg" CssClass="Button" />
                                    &nbsp;
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" __designer:wfdid="w392"
                                        TargetControlID="txtTaxPrices" ValidChars="0123456789." FilterType="Custom">
                                    </cc1:FilteredTextBoxExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" __designer:wfdid="w393"
                                        TargetControlID="txtTradePrice" ValidChars=".0123456789" FilterType="Custom">
                                    </cc1:FilteredTextBoxExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" __designer:wfdid="w394"
                                        TargetControlID="txtRetailPrice" ValidChars=".0123456789" FilterType="Custom">
                                    </cc1:FilteredTextBoxExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" __designer:wfdid="w395"
                                        TargetControlID="txtDistributorPrice" ValidChars=".0123456789" FilterType="Custom">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="left">
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="z-index: 101; left: 530px; width: 100px; position: absolute; top: 440px;
                        height: 100px">
                        &nbsp;
                        <asp:Panel ID="Panel21" runat="server" __designer:wfdid="w396">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" __designer:wfdid="w397" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Width="23px" Height="26px" __designer:wfdid="w398"
                                        ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton>
                                    Wait Update
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Width="100%" Height="200px" ScrollBars="Vertical"
                        __designer:wfdid="w405" BorderWidth="1px">
                        <asp:GridView ID="Grid_pricedetails" runat="server" Width="100%" ForeColor="SteelBlue"
                            __designer:wfdid="w406" CssClass="gridRow2" BorderColor="White" BackColor="White"
                            AutoGenerateColumns="False" HorizontalAlign="Center">
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                PreviousPageText="Previous"></PagerSettings>
                            <Columns>
                                <asp:BoundField DataField="distributor_name" HeaderText="Location">
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GST_ON" HeaderText="GST">
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DISTRIBUTOR_PRICE" HeaderText="Factory Price" DataFormatString="{0:F4}">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TRADE_PRICE" HeaderText="Trade Price" DataFormatString="{0:F4}">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RETAIL_PRICE" HeaderText="Retail Price" DataFormatString="{0:F4}">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TAX_PRICE" HeaderText="GST (%)" DataFormatString="{0:F4}">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle BorderColor="DarkGray" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SED_TAX" DataFormatString="{0:F4}" HeaderText="SED (%)">
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DATE_EFFECTED" HeaderText="Date Effected">
                                    <ItemStyle BackColor="Transparent" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                    </ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>