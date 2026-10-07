<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmAccountHeadAssignment.aspx.cs" Inherits="Forms_frmAccountHeadAssignment" Title="SAMS: Account Head Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
<script language="javascript" type="text/javascript">

Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );
Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );
function startRequest( sender, e )
{
    document.getElementById('<%=btnAssign.ClientID%>').disabled = true; 
}

function endRequest( sender, e ) 
{
    document.getElementById('<%=btnAssign.ClientID%>').disabled = false;   
}
    
function SelectAllAccountHead()
{    
    var chkBoxList = document.getElementById('<%= ChAccountHead.ClientID %>');
    var chkBox = document.getElementById('<%= ChAll.ClientID %>');
    if(chkBox.checked == true)
    {
        var chkBoxCount= chkBoxList.getElementsByTagName("input");
    
        for(var i=0;i<chkBoxCount.length;i++) 
        {
            chkBoxCount[i].checked = true;
        }
    }
    else
    {
        var chkBoxCount= chkBoxList.getElementsByTagName("input");
    
        for(var i=0;i<chkBoxCount.length;i++) 
        {
            chkBoxCount[i].checked = false;
        }
    }            
}

function UnCheckSelectAll()
{
    var chkBox = document.getElementById('<%= ChAll.ClientID %>');
    var chkBoxList = document.getElementById('<%= ChAccountHead.ClientID %>');
    var chkBoxCount= chkBoxList.getElementsByTagName("input");
    var count = 0;
    for(var i=0;i<chkBoxCount.length;i++) 
     {
        if(chkBoxCount[i].checked == false)
        {
            count +=1;
        }
     }
     if(count > 0)
     {
        chkBox.checked = false;
     }
     else
     {
        chkBox.checked = true;
     }         
}
</script>
<div id="right_data">
<div >    
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<TABLE width=500 align=center><TBODY><TR><TD style="WIDTH: 100%" colSpan=5>&nbsp;</TD></TR><TR><TD style="WIDTH: 5%; HEIGHT: 22px"></TD><TD style="WIDTH: 25%; HEIGHT: 22px" align=left><strong>Principal:</strong></TD><TD style="WIDTH: 5%; HEIGHT: 22px"></TD><TD style="WIDTH: 60%; HEIGHT: 22px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w79" CssClass="DropList"></asp:DropDownList> </TD><TD style="WIDTH: 5%; HEIGHT: 22px"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 25%" align=left><strong>Account Category</strong></TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 60%" align=left><asp:DropDownList id="DrpAccountCategory" runat="server" Width="200px" OnSelectedIndexChanged="DrpAccountCategory_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w103" CssClass="DropList"><asp:ListItem>Balance Sheet Account</asp:ListItem>
<asp:ListItem>Income Statment Account</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%; HEIGHT: 24px"></TD><TD style="WIDTH: 25%; HEIGHT: 24px" align=left><strong>Main Account Type:</strong></TD><TD style="WIDTH: 5%; HEIGHT: 24px"></TD><TD style="WIDTH: 60%; HEIGHT: 24px" align=left><asp:DropDownList id="DrpMainAccountType" runat="server" Width="200px" OnSelectedIndexChanged="DrpMainAccountType_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w80" CssClass="DropList"></asp:DropDownList> </TD><TD style="WIDTH: 5%; HEIGHT: 24px"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 25%" align=left><strong>Sub Account Type:</strong></TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 60%" align=left><asp:DropDownList id="DrpSubAccountType" runat="server" Width="200px" OnSelectedIndexChanged="DrpSubAccountType_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w81" CssClass="DropList"></asp:DropDownList> </TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 25%" align=left><strong>Detail Account Type:</strong></TD><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 60%" align=left><asp:DropDownList id="DrpDetailAccountType" runat="server" Width="200px" OnSelectedIndexChanged="DrpDetailAccountType_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w82" CssClass="DropList"></asp:DropDownList> </TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 100%" colSpan=5>
<div style="z-index: 101; left: 495px; width: 100px; position: absolute; top: 470px;
        height: 100px">
        <asp:Panel ID="Panel1" runat="server">
                    <asp:UpdateProgress id="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        &nbsp;<asp:ImageButton ID="btnImage" runat="server" Height="33px" Width="31px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"/>
</ProgressTemplate>

                    </asp:UpdateProgress>
        </asp:Panel>
    </div>

</TD></TR><TR><TD style="WIDTH: 5%"></TD><TD align=left colSpan=3>
<strong> <asp:Label id="lblAccountHead" runat="server" Visible="False" Text="Account Head" __designer:wfdid="w1"></asp:Label></strong></TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD align=left colSpan=3><strong><asp:CheckBox id="ChAll" onclick="SelectAllAccountHead()" runat="server" Visible="False" Width="75px" Font-Size="8pt" Text="Select All" __designer:wfdid="w2" CssClass="DropList"></asp:CheckBox> </strong></TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%; HEIGHT: 36px"></TD><TD style="HEIGHT: 36px" align=left colSpan=3><asp:Panel id="Panel2" runat="server" Visible="False" Width="350px" Height="150px" ScrollBars="Vertical" __designer:wfdid="w3" BackColor="White" BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
<asp:CheckBoxList id="ChAccountHead" onclick = "UnCheckSelectAll()" runat="server" __designer:wfdid="w4">
        </asp:CheckBoxList> <DIV style="Z-INDEX: 101; LEFT: -97px; WIDTH: 100px; POSITION: absolute; TOP: 216px; HEIGHT: 100px"></DIV></asp:Panel> </TD><TD style="WIDTH: 5%; HEIGHT: 36px"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD align=center colSpan=3></TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD align=center colSpan=3>
        <asp:Button id="btnAssign" onclick="btnAssign_Click" runat="server" Text="Assign" CssClass="Button" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD align=center colSpan=3></TD><TD style="WIDTH: 5%"></TD></TR></TBODY></TABLE>
</ContentTemplate>
        </asp:UpdatePanel>
                </td>
            </tr>
            
        </table>
    </div>
    </div>
</asp:Content>

