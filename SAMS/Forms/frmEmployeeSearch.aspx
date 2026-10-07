<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmEmployeeSearch.aspx.cs" Inherits="Forms_frmEmployeeSearch" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">
    <div class="container" style="background-color: white">
        <h2>
            &nbsp; Employee Information Step 1</h2>
    </div>
       
     
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px; height: 13px;">
                </td>
                <td style="width: 100px; height: 13px;">
                </td>
                <td style="width: 100px; height: 13px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 18px">
                </td>
                <td align="center">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="12px" RepeatDirection="Horizontal"
                        Width="247px">
                        <asp:ListItem Selected="True" Value="EMPLOYEE_ID">Id</asp:ListItem>
                        <asp:ListItem Value="EMPLOYEE_NAME">Name</asp:ListItem>
                        <asp:ListItem Value="NIC_NO">NIC No</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 30px">
                </td>
                <td align="center">
                    <asp:TextBox ID="txtSeach" runat="server" Height="17px"
                        Width="308px"></asp:TextBox></td>
                <td style="width: 100px; height: 30px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 30px">
                </td>
                <td align="center">
                    <asp:Button ID="Button2" runat="server" Font-Size="8pt" Height="25px" OnClick="Button2_Click"
                        Text="Search" Width="105px" />
                    <asp:Button ID="Button1" runat="server" Font-Size="8pt" Height="25px" OnClick="Button1_Click"
                        Text="New Entry" Width="102px" />
                    </td>
                <td style="width: 100px; height: 30px">
                </td>
            </tr>
        </table>
    </div>
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 30px">
                </td>
                <td align="center" style="width: 100px; height: 30px">
                                <asp:GridView ID="Grid_users" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center" Width="100%" OnRowEditing="Grid_users_RowEditing">
                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                        PreviousPageText="Previous" />
                                    <RowStyle ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Id">
                                            <ItemStyle BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Name">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Location">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CELL_NO" HeaderText="Contact No">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMAIL_ADDRESS" HeaderText="Email">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Address" DataField="PRESENT_ADDRESS">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="White" />
                                    <PagerStyle BackColor="Transparent" />
                                    <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                        VerticalAlign="Middle" />
                                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                </asp:GridView>
                </td>
                <td style="width: 100px; height: 30px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 30px">
                </td>
                <td align="center" style="width: 100px; height: 30px">
                </td>
                <td style="width: 100px; height: 30px">
                </td>
            </tr>
        </table>
    </div> 
</asp:Content>

