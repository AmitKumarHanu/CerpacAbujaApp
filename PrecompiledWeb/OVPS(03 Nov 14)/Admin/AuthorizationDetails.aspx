<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_AuthorizationDetails, App_Web_authorizationdetails.aspx.fdf7a39c" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
  <style type="text/css">
      <style type="text/css"> 
      
<!-- 
.popup { 
      background-color: #DDD; 
      height: 300px; width: 500px; 
      border: 5px solid #666; 
      position: absolute; visibility: hidden; 
      font-family: Verdana, Geneva, sans-serif; 
      font-size: small; text-align: justify; 
      padding: 5px; overflow: auto; 
      z-index: 2; 
} 
.popup_bg { 
      position: absolute; 
      visibility: hidden; 
      height: 100%; width: 100%; 
      left: 0px; top: 0px; 
      filter: alpha(opacity=70); /* for IE */ 
      opacity: 0.7; /* CSS3 standard */ 
      background-color: #999; 
      z-index: 1; 
} 
       .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
      .abc {
      margin-top: -47px;
      margin-left: 249px;
      }
      .bcd {
       margin-top: -35px;
      margin-left: 249px;
      }
  </style>
  <link rel=Stylesheet type="text/css" href="../css/animate-custom.css" /> 
  <script type="text/javascript">
      function reason() {
          // document.getElementById('<%=authtable.ClientID %>').className = 'animated flipOutY';
          // 
          document.getElementById('<%=lblreason.ClientID %>').style.display = '';
          document.getElementById('<%=txtreason.ClientID %>').className = '';
          document.getElementById('<%=btnsubmit.ClientID %>').style.display = '';
          document.getElementById('<%=btnverify.ClientID %>').className = 'adminbutton animated fadeOutUpBig'; 
          document.getElementById('<%=btnbio.ClientID %>').className = 'adminbutton animated fadeOutUpBig';
          document.getElementById('<%=btnAppliHist.ClientID %>').className = 'adminbutton animated fadeOutUpBig';
          document.getElementById('deny').className = 'adminbutton animated fadeOutUpBig';
      }

      function change() {
          document.getElementById('<%=authtable.ClientID %>').className = 'animated-table fadeOutUp';
          document.getElementById('<%=loading.ClientID %>').style.display = '';

      }
      function openpopup(id) {
          //Calculate Page width and height 
          var pageWidth = window.innerWidth;
          var pageHeight = window.innerHeight;
          if (typeof pageWidth != "number") {
              if (document.compatMode == "CSS1Compat") {
                  pageWidth = document.documentElement.clientWidth;
                  pageHeight = document.documentElement.clientHeight;
              } else {
                  pageWidth = document.body.clientWidth;
                  pageHeight = document.body.clientHeight;
              }
          }
          //Make the background div tag visible... 
          var divbg = document.getElementById('bg');
          divbg.style.visibility = "visible";

          var divobj = document.getElementById(id);
          divobj.style.visibility = "visible";
          if (navigator.appName == "Microsoft Internet Explorer")
              computedStyle = divobj.currentStyle;
          else computedStyle = document.defaultView.getComputedStyle(divobj, null);
          //Get Div width and height from StyleSheet 
          var divWidth = computedStyle.width.replace('px', '');
          var divHeight = computedStyle.height.replace('px', '');
          var divLeft = (pageWidth - divWidth) / 2;
          var divTop = (pageHeight - divHeight) / 2 + 300;
          //Set Left and top coordinates for the div tag 
          divobj.style.left = divLeft + "px";
          divobj.style.top = divTop + "px";
          //Put a Close button for closing the popped up Div tag 
          if (divobj.innerHTML.indexOf("closepopup('" + id + "')") < 0)
              divobj.innerHTML = "<a href=\"#\" onclick=\"closepopup('" + id + "')\"><span class=\"close_button\">X</span></a>" + divobj.innerHTML;
      }
      function reject() {
          var a = document.getElementById('<%=txtreason.ClientID %>').value;
          if (a.options[a.selectedIndex].value == 0) {
              alert('Please give the reason for rejection');
              return false;
          }
          else
          {
              document.getElementById('<%=authtable.ClientID %>').className = 'animated-table fadeOutUp';
              document.getElementById('<%=tbl12.ClientID %>').className = 'animated-table fadeOutUp';
              document.getElementById('<%=loading.ClientID %>').style.display = '';
              document.getElementById('loader').innerHTML = 'Rejecting.Please wait.....';
              return true;
          }
      }
     
      
  </script>
    <style type="text/css">
        .a {
        display:none;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .information-box, .confirmation-box, .error-box, .warning-box {
	padding: 0.833em 0.833em 0.833em 3em; /* 10/12 36/12 */
	margin-bottom: 0.833em; /* 20/12 */ }

.confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
    font-size: 18px;
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
    width:55%;
}
    </style>
     <div id="popup1" class="popup">
			
		</div>
    <div id="Div_ContentPlaceHolder" align="center" class="bcolour">
        <table cellpadding="2" cellspacing="5" class="bcolour" style="width: 98%"  id="combox">
            <tr>
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Authorization&nbsp; Section</span></font></div>
                </td>
            </tr>
            <tr class="t11">
                <td align="center" colspan="2">
                    <asp:Label ID="reviewmsg" runat="server" ForeColor="#990000"></asp:Label>
                    <asp:Label ID="msg" runat="server" ForeColor="#339933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <center>
                        <table id="tbl12" cellpadding="5" cellspacing="2" border="0" width="750px" runat="server">
                            <tr class="b11">
                                <td align="center" style="width: 10%; vertical-align: middle; text-align: center;
                                    background-repeat: no-repeat;">
                                    <asp:Image runat="server" ID="ImgPhoto" Width="100px" Height="120px" ImageUrl="~/Images/Logo/default_logo.gif" />
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="loading" runat="server" style="display:none">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center><p id="loader">Authorization in progress.Please Wait. . . . .</p></td></tr>
                        </table>
                        <div id="authtable" runat="server" >
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="detailtable" runat=server>
                            <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Passport Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Passport No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtPassportNo" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Nationality
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtNationality" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Passport Issue By
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtPassportType" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Date Of Issue
                                </td>
                                <td align="left" style="width: 190px">
                                    <asp:Label ID="TxtDateOfIssue" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                             <td align="left" style="width: 150px;" class="b55">
                             Date of Expiry
                                </td>
                                <td align="left" style="width: 150px;">
                                <asp:Label ID=txtdoe runat=server CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Place of Issue
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtPlaceOfIssue" runat="server" CssClass="b99"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>

                                <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Bank Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    First Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtbankfname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Last Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtbanklname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Middle Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtbankmname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr class="b77"><td style="height:2px;" colspan="4"></td></tr>

                            <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Personal Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    First Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtFirstName" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Last Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtLastName" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Middle Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtMiddleName" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Sex
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtSex" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Email Id
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtemailprsn" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Contact Number
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcntcnoprsn" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Cerpac Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Cerpac Number
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtCerpacNo" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Cerpac Issue Date
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtIssueDate" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Cerpac Expiry Date
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtExpDate" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                 <td align="left" style="width: 150px;" class="b55">
                                    Cerpac File No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtfileno" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" class="b55">
                                    Zone Code
                                </td>
                                <td align="left" style="width: 190px;" ><asp:Label ID="txtZoneCode" runat="server" CssClass="b99" ></asp:Label>
                                </td>
                           <td align="left" class="b55">
                                    File No</td>
                                <td align="left" ><asp:Label ID="txtphyfileno" runat="server" CssClass="b99" ></asp:Label>
                                </td>
                           
                                 </tr>
                            
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                             <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Company Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Id
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompid" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Address 1
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompadd1" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Address 2
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompadd2" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Designation
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtdesig" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Telephone No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtphno" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Fax No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtfaxno" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                
                            </tr>
                        <!-- from here -->      
            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
            </tr>
                            <tr >
                                <td align="left" class="b77">Previous Notes</td>
                <td colspan="3" align="left" style="height: 20px;"><asp:TextBox ID="txtprevnote" runat="server" Height="43px" Width="548px"></asp:TextBox>
                    </td>
            </tr>
                            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
            </tr>
                            <tr >
                                <td align="left" class="b77">Notes</td>
                <td colspan="3" align="left" style="height: 20px;"><asp:TextBox ID="txtauthnotes" runat="server" Height="43px" Width="548px"></asp:TextBox>
                    </td>
            </tr>
                            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
            </tr>
            <!-- till here -->
           
             <tr class="b11">
             <td align=left><asp:Label ID=lblreason Text="Rejection Reason" style="display:none;" runat=server></asp:Label> </td>
                <td colspan="2" align="left">
               <asp:DropDownList ID="txtreason" CssClass="a" runat="server" Height="21px" Width="141px"></asp:DropDownList>
                    </td>
                    <td align=center><asp:Button ID="btnsubmit" runat=server Text="Submit" width=149px
                            CssClass=adminbutton onclick="btnsubmit_Click" style="display:none;" OnClientClick="sreject()" /></td>
            </tr> 
            
            
            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
            </tr>
            <tr class="b11" align="center">
                <td align="center" colspan="1">
                    <asp:Button ID="btnverify" runat="server" class="adminbutton" Text="Authorize"  
                        Width="140px" onclick="btnverify_Click" OnClientClick="change();" />
                    <%//  %>
                </td>
                <td align="center" colspan="1">
                <input type="button" id="deny" value="Deny" class=adminbutton onclick="reason()" style="width:149px;" />
                    
                    
                </td>
                 <td align="center" colspan="1">
                    <asp:Button ID="btnAppliHist" runat="server" class="adminbutton" 
                         Text="Applicant History" OnClick="btnAppliHist_Click"/>
                    
                </td>
                <td align="center" colspan="1">
                    <asp:Button ID="btnbio" runat="server" class="adminbutton" 
                         Text="Retrieve Bio Metrics" onclick="btnbio_Click"/>
                    
                </td>
            </tr>
            <tr><td height="25px">&nbsp;</td></tr>
        </table>

                            </div>


       <tr><td align=center><div height=10px style="display:none;" id=confirm  runat=server><p style="color:#006600" id="p" runat=server>
           <asp:Image runat="server" ImageUrl="~/Images/stamp.png" ID="imgapproved" Height="105px" Width="296px"/></p>
           <br /><asp:Image ID="img_sign" runat="server" ImageUrl="" Height="37px" Width="150px" CssClass="abc"/>
           <br /><br /><asp:Label ID="lblname" runat="server" CssClass="bcd" Text="(abc)" Visible="false"></asp:Label>
        </div></td></tr>
        <tr><td align=center><div class="warning-box" height=10px style="display:none;" id=warn  runat=server><p style="color:#A0522D"><strong>CERPAC Number has been authorized</strong></p></div></td></tr>
        </center> </td> </tr>
            <tr><td height="20"></td></tr>
        </table>
    </div>
</asp:Content>

