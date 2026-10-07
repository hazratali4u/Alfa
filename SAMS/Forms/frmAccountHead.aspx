<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmAccountHead.aspx.cs" Inherits="Forms_frmAccountHead" Title="SAMS: Chart of Account" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(startRequest);

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);

        function startRequest(sender, e) {

            document.getElementById('<%=btnAccountType.ClientID%>').disabled = true;
            document.getElementById('<%=btnAccountSubType.ClientID%>').disabled = true;
            document.getElementById('<%=btnAccountDetailType.ClientID%>').disabled = true;
            document.getElementById('<%=btnSave.ClientID%>').disabled = true;

        }

        function endRequest(sender, e) {

            document.getElementById('<%=btnAccountType.ClientID%>').disabled = false;
            document.getElementById('<%=btnAccountSubType.ClientID%>').disabled = false;
            document.getElementById('<%=btnAccountDetailType.ClientID%>').disabled = false;
            document.getElementById('<%=btnSave.ClientID%>').disabled = false;
        }
        
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="400px"
                        Width="650px">
                        <cc1:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>
                                Main Type
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                                <td style="width: 49px">
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <strong>
                                                                        <asp:Label ID="Label3" runat="server" Width="118px" Text="Account Category " __designer:wfdid="w123"
                                                                            CssClass="lblbox"></asp:Label></strong>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:DropDownList ID="DrpAccountCategory" runat="server" Width="265px" __designer:wfdid="w124"
                                                                        CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpAccountCategory_SelectedIndexChanged">
                                                                        <asp:ListItem>Balance Sheet Account</asp:ListItem>
                                                                        <asp:ListItem>Income Statment Account</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 28px">
                                                                    <strong>
                                                                        <asp:Label ID="Label1" runat="server" Width="119px" Text="Main Account Type " __designer:wfdid="w125"
                                                                            CssClass="lblbox"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 49px; height: 28px">
                                                                    <asp:TextBox ID="txtAtypeCode" runat="server" Width="77px" __designer:wfdid="w126"
                                                                        CssClass="txtBox " MaxLength="2" ReadOnly="True"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtAtypeName" runat="server" Width="170px" __designer:wfdid="w127"
                                                                        CssClass="txtBox "></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td style="height: 37px" align="left" colspan="2">
                                                                    <asp:Button ID="btnAccountType" OnClick="btnAccountType_Click" runat="server" Width="125px"
                                                                        Font-Size="8pt" Text="New Account Type" __designer:wfdid="w128" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GrdMainType" runat="server" Width="100%" ForeColor="SteelBlue"
                                                        __designer:wfdid="w130" CssClass="gridRow2" OnRowDeleting="GrdMainType_RowDeleting"
                                                        BorderColor="White" HorizontalAlign="Center" BackColor="White" AutoGenerateColumns="False"
                                                        OnRowEditing="GrdMainType_RowEditing">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                                                <HeaderStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ACCOUNT_CATEGORY" HeaderText="ACCOUNT_CATEGORY">
                                                                <FooterStyle CssClass="HidePanel" />
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="tblhead" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>
                                Sub Type
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="left" style="width: 100px">
                                            &nbsp; &nbsp;
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="left" style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label8" runat="server" Width="123px" Text="Main Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w105"></asp:Label></strong>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:DropDownList ID="ddAccountType1" runat="server" Width="268px" CssClass="DropList"
                                                                        __designer:wfdid="w106" OnSelectedIndexChanged="ddAccountType1_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 28px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label2" runat="server" Width="124px" Text="Sub Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w107"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 49px; height: 28px">
                                                                    <asp:TextBox ID="txtASubTypeCode" runat="server" Width="81px" CssClass="txtBox "
                                                                        __designer:wfdid="w108" ReadOnly="True" MaxLength="2"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtSubTypeName" runat="server" Width="170px" CssClass="txtBox "
                                                                        __designer:wfdid="w109"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="height: 29px" align="left" colspan="2">
                                                                    <asp:Button ID="btnAccountSubType" OnClick="btnAccountSubType_Click" runat="server"
                                                                        Width="125px" Font-Size="8pt" Text="New Sub Type" __designer:wfdid="w110" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="left" style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GrdSubType" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="gridRow2"
                                                        __designer:wfdid="w112" OnRowEditing="GrdSubType_RowEditing" AutoGenerateColumns="False"
                                                        BackColor="White" HorizontalAlign="Center" BorderColor="White" OnRowDeleting="GrdSubType_RowDeleting">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                                                <HeaderStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ACCOUNT_CATEGORY" HeaderText="ACCOUNT_CATEGORY">
                                                                <FooterStyle CssClass="HidePanel" />
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="tblhead" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                &nbsp;
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                            <HeaderTemplate>
                                Detail Type
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="center" style="width: 100px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="center" style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px; height: 16px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label81" runat="server" Width="123px" Text="Main Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w84"></asp:Label></strong>
                                                                </td>
                                                                <td style="height: 28px" align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddAccountType2" runat="server" Width="250px" CssClass="DropList"
                                                                        __designer:wfdid="w85" OnSelectedIndexChanged="ddAccountType2_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 8px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label4" runat="server" Width="123px" Text="Sub Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w86"></asp:Label></strong>
                                                                </td>
                                                                <td style="height: 28px" align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddAccountSubType1" runat="server" Width="250px" CssClass="DropList"
                                                                        __designer:wfdid="w87" OnSelectedIndexChanged="ddAccountSubType1_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 8px" align="left">
                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong>
                                                                        <asp:Label ID="Label5" runat="server" Width="116px" Text="Detail Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w88"></asp:Label></strong> &nbsp; &nbsp;
                                                                </td>
                                                                <td style="width: 49px; height: 28px" align="left">
                                                                    <asp:TextBox ID="txtADetailTypeCode" runat="server" Width="62px" CssClass="txtBox "
                                                                        __designer:wfdid="w89" ReadOnly="True" MaxLength="2"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDetailTypeName" runat="server" Width="170px" CssClass="txtBox "
                                                                        __designer:wfdid="w90"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td align="left" colspan="2">
                                                                    <asp:Button ID="btnAccountDetailType" OnClick="btnAccountDetailType_Click" runat="server"
                                                                        Width="125px" Font-Size="8pt" Text="New Detail Type" __designer:wfdid="w91" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="Panel4" runat="server" Height="150px" ScrollBars="Vertical" Width="100%" BorderWidth="1px">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdDetailType" runat="server" Width="100%" ForeColor="SteelBlue"
                                                            CssClass="gridRow2" __designer:wfdid="w94" OnRowEditing="GrdDetailType_RowEditing"
                                                            AutoGenerateColumns="False" BackColor="White" HorizontalAlign="Center" BorderColor="White"
                                                            OnRowDeleting="GrdDetailType_RowDeleting">
                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                PreviousPageText="Previous" />
                                                            <Columns>
                                                                <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                                                                    <HeaderStyle CssClass="HidePanel" />
                                                                    <ItemStyle CssClass="HidePanel" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                                                    <HeaderStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ACCOUNT_CATEGORY" HeaderText="ACCOUNT_CATEGORY">
                                                                    <FooterStyle CssClass="HidePanel" />
                                                                    <HeaderStyle CssClass="HidePanel" />
                                                                    <ItemStyle CssClass="HidePanel" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="tblhead" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                            <HeaderTemplate>
                                Account Head&nbsp;
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="center" style="width: 100px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td align="center" style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100px; height: 16px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label34" runat="server" Width="119px" Text="Main Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w58"></asp:Label></strong>
                                                                </td>
                                                                <td style="height: 28px" align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddAccountType3" runat="server" Width="280px" CssClass="DropList"
                                                                        __designer:wfdid="w59" OnSelectedIndexChanged="ddAccountType3_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 16px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label62" runat="server" Width="120px" Text="Sub Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w60"></asp:Label></strong>
                                                                </td>
                                                                <td style="height: 28px" align="left" colspan="2">
                                                                    <asp:DropDownList ID="ddAccountSubType2" runat="server" Width="280px" CssClass="DropList"
                                                                        __designer:wfdid="w61" OnSelectedIndexChanged="ddAccountSubType2_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 16px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label71" runat="server" Width="120px" Text="Detail Account Type" CssClass="lblbox"
                                                                            __designer:wfdid="w62"></asp:Label></strong>
                                                                </td>
                                                                <td style="height: 28px" align="left" colspan="2">
                                                                    <asp:DropDownList ID="drpAccountTypeDetail" runat="server" Width="280px" CssClass="DropList"
                                                                        __designer:wfdid="w63" OnSelectedIndexChanged="drpAccountTypeDetail_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px; height: 16px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 8px" align="left">
                                                                    <strong>
                                                                        <asp:Label ID="Label6" runat="server" Width="120px" Text="Account Head" CssClass="lblbox"
                                                                            __designer:wfdid="w64"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 49px; height: 28px" align="left">
                                                                    <asp:TextBox ID="txtAccountCode" runat="server" Width="90px" CssClass="txtBox " __designer:wfdid="w65"
                                                                        ReadOnly="True" MaxLength="4"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAccountHead" runat="server" Width="175px" CssClass="txtBox "
                                                                        __designer:wfdid="w66"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 8px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="94px" Font-Size="8pt"
                                                                        Text="New" __designer:wfdid="w67" CssClass="Button" />
                                                                </td>
                                                                <td align="left">
                                                                </td>
                                                                <td style="width: 100px; height: 37px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            <asp:Panel ID="Panel12" runat="server" Height="150px" ScrollBars="Vertical" Width="100%" BorderWidth="1px">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridAccountHead" runat="server" Width="100%" ForeColor="SteelBlue"
                                                            CssClass="gridRow2" __designer:wfdid="w70" OnRowEditing="GridAccountHead_RowEditing"
                                                            AutoGenerateColumns="False" BackColor="White" HorizontalAlign="Center" BorderColor="White"
                                                            OnRowDeleting="GridAccountHead_RowDeleting">
                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                PreviousPageText="Previous"></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                                                    <HeaderStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>
                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
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
