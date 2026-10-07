<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmLeaveAllow.aspx.cs" Inherits="Forms_frmLeaveAllow" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainCopy">
    <div class="container" style="background-color: white">
    
        <h2>
            &nbsp; Leave Allow</h2>
    </div>
        
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px;">
                </td>
                <td align="center" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table style="width: 43%">
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label1" runat="server" Text="Location" Width="87px"></asp:Label>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpLocation" runat="server" CssClass="DropList" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label2" runat="server" Text="Designation" Width="90px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpDesignation" runat="server" CssClass="DropList" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpDesignation_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label6" runat="server" Text="Employee Name" Width="114px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpEmployee" runat="server" CssClass="DropList" Width="200px" AutoPostBack="True" CausesValidation="True" OnSelectedIndexChanged="DrpEmployee_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label5" runat="server" Text="Remarks" Width="91px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " Width="191px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label24" runat="server" Text="Leave Type" Width="91px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpLeaveType" runat="server" CssClass="DropList" Width="200px">
                                            <asp:ListItem Value="588">Casual </asp:ListItem>
                                            <asp:ListItem Value="589">Medical</asp:ListItem>
                                            <asp:ListItem Value="590">Annual</asp:ListItem>
                                            <asp:ListItem Value="591">Special</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="77px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10" Width="169px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="77px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10" Width="167px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label7" runat="server" Height="13px" Text="Allow Days" Width="88px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:TextBox ID="txtdays" runat="server" onfocus ="CalDate()" CssClass="txtBox " MaxLength="10" Width="87px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1" style="height: 23px">
                                    </td>
                                    <td align="left" colspan="1" style="height: 23px">
                                        <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Save"
                                            Width="86px" />
                                        <asp:Button ID="BtnClear" runat="server" Font-Size="8pt" OnClick="BtnClear_Click"
                                            Text="Clear" Width="81px" /></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1" style="height: 23px">
                                    </td>
                                    <td align="left" colspan="1" style="height: 23px">
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                            TargetControlID="txtdays" ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                            MaskType="Date" TargetControlID="txtStartDate">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                            MaskType="Date" TargetControlID="txtEndDate">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
        </table>
        
           </div>
    <div class="container"><table width="100%">
        <tr>
            <td style="width: 100px; height: 173px;">
            </td>
            <td align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                <asp:Panel ID="Panel12" runat="server" Height="136px" ScrollBars="Vertical" Width="620px" BorderColor="Gray" BorderStyle="Groove" BorderWidth="1px">
                                    <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="White" CaptionAlign="Left" CssClass="gridRow2" ForeColor="SteelBlue"
                                        HorizontalAlign="Center" Width="600px">
                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                            PreviousPageText="Previous" />
                                        <RowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="TIME_STAMP" HeaderText="Apply Date">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SLASH_DESC" HeaderText="Leave Type">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FROM_DATE" HeaderText="From Date">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TO_DATE" HeaderText="To Date">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ALLOW_DAYS" HeaderText="Days">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" />
                                        <PagerStyle BackColor="Transparent" />
                                        <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                            VerticalAlign="Middle" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                    </asp:GridView>
                                </asp:Panel>
                &nbsp; &nbsp; &nbsp;
                                
            </ContentTemplate>
        </asp:UpdatePanel>
        
             </td>
            <td style="width: 100px; height: 173px;">
            </td>
        </tr>
    </table>
    </div>
    
   
</asp:Content>
