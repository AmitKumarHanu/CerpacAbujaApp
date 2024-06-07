<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ OutputCache NoStore="true" Location="None" VaryByParam="None" %>

<!DOCTYPE html>

<html lang="en">
	<head>
	<title>.: CERPAC :.</title>

           <!-- https://www.tutorialrepublic.com/twitter-bootstrap-tutorial/bootstrap-get-started.php -->
    <meta charset="utf-8">
  
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Basic Bootstrap Template</title>
    <!-- Bootstrap CSS file -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
 
 <meta http-equiv="refresh" content="10;url=Dashboard.aspx" />
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
            
             <li id="home"><a href="Login.aspx" class="homeIcon"><strong>Home</strong></a></li>
            
           
                <li id="about"><a href="about.html"><strong>About Us</strong> </a></li>                                                                                                                             </a></li>
                <li id="guideline"><a href="guidelines.html"><strong>CERPAC Guidelines</strong></a></li>
                <li id="mission"><a href="mission.html"><strong>Zonal Offices</strong></a></li>
                 <!--<li id="faq"><a href="faq.html"><strong>FAQ</strong></a></li>-->
                 <li id="visa"><a href="visa.html"><strong>CERPAC FEES</strong></a></li>
                <%-- <li id="terms"><a href="terms.html"><strong>Terms & Condition</strong></a></li>--%>
                 <li id="terms"><a href="Dashboard.aspx"><strong>Dashboard</strong></a></li>
                <li id="Li1"><a href="Admin/FrmLicAct.aspx"><strong>Licence</strong></a></li>
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



<form id="Form1" name="form1" runat="server">
   <asp:ScriptManager runat="server" ID="scr" EnablePageMethods="true"></asp:ScriptManager>
    <!-- JS files: jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">  <ContentTemplate> <asp:Panel runat="server" ID="Panel1" >  
    <div class="container">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row justify-content-center">            
                  <div class="col-sm-12"> <div class="card-body text-center">
                         <h1 class="card-title" id="lblZoneName" runat="server">Abuja </h1>                                                         
                 </div> </div>            
            </div>
           <div class="row justify-content-center">
               
          
<%--            <div class="col-sm-6"> <%--Data Entry
                 <div class="card text-white bg-secondary mb-4" >
                      <div class="card-body">
                                        <h5 class="card-title">Data Entry Module</h5>
                                        <h5 class="card-title" id="lblDataEntry" runat="server">Data Entry Module</h5>                                     
                       </div>
                 </div>
            </div>--%>
              <div class="col-sm-3"> <%--Authorization--%>
                 <div class="card text-white bg-primary mb-4 " >
                      <div class="card-body text-center">
                          <h1 class="card-title" id="lblAuthorization" runat="server">Authoriztaion Module</h1> 
                          <p class="card-title" >Authoriztaion </p>                                  
                       </div> 
                  </div>
            </div>
                 <div class="col-sm-3"> <%--Contec Verification--%>
                 <div class="card text-white bg-success mb-4">
                     <div class="card-body text-center">
                         <h1 class="card-title" id="lblVerification" runat="server" >Verification Module</h1>    
                          <p class="card-title" >Verification </p>                                    
                       </div> 
                     </div>                      
            </div>
                 <div class="col-sm-3"> <%--Production --%>
                 <div class="card text-white bg-danger mb-4">
                       <div class="card-body text-center">                                        
                            <h1 class="card-title" id="lblProduction" runat="server" >Production Module</h1>    
                            <p class="card-title" >Production </p>                                    
                       </div>                            
                  </div>
            </div>
            <div class="col-sm-3"> <%--Quality --%>
                 <div class="card text-white bg-warning mb-4">
                             <div class="card-body text-center">                                       
                                 <h1 class="card-title" id="lblQuality" runat="server" >Quality Module</h1>        
                                 <p class="card-title" >Quality </p>                                
                            </div>                            
                   </div>
            </div>

               <%-- <div class="col-sm-3"> <%--Completed 
                      <div class="card text-white bg-dark">
                                    <div class="card-body">
                                      <h1 class="card-title" id="lblCompleted" runat="server" >Completed </h1>        
                                      <p class="card-title" >Completed </p>   
                                    </div>
                                </div>
               
            </div>--%>
        </div>
        <div class="row justify-content-center">            
            <div class="col-sm-12"> <div class="progress">
                <div class="progress-bar  bg-primary " id="lblA" runat="server" ></div>
                <div class="progress-bar  bg-success " id="lblV" runat="server" ></div>
                <div class="progress-bar  bg-danger " id="lblP" runat="server" ></div>
                 <div class="progress-bar  bg-warning " id="lblQ" runat="server" ></div>
            </div> </div>
         </div>
           
    
    </div>
          </asp:Panel>
          </ContentTemplate>
     </asp:UpdatePanel>
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
</div>
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