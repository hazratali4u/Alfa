<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmLoadPassReturn.aspx.cs" Inherits="Forms_frmLoadPassReturn" Title="SAMS:Load Pass Return" %>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="cphPage">
<script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(startRequest);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
                function startRequest(sender, e) {
                        document.getElementById('<%=btnSaveOrder.ClientID%>').disabled = true;
            document.getElementById('<%=btnCalculate.ClientID%>').disabled = true;
                            }
        function endRequest(sender, e) {

            document.getElementById('<%=btnSaveOrder.ClientID%>').disabled = false;
            document.getElementById('<%=btnCalculate.ClientID%>').disabled = false;
        }

        function ValidateSaveOrder() {
            var str;
            str = document.getElementById('<%=txtNetAmount.ClientID%>').value;
            if (str == null || str.length == 0 || str < 0) {
                alert('Must Select SKU and Press Calculate');
                return false;
            }
            return true;

        }


        function ValidateForm() {
            
         
            return true;
        }

        function pageLoad() {

            $("select").searchable();
        }

        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }

    </script>
    <div id="right_data">
        <div>
            <span class="heading">Load Pass<br />
            </span>&nbsp;</div>
        <div>
            <table width="100%">
                <tr>
                    <td align="left">
                        
                        
                        <div style="z-index: 101; left: 612px; width: 100px; position: absolute; top: 369px;
                            height: 100px">
                            &nbsp;<asp:Panel ID="Panel21" runat="server">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                    <ProgressTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                            Width="31px" />
                                        Wait Update</ProgressTemplate>
                                </asp:UpdateProgress>
                            </asp:Panel>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="lblDocumentNo" runat="server" Width="94px" Text="Order No" CssClass="lblbox"
                                                        Visible="False"></asp:Label></strong>
                                            </td>
                                            <td style="width: 194px">
                                                <asp:DropDownList ID="drpDocumentNo" runat="server" runat="server" Width="180px"
                                                    CssClass="DropList" AutoPostBack="True" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                            </td>
                                            <td style="width: 194px">
                                                <asp:DropDownList ID="drpDistributor" runat="server" Width="180px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="height: 24px; width: 88px;">
                                                <strong>
                                                    <asp:Label ID="lblDeliveryMan" runat="server" Width="74px" Text="DeliveryMan" CssClass="lblbox"></asp:Label>
                                            </td>
                                            <td style="width: 194px">
                                                <strong>
                                                    <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="180px" CssClass="DropList"
                                                        OnSelectedIndexChanged="DrpDeliveryMan_SelectedIndexChanged" TabIndex="4">
                                                    </asp:DropDownList>
                                                </strong>
                                            </td>
                                            <td  align="left" style="height: 24px; width: 113px;">
                                                <strong>
                                                    <asp:Label ID="lblOpeningReading" runat="server" CssClass="lblbox" TabIndex="1" Text="Opening Reading"
                                                        Style="text-align: left"></asp:Label></strong>
                                            </td>
                                            <td valign="middle" align="left" style="width: 133px">
                                                </strong>
                                                <asp:TextBox ID="txtOpeningReading" runat="server" Width="178px" TabIndex="7"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblPrincipal" runat="server" Text="Principal"></asp:Label>
                                            </td>
                                            </strong>
                                            <td style="width: 194px; height: 25px" align="left">
                                                <asp:DropDownList ID="DrpPrincipal" runat="server" Width="180px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged"
                                                    __designer:wfdid="w2" TabIndex="1">
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="middle" align="left" style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblVisit" runat="server" Text="Visit" Width="74px"></asp:Label></strong>
                                            </td>
                                            <td style="width: 194px">
                                                </strong><asp:TextBox ID="txtVisit" runat="server" Width="178px" TabIndex="5"></asp:TextBox>
                                            </td>
                                            <td  align="left" style="width: 113px">
                                                <strong>
                                                    <asp:Label ID="lblCloseReading" runat="server" Text="Closing Reading"></asp:Label></strong>
                                            </td>
                                            <td style="width: 133px">
                                                <asp:TextBox ID="txtCloseReading" runat="server" Width="178px" TabIndex="8"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                                            </td>
                                            </strong>
                                            <td style="width: 194px; height: 25px" align="left">
                                                <asp:DropDownList ID="DrpRoute" runat="server" Width="180px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" TabIndex="2">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" valign="middle" style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblProductiveCall" runat="server" Text="Productive Call" Width="89px"></asp:Label>
                                            </td>
                                            </strong>
                                            <td style="width: 194px">
                                                <asp:TextBox ID="txtProductiveCall" runat="server" Width="178px" TabIndex="6"></asp:TextBox>
                                            </td>
                                            <td style="width: 113px">
                                                <strong>
                                                    <asp:Label ID="lblBillNoFrom" runat="server" Text="Bill # From" Width="74px"></asp:Label>
                                            </td>
                                            </strong>
                                            <td>
                                                <asp:TextBox ID="txtBillNoFrom" runat="server" Width="178px" TabIndex="9"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 88px">
                                                <strong>
                                                    <asp:Label ID="lblOrderBooker" runat="server" CssClass="lblbox" Text="Order Booker"
                                                        Width="101px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 194px; height: 25px" align="left">
                                                <asp:DropDownList ID="DrpOrderBooker" runat="server" Width="180px" CssClass="DropList"
                                                    OnSelectedIndexChanged="DrpOrderBooker_SelectedIndexChanged" TabIndex="3">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" style="height: 23px; width: 88px;">
                                            </td>
                                            <td align="left" style="height: 23px; width: 194px;">
                                                &nbsp;
                                            </td>
                                            <td  align="left" style="width: 113px">
                                                <strong>
                                                    <asp:Label ID="lblBillNoTo" runat="server" Text="Bill # To" Height="16px" Width="69px"></asp:Label>
                                            </td>
                                            </strong>
                                            <td>
                                                <asp:TextBox ID="txtBillNoTo" runat="server" Width="178px" TabIndex="10"></asp:TextBox>
                                            </td>
                                        </tr>
                                        </caption>
                                    </tbody>
                                </table>
                               
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </td>
                    <td >
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel5"  runat="server"  Width="989px">
                                   
                                  <table>
                                        <tr>
                                            <td align="left" colspan="8">
                                                <asp:Panel ID="Panel2" runat="server" Height="170px" ScrollBars="Auto" Width="950px"
                                                    BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px" >
                                                    <asp:GridView ID="GrdPurchase" runat="server" ForeColor="SteelBlue" CssClass="gridRow2"
                                                        BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White"
                                                       ShowHeader="true" RowStyle-BorderWidth="1px" Width="100%" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" >
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous"></PagerSettings>
                                                        <Columns>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="40px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="150px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PACKING" HeaderText="Packing">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="77px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNIT_PRICE" HeaderText="T.P" DataFormatString="{0:F4}">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="54px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ISSUE_CTN" HeaderText="ISSUE CTN">
                                                                <ItemStyle HorizontalAlign="left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="45px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ISSUE_UNITS" HeaderText="ISSUE UNITS">
                                                                <ItemStyle HorizontalAlign="left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="45px"></ItemStyle>
                                                            </asp:BoundField>
                                                              <asp:TemplateField HeaderText="RET. CTN">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtReturnCtn" runat="server" Text='<%# Eval("RETURN_CTN") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="RET. Units">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtReturnUnits" runat="server" Text='<%# Eval("RETURN_UNITS") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           
                                                            
                                                               <asp:TemplateField HeaderText="Gross Units">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtGrossUnits" runat="server" ReadOnly="true" Text='<%# Eval("GROSS_UNITS") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        
                                                            <asp:TemplateField HeaderText="S.Ret Units">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtDamageUnits" runat="server" Text='<%# Eval("DAMAGE_UNITS") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Damage Units">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActDamageUnits" runat="server" Text='<%# Eval("Actual_DAMAGE_UNITS") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            

                                                            <asp:TemplateField HeaderText="Sch. Units">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtSchemeUnits" runat="server" Text='<%# Eval("SCHEME_UNITS") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                             <asp:TemplateField HeaderText="N.Sale Ctn">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtNetSaleCtn" runat="server" ReadOnly="true" Text='<%# Eval("NET_SALE_CTN") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           

                                                             <asp:TemplateField HeaderText="N.Sale Units">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtNetSale" runat="server" ReadOnly="true" Text='<%# Eval("NET_SALE") %>' Width="45px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            

                                                             <asp:TemplateField HeaderText="Net Value">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtNetValue" runat="server" ReadOnly="true" Text='<%# Eval("NET_VALUE") %>' Width="60px" CssClass="txtBox" __designer:wfdid="w3"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="QUANTITY_CTN" HeaderText="QUANTITY_CTN">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="GST_RATE_TP" HeaderText="GST_RATE_TP">
                                                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                            </asp:BoundField>

                                                               <asp:BoundField DataField="UNITS_IN_CASE" HeaderText="UNITS_IN_CASE">
                                                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                            </asp:BoundField>
                                                            
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td colspan="8">
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 100px">
                        <asp:HiddenField ID="hfBillBookNo" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 116px">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Gross Weight"
                                                        Width="136px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumGrossWeight" runat="server" CssClass="txtBoxnNum" 
                                                    Font-Bold="True" ForeColor="Black" Width="150px" TabIndex="30"></asp:TextBox>
                                            </td>
                                            
                                            <td style="width: 18px"></td>
                                             <td align="left" style="height: 20px; width: 113px;">
                                                <strong>
                                                    <asp:Label ID="lblfromLocation1" runat="server" Width="94px" Text="Extra Discount"
                                                        CssClass="lblbox" Visible="False"></asp:Label>
                                                    <asp:Label ID="lblWholeSaleDiscount" runat="server" CssClass="lblbox" Text="WholeSale Discount"
                                                        Width="120px" Height="16px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px; height: 20px">
                                               <asp:TextBox ID="numtxtTotalExtraDiscnt" runat="server" Width="150px" ForeColor="Black"
                                                    Font-Bold="True" CssClass="txtBoxnNum" ReadOnly="True" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="txtWholeSaleDiscount" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" onblur="CalculateClaimableDiscount(event)" TabIndex="24"></asp:TextBox>
                                           

                                            </td>
                                            <td style="width: 26px"></td>
                                        <td style="width: 94px; height: 7px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label91" runat="server" Width="88px" Text="Net Amount" CssClass="lblbox"
                                                        Visible="False" Height="16px"></asp:Label>
                                                    <asp:Label ID="lblGSTAmount" runat="server" CssClass="lblbox" 
                                                    Text="GST Amount" Width="103px"
                                                        Font-Bold="True" Visible="true"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px; height: 7px" align="right">
                                                <asp:TextBox ID="numTxtTotlAmnt" runat="server" Width="150px" ForeColor="Black" Font-Bold="True"
                                                    CssClass="txtBoxnNum" ReadOnly="True" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="txtGSTAmount" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="29" ></asp:TextBox>
                                            </td>
                                        
                                        </tr>
                                        <tr>
                                            
                                       <td style="width: 116px">
                                                <strong>
                                                    <asp:Label ID="lblnumGrossSale" runat="server" CssClass="lblbox" Text="Gross Amount"
                                                        Width="136px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtnumGrossSale" runat="server" CssClass="txtBoxnNum" 
                                                    Font-Bold="True" ForeColor="Black" Width="150px" TabIndex="22"></asp:TextBox>
                                            </td>
                                            
                                            <td style="width: 18px"></td>
                                            <td align="left" style="width: 113px">
                                               <strong>
                                                    <asp:Label ID="Label51" runat="server" Width="110px" Text="Standard Discount" CssClass="lblbox"
                                                        Visible="False"></asp:Label>
                                                    <asp:Label ID="lblBRD" runat="server" CssClass="lblbox" Text="BRD" 
                                                    Width="107px" Height="16px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px">
                                                   <asp:TextBox ID="numTxtTotalStndrdDiscnt" runat="server" Width="150px" ForeColor="Black"
                                                    Font-Bold="True" CssClass="txtBoxnNum" ReadOnly="True" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="txtBRD" runat="server" CssClass="txtBoxnNum" Font-Bold="True" ForeColor="Black"
                                                    Width="150px" TabIndex="25"></asp:TextBox>
                                                </td><td style="width: 26px"></td>
                                            <td style="width: 94px">
                                                <strong>
                                                    <asp:Label ID="lblTSTAmount" runat="server" CssClass="lblbox" 
                                                    Text="TST Amount" Width="103px"
                                                        Font-Bold="True" Visible="true"></asp:Label> <br />
                                                   
                                                </strong>
                                            </td>
                                            
                                            <td>
                                                <asp:TextBox ID="txtTSTAmount" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="30" Visible="true" ></asp:TextBox>
                                             
                                            </td>
                                        
                                        </tr>
                                        <tr>
                                        <td style="width: 116px">
                                                <strong>
                                                    <asp:Label ID="lblTotalDamage" runat="server" CssClass="lblbox" Text="S.Return Amount"
                                                        Width="136px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDamageValue" runat="server" CssClass="txtBoxnNum" 
                                                    Font-Bold="True" ForeColor="Black" Width="150px" TabIndex="30"></asp:TextBox>
                                            </td>
                                            
                                            <td style="width: 18px"></td>
                                            <td style="height: 18px; width: 113px;" align="left">
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Width="113px" 
                                                    Text="Claimable  Discount" CssClass="lblbox"
                                                        Visible="False" Height="16px"></asp:Label>
                                                    <asp:Label ID="lblTradeOffer" runat="server" CssClass="lblbox" Text="Trade Offers"
                                                        Width="88px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px; height: 18px">
                                              <asp:TextBox ID="numtxtUnClaimabledist" runat="server" Width="150px" ForeColor="Black"
                                                    Font-Bold="True" CssClass="txtBoxnNum" ReadOnly="True" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="txtTradeOffers" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="26"></asp:TextBox>
                                            </td>
                                            <td style="width: 26px"></td><td style="width: 94px"> <strong >
                                        <asp:Label ID="lblVanFuel" runat="server" CssClass="lblbox" Font-Bold="True" Text="Fuel "
                                                        Width="103px"></asp:Label></strong></td>
                                        <td>   <asp:TextBox ID="txtFuel" runat="server" CssClass="txtBoxnNum" Font-Bold="True" ForeColor="Black"
                                                    TabIndex="30" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                       <td style="width: 116px"><strong>
                                                <asp:Label ID="Label11" runat="server" CssClass="lblbox" Text="Damage Amount"
                                                        Width="136px"></asp:Label> </strong>
                                            </td>
                                            <td><asp:TextBox ID="txtTotalActualDamageValue" runat="server" CssClass="txtBoxnNum" 
                                                    Font-Bold="True" ForeColor="Black" Width="150px" TabIndex="30"></asp:TextBox></td>
                                               
                                        <td style="width: 18px"></td>
                                            <td style="width: 113px; height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label81" runat="server" Width="93px" Text="GST Amount" CssClass="lblbox"
                                                     Visible="false"  ></asp:Label>
                                                    <asp:Label ID="lblOtherDiscounts" runat="server" CssClass="lblbox" Text="Other Discounts"
                                                        Width="107px" Height="17px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px; height: 20px" align="right">
                                                  <asp:TextBox ID="numTxtTotalGST" runat="server" Width="150px" ForeColor="Black" Font-Bold="True"
                                                    CssClass="txtBoxnNum" ReadOnly="True" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtOtherDiscounts" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="27"></asp:TextBox>
                                            </td>
                                            <td style="width: 26px"></td>
                                             <td style="width: 94px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Width="105px" Text="Cash Received" CssClass="lblbox"
                                                        Visible="False"></asp:Label>
                                                    <asp:Label ID="lblNetAmount" runat="server" CssClass="lblbox" 
                                                     Font-Bold="True" Text="Net Amount"
                                                        Width="101px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px" align="right">
                                                <asp:TextBox ID="txtCashReceived" runat="server" Width="150px" ForeColor="Black"
                                                    Font-Bold="True" CssClass="txtBoxnNum" Enabled="False" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="txtNetAmount" runat="server" CssClass="txtBoxnNum" 
                                                    Font-Bold="True" ForeColor="Black" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td style="width: 116px"><strong>
                                                    <asp:Label ID="lblTotalSchemeValue" runat="server" CssClass="lblbox" Text="Scheme Amount"
                                                        Width="136px"></asp:Label>
                                                </strong>
                                        </td>
                                        <td> <asp:TextBox ID="txtTotalSchemeValue" runat="server" CssClass="txtBoxnNum" 
                                                    Font-Bold="True" ForeColor="Black" Width="150px" TabIndex="30"></asp:TextBox>
                                            </td>
                                        <td style="width: 18px"></td>
                                            <td style="width: 113px; height: 20px" align="left">
                                                <strong>
                                                   
                                                    <asp:Label ID="Label15" runat="server" CssClass="lblbox" Text="Incentive"
                                                        Width="107px" Height="17px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px; height: 20px" align="right">
                                                  <asp:TextBox ID="txtIncentive" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="28"></asp:TextBox>
                                          
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 116px; height: 20px" valign="top">
                                                <strong>
                                                    <asp:Label ID="Label17" runat="server" CssClass="lblbox" Text="Unclaimable Discount"
                                                        Width="136px"></asp:Label>
                                                </strong> 
                                            </td>
                                            <td>  <asp:TextBox ID="txtGrossAmount" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" ReadOnly="True" Visible="False" Width="150px"></asp:TextBox>
                                                <asp:TextBox ID="txtUnclaimAbleDiscount" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="23"></asp:TextBox></td>
                                            <td style="width: 18px"></td>
                                            <td style="width: 113px; height: 20px" align="left">
                                                <strong>
                                                   
                                                    <asp:Label ID="Label12" runat="server" CssClass="lblbox" Text="Rental"
                                                        Width="107px" Height="17px"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 7px; height: 20px" align="right">
                                                  <asp:TextBox ID="txtRental" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="28"></asp:TextBox>
                                           
                                                 </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td>  <strong>
                                                   
                                                    <asp:Label ID="Label16" runat="server" CssClass="lblbox" Text="Display"
                                                        Width="107px" Height="17px"></asp:Label>
                                                </strong></td>
                                            <td>  <asp:TextBox ID="txtDisplay" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="28"></asp:TextBox>
                                           </td>


                                        </tr>
                                        <tr>
                                            <td style="width: 116px; height: 7px" valign="top">
                                           
                                                 </td>
                                            <td></td>
                                            <td></td>
                                            <td> <strong>
                                                    <asp:Label ID="Label9" runat="server" Width="93px" Text="TST Amount" CssClass="lblbox"
                                                 Visible="false"       ></asp:Label>
                                                    <asp:Label ID="lblClaimAbleDiscount" runat="server" CssClass="lblbox" Text="Claimble Discounts"
                                                        Width="116px" Font-Bold="True"></asp:Label>
                                                </strong></td>
                                            <td>   <asp:TextBox ID="numTxtTotalTST" runat="server" Width="150px" ForeColor="Black" Font-Bold="True"
                                                    CssClass="txtBoxnNum" ReadOnly="True" Visible ="false"  ></asp:TextBox>
                                                <asp:TextBox ID="txtClaimableDiscounts" runat="server" CssClass="txtBoxnNum" Font-Bold="True"
                                                    ForeColor="Black" Width="150px" TabIndex="28"></asp:TextBox>
                                       </td>
                                            <td></td>
                                            </tr>
                                        <tr>
                                            <td colspan="3">
                                            </td>
                                            </tr>
                                        <tr>
                                        <td colspan ="3"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="5">
                                                <table>
                                                    <tbody>
                                                        <tr><td></td>
                                                            <td style="width: 100px">
                                                                <asp:Button AccessKey="C" ID="btnCalculate" TabIndex="31" runat="server" Width="100px"
                                                                    Font-Size="8pt" Text="Calculate" Enabled="False" CssClass="Button" OnClick="btnCalculate_Click" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <asp:Button AccessKey="S" ID="btnSaveOrder" TabIndex="32" runat="server" Width="110px"
                                                                    Font-Size="8pt" Text="Save" CssClass="Button" 
                                                                    OnClick="btnSaveOrder_Click" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <asp:Button AccessKey="H" ID="btnCancel" TabIndex="33" runat="server" Width="110px"
                                                                    Font-Size="8pt" Text="Home" CssClass="Button" Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                           
                                           
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="numTxtTotalSED" runat="server" CssClass="txtBox " Font-Bold="False"
                            ForeColor="Black" Width="139px" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
