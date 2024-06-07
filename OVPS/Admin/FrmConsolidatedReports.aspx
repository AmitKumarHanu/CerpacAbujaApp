<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_ConsolidatedReports, App_Web_frmconsolidatedreports.aspx.fdf7a39c" %>

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
      
       </script>
     <script  language="javascript" type="text/javascript">
         function PrintContent() {
             //alert('hi');
             var html = "<html>";
             html += document.getElementById("DivReport").innerHTML;
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
    <div id="R2" runat="server"  >


            <table style="width:100%;" id="combox">
            <tr>
                
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        Consolidated <font class="b12"><span style="font-size: 16px; color:White;">Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
             <tr>
                  <td style="width: 30px"> &nbsp;</td>
            <td align="left"><asp:Label ID="lbl_from_date0" runat="server" Text="From Date:" style="text-align: left"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    TabIndex="1" id="txtFromDate" onblur="validateFromDate();" 
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"  />
              <span class="star">* <a id="From" runat="server"  href="javascript:NewCal('TxtFromDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>

                                  
            </td>
            <td></td>
            <td align="left"><asp:Label ID="LblToDate0" runat="server" Text="To Date:"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    tabindex="2" id="txtToDate"   onblur="validateToDate();"
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"/>
                      <span class="star">* <a id="To" runat="server"  href="javascript:NewCal('txtToDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>
        </td>
          </tr>
          <tr>
               <td style="width: 30px"> &nbsp;</td>
          <td><br /></td>
          <td><br /></td>
          <td><br /></td>
          <td><br /></td>
          <td><br /></td>
          </tr>
          <tr>
               <td style="width: 30px"> &nbsp;</td>
            <td align="left"><asp:Label ID="lbl_sorting_criteria" runat="server" Text="Criteria:"></asp:Label></td>
            <td colspan="4" align="left"> 
            <asp:CheckBox ID="chk_date" runat="server" Text=" Date Wise"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chk_nationality" runat="server" Text=" Nationality Wise" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chk_user" runat="server" Text=" User Wise"/>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chk_Zone" runat="server" Text=" Zone Wise" Visible="false"/>
           </td>
              
           
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
          <tr>
          <td style="width: 30px">&nbsp;</td>
            <td> 
                <asp:Button ID="btn_generate_report0" runat="server" 
                    Text="Generate Report" class="adminbutton" onclick="btn_generate_report_Click" 
                    /> </td>
            <td> &nbsp;</td>
            
            <td colspan="3">
                
              </td>
              
            
            </tr>
            <tr>
            <td colspan="6">
            
            </td>
            </tr>
            </table>
        

    </div>
 <div id="R1" align="center" style="overflow: scroll; height:auto;"  runat="server" >
    
                <div id="DivReport" style="width: 800px;">
                    
                        <table style="width:100%;" align="center">
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">DATEWISE CONSOLIDATED PRODUCTION REPORT</td>
                                <td align="center">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="4">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
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
                            
                        </table>
                        <% if (objDs.Tables.Count > 0)
               {
                   if (objDs.Tables[0].Rows.Count > 0)
                   { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 90%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Date</th>                                
                                <%--<th align="center" scope="col" style="white-space: nowrap;" valign="middle">Zone Name</th>--%>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nationality </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Name </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Passport </th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac No. </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">FRN No. </th>
                                <%--<th align="center" scope="col" style="white-space: nowrap;" valign="middle">Card No </th>--%>
                                 <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Receipt Date </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Expiry Date </th>                              
                                
                            </tr>
                           
                            <%  int c = 1;
                                string var1 = "ZoneCode";

                                if (chk_date.Checked == true)
                                {
                                    var1 = "CreatedON";
                                }
                                if (chk_Zone.Checked == true)
                                {
                                    var1 = "ZoneCode";
                                }
                                if (chk_nationality.Checked == true)
                                {
                                    var1 = "nationality";
                                }
                                
                   for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                  {
                           if (i>0)
                           {
                            if (i <= objDs.Tables[0].Rows.Count)
                            {
                                if (Convert.ToString(objDs.Tables[0].Rows[i - 1][var1])  ==  Convert.ToString(objDs.Tables[0].Rows[i][var1]))
                                    c = c + 1;
                               // else if (Convert.ToString(objDs.Tables[0].Rows[i - 1]["ZoneName"]) != Convert.ToString(objDs.Tables[0].Rows[i]["ZoneName"]) || i == objDs.Tables[0].Rows.Count) 
                            }

                            if ((Convert.ToString(objDs.Tables[0].Rows[i - 1][var1]) != Convert.ToString(objDs.Tables[0].Rows[i][var1])))
                            {%>
                               <tr class="Grid_Item_Alternaterow" style="border :0 ;" >   
                               
                                  
                                   <td colspan="5"></td>
                                   <td align="center"   valign="middle" class="b11" ><label id="lblTotal"  > Total : </label> </td>
                                   <td align="center"   valign="middle" class="b11"><%=Convert.ToString(c)%></td>
                                   <td colspan="4"></td>
                                </tr>
                            <%
                                c = 1;
                             } 
                       
                             }%>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=  (objDs.Tables[0].Rows[i]["CreatedON"]).ToString() %>
                                </td>
                               <%-- <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["ZoneName"])%>
                                </td>--%>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["nationality"])%>
                                </td>
                                <td align="center" valign="middle">
                                         <%=Convert.ToString(objDs.Tables[0].Rows[i]["forename"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["passport_no"])%>
                                </td>

                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_no"])%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_file_no"])%>
                                </td>

                                   <%--  <td align="center" valign="middle">
                                         <%=Convert.ToString(objDs.Tables[0].Rows[i]["CardNo"])%>
                                </td>--%>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_receipt_date"])%>
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_expiry_date"])%>
                                </td>
                               
                            </tr>
                            <%                             
                        if (i+1 == (  objDs.Tables[0].Rows.Count ))
                             {%>
                               <tr class="Grid_Item_Alternaterow" style="border :0 ;" >   
                               
                                  
                                   <td colspan="5"></td>
                                   <td align="center"   valign="middle" class="b11" ><label id="lblTotal1"  > Total : </label> </td>
                                   <td align="center"   valign="middle" class="b11"><%=Convert.ToString(c)%></td>
                                   <td colspan="4"></td>
                                </tr>
                            <%
                                c = 1;
                             } 
                      
                        }%>
                        </table>
                        <%}
               } %>                        <%--<div style=" height: 73px;" width="100px">
                            <table>
                                <tr>
                                    <td>
                                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" DocumentMapWidth="100%" Font-Names="Verdana" Font-Size="8pt" Height="100%" InteractiveDeviceInfos="(Collection)" ShowPrintButton="true" Width="100%">
                                            <LocalReport ReportPath="Admin\Reports\RdlcReport1.rdlc">
                                            </LocalReport>
                                        </rsweb:ReportViewer>
                                        <asp:GridView ID="GridView1" runat="server">     </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>--%>

                    <br />
     
                    </div>
      
   

       
  </div>
    <br />
    <div id ="DivPrint" runat="server" >
        <table style="width:100%;" align="center" id="Table1">
            <tr>
               
                <td><br /></td>
                <td><br /></td>
                 <td align="right"><asp:Button ID="Button2" runat="server" class="adminbutton" OnClientClick="PrintContent()" TabIndex="6" Text="Print Report" Visible="true"  /></td>
                 <td align="left"><asp:Button ID="btnBack" runat="server" class="adminbutton" TabIndex="7" Text="Back" Visible="true" OnClick="btnBack_Click"  /></td>
                               
                <td><br /></td>
                <td><br /></td>


            </tr>
        </table>
            </div>
    

</asp:Content>

