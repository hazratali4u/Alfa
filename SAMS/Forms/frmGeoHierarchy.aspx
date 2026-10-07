<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmGeoHierarchy.aspx.cs" Inherits="frmGeoHierarchy" Title="SAMS: Geo Hierarchy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">
 <div class="container" style="background-color: white">
        <h2>
            &nbsp;
            Geo Hierarchy</h2>
    </div>
     <script language="JavaScript" type="text/javascript">
        function ValidatRegion()
		{
			var str;
			str  = document.getElementById('<%=txtRegion.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Region Name');
				return false;
			}
	    }
	    function ValidatZone()
		{
			var str;
			str  = document.getElementById('<%=txtZone.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Zone Name');
				return false;
			}
	    }
	    function ValidateTerritory()
		{
			var str;
			str  = document.getElementById('<%=txtterritory.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Territory Name');
				return false;
			}
	    }
	    function ValidateTown()
		{
			var str;
			str  = document.getElementById('<%=txtRoute.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Town Name');
				return false;
			}
	    }
		</script>
     <div class="container">
         <table width="100%">
             <tr>
                 <td style="width: 100px">
                     <div style="z-index: 101; left: 403px; width: 68px; position: absolute; top: 232px;
                         height: 86px">
                     <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                         <progresstemplate>
<asp:ImageButton id="ImageButton1" runat="server" Width="31px" Height="24px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton>
</progresstemplate>
                     </asp:UpdateProgress>
                     </div>
                 </td>
                 <td>
                     
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD colSpan=5><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" Height="13px" Width="214px"></asp:Label></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD><asp:Label id="Label1" runat="server" Text="Region" CssClass="lblbox"></asp:Label></TD><TD><asp:DropDownList id="ddRegion" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddRegion_SelectedIndexChanged"></asp:DropDownList> <asp:TextBox id="txtRegion" runat="server" Visible="False" Width="194px" CssClass="txtBox "></asp:TextBox></TD><TD></TD><TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD><asp:Button id="btnRegion" onclick="btnRegion_Click" runat="server" Width="125px" Font-Size="8pt" Text="New Region" AccessKey="R"></asp:Button></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD><asp:Label id="Label2" runat="server" Text="Zone" CssClass="lblbox"></asp:Label></TD><TD><asp:DropDownList id="ddZone" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddZone_SelectedIndexChanged"></asp:DropDownList> <asp:TextBox id="txtZone" runat="server" Visible="False" Width="194px" CssClass="txtBox "></asp:TextBox></TD><TD></TD><TD></TD><TD><asp:Button id="btnZone" onclick="btnZone_Click" runat="server" Width="125px" Font-Size="8pt" Text="New Zone" AccessKey="Z"></asp:Button></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD><asp:Label id="Label3" runat="server" Text="Territory" CssClass="lblbox"></asp:Label></TD><TD><asp:DropDownList id="ddTerritory" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddTerritory_SelectedIndexChanged"></asp:DropDownList> <asp:TextBox id="txtterritory" runat="server" Visible="False" Width="194px" CssClass="txtBox "></asp:TextBox></TD><TD></TD><TD></TD><TD><asp:Button id="btnTerritory" onclick="btnTerritory_Click" runat="server" Width="125px" Font-Size="8pt" Text="New Territory" AccessKey="T"></asp:Button></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD><asp:Label id="Label5" runat="server" Text="Town" CssClass="lblbox"></asp:Label></TD><TD style="WIDTH: 169px; HEIGHT: 26px"><asp:TextBox id="txtRoute" runat="server" Width="194px" CssClass="txtBox "></asp:TextBox></TD><TD style="HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"><asp:CheckBox id="IsActive" runat="server" Font-Size="9pt" Text="IsActive" CssClass="lblbox" Checked="True" Visible="False"></asp:CheckBox></TD><TD style="WIDTH: 11px; HEIGHT: 26px"></TD></TR><TR><TD></TD><TD align=left><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="89px" Font-Size="8pt" Text="Save Town" AccessKey="S"></asp:Button> <asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="81px" Font-Size="8pt" Text="Cancel"></asp:Button></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 11px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                     </asp:UpdatePanel> &nbsp;
                 </td>
                 <td>
                 </td>
             </tr>
         </table>
     </div>
    <div class="container">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
<TABLE style="BORDER-RIGHT: silver thin inset; BORDER-TOP: silver thin inset; BORDER-LEFT: silver thin inset; BORDER-BOTTOM: silver thin inset; BACKGROUND-COLOR: silver"><TBODY><TR><TD style="HEIGHT: 21px" align=left><asp:Label id="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label> </TD><TD style="WIDTH: 170px; HEIGHT: 21px" align=left><asp:DropDownList id="ddSearchType" runat="server" Width="200px" CssClass="DropList"><asp:ListItem Value="SKU_code">All Records</asp:ListItem>
<asp:ListItem Value="region_name">Region</asp:ListItem>
<asp:ListItem Value="Zone_Name">Zone</asp:ListItem>
<asp:ListItem Value="Territory_Name">Territory</asp:ListItem>
<asp:ListItem Value="Town_name">Town</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 224px; HEIGHT: 21px" align=left><asp:TextBox id="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox> </TD><TD style="HEIGHT: 21px" align=left width=250><asp:Button id="Button2" onclick="Button2_Click" runat="server" Width="85px" Font-Size="8pt" Text="Filter"></asp:Button> </TD></TR></TBODY></TABLE><asp:GridView id="Grid_Hierarchy" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="gridRow2" OnRowCommand="Grid_Hierarchy_RowCommand" OnRowDeleting="Grid_Hierarchy_RowDeleting" OnRowEditing="Grid_Hierarchy_RowEditing" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" HorizontalAlign="Center" OnPageIndexChanging="Grid_Brand_PageIndexChanging" BorderColor="White">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="region_id" HeaderText="Region Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="region_name" HeaderText="Region Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" HorizontalAlign="Left"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="zone_id" HeaderText="zone id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="zone_name" HeaderText="Zone Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" HorizontalAlign="Left"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="territory_Id" HeaderText="territory Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="territory_Name" HeaderText="Territory Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" HorizontalAlign="Left"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="town_Id" HeaderText="town Id">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="town_name" HeaderText="Town Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" HorizontalAlign="Left"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:LinkButton id="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;" CommandName="Delete"></asp:LinkButton> 
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle BackColor="#007395" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
                     </asp:UpdatePanel>
    </div>
</asp:Content>

