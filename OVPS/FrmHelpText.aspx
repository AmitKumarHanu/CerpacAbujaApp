<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmHelpText.aspx.cs" Inherits="FrmHelpText" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>Nigeria</title>
	<%--<link href="includes/style.css" rel="stylesheet" type="text/css" />--%>
    <link href="App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript">

        function killCopy(e) {
            return false
        }
        function reEnable() {
            return true
        }
        document.onselectstart = new Function("return false")
        if (window.sidebar) {
            document.onmousedown = killCopy
            document.onclick = reEnable
        }
</script>
</head>
	<body>
		<div class="wraper_hm">
			<div class="header_hmtp">
				<div class="menu">
					<ul>
						<li><a href="FrmHomePage.aspx">Home</a></li>
                       
						<li><a href="about.aspx">About Us</a></li>
				<!--		<li><a href="http://www.fco.gov.uk/en/travel-and-living-abroad/travel-advice-by-country/country-profile/sub-saharan-africa/nigeria/">About Nigeria</a></li>
						<li><a href="uc.aspx">Media</a></li>
						<li><a href="uc.aspx">FAQ</a></li>
						<li><a href="uc.aspx">Foreign Policy Issues</a></li>
						<li><a href="uc.aspx">Trade & Investment</a></li>-->
                         <li><a href="mission.aspx">Foreign Missions</a></li>
                        <li><a href="fees.aspx">Visa Fees</a></li>
                        <li><a href="icao.pdf" target="_blank"> ICAO Photo Recommendations</a></li>
                        <li><a href="faq.html">FAQ</a></li>
                            <li><a href="contactus.aspx">Contact Us</a></li>
					</ul> 
				</div>
				<div class="hm_banner"></div>
			</div>
			<div class="cont_hmtp">
				<div class="cont_hmtplft_int">
					
					
                    <font style="color:#9f0109;font-size:18px;line-height:24px;">Help</font> <br/><br/>
					
                    


                     
              <div id="page_3" class="XY20"> <table align="left" style="width:100%; height:350px;">
   
    
    <%--<tr>
    <td style="height:"1px">
    </td>
    </tr>--%>
    
    <tr>
    <td align="center" style="height:"5px"><h5 style="text-decoration: underline">Guest Login</h5>
    </td>
    </tr>
    
    <tr>
    <td style="height:"5px">
    'Guest Login' is mainly used by the users who are in hurry.<br /> Only EmailId, LoginId and Password are required.<br /> After successful registration, his login id, password along with one system generated unique code will be sent to the email id provided by him.<br /> This unique code is user specific and must be provided while verifying user’s login.<br /> In that email, a link will also be sent to the user through which he will be directed to the login page and now he can log in, enter OVPS and apply for visa.<br /> In visa application form, two fields(login id and email id) will be auto filled.<br /> Rest of the fields must be filled by the user.
    </td>
    </tr>
    
    <tr>
    <td>
    </td>
    </tr>
    
    <tr>
    <td align="center" style="height:"5px"><h5 style="text-decoration: underline">New User</h5>
    </td>
    </tr>
    
    <tr>
    <td style="height:"5px">
    ‘New User’ is the general process for one to register him.<br /> The ‘New User’ link will direct the user to a registration form.<br />  User needs to fill all the required personal details and submit the form in order to register himself.<br /> After successful registration, his login id, password along with one system generated unique code will be sent to the primary email id provided by him in the registration form.<br /> This unique code is user specific and must be provided while verifying user’s login.<br /> In email, a link saying “Click me to verify your login” will be sent which will direct the user to a page where his registration will be verified. In verify login page, user must fill the fields, login id, password and unique code.<br /> After successful login, user can enter OVPS and apply for visa.<br /> In visa application form, information which is already provided by the user in registration form, will auto fill and rest of the fields shall be filled by the user.
    </td>
    </tr>
    
    <tr>
    <td>
    </td>
    </tr>
    
    <tr>
    <td align="center" style="height:"5px"><h5 style="text-decoration: underline" >Recover Login Detail</h5>
    </td>
    </tr>
    
    <tr>
    <td 10px" class="style1">
    User can retrieve his login details (Login id and password) from “Recover Login Details”.<br /> In order to retrieve details, user must remember either his login id or email id based on any one of which details can be recovered.<br /> Recovered details will be sent to his email id. 
    </td>
    </tr>
    
    <tr>
    <td style="height:"5px">
    </td>
    </tr>    
    </table></div>


				
				</div>
			</div>
			<div class="cont_hmdwn">
				<div class="cont_qkcnt">
				</div>
			</div>


            <table border="0" cellspacing="0" cellpadding="0" bgcolor="1bb741" height="28px !important;">
            <tr >
         <td style="width:340px;"></td>
       
         
            <td valign="top">
         
           <div class="fmenu">
            
            <ul>
            <li>
            <a href="Termsandconditions.htm" class="terms">Terms and Conditions &nbsp;&nbsp; |</a>
            </li>
            <li>
            <a href="Privacypolicy.htm" class="terms">Privacy Policy &nbsp;&nbsp;  |</a>
            </li>
            <li>
            <a href="Websitecopyright.htm" class="terms">Website Copyright</a>
            </li>
            
            </ul>
            </div>
           </td>
            </tr>
        </table>

			<div class="footer_hm">
            



				<div class="footer_hmlft">
				<%--<a href ="Login.aspx"></a>--%> 
					<div style="width:75px;height:75px;float:left;">
						<a href="http://ecowas.int/" target="_blank"><img src="./images/ft_icon1.png" alt="icon1"/></a>
					</div>
					<div style="width:106px;height:29px;float:left;margin:30px 0 0 20px;">
						<a href="http://www.african-union.org/" target="_blank"><img src="./images/ft_icon2.png" alt="icon2"/></a>
					</div>
					<div style="width:81px;height:51px;float:left;margin:10px 0 0 20px;">
						<a href="http://www.mfa.gov.ng/deight/" target="_blank"><img src="./images/ft_icon3.png" alt="icon3"/></a>
					</div>
					<div style="width:68px;height:60px;float:left;margin:10px 0 0 20px;">
						<a href="http://www.un.org/" target="_blank"><img src="./images/ft_icon4.png" alt="icon4"/></a>
					</div>
					<div style="width:166px;height:37px;float:left;margin:20px 0 0 20px;">
						<a href="http://www.opec.org/opec_web/en/" target="_blank"><img src="./images/ft_icon5.png" alt="icon5"/></a>
					</div>
				</div>
				<div class="footer_hmrt">
					&copy; 2012 (MFA) Ministry of Foreign Affairs <br/>
					Federal Republic of Nigeria.<br/>
					All Rights Reserved.
				</div>
			</div>
            
		</div>
	</body>
</html>


