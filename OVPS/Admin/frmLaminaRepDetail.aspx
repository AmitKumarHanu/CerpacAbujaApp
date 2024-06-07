<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmLaminaRepDetail.aspx.cs" Inherits="Admin_frmLaminaRepDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" />
    <link href="../css/country.css" rel=Stylesheet type="text/css" /> 
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
    </style>
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
          function PrintR1() {
              //alert('hi');
              var html = "<html>";
              html += document.getElementById("R1").innerHTML;
              html += "</html>";

              var printWin = window.open('', '', 'location=no,width=10,height=10,left=50,top=50,toolbar=no,scrollbars=no,status=0,titlebar=no');

              printWin.document.write(html);
              printWin.document.close();
              printWin.focus();
              printWin.print();
              printWin.close();
          }
          function ExportDivDataToExcelR1() {
              var html = document.getElementById("R1").innerHTML;

              html = html.replace(/>/g, '&gt;');
              html = html.replace(/</g, '&lt;');


              document.getElementById('ctl00_ContentPlaceHolder1_HdnValue').value = html;

          }

          function PrintR2() {
              //alert('hi');
              var html = "<html>";
              html += document.getElementById("R2").innerHTML;
              html += "</html>";

              var printWin = window.open('', '', 'location=no,width=10,height=10,left=50,top=50,toolbar=no,scrollbars=no,status=0,titlebar=no');

              printWin.document.write(html);
              printWin.document.close();
              printWin.focus();
              printWin.print();
              printWin.close();
          }
          function ExportDivDataToExcelR2() {
              var html = document.getElementById("R2").innerHTML;

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
    </script>

    <strong></strong>
    <div id="MainDiv" runat="server" align="center" >
                <div   class="bcolor" align="center"  id="combox" >

        <table cellpadding="2" cellspacing="10" style="width: 95%"   >
          <tr>
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Laminate Card Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>


            <tr>
            <td colspan="6"></td>
            </tr>
            <tr>
            <td></td>        
            <td colspan="2"><asp:Label ID="lbl_tot_lam" Text="Total No. of Laminate:" runat="server" Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_tot_lam" runat="server"></asp:Label></td>
            <td colspan="2"><asp:Label ID="lbl_used_lam" Text="Laminate Used:" runat="server"  Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_used_lam" runat="server"></asp:Label></td>
            <td></td>   
             </tr>        
             <tr>
            <td colspan="6"></td>
            </tr>

             <tr>
              <td></td>            
            <td colspan="2"><asp:Label ID="lbl_wasted_lam" Text="Laminate Wasted:" runat="server" Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_wasted_lam" runat="server"></asp:Label></td>
            <td colspan="2"><asp:Label ID="lbl_rest_lam" Text="Total No. of Unused Laminate:" runat="server"  Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_rest_lam" runat="server"></asp:Label></td>
             <td></td>   
            </tr>
            <tr>
            <td colspan="6"></td>
            </tr>
            <tr>
            <td colspan="4"></td>   
            <td colspan="2" align="center"> 
                <asp:Button ID="DatawiseR" runat="server" Text="Datewise Report" 
                    class="adminbutton" onclick="DatawiseR_Click"    /> 
            </td>
            </tr>             
        </table>
        </div>
        </div>
 <div id="Datewise" runat="server" visible="false" align="center">
 <div id="combox" class="bcolor" align="center"  >
            <table cellpadding="2" cellspacing="10" style="width: 95%"  >
            <tr>                
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        &nbsp;<font class="b12"><span style="font-size: 16px; color:White;">Datawise Laminate Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
             <tr>
                  <td style="width: 30px"> &nbsp;</td>
            <td align="left"><asp:Label ID="Label1" runat="server" Text="From Date:" style="text-align: left"></asp:Label></td>
            <td align="left"> 
            <input type="text" class="textbox2" onkeypress="retrun false" 
                    tabindex="1" id="txtFromDate" onblur="validateFromDate();" 
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server"  />
              <span class="star">* <a id="From" runat="server"  href="javascript:NewCal('TxtFromDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>

                                  
            </td>
            <td></td>
            <td align="left"><asp:Label ID="Label2" runat="server" Text="To Date:"></asp:Label></td>
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
          <td colspan="2" style="width: 30px"> 
               </td>
            <td colspan="2" align="center"> 
                <asp:Button ID="btnCardReport" runat="server" Text="Laminate Card Report" 
                    class="adminbutton" onclick="btnCardReport_Click"    /> 
            </td>
            <td colspan="2" align="center"> 
                <asp:Button ID="btnWastedReport" runat="server" Text="Laminate Wasted Report" 
                    class="adminbutton" onclick="btnWastedReport_Click"    /> 
            </td>
            </tr>
             <tr>
               <td style="width: 30px"> &nbsp;</td>
          <td><br /></td>
          <td><br /></td>
          <td><br /></td>         
         
          </table>
          </div>
          </div>
    <div id="LamCard" align="center"   runat="server" visible="false" style="width: 100%; height:550px; overflow: scroll; clip: rect(auto, auto, auto, auto);" >
    <table  >
    <tr align="center">
    <td><br /></td>
    <td><br /></td>
     <td > <asp:ImageButton ID="BtnPrint" runat="server" OnClientClick="PrintR1()" ImageUrl="~/Images/print.png" Height="40px" /></td>
               
      <td  ><asp:ImageButton ID="BtnExcel" runat="server" 
              OnClientClick="ExportDivDataToExcelR1()" ImageUrl="~/Images/excel_logo.gif" 
              onclick="BtnExcel_Click" /> </td>
      <td> <asp:ImageButton ID="btnRefresh" runat="server" 
              ImageUrl="~/Images/gtk_refresh.png" Height="40px" Width="33px" 
              onclick="btnRefresh_Click" /></td>
      <td><br /></td>
      </tr>
      <tr>    
    <td colspan="6" align="center">
    <div id="R1" style="width: 800px; " >
                     <% if (objDsCR.Tables.Count > 0)
                        {
                            if (objDsCR.Tables[0].Rows.Count > 0)
                            { %>
                        <table   class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 80%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                           
                           
                         <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="7" class="column_right" >
                                    Laminate Card Report</th>
                               
                            </tr>
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="7" class="column_right" >
                                  Location : <asp:Label ID="lblZoneName" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;(from 
                                    <asp:Label ID="lblFDate" runat="server"></asp:Label>
&nbsp;to&nbsp;<asp:Label ID="lblTDate" runat="server"></asp:Label>
                                    )</th>
                               
                            </tr>

                            <tr class="Grid_Header">
                                 <th align="center">Sl No.</th> 
                                <th align="center">Cerpac No.</th>  
                                <th align="center">FRN</th>                                
                                <th align="center">Card No</th>
                                <th align="center">Front Lamination No.</th>
                                <th align="center">Back Lamination No.</th>
                                <th align="center">Date</th>
                                
                               
                             </tr>
                            <%  
                               
                        for (int i = 0; i < objDsCR.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> <%=Convert.ToString(i+1)%> </td>
                                <td align="center"> <%=Convert.ToString(objDsCR.Tables[0].Rows[i]["lam_issued_cerpac_no"])%></td>   
                                <td align="center"> <%=Convert.ToString(objDsCR.Tables[0].Rows[i]["lam_issued_cerpac_fileno"])%></td>                                                                                       
                                <td align="center"><%=Convert.ToString(objDsCR.Tables[0].Rows[i]["Card_no"])%></td>
                                <td align="center" ><%=Convert.ToString(objDsCR.Tables[0].Rows[i]["FrontL"])%></td>
                                <td align="center" ><%=Convert.ToString(objDsCR.Tables[0].Rows[i]["backL"])%></td>  
                                <td align="center" ><%=Convert.ToString(objDsCR.Tables[0].Rows[i]["Dt"])%></td>                                
                            </tr>
                            <%                             
                            }
                        }%>
                           </table>
                            
                            <%}
                        } %>
                            </div>
    </td>
    </tr>
    </table>               
               </div>
    <div id="LamWaste" align="center"   runat="server" visible="false" style="width: 100%; height:550px; overflow: scroll; clip: rect(auto, auto, auto, auto);" >
    <table  >
    <tr align="center">
    <td><br /></td>
    <td><br /></td>
     <td > <asp:ImageButton ID="BtnPrintW" runat="server" OnClientClick="PrintR2()" ImageUrl="~/Images/print.png" Height="40px" /></td>
               
      <td  >
              <asp:ImageButton ID="BtnExcelW" runat="server" 
              OnClientClick="ExportDivDataToExcelR2()" 
              ImageUrl="~/Images/excel_logo.gif" onclick="BtnExcelW_Click" 
              /> </td>
      <td> <asp:ImageButton ID="btnRefreshW" runat="server" 
              ImageUrl="~/Images/gtk_refresh.png" Height="40px" Width="33px" 
              onclick="btnRefreshW_Click" /></td>
      <td><br /></td>
      </tr>
    <tr>    
    <td colspan="6" align="center">
                <div id="R2" style="width: 800px;">
                     <% if (objDsWR.Tables.Count > 0)
                        {
                            if (objDsWR.Tables[0].Rows.Count > 0)
                            { %>
                        <table   class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 80%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                           
                           
                         <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="7" class="column_right" >
                                    Laminate
                                    Wasted Report</th>
                               
                            </tr>
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="7" class="column_right" >
                                  Location : <asp:Label ID="lblZoneNameW" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;(from 
                                    <asp:Label ID="lblFDateW" runat="server"></asp:Label>
&nbsp;to&nbsp;<asp:Label ID="lblTDateW" runat="server"></asp:Label>
                                    )</th>
                               
                            </tr>

                            <tr class="Grid_Header">
                                 <th align="center">Sl No.</th> 
                                <th align="center">Cerpac No.</th> 
				<th align="center">FRN</th>                                  
                                <th align="center">Card No</th>
                                <th align="center">Front Lamination No.</th>
                                <th align="center">Back Lamination No.</th>
                                <th align="center">Date</th>
                                
                               
                             </tr>
                            <%  
                               
                                for (int i = 0; i < objDsWR.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> <%=Convert.ToString(i+1)%> </td>
                                <td align="center"> <%=Convert.ToString(objDsWR.Tables[0].Rows[i]["lam_issued_cerpac_no"])%></td>   
                                <td align="center"> <%=Convert.ToString(objDsWR.Tables[0].Rows[i]["lam_issued_cerpac_fileno"])%></td>                                                                                       
                                <td align="center"> <%=Convert.ToString(objDsWR.Tables[0].Rows[i]["Card_no"])%></td>
                                <td align="center"> <%=Convert.ToString(objDsWR.Tables[0].Rows[i]["FrontL"])%></td>
                                <td align="center"> <%=Convert.ToString(objDsWR.Tables[0].Rows[i]["backL"])%></td>  
                                <td align="center" ><%=Convert.ToString(objDsWR.Tables[0].Rows[i]["Dt"])%></td>                               
                            </tr>
                            <%                             
                            }
                        }%>
                           </table>
                            
                            <%}
                        } %>
                            </div>
              </td>
    </tr>
    </table>          
     </div>
     <asp:HiddenField ID="HdnValue" runat="server" />
</asp:Content>

