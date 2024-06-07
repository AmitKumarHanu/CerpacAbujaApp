<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_ApplicationProcessForAR, App_Web_applicationprocessforar.aspx.fdf7a39c" %>


<%@ Import Namespace="System.Data" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/country.css" rel=Stylesheet type="text/css" /> 
     <script type="text/javascript">
         function change() {
             
                 document.getElementById('zone_contain').className = 'animated-table flipOutY';
                 document.getElementById('loading').style.display = '';

            
         }

        
    </script>
    <strong></strong>
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
        .auto-style1 {
            height: 16px;
            width: 251px;
        }
        .auto-style2 {
            width: 256px;
        }
        .auto-style3 {
            width: 109px;
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
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Application Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td height=15></td></tr>
            <tr><td align=center>
            <asp:Label ID=lblmsg runat=server CssClass="information-box abc" Text = "Please Enter CERPAC No/Secured Sold Form No." Font-Size=Small></asp:Label>
            </td>
            </tr>
            <tr><td height=10px></td></tr>
             <tr><td height=10px align="center"><asp:RadioButtonList ID="radionewold" runat="server" RepeatColumns="2" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="radionewold_SelectedIndexChanged">
                 <asp:ListItem Text="New" Value="0" Selected="True"></asp:ListItem>
                 <asp:ListItem Text="Renew" Value="1"></asp:ListItem>
                                 </asp:RadioButtonList></td></tr>
            <tr>
                <td align="center">
                    <table class="t11"  style="width: 100%;">
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1">
                               <strong><span runat="server" id="cerpfrm" style="display:none;"> Enter CERPAC Number </span></strong> &nbsp;&nbsp;</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" MaxLength="8" Width="196px" CssClass="txtbox"
                                    Height="26px" Visible="false"></asp:TextBox>&nbsp; 
                                </td>
                            <td></td>
                        </tr>
                      
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1" >
                           <strong><span id="secfrm" runat="server">Enter Secured Form No</span>  </strong>&nbsp;</td>
                            <td  align="left" class="auto-style2">
                                <asp:TextBox ID="txtssfn" runat="server" Visible="true"  Width="196px" CssClass="txtbox" MaxLength="8"  Height="26px" AutoComplete="Off" ></asp:TextBox>   
                            </td>
                            <td></td>
                        </tr>
                        <tr><td height="30" colspan="3"></td></tr>
                        <tr>
                            <td colspan="4" align="center"><asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" OnClientClick="return change()" />
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
