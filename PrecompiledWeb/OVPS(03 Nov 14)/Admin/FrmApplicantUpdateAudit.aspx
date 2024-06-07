<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmApplicantUpdateAduit, App_Web_frmapplicantupdateaudit.aspx.fdf7a39c" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" media="all" href="Date/jsDatePick_ltr.min.css" />

<script type="text/javascript" src="Date/jsDatePick.min.1.3.js"></script>
<script type="text/javascript" src="../JS/popcalender.js"></script>
<script language="javascript" type="text/javascript">

    var minYear = 1908;
    var maxYear = 2200;
   </script>
   <script language="javascript" type="text/javascript">
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
       function AlfaNum2(t) {
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
      
       </script>
     <script  language="javascript" type="text/javascript">
         function PrintContent() {
            
             var html = "<html>";
             html += document.getElementById("DivReport").innerHTML;
             html += "</html>";
             alert('hi !');
             var printWin = window.open('', '', 'location=no,width=10,height=10,left=50,top=50,toolbar=no,scrollbars=no,status=0,titlebar=no');
             alert('hi !!');
             printWin.document.write(html);
             printWin.document.close();
             printWin.focus();
             printWin.print();
             printWin.close();

         }
        
         function ExportDivDataToExcel() {
             var html = document.getElementById("DivReport").innerHTML;

             html = html.replace(/>/g, '&gt;');
             html = html.replace(/</g, '&lt;');


             document.getElementById('ctl00_ContentPlaceHolder1_HdnValue').value = html;

         }
</script>
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
    function NumNSign(t) {

        var cod = "+-0123456789";
        var v = cod
        var w = "";
        for (var i = 0; i < t.value.length; i++) {
            x = t.value.charAt(i);
            if (v.indexOf(x, 0) != -1)
                w += x;
        }
        t.value = w;
    }
    function AlfaNumeric(t) {
        var cod = " ";
        var v = cod
        var w = "";
        if (event.keyCode >= 37 && event.keyCode <= 40) {
        }
        else {
            for (var i = 0; i < t.value.length; i++) {
                x = t.value.charAt(i);
                if (v.indexOf(x, 0) == -1)
                    w += x;
            }
            t.value = w;
        }
    }
    

    function validateFromDate() {

        var currVal = document.getElementById("<%= txtFromDate.ClientID%>").value;
        if (currVal == "") {
            alert("Please enter From Date ");
            return false;
        }

        //Declare Regex 
        var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var dtArray = currVal.match(rxDatePattern); // is format OK?

        if (dtArray == null) {
            alert("Please enter valid From Date ");
            return false;
        }

        var today = new Date();

        //Checks for mm/dd/yyyy format.
        dtDay = dtArray[1];
        dtMonth = dtArray[3];
        dtYear = dtArray[5]

        if (process(currVal) > today) {
            //msg += "Date of Issue should be less than today's date \n";
            alert("Form date should be less than today's date");
            //objdoi.value = "";
            //blnFalg = false;
            //blnDoiFalg = false;
            //objdoi.value = "";
            currVal = "";
            return false;
        }


        if (dtMonth < 1 || dtMonth > 12) {
            alert("Please enter valid month for From Date ");
            return false;
        }
        else if (dtDay < 1 || dtDay > 31) {
            alert("Please enter valid day for  From Date ");
            return false;
        }
        else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
            alert("Please enter valid day for date  ");
            return false;
        }
        else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
            alert("Please enter a valid 4 digit year between " + minYear + " and " + today);
            return false;
        }
        else if (dtMonth == 2) {
            var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
            if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                alert("Please enter valid From date ");
                return false;
            }
        }

        return true;
    }

    function process(date) {
        var parts = date.split("-");
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }

    function validateToDate() {

        var currVal = document.getElementById("<%= txtToDate.ClientID%>").value;
        if (currVal == "") {
            alert("Please enter To Date ");
            return false;
        }

        //Declare Regex 
        var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var dtArray = currVal.match(rxDatePattern); // is format OK?

        if (dtArray == null) {
            alert("Please enter valid To Date ");
            return false;
        }

        var today = new Date();

        //Checks for mm/dd/yyyy format.
        dtDay = dtArray[1];
        dtMonth = dtArray[3];
        dtYear = dtArray[5]

        if (process(currVal) > today) {
            //msg += "Date of Issue should be less than today's date \n";
            alert("To date should be less or equal than today's date");
            //objdoi.value = "";
            //blnFalg = false;
            //blnDoiFalg = false;
            //objdoi.value = "";
            currVal = "";
            return false;
        }


        if (dtMonth < 1 || dtMonth > 12) {
            alert("Please enter valid month for To Date ");
            return false;
        }
        else if (dtDay < 1 || dtDay > 31) {
            alert("Please enter valid day for  To Date ");
            return false;
        }
        else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
            alert("Please enter valid day for date  ");
            return false;
        }
        else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
            alert("Please enter a valid 4 digit year between " + minYear + " and " + today);
            return false;
        }
        else if (dtMonth == 2) {
            var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
            if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                alert("Please enter valid To date ");
                return false;
            }
        }

        return true;
    }

    function process(date) {
        var parts = date.split("-");
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }
    
    

