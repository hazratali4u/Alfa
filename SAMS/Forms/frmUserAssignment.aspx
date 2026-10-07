<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmUserAssignment.aspx.cs" Inherits="Forms_frmUserAssignment" Title="SAMS: User Assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
<script language="JavaScript" type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );
    function startRequest( sender, e )
    {
        document.getElementById('<%=btnSave.ClientID%>').disabled = true;  
        document.getElementById('<%=btnAssign.ClientID%>').disabled = true;
        document.getElementById('<%=btnAssignLocation.ClientID%>').disabled = true;  
        document.getElementById('<%=btnUnAssignLocation.ClientID%>').disabled = true;
        document.getElementById('<%=btnAssignPrincipal.ClientID%>').disabled = true;  
        document.getElementById('<%=btnAssignAllPrincipal.ClientID%>').disabled = true;
        document.getElementById('<%=btnUnAssignPrincipal.ClientID%>').disabled = true;  
        document.getElementById('<%=btnUnAssignAllPrincipal.ClientID%>').disabled = true;        
    }

    function endRequest( sender, e ) 
    {
        document.getElementById('<%=btnSave.ClientID%>').disabled = false;        
        document.getElementById('<%=btnAssign.ClientID%>').disabled = false;
        document.getElementById('<%=btnAssignLocation.ClientID%>').disabled = false;        
        document.getElementById('<%=btnUnAssignLocation.ClientID%>').disabled = false;
        document.getElementById('<%=btnAssignPrincipal.ClientID%>').disabled = false;        
        document.getElementById('<%=btnAssignAllPrincipal.ClientID%>').disabled = false;
        document.getElementById('<%=btnUnAssignPrincipal.ClientID%>').disabled = false;                        
        document.getElementById('<%=btnUnAssignAllPrincipal.ClientID%>').disabled = false;  
    }
	</script>
	
<div id="right_data">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE width="100%">
<TBODY>
<TR>
<td colSpan="3">
<TABLE width="100%">
<TBODY>
<TR>
<TD >
<strong><asp:Label id="Label5" runat="server" Width="107px" Text="User" ></asp:Label> </strong><asp:DropDownList id="ddUser" runat="server" Width="200px" __designer:wfdid="w62" CssClass="DropList" OnSelectedIndexChanged="ddUser_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD>
</TR>
</TBODY>
</TABLE>
</TD>
</TR>
<TR>
<TD style="HEIGHT: 345px"><cc1:TabContainer id="tbUserAssignment" runat="server" Width="550px" Height="260px" AutoPostBack="True" ActiveTabIndex="0" OnActiveTabChanged="tbUserAssignment_ActiveTabChanged"><cc1:TabPanel runat="server" ID="TabPanel1"><HeaderTemplate>
                                     Location Assignment
                                 
</HeaderTemplate>
<ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 5%; HEIGHT: 250px"></TD><TD style="WIDTH: 90%" vAlign=top><TABLE><TBODY><TR><TD style="HEIGHT: 13px" align=left colSpan=2>
<strong><asp:Label id="Label1" runat="server" Width="112px" Text="Location Type" ></asp:Label></strong> <asp:DropDownList id="ddDistributorType" runat="server" Width="200px" __designer:wfdid="w20" CssClass="DropList" OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;</TD></TR><TR><TD align=center colSpan=2>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </TD></TR><TR><TD colSpan=3><TABLE><TBODY><TR><TD style="WIDTH: 40%" rowSpan=4><asp:ListBox id="lstUnAssignDistributor" runat="server" Width="200px" Height="200px" __designer:wfdid="w21" CssClass="DropList"></asp:ListBox> </TD><TD style="WIDTH: 52px" align=center></TD><TD style="WIDTH: 40%" rowSpan=4><asp:ListBox id="lstAssignDistributor" runat="server" Width="200px" Height="200px" __designer:wfdid="w22" CssClass="DropList"></asp:ListBox> </TD></TR><TR><TD style="WIDTH: 52px" align=center>
<asp:Button id="btnAssignLocation" onclick="btnAssignLocation_Click" runat="server" Width="30px" Font-Size="8pt" Text=">" CssClass="Button" /> </TD></TR><TR><TD style="WIDTH: 52px" align=center>
<asp:Button id="btnUnAssignLocation" onclick="btnUnAssignLocation_Click" runat="server" Width="30px" Font-Size="8pt" Text="<" CssClass="Button" /> </TD></TR><TR><TD style="WIDTH: 52px" align=center></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 5%; HEIGHT: 250px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" TabIndex="1" ID="TabPanel2"><HeaderTemplate>
                                     Principal Assignment
                                 
