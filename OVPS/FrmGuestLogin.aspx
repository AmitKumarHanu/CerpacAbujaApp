<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmGuestLogin.aspx.cs" Inherits="FrmGuestLogin" %>
<%@ OutputCache NoStore="true" Location="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" cssclass="textbox" runat="server">
    <title>Guest Login</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" /> 
   
    <link href="App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <link href="App_theme/css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript" src="/JS/checkFileExt.js"></script> 
     <script language="javascript" type="text/javascript" src="/JS/validation.js"></script>   
    
        
    <script language="javascript" type="text/javascript">
    
    function AlfaNumeric(t){
        var cod = " ";
        var v = cod
        var w = "";
        for (var i=0; i < t.value.length; i++)
          {
            x = t.value.charAt(i);

        if (v.indexOf(x,0) == -1)
            w += x;
            }
                t.value = w;
           }

    function checkonlySpace(t)
        { 	 
             var val   = t.value.replace(/^\s+|\s+$/, ''); 
                 // alert(t.value.length);
                 if (val.length == 0) 
                    {   
                       t.value = ''; 
                  //t.focus();
                    }
                } 
 
 
     function checkzero(t)
            {
                var val = t.value;
                if(parseInt(val)  == 0)
                {
                    t.value = '';
                    }
               }
 
        function checkTextuserloginidMaxMinLength(t)
        {
            
           var userloginidlength =(document.getElementById('<%=txtLoginId.ClientID%>')) 
            //var loginidlength=txtLoginId.text;
            if(userloginidlength.value.lenght > 20)
             {
             alert("login Id should be less then or equal to 20 alfanumeric characters.");
             return false;
             }
             
             if(userloginidlength.value.length < 8)
             {
             alert("login Id should be greater than or equal to 8 alfanumeric characters.");
             return false;
             } 
             
         } 

    
    ///////////////////----------------Password Validation---------------------------///////////////////////////////////
    
             function pwd(action)
                {       
            var pwd1=document.getElementById('<%=txtPassword.ClientID%>');
            var loginid=document.getElementById('<%=txtLoginId.ClientID%>');
           
            if(checkForm(loginid,pwd1)==true)
            {
                        var loginid=loginid.value;
                        
                                       
                        var New=pwd1.value; 
                      
                        if(!confirm('Do you want to '+action +' this record ?')) return false;
                        else        
                        return true;           
              }
              else
              {
                //alert('test');
                return false;
              }   
             
          }

	function checkForm(loginid,pwd1)
  {  
    
    re = /^\w+$/;
    if(!re.test(pwd1.value)) 
    {
    //alert('2');
      alert("Pasword must contain only letters, numbers and underscores!");
      pwd1.focus();
      pwd1.value='';
      return false;
    }
    
      if(pwd1.value == loginid.value )
       {
       
        alert("Password must be different from User login ID!");
        pwd1.focus();
        pwd1.value='';
        return false;
      }
      
      re = /[0-9]/;
      if(!re.test(pwd1.value)) 
      {
       //alert('6');
        alert("password must contain at least one number (0-9)!");
        pwd1.focus();
        pwd1.value='';
        return false;
      }
       re = /^.*[a-zA-Z]+.*$/;
      if(!re.test(pwd1.value)) 
      {
      //alert('7');
        alert("password must contain at least one letter !");
        pwd1.focus();
        pwd1.value='';
        return false;
      }

    if(pwd1.value != "" ) 
    {
      if(pwd1.value.length < 8)
       {
       //alert('4');
        alert("Password must contain at least 8 characters!");
        pwd1.focus();
        pwd1.value='';
        return false;
      }
         
    } 
    else 
    {
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
    
    <table cellpadding="2"  cellspacing="10" style="border:1px solid #dddddd; width:70%">
    <tr>
        <td colspan="2"  class="style1" align="center">Guest Registration Form
        </td>
    </tr>     
    
       <tr> 
         <td align="center" colspan ="2">       
        <center>        
                <table cellpadding="5" cellspacing="2" border="0" width="90%">
                   <tr>
                      <td colspan="2"  align="center" >
                         <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label> 
                     </td>
                   </tr> 
                    
                    <tr class="b11">
                        <td  style="width:120px" align="right">E-mail Id :</td>
                       <td align="left">
                            <asp:TextBox ID="txtEmailId" CssClass="textbox" runat="server" MaxLength="50" 
                                ValidationGroup="a" onkeyup="checkonlySpace(this); AlfaNumeric(this);"></asp:TextBox>
                            <span style="color: Red; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvEmailId" runat="server"
                                    ControlToValidate="txtEmailId" Display="None" 
                                ErrorMessage="Please Enter E-Mail Address" ValidationGroup="a" 
                                ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rgeEmailId" runat="server"
                                    ControlToValidate="txtEmailId" 
                                ErrorMessage=" Please Enter Correct E-Mail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="a" Display="None" ForeColor="#9EC550"></asp:RegularExpressionValidator>                           
                            </td>
                        </tr>
                        
                        <tr >
                        <td colspan="4" align="center"></td>
                          </tr>
                    
                    <tr class="b11">
                        <td align="right" style="width:120px">Login ID :</td>
                        <td align="left">
                            <asp:TextBox ID="txtLoginId" runat="server"  CssClass="textbox" MaxLength="20" onblur="checkTextuserloginidMaxMinLength(this);" onkeyup="checkzero(this); AlfaNumeric(this);" ValidationGroup="a"></asp:TextBox>
                            <span style="color: Red; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvlogin" runat="server" 
                                ErrorMessage="Please Enter Your Login ID" ControlToValidate="txtLoginId" 
                                Display="None" ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                         </td>
                      </tr>
                      
                    <tr >
                        <td colspan="4" align="center" style="height: 1px;"></td>
                    </tr>
                    
                    <tr class="b11">                       
                        <td align="right" style="width:120px">Password :</td>
                       <td align="left">
                            <asp:TextBox ID="txtPassword" CssClass="textbox" runat="server" onkeyup="checkonlySpace(this); AlfaNumeric(this);"
                                MaxLength="20" ValidationGroup="a" TextMode="Password"></asp:TextBox>
                            <span style="color: Red; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvpassword" runat="server" 
                                ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" Display="None" 
                                ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    
                    
                    <tr >
                        <td colspan="4" align="center" style="height: 5px;">
                        </td>
                    </tr>
                    
                    <tr >
                        <td colspan="4" align="center" style="height: 2px;">
                        <asp:Button ID="Submit" CssClass="subbtn1" runat="server" Text="Submit" 
                                ValidationGroup="a" onclick="Submit_Click" /> 
                         &nbsp;<asp:Button ID="BtnCancel" CssClass="subbtn1" runat="server" Text="Cancel" 
                                onclick="BtnCancel_Click" />                                                 
                        </td>
                    </tr>
                    
                    <tr>
                    <td colspan="4" style="width: 100%; height: 22px; text-align:center;">
                    
                     <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
					  <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						  * Note : Please do not enter '0' or only Combination of '0' in User LoginID textbox
					  </span>				  
                       </li>
                                  
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   1.The minimum length of password should be 8 characters and maximum should be 20 characters.
						   </span>             
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">               
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   2.Password must have at least 1 alphabet and 1 number.
						   </span>              
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						  <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">           
						   3.User Guest LoginId can not be used as password.
						   </span>               
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						  4.In case of any problem , please contact to your system administrator.
						  </span>             
					   </li>
           
                  
                     </td>
                    </tr>
                    
                    <%--insert here--%>
                    <tr class="b11">
						<td colspan="4" style="height: 10px">
							<asp:ValidationSummary ID="vsapplicantregister" runat="server" 
                                ValidationGroup="a" ShowMessageBox="True"
								ShowSummary="False" ForeColor="#9EC550" />
						</td>
					</tr>                    
                </table>
            <%--</fieldset>--%>
         </center>
          </td>
         </tr>
       </table> 
       </center>  
    </form>
  </body>
</html>
