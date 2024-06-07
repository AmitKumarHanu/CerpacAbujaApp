<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmReviewCardList.aspx.cs" Inherits="Admin_FrmReviewCardList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 
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
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
        .auto-style1 {
            height: 29px;
        }
        .auto-style3 {
            width: 108px;
        }
        .auto-style5 {
            height: 29px;
            width: 108px;
        }
        .auto-style6 {
            font-size: 13px;
            font-weight : bold;
            font-family: 'Arial';
            color: #000000;
            width: 108px;
            height: 26px;
        }
        .auto-style7 {
            width: 190px;
            height: 26px;
        }
        .auto-style8 {
            font-size: 13px;
            font-weight : bold;
            font-family: 'Arial';
            color: #000000;
            width: 150px;
            height: 26px;
        }
        .auto-style9 {
            font-size: 13px;
            font-weight : bold;
            font-family: 'Arial';
            color: #000000;
            width: 108px;
            height: 27px;
        }
        .auto-style10 {
            width: 190px;
            height: 27px;
        }
        .auto-style11 {
            font-size: 13px;
            font-weight : bold;
            font-family: 'Arial';
            color: #000000;
            width: 150px;
            height: 27px;
        }
        .auto-style12 {
            height: 36px;
        }
    </style>
    <strong></strong>
     <table cellpadding="5" cellspacing="2" border="0" width="750px" id=loading style="display:none" runat="server">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Fetching data.Please Wait. . . . .</td></tr>
                        </table>
    <center><div align=center class="confirmation-box" height=10px style="display:none;" id=confirm  runat=server><p style="color:#006600" id="p" runat=server><strong>Review saved sucessfully</strong></p></div></center>
    <div align="center" class="bcolour" id="auth_contain" runat="server">
        <table cellpadding="2" cellspacing="10" style="width: 95%"  id="combox" >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Eligibility Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td align="center">
                    <table class="t11" style="width: 100%;" >
                        <tr>
                                       <!-- starts here -->
                        <table id="tbldtrange" runat="server">    
                      <tr>
                  <td> &nbsp;</td>
            <td align="left"><asp:Label ID="lbl_from_date0" runat="server" Text="From Date:" style="text-align: left"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="return false" autocomplete="Off"
                    TabIndex="1" id="txtFromDate" onblur="validateFromDate();" 
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"  />
              <span class="star">* <a id="From" runat="server"  href="javascript:NewCal('TxtFromDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFromDate"
                        EnableTheming="True" ErrorMessage="Select From Date" 
                        ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                                         
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td align="left"><asp:Label ID="LblToDate0" runat="server" Text="To Date:"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="return false" autocomplete="Off"
                    tabindex="2" id="txtToDate"   onblur="validateToDate();"
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"/>
                      <span class="star">* <a id="To" runat="server"  href="javascript:NewCal('txtToDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtToDate"
                        EnableTheming="True" ErrorMessage="Select User Active To" 
                        ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                        
        </td>
          </tr>
                            <tr><td colspan="6"></td></tr>
                            <tr>
                                <td colspan="6" align="center" valign="middle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    <asp:Button ID="btngenerate" runat="server" Text="Generate" CssClass="adminbutton" OnClick="btngenerate_Click"/></td>
                            </tr>
                            </table>
                     <!--ends here       -->
                        
                              <tr>
                                  <td colspan="6">
                                      <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="750px" style="display:;" runat="server"></table>
                                      <center>
                                      <table cellpadding="5" cellspacing="2" border="0" width="750px" id="detailtable" runat=server align="center" style="display:none;">
                            <tr class="b77">
                                <td colspan="5" align="center" class="auto-style12">
                                    &nbsp;Status: <asp:Label ID="lblnewrenew" runat="server" Text="Renewal"></asp:Label></td>
                           
                            </tr>
                            <tr class="b77">
                                
                                <td  align="left" class="t55 mb-lt">
                                    <strong>Personal Details</strong>
                                </td>
                                 <td  align="left" class="t55 mb-lt">
                                    <strong>From Bank </strong>
                                </td>
                                 <td  align="left" class="t55 mb-ltr">
                                    <strong>Data Entered</strong>
                                </td>
                                <td rowspan="3">
                                    <asp:Image runat="server" ID="ImgPhoto" Width="100px" Height="120px" ImageUrl="~/Images/Logo/default_logo.gif" />
                                </td>
                            </tr>
                            
                            <tr>
                                
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
                                <td align="left" class="auto-style6">
                                    Cerpac Number
                                </td>
                                <td align="left" class="auto-style7">
                                    <asp:Label ID="TxtCerpacNo" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" class="auto-style8">
                                    Date of Receipt</td>
                                <td align="left" class="auto-style7">
                                    <asp:Label ID="lbldor" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" class="auto-style9">
                                    Nationality</td>
                                <td align="left" class="auto-style10">
                                    <asp:Label ID="lblnationality" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" class="auto-style11">
                                    Expiry Date
                                </td>
                                <td align="left" class="auto-style10">
                                    <asp:Label ID="lblexp" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" class="auto-style9">
                                    FRN No</td>
                                <td align="left" class="auto-style10">
                                    <asp:Label ID="txtfrnnoorig" runat="server" CssClass="b99"></asp:Label>
                                    <asp:Label ID="txtfrnno" runat="server" CssClass="b99" Visible="false"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbldt" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" class="auto-style11">
                                    Number of Forms</td>
                                <td align="left" class="auto-style10">
                                    <asp:Label ID="lblnum" runat="server" CssClass="b99"></asp:Label>
                                </td>
                               </tr>
                                                     
            <!-- till here -->
            <tr>
                <td colspan="4">
                &nbsp;
               </td>
               </tr>                              
           <tr>
               <td colspan="4">
                   <!-- tracking table -->
                    <table align="left" style="width: 100%"   >
                         <tr class="Grid_Item_Alternaterow">
                             <td  colspan="6" style="border: thin groove #C0C0C0;  text-align : center;  ">&nbsp;&nbsp;<asp:Label ID="lblZoneName" runat="server"  style="font-size: x-large" Text="Application Report"></asp:Label>
                             </td>
                         </tr>
                         <tr class="Grid_Item_Alternaterow" style="font-size:14px; font-style :oblique;"  >
                             <td style="width: 10%" >&nbsp;&nbsp;SerialNo.</td>
                             <td style="width: 30%" >Activity</td>
                             <td style="width: 15%" >User</td>
                             <td style="width: 15%" >Date </td>
                             <td style="width: 15%" >Time </td>
                            
                         </tr>
                         <tr class="Grid_Item_Alternaterow" >
                             <td style="width: 347px" ><asp:Label ID="lblSr1" runat="server" Text="Label"/></td>
                             <td>Data Capture</td>
                                 
                             
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
                                 <asp:Label ID="lblRejectDetails" runat="server" ForeColor="Black" style="font-size: large; text-align: center;" Text="Label" Visible="false"></asp:Label>
                             </td>
                         </tr>
                     </table>
                  <!-- ends here -->
               </td>
           </tr>
            <tr class="b11">
                <td colspan="4" align="left">
                    &nbsp;</td>
            </tr>
            <tr class="b11">
                <td colspan="1" align="left" class="auto-style3">
                    Notes</td><td colspan="3" align="left"><asp:TextBox ID="txtnotes" runat="server" Height="33px" Width="501px"></asp:TextBox></td>
            </tr>
              <tr class="b11">
                <td colspan="4" align="left">
                    &nbsp;</td>
            </tr>
            <tr class="b11">
                <td class="auto-style5"></td>
                <td align="center" colspan="1" class="auto-style1">
                    <asp:Button ID="btnverify" runat="server" class="adminbutton" Text="Card is ok"  
                        Width="140px" onclick="btnverify_Click" OnClientClick="change()" />
                    
                </td>
               
                 <td align="center" colspan="1" class="auto-style1">
                   <asp:Button ID="Button1" runat=server Text="Data Inaccurate" width=149px
                            CssClass=adminbutton onclick="btnsubmit_Click" />
                    
                </td>
                
            </tr>
                                                      
        </table>
                                          </center>
                                  </td>
                                  <tr>
                                      <td colspan="6">
                                          <div>
                             <asp:GridView ID="GridViewreview" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="cerpac_no"
                        OnPageIndexChanging="GridViewreview_PageIndexChanging" OnRowEditing="GridViewreview_RowEditing" OnRowCreated="GridViewreview_RowCreated" 
                        OnSelectedIndexChanged="GridViewreview_SelectedIndexChanged" Visible="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerpac No">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of Production">
                                <ItemTemplate>
                                    <asp:Label ID="lblformno" runat="server" Text='<%# Bind("ProducedOn") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>

                             
                            
                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView></div>
                                      </td>
                                  </tr>
                              </tr>
                            <tr><td><asp:LinkButton ID="lnkgrd" runat="server" OnClick="lnkgrd_Click">Show Records</asp:LinkButton></td></tr>
                    </table>
                     &nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            
            </table>
         
    </div>
    <script type="text/javascript">
        var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
</asp:Content>

