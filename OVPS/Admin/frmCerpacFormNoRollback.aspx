<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmCerpacFormNoRollback.aspx.cs" Inherits="Admin_frmCerpacFormNoTracking" %>
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
       
    <script type="text/javascript">



        function PopUp(ctrl) {
            var controlName = document.getElementById(ctrl);
            var WinHeight = document.body.clientHeight;
            var WinWidth = document.body.clientWidth;
            controlName.style.top = (WinHeight - controlName.style.posHeight) / 2;
            controlName.style.left = (WinWidth - 400) / 2;
            controlName.value = 'true';
        }
    </script>
 
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "../images/minus.png");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "../images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>
    

 <div id="div_main" runat="server" >
     <div id="DetailPage" align="left" style="width: 750px" >
        <table cellpadding="2" cellspacing="10" style="width: 100%" >
             <tr >
                
                <td style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Application Rollback</span></font></div>
                </td>
            </tr>
                </table>
          </div>  
     <div id="DivOpt" runat="server" align="left">
        <table cellpadding="2" cellspacing="10" class="Grid_Item_Alternaterow" style="width: 100%" >
       <tr>
                 <td style="width: 10px">&nbsp;</td>
                 <td style="width: 20%; height: 26px;"></td>
                 <td style="width: 10%; height: 26px;"></td>
                 <td style="width: 10%;"></td>
                 <td style="height: 26px; width: 10%;"></td>
                   <td>&nbsp;</td>
             </tr>
             <tr>
                 <td style="width: 10px">&nbsp;</td>

                 <td style="" align="left">Sold Secure Form No.</td>

                 <td style="">
                     <asp:TextBox ID="txtSerach" runat="server" class="textbox2" onkeyup="return AlfaNum1(this)"></asp:TextBox>
                 </td>
                 <td>
                     <asp:Button ID="Button1" runat="server" OnClick="btnSerach_Click" Text="Search " CssClass="adminbutton" />
                 </td>
                 <td style=""> </td>
                 <td>&nbsp;</td>
             </tr>
            <tr>
                 <td style="width: 10px">&nbsp;</td>
                 <td style="width: 20%; height: 26px;"></td>
                 <td style="width: 10%; height: 26px;"></td>
                 <td style="width: 10%;"></td>
                 <td style="height: 26px; width: 10%;"></td>
                   <td>&nbsp;</td>
             </tr>
            <tr>
            <td style="width: 10px">
               
                 </td>
             <td colspan="5">
                 
            <div id="DivVendorGrid" align="top" runat="server"  style=" width:100% ">
                
            <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="False" CssClass="Grid"    DataKeyNames="cerpac_no" OnRowDataBound="gvMaster_RowDataBound" >
                <Columns>
                            

                            <asp:TemplateField>
                        <ItemTemplate>
                        <img alt = "" style="cursor: pointer" src="../Images/plus.png" />               
                        <asp:Panel ID="Panel1" runat="server" Style="display: none;" ScrollBars="Auto" >
                            <asp:DetailsView ID="gvDetails" runat="server" AutoGenerateRows="false" Height="50px" Width="500px">
                                            <Fields>
                                                
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="ZoneName" ItemStyle-Width="300px" HeaderText="ZoneName" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="title" ItemStyle-Width="300px" HeaderText="Title" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="forename" ItemStyle-Width="300px" HeaderText="Forename" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="middle_name" ItemStyle-Width="300px" HeaderText="Middle_name" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="surname" ItemStyle-Width="300px" HeaderText="Surname" />   

                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="cerpac_no" ItemStyle-Width="300px" HeaderText="Cerpac No" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="cerpac_file_no" ItemStyle-Width="300px" HeaderText="Form No" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="cerpac_receipt_date" ItemStyle-Width="300px" HeaderText="Receipt Date" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="cerpac_expiry_date" ItemStyle-Width="300px" HeaderText="Expiry Date" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="card_no" ItemStyle-Width="300px" HeaderText="Card No" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="front_lam_No" ItemStyle-Width="300px" HeaderText="Front lamination No." /> 
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="back_lam_No" ItemStyle-Width="300px" HeaderText="Back lamination No." />   
                                                                              
                                            
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="Request_CreatedBy" ItemStyle-Width="300px" HeaderText="Request CreatedBy" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="Request_CreatedOn" ItemStyle-Width="300px" HeaderText="Request CreatedOn" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="CallbackApproveBy" ItemStyle-Width="300px" HeaderText="Callback Approve Authority" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="CallbackReason" ItemStyle-Width="300px" HeaderText="Callback Reason" />
                                                           
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="CallBackOn" ItemStyle-Width="300px" HeaderText="Callback Date" />
                                                            <asp:BoundField  HeaderStyle-Font-Bold="true" DataField="flag" ItemStyle-Width="300px" HeaderText="Status" />     

                                            </Fields>
                            </asp:DetailsView>
                        </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name"  >
            <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="cerpac_no" HeaderText="CerpacNo" >
            <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="cerpac_expiry_date" HeaderText="Expiry Date"   SortExpression="cerpac_expiry_date" >
            <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="card_no" HeaderText="Card No" > 
            <ItemStyle Width="200px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="CallbackReason" HeaderText="Reason" >
            <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="flag" HeaderText="Flag" >
            <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

         

                </Columns>
            </asp:GridView>
                           <br />
                     </div>
                       </td>
        </tr>
       </table>
    </div>
     <div id="DivCheckSheet" runat="server" align="left" >

        <table cellpadding="2" cellspacing="10" class="Grid_Item_Alternaterow" style="width: 100%" >
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
             <tr >
                 <td style=" height: 25px;"></td>
                 <td style=" height: 25px;"></td>
                 <td style=" height: 25px;"></td>
                 <td style="height: 25px;" colspan="2"  align="right">  <asp:Button ID="btnRequestCallBack" runat="server" Text="Request " CssClass="adminbutton" OnClick="btnRequestCallBack_Click" />
                     </td>
                 <td style="height: 25px"></td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;Form No.</td>
                 <td style="">
                     <asp:Label ID="lblFRMNo" runat="server" Text=""></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;</td>
             </tr>

             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;Cerpac No.</td>
                 <td style="">
                     <asp:Label ID="lblCerpacNo" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td rowspan="7" style="" align="right">
                     <asp:Image ID="ImgPhoto" runat="server" ImageUrl="~/Images/Logo/default_logo.gif" Style="height: 164px; margin-left: 8px; margin-top: 9px; width: 164px; border-width: 1px;" BorderColor="#333333" BorderStyle="None" BorderWidth="1px" />
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td style="height: 26px;"></td>
                 <td style="height: 26px;">Cerpac Expiry Date</td>
                 <td style="height: 26px; ">
                     <asp:Label ID="lblCerpacExpDt" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td style="height: 26px;"></td>
                 <td style="height: 26px"></td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">Applicant Name</td>
                 <td colspan="2">
                     <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                     <asp:Label ID="lblForeName" runat="server" Text="Label"></asp:Label>
                     <asp:Label ID="lblMiddleName" runat="server" Text="Label"></asp:Label>
                     <asp:Label ID="lblSurName" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">Sex</td>
                 <td style="">
                     <asp:Label ID="lblSex" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>

             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">Company Name</td>
                 <td colspan="2">
                     <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">Designation</td>
                 <td style="">
                     <asp:Label ID="lblDesignation" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">Passport No.</td>
                 <td style="">
                     <asp:Label ID="lblPassportNo" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td style="">&nbsp;</td>
               
             </tr>
             <tr>
                 <td style=" height: 26px;"></td>
                 <td colspan="4" rowspan="6">
                     <table align="center" style="width: 100%">
                         <tr class="Grid_Item_Alternaterow">
                             <td colspan="6" style="border: thin groove #C0C0C0; text-align: center;">&nbsp;&nbsp;<asp:Label ID="lblZoneName" runat="server" Style="font-size: x-large" Text="Label"></asp:Label>
                             </td>
                         </tr>
                         <tr class="Grid_Item_Alternaterow" style="font-size: 14px; font-style: oblique;">
                             <td>&nbsp;&nbsp;SerialNo.</td>
                             <td>Activity</td>

                             <td>Status</td>
                             <td>User</td>
                             <td>Date </td>
                             <td>Time </td>

                         </tr>
                         <tr class="Grid_Item_Alternaterow">
                             <td>
                                 <asp:Label ID="lblSr1" runat="server" Text=""></asp:Label></td>
                             <td>Data Capture</td>

                             <td>
                                 <asp:Label ID="lblStatusV" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblVerify" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblVerifyDt" runat="server" Text=""></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblVerifyTime" runat="server" Text=""></asp:Label>
                             </td>

                         </tr>
                         <tr class="Grid_Item_Alternaterow">
                             <td>
                                 <asp:Label ID="lblSr2" runat="server" Text="Label"></asp:Label></td>
                             <td>Authorization</td>

                             <td>
                                 <asp:Label ID="lblStatusA" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAuthBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAuthDt" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblAuthTime" runat="server" Text="Label"></asp:Label>
                             </td>

                         </tr>
                         <tr id="AuthContecOfficer" runat="server" class="Grid_Item_Alternaterow">
                             <td>
                                 <asp:Label ID="lblSr3" runat="server" Text="Label"></asp:Label></td>
                             <td>Authorization by Contec Officer </td>
                             <td>
                                 <asp:Label ID="lblStatusAC" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblContecBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblContecDt" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblContecT" runat="server" Text="Label"></asp:Label>
                             </td>

                         </tr>
                         <tr class="Grid_Item_Alternaterow">
                             <td>
                                 <asp:Label ID="lblSr4" runat="server" Text="Label"></asp:Label></td>
                             <td>Production</td>

                             <td>
                                 <asp:Label ID="lblStatusP" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblProdBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblProdOn" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblProdTime" runat="server" Text="Label"></asp:Label>
                             </td>

                         </tr>

                         <tr class="Grid_Item_Alternaterow">
                             <td>
                                 <asp:Label ID="lblSr5" runat="server" Text="Label"></asp:Label></td>
                             <td>Quality</td>

                             <td>
                                 <asp:Label ID="lblStatusQ" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblQualityBy" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblQualityOn" runat="server" Text="Label"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="lblQualTime" runat="server" Text="Label"></asp:Label>
                             </td>

                         </tr>
                         <tr class="Grid_Item_Alternaterow">
                             <td colspan="6" style="border: thin groove #C0C0C0; text-align: center;">
                                 <asp:Label ID="lblRejectDetails" runat="server" ForeColor="Black" Style="font-size: large; text-align: center;" Text="Label"></asp:Label>
                             </td>
                         </tr>
                     </table>
                 </td>
                  <td style=" height: 26px;"></td>
             </tr>
             
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;</td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;</td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;</td>
             </tr>
             <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;</td>
             </tr>
            <tr>
                 <td style="">&nbsp;</td>
                 <td style="">&nbsp;</td>
             </tr>

             
            
             <tr id="RollbackRej" runat="server">
                 <td style=" height: 25px;"></td>
                 <td style=" height: 25px;"></td>
                 <td style=" height: 25px;"></td>
                 <td style="height: 25px;" colspan="2"><asp:Button ID="btnRollBackProd" runat="server" Text="Rollback Cerpac Card" OnClientClick="PopUp('AuthMsg');" OnClick="btnRollBackProd_Click" CssClass="adminbutton" Visible="False" /></td>
                     
                 <td style="height: 25px"></td>
             </tr>
            
         </table>

     </div>    
     <div id="DivAuthMsg" runat="server" align="center" visible="false">
         <table style="width: 100%;" align="center">
             <tr>
                 <td style="width: 15%;">&nbsp;</td>
                 <td style="width: 70%;">&nbsp;</td>
                 <td style="width: 15%;">&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td rowspan="3">
                     <table cellpadding="2" cellspacing="10" align="center" class="Grid_Item_Alternaterow" style="width: 100%" >
                         <tr>
                             <td style="width: 45%" align="left">Approve Authority</td>
                             <td style="width: 45%">
                                <asp:DropDownList ID="ddlAuthority" runat="server">
                                <asp:ListItem Enabled="true" Text="-Select Authoity-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="C.I.S" Value="1"></asp:ListItem>
                                <asp:ListItem Text="D.C.I" Value="2"></asp:ListItem>   
                                <asp:ListItem Text="A.C.I" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                             </td>
                             <td style="width:10%">&nbsp;
                                 <asp:RequiredFieldValidator ID="ReqAuthority" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlAuthority" InitialValue="-1" validationgroup="grpItem" setfocusonerror="True"  >
                                 </asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                              <td style="width: 20%" align="left">Purpose for Callback</td>                            
                             <td style="width: 15%"> <asp:DropDownList ID="ddlPurpose" runat="server">
                                <asp:ListItem Enabled="true" Text="-Select Purpose-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Lost Card Cases" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Data Correction" Value="2"></asp:ListItem>   
                                <asp:ListItem Text="Correction for Printing or Lamination Alignment " Value="3"></asp:ListItem>
                                <asp:ListItem Text="Correction for card Chip not readable !!" Value="4"></asp:ListItem>
                                </asp:DropDownList>

                             </td>
                             <td style="width: 5%">&nbsp; 
                                 <asp:RequiredFieldValidator ID="ReqPurpose" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlPurpose" InitialValue="-1" validationgroup="grpItem" setfocusonerror="True" >
                                 </asp:RequiredFieldValidator>

                             
      

                             </td>
                         </tr>
                         <tr>
                             
                             <td style="height: 24px;" colspan="3" align="center"></td>
                          </tr>
                         <tr>
                             
                             <td style="height: 24px;" colspan="3" align="center">
                                <asp:Button ID="btnRollBackCard" runat="server" Text="Ok" CssClass="adminbutton" validationgroup="grpItem" OnClick="btnRollBackCard_Click" />

                             </td>
                 <td style="height: 24px; width: 2%;"></td>
                             
                         </tr>
                          
                     </table>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>

     </div>
     <div id="DivCreateRequest" runat="server" align="center" visible="false">
         <table style="width: 100%;" align="center">
             <tr>
                 <td style="width: 15%;">&nbsp;</td>
                 <td style="width: 70%;">&nbsp;</td>
                 <td style="width: 15%;">&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td rowspan="3">
                     <table cellpadding="2" cellspacing="10" align="center" class="Grid_Item_Alternaterow" style="width: 100%" >
                         <tr>
                             <td style="width: 45%" align="left">Approve Authority</td>
                             <td style="width: 45%">
                                <asp:DropDownList ID="ddlAuthority1" runat="server">
                                <asp:ListItem Enabled="true" Text="-Select Authoity-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="C.I.S" Value="1"></asp:ListItem>
                                <asp:ListItem Text="D.C.I" Value="2"></asp:ListItem>   
                                <asp:ListItem Text="A.C.I" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                             </td>
                             <td style="width:10%">&nbsp;
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlAuthority" InitialValue="-1" validationgroup="grpItem" setfocusonerror="True"  >
                                 </asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                              <td style="width: 20%" align="left">Purpose for Callback</td>                            
                             <td style="width: 15%"> <asp:DropDownList ID="ddlPurpose1" runat="server">
                                <asp:ListItem Enabled="true" Text="-Select Purpose-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Lost Card Cases" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Data Correction" Value="2"></asp:ListItem>   
                                <asp:ListItem Text="Correction for Printing or Lamination Alignment " Value="3"></asp:ListItem>
                                <asp:ListItem Text="Correction for card Chip not readable !!" Value="4"></asp:ListItem>
                                </asp:DropDownList>

                             </td>
                             <td style="width: 5%">&nbsp; 
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlPurpose" InitialValue="-1" validationgroup="grpItem" setfocusonerror="True" >
                                 </asp:RequiredFieldValidator>

                             
      

                             </td>
                         </tr>
                         <tr>
                             
                             <td style="height: 24px;" colspan="3" align="center"></td>
                          </tr>
                         <tr>
                             
                             <td style="height: 24px;" colspan="3" align="center">
                                <asp:Button ID="btnProceedCallBackRequest" runat="server" Text="Proceed Callback"  CssClass="adminbutton" validationgroup="grpItem" OnClick="btnProceedCallBackRequest_Click"  />

                             </td>
                 <td style="height: 24px; width: 2%;"></td>
                             
                         </tr>
                          
                     </table>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
              <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>

     </div>
      <asp:Timer ID="Timer1" runat="server"></asp:Timer>
        <asp:HiddenField ID="HdnValue" runat="server" />
  </div>  
    
</asp:Content>

