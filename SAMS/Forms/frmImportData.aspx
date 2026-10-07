<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmImportData.aspx.cs" Inherits="Forms_frmImportData" Title="SAMS: Import Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 486px; width: 100px; position: absolute; top: 191px;
                        height: 100px">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                    Width="22px" />
                                Record Update
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
<TABLE><TBODY>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
        </td>
        <td align="left">
            <strong><asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Width="175px"></asp:Label></strong></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
          <strong>  <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="File Type" Width="58px"></asp:Label></strong></td>
        <td align="left">
            <asp:DropDownList id="cboFileTypes" runat="server" Width="200px" CssClass="DropList">
                <asp:ListItem Value="0">Route</asp:ListItem>
                <asp:ListItem Value="1">Market</asp:ListItem>
                <asp:ListItem Value="2">Customer</asp:ListItem>
                <asp:ListItem Value="3">SKUS</asp:ListItem>
                <asp:ListItem Value="4">SKU Price</asp:ListItem>
            </asp:DropDownList></td>
        <td style="height: 10px">
        </td>
    </tr>
    <TR><TD style="HEIGHT: 25px; width: 59px;" align="left">
    <strong><asp:Label id="Label1" runat="server" Width="58px" Text="Locaton" CssClass="lblbox"></asp:Label></strong></TD><TD align="left"><asp:DropDownList id="DrpDistributor" runat="server" Width="200px" CssClass="DropList"></asp:DropDownList></TD><TD style="HEIGHT: 10px"></TD></TR>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Town" Width="46px"></asp:Label></strong></td>
        <td align="left">
            <asp:DropDownList id="DrpTown" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
            <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Principal" Width="46px"></asp:Label></strong></td>
        <td align="left">
            <asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
        </td>
        <td align="left">
        </td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="height: 25px">
            <asp:FileUpload ID="txtFile" runat="server" Width="287px" /></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 59px; height: 25px">
        </td>
        <td align="left">
            <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" Text="Save"
                ValidationGroup="vg" CssClass="button" /></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="height: 25px">
        </td>
        <td style="height: 10px">
        </td>
    </tr>
</TBODY></TABLE>
                </td>               
            </tr>
        </table>
      
       
        </div>
</asp:Content>
