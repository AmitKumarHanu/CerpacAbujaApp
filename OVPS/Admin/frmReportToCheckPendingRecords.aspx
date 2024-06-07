﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmReportToCheckPendingRecords.aspx.cs" Inherits="Admin_frmReportToCheckPendingRecords" %>

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
    </script>

     <div id="R2" runat="server" >
            <table style="width:100%;" id="combox">
            <tr>
                
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        &nbsp;<font class="b12"><span style="font-size: 16px; color:White;">Pending Records Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
             <tr>
                  <td style="width: 30px"> &nbsp;</td>
            <td align="left"><asp:Label ID="lbl_from_date0" runat="server" Text="From Date:" style="text-align: left"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    tabindex="1" id="txtFromDate" onblur="validateFromDate();" 
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
                    <td></td>
                    <td>Select Zone:</td>
                    <td colspan="4">

                        <asp:DropDownList ID="dpd_zone" runat="server" CssClass="textbox2" Width="170px" >
                             <asp:ListItem Value="ALL">ALL</asp:ListItem>
                                    <asp:ListItem Value="512">Abuja</asp:ListItem>
                                    <asp:ListItem Value="513">Lagos</asp:ListItem>
                                    <asp:ListItem Value="514">Bauchi</asp:ListItem>
                                    <asp:ListItem Value="515">Benin</asp:ListItem>
                                    <asp:ListItem Value="516">Owerri</asp:ListItem>
                                    <asp:ListItem Value="517">Ibadan</asp:ListItem>
                                    <asp:ListItem Value="518">Makurdi</asp:ListItem>
                                    <asp:ListItem Value="519">Kaduna</asp:ListItem>

                </asp:DropDownList>
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
          <td style="width: 30px">&nbsp;</td>
            <td colspan="6" align="center"> 
                <asp:Button ID="btn_generate" runat="server" 
                    Text="Generate Report" class="adminbutton" 
                    onclick="btn_generate_Click"   /> 
           
            </td>
            </tr>
            <tr>
            <td colspan="6">
            
            </td>
            </tr>
          </table></div>
           <script type="text/javascript">

               function process(date) {
                   var parts = date.split("-");
                   return new Date(parts[2], parts[1] - 1, parts[0]);
               }



</script>

     <script language="javascript" type="text/javascript">
         function ExportDivDataToExcel() {

             alert('hi');
             // var html = "<html>";
             // html += document.getElementById("DivReport").innerHTML;
             // html += "</html>";
             var html = "<html>";
             // alert('hi');
             html += document.getElementById("DivReport").innerHTML;
             html += "</html>";
             //  alert(html);

             html = html.replace(/>/g, '&gt;');
             html = html.replace(/</g, '&lt;');

             document.getElementById('<%=HdnValue.ClientID %>').value = html;
             //   alert(html);

         }


</script>

  <div id="R1" align="center"   runat="server" visible="false">
    
                <div id="DivReport" style="width: 800px;">
                     <% if (objDsAO.Tables.Count > 0)
                        {
                            if (objDsAO.Tables[0].Rows.Count > 0)
                            { %>
                        <table   class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 80%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                           
                           
                         <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="4" class="column_right" >ModuleWise Pending Records Report</th>
                               
                            </tr>

                            <tr class="Grid_Header">
                                <th align="center" rowspan="2">Description</th>                                
                                <th colspan="3" align="center">Total Pending Records</th>
                            </tr>
                            
                             <tr class="Grid_Header">
                                <th style="width:20%" align="center">AO Forms</th>
                                <th style="width:20%" align="center">AR Forms</th>
                                <th style="width:20%" align="center">CR Forms</th>
                               
                             </tr>

                            <tr class="Grid_Item_Alternaterow">
                                <td > <label id="lblTotal" > Application Awating Approvals </label></td>
                                
                                <td align="center"><%=Convert.ToString(objDsAO.Tables[0].Rows[0]["auth"])%></td>
                              <td align="center"><%=Convert.ToString(objDsAR.Tables[0].Rows[0]["auth"])%></td>
                                <td align="center"><%=Convert.ToString(objDsCR.Tables[0].Rows[0]["auth"])%></td>
                               
                            </tr>

                            <tr class="Grid_Item_Alternaterow">
                                <td ><label id="Label1"  > Application Awating Production </label></td>                                
                                <td align="center"><%=Convert.ToString(objDsAO.Tables[0].Rows[0]["prod"])%></td>
                                <td align="center"><%=Convert.ToString(objDsAR.Tables[0].Rows[0]["prod"])%></td>
                                <td align="center"><%=Convert.ToString(objDsCR.Tables[0].Rows[0]["prod"])%></td>
                                
                      
                            </tr>

                             <tr class="Grid_Item_Alternaterow">
                                <td ><label id="Label2"  > Application Awating Contec Verification </label></td>                                
                                <td align="center"><%=Convert.ToString(objDsAO.Tables[0].Rows[0]["ISARCR"])%></td>
                                <td align="center"><%=Convert.ToString(objDsAR.Tables[0].Rows[0]["ISARCR"])%></td>
                                 <td align="center"><%=Convert.ToString(objDsCR.Tables[0].Rows[0]["ISARCR"])%></td>                                
                            </tr>

                             <tr class="Grid_Item_Alternaterow">
                                <td ><label id="Label3"  > Application Awating Quality </label></td>
                                
                                <td align="center"><%=Convert.ToString(objDsAO.Tables[0].Rows[0]["qual"])%></td>
                                <td align="center"><%=Convert.ToString(objDsAR.Tables[0].Rows[0]["qual"])%></td>
                                <td align="center"><%=Convert.ToString(objDsCR.Tables[0].Rows[0]["qual"])%></td>
                                
                      
                            </tr>

                            </table>
                            
                            <%}
                        } %>
                            </div>
                            <asp:HiddenField ID="HdnValue" runat="server" />
                            </div>
</asp:Content>

