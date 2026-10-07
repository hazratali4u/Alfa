<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmCustomerCreditLimit.aspx.cs" Inherits="Forms_frmCustomerCreditLimit" Title="SAMS: Customer Assignement" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
<script language="JavaScript" type="text/javascript">
    function pageLoad()
    {
        $('#<%=Grid_users.ClientID %>').tablesorter(
	     {
            headers: {
                8: {
                sorter: false
                }
            }
        });  
    }
</script>
<div id="right_data">
    <div >
        <table width="100%">
            <tr>               
                <td style="width: 100px">
                    <table>
                        <tr>
                            <td style="width: 100px">
                               <strong>  <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Location" Width="77px"></asp:Label></strong> </td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="DrpDistributor" runat="server" CssClass="DropList" Width="205px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE class="tblhead"><TBODY><TR><TD style="color:White;font-weight:bold;">
<asp:Label id="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label> </TD><TD><asp:DropDownList id="ddSearchType" runat="server" Width="200px" CssClass="DropList"><asp:ListItem Value="CUSTOMER_CODE">Customer Code</asp:ListItem>
<asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
<asp:ListItem Value="CONTACT_PERSON">Contact Person</asp:ListItem>
<asp:ListItem Value="CONTACT_NUMBER">Contact Number</asp:ListItem>
<asp:ListItem Value="ADDRESS">Address</asp:ListItem>
<asp:ListItem Value="EMAIL_ADDRESS">Email Address</asp:ListItem>
<asp:ListItem Value="GEO_NAME">Town Name</asp:ListItem>
<asp:ListItem Value="AREA_NAME">Route Name</asp:ListItem>
<asp:ListItem Value="ROUTE_NAME">Market Name</asp:ListItem>
<asp:ListItem Value="SLASH_DESC">Channel Type</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 224px; HEIGHT: 21px" align=left><asp:TextBox id="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox> </TD><TD style="HEIGHT: 21px;width:145px" align=left >
<asp:Button id="btnSearch" runat="server" Width="85px" Font-Size="8pt" Text="Filter" OnClick="btnSearch_Click"></asp:Button> </TD></TR></TBODY></TABLE><asp:Panel id="Panel2" runat="server" Width="750px" Height="150px" ScrollBars="Vertical" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black">
<asp:GridView id="Grid_users" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="tablesorter" BorderColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White" OnRowEditing="Grid_users_RowEditing">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="DISTRIBUTOR_ID">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GEO_NAME" HeaderText="Town">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AREA_NAME" HeaderText="Route">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ROUTE_NAME" HeaderText="Market">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Select">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
</Columns>
<HeaderStyle CssClass="tblhead"></HeaderStyle>
</asp:GridView> </asp:Panel> 
</contenttemplate>
        </asp:UpdatePanel>
                </td>               
            </tr>
        </table>
        
           </div>
    <div >
        <table width="100%">
            <tr>                
                <td style="width: 100px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel3" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                Height="208px" ScrollBars="Vertical" Width="750px">
                                <asp:GridView ID="GrdCreditLimit" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="White" CssClass="gridRow2" ForeColor="Silver" HorizontalAlign="Center"
                                    Width="100%">
                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                        PreviousPageText="Previous" />
                                    <Columns>
                                        <asp:BoundField DataField="Company_Id" HeaderText="Company_Id">
                                            <HeaderStyle CssClass="HidePanel" />
                                            <ItemStyle CssClass="HidePanel" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Assign">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChbSelect" runat="server" Width="73px" />
                                            </ItemTemplate>
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Company_Name" HeaderText="Principal">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Credit Limit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCreditLimit" runat="server" CssClass="txtBox" Width="100%"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Allow Days">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCreditDays" runat="server" CssClass="txtBox " Width="100%"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Channel">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="drpChannelType" runat="server" CssClass="DropList" Width="100%">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DrpBusinessType" runat="server" CssClass="DropList" Width="100%">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Class">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DrpVolumeClass" runat="server" CssClass="DropList" Width="100%">
                                                    <asp:ListItem>A</asp:ListItem>
                                                    <asp:ListItem>B</asp:ListItem>
                                                    <asp:ListItem>C</asp:ListItem>
                                                    <asp:ListItem>D</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                                <asp:DropDownList id="DrpType" runat="server" Width="100%">
                                                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                    <asp:ListItem Value="Bill">Bill</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="tblhead" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="z-index: 101; left: 740px; width: 100px; position: absolute; top: 134px;
                        height: 100px">
                        &nbsp;<asp:Panel ID="Panel1" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="23px" />
                                    Wait Update
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                    <br />
                    <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Save" ValidationGroup="vg" Width="89px" CssClass="Button" />
                    <asp:Button ID="btnCancel" runat="server" Font-Size="8pt" Text="Cancel" Width="91px" CssClass="Button" />
                    <br />
                    <br />
                    </td>               
            </tr>
        </table>
        
    </div>    
   </div>
</asp:Content>

