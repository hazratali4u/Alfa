<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmTownAssignment.aspx.cs" inherits="Forms_frmTownAssignment" title="SAMS: Town Assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <div id="right_data">
    <div>
        <table width="100%">
            <tr>
                
                <td align="left">
                
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE><TBODY><TR>
    <td colspan="2" align="left">
        <asp:Label id="lblmsg" runat="server" Visible="False" Width="175px" ForeColor="Red"></asp:Label>&nbsp;
    </td>
    <TD style="HEIGHT: 17px"></TD></TR><TR><TD style="HEIGHT: 25px;" align="left">
   <strong> <asp:Label id="Label1" runat="server" Width="58px" Text="Locaton"></asp:Label></strong>
   </TD><TD align="left"><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged"></asp:DropDownList></TD><TD style="HEIGHT: 10px"></TD></TR><TR><TD style="HEIGHT: 25px;" align="left">
   <strong><asp:Label id="Label11" runat="server" Width="56px" Text="Region" CssClass="lblbox"></asp:Label></strong>
   </TD><TD align="left"><asp:DropDownList id="ddRegion" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddRegion_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align="left">
   <strong><asp:Label id="Label2" runat="server" Width="43px" Text="Zone" CssClass="lblbox"></asp:Label></strong>
   </TD><TD align="left"><asp:DropDownList id="ddZone" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddZone_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align="left">
   <strong><asp:Label id="Label3" runat="server" Width="51px" Text="Territory" CssClass="lblbox"></asp:Label></strong>
   </TD><TD align="left"><asp:DropDownList id="ddTerritory" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddTerritory_SelectedIndexChanged"></asp:DropDownList></TD></TR></TBODY></TABLE>
</ContentTemplate>
                    </asp:UpdatePanel>
                </td>
               
            </tr>
        </table>
      
       
        </div>
    <div >
        <table width="100%">
            <tr>
                
                <td align="left">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server"><contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px" rowSpan=1>
<strong><asp:Label id="Label4" runat="server" Width="142px" Text="Unassigned Town" CssClass="lblbox"></asp:Label></strong>
</TD><TD style="WIDTH: 102px" vAlign=bottom align=center></TD><TD style="WIDTH: 102px" rowSpan=1>
<strong><asp:Label id="Label6" runat="server" Text="Assigned Town"></asp:Label></strong>
</TD></TR><TR><TD style="WIDTH: 100px" rowSpan=4><asp:ListBox id="lstUnAssignTown" runat="server" Width="150px" Height="200px" CssClass="DropList"></asp:ListBox></TD><TD vAlign=middle align=center>
<asp:Button id="btnAssign" runat="server" Width="30px" Font-Size="8pt" Text=">" OnClick="btnAssign_Click" CssClass="Button" />
</TD><TD style="WIDTH: 102px" rowSpan=4><asp:ListBox id="lstAssignTown" runat="server" Width="150px" Height="200px" CssClass="DropList"></asp:ListBox></TD></TR><TR><TD align=center>
<asp:Button id="btnAssignAll" runat="server" Width="30px" Font-Size="8pt" Text=">>" OnClick="btnAssignAll_Click" CssClass="Button" />
</TD></TR><TR><TD align=center>
<asp:Button id="btnUnAssign" runat="server" Width="30px" Font-Size="8pt" Text="<<" OnClick="btnUnAssign_Click" CssClass="Button" />

</TD></TR><TR><TD vAlign=middle align=center>
<asp:Button id="btnUnAssignAll" runat="server" Width="30px" Font-Size="8pt" Text="<" OnClick="btnUnAssignAll_Click" CssClass="Button" /> </TD></TR><TR><TD style="HEIGHT: 24px" rowSpan=1></TD><TD style="WIDTH: 102px; HEIGHT: 24px"></TD><TD style="HEIGHT: 24px" rowSpan=1></TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
                
            </tr>
            
        </table>
    </div>
    </div>
</asp:Content>
