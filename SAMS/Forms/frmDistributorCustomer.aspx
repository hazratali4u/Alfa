<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributorCustomer.aspx.cs" Inherits="Forms_frmDistributorCustomer"
    Title="SAMS: New Customer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">

        function NameValidation(event) {
            // Allow: backspace, delete, tab and escape
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 32 ||
                // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
                // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39) ||
                // Allow: Dash, Underscoor
            (event.keyCode == 189) ||
                //Allow Comma,Period
            ((event.keyCode == 190 || event.keyCode == 188) && event.shiftKey === false) ||
                //Allow a-z
            (event.keyCode >= 65 && event.keyCode <= 90)) {
                // let it happen, don't do anything
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                event.preventDefault();
            }
        }

        function AddressValidation(event) {
            // Allow: backspace, delete, tab , escape and space bar
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 32 ||
                // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
                // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39) ||
                // Allow: Dash, Underscoor
            (event.keyCode == 189) ||
                // Allow: Open bracket, Close bracket
            ((event.keyCode == 57 || event.keyCode == 48) && event.shiftKey === true) ||
                //Allow Comma,Period
            ((event.keyCode == 190 || event.keyCode == 188) && event.shiftKey === false) ||
                //Allow 0-9
            ((event.keyCode >= 48 && event.keyCode <= 57) && event.shiftKey === false) || //Standard Numbers
            (event.keyCode >= 96 && event.keyCode <= 105) || //Keypad numbers
                //Allow a-z
            (event.keyCode >= 65 && event.keyCode <= 90)) {
                // let it happen, don't do anything
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                event.preventDefault();
            }
        }

        function PhoneValidation(event) {
            // Allow: backspace, delete, tab , escape
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 ||
                // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
                // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39) ||
                // Allow: Dash
            (event.keyCode == 189 && event.shiftKey === false) ||
                //Allow 0-9
            ((event.keyCode >= 48 && event.keyCode <= 57) && event.shiftKey === false) || //Standard Numbers
                //Keypad numbers
            (event.keyCode >= 96 && event.keyCode <= 105)) {
                // let it happen, don't do anything
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                event.preventDefault();
            }
        }

       <%--   function pageLoad() {
         $('#<%=txtCNIC.ClientID %>').mask("99999-9999999-9");
            $('#<%=txtNTN.ClientID %>').mask("9999999-9");
            $('#<%=txtCustomerCode.ClientID %>').mask("*******");
            $('#<%=txtIsRegister.ClientID %>').mask("99-99-9999-999-99");

            $('#<%=Grid_users.ClientID %>').tablesorter(
         {
             headers: {
                 25: {
                     sorter: false
                 }
             }
         }
         ); 

        }--%>
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(startRequest);

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);

        function startRequest(sender, e) {
            document.getElementById('<%=btnSave.ClientID%>').disabled = true;
            document.getElementById('<%=btnSearch.ClientID%>').disabled = true;
            document.getElementById('<%=btnCancel.ClientID%>').disabled = true;

        }

        function endRequest(sender, e) {

            document.getElementById('<%=btnSave.ClientID%>').disabled = false;
            document.getElementById('<%=btnSearch.ClientID%>').disabled = false;
            document.getElementById('<%=btnCancel.ClientID%>').disabled = false;
        }


        function ValidateForm() {
            var str;
            str = document.getElementById('<%=txtCustomerName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Customer Name');
                return false;
            }
            str = document.getElementById('<%=txtContactPerson.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Contact Person Name');
                return false;
            }
            str = document.getElementById('<%=txtAddress.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Address');
                return false;
            }

            str = document.getElementById('<%=txtPhoneNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Phone No');
                return false;
            }
            str = document.getElementById('<%=txtRegdate.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Register Date');
                return false;
            }

            str = document.getElementById('<%=txtCNIC.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter CNIC #');
                return false;
            }

            str = document.getElementById('<%=txtNTN.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter NTN #');
                return false;
            }


            if ($('#<%= ChbIsRegister.ClientID %>').is(':checked')) {
                str = document.getElementById('<%=txtIsRegister.ClientID%>').value;
                if (str == null || str.length == 0) {
                    alert('Must enter STRN #');
                    return false;
                }
            }


            return true;
        }

        function ValidateBank() {
            var str;
            str = document.getElementById('<%=txtBankName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Bank Name');
                return false;
            }
            str = document.getElementById('<%=txtAccountNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Account No');
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
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 133px" align="left"></td>
                                            <td style="width: 175px">
                                                <asp:Label ID="lblErrorMsg" runat="server" Width="159px" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="width: 1px">
                                                <asp:HiddenField ID="hdnCustomerID" Value="0" runat="server" />
                                            </td>
                                            <td align="left"></td>
                                            <td style="width: 219px"></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label7" runat="server" Width="77px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px">
                                                <asp:DropDownList ID="DrpDistributor" runat="server" Width="180px" CssClass="DropList"
                                                    OnSelectedIndexChanged="DrpDistributor_SelectedIndexChanged"
                                                    AutoPostBack="True" TabIndex="1">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px"></td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Width="56px" Text="Town" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 219px">
                                                <asp:DropDownList ID="DrpTown" runat="server" Width="180px" CssClass="DropList" OnSelectedIndexChanged="DrpTown_SelectedIndexChanged"
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 28px">
                                                            <strong>
                                                                <asp:Label ID="lblBankName" runat="server" Text="Bank Name" CssClass="lblbox" Height="16px"
                                                                    Width="67px"></asp:Label></strong>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBankName" runat="server" Width="180px" Font-Bold="True"
                                                                CssClass="txtBox" TabIndex="19"></asp:TextBox>

                                                            <asp:Label ID="lblBankId" runat="server" CssClass="lblbox"
                                                                Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Width="78px" Text="Route" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 12px">
                                                <asp:DropDownList ID="DrpRoute" runat="server" Width="180px" CssClass="DropList"
                                                    OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" AutoPostBack="True"
                                                    TabIndex="3">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px; height: 12px"></td>
                                            <td style="height: 12px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Width="59px" Text="Market" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 219px; height: 12px">
                                                <asp:DropDownList ID="DrpMarket" runat="server" Width="180px"
                                                    CssClass="DropList" TabIndex="4">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <table border="0">
                                                    <tr>
                                                        <td style="width: 28px">
                                                            <asp:Label ID="lblAccountNo" runat="server" CssClass="lblbox" Height="16px" Style="font-weight: 700"
                                                                Text="Account No" Width="67px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAccountNo" runat="server" CssClass="txtBox" Font-Bold="True"
                                                                Width="180px" TabIndex="20"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="lblNickName" runat="server" Width="79px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px">
                                                <asp:DropDownList ID="drpChannelType" runat="server" Width="180px"
                                                    CssClass="DropList" TabIndex="5">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px"></td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblMobileNo" runat="server" Width="96px" Text="Business Type" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 219px">
                                                <asp:DropDownList ID="DrpBusinessType" runat="server" Width="180px"
                                                    CssClass="DropList" TabIndex="6">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
                                                <asp:Button ID="btnAddBank" runat="server" AccessKey="A" CssClass="Button" Font-Size="8pt"
                                                    Text="Add Bank" ValidationGroup="vg" Width="80px" OnClick="btnAddBank_Click" TabIndex="21" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server" Width="101px" Text="Promotion Class" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 26px">
                                                <asp:DropDownList ID="DrpVolumeClass" runat="server" Width="180px"
                                                    CssClass="DropList" TabIndex="7">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px; height: 26px" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Width="106px" Text="Contact Person" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 219px; height: 26px">
                                                <asp:TextBox ID="txtContactPerson" runat="server" Width="180px" CssClass="txtBox"
                                                    MaxLength="50" TabIndex="8"></asp:TextBox>
                                            </td>
                                            <td rowspan="4">
                                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="150" Width="350"
                                                    BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px">
                                                    <asp:GridView ID="GrdBankInfo" runat="server" ForeColor="SteelBlue" CssClass="gridRow2"
                                                        BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White"
                                                        ShowHeader="true" Width="100%" BorderWidth="1" OnRowEditing="GrdBankInfo_RowEditing"
                                                        OnRowDeleting="GrdBankInfo_RowDeleting">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous"></PagerSettings>
                                                        <HeaderStyle BorderWidth="1" BorderColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Bank_Name" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="95px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Account_No" HeaderText="Account No" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="95px"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="BANK_ID" HeaderText="Account No" HeaderStyle-HorizontalAlign="Left">
                                                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowEditButton="True" HeaderText="Edit" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle BorderColor="Silver" BorderWidth="2px" Width="30px"></ItemStyle>
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        CommandName="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="45px"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label9" runat="server" Width="101px" Text="Customer Type" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 26px">
                                                <asp:DropDownList ID="DrpCustomerType" runat="server" Width="180px"
                                                    CssClass="DropList">
                                                    <asp:ListItem Value="0">Credit</asp:ListItem>
                                                    <asp:ListItem Value="1">Cash</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1px; height: 26px" valign="top"></td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label11" runat="server" CssClass="lblbox" Text="Name" Width="51px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 219px; height: 26px">
                                                <asp:TextBox ID="txtCustomerName" runat="server" CssClass="txtBox" MaxLength="100"
                                                    Width="180px" TabIndex="10"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="lblPhNo" runat="server" Width="100px" Text="Phone No" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 26px">
                                                <asp:TextBox ID="txtPhoneNo" runat="server" Width="180px" CssClass="txtBox"
                                                    MaxLength="15" TabIndex="11"></asp:TextBox>
                                            </td>
                                            <td style="width: 1px; height: 26px" valign="top"></td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblAddress" runat="server" CssClass="lblbox" Text="Address " Width="44px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 219px; height: 26px">
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox " MaxLength="250"
                                                    Width="180px" TabIndex="12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Width="100px" Text="CNIC #" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 26px">
                                                <asp:TextBox ID="txtCNIC" runat="server" Width="180px" CssClass="txtBox"
                                                    TabIndex="13"></asp:TextBox>
                                            </td>
                                            <td style="width: 1px; height: 26px" valign="top"></td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lbldesignationID0" runat="server" CssClass="lblbox" Text="Register Date"
                                                        Width="80px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 219px; height: 26px">
                                                <asp:TextBox ID="txtRegdate" runat="server" CssClass="txtBox" ReadOnly="True"
                                                    Width="180px" TabIndex="14"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="lblWHTAX" runat="server" Width="100px" Text="W.H.Tax %" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 26px">
                                                <asp:TextBox ID="txtWHTax" runat="server" Width="180px" CssClass="txtBox"
                                                    TabIndex="15"></asp:TextBox>
                                            </td>
                                            <td style="width: 1px; height: 26px" valign="top"></td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblNTN0" runat="server" CssClass="lblbox" Text="NTN #"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 219px; height: 26px">
                                                <asp:TextBox ID="txtNTN" runat="server" CssClass="txtBox" Width="180px"
                                                    TabIndex="16"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px; width: 133px;" align="left">


                                                <asp:CheckBox ID="ChbIsRegister" runat="server" Width="96px" Text="Is Register" AutoPostBack="True"
                                                    OnCheckedChanged="ChbIsRegister_CheckedChanged" TabIndex="17"></asp:CheckBox>
                                            </td>
                                            <td align="left" colspan="1">

                                                <asp:TextBox ID="txtIsRegister" runat="server" Width="180px" CssClass="txtBox "
                                                    Enabled="False" TabIndex="18"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td style="height: 26px; width: 133px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="101px" Text="Classification" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 175px; height: 26px">
                                                <asp:DropDownList ID="ddlClassification" runat="server" Width="180px"
                                                    CssClass="DropList">
                                                    <asp:ListItem Value="0">A+</asp:ListItem>
                                                    <asp:ListItem Value="1">A</asp:ListItem>
                                                    <asp:ListItem Value="2">B</asp:ListItem>
                                                    <asp:ListItem Value="3">C</asp:ListItem>
                                                    <asp:ListItem Value="4">D</asp:ListItem>
                                                    <asp:ListItem Value="5">PET</asp:ListItem>
                                                    <asp:ListItem Value="6">W/S</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="left" style="width: 133px"></td>
                                            <td style="width: 175px">
                                                <asp:Button ID="btnSave" runat="server" CssClass="Button" Font-Size="8pt" OnClick="btnSave_Click"
                                                    Text="Save" ValidationGroup="vg" Width="80px" TabIndex="22" />
                                                &nbsp;
                                                <asp:Button ID="btnCancel" runat="server" CssClass="Button" Font-Size="8pt" OnClick="btnCancel_Click"
                                                    Text="Cancel" Width="80px" TabIndex="23" />
                                            </td>
                                            <td style="width: 1px"></td>
                                            <td>
                                                <asp:CheckBox ID="chkIsActive" runat="server" Checked="True" Text="IsActive" Width="93px" />
                                            </td>
                                            <td style="width: 219px"></td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div style="z-index: 101; left: 640px; width: 100px; position: absolute; top: 244px; height: 100px">
                            &nbsp;<asp:Panel ID="Panel21" runat="server">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                    <ProgressTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                            Width="23px" />
                                        Wait Update
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset; width: 100%; border-bottom: silver thin inset; background-color: silver">
                        <tbody>
                            <tr>
                                <td style="height: 21px" align="left">
                                    <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label>
                                </td>
                                <td style="width: 170px; height: 21px" align="left">
                                    <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                        <asp:ListItem Value="CUSTOMER_CODE">Customer Code</asp:ListItem>
                                        <asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
                                        <asp:ListItem Value="CONTACT_PERSON">Contact Person</asp:ListItem>
                                        <asp:ListItem Value="CONTACT_NUMBER">Contact Number</asp:ListItem>
                                        <asp:ListItem Value="ADDRESS">Address</asp:ListItem>
                                        <asp:ListItem Value="EMAIL_ADDRESS">Email Address</asp:ListItem>
                                        <asp:ListItem Value="GEO_NAME">Town Name</asp:ListItem>
                                        <asp:ListItem Value="AREA_NAME">Route Name</asp:ListItem>
                                        <asp:ListItem Value="ROUTE_NAME">Market Name</asp:ListItem>
                                        <asp:ListItem Value="SLASH_DESC">Channel Type</asp:ListItem>
                                        <asp:ListItem>CNIC</asp:ListItem>
                                        <asp:ListItem>NTN</asp:ListItem>
                                        <asp:ListItem Value="GST_NUMBER">STRN</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 224px; height: 21px" align="left">
                                    <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                </td>
                                <td style="height: 21px" align="left" width="250">
                                    <asp:Button ID="btnSearch" runat="server" Width="85px" Font-Size="8pt" Text="Filter"
                                        OnClick="btnSearch_Click"></asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:Panel ID="Panel2" runat="server" Width="100%" Height="200px" ScrollBars="Vertical">
                        <asp:GridView ID="Grid_users" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="tablesorter"
                            HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White" BorderColor="White"
                            OnRowEditing="Grid_users_RowEditing">
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                PreviousPageText="Previous"></PagerSettings>
                            <RowStyle ForeColor="Black"></RowStyle>
                            <Columns>
                                <asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="DISTRIBUTOR_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="BUSINESS_TYPE_ID" HeaderText="BUSINESS_TYPE_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PROMOTION_CLASS" HeaderText="PROMOTION_CLASS">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CHANNEL_TYPE_ID" HeaderText="CHANNEL_TYPE_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="TOWN_ID" HeaderText="TOWN_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AREA_ID" HeaderText="AREA_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ROUTE_ID" HeaderText="ROUTE_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CONTACT_PERSON" HeaderText="Contact Person">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="EMAIL_ADDRESS" HeaderText="Email">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="GST_NUMBER" HeaderText="Gst No">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ChannelType" HeaderText="Channel Type">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="GEO_NAME" HeaderText="Town">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AREA_NAME" HeaderText="Route">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ROUTE_NAME" HeaderText="Market">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>


                                <asp:TemplateField HeaderText="Status" SortExpression="IS_ACTIVE">
                                    <ItemTemplate><%# (Boolean.Parse(Eval("IS_ACTIVE").ToString())) ? "Active" : "In Active"%></ItemTemplate>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="REGDATE">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IS_STAND" HeaderText="Stand">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IS_COOLER" HeaderText="Cooler">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CNIC" HeaderText="CNIC">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NTN" HeaderText="NTN">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="WHTAX" HeaderText="W.H.Tax">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">

                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="CLASSIFICATION_ID" HeaderText="CLASSIFICATION_ID">

                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="CUSTOMER_TYPE" HeaderText="CUSTOMER_TYPE">

                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White"></FooterStyle>
                            <PagerStyle BackColor="Transparent"></PagerStyle>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#007395"
                                Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333"></AlternatingRowStyle>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
