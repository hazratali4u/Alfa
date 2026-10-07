<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmGeoHierarchyData.aspx.cs" Inherits="Forms_frmGeoHierarchyData" Title="SAMS: Geo Hierarchy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function ValidatRegion()
		{
			var str;
			
			str  = document.getElementById('<%=txtRegionName.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Region Name');
				return false;
			}
			return true;
	    }
	    
	    function ValidatZone()
		{
			var str;
					
			str  = document.getElementById('<%=txtZoneName.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Zone Name');
				return false;
			}
			return true;
	    }
	    function ValidateTerritory()
		{
			var str;
			str  = document.getElementById('<%=txtTerritoryName.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Territory Name');
				return false;
			}
			return true;
	    }
	    function ValidateTown()
		{
			var str;
			str  = document.getElementById('<%=txtTownName.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Town Name');
				return false;
			}
			return true;
	    }
    </script>
    
     <div id="right_data">
              <table>
             <tr>
                 <td>
         <table>
             <tr>
                 <td>
                     <cc1:TabContainer ID="TabContainer1" runat="server"  Height="400px"
                         Width="650px" ActiveTabIndex="0">
                         <cc1:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    Region&nbsp;
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
<TABLE width="100%">
                                                         <TBODY>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 49px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px">
                                                                 </TD>
                                                                 <TD colSpan=2>
                                                                     <asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                                                     <BR />
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 28px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px">
                                                                     <strong>
                                                                     <asp:Label ID="Label2" runat="server" Text="Name" Width="65px" Height="14px"></asp:Label>
                                                                     </strong>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 28px">
                                                                     <asp:TextBox ID="txtRegionName" runat="server" CssClass="txtBox " Width="192px" Height="17px"></asp:TextBox>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 28px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 29px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 29px">
                                                                     &nbsp;</TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 29px">
                                                                     &nbsp;<asp:CheckBox id="ChIsActive" runat="server" Text="Is Active" Checked="True">
                                                                     </asp:CheckBox>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 29px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 37px" align=right>
                                                                     <asp:Label ID="Label3" runat="server" Text="Code" Width="65px" Visible="False"></asp:Label>
                                                                     &nbsp;</TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                     <asp:Button id="btnRegionSave" onclick="btnRegionSave_Click" runat="server" Width="85px" Font-Size="8pt" Text="Save" CssClass="Button" />
                                                                     <asp:TextBox ID="txtRegionCode" runat="server" CssClass="txtBox " Width="77px" Visible="False">N/A</asp:TextBox>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </TD>
                                                             </TR>
                                                         </TBODY>
                                                     </TABLE>
</contenttemplate>
                                             </asp:UpdatePanel></td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="left" colspan="3">
                                             <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                                 <contenttemplate>
<asp:GridView id="grdRegionData" runat="server" Width="90%" Font-Size="9pt"  AutoGenerateColumns="False" HorizontalAlign="Center" OnRowEditing="grdRegionData_RowEditing">
<Columns>
    <asp:BoundField DataField="GEO_ID" HeaderText="GEO_ID">
        <HeaderStyle CssClass="HidePanel" />
        <ItemStyle CssClass="HidePanel" />
    </asp:BoundField>
<asp:BoundField DataField="GEO_CODE" HeaderText="Region Code">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" CssClass="HidePanel" />
</asp:BoundField>
<asp:BoundField DataField="GEO_NAME" HeaderText="Region Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="ISDELETED" HeaderText="Status">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
</asp:CommandField>
</Columns>

