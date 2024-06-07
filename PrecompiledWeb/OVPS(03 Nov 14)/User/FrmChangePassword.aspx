<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="User_FrmChangePassword, App_Web_frmchangepassword.aspx.6cc23264" title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
<style type="text/css">
/*START Error msg. have this class*/
.errormsg
{
	
	Color:#333333;
	background-color:#E9ACAC;
	border:Solid 1px; 
	border-color:Red;
  }

/*START Success msg. have this class*/
.successmsg
{
	
	Color:#333333;
	background-color:#a5f4b2;
	border:Solid 1px; 
	border-color:#00ff2a;
	 /*background-color:Green;*/
	}

</style>
 <script language="javascript" type="text/javascript">
     function validatePassword() {
         var password = (document.getElementById('<%=txtNewPassword.ClientID%>'));
         if (password.value.length == 0) {
             password.style.borderColor = 'red';
             //alert("Please enter password");
             password.focus();
             return false;
         }
         else {

             if (password.value.length < 4) {
                 //alert('4');
                 alert("Password must contain at least 4 characters!");
                 password.focus();
                 password.value = '';
                 return false;
             }
             var loginid = document.getElementById('<%=txtLoginId.ClientID%>');
             if (password.value == loginid.value) {
                 alert("Password must be different from user loginiD ");
                 password.focus();
                 password.value = '';
                 return false;
             }
             var pwd = document.getElementById('<%=txtOldPassword.ClientID%>');
             if (password.value == pwd.value) {
                 alert("New password must be different from old password ");
                 password.focus();
                 password.value = '';
                 return false;
             }
             re = /^\w+$/;
             if (!re.test(password.value)) {
                 //alert('2');
                 alert("Password must contain only letters, numbers and underscores!");
                 password.focus();
                 password.value = '';
                 return false;
             }
             re = /^.*[a-zA-Z]+.*$/;
             if (!re.test(password.value)) {
                 //alert('7');
                 alert("password must contain at least one letter !");
                 password.focus();
                 password.value = '';
                 return false;
             }

             return true;
         }
     } 
    function AlfaNumeric(t)
    {
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

  
  
     
    
    
    ///////////////////////////////////////---------------------------------------/////////////////////////////////////////
    
     
    </script>


<div align="center"> 
            
     <table cellpadding="2" cellspacing="10" style="width:95%" id="combox">
   
 <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS"  style="text-align: center"><font class="b12"><span style="font size:16px; color:white" >&nbsp; Change Password Form   &nbsp; </span></font>
                        </div>
                    </td>
                </tr> 
   <tr>
        <td colspan=2 align=center>  <asp:Label ID="lblmessage"  runat="server" Text="Label"  Width="600px" Visible=false Height="20px"></asp:Label>
        </td>
    </tr> 
       
      <tr> 
        <td align="center" colspan ="2" >
            <table style="font-style:normal" width ="55%"> 
            <tr align="center" valign="top">
                                    <td style="height: 208px">
                                    
                                     <table style="font-style:normal" width ="100%">   
            
                <tr>
                 <td colspan="4" style="height: 5px" >
                     </td>
                 </tr>
                 
           <tr class="t11">   
                                <td align="left" valign="top"  style="width: 237px;" class="b11">
                                    Login Id</td>
                                <td align="left" style="width: 237px;" >
                                    <asp:TextBox ID="txtLoginId" Autocomplete="off" runat="server" 
                                        MaxLength="20" Width="200px" CssClass="textbox2" Enabled="False" ></asp:TextBox></td>
                                
                 </tr>
                 <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
                                         
                <tr class="t11">
                    <td align="left" valign="top" style="width: 237px" class="b11">Old Password</td>
                    <td align="left" style="width: 237px" >
                       <asp:TextBox ID="txtOldPassword"  Autocomplete="off" runat="server"  CssClass="textbox2" 
                            TextMode="Password" MaxLength="20"  
                            onkeyup="checkzero(this); AlfaNumeric(this);" Width="200px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldPassword" runat="server" 
                            ControlToValidate="txtOldPassword" ErrorMessage="Fill Old Password"
                            SetFocusOnError="True" ValidationGroup="Update" Width="1px" 
                            ForeColor="Red">*</asp:RequiredFieldValidator></td>
                </tr> 
                <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
            <tr class="t11">
                    <td align="left" valign="top" style="width: 237px; height: 21px;" class="b11">New Password</td>
                    <td align="left" style="width: 237px; height: 21px;" >
                       <asp:TextBox ID="txtNewPassword" Autocomplete="off" runat="server"  CssClass="textbox2" TextMode="Password" MaxLength="20" onblur=validatePassword(); onkeyup="checkzero(this); AlfaNumeric(this);" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword" runat="server"
                            ControlToValidate="txtNewPassword" ErrorMessage="Fill New Password"
                            SetFocusOnError="True" ValidationGroup="Update" Width="1px" 
                            ForeColor="Red">*</asp:RequiredFieldValidator></td>
                </tr>  
                
                 <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
                               
            <tr class="t11">
                    <td align="left" valign="top" style="width: 84px" class="b11">Confirm Password</td>
                    <td align="left" style="width: 237px" >
                        <asp:TextBox ID="txtconfirmpassword" Autocomplete="off" runat="server" MaxLength="20"  onkeyup="checkzero(this); AlfaNumeric(this);" Width="200px" CssClass="textbox2" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server"
                            ControlToValidate="txtconfirmpassword" ErrorMessage="Fill Confirm Password"
                            SetFocusOnError="True" ValidationGroup="Update" Width="1px" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator" runat="server"
                            ControlToCompare="txtnewpassword" ControlToValidate="txtconfirmpassword"
                            ErrorMessage="Confirm password value should match with new password value" SetFocusOnError="True" 
                            ValidationGroup="Update" Display="Dynamic" ForeColor="RED"></asp:CompareValidator>
                    </td>
                        
                </tr> 
              
                 
                     </table> 
                   
                 </td>
            </tr>
                 
                                
            <tr>
            
        <td style="text-align: center; height: 24px;" class="button">            
            <asp:Button ID="BtnUpdate" runat="server" class="adminbutton" Text="Update" OnClick="BtnUpdate_Click" ValidationGroup="Update" UseSubmitBehavior="true"   /></td>        
        </tr>
         <tr>
                 <td style="height: 5px" >&nbsp;&nbsp;</td></tr>
               
        
          </table>
            <asp:Label ID="lblpwdchngmsg" runat="server" CssClass="information-box" Font-Size="Medium" Text="Since your password is 20 days old, so you need to change it for security reasons."></asp:Label>
      <br /><br />
            <asp:ValidationSummary ID="ValidationSummaryUpdate" runat="server" 
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Update" 
                ForeColor="#9EC550" />
    </td>
               </tr>
       
    </table>
    
 </div>

</asp:Content>