</script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">--%><%--</asp:ScriptManager>--%>
    <div id="R1" runat="server"  >
                    <table style="width:100%;" id="combox">
            <tr>
                
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center"> <font class="b12"><span style="font-size: 16px; color:White;">Applicant Update Audit Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
                <tr>
               <td style="width: 10%"> &nbsp;</td>
               <td style="width: 25%">&nbsp;</td>
            <td style="width: 50%"> </td>
            <td style="width: 5%"></td>
            <td style="width: 5%"></td>
            <td style="width: 5%"></td>
          </tr>
                <tr>
               <td style="width: 30px"> &nbsp;</td>
                      <td><asp:Label ID="lblSerachType" runat="server" Text="Search Type:"></asp:Label></td>
            <td> 
                <asp:RadioButtonList ID="rdOpt" runat="server" OnSelectedIndexChanged="rdOpt_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal" >
                    <asp:ListItem>Cerpac No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem>Data Views</asp:ListItem>
                </asp:RadioButtonList>
           </td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
                <tr>
               <td style="width: 30px"> &nbsp;</td>
                      <td>&nbsp;</td>
            <td> 
           </td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>

          <tr id="trCerpacNoViews" runat="server">
               <td style="width: 30px"> &nbsp;</td>
                      <td><asp:Label ID="lblCerpacNo" runat="server" Text="Cerpac No." style="text-align: left"></asp:Label></td>
            <td> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    TabIndex="1" id="txtCerpacNo" onkeyup="AlfaNum2(this);" 
                     style="border-width: 1px; width: 132px;" 
                    runat="server"  /></td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr id="trFromDate" runat="server">
                  <td style="width: 30px"> &nbsp;</td>
            <td align="left"><asp:Label ID="lbl_from_date0" runat="server" Text="From Date:" style="text-align: left"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    TabIndex="2" id="txtFromDate"  
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"  />
              <span class="star">* <a id="From" runat="server"  href="javascript:NewCal('TxtFromDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>

                                  
            </td >
            <td></td>
            <td align="left">&nbsp;</td>
            <td align="left"> 
            &nbsp;
        </td>
          </tr>
          <tr id="trToDate" runat="server">
               <td style="width: 30px"> &nbsp;</td>
          <td><asp:Label ID="LblToDate0" runat="server" Text="To Date:"></asp:Label><br /></td>
          <td> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    tabindex="3" id="txtToDate"   
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"/>
              <span class="star">* <a id="To" runat="server"  href="javascript:NewCal('txtToDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>
          </td>
          <td><br /></td>
          <td><br /></td>
          <td><br /></td>
          </tr>
          <tr>
               <td style="width: 30px"> &nbsp;</td>
            <td align="left">&nbsp;</td>
            <td colspan="4" align="left"> 
            &nbsp;</td>
              
           
          </tr>

          
          <tr>
          <td style="width: 30px">&nbsp;</td>
            <td> 
                <asp:Button ID="btn_generate_report0" runat="server" 
                    Text="Generate Report" class="adminbutton" onclick="btn_generate_report_Click" 
                    /> </td>
            <td>
                 &nbsp;</td>
            
            <td colspan="3">
                
              </td>
              
            
            </tr>
            <tr>
            <td colspan="6">
            
            </td>
            </tr>
            </table>
        
    </div>
 <div id="R2" align="center" style="overflow: scroll; height:350px;"  runat="server" >
    
                <div id="DivReport"  style="width: 800px;">
                    
                        <table style="width:100%;" align="center">
                            <tr id="Opt2a" runat="server">
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">DATEWISE APPLICANT UPDATES AUDIT REPORT</td>
                                <td align="center"></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr id="Opt1" runat="server">
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">APPLICANT UPDATE RECORD DETAILS</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr id="Opt2b" runat="server">
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">(FROM
                                    <asp:Label ID="lblFDate" runat="server"></asp:Label>
