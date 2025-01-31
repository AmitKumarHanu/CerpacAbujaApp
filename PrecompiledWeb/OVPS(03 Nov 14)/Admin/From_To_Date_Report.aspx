﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_From_To_Date_Report, App_Web_from_to_date_report.aspx.fdf7a39c" enableeventvalidation="false" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

     function datevalidate() {
         var Fdate = document.getElementById('<%=txtVisaDate.ClientID%>').value;
         var Edate = document.getElementById('<%=txtVisaToDate.ClientID%>').value;
         //         if (Fdate == "") {
         //             alert("Arrival Date requierd.")
         //             return false;
         //          }

         //         if (Edate == "") {
         //             alert("Departure Date requierd.")
         //             return false;
         //         }

         if (Date.parse(Fdate) > Date.parse(Edate)) {
             alert("From Date should be greater than or equal to To Date.")
             return false;
         }
         else {
             return true;
         }
     }
     </script>
<script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
 
<div align="center">
     
                <table id="tblFilter" runat="server" cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
                
                <tr>
                    <td colspan="2"  class="PageNameHeadingCSS_2" align="center">Summarised Sticker Report
                    </td>
                </tr>     
                <tr>
                    <td style="height: 18px" > 
                    </td>
                </tr>        
                  <tr> 
                    <td align="center" colspan ="2" >
                        <table style="font-style:normal" width ="55%"> 
                        <tr align="center" valign="top">
                            <td style="height: 153px">
                               <table style="font-style:normal" width ="100%">   
                                       
                            <tr class="t11">
                                <td align="left" valign="top" style="width: 130px">Enter From Date:</td>
                                <td align="left" >
                                            <input type="text" class="textbox-medium" id="txtVisaDate" readonly="readonly" style="border-width: 1px;
                                              width: 130px;" runat="server" validationgroup="a" tabindex="10" />
                                               <span style="color: #9EC550; text-align: center; font-size: medium;">*</span>
                                            <a id="AD" runat="server" href="javascript:NewCal('txtArrivalDate','DDMMMYYYY')">
                                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                                                
                                            <asp:RequiredFieldValidator ID="rfvVisaDate" runat="server" ControlToValidate="txtVisaDate"
                                                ErrorMessage="Please Select From Date" ValidationGroup="a" Display="None"
                                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                        </td>
                                    
                            </tr> 
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td align="left" valign="top" style="width: 130px">Enter To Date:</td>
                                <td align="left">
                                            <input type="text" class="textbox-medium" id="txtVisaToDate" readonly="readonly" style="border-width: 1px;
                                                width: 130px;" runat="server" validationgroup="a" title="11" />
                                                 <span style="color: #9EC550;text-align: center; font-size: medium;">*</span>
                                            <a id="DD" runat="server" href="javascript:NewCal('txtDepartureDate','DDMMMYYYY')">
                                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                                                
                                            <asp:RequiredFieldValidator ID="rfvIsaToDate" runat="server" ControlToValidate="txtVisaToDate"
                                                ErrorMessage="Please Select To Date" ValidationGroup="a" Display="None"
                                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                                        </td>
                                    
                            </tr>
                            </table> 
                  </td>
                </tr>
                                            
               <tr>
                        
                    <td align="center" colspan="4">
                       <asp:Button ID="btnGenReport" runat="server" CssClass="button" 
                            Text="View Report" Width="109px"
                            ValidationGroup="a" onclick="btnGenReport_Click" />
                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                         ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" CssClass="t11" />
                    </td>
               <tr>
                    <td colspan="4" style="width: 100%; height: 22px; text-align: left">
                    
                     <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
					  <span style="color: White; text-align: center; font-weight: bold; font-size: smaller;">
						  * Note : Click on View Report button to generate the Report.
					  </span>				  
                       </li>
                                  
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						   <span style="color: White; text-align: center; font-weight: bold; font-size: smaller;">
						   1.You can Enter the From Date in the text box.
						   </span>             
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">               
						   <span style="color: White; text-align: center; font-weight: bold; font-size: smaller;">
						   2.You can Enter To Date in the text box for displaying the report passport no wise.
						   </span>              
					   </li>
           
                  
                     </td>
               </tr>
                    
                </tr>
                    </table>
                </td>
                           </tr>
                   
                </table>
                
                 <table id="tblReport" runat="server" cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
                    <tr>
                      <td colspan="2"  class="PageNameHeadingCSS_2" align="center">Summarised Sticker Report
                      </td>
                    </tr>     
                    <tr>
                      <td style="height: 5px" > 
                    </td>
                   </tr>
                   <tr>
                      <td align="center"> 
                          <asp:Button ID="btnBack" runat="server" CssClass="button" 
                            Text="Back" Width="45px" onclick="btnBack_Click" />&nbsp;
                          <asp:Button ID="btnExcel" runat="server" CssClass="button" 
                            Text="Export To Excel" Width="111px" onclick="btnExcel_Click" />
                     </td>
                   </tr>
                    <tr align="center"  style="background-color: #F0F0F0; border-color:#F7D117; border-width:1px; border-style:solid;">
                        <td align="center"> 
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BorderColor="Silver" InternalBorderStyle="NotSet"
                            Font-Names="Verdana" ToolBarItemHoverBackColor="Beige" Font-Size="8pt" ShowParameterPrompts="True"
                            ShowExportControls="false" Width="100%" ShowToolBar="true" ShowPrintButton="true" ProcessingMode="Local">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
            </table>
                
          <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    
 </div>
</asp:Content>

