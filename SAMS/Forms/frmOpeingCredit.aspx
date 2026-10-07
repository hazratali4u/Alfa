<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmOpeingCredit.aspx.cs" Inherits="Forms_frmOpeingCredit" Title="SAMS: Opening Credit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
<script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">

        function ValidateForm() {
            var str;
            str = document.getElementById("<%= txtOutletCode.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must enter Outlet Code');
                return false;
            }
         
            str = document.getElementById("<%= txtAmount.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must Enter Amount');
                return false;
            }
          
            str = document.getElementById("<%= txtChequeNo.ClientID %>").value;
            if (str == null || str.length <= 1) {
                alert('Must Enter Invoice No');
                return false;
            }
        }
        function SearchList() {
            var l = document.getElementById('<%= ListCustomer.ClientID %>');
            var tb = document.getElementById('<%= txtOutletCode.ClientID %>');

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
        function SearchedCode() {
            var str = document.getElementById("<%= ListCustomer.ClientID %>").value;
            var stroption = document.getElementById("<%= txtOutletCode.ClientID %>").value;
            if (str.length > 0) {
                document.getElementById("<%= txtOutletCode.ClientID %>").value = str.substring(str.indexOf('|') + 2);
                document.getElementById("<%= txtOutletName.ClientID %>").value = str.substring(0, str.indexOf('|'));

            }
            ClearSelection(document.getElementById('<%= ListCustomer.ClientID %>'));

        }
        function SelectCode(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                var str = document.getElementById("<%= ListCustomer.ClientID %>").value;
                document.getElementById("<%= txtOutletCode.ClientID %>").value = str.substring(str.indexOf('|') + 2);
                document.getElementById("<%= txtOutletName.ClientID %>").value = str.substring(0, str.indexOf('|'));
                document.getElementById("<%= txtChequeNo.ClientID %>").focus();
            /* document.getElementById(" txtOutletCode.ClientID ").value = "OT" + str.substring(str.indexOf('|') + 2)  */    
            }
        }
        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }
        function pageLoad() {

            $("select").searchable();

            var Str = $('#<%=DrpCustomer.ClientID %> option:selected').text();
             document.getElementById("<%= txtOutletCode.ClientID %>").value=Str.substring(Str.indexOf('|') + 2,Str.indexOf('~'));
             document.getElementById("<%= txtOutletName.ClientID %>").value=Str.substring(0,Str.indexOf('|'));
          

            $('#<%=DrpCustomer.ClientID %>').change(function () {
               var Str = $('#<%=DrpCustomer.ClientID %> option:selected').text();
                document.getElementById("<%= txtOutletCode.ClientID %>").value=Str.substring(Str.indexOf('|') + 2,Str.indexOf('~'));
                 document.getElementById("<%= txtOutletName.ClientID %>").value=Str.substring(0,Str.indexOf('|'));
            });

        }
    </script>
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td style="width: 109px" align="left" colspan="1">
                                            </td>
                                            <td align="left" colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Width="89px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 109px" align="left">
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DrpRoute" runat="server" Width="308px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label7" runat="server" Width="94px" Text="Credit Type" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DrpCreditType" runat="server" Width="200px" 
                                                    CssClass="DropList" onselectedindexchanged="DrpCreditType_SelectedIndexChanged" AutoPostBack ="true">
                                                    <asp:ListItem Value="24">New Credit</asp:ListItem>
                                                    <asp:ListItem Value="25">Opening Credit</asp:ListItem>
                                                    <asp:ListItem Value="26">Credit Transfer In</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 109px" align="left">
                                            </td>
                                            <td align="left" rowspan="11" valign="top">
                                               <asp:DropDownList ID="DrpCustomer" runat="server" Width="308px" CssClass="DropList"
                                                   >
                                                </asp:DropDownList>
                                                <asp:ListBox ID="ListCustomer" onkeydown="SelectCode(event)" runat="server" Width="310px"
                                                    Height="210px" CssClass="DropList" Visible="false"></asp:ListBox>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lblfromLocation" runat="server" Width="94px" Text="Distributor" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 109px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblDocumentNo" runat="server" Width="32px" Text="            " CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 21px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Width="89px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 21px">
                                                <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="200px" 
                                                    CssClass="DropList" AutoPostBack="True"
                                                    onselectedindexchanged="DrpDeliveryMan_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 21px; width: 109px;" align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="89px" Text="Bill Date" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:TextBox Style="text-align: justify" ID="txtFromdate" 
                                                    runat="server" Width="192px" CssClass="txtBox" MaxLength="1" ></asp:TextBox>
                                            </td>
                                            <td align="left" style="width: 109px">
                                                <asp:ImageButton ID="ImgBntFromCalc" runat="server" CausesValidation="False" Enabled ="false" 
                                                    ImageUrl="~/App_Themes/Granite/Images/date.gif" Width="17px" ></asp:ImageButton>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" align="left">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Width="94px" Text="Customer Code" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td valign="bottom" align="left">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server" Width="94px" Text="Customer Name" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td valign="bottom" align="left" style="width: 109px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="txtOutletCode" onkeyup="SearchList()" runat="server" Width="112px"
                                                    CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtOutletName" runat="server" Width="193px" ForeColor="Black" Font-Bold="True"
                                                    CssClass="txtBox " Enabled="False"></asp:TextBox>
                                            </td>
                                            <td valign="top" style="width: 109px">
                                                <asp:HiddenField ID="hfPrincipalID" runat="server" __designer:wfdid="w1" Value="-1">
                                                </asp:HiddenField>
                                                <asp:HiddenField ID="hfLegendID" runat="server" Visible="False" __designer:wfdid="w2"
                                                    Value="-1"></asp:HiddenField>
                                                <asp:HiddenField ID="hfCustomerID" runat="server" __designer:wfdid="w3" Value="-1">
                                                </asp:HiddenField>
                                                <asp:HiddenField ID="hfSaleInvoiceID" runat="server" __designer:wfdid="w4" Value="-1">
                                                </asp:HiddenField>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Width="94px" Text="Invoice No" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 201px" valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Width="74px" Text="Amount" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td valign="top" align="left" style="width: 109px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="txtChequeNo" onfocus="SearchedCode()" runat="server" Width="112px"
                                                    CssClass="uppercase" MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="txtAmount" runat="server" Width="118px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td valign="top" align="left" style="width: 109px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <strong>
                                                    <asp:Label ID="Label9" runat="server" Width="73px" Text="Remarks" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td valign="top" align="left">
                                            </td>
                                            <td valign="top" align="left" style="width: 109px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px" valign="top" align="left" colspan="2">
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="239px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td style="height: 22px; width: 109px;" valign="top" align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                            </td>
                                            <td align="left" colspan="1" style="width: 109px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 36px" align="left">
                                                <asp:Button AccessKey="S" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="119px"
                                                    Font-Size="8pt" Text="Save" CssClass="Button" />
                                                <div style="z-index: 101; left: 503px; width: 100px; position: absolute; top: 251px;
                                                    height: 100px">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                        <ProgressTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                                Width="22px" />
                                                            Record Update
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </div>
                                            </td>
                                            <td style="width: 201px; height: 36px" valign="middle" align="left">
                                                <asp:Button AccessKey="C" ID="btnCancel" OnClick="btnCancel_Click" runat="server"
                                                    Width="120px" Font-Size="8pt" Text="Cancel" CssClass="Button" />
                                            </td>
                                            <td style="width: 109px; height: 36px" valign="middle" align="left">
                                            </td>
                                            <td style="width: 201px; height: 36px" valign="middle" align="left">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmount">
                                </ajaxToolkit:FilteredTextBoxExtender>                                     
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  
                                    TargetControlID="txtFromdate" Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc">
                                </ajaxToolkit:CalendarExtender>
                                &nbsp;
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DrpRoute" EventName="SelectedIndexChanged">
                                </asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                        width: 650px; border-bottom: silver thin inset">
                        <tbody>
                            <tr>
                                <td style="height: 20px; width: 786px;" align="left" colspan="5">
                                    <asp:Panel ID="Panel12" runat="server" Width="781px" Height="200px" 
                                        ScrollBars="Vertical">
                                        <asp:GridView ID="GrdOrder" runat="server" Width="770px" ForeColor="SteelBlue" CssClass="gridRow2"
                                            AutoGenerateColumns="False" BackColor="White" BorderColor="White" HorizontalAlign="Center"
                                            OnRowEditing="GrdOrder_RowEditing" OnRowDeleting="GrdOrder_RowDeleting">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous"></PagerSettings>
                                            <Columns>
                                                <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PRINCIPAL_ID" HeaderText="PRINCIPAL_ID">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Principal">
                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Invoice Date">
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" Text='<%# Bind("DOCUMENT_DATE") %>' ID="TextBox1"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Bind("DOCUMENT_DATE", "{0:dd-MM-yyyy}") %>' ID="Label1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                    </ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SALE_INVOICE_ID" HeaderText="Invoice No">
                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CURRENT_CREDIT_AMOUNT" HeaderText="Credit Amount">
                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LEGEND_ID" HeaderText="LEGEND_ID">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="CUSTOMER_CODE">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="DOCUMENT_DATE">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SALE_INVOICE_MASTER_ID" HeaderText="SALE_INVOICE_MASTER_ID">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="AREA_ID" HeaderText="AREA_ID">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>

                                                </asp:BoundField>
                                                
                                                
                                                   <asp:BoundField DataField="DELIVERYMAN_ID" HeaderText="DELIVERYMAN_ID">
                                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                    <ItemStyle CssClass="HidePanel"></ItemStyle>

                                                </asp:BoundField>
                                                <asp:CommandField ShowEditButton="True" ShowHeader="True" HeaderText="Edit">
                                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                            CommandName="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead">
                                            </HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
