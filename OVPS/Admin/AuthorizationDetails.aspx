<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="AuthorizationDetails.aspx.cs" Inherits="Admin_AuthorizationDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <link rel=Stylesheet type="text/css" href="../css/animate-custom.css" /> 
      <style type="text/css"> 
      

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
     <script type="text/javascript">
        
         function dtval(d, e) {
             var pK = e ? e.which : window.event.keyCode;
             if (pK == 8) { d.value = substr(0, d.value.length - 1); return; }
             var dt = d.value;
             var da = dt.split('-');
             for (var a = 0; a < da.length; a++) { if (da[a] != +da[a]) da[a] = da[a].substr(0, da[a].length - 1); }
             if (da[0] > 31) { da[1] = da[0].substr(da[0].length - 1, 1); da[0] = '0' + da[0].substr(0, da[0].length - 1); }
             if (da[1] > 12) { da[2] = da[1].substr(da[1].length - 1, 1); da[1] = '0' + da[1].substr(0, da[1].length - 1); }
             if (da[2] > 9999) da[1] = da[2].substr(0, da[2].length - 1);
             dt = da.join('-');
             if (dt.length == 2 || dt.length == 5) dt += '-';
             d.value = dt;
         }
</script>

 
  <script type="text/javascript">
      function reason() {
          // document.getElementById('<%=DivAuthRecord.ClientID %>').className = 'animated flipOutY';
          // 
          document.getElementById('<%=lblreason.ClientID %>').style.display = '';
          document.getElementById('<%=txtReason.ClientID %>').className = '';
          document.getElementById('<%=btnsubmit.ClientID %>').style.display = '';
          document.getElementById('<%=btnverify.ClientID %>').style.display = false; 
          document.getElementById('<%=btnbio.ClientID %>').style.display = false; 
          document.getElementById('<%=btnAppliHist.ClientID %>').style.display = false; 
          document.getElementById('deny').className = 'adminbutton animated fadeOutUpBig';
      }

      function change() {
          document.getElementById('<%=DivAuthRecord.ClientID %>').className = 'animated-table fadeOutUp';
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
          var a = document.getElementById('<%=txtReason.ClientID %>').value;
          if (a.options[a.selectedIndex].value == 0) {
              alert('Please give the reason for rejection');
              return false;
          }
          else
          {
              document.getElementById('<%=DivAuthRecord.ClientID %>').className = 'animated-table fadeOutUp';
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
        .auto-style1 {
            height: 41px;
        }
    </style>
     <div id="popup1" class="popup">
			
		</div>
    <div id="Div_ContentPlaceHolder" align="center" class="bcolour">
        <table cellpadding="2" cellspacing="5" class="bcolour" align="center"  style="width: 100%"  id="combox">
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
                        
          <div id="DivAuthDetails" runat="server" align="center" >
          <table id="tbl12" cellpadding="5" cellspacing="2" border="0" width="750px" runat="server">
                            <tr class="b11">
                                <td align="center" style="width: 10%; vertical-align: middle; text-align: center; background-repeat: no-repeat;">
                                
                                    <asp:UpdatePanel runat="server"  ID="UpdatePic" UpdateMode="Conditional" >
                            <ContentTemplate>
                                <center>
                            <div id="DivPic" style="position:relative; width:50%;" >
                                <img src="~/Images/Logo/Pic_Format.png" alt="" id="fimg"   style=" height:185px; top: 0px; left: 26%;  position:absolute; width:185px; border-radius: 6px;  border: 2px solid #000;" />
                                <asp:Image runat="server" ID="ImgPhoto"   ImageUrl="~/Images/Logo/default_logo.gif" style="margin-left:5px; margin-top: 1px; border-width:0px; z-index:1;" width="185px" Height="185px"  />
                             </div>
                                  </center> 
                          </ContentTemplate>

             </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        </div>
          <div id="DivLoader" runat="server" align="center"  style="display:block;">
                        <table cellpadding="5" align="center" cellspacing="2" border="0" width="100%" id="loading" runat="server" style="display:none">
                            <tr><td align="center"><img src="../Images/loading.gif" /></td></tr>
                            <tr><td height="10"></td></tr>
                            <tr><td align="center"><p id="loader">Authorization in progress.Please Wait. . . . .</p></td></tr>
                        </table>
                            </div>
          <div id="DivAuthRecord" runat="server" align="center"  >
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="detailtable" runat="server">
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
                            <tr id="trHQAuth" runat="server">
                                <td align="left" class="b55">Headquarter Command Apprival </td>
                <td colspan="3" align="left" style="height: 20px;"><asp:Label ID="lblHeadQuatorAuth" runat="server" CssClass="b99"></asp:Label>
                    <asp:Label ID="lblHeadDate" runat="server" CssClass="b99"></asp:Label>
                    </td>
            </tr>
                            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
            </tr>
                            <tr id="trSCAuth" runat="server" >
                                <td align="left" class="b55">State Command Apprival </td>
                <td colspan="3" align="left" style="height: 20px;"><asp:Label ID="lblStateCommadAuth" runat="server" CssClass="b99"></asp:Label>
                    <asp:Label ID="lblStateDate" runat="server" CssClass="b99"></asp:Label>
                    </td>
            </tr>
                            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
            </tr>
            <!-- till here -->
           <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr> 
           <tr id="trBtn" runat="server" style="display:block; align-items:center">
              
               <td colspan="4"><asp:Button ID="btnProceedAuthorize" runat="server" class="adminbutton" Text="Cross Validation"  Visible="false"
                        OnClientClick="change();" OnClick="btnProceedAuthorize_Click" /></td>
             
           </tr>
                            </table>
                         </div>
          <div id="DivCrossValidation" runat="server" align="center" style="display:block"  >
          <table  cellpadding="2" cellspacing="5" class="bcolour" style="text-align: center; width:100%; border: 2px solid Gray; padding: 10px; border-radius: 25px;" id="combox">
                    <tr>
               <td colspan="4">
                    <div class="PageNameHeadingCSS" style="text-align: center;">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Cross Data Validation&nbsp; Section</span></font></div>
               </td>
           </tr>
     <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
                                 <tr>
               <td></td>
                <td align="left" style="width: 150px;" class="b55"> First Name </td>
                <td align="left" style="width: 190px;"> <asp:Label ID="ePassFristName" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
           </tr>
                                 <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
            <tr>
               <td></td>
               <td align="left" style="width: 150px;" class="b55"> Last Name </td>
               <td align="left" style="width: 190px;"> <asp:Label ID="ePassLastName" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
             </tr>
          <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
            </tr>
             <tr>
               <td></td>
               <td align="left" style="width: 150px;" class="b55"> Passport No. </td>
              <td align="left" style="width: 190px;"> <asp:Label ID="ePassPassportNo" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
           </tr>
         <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
<tr>
               <td></td>
               <td align="left" style="width: 150px;" class="b55"> Nationality </td>
               <td align="left" style="width: 190px;"> <asp:Label ID="ePassNationality" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
           </tr>
              <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
              <tr>
               <td></td>
              <td align="left" style="width: 150px;" class="b55"> Port of Entry </td>
               <td align="left" style="width: 190px;"> <asp:Label ID="ePassPortofEntry" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
           </tr>
               <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
              <tr>
               <td></td>
              <td align="left" style="width: 150px;" class="b55"> Arrival Date </td>
              <td align="left" style="width: 190px;"> <asp:Label ID="ePassArrivalDate" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
           </tr>
              <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
                <tr>
               <td></td>
              <td align="left" style="width: 150px;" class="b55"> VISA Category </td>
              <td align="left" style="width: 190px;"> <asp:Label ID="ePassVISACategory" runat="server" CssClass="b99"></asp:Label></td>
               <td></td>
           </tr>
         <tr>
               <td></td>
               <td></td>
               <td></td>
               <td></td>
           </tr>
               </table>
          </div>  

          <div id="DivBtn" runat="server" align="center" >
         <table  cellpadding="2" cellspacing="5" class="bcolour" style="text-align: center;" >
             <tr  id="trDeny" runat="server" cellpadding="2" cellspacing="5" class="bcolour"  style="text-align: center; width:100%; border: 2px solid Gray; padding: 10px; border-radius: 25px;" >
             <td align="right"><asp:Label ID="lblreason" Text="Rejection Reason"  runat="server"></asp:Label> </td  >
             <td colspan="2" align="left" >
                        <asp:TextBox ID="txtReason" runat="server"   Width="80%"></asp:TextBox>  
                      <asp:RequiredFieldValidator ID="ReqReason" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtReason"  validationgroup="grpItemDeny" setfocusonerror="True"  >
                                 </asp:RequiredFieldValidator></td>
             <td align="center">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" width="149px" CssClass="adminbutton" validationgroup="grpItemDeny" OnClick="btnsubmit_Click"   /></td>
            </tr>         
            
          
            <tr  align="center"  id="trBtnOption" runat="server" class="bcolour"  style="text-align: center; width:50%; border: 2px solid Gray; padding: 10px; border-radius: 25px;" >
                <td align="center" colspan="1">
                    <asp:Button ID="btnverify" runat="server" class="adminbutton" Text="Authorize"  
                        Width="140px" onclick="btnverify_Click" OnClientClick="change();" />
                   
                </td>
                <td align="center" colspan="1">
                <asp:Button ID="btnDeny" runat="server" class="adminbutton" Text="Deny"  Width="140px" OnClick="btnDeny_Click"  OnClientClick="change();" /> 
                    
                </td>
                 <td align="center" colspan="1">
                    <asp:Button ID="btnAppliHist" runat="server" class="adminbutton" 
                         Text="Applicant History"  OnClientClick="change();"  OnClick="btnAppliHist_Click"/>
                    
                </td>
                <td align="center" colspan="1">
                    <asp:Button ID="btnbio" runat="server" class="adminbutton" 
                         Text="Retrieve Bio Metrics" OnClientClick="change();"  onclick="btnbio_Click"/>
                    
                </td>
            </tr>
            
        </table>
          </div> 
          <div id="DivApproved" runat="server" align="center" >
              <table  cellpadding="2" cellspacing="5" class="bcolour" style="text-align: center; width:70%; border: 2px solid Gray; padding: 10px; border-radius: 25px;" > 
                <tr>
           <td align="center">
               <div height=10px style="display:block;" id=confirm  runat=server><p style="color:#006600" id="p" runat=server>
           <asp:Image runat="server" ImageUrl="~/Images/stamp.png" ID="imgapproved" Height="105px" Width="296px"/></p>
           <br /><asp:Image ID="img_sign" runat="server" ImageUrl="" Height="37px" Width="150px" CssClass="abc"/>
           <br /><br /><asp:Label ID="lblname" runat="server" CssClass="bcd" Text="(abc)" Visible="false"></asp:Label>
        </div></td></tr>
                 <tr>
            <td align="center">
                <div class="warning-box" height="10px" style="display:block;" id="warn"  runat="server">
                    <p style="color:#A0522D"><strong>CERPAC Number has been authorized</strong></p>

                </div>

            </td>

        </tr>
                  </table>
            </div>

          <div id="DivePassMsg" runat="server" align="center"  style="display:block">
            <table  cellpadding="2" cellspacing="5" class="bcolour" style="text-align: center; width:70%; border: 2px solid Gray; padding: 10px; border-radius: 25px;" >
            <tr>
        <td align="center" class="auto-style1">
                </td></tr>
                <tr>
        <td align="center">
            <div  class="warning-box" height="10px" style="display:block;" id="warn1"  runat="server" >
                <p style="color:#A0522D"><strong>The arrival information does not exist</strong></p>

            </div>

        </td>

    </tr>
                </table>
        </div>

          <div id="DivFreshAuth" runat="server" align="center"  style="display:block">
                    <table cellpadding="2" cellspacing="10" align="center"  class="bcolour" style="text-align: center; width:90%; border: 2px solid Gray; padding: 10px; border-radius: 25px;" >
                        <tr>                             
                             <td style="height: 24px;" colspan="4" align="center">
                                 <div  style="text-align: center">
                                 <font class="b12"><span style="font-size: 16px; ">&nbsp; Fresh Case Application Approval &nbsp;</span></font>
                                 </div>
                             </td>
                          </tr>
                        <tr align="left">
                            <td style="width: 40%" class="b12" align="left">Cerpac No.</td>                             
                            <td> <asp:Label ID="lblCerpacNoAuth" runat="server" CssClass="b99"></asp:Label></td>
                            <td><asp:Label ID="lblZoneNameAuth" runat="server" Visible="false" CssClass="b99"></asp:Label></td>
                            <td></td>
                        </tr>
                         <tr align="left">
                            <td style="width: 40%" class="b12" align="left">Bank From No.</td>                             
                            <td> <asp:Label ID="lblFormNoAuth" runat="server" CssClass="b99"></asp:Label></td>
                            <td><asp:Label ID="lblZoneCodeAuth" runat="server" Visible="false" CssClass="b99"></asp:Label></td>
                            <td></td>
                        </tr>
                         <tr>
                             <td style="width: 40%" class="b12" align="left">HeadQuarter Authorization</td>
                             <td class="b12">
                                <asp:DropDownList ID="ddlHQAuthority" runat="server" TabIndex="0" Width="150px" Height="25px" CssClass="textbox2" >
                                <asp:ListItem Enabled="true" Text="-Select Authority-" Value="-1" ></asp:ListItem>                                
                                <asp:ListItem Text="A.C.G" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="ReqHQAuthority" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlHQAuthority" InitialValue="-1" validationgroup="grpItem" setfocusonerror="True"  >
                                 </asp:RequiredFieldValidator>
                             </td>
                            
                             <td align="right" >
                                 <asp:TextBox ID="txtHQDate" runat="server" Width="150px" Height="20px" placeholder="DD-MM-YYYY" onkeyup="dtval(this,event)" Enabled="true" CssClass="textbox2" AutoComplete="off" TabIndex="1" ></asp:TextBox>
                                  
                             </td>

                              <td  align="left"  class="b12"><asp:RequiredFieldValidator ID="ReqHQDate" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtHQDate" validationgroup="grpItem" setfocusonerror="True" ></asp:RequiredFieldValidator>
                               <a id="A1" runat="server" href="javascript:NewCal('txtHQDate','DDMMMYYYY')"> <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                           
                              
                             </td>
                         </tr>
                         <tr>
                              <td  class="b12" align="left">State Command Authorization</td>                            
                             <td  class="b12">  <asp:DropDownList ID="ddlSCAuthority" runat="server" TabIndex="2" Width="150px" Height="25px" CssClass="textbox2" >
                                <asp:ListItem Enabled="true" Text="-Select Authority-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="C.I.S" Value="1"></asp:ListItem>
                                <asp:ListItem Text="D.C.I" Value="2"></asp:ListItem>                                 
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqSCPurpose" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlSCAuthority" InitialValue="-1" validationgroup="grpItem" setfocusonerror="True" >
                                </asp:RequiredFieldValidator>

                             </td>
                             <td align="right"  > 
                                    <asp:TextBox ID="txtSCDate" Width="150px" Height="20px" runat="server" placeholder="DD-MM-YYYY" onkeyup="dtval(this,event)" Enabled="true" CssClass="textbox2" AutoComplete="off" TabIndex="3" ></asp:TextBox>
                                </td>

                             <td " align="left"  class="b12"><asp:RequiredFieldValidator ID="ReqSCDate" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtSCDate" validationgroup="grpItem" setfocusonerror="True" ></asp:RequiredFieldValidator>
                            <a id="A2" runat="server" href="javascript:NewCal('txtSCDate','DDMMMYYYY')"> <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                           
                       </td >
                         </tr>
                         <tr>
                             
                             <td style="height: 24px;" colspan="4" align="center"></td>
                          </tr>
                         <tr>
                             
                             <td style="height: 24px;" colspan="4" align="center">
                                <asp:Button ID="BtnAuth" runat="server" Text="Ok" TabIndex="4" CssClass="adminbutton" validationgroup="grpItem" OnClick="BtnAuth_Click" />
                                <asp:Button ID="BtnBack" runat="server" Text="Back" TabIndex="5" CssClass="adminbutton" OnClick="BtnBack_Click" />
                             </td>
                             
                         </tr>
                          
                     </table>
                        </div>

                    </center>
                    </td>
                </tr>
              
        </table>
    </div>
</asp:Content>

