<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmFindCerpacNo, App_Web_frmfindcerpacno.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/country.css" rel=Stylesheet type="text/css" /> 
    <script type="text/javascript">
        

        function validate() {
            var a = document.getElementById('<%=txtfname.ClientID %>');
            var b = document.getElementById('<%=txtlname.ClientID %>');
            var c = document.getElementById('<%=txtDob.ClientID %>');
            if (a.value == '')
            {
                a.className = 'txtboxerror';
                return false;
            }
            else if (b.value == '') {
                b.className = 'txtboxerror';
                return false;
            }
            else if (c.value == '') {
                c.className = 'txtboxerror';
                return false;
            }
            else
            {
                return true;
            }
        }

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

        function process(date) {
            var parts = date.split("-");
            return new Date(parts[2], parts[1] - 1, parts[0]);
        }
    </script>
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
        .auto-style1 {
            height: 16px;
            width: 251px;
            text-align: left;
        }
        .auto-style2 {
            width: 256px;
        }
        .auto-style3 {
            width: 109px;
        }
        .auto-style4 {
            height: 15px;
        }
    </style>
    <table cellpadding="5" cellspacing="2" border="0" width="750px" id=loading style="display:none">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Fetching data.Please Wait. . . . .</td></tr>
                        </table>
    <div align="center" class="bcolour" id="zone_contain">
        <table cellpadding="2" cellspacing="10" style="width: 95%" id="combox" >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Find Cerpac No&nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td class="auto-style4"></td></tr>
            <tr><td align=center>
            <asp:Label ID=lblmsg runat=server CssClass="information-box abc" Text = "Please enter following details." Font-Size=Small></asp:Label>
            </td>
            </tr>
            <tr><td height=10px></td></tr>
            
            <tr>
                <td align="center">
                    <table class="t11"  style="width: 100%;">
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1">
                               <strong>First Name </strong> &nbsp;&nbsp;</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtfname" runat="server" AutoComplete="Off" Width="196px" CssClass="txtbox"
                                    Height="26px"></asp:TextBox>&nbsp; 
                                </td>
                            <td></td>
                        </tr>
                      
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1" >
                           <strong> Enter Last Name </strong>&nbsp;</td>
                            <td  align="left" class="auto-style2">
                                <asp:TextBox ID="txtlname" runat="server" Visible="true"  Width="196px" CssClass="txtbox"  Height="26px"  ></asp:TextBox>   
                            </td>
                            <td></td>
                        </tr>
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1" >
                           <strong> Enter Date of birth </strong>&nbsp;</td>
                            <td  align="left" class="auto-style2" valign="middle">
                                <asp:TextBox ID="txtDob" runat="server" Visible="true"  Width="196px" CssClass="txtbox"  Height="26px" ReadOnly="false" placeholder="dd-MM-YYYY" onkeyup="dtval(this,event)" ></asp:TextBox>&nbsp;
                                <a id="DOI" runat="server" href="javascript:NewCal('txtDob','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border-style: none; border-color: inherit; border-width: 0; height: 21px;" width="26px" /></a> 
                             </td>
                            <td></td>
                        </tr>
                        <tr runat="server" id="trcerpac" style="display:none;"><td class="auto-style3"></td>
                            <td align="center" class="auto-style1" >
                           <strong> Cerpac Number </strong>&nbsp;</td>
                            <td  align="left" class="auto-style2">
                                <asp:TextBox ID="txtcerpacno" runat="server" Visible="true"  Width="196px" CssClass="txtbox"  Height="26px" ReadOnly="true"></asp:TextBox>   
                            </td>
                            <td></td>
                        </tr>
                        <tr><td height="30" colspan="3"></td></tr>
                        <tr>
                            <td colspan="4" align="center"><asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" OnClientClick="return validate()" />
                            </td>

                        </tr>
                       
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
</asp:Content>

