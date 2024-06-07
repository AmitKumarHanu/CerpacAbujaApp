<%@ Page Language="C#" MasterPageFile="~/MasterPage-Jan-16/RegistrationMasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="design_register" Title="New User Registration Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />

     <script language="javascript" type="text/javascript" src="JS/datetimepicker.js"></script>
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
        var userloginidlength = (document.getElementById('<%=txtuserLoginId.ClientID%>'))
        //var userloginidlength=txtuserLoginId.text;
        if (userloginidlength.value.length > 20) {
            alert("User login Id should be less then or equal to 20 alfanumeric characters.");
            return false;
        }
        if (userloginidlength.value.length < 8) {
            alert("User login Id should be greater than or equal to 8 alfanumeric characters.");
            return false;
        }
    }

    function textboxMultilineMaxNumber(txt, maxLen) {
        try {
            if (txt.value.length > (maxLen - 1))
            //alert('Enter Only 200 characters for address');
                return false;
        }
        catch (e) {

        }

    }

    ///////////////////----------------Password Validation---------------------------///////////////////////////////////

    function pwd(action) {
        var pwd1 = document.getElementById('<%=txtPassword.ClientID%>');
        var pwd2 = document.getElementById('<%=txtConfPassword.ClientID%>');
        var loginid = document.getElementById('<%=txtuserLoginId.ClientID%>');

        if (checkForm(loginid, pwd1, pwd2) == true) {
            var loginid = loginid.value;
            var New = pwd1.value;
            var Confirm = pwd2.value;

            if (!confirm('Do you want to ' + action + ' this record ?')) return false;
            else
                return true;
        }
        else {
            //alert('test');
            return false;
        }
    }

    function checkForm(loginid, pwd1, pwd2) {

        re = /^\w+$/;
        if (!re.test(pwd1.value)) {
            //alert('2');
            alert("Password must contain only letters, numbers and underscores!");
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
        if (pwd2.value == loginid.value) {
            alert("Confirm password also must be different from user loginiD ");
            pwd2.focus();
            pwd2.value = '';
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
        if (!re.test(pwd2.value)) {
            alert("Confirm password must contain at least one number (0-9)!");
            pwd2.focus();
            pwd2.value = '';
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
        if (!re.test(pwd2.value)) {
            // alert('3');
            alert("Confirm Password must contain only letters, numbers and underscores!");
            pwd2.focus();
            pwd2.value = '';
            return false;
        }

        if (pwd1.value != pwd2.value) {
            alert("Confirm Password does not match with Password!");
            pwd1.value = '';
            pwd2.value = '';
            return false;
        }

        if (pwd1.value != "" && pwd1.value == pwd2.value) {
            if (pwd1.value.length < 8) {
                //alert('4');
                alert("Password must contain at least 8 characters!");
                pwd1.focus();
                pwd1.value = '';
                return false;
            }

            /*
            re = /[A-Z]/;
            if(!re.test(pwd1.value)) 
            {
            // alert('8');
            alert("Error: password must contain at least one uppercase letter (A-Z)!");
            pwd1.focus();
            return false;
            }*/
        }
        else {
            //alert('9');
            alert("Please check that you've entered and confirmed your password!");
            pwd1.focus();
            return false;
        }

        //alert("You entered a valid password: " + form.pwd1.value);
        return true;
    }

    function NumNSign(t) {

        var cod = "+-0123456789";
        var v = cod
        var w = "";
        for (var i = 0; i < t.value.length; i++) {
            x = t.value.charAt(i);
            if (v.indexOf(x, 0) != -1)
                w += x;
        }
        t.value = w;
    }


    ///////////////////////////////////////---------------------------------------///////////////////////////////////////// 
</script>


<script type="text/javascript">
    function HideTextBox(ddlId) {
        var ddlControl = document.getElementById(ddlId.id);
        var Text = ddlControl.options[ddlControl.selectedIndex].text;
        //it depends on which text Selection do u want to hide or show your textbox
        if (Text == 'Test1') {
            document.getElementById('<%= txtDemo.ClientID %>').style.display = 'none';

        }
        else {
            document.getElementById('<%= txtDemo.ClientID %>').style.display = '';
        }
    }

</script>


<asp:DropDownList ID="drop1" runat="server" onchange="HideTextBox(this);">
      <asp:ListItem Value="0" Text="Test"></asp:ListItem>
      <asp:ListItem Value="1" Text="Test1"></asp:ListItem>
  </asp:DropDownList>
  <asp:TextBox ID="txtDemo" runat="server"></asp:TextBox>


<div style="text-align:center;"  >
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
  <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; background-color:"#696969 width:100%">
    <tr>
        <td colspan="2"  class="PageNameHeadingCSS_2" align="center">Applicant Registration Form
        </td>
    </tr>     
    <tr>
        <td align="center" > 
            
           
            <table cellpadding="5" cellspacing="2" border="0" width="100%"> 
              <tr class="b11" align="center">
                 <td align="left" style="width: 10%; vertical-align:middle; text-align:left; background-repeat: no-repeat;">
                   <asp:Image runat="server" ID="ImgPhoto" ImageUrl="~/Images/Logo/default_logo.gif" Width="150px" Height="150px" />
                 </td>
                   <td align="left" style=" text-align: left; " class="style2" >
                    <asp:FileUpload ID="logobrowse" BackColor="White" runat="server" 
                           CssClass="button1" Width="80%" ForeColor="White" /><br />
                    <asp:Button ID="btnUploadPhoto"  runat="server" CssClass="subbtn1" 
                           Text="Upload Photo"  Height="25px" /> 
                     <asp:Button ID="btnUploadCancel" runat="server" CssClass="subbtn1" Text="Cancel"  />                                                                                                                                 
                   </td>
                   <td style="width:2%;"></td>                 
                    <td colspan="6" style="width: 100%; height: 22px; text-align: left">  
                    <ul>                 
                      
                     <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
					  <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						  * Note : Please do not enter '0' or only Combination of '0' in User LoginID textbox
					  </span>				  
                       </li>
                       <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   1.Fields marked with * are mandatory.
						   </span>             
					   </li>
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   2.Take the photo in front of a white or off-white background.
						   </span>             
					   </li>
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   3.Application supports .jpg/.gif/.jpeg/.png/.JPG/.GIF/.PNG Image extension.
						   </span>             
					   </li>					   
                                  
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   4.The minimum length of password should be 8 characters and maximum should be 20 characters.
						   </span>             
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">               
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						   5.Password must have at least 1 alphabet and 1 number.
						   </span>              
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						  <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">           
						   6.User LoginId can not be used as password.
						   </span>               
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: #9EC550; text-align: center; font-weight: bold; font-size: smaller;">
						  7.In case of any problem , please contact to your system administrator.
						  </span>             
					   </li> 
					   </ul> 
                     </td>
                 </tr>                                   
               </table>
             
           
            </td>
         </tr>        
     <tr> 
        <td align="center" colspan ="2" >
          <center> 
             <table cellpadding="7" cellspacing="2" border="0" width="100%" class="BackGround2">
                <tr >
                  <td colspan="6" align="center" class="style1">
                  </td>
                </tr>
                    <tr>
                    <td colspan="2"></td>
                        <td align="left" class="t11">User Login ID :</td>
                        <td align="left" class="t11" colspan="3"><asp:TextBox ID="txtuserLoginId" runat="server"  CssClass="textbox2" MaxLength="20" onblur="checkTextuserloginidMaxMinLength(this);" 
                            onkeyup="checkzero(this); AlfaNumeric(this);" ValidationGroup="a"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvuserlogin" runat="server"  ErrorMessage="Please Enter Your Login ID" ControlToValidate="txtuserLoginId" 
                                Display="None" ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                            </tr>
                    <tr>
                        <td colspan="6" align="center" style="height: 15px;">
                        </td>
                    </tr>
                     
                    <tr class="b11" runat="server" id="tr7">
                       <td align="left" class="style3">
                            Passport Number :
                        </td>
                        <td align="left" style="width: 23%;">
                            <asp:TextBox ID="TxtPassportNumber" CssClass="textbox2" runat="server"
                                MaxLength="10" ValidationGroup="a"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                <asp:RequiredFieldValidator ID="rfvpassportno" CssClass="textbox" 
                                runat="server" ControlToValidate="TxtPassportNumber"
                                ErrorMessage="Please Enter Passport number" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                         <td align="left" style="width: 12%;">
                            Nationality :
                        </td>
                        <td align="left" style="width: 20%;">
                                <asp:DropDownList ID="ddlNationality" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br/>
                         <asp:RequiredFieldValidator ID="rfvnationality" CssClass="textbox" 
                                runat="server" ControlToValidate="ddlNationality"
                                ErrorMessage="Please Enter Nationality" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                         <td align="left" style="width: 15%;">Passport Type :
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:TextBox ID="TxtPassportType" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                          <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                <asp:RequiredFieldValidator ID="rfvpassporttype" CssClass="textbox" runat="server" ControlToValidate="TxtPassportType"
                                ErrorMessage="Please Enter Passport Type" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                       <%-- <tr >
                        <td colspan="6" align="center" style="height: 1px;">
                        </td>
                    </tr>--%>
                     <tr class="b11">
                        <td align="left" class="style3">
                            Date of Issue :
                        </td>
                        <td align="left">
                            <input type="text" class="textbox2" id="TxtDOI"  readonly="readonly" style="border-width: 1px; width: 132px;" runat="server" />
                            <span style="color: #9EC550;text-align: center; font-size: medium;">*</span>
                            <a id="DOI" runat="server" href="javascript:NewCal('TxtDOI','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />                            
                            <asp:RequiredFieldValidator ID="rfvDOI" CssClass="textbox" runat="server" ControlToValidate="txtDOI"
                                ErrorMessage="Select date of Issue" ValidationGroup="a" Display="None" 
                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 150px;">Date of Expiry :
                        </td>
                        <td align="left">
                            <input type="text" class="textbox2" id="TxtDOE" style="border-width: 1px; width: 131px;"  readonly="readonly" runat="server" />
                             <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <a id="DOE" runat="server" href="javascript:NewCal('TxtDOE','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />                                
                                <asp:RequiredFieldValidator ID="rfvDOE" CssClass="textbox" runat="server" ControlToValidate="TxtDOE"
                                    Display="None" ErrorMessage="Select Passport Expiry Date" ValidationGroup="a"
                                    SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                            
                        </td>
                         <td align="left" style="width: 150px;">Place of Issue :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="TxtPlaceofIssue" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                <asp:RequiredFieldValidator ID="rfvplaceofissue" CssClass="textbox" runat="server" ControlToValidate="TxtDOI"
                                    Display="None" ErrorMessage="Please Enter Place of issue" ValidationGroup="a" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  
                    <tr class="b11">
                     <td align="left" class="style3">Issuing Authority :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="TxtIssuingAuthority" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                           <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                <asp:RequiredFieldValidator ID="rfvissuingauthority" CssClass="textbox" 
                                runat="server" ControlToValidate="TxtIssuingAuthority" Display="None" ErrorMessage="Please Enter issuing Authority"
                                 ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 150px;">
                            Password :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="txtPassword" CssClass="textbox2" runat="server" onkeyup="checkonlySpace(this); AlfaNumeric(this);"
                                MaxLength="20" ValidationGroup="a" TextMode="Password"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvpassword" runat="server" 
                                ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" Display="None" 
                                ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 150px;">
                            Confirm  Password :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="txtConfPassword" CssClass="textbox2" runat="server" onkeyup="checkonlySpace(this); AlfaNumeric(this);"
                                MaxLength="20" ValidationGroup="a" TextMode="Password"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                             <asp:RequiredFieldValidator ID="rfvconpass" runat="server" 
                                ErrorMessage="Please Enter Confirm Password" 
                                ControlToValidate="txtConfPassword" Display="None" 
                                ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Cmppassword" runat="server" 
                                ErrorMessage="Confirm Password does not match with Password" 
                                ControlToCompare="txtPassword" Display="None" 
                                ControlToValidate="txtConfPassword" Font-Size="Smaller" 
                                ValidationGroup="a" ForeColor="#9EC550"></asp:CompareValidator>
                            
                        </td>
                    </tr>                  
                    <tr class="b11">
                        <td align="left" class="style4">
                            Primary Email :
                        </td>
                        <td align="left" class="b11">
                            <asp:TextBox ID="txtPrimaryEmail" CssClass="textbox2" runat="server" MaxLength="50" 
                                ValidationGroup="a"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvprimaryemail" runat="server"
                                    ControlToValidate="txtPrimaryEmail" Display="None" 
                                ErrorMessage="Please Enter E-Mail Address" ValidationGroup="a" 
                                ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rgeprimaryemail" runat="server"
                                    ControlToValidate="txtPrimaryEmail" 
                                ErrorMessage=" Please Enter Correct E-Mail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="a" Display="None" ForeColor="#9EC550"></asp:RegularExpressionValidator>
                            
                        </td>
                        <td align="left" class="b11">
                            Alternate Email :
                        </td>
                        <td align="left" class="b11">
                            <asp:TextBox ID="txtAlternatEmail" CssClass="textbox2" runat="server" MaxLength="50" 
                                ValidationGroup="a"></asp:TextBox><br />
                          
                            <asp:RegularExpressionValidator ID="rgealternateemail" runat="server"
                                    ControlToValidate="txtAlternatEmail" 
                                ErrorMessage="Please Enter Correct Alternate E-Mail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="a" Display="None" ForeColor="#9EC550"></asp:RegularExpressionValidator>
                                   
                        </td>
                         <td align="left" style="width: 150px;">Mobile Number :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="TxtMobileNumber" CssClass="textbox2" runat="server"  onkeyup="NumNSign(this);"
                                MaxLength="15" ValidationGroup="a"></asp:TextBox>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                <asp:RequiredFieldValidator ID="rfvmobileno" CssClass="textbox" 
                                runat="server" ControlToValidate="TxtMobileNumber"
                                    Display="None" ErrorMessage="Please Enter mobile Number" 
                                ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                            
                        </td>
                       
                    </tr>
                  
                    
                    <tr class="b11" style="height:5%">
                     <td align="left" class="style3">LandLine Number :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="TxtLandLineNumber" CssClass="textbox2" runat="server" onkeyup="NumNSign(this);"  
                                MaxLength="15" ValidationGroup="a"></asp:TextBox>
                         <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                
                        </td>
                        <td align="left" style="width: 150px;" class="b11">
                            SecretQuestion :
                        </td>
                        <td align="left" style="width: 190px;" class="b11">
                            <asp:TextBox ID="TxtSecretQuestion" CssClass="textbox2" runat="server"
                                MaxLength="100" ValidationGroup="a"></asp:TextBox>
                           
                        </td>
                        <td align="left" style="width: 150px;" class="b11">
                            SecretQueAnswer:
                        </td>
                        <td align="left" style="width: 190px;" class="b11">
                            <asp:TextBox ID="TxtSecretQueAnswer" CssClass="textbox2" runat="server"
                                ValidationGroup="a" TextMode="Password" MaxLength="50"></asp:TextBox>                          
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" class="style4">
                            First Name :
                        </td>
                        <td align="left" style="width: 190px;" class="b11">
                            <asp:TextBox ID="TxtFirstName" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvfirstname" runat="server"
                                    ControlToValidate="TxtFirstName" Display="None" 
                                ErrorMessage="Please Enter First Name" ValidationGroup="a" 
                                ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 150px;">
                            Middle Name:
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="TxtMiddleName" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a" ></asp:TextBox>
                            
                        </td>
                        <td align="left" class="b11">
                            Last Name :
                        </td>
                        <td align="left" class="b11">
                            <asp:TextBox ID="TxtLastName" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvlastname" runat="server" 
                                ErrorMessage="Please Enter Last Name" ControlToValidate="TxtLastName" Display="None" 
                                ValidationGroup="a" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                   
                    
                    <tr class="b11">
                     <td align="left" class="style4">
                            Sex :</td>
                        <td align="left" class="b11">
                           
                                <asp:DropDownList ID="ddlsex" runat="server" CssClass="dropdown3" 
                        ValidationGroup="a">
                           <asp:ListItem Value="0">--Select--</asp:ListItem>
                           <asp:ListItem Value="M" >Male</asp:ListItem>
                           <asp:ListItem Value="F" >Female</asp:ListItem>
                          </asp:DropDownList>
                            <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br />
                            <asp:RequiredFieldValidator ID="rfvsex" runat="server" 
                                ErrorMessage="Please select Sex" ControlToValidate="ddlsex" Display="None" 
                                ValidationGroup="a" InitialValue="0" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" class="b11">
                            Date of Birth :
                        </td>
                        <td align="left" class="b11">
                            <input type="text"  class="textbox2" id="txtDOB" readonly="readonly" runat="server" />
                             <span style="color: #9EC550;text-align: center; font-size: medium;">*</span>                      
                            <a id="DOB" runat="server" href="javascript:NewCal('txtDOB','DDMMMYYYY')">
                          <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                           
                            <asp:RequiredFieldValidator ID="rfvdob" CssClass="textbox" runat="server" ControlToValidate="txtDOB"
                                ErrorMessage="Select date of Birth" ValidationGroup="a" Display="None" 
                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" class="b11">
                            Place of Birth :
                        </td>
                        <td align="left" class="b11">
                             <asp:TextBox ID="txtplaceofbirth" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a" ></asp:TextBox>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvplaceofbirth" CssClass="textbox" 
                                 runat="server" ControlToValidate="txtplaceofbirth"
                                ErrorMessage="Please Enter Place of Birth" ValidationGroup="a" 
                                 Display="None" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  
                    <tr class="b11" CssClass="textbox" runat="server" id="tr2">
                        <td align="left" class="style3">
                            Marital Status :
                        </td>
                        <td align="left" style="width: 190px;">
                             <asp:DropDownList ID="ddlMS" runat="server" CssClass="dropdown3" 
                        ValidationGroup="a">
                           <asp:ListItem Value="0">--Select--</asp:ListItem>
                           <asp:ListItem >Married</asp:ListItem>
                           <asp:ListItem >Single</asp:ListItem>
                           <asp:ListItem >Divorcee</asp:ListItem>
                           <asp:ListItem >Seperated</asp:ListItem>
                           <asp:ListItem >Widow</asp:ListItem>
                   </asp:DropDownList>
                   <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                     <asp:RequiredFieldValidator ID="rfvmaritalstatus" CssClass="textbox" runat="server" ControlToValidate="ddlMS"
                                ErrorMessage="Please Select Marital Status" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" InitialValue="0" ForeColor="#9EC550"></asp:RequiredFieldValidator>      
                        </td>
                        <td align="left" style="width: 150px;">
                            Father's Name :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:TextBox ID="txtFatherName" CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvfathername" CssClass="textbox" 
                                runat="server" ControlToValidate="txtFatherName"
                                ErrorMessage="Please Enter Father Name" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" class="b11">
                            Mother's Name :
                        </td>
                        <td align="left" class="t11">
                            <asp:TextBox ID="txtMotherName"   CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvmothername" CssClass="textbox" 
                                runat="server" ControlToValidate="txtMotherName"
                                ErrorMessage="Please Enter Mother Name" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--Task1 changes : start--%>
                      <tr class="b11" cssclass="textbox">
                        <td align="left" class="style3">
                            Color Of Hair : 
                        </td>
                        <td align="left" style="width: 190px;">
                             <asp:DropDownList ID="ddlHairColor" runat="server" CssClass="dropdown3" 
                        ValidationGroup="a">
                           <asp:ListItem Value="0">--Select--</asp:ListItem>
                           <asp:ListItem Value="Black">Black</asp:ListItem>
                           <asp:ListItem Value="Brown">Brown</asp:ListItem>
                           <asp:ListItem Value="Gray">Gray</asp:ListItem>
                           <asp:ListItem Value="White">White</asp:ListItem> 
                           <asp:ListItem Value="Red">Red</asp:ListItem>    
                   </asp:DropDownList>
                    <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br />
                     <asp:RequiredFieldValidator ID="rfvHairColor" CssClass="textbox" runat="server" ControlToValidate="ddlHairColor"
                                ErrorMessage="Please Select Color Of Hair" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" InitialValue="0" ForeColor="#9EC550"></asp:RequiredFieldValidator>      
                        </td>
                       <td align="left" style="width: 150px;">
                            Color Of Eyes :
                        </td>
                        <td align="left" style="width: 190px;">
                             <asp:DropDownList ID="ddlEyeColor" runat="server" CssClass="dropdown3" 
                        ValidationGroup="a">
                           <asp:ListItem Value="0">--Select--</asp:ListItem>
                           <asp:ListItem Value="Black">Black</asp:ListItem>
                           <asp:ListItem Value="Brown">Brown</asp:ListItem>
                           <asp:ListItem Value="Blue">Blue</asp:ListItem>
                           <asp:ListItem Value="Gray">Gray</asp:ListItem>
                           <asp:ListItem Value="Green">Green</asp:ListItem>      
                   </asp:DropDownList>
                    <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br />
                     <asp:RequiredFieldValidator ID="rfvEyeColor" CssClass="textbox" runat="server" ControlToValidate="ddlEyeColor"
                                ErrorMessage="Please Select Marital Status" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" InitialValue="0" ForeColor="#9EC550"></asp:RequiredFieldValidator>      
                        </td>
                        <td align="left" class="b11">
                             Identification Marks :
                        </td>
                        <td align="left" class="t11">
                            <asp:TextBox ID="txtMark"   CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a" Width="188px"></asp:TextBox>
                                 <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="textbox" 
                                runat="server" ControlToValidate="txtMark"
                                ErrorMessage="Please Enter Identification Marks" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                
                         <tr class="b11" CssClass="textbox" runat="server" id="tr1">
                       
                        <td align="left" class="style4">
                             Height(in cm) :
                        </td>
                        <td align="left" class="t11">
                            <asp:TextBox ID="txtHeights"   CssClass="textbox2" runat="server"
                                MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="textbox" 
                                runat="server" ControlToValidate="txtHeights"
                                ErrorMessage="Please Enter Height" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--Task1 changes : End--%>
                    <tr class="b11" runat="server" id="tr3">
                        <td align="left" class="style3">Current Address :
                        </td>
                        <td align="left" colspan="2">                            
                          <asp:TextBox ID="txtcurrentadd" CssClass="MultiLine_Textbox" runat="server" ValidationGroup="a" Height="40px" TextMode="MultiLine"
                            Width="95%" onkeypress="return textboxMultilineMaxNumber(this,200)" MaxLength="200"></asp:TextBox>
                                <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br />
                                <asp:RequiredFieldValidator ID="rfvcurrentadd" CssClass="textbox" runat="server" ControlToValidate="txtcurrentadd"
                                ErrorMessage="Please Enter Current Address" ValidationGroup="a" Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                   </td>
                        <td align="left" >Permanent Address : </td>
                        <td align="left" colspan="2">
                            
                                 <asp:TextBox ID="txtPermanetadd" runat="server" CssClass="MultiLine_Textbox"
                                 ValidationGroup="a" Height="40px" TextMode="MultiLine" Width="95%" onkeypress="return textboxMultilineMaxNumber(this,200)"
                                MaxLength="200"></asp:TextBox>
                                  <span style="color: #9EC550; text-align: center; font-size: medium;">*</span><br />
                                <asp:RequiredFieldValidator ID="rfvpermanentaddress" CssClass="textbox" 
                                runat="server" ControlToValidate="txtPermanetadd"
                                ErrorMessage="Please Enter Permanent Address" ValidationGroup="a" 
                                 Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                </td>
                    </tr>
                   <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        If you have served in militery, please state
                                    </td>
                                </tr>
                                   <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        From Date :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtFromDate" readonly="readonly" style="border-width: 1px;
                                            width: 132px;" runat="server" />
                                        <a id="FromDate" runat="server" href="javascript:NewCal('txtFromDate','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        To Date :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtToDate" style="border-width: 1px; width: 131px;"
                                            readonly="readonly" runat="server" />
                                        <a id="ToDate" runat="server" href="javascript:NewCal('txtToDate','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                    <td align="left" class="b11">
                                        In :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtInMilitary" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                </tr>
                  
                    <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Give particulars of the employement of parents/spouse in Nigeria(If Applicable)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        Name Of Employer:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpName" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        Phone Number Of Employer:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpPhoneNo" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        How long your parents/spouse been in Nigeria(In Months):
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpLivedFrom" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr class="b11">
                                    <td align="left" class="style3">
                                        Address1:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpAddr1" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                       Address2:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpAddr2" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        City:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpCity" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        State:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpState" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        Country:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlEmpCountry" Enabled ="false"  runat="server" CssClass="dropdown3" ValidationGroup="a">
                                             <asp:ListItem Selected="True" Value="234">Nigeria</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        Postcode:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtEmpPostCode" CssClass="textbox2" runat="server" MaxLength="30" ValidationGroup="a"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Intended Address In Nigeria
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        Address1:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtIntededAddress1" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                        <asp:RequiredFieldValidator ID="rfvIntededAddress1" CssClass="textbox" runat="server"
                                            ControlToValidate="txtIntededAddress1" ErrorMessage="Please Enter Intended Address"
                                            ValidationGroup="a" Display="None" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        Address2:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtIntededAddress2" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        City:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtIntededCity" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                        <asp:RequiredFieldValidator ID="rfvIntededCity" CssClass="textbox" runat="server" ControlToValidate="txtIntededCity"
                                            ErrorMessage="Please Enter Intended City" ValidationGroup="a" Display="None"
                                            SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        State:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtIntededState" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                        <asp:RequiredFieldValidator ID="rfvIntededState" CssClass="textbox" runat="server" ControlToValidate="txtIntededState"
                                            ErrorMessage="Please Enter Intended state" ValidationGroup="a" Display="None"
                                            SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        Country:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlIntededCountry" runat="server" Enabled="false" CssClass="dropdown3"
                                            ValidationGroup="a">
                                            <asp:ListItem Selected="True" Value="234">Nigeria</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        District:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtIntededDistrict" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" style="width: 150px;">
                                        Postcode:
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtIntededPostcode" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Travel History
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3" colspan ="2">
                                        How long have you lived in the country from where you are applying for visa(In Years)
                                        ?
                                    </td>
                                    <td align="left" class="t11">
                                    <asp:TextBox ID="txtApplyCountryYears" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>                                      
                                             <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                        <asp:RequiredFieldValidator ID="rfvApplyCountryYears" CssClass="textbox" runat="server" ControlToValidate="txtApplyCountryYears"
                                            ErrorMessage="Please Enter you lived in the country from where you are applying for visa" ValidationGroup="a" Display="None"
                                            SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" style="width: 150px;" colspan ="2">
                                        Have you ever been infected by any contagious disease(e.g Turbeculosis) or suffered
                                        serious mental illness ?
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlSeriousDisease" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                          <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>                                      
                                    </td>
                                    </tr>
                                     <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                     <tr class="b11">
                                    <td align="left" style="width: 150px;" colspan ="2">
                                        Have you ever been arrested or convicated for an offence(even though subject to
                                        pardon)?
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlCrimeRecord" runat="server" CssClass="dropdown4" ValidationGroup="a">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                    </td>                             
                                    <td align="left" class="style3" colspan ="2">
                                        Have you ever been involved in narcotic activity?
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlDrugReport" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                    </td>
                                    </tr>
                                     <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                     <tr class="b11">
                                    <td align="left" style="width: 150px;" colspan ="2">
                                        Have you ever been deported?
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlDeported" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                    </td>
                                    <td align="left" style="width: 150px;" colspan ="2">
                                        Have you sought to obtain visa by mis-represantation or fraud?
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlFraudRecord" runat="server" CssClass="dropdown4" ValidationGroup="a">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                    </td>
                                </tr>
                                  <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                        
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Give a list of the countries you have visited in the last twelve(12) months :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Period1 :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        Country :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlLastVisitCountry1" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="b11">
                                        City :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtLastVisitCity1" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style3">
                                        Date Of Departure :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtLastVisitDeptDate1" readonly="readonly"
                                            style="border-width: 1px; width: 132px;" runat="server" />
                                        <a id="LastVisitDeptDate1" runat="server" href="javascript:NewCal('txtLastVisitDeptDate1','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Period2 :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        Country :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlLastVisitCountry2" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="b11">
                                        City :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtLastVisitCity2" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style3">
                                        Date Of Departure :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtLastVisitDeptDate2" readonly="readonly"
                                            style="border-width: 1px; width: 132px;" runat="server" />
                                        <a id="LastVisitDeptDate2" runat="server" href="javascript:NewCal('txtLastVisitDeptDate2','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Period3 :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                       Country :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlLastVisitCountry3" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="b11">
                                        City :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtLastVisitCity3" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style3">
                                        Date Of Departure :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtLastVisitDeptDate3" readonly="readonly"
                                            style="border-width: 1px; width: 132px;" runat="server" />
                                        <a id="LastVisitDeptDate3" runat="server" href="javascript:NewCal('txtLastVisitDeptDate3','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="height: 2px;">
                                        </td>
                                    </tr>
                                </tr>
                               
                               <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                        
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Give a list of the countries you have lived for more then one year :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Period1 :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        Country :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlLastLivedCountry1" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="b11">
                                        City :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtLastLivedCityName1" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style3">
                                        Date Of Departure :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtLastLivedDepartureDate1" readonly="readonly"
                                            style="border-width: 1px; width: 132px;" runat="server" />
                                        <a id="aLastLivedDepartureDate1" runat="server" href="javascript:NewCal('txtLastLivedDepartureDate1','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Period2 :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                        Country :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlLastLivedCountry2" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="b11">
                                        City :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtLastLivedCityName2" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style3">
                                        Date Of Departure :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtLastLivedDepartureDate2" readonly="readonly"
                                            style="border-width: 1px; width: 132px;" runat="server" />
                                        <a id="aLastLivedDepartureDate2" runat="server" href="javascript:NewCal('txtLastVisitDeptDate2','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" colspan="6">
                                        Period3 :
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" style="height: 2px;">
                                    </td>
                                </tr>
                                <tr class="b11">
                                    <td align="left" class="style3">
                                       Country :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:DropDownList ID="ddlLastLivedCountry3" runat="server" CssClass="dropdown3" ValidationGroup="a">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="b11">
                                        City :
                                    </td>
                                    <td align="left" class="t11">
                                        <asp:TextBox ID="txtLastLivedCityName3" CssClass="textbox2" runat="server" MaxLength="30"
                                            ValidationGroup="a"></asp:TextBox>
                                    </td>
                                    <td align="left" class="style3">
                                        Date Of Departure :
                                    </td>
                                    <td align="left">
                                        <input type="text" class="textbox2" id="txtLastLivedDepartureDate3" readonly="readonly"
                                            style="border-width: 1px; width: 132px;" runat="server" />
                                        <a id="aLastLivedDepartureDate3" runat="server" href="javascript:NewCal('txtLastVisitDeptDate3','DDMMMYYYY')">
                                            <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a><br />
                                    </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="height: 2px;">
                                        </td>
                                    </tr>
                                
                               
                    <tr >                    
                        <td colspan="6" align="center" style="height: 2px;">
                        </td>
                    </tr>
                    <tr align="left" class="t11">
                                    <td colspan="6" style="height: 2px;">
                                        <asp:CheckBox ID="chkAgree" runat="server" Text ="  I understand that I will be require to comply with immegration/alien and other laws governing entry of immegrants into the country to which I now apply for Visa/Entry permit." />
                                      
                                    </td>
                                </tr>
                                 <tr>
                                        <td colspan="6" align="center" style="height: 2px;">
                                        </td>
                                    </tr>
                    <tr>
                        <td colspan="6" align="center" style="height: 2px;">
                        <asp:Button ID="Submit" CssClass="subbtn1" runat="server" Text="Submit" 
                                ValidationGroup="a"   OnClientClick="javascript:check();" />&nbsp;                                
                            <asp:Button CssClass="subbtn1" ID="cancel" runat="server" Text="Cancel" 
                               />   
                        </td>
                    </tr>                                 
                    <tr class="b11">
						<td colspan="6" style="height: 10px">
							<asp:ValidationSummary ID="vsapplicantregister" runat="server" ValidationGroup="a" ShowMessageBox="True" ShowSummary="False" ForeColor="#9EC550" />
						</td>
					</tr>
                    <tr>
                        <td colspan="6" align="center" style="height: 2px;">
                        </td>
                    </tr>

                                   
                </table>           
             </center>
            </td>
          </tr>
       </table>
    
</div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        // window.history.back(1);
        if (window.history.length > 0) {
            window.history.go(4);
        }

        function DisplayPaperVisa(AppID) {
            window.open('FrmPrintPaperVisa.aspx?ApplicationId=' + AppID, 'PaperVisa', 'menubar=no,status=yes,Width=1000,Height=768,top=50,left=5');
        }
    </script>

    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/checkFileExt.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
    <script language="javascript" type="text/javascript">   
    </script>

    <style type="text/css">
        .style1
        {
            width: 80%;
        }
    </style>
    <style type="text/css">
        .style2
        {
            width: 35%;
        }
        .style3
        {
            width: 219px;
        }
        .style4
        {
            font-size: 11px;
            font-family: Arial;
            font-weight: bold;
            width: 219px;
        }
        </style>

</asp:Content>