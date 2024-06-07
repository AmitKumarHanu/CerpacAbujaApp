<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmConfirmEligibilityAO, App_Web_frmconfirmeligibilityao.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel=Stylesheet type="text/css" href="../css/animate-custom.css" /> 
  <script type="text/javascript">
      function reason() {
          // document.getElementById('<%=authtable.ClientID %>').className = 'animated flipOutY';
          // 
          document.getElementById('<%=btnverify.ClientID %>').className = 'adminbutton animated fadeOutUpBig';
          document.getElementById('<%=btnAppliHist.ClientID %>').className = 'adminbutton animated fadeOutUpBig';
          document.getElementById('deny').className = 'adminbutton animated fadeOutUpBig';
      }

      function change() {
          document.getElementById('<%=authtable.ClientID %>').className = 'animated-table fadeOutUp';
          document.getElementById('<%=loading.ClientID %>').style.display = '';
      }

      function printrefusal()
      {
          var prtContent = document.getElementById('Div_ContentPlaceHolder');
          var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
          WinPrint.document.write(prtContent.innerHTML);
          WinPrint.document.close();
          WinPrint.focus();
          WinPrint.print();
          WinPrint.close();
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
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
    width:55%;
}
        </style>
    <div id="Div_ContentPlaceHolder" align="center" class="bcolour">
        <table cellpadding="2" cellspacing="5" class="bcolour" style="width: 98%"  id="combox">
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Eligibility&nbsp; Section</span></font></div>
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
                        <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="750px">
                            <tr class="b11">
                                <td align="center" style="width: 10%; vertical-align: middle; text-align: center;
                                    background-repeat: no-repeat;">
                                    <asp:Image runat="server" ID="ImgPhoto" Width="100px" Height="120px" ImageUrl="~/Images/Logo/default_logo.gif" />
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id=loading runat=server style="display:none">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Confirmation in progress.Please Wait. . . . .</td></tr>
                        </table>
                        <div id="authtable" runat=server >
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id=detailtable runat=server>
                            <tr class="b77">
                                <td colspan="4" align="center" class="t55">
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   Status: <asp:Label ID="lblnewrenew" runat="server"></asp:Label></td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <img src="printicon.png" height="40" width="40" onclick="printrefusal();" /></td>
                            </tr>
                            <tr class="b77">
                               <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                                <td  align="left" class="t55 mb-lt">
                                    <strong>Personal Details</strong>
                                </td>
                                 <td  align="left" class="t55 mb-lt">
                                    <strong>From Bank </strong>
                                </td>
                                 <td  align="left" class="t55 mb-ltr">
                                    <strong>Data Entered</strong>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                                <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    Name
                                </td>
                                <td align="left" style="width: 190px;" class="b-lt">
                                    <asp:Label ID="txtbankname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b-ltr">
                                    <asp:Label ID="txtdbname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                               
                            </tr>
                          
                            <tr >
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                                <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                   Company
                                </td>
                                <td align="left" style="width: 190px;" class="b-b b-lt">
                                    <asp:Label ID="txtcompanybank" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b-rb b-lt">
                                    <asp:Label ID="txtcompany" runat="server" CssClass="b99"></asp:Label>
                                </td>
                           
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            
                           </table>
                            <table cellpadding="5" cellspacing="2" border="0" width="750px" id=Table1 runat=server>
                            <tr class="b77">
                                <td  align="left" style="border-right: 2px dashed #000;" class="t55 mb-lt">
                                    <strong>Cerpac Details</strong>
                                </td>
                            </tr>
                            <tr >
                               
                             <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                   Cerpac No
                                </td>
                                 <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    <asp:Label ID="TxtCerpacNo" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                 <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    Date of Purchase
                                </td>
                                   <td align="left" style="width: 150px;" class="b-ltr">
                                    <asp:Label ID="lblprchase" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                 
                                   <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    FRN No
                                </td>
                                    <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    <asp:Label ID="txtfrnno" runat="server" CssClass="b99" Visible="false"></asp:Label>
                                        <asp:Label ID="txtfrnnoorig" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                 <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    Date of Receipt
                                </td>
                                  <td align="left" style="width: 150px;" class="b-ltr">
                                    <asp:Label ID="lblrcpt" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                
                                  <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                    Number of Forms Purchased
                                </td>
                                  <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                    <asp:Label ID="lblnum" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                  <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                    Expiry Date
                                </td>
                                <td align="left" style="width: 150px;" class="b-rb b-lt">
                                    <asp:Label ID="lblexp" runat="server" CssClass="b99"></asp:Label>
                                </td>
                               </tr>
                                                     
            <!-- till here -->
           
            <tr class="b11">
                <td colspan="4" align="left">
                    &nbsp;</td>
            </tr>
                                <tr class="b11">
                                    <td align="left" class="b55">Reason</td>
                                    <td colspan="3" align="left">
                                        <asp:RadioButtonList runat="server" ID="radreason" RepeatColumns="3" CellSpacing="5" CellPadding="5" Width="468px">
                                            <asp:ListItem Selected="True" Value="BDMS">Bank Data Missmatch</asp:ListItem>
                                            <asp:ListItem Value="EDWC">Expiry Date wrongly calculated</asp:ListItem>
                                            <asp:ListItem Value="OTHS">Others</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>

                                </tr>
                                <tr class="b11">
                <td colspan="4" align="left">
                    &nbsp;</td>
            </tr>

            <tr class="b11">
                <td></td>
                <td align="center" colspan="1">
                    <asp:Button ID="btnverify" runat="server" class="adminbutton" Text="Confirm"  
                        Width="140px" onclick="btnverify_Click" OnClientClick="change()" />
                    
                </td>
               
                 <td align="center" colspan="1">
                   <asp:Button ID="Button1" runat=server Text="Defer" width=149px
                            CssClass=adminbutton onclick="btnsubmit_Click" />
                    
                </td>
               <td height=25px colspan="4">
                    <asp:Button ID="btndenycompletely" Text="Deny Completely" runat="server" CssClass="adminbutton" OnClick="btndenycompletely_Click" />

                </td>

                <td align="center" colspan="1">
                    
                </td>
            </tr>
            </table>

                            </div>


       <tr><td align=center><div class="confirmation-box" height=10px style="display:none;" id=confirm  runat=server><p style="color:#006600" id="p" runat=server><strong>Applicant Confirmed Sucessfully</strong></p></div> <td align="center" colspan="1" style="display:none;">
                    <asp:Button ID="btnAppliHist" runat="server" class="adminbutton" 
                         Text="Applicant History" OnClick="btnAppliHist_Click" Visible="false"/>
                    
                </td></td></tr>
        <tr><td align=center><div class="warning-box" height=10px style="display:none;" id=warn  runat=server><p style="color:#A0522D"><strong>CERPAC Number has been confirmed</strong></p></div></td></tr>
        </center> </td> </tr> </table>
    </div>  
</asp:Content>