<HeaderStyle CssClass="tblhead"></HeaderStyle>
</asp:GridView>
</contenttemplate>
                                             </asp:UpdatePanel></td>
                                     </tr>
                                 </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel2" runat="server">
                             <HeaderTemplate>
                                 Zone
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                 <ContentTemplate>
<TABLE width="100%">
                                                         <TBODY>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </TD>
                                                                 <TD style="HEIGHT: 8px" align=left colSpan=2>
                                                                     <asp:Label id="lblErrorMsgDivsion" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                                                     <BR />
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 16px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px" align=left>
                                                                     <strong><asp:Label id="Label1" runat="server" Width="47px" Text="Region"></asp:Label></strong>
                                                                 </TD>
                                                                 <TD style="HEIGHT: 16px" align=left>
                                                                     <asp:DropDownList id="DrpRegion" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpRegion_SelectedIndexChanged" CssClass="DropList">
                                                                     </asp:DropDownList>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 16px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </TD>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px" align=left>
                                                                     <strong><asp:Label id="Label21" runat="server" Width="43px" Text="Name"></asp:Label></strong>
                                                                 </TD>
                                                                 <TD align=left>
                                                                     <asp:TextBox id="txtZoneName" runat="server" Width="194px" CssClass="txtBox "></asp:TextBox>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </TD>
                                                                 <TD align=right>
                                                                 </TD>
                                                                 <TD align=left>
                                                                     <asp:CheckBox id="chbIsZoneActive" runat="server" Text="Is Active" Checked="True">
                                                                     </asp:CheckBox>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </TD>
                                                             </TR>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </TD>
                                                                 <TD align=right>
                                                                     <asp:Label ID="Label4" runat="server" Text="Code" Width="43px" Visible="False"></asp:Label>
                                                                     &nbsp;</TD>
                                                                 <TD align=left>
                                                                     <asp:Button id="btnSaveZone" onclick="btnSaveZone_Click" runat="server" Width="85px" Font-Size="8pt" Text="Save" CssClass="Button" />
                                                                     <asp:TextBox ID="txtZoneCode" runat="server" CssClass="txtBox " Width="100px" Visible="False">N/A</asp:TextBox>
                                                                 </TD>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </TD>
                                                             </TR>
                                                         </TBODY>
                                                     </TABLE>
</ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="left" colspan="3">
                                             <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                 <contenttemplate>
