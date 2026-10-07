<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmEmployeeNomes.aspx.cs" Inherits="Forms_frmEmployeeNomes" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainCopy">
    <div class="container" style="background-color: white">
    
        <h2>
            &nbsp; Employee Norms</h2>
    </div>
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
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px;">
                    <div style="z-index: 101; left: 535px; width: 100px; position: absolute; top: 205px;
                        height: 83px">
                        &nbsp;<asp:Panel ID="Panel21" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="23px" />
                                    Wait Update
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                </td>
                <td align="center" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left" style="height: 20px">
                                        <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Employee Group" Width="92px"></asp:Label></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:DropDownList id="DrpEmployeeGroup" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpEmployeeGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtEmpGroup" runat="server" CssClass="txtBox " Width="215px" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnRole" runat="server" Font-Size="8pt" OnClick="btnRole_Click"
                Text="New" Width="50px" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
            <asp:Label id="Label1" runat="server" Width="113px" Text="Employee Norms" CssClass="lblbox"></asp:Label></td>
                                    <td style="width: 100px">
            <asp:DropDownList id="DrpEmployeeNoams" runat="server" Width="200px" CssClass="DropList">
</asp:DropDownList>
                                        <asp:TextBox ID="txtnoams" runat="server" CssClass="txtBox " Width="215px" Visible="False"></asp:TextBox></td>
                                    <td style="width: 100px"><asp:Button ID="btnnoams" runat="server" Font-Size="8pt" OnClick="btnnoams_Click"
                Text="New" Width="50px" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
            <asp:Label id="Label6" runat="server" Width="63px" Text="Amount" CssClass="lblbox"></asp:Label></td>
                                    <td align="left" style="height: 20px">
            <asp:TextBox id="txtAmount" runat="server" Width="163px" CssClass="txtBox "></asp:TextBox></td>
                                    <td align="left" style="height: 20px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
                                    </td>
                                    <td align="left" style="height: 20px">
                                        <asp:CheckBox ID="ChbIsTaxable" runat="server" Text="Is Taxable" /></td>
                                    <td align="left" style="height: 20px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
            </td>
                                    <td align="left" style="height: 20px"><asp:Button ID="btnsave" runat="server" Font-Size="8pt" OnClick="btnAddNew_Click"
                Text="Add New" Width="103px" /></td>
                                    <td align="left" style="height: 20px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
                                    </td>
                                    <td align="left" style="height: 20px">
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                            TargetControlID="txtAmount" ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td align="left" style="height: 20px">
                                    </td>
                                </tr>
                            </table>
                          
                            &nbsp;&nbsp;&nbsp;&nbsp;
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
                                        HorizontalAlign="Center" OnRowDeleting="GrdOrder_RowDeleting"
                                        OnRowEditing="GrdOrder_RowEditing" Width="600px">
                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                            PreviousPageText="Previous" />
                                        <RowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="ROLE_ID" HeaderText="ROLE_ID">
                                                <FooterStyle CssClass="HidePanel" />
                                                <HeaderStyle CssClass="HidePanel" />
                                                <ItemStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ROLE_DESCRIPTION" HeaderText="Employee Role">
                                                <FooterStyle CssClass="HidePanel" />
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NORMS_ID" HeaderText="NORMS_ID">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" CssClass="HidePanel" />
                                                <HeaderStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SLASH_DESC" HeaderText="Norms">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IS_TAXABLE" HeaderText="Taxable">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AMOUNT" DataFormatString="{0:F2}" FooterText="Total" HeaderText="Amount">
                                                <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="47px" />
                                            </asp:CommandField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                        Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="46px" />
                                            </asp:TemplateField>
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
