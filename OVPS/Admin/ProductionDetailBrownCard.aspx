<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_ProductionDetailBrownCard, App_Web_productiondetailbrowncard.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    	
<link rel="shortcut icon" type="images/ico" href="../images/favi-icon.png" />
<link href="../css/minicart.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="../css/product-ensemble-styles.jsp" type="text/css" media="all"/>
<link href="../css/left_sty.css" rel="stylesheet" type="text/css" />	

<link rel="stylesheet" type="text/css" href="../css/ims_motif_styles.jsp" />
<link rel="stylesheet" href='../css/global.css' type="text/css" media="all"/>

<link rel="stylesheet" href="../css/countryPrint.css" type="text/css" media="print"/>
<link media="all" type="text/css" href="../css/video.css" rel="stylesheet">
	

<link type="text/css" media="screen" href="../css/autosuggest.css" rel="stylesheet">

<link media="all" type="text/css" href="../css/quickview.css" rel="stylesheet">

<link rel="stylesheet" href="../css/country.css" type="text/css" media="all"/>

<link rel="stylesheet" type="text/css" href="../engine1/style.css" />
    <link href="../ddmenu/ddmenu.css" rel="stylesheet" type="text/css" />
    <script src="../ddmenu/ddmenu.js" type="text/javascript"></script>

<script type="text/javascript" src="../engine1/jquery.js"></script>
<script type="text/javascript" src="../js/scrolltopcontrol.js"></script>

    
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" />

    
<script type="text/javascript" src="http://cloud.github.com/downloads/malsup/cycle/jquery.cycle.all.latest.js"></script>

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
      .auto-style2 {
          width: 145px;
      }
      .auto-style4 {
          width: 32px;
      }
      .auto-style5 {
          width: 42px;
      }
      --> 
</style>
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


         Ext.onReady(function () {
             Ext.get('mb1').on('click', function (e) {
                 Ext.MessageBox.confirm('Confirm', 'Are you sure you want to do that?', showResult);
             })
         });

    </script>

<script type="text/javascript">
    var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
    
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>


               

    <div id="bill_print" style="display:none;">

    <table style="font-family: Verdana; left: 18px;  position: relative; top: 34px;">
      <tr style="width:60px !important;">

           <td  style="width:110px;" rowspan="6" valign="middle" align="left">
        <img id="ImgPhoto2" alt="Img" src="Saurabh.jpg" runat="server" style="border:3px solid #b64d17; height: 93px  !important; width: 84px !important; left: 3px; position:absolute; top: 0px;" /><br />
       </td>
      </tr>

        
<tr>
    <td class="style11" valign="top">
      
     <asp:Label ID="Label11" runat="server" Text="Name" ForeColor="#b64d17" Font-Size="x-Small"></asp:Label>
    <br />
        <asp:Label ID="txt_name_1" runat="server" Text="Saurabh Bansal" Font-Size="x-Small" Font-Bold="true"></asp:Label>
    </td>
   
    </tr> 
    <tr >
   
    <td class="style11" valign="top">
        
     <asp:Label ID="Label1" runat="server" Text="Passport No." ForeColor="#b64d17" Font-Size="x-Small"></asp:Label>
        <br />
        <asp:Label ID="txt_pass_no" runat="server" Text="J284455" Font-Size="x-Small" Font-Bold="true"></asp:Label>
    
    </td>
    
    </tr>


    
<tr>
    <td class="style11" valign="top" >
       
     <asp:Label ID="Label5" runat="server" Text="Nationality" ForeColor="#b64d17"  Font-Size="x-Small"></asp:Label>
    <br />
        <asp:Label ID="txt_nationality_4" runat="server" Text="Indian" Font-Size="x-Small" Font-Bold="true"></asp:Label>
    </td>
    <%--<td class="style12" valign="top">
     
    
    </td>--%>
    </tr>


        
<tr>
    <td class="style11">
     
     <asp:Label ID="Label2" runat="server" Text="Company" ForeColor="#b64d17" valign="top"  Font-Size="x-Small"></asp:Label>
    <br />
        <asp:Label ID="comp_c" runat="server" Text="SAMPLE" Font-Size="x-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>

<tr>
    <td class="style11">
     
     <asp:Label ID="Label9" runat="server" Text="Designation" ForeColor="#b64d17" valign="top"  Font-Size="x-Small"></asp:Label>
    <br />
        <asp:Label ID="txt_desig_3" runat="server" Text="Software Engineer" Font-Size="x-Small" Font-Bold="true"></asp:Label>
    </td>
  
    </tr>
   

<%--<tr>
    <td class="style2" colspan="2" valign="top">
      
     <asp:Label ID="Label14" runat="server" Text="Signature" ></asp:Label>
    
    </td>
    </tr>--%>
       

    <tr>
    <td >
       
        
        </td>
  
    
    </tr>
    
                                  
                                  <tr>
                                 
                                  <td style=" text-align: left; font-size:x-small;" colspan="2" class="auto-style1" valign="top">
                                    
                                      <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>


                                  <tr>
                                 
                                  <td style="text-align: left" colspan="2" class="auto-style1">
                                
                                      <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
      <tr style="height:8px; line-height:44px;">
          <td style="height:8px;"> &nbsp;</td>

      </tr>
        
       
        
         <tr  >
                                       
                                   <td colspan="4"  valign="top"  style="width:275px; line-height:8px; font-size:8px;" class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Cerpac No.: <asp:Label ID="txt_cer_no_5" runat="server" Text="AO455877" Font-Size="X-Small"></asp:Label>                              
                                       &nbsp; Issue :&nbsp;
                                      <asp:Label ID="txt_date_of_issue_6" runat="server" Text="03/03/2013" Font-Size="9px"></asp:Label>

                                  </td>
                                 
                                  </tr>
                        
                 <tr  >
                                       
                                   <td colspan="4"  valign="top"  style="width:275px; line-height:8px; font-size:8px;" class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; Place Of Issue :<asp:Label ID="txt_loc_card" runat="server" Text="ABUJA" Font-Size="9px"></asp:Label>                              
&nbsp;&nbsp;&nbsp;&nbsp; Expiry
                                       :
                                      <asp:Label ID="txt_date_of_exp_8" runat="server" Text="02/09/2014" Font-Size="9px"></asp:Label>

                                  </td>
                                 
                                  </tr>
                                    




  
                                  
                                  
                                  
                                  

                                   <tr>
                                                                          <asp:Label ID="txtt" runat="server" Visible="false"></asp:Label>
                                   <td  valign="top" style=" line-height:8px; font-size:X-Small;" class="auto-style4">&nbsp;</td>
                                  <td style="text-align: left; line-height:8px;" align="left" class="style12" valign="top" style="font-size:small;">
                                  &nbsp;&nbsp;&nbsp;</td>
                                 
                                  </tr>
                                  
                                      
                                  

                                  <tr>
                                      
                                  <td valign="top" style="line-height:8px; font-size:X-Small;" class="auto-style4">&nbsp;</td>
                                  <td style="text-align: left; line-height:8px;" align="left" class="style12" style="font-size:small;">


                                   &nbsp;
                                    
                                      
                                     
                                      </td>
                                 
                                  
                                 
                                  </tr>

        <tr> 
            <td colspan="2">
                 <asp:Image  runat="server" ID="imgbarcode2" Height="62px" Width="225px" ImageAlign="Right" />

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
          

            <tr>
                <td>

                    <div id="Accordion1" class="Accordion" tabindex="0">
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">Front View
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">

 <center>
                        <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="750px" 
                            style="height: 355px">
                            
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/frontbrown.png'); height: 350px; width: 564px; border: 1px solid black; background-repeat:no-repeat;" align="right">
                               <asp:Image ID="ImgPhoto" runat="server" Style="position:absolute;top: 360px;left: 500px;height: 163px;width: 149px;" />

<table style="width: 53%;">
                              
    <br /><br />           <br />       <br />   
                                      
    <tr>

        <td style="width: 128px;">&nbsp;
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       </td>
                                  <td style="text-align: left; text-decoration-color:maroon;" >
                                  Name.
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s;">

                <asp:Label ID="lbl_name" runat="server" Text="PIA ANGELA" Width="300px" style="color: #FFFFFF"></asp:Label>
                               
        </td>
    </tr>
                                  <tr>
                                  <td style="width: 128px;">&nbsp;
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       </td>
                                  <td style="text-align: left; text-decoration-color:maroon;" >
                                  PASSPORT NO.
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s;">
                                  <asp:Label ID="lbl_passport" runat="server" Text="745698213" style="color: #FFFFFF">

                                  </asp:Label>
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  NATIONALITY
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s; border-width:thin;">
                                  <asp:Label ID="lbl_nationality" runat="server" Text="UTOPIA" style="color: #FFFFFF"></asp:Label>
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      Company Name</td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      <asp:Label runat="server" ID="txt_comps" Text="Company" style="color: #FFFFFF"></asp:Label></td>
                                  </tr>

                                   <tr>
                                   <td style="width: 128px">&nbsp;</td>
                                  <td style="text-align: left">
                                  DESIGNATION
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   <asp:Label ID="lbl_desig" runat="server" Text="Designation" style="color: #FFFFFF"></asp:Label>
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      &nbsp;</td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left;">
                                  
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      &nbsp;</td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   
                                  
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
                        <div class="AccordionPanelTab">Back View
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">
                      
 
 <center>
                        <table id="Table1" cellpadding="5" cellspacing="2" border="0" width="750px" 
                            style="height: 355px">
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/backbrown.png'); height: 350px; width: 564px; border: 1px solid black; background-repeat:no-repeat;" align="center">
                                      <br />
                                      <br />
                                      
                                    <br />
                                 <br /><br /><br />
                                  <table style="width: 40%;">
                                   <tr>
                                   <td align="left" class="auto-style5" style="padding-left: 62px; width:275px; line-height:8px; font-size:8px;"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;Cerpac No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                  <td style="text-align: left" align="left">
<asp:Label ID="lbl_cerpac_no" runat="server" Text="" style="color: #FFFFFF" Font-Size="XX-Small"></asp:Label>
                                  
                                  </td>
                                 <td style="width: 128px" align="left">Issue</td>
                                  <td style="text-align: left" align="left">
                                   
                                       <asp:Label ID="lbl_date_of_issue" runat="server" Text="" style="color: #FFFFFF" Font-Size="XX-Small"></asp:Label></td>
                                  </tr>
                                     
 <tr>
                                    <td   valign="top"  style="float: left !important; width:119px; line-height:8px; font-size:8px;" class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;  Place Of Issue</td>
                                  <td style="text-align: left" align="left">
<asp:Label ID="poi" runat="server" Text="" style="color: #FFFFFF" Font-Size="XX-Small"></asp:Label>
                                  
                                  </td>
                                 <td style="width: 128px" align="left"><font size="-3">Expiry</font></td>
                                  <td style="text-align: left" align="left">
                                        <asp:Label ID="lbl_expiry_date" runat="server" Text="" style="color: #FFFFFF" Font-Size="XX-Small"></asp:Label>
                                </td>
                                  </tr>
                                 
                                 </table>
                                      <br /><br />
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image runat="server" ID="imgbarcode" Height="100px" Width="323px" />
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
                </td>
                   
                </tr>


             <tr>

                <td style="color:brown">
                    <asp:Label ID="lbl_msg_cond3" runat="server" Font-Bold="true" Visible="false" Text="You have already fired print command but status of printout is pending! Update Status."> </asp:Label>
                </td>
            </tr>

                <tr align="center"><td align="center">
                   
                    <asp:Button ID="btn_pr_ok" runat="server" Text="Ok" class="adminbutton" 
                        ValidationGroup="a" OnClick="btn_pr_ok_Click" />
                   &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_ok" runat="server"  
                        Text="Print" class="adminbutton" 
                        ValidationGroup="a" onclick="btn_ok_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <%-- <asp:Button ID="btn_reprint" runat="server" Text="Re-Print" class="adminbutton" OnClick="javascript:return hide('popDiv');"
                        />--%>

                        <%--<a href="#"  onclick="openpopup('popup1')">Close</a>--%>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                

                 
                </td>
                
                
                </tr>

           


                <tr><td align="center"><div class="confirmation-box" height="10px" style="display:none;" id="confirm" width="650px" runat="server"><p style="color:#006600"><strong>Card Produced Sucessfully</strong></p></div></td></tr>
        <tr><td><div class="warning-box" height="10px" style="display:none;" id="warn" width="650px" runat="server"><p style="color:Gray"><strong>Already Produced</strong></p></div></td></tr>
            </table>
            </div>
    <script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
    <SCRIPT>
        $("#accordion > li > div").click(function () {

            if (false == $(this).next().is(':visible')) {
                $('#accordion ul').slideUp(300);
            }
            $(this).next().slideToggle(300);
        });

        $('#accordion ul:eq(0)').show();

</SCRIPT>
<script type="text/javascript">
    var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: 0 });


    </script>

</asp:Content>
