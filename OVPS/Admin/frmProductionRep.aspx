<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmProductionRep.aspx.cs" Inherits="Admin_frmProductionRep" %>

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
        .auto-style2 {
            width: 20%;
        }
        .auto-style5 {
            width: 10%;
        }
        .auto-style6 {
            width: 20%;
        }
        .auto-style7 {
            width: 40%;
        }
        .auto-style8 {
            width: 40%;
        }
    </style>
    <strong></strong>
    <div align="center" class="bcolour" id="combox" ">
        <div id="Details" >
        <table cellpadding="2" cellspacing="10" style="width: 70%; border:1px"   >
          <tr>
                <td colspan="4" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center;" >
                        <font class="b12"><span style="font-size: 16px; color:Black;">&nbsp;Daily Production Card Report &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>            

          <tr class="auto-style2">
                 
            <td align="left" class="auto-style2"></td>
            <td align="left" class="auto-style8"> 
            <asp:Label ID="lbl_from_date" class="auto-style8" runat="server" Text="From Date:" style="text-align: left"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; 
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
           
            <td align="left" class="auto-style7"> <asp:Button ID="btn_generate_report0" runat="server" 
                    Text="Generate Report" class="adminbutton" onclick="btn_generate_report_Click"  /></td>
            <td align="left" class="auto-style5"> 
        
                      
        </td>
          </tr>       
        
          <tr>
            <td class="auto-style2"></td>
            <td align="left" class="auto-style8"><asp:Label ID="lblProdCount" Text="Production Count" runat="server" Font-Bold="True"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; </td>
             <td class="auto-style7"><asp:Label ID="txtProdCount" runat="server"></asp:Label></td>
            
            <td align="left" class="auto-style5"></td>
           
            </tr>           

          <tr>
            <td class="auto-style2"></td>
            <td align="left" class="auto-style8"><asp:Label ID="lblWastedCard" Text="Wasted Card Count" runat="server" Font-Bold="True"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 
                </td>
            <td class="auto-style7"><asp:Label ID="txtWastedCard" runat="server"></asp:Label></td>
            <td align="left" class="auto-style5"></td>
           
            </tr>

              <tr>
            <td colspan="4" ></td>
            </tr>

             <tr>
            <td class="auto-style2"></td>
            <td align="left" class="auto-style8"><asp:Label ID="lblTotalCount" Text="Total No." runat="server" Font-Bold="True"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; 
                </td>
            <td class="auto-style7"><asp:Label ID="txtTotalCount" runat="server"></asp:Label></td>
            <td align="left" class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp; </td>
           
            </tr>

              <tr>
            <td colspan="4" ></td>
            </tr>

             <tr>
            <td class="auto-style2"></td>
            <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp; 
                </td>
               <td align="left" class="auto-style7"> <asp:Button ID="btnSynchornicReport" runat="server" 
                    Text="Synchronic Report" class="adminbutton" OnClick="btnSynchornicReport_Click"  />

               </td>
            <td align="left" class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp; </td>
           
            </tr>
          
            <tr>
                <td colspan="4" >
                    <div id="DivReport" >
                    
                        <table style="width:50%;" align="center">
                          
                            <tr>
                                <td>
                                
                            
                         
                        
                        <% if (objDs.Tables.Count > 0)
                         {
                         if (objDs.Tables[0].Rows.Count > 0)
                         { %>
                        <table class="GridBaseStyle"   border="1" cellspacing="1"  rules="all" style="width: 80%; overflow: scroll; clip: rect(auto, auto, auto, auto);">
                              <tr>
                                
                                <th align="center" colspan="6"> DAILY CARD PRODUCTION DETAILS </th>
                            
                                
                            </tr>
                            <tr class="Grid_Header">
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">S.N.</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Date</th>                                
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Print Card</th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Wasted Card </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Total Card </th>
                                <th align="center" scope="col" style="white-space: nowrap;" valign="middle">Zone</th> 
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
                                    <%=Convert.ToDateTime(objDs.Tables[0].Rows[i]["Prod_Date"]).ToShortDateString()%>
                                </td>
                                <td align="center" valign="middle"> 
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["Prod_Card"])%> 
                                </td>
                                <td align="center" valign="middle">
                                    <%=Convert.ToString(objDs.Tables[0].Rows[i]["Prod_Wasted"])%>
                                </td>
                                <td align="center" valign="middle">
                                         <%=Convert.ToString(objDs.Tables[0].Rows[i]["Prod_Total"])%>
                                </td>
                                <td align="center" valign="middle">
                                      <%=Convert.ToString(objDs.Tables[0].Rows[i]["zonename"])%>
                                </td>
                             </tr>
                            <%                             
                            }
                        }%>
                        </table>
                        <%}
                    } %>     &nbsp;</td>
                               
                        </tr>    
                             </table>              
                    <br />
     
                    </div>
                </td>
            </tr>
        </table>
            </div>
        
        </div>
    

</asp:Content>

