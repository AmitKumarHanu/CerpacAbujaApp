<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_StickerPrintingProcess" CodeFile="~/Admin/StickerPrintingProcess.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" />
    <script type="text/javascript">
        function validate()
        {
            var sti = document.getElementById('<%=StickerNo.ClientID%>').value;
            var dee = document.getElementById('<%=txtdeed.ClientID%>').value;
            if (sti.length == 0)
            {
                alert('Please enter sticker number');
                return false;
            }
            else if (dee.length == 0) {
                alert('Please enter deedmark number');
                return false;
            }
            else {
                return true;
            }
        }
        </script>
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
    </style>
    <strong></strong>
    <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 95%"  id="combox" >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Production Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td height="15"></td></tr>
            <tr id="tr_msg" runat="server"><td align="center">
            <%--<asp:Label ID="lblmsg" runat="server" CssClass="information-box abc" Text = "Please Enter CERPAC No./Secured Sold Form No. of the applicant" Font-Size="Small" Width="620px"></asp:Label>--%>

            <asp:Label ID="lblmsg" runat="server"  CssClass="information-box abc" Text = "Please Select CERPAC No./Secured Sold Form No. of the applicant" Font-Size="Small" ></asp:Label>
            </td>
            </tr>
            <tr><td height="10px"></td></tr>
             <tr><td align=center><div class="confirmation-box" height="10px" style="display:none;" id="confirm"  runat="server"><p style="color:#006600"><strong> Updated Sucessfully</strong></p></div></td></tr>
        <tr><td align=center><div class="warning-box" height="10px" style="display:none;" id="warn"  runat="server"><p style="color:#A0522D"><strong>Cerpac Number has not been verified or not exist.</strong></p></div></td></tr>
         
            <tr>
                <td align="center">
                      <table class="t11" style="width: 100%;" runat="server" id="searchopt" >
                        <tr id="tr_ser" runat="server" >
                            <td align="center" style="height: 16px; width: 150px;">
                              <strong>  CERPAC No/Secured Sold Form No.</strong> &nbsp;&nbsp;
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" />
                            </td>
                        </tr>
                      
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">

                            <div></div>    
                            </td>
                        </tr>
                       
                    </table>
                    <table class="t11" style="width: 100%;display:none;" runat="server" id="sticker" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
    
     <asp:Image ID="ImgPhoto" style="position:absolute; top: 409px; width: 194px; height: 217px; left: 800px;" runat="server" ImageUrl="~/Images/Logo/default_logo.gif" />
     <asp:Image ID="imgbarcode" style="position:absolute;width: 398px; height: 137px; top: 803px; left: 601px;" runat="server" />
    <div style="background-image: url('../Images/sticker.png');height:623px; width:412px; margin-left: 164px;" id="div_grd" runat="server">
        <!--sticker goes here -->
        <span style="position:absolute; top: 401px; left: 678px;">
            
       <asp:Label ID="issued" Text="asdfasfdasdf" style="float:left;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>

             <asp:Label ID="at" Text="asdfasfdasdf" style="position:absolute; top:34px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
             <asp:Label ID="expires" style="position:absolute; top:68px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
             <asp:Label ID="audit" style="position:absolute; top:102px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="state" style="position:absolute; top:136px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="passportno" style="position:absolute; top:170px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="dob" style="position:absolute; top:204px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="name" style="position:absolute; top:238px;" runat="server" Width="200px" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="address" style="position:absolute; top:272px;" runat="server" Width="500px" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="address1" style="position:absolute; top:306px; width: 500px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="address2" style="position:absolute; top:340px; width: 500px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
        </span>
        <!--till here -->
       
</div>
   
      </table>
                    </td>
                </tr>
            </td></tr>
        <tr><td height="15"><asp:HiddenField ID="hidcerpacno" runat="server" /><asp:HiddenField ID="hidform" runat="server" /></td></tr>  
                        <tr>
                            <td align="center">
                                <table><tr><td>
                      <asp:Label ID="lbl1" runat="server" Text="Enter the Sticker Number:" Visible="false"></asp:Label></td><td align="center">&nbsp;&nbsp;&nbsp;<asp:TextBox ID="StickerNo" runat="server" CssClass="textbox2" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>
                          </tr></table>          
                      </td>
                        </tr> 
            <tr>
                            <td align="center">
                                <table><tr><td>
                      <asp:Label ID="lbldeed" runat="server" Text="Enter Deedmark Number:" Visible="false"></asp:Label>&nbsp;&nbsp;</td><td align="center">&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtdeed" runat="server" CssClass="textbox2" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>
                          </tr></table>          
                                </td>
                        </tr>  
            <tr>
                <td align="center">                               
                     <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="adminbutton" OnClick="btnSubmit_Click" Visible="false" OnClientClick="return validate();"/>
                            </td>

            </tr>            
    <tr>
        <td align="center">
            <br />
                        <asp:Button ID="btnOk" Text="Ok" runat="server" CssClass="adminbutton" OnClick="btnOk_Click" Visible="false"/> &nbsp;&nbsp;&nbsp;&nbsp;
        
            <asp:Button ID="print" Text="Print Sticker" runat="server" CssClass="adminbutton" OnClick="print_Click" Visible="false"/> 
            </td>

    </tr>
             
        </table>
    </div>
    <script type="text/javascript">
        var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
</asp:Content>

