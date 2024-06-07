<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmConfirmEligibility, App_Web_frmconfirmeligibility.aspx.fdf7a39c" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
  
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
                                    Company Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompname" runat="server" CssClass="b99"></asp:Label>
                                </td>

                                <td align="left" style="width: 150px; display:none" class="b55">
                                    Company Id
                                </td>
                                <td align="left" style="width: 190px; display:none;">
                                    <asp:Label ID="txtcompid" runat="server" CssClass="b99"></asp:Label>
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
                <td colspan="4" align="left" style="height: 20px;">
                    </td>
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
                <td align="center" colspan="1">
                    <asp:Button ID="btnAppliHist" runat="server" class="adminbutton" 
                         Text="Applicant History" OnClick="btnAppliHist_Click"/>
                    
                </td>
            </tr>
            <tr><td height=25px></td></tr>
        </table>

                            </div>


       <tr><td align=center><div class="confirmation-box" height=10px style="display:none;" id=confirm  runat=server><p style="color:#006600" id="p" runat=server><strong>Applicant Confirmed Sucessfully</strong></p></div></td></tr>
        <tr><td align=center><div class="warning-box" height=10px style="display:none;" id=warn  runat=server><p style="color:#A0522D"><strong>CERPAC Number has been confirmed</strong></p></div></td></tr>
        </center> </td> </tr> </table>
    </div>
</asp:Content>

