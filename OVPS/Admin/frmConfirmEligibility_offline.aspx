<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmConfirmEligibility_offline.aspx.cs" Inherits="Admin_frmConfirmEligibility_offline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 

      <style type="text/css">
    .abc
    {text-decoration:blink;
        }
        .style1
        {
            height: 52px;
        }
        .style2
        {
            height: 16px;
            width: 241px;
        }
        .style3
        {
            width: 241px;
        }
    </style>
    <strong></strong>


      <table cellpadding="5" cellspacing="2" border="0" width="750px" id=loading style="display:none" runat="server">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Fetching data.Please Wait. . . . .</td></tr>
                        </table>


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


            <tr>
<td style="height: 5px; width: 720px; text-align: left;"  >
 
 <div id="divSearchResult" runat="server" align="center" style="width:720px; display:block "  >
<table class="t11">
<tr >
    <td colspan="3" style="border: 2px dashed #000;" align="center" class="t55 mb-lt"><asp:Label ID="lblZonename" runat="server"></asp:Label></td>
</tr>
<tr >

<td align= "left"  style="border: 2px dashed #000;" class="b55 mb-lt "><strong>AO CerpacNo</strong> </td>
<td align= "left"  style="border: 2px dashed #000;" class="t55 mb-lt"><strong>AR CerpacNo</strong></td>
<td align= "left"  style="border: 2px dashed #000;" class="t55 mb-lt"><strong>CR CerpacNo</strong></td>


</tr>
<tr class="b77">

<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblAOCerpacNo" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblARCerpacNo" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblCRCerpacNo" runat="server"></asp:Label></td>

</tr>
<tr>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>

</tr>
</table>
</div>
<div id="divgrd" class="t11" runat="server" align="center" style="overflow: scroll; height:auto; width:720px;  " >
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="False" 
              CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging" Width="100%"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>


    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>

    <asp:BoundField DataField="dist" HeaderText="distinct" Visible="False" />

<asp:BoundField DataField="forename" HeaderText="First Name" 
        SortExpression="forename" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="middle_name" HeaderText="Middle Name" />

<asp:BoundField DataField="surname" HeaderText="Last Name" SortExpression="surname" 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="Cerpac_No" HeaderText="Cerpac No." 
        SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="Cerpac_file_no" HeaderText="FRN No." 
        SortExpression="Cerpac_file_no" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="cerpac_expiry_date" HeaderText="Cerpac Expiry Date"/>

    <asp:BoundField DataField="cerpac_receipt_date" HeaderText="Cerpac Issue Date"/>


<asp:BoundField DataField="nationality" HeaderText="Nationality " 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>

</asp:BoundField>
  

    <asp:BoundField DataField="passport_no" HeaderText="Passport No " />
    <asp:BoundField DataField="date_of_birth" HeaderText="Date of Birth" />
    <asp:BoundField DataField="company" HeaderText="Company" />
    <asp:BoundField DataField="designation" HeaderText="Designation " />    

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>  

    </div>
<div id="divCrefile" runat="server"  >
    <table class="t11" style="width: 100%;" >
                    <tr id="tr45" runat="server" style="display:block;" align="right" >
<td valign="top" align="right" style="width: 100%; text-align: right;">
<asp:Button ID="btnEncrypt" runat="server"  Text="Encrypt & Download" class="adminbutton" 
        ValidationGroup="a" onclick="btnEncrypt_Click"    />       

</td>
<td>
 
    <input id="txtfilename" type="text" runat="server" style="display:none;" />
    
</td>
</tr>
         </table>
         </div>
    </td>
    </tr>
            </table>
            </div>
</asp:Content>

