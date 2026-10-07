<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true"  CodeFile = "frmRoleManagement.aspx.cs" inherits="frmRoleManagement" title="SAMS: Role Management" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 82px; HEIGHT: 17px"><asp:Label id="lblmsg" runat="server" Visible="False" Width="114px" ForeColor="Red"></asp:Label></TD><TD>&nbsp; </TD><TD style="HEIGHT: 17px"></TD></TR><TR><TD>
<strong> <asp:Label id="Label1" runat="server" Width="107px" Text="Role Description" CssClass="lblbox"></asp:Label></strong></TD><TD><asp:DropDownList id="ddRole" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="ddRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:TextBox id="TextBox1" runat="server" Visible="False" Width="195px" CssClass="txtBox " Enabled="False"></asp:TextBox></TD><TD>
<asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Width="55px" Font-Size="8pt" Text="New" CssClass="Button" /> </TD></TR><TR><TD>
<strong><asp:Label id="Label11" runat="server" Width="112px" Text="Module 1st Layer" CssClass="lblbox"></asp:Label></strong></TD><TD><asp:DropDownList id="DrpModule1stLayer" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="DrpModule1stLayer_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 24px">
<strong><asp:Label id="Label2" runat="server" Width="112px" Text="Module 2nd Layer" CssClass="lblbox"></asp:Label></strong></TD><TD><asp:DropDownList id="DrpModule2ndLayer" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="DrpModule2ndLayer_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 16px">
<strong><asp:Label id="Label3" runat="server" Width="112px" Text="Module 3rd Layer" CssClass="lblbox"></asp:Label></strong></TD><TD><asp:DropDownList id="DrpModule3rdLayer" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="DrpModule3rdLayer_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=center colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<strong><asp:Label id="Label4" runat="server" Width="142px" Text="Module Assignment" CssClass="lblbox"></asp:Label></strong> &nbsp; </TD></TR><TR><TD style="HEIGHT: 182px" colSpan=2><TABLE><TBODY><TR><TD style="WIDTH: 100px" rowSpan=4><asp:ListBox id="lstUnAssignModule" runat="server" Width="150px" Height="200px" CssClass="DropList"></asp:ListBox></TD><TD></TD><TD style="WIDTH: 102px" rowSpan=4><asp:ListBox id="lstAssignModule" runat="server" Width="150px" Height="200px" CssClass="DropList"></asp:ListBox></TD></TR><TR><TD align=center>
<asp:Button id="btnAssign" runat="server" Width="30px" Font-Size="8pt" Text=">>" OnClick="btnAssign_Click" CssClass="Button" /> </TD></TR><TR><TD align=center>
<asp:Button id="btnUnAssign" runat="server" Width="30px" Font-Size="8pt" Text="<<" OnClick="btnUnAssign_Click" CssClass="Button" /> </TD></TR><TR><TD style="WIDTH: 75px"></TD></TR><TR><TD rowSpan=1></TD><TD style="WIDTH: 75px; HEIGHT: 24px"></TD><TD rowSpan=1></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
                    </asp:UpdatePanel>
                </td>
              
            </tr>
            <tr>
                <td align="left" width="10%">
                <asp:Button ID="btnReport" runat="server" Text="View Report" OnClick="btnReport_Click" Width="120px" CssClass="Button" />
                </td>
            </tr>
           
        </table>
      
       
        </div>
</asp:Content>

