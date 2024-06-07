<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmTestPrint.aspx.cs" Inherits="Admin_frmTestPrint" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<link rel="shortcut icon" type="images/ico" href="../images/favi-icon.png" />
<link href="../css/minicart.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="../css/product-ensemble-styles.jsp" type="text/css" media="all"/>
<link href="../css/left_sty.css" rel="stylesheet" type="text/css" />	

<link rel="stylesheet" type="text/css" href="../css/ims_motif_styles.jsp" />

<link rel="stylesheet" href='../css/style.css' type="text/css" media="all"/>
<link rel="stylesheet" href="../css/countryPrint.css" type="text/css" media="print"/>
<link media="all" type="text/css" href="../css/video.css" rel="stylesheet">

	

<link type="text/css" media="screen" href="../css/autosuggest.css" rel="stylesheet">

<link media="all" type="text/css" href="../css/quickview.css" rel="stylesheet">
<link href="../css/country.css" rel=Stylesheet type="text/css" /> 

<link rel="stylesheet" href="../css/country.css" type="text/css" media="all"/>

<link rel="stylesheet" type="text/css" href="../engine1/style.css" />
    <link href="../ddmenu/ddmenu.css" rel="stylesheet" type="text/css" />
    <script src="../ddmenu/ddmenu.js" type="text/javascript"></script>

<script type="text/javascript" src="../engine1/jquery.js"></script>

    
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" />





    <script type="text/javascript" src="jquery-1.4.2.min.js"></script>
    
       <script type="text/javascript" src="image/gr.js"></script>


    
<%--<script type="text/javascript" src="http://cloud.github.com/downloads/malsup/cycle/jquery.cycle.all.latest.js"></script>--%>

    <script language="javascript">
        function PrintContent() {
            var html = "<html>";
            html += document.getElementById("bill_print").innerHTML;
            html += "</html>";

            var printWin = window.open('', '', 'location=no,width=10,height=10,left=50,top=50,toolbar=no,scrollbars=no,status=0,titlebar=no');

            printWin.document.write(html);
            printWin.document.close();
            printWin.focus();
            printWin.print();
            printWin.close();
        }


</script>

<script type="text/javascript">

    $(document).ready(function () {

        $('#testimonials1')

        .before('<div id="nav">')

        .cycle({

            fx: 'fade', // choose your transition type, ex: fade, scrollUp, scrollRight, shuffle

            // pager:  '#nav',

            timeout: 1000

        });



        $('#testimonials2')

      .after('<div id="nav2">')

      .cycle({

          fx: 'scrollRight', // choose your transition type, ex: fade, scrollUp, scrollRight, shuffle

          //	pager:  '#nav2'

      });

    });

</script>
   

  <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
<script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
<link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
<link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css"><strong></strong>


  <style type="text/css"> 
      
       .style12
        {
            width: 1px;
        }
        
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
        .information-box, .confirmation-box, .error-box, .warning-box {
	padding: 0.833em 0.833em 0.833em 3em; /* 10/12 36/12 */
	margin-bottom: 0.833em; /* 20/12 */ }

.confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
	align:center;
    font-size: 18px;
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
}
.close_button { 
      font-family: Verdana, Geneva, sans-serif; 
      font-size: small; font-weight: bold; 
      float: right; color: #666; 
      display: block; text-decoration: none; 
      border: 2px solid #666; 
      padding: 0px 3px 0px 3px; 
} 
body { margin: 0px; } 
      .auto-style1 {
          height: 74px;
      }
      --> 
</style><script language="javascript">
            function openpopup(id) {
                //Calculate Page width and height 
                document.getElementById('<%=txt_reprint_card_serial_no.ClientID%>').value = document.getElementById('<%=txt_cerpac_serial_no.ClientID%>').value
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
    function closepopup(id) {
        var divbg = document.getElementById('bg');
        divbg.style.visibility = "hidden";
        var divobj = document.getElementById(id);
        divobj.style.visibility = "hidden";
    } 

</script>
    



    <script type="text/javascript" src="../engine1/wowslider.js"></script>
	<script type="text/javascript" src="../engine1/script.js"></script>
    <SCRIPT>
        $("#accordion > li > div").click(function () {

            if (false == $(this).next().is(':visible')) {
                $('#accordion ul').slideUp(300);
            }
            $(this).next().slideToggle(300);
        });

        $('#accordion ul:eq(0)').show();

</SCRIPT>

     <script type = "text/javascript">
         function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("You have already fired print command but status of printout is pending! Update Status.")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
                 PrintContent();
             }
             document.forms[0].appendChild(confirm_value);
         }


         Ext.onReady(function(){
             Ext.get('mb1').on('click', function(e){
                 Ext.MessageBox.confirm('Confirm', 'Are you sure you want to do that?', showResult);
             })});

    </script>

