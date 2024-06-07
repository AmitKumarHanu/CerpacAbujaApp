<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmBrownCardReport.aspx.cs" Inherits="Admin_frmBrownCardReport" %>

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
    
    
    
     #menuTabs {
margin: 0;
padding: 0;
list-style: none;
overflow: hidden;
border-top: 0.5em solid #fff;
border-bottom: 0.4em solid #0288D8;
}
#menuTabs li {
float: left;
height: 2em;
margin: 0 0.5em;
}
#menuTabs a:link,
#menuTabs a:visited {
float: left;
height: 1.6em;
padding: 0.2em 0.5em;
background: #CCE7F7;
color: #0288E1;
font-weight: bold;
text-decoration: none;
border-width: 0.1em 0.1em 0 0.1em;
border-style: solid;
border-color: #CCE7F7;
border-radius: 6px;
-moz-border-radius: 6px;
-webkit-border-radius: 6px;
line-height: 1.6em;
position: relative;
top: 0.3em;
}
#menuTabs a:hover
{
background: #0288D8;
border-color: #0288D8;
color: #fff;
}
</style>
  <%--<style type="text/css">
      
        .menuTabs
        {
            position:inherit;
            top:5px;
            left:10px;
        }
        .tab
        {
            border:Solid 1px black;
            border-bottom:none;
            padding:0px 10px;
            background-color:White;
            border-radius: 5px;
        }
        .selectedTab
        {
            border:Solid 1px black;
            border-bottom:Solid 1px white;
            padding:0px 10px;
            background-color:#99FFFF;
            border-radius: 5px;
        }
        .tabBody
        {
            border-radius: 20px;
            border:Solid 1px black;
            padding:20px;
            /*background-color:white;*/
        }
    sup.reference{font-weight:normal;font-style:normal}sup.reference{unicode-bidi:-moz-isolate;unicode-bidi:-webkit-isolate;unicode-bidi:isolate}sup,sub{line-height:1em}
         .style1
         {
             font-family: "Times New Roman", Times, serif;
         }
         .style2
         {
             color: #520;
             text-decoration: underline;
             padding: 0;
            
         }
         .menuTabs
         {
             font-size:medium;
         }
         .menuTabs
         {
             font-family: "Times New Roman", Times, serif;
         }
         .menuTabs
         {
             font-family: "Times New Roman", Times, serif;
         }
    </style>--%>
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

        ;


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
                         <font class="b12"><span style="font-size: 16px; color:White;">Monthly Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>

           
            <tr>
            <td style="width: 30px"> 
                <br />
                </td>
            <td align="left"><br /><asp:Label ID="lblMon" runat="server" Text="Month:" style="text-align: left"></asp:Label></td>
            <td align="left"><br />
            <asp:DropDownList ID="dpdMon" runat="server">
            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
            <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
