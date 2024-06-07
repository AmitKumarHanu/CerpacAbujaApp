<%@ page language="C#" autoeventwireup="true" inherits="FrmVerify, App_Web_frmverify.aspx.cdcab7d2" %>
<%@ OutputCache Location="None" NoStore="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" cssclass="textbox" runat="server">
    <title>Verify Login</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" /> 
   
    <link href="App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <link href="App_theme/css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript" src="/JS/checkFileExt.js"></script> 
     <script language="javascript" type="text/javascript" src="/JS/validation.js"></script>   
    
        
    <script language="javascript" type="text/javascript">

        function AlfaNumeric(t) {
            var cod = " ";
            var v = cod
            var w = "";
            for (var i = 0; i < t.value.length; i++) {
                x = t.value.charAt(i);

                if (v.indexOf(x, 0) == -1)
                    w += x;
            }
            t.value = w;
        }

        function checkonlySpace(t) {
            var val = t.value.replace(/^\s+|\s+$/, '');
            // alert(t.value.length);
            if (val.length == 0) {
                t.value = '';
                //t.focus();
            }
        }


        function checkzero(t) {
            var val = t.value;
            if (parseInt(val) == 0) {
                t.value = '';
            }
        }

        function checkTextuserloginidMaxMinLength(t) {

            var userloginidlength = (document.getElementById('<%=txtLoginId.ClientID%>'))
            //var loginidlength=txtLoginId.text;
            if (userloginidlength.value.lenght > 20) {
                alert("login Id should be less then or equal to 20 alfanumeric characters.");
                return false;
            }

            if (userloginidlength.value.length < 8) {
                alert("login Id should be greater than or equal to 8 alfanumeric characters.");
                return false;
            }

        }


        ///////////////////----------------Password Validation---------------------------///////////////////////////////////

        function pwd(action) {
            var pwd1 = document.getElementById('<%=txtPassword.ClientID%>');
            var loginid = document.getElementById('<%=txtLoginId.ClientID%>');

            if (checkForm(loginid, pwd1) == true) {
                var loginid = loginid.value;


                var New = pwd1.value;

                if (!confirm('Do you want to ' + action + ' this record ?')) return false;
                else
                    return true;
            }
            else {
                //alert('test');
                return false;
            }

        }

        function checkForm(loginid, pwd1) {

            re = /^\w+$/;
            if (!re.test(pwd1.value)) {
                //alert('2');
                alert("Pasword must contain only letters, numbers and underscores!");
                pwd1.focus();
                pwd1.value = '';
                return false;
            }

            if (pwd1.value == loginid.value) {

                alert("Password must be different from User login ID!");
                pwd1.focus();
                pwd1.value = '';
                return false;
            }

            re = /[0-9]/;
            if (!re.test(pwd1.value)) {
                //alert('6');
                alert("password must contain at least one number (0-9)!");
                pwd1.focus();
                pwd1.value = '';
                return false;
            }
            re = /^.*[a-zA-Z]+.*$/;
            if (!re.test(pwd1.value)) {
                //alert('7');
                alert("password must contain at least one letter !");
                pwd1.focus();
                pwd1.value = '';
                return false;
            }

            if (pwd1.value != "") {
                if (pwd1.value.length < 8) {
                    //alert('4');
                    alert("Password must contain at least 8 characters!");
                    pwd1.focus();
                    pwd1.value = '';
                    return false;
                }

            }
            else {
                //alert('9');
                alert("Please check that you've entered !");
                pwd1.focus();
                return false;
            }

            //alert("You entered a valid password: " + form.pwd1.value);
            return true;
        }        
    </script> 
    <style type="text/css">
        .style1
        {
            /*background-image:url(../../Images/Content_New.gif);*/
	    color: #384467;
            border-style: none;
            font-size: 20px;
            font-family: Arial;
            font-weight: bold;
            text-decoration: none;
            height: 33px;
        }
    </style>
</head>

