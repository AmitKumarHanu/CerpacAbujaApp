<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" EnableEventValidation="false" Inherits="Login" %>
<%@ OutputCache NoStore="true" Location="None" VaryByParam="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
	<title>.: CERPAC :.</title>

<link rel="shortcut icon" href="/favicon.ico" type="image/x-icon">
<link rel="icon" href="/favicon.ico" type="image/x-icon">

<script type="text/javascript" src="Placeholders.min.js"></script>
<script type="text/javascript" src="Placeholders.js"></script>


<script type="text/javascript">
    Modernizr.TextBox.load({
        test: Modernizr.TextBox.placeholder,
        nope: ['Placeholders.js'],
        complete: function () { Placeholders.init(); }
    });
</script>
		
<link rel="shortcut icon" type="images/ico" href="images/favi-icon.png" />
<link href="css/minicart.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="css/product-ensemble-styles.jsp" type="text/css" media="all"/>
<link href="css/left_sty.css" rel="stylesheet" type="text/css" />	

<link rel="stylesheet" type="text/css" href="css/ims_motif_styles.jsp" />
<link rel="stylesheet" href='css/global.css' type="text/css" media="all"/>

<link rel="stylesheet" href="css/countryPrint.css" type="text/css" media="print"/>
<link media="all" type="text/css" href="css/video.css" rel="stylesheet">
	

<link type="text/css" media="screen" href="css/autosuggest.css" rel="stylesheet">

<link media="all" type="text/css" href="css/quickview.css" rel="stylesheet">

<link rel="stylesheet" href="css/country.css" type="text/css" media="all"/>
        <link rel="Stylesheet" href="css/scanpage.css" media="all" type="text/css" />

<link rel="stylesheet" type="text/css" href="engine1/style.css" />
    <link href="ddmenu/ddmenu.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="assets/css/styles.css" />
    <script src="ddmenu/ddmenu.js" type="text/javascript"></script>

<script type="text/javascript" src="engine1/jquery.js"></script>
<script type="text/javascript" src="js/scrolltopcontrol.js"></script>


  <!-- include Cycle plugin-->
  


        </head>



	<body>

	<div id="wrapper">
   			<div id="templateHeader">
				<div id="headerWrapper">
            <div id="branding">
        		<div id="logo">
        
                 <img src="img/hm_banner.png" align="left" />
         
	        </div>
				<!-- /logo -->

	<div id="headerContentArea">

	</div>



				<br class="clear"/>
        	</div><!-- /branding -->
         <div id="globalNav">
 <nav id="ddmenu">
            <ul class="fancyNav">
            
             <li id="home"><a href="Login.aspx" class="homeIcon"><strong> Home </strong></a></li>
            
           
                <li id="about"><a href="about.html"><strong> About Us</strong> </a></li>                                                                                                                             </a></li>
                <li id="guideline"><a href="guidelines.html"><strong>CERPAC Guidelines</strong></a></li>
                <li id="mission"><a href="mission.html"><strong>Zonal Offices</strong></a></li>
                 <!--<li id="faq"><a href="faq.html"><strong>FAQ</strong></a></li>-->
                 <li id="visa"><a href="visa.html"><strong>CERPAC FEES</strong></a></li>
                   <%-- <li id="terms"><a href="terms.html"><strong>Terms & Condition</strong></a></li>--%>
                 <li id="terms"><a href="Dashboard.aspx"><strong>Dashboard</strong></a></li>
  		<li id="Li1"><a href="Admin/FrmLicAct.aspx"><strong>License</strong></a></li>
                  <li id="contactus"><a href="contact.html"><strong>Contact</strong></a></li>
            </ul>
        </nav>
				</div>
         <!-- /globalNav -->
				<!-- /plan -->



			

<!-- /search -->
        	<div id="ideas"></div>
             <!-- /ideas -->
			
        </div>
		  </div><!-- /templateHeader -->


			<div id="caregry_page" >
			    <div id="left_cat">

<div class="leftcol">
    <div class="left_heading">
   
    
    </div>

    
    
    <!--space -->
    
    
    <div class="dg">
    
    <!--
        <img src="img/nigerian-flag.jpg" width="186" height="160" />
        -->
    </div>
    
     <!--space end -->
	 <div class="clear"></div>
	
     



</div>

</div>
			    
			    <div id="right_cat_clogin"  height: 608px;">
  

<p style="margin-top: 21px; ">



<form id="Form1" name="form1" runat=server>
 
<div id="formContainer">
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
  <center>
  <asp:Label ID="lblmessage"  runat="server" Text="Label" Font-Size="Small" Visible=false ></asp:Label>
</center>
    <br /><br /> 
  <div id="login">

      
      
			<!--	<a href="#" id="flipToRecover" class="flipLink">Forgot?</a>
                        -->
				<asp:TextBox ID="UserName" placeholder="Username"  name="UserName"  CssClass="txtbox" Autocomplete="off" runat="server" ></asp:TextBox>
				<asp:TextBox ID="Password" placeholder="Password"  name="Password"  CssClass="txtbox" Autocomplete="off" runat="server" TextMode="Password"></asp:TextBox>
				
						<%--<input type="button" value="Login"/>--%>
						<asp:Button ID="BtnLogin" runat="server" CssClass="Btnstl" Text="Login" onclick="BtnLogin_Click" validationgroup="login" />
						<asp:RequiredFieldValidator ID="RfvLoginID" runat="server" ErrorMessage="Please enter Login ID....." ControlToValidate="UserName" validationgroup="login" setfocusonerror="True" Display="None">*</asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator ID="RfvPassword" runat="server"  ErrorMessage="Please enter Password....!" ControlToValidate="Password" validationgroup="login" setfocusonerror="True" Display="None">*</asp:RequiredFieldValidator>
                  <br />
                 <center style="margin-top: 110px; margin-left:0px;" > 
              <!--   <a href="Admin/FrmNewUsersRegistration.aspx"><span style=" color:Black; font-size:12px; font-weight:bold; ">Create  user</span></a> 
                 &nbsp; | &nbsp; <a href="FrmRecoverLoginid.aspx"><span style=" color:Black; font-size:12px; font-weight:bold; ">Recover Login Details</span></a>

                 | &nbsp;
               --> <!-- <a href="help.html" target="_blank"><span style=" color:Black; font-size:13px; font-weight:bold; ">Help</span></a> -->
                 </center>
                </div>
	<!--		
			<div id="recover">
				<a href="#" id="flipToLogin" class="flipLink">Forgot?</a>
           
				<asp:TextBox ID="txtLoginId" Autocomplete="off"  runat="server"  MaxLength="25"></asp:TextBox>
               
				 <asp:TextBox ID="txtEmailId" Autocomplete="off" runat="server" MaxLength="50"></asp:TextBox>
				
				</div>
 -->
              
	  </div>
      </form>



</p>
<p style="float:right;">
  
  <br />

</p>
<p>
</p>

</div>

</div>
<!-- /centerContent -->

			<div id="templateFooter" style="height:0px !important; padding: 0px 0px 0px !important;" class="clear">
				<!--// begin footer //-->


<!--// end footer // -->

<!-- Tealium script for tagging -->


</div><!-- /templateFooter -->

	<!-- /partner -->
			
			

		<!-- /wrapper -->
			<div id="social_icon"><table width="1000" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="392" align="center">
    
   <a href="terms.html"><strong> Terms and Conditions</strong></a> | 
     <a href="privacy.html"><strong> Privacy Policy</strong></a> | 
     <a href="websitecopy.html"><strong> Website Copyright</strong></a> 
    
    &nbsp;</td>
    <td width="378" height="47">&nbsp;
      </td>
    <td width="230"><strong>All Rights Reserved. &copy; 2012 (MOI)</strong></td>
  </tr>
</table>
</div>
	<!-- Start Epsilon Tag -->


	<!-- End Epsilon Tag -->

    <SCRIPT>
        $("#accordion > li > div").click(function () {

            if (false == $(this).next().is(':visible')) {
                $('#accordion ul').slideUp(300);
            }
            $(this).next().slideToggle(300);
        });

        $('#accordion ul:eq(0)').show();

</SCRIPT>
<!-- Start Media Math Tag -->
<script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
		<script src="assets/js/script.js"></script>

</body>

</html>