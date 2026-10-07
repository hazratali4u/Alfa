<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptVolumeSale.aspx.cs" Inherits="Forms_RptVolumeSale"
    MasterPageFile="~/Forms/PageMaster.master" Title="SAMS: Target Vs Achievement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="javascript" type="text/javascript">

        function onCalendarShown() {
            var cal = $find("calendar1");     //Setting the default mode to month   
            cal._switchMode("months", true);          //Iterate every month Item and attach click event to it   
            if (cal._monthsBody) {
                for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                    var row = cal._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }

        function onCalendarHidden() {
            var cal = $find("calendar1");
            //Iterate every month Item and remove click event from it
            if (cal._monthsBody) {
                for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                    var row = cal._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }

        function call(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "month":
                    var cal = $find("calendar1");
                    cal._visibleDate = target.date;
                    cal.set_selectedDate(target.date);
                    cal._switchMonth(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged();
                    break;
            }
        }
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                 
                                 <tr>
                                        <td>
                                          
                                        </td>
                                        <td>
                                              <strong>
                                                <asp:Label ID="Label4" runat="server" CssClass="lblbox" Height="14px" Text="Report Type"
                                                    Width="98px"></asp:Label></strong>
                                        </td>
                                       
                                        <td>
                                        
                                        </td>
                                        <td >
                                               <asp:RadioButtonList ID="RdoTargetType" runat="server" Width="228px" Height="1px"
                                                RepeatDirection="Horizontal" AutoPostBack="true"> 
                                                <asp:ListItem Selected="True" Value="1">Value Wise</asp:ListItem>
                                                <asp:ListItem Value="2">Sku Wise</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td >
                                           
                                        </td>
                                    </tr>
                                 


                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 92px" align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="65px" Text="Region" Enabled="False"
                                                    CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpRegion" runat="server" Width="200px" Enabled="False" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 92px" align="left">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpLocation" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 92px" align="left">
                                            <strong>
                                                <asp:Label ID="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left">
                                        </td>
                                        <td style="width: 92px; height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="48px" Text="Month" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:TextBox ID="txtDate" runat="server" Width="70px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MMM-yyyy" EnableViewState="False"
                                PopupButtonID="ImgBntFromCalc" TargetControlID="txtdate" OnClientHidden="onCalendarHidden"
                                OnClientShown="onCalendarShown" BehaviorID="calendar1">
                            </cc1:CalendarExtender>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" Width="90" Text="View PDF"
                        OnClick="btnViewPDF_Click" />
                    <asp:Button ID="btnViewExcel" runat="server" Width="90" OnClick="btnViewExcel_Click"
                        Text="View Excel" CssClass="Button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
