<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_frmApplicantTracking, App_Web_frmapplicanttracking.aspx.fdf7a39c" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <link href="../css/scanpage.css" rel="Stylesheet" type="text/css" /> 
    <link href="../css/animate-custom.css" rel="Stylesheet" type="text/css" /> 
    <link href="../css/country.css" rel="Stylesheet" type="text/css" /> 
<script type="text/javascript" language="javascript" >

    function AlfaNum1(t) {
        var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var v = cod
        var w = "";
        for (var i = 0; i < t.value.length; i++) {
            x = t.value.charAt(i);
            if (v.indexOf(x, 0) != -1)
                w += x;
        }
        t.value = w;
    }
    function first_Click() {
        //open new window set the height and width =0,set windows position at bottom
        var a = window.open('', '', 'left =' + screen.width + ',top=' + screen.height + ',width=0,height=0,toolbar=0,scrollbars=1,status=0');

        a.document.write($("P604b8288e65b492695e9f9782b49f6d3_2_oReportDiv").html());
        a.document.close();
        a.focus();
        //call print
        a.print();
        a.close();
        return false;
    }
    
       function PrintContent() {
           //alert('hi');
           var html = "<html>";
           html += document.getElementById("DivCheckSheet").innerHTML;
           html += "</html>";

           var printWin = window.open('', '', 'location=no,width=10,height=10,left=50,top=50,toolbar=no,scrollbars=no,status=0,titlebar=no');

           printWin.document.write(html);
           printWin.document.close();
           printWin.focus();
           printWin.print();
           printWin.close();
       }


