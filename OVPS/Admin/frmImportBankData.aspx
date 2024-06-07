<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmImportBankData.aspx.cs" Inherits="Admin_frmImportBankData" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

        
        .confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
	align:center;
    font-size: 18px;
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
}

       

       

       

    </style>

      <style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: transparent;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 60%;
        width: 60%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        /*border: 5px solid #67CFF5;*/
        width: 100%;
        vertical-align:text-top !important;
     
    background-color: transparent;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        position: absolute;

        top: 0px!important;
height: 100%;
display: none;
margin-left: 0px !important;


        background-color: lightgrey;
        z-index: 999;
    }


     .loading_other
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
    </style>

 <script type="text/javascript" src="../JS/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            location.href = '#top';
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });

        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>

   
     <div id="div_load" class="loading" align="center" valign="center" runat="server">
   
                       
    <img src="../Images/712.gif" alt="" / style="margin-top:20%">
         <br />
    <b>Pl. Wait.....</b>
</div>


     <div align="center" class="bcolour" style=" width: 750px">
        <table cellpadding="2" cellspacing="10" style="width: 750px;"  id="combox" >
            <tr>
                <td colspan="2" class="style3">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Bank Form Request &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr>
<td  valign="top" align="center" style="width: 750px;" text-align: right;">


</td> 
  
</tr>
            <tr>
                <td colspan="2" class="style3" style="text-align:left;">
                    <strong> New Case.</strong>
                </td>
            </tr>
            <tr>
                <td align="center" class="style4">
                      <table class="t11" style="width:  750px;"" >                          

                        <tr id="tr_ser" runat="server" >
                        <td align="left" class="style1" ><strong> Form No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong>&nbsp; &nbsp; &nbsp;</td>
                            <td align="left" >
                                <asp:TextBox ID="txtFormNo" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="250px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            
                        </tr>
                    
 </table>  
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table cellpadding="2" cellspacing="10" style="width: 750px;"  id="combox" >           
            
            <tr>
                <td   style="text-align:left;">
                    <strong> Renewal Case.</strong>
                </td>
            </tr>
            <tr>
                <td align="center">
                <table class="t11" style="width: 750px;" >  
                        <tr id="tr1" runat="server" >
                        <td align="left" ><strong> Form No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong></td>
                            <td align="left" >
                                <asp:TextBox ID="txtFormNo1" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="250px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            
                        </tr>
                        <tr id="tr2" align="left" runat="server" >
                            <td ><strong>Cerpac No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong></td>
                            <td align="left" >
                                <asp:TextBox ID="txtCerpacno" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="250px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            
                        </tr>
                    </table>
                <table class="t11" style="width: 750px;" >
 <tr>
 <td  valign="top" align="center" style="width: 750px; text-align: right;">
    
<hr />
 <asp:Button ID = "btnSearch" class="adminbutton" Text="Search" runat="server" 
         onclick="btnSearch_Click"  OnClientClick="ShowProgress();"  />

</td> 
<td>
 
    &nbsp;</td> 
</tr>
<tr>
<td colspan="2"> 
   <div id="divSearchResult" runat="server" align="left" style="width:750px; "  >
<table class="t11"   style="text-align:center; width: 750px;" align="center"  >
<tr >
    <td colspan="4" style="border: 2px dashed #000;" align="center" class="t55 mb-lt"><asp:Label ID="lblZonename" runat="server"></asp:Label></td>
</tr>
<tr >
<td align= "left"  style="border-right: 2px dashed #000; border-left: 2px dashed #000;"><strong>Request Form</strong> </td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>Available in Database</strong> </td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>Already Used Form</strong></td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>Free Form</strong></td>

</tr>
<tr class="b77">
<td align="center" style="border: 2px dashed #000; " class="b55 b-lt "><asp:Label ID="lblTotalRequest" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblFoundinDatabae" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblAlreadyUsedForm" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblFreeForm" runat="server"></asp:Label></td>

</tr>
</table>
<table style="text-align:left;">
<tr>

    <td colspan="4" align="left" class="style1" ><strong>Bank Form Details</strong></td>
</tr>
</table>

</div>
   <div id="divgrd" class="t11" runat="server" align="center" style="overflow: scroll; height:auto; width:750px;  " >
<asp:GridView ID="grd_Bankdata" runat="server"  AutoGenerateColumns="False" 
            PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7" Width="100%"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>


    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>


<asp:BoundField DataField="Date1" HeaderText="Date" 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>

</asp:BoundField>


    

<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="middlename" HeaderText="Middle Name" 
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

    <asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>


    

<asp:BoundField DataField="PassportNo" HeaderText="PassportNo" 
        SortExpression="PassportNo" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" Visible="False" >

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />

</asp:BoundField>

    <asp:BoundField DataField="StrVisaNo" HeaderText="StrVisaNo" 
        SortExpression="StrVisaNo" Visible="False" />


    

    <asp:BoundField DataField="TellerNo" HeaderText="Teller No" SortExpression="TellerNo"/>

    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" 
        Visible="False"/>


    

    <asp:BoundField DataField="RequisitionNo" HeaderText="RequisitionNo" 
        SortExpression="RequisitionNo" Visible="False" />


    

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>  

    </div>
   <div id="divSearchCerpac" runat="server" align="Left" style="width: 750px;"  >
<table>
<tr>

    <td colspan="4" align="left" class="style1" ><strong>Cerpa Details</strong></td>
</tr>
</table>
</div>
   <div id="divgrdCerpac" class="t11" runat="server" align="center" style="overflow: scroll; height:auto; width:750px;" >
<asp:GridView ID="grd_CerpacNo" runat="server"  AutoGenerateColumns="False" 
            PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7" Width="100%" onselectedindexchanged="grd_CerpacNo_SelectedIndexChanged"
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

<asp:BoundField DataField="company"  HeaderText="Company Name" SortExpression="company" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="designation" HeaderText="Designation" 
        SortExpression="designation"/>


    

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>  

    </div>
   <div id="divImportBtn" class="t11" runat="server" >
    <table class="t11"   style="text-align:center; width: 750px;" align="center"  >
<tr >
<td  valign="top" align="center" style="width: 750px; text-align: right;">
    

 <asp:Button ID = "btnImport" class="adminbutton" Text="Import Bank Data" 
        runat="server" onclick="btnImport_Click"   />

</td> 
</tr>
</table>

    </div>
     </td>
</tr>
<tr>

<td>
 
    &nbsp;</td>   
</tr>
                    
</table>  
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