</HeaderTemplate>
<ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 2%; HEIGHT: 250px"></TD><TD style="WIDTH: 96%; HEIGHT: 250px" colSpan=3><TABLE><TBODY><TR><TD style="HEIGHT: 265px" colSpan=3><TABLE><TBODY><TR><TD style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; BORDER-LEFT: gray thin solid; WIDTH: 102px; BORDER-BOTTOM: gray thin solid" rowSpan=4><asp:Panel id="pnllstUnAssignBran" runat="server" Width="200px" Height="200px" __designer:wfdid="w842" BorderColor="#404040" BackColor="White" HorizontalAlign="Left"><asp:ListBox id="lstUnAssignBrand" runat="server" Width="200px" Height="200px" CssClass="DropList" __designer:wfdid="w843"></asp:ListBox> </asp:Panel> </TD><TD style="WIDTH: 75px" align=center>
<asp:Button id="btnAssignPrincipal" onclick="btnAssignPrincipal_Click" runat="server" Width="30px" Font-Size="8pt" Text=">" CssClass="Button" /> </TD><TD style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; BORDER-LEFT: gray thin solid; WIDTH: 112px; BORDER-BOTTOM: gray thin solid" rowSpan=4><asp:Panel id="pnllstAssignBran" runat="server" Width="220px" Height="200px" ScrollBars="Vertical" __designer:wfdid="w845" BorderColor="#404040" BackColor="White" HorizontalAlign="Left">
<asp:CheckBoxList id="lstAssignBrand" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w846" BorderColor="White" RepeatLayout="Flow"></asp:CheckBoxList>
</asp:Panel> </TD></TR><TR><TD style="WIDTH: 75px" align=center>
<asp:Button id="btnAssignAllPrincipal" onclick="btnAssignAllPrincipal_Click" runat="server" Width="30px" Font-Size="8pt" Text=">>" CssClass="Button" /> </TD></TR><TR><TD style="WIDTH: 75px" align=center>
<asp:Button id="btnUnAssignPrincipal" onclick="btnUnAssignPrincipal_Click" runat="server" Width="30px" Font-Size="8pt" Text="<<" CssClass="Button" /> </TD></TR><TR><TD style="WIDTH: 75px" align=center>
<asp:Button id="btnUnAssignAllPrincipal" onclick="btnUnAssignAllPrincipal_Click" runat="server" Width="30px" Font-Size="8pt" Text="<" CssClass="Button" /> </TD></TR><TR><TD rowSpan=1></TD><TD style="WIDTH: 20%; HEIGHT: 14px"></TD><TD rowSpan=1></TD></TR><TR><TD style="HEIGHT: 21px" align=center colSpan=3 rowSpan=1>
<asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="80px" Font-Size="8pt" Text="Save" CssClass="Button" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 2%; HEIGHT: 250px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" HeaderText="TabPanel3" TabIndex="2" ID="TabPanel3"><HeaderTemplate>
                                     Voucher Type Assignment
                                 
</HeaderTemplate>
<ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 5%; HEIGHT: 250px"></TD><TD style="WIDTH: 90%; HEIGHT: 250px" vAlign=middle align=center><TABLE><TBODY><TR><TD colSpan=2><TABLE><TBODY><TR><TD style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; BORDER-LEFT: gray thin solid; WIDTH: 112px; BORDER-BOTTOM: gray thin solid" rowSpan=4><asp:Panel id="pnlVoucherType" runat="server" Width="220px" Height="150px" ScrollBars="Vertical" __designer:wfdid="w854" BorderColor="#404040" BackColor="White" HorizontalAlign="Left"><asp:CheckBoxList id="cblVoucherType" runat="server" Width="200px" CssClass="DropList" __designer:wfdid="w855" BorderColor="White" RepeatLayout="Flow"></asp:CheckBoxList></asp:Panel> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><BR />
<asp:Button id="btnAssign" onclick="btnAssign_Click" runat="server" Width="80px" Font-Size="8pt" Text="Assign" CssClass="Button" /> </TD><TD style="WIDTH: 5%; HEIGHT: 250px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer></TD>
</TR>
</TBODY></TABLE>
</ContentTemplate>
                      </asp:UpdatePanel>
</div> 
</asp:Content>