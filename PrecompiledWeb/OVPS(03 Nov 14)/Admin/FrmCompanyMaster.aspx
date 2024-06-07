<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmCompanyMaster, App_Web_frmcompanymaster.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script> 
    
    <link href="../css/scanpage.css" rel="Stylesheet" type="text/css" />

    <script type ="text/javascript">
        function ShowPopUp(e) {

            //if (document.getElementById("<%=txtCompanyName.ClientID%>").value == '' && document.getElementById("<%=lblOpt.ClientID%>").innerHTML == '' || document.getElementById("<%=txtRegno.ClientID%>").value == '' && document.getElementById("<%=lblOpt.ClientID%>").innerHTML == '')
            if (document.getElementById("<%=lblOpt.ClientID%>").innerHTML == '')
                return false;

            var ReturnValue = window.showModalDialog("CompMasterPopUp.aspx?val=" + document.getElementById("<%=txtCompanyName.ClientID%>").value + "&Regno=" + document.getElementById("<%=txtRegno.ClientID%>").value+ "&Opt=" + document.getElementById("<%=lblOpt.ClientID%>").innerHTML, e.paras, "dialogWidth=450px;dialogHeight=500px;scroll:no; status:no;")
            var value = ReturnValue.split(',');
           
            document.getElementById("<%=txtRegno.ClientID%>").value = value[0];
            document.getElementById("<%= txtCompanyName.ClientID%>").value = value[1];
            btnUpdate.Visible = false;
            lblstatus.Visible = false;
            
            
            


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

        function AllowAlphabetpp() {
            
            var director = document.getElementById("<%=txtRegno.ClientID%>");
            if (!director.value.match(/^[a-zA-Z0-9]+$/) && director.value != "") {
                director.value = "";
                director.focus();
                alert("Please Enter Alpha-Numberic  Value.");
            }
        }
        function Num1(t) {
            var cod = "0123456789";
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
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><fontclass="b12"><span style="fontsize:16px; color:White">&nbsp;Company Master &nbsp; </span></font>
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
                <table cellpadding="5" cellspacing="2" border="0" style="width: 562px">
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 10px;">
                        </td>
                    </tr>
                    <tr class="t11">
                        <td colspan="4" align="center">
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 250px;">
                           
                            <asp:Label runat="server" ID="lblCompanyfor" Text="Company For"></asp:Label></td>
                        <td align="left" style="width: 200px;">
                            <asp:RadioButtonList ID="rdOptionList" runat="server" OnSelectedIndexChanged="rdOptionList_SelectedIndexChanged" AutoPostBack="True" >
                                <asp:ListItem Value="0" Text="AO Form">AO Form</asp:ListItem>
                                <asp:ListItem Value="1" Text="AR & CR Form">AR &amp; CR Form</asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 200px;">
                           <asp:Label runat="server" ID="lblRegno" Text="Registration No."></asp:Label></td>
                        <td align="left" style="width: 200px;">
                            <asp:TextBox ID="txtRegno" runat="server" CssClass="textbox2"
                                MaxLength="10"  onkeyup="return Num1(this)"
                                AutoComplete="off" TabIndex="2" ToolTip="Enter Company Registration Number" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 200px;">                           
                            <asp:Label runat="server" ID="lblCompanyName" Text="Company Name"></asp:Label></td>
                        <td align="left" style="width: 200px;">
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textbox2" TabIndex="3" Width="273px"  onkeyup="return AlfaNum2(this)"
                                AutoComplete="off"  ToolTip="Enter Company Registration Number"  ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr class="b11">
                        <td align="left" style="width: 100px;">
                           
                            &nbsp;</td>
                        <td align="left" style="width: 200px;">
                            &nbsp;</td>
                    </tr>                    
                     <tr class="b11">
                        <td colspan="4" align="left" style="height: 5px">
                            </td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" align="center" style="height: 10px;">
                           <asp:Button ID="btnSearch" class="adminbutton" runat="server" OnClientClick="ShowPopUp(this);return false;" 
                               Text="Search" ValidationGroup="a" TabIndex="4"/>
                            <asp:Button ID="btnUpdate" class="adminbutton" runat="server"  
                                Text="Update" onclick="btnUpdate_Click" ValidationGroup="a" TabIndex="5" />
                            <asp:Button ID="btnSave" class="adminbutton" runat="server" Text="Save" onclick="btnSave_Click" ValidationGroup="a" TabIndex="6"/>
                            <asp:Button ID="btnAdd" class="adminbutton" runat="server" Text="Add" onclick="btnAdd_Click" ValidationGroup="a" TabIndex="7"/>
                           
                             <asp:Button ID="btnCancel" class="adminbutton" runat="server" onclick="btnCancel_Click" Text="Cancel" TabIndex="8" />
                            
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="center" colspan="4">
                            <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" 
                                ForeColor="#9EC550" />--%>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left"  colspan="4" style="height:20px;">
                            <asp:Label ID="lblOpt" runat="server" Enabled="False" Font-Size="1pt"></asp:Label>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" style="height: 10px">
                            &nbsp;</td>
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

