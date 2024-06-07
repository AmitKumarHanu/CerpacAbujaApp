<%@ page language="C#" autoeventwireup="true" inherits="Admin_PassportDetails, App_Web_passportdetails.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/color.css" rel="stylesheet" type="text/css" />
     
    <script type="text/javascript" language=javascript>
        function disableback() {
            window.history.forward(1);
        }
        function sucess() {
            //var thissound = document.getElementById('sound1');
            // thissound.Play();
            document.getElementById("dummy").innerHTML = "<embed src=\"../sounds/sucess.wav\" hidden=\"true\" autostart=\"true\" loop=\"false\" />";
        }
        function fail() {
           // alert('angvb');
           // var thissound = document.getElementById('sound2');
            // thissound.Play();
            
           document.getElementById("dummy").innerHTML="<embed src=\"../sounds/fail.wav\" hidden=\"true\" autostart=\"true\" loop=\"false\" />";
       }

       function showhide() {
           document.getElementById('<%=btnverify.ClientID%>').style.display = 'none';
           document.getElementById('<%=lbl154.ClientID%>').style.display = '';
           document.getElementById('<%=imgverifying.ClientID%>').style.display = '';
       }
 </script>
 <style type="text/css">
 .information-box, .confirmation-box, .error-box, .warning-box, ol, .regular-ul, 
.custom-ul, blockquote, cite { font-size: 0.75em; /* 12/16 */ }

.information-box, .confirmation-box, .error-box, .warning-box {
	padding: 0.833em 0.833em 0.833em 3em; /* 10/12 36/12 */
	margin-bottom: 0.833em; /* 20/12 */ }

.information-box {
	background: #e5f5f9 url('../Images/icons/information.png') no-repeat 0.833em center;
	border: 1px solid #cae0e5;
	color: #5a9bab;
	}
	
.confirmation-box {
	background: #e7fae6 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 1px solid #b7cbb6;
	color: #52964f;
}

.error-box {
	background: #fde8e4 url('../Images/icons/error.png') no-repeat 0.833em center;
	border: 1px solid #e6bbb3;
	color: #cf4425;
}

.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
}
 </style>
</head>
<body onload="disableback();">
<span id=dummy></span>
 <!-- <embed src="../sounds/sucess.wav" autostart=false width=1 height=1 id="sound1" enablejavascript="true">
  <embed src="../sounds/fail.wav" autostart=false width=1 height=1 id="sound2"  enablejavascript="true"> -->
    <form id="form1" runat="server">










              <div class="wraper_app">
<!--.........................................................header start................................................-->
	<div class="header_app">	
		<div class="flag_app"></div>
		<div class="hdtxt_app"><img src="../images/hdtxt_app.png" alt="hdtxt_app"/></div>
		<div class="hdline_app"><img src="../images/hdline_app.png" alt="hdline_app"/></div>
		
	    <div class="hdtext2_app">
      
           <br/>
            <br/>
           &nbsp;&nbsp;                
		  <asp:Label ID="LabelSysDate" Font-Size="Smaller" runat="Server" CssClass="lbl"></asp:Label>
	</div>
		<div class="hdlogo_app">
			<img src="../images/logo_app.png" alt="logo_app"/>
		</div>		
	</div>	
<!--.........................................................header end................................................-->

<!--.........................................................content start................................................-->
	
            <div  id="combox"  style="width: 500px ! important; margin-left: 300px; height:400px;" >
	
        























    <div>
    <div>
   <td style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><font class="b12"><span style="font-size:16px; color:White">&nbsp;Passport Details &nbsp; </span></font>
                        </div>
                    </td>
    <div align=center><asp:Label runat=server ID=lblmsg Visible=false></asp:Label></div><br /><br />
    <table border=0 cellpadding=0 cellspacing=0 align=center>
    <tr>
    <td>
    <asp:Label ID=lbl1 Font-Bold="true" runat=server Text="Document Type"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lblDocName Font-Bold="true" runat=server></asp:Label>
    </td>
    </tr>
    <tr><td height=15></td></tr>
    <tr>
    <td>
    <asp:Label ID=Label3 Font-Bold="true" runat=server Text="First Name"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lblName Font-Bold="true" runat=server></asp:Label>
    </td>
      
  
    </tr>
    <tr><td height=15></td></tr>
    <tr>
    <td>
    <asp:Label ID=Label2 Font-Bold="true" runat=server Text="Last Name"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lblFamily Font-Bold="true" runat=server></asp:Label>
    </td>
      
    </tr>
    <tr><td height=15></td></tr>
    <tr>
    <td>
    <asp:Label ID=Label4 Font-Bold="true" runat=server Text="Document Number"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lblDocNo Font-Bold="true" runat=server></asp:Label>
    </td>
       
 
    </tr>
    <tr><td height=15></td></tr>
        <tr>
    <td>
    <asp:Label ID=Label5 Font-Bold="true" runat=server Text="Nationality"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label Font-Bold="true" ID=lblNationality runat=server></asp:Label>
    </td>
          
           
    </tr>
    <tr><td height=15></td></tr>
        <tr>
    <td>
    <asp:Label Font-Bold="true" ID=Label6 runat=server Text="Date of Birth"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label Font-Bold="true" ID=lblDOB runat=server></asp:Label>
    </td>
           
         
    </tr>
    <tr><td height=15></td></tr>
        <tr>
    <td>
    <asp:Label ID=Label7 runat=server Font-Bold="true" Text="Sex"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lblSex Font-Bold="true" runat=server></asp:Label>
    </td>
<td>&nbsp;</td>

    </tr>
    <tr><td height=15></td></tr>
    <tr><td><asp:Label ID="lbl12" runat="server" Font-Bold="true" Text="Date of Expiry"></asp:Label></td><td width="12"></td><td colspan="3"><asp:Label Font-Bold="true" ID="lbldoe" runat="server"></asp:Label></td></tr>
    <tr><td height=15></td></tr>
        <tr><td colspan=7 align=center>
            <asp:Button ID=btnverify Text="Transfer Data" runat=server onclick="btnverify_Click" OnClientClick="showhide();" CssClass="adminbutton" style="background-color:#009900;" />
    <asp:Label ID="lbl154" style="display:none;" runat=server Text="Transfering Data.Please wait....." ForeColor=Gray Font-Size=Medium></asp:Label><asp:Image ID="imgverifying" ImageUrl="~/Images/verifying.gif" style="display:none;" runat=server  ImageAlign=Bottom/></td></tr>
    </table>
    
    </div>
   

    </div>
                  </div>
      </div>  
    </form>
</body>
</html>