<script type="text/javascript">
    var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
    

    <style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: transparent;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 60%;
        width: 60%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        /*border: 5px solid #67CFF5;*/
        width: 650px;
        vertical-align:text-top !important;
     
    
        position: absolute;

        top: 254px!important;
height: 600px;
display: none;
margin-left: 92px !important;


        background-color: lightgrey;
        z-index: 999;
    }


     .loading_other
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
    </style>

 <script type="text/javascript" src="../JS/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            location.href = '#top';
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });

        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>

   
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
       <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>--%>
                        <div id="div_load" class="loading" align="center" runat="server">
   
                            
    <img src="../Images/load1.gif" alt="" />

    Chip Encoding In Progress.....
</div>




<%--</ContentTemplate></asp:UpdatePanel>--%>


                <div id="popup1" class="popup">
			<table  id="tab1" width="100%">
				<tr>
					<td colspan="5" style="text-align: center">
						<%--<asp:Label ID="lbl_heading" runat="server" Text="Reason of Re-Print" Font-Bold="true"></asp:Label>--%>

                         <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Re-Print Card &nbsp; </span>
                        </font>
                    </div>
					</td>

                    

                   
				</tr>
				<tr>
					<td>
						
						<%--<a href="#" onclick="hide('popDiv')">Close</a>--%>


					</td>

                    <td></td>
                    <td></td>
                    <td></td>

                    <td></td>
				</tr>

                 <tr>
                 <td></td>
                <td>
                    
                 <asp:Label ID="lbl_reprint_card_serial_no" runat="server" Text="Enter the spoil card No." Font-Bold="true"></asp:Label>

                 
                </td>
                     
                   <td style="font-weight:bold;"></td>
<td><asp:TextBox ID="txt_reprint_card_serial_no" runat="server" Style="margin-left: 22px; Color:#00CC00;" Font-Bold="true"></asp:TextBox></td>
<td></td>
                </tr>

                <tr>
                <td></td>
                <td>
                    
                 <asp:Label ID="Label6" runat="server" Text="Enter The Spoil Lamination No." Font-Bold="true"></asp:Label>
                                  
                </td>
                
                <td style="font-weight:bold;"></td>
<td>
<asp:TextBox style="margin-left:22px;" ID="txt_lam_front" runat="server" AutoComplete="Off" AutoPostBack="False" placeholder="Front"  Width="100px"></asp:TextBox>
                 <asp:TextBox style="margin-left:22px;" ID="txt_lam_back" runat="server" AutoComplete="Off" AutoPostBack="False" placeholder="Back"  Width="100px"></asp:TextBox>
                
</td>
<td></td>

                </tr>


                <tr>
                <td></td>
                <td valign="top"><asp:Label ID="lbl_reason" runat="server" Text="Re-Print Reason" Font-Bold="true"></asp:Label></td>

                <td style="font-weight:bold;" align="center"></td>

                <td style="float: right;
margin-right: 215px;">

             
                    <asp:RadioButton ID="Rd1" runat="server" GroupName="AB" Text="Printing Error" Checked="true"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd2" runat="server" GroupName="AB" Text="Chip Encoding Error"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd3" runat="server" GroupName="AB" Text="Lamination Error"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd4" runat="server" GroupName="AB" Text="Others"/>
                
                
                        
                        </td>

                <td></td>
                </tr>

                <tr>
					<td></td>

                    <td></td>
                    <td colspan="2">
                    
                    <asp:Button ID="btn_Reason_Print" runat="server"  
                        Text="Ok" class="adminbutton" onclick="btn_Reason_Print_Click" UseSubmitBehavior="false" />

                        &nbsp;&nbsp;&nbsp;

                     

                        <input type="button" id="btn_cancel" runat="server"  value="Cancel" class="adminbutton" onclick="closepopup('popup1')"/>

                    </td>
                    <td></td>

                    <td></td>
				</tr>

			</table>
		</div>

    <%--<div id="bill_print" style="display:none;">

    <table style="font-family: Verdana; left: 20px; position: relative; top: 38px;">
       
      
    <tr>
    <td  rowspan="6" valign="middle" align="left" class="auto-style2">
        <img id="ImgPhoto2" alt="Img" src="Saurabh.jpg" runat="server" style="border:3px solid #006600; height: 94px; width: 85px; left: -4px; position: relative; top: -36px;" /><br />
       </td>

         <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label5" runat="server" Text="Name"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_name_1" runat="server" Text="Saurabh Bansal" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>

   
    
    </tr>

     <tr>
    <td class="style11" valign="top" colspan="2">
        
     <asp:Label ID="Label1" runat="server" Text="Passport No." Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
        <br />
        <asp:Label ID="txt_pass_no" runat="server" Text="J284455" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    
    </td>
   
    </tr>

        <tr>
    <td class="style11" valign="top" colspan="2">
      
     <asp:Label ID="Label11" runat="server" Text="Nationality" Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_nationality_4" runat="server" Text="Indian" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
   
    </tr>    
