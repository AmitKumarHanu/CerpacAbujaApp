﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmLaminaRep.aspx.cs" Inherits="Admin_frmLaminaRep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


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
    <strong></strong>
    <div align="center" class="bcolour" id="combox">
        <table cellpadding="2" cellspacing="10" style="width: 95%"   >
          <tr>
                <td colspan="4" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:Black;">&nbsp;Lamination Card Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>


            <tr>
            <td colspan="4"></td>
            </tr>

               <tr>
                 
            <td align="left"></td>
            <td align="left"> 
            <asp:Label ID="lbl_from_date0" runat="server" Text="From Date:" style="text-align: left"></asp:Label>

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
           
            <td align="left"></td>
            <td align="left"> 
            <asp:Label ID="LblToDate0" runat="server" Text="To Date:"></asp:Label>
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
            <td colspan="4"></td>
            </tr>


           <tr>
            <td colspan="4" align="center">
            <asp:Button ID="btn_generate_report0" runat="server" 
                    Text="Generate Report" class="adminbutton" onclick="btn_generate_report_Click" 
                    />
            </td>
            </tr>
            <tr>
            <td></td>
            <td align="left"><asp:Label ID="lbl_tot_lam" Text="Total No. of Laminations:" runat="server" Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_tot_lam" runat="server"></asp:Label></td>
             <td></td>
            
            <td align="left"><asp:Label ID="lbl_used_lam" Text="Total No. of Laminations Used:" runat="server"  Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_used_lam" runat="server"></asp:Label></td>
           
            </tr>
             <tr>
            <td colspan="4"></td>
            </tr>

             <tr>
            <td></td>
            <td align="left"><asp:Label ID="lbl_wasted_lam" Text="Total No. of Laminations Wasted:" runat="server" Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_wasted_lam" runat="server"></asp:Label></td>
            <td></td>
            <td align="left"><asp:Label ID="lbl_rest_lam" Text="Total No. of Unused Laminations:" runat="server"  Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_rest_lam" runat="server"></asp:Label></td>
           
            </tr>

              <tr>
            <td colspan="4"></td>
            </tr>

             <tr>
            <td></td>
            <td align="left"><asp:Label ID="lbl_used_lam_date" Text="Total No. of Laminations Used (Between Above Dates):" runat="server" Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_used_lam_date" runat="server"></asp:Label></td>
            <td></td>
            <td align="left"><asp:Label ID="lbl_wasted_lam_date" Text="Total No. of Laminations Wasted (Between Above Dates):" runat="server"  Font-Bold="true"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_wasted_lam_date" runat="server"></asp:Label></td>
           
            </tr>

        </table>
        </div>


</asp:Content>

