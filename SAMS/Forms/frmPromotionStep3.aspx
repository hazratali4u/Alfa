<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmPromotionStep3.aspx.cs" inherits="Forms_frmPromotionStep3" title="SAMS: Promotion Wizard Step 2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    
    <div id="right_data">
        <table width="100%">
        <tr>
            <td>
            <h2>Promotion Wizard Step 2</h2>
            </td>
        </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 16px" align=left></TD><TD align=left colSpan=5>
<asp:Label id="lblErrorMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 22px"></TD></TR><TR><TD style="WIDTH: 16px; HEIGHT: 20px"></TD><TD style="HEIGHT: 20px" colSpan=2>
<strong> <asp:Label id="Label1" runat="server" Width="96px" Text="Location Type" CssClass="lblbox"></asp:Label></strong> <asp:CheckBox id="ChbAllLocationType" runat="server" Text="All Type Location" AutoPostBack="True" OnCheckedChanged="ChbAllLocationType_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 30px; HEIGHT: 20px"></TD><TD style="HEIGHT: 20px" colSpan=2>&nbsp;
<strong><asp:Label id="Label5" runat="server" Width="96px" Text="Location" CssClass="lblbox"></asp:Label></strong> <asp:CheckBox id="chkSelectAllDistributors" runat="server" Text="All Location" AutoPostBack="True" OnCheckedChanged="chkSelectAllDistributors_CheckedChanged"></asp:CheckBox></TD></TR><TR><TD colSpan=1></TD><TD style="HEIGHT: 126px" colSpan=2><asp:Panel id="Panel1" runat="server" Width="295px" Height="150px" ScrollBars="Vertical" BorderStyle="Groove" BorderWidth="1px"><asp:CheckBoxList id="ChbDistributorType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ChbDistributorType_SelectedIndexChanged"></asp:CheckBoxList></asp:Panel></TD><TD style="WIDTH: 30px"></TD><TD colSpan=2><asp:Panel id="Panel6" runat="server" Width="300px" Height="150px" ScrollBars="Vertical" BorderStyle="Groove" BorderWidth="1px"><asp:CheckBoxList id="chklDistributors" runat="server" CssClass="lblbox"></asp:CheckBoxList></asp:Panel></TD></TR><TR><TD style="HEIGHT: 16px" colSpan=1></TD><TD style="HEIGHT: 16px" colSpan=2>
<strong><asp:Label id="Label3" runat="server" Width="96px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong> <asp:CheckBox id="chkSelectAllCustomerType" runat="server" Text="All Channel Type" CssClass="lblbox" AutoPostBack="True" OnCheckedChanged="chkSelectAllCustomerType_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 30px; HEIGHT: 16px"></TD><TD style="HEIGHT: 16px" colSpan=2>
<strong><asp:Label id="Label6" runat="server" Width="96px" Text="Volume Class" CssClass="lblbox"></asp:Label></strong> <asp:CheckBox id="ChbAllVolumeClass" runat="server" Text="All Volume Class" CssClass="lblbox" AutoPostBack="True" OnCheckedChanged="ChbAllVolumeClass_CheckedChanged"></asp:CheckBox></TD></TR><TR><TD colSpan=1></TD><TD style="HEIGHT: 126px" colSpan=2><asp:Panel id="Panel5" runat="server" Width="295px" Height="150px" ScrollBars="Vertical" BorderStyle="Groove" BorderWidth="1px"><asp:CheckBoxList id="chklCustomerType" runat="server"></asp:CheckBoxList></asp:Panel></TD><TD style="WIDTH: 30px"></TD><TD colSpan=2><asp:Panel id="Panel8" runat="server" Width="300px" Height="150px" ScrollBars="Vertical" BorderStyle="Groove" BorderWidth="1px"><asp:CheckBoxList id="ChbVolumClass" runat="server"></asp:CheckBoxList></asp:Panel></TD></TR><TR><TD style="WIDTH: 16px"></TD><TD style="WIDTH: 170px"><asp:RadioButton id="rBtnBasketPromotion" runat="server" Width="121px" Font-Size="8pt" Text="Basket Promotion" AutoPostBack="True" Visible="False"></asp:RadioButton><BR /><asp:RadioButton id="rBtnSlabPromotion" runat="server" Width="114px" Font-Size="8pt" Text="Slab Promotion" AutoPostBack="True" Checked="True"></asp:RadioButton></TD><TD></TD><TD style="WIDTH: 30px"></TD><TD></TD><TD></TD></TR></TBODY></TABLE><DIV>&nbsp;&nbsp;&nbsp;
<asp:Button id="btnCancel" onclick="btnCancel_Click" runat="server" Width="90px" Text="Cancel" ValidationGroup="vg" CausesValidation="False" CssClass="Button" /> &nbsp;
<asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="90" Text="Back" ValidationGroup="vg" CssClass="Button" /> 
<asp:Button id="btnNext" onclick="btnNext_Click" runat="server" Width="90" Text="Next" ValidationGroup="vg" CssClass="Button" />
</DIV>
</contenttemplate>
                </asp:UpdatePanel>
                 </td>
            </tr>
        </table>
    </div>
</asp:Content>