<asp:ListItem Text="Feb" Value="02"></asp:ListItem>
<asp:ListItem Text="Mar" Value="03"></asp:ListItem>
<asp:ListItem Text="Apr" Value="04"></asp:ListItem>
<asp:ListItem Text="May" Value="05"></asp:ListItem>
<asp:ListItem Text="Jun" Value="06"></asp:ListItem>
<asp:ListItem Text="Jul" Value="07"></asp:ListItem>
<asp:ListItem Text="Aug" Value="08"></asp:ListItem>
<asp:ListItem Text="Sep" Value="09"></asp:ListItem>
<asp:ListItem Text="Oct" Value="10"></asp:ListItem>
<asp:ListItem Text="Nov" Value="11"></asp:ListItem>
<asp:ListItem Text="Dec" Value="12"></asp:ListItem>

                </asp:DropDownList>
            </td>
                

             <td><br /></td>
            <td align="left"><br /><asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label></td>
            <td align="left"><br />
                        <asp:DropDownList ID="dpdYear" runat="server" OnSelectedIndexChanged="dpdYear_SelectedIndexChanged">
                       
                </asp:DropDownList>

            </td>
            </tr>
             <tr style="display:none;">
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
          <tr style="display:none;">
               <td style="width: 30px"> &nbsp;</td>
            <td align="left">
              <strong> 

                                <asp:DropDownList ID="dropdown_SearchOption" runat="server" AutoPostBack="true" CssClass="textbox2" 
                    Height="25px"  BackColor="#bcc7d8" ForeColor="#333333"
                                    Width="149px" Font-Bold="true" 
                    onselectedindexchanged="dropdown_SearchOption_SelectedIndexChanged">

                                    <asp:ListItem Value="select">--Select Criteria--</asp:ListItem>
                                    <asp:ListItem Value="ProducedONDate" Selected="True">Generic</asp:ListItem>
                                    <asp:ListItem Value="Nationality">Nationality</asp:ListItem>
                                    <asp:ListItem Value="Company">Company</asp:ListItem>
                                    <asp:ListItem Value="User">User</asp:ListItem>
                                    
                                </asp:DropDownList></strong> 
            </td>

            <td colspan="4" align="left"> 
                <span id="sp1" runat="server">
                <asp:DropDownList ID="dpd_search" runat="server" CssClass="textbox2" Width="170px"
                    >
                    <asp:ListItem Value="ALL" Selected="True">ALL</asp:ListItem>
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
          <br />
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
          
                <tr style="display:none;">
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
            <td colspan="5" align="center"> <br />
                <asp:Button ID="btn_generate_report0" runat="server" 
                    Text="Generate Report" class="adminbutton" onclick="btn_generate_report_Click" OnClientClick="ShowProgress();"
                    /> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
                <asp:ImageButton ID="btn_excel" runat="server"  ImageUrl="~/Images/excel_logo.gif" CssClass="Adminshortcut" Height="25px" Width="25px"     OnClientClick="ExportDivDataToExcel()" OnClick="btn_excel_Click" Visible="true"/>
                    <%--</ContentTemplate></asp:UpdatePanel>--%>


                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
                <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Images/print.png" CssClass="Adminshortcut" Height="25px" Width="25px"     OnClientClick="PrintContent()" Visible="false" />
                    <%--</ContentTemplate></asp:UpdatePanel>--%>

            </td>
           
            
            </tr>
            <tr>
            <td colspan="6">
            
            </td>
            </tr>
            </table>
        
        <table style="width:100%;">



           <tr >
                                <td colspan="4" align="left">
                               <%-- <asp:UpdatePanel ID="up1" runat="server" >
                                
                                <ContentTemplate >--%>
                               <br /><br />
                                     <asp:Menu 
        id="menuTabs"
       
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="selectedTab"
        Orientation="Horizontal"
        OnMenuItemClick="menuTabs_MenuItemClick"
        Runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" 
            Font-Names="Verdana" Font-Size="0.7em" ForeColor="" Font-Bold="true" 
            StaticSubMenuIndent="10px">
        <DynamicHoverStyle BackColor="#990000" ForeColor="#009999" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <Items>
       <%-- <asp:MenuItem 
            Text="Production Report"
            Value="0" Enabled="false"/>--%>

        <asp:MenuItem
            Text="Production Report (Brown Card)"
            Value="0" 
            Selected="true"   />    

      <%--  <asp:MenuItem 
            Text="User-Wise Statistics Report"  
            Value="1"/>
        <asp:MenuItem
            Text="Wrong Form Used"
            Value="2" />--%>

    
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="#004C99" Font-Bold="true" />

<StaticMenuItemStyle CssClass="tab" HorizontalPadding="5px" VerticalPadding="2px"></StaticMenuItemStyle>

