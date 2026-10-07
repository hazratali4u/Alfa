<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSaleForceAreaAssignment.aspx.cs" Inherits="Forms_frmSaleForceAreaAssignment"
    Title="SAMS: Sale Force Assignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">
        function ChRouteListSelect() {
            var chkBoxList = document.getElementById('<%= ChbAreaList.ClientID %>');
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            if (chkBox.checked == true) {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = true;
                }
            }
            else {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = false;
                }
            }

        }

        function UnCheckRouteAll() {
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            var chkBoxList = document.getElementById('<%= ChbAreaList.ClientID %>');
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

        function ChPrincipalListSelect() {
            var chkBoxList = document.getElementById('<%= ChbPrincipal.ClientID %>');
            var chkBox = document.getElementById('<%= ChPrincipal.ClientID %>');
            if (chkBox.checked == true) {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = true;
                }
            }
            else {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = false;
                }
            }
        }

        function UnCheckPrincipalAll() {
            var chkBox = document.getElementById('<%= ChPrincipal.ClientID %>');
            var chkBoxList = document.getElementById('<%= ChbPrincipal.ClientID %>');
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
                                        <td colspan="2">
                                            <asp:Label ID="lblmsg" runat="server" Visible="False" Width="175px" ForeColor="Red"></asp:Label>&nbsp;
                                        </td>
                                        <td style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="67px" Text="Locaton" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 10px">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" Width="81px" Text="Designation" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 9px">
                                            <asp:DropDownList ID="DrpDesignation" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpDesignation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="83px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 13px">
                                            <asp:DropDownList ID="DrpSaleForce" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpSaleForce_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Save"
                                                ValidationGroup="vg" Width="82px" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td style="width: 100px" rowspan="1" align="left">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Width="114px" Text="Route List" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="width: 102px" valign="bottom" align="center">
                                    </td>
                                    <td style="width: 102px" rowspan="1" align="left">
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" Text="Principal List"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" rowspan="1" style="width: 100px">
                                        <asp:CheckBox ID="ChbSelectAll" runat="server" CssClass="DropList" Font-Size="8pt"
                                            onclick="ChRouteListSelect()" Text="Select All" Width="75px" OnCheckedChanged="ChbSelectAll_CheckedChanged" />
                                    </td>
                                    <td align="center" style="width: 102px" valign="bottom">
                                    </td>
                                    <td align="left" rowspan="1" style="width: 102px">
                                        <asp:CheckBox ID="ChPrincipal" runat="server" Font-Size="8pt" onclick="ChPrincipalListSelect()"
                                            Text="Select All" Width="75px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="4" align="left">
                                        <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="200px" ScrollBars="Vertical" Width="200px" BackColor="White">
                                            <asp:CheckBoxList ID="ChbAreaList" runat="server" onclick="UnCheckRouteAll()" 
                                                >
                                            </asp:CheckBoxList>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 102px" valign="middle" align="center">
                                    </td>
                                    <td rowspan="4" align="left">
                                        <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="200px" ScrollBars="Vertical" Width="200px" BackColor="White">
                                            <asp:CheckBoxList ID="ChbPrincipal" runat="server" onclick="UnCheckPrincipalAll();">
                                            </asp:CheckBoxList>
                                            <div style="z-index: 101; left: -97px; width: 100px; position: absolute; top: 216px;
                                                height: 100px">
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 102px" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 102px" align="center">
                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 102px" valign="middle" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
