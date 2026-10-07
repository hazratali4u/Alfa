<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptMonthlySaleAnalysis.aspx.cs" Inherits="Forms_RptMonthlySaleAnalysis" Title="SAMS: Monthly Sale Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="javascript" type="text/javascript">
    function onCalendarShown() {
   var cal = $find("calendar1");
   cal._switchMode("years", true); 
   if (cal._yearsBody) {
      for (var i = 0; i < cal._yearsBody.rows.length; i++) {
         var row = cal._yearsBody.rows[i];
         for (var j = 0; j < row.cells.length; j++) {
             Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
         }
        }
      }
   }

function onCalendarHidden() {
  var cal = $find("calendar1");
  if (cal._yearsBody) {
     for (var i = 0; i < cal._yearsBody.rows.length; i++) {
        var row = cal._yearsBody.rows[i];
        for (var j = 0; j < row.cells.length; j++) {
           Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
        }
     }
    }
}

function call(eventElement) {
   var target = eventElement.target;
   switch (target.mode) {
       case "year":
        var cal = $find("calendar1");
       cal.set_selectedDate(target.date);
       cal._blur.post(true);
       cal.raiseDateSelectionChanged(); break;
  }
}


function onCalendarShown2() {
   var cal = $find("calendar2");
   cal._switchMode("years", true); 
   if (cal._yearsBody) {
      for (var i = 0; i < cal._yearsBody.rows.length; i++) {
         var row = cal._yearsBody.rows[i];
         for (var j = 0; j < row.cells.length; j++) {
             Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call2);
         }
        }
      }
   }

function onCalendarHidden2() {
  var cal = $find("calendar2");
  if (cal._yearsBody) {
     for (var i = 0; i < cal._yearsBody.rows.length; i++) {
        var row = cal._yearsBody.rows[i];
        for (var j = 0; j < row.cells.length; j++) {
           Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call2);
        }
     }
    }
}

function call2(eventElement) {
   var target = eventElement.target;
   switch (target.mode) {
       case "year":
        var cal = $find("calendar2");
       cal.set_selectedDate(target.date);
       cal._blur.post(true);
       cal.raiseDateSelectionChanged(); break;
  }
}


function onCalendarShown3() {      
    var cal = $find("calendar3");
    cal._switchMode("months", true);
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call3);
            }
        }
    }
}

function onCalendarHidden3() {
    var cal = $find("calendar3");

    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call3);
            }
        }
    }
}

function call3(eventElement) {
    var target = eventElement.target;
    switch (target.mode) {
        case "month":
            var cal = $find("calendar3");
            cal._visibleDate = target.date;
            cal.set_selectedDate(target.date);
            cal._switchMonth(target.date);
            cal._blur.post(true);
            cal.raiseDateSelectionChanged();
            break;
    }
}


function onCalendarShown4() {      
    var cal = $find("calendar4");
    cal._switchMode("months", true);
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call4);
            }
        }
    }
}

function onCalendarHidden4() {
    var cal = $find("calendar4");

    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call4);
            }
        }
    }
}

function call4(eventElement) {
    var target = eventElement.target;
    switch (target.mode) {
        case "month":
            var cal = $find("calendar4");
            cal._visibleDate = target.date;
            cal.set_selectedDate(target.date);
            cal._switchMonth(target.date);
            cal._blur.post(true);
            cal.raiseDateSelectionChanged();
            break;
    }
}

    </script>
     <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{			
		return true;	  		
	}

    </script>
<div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD style="HEIGHT: 12px" align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD></TR><TR><TD align=left></TD><TD vAlign=top align=left>
<strong><asp:Label id="Label7" runat="server" Width="118px" Text="Rate Impelement" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="210px" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">Trade Price</asp:ListItem>
            <asp:ListItem>Purchase Price</asp:ListItem>
        </asp:RadioButtonList></TD></TR><TR><TD align=left></TD><TD align=left>
        <strong><asp:Label id="Label1" runat="server" Width="78px" Text="Report Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpReportType" runat="server" Width="200px" CssClass="DropList">
