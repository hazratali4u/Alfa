<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmDayCloseStatus.aspx.cs" Inherits="Forms_frmDayCloseStatus" Title="SAMS: Data Update Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
<script language="JavaScript" type="text/javascript" >
           javascript:window.history.forward(1);        
           
</script>
    <script language="JavaScript" type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );
    function startRequest( sender, e )
    {
        if (document.getElementById('<%=btnDayClose.ClientID%>')!= null)
        {
            document.getElementById('<%=btnDayClose.ClientID%>').disabled = true;
        }
    }
    
    function endRequest( sender, e ) 
    {
        if (document.getElementById('<%=btnDayClose.ClientID%>')!= null)
        {
            document.getElementById('<%=btnDayClose.ClientID%>').disabled = false;
        }        
    }
    
    function pageLoad()
    {
        $.tablesorter.addParser({
            id: "datetime",
            is: function(s) {
                return false; 
            },
            format: function(s,table) {
                s = s.replace(/\-/g,"/");
                s = s.replace(/(\d{1,2})[\/\-](\d{1,2})[\/\-](\d{4})/, "$3/$2/$1");
                return $.tablesorter.formatFloat(new Date(s).getTime());
            },
            type: "numeric"
        });
        

        $('#<%=Grid_Hierarchy.ClientID %>').tablesorter( 
        {
            dateFormat: 'dd-mm-yyyy', 
            headers: 
                {
                    3:{sorter:'datetime'},
                    2:{sorter:false}
                } 
        } );         
    }
	</script>
    <div id="right_data">
 <asp:UpdatePanel id="UpdatePanel1" runat="server">
    <contenttemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD align=left width="100%" colSpan=3><asp:RadioButtonList id="rblDistributorTypes" runat="server" Visible="False" Width="450px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblDistributorTypes_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="0">All</asp:ListItem>
<asp:ListItem Value="1">Active</asp:ListItem>
<asp:ListItem Value="2">In Active</asp:ListItem>
</asp:RadioButtonList> </TD></TR>
<TR>
<TD align=center colSpan=3>
<asp:GridView id="Grid_Hierarchy" runat="server" Width="100%" ForeColor="SteelBlue" HorizontalAlign="Center" CssClass="tablesorter" BorderColor="White" BackColor="White" AutoGenerateColumns="False">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                            PreviousPageText="Previous" />
                        <Columns>
                            <asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Location Name" >
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACT_PERSON" HeaderText="Contact Person" >
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number" >
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CLOSING_DATE" HeaderText="Last Day Close">
                                <ItemStyle ForeColor="Red" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TIME_STAMP" HeaderText="Date/Time of Closing">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="tblhead" />
                    </asp:GridView> 
<asp:Button id="btnDayClose" runat="server" Visible="False" Text="Day Close" OnClick="btnDayClose_Click" CssClass="Button" Width="90" /> </TD>
</TR>
<tr>
        <td align="center" colspan="3">
        
        <div style="z-index: 101; left: 555px; width: 100px; position: absolute; top: 175px;
        height: 100px">
        <asp:Panel ID="Panel1" runat="server">
                    <asp:UpdateProgress id="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        &nbsp;<asp:ImageButton ID="btnImage" runat="server" Height="33px" Width="31px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"/>
</ProgressTemplate>

                    </asp:UpdateProgress>
        </asp:Panel>
    </div>
            
         </td>
    </tr>
</TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</div>
</asp:Content>