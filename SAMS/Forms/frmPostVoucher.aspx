<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmPostVoucher.aspx.cs" Inherits="Forms_frmPostVoucher" Title="SAMS: Voucher Posting" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
<div id="right_data">
     <div>
     <table width="100%">
         <tr>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px" align=left>
<strong> <asp:Label id="lbltoLocation" runat="server" Width="67px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 100px"><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList">
                                     </asp:DropDownList></TD><TD style="HEIGHT: 25px"></TD></TR><TR><TD style="WIDTH: 100px" align=left>
                                     <strong><asp:Label id="Label3" runat="server" Width="104px" Text="Voucher Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 100px"><asp:DropDownList id="DrpVoucherType" runat="server" Width="200px" CssClass="DropList">
                                         <asp:ListItem Value="14">Cash Voucher</asp:ListItem>
                                         <asp:ListItem Value="15">Bank Voucher</asp:ListItem>
                                         <asp:ListItem Value="16">Journal Voucher</asp:ListItem>
                                     </asp:DropDownList></TD><TD style="HEIGHT: 25px"></TD></TR><TR><TD style="WIDTH: 100px" vAlign=middle align=left>
                                     <strong><asp:Label id="Label1" runat="server" Width="104px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 100px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
                                     </asp:DropDownList></TD><TD style="HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 100px" vAlign=middle align=left>
                                     <strong><asp:Label id="Label4" runat="server" Width="70px" Height="13px" Text="From Date"></asp:Label></strong></TD><TD style="WIDTH: 100px" align=left><asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="190px" CssClass="txtBox" MaxLength="10"></asp:TextBox></TD><TD style="HEIGHT: 25px" align=left><asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 100px" vAlign=middle align=left>
                                     <strong><asp:Label id="Label5" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong></TD><TD style="WIDTH: 100px" align=left><asp:TextBox id="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server" Width="191px" CssClass="txtBox " MaxLength="10"></asp:TextBox></TD><TD style="HEIGHT: 25px" align=left><asp:ImageButton id="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD vAlign=top align=left>&nbsp;</TD><TD align=left><cc1:CalendarExtender id="CEStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
                                     </cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
                                     </cc1:CalendarExtender> </TD><TD align=left></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 12px" vAlign=top align=left><asp:CheckBox id="ChbSelect" runat="server" Width="115px" Text="All Select" OnCheckedChanged="ChbSelect_CheckedChanged" AutoPostBack="True"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 12px" align=left>
                                     <asp:Button id="btnView" onclick="btnView_Click" runat="server" Width="80px" Font-Size="8pt" Text="View" CssClass="Button" />
                                     <asp:Button id="btnPost" runat="server" Width="80px" Font-Size="8pt" Text="Post" OnClick="btnPost_Click" CssClass="Button" /> <DIV style="Z-INDEX: 101; LEFT: 368px; WIDTH: 100px; POSITION: absolute; TOP: 242px; HEIGHT: 100px"><asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                             <ProgressTemplate>
                                                 <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                     Width="22px" />
                                                 Record Update
                                             </ProgressTemplate>
                                         </asp:UpdateProgress> </DIV></TD><TD style="HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE>
</ContentTemplate>
                 </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                     <ContentTemplate>
                         <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2px"
                             Height="150px" ScrollBars="Vertical" Width="650px">
                             <asp:GridView ID="GrdLedger" runat="server" AutoGenerateColumns="False" BackColor="White"
                                 BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                 OnRowEditing="GrdLedger_RowEditing" Width="628px">
                                 <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                     PreviousPageText="Previous" />
                                 <Columns>
                                     <asp:TemplateField HeaderText="Voucher">
                                         <ItemTemplate>
                                             <asp:CheckBox ID="ChbSelect" runat="server" />
                                         </ItemTemplate>
                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="VOUCHER_NO" HeaderText="Voucher No">
                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Ledger_date" HeaderText="Voucher Date">
                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" Width="250px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="VOUCHER_TYPE_ID" HeaderText="VOUCHER_TYPE_ID">
                                         <HeaderStyle CssClass="HidePanel" />
                                         <ItemStyle CssClass="HidePanel" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="VOUCHER_DATE" HeaderText="VOUCHER_DATE">
                                         <HeaderStyle CssClass="HidePanel" />
                                         <ItemStyle CssClass="HidePanel" />
                                     </asp:BoundField>
                                     <asp:CommandField EditText="View" HeaderText="Detail" ShowEditButton="True">
                                         <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                     </asp:CommandField>
                                 </Columns>
                                 <HeaderStyle CssClass="tblhead" HorizontalAlign="Center"
                                     VerticalAlign="Middle" />
                             </asp:GridView>
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="2px"
                                                    Height="150px" ScrollBars="Vertical" Width="650px">
                                                <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CaptionAlign="Left" CssClass="gridRow2" ForeColor="SteelBlue"
                                                    HorizontalAlign="Center" Width="628px" OnRowDataBound="GrdOrder_RowDataBound" ShowFooter="True">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                                            <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                                Width="90px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                                                            <FooterStyle CssClass="HidePanel" />
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                                Width="170px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="REMARKS" HeaderText="Account Description">
                                                            <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                                Width="180px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="debit" DataFormatString="{0:F2}" HeaderText="Debit">
                                                            <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="credit" DataFormatString="{0:F2}" HeaderText="Credit">
                                                            <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <HeaderStyle CssClass="HidePanel" />
                                                            <ItemStyle CssClass="HidePanel" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="tblhead" HorizontalAlign="Center"
                                                        VerticalAlign="Middle" />
                                                </asp:GridView>
                                                </asp:Panel>
                                                <asp:HiddenField ID="HF1" runat="server" />
                                                <asp:HiddenField ID="HF2" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>                
            </td>
        </tr>
    </table>
    </div>
    </div>
</asp:Content>

