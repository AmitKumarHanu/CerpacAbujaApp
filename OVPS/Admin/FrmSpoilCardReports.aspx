<%@ Page Title="Spoil Card Report" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="FrmSpoilCardReports.aspx.cs" Inherits="Admin_SpoilCardReports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" media="all" href="Date/jsDatePick_ltr.min.css" />

<script type="text/javascript" src="Date/jsDatePick.min.1.3.js"></script>
<script type="text/javascript" src="../JS/popcalender.js"></script>
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



        function pwd(action) {


            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;

            if (process(FromDate) > process(ToDate)) {

                alert("User To date should be greater than User From date");
                return false;
            }

            if (!confirm('Do you want to ' + action + ' this record ?')) return false;
            else
                return true;
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
            function ExportDivDataToExcel() {
                var html = document.getElementById("DivReport").innerHTML;

                html = html.replace(/>/g, '&gt;');
                html = html.replace(/</g, '&lt;');


                document.getElementById('ctl00_ContentPlaceHolder1_HdnValue').value = html;

            }

</script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">--%>                <%--</asp:ScriptManager>--%>

 <div id="R2" align="center" runat="server"  class="bcolour">
        <table style="width:100%;" id="combox">
            <tr>
                
                <td colspan="5" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Spoil Card Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>

            <tr>
            <td><asp:Label ID="lbl_from_date" runat="server" Text="From Date:"></asp:Label></td>
            <td> 
            <input type="text" class="textbox2" onkeyup="dtval(this,event)" AutoComplete="off" onkeypress="return false"
                    TabIndex="1" id="txtFromDate" onblur="validateFromDate();" 
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server" />
              <span class="star">* <a id="From" runat="server"  href="javascript:NewCal('TxtFrom','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFromDate"
                        EnableTheming="True" ErrorMessage="Select From Date" 
                        ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToValidate="txtFromDate" ErrorMessage="User active date should be greater than today's date" 
                      Display="None" EnableClientScript="true"
                        Operator="GreaterThanEqual" Type="Date" SetFocusOnError="True" ValidationGroup="a" 
                               ></asp:CompareValidator>
                                  
            </td>
            <td></td>
            <td><asp:Label ID="LblToDate" runat="server" Text="To Date:"></asp:Label></td>
            <td> 
            <input type="text" class="textbox2" onkeyup="dtval(this,event)" AutoComplete="off" onkeypress="return false"
                    TabIndex="2" id="txtToDate" onblur="validateToDate();" on 
                    placeholder="DD-MM-YYYY" style="border-width: 1px; width: 132px;" 
                    runat="server" />
                      <span class="star">* <a id="To" runat="server"  href="javascript:NewCal('txtToDate','DDMMMYYYY')">
        <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a> </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtToDate"
                        EnableTheming="True" ErrorMessage="Select User Active To" 
                        ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtToDate" ErrorMessage="User active to should be greater than the user active from" 
                      Display="None" EnableClientScript="true" 
                        Operator="greaterThan" Type="Date" SetFocusOnError="True" ValidationGroup="a"></asp:CompareValidator>
        </td>
          </tr>

          <tr>
            <td>&nbsp;</td>
            <td> 
            &nbsp;<%-- <script id="script1" language="javascript" type="text/javascript">
                                        if (!document.layers) {
                                            document.write("<img src='../Images/cal.jpg' onclick='popUpCalendar(this, txt_from_date, \"dd/mm/yyyy\")' > ")
                                        }
                                    </script>--%></td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
          
            <td> &nbsp;</td>
            <td colspan="2"><asp:Button ID="btn_generate_report" runat="server" 
                    Text="Generate Report" class="adminbutton" 
                    onclick="btn_generate_report_Click" /> </td>
              
            
            </tr>
             <tr>
                <td colspan="5" >


                   <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:NigeriaConnectionString %>" 
                        SelectCommand="SELECT * FROM [ProdReportCerpacCard]"></asp:SqlDataSource>--%>
                </td>
                </tr>
                </table>
                </div>
    <div id="R1" align="center" style="overflow: scroll; height:350px;"  runat="server" >
    
                <div id="DivReport" style="width: 800px;">
                    
                        <table style="width:100%;" align="center">
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center" colspan="4">DATEWISE SPOIL CARD&nbsp; REPORT</td>
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
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 100%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>                                                         
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Cerpac No. </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Card No. </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Wasted Reason  </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Production On</th>  
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Production User</th>                                     
                                
                            </tr>
                           
                            <%  int c = 1;
                               
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
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["StickerIssuedToApplicationID"])%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["StickerNumber"])%> 
                                </td>
                               
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["StickerWastedReason"])%>
                                </td>                               
                                <td align="center" valign="middle">
                                    <%=Convert.ToDateTime(objDs.Tables[0].Rows[i]["producedon"]).ToShortDateString()%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString  (objDs.Tables[0].Rows[i]["UserName"]) %>
                                </td>
                             </tr>
                            <%                             
                            }
                        }%>
                        </table>
                        <%}
                    } %>                       
                    <br />
     
                    </div>
      
   

       
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

