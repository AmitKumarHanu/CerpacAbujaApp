<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="FrmWorkCenterMaster, App_Web_frmworkcentermaster.aspx.fdf7a39c" title="Work Center Master" %>
<%@ OutputCache NoStore="true" Location="None"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script> 

   <div align="center" class="bcolour">      
      <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>  
    
    <asp:UpdatePanel ID="FrmWorkCenterMasterUpdatePanel" runat="server" >
       <ContentTemplate>  
            
     <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%" id="combox">
   
    <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><fontclass="b12">
                            <span style="fontsize:16px; color:White"">&nbsp;Work Center Form&nbsp; </span></font>
                        </div>
                    </td>
                </tr>   
      
      <tr> 
        <td align="center" >
        <center>
            <%--<fieldset style="width: 90%; height: auto;">--%>
                <%--<legend>
                    <div class="PageNameHeadingCSSHeader" >
                        <img src="../Images/DocumentHeader.gif" width="20px" height="20px" style="background-position: center;
                            vertical-align: middle" alt="" />
                        <asp:Label ID="LabelTitle" runat="server" Visible="true"></asp:Label>
                    </div>
                </legend>--%>
                <table cellpadding="5" cellspacing="2" border="0" width="680px">
                   
                    <tr class="t11">
                        <td colspan="4" align =center > 
        <asp:Label ID=lblstatus runat=server Visible=false BorderStyle=Solid BorderWidth=1px Width=500px Font-Size=Medium></asp:Label>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 200px;">
                           &nbsp;
                        </td>
                        <td align="left" style="width: 200px;">
                        </td>
                    </tr>                    
                     <tr class="b11">
                        <td colspan="4" align="left" style="height: 5px">
                            </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 100px;">
                               
                            Work Center</td>
                        <td align="left" style="width: 200px;">
                               
                            <asp:TextBox ID="txtWorkCenter" runat="server" CssClass="textbox2" onblur="checkonlySpace(this);" onkeyup="AlfaNum3(this);" 
                                ValidationGroup="a" MaxLength="35" TabIndex="1" AutoComplete="Off" 
                                ToolTip="Enter Work Center"></asp:TextBox>
                            <span style="color:  red; text-align: center; font-size: medium;">*</span></td>
                        <td align="left" style="width: 100px;">
                            &nbsp;</td>
                        <td align="left" style="width: 200px;">
                               
                            &nbsp;</td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 100px;">
                               
                        </td>
                        <td align="left" style="width: 200px;">
                               
                            <asp:RequiredFieldValidator ID="rfvWorkCenter" runat="server" Display="None" 
                                ErrorMessage="Enter Work Center" SetFocusOnError="True" 
                                ValidationGroup="a" ControlToValidate="txtWorkCenter" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                               
                        </td>
                        <td align="left" style="width: 100px;">
                               
                        </td>
                        <td align="left" style="width: 200px;">
                               &nbsp;</td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" align="left" style="height: 5px">
                             </td>
                    </tr>
                    <tr class="t11" style = "display:none">
                        <td align="left" style="width: 100;">
                               
                            Status </td>
                        <td align="left" style="width: 200;">
                            <asp:CheckBox ID="chkactive" runat="server" Checked="True" TabIndex="5" 
                                ToolTip="Checked Active Status" />
                        </td>
                        <td align="left" style="width: 100;">
                            &nbsp;</td>
                        <td align="left" style="width: 100;">
                            &nbsp;</td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" align="left" style="height: 10px;">
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="center" colspan="4">
                            <asp:Button ID="btnSave" runat="server" class="adminbutton" Text="Save" Width="76px"
                                ValidationGroup="a"  TabIndex="6" onclick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" runat="server" class="adminbutton" Text="Update" Width="76px"
                                ValidationGroup="a"  TabIndex="9" onclick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" class="adminbutton" Text="Cancel" Width="76px"
                                 TabIndex="10" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" align="left" style="height: 10px;">
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="center" colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" 
                                ForeColor="#9EC550" />
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left"  colspan="4" style="height:20px;">
                            &nbsp;</td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" style="height: 10px">
                            &nbsp;</td>
                    </tr>
                </table>
            <%--</fieldset>--%>
       
 </center>
            </td>
            </tr>
            </table>
      </ContentTemplate>
    </asp:UpdatePanel>  
    </div>
</asp:Content>

