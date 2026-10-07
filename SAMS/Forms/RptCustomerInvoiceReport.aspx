<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptCustomerInvoiceReport.aspx.cs" Inherits="Forms_RptCustomerInvoiceReport" Title="SAMS: Customer Invoice Wise Sales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
     <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{
			
		return true;	  		
	}

    </script>
    <div id="right_data">
<div >
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE>
    <tr>
        <td align="left">
        </td>
        <td align="left" colspan="3">
        </td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Principal" Width="70px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="drpDistributor" runat="server" CssClass="DropList" Width="200px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="77px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10"
                onkeyup="BlockStartDateKeyPress()" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="76px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10"
                onkeyup="BlockEndDateKeyPress()" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:RadioButtonList ID="RblCustomer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RblCustomer_SelectedIndexChanged">
                <asp:ListItem Selected="True">Show All Customer</asp:ListItem>
                <asp:ListItem>Individulal Customer</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="left">
            </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
            <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy"
                PopupButtonID="ibtnStartDate" TargetControlID="txtStartDate">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                TargetControlID="txtEndDate">
            </cc1:CalendarExtender>
            </td>
    </tr>
</TABLE>
                            &nbsp;
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
         &nbsp;
        
           </div>
    <div >
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <ContentTemplate>
<TABLE style="BORDER-RIGHT: silver thin inset; BORDER-TOP: silver thin inset; BORDER-LEFT: silver thin inset; WIDTH: 100%; BORDER-BOTTOM: silver thin inset; BACKGROUND-COLOR: silver"><TBODY><TR><TD style="HEIGHT: 21px" align=left>
<strong><asp:Label id="Label10" runat="server" Width="127px" Text="Select Searching Type"></asp:Label></strong> </TD><TD style="WIDTH: 170px; HEIGHT: 21px" align=left><asp:DropDownList id="ddSearchType" runat="server" Width="195px" CssClass="DropList">
                                            <asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
                                            <asp:ListItem Value="ADDRESS">Address</asp:ListItem>
                                            <asp:ListItem Value="Distributor_NAME">Location</asp:ListItem>
                                            <asp:ListItem Value="AREA_NAME">Route Name</asp:ListItem>
                                            <asp:ListItem Value="SLASH_DESC">Channel Type</asp:ListItem>
                                            <asp:ListItem Value="CUSTOMER_CODE">Customer Code</asp:ListItem>
                                        </asp:DropDownList> </TD><TD align=right>&nbsp;Value%</TD><TD style="WIDTH: 224px; HEIGHT: 21px" align=left><asp:TextBox id="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox> </TD><TD style="HEIGHT: 21px" align=left width=250><asp:Button id="btnFilter" runat="server" Width="85px" Font-Size="8pt" Text="Filter" OnClick="btnFilter_Click"></asp:Button> </TD></TR></TBODY></TABLE><asp:Panel id="Panel2" runat="server" Width="100%" Height="169px" ScrollBars="Vertical">
                            <asp:GridView ID="Grid_users" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center" Width="99%">
                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                    PreviousPageText="Previous" />
                                <RowStyle ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChbCustomer" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                                        <HeaderStyle CssClass="HidePanel" />
                                        <ItemStyle CssClass="HidePanel" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Distributor_id" HeaderText="Distributor_id">
                                        <HeaderStyle CssClass="HidePanel" />
                                        <ItemStyle CssClass="HidePanel" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Distributor_Name" HeaderText="Location">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AREA_NAME" HeaderText="Route">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChannelType" HeaderText="Channel Type">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="tblhead" />
                                
                            </asp:GridView>
                        </asp:Panel> 
</ContentTemplate>
                </asp:UpdatePanel>
                    <asp:Button ID="BtnViewPdf" runat="server" CssClass="Button" OnClick="BtnViewPdf_Click"
                        Text="View PDF" Width="90" />
                <asp:Button ID="btnViewExcel" runat="server" CssClass="Button"
                Text="View Excel" Width="90" OnClick="btnViewExcel_Click" />
            </td>
        </tr>
    </table>
    </div>
    </div>
   
</asp:Content>
