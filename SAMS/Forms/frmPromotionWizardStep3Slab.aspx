<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmPromotionWizardStep3Slab.aspx.cs" Inherits="Forms_frmPromotionWizardStep3Slab" Title="SAMS: Promotion Wizard Step 3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">

    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;
            if (document.getElementById('<%=rbSKUGroup.ClientID%>').checked == true) {
			    str = document.getElementById('<%=ddSKUSelectedGroup.ClientID%>').value;
			    if (str == null || str.length == 0) {
			        alert('Must select SKU Group');
			        return false;
			    }
			}

            if (document.getElementById('<%=chIsMultiple.ClientID%>').checked == true) {
                str = document.getElementById('<%=txtMultipleOf.ClientID%>').value;
			    if (str == null || str.length == 0) {
			        alert('Must enter Multiple of');
			        return false;
			    }
			}
            str = document.getElementById('<%=txtFrom.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter From Range');
                return false;
            }
            str = document.getElementById('<%=txtTo.ClientID%>').value;
			if (str == null || str.length == 0) {
			    alert('Must enter To Range');
			    return false;
			}
			if (!(document.getElementById('<%=chDiscount.ClientID%>').checked || document.getElementById('<%=chSKU.ClientID%>').checked)) {
			    alert('Must Supply values either of Discount or SKU or both');
			    return false;
			}
			if (document.getElementById('<%=chDiscount.ClientID%>').checked) {
                if (document.getElementById('<%=rbtnDiscount.ClientID%>').index == 0) {
			        str = document.getElementById('<%=txtDiscountRate.ClientID%>').value;
			        if (str == null || str.length == 0) {
			            alert('Must enter Discount Rate');
			            return false;
			        }
			        var num = parseFloat(str);
			        if (num >= 100.0) {
			            alert('Discount Rate must not be greater than 100');
			            return false;
			        }
			    }
                if (document.getElementById('<%=rbtnDiscount.ClientID%>').index == 1) {
			        str = document.getElementById('<%=txtDiscountAmount.ClientID%>').value;
				    if (str == null || str.length == 0) {
				        alert('Must enter Discount Amount');
				        return false;
				    }
				}
            }
            return true;
        }
    </script>

    <div id="right_data">

        <div>
            <table width="100%">
                <tr>
                    <td>
                        <h2>Promotion Wizard Step 3</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left">
                                                <asp:RadioButton ID="rbSKUHierarchy" runat="server" Width="139px" Text="By SKU Hierarchy" AutoPostBack="True" Checked="True" OnCheckedChanged="rbSKUHierarchy_CheckedChanged"></asp:RadioButton></td>
                                            <td align="left"></td>
                                            <td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </td>
                                            <td align="left" colspan="2">
                                                <strong>
                                                    <asp:Label ID="lblPromotionOffer" runat="server" Width="120px" CssClass="entryErrorMessage"> Promotion Offer</asp:Label></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblSKUCatagory" runat="server" Width="100px" Text="SKU Category" CssClass="lblbox"></asp:Label></strong></td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddSKUCatagory" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddSKUCatagory_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td></td>
                                            <td align="left" colspan="2" rowspan="9">
                                                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%" BorderWidth="1px" BorderStyle="Groove" BorderColor="Gray">
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:CheckBox ID="chDiscount" runat="server" Width="95px" Font-Size="8pt" Text="Discount" AutoPostBack="True"></asp:CheckBox></td>
                                                                <td style="width: 100px"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px" rowspan="2">
                                                                    <asp:RadioButtonList ID="rbtnDiscount" runat="server" Width="128px" Height="34px" Font-Size="8pt" AutoPostBack="True" CssClass="lblbox" OnSelectedIndexChanged="rbtnDiscount_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">Discount Rate</asp:ListItem>
                                                                        <asp:ListItem Value="1">Discount Amount</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                                <td style="width: 100px">
                                                                    <asp:TextBox ID="txtDiscountRate" runat="server" Width="168px" CssClass="txtBox" Enabled="False"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:TextBox ID="txtDiscountAmount" runat="server" Width="168px" CssClass="txtBox " Enabled="False"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:CheckBox ID="chSKU" runat="server" Width="49px" Font-Size="8pt" Text="SKU"></asp:CheckBox></td>
                                                                <td style="width: 100px"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <strong>
                                                                        <asp:Label ID="lblSKUCategory2" runat="server" Width="101px" CssClass="lblbox">SKU Category</asp:Label></strong></td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="ddPromotionCatagory" runat="server" Width="174px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddPromotionCatagory_SelectedIndexChanged">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <strong>
                                                                        <asp:Label ID="lblSKU2" runat="server" Width="61px" CssClass="lblbox">SKU</asp:Label></strong></td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="ddPromotionSKU" runat="server" Width="174px" AutoPostBack="True" CssClass="DropList">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <strong>
                                                                        <asp:Label ID="lblQuantity2" runat="server" Width="99px" CssClass="lblbox"> Quantity</asp:Label></strong></td>
                                                                <td style="width: 100px">
                                                                    <asp:TextBox ID="txtPromotionQuantity" runat="server" Width="168px" CssClass="txtBox "></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px"></td>
                                                                <td style="width: 100px"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblSKUBrand" runat="server" Width="100px" Text="SKU Brand" CssClass="lblbox"></asp:Label></strong></td>
                                            <td style="height: 18px" align="left">
                                                <asp:DropDownList ID="ddSKUBrand" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddSKUBrand_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td style="height: 18px"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblSKU" runat="server" Width="100px" Text="SKU" CssClass="lblbox"></asp:Label></strong></td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddSKU" runat="server" Width="175px" CssClass="DropList"></asp:DropDownList></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:RadioButton ID="rbSKUGroup" runat="server" Width="139px" Text="By SKU Group" AutoPostBack="True" OnCheckedChanged="rbSKUGroup_CheckedChanged"></asp:RadioButton></td>
                                            <td align="left"></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblSKUGroup" runat="server" Width="100px" Text="SKU Group" CssClass="lblbox"></asp:Label></strong></td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddSKUSelectedGroup" runat="server" Width="175px" CssClass="DropList" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblSlabOn" runat="server" Width="100px" Text="Slab On" CssClass="lblbox"></asp:Label></strong></td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddSlabOn" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddSlabOn_SelectedIndexChanged">
                                                    <asp:ListItem Value="82">Quantity</asp:ListItem>
                                                    <asp:ListItem Value="83">Amount</asp:ListItem>
                                                    <asp:ListItem Value="84">CTN</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <asp:CheckBox ID="chIsMultiple" runat="server" Text="Is Multiple" AutoPostBack="True" OnCheckedChanged="chIsMultiple_CheckedChanged"></asp:CheckBox></td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMultipleOf" runat="server" Width="168px" CssClass="txtBox" Enabled="False"></asp:TextBox></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblfromquantity" runat="server" Width="100px" Text="From Quantity" CssClass="lblbox"></asp:Label></strong></td>
                                            <td align="left">
                                                <asp:TextBox ID="txtFrom" runat="server" Width="168px" CssClass="txtBox"></asp:TextBox></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblToQuantity" runat="server" Width="100px" Text="To Quantity" CssClass="lblbox"></asp:Label></strong></td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTo" runat="server" Width="168px" CssClass="txtBox"></asp:TextBox></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" align="left"></td>
                                            <td align="left">
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789." FilterType="Custom" TargetControlID="txtFrom">
                                                </cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789." FilterType="Custom" TargetControlID="txtDiscountAmount">
                                                </cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="0123456789." FilterType="Custom" TargetControlID="txtMultipleOf">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789." FilterType="Custom" TargetControlID="txtTo">
                                                </cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers" TargetControlID="txtPromotionQuantity">
                                                </cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" ValidChars="0123456789." FilterType="Custom" TargetControlID="txtDiscountRate">
                                                </cc1:FilteredTextBoxExtender>
                                                &nbsp; &nbsp;&nbsp; </td>
                                            <td>&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAddtoSlab" OnClick="btnAddtoSlab_Click" runat="server" Width="90" CssClass="Button" Text="Add To Slab" ValidationGroup="vg"></asp:Button></td>
                                            <td align="left">
                                                <asp:Button ID="btnCreateNewSlab" OnClick="btnCreateNewSlab_Click" runat="server" Width="120" CssClass="Button" Text="Create New Slab" ValidationGroup="vg" CausesValidation="False"></asp:Button></td>
                                            <td></td>
                                            <td align="right">
                                                <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Width="90px" CssClass="Button" Text="Back" ValidationGroup="vg" CausesValidation="False"></asp:Button>&nbsp;</td>
                                            <td align="left">
                                                <asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" Width="90px" CssClass="Button" Text="Next" ValidationGroup="vg" CausesValidation="False"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>

        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdSlab" runat="server" Width="94%" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" OnRowDeleting="grdSlab_RowDeleting" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" OnRowEditing="grdSlab_RowEditing">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                        <Columns>
                            <asp:BoundField DataField="SLAB_NO" HeaderText="SLAB_NO">
                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>

                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SLAB NO" HeaderText="Slab No">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Is_Multiple" HeaderText="Is Multiple"></asp:BoundField>
                            <asp:BoundField DataField="Multiple_of" HeaderText="Multiple Of">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SKU" HeaderText="SKU">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UOM" HeaderText="UOM" Visible="False">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Slab On" HeaderText="Slab On">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="From" HeaderText="From">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="To" HeaderText="To">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Discount" HeaderText="Discount">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SKU Offer" HeaderText="SKU Offer">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SKU Quantity" HeaderText="SKU Quantity">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;" CommandName="Delete"></asp:LinkButton>
                                </ItemTemplate>

                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="tblhead"></HeaderStyle>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

</asp:Content>
