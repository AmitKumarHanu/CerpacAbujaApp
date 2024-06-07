<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmWastedBeforeProduction, App_Web_frmwastedbeforeproduction.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script> 
    
    <link href="../css/scanpage.css" rel="Stylesheet" type="text/css" />

    <script type ="text/javascript">
       
               function AlfaNum1(t) {
            var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var v = cod
            var w = "";
            for (var i = 0; i < t.value.length; i++) {
                x = t.value.charAt(i);
                if (v.indexOf(x, 0) != -1)
                    w += x;
            }
            t.value = w;
        }
        function AlfaNum2(t) {
            var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz0123456789/.-@&$_";
            var v = cod
            var w = "";
            for (var i = 0; i < t.value.length; i++) {
                x = t.value.charAt(i);
                if (v.indexOf(x, 0) != -1)
                    w += x;
            }
            t.value = w;
        }

    </script>
   <div align="center" class="bcolour">      
   
            
     <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:98%" id="combox">
   
    
 <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><fontclass="b12"><span style="fontsize:16px; color:White">&nbsp;Card Wasted Before Production&nbsp; </span></font>
                        </div>
                    </td>
                </tr>  
    <tr>
        <td style="height: 18px" align =center > 
        <asp:Label ID=lblstatus runat=server Visible=false BorderStyle=Solid BorderWidth=1px Width=500px Font-Size=Medium></asp:Label> 
        </td>
    </tr>        
      <tr> 
        <td align="center" >
        <center>
            <%--<fieldset style="width: 90%; height: auto;">--%><%--<legend>
                    <div class="PageNameHeadingCSSHeader" >
                        <img src="../Images/DocumentHeader.gif" width="20px" height="20px" style="background-position: center;
                            vertical-align: middle" alt="" />
                        <asp:Label ID="LabelTitle" runat="server" Visible="true"></asp:Label>
                    </div>
                </legend>--%>
            <div id ="One">
                <table cellpadding="5" cellspacing="2" border="0" style="width: 421px">
                    <tr class="b11">
                        <td align="left" style="width: 92px; height: 18px;">
                           
                            </td>
                        <td align="left" style="width: 200px; height: 18px;">
                            </td>
                    </tr>
                     <tr class="b11">
                        <td align="left" style="width: 92px;">                           
                            <asp:Label runat="server" ID="lblCompanyName" Text="Cerpac No."></asp:Label></td>
                        <td align="left" style="width: 200px;">
                            <asp:TextBox ID="txtCerpacNo" runat="server" CssClass="textbox2" TabIndex="2" Width="104px"  onkeyup="return AlfaNum1(this)"
                                AutoComplete="off" MaxLength="10"   ToolTip="Enter Cerpac No. "  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 92px;">
                           <asp:Label runat="server" ID="lblRegno" Text="Card No."></asp:Label></td>
                        <td align="left" style="width: 200px;">
                            <asp:TextBox ID="txtCardNo" runat="server" CssClass="textbox2"
                                MaxLength="10"   Width="104px"
                                AutoComplete="off" TabIndex="3" ToolTip="Enter Wasted Card Number only" ></asp:TextBox>
                        </td>
                    </tr>
                   
                    
                    <tr class="b11">
                        <td align="left" style="width: 92px;">
                           
                            &nbsp;</td>
                        <td align="left" style="width: 200px;">
                            &nbsp;</td>
                    </tr>                    
                     <tr class="b11">
                        <td colspan="2" align="left" style="height: 5px">
                            </td>
                    </tr>
                    <tr class="b11">
                        <td colspan="2" align="center" style="height: 10px;">
                            <asp:Button ID="btnSave" class="adminbutton" runat="server" Text="Save" onclick="btnSave_Click"  TabIndex="7"/>
                           
                             <asp:Button ID="btnCancel" class="adminbutton" runat="server" onclick="btnCancel_Click" Text="Cancel" TabIndex="8" />
                            
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="center" colspan="2">
                            <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" 
                                ForeColor="#9EC550" />--%>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left"  colspan="2" style="height:20px;">
                            <asp:Label ID="lblOpt" runat="server" Enabled="False" Font-Size="1pt"></asp:Label>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td colspan="2" style="height: 10px">                           
                        </td>
                    </tr>
                </table>
                <%--</fieldset>--%>
                </div>
            
       
 </center>
            </td>
            </tr>
            </table>
     
    </div>

    

</asp:Content>