&nbsp;TO&nbsp;<asp:Label ID="lblTDate" runat="server"></asp:Label>
                                    )</td>
                                <td align="center">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>  
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                                <td align="right">
                               

                                </td>
                                <td align="center">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>  
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">&nbsp;</td>
                                <td align="center">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>  
                                                      
                        </table>
                        <% if (objDs.Tables.Count > 0)
               { %>

                                               
                   <%   
                   if (objDs.Tables[0].Rows.Count > 0)
                   { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 90%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" colspan="13" style="white-space: nowrap;" valign="middle">Current Details</th>
                                <th align="center" scope="col" colspan="16" style="white-space: nowrap;" valign="middle">Previous Details</th>
                            </tr>
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.No.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac No.</th> 
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac File No.</th> 
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac Issue Date</th> 
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac Expiry Date</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company Name</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company Address 1</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company Address 2</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Designation</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nigeria Address 1</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nigeria Address 2</th>    
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Abroad Address 1</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Abroad Address 2</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.No.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac No.</th> 
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac Issue Date</th> 
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac Expiry Date</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company Name</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company Address 1</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company Address 2</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Designation</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nigeria Address 1</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nigeria Address 2</th>    
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Abroad Address 1</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Abroad Address 2</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Updated By</th>   
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Updated On</th>                                                          
                                
                            </tr>                           
                            <%                             
                                
                   for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                  {
                           if (i>=0)
                           {
                            %>                             
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td> 
                                <td align="center" valign="middle"> 
                                    <%=  (objDs.Tables[0].Rows[i]["Cerpac_no"]).ToString() %>
                                </td>                           
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_file_no"])%>
                                </td>
                                 <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_receipt_date"])%>
                                </td>
                                <td align="center" valign="middle">
                                         <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_expiry_date"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["company"])%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["company_add_1"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["company_add_2"])%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["designation"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["nigeria_add_1"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["nigeria_add_2"])%>
                                </td>                                
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["abroad_add_1"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["abroad_add_2"])%>
                                </td>
                               
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td> 
                               
                                 <td align="center" valign="middle"> 
                                    <%=  (objDs.Tables[0].Rows[i]["Cerpac_no"]).ToString() %>
                                </td>
                                                                
                                 <% 
                                //------------------cerpac_issue_date--------------------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_issue_date"]) == Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_receipt_date"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_issue_date"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_issue_date"])%>
                                </td>
                                 <%
                               }
                               //-----------cerpac_exp_date---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_exp_date"]) == Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_expiry_date"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_exp_date"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_exp_date"])%>
                                </td>
                                 <%
                               }
                               //-----------CompName---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["CompName"]) == Convert.ToString(objDs.Tables[0].Rows[i]["company"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["CompName"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["CompName"])%>
                                </td>
                                 <%
                               }
                               //-----------CompAdd1---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["CompAdd1"]) == Convert.ToString(objDs.Tables[0].Rows[i]["company_add_1"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["CompAdd1"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["CompAdd1"])%>
                                </td>
                                 <%
                               }
                                //-----------CompAdd2---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["CompAdd2"]) == Convert.ToString(objDs.Tables[0].Rows[i]["company_add_2"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["CompAdd2"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["CompAdd2"])%>
                                </td>
                                 <%
                               }
                               //-----------Designat---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["Designat"]) == Convert.ToString(objDs.Tables[0].Rows[i]["designation"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["Designat"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["Designat"])%>
                                </td>
                                 <%
                               }
                               //-----------addnigeria1---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["addnigeria1"]) == Convert.ToString(objDs.Tables[0].Rows[i]["nigeria_add_1"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addnigeria1"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addnigeria1"])%>
                                </td>
                                 <%
                               }
                               //-----------addnigeria2---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["addnigeria2"]) == Convert.ToString(objDs.Tables[0].Rows[i]["nigeria_add_2"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addnigeria2"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addnigeria2"])%>
                                </td>
                                 <%
                               }
                               //-----------addabroad1---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["addabroad1"]) == Convert.ToString(objDs.Tables[0].Rows[i]["abroad_add_1"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addabroad1"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addabroad1"])%>
                                </td>
                                 <%
                               }
                               //-----------addabroad2---------------
                               if (Convert.ToString(objDs.Tables[0].Rows[i]["addabroad2"]) == Convert.ToString(objDs.Tables[0].Rows[i]["abroad_add_2"]))
                                { %>                         
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addabroad2"])%>
                                </td>
                                 <%
                                } else
                                {
                                   %>                         
                                <td align="center" valign="middle" style="color:red" >
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["addabroad2"])%>
                                </td>
                                 <%
                               }
                                %>                                                               
                               
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["UserName"])%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["UpdatedON"])%>
                                </td>
                                                                                          
                            </tr>
                           <%                               
                             } 
                      
                        }%>
                        </table>                                
                          
                        <%}
               } %>

                    </div>
          <br />
        </div>
    <div id ="DivPrint" runat="server" >
        <table style="width:100%;" align="center" id="Table1">
            <tr>
               
                <td><br /></td>
                <td align="center"><br />
                <asp:ImageButton ID="BtnPrint" runat="server" OnClientClick="PrintContent()" ImageUrl="~/Images/print.png" Height="40px" Width="33px" />
                <asp:ImageButton ID="BtnExcel" runat="server" OnClick="btnExcel_Click" OnClientClick="ExportDivDataToExcel()" ImageUrl="~/Images/excel_logo.gif" />
                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Images/gtk_refresh.png" Height="40px" Width="33px" OnClick="btnBack_Click" />
                 </td>
                <td><br /></td>
                <td><br /></td>


            </tr>
        </table>
            </div>

  
    
     <asp:HiddenField ID="HdnValue" runat="server" />
    
     
</asp:Content>

