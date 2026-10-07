<%@ page language="C#" masterpagefile="~/Forms/AppMaster.master" autoeventwireup="true" CodeFile = "frmBrandAssignment.aspx.cs" inherits="Forms_frmBrandAssignment" title="SAMS: Principal Assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">
<script language="JavaScript" type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );
    function startRequest( sender, e )
    {
        document.getElementById('<%=btnSave.ClientID%>').disabled = true;        
    }

    function endRequest( sender, e ) 
    {
        document.getElementById('<%=btnSave.ClientID%>').disabled = false;        
    }
	</script>
	
   <div class="container" style="background-color: white">
        <h2>
            &nbsp; Principal Assignment</h2>
    </div>
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px; height: 357px;">
                </td>
                <td style="height: 357px">
                
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 124px; HEIGHT: 17px"><asp:Label id="lblmsg" runat="server" Visible="False" Width="114px" ForeColor="Red"></asp:Label></TD><TD style="WIDTH: 293px">&nbsp; </TD><TD style="HEIGHT: 17px"></TD></TR><TR><TD align=right><asp:Label id="Label5" runat="server" Width="52px" Text="User" CssClass="lblbox"></asp:Label> &nbsp;&nbsp; </TD><TD style="WIDTH: 293px; HEIGHT: 10px"><asp:DropDownList id="ddRole" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddUser_SelectedIndexChanged"></asp:DropDownList></TD><TD style="HEIGHT: 10px"></TD></TR><TR><TD align=center colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD colSpan=2><TABLE><TBODY><TR><TD style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; BORDER-LEFT: gray thin solid; WIDTH: 102px; BORDER-BOTTOM: gray thin solid" rowSpan=4><asp:Panel id="pnllstUnAssignBran" runat="server" Width="200px" Height="200px" ScrollBars="None" HorizontalAlign="Left" BorderColor="#404040" BackColor="White">
<asp:ListBox id="lstUnAssignBrand" runat="server" Width="200px" Height="200px" CssClass="DropList"></asp:ListBox> 
</asp:Panel> <DIV style="Z-INDEX: 101; LEFT: 284px; WIDTH: 100px; POSITION: absolute; TOP: 245px; HEIGHT: 100px"><asp:Panel id="Panel1" runat="server"><asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"><ProgressTemplate>
&nbsp;<asp:ImageButton id="ImageButton1" runat="server" Width="31px" Height="33px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton> 
</ProgressTemplate>
</asp:UpdateProgress> </asp:Panel> </DIV></TD><TD style="WIDTH: 75px" align=center><asp:Button id="Button3" onclick="Button3_Click" runat="server" Width="30px" Font-Size="8pt" Text=">"></asp:Button></TD><TD style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; BORDER-LEFT: gray thin solid; WIDTH: 112px; BORDER-BOTTOM: gray thin solid" rowSpan=4><asp:Panel id="pnllstAssignBran" runat="server" Width="220px" Height="200px" ScrollBars="Vertical" HorizontalAlign="Left" BorderColor="#404040" BackColor="White"><asp:CheckBoxList id="lstAssignBrand" runat="server" Width="200px" CssClass="DropList" RepeatLayout="Flow" BorderColor="White"></asp:CheckBoxList></asp:Panel> </TD></TR><TR><TD style="WIDTH: 75px" align=center><asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="30px" Font-Size="8pt" Text=">>"></asp:Button></TD></TR><TR><TD style="WIDTH: 75px" align=center><asp:Button id="Button2" onclick="Button2_Click" runat="server" Width="30px" Font-Size="8pt" Text="<<"></asp:Button></TD></TR><TR><TD style="WIDTH: 75px" align=center><asp:Button id="Button4" onclick="Button4_Click" runat="server" Width="30px" Font-Size="8pt" Text="<"></asp:Button></TD></TR><TR><TD rowSpan=1></TD><TD style="WIDTH: 75px; HEIGHT: 14px"></TD><TD rowSpan=1></TD></TR><TR><TD align=center colSpan=3 rowSpan=1><asp:Button id="btnSave" runat="server" Width="80px" Font-Size="8pt" Text="Save" __designer:wfdid="w2" OnClick="btnSave_Click"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 100px; height: 357px;">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    </td>
            </tr>
        </table>
      
       
        </div>

</asp:Content>

