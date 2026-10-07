<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmVoucherEditing.aspx.cs" Inherits="Forms_frmVoucherEditing" Title="SAMS: Voucher Editing" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
  
  <link href="../App_Themes/Granite/Default.css" rel="stylesheet" type="text/css" />
  
   <script language="JavaScript" type="text/javascript">
        
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );

        function startRequest( sender, e )
        { 
            
            document.getElementById('<%=btnSave.ClientID%>').disabled = true;
            document.getElementById('<%=btnDone.ClientID%>').disabled = true;

        }

        function endRequest( sender, e ) 
        { 
           
            document.getElementById('<%=btnSave.ClientID%>').disabled = false;
            document.getElementById('<%=btnDone.ClientID%>').disabled = false;

        }
        
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
        document.getElementById("<%= txtAccountDes.ClientID %>").focus();
      }
 }
 function ClearSelection(lb)
 {
    lb.selectedIndex = -1;
 }

  </script>
</head>
<body>
<form id="Form1" runat="server" >

<asp:ScriptManager ID="VoucherScriptManager" runat="server"/>

 <div style="background-color: #848484">
     <div style="background-color: white">
         <h2>
             &nbsp; Voucher Editing</h2>
     </div>
     <div style="background-color: Gainsboro" >
         <table width="100%" style="font-size: 0.78em">
             <tr>
                 <td style="height: 13px">
                 </td>
                 <td align="center" style="height: 13px">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <table>
                                 <tr>
                                     <td align="left" style="height: 25px;">
                                         <asp:Label ID="Label4" runat="server" Text="Location" Width="97px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:DropDownList ID="drpDistributor" runat="server" CssClass="DropList" Width="206px" Enabled="False">
                                         </asp:DropDownList></td>
                                     <td align="left">
                                     </td>
                                     <td align="left" style="width: 99px">
                                         <asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="Voucher Type" Width="123px"></asp:Label></td>
                                     <td align="left">
                                         <asp:DropDownList ID="DrpVoucherType" runat="server" CssClass="DropList" Width="205px" Enabled="False">
                                             <asp:ListItem Value="14">Cash Voucher</asp:ListItem>
                                             <asp:ListItem Value="15">Bank Voucher</asp:ListItem>
                                             <asp:ListItem Value="16">Journal Voucher</asp:ListItem>
                                         </asp:DropDownList></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="height: 25px;">
                                         <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Voucher Date" Width="117px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:TextBox ID="txtVoucherDate" runat="server" CssClass="txtBox " Width="200px" ReadOnly="True"></asp:TextBox></td>
                                     <td align="left" style="height: 18px">
                                     </td>
                                     <td align="left" style="height: 18px; width: 99px;">
                                         <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Voucher No" Width="72px"></asp:Label></td>
                                     <td align="left" style="height: 18px">
                                         <asp:TextBox ID="lblVoucherNo" runat="server" CssClass="txtBox " Width="200px" ReadOnly="True"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="height: 25px;">
                                         <asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Payment Mode"
                                             Width="105px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:DropDownList ID="DrpPaymentMode" runat="server" CssClass="DropList" Width="206px">
                                             <asp:ListItem Value="19">Cash</asp:ListItem>
                                             <asp:ListItem Value="18">Cheque</asp:ListItem>
                                             <asp:ListItem Value="21">Pay Order</asp:ListItem>
                                         </asp:DropDownList></td>
                                     <td align="left">
                                     </td>
                                     <td align="left" style="width: 99px">
                                         <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Slip No" Width="91px"></asp:Label></td>
                                     <td align="left" style="height: 20px">
                                         <asp:TextBox ID="txtSlipNo" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                             Width="200px"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="height: 25px;">
                                         <asp:Label ID="lblChequeNo" runat="server" CssClass="lblbox" Text="Cheque No" Width="108px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:TextBox ID="txtChequeNo" runat="server" CssClass="txtBox " 
                                             Width="200px"></asp:TextBox></td>
                                     <td align="left" style="height: 20px">
                                     </td>
                                     <td align="left" style="height: 20px; width: 99px;">
                                         <asp:Label ID="lblChequedate" runat="server" CssClass="lblbox" Text="Cheque Date"
                                             Width="125px"></asp:Label></td>
                                     <td align="left" style="height: 20px">
                                         <asp:TextBox ID="txtChequeDate" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                             Width="200px"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="height: 25px;">
                                         <asp:Label ID="Label10" runat="server" CssClass="lblbox" Text="Payee's Name" Width="117px"></asp:Label></td>
                                     <td align="left" style="height: 25px">
                                         <asp:TextBox ID="txtpayeesName" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox></td>
                                     <td align="left" style="height: 25px">
                                         <asp:Label ID="Label14" runat="server" CssClass="lblbox" Width="10px"></asp:Label></td>
                                     <td align="left" style="height: 25px; width: 99px;">
                                         <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Due Date" Width="85px"></asp:Label></td>
                                     <td align="left" style="height: 25px">
                                         <asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                             Width="200px"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="height: 25px">
                                         <asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Narration" Width="85px"></asp:Label></td>
                                     <td align="left" style="height: 25px">
                                         <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " 
                                             Width="200px" MaxLength="255"></asp:TextBox></td>
                                     <td align="left" style="height: 25px">
                                     </td>
                                     <td align="left" style="width: 99px; height: 25px">
                                         </td>
                                     <td align="left" style="height: 25px">
                                         </td>
                                 </tr>
                             </table>
                             <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                 MaskType="Date" TargetControlID="txtChequeDate">
                             </cc1:MaskedEditExtender>
                             <div style="z-index: 101; left: 471px; width: 100px; position: absolute; top: 291px;
                                 height: 100px">
                                 <asp:Panel ID="Panel212" runat="server">
                                     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                         <ProgressTemplate>
                                             <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                 Width="39px" />
                                             Wait Update
                                         </ProgressTemplate>
                                     </asp:UpdateProgress>
                                 </asp:Panel>
                             </div>
                             <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                 MaskType="Date" TargetControlID="txtVoucherDate">
                             </cc1:MaskedEditExtender><cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                                 MaskType="Date" TargetControlID="txtDueDate">
                             </cc1:MaskedEditExtender>
                             &nbsp;&nbsp;
                             <asp:TextBox ID="txtTotalDebit" runat="server" CssClass="HidePanel" Width="100px"></asp:TextBox><asp:TextBox
                                 ID="txtTotalCredit" runat="server" CssClass="HidePanel" Width="73px"></asp:TextBox>
                             &nbsp;
                             &nbsp; &nbsp;
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     &nbsp;</td>
                 <td style="height: 13px">
                 </td>
             </tr>
         </table>
     </div>
     <div style="background-color: Gainsboro">
         <table width="100%">
             <tr>
                 <td style="width: 100px">
                 </td>
                 <td align="center">
                     &nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                             <table cellpadding="0" cellspacing="0" style="border-right: #007395 1px solid; border-top: #007395 1px solid;
                                 border-left: #007395 1px solid; border-bottom: #007395 1px solid">
                                 <tr>
                                     <td style="height: 16px">
                                         <asp:Label ID="lblskuCode" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Acct Code" Width="83px" CssClass="lblbox" Font-Size="X-Small"></asp:Label></td>
                                     <td style="height: 16px">
                                         <asp:Label ID="Label13" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Description" Width="163px" Font-Size="X-Small"></asp:Label></td>
                                     <td style="width: 196px; height: 16px">
                                         <asp:Label ID="lblskuname" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Remarks" Width="146px" Font-Size="X-Small"></asp:Label></td>
                                     <td style="width: 196px; height: 16px">
                                         <asp:Label ID="Label15" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Principal" Width="135px" Font-Size="X-Small"></asp:Label></td>
                                     <td style="height: 16px">
                                         <asp:Label ID="Label11" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Debit" Width="89px" Font-Size="X-Small"></asp:Label></td>
                                     <td style="height: 16px">
                                         <asp:Label ID="Label12" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Credit" Width="87px" Font-Size="X-Small"></asp:Label></td>
                                     <td style="height: 16px">
                                     </td>
                                     <td style="width: 79px; height: 16px">
                                         <asp:Label ID="Label8" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Width="69px" Font-Size="X-Small"></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="txtAccountCode" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                             Width="76px" Font-Size="X-Small"></asp:TextBox></td>
                                     <td colspan="1" rowspan="1">
                                         <asp:TextBox ID="txtAccountName" runat="server" CssClass="txtBox " Enabled="False"
                                             Font-Bold="False" ForeColor="Black" Width="156px" Font-Size="X-Small"></asp:TextBox></td>
                                     <td style="width: 196px; height: 12px">
                                         <asp:TextBox ID="txtAccountDes" runat="server" CssClass="txtBox " onfocus="SearchedCode();"
                                             Width="140px" Font-Size="X-Small"></asp:TextBox></td>
                                     <td style="width: 196px; height: 12px">
                                         <asp:DropDownList ID="DrpPrincipal" runat="server" CssClass="DropList" Width="133px" Font-Size="X-Small">
                                         </asp:DropDownList></td>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="txtDebitAmount" runat="server" CssClass="txtBox " Width="80px" Font-Size="X-Small"></asp:TextBox></td>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="txtCreditAmount" runat="server" CssClass="txtBox " Width="80px" Font-Size="X-Small"></asp:TextBox></td>
                                     <td style="height: 12px">
                                     </td>
                                     <td style="width: 79px; height: 12px">
                                         <asp:Button ID="btnSave" runat="server" AccessKey="A" Font-Size="8pt" OnClick="btnSave_Click"
                                             Text="Add New" Width="70px" /></td>
                                 </tr>
                                 <tr>
                                     <td align="center" colspan="8" rowspan="1">
                                         <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                             BorderColor="White" CaptionAlign="Left" CssClass="gridRow2" ForeColor="SteelBlue"
                                             HorizontalAlign="Center" OnRowDataBound="GrdOrder_RowDataBound" OnRowDeleting="GrdOrder_RowDeleting"
                                             OnRowEditing="GrdOrder_RowEditing" ShowFooter="True" ShowHeader="False" Width="100%" Font-Size="X-Small">
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
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                         Width="80px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Account_Name">
                                                     <FooterStyle CssClass="HidePanel" />
                                                     <HeaderStyle CssClass="HidePanel" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                         Width="170px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="REMARKS" HeaderText="Account Description">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <HeaderStyle HorizontalAlign="Left" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                         Width="150px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Principal" HeaderText="Principal">
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                         Width="150px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="debit" DataFormatString="{0:F2}" HeaderText="Debit">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <HeaderStyle HorizontalAlign="Right" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                         Width="85px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="credit" DataFormatString="{0:F2}" HeaderText="Credit">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <HeaderStyle HorizontalAlign="Right" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                         Width="85px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Principal_id" HeaderText="Principal">
                                                     <FooterStyle HorizontalAlign="Right" />
                                                     <HeaderStyle CssClass="HidePanel" />
                                                     <ItemStyle CssClass="HidePanel" HorizontalAlign="Right" />
                                                 </asp:BoundField>
                                                 <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                         Width="35px" />
                                                 </asp:CommandField>
                                                 <asp:TemplateField HeaderText="Delete">
                                                     <ItemTemplate>
                                                         <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                             Text="Delete"></asp:LinkButton>
                                                     </ItemTemplate>
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                         Width="35px" />
                                                 </asp:TemplateField>
                                             </Columns>
                                             <FooterStyle BackColor="White" />
                                             <PagerStyle BackColor="Transparent" />
                                             <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                 VerticalAlign="Middle" />
                                             <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                         </asp:GridView>
                                         <div style="left: 338px; width: 352px; position: absolute; top: 55px; height: 352px">
                                             <asp:Panel ID="Panel3" runat="server" BackColor="Silver" BorderColor="White" BorderStyle="Inset"
                                                 BorderWidth="1px" CssClass="HidePanel" Height="357px" Width="349px">
                                                 <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                                     border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                                     <tbody>
                                                         <tr>
                                                             <td align="left" colspan="2" style="border-bottom: black thin solid">
                                                                 &nbsp;Select A<strong>ccount Head from List</strong></td>
                                                             <td align="right" style="border-bottom: black thin solid" valign="top">
                                                                 <asp:Button ID="Button5" runat="server" BorderStyle="Groove" BorderWidth="1px" Font-Size="8pt"
                                                                     Height="16px" Text="X" Width="21px" /></td>
                                                         </tr>
                                                     </tbody>
                                                 </table>
                                                 <asp:ListBox ID="LstAccountHead" runat="server" CssClass="DropList" Height="326px"
                                                     onkeyup="SelectCode(event)" Width="346px"></asp:ListBox></asp:Panel>
                                             &nbsp; &nbsp;&nbsp;
                                         </div>
                                         &nbsp;&nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td align="center" colspan="8">
                                     </td>
                                 </tr>
                             </table>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                 TargetControlID="txtCreditAmount" ValidChars=".0123456789">
                             </cc1:FilteredTextBoxExtender>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                 TargetControlID="txtDebitAmount" ValidChars="0123456789.">
                             </cc1:FilteredTextBoxExtender>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     &nbsp;<asp:Button ID="btnDone" runat="server" AccessKey="S" Font-Size="8pt" OnClick="btnDone_Click"
                                             Text="Save" Width="105px" /></td>
                 <td style="width: 93px">
                 </td>
             </tr>
         </table>
     </div>
            <br />
            
  </div>
  </form> 
  </body>
</html>



