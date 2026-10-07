<%@ Page Title="CORN >> License Renewal" Language="C#" MasterPageFile="~/LoginMaster.master" AutoEventWireup="true" CodeFile="License.aspx.cs" Inherits="License" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpChild" Runat="Server">
<table width="50%">
    <tr>
        <td style="width:30%" align="right">
        </td>
        <td style="width:1%"></td>
        <td style="width:69%">
            <h1>License Renewal</h1>
        </td>
    </tr>
    <tr>
        <td style="width:30%" align="right">
        </td>
        <td style="width:1%"></td>
        <td style="width:69%">
            <br />
        </td>
    </tr>
    <tr>
        <td style="width:30%" align="right">
            <strong><asp:Label ID="lblFileUpload" runat="server" Text="Browse License File: "></asp:Label></strong>
        </td>
        <td style="width:1%"></td>
        <td style="width:69%">
            <asp:FileUpload ID="fuLicense" runat="server" />                       
        </td>
    </tr>
    <tr>
        <td style="width:30%" align="right">            
        </td>
        <td style="width:1%"></td>
        <td style="width:69%">
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="This is a required field!" ControlToValidate="fuLicense">
            </asp:RequiredFieldValidator>             
        </td>
    </tr>
    <tr>
        <td style="width:30%" align="right">            
        </td>
        <td style="width:1%"></td>
        <td style="width:69%">
            <asp:Button ID="btnUpload" runat="server" Text="Run" CssClass="Button" 
                onclick="btnUpload_Click" />
        </td>
    </tr>
</table>
    
</asp:Content>

