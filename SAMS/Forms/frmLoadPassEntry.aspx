<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" 
    AutoEventWireup="true" CodeFile="frmLoadPassEntry.aspx.cs"
     Inherits="Forms_LoadPassEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 914px">
                                            <asp:Label ID="ltrAdd" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 914px">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                <tr>
                                                    <td class="tblhead" style="width: 10%;">
                                                        <asp:Label ID="lblID" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Document No" Width="99%" BackColor="#006699"></asp:Label>
                                                    </td>

                                                    <td class="tblhead" style="width: 20%;">
                                                        <asp:Label ID="lblLocation" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Sales Person" Width="100%" BackColor="#006699"
                                                            Style="margin-left: 0px"></asp:Label>
                                                    </td>


                                                    <td class="tblhead" style="width: 20%;">
                                                        <asp:Label ID="Label1" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Principal" Width="100%" BackColor="#006699"></asp:Label>
                                                    </td>
                                                    <td class="tblhead" style="width: 20%;">
                                                        <asp:Label ID="lblDocumentDate" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Route" Width="100%" BackColor="#006699"></asp:Label>
                                                    </td>
                                                    <td class="tblhead" style="width: 20%;">
                                                        <asp:Label ID="lblAmount" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Gross Amount" Width="100%" BackColor="#006699"></asp:Label>
                                                    </td>
                                                    <td class="tblhead" style="width: 10%;">
                                                        <asp:Label ID="lblUserName" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Net Amount" Width="96%" BackColor="#006699"></asp:Label>
                                                    </td>
                                                 <%--   <td class="tblhead"  style="width: 30%;">
                                                        <asp:Label ID="lblAction" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Action" Width="100%" BackColor="#006699"></asp:Label>
                                                    </td>--%>
                                                   <td class="tblhead"  style="width: 30%;">
                                                        <asp:Label ID="Label2" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Action" Width="100%" BackColor="#006699"></asp:Label>
                                                    </td><td class="tblhead"  style="width: 30%;">
                                                        <asp:Label ID="Label3" runat="server" ForeColor="White" Height="100%" Font-Bold="True"
                                                            Text="Action" Width="100%" BackColor="#006699"></asp:Label>
                                                    </td>

                                                </tr>
                                            </table>
                                            <asp:Repeater ID="rPurchaseOrder" runat="server" OnItemCommand="rPurchaseOrder_ItemCommand">
                                                <ItemTemplate>
                                                    <div style="background: #EFF3FB">
                                                        <table width="99%" border="0" cellspacing="0" cellpadding="2">
                                                            <tr>
                                                                <td style="width: 10%;">
                                                                    <%# Eval("SALE_INVOICE_ID")%>
                                                                </td>

                                                                <td style="width: 20%;">
                                                                    <%# Eval("USER_NAME")%>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <%# Eval("SKU_HIE_NAME")%>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <%# Eval("[AREA_NAME]")%>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <%# Eval("TOTAL_AMOUNT", "{0:0.00}")%>
                                                                </td>
                                                                <td style="width: 10%;">
                                                                    <%# Eval("TOTAL_NET_VALUE", "{0:0.00}")%>
                                                                </td>

                                                                <td style="width: 20%;" align="center">
                                                                    <asp:LinkButton ID="btnLoad" runat="server" CommandName="Load" CommandArgument='<%# Eval("SALE_INVOICE_ID") %>'
                                                                        ToolTip="Close" Text="Edit" OnClientClick="return confirm('Are you sure? to Edit this Load Pass.');">
                                                                    </asp:LinkButton>
                                                                </td>
                                                                  <%--<td style="width: 20%;" align="center">
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("SALE_INVOICE_ID") %> '
                                                                        ToolTip="Close" Text="Delete" OnClientClick="return confirm('Are you sure? to Delete this Load Pass.');">
                                                                    </asp:LinkButton>
                                                                </td>--%>
                                                                 <td style="width: 20%;" align="center">
                                                                    <asp:LinkButton ID="btnReturn" runat="server" CommandName="Return" CommandArgument='<%# Eval("SALE_INVOICE_ID") %> '
                                                                        ToolTip="Close" Text="Return" OnClientClick="return confirm('Are you sure? to Return this Load Pass.');">
                                                                    </asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <div style="background: #ffffff">
                                                        <table width="99%" border="0" cellspacing="0" cellpadding="2">
                                                            <tr>
                                                                <td style="width: 10%;">
                                                                    <%# Eval("SALE_INVOICE_ID")%>
                                                                </td>

                                                                <td style="width: 20%;">
                                                                    <%# Eval("USER_NAME")%>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <%# Eval("SKU_HIE_NAME")%>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <%# Eval("[AREA_NAME]")%>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <%# Eval("TOTAL_AMOUNT", "{0:0.00}")%>
                                                                </td>
                                                                <td style="width: 10%;">
                                                                    <%# Eval("TOTAL_NET_VALUE", "{0:0.00}")%>
                                                                </td>

                                                                <td style="width: 20%;" align="center">
                                                                    <asp:LinkButton ID="btnLoad" runat="server" CommandName="Load" CommandArgument='<%# Eval("SALE_INVOICE_ID") %> '
                                                                        ToolTip="Close" Text="Edit" OnClientClick="return confirm('Are you sure? to Edit this Load Pass.');">
                                                                    </asp:LinkButton>
                                                                </td>

                                                                 <%-- <td style="width: 20%;" align="center">
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("SALE_INVOICE_ID") %> '
                                                                        ToolTip="Close" Text="Delete" OnClientClick="return confirm('Are you sure? to Delete this Load Pass.');">
                                                                    </asp:LinkButton>
                                                                </td>--%>

                                                                <td style="width: 20%;" align="center">
                                                                    <asp:LinkButton ID="btnReturn" runat="server" CommandName="Return" CommandArgument='<%# Eval("SALE_INVOICE_ID") %> '
                                                                        ToolTip="Close" Text="Return" OnClientClick="return confirm('Are you sure? to Return this Load Pass.');">
                                                                    </asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </AlternatingItemTemplate>
                                            </asp:Repeater>
                                            <table width="100%">
                                                <tr>
                                                    <td align="right" width="56%">
                                                        <asp:LinkButton ID="linkbtnprev" runat="server" Enabled="False" OnClick="linkbtnprev_Click"
                                                            CausesValidation="false" Visible="false" Style="color: #6C5A10;">Previous</asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="linkbtnnext" runat="server" Enabled="False" OnClick="linkbtnnext_Click"
                                                            CausesValidation="false" Visible="false" Style="color: #6C5A10;">Next</asp:LinkButton>
                                                    </td>
                                                    <td align="right" width="44%">
                                                        <asp:Label ID="lblCurrentPageNo" runat="server" Text="" Visible="false" Style="color: #6C5A10;"></asp:Label>
                                                        <asp:Label ID="lblOf" runat="server" Text="Of" Visible="false" Style="color: #6C5A10;"></asp:Label>
                                                        <asp:Label ID="lblTotalNoOfPages" runat="server" Text="" Visible="false" Style="color: #6C5A10;"></asp:Label>
                                                        <asp:Label ID="lblDummy" runat="server" Text="| Total Records:" Visible="false" Style="color: #6C5A10;"></asp:Label>
                                                        <asp:Label ID="lblTotalNoOfRecords" runat="server" Text="" Visible="false" Style="color: #6C5A10;"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
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