<asp:ListItem>Gross Sale </asp:ListItem>
<asp:ListItem>Sales Return </asp:ListItem>
<asp:ListItem>Purchase</asp:ListItem>
<asp:ListItem>Closing Credit </asp:ListItem>
<asp:ListItem>Credit Sale </asp:ListItem>
<asp:ListItem>Net Sale </asp:ListItem>
<asp:ListItem>Transfer In</asp:ListItem>
<asp:ListItem>Transfer Out</asp:ListItem>
<asp:ListItem>Closing Stock</asp:ListItem>
<asp:ListItem>Opening Stock</asp:ListItem>
<asp:ListItem>Extra Discount</asp:ListItem>
<asp:ListItem>Standard Discount</asp:ListItem>
<asp:ListItem>Purchase Return</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD align=left></TD><TD align=left>
<strong><asp:Label id="Label5" runat="server" Width="78px" Text="Value Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpUnitType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpUnitType_SelectedIndexChanged"><asp:ListItem Value="0">Year Wise</asp:ListItem>
<asp:ListItem Value="1">Month Wise</asp:ListItem>
<asp:ListItem Value="2">Date Wise</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
<strong><asp:Label id="Label2" runat="server" Width="78px" Text="Location Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><asp:DropDownList id="ddDistributorType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged">
            </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
            <strong><asp:Label id="lbltoLocation" runat="server" Width="66px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList">
    </asp:DropDownList></TD></TR><TR><TD align=left></TD><TD align=left>
    <strong><asp:Label id="Label6" runat="server" Width="78px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 68px" align=left colSpan=4><DIV id="divYear" class="divYear" runat="server"><TABLE width="100%"><TBODY><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
            <strong><asp:Label id="Label3" runat="server" Width="70px" Text="From Year" __designer:wfdid="w70"></asp:Label></strong></TD><TD style="WIDTH: 20px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px" align=left>&nbsp; <asp:TextBox id="txtStartYear" onkeyup="BlockStartDateKeyPress()" runat="server" Width="50px" CssClass="txtBox" __designer:wfdid="w65" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartYear" runat="server" Width="16px" __designer:wfdid="w66" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px">
            <strong><asp:Label id="Label4" runat="server" Width="80px" Text="To Year" __designer:wfdid="w71"></asp:Label></strong></TD><TD style="WIDTH: 10px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px">&nbsp; <asp:TextBox id="txtEndYear" onkeyup="BlockEndDateKeyPress()" runat="server" Width="50px" CssClass="txtBox " __designer:wfdid="w68" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnEndYear" runat="server" Width="16px" __designer:wfdid="w69" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR></TBODY></TABLE></DIV><DIV id="divDate" class="divDate" runat="server"><TABLE width="100%"><TBODY><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
            <strong><asp:Label id="lblFromDate" runat="server" Width="78px" Text="From Date"></asp:Label></strong></TD><TD style="WIDTH: 20px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px" align=left>&nbsp; <asp:TextBox id="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="100px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
            <strong><asp:Label id="lblToDate" runat="server" Width="78px" Text="To Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px">&nbsp; <asp:TextBox id="txtEndDate" onkeyup="BlockStartDateKeyPress()" runat="server" Width="100px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR></TBODY></TABLE></DIV><DIV id="divMonth" class="divMonth" runat="server"><TABLE width="100%"><TBODY><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
            <strong><asp:Label id="lblFromMonth" runat="server" Width="78px" Text="From Month" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 20px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px" align=left>&nbsp;<asp:TextBox id="txtFromMonth" onkeyup="BlockStartDateKeyPress()" runat="server" Width="70px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnStartMonth" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR><TR><TD style="PADDING-LEFT: 5px; WIDTH: 8px; HEIGHT: 25px">
            <strong><asp:Label id="lblToMonth" runat="server" Width="78px" Text="To Month" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px; HEIGHT: 25px"></TD><TD style="PADDING-LEFT: 7px; WIDTH: 204px; HEIGHT: 25px">&nbsp;<asp:TextBox id="txtToMonth" onkeyup="BlockStartDateKeyPress()" runat="server" Width="70px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ibtnEndMonth" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD align=left></TD><TD align=left></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 201px; HEIGHT: 25px" align=left><%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %><cc1:CalendarExtender id="CEStartYear" runat="server" BehaviorID="calendar1" OnClientShown="onCalendarShown" OnClientHidden="onCalendarHidden" Format="yyyy" PopupButtonID="ibtnStartYear" TargetControlID="txtStartYear"></cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndYear" runat="server" BehaviorID="calendar2" OnClientShown="onCalendarShown2" OnClientHidden="onCalendarHidden2" Format="yyyy" PopupButtonID="ibtnEndYear" TargetControlID="txtEndYear"></cc1:CalendarExtender> <cc1:CalendarExtender id="CEStartMonth" runat="server" __designer:wfdid="w62" BehaviorID="calendar3" OnClientShown="onCalendarShown3" OnClientHidden="onCalendarHidden3" Format="MMM-yyyy" PopupButtonID="ibtnStartMonth" TargetControlID="txtFromMonth"></cc1:CalendarExtender> <cc1:CalendarExtender id="CESEndMonth" runat="server" __designer:wfdid="w63" BehaviorID="calendar4" OnClientShown="onCalendarShown4" OnClientHidden="onCalendarHidden4" Format="MMM-yyyy" PopupButtonID="ibtnEndMonth" TargetControlID="txtToMonth"></cc1:CalendarExtender> <cc1:CalendarExtender id="CEStartDate" runat="server" __designer:wfdid="w78" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate" TargetControlID="txtStartDate"></cc1:CalendarExtender> <cc1:CalendarExtender id="CEEndDate" runat="server" __designer:wfdid="w79" Format="dd-MMM-yyyy" PopupButtonID="ibtnEndDate" TargetControlID="txtEndDate"></cc1:CalendarExtender> &nbsp;&nbsp;&nbsp; </TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
        <asp:Button ID="btnViewPDF" runat="server" CssClass="Button"
                Text="View PDF" OnClick="btnViewPDF_Click"/>
                    <asp:Button ID="btnViewExcel" runat="server" CssClass="Button"
                Text="View Excel" OnClick="btnViewExcel_Click" /></td>
            </tr>
        </table>
         &nbsp;
        
           </div>
</asp:Content>