<asp:GridView id="grdZoneData" runat="server" Width="100%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="grdZoneData_RowEditing">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<Columns>
<asp:BoundField DataField="PARENT_GEO_ID" HeaderText="PARENT_GEO_ID">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GEO_ID" HeaderText="GEO_ID">
<HeaderStyle CssClass="HidePanel"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GEO_CODE" HeaderText="Zone Code">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" CssClass="HidePanel" />
</asp:BoundField>
<asp:BoundField DataField="GEO_NAME" HeaderText="Zone Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="ISDELETED" HeaderText="Status">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView>&nbsp; 
</contenttemplate>
                                             </asp:UpdatePanel></td>
                                     </tr>
                                 </table>
                                 <br />
                                 &nbsp;
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                             <HeaderTemplate>
                                 Territory
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                 <ContentTemplate>
                                                     <TABLE width="100%">
                                                         <TBODY>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                                 <TD style="HEIGHT: 8px" align=left colSpan=2>
                                                                     <asp:Label ID="lblErrorZone" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                     <BR />
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 16px">
                                                                 </td>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px" align=left>
                                                                     <strong>
                                                                     <asp:Label ID="Label5" runat="server" Text="Region" Width="47px"></asp:Label>
                                                                     </strong>
                                                                 </td>
                                                                 <TD style="HEIGHT: 16px" align=left>
                                                                     <asp:DropDownList id="drpRegionTerritory" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpRegionTerritory_SelectedIndexChanged" CssClass="DropList">
                                                                     </asp:DropDownList>
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 16px">
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 100px; height: 8px">
                                                                 </td>
                                                                 <td align="left" style="width: 49px; height: 28px">
                                                                     <strong>
                                                                     <asp:Label ID="Label11" runat="server" Text="Zone" Width="47px"></asp:Label>
                                                                     </strong>
                                                                 </td>
                                                                 <td align="left">
                                                                     <asp:DropDownList id="DrpZone" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpZone_SelectedIndexChanged" CssClass="DropList">
                                                                     </asp:DropDownList>
                                                                 </td>
                                                                 <td style="width: 100px; height: 8px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px" align=left>
                                                                     <strong>
                                                                     <asp:Label ID="Label211" runat="server" Text="Name" Width="43px"></asp:Label>
                                                                     </strong>
                                                                 </td>
                                                                 <TD align=left>
                                                                     <asp:TextBox ID="txtTerritoryName" runat="server" CssClass="txtBox " Width="197px"></asp:TextBox>
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                                 <TD align=right>
                                                                 </td>
                                                                 <TD align=left>
                                                                     <asp:CheckBox ID="chbIsTerritoryActive" runat="server" Checked="True" Text="Is Active" />
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                                 <TD align=right>
                                                                     <asp:Label ID="Label41" runat="server" Text="Code" Width="43px" Visible="False"></asp:Label>
                                                                     &nbsp;</td>
                                                                 <TD align=left>
                                                                     <asp:Button ID="btnSaveTerritory" runat="server" Font-Size="8pt" OnClick="btnSaveTerritory_Click" CssClass="Button"
                                                                         Text="Save" Width="85px" />
                                                                     <asp:TextBox ID="txtTerritoryCode" runat="server" CssClass="txtBox " Width="100px" Visible="False">N/A</asp:TextBox>
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                             </tr>
                                                         </tbody>
                                                     </table>
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="left" colspan="3">
                                             <asp:UpdatePanel id="UpdatePanel11" runat="server">
                                                 <contenttemplate>
                                                     <asp:GridView id="grdTerritoryData" runat="server" Width="100%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="grdTerritoryData_RowEditing" AllowPaging="True" OnPageIndexChanging="grdTerritoryData_PageIndexChanging">
                                                         <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                             PreviousPageText="Previous" />
                                                         <Columns>
                                                             <asp:BoundField DataField="PARENT_GEO_ID" HeaderText="PARENT_GEO_ID">
                                                                 <HeaderStyle CssClass="HidePanel" />
                                                                 <ItemStyle CssClass="HidePanel" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="GEO_ID" HeaderText="GEO_ID">
                                                                 <HeaderStyle CssClass="HidePanel" />
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" CssClass="HidePanel"
                                                                     HorizontalAlign="Left" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="GEO_CODE" HeaderText="Territory Code">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" CssClass="HidePanel" />
                                                                 <HeaderStyle HorizontalAlign="Left" CssClass="HidePanel" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="GEO_NAME" HeaderText="Territory Name">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                 <HeaderStyle HorizontalAlign="Left" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="ISDELETED" HeaderText="Status">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                 <HeaderStyle HorizontalAlign="Left" />
                                                             </asp:BoundField>
                                                             <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                             </asp:CommandField>
                                                         </Columns>
                                                         <FooterStyle BackColor="White" />
                                                         <PagerStyle BackColor="Transparent" />
                                                         <HeaderStyle CssClass="tblhead"/>
                                                         <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                                                     </asp:GridView>
                                                     &nbsp;
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                     </tr>
                                 </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                             <HeaderTemplate>
                                 Town
                             </HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                 <ContentTemplate>
                                                     <TABLE width="100%">
                                                         <TBODY>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                                 <TD style="HEIGHT: 8px" align=left colSpan=2>
                                                                     <asp:Label ID="lblErrorZone1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                     <BR />
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 100px; height: 16px">
                                                                 </td>
                                                                 <td align="left" style="width: 49px; height: 28px">
                                                                     <strong><asp:Label ID="Label6" runat="server" Text="Region" Width="58px"></asp:Label></strong>
                                                                 </td>
                                                                 <td align="left" style="height: 16px">
                                                                     <asp:DropDownList ID="DrpTownRegion" runat="server" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="DrpTownRegion_SelectedIndexChanged" Width="200px">
                                                                     </asp:DropDownList>
                                                                 </td>
                                                                 <td style="width: 100px; height: 16px">
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                                 <td style="width: 100px; height: 16px">
                                                                 </td>
                                                                 <td align="left" style="width: 49px; height: 28px">
                                                                     <strong><asp:Label ID="Label7" runat="server" Text="Zone" Width="58px"></asp:Label></strong>
                                                                 </td>
                                                                 <td align="left" style="height: 16px">
                                                                     <asp:DropDownList ID="DrpTownZone" runat="server" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="DrpTownZone_SelectedIndexChanged" Width="200px">
                                                                     </asp:DropDownList>
                                                                 </td>
                                                                 <td style="width: 100px; height: 16px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 16px">
                                                                 </td>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px" align=left>
                                                                     <strong><asp:Label ID="Label33" runat="server" Text="Territory" Width="58px"></asp:Label></strong>
                                                                 </td>
                                                                 <TD style="HEIGHT: 16px" align=left>
                                                                     <asp:DropDownList id="DrpTerritory" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpTerritory_SelectedIndexChanged" CssClass="DropList">
                                                                     </asp:DropDownList>
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 16px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                                 <TD style="WIDTH: 49px; HEIGHT: 28px" align=left>
                                                                     <strong><asp:Label ID="Label22" runat="server" Text="Name" Width="43px"></asp:Label></strong>
                                                                 </td>
                                                                 <TD align=left>
                                                                     <asp:TextBox ID="txtTownName" runat="server" CssClass="txtBox " Width="197px"></asp:TextBox>
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 8px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                                 <TD align=right>
                                                                 </td>
                                                                 <TD align=left>
                                                                     <asp:CheckBox ID="chbIsTownActive" runat="server" Checked="True" Text="Is Active" />
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                             </tr>
                                                             <TR>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                                 <TD align=right>
                                                                     <asp:Label ID="Label44" runat="server" Text="Code" Width="43px" Visible="False"></asp:Label>
                                                                     &nbsp;</td>
                                                                 <TD align=left>
                                                                     <asp:Button ID="btnSaveTown" runat="server" Font-Size="8pt" OnClick="btnSaveTown_Click" CssClass="Button"
                                                                         Text="Save" Width="85px" />
                                                                     <asp:TextBox ID="txtTownCode" runat="server" CssClass="txtBox " Width="100px" Visible="False">N/A</asp:TextBox>
                                                                 </td>
                                                                 <TD style="WIDTH: 100px; HEIGHT: 37px">
                                                                 </td>
                                                             </tr>
                                                         </tbody>
                                                     </table>
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="left" colspan="3">
                                             <asp:UpdatePanel id="UpdatePanel15" runat="server">
                                                 <contenttemplate>
                                                     <asp:GridView id="grdTownData" runat="server" Width="100%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="grdTownData_RowEditing" AllowPaging="True" OnPageIndexChanging="grdTownData_PageIndexChanging">
                                                         <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                             PreviousPageText="Previous" />
                                                         <Columns>
                                                             <asp:BoundField DataField="PARENT_GEO_ID" HeaderText="PARENT_GEO_ID">
                                                                 <HeaderStyle CssClass="HidePanel" />
                                                                 <ItemStyle CssClass="HidePanel" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="GEO_ID" HeaderText="GEO_ID">
                                                                 <HeaderStyle CssClass="HidePanel" />
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" CssClass="HidePanel"
                                                                     HorizontalAlign="Left" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="GEO_CODE" HeaderText="Town Code">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" CssClass="HidePanel" />
                                                                 <HeaderStyle HorizontalAlign="Left" CssClass="HidePanel" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="GEO_NAME" HeaderText="Town Name">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                 <HeaderStyle HorizontalAlign="Left" />
                                                             </asp:BoundField>
                                                             <asp:BoundField DataField="ISDELETED" HeaderText="Status">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                 <HeaderStyle HorizontalAlign="Left" />
                                                             </asp:BoundField>
                                                             <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                 <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                             </asp:CommandField>
                                                         </Columns>
                                                         <FooterStyle BackColor="White" />
                                                         <PagerStyle BackColor="Transparent" />
                                                         <HeaderStyle CssClass="tblhead" />
                                                         <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                                                     </asp:GridView>
                                                     &nbsp;
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                         </td>
                                     </tr>
                                 </table>
                             </ContentTemplate>
                         </cc1:TabPanel>
                     </cc1:TabContainer>
            </td>
             </tr>
         </table>
                 </td>
                 <td>
                 </td>
             </tr>
         </table>
     </div>
</asp:Content>
