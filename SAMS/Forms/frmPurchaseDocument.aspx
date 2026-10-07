<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmPurchaseDocument.aspx.cs" Inherits="Forms_frmPurchaseDocument" Title="SAMS: Stock Register" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
   <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">

        function ValidateForm() {
            var str;

          
            str = document.getElementById('<%=txtQuantity.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Quantity');
                return false;
            }

            str = document.getElementById('<%=txtDocumentNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Invoice/DC No');
                return false;
            }

            str = document.getElementById('<%=txtBuiltyNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Builty No');
                return false;
            }

            return true;
        }

        function pageLoad() {

            $("select").searchable();
        }
       function fillB()
       {
           var net = 0;
           var txtA = document.getElementById('<%=txtTotalAmount.ClientID%>').value;
           var txtB = document.getElementById('<%=txtfreight.ClientID%>').value;
           if (parseFloat(txtB) > 0) {
                net = parseFloat(txtA) - parseFloat(txtB);
           } else
           {
                net = parseFloat(txtA)
           }
           document.getElementById('<%=txtNetAmount.ClientID%>').value = net;
          
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
                                            <td style="height: 24px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" CssClass="lblbox" Height="14px" Text="Transaction Type"
                                                        Width="128px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 24px">
                                                <asp:DropDownList ID="DrpDocumentType" runat="server" AutoPostBack="True" CssClass="DropList"
                                                    OnSelectedIndexChanged="DrpDocumentType_SelectedIndexChanged" Width="200px">
                                                    <asp:ListItem Value="2">Purchase</asp:ListItem>
                                                   <%-- <asp:ListItem Value="5">Transfer Out</asp:ListItem>
                                                    <asp:ListItem Value="3">Purchase Return</asp:ListItem>
                                                    <asp:ListItem Value="4">Transfer In</asp:ListItem>
                                                    <asp:ListItem Value="6">Damage(Replace)</asp:ListItem>
                                                    <asp:ListItem Value="10">Damage(Return)</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 24px">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Width="5px"></asp:Label></strong>
                                            </td>
                                            <td style="width: 316px;" align="center" colspan="1" rowspan="8" valign="middle">
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lblDocumentNo" runat="server" Text="Document No" Width="94px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="drpDocumentNo" runat="server" AutoPostBack="True" CssClass="DropList"
                                                    OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Principal" Width="94px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="drpPrincipal" runat="server" AutoPostBack="True" CssClass="DropList"
                                                    OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px">
                                                <strong>
                                                    <asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" Text="Purchase For"
                                                        Width="94px"></asp:Label></strong>
                                            </td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="drpDistributor" runat="server" AutoPostBack="True" CssClass="DropList"
                                                    Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Transfer To" Visible="False"
                                                        Width="124px" Height="16px"></asp:Label></strong>
                                            </td>
                                            <td >
                                                <asp:DropDownList ID="DrpTransferFor" runat="server" CssClass="DropList" Visible="False"
                                                    Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Invoice #" Width="94px"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDocumentNo" runat="server" CssClass="txtBox" Width="195px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Dispatch Note #" Width="94px"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBuiltyNo" runat="server" CssClass="txtBox" Width="195px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Remarks" Width="94px"></asp:Label></strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Height="30px" runat="server" CssClass="txtBox" Width="192px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px" valign="top" align="left">
                                                <asp:CheckBox ID="ChbBatchNo" runat="server" AutoPostBack="True" OnCheckedChanged="ChbBatchNo_CheckedChanged"
                                                    Text="Batch No" Width="77px" Visible="false" />
                                            </td>
                                            <td style="height: 25px; width: 1px;" valign="top">
                                                <asp:CheckBox ID="ChbFreeSKU" runat="server" Width="121px" Text="Apply Free SKU"
                                                    AutoPostBack="True" OnCheckedChanged="ChbFreeSKU_CheckedChanged" Visible="true">
                                                </asp:CheckBox>
                                            </td>
                                            <td style="width: 1px; height: 25px" valign="top">
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
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                              
                                                <asp:Label ID="lblskuname" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="   SKU Name" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblquantity" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Quantity CTN" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUnits" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Quantity Unit" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Free Unit" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="Label9" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Amount" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:Label ID="Label41" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Add SKU" CssClass="lblbox" BackColor="#006699"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                   <asp:DropDownList ID="ddlSKuCde" runat="server" Width="316px" >
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuantity"  runat="server" Width="80px"
                                                    CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox>
                                            </td>
                                            <td>
                                             <asp:TextBox ID="txtFreeSKU" runat="server" CssClass="txtBox" Enabled="False" Width="80px"
                                            >0</asp:TextBox></td>
                                             <td>
                                             <asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" Enabled="False" Width="80px"
                                            ></asp:TextBox></td>
                                            <td style="width: 100px">
                                                <asp:Button AccessKey="A" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="100px"
                                                    Font-Size="8pt" Text="Add Sku" ValidationGroup="vg" CssClass="Button" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7">
                                                <asp:TextBox ID="txtBatchNo" runat="server" Width="80px" CssClass="txtBox" Enabled="False"
                                                    Visible="False">N/A</asp:TextBox>
                                               
                                                <asp:TextBox ID="txtTransitDamage" runat="server" CssClass="txtBox" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="7">
                                                <asp:Panel ID="Panel2" runat="server" Width="100%" Height="130px" ScrollBars="Vertical"
                                                    BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                    <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                        OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                                        ShowHeader="False" Width="100%">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous" />
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                                    Width="75px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                                    Width="225px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                    Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="QuantityUnit" HeaderText="Quantity">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                    Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FREE_SKU" HeaderText="Free SKU">
                                                              <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                    Width="80px" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="AMOUNT_GST" HeaderText="AMOUNT">
                                                              <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                    Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TDAMAGE" HeaderText="T.DAMAGE">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                                <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="35px" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="45px" />
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
                                    </tbody>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 342px" colspan="2" align="right">
                                            <strong>
                                                <asp:Label ID="lblTotalCtn" runat="server" Width="103px" Height="16px" Text="Total"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalQuantityCtn" runat="server" Width="80px" CssClass="txtBox"
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                       
                                        <td>
                                            <asp:TextBox ID="txtTotalQuantity"  runat="server" Width="80px"
                                                CssClass="txtBox" ReadOnly="True" style="margin-left: 0px"></asp:TextBox>
                                        </td>
                                        
                                        <td>
                                            <asp:TextBox ID="txtTotalFreesku" runat="server" Width="80px" CssClass="txtBox" ReadOnly="True"  ></asp:TextBox>
                                            </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalAmount" runat="server" Width="80px" CssClass="txtBox" ReadOnly="True"  ></asp:TextBox>
                                            <asp:TextBox ID="txtTotalTDamage" runat="server" Width="80px" CssClass="txtBox" ReadOnly="True" Visible="false" ></asp:TextBox>
                                        </td>
                                    </tr>
                                                                        <tr>
                                        <td style="width: 92px" colspan="2" align="right">
                                            <strong>
                                                <asp:Label ID="Label10" runat="server" Width="103px" Height="16px" Text="Freight Amount"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtfreight" runat="server" Width="80px" CssClass="txtBox" onblur="fillB()"
                                               ></asp:TextBox>
                                        </td>
                                        <td>
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" Width="78px" Height="16px" Text="Net Amount"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNetAmount"  runat="server" Width="80px"
                                                CssClass="txtBox" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td></td>
                                      
                                    </tr>
                                    <tr>
                                        <td colspan="6">

                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 92px">
                                            <asp:Button AccessKey="S" ID="btnSaveDocument" runat="server" Width="119px" Font-Size="8pt"
                                                Text="Save Document" UseSubmitBehavior="False" OnClick="btnSaveDocument_Click"
                                                CssClass="Button" />
                                        </td>
                                        <td>
                                            <asp:Button AccessKey="C" ID="btnCancel" runat="server" Width="120px" Font-Size="8pt"
                                                Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" CssClass="Button" />
                                        </td>
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">

                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
