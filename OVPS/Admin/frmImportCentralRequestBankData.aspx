﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmImportCentralRequestBankData.aspx.cs" Inherits="Admin_frmImportCentralRequestBankData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="" style="width:95%;">
     <table  id="combox" style="width:100%;">
            <tr>
                
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">Import Bank Data From Central &nbsp; </span>
                        </font>
                    </div>
                </td>


            </tr>
            <tr>
            <td colspan="3" style="height: 5px" align="center">
                    <div  style="text-align: center; width: 100%; ">
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
                        </table>
                    </div>
                </td>
            </tr>
         <tr><td height="15"></td></tr>
            <tr id="tr_msg" runat="server"><td align="center" style="visibility:hidden">
                <%--<asp:Label ID="lblmsg" runat="server" CssClass="information-box abc" Text = "Please Enter CERPAC No./Secured Sold Form No. of the applicant" Font-Size="Small" Width="620px"></asp:Label>--%>

            <asp:Label ID="lblmsg" runat="server"  CssClass="information-box abc" Text = "Please Select Secured Sold Form No. of the applicant" Font-Size="Small" ></asp:Label>
            </td>
            </tr>
          <tr><td height="10px"></td></tr>
            <tr>
                <td align="center">
                      <table class="t11" style="width: 100%;" >
                      <tr>
                      <td align="center" style="height: 16px; width: 150px;" ><asp:Label ID="lblRequestedZone" runat="server"></asp:Label></td>
                      </tr>
                        <tr id="tr_ser" runat="server" >
                        
                            <td align="center" style="height: 16px; width: 150px;">
                              <strong>Secured Sold Form No.</strong> &nbsp;&nbsp;
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2" 
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Form No." ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Button ID="btnSearchForm" runat="server"  Text="Search Form" 
                                    class="adminbutton" ValidationGroup="a" onclick="btnSearchForm_Click" />

                            </td>
                        </tr>
                      
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">

                            </td>
                        </tr>
                        </table>

                      <table class="t11" style="width: 100%;" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
<div id="div_SeachDetails" runat="server" align="center" style="width:90%;" >
<table>
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
<tr>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>

</tr>
<tr>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>

</tr>
</table>
</div>
    <div id="div_grd" runat="server" align="center" style="overflow: scroll; height:auto; width:90%;" >
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="false"  
        AllowPaging="true" PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" onselectedindexchanging="grd_display_data_SelectedIndexChanging" Width="100%"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>
<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

<asp:BoundField DataField="Date1" HeaderText="Date" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="MiddleName" HeaderText="Middle Name" SortExpression="MiddleName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

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

<asp:BoundField DataField="RequisitionNo" HeaderText="Req No." SortExpression="RequisitionNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="CerpacNo" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="TellerNo" HeaderText="Teller No" SortExpression="TellerNo"/>

    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"/>

    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>
    <asp:BoundField DataField="PassportNo" HeaderText="Passport No." SortExpression="PassportNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="StrVisaNo" HeaderText="Str Visa No." SortExpression="StrVisaNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

     

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

     

    <%--<asp:TemplateField HeaderText="Row Inserted">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>

</div>
    <%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

</td>
    
</tr>
                    
                    </table>
                    <table class="t11" style="width: 80%;" >
                    <tr id="tr45" runat="server" style="display:block;" align="right" >
<td valign="top" align="right" style="width: 100%; text-align: right;">
<asp:Button ID="btnEncrypt" runat="server"  Text="Import" class="adminbutton" 
        ValidationGroup="a" onclick="btnEncrypt_Click"  />
<asp:Button ID="btn_cancel" runat="server"  Text="Cancel" class="adminbutton" 
        ValidationGroup="a" onclick="btn_cancel_Click" />

</td></tr>
         </table>
                    </td>
                    </tr>
         </table>
         </div>
</asp:Content>

