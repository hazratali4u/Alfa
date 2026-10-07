<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="RptLoadPassEntry.aspx.cs" Inherits="Forms_Default2" %><%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="4">
                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                   <tr>
                                            <td align="left" style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 248px">
                                                <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True" 
                                                    onselectedindexchanged="drpDistributor_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="height: 24px; width: 88px;">
                                                <strong>
                                                <asp:Label ID="lblOrderBooker" runat="server" CssClass="lblbox" 
                                                    Text="Order Booker" Width="101px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DrpOrderBooker" runat="server" CssClass="DropList" 
                                                    TabIndex="3" 
                                                    Width="200px" onselectedindexchanged="DrpOrderBooker_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                           
                                            
                                        </tr>
                                        <tr>
                                            <td style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblPrincipal" runat="server" Text="Principal"></asp:Label>
                                            </td>
                                            </strong>
                                            <td style="width: 248px; height: 25px" align="left">
                                                <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True" designer:wfdid="w2" TabIndex="1" 
                                                    onselectedindexchanged="DrpPrincipal_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            
                                            <td>  <strong>
                                                <asp:Label ID="lblDeliveryMan" runat="server" CssClass="lblbox" 
                                                    Text="DeliveryMan" Width="74px"></asp:Label>
                                                </strong>  </td>
                                            <td>  <strong>
                                                <asp:DropDownList ID="DrpDeliveryMan" runat="server" CssClass="DropList" 
                                                    TabIndex="4" 
                                                    Width="200px" onselectedindexchanged="DrpDeliveryMan_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                </strong>  </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                                            </td>
                                            </strong>
                                            <td style="width: 248px; height: 25px" align="left">
                                                <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True"  
                                                    TabIndex="2" onselectedindexchanged="DrpRoute_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                          <td> <strong>
                                              <asp:Label ID="Label6" runat="server" Height="13px" Text="From Date" 
                                                  Width="70px"></asp:Label>
                                              </strong> </td>
                                          <td> 
                                              <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" MaxLength="10" 
                                                   Width="150px"></asp:TextBox>
                                              <asp:ImageButton ID="ImgBntFromCalc" runat="server" 
                                                  ImageUrl="~/App_Themes/Granite/Images/date.gif" Width="16px" />
                                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate">
                            </cc1:CalendarExtender>
                                            </td>
                                           
                                            
                                        </tr>
                                        <tr>
                                            <td style="width: 88px">
                                                &nbsp;</td>
                                            <td style="width: 248px; height: 25px" align="left">
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                            <td></td>
                                            
                                           
                                        </tr>
                                 
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
                    <asp:Button ID="btnViewPDF" runat="server" CssClass="Button" Width="90" 
                        Text="View PDF" onclick="btnViewPDF_Click"
                         />
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button" Width="90" 
                        Text="View Excel" onclick="btnViewExcel_Click"
                        />
                </td>
            </tr>
        </table>
        &nbsp;
    </div>
</asp:Content>
