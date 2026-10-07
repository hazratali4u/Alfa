<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmInvoiceBuiltyDetail.aspx.cs" Inherits="Forms_frmInvoiceBuiltyDetail" Title="SAMS: Freight Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
      <script language="JavaScript" type="text/javascript">
    
    function ValidateForm()
    {
        var str;
        str  =  document.getElementById("<%= txtAmount.ClientID %>").value;
        if(str == null || str.length == 0)
		{
			alert('Must enter Amount');
			return false;
		}
		
    }
 
  </script>
  <div id="right_data">
    <div >
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 346px; width: 100px; position: absolute; top: 246px;
                        height: 100px">
                        <asp:Panel ID="Panel21" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="23px" />
                                    Wait Update
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
<cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789." TargetControlID="txtAmount" FilterType="Custom">
                            </cc1:FilteredTextBoxExtender> <asp:Panel id="Panel1" runat="server" DefaultButton="btnAddNew"><TABLE><TBODY><TR><TD style="HEIGHT: 20px" align=left>
                           <strong> <asp:Label id="Label8" runat="server" Width="68px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 100px"><asp:DropDownList id="DrpPrincipal" runat="server" Width="250px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
            </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 20px" align=left>
            <strong><asp:Label id="lblfromLocation" runat="server" Width="65px" Height="14px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 100px"><asp:DropDownList id="drpDistributor" runat="server" Width="250px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                    </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 20px" align=left>
                                    <strong><asp:Label id="Label1" runat="server" Width="82px" Text="Transporter" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 20px" align=left><asp:DropDownList id="DrpTransporter" runat="server" Width="250px" CssClass="DropList">
</asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 20px" align=left>
<strong><asp:Label id="Label4" runat="server" Width="82px" Text="Customer" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 20px" align=left><asp:DropDownList id="DrpCustomer" runat="server" Width="250px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpCustomer_SelectedIndexChanged">
                                        </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 20px" align=left>
                                        <strong><asp:Label id="Label2" runat="server" Width="82px" Text="Invoice No" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 20px" align=left><asp:DropDownList id="DrpInvoiceNo" runat="server" Width="174px" CssClass="DropList">
                                        </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 20px" align=left>
                                        <strong><asp:Label id="Label9" runat="server" Width="71px" Text="Builty No" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 20px" align=left><asp:TextBox id="txtRemarks" runat="server" Width="167px" CssClass="txtBox "></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 20px" align=left>
                                        <strong><asp:Label id="Label6" runat="server" Width="63px" Text="Freight" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 20px" align=left><asp:TextBox id="txtAmount" runat="server" Width="99px" CssClass="txtBox "></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px" align=left></TD><TD style="HEIGHT: 20px" align=left colSpan=1>
                                        <asp:Button accessKey="S" id="btnAddNew" onclick="btnAddNew_Click" runat="server" Width="95px" Font-Size="8pt" Text="Save" CssClass="Button" /> </TD></TR></TBODY></TABLE></asp:Panel> &nbsp;&nbsp; 
</ContentTemplate>
                    </asp:UpdatePanel>
                    <strong><asp:Label ID="lblRowId" runat="server" Text="Label" Visible="False"></asp:Label></strong>
                    &nbsp;
                </td>
            </tr>
        </table>
        
           </div>
    <div>
    <table width="100%">
        <tr>
            <td >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<TABLE style="BORDER-RIGHT: silver thin inset; BORDER-TOP: silver thin inset; BORDER-LEFT: silver thin inset; WIDTH: 650px; BORDER-BOTTOM: silver thin inset"><TBODY><TR><TD style="HEIGHT: 20px" align=left colSpan=5><asp:Panel id="Panel12" runat="server" Width="750px" Height="200px" ScrollBars="Vertical">
<asp:GridView id="GrdOrder" runat="server" Width="728px" ForeColor="SteelBlue" CssClass="gridRow2" OnRowDeleting="GrdOrder_RowDeleting" HorizontalAlign="Center" BorderColor="White" BackColor="White" AutoGenerateColumns="False">
<PagerSettings PreviousPageText="Previous" Mode="NextPrevious" LastPageText="" FirstPageText="" NextPageText="Next"></PagerSettings>

<Columns>
<asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
<ItemStyle CssClass="HidePanel"></ItemStyle>

<HeaderStyle CssClass="HidePanel"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="PRINCIPAL_ID" HeaderText="PRINCIPAL_ID">
<ItemStyle CssClass="HidePanel"></ItemStyle>

<HeaderStyle CssClass="HidePanel"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="voucher_type_id" HeaderText="voucher_type_id">
<ItemStyle CssClass="HidePanel"></ItemStyle>

<HeaderStyle CssClass="HidePanel"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Principal">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Manual_Document_no" HeaderText="Invoice No">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Ledger_date" HeaderText="Invoice Date">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Voucher_no" HeaderText="Voucher No">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataFormatString="{0:F2}" DataField="Balance" HeaderText="Freight">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Builty No">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"></ItemStyle>
<ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                Text="Delete"></asp:LinkButton>
                                                        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<HeaderStyle CssClass="tblhead" VerticalAlign="Middle"></HeaderStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </div>
</asp:Content>