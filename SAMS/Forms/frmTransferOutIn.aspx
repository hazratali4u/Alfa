<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmTransferOutIn.aspx.cs" Inherits="Forms_frmTransferOutIn" Title="SAMS: Transfer In" %>
<%@ Register Assembly="AjaxControlToolkit"   Namespace="AjaxControlToolkit"    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
     <div id="right_data">
    <div >
        <table width="100%">
            <tr>
                <td style="width: 100px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td align="left">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 143px" align=left></TD><TD align=left colSpan=2>&nbsp;</TD></TR><TR><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:Label id="lblDocumentNo" runat="server" Width="100px" Text="Document No" CssClass="lblbox"></asp:Label></TD><TD style="HEIGHT: 25px"><asp:DropDownList id="drpDocumentNo" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:Label id="Label2" runat="server" Width="94px" Text="Transfer From" CssClass="lblbox"></asp:Label></TD><TD style="HEIGHT: 25px"><asp:DropDownList id="DrpTransferFor" runat="server" Width="200px" CssClass="DropList" Enabled="False">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD style="HEIGHT: 25px" align=left><asp:Label id="lblfromLocation" runat="server" Width="94px" Text="Transfer To" CssClass="lblbox"></asp:Label></TD><TD style="HEIGHT: 25px"><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align=left></TD><TD style="HEIGHT: 25px" align=left><asp:Label id="Label1" runat="server" Width="94px" Text="Principal" CssClass="lblbox"></asp:Label></TD><TD style="HEIGHT: 25px"><asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" Enabled="False">
            </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align=left></TD><TD style="HEIGHT: 25px" align=left><asp:Label id="lbltoLocation" runat="server" Width="63px" Text="Order No" CssClass="lblbox"></asp:Label></TD><TD style="HEIGHT: 25px"><asp:TextBox id="txtDocumentNo" runat="server" Width="195px" CssClass="txtBox"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 25px" align=left></TD><TD style="HEIGHT: 25px" align=left><asp:Label id="Label3" runat="server" Width="94px" Text="Builty No" CssClass="lblbox"></asp:Label></TD><TD style="HEIGHT: 25px"><asp:TextBox id="txtBuiltyNo" runat="server" Width="195px" CssClass="txtBox"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 100px">
                    &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>
        
           </div>
    <div >
    <table width="100%">
        <tr>
            <td style="width: 100px;">
            </td>
            <td align="left" style="height: 220px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD align=left colSpan=6><asp:Panel id="Panel2" runat="server" Width="640px" Height="140px" ScrollBars="Vertical" BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                        <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center" Width="620px">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous" />
                                            <RowStyle ForeColor="Black" />
                                            <Columns>
                                                <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                    <HeaderStyle CssClass="HidePanel" />
                                                    <ItemStyle CssClass="HidePanel" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                        Width="85px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                        Width="205px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                        Width="75px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="White" />
                                            <PagerStyle BackColor="Transparent" />
                                            <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                        </asp:GridView>
                                    </asp:Panel> </TD></TR></TBODY></TABLE><asp:Button accessKey="S" id="btnTransferIn" runat="server" Width="119px" Font-Size="8pt" Text="Transfer In" UseSubmitBehavior="False" OnClick="btnTransferIn_Click"></asp:Button> <asp:Button accessKey="C" id="btnCancel" runat="server" Width="120px" Font-Size="8pt" Text="Cancel" UseSubmitBehavior="False"></asp:Button>&nbsp; 
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 100px;">
            </td>
        </tr>
    </table>
        &nbsp;
    </div>   
    </div>
</asp:Content>
