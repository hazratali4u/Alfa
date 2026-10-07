<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptDamageReport.aspx.cs" Inherits="Forms_RptDamageReport" Title="SAMS: Damage Detail Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
  <%@register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
      
    <script language="JavaScript" type="text/javascript">
        function ChbDamageTypeSelect() {
            var chkBoxList = document.getElementById('<%= ChbDamageList.ClientID %>');
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            var chkBoxCount;
            var i;
            if (chkBox.checked == true) {
                chkBoxCount = chkBoxList.getElementsByTagName("input");
                for (i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = true;
                }
            }
            else {
                chkBoxCount = chkBoxList.getElementsByTagName("input");
                for (i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = false;
                }
            }

        }

        function UnCheckAll() {
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            var chkBoxList = document.getElementById('<%= ChbDamageList.ClientID %>');
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            var count = 0;
            for (var i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].checked == false) {
                    count += 1;
                }
            }
            if (count > 0) {
                chkBox.checked = false;
            }
            else {
                chkBox.checked = true;
            }
        }

       

       
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td align="left" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                       
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Height="14px" Text="Rate Impelement" Width="98px"></asp:Label></strong>
                                    </td>
                                  
                                    <td align="left" style="height: 25px">
                                        <asp:RadioButtonList ID="rblRate" runat="server" Width="200px" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True">Trade Price</asp:ListItem>
                                            <asp:ListItem Value="1">Purchase Price</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                              

                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="67px" Text="Locaton" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 10px">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="230px" CssClass="DropList"
                                                AutoPostBack="True" 
                                                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" Height="16px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" Width="81px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 9px">
                                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="230px" CssClass="DropList"
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                
                                    
                                 
                            
                                <tr> 
                                    <td style="width: 100px" rowspan="1" align="left">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Width="114px" Text="Damage Type" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td align="left" rowspan="1" style="width: 100px">
                                        <asp:CheckBox ID="ChbSelectAll" runat="server" CssClass="DropList" Font-Size="8pt"
                                            onclick="ChbDamageTypeSelect()" Text="Select All" Width="75px" />
                                    </td>
                                    
                                   
                                </tr>
                             
                                <tr> <td></td>
                                    <td  align="left">
                                        <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="80px" ScrollBars="Vertical" Width="230px" BackColor="White">
                                            <asp:CheckBoxList ID="ChbDamageList" runat="server" onclick="UnCheckAll()">
                                                
                                            </asp:CheckBoxList>

                                        </asp:Panel>
                                    </td>
                                   
                                 
                                </tr>
                                <tr>
                                        
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="75px" Height="13px" Text="From Date"></asp:Label></strong>
                                        </td>
                                     
                                        <td style="width: 258px; height: 25px" align="left">
                                            <asp:TextBox ID="txtStartDate"  runat="server"
                                                Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong>
                                        </td>
                                        
                                        <td style="width: 258px; height: 25px" align="left">
                                            <asp:TextBox ID="txtEndDate"  runat="server"
                                                Width="150px" CssClass="txtBox " MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                         <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                                            TargetControlID="txtStartDate">
                                        </cc1:CalendarExtender>
                                        <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                                            TargetControlID="txtEndDate">
                                        </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                
                                <tr>
                                    <td></td>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                          
                                        </td>
                                    </tr>
                                </tr>
                            </table>
                        </ContentTemplate>
                      </asp:UpdatePanel>
                    <table>
                        <tr><td style="width: 58px; height: 25px" align="left"></td><td>                  <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" 
                                                OnClick="btnViewPDF_Click" Text="View PDF" Width="90" />
                                            <asp:Button ID="btnViewExcel" runat="server" CssClass="Button" 
                                                OnClick="btnViewExcel_Click" Text="View Excel" Width="90" />
                                    
              </td></tr> </table>
   </td>
            </tr>
        </table>
    </div>

</asp:Content>
