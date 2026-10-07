<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmGeneralLedgerEntry.aspx.cs" Inherits="Forms_frmGeneralLedgerEntry" Title="Voucher Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainCopy">
    <div class="container" style="background-color: white">
    
        <h2>
            &nbsp; Voucher Entry</h2>
    </div>
    <script language="JavaScript" type="text/javascript">
    function ValidateForm()
    {
        var str;
        str  =  document.getElementById("<%= txtAccountCode.ClientID %>").value;
        if(str == null || str.length == 0)
		{
			alert('Must enter Account Code');
			return false;
		}
		str  =  document.getElementById("<%= txtAccountName.ClientID %>").value;
		if(str == null || str.length == 0)
		{
			alert('Wrong Account Code');
			return false;
		}
		str  =  document.getElementById("<%= txtRemarks.ClientID %>").value;
		if(str == null || str.length == 0)
		{
			alert('Must Enter Remarks');
			return false;
		}
		str  =  document.getElementById("<%= txtVoucherDate.ClientID %>").value;
		if(str == null || str.length < 9)
		{
			alert('Must Enter Voucher Date');
			return false;
		}
        var Debit = document.getElementById("<%= txtDebitAmount.ClientID %>").value;
        var Credit = document.getElementById("<%= txtCreditAmount.ClientID %>").value;
        
        if(Debit.length == 0 && Credit.length == 0)
        {
            alert('Debit or Credit Must Enter');
            return false;
        }  
        
        if(Debit > 0 && Credit > 0)
        {
            alert('Only Debit or Credit Can Enter');
            return false;
        }
        return true;
 }
 function SearchList()
 {
     var l =  document.getElementById('<%= LstAccountHead.ClientID %>');
     var tb = document.getElementById('<%= txtAccountCode.ClientID %>');
        
            if(tb.value == "")
            {
                ClearSelection(l);
            }
            else
            {
                for (var i=0; i < l.options.length; i++)
                {
                    if (l.options[i].value.toLowerCase().match(tb.value.toLowerCase()))
                    {
                        l.options[i].selected = true;
                        return false;
                    }
                    else
                    {
                        ClearSelection(l);
                    }
                }
           }
 }
 function SearchedCode()
 {
    var str  
    var stroption
    str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
    stroption = document.getElementById("<%= txtAccountCode.ClientID %>").value;
    
     if(str.length > 0)
     {      
            document.getElementById("<%= txtAccountCode.ClientID %>").value =  str.substring(str.indexOf('~') + 1);
            document.getElementById("<%= txtAccountName.ClientID %>").value =  str.substring(0,str.indexOf('~'));
            document.getElementById("<%= Panel3.ClientID %>").className = "HidePanel";
    
     }
     else if(stroption.length == 0)
     {
            document.getElementById("<%= Panel3.ClientID %>").className = "ShowPanel";
            document.getElementById("<%= LstAccountHead.ClientID %>").focus();
     }
     ClearSelection(document.getElementById('<%= LstAccountHead.ClientID %>'));
    
 }

 function SelectCode(e)
 {
      if(e.keyCode == 13)
      {
        var str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
        document.getElementById("<%= txtAccountCode.ClientID %>").value =  str.substring(0,str.indexOf('~')); 
        document.getElementById("<%= txtAccountName.ClientID %>").value =  str.substring(str.indexOf('~') + 1);
        document.getElementById("<%= Panel3.ClientID %>").className = "HidePanel";
        document.getElementById("<%= txtDebitAmount.ClientID %>").focus();
      }
 }
 function ClearSelection(lb)
 {
    lb.selectedIndex = -1;
 }

  </script>
     <div class="container">
        <table width="100%">
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE>
    <tr>
        <td align="left">
            <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Location" Width="61px"></asp:Label></td>
        <td align="left" style="width: 187px">
        <asp:DropDownList id="drpDistributor" runat="server" Width="180px" CssClass="DropList"></asp:DropDownList></td>
        <td align="left">
        </td>
        <td align="left">
            <asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="Voucher Type" Width="83px"></asp:Label></td>
        <td align="left">
        <asp:DropDownList id="DrpVoucherType" runat="server" Width="180px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpVoucherType_SelectedIndexChanged">
            <asp:ListItem Value="14">Cash Voucher</asp:ListItem>
            <asp:ListItem Value="15">Bank Voucher</asp:ListItem>
            <asp:ListItem Value="16">Journal Voucher</asp:ListItem>
            <asp:ListItem Value="17">Contra Voucher</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label id="Label2" runat="server" Width="72px" Text="Principal" CssClass="lblbox"></asp:Label></td>
        <td align="left" style="width: 187px">
        <asp:DropDownList id="DrpPrincipal" runat="server" Width="180px" CssClass="DropList">
</asp:DropDownList></td>
        <td align="left" style="height: 18px">
        </td>
        <td align="left" style="height: 18px">
            <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Bank/Cash Head" Width="100px"></asp:Label></td>
        <td align="left" style="height: 18px">
            <asp:DropDownList id="drpBanks" runat="server" Width="180px" CssClass="DropList">
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Voucher Date" Width="76px"></asp:Label></td>
        <td align="left" style="width: 187px">
            <asp:TextBox ID="txtVoucherDate" runat="server" CssClass="txtBox " Width="172px"></asp:TextBox></td>
        <td align="left">
        </td>
        <td align="left">
            <asp:Label ID="Label10" runat="server" CssClass="lblbox" Text="Payee's Name" Width="96px"></asp:Label></td>
        <td align="left" style="height: 20px">
            <asp:TextBox ID="txtpayeesName" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                Width="172px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label8" runat="server" CssClass="lblbox" Text="Cheque No" Width="76px"></asp:Label></td>
        <td align="left" style="width: 187px">
            <asp:TextBox ID="txtChequeNo" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                Width="172px"></asp:TextBox></td>
        <td align="left" style="height: 20px">
        </td>
        <td align="left" style="height: 20px">
            <asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Cheque Date" Width="75px"></asp:Label></td>
        <td align="left" style="height: 20px">
            <asp:TextBox ID="txtChequeDate" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                Width="172px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" style="height: 25px; width: 84px;">
            <asp:Label ID="Label16" runat="server" CssClass="lblbox" Text="Remarks" Width="75px"></asp:Label></td>
        <td align="left" style="height: 20px" colspan="4">
            <asp:TextBox ID="txtRemarks" runat="server" Width="468px" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" style="width: 84px">
            &nbsp;</td>
        <td align="left" style="width: 187px">
            &nbsp; &nbsp;
            <asp:DropDownList id="DrpPaymentMode" runat="server" Width="98px" CssClass="DropList">
            <asp:ListItem Value="19">Cheque</asp:ListItem>
            <asp:ListItem Value="20">Cash</asp:ListItem>
            <asp:ListItem Value="21">Pay Order</asp:ListItem>
        </asp:DropDownList></td>
        <td align="left">
        </td>
        <td align="left">
            &nbsp;</td>
        <td align="right">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >Show Pending Invoice</asp:LinkButton>&nbsp;</td>
    </tr>
</TABLE>
                            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTotalDebit" runat="server" CssClass="HidePanel" Width="100px"></asp:TextBox>
            <asp:TextBox ID="txtTotalCredit" runat="server" CssClass="HidePanel" Width="73px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                MaskType="Date" TargetControlID="txtChequeDate">
            </cc1:MaskedEditExtender>
            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtVoucherDate">
            </cc1:MaskedEditExtender>
                            &nbsp;&nbsp;
                            <div style="left: 396px; position: absolute; top: 460px; height: 248px">
                                <asp:Panel ID="Panel3" runat="server" BackColor="Silver" BorderColor="White" BorderStyle="Inset"
                                    BorderWidth="1px" CssClass="HidePanel" Height="237px" Width="327px">
                                    <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                        border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                        <tbody>
                                            <tr>
                                                <td align="left" colspan="2" style="border-bottom: black thin solid">
                                                    &nbsp;Select A<strong>ccount Head from List</strong></td>
                                                <td align="right" style="border-bottom: black thin solid" valign="top">
                                                    <asp:Button ID="Button5" runat="server" BorderStyle="Groove" BorderWidth="1px"
                                                        Font-Size="8pt" Height="16px" Text="X" Width="21px" /></td>
                                            </tr>
                                        </tbody>
                                    </table>
                        <asp:ListBox ID="LstAccountHead" runat="server" CssClass="DropList" Height="206px" Width="314px" onkeyup = "SelectCode(event)">
                        </asp:ListBox></asp:Panel>
                                &nbsp; &nbsp;
                                <div style="left: 378px; position: absolute; top: -160px; height: 226px">
                                    <asp:Panel ID="Panel2" runat="server" BackColor="Gainsboro" BorderColor="Black" BorderStyle="Outset"
                                    BorderWidth="2px" Height="100%" Width="500px" Visible="False">
                                        <table width="90%" style="border-right: #0099ff 1px groove; border-top: #0099ff 1px groove; border-left: #0099ff 1px groove; border-bottom: #0099ff 1px groove; background-repeat: repeat-x; background-color: #007395">
                                            <tbody>
                                                <tr>
                                                    <td align="left" style="height: 21px; width: 68px;">
                                                        &nbsp;<asp:Label ID="Label14" runat="server" Text="Select Date" Width="93px" Font-Bold="True" ForeColor="White"></asp:Label></td>
                                                    <td align="left" style="height: 21px">
                                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox " Width="100px"></asp:TextBox></td>
                                                    <td align="left" style="width: 200px; height: 21px">
                                                        <asp:TextBox ID="txtEnddate" runat="server" CssClass="txtBox " Width="100px"></asp:TextBox></td>
                                                    <td align="left" style="width: 200px; height: 21px">
                                                        <asp:Button ID="btnFilter" runat="server" Font-Size="8pt" OnClick="Button2_Click" Text="Filter"
                                                            Width="83px" />
                                                    </td>
                                                    <td align="left" style="height: 21px; width: 250px;">
                                                        <asp:Button ID="btnAddVoucher" runat="server" Font-Size="8pt" OnClick="btnAddVoucher_Click" Text="Add Voucher"
                                                            Width="93px" /></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:GridView ID="GrdPendingInvoice" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                            Width="500px">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous" />
                                            <RowStyle ForeColor="Black" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChbInvoice" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Document_no" HeaderText="Invoice No">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="openingBalance" HeaderText="Credit">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="paid" DataFormatString="{0:F2}" HeaderText="Paid Amont">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="closingBalance" DataFormatString="{0:F2}" HeaderText="Closing Amount">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="White" />
                                            <PagerStyle BackColor="Transparent" />
                                            <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                        </asp:GridView><cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                MaskType="Date" TargetControlID="txtStartDate">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999"
                MaskType="Date" TargetControlID="txtEnddate">
                                        </cc1:MaskedEditExtender>
                                    </asp:Panel>
                                    &nbsp;&nbsp;
                                </div>
                            </div>
</contenttemplate>
                    </asp:UpdatePanel>
                   
                </td>
                <td style="height: 284px">
                </td>
            </tr>
        </table>
        
           </div>
    <div class="container"><table width="100%">
        <tr>
            <td style="width: 100px">
            </td>
            <td align="left" valign="top">
                &nbsp;<asp:Panel ID="Panel4" runat="server" DefaultButton="btnSave">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 16px">
                                    <asp:Label ID="lblskuCode" runat="server" BackColor="#007395" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Account Code" Width="128px"></asp:Label></td>
                                <td style="height: 16px">
                                    <asp:Label ID="lblskuname" runat="server" BackColor="#007395" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Account Name" Width="236px"></asp:Label></td>
                                <td style="height: 16px">
                                    <asp:Label ID="Label11" runat="server" BackColor="#007395" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Debit" Width="116px"></asp:Label></td>
                                <td style="height: 16px">
                                    <asp:Label ID="Label12" runat="server" BackColor="#007395" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Credit" Width="118px"></asp:Label></td>
                                <td style="height: 16px">
                                    </td>
                                <td style="height: 16px">
                                    <asp:Label ID="Label15" runat="server" BackColor="#007395" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Add New" Width="113px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 12px">
            <asp:TextBox ID="txtAccountCode" runat="server"
                Width="122px" onkeyup = "SearchList()" CssClass="txtBox "></asp:TextBox></td>
                                <td colspan="" rowspan="">
            <asp:TextBox ID="txtAccountName" runat="server"
                Width="230px" Enabled="False" Font-Bold="False" ForeColor="Black" CssClass="txtBox "></asp:TextBox></td>
                                <td style="height: 12px">
            <asp:TextBox ID="txtDebitAmount" runat="server" Width="110px" onfocus="SearchedCode()" CssClass="txtBox "></asp:TextBox></td>
                                <td style="height: 12px">
            <asp:TextBox ID="txtCreditAmount" runat="server" Width="110px" CssClass="txtBox "></asp:TextBox></td>
                                <td style="height: 12px">
                                </td>
                                <td style="height: 12px">
            <asp:Button ID="btnSave" runat="server" Font-Size="9pt"
                Text="Add" Width="112px" OnClick="btnSave_Click" /></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" rowspan="">
                        <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                            ShowFooter="True" OnRowDataBound="GrdOrder_RowDataBound" OnRowDeleting="GrdOrder_RowDeleting" OnRowEditing="GrdOrder_RowEditing" Width="714px" ShowHeader="False" CaptionAlign="Left">
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                PreviousPageText="Previous" />
                            <RowStyle ForeColor="Black" />
                            <Columns>
                                <asp:BoundField DataField="Account_Head_Id" HeaderText="Account Head Id">
                                    <FooterStyle CssClass="HidePanel" />
                                    <HeaderStyle CssClass="HidePanel" />
                                    <ItemStyle CssClass="HidePanel" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                    <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="105px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Account_Name" FooterText="Total" HeaderText="Account Name">
                                    <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="200px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="debit" DataFormatString="{0:F2}" HeaderText="Debit">
                                    <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="credit" DataFormatString="{0:F2}" HeaderText="Credit">
                                    <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px" />
                                </asp:BoundField>
                                <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="47px" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="46px" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                            Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" />
                            <PagerStyle BackColor="Transparent" />
                            <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                VerticalAlign="Middle" />
                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                        </asp:GridView>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
            <asp:Button ID="btnDone" runat="server" Font-Size="8pt"
                Text="Save" Width="105px" OnClick="btnDone_Click" AccessKey="S" /></td>
                            </tr>
                        </table>
                        <br />
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                TargetControlID="txtCreditAmount" ValidChars=".0123456789">
            </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender
                    ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom" TargetControlID="txtDebitAmount"
                    ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
                </asp:Panel>
                &nbsp;
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    </div>
    
   
</asp:Content>

