<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_frmverifierlinknmessage.aspx.cdcab7d2" %>
<%@ OutputCache Location="None" NoStore="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OVPS:: Verification Link Message</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <link href="App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 40px;
        }
        .boxshow
        {
            border: 1px solid #DDD;
background-color: #F7F3F3;
width: 52%;
margin: 0 auto;
border-radius: 10px;
font-size: 18px;
color: #1A1A1A;
font-family: inherit;
        }
          .boxshow h2
          {
              font-size: 22px;
              color:Black;
             font-family:Cambria;
          }
        .style2
        {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
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
	</center>
	
    <div>
    <table cellpadding="2" cellspacing="10" class="boxshow">
    <tr>
        <td colspan="2" align="center" class="style1"> 
           <h2> Verifier Link Page</h2>
        </td>
    </tr> 
    <tr>
        <td colspan="2" align="center" class="style2"> 
        </td>
    </tr> 
    <tr>
        <td colspan="2" align="center"> 
           <h4>Dear Applicant Your Login Id,Password and Unique Code has been sent to your Email Address.</h4>
        </td>
    </tr> 
    <tr>
        <td colspan="2" align="center"> 
           <h4>Kindly Verify your Login, by clicking on the given link or link provided in your Email</h4>
        </td>
    </tr> 
    
    <tr>
        <td colspan="2" align="center" > 
           <h4><a href="FrmVerify.aspx" >Click here to Verify Your login </a> </h4>  
        </td>
    </tr> 
    <tr>
        <td colspan="2" align="center" class="style2"> 
        </td>
    </tr>
    </table> 
    </div>
    </form>
</body>
</html>
