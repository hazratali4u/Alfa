<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="Level2.aspx.cs" Inherits="Forms_Level2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" Runat="Server">
<div id="right_data">

<asp:GridView ID="gvFrom" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="MODULE_ID" CellPadding="0" CellSpacing="0" ForeColor="Black" GridLines="None"
    ShowHeader="false" >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
               <table cellpadding="0" cellspacing="0" heith="100%">
                    <tr>
                        <td width="40">&nbsp;</td>
                        <td style="font-size:15px">
                            <a href="<%# Eval("MODULE_ID")%>?LevelType=3&LevelID=<%# Eval("mid")%>" style="text-decoration:none; color:#006699;"><%# Eval("MODULE_DESCRIPTION")%></a> 
                        </td>
                    </tr>
               </table>                     
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</div>
</asp:Content>