<StaticSelectedStyle CssClass="selectedTab" BackColor="#009999"></StaticSelectedStyle>
    </asp:Menu>    
   
    <%--</ContentTemplate></asp:UpdatePanel>--%>
                                </td>

                                </tr>


                                <tr class="b77">
                                <td colspan="4" align="left">
                                <div class="tabBody" id="DivReport">
                                
                               <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                               
                                <ContentTemplate>--%>

         

    <asp:MultiView  
        id="multiTabs"
        ActiveViewIndex="0" 
        Runat="server" onactiveviewchanged="multiTabs_ActiveViewChanged" >
        

        <asp:View ID="view1" runat="server">
        
        <div style="overflow:scroll; width:750px; height:600px;">
                 <% if (objDs_prod.Tables.Count > 0)
               {
                   if (objDs_prod.Tables[0].Rows.Count > 0)
                   { %>
                   <div style="overflow:scroll;">
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 90%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            
                             <tr class="Grid_Header">
                            <th align="center" scope="col" style="white-space: nowrap;" valign="middle" rowspan="2">Month</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" rowspan="2">Zone Name</th>                                
                            <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="2">Form Sold</th>
                            <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="3">Total Brown Card Produced</th>
                            <th align="center" scope="col" style="white-space: nowrap;" valign="middle" rowspan="2">Total Personalized</th>
                                <%-- <th align="center" scope="col" style="white-space: nowrap;" valign="middle" rowspan="2">Cards Wasted</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" rowspan="2">Physical Cards Used </th>--%>
                            </tr>
                            <tr class="Grid_Header">
                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">AO</th>
                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">CR</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">AO</th>  
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">CR</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">AR</th>

                                
                                   
                                
                                                            
                                
                            </tr>
                    <%
                       for (int i = 0; i < objDs_prod.Tables[0].Rows.Count; i++)
                       { 
                       %>
                       <tr>
                       <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["Month_S"]) +" " + Convert.ToString(objDs_prod.Tables[0].Rows[i]["Year_S"]) %></th>
                                <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["ZoneName"]) %></th>                                
                                <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["AO_S"]) %></th>
                                
                                <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["CR_S"]) %></th>
                                <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["AO"]) %></th>  
                                <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["CR"]) %></th>
                                <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["AR"]) %></th>

                                
                                 <th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_prod.Tables[0].Rows[i]["Total"]) %></th>
                         
                         <%
                           int flg = 0;
                           int ph_cnt = 0;
                           for (int j = 0; j < objDs_wasted.Tables[0].Rows.Count; j++)
                           {
                               if (Convert.ToString(objDs_prod.Tables[0].Rows[i]["Month_S"]) + " " + Convert.ToString(objDs_prod.Tables[0].Rows[i]["Year_S"]) == Convert.ToString(objDs_wasted.Tables[0].Rows[j]["Month"]) + " " + Convert.ToString(objDs_wasted.Tables[0].Rows[j]["Year"]) && Convert.ToString(objDs_prod.Tables[0].Rows[i]["ZoneName"]) == Convert.ToString(objDs_wasted.Tables[0].Rows[j]["ZoneName"]))
                               {
                                   flg = 1;
                                   ph_cnt = Convert.ToInt32(objDs_wasted.Tables[0].Rows[j]["wastecards"]);
                       %>
                                 <%--<th align="center" class="b11" style="white-space: nowrap;" valign="middle"><%= Convert.ToString(objDs_wasted.Tables[0].Rows[j]["wastecards"])%></th>--%>
                                 <%}
                               else
                               {
                                   
                                   %>

                                   <%-- <th align="center" scope="col" style="white-space: nowrap;" valign="middle">0</th>--%>
                          <% }
                           }
                           if (flg == 0)
                           {
                            %>
                           <%-- <th align="center" class="b11" style="white-space: nowrap;" valign="middle">0</th>--%>
                            <%} %>
                            <%if (flg == 0)
                              {
                                   %>
                                <%--<th align="left" class="b11" style="white-space: nowrap;" valign="middle"><%=Convert.ToString(objDs_prod.Tables[0].Rows[i]["Total"]) %> </th>  --%>

                                <%} %>


                                <%if (flg == 1)
                              {
                                   %>
                                <%--<th align="left" class="b11" style="white-space: nowrap;" valign="middle"><%=Convert.ToInt32(objDs_prod.Tables[0].Rows[i]["Total"])+ph_cnt %> </th> --%> 

                                <%} %>
                       </tr>
                       
                       <%
                       }
                       %>     
                        </table>
                        </div>
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
        </asp:View>

        <asp:View ID="view2" runat="server">
        <div>
                               <% if (objDs1.Tables.Count > 0)
                         {
                         if (objDs1.Tables[0].Rows.Count > 0)
                         { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 70%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="3" >Data Entry</th>
                               
                            </tr>
                             <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Login User </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Total Working </th>
                               
                            </tr>
                           
                            <%  
                        for (int i = 0; i < objDs1.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                              
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs1.Tables[0].Rows[i]["LoginID"])%> 
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs1.Tables[0].Rows[i]["VerCount"])%>
                                </td>
                               
                             </tr>
                            <%                             
                            }
                        }
                        %>
                        </table>
                     <%}
                    } 
                    
                    if (objDs5.Tables.Count > 0)
                         {
                         if (objDs5.Tables[0].Rows.Count > 0)
                         { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 70%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="3" >Contec Officer</th>                               
                            </tr>
                             <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Login User </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Total Working </th>
                               
                            </tr>
                           
                            <%  
                               
                        for (int i = 0; i < objDs5.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                              
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs5.Tables[0].Rows[i]["LoginID"])%> 
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs5.Tables[0].Rows[i]["ContecOfficer"])%>
                                </td>
                               
                             </tr>
                            <%                             
                            }
                        }%>
                        </table>
                      <%}
                    } 
                    
                    if (objDs2.Tables.Count > 0)
                         {
                         if (objDs2.Tables[0].Rows.Count > 0)
                         { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 70%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="3" >Authorization</th>                               
                            </tr>
                             <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Login User </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Total Working </th>
                               
                            </tr>
                           
                            <%  
                               
                        for (int i = 0; i < objDs2.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                              
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs2.Tables[0].Rows[i]["LoginID"])%> 
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs2.Tables[0].Rows[i]["AuthCount"])%>
                                </td>
                               
                             </tr>
                            <%                             
                            }
                        }%>
                        </table>
                      <%}
                    } 
                    if (objDs3.Tables.Count > 0)
                         {
                         if (objDs3.Tables[0].Rows.Count > 0)
                         { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 70%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="3" >Production</th>                               
                            </tr>
                             <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Login User </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Total Working </th>
                               
                            </tr>
                           
                            <%  
                               
                        for (int i = 0; i < objDs3.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                              
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs3.Tables[0].Rows[i]["LoginID"])%> 
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs3.Tables[0].Rows[i]["ProdCount"])%>
                                </td>
                               
                             </tr>
                            <%                             
                            }
                        }%>
                        </table>
                      <%}
                    } 
                    if (objDs4.Tables.Count > 0)
                         {
                         if (objDs4.Tables[0].Rows.Count > 0)
                         { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 70%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="3" >Quality</th>                               
                            </tr>
                             <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Login User </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Total Working </th>
                               
                            </tr>
                           
                            <%  
                               
                        for (int i = 0; i < objDs4.Tables[0].Rows.Count; i++)
                         {
                           if (i>=0)
                           {
                             %>
                            <tr class="Grid_Item_Alternaterow">
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                              
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs4.Tables[0].Rows[i]["LoginID"])%> 
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs4.Tables[0].Rows[i]["QualCount"])%>
                                </td>
                               
                             </tr>
                            <%                             
                            }
                        }%>
                        </table>
                        <%}
                    } %>                       
                    <br />
        
        </div></asp:View>
         <asp:View ID="view3" runat="server">
        <div style="overflow:scroll; width:700px; height:600px;">
          <% if (objDs.Tables.Count > 0)
             {
                 if (objDs.Tables[0].Rows.Count > 0)
                 { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="overflow: scroll; clip: rect(auto, auto, auto, auto);">
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="6">Purchased By</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle" colspan="4">Issued To</th>

                            </tr>
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Form No.</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">First Name</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Last Name</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Company</th>

                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Nationality </th>

                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">First Name</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Last Name</th>
                                
                               

                               

                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">DataEntry User</th>
                                

                               
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Auth User</th>
                               
                                


                                <%--<th align="center" scope="col" style="white-space: nowrap;" valign="middle">No Exception</th>--%>

                            </tr>


                             <% 
                                  
                                  for (int i = 0; i < objDs_WrongForms.Tables[0].Rows.Count; i++)
                                  { %><tr class="Grid_Item_Alternaterow">
                                <td align="left" valign="middle"> 
                                    <%=Convert.ToString(i+1)%>
                                </td>
                                       <td align="center" valign="middle">
                                         <%=Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["formno"])%>
                                </td>
                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["firstname"])).ToUpper()%>
                                </td>
                                      
                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["lastname"])).ToUpper()%>
                                </td>
                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["company"])).ToUpper()%>
                                </td>

                                      

                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["NATIONALITY"])).ToUpper()%>
                                </td>

                                         <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["first_name"])).ToUpper()%>
                                </td>
                                      
                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["last_name"])).ToUpper()%>
                                </td>
                                      
                                      
                                
                                     

                                      
                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["VerifiedBy"])).ToUpper()%>
                                </td>
                                      

                                      
                                       <td align="left" valign="middle">
                                         <%=(Convert.ToString(objDs_WrongForms.Tables[0].Rows[i]["AuthorizedBy"])).ToUpper()%>
                                </td>
                                      
                                
                                      </tr>

                                       <%}
                                        
                                       
                              
                          %>

                                </table>
                                <%}
             } %>

        </div></asp:View>


         

        </asp:MultiView>

       <%-- </ContentTemplate></asp:UpdatePanel>--%>
        </div></td></tr>
        
        </table>
        <asp:HiddenField ID="HdnValue" runat="server" />
    </div>


</asp:Content>