<tr style="display:none;">
    <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label7" runat="server" Text="DOB"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
         <asp:Label ID="txt_dob_2" runat="server" Text="25 Dec 82"  Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
    
    </tr>

        <tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="lbl_comp" runat="server" Text="Company" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_comp" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>

<tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="Label9" runat="server" Text="Designation" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_desig_3" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>



                                <tr>
                                 
                                  <td style="text-align: center" colspan="3" class="auto-style1">
                                
                                    <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  <tr>
                                 <td class="auto-style3"></td>
                                  <td style="text-align: left; font-size:smaller;"  class="auto-style4" valign="top" colspan="2">
                                       <asp:Image ID="img_sign_card" runat="server" Height="39px" Width="176px"/>
                           
                                     
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>


                               
        
         <tr>
                                 
                                  <td style="text-align: left; vertical-align:top;" colspan="3" class="auto-style5">
                                
                                      
                                      <asp:Label ID="Label2" runat="server" Text="FOR COMPTROLLER-GENERAL," Font-Size="9px"></asp:Label><br />
                                      <asp:Label ID="Label3" runat="server" Text="NIGERIA IMMIGRATION SERVICE" Font-Size="9px"></asp:Label>
                                      
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                       
                                   <td style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td colspan="2" style="text-align: left;font-size:x-small;" align="left" class="style12">Cerpac No.:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                  
                                  <asp:Label ID="txt_cer_no_5" runat="server" Text="AO455877" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  
                                   <tr>
                                       
                                   <td  style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td colspan="2" style="text-align: left;font-size:x-small;" align="left" class="style12">Date Of Issue:&nbsp;
                                      
                                 <asp:Label ID="txt_date_of_issue_6" runat="server" Text="9 Jul 13" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  

                                   <tr>
                                       
                                   <td  style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td colspan="2" style="text-align: left;font-size:x-small;" align="left" class="style12">Place Of Issue:
                                 <asp:Label ID="txt_place_of_issue_7" runat="server" Text="Abuja" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                      
                                  

                                  <tr>
                                      
                                  <td  style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td colspan="2" style="text-align: left;font-size:x-small;" align="left" class="style12" >Date Of Expiry:
                                    
                                    
                                 <asp:Label ID="txt_date_of_exp_8" runat="server" Text="1 Nov 13" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                 
                                  </tr>


    </table>
 </div>--%>


     <div id="bill_print" style="display:block;">

    <%--<table style="font-family: Verdana; left: 20px; position: relative; top: 38px;">
       
      
    <tr>
    <td  rowspan="6" valign="middle" align="left" class="auto-style2">
        <img id="ImgPhoto2" alt="Img" src="Saurabh.jpg" runat="server" style="border:3px solid #006600; height: 94px; width: 85px; left: -4px; position: relative; top: -34px;" /><br />
       </td>

         <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label5" runat="server" Text="Name"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_name_1" runat="server" Text="Saurabh Bansal" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>

   
    
    </tr>

     <tr>
    <td class="style11" valign="top" colspan="2">
        
     <asp:Label ID="Label1" runat="server" Text="Passport No." Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
        <br />
        <asp:Label ID="txt_pass_no" runat="server" Text="J284455" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    
    </td>
   
    </tr>

        <tr>
    <td class="style11" valign="top" colspan="2">
      
     <asp:Label ID="Label11" runat="server" Text="Nationality" Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_nationality_4" runat="server" Text="Indian" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
   
    </tr>    
<tr style="display:none;">
    <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label7" runat="server" Text="DOB"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
         <asp:Label ID="txt_dob_2" runat="server" Text="25 Dec 82"  Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
    
    </tr>

        <tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="lbl_comp" runat="server" Text="Company" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_comp" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>

<tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="Label9" runat="server" Text="Designation" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_desig_3" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>



                                   <tr>
                                 
                                  <td style="text-align: center" colspan="3" class="auto-style1">
                                
                                    <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  <tr>
                                 <td class="auto-style3"></td>
                                  <td style="text-align: left; font-size:smaller;"  class="auto-style4" valign="top" colspan="2">
                                       <asp:Image ID="img_sign_card" runat="server" Height="39px" Width="176px"/>
                            
                                     
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>


                               
        
         <tr>
                                 
                                  <td style="text-align: right; vertical-align:top;" colspan="3" class="auto-style5">
                                
                                      
                                       <asp:Label ID="Label2" runat="server" Text="FOR COMPTROLLER-GENERAL," Font-Size="8.5px" Font-Bold="true"></asp:Label><br />
                                      <asp:Label ID="Label3" runat="server" Text="NIGERIA IMMIGRATION SERVICE" Font-Size="8.5px" Font-Bold="true"></asp:Label>
                                       <br />
                                      
                                      </td>
                                 
                                  
                                 
                                  </tr>


 
 
    <tr><td colspan="3" style="height:30px;"></td></tr>
                                  
                                   <tr>
                                       
                                   <td style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label id="lbl1" runat="server" Text="Cerpac No." Width="76px"></asp:Label>:

                                   </td><td>
                                  <asp:Label ID="txt_cer_no_5" runat="server" Text="AO455877" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  
                                   <tr>
                                       
 <td  style="font-size:X-Small;" valign="bottom" >
                                      
                                   </td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label id="Label6" runat="server" Text="Date Of Issue" Width="76px"></asp:Label>:
                                       </td><td>
                                 <asp:Label ID="txt_date_of_issue_6" runat="server" Text="9 Jul 13" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  

                                   <tr>
                                       
 <td style="font-size:X-Small;" valign="bottom"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lbl_placeofissue" runat="server" Text="Place Of Issue" Width="76px"></asp:Label>:
 </td><td>                                 
<asp:Label ID="txt_place_of_issue_7" runat="server" Text="Abuja" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                      
                                  

                                  <tr>
                                      
 <td style="font-size:X-Small;" valign="bottom"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lbl_expiry" runat="server" Text="Date Of Expiry" Width="76px"></asp:Label>:
                                    
                                     </td><td>
                                 <asp:Label ID="txt_date_of_exp_8" runat="server" Text="1 Nov 13" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                 
                                  </tr>



    </table>--%>

          <%--<table style="font-family: Verdana; left: 20px; position: relative; top: 38px;">
       
      
    <tr>
    <td  rowspan="6" valign="middle" align="left" class="auto-style2">
<img id="permit" runat="server" 
            style="left:-24px; top:1px; position:absolute; width:16px;  height: 140px;" 
            src="../permit.png" />
        <img id="ImgPhoto2" alt="Img" src="Saurabh.jpg" runat="server" style="border:3px solid #006600; height: 94px; width: 85px; left: -4.5px; position: relative; top: -36.5px;" /><br />
       </td>

         <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label5" runat="server" Text="Name"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_name_1" runat="server" Text="Saurabh Bansal" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>

   
    
    </tr>

                   <tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="lbl_comp" runat="server" Text="Company" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_comp" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>

<tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="Label9" runat="server" Text="Designation" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_desig_3" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true" ></asp:Label>
    </td>
  
    </tr>

     <tr>
    <td class="style11" valign="top" colspan="2">
        
     <asp:Label ID="Label1" runat="server" Text="Passport No." Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
        <br />
        <asp:Label ID="txt_pass_no" runat="server" Text="J284455" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    
    </td>
    <%--<td class="style12" valign="top">
     
    
    </td>
    </tr>

        <tr>
    <td class="style11" valign="top" colspan="2">
      
     <asp:Label ID="Label11" runat="server" Text="Nationality" Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_nationality_4" runat="server" Text="Indian" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
   
    </tr>    
<tr style="display:none;">
    <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label7" runat="server" Text="DOB"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
         <asp:Label ID="txt_dob_2" runat="server" Text="25 Dec 82"  Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
    
    </tr>

   --%>



