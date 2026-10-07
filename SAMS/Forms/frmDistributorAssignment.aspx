<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmDistributorAssignment.aspx.cs" inherits="Forms_frmDistributorAssignment" title="SAMS: Location Assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">

    <div id="right_data">
        <table width="100%">
            <tr>
                <td style="width: 100px; height: 363px;">
                </td>
                <td>
                
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 82px; HEIGHT: 17px"><asp:Label id="lblmsg" runat="server" Width="114px" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 216px">&nbsp; </TD><TD style="HEIGHT: 17px"></TD></TR><TR><TD style="HEIGHT: 10px">
<strong> <asp:Label id="Label5" runat="server" Width="107px" Text="Select User" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 216px; HEIGHT: 10px"><asp:DropDownList id="ddRole" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="ddUser_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="HEIGHT: 10px"></TD></TR><TR><TD style="HEIGHT: 13px">
<strong><asp:Label id="Label1" runat="server" Width="112px" Text="Location Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 216px; HEIGHT: 13px"><asp:DropDownList id="ddDistributorType" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=center colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD colSpan=2><TABLE><TBODY><TR><TD style="WIDTH: 100px" rowSpan=4><asp:ListBox id="lstUnAssignDistributor" runat="server" Width="150px" Height="200px" CssClass="DropList"></asp:ListBox></TD><TD align=center></TD><TD style="WIDTH: 102px" rowSpan=4><asp:ListBox id="lstAssignDistributor" runat="server" Width="150px" Height="200px" CssClass="DropList"></asp:ListBox></TD></TR><TR><TD align=center>
<asp:Button id="Button3" onclick="Button3_Click" runat="server" Width="30px" CssClass="Button" Text=">"></asp:Button></TD></TR><TR><TD align=center>
<asp:Button id="Button4" onclick="Button4_Click" runat="server" Width="30px" CssClass="Button" Text="<"></asp:Button></TD></TR><TR><TD align=center></TD></TR><TR><TD rowSpan=1></TD><TD style="WIDTH: 75px; HEIGHT: 24px"></TD><TD rowSpan=1></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 100px; height: 363px;">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:UpdateProgress id="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
<asp:ImageButton id="ImageButton1" runat="server" Width="28px" Height="22px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton> 
</ProgressTemplate>

                    </asp:UpdateProgress></td>
            </tr>
        </table>
        </div>

</asp:Content>

