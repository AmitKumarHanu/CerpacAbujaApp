<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmImportCentralResponseBankData.aspx.cs" Inherits="Admin_frmImportCentralResponseBankData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



 <div id="Main" style="width:95%;" runat="server" >
     <table  id="combox" style="width:100%;" >
            
 <tr>                
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">Import Bank Data From Central &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
 <tr>
<td style="height: 5px; width: 90%; text-align: center;"  >
<div id="divbrowsefile" runat="server" style=" text-align:center; width: 100%; display:block"  >
                        <table style="width: 100%; " >
                        <tr>
                        <td  valign="top" style=  "text-align:left; width: 80%;" >
                            <asp:FileUpload ID="FileUpload1"  runat="server" />
                            <hr />
                        </td>
                        </tr>
                        <tr>
                        <td  valign="top" style=  "text-align:center; width: 20%;" >
                            <asp:Button ID = "btnDecrypt" style="text-align: center;"  class="adminbutton" Text="Decrypt File" runat="server" OnClick = "DecryptFile" /> 
                        </td> 
                        </tr>
                        <tr>
                        <td>  </td>
                       
                        </tr>
                        </table>
                    </div> 
<div id="divSearchResult" runat="server" align="Left" style="width:720px; "  >
<table class="t11"   style="text-align:center;" align="center" width="100%" >
<tr >
    <td colspan="4" style="border: 2px dashed #000;" align="center" class="t55 mb-lt"><asp:Label ID="lblZonename" runat="server"></asp:Label></td>
</tr>

<tr class="b77">
<td align="center" style="border: 2px dashed #000; " class="b55 b-lt "><asp:Label ID="lblTotalRequest" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblFoundinDatabae" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblAlreadyUsedForm" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblFreeForm" runat="server"></asp:Label></td>

</tr>
<tr>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>

</tr>
</table>
<table style="text-align:left;">
<tr>

    <td align="left" class="style1" ><strong>Bank Form Details</strong></td>
</tr>
</table>
</div>
<div id="divgrd" class="t11" runat="server" align="center" style="overflow: scroll; height:auto; width:750px;  " >
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="False" 
            PageSize="5"  CssClass="GridBaseStyle" 
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


    

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1" />

<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="middlename" HeaderText="MiddleName" 
        SortExpression="middlename" />

<asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="Company"  HeaderText="Company Name" SortExpression="Company" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="PassportNo" HeaderText="Passport No" 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>


    

    <asp:BoundField DataField="StrVisaNo" HeaderText="Str Visa No." />


    

    <asp:BoundField DataField="TellerNo" HeaderText="Teller No" SortExpression="TellerNo"/>


    

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>  

    </div>
<div id="divSearchCerpac" runat="server" align="Left" style="width:90%; "  >
<table>
<tr>

    <td colspan="4" align="left" class="style1" ><strong>Cerpa Details</strong></td>
</tr>
</table>
</div>
<div id="divgrdCerpac" class="t11" runat="server" align="center" style="overflow: scroll; height:auto; width:750px;" >
<asp:GridView ID="grd_CerpacNo" runat="server"  AutoGenerateColumns="False" 
            PageSize="5"  CssClass="GridBaseStyle" 
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

<asp:BoundField DataField="forename" HeaderText="First Name" 
        SortExpression="forename" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>


<asp:BoundField DataField="middle_name" HeaderText="Middle Name" 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" 
        SortExpression="middle_name" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>


    

<asp:BoundField DataField="surname" HeaderText="Last Name" SortExpression="surname" 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="sex" HeaderText="Sex" SortExpression="sex" />

<asp:BoundField DataField="cerpac_no" HeaderText="Cerpac No." 
        SortExpression="cerpac_no" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="cerpac_file_no" HeaderText="FRN No." 
        SortExpression="cerpac_file_no" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField HeaderText="Cerpac Receipt Date" DataField="cerpac_receipt_date" 
        SortExpression="cerpac_receipt_date" />

    <asp:BoundField HeaderText="Cerpac Expiry Date" DataField="cerpac_expiry_date" 
        SortExpression="cerpac_expiry_date" />

<asp:BoundField DataField="nationality" HeaderText="Nationality" 
        SortExpression="nationality" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="passport_no" HeaderText="Passport" 
        SortExpression="passport_no"/>

<asp:BoundField DataField="company"  HeaderText="Company Name" 
        SortExpression="company" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" Visible="False" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="designation" HeaderText="Designation" 
        SortExpression="designation" Visible="False"/>


    

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>  

    </div>
<div id="divCrefile" runat="server" align="center" style="width:90%; "  >
    <table class="t11" style="width: 100%;" >
                    <tr id="tr45" runat="server" style="display:block;" align="right" >
<td valign="top" align="right" style="width: 100%; text-align: right;">
<asp:Button ID="btnSave" runat="server"  Text="  Save  " class="adminbutton" 
        ValidationGroup="a" onclick="btnSave_Click"    />  

     

</td>
<td>
 
    <input id="txtBankDate" type="text" runat="server" style="display:none;" />
    
</td> 
</tr>
         </table>
         </div>
    </td>
    </tr>
    
  </table>                 
            
 </div>
</asp:Content>

