<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
<!--

#main {
	position:relative;
	width:565px;
}
#boxbody {
	float:left;
	width:565px;
	padding:69px 0px 130px 0px;
	margin-top:30px;
    margin-left:80px;
	background-image:url(images/login.png);
	background-repeat:no-repeat;
	background-position:top;
}
#boxbody div {
	margin:5px 0px 0px 32px;/*background-color:#CCC;*/
}
#boxbody div input {
	width:235px;
	padding:9px 5px;
	border:0px;
	background-color:transparent;
	font-weight:bold;/*background-color:#CCC;*/
}
#Products_select input {
	cursor:pointer;
}

#boxbody div input.tb_signin {
	width:100px;
	margin-left:144px;
	background-color:transparent;
	cursor:pointer;
	border:0px solid red;
}
-->
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpChild" Runat="Server">
<div id="right_data">
     <div runat="server" id="dvLicense" visible="false" style='padding: 10px; margin: 5px;
            background-color: #fbefef; border: Solid 1px #bb0000; color: #bb0000; font-size: 12px;
            font-family: Verdana; width: 70%'>
            <asp:Label ID="lblLicenseMsg" runat="server" Text=""></asp:Label>
        </div>
         <div runat="server" id="dvError" visible="false" style='padding: 10px; margin: 5px;
            background-color: #fbefef; border: Solid 1px #bb0000; color: #bb0000; font-size: 12px;
            font-family: Verdana; width: 70%'>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
   <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <div id="main">
  <div id="boxbody">
  <div id="Products_select" style="padding-bottom:17px;">Please enter login & password to proceed.</div>    
    <div>          
      <asp:TextBox ID="txtLogin" runat="server" Text="Login" onfocus="if(this.value=='Login'){this.value='';}" onblur="if(this.value=='' || this.value==null) this.value='Login'"></asp:TextBox>
    </div>
    <div>
      <asp:TextBox ID="txtPassword" runat="server" Text="........." TextMode="Password" onfocus="if(this.value=='.........'){this.value='';}" onblur="if(this.value=='' || this.value==null) this.value='.........'"></asp:TextBox>
    </div>
    <div>
      <asp:Button ID="btnSignIn" runat="server" CssClass="tb_signin" OnClick="btnSignIn_Click" />
    </div>
    <div><br /><br />
      *This is a secure server. Your activity will be monitored. </div>
  </div>
</div>
</div>
</asp:Content>

