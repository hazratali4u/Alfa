<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Forms_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" Runat="Server">
<script type="text/javascript">
    function ShowHide(id, level) {
        if (level == '1') {
            if (document.getElementById("dvtr" + id).style.display == 'none') {
                document.getElementById("dvtr" + id).style.display = 'block';
                document.getElementById("imgminus" + id).style.display = 'block';
                document.getElementById("imgplus" + id).style.display = 'none';
            }
            else {
                document.getElementById("dvtr" + id).style.display = 'none';
                document.getElementById("imgminus" + id).style.display = 'none';
                document.getElementById("imgplus" + id).style.display = 'block';

            }
        }
        else if (level == 2) {

            if (document.getElementById("dvttr" + id).style.display == 'none') {
                document.getElementById("dvttr" + id).style.display = 'block';
                document.getElementById("imgminus" + id).style.display = 'block';
                document.getElementById("imgplus" + id).style.display = 'none';
            }
            else {
                document.getElementById("dvttr" + id).style.display = 'none';
                document.getElementById("imgminus" + id).style.display = 'none';
                document.getElementById("imgplus" + id).style.display = 'block';
            }
        }
    }

    function SHALL() {

        var divs = document.getElementsByTagName('div');

        for (var i = 0; i < divs.length; i++) {
            var div = divs[i];

            if (document.getElementById('hf').value == '1') {
                if (div.id.substr(0, 3) == 'dvt')
                    div.style.display = 'none';
            }
            else {
                if (div.id.substr(0, 3) == 'dvt')
                    div.style.display = 'block';
            }
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" Runat="Server">
<div id="right_data">
<table>
    <tr>
        <td colspan="2">
            <h2><asp:Label ID="lblTitle" runat="server" Text="Add Level"></asp:Label></h2>
        </td>
    </tr>
    <tr>
        <td colspan="2"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label> <br /> </td>
    </tr>
    <tr>
        <td width="20%">
           <strong> <asp:Label ID="lblMenu" runat="server" Text="Name:"></asp:Label> </strong>
        </td>
        <td>
            <asp:TextBox ID="txtMenu" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMenu" runat="server" ControlToValidate="txtMenu" ErrorMessage="Please enter Level Name" ValidationGroup="vgMenu"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td></td>
        <td>
        <br />
            <asp:Button ID="btnAdd" runat="server" Text="Save" onclick="btnAdd_Click" CssClass="Button" Width="90" ValidationGroup="vgMenu" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
         <asp:HiddenField ID="hfModuleID" runat="server" Value="0" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
        
        <h2><asp:Label ID="lblFormTitle" runat="server" Visible="false" Text="Add Forms To Level"></asp:Label> </h2>
        </td>
    </tr>
</table>   
<div>
<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="MODULE_ID" CellPadding="0" CellSpacing="0" ForeColor="Black" GridLines="None"
    ShowHeader="false" onrowdatabound="gvMain_RowDataBound" Visible="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="20">&nbsp;</td>
                                                        <td align="left" width="15">
                                                            <div id='imgplus<%# Eval("MODULE_ID") %>'>
                                                                <a href="javascript:void();" onclick="ShowHide('<%# Eval("MODULE_ID")%>','1')"> <img src="../images/left_navi-icon1_off.png"  width="11" height="11"/></a>
                                                            </div>
                                                            <div id='imgminus<%# Eval("MODULE_ID") %>' style="display:none;">
                                                                <a href="javascript:void();" onclick="ShowHide('<%# Eval("MODULE_ID")%>','1')"> <img src="../images/left_navi-icon1_on.png"  width="11" height="11"/></a>
                                                            </div>
                                                        </td>
                                                        <td align="left"><h1><%# Eval("MODULE_DESCRIPTION")%></h1></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <div id='dvtr<%# Eval("MODULE_ID") %>' style="display: none;">
                                                    <asp:GridView ID="gvSubMenu" runat="server" Width="100%" AutoGenerateColumns="False"  DataKeyNames="MODULE_ID"
                                                        CellPadding="0" CellSpacing="0" ForeColor="Black" GridLines="None" ShowHeader="false" onrowdatabound="gvSubMenu_RowDataBound">                                                        
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                        <tr>
                                                                           <td width="40">&nbsp;</td>
                                                                            <td align="left" width="15">
                                                                                <div id='imgplus<%# Eval("MODULE_ID") %>'>
                                                                                    <a href="javascript:void();" onclick="ShowHide('<%# Eval("MODULE_ID")%>','2')"> <img src="../images/left_navi-icon1_off.png"  width="11" height="11"/></a>
                                                                                </div>
                                                                                 <div id='imgminus<%# Eval("MODULE_ID") %>' style="display:none;">
                                                                                    <a href="javascript:void();" onclick="ShowHide('<%# Eval("MODULE_ID")%>','2')"> <img src="../images/left_navi-icon1_on.png"  width="11" height="11"/></a>
                                                                                </div>
                                                                            </td>
                                                                            <td align="left"><h1><%# Eval("MODULE_DESCRIPTION")%></h1></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                            <div id='dvttr<%# Eval("MODULE_ID") %>' style="display: none;">
                                                    <asp:GridView ID="gvForms" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        CellPadding="0" CellSpacing="0" ForeColor="Black" GridLines="None" ShowHeader="false" onrowdatabound="gvForms_RowDataBound">                                                        
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                        <tr>
                                                                           <td width="60">&nbsp;</td>
                                                                            <td align="left" width="5%"><asp:CheckBox ID="cbModule" runat="server" /> </td>
                                                                            <td align="left" width="500"><h2> <%# Eval("MODULE_DESCRIPTION")%></h2></td>
                                                                            <td align="left">
                                                                                <asp:HiddenField ID="hfMODULE_ID" runat="server" Value=<%# Eval("MODULE_ID")%> />
                                                                                <asp:HiddenField ID="hfParentID" runat="server" Value=<%# Eval("MODULE_PARENT_ID")%> />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
    </div>
</div>  
    <script>
        onload = function () { SHALL(); }
    </script>
</asp:Content>

