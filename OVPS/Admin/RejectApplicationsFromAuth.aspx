<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="RejectApplicationsFromAuth.aspx.cs" Inherits="Admin_RejectApplicationsFromAuth" EnableEventValidation="false" %>

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
        <table cellpadding="2" cellspacing="10" style="width: 95%;" id="combox" >
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
            <asp:Label ID=lblmsg runat=server CssClass="information-box abc" Text = "Please type Secured Sold Form No." Font-Size=Small></asp:Label>
            </td> </tr>
            <tr><td align="center"><table class="t11" style="width: 50%;" >
                        <tr id="tr_ser" runat="server" >
                            <td align="center" style="height: 16px; width: 150px;">                              
                                <asp:TextBox ID="txtSearchFormno" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2" MaxLength="8"
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Button ID="Button1" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Search_Click" />
                            </td>
                        </tr>
                      
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">

                            </td>
                        </tr>
                       
                        

                    </table></td></tr>
             <tr><td height=10px align="center" style="display:none;"><asp:RadioButtonList ID="radionewold" runat="server" RepeatColumns="2" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="radionewold_SelectedIndexChanged" Visible="false">
                 <asp:ListItem Text="New" Value="0" Selected="True"></asp:ListItem>
                 <asp:ListItem Text="Renew" Value="1"></asp:ListItem>
                                 </asp:RadioButtonList></td></tr>
            <tr>
                <td align="center">
                    <table class="t11"  style="width: 100%; display:none;">
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1">
                               <strong><span runat="server" id="cerpfrm" style="display:none;"> Enter CERPAC Number </span></strong> &nbsp;&nbsp;</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" Width="196px" CssClass="txtbox"
                                    Height="26px" Visible="false"></asp:TextBox>&nbsp; 
                                </td>
                            <td></td>
                        </tr>
                      
                        <tr><td class="auto-style3"></td>
                            <td align="center" class="auto-style1" >
                           <strong><span id="secfrm" runat="server">Enter Secured Form No</span>  </strong>&nbsp;</td>
                            <td  align="left" class="auto-style2">
                                <asp:TextBox ID="txtssfn" runat="server" Visible="true"  Width="196px" CssClass="txtbox"  Height="26px" ></asp:TextBox>   
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
            <tr>
                <td>
                    <asp:GridView ID="GridViewReject" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="cerpac_no"
                        OnPageIndexChanging="GridViewReject_PageIndexChanging" OnRowCreated="GridViewReject_RowCreated" OnSelectedIndexChanged="GridViewReject_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="Cerpac_No" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>
                            <asp:TemplateField HeaderText="Cerpac No" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FRN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblFRNNo" runat="server" Text='<%# Bind("Formno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>                       


                                                          <asp:TemplateField HeaderText="Remark">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField> 
                                                         <asp:BoundField DataField="Cerpac_No" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
</asp:Content>


