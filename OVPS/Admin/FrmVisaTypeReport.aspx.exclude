<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmVisaTypeReport, App_Web_frmvisatypereport.aspx.fdf7a39c" title="CERPAC TYPE REPORT" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
   <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <link href="../css/scanpage.css" rel="Stylesheet"/>
    <script type="text/javascript" language="javascript">

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
    
    <%--<asp:UpdatePanel ID="FrmReportUpdatePanel" runat="server">
          <ContentTemplate>--%>
                 <table id="tblFilter" runat="server" cellpadding="2" cellspacing="10" style=" width:95%">
                
                <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><font class="b12"><span style="fontsize:16px; color:white">&nbsp;Production Report &nbsp; </span></font>
                        </div>
                    </td>
                </tr>    
                 
                  <tr> 
                    <td align="center" colspan ="2" >
                        <table style="font-style:normal" width ="55%" id="combox"> 
                             <tr>
                                    <td colspan="2" style="height: 5px" ><asp:Label runat="server" ID="lblerror" CssClass="warning-box" Text="No data found with this combination" Font-Size="Small" Visible="false"></asp:Label></td>
                                </tr>
                        <tr align="center" valign="top">
                            <td style="height: auto">
                               <table style="font-style:normal" width ="100%">   
                               
                                   &nbsp;
                             <tr class="t11">
                                
                                <td align="center"  colspan="2" class="b11">
                                    <input type="radio" value ="Detailed" id="raddetail" runat="server" />Detailed &nbsp;&nbsp;&nbsp; <input type="radio" value ="Summarized" id="radsummarized" runat="server" checked="true" />Summarized
                               </td>                        
                                </tr>  
                            <tr>
                                    <td colspan="2" style="height: 5px" ></td>
                                </tr>               
                            <tr class="t11">
                                <td align="left" valign="top" style="width: 110px" class="b11">Company Name</td>
                                <td align="left" style="width: 237px" >
                                         <asp:DropDownList ID="ddlVisaType" runat="server" Height="18px" Width="126px" CssClass="dropdown3" />
                                    </td>
                            </tr>
                             <tr>
                             <td colspan="2" style="height: 5px" ></td>
                             </tr>
                             
                             <tr class="t11">
                                    <td align="left" valign="top" style="width: 110px" class="b11">Nationality </td>
                                    <td align="left" style="width: 237px" >
                                         <asp:DropDownList ID="ddlnationality" runat="server" Height="18px" Width="126px" CssClass="dropdown3" />
                                    </td>
                             </tr>
                             <tr>
                             <td colspan="2" style="height: 5px" ></td>
                             </tr>
                            <tr class="t11">
                                <td align="left" valign="top" style="width: 110px" class="b11">Zone Wise </td>
                                <td align="left" style="width: 237px" >
                                <asp:DropDownList ID="ddlborder" runat="server" Height="18px" Width="126px" CssClass="dropdown3" />
                                    </td>
                             </tr>
                             <%--<tr>
                             <td colspan="2" style="height: 5px" ></td>
                             </tr>
                             
                             <tr class="t11">
                                    <td align="left" valign="top" style="width: 110px">Embassy Wise :</td>>
                                    <td align="left" style="width: 237px" >
                                         <asp:DropDownList ID="ddlembassy" runat="server" Height="18px" Width="126px" CssClass="dropdown3" />
                                    </td>
                             </tr>--%>
                                                                                      
                            <tr>
                             <td colspan="2" style="height: 5px" ></td>
                             </tr>                
                              <tr class="t11">
                                <td align="left" valign="top" style="width: 130px" class="b11">Cerpac Issue From</td>
                                <td align="left" >
                                            <asp:TextBox class="textbox2" id="txtfrmDate" style="border-width: 1px;
                                      width: 130px;" onkeyup="dtval(this,event)" runat="server" />
                                               <span style="color: red; text-align: center; font-size: medium;">*</span>
                                            <a id="AD" runat="server" href="javascript:NewCal('txtfrmDate','DDMMMYYYY')">
                                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                                                
                                           
                                        </td>
                                    
                            </tr> 
                            <tr>
                                <td>
                                </td>
                            </tr>
                            
                              <tr class="t11">
                                <td align="left" valign="top" style="width: 130px" class="b11">Cerpac Issue To </td>
                                <td align="left">
                                            <asp:TextBox class="textbox2" id="txtVisaToDate" style="border-width: 1px;
                                      width: 130px;" onkeyup="dtval(this,event)" runat="server" />
                                                 <span style="color: red;text-align: center; font-size: medium;">*</span>
                                            <a id="DD" runat="server" href="javascript:NewCal('txtVisaToDate','DDMMMYYYY')">
                                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>                                                
                                            <%--<asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="txtVisaToDate"
                                                ErrorMessage="Please Select To Date" ValidationGroup="a" Display="None"
                                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    
                            </tr>
                                
                      <tr class="t11">
                            <td align="left" valign="top"  style="width: 93px;" >
                                &nbsp;</td>
                            <td style="text-align: left;">
                                &nbsp;</td>
                      </tr>
                             
                   </table> 
                 
                  </td>
                </tr>
                                            
              <tr>
                        
                    <td align="center" colspan="4">
                       <asp:Button ID="btnGenReport" runat="server" class="adminbutton"
                            Text="View Report" 
                            ValidationGroup="a" onclick="btnGenReport_Click" />
                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                         ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" CssClass="t11" />
                         
                         </td>
                         <tr class="t11">
                            <td style="height: 15px;"> </td>
                          </tr>
                    <%--<tr>
                    <td colspan="4" style="width: 100%; height: 22px; text-align: left">
                    
                     <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
					  <span style="color: White; text-align: center; font-weight: bold; font-size: smaller;">
						  * Note : Click on View Report button to generate the Report.
					  </span>				  
                       </li>
                       
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">               
						   <span style="color: White; text-align: center; font-weight: bold; font-size: smaller;">
						   1.You can select Visa Type from the Drop Down List for displaying the report passport no wise.
						   </span>              
					   </li>
           
					   <li class="b11" style="margin: 0in 0in 0pt; text-align: left">
						  <span style="color: White; text-align: center; font-weight: bold; font-size: smaller;">           
						   2.You can select the visa report date for displaying the report date wise.
						   </span>               
					   </li>
           
                  
                     </td>
               </tr>--%>
                    
                </tr>
                    </table>
                </td>
                           </tr>
                   
                </table>
                
                 <table id="tblReport" runat="server" cellpadding="2" cellspacing="10" style=" width:95%">
                    <tr>
                      <td colspan="2"  class="PageNameHeadingCSS_2" align="center">Visa Type Report
                      </td>
                    </tr>     
                    <tr>
                      <td style="height: 5px" > 
                    </td>
                   </tr>
                   <tr>
                      <td align="center"> 
                          <asp:Button ID="btnBack" runat="server" class="adminbutton" 
                            Text="Back"  onclick="btnBack_Click" />&nbsp;
                          <asp:Button ID="btnExcel" runat="server" class="adminbutton"
                            Text="Export To Excel" Width="121px" onclick="btnExcel_Click" />
                     </td>
                   </tr>
                    <tr align="center" style="background-color: #F0F0F0; border-color:#F7D117; border-width:1px; border-style:solid;">
                        <td align="center"> 
                            &nbsp;</td>
                    </tr>
            </table>
                
          <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    
 </div>
</asp:Content>