<body>
    <form id="form1"   runat="server" > 
    <center> 
    <%--<div id="container" align="center">
	
	    <ul style="list-style:none;">
                 
    <li style="font-size: 70px; font-weight: bold; padding-top: 3px; vertical-align: top ;margin:0px 30px 0px 90px; display:inline">Online Visa Application</li>
    
  </ul>
</div> --%>
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
    
    <table cellpadding="2"  cellspacing="10" style="border:1px solid #dddddd; width:60%">
    <tr>
        <td colspan="2"  class="style1" align="center">Verify Applicant Form
        </td>
    </tr>     
    
       <tr> 
         <td align="center" colspan ="2">       
        <center>        
                <table cellpadding="2" cellspacing="2" border="0" width="90%">
                   <tr>
                      <td colspan="2"  align="center" >
                         <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#339933" ></asp:Label> 
                     </td>
                   </tr> 
                    
                  
                    
                    <tr class="b11">
                        <td style="width:120px" align="right">Login ID :</td> 
                        <td align="left">                       
                           <asp:TextBox ID="txtLoginId" Autocomplete="off" runat="server" class ="login" Width="175px"  Height="20px"></asp:TextBox>                               		
    			            <span style="color: #339933; text-align: center; font-size: medium;">*</span>
                             <asp:RequiredFieldValidator ID="RfvLoginId" runat="server" 
                                ErrorMessage="Enter Login Id" ControlToValidate="txtLoginId"
                                Display="None" ValidationGroup="a" SetFocusOnError="True" 
                                ForeColor="#339933"></asp:RequiredFieldValidator>
                         </td>
                      </tr>
                      
                    <tr >
                        <td colspan="2" align="center" style="height: 1px;"></td>
                    </tr>
                    
                    
                    
                    <tr class="b11">                       
                        <td align="right" style="width:120px">Password :</td>
                       <td align="left">
                            <asp:TextBox ID="txtPassword" Autocomplete="off" runat="server" TextMode="Password" class ="login" 
                    Width="175px" Height="20px"></asp:TextBox>
                     <span style="color: #339933; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="RfvPassword" runat="server" 
                    ErrorMessage="Enter Password" ControlToValidate="txtPassword"
                                Display="None" ValidationGroup="a" SetFocusOnError="True" ForeColor="#339933"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    
                    
                    <tr >
                        <td colspan="2" align="center" style="height: 5px;">
                        </td>
                    </tr>
                    
                      <tr class="b11">
                        <td  style="width:120px" align="right">Unique Code :</td>
                       <td align="left">
                             <asp:TextBox ID="TxtUniqueCode" Autocomplete="off" runat="server" class ="login" Width="175px" 
                    Height="20px"></asp:TextBox>               
				  			
    			<span style="color: #339933; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="RfvUniqueCode" runat="server" ErrorMessage="Enter Unique Code" ControlToValidate="TxtUniqueCode"
                                Display="None" ValidationGroup="a" SetFocusOnError="True" ForeColor="#339933"></asp:RequiredFieldValidator> 
    			</td>
                        </tr>
                        
                        <tr >
                        <td colspan="2" align="center"></td>
                          </tr>
                    
                    <tr >
                        <td colspan="4" align="center" style="height: 2px;">
                        <asp:Button ID="VerifyButton" CssClass="subbtn1" Text="Verify" runat="server" onclick="VerifyButton_Click" ValidationGroup="a"  />                                                                         
                        </td>                
                    </tr>
                
                    <tr class="b11">
						<td colspan="2" style="height: 10px">
						<asp:ValidationSummary ID="vsverifier" runat="server" DisplayMode="List" 
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" Visible="True"  />
						</td>
					</tr>                    
                </table>          
         </center>
          </td>
         </tr>
       </table>        
            <div id="footer" style="padding-top:10px; left: 0px; width:60%;"><br />Powered by <a href="http://www.contecglobal.com/" 
            target="_blank">Contech Global</a></div>  
       </center>         
    </form>
  </body>
</html>


	
