<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true"
    CodeFile="ApplicationProcess.aspx.cs" Inherits="Admin_ApplicationProcess" Title="Applicant Status Master" %>

<%@ Import Namespace="System.Data" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/country.css" rel=Stylesheet type="text/css" /> 
     <script type="text/javascript">
         function change() {
             if (document.getElementById('<%=TextAppId.ClientID %>').value != '' && document.getElementById('<%=txtssfn.ClientID %>').value != '') {
                 document.getElementById('zone_contain').className = 'animated-table flipOutY';
                 document.getElementById('loading').style.display = '';

             }
             else {
                 document.getElementById('<%=TextAppId.ClientID %>').className = 'txtboxerror';
                 document.getElementById('<%=txtssfn.ClientID %>').className = 'txtboxerror';
                 return false;
             }
         }

         function claschnge()
         {
             document.getElementById('<%=TextAppId.ClientID %>').className = 'txtbox';
             document.getElementById('<%=txtssfn.ClientID %>').className = 'txtbox';
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
            
            <tr>
                <td align="center">
                    <table class="t11"  style="width: 100%;">
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1">
                               <strong>Enter CERPAC Number </strong> &nbsp;&nbsp;</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" Width="196px" CssClass="txtbox"
                                    Height="26px" onkeyup="claschnge()"></asp:TextBox>&nbsp; 
                                </td>
                            <td></td>
                        </tr>
                      
                        <tr>
                            <td></td>
                            <td></td>
                            <td style="text-align: left">

                              <asp:LinkButton ID="lnkfind" Text="Find CerpacNo" runat="server" Font-Size="Smaller" ForeColor="Blue" OnClick="lnkfind_Click"></asp:LinkButton>
                            </td>
                            <td></td>
                        </tr>


                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1" >
                           <strong> Enter Secured Form No </strong>&nbsp;</td>
                            <td  align="left" class="auto-style2">
                                <asp:TextBox ID="txtssfn" runat="server" Visible="true"  Width="196px" CssClass="txtbox"  Height="26px" onkeyup="claschnge()" AutoComplete="Off" ></asp:TextBox>   
                            </td>
                            <td></td>
                        </tr>
                        <tr><td height="30" colspan="3"></td></tr>
                        <tr>
                            <td colspan="4" align="center"><asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" OnClientClick="return change()" />
                            </td>

                        </tr>
                       <tr>
                           <td colspan="4" align="center">

                           </td>
                       </tr>
                        <tr>
                           <td colspan="4" align="center">
                               <asp:RadioButtonList runat="server" RepeatColumns="2" ID="radbrkcnt" OnSelectedIndexChanged="radbrkcnt_SelectedIndexChanged" AutoPostBack="true" Visible="false">
                                   <asp:ListItem Text="Maintain Continuity" Value="2"></asp:ListItem>
                               </asp:RadioButtonList>
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