</script>
       
    
    

 <div id="div_main" runat="server" >
 <div id="DetailPage" align="left" style="width: 750px" >
        <table cellpadding="2" cellspacing="10" style="width: 100%"  >
             <tr >
                
                <td style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Application Tracking</span></font></div>
                </td>
            </tr>
                </table>
          </div>  
    
     <div id="DivCheckSheet" align="left" >
         <table cellpadding="2" cellspacing="10" class="Grid_Item_Alternaterow" style="width: 100%" >
            
            <tr>
                 <td style="width: 10%; height: 26px;"></td>
                 <td style="width: 20%;  height: 26px;"></td>
                 <td style="width: 20%; ; height: 26px;" ></td>
                 <td style="width: 10%; height: 26px;" ></td>
                 <td style="width: 20%; "></td>
                 <td style="width: 10%;"></td>
             </tr>
            <tr>
                 <td style="width: 16px">&nbsp;</td>
                 
                 <td style="width: 168px" align="left">Sold Secure Form No.</td>
                 
                 <td style="width:120px" ><asp:TextBox ID="txtSerach" runat="server"  class="textbox2" onkeyup="return AlfaNum1(this)"></asp:TextBox> 
                 </td>
                 <td style="width: 41px"  >
                     <asp:Button ID="Button1" runat="server" onclick="btnSerach_Click" Text="Search " CssClass="adminbutton" />
                 </td>
                <td style="width: 30% ">&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px">&nbsp;Form No.</td>
                 <td style="width: 120px">
                     <asp:Label ID="lblFRMNo" runat="server" Text=""></asp:Label>
                 </td>
                 <td style="width: 41px" >&nbsp;</td>
                 <td>&nbsp;</td>
                  <td ></td>
             </tr>
             
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px">&nbsp;Cerpac No.</td>
                 <td style="width: 120px">
                     <asp:Label ID="lblCerpacNo" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td style="width: 41px" >&nbsp;</td>
                 <td rowspan="7">
                     <asp:Image ID="ImgPhoto" runat="server" ImageUrl="~/Images/Logo/default_logo.gif" style="height:164px; margin-left:8px; margin-top:9px; width:164px; border-width:0px;" BorderColor="#003300" BorderStyle="None" BorderWidth="1px" />
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td  style="width: 16px; height: 26px;"></td>
                 <td style="width: 168px; height: 26px;" >Cerpac Expiry Date</td>
                 <td style="height: 26px; width: 120px">
                     <asp:Label ID="lblCerpacExpDt" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td style="width: 41px; height: 26px;" ></td>
                 <td style="height: 26px" ></td>
             </tr>
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px">Applicant Name</td>
                 <td  colspan="2">
                     <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                     <asp:Label ID="lblForeName" runat="server" Text="Label"></asp:Label>
                     <asp:Label ID="lblMiddleName" runat="server" Text="Label"></asp:Label>
                     <asp:Label ID="lblSurName" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px">Sex</td>
                 <td style="width: 120px">
                     <asp:Label ID="lblSex" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td style="width: 41px" >&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
             
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px" >Company Name</td>
                 <td colspan="2" >
                     <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px" >Designation</td>
                 <td style="width: 120px" >
                     <asp:Label ID="lblDesignation" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td style="width: 41px" >&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td style="width: 168px" >Passport No.</td>
                 <td style="width: 120px" >
                     <asp:Label ID="lblPassportNo" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td style="width: 41px" >&nbsp;</td>
                 <td> &nbsp;</td>
                 
             </tr>
             <tr>
                 <td style="width: 16px; height: 26px;"></td>
                 <td colspan="4" rowspan="6">
                     <table align="left" style="width: 100%"   >
                         <tr class="Grid_Item_Alternaterow">
                             <td  colspan="6" style="border: thin groove #C0C0C0;  text-align : center;  ">&nbsp;&nbsp;<asp:Label ID="lblZoneName" runat="server"  style="font-size: x-large" Text="Label"></asp:Label>
                             </td>
                         </tr>
                         <tr class="Grid_Item_Alternaterow" style="font-size:14px; font-style :oblique;"  >
                             <td style="width: 10%" >&nbsp;&nbsp;SerialNo.</td>
                             <td style="width: 30%" >Activity</td>
                                 
                             <td style="width: 15%" >Status</td>
                             <td style="width: 15%" >User</td>
                             <td style="width: 15%" >Date </td>
                             <td style="width: 15%" >Time </td>
                            
                         </tr>
                         <tr class="Grid_Item_Alternaterow" >
                             <td style="width: 347px" ><asp:Label ID="lblSr1" runat="server" Text="Label"/></td>
                             <td>Data Capture</td>
                                 
                             <td>
                                 <asp:Label ID="lblStatusV" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblVerify" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td >
                                 <asp:Label ID="lblVerifyDt" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblVerifyTime" runat="server" Text="Label"></asp:Label>
                             </td>
                            
                         </tr>
                         <tr class="Grid_Item_Alternaterow" >
                             <td style="width: 347px" ><asp:Label ID="lblSr2" runat="server" Text="Label"/></td>
                             <td>Authorization</td>
                                 
                             <td>
                                 <asp:Label ID="lblStatusA" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAuthBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td >
                                 <asp:Label ID="lblAuthDt" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAuthTime" runat="server" Text="Label"></asp:Label>
                             </td>
                             
                         </tr>
                         <tr id="AuthContecOfficer" runat="server" class="Grid_Item_Alternaterow" >
                             <td style="width: 347px" ><asp:Label ID="lblSr3" runat="server" Text="Label"/></td>
                             <td>Authorization by Contec Officer </td>
                             <td>
                                 <asp:Label ID="lblStatusAC" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblContecBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td >
                                 <asp:Label ID="lblContecDt" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblContecT" runat="server" Text="Label"></asp:Label>
                             </td>
                            
                         </tr>
                         <tr class="Grid_Item_Alternaterow" >
                             <td style="width: 347px" ><asp:Label ID="lblSr4" runat="server" Text="Label"/></td>
                             <td>Production</td>
                                
                             <td>
                                 <asp:Label ID="lblStatusP" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblProdBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td >
                                 <asp:Label ID="lblProdOn" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblProdTime" runat="server" Text="Label"></asp:Label>
                             </td>
                            
                         </tr>
                         
                         <tr class="Grid_Item_Alternaterow" >
                             <td style="width: 347px" > <asp:Label ID="lblSr5" runat="server" Text="Label"></asp:Label></td>
                             <td>Quality</td>
                                 
                             <td>
                                 <asp:Label ID="lblStatusQ" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblQualityBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td >
                                 <asp:Label ID="lblQualityOn" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblQualTime" runat="server" Text="Label"></asp:Label>
                             </td>
                           
                         </tr>
                         <tr class="Grid_Item_Alternaterow" >
                             <td  colspan="6" style="border: thin groove #C0C0C0;  text-align : center;  ">
                                 <asp:Label ID="lblRejectDetails" runat="server" ForeColor="Black" style="font-size: large; text-align: center;" Text="Label"></asp:Label>
                             </td>
                         </tr>
                     </table>
                 </td>
                  <td ></td>
             </tr>
             <td style="height: 25px"></td>
             <td ></td>
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td ></td>
             </tr>
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td ></td>
             </tr>
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td ></td>
             </tr>
             <tr>
                 <td style="width: 16px">&nbsp;</td>
                 <td ></td>
             </tr>
             
             
             <tr>
                 <td style="width: 16px; height: 25px;"></td>
                 <td style="width: 168px; height: 25px;"></td>
                 <td style="width: 120px; height: 25px;" ></td>
                 <td style="width: 41px; height: 25px;" ></td>
                 <td style="height: 25px"></td>
                 <td style="height: 25px"></td>
             </tr>
         </table>

         </div>    
  </div>    
</asp:Content>

