<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" enableeventvalidation="false" validaterequest="false" inherits="Admin_frmMagicReport, App_Web_frmmagicreport.aspx.fdf7a39c" %>

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



        function pwd(action) {


            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;

            if (process(FromDate) > process(ToDate)) {

                alert("User To date should be greater than User From date");
                return false;
            }

            // if (!confirm('Do you want to ' + action + ' this record ?')) return false;
            else
                return true;
        }
        
        
 </script>

     <script language="javascript" type="text/javascript">

         function ShowPopUp(e) {
             var lbl = 'AO121212';
               //alert(lbl.value);
               var ReturnValue = window.showModalDialog("CompanyPopUp.aspx?val=" + document.getElementById("<%=txtcompname.ClientID%>").value + "&no=" + lbl, e.paras, "dialogWidth=450px;dialogHeight=500px;scroll:no; status:no;")

               var value = ReturnValue.split(',');
               document.getElementById("<%=txtcompid.ClientID%>").value = value[0];
                 document.getElementById("<%=txtcompname.ClientID%>").value = value[1];


           }

           // function for returning company name to tool tip
           function compnyname() {
               var desig = document.getElementById("<%=txtcompname.ClientID%>").value;
               document.getElementById('comptool').title = desig;
           }
           // ends here
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
    <script language="javascript" type="text/javascript">
        function ExportDivDataToExcel() {
           
           // alert('hi');
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
    <style type="text/css">
    .modal
    {
         position: fixed;
        top: 0;
        left: 0;
        background-color: lightgray;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>

 <script type="text/javascript" src="../JS/jquery.min.js"></script>

    <script type="text/javascript">

        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });


</script>
     <div class="loading" align="center">
    Report Generation In Progress. Please wait...<br />
    <br />
    <img src="../Images/loading.gif" alt="" />
