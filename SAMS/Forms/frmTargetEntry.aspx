<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmTargetEntry.aspx.cs" Inherits="Forms_frmTargetEntry" Title="SAMS: Target Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(startRequest);

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);

        function startRequest(sender, e) {

            document.getElementById('<%=btnTarget.ClientID%>').disabled = true;

        }

        function endRequest(sender, e) {


            document.getElementById('<%=btnTarget.ClientID%>').disabled = false;

        }

        function ConfirmDelete() {
            if (confirm("Do you want to Cancel this record?") == true)
                return true;

            else {
                return false;
            }
        }

        function ValidateForm() {
            var radiolist = document.getElementById('<%= RbTargetMode.ClientID %>');
            var radio = radiolist.getElementsByTagName("input");
            var type;
            for (var x = 0; x < radio.length; x++) {
                if (radio[x].checked) {
                   type= radio[x].value;
                }
            }
             
               
            var str;

            str = document.getElementById('<%=txtSkuAmount.ClientID%>').value;
            if ((str == null || str.length == 0) && type == 1) {
                alert('Must Enter Amount');
                return false;
            }
            str = document.getElementById('<%=txtFromdate.ClientID%>').value;
            if (str == null || str.length <= 1) {
                alert('Must Select Target Month');
                return false;
            }
            str = document.getElementById('<%=drpPrincipal.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select Principal');
                return false;
            }
            str = document.getElementById('<%=drpDistributor.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select Distributor');
                return false;
            }

            return true;
        }
        function SearchSKUCode() {
          
            var str = document.getElementById("<%= lstCode.ClientID %>").value;
           
            var stroption = document.getElementById("<%= txtSkuCode.ClientID %>").value;

            if (str.length > 0) {
              
                document.getElementById("<%= txtSkuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
                document.getElementById("<%= txtSkuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));

                document.getElementById("<%= txtTP.ClientID %>").value = str.substring(str.indexOf(':') + 1, str.length - 1);
                document.getElementById("<%= Panel3.ClientID %>").className = "HidePanel";

            }
            else if (stroption.length == 0) {
           
                document.getElementById("<%= Panel3.ClientID %>").className = "ShowPanel";
                document.getElementById("<%= lstCode.ClientID %>").focus();
            }
            ClearSelection(document.getElementById('<%= lstCode.ClientID %>'));
        }
        function SearcSKUList(e) {

            var l = document.getElementById('<%= lstCode.ClientID %>');

            var tb = document.getElementById('<%= txtSkuCode.ClientID %>');

            if (e.keyCode == 27) {
              
            }
            else {
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

        }
        function SelectSkuCode(e) {

            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                var str = document.getElementById("<%= lstCode.ClientID %>").value;
                document.getElementById("<%= txtSkuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
                document.getElementById("<%= txtSkuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));

                document.getElementById("<%= txtTP.ClientID %>").value = str.substring(str.indexOf(':') + 1, str.length - 1);
                document.getElementById("<%= Panel3.ClientID %>").className = "HidePanel";
                document.getElementById("<%= txtQuantity.ClientID %>").focus();
            }
                     }
        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }



        function CalculateNetSaleUnit() {
          
            var tp = document.getElementById("<%= txtTP.ClientID %>").value;
            var qty = document.getElementById("<%= txtQuantity.ClientID %>").value;
            var net = tp * qty;
            document.getElementById("<%= txtSkuAmount.ClientID %>").value = Math.round(net * 100) / 100;
          return true;
        }







    </script>
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upSearchResults" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                                <tr>
                                    <td colspan ="4">
                                    
                                    <asp:Label ID="lblerror" runat="server" CssClass="lblbox" Height="14px" Text=""
                                                   Visible="false"  Width="98px"></asp:Label>
                                                   <asp:Label ID="lblSkiId" runat="server" CssClass="lblbox" Height="14px" Text=""
                                                   Visible="false"  Width="98px"></asp:Label>
                                    </td></tr>
                                        <tr>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="lblTargetType" runat="server" CssClass="lblbox" Height="14px" Text="Target Type"
                                                        Width="98px"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="RbTargetMode" runat="server" Width="228px" Height="1px"
                                                    RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RbTargetMode_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="1">Value Wise</asp:ListItem>
                                                    <asp:ListItem Value="2">Sku Wise</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                            </td>
                                            <td rowspan ="4">
                                            <asp:Panel ID ="Panel3" runat="server" Width="327px" Height="100px" BorderWidth="1px"
                                                       BorderStyle="Inset" BorderColor="White" BackColor="Silver" CssClass="HidePanel" >

                                             <asp:ListBox ID="lstCode" onkeydown="SelectSkuCode(event)" runat="server" Width="95%"
                                            Height="87%" SelectionMode="Multiple"></asp:ListBox>
                                             </asp:Panel>
                                            
                                            
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lblLocation" runat="server" CssClass="lblbox" Height="14px" Text="Location"
                                                        Width="98px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="drpDistributor" runat="server" CssClass="DropList" Width="212px"
                                                    OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lblprincipal" runat="server" Width="71px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="drpPrincipal" runat="server" Width="211px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lbltargetfortype" runat="server" Width="98px" Text="Target For Type"
                                                        CssClass="lblbox" Height="14px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpTargetType" runat="server" Width="211px" CssClass="DropList"
                                                    OnSelectedIndexChanged="DrpTargetType_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="96">Order Booker</asp:ListItem>
                                                    <asp:ListItem Value="97">Sale Person</asp:ListItem>
                                                    <asp:ListItem Value="98">Town</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lblDocumentNo" runat="server" Width="76px" Text="Target For" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpTargetFor" runat="server" Width="210px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                        
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="72px" Text="For Month" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:TextBox ID="txtFromdate" runat="server" Width="204px" CssClass="txtBox" MaxLength="1"></asp:TextBox>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                                    Width="16px" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lbltargetvalue" runat="server" CssClass="lblbox" Text="Target Value"
                                                        Width="97px"></asp:Label></strong>
                                            </td>
                                            <td align="left" style="height: 30px">
                                                <asp:TextBox ID="txttargetAmount" runat="server" CssClass="txtBox" Width="204px">0</asp:TextBox>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px" valign="top">
                                            </td>
                                            <td style="width: 1px; height: 25px;" valign="top">
                                                <%@register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                                <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="MMM-yyyy" PopupButtonID="ibtnStartDate"
                                                    TargetControlID="txtFromdate">
                                                </cc1:CalendarExtender>
                                                <asp:Button ID="btnTarget" runat="server" Font-Size="8pt" Text="Save" ValidationGroup="vg"
                                                    Width="95px" OnClick="btnTarget_Click" CssClass="Button" />
                                            </td>
                                            <td style="width: 1px; height: 25px;" valign="top">

                                            </td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                    <asp:UpdatePanel ID ="panel" runat="server" >
                    <ContentTemplate>
                        <asp:Panel ID="pnlskydetail" runat="server" BorderColor ="Silver" >
                            <table id ="tblskudetail" border="1"> 
                                                           <tr>
                                    <td style="width: 82px;">
                                        <strong><span id="lblskuCode" class="tblhead" style="display: inline-block; color: White;
                                            font-weight: bold; width: 75px;">SKU Code</span></strong>
                                    </td>
                                    <td style="width: 200px;">
                                        <strong><span id="lblskuname" class="tblhead" style="display: inline-block; color: White;
                                            font-weight: bold; width: 195px;">SKU Name</span></strong>
                                    </td>
                                    <td style="width: 62px;">
                                        <strong><span id="lblquantity" class="tblhead" style="display: inline-block; color: White;
                                            font-weight: bold; height: 16px; width: 62px;">Quantity</span></strong>
                                    </td>
                                    <td style="width: 70px;">
                                        <strong><span id="lblFreeSKU" class="tblhead" style="display: inline-block; color: White;
                                            font-weight: bold; height: 16px; width: 70px;">SKU Rate</span></strong>
                                    </td>
                                    <td style="width: 70px;">
                                        <strong><span id="lblBatchNo" class="tblhead" style="display: inline-block; color: White;
                                            font-weight: bold; height: 16px; width: 70px;">Amount</span></strong>
                                    </td>
                                    <td>
                                        <strong><span id="Label41" class="tblhead" style="display: inline-block; color: White;
                                            font-weight: bold; height: 16px; width: 85px;">Add SKU</span></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtSkuCode" runat="server" Width="68px" CssClass="txtBox" onkeyup="SearcSKUList(event)"></asp:TextBox>
                                    </td>
                                    <td style="width: 200px;">
                                        <asp:TextBox ID="txtSkuName" runat="server" Width="181px" Font-Bold="True" CssClass="txtBox"
                                            Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox " onfocus="SearchSKUCode()" Width="55px" onblur="CalculateNetSaleUnit()"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTP" runat="server" CssClass="txtBoxnNum" Enabled="False"
                                            Width="72px"></asp:TextBox>
                                        <td>
                                            <asp:TextBox ID="txtSkuAmount" runat="server" CssClass="txtBoxnNum" Width="72px" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAddSku" runat="server" Font-Size="8pt" Text="Add Sku" ValidationGroup="vg"
                                                Width="100px" AccessKey="A" CssClass="Button" OnClick="btnAddSku_Click" />
                                        </td>
                                </tr>
                            </table>
                        </asp:Panel>
                           </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td colspan="6">
                                            <asp:Panel ID="pnlgrdSkuDetail" runat="server" BorderColor="Silver" BorderStyle="Groove"
                                                BorderWidth="1px" Height="100px" ScrollBars="Vertical" Width="656px">
                                                <asp:GridView ID="GrdSkuDetail" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    Width="632px" ShowHeader="False" 
                                                    onselectedindexchanged="GrdSkuDetail_SelectedIndexChanged"  OnRowDeleting="GrdSkuDetail_RowDeleting" OnRowEditing="GrdSkuDetail_RowEditing">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <Columns>
                                                        <asp:BoundField DataField="SKU_ID" HeaderText="TARGET_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_Code" HeaderText="Sku Code">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_Name" HeaderText="Description">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QUANTITY" HeaderText="Description"   >
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UNIT_PRICE" HeaderText="Sku Rate"  DataFormatString="{0:f2}" >
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="Sku Amount"  DataFormatString="{0:f2}" >
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
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
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                      
                                    </tr>
                                    <tr>
                                      <td colspan="6">                                        
                                            <asp:Panel ID="PnlGrdPurchase" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                                Height="100px" ScrollBars="Vertical" Width="656px">
                                                <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                                   Width="632px">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <Columns>
                                                        <asp:BoundField DataField="TARGET_ID" HeaderText="TARGET_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TARGET_FOR_ID" HeaderText="TARGET_FOR_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="USER_CODE" HeaderText="Code">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="85px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="User_NAME" HeaderText="Description">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TARGET_MONTH" HeaderText="Target Month">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AMOUNT" HeaderText="Value" DataFormatString="{0:F2}">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
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
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="6">
                                            <asp:Panel ID="PnlGrdTargetView" runat="server" BorderColor="Silver" BorderStyle="Groove"
                                                BorderWidth="1px" Height="100px" ScrollBars="Vertical" Width="656px">
                                                <asp:GridView ID="GrdTargetView" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    Width="632px" ShowHeader="False" onRowDeleting="GrdTargetView_RowDeleting" OnRowEditing="GrdTargetView_RowEditing">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
                                                    <Columns>
                                                           <asp:BoundField DataField="TARGET_ID" HeaderText="TARGET_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_Code" HeaderText="Sku Code">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SKU_Name" HeaderText="Description">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QUANTITY" HeaderText="Description"   >
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UNIT_PRICE" HeaderText="Sku Rate"  DataFormatString="{0:f2}" >
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="Sku Amount"  DataFormatString="{0:f2}" >
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                                Width="205px" />
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
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                      
                                    </tr>
                                </table>
                                &nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            &nbsp;
        </div>
    </div>
</asp:Content>
