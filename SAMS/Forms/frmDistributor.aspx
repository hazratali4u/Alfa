<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributor.aspx.cs" Inherits="Forms_frmDistributor" Title="SAMS: New Location" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            $('#<%=txtgstno.ClientID %>').mask("99-99-9999-999-99");
        }

        function ValidateForm() {
            var str;
            str = document.getElementById('<%=txtDistributorCode.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Distributor Code');
                return false;
            }
            str = document.getElementById('<%=txtDistributorName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Distributor Name');
                return false;
            }
            str = document.getElementById('<%=txtPhoneNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter phone');
                return false;
            }
            str = document.getElementById('<%=txtcontactperson.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Contact Person Name');
                return false;
            }

            str = document.getElementById('<%=txtAddress2.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Email Address');
                return false;
            }
            str = document.getElementById('<%=txtAddress1.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Address');
                return false;
            }
            str = document.getElementById('<%=txtpassword.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Fax No');
                return false;
            }
            return true;
        }
    </script>
    <div id="right_data">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="height: 25px" align="left" colspan="4">
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server" Width="83px" Text="Company" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="DrpCompanyName" runat="server" Width="202px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label ID="lbldesignationID" runat="server" Width="80px" Text="Location Type"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="ddDistributorType" runat="server" Width="202px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="77px" Text="Code" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtDistributorCode" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblNickName" runat="server" Width="69px" Text="Name" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:TextBox ID="txtDistributorName" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Width="96px" Text="Contact Person" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtcontactperson" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblPhNo" runat="server" Width="76px" Text="Phone No" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:TextBox ID="txtPhoneNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblAddress2" runat="server" Width="80px" Text="Address" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" colspan="4">
                                                <asp:TextBox ID="txtAddress1" runat="server" Width="532px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblAddress1" runat="server" Width="91px" Text="Email Address" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 200px; height: 24px">
                                                <asp:TextBox ID="txtAddress2" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="height: 24px">
                                            </td>
                                            <td style="height: 24px" align="left">
                                                <asp:CheckBox ID="cbRegistered" runat="server" Width="97px" Text="Is Registered"
                                                    AutoPostBack="True" OnCheckedChanged="cbRegistered_CheckedChanged"></asp:CheckBox>
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtgstno" runat="server" Width="200px" CssClass="txtBox " Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" align="left">
                                            </td>
                                            <td style="width: 200px; height: 26px">
                                                <asp:CheckBox ID="chkIsActive" runat="server" Width="97px" Text="Is Active" AutoPostBack="True"
                                                    Checked="True"></asp:CheckBox>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td style="height: 25px" align="left">
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 143px; height: 32px" align="left">
                                            </td>
                                            <td style="width: 200px; height: 32px">
                                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="84px" Font-Size="8pt"
                                                    Text="Save" ValidationGroup="vg" CssClass="Button" />
                                                <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="83px"
                                                    Font-Size="8pt" Text="Cancel" CssClass="Button" />
                                            </td>
                                            <td style="width: 1px; height: 32px">
                                            </td>
                                            <td style="height: 32px">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Visible="False" Width="69px" Text="Fax No"
                                                        CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 237px; height: 32px">
                                                <asp:TextBox ID="txtpassword" runat="server" Visible="False" Width="200px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                               
                                <td>
                                    <table class="tblhead">
                                        <tbody>
                                            <tr>
                                                <td style="color: White; font-weight: bold;">
                                                    <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label>
                                                </td>
                                                <td style="width: 170px; height: 21px">
                                                    <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                                        <asp:ListItem Value="SKU_code">All Records</asp:ListItem>
                                                        <asp:ListItem Value="Distributor_Code">Distributor Code</asp:ListItem>
                                                        <asp:ListItem Value="Distributor_Name">Distributor Name</asp:ListItem>
                                                        <asp:ListItem Value="Contact_Person">Contact Person</asp:ListItem>
                                                        <asp:ListItem Value="CONTACT_NUMBER">Contact No</asp:ListItem>
                                                        <asp:ListItem Value="TYPENAME">Distributor Type</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 224px; height: 21px">
                                                    <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                                </td>
                                                <td style="height: 21px; width: 250px">
                                                    <asp:Button ID="btnFilter" runat="server" Width="85px" Font-Size="8pt" Text="Filter"
                                                        OnClick="btnFilter_Click" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="200" BorderWidth="1px">
                                        <asp:GridView ID="GridDistributor" runat="server" Width="100%" ForeColor="SteelBlue"
                                            CssClass="gridRow2" AutoGenerateColumns="False" BackColor="White" BorderColor="White"
                                            OnPageIndexChanging="GridDistributor_PageIndexChanging" OnRowEditing="GridDistributor_RowEditing"
                                            HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="DISTRIBUTOR_ID" Visible="False" HeaderText="DISTRIBUTOR_ID">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IS_REGISTERED" Visible="False" HeaderText="IS_REGISTERED">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SUBZONE_ID" Visible="False" HeaderText="SUBZONE_ID"></asp:BoundField>
                                                <asp:BoundField DataField="ADDRESS2" Visible="False" HeaderText="ADDRESS2"></asp:BoundField>
                                                <asp:BoundField DataField="DISTRIBUTOR_CODE" HeaderText="Code">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Name">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TYPENAME" HeaderText="Type">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ADDRESS1" HeaderText="Address">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CONTACT_PERSON" HeaderText="Cantact Person">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GST_NUMBER" HeaderText="Gst Number">
                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="COMPANY_ID" Visible="False" HeaderText="COMPANY_ID">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ISDELETED" HeaderText="Status">
                                                     <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                 <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:CommandField>
                                            </Columns>
                                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
