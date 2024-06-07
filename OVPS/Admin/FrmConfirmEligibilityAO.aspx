<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="~/Admin/FrmConfirmEligibilityAO.aspx.cs" Inherits="Admin_FrmConfirmEligibilityAO" %>

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
        .auto-style1 {
            width: 150px;
        }
        .style1
        {
            height: 45px;
        }
        </style>
    <div id="Div_ContentPlaceHolder" align="center" class="bcolour" >
        <table cellpadding="2" cellspacing="2" class="bcolour"   id="combox" >
        
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
                        <table id="tbl1" style="width:750px;"   cellpadding="5" cellspacing="2" border="0" >
                            <tr class="b11">
                                <td align="center" scope="2" style="width: 100%; height:auto; vertical-align: middle; text-align: center;
                                    background-repeat: no-repeat;">
                                    <asp:Image runat="server" ID="ImgPhoto" Width="100px" Height="120px" ImageUrl="~/Images/Logo/default_logo.gif" />
                                </td>
                            </tr>
                        <tr>
                       <td align="center" colspan="2" >
                          <div class="warning-box" height="10px" style="display:none;" id="warn"  runat="server"><p style="color:#A0522D">
                          <strong>CERPAC Number has been confirmed</strong></p>
                          </div>                      
                         
                          <asp:Button ID="btnAppliHist" runat="server" class="adminbutton"   Text="Applicant History" OnClick="btnAppliHist_Click" Visible="false"/>
                          <div class="confirmation-box" height="10px" style="display:none;" id="confirm"  runat="server">
                             <p style="color:#006600" id="p" runat="server"><strong>Applicant Confirmed Sucessfully</strong></p>
                          </div>
                        </td>
                        </tr>
                        </table>
                        <table cellpadding="5" cellspacing="2" border="0"   id=loading runat=server style="display:none">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Confirmation in progress.Please Wait. . . . .</td></tr>
                       
                        </table>

                        <div id="authtable" runat="server" >
                        <table cellpadding="2" cellspacing="2" border="0" with="300px" id="detailtable" runat="server" align="center">
                            <tr class="b77">
                                <td colspan="2" align="left" style="border-right: 2px dashed #000;" class="t55 mb-lt">
                                  
                                   Status: <asp:Label ID="lblnewrenew" runat="server"></asp:Label></td>
                                <td align="center" class="style1" >  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <img src="printicon.png" height="40" width="40" onclick="printrefusal();" /></td>
                            </tr>
                            <tr  class="b77">
                            <td colspan="2"  class="b55 b-lt ">Database Details</td>                            
                            <td rowspan="6"  class="b55 b-lt " >
                           <asp:Panel ID="Panel1" runat="server" Height="200px" Width="400px" ScrollBars="Horizontal" BorderStyle="Outset" Direction="LeftToRight">
  
                             <asp:DataList ID="DataList1" runat="server"  BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="2" CellSpacing="2"  

            Font-Names="Verdana" Font-Size="Small"  RepeatColumns="0"  RepeatDirection="Horizontal"  >

            <FooterStyle  />

            <HeaderStyle />

            <HeaderTemplate>
             </HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />

            <ItemTemplate>
           <table style="height:160px;">
            <tr>
                <td><b>Form No:</b> </td>
                <td><asp:Label ID="lblCName" runat="server" Text='<%# Eval("Formno") %>'></asp:Label></td>
            </tr>
            <tr>
                <td><b>Name:</b></td>
                <td><asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
            </tr>
            <tr>
                <td><b> Nationality:</b></td>
                <td><asp:Label ID="lblNationality" runat="server" Text=' <%# Eval("Nationality") %>'></asp:Label></td>
            </tr>
                <tr>
                <td><b> Passport No.:</b></td>
                <td><asp:Label ID="Label1" runat="server" Text=' <%# Eval("PassportNo") %>'></asp:Label></td>
            </tr>
                <tr>
                <td><b> Company:</b></td>
                <td><asp:Label ID="Label2" runat="server" Text=' <%# Eval("Company") %>'></asp:Label></td>
            </tr>
           </table>
            </ItemTemplate>

        </asp:DataList>
       
                            </asp:Panel> 
                            
                            </td>                            
                            </tr>
                             <tr class="b77" >
                            <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    Cerpac No.
                                </td>                           
                            <td align="left" style="width: 190px;" class="b-lt">
                                    <asp:Label ID="lblPeopleCerpac" runat="server" CssClass="b99"></asp:Label>
                                </td>  
                            </tr>
                            <tr class="b77" >
                            <td align="left" style=" width: 150px;" class="b55 b-lt ">
                                    Name
                                </td>                           
                            <td align="left" style="width: 190px;" class="b-lt">
                                    <asp:Label ID="txtPeoplename" runat="server" CssClass="b99"></asp:Label>
                                </td>  
                            </tr>
                            <tr class="b77" >
                            <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                   Nationality
                                </td>                          
                            <td align="left" style="width: 190px;" class="b-b b-lt">
                                    <asp:Label ID="lblPeopleNationlaity" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr class="b77" >
                            <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                   Passport No.
                                </td>                          
                            <td align="left" style="width: 190px;" class="b-b b-lt">
                                    <asp:Label ID="lblPeoplePassportNo" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr class="b77" >
                            <td align="left" style="width: 150px;" class="b55 b-lb b-t">
                                   Company
                                </td>                           
                            <td align="left" style="width: 190px;" class="b-b b-lt">
                                    <asp:Label ID="txtPeolpeCompany" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>

                            
                                                      

                           

                            <tr class="t11">
                                <td colspan="3" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>

                            
                           </table>
                        <table  border="0"  id="Table1" runat="server">
                            
                            <tr class="b77">
                                <td  align="left" style="border-right: 2px dashed #000;" class="t55 mb-lt">
                                    <strong>Cerpac Details</strong>
                                </td>
                            </tr>
                            <tr >
                               
                             <td align="left"  class="b55 b-lt ">
                                   Cerpac No
                                </td>
                                 <td align="left"  class="b55 b-lt ">
                                    <asp:Label ID="TxtCerpacNo" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                 <td align="left"  class="b55 b-lt ">
                                    Date of Purchase
                                </td>
                                   <td align="left"  class="b-ltr">
                                    <asp:Label ID="lblprchase" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                 
                                   <td align="left"  class="b55 b-lt ">
                                    FRN No
                                </td>
                                    <td align="left"  class="b55 b-lt ">
                                    <asp:Label ID="txtfrnno" runat="server" CssClass="b99" Visible="false"></asp:Label>
                                        <asp:Label ID="txtfrnnoorig" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                 <td align="left"  class="b55 b-lt ">
                                    Date of Receipt
                                </td>
                                  <td align="left"  class="b-ltr">
                                    <asp:Label ID="lblrcpt" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                
                                  <td align="left"  class="b55 b-lb b-t">
                                    Number of Forms Purchased
                                </td>
                                  <td align="left" class="b55 b-lb b-t">
                                    <asp:Label ID="lblnum" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                  <td align="left"  class="b55 b-lb b-t">
                                    Expiry Date
                                </td>
                                <td align="left"  class="b-rb b-lt">
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
       </td>
            </tr>

            <tr class="b11">
                <td colspan="4" align="center">
                    <asp:Button ID="btnverify" runat="server" class="adminbutton" Text="Confirm"  
                        Width="140px" onclick="btnverify_Click" OnClientClick="change()" />
                    
                   <asp:Button ID="Button1" runat=server Text="Defer" width=149px
                            CssClass=adminbutton onclick="btnsubmit_Click" />
                    
                    <asp:Button ID="btndenycompletely" Text="Deny Completely" runat="server" CssClass="adminbutton" OnClick="btndenycompletely_Click" />

                </td>

              
            </tr>
            <tr>
            <td></td>
            </tr>
            </table>
      
               </div>

                </center>
                </td>
            <td align="center">
        
       </td>
           
                
            </tr>
            
        
        </table>
    </div>  
</asp:Content>

