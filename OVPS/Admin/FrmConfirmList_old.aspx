<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" enableeventvalidation="false" inherits="Admin_FrmConfirmList, App_Web_frmconfirmlist.aspx.fdf7a39c" %>

<%@ Import Namespace="System.Data" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 
    <script type="text/javascript">
        function change(text) {

            if (text == 1) {
                if (document.getElementById('<%=TextAppId.ClientID %>').value != '')
                    document.getElementById('<%=auth_contain.ClientID %>').className = 'animated-table flipOutY';
                document.getElementById('<%=loading.ClientID %>').style.display = '';
                document.getElementById('loadertext').innerHTML = 'Fetching Data.Please Wait. . . . .';
            }
            else if (text == 2) {
                document.getElementById('<%=auth_contain.ClientID %>').className = 'animated-table flipOutY';
                document.getElementById('<%=loading.ClientID %>').style.display = '';
                document.getElementById('loadertext').innerHTML = 'Authorisation in progress.Please Wait. . . . .';

            }
            else if (text == 3) {
                document.getElementById('<%=auth_contain.ClientID %>').className = 'animated-table flipOutY';
                document.getElementById('<%=loading.ClientID %>').style.display = '';
                document.getElementById('loadertext').innerHTML = 'Rejection in progress.Please Wait. . . . .';
            }

}
    </script>
    <style type="text/css">
    .abc
    {text-decoration:blink;
        }
    </style>
    <strong></strong>
     <table cellpadding="5" cellspacing="2" border="0" width="750px" id=loading style="display:none" runat="server">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Fetching data.Please Wait. . . . .</td></tr>
                        </table>
    <center><div align=center class="confirmation-box" height=10px style="display:none;" id=confirm  runat=server><p style="color:#006600" id="p" runat=server><strong>Applicant Confirmed Sucessfully</strong></p></div></center>
    <div align="center" class="bcolour" id="auth_contain" runat="server">
        <table cellpadding="2" cellspacing="10" style="width: 95%"  id="combox" >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Eligibility Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td height=15></td></tr>
            <tr><td align=center>
            <asp:Label ID=lblmsg runat=server CssClass="information-box abc" Text = "Please Enter CERPAC No./Secured Sold Form No. of the applicant" Font-Size=Small Width=620px></asp:Label>
            </td>
            </tr>
            <tr><td height=10px></td></tr>
            <tr>
                <td align="center">
                    <table class="t11" style="width: 100%;" >
                        <tr>
                            <td align="center" style="height: 16px; width: 150px;">
                               <strong>CERPAC No </strong><span style="font-size:12px;"><strong >(Secured Sold Form No. in case of new case)</strong></span> &nbsp;&nbsp;
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" OnClientClick="change(1)" />
                            </td>
                        </tr>
                      <tr><td height=20px></td></tr>
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">
                                <div>
                             <asp:GridView ID="GridViewAuth" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="cerpac_no"
                        OnPageIndexChanging="GridViewAuth_PageIndexChanging" OnRowEditing="GridViewAuth_RowEditing" OnRowCreated="GridViewAuth_RowCreated" OnSelectedIndexChanged="GridViewAuth_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerpac No">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Passport No" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassportno" runat="server" Text='<%# Bind("passport_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Company">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Nationality">
                                <ItemTemplate>
                                    <asp:Label ID="lblNationality" runat="server" Text='<%# Bind("Nationality") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Designation" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesig" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>

                <asp:TemplateField HeaderText="Select" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                    <HeaderTemplate><asp:CheckBox ID="chkselectall" runat="server" Text= 
                                            OnCheckedChanged="chkAccessAll_CheckedChanged" AutoPostBack="true" /></HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" />
                                </asp:TemplateField>
                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView></div>
                            </td>
                        </tr>
                       
                    </table>
                     &nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr><td><asp:Button ID="btnconfirm" runat="server" Text="Confirm" CssClass="adminbutton" OnClick="btnconfirm_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btndeny" runat="server" Text="Deny" CssClass="adminbutton" OnClick="btndeny_Click" />
                </td></tr>
        </table>
    </div>
    <script type="text/javascript">
        var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
</asp:Content>