</div>
  <div id="R2" runat="server"  >


            <table style="width:100%;" id="combox">
            <tr>
                
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">Production Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
             <tr>
                  <td style="width: 30px"> &nbsp;</td>
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
                        <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToValidate="txtFromDate" ErrorMessage="User active date should be greater than today's date" 
                      Display="None" EnableClientScript="true" 
                        Operator="GreaterThanEqual" Type="Date" SetFocusOnError="True" ValidationGroup="a" 
                               ></asp:CompareValidator>
                                  
            </td>
            <td></td>
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
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtToDate" ErrorMessage="User active to should be greater than the user active from" 
                      Display="None" EnableClientScript="true"
                        Operator="greaterThan" Type="Date" SetFocusOnError="True" ValidationGroup="a"></asp:CompareValidator>
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
            <td align="left">
              <strong> 

                                <asp:DropDownList ID="dropdown_SearchOption" runat="server" AutoPostBack="true" CssClass="textbox2" 
                    Height="25px"  BackColor="#bcc7d8" ForeColor="#333333"
                                    Width="149px" Font-Bold="true" 
                    onselectedindexchanged="dropdown_SearchOption_SelectedIndexChanged">

                                    <asp:ListItem Value="select">--Select Criteria--</asp:ListItem>
                                    <asp:ListItem Value="ProducedONDate">Generic</asp:ListItem>
                                    <asp:ListItem Value="Nationality">Nationality</asp:ListItem>
                                    <asp:ListItem Value="Company">Company</asp:ListItem>
                                    <asp:ListItem Value="User">User</asp:ListItem>
                                    
                                </asp:DropDownList></strong> 
            </td>

            <td colspan="4" align="left"> 
                <span id="sp1" runat="server">
                <asp:DropDownList ID="dpd_search" runat="server" CssClass="textbox2" Width="170px"
                    >
                </asp:DropDownList>
                    </span>

            <span id="sp2" runat="server">


                <a title="abcde" id="comptool" onmouseover="return compnyname();">
                                    <asp:TextBox ID="txtcompname" runat="server" CssClass="textbox2" Width="300px" Enabled="true" AutoComplete="Off" Text="ALL"></asp:TextBox>
                                       </a> 
                                 <span class="star">       
                                     
                                     <asp:ImageButton ID="Button1" runat="server" Text="Search" ImageUrl="~/Images/search-button-without-text-md.png" OnClientClick="ShowPopUp(this);return false;" CssClass="Adminshortcut" Height="25px" Width="25px"  />                    

            </span>
                </span>
           </td>
              
           
          </tr>

                <tr>
                    <td></td>
                    <td>Select Zone:</td>
                    <td colspan="4">

                        <asp:DropDownList ID="dpd_zone" runat="server" CssClass="textbox2" Width="170px" Enabled="false">
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

          <tr style="display:none;">
               <td style="width: 30px"> &nbsp;</td>
                      <td>
                          
               </td>

            <td> 
                <asp:TextBox ID="txtcompid" runat="server" CssClass="textbox2" Enabled="false"></asp:TextBox>
           </td>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          
                <tr>
               <td style="width: 30px"> &nbsp;</td>
                      <td valign="top">Extra Display Fields:</td>

            <td colspan="4"> 
                
                
                <asp:CheckBox ID="chk_Address" runat="server" Text="Address"/>
                <asp:CheckBox ID="chk_CardNo" runat="server" Text="Card No." Visible="false"/>
                <asp:CheckBox ID="chk_Passport" runat="server" Text="Passport Date of Expiry"/>
                <asp:CheckBox ID="chk_DOB" runat="server" Text="DOB"/>
                <asp:CheckBox ID="chk_file_no" runat="server" Text="File No."/>

                <br />
                <asp:CheckBox ID="chk_dtuser" runat="server" Text="DataEntry Audit"/>
                <asp:CheckBox ID="chk_auth" runat="server" Text="Auth Audit"/>
                <asp:CheckBox ID="chk_prodUser" runat="server" Text="Production Audit"/>
                <asp:CheckBox ID="chk_qualuser" runat="server" Text="Qual Audit"/>



           </td>
           
          </tr>
                
                
                      
          <tr>
          <td style="width: 30px">&nbsp;</td>
            <td colspan="5" align="center"> 
                <asp:Button ID="btn_generate_report0" runat="server" 
                    Text="Generate Report" class="adminbutton" onclick="btn_generate_report_Click" OnClientClick="ShowProgress();"
                    /> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
                <asp:ImageButton ID="btn_excel" runat="server"  ImageUrl="~/Images/excel_logo.gif" CssClass="Adminshortcut" Height="25px" Width="25px"     OnClientClick="ExportDivDataToExcel()" OnClick="btn_excel_Click"/>
                    <%--</ContentTemplate></asp:UpdatePanel>--%>


                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
                <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Images/print.png" CssClass="Adminshortcut" Height="25px" Width="25px"     OnClientClick="PrintContent()" />
                    <%--</ContentTemplate></asp:UpdatePanel>--%>

            </td>
           
            
            </tr>
            <tr>
            <td colspan="6">
            
            </td>
            </tr>
            </table>
        

    </div>



    <div id="R1" align="center" style="overflow: scroll; height:800px;"  runat="server" >
    
                <div id="DivReport" style="width: 800px;">
                    
                        <table style="width:100%;" align="center" id="tab1" runat="server">
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center" colspan="4" style="font-size:large;">DATEWISE CONSOLIDATED PRODUCTION REPORT</td>
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
                                <td align="center" colspan="4" style="font-size:larger;">(FROM
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
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.No.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Production Date</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Zone Name</th>
                                <%if(dropdown_SearchOption.SelectedValue!="Nationality")
                                  {
                                       %>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nationality </th>

                                <%} %>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Name </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Passport No.</th>  
                                 <%if(chk_Passport.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Passport Date of Expiry</th>

                                <%} %>                              
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">CERPAC No. </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">FRN No. </th>

                                 <%if(chk_DOB.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">DOB</th>

                                <%} %>

                                 <%if (dropdown_SearchOption.SelectedValue != "Company")
                                   {
                                       %>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company </th>
                                <%} %>

                                 <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Designation</th>
                                 <th align="center" scope="col" style="white-space: nowrap;" valign="middle">CERPAC Receipt Date </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">CERPAC Expiry Date </th>  
                                
                                                            
                                 <%if(chk_Address.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Address</th>

                                <%} %>
                                
                                 <%if(chk_prodUser.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Produced By</th>

                                <%} %>    
                                
                                 <%if(chk_file_no.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">File No.</th>

                                <%} %>
                                
                                <%if(chk_dtuser.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">DataEntry Date</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">DataEntry User</th>


                                <%} %>    
                                
                                
                                <%if(chk_auth.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Authorization Date</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Authorization User</th>

                                <%} %>     

                                 <%if(chk_qualuser.Checked==true)
                                  {
                                       %>


                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Quality Date</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Quality User</th>

                                <%} %>     
                            </tr>
                           
                            <%  int c = 1;
                                string var1 = "ZoneName";
                                //if (chk_Zone.Checked == true)
                                //{
                                //    var1 = "ZoneName";
                                //}
                                //if (chk_nationality.Checked == true)
                                //{
                                //    var1 = "nationality";
                                //}

                                var1 = dropdown_SearchOption.SelectedValue;
                   for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                  {
                           if (i>0)
                           {
                            if (i <= objDs.Tables[0].Rows.Count)
                            {
                                if ((Convert.ToString(objDs.Tables[0].Rows[i - 1][var1])).ToUpper()  ==  (Convert.ToString(objDs.Tables[0].Rows[i][var1])).ToUpper())
                                    c = c + 1;
                               // else if (Convert.ToString(objDs.Tables[0].Rows[i - 1]["ZoneName"]) != Convert.ToString(objDs.Tables[0].Rows[i]["ZoneName"]) || i == objDs.Tables[0].Rows.Count) 
                            }

                            if (((Convert.ToString(objDs.Tables[0].Rows[i - 1][var1])).ToUpper() != (Convert.ToString(objDs.Tables[0].Rows[i][var1])).ToUpper()))
                            {%>

                            <%if(dropdown_SearchOption.SelectedValue!= "ProducedONDate")
                              {
                                  %>
                             <tr class="Grid_Item_Alternaterow" style="border :0 ;" >   
                               
                                  
                                   <td colspan="5"></td>
                                   <td align="center"   valign="middle" class="b11" ><label id="Label4"  > Total : </label> </td>
                                   <td align="center"   valign="middle" class="b11"><%=Convert.ToString(c)%></td>
                                   <td colspan="4"></td>

                                 
                                 <%if(chk_prodUser.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  

                                 <%if(chk_dtuser.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  
                                 
                                  <%if(chk_qualuser.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  
                                 

                                 <%if(chk_auth.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  

                                 <%if(chk_file_no.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  

                                 <%if(chk_Address.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  

                                 <%if(chk_DOB.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  
                                 <%if(chk_Passport.Checked==true)
                                  {
                                       %>


                                <td></td>

                                <%} %>  
                                </tr>
                            <%} %>
                               <tr class="Grid_Item_Alternaterow" style="border :0 ;" >   
                               
                                   <%if (dropdown_SearchOption.SelectedValue == "Nationality")
                                     {
                                       %>
                                  
                                   <td align="left"   valign="middle" class="b11" colspan="11" ><label id="lblTotal"  > Nationality: <%=Convert.ToString(objDs.Tables[0].Rows[i]["nationality"])%></label> </td>
                                   <%} %>

                                   <%if (dropdown_SearchOption.SelectedValue == "Company")
                                     {
                                       %>
                                  
                                   <td align="left"   valign="middle" class="b11" colspan="11" ><label id="Label2"  > Company: <%=Convert.ToString(objDs.Tables[0].Rows[i]["Company"])%></label> </td>
                                   <%} %>

                                </tr>
                            <%
                                c = 1;
                             } 
                       
                             }%>

                             <%if (i == 0)
                               {%>
                                <tr class="Grid_Item_Alternaterow" style="border :0 ;" >   
                               
                                  
                                  
                                    <%if (dropdown_SearchOption.SelectedValue == "Nationality")
                                     {
                                       %>
                                  
                                   <td align="left"   valign="middle" class="b11" colspan="11" ><label id="Label1"  > Nationality: <%=Convert.ToString(objDs.Tables[0].Rows[i]["nationality"])%></label> </td>

                                   <%} %>

                                   <%if (dropdown_SearchOption.SelectedValue == "Company")
                                     {
                                       %>
                                  
                                   <td align="left"   valign="middle" class="b11" colspan="11" ><label id="Label3"  > Company: <%=Convert.ToString(objDs.Tables[0].Rows[i]["Company"])%></label> </td>
                                   <%} %>
                                   
                                </tr>
                                 <%  
                               }
                               
                                %>
                            
                            <tr class="Grid_Item_Alternaterow">
                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                                <td align="left" valign="middle"> 
                                    <%=  (objDs.Tables[0].Rows[i]["ProducedONDate"]).ToString() %>
                                </td>
                                <td align="left" valign="middle"> 
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["ZoneName"])).ToUpper()%>
                                </td>
                                <%if(dropdown_SearchOption.SelectedValue!="Nationality")
                                  {
                                       %>
                                <td align="left" valign="middle">
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["nationality"])).ToUpper()%>
                                </td>
                                <%} %>
                                <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs.Tables[0].Rows[i]["forename"])).ToUpper()%>
                                </td>
                                <td align="left" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["passport_no"])%>
                                </td>

                                 <%if(chk_Passport.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["passport_expiry_date"])%>
                                </td>


                                <%} %>

                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_no"])%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_file_no"])%>
                                </td>

                                <%if(chk_DOB.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["date_of_birth"])%>
                                </td>


                                <%} %>

                                 <%if (dropdown_SearchOption.SelectedValue != "Company")
                                   {
                                       %>
                                    <td align="left" valign="middle"> 
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["company"])).ToUpper()%>
                                </td>
                                <%} %>

                                 <td align="left" valign="middle"> 
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["designation"])).ToUpper()%>
                                </td>

                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_receipt_date"])%>
                                </td>
                                <td align="left" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_expiry_date"])%>
                                </td>
                               
                                <%if(chk_Address.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["nigeria_add_1"])).ToUpper()%>
                                </td>


                                <%} %>

                                 <%if(chk_prodUser.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["UserName"])).ToUpper()%>
                                </td>


                                <%} %>

                                 <%if(chk_file_no.Checked==true)
                                  {
                                       %>


                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["file_no"])%>
                                </td>


                                <%} %>


                                  <%if(chk_dtuser.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["verifiedon"])%> 
                                </td>
                                <td align="left" valign="middle"> 
                                     <%=(Convert.ToString(objDs.Tables[0].Rows[i]["dataentryuser"])).ToUpper()%> 
                                </td>


                                <%} %>


                                 <%if(chk_auth.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["Authorizedon"])%> 
                                </td>

                                <td align="left" valign="middle"> 
                                     <%=(Convert.ToString(objDs.Tables[0].Rows[i]["authuser"])).ToUpper()%> 
                                </td>


                                <%} %>


                                <%if(chk_qualuser.Checked==true)
                                  {
                                       %>


                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["qualon"])%> 
                                </td>

                                 <td align="left" valign="middle"> 
                                    <%=(Convert.ToString(objDs.Tables[0].Rows[i]["qualuser"])).ToUpper()%> 
                                </td>


                                <%} %>

                            </tr>
                          <%                             
                        if (i+1 == (  objDs.Tables[0].Rows.Count ))
                             {
                            
                             if(dropdown_SearchOption.SelectedValue!= "ProducedONDate")
                              {
                                 
                            %>
                               <tr class="Grid_Item_Alternaterow" style="border :0 ;" >   
                               
                                  
                                   <td colspan="5"></td>
                                   <td align="center"   valign="middle" class="b11" ><label id="lblTotal1"  > Total : </label> </td>
                                   <td align="center"   valign="middle" class="b11"><%=Convert.ToString(c)%></td>
                                   <td colspan="4"></td>
                                </tr>
                            <%
                            }
                                c = 1;
                             } 
                      
                        }%>
                        </table>
                        <%}
               }
                          
                %>                        <%--<div style=" height: 73px;" width="100px">
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


       
      
    <asp:HiddenField ID="HdnValue" runat="server" />

       
  </div>
    
    <div id="divmain" runat="server"> </div>
    
</asp:Content>