<%--<tr>
    <td class="style2" colspan="2" valign="top">
      
     <asp:Label ID="Label14" runat="server" Text="Signature" ></asp:Label>
    
    </td>
    </tr>--%>
       

   <%-- <tr>
    <td class="style11" colspan="2">
        <br />
        <br />
        </td>
  
    
    </tr>
   
                                   <tr>
                                 
                                  <td style="text-align: center" colspan="3" class="auto-style1">
                                
                                    <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  <tr>
                                 <td class="auto-style3"></td>
                                  <td style="text-align: left; font-size:smaller;"  class="auto-style4" valign="top" colspan="2">
                                       <asp:Image ID="img_sign_card" runat="server" Height="39px" Width="176px"/>--%>
                              <%--  Authorized Signatory     --%>
                                     
                                
                                 <%--      </td>
                                 
                                  
                                 
                                  </tr>


                                 <tr>
                                 
                                  <td style="text-align: left" colspan="3" class="auto-style1">
                                
                                      <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
        
         <tr>
                                 
                                  <td style="text-align: right; vertical-align:top;" colspan="3" class="auto-style5">
                                
                                      
                                       <asp:Label ID="Label2" runat="server" Text="FOR COMPTROLLER-GENERAL," Font-Size="8.5px" Font-Bold="true"></asp:Label><br />
                                      <asp:Label ID="Label3" runat="server" Text="NIGERIA IMMIGRATION SERVICE" Font-Size="8.5px" Font-Bold="true"></asp:Label>
                                       <br />
                                      
                                      </td>
                                 
                                  
                                 
                                  </tr>


 
 
    <tr><td colspan="3" style="height:24px;"></td></tr>
                                  
                                   <tr>
                                       
                                   <td style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label id="lbl1" runat="server" Text="        " Width="76px"></asp:Label>:

                                   </td><td>
                                  <asp:Label ID="txt_cer_no_5" runat="server" Text="AO455877" Font-Size="12px" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  
                                   <tr>
                                       
 <td  style="font-size:X-Small;" valign="bottom" >
                                      
                                   </td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label id="Label4" runat="server" Text="Date Of Issue" Width="76px"></asp:Label>:
                                       </td><td>
                                 <asp:Label ID="txt_date_of_issue_6" runat="server" Text="9 Jul 13" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  

                                   <tr>
                                       
 <td style="font-size:X-Small;" valign="bottom"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lbl_placeofissue" runat="server" Text="Place Of Issue" Width="76px"></asp:Label>:
 </td><td>                                 
<asp:Label ID="txt_place_of_issue_7" runat="server" Text="Abuja" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                      
                                  

                                  <tr>
                                      
 <td style="font-size:X-Small;" valign="bottom"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lbl_expiry" runat="server" Text="Date Of Expiry" Width="76px" ></asp:Label>:
                                    
                                     </td><td>
                                 <asp:Label ID="txt_date_of_exp_8" runat="server" Text="1 Nov 13" Font-Size="X-Small" Font-Bold="true"></asp:Label>
                                          
                                      </td>
                                 
                                  </tr>



    </table>--%>


     <table style="font-family: Verdana; left: 20px; position: relative; top: 38px; ">
       
      
    <tr>
    <td  rowspan="6" valign="middle" align="left" class="auto-style2">

        <img id="ImgPhoto2" alt="Img" src="Saurabh.jpg" runat="server" style="border:3px solid #006600; height: 94px; width: 85px; left: -4.5px; position: relative; top: -36.5px;" /><br />
       </td>

         <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label5" runat="server" Text="Name"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_name_1" runat="server" Text="Saurabh Bansal" Font-Size="X-Small" width="100%"  style="word-wrap:break-word;    overflow: hidden;  " Font-Bold="true"></asp:Label>
    </td>

   
    
    </tr>


       <tr>
    <td class="style11" colspan="2">
     
     <asp:Label ID="lbl_comp" runat="server" Text="Company" valign="top"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_comp" runat="server" Text="Sample" Font-Size="X-Small" width="100%"  style="word-wrap:break-word;    overflow: hidden;  " Font-Bold="true"></asp:Label>
    </td>
  
    </tr>

<tr>
    <td class="style11" colspan="2">
     <asp:Label ID="lbl_expiry" runat="server" Text="Date Of Expiry" Width="100px" Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>

    <br />
         <asp:Label ID="txt_date_of_exp_8" runat="server" Text="1 Nov 13" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>

     <tr>
    <td class="style11" valign="top" colspan="2">
        
     <asp:Label ID="Label1" runat="server" Text="Passport No." Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
        <br />
        <asp:Label ID="txt_pass_no" runat="server" Text="J284455" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    
    </td>
    <%--<td class="style12" valign="top">
     
    
    </td>--%>
    </tr>

        <tr>
    <td class="style11" valign="top" colspan="2">
      
     <asp:Label ID="Label11" runat="server" Text="Nationality" Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
        <asp:Label ID="txt_nationality_4" runat="server" Text="Indian" Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
   
    </tr>    
