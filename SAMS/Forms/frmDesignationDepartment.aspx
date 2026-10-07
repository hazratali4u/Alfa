<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmDesignationDepartment.aspx.cs" Inherits="Forms_frmDesignationDepartment" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">

 <div class="container" style="background-color: white">
        <h2>
            &nbsp; Employee Type</h2>
    </div>
     <div class="container">
         <table>
             <tr>
                 <td style="width: 100px">
                 </td>
                 <td style="width: 100px">
                 </td>
                 <td style="width: 100px">
                 </td>
             </tr>
             <tr>
                 <td>
                 </td>
                 <td>
         <table width="100%">
             <tr>
                 <td style="width: 100px">
                     <cc1:TabContainer ID="TabContainer1" runat="server"  Height="375px"
                         Width="650px" ActiveTabIndex="0">
                         <cc1:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    Department
                             </HeaderTemplate>
                             <ContentTemplate>
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
                                         <td style="width: 100px">
                                         </td>
                                         <td style="width: 100px">
                                             <asp:UpdatePanel id="UpdatePanel6" runat="server">
                                                 <contenttemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 49px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD colSpan=2><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" AccessKey="C"></asp:Label><BR /></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD style="WIDTH: 49px; HEIGHT: 28px"><asp:Label id="Label1" runat="server" Width="62px" Text="Code"></asp:Label> </TD><TD align="left"><asp:TextBox id="txtChannelCode" runat="server" Width="100px" CssClass="txtBox " Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px"></TD><TD style="WIDTH: 49px; HEIGHT: 29px"><asp:Label id="Label2" runat="server" Width="65px" Text="Name"></asp:Label> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtChannelName" runat="server" Width="200px" CssClass="txtBox " Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD align=right>&nbsp;</TD><TD><asp:Button id="btnSaveDepartment" onclick="btnSaveDepartment_Click" runat="server" Width="85px" Font-Size="8pt" Text="New"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</contenttemplate>
                                             </asp:UpdatePanel></td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="center" colspan="3">
                                             <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                                             <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                                 <contenttemplate>
<asp:GridView id="grdDepartmentData" runat="server" Width="90%" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="grdChannelData_RowEditing" OnRowDeleting="grdChannelData_RowDeleting">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="REF_ID" HeaderText="Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLASH_CODE" HeaderText="Code">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLASH_DESC" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                             <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                 Text="Delete"></asp:LinkButton>
                                                         
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle BackColor="#007395" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                                             </asp:UpdatePanel>
                                             </asp:Panel>
                                             &nbsp;
                                         </td>
                                     </tr>
                                 </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel2" runat="server">
                             <HeaderTemplate>
                                 Designation&nbsp;
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                 <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="HEIGHT: 8px" align=left colSpan=2><asp:Label id="lblErrorMsgDivsion" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label><BR /></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="WIDTH: 159px; HEIGHT: 8px"></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD align=left><asp:Label id="Label12" runat="server" Width="52px" Text="Code"></asp:Label> </TD><TD align="left"><asp:TextBox id="txtbustypeCode" runat="server" Width="100px" CssClass="txtBox " Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px"></TD><TD align=left><asp:Label id="Label21" runat="server" Width="53px" Text="Name"></asp:Label> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtbustypeName" runat="server" Width="194px" CssClass="txtBox " Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD align=right>&nbsp;</TD><TD align=left><asp:Button id="btnSaveBusType" onclick="btnSaveBusType_Click" runat="server" Width="85px" Font-Size="8pt" Text="New"></asp:Button> </TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="center" colspan="3">
                                             <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                                             <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                 <contenttemplate>
<asp:GridView id="GrdDesignation" runat="server" Width="90%" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdBusType_RowEditing" OnRowDeleting="GrdBusType_RowDeleting">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="REF_ID" HeaderText="Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLASH_CODE" HeaderText="Code">
<HeaderStyle BorderColor="Silver" BorderWidth="1px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLASH_DESC" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                             <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                 Text="Delete"></asp:LinkButton>
                                                         
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle BackColor="#007395" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                                             </asp:UpdatePanel>
                                             </asp:Panel>
                                             &nbsp;
                                         </td>
                                     </tr>
                                 </table>
                                 <br />
                                 &nbsp;
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel3" runat="server">
                             <HeaderTemplate>
                                 Employee Type&nbsp;
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                 <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 16px"></TD><TD style="HEIGHT: 16px" align=left colSpan=2><BR /><asp:Label id="lblErrorMsgCategory" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 16px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD></TD><TD></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD align=left><asp:Label id="Label121" runat="server" Width="53px" Text="Code"></asp:Label> </TD><TD align="left"><asp:TextBox id="txtCategoryCode" runat="server" Width="100px" CssClass="txtBox " Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px"></TD><TD align=left><asp:Label id="Label211" runat="server" Width="52px" Text="Name"></asp:Label> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtCategoryName" runat="server" Width="194px" CssClass="txtBox " Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD align=right>&nbsp;</TD><TD align=left><asp:Button id="btnSaveCategory" onclick="btnSaveCategory_Click" runat="server" Width="85px" Font-Size="8pt" Text="New" AccessKey="v"></asp:Button> </TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="center" colspan="3">
                                             <asp:Panel ID="Panel3" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                                             <asp:UpdatePanel id="UpdatePanel7" runat="server">
                                                 <contenttemplate>
<asp:GridView id="GrdType" runat="server" Width="90%" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdVolumeClass_RowEditing" OnRowDeleting="GrdVolumeClass_RowDeleting">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="REF_ID" HeaderText="Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLASH_CODE" HeaderText="Code">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLASH_DESC" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                 <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                     Text="Delete"></asp:LinkButton>
                                             
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle BackColor="#007395" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                                             </asp:UpdatePanel>
                                             </asp:Panel>
                                             &nbsp;
                                         </td>
                                     </tr>
                                 </table>
                                 &nbsp;&nbsp;
                             </ContentTemplate>
                         </cc1:TabPanel>
                     </cc1:TabContainer></td>
             </tr>
         </table>
                 </td>
                 <td>
                 </td>
             </tr>
             <tr>
                 <td style="width: 100px">
                 </td>
                 <td style="width: 100px">
                 </td>
                 <td style="width: 100px">
                 </td>
             </tr>
         </table>
     </div>
</asp:Content>