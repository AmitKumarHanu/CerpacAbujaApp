<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_ProdCardPersonalisation, App_Web_prodcardpersonalisation.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" />

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
--> 
</style>

<script language="javascript">
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
        var divTop = (pageHeight - divHeight) / 2;
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


<script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <link href="../css/scanpage.css" rel="Stylesheet" type="text/css" /> 
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
    </style>
    <strong></strong>



               <div id="popup1" class="popup">
			<table  id="tab1" width="100%"  >
				<tr>
					<td colspan="5" style="text-align: center">
						<%--<asp:Label ID="lbl_heading" runat="server" Text="Reason of Re-Print" Font-Bold="true"></asp:Label>--%>

                         <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Reason to select another card &nbsp; </span>
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
                <td >
                    
                 <asp:Label ID="lbl_reprint_card_serial_no" runat="server" Text="Cerpac Card Serial No." Font-Bold="true" Visible="false"></asp:Label>

                 
                </td>
                   <td style="font-weight:bold;"></td>
<td><asp:Label ID="txt_reprint_card_serial_no" runat="server" Visible="false"></asp:Label></td>
<td></td>
                </tr>

                <tr>
                <td></td>
                <td valign="top"><asp:Label ID="lbl_reason" runat="server" Text="" Font-Bold="true"></asp:Label></td>

                <td style="font-weight:bold;" align="center" ></td>

                <td style="float: right;
margin-right: 215px;">

                <%--<asp:TextBox ID="txt_reason" runat="server" TextMode="MultiLine" Height="66px" 
                        Width="305px"></asp:TextBox>
--%>
                    <asp:RadioButton ID="Rd1" runat="server" GroupName="AB" Text="Reason A" Checked="true" />
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd2" runat="server" GroupName="AB" Text="Reason B"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd3" runat="server" GroupName="AB" Text="Reason C"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd4" runat="server" GroupName="AB" Text="Reason D"/>
                
                
                        
                        </td>

                <td></td>
                </tr>

                <tr>
					<td></td>

                    <td></td>
                      <td colspan="2">
                         

                     
                                        </td>
                    <td></td>

                    <td></td>
				</tr>

			</table>
                   <input type="button" id="btn_Reason_Print" runat="server"   
                        value="Ok" class="adminbutton" onclick="btn_Reason_Print_Click"  />

                        &nbsp;&nbsp;&nbsp;

                        <%--<asp:Button ID="btn_cancel" runat="server"  
                        Text="Cancel" class="adminbutton" />
--%>

                        <input type="button" id="btn_cancel" runat="server"  value="Cancel" class="adminbutton" onclick="closepopup('popup1')"/>


		</div>

        <div id="bg" class="popup_bg"></div>


    <div align="center" class="bcolour"  id="combox">
        <table cellpadding="2" cellspacing="10" style="width: 95%"  >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Production Card Personalisation Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            </table>

                <table cellpadding="5" cellspacing="2" border="0" width="750px" id="detailtable" runat="server">
                           <%-- <tr class="b11">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Passport Details</strong>
                                </td>
                            </tr>--%>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>


                            <tr class="b11" style="display:none;">
                            <td style="width: 70px;"></td>
                                <td align="left" style="width: 160px;" >
                                  <strong>Current Available Stock</strong> 
                                    <br />
                                    <br />
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtStock" runat="server" Font-Bold="true"></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                </td>
                          </tr>

                            <tr class="b11">
                            <td style="width: 70px;"></td>
                                <td align="left" style="width: 160px;" >
                                <strong>Enter the card No. to be Personalised</strong> 
                                    <br />
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtCardSerialNo" runat="server" Font-Bold="true" AutoComplete="Off"></asp:TextBox>
                                    <br />
                                    <br />
                                </td>
<%--                                <td align="left" style="width: 150px;">
                                    Nationality
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtNationality" runat="server"></asp:Label>
                                </td>
--%>                            </tr>




                           <tr class="b11">
                <td align="center" colspan="4">
                    <br />
                    <br />
                    <asp:Button ID="btnCardProceed" runat="server" class="adminbutton" 
                        Text="Personalise" onclick="btnCardProceed_Click" />
                                           
                         <input type="button" id="btnOtherCard" runat="server"  value="Select Other Card" class="adminbutton" onclick="openpopup('popup1')"  visible="false" />

                         <asp:Button ID="btnCancel" runat="server" class="adminbutton" 
                        Text="Cancel" onclick="btnCancel_Click" />

                </td>
            </tr>


              <tr><td align="center" colspan="4"><div class="confirmation-box" height="10px" style="display:none;" id="confirm" width="650px" runat="server"><p style="color:#006600"><strong>Card Produced Sucessfully</strong></p></div></td></tr>
        <tr><td colspan="4"><div class="warning-box" height="10px" style="display:none;" id="warn" width="650px" runat="server"><p style="color:Gray"><strong>Already Produced</strong></p></div></td></tr>
                            </table>
            </div>

</asp:Content>

