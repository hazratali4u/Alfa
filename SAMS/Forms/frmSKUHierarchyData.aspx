<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKUHierarchyData.aspx.cs" Inherits="frmSKUHierarchyData" Title="SAMS: SKU Hierarchy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            $('#<%=txtNTN.ClientID %>').mask("9999999-9");
            $('#<%=txtSTRN.ClientID %>').mask("99-99-9999-999-99");
        }
 
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <cc1:TabContainer ID="TabContainer1" runat="server" Height="400px" Width="650px"
                        ActiveTabIndex="0">
                        <cc1:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>
                                Principal
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" __designer:wfdid="w185"></asp:Label><br />
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                                <td style="width: 49px; height: 28px">
                                                                    <strong>
                                                                        <asp:Label ID="Label1" runat="server" Width="90px" Text="Principal Code" __designer:wfdid="w186"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtPrincipalCode" runat="server" Width="200px" __designer:wfdid="w187"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 49px; height: 29px">
                                                                    <strong>
                                                                        <asp:Label ID="Label2" runat="server" Width="96px" Text="Principal Name" __designer:wfdid="w188"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtPrincipalName" runat="server" Width="200px" __designer:wfdid="w189"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 49px; height: 29px">
                                                                    <strong>
                                                                        <asp:Label ID="Label11" runat="server" Width="96px" Text="Address" __designer:wfdid="w190"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" __designer:wfdid="w191"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 49px; height: 29px">
                                                                    <strong>
                                                                        <asp:Label ID="Label13" runat="server" Width="96px" Text="NTN" __designer:wfdid="w192"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtNTN" runat="server" Width="200px" __designer:wfdid="w193" Enabled="False"
                                                                        CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 49px; height: 29px">
                                                                    <strong>
                                                                        <asp:Label ID="Label14" runat="server" Width="96px" Text="STRN" __designer:wfdid="w194"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtSTRN" runat="server" Width="200px" __designer:wfdid="w195" Enabled="False"
                                                                        CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td style="width: 49px; height: 37px" align="left">
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                    <asp:CheckBox ID="ChIsMunalDiscount" runat="server" Width="190px" Text="Is Manual Dicount"
                                                                        __designer:wfdid="w196"></asp:CheckBox>
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                                <td style="width: 49px" align="right">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 100px">
                                                                    <asp:Button ID="btnSavePrincipal" OnClick="btnSavePrincipal_Click" runat="server"
                                                                        Width="85px" Font-Size="8pt" Text="New" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                                                <ProgressTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" Width="33px" Height="31px" __designer:wfdid="w199"
                                                        ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Vertical" Width="100%"
                                                BorderWidth="1px">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdPrincipal" runat="server" Width="100%" ForeColor="SteelBlue"
                                                            Font-Size="9pt" __designer:wfdid="w202" CssClass="gridRow2" BorderColor="White"
                                                            BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdPrincipal_RowEditing"
                                                            OnRowDeleting="GrdPrincipal_RowDeleting" OnPageIndexChanging="GrdPrincipal_PageIndexChanging">
                                                            <PagerSettings PreviousPageText="Previous" Mode="NextPrevious" LastPageText="" FirstPageText=""
                                                                NextPageText="Next"></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="SKU_HIE_ID" Visible="False" HeaderText="ID">
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="IS_MANUALDISCOUNT" HeaderText="Manual Discount">
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ADDRESS" Visible="False" HeaderText="ADDRESS"></asp:BoundField>
                                                                <asp:BoundField DataField="NTN" Visible="False" HeaderText="NTN"></asp:BoundField>
                                                                <asp:BoundField DataField="STRN" Visible="False" HeaderText="STRN"></asp:BoundField>
                                                                <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>
                                Division
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px;">
                                        </td>
                                        <td align="center">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                                <td style="height: 8px" align="left" colspan="2">
                                                                    <asp:Label ID="lblErrorMsgDivsion" runat="server" ForeColor="Red" Font-Bold="True"
                                                                        __designer:wfdid="w16"></asp:Label><br />
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                                <td style="width: 159px; height: 8px">
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 23px">
                                                                </td>
                                                                <td style="width: 159px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label3" runat="server" Width="80px" Text="Principal" __designer:wfdid="w17"></asp:Label></strong>
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:DropDownList ID="dddivisonPrincipal" runat="server" Width="198px" __designer:wfdid="w18"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="dddivisonPrincipal_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 23px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                                <td style="width: 159px; height: 28px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label12" runat="server" Width="80px" Text="Division Code" __designer:wfdid="w19"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtDivisionCode" runat="server" Width="194px" __designer:wfdid="w20"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 159px; height: 29px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label21" runat="server" Width="85px" Text="Division Name" __designer:wfdid="w21"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtDivisionName" runat="server" Width="194px" __designer:wfdid="w22"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td style="width: 159px; height: 37px" align="right">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 100px; height: 37px" align="left">
                                                                    <asp:Button ID="btnSaveDivison" OnClick="btnSaveDivison_Click" runat="server" Width="85px"
                                                                        Font-Size="8pt" Text="New" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image2" runat="server" Width="30px" Height="28px" __designer:wfdid="w25"
                                                        ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:Image>&nbsp; Loading
                                                    .........
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="width: 100px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical" Width="100%" BorderWidth="1px">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdDivision" runat="server" Width="100%" ForeColor="SteelBlue" Font-Size="9pt"
                                                            __designer:wfdid="w28" CssClass="gridRow2" BorderColor="White" BackColor="White"
                                                            HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdDivision_RowEditing"
                                                            OnRowDeleting="GrdDivision_RowDeleting" OnPageIndexChanging="GrdDivision_PageIndexChanging">
                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                PreviousPageText="Previous"></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit"><ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle></asp:CommandField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel3" runat="server">
                            <HeaderTemplate>
                                Category
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="center" style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px; height: 16px">
                                                                </td>
                                                                <td style="height: 16px" align="left" colspan="2">
                                                                    <br />
                                                                    <asp:Label ID="lblErrorMsgCategory" runat="server" ForeColor="Red" Font-Bold="True"
                                                                        __designer:wfdid="w114"></asp:Label>
                                                                </td>
                                                                <td style="width: 100px; height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                                <td style="width: 69px; height: 8px">
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 21px">
                                                                </td>
                                                                <td style="width: 69px; height: 21px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label5" runat="server" Width="80px" Text="Principal" __designer:wfdid="w115"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:DropDownList ID="DrpCategoryPrincipal" runat="server" Width="198px" __designer:wfdid="w116"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpCategoryPrincipal_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 21px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 21px">
                                                                </td>
                                                                <td style="width: 69px; height: 21px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label4" runat="server" Width="80px" Text="Division" __designer:wfdid="w117"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:DropDownList ID="ddCategoryDivision" runat="server" Width="198px" __designer:wfdid="w118"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddCategoryDivision_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 21px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                                <td style="width: 69px; height: 28px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label121" runat="server" Width="90px" Text="Category Code" __designer:wfdid="w119"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtCategoryCode" runat="server" Width="194px" __designer:wfdid="w120"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 69px; height: 29px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label211" runat="server" Width="90px" Text="Category Name" __designer:wfdid="w121"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtCategoryName" runat="server" Width="194px" __designer:wfdid="w122"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td style="width: 69px; height: 37px" align="right">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 100px; height: 37px" align="left">
                                                                    <asp:Button ID="btnSaveCategory" OnClick="btnSaveCategory_Click" runat="server" Width="85px"
                                                                        Font-Size="8pt" Text="New" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel21">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image3" runat="server" Width="30px" Height="28px" __designer:wfdid="w125"
                                                        ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:Image>&nbsp; Loading
                                                    .........
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Panel ID="Panel3" runat="server" Height="200px" ScrollBars="Vertical" Width="100%" BorderWidth="1px">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdCategory" runat="server" Width="100%" ForeColor="SteelBlue" Font-Size="9pt"
                                                            __designer:wfdid="w128" CssClass="gridRow2" BorderColor="White" BackColor="White"
                                                            HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdCategory_RowEditing"
                                                            OnRowDeleting="GrdCategory_RowDeleting" OnPageIndexChanging="GrdCategory_PageIndexChanging">
                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                PreviousPageText="Previous"></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit"><ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle></asp:CommandField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel4" runat="server">
                            <HeaderTemplate>
                                Brand
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="center" style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblErrorMsgBrand" runat="server" ForeColor="Red" Font-Bold="True"
                                                                        __designer:wfdid="w148"></asp:Label><br />
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 25px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label6" runat="server" Width="80px" Text="Principal" __designer:wfdid="w149"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="DrpBrandPrincipal" runat="server" Width="198px" __designer:wfdid="w150"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpBrandPrincipal_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label10" runat="server" Width="64px" Text="Division" __designer:wfdid="w151"></asp:Label></strong>
                                                                </td>
                                                                <td style="height: 25px">
                                                                    <asp:DropDownList ID="DrpBrandDivision" runat="server" Width="198px" __designer:wfdid="w152"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpBrandDivision_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 21px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 25px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label9" runat="server" Width="80px" Text="Category" __designer:wfdid="w153"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:DropDownList ID="ddBrandCategory" runat="server" Width="198px" __designer:wfdid="w154"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddBrandCategory_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 28px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label7" runat="server" Width="90px" Text="Brand Code" __designer:wfdid="w155"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtBrandCode" runat="server" Width="194px" __designer:wfdid="w156"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label8" runat="server" Width="90px" Text="Brand Name" __designer:wfdid="w157"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtBrandName" runat="server" Width="194px" __designer:wfdid="w158"
                                                                        Enabled="False" CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td style="width: 100px; height: 37px" align="left">
                                                                    <asp:Button AccessKey="B" ID="btnSaveBrand" OnClick="btnSaveBrand_Click" runat="server"
                                                                        Width="85px" Font-Size="8pt" Text="New" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image4" runat="server" Width="24px" Height="23px" __designer:wfdid="w161"
                                                        ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:Image>&nbsp; Loading.....
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Panel ID="Panel4" runat="server" Height="150px" ScrollBars="Vertical" Width="100%" BorderWidth="1px">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdBrand" runat="server" Width="100%" ForeColor="SteelBlue" Font-Size="9pt"
                                                            __designer:wfdid="w164" CssClass="gridRow2" BorderColor="White" BackColor="White"
                                                            HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdBrand_RowEditing"
                                                            OnRowDeleting="GrdBrand_RowDeleting" OnPageIndexChanging="GrdBrand_PageIndexChanging">
                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                PreviousPageText="Previous"></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit"><ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle></asp:CommandField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                                    </ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