<tr style="display:none;">
    <td class="style11" valign="top" colspan="2">
       
     <asp:Label ID="Label7" runat="server" Text="DOB"  Font-Size="X-Small" ForeColor="DarkGreen"></asp:Label>
    <br />
         <asp:Label ID="txt_dob_2" runat="server" Text="25 Dec 82"  Font-Size="X-Small" Font-Bold="true"></asp:Label>
    </td>
    
    </tr>

 


   
                                   <tr>
                                 
                                  <td style="text-align: center" colspan="3" class="auto-style1">
                                
                                    <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  <tr>
                                 <td class="auto-style3"></td>
                                  <td style="text-align: left; font-size:smaller;"  class="auto-style4" valign="top" colspan="2">
                                       <asp:Image ID="img_sign_card" runat="server" Height="39px" Width="176px"/>
                              
                                     
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>


                                
        
         <tr>
                                 
                                  <td style="text-align: right; vertical-align:top;" colspan="3" class="auto-style5">
                                
                                      
                                       <asp:Label ID="Label2" runat="server" Text="FOR COMPTROLLER-GENERAL," Width="70%" Font-Size="8.5px" Font-Bold="true"></asp:Label><br />
                                      <asp:Label ID="Label3" runat="server" Text="NIGERIA IMMIGRATION SERVICE" Width="70%"   Font-Size="8.5px" Font-Bold="true"></asp:Label>
                                       <br />
                                      
                                      </td>
                                 
                                  
                                 
                                  </tr>


 
 
    <%--<tr><td colspan="3" style="height:24px;"></td></tr>--%>
     <tr>
                                       
 <td  style="font-size:X-Small;" valign="bottom" >
                                      
                                   </td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label id="Label4" runat="server" Text="Date Of Issue" Width="76px" visible="false" ></asp:Label>
                                       </td><td>
                                 <asp:Label ID="txt_date_of_issue_6" runat="server" Text="9 Jul 13" Font-Size="X-Small" Font-Bold="true" visible="false"></asp:Label></td>
                                  </tr>
                                  
                                   <tr>
                                       
                                   <td style="font-size:X-Small;" valign="bottom" class="auto-style2"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label id="lbl1" runat="server" Text="CERPAC" Font-Size="16px"  Font-Bold="True" Width="76px" ForeColor="#666699"></asp:Label>:
                                   </td><td>
                                  <asp:Label ID="txt_cer_no_5" runat="server" Text="AO455877" Font-Size="12px" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                  
                                  
                                  
                                  

                                   <tr>
                                       
 <td style="font-size:X-Small;" valign="bottom"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" class="style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lbl_placeofissue" runat="server" Text="Place Of Issue" Width="76px"></asp:Label>:
 </td><td>                                 
<asp:Label ID="txt_place_of_issue_7" runat="server" Text="Abuja" Font-Size="X-Small" Font-Bold="true"></asp:Label></td>
                                  </tr>
                                  
                                      
                                  

                                  <tr>
                                      
 <td style="font-size:X-Small;" valign="top"></td>
                                  <td style="text-align: left;font-size:x-small;" align="left" valign="top" class="style12" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label9" runat="server" Text="Designation" valign="top"  Width="72px"  ></asp:Label>
                                 :
                                    
                                     </td><td>
                                     
<asp:Label ID="txt_desig_3" runat="server" Text="Sample" Font-Size="X-Small" Font-Bold="true" Width="80px" Height="65px" style="word-wrap:break-word;" ></asp:Label>
                                </td>
                                 
                                  </tr>



    </table>

 </div>


        <div id="bg" class="popup_bg" style="left: 5px; top: 258px;"></div>
    <div align="center" class="bcolour" id="combox">
        <table cellpadding="2" cellspacing="10" style="width: 95%" >
            <tr>
                
                <td style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Cerpac Card &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
             <tr style="display:none;">
                <td >
                
                
                  
                
                
                </td>
                </tr>

            <tr>
                <td>

                    <div id="Accordion1" class="Accordion" tabindex="0">
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab"style="left: -2px; top: 2px;">Front View
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">

 <center>
                        <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="750px" 
                            style="height: 355px">
                            
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/front1.png'); height: 350px; width: 564px; border: 1px solid black; background-repeat:no-repeat;" align="right">
                              


                                       <div id="container" style="position:relative;">

                                      <asp:Image ID="ImgPhoto" runat="server" Style="position:absolute;top: 90px;left: 50px;height: 163px;width: 149px;" />
                                           </div>

<table style="width: 53%;">
                              
    <br /><br />           <br />       <br />   
                                      <tr>
                                          
                                

                            
                                          <td>
                                              <br />
                                              <br />
                                          </td>
                                          <td>
                                              <br />
                                              <br />
                                          </td>
                                      </tr>


     <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left; color:darkgreen;">
                                  Name
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s; border-width:thin;">
                                  <asp:Label ID="lbl_name" runat="server" Text="PIA ANGELA" Width="300px"></asp:Label>
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>

    <tr>
          <td style="width: 128px"></td>
     <td style="text-align: left;color:darkgreen;">
                                  Company
                                  </td>
  
    </tr>
    <tr>

         <td style="width: 128px"></td>

         <td style="text-align: left">

              <asp:Label ID="txt_comps" runat="server" Text=""  Font-Bold="true"></asp:Label>
         </td>
    </tr>

     <tr>
                                   <td style="width: 128px">&nbsp;</td>
                                  <td style="text-align: left;color:darkgreen;">
                                  Designation
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   <asp:Label ID="lbl_desig" runat="server" Text="56982145" ></asp:Label>
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

     <tr>
                                  <td style="width: 128px;">&nbsp;
                                      
                                       </td>
                                  <td style="text-align: left;color:darkgreen;" >
                                  Passport No.
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s;">
                                  <asp:Label ID="lbl_passport" runat="server" Text="745698213"> </asp:Label>
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>
     <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left;color:darkgreen;">
                                  Nationality
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  <asp:Label ID="lbl_nationality" runat="server" Text="UTOPIA"></asp:Label>
                                   
                                      </td>
                                 
                                  
                                 
                                  </tr>
      
                                 

                                  
                                   <tr style="display:none">
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  DOB
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr style="display:none;">
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                    <asp:Label ID="lbl_dob" runat="server" Text="05.07.1978" style="color: #FFFFFF"></asp:Label>
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                  

                                  

   

                                   <tr style="display:none;">
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  SIGNATURE
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr style="display:none;">
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   <asp:Label ID="lbl_sig" runat="server" Text="" style="color: #FFFFFF"></asp:Label>
                                  
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  </table>

                                  </div>
                                </td>
                            </tr>
                        </table>
                        </center>
</div>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab" style="left: -2px; top: 2px;">Back View
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">
                      
 
 <center>
                        <table id="Table1" cellpadding="5" cellspacing="2" border="0" width="750px" 
                            style="height: 355px">
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/back1.png'); height: 350px; width: 564px; border: 1px solid black; background-repeat:no-repeat;" align="center">
                                      <br />
                                      <br />
                                      <br />
                                      <br />
                                   
                                 
                                  <table style="width: 53%;">
                                     
                                     
                                  <tr>
                                  <td style="width: 228px;" colspan="2" align="left">
                                      
                                  Authorized Signatory     
                                  </td>
                                  
                                 
                                  </tr>
        
                                       <tr>
                                 
                                  <td align="center" colspan="2" class="auto-style1">
                                      <asp:Image ID="img_sign" runat="server" Height="37px" Width="174px"/>
                                  </td>
                                           </tr>

                                  <tr>
                                 
                                  <td style="text-align: left" colspan="2">
                                 <asp:Label ID="Label41" runat="server" Text="For Comptroller-General, Nigeria Immigration Service" Font-Size="XX-Small"></asp:Label>
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px" align="left">Cerpac No.</td>
                                  <td style="text-align: left" align="left">
<asp:Label ID="lbl_cerpac_no" runat="server" Text=""></asp:Label>
                                  
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px" align="left">Date Of Issue</td>
                                  <td style="text-align: left" align="left">
                                  <asp:Label ID="lbl_date_of_issue" runat="server" Text=""></asp:Label>
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px" align="left">Place Of Issue</td>
                                  <td style="text-align: left" align="left">
                                  <asp:Label ID="lbl_place_of_issue" runat="server" Text="" ></asp:Label>
                                  </td>
                                 
                                  </tr>
                                  
                                      
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                  <tr>
                                  <td style="width: 128px" align="left">Date Of Expiry</td>
                                  <td style="text-align: left" align="left">
                                   <asp:Label ID="lbl_expiry_date" runat="server" Text=""></asp:Label>
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                  <%--  <tr>
                              <td align="left" style="height: 16px;" colspan="2">

                                <asp:UpdatePanel runat="server" id="UpdatePanel1">
<ContentTemplate>
<asp:Timer runat="server" id="Timer1" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>

</ContentTemplate>
</asp:UpdatePanel></td>
                          </tr>--%>
                                  
                                  </table>
                                  
                                  </div>
                                </td>
                            </tr>
                        </table>
                        </center>

                        </div>
                      </div>
                      </div>
                </td>

            </tr>

            

                <tr id="tr1" runat="server" style="display:none;">
                <td align="left">
                    <br />
                 <asp:Label ID="lbl_cerpac_serial_no" runat="server" Text="Enter Printed Cerpac Card No." Font-Bold="true"   ></asp:Label>
                 
                 <asp:TextBox style="margin-left:22px;" ID="txt_cerpac_serial_no" runat="server" AutoComplete="Off" AutoPostBack="False"  ></asp:TextBox>
                </td>
                   
                </tr>

                 <tr id="tr2" runat="server" style="display:none;">
                <td align="left">
                    <br />
                 <asp:Label ID="lbl_lam_no" runat="server" Text="Enter Lamination No." Font-Bold="true"   ></asp:Label>
                 
                 <asp:TextBox style="margin-left:22px;" ID="txt_front_lam" runat="server" AutoComplete="Off" AutoPostBack="False" placeholder="Front"  ></asp:TextBox>
                 <asp:TextBox style="margin-left:22px;" ID="txt_back_lam" runat="server" AutoComplete="Off" AutoPostBack="False" placeholder="Back"  ></asp:TextBox>
                
                </td>
                   
                </tr>

             <tr>

                <td style="color:brown">
                    <asp:Label ID="lbl_msg_cond3" runat="server" Font-Bold="true" Visible="false" Text="You have already fired print command but status of printout is pending! Update Status."> </asp:Label>
                </td>
            </tr>

                <tr align="center"><td align="center">
                    <%--<br />
                    <br />--%>
                <asp:Button ID="btn_ok" runat="server"  
                        Text="Start Chip Encoding" class="adminbutton" 
                        ValidationGroup="a" onclick="btn_ok_Click" OnClientClick="ShowProgress();" 
                                    />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                

                    <asp:Button ID="btn_print_cond3" runat="server"  
                        Text="Start Chip Encoding" class="adminbutton" 
                        ValidationGroup="a" OnClick="btn_print_cond3_Click" 
                                     />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <%-- <asp:Button ID="btn_reprint" runat="server" Text="Re-Print" class="adminbutton" OnClick="javascript:return hide('popDiv');"
                        />--%>

                        <%--<a href="#"  onclick="openpopup('popup1')">Close</a>--%>
                        <asp:Button ID="btn_print_ok" runat="server" Text="Save & Continue" class="adminbutton" 
                        ValidationGroup="a" onclick="btn_print_ok_Click" />

                        &nbsp;&nbsp;&nbsp;&nbsp;

                        <input type="button" id="btn_reprint_card" runat="server"  value="Re-Print" class="adminbutton" onclick="openpopup('popup1')"  />

                

                 
                </td>
                
                
                </tr>

           
            <tr>

<td align="center">
     <asp:Button ID="btn_pr_ok" runat="server" Text="Ok" class="adminbutton" 
                        ValidationGroup="a" OnClick="btn_pr_ok_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="btn_pr_not_ok" runat="server" Text="Not Ok" class="adminbutton" 
                        ValidationGroup="a" OnClick="btn_pr_not_ok_Click" />
</td>

               
            </tr>

                <tr><td align="center"><div class="confirmation-box" height="10px" style="display:none;" id="confirm" width="650px" runat="server"><p style="color:#006600"><strong>Card Produced Sucessfully</strong></p></div></td></tr>
        <tr><td><div class="warning-box" height="10px" style="display:none;" id="warn" width="650px" runat="server"><p style="color:Gray"><strong>Already Produced</strong></p></div>
     <asp:Button ID="btn_TestPrint" runat="server" Text="Test Print" class="adminbutton" 
                        ValidationGroup="a" OnClick="btn_TestPrint_Click"  />
            </td></tr>
            </table>
            </div>
    <script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
    <script type="text/javascript">
        $("#accordion > li > div").click(function () {

            if (false == $(this).next().is(':visible')) {
                $('#accordion ul').slideUp(300);
            }
            $(this).next().slideToggle(300);
        });

        $('#accordion ul:eq(0)').show();

</script>
<script type="text/javascript">
    var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: 0 });


function btn_reprint_card_onclick() {

}

function btn_reprint_card_onclick() {

}

    </script>

</asp:Content>

