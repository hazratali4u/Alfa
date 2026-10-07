<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmLeaveSignature.aspx.cs" Inherits="Forms_frmLeaveSignature" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainCopy">
    <div class="container" style="background-color: white">
    
        <h2>
            &nbsp; Leave Cancel</h2>
    </div>
    <script language="JavaScript" type="text/javascript">
        
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest( startRequest );

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest( endRequest );

        function startRequest( sender, e )
        { 
            
            document.getElementById('<%=btnSave.ClientID%>').disabled = true;
            document.getElementById('<%=BtnClear.ClientID%>').disabled = true;
            

        }

        function endRequest( sender, e ) 
        { 
           
            document.getElementById('<%=btnSave.ClientID%>').disabled = false;
            document.getElementById('<%=BtnClear.ClientID%>').disabled = false;
            
        }
    </script>    
    <div class="container">
        <table width="100%">
            <tr>
                <td style="width: 100px;">
                </td>
                <td align="center" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table style="width: 43%">
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label1" runat="server" Text="Location" Width="87px"></asp:Label>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpLocation" runat="server" CssClass="DropList" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label2" runat="server" Text="Designation" Width="90px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpDesignation" runat="server" AutoPostBack="True" CssClass="DropList"
                                            OnSelectedIndexChanged="DrpDesignation_SelectedIndexChanged" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label6" runat="server" Text="Employee Name" Width="114px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpEmployee" runat="server" AutoPostBack="True" CausesValidation="True"
                                            CssClass="DropList" OnSelectedIndexChanged="DrpEmployee_SelectedIndexChanged"
                                            Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label5" runat="server" Text="Type" Width="114px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">Allow</asp:ListItem>
                                            <asp:ListItem>Avail</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="90px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtBox" onkeyup="BlockFromDateKeyPress()"
                                            Style="text-align: justify" Width="130px"></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="ImgBntFromCalc" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Granite/Images/date.gif" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="90px"></asp:Label></td>
                                    <td align="left" style="height: 25px">
                                        <asp:TextBox ID="txttoDate" runat="server" CssClass="txtBox" onkeyup="BlocktoDateKeyPress()"
                                            Style="text-align: justify" Width="130px"></asp:TextBox>&nbsp; <asp:ImageButton
                                                ID="btnToDate" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Granite/Images/date.gif" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px">
                                        <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="View"
                                            Width="108px" /></td>
                                    <td align="left" style="height: 25px">
                                        <asp:Button ID="BtnClear" runat="server" Font-Size="8pt" OnClick="BtnClear_Click"
                                            Text="Cancel" Width="109px" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 25px" colspan="2">
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" EnableViewState="False"
                                            Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromdate">
                                        </cc1:CalendarExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" EnableViewState="False"
                                            Format="dd-MMM-yyyy" PopupButtonID="btnToDate" TargetControlID="txttoDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
        </table>
        
           </div>
    <div class="container"><table width="100%">
        <tr>
            <td style="width: 100px; height: 173px;">
            </td>
            <td align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                <asp:Panel ID="Panel12" runat="server" Height="136px" ScrollBars="Vertical" Width="651px" BorderColor="Gray" BorderStyle="Groove" BorderWidth="1px">
                                    <asp:GridView ID="GrdLedger" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                        Width="100%">
                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                            PreviousPageText="Previous" />
                                        <RowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="EMPLOYEE_LEAVE_ID" HeaderText="EMPLOYEE_LEAVE_ID">
                                                <HeaderStyle CssClass="HidePanel" />
                                                <ItemStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Check">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChbSelect" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SLASH_DESC" HeaderText="Leave Type">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FROM_DATE" HeaderText="From Date">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TO_DATE" HeaderText="To Date">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USED_DAYS" HeaderText="Days">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" />
                                        <PagerStyle BackColor="Transparent" />
                                        <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                            VerticalAlign="Middle" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                    </asp:GridView>
                                </asp:Panel>
                &nbsp; &nbsp; &nbsp;
                                
            </ContentTemplate>
        </asp:UpdatePanel>
        
             </td>
            <td style="width: 100px; height: 173px;">
            </td>
        </tr>
    </table>
    </div>
    
   
</asp:Content>