<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" inherits="Login, App_Web_login-.aspx.cdcab7d2" %>
<%@ OutputCache NoStore="true" Location="None" VaryByParam="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	  <title>Nijeria</title>
</head>

<body>
<form id="Form1" runat="server">
   <div class="wraper_lgn">
     <div class="header_tp">
		<div class="emblem_icon">
					<a href="#"><img src="./images/emblem.jpg" alt="emblem"/></a>
		</div>
				<div class="nijeria_hdng">
					<img src="./images/nijeria_hdng.png" alt="nijeria hdng"/>
				</div>
				<div class="flag_icon">
					<a href="#"><img src="./images/flag.jpg" alt="flag"/></a>
				</div>
	</div>
	<%--<div id="login">--%>
	   
	<div class="loginbx">	
	  <div class="lgn_tptxt">
					<div class="lg_hdng">
						User Login
					</div>
					<div class="lg_help">
						<a href="FrmHelpText.aspx" target="_blank">Help</a>
					</div>
				</div>
				<div class="lgn_tptxt" style="margin-top:20px;">
					<div class="lg_id">
						<label>Login ID</label>
						<%--<input type="text" value=""/>--%>
						<asp:TextBox ID="UserName" Autocomplete="off" runat="server"  CssClass="txtBoxstl"></asp:TextBox>
						<%--<asp:RequiredFieldValidator ID="RfvLoginID" runat="server" ErrorMessage="Please enter Login ID....." ControlToValidate="UserName" validationgroup="login" setfocusonerror="True">*</asp:RequiredFieldValidator>--%>
					</div>
				</div>
				<div class="lgn_tptxt" style="margin-top:15px;">
					<div class="lg_id">
						<label>Password</label>
						<%--<input style="margin-left:10px;" type="text" value=""/>--%>
						<asp:TextBox ID="Password" Autocomplete="off" runat="server" CssClass="txtBoxstl" TextMode="Password"></asp:TextBox>
						<%--<asp:RequiredFieldValidator ID="RfvPassword" runat="server"  ErrorMessage="Please enter Password....!" ControlToValidate="Password" validationgroup="login" setfocusonerror="True">*</asp:RequiredFieldValidator>--%>
					</div>
				</div>
				<div class="lgn_tptxt" style="margin-top:15px;">
						<%--<input type="button" value="Login"/>--%>
						<asp:Button ID="BtnLogin" runat="server" CssClass="Btnstl" Text="Login" onclick="BtnLogin_Click" validationgroup="login" />
						
				</div>
				<asp:RequiredFieldValidator ID="RfvLoginID" runat="server" ErrorMessage="Please enter Login ID....." ControlToValidate="UserName" validationgroup="login" setfocusonerror="True" Display="None">*</asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="RfvPassword" runat="server"  ErrorMessage="Please enter Password....!" ControlToValidate="Password" validationgroup="login" setfocusonerror="True" Display="None">*</asp:RequiredFieldValidator>
				<div class="lgn_tptxt" style="margin-top:10px;">
					<div class="lg_link" style="margin-left:10px;">
					<!--	<a href="FrmGuestLogin.aspx">Guest Login</a>-->
					</div>
					<div class="lg_link" style="margin-left:70px !important; ">
						<a href="Admin/FrmNewUsersRegistration.aspx">Create User</a>
						<span style=" margin-left:30px;"><a href="FrmRecoverLoginid.aspx">Recover Login Details</a></span>
					</div>
					<div class="lg_link">
					<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" validationgroup="login" /> 
					</div>
				</div>

	</div>
	
	    <div style=" padding-left:480px;">
	        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="X-Small" ></asp:Label>
	    </div>
	    
	</div>
	
</form>
  </body>
</html>