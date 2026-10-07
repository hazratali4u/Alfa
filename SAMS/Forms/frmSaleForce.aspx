<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSaleForce.aspx.cs" Inherits="Forms_frmSaleForce" Title="SAMS: Employee Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;
            str = document.getElementById('<%=txtUserName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter User Name');
                return false;
            }
            str = document.getElementById('<%=txtNICNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter NIC No');
                return false;
            }
            str = document.getElementById('<%=txtLoginId.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Login Id');
                return false;
            }
            str = document.getElementById('<%=txtpassword.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Password');
                return false;
            }
            str = document.getElementById('<%=txtMobileNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Mobile No');
                return false;
            }
            str = document.getElementById('<%=txtAddress2.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Address');
                return false;
            }
            return true;
        }
    </script>
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td style="width: 100px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 143px" align="left">
                                            </td>
                                            <td style="width: 175px">
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="width: 1px">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px; height: 15px" align="left">
                                                <strong>
                                                    <asp:Label ID="lbldesignationID" runat="server" Width="94px" Text="Base Location"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 15px">
                                                <asp:DropDownList ID="ddDistributorId" runat="server" Width="202px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddDistributorId_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px; height: 15px">
                                                &nbsp; &nbsp;
                                            </td>
                                            <td style="height: 15px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="96px" Text="Name" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="txtUserName" runat="server" Width="200px" CssClass="txtBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px; height: 12px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Width="79px" Text="Designation" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 12px">
                                                <asp:DropDownList ID="ddDesignation" runat="server" Width="202px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px; height: 12px">
                                            </td>
                                            <td style="height: 12px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Width="79px" Text="N.I.C No" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 12px">
                                                <asp:TextBox ID="txtNICNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px; height: 22px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblMobileNo" runat="server" Width="96px" Text="Mobile No:" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 22px">
                                                <asp:TextBox ID="txtMobileNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="width: 1px; height: 22px">
                                            </td>
                                            <td style="height: 22px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblPhNo" runat="server" Width="90px" Text="Phone No:" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtPhoneNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>

                                           <tr>
                                            <td style="width: 143px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Width="82px" Text="Credit Limit"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px">
                                                <asp:TextBox ID="txtCreditLimit" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="width: 1px">
                                            </td>
                                            <td valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label7" runat="server"  Width="69px" Text="Credit Days"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditDays" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="lblEmail" runat="server" Width="87px" Text="Email Address" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtEmail" runat="server" Width="514px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="lblAddress2" runat="server" Width="126px" Text="Parmanent Address "
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtAddress2" runat="server" Width="514px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="lblAddress1" runat="server" Width="126px" Text="Present Address "
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtAddress1" runat="server" Width="514px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>


                                        
                                        <tr>
                                            <td style="width: 143px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server" Visible="False" Width="82px" Text="Login Id"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px">
                                                <asp:TextBox ID="txtLoginId" runat="server" Visible="False" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="width: 1px">
                                            </td>
                                            <td valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Visible="False" Width="69px" Text="Password"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpassword" runat="server" Visible="False" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px; height: 21px" align="left">
                                            </td>
                                            <td style="width: 175px; height: 21px">
                                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="82px" Font-Size="8pt"
                                                    Text="Save" ValidationGroup="vg" CssClass="Button" />
                                                <asp:Button ID="btnCancel" runat="server" Width="73px" Font-Size="8pt" Text="Cancel"
                                                    OnClick="btnCancel_Click" CssClass="Button" />
                                            </td>
                                            <td style="width: 1px; height: 21px">
                                            </td>
                                            <td style="height: 21px">
                                                <asp:CheckBox ID="chkIsActive" runat="server" Width="93px" Text="IsActive" Checked="True">
                                                </asp:CheckBox>
                                            </td>
                                            <td style="height: 21px">
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
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Vertical" Width="100%" BorderWidth="1px">
                        <asp:GridView ID="Grid_users" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="gridRow2"
                            BorderColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White"
                            OnRowEditing="Grid_users_RowEditing" PageSize="15">
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                PreviousPageText="Previous"></PagerSettings>
                            <Columns>
                                <asp:BoundField DataField="USER_ID" HeaderText="User Id">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="USER_CODE" HeaderText="Code">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="USER_NAME" HeaderText="Name">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NIC_NO" HeaderText="NIC No">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PHONE" HeaderText="Phone No">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MOBILE" HeaderText="Mobile">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="EMAIL" HeaderText="Email">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel">
                                    </ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ADDRESS1" HeaderText="Present Address">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ADDRESS2" HeaderText="Permanent Address">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel">
                                    </ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SLASH_DESC" HeaderText="Designation">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel">
                                    </ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="USER_TYPE_ID" HeaderText="USERTYPE_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="COMPANY_ID" HeaderText="COMPANY_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                  <asp:BoundField DataField="Credit_limit" HeaderText="Credit_limit">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                  <asp:BoundField DataField="Credit_Days" HeaderText="Credit_Days">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead">
                            </HeaderStyle>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
