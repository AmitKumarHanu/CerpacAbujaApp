<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmImportBankDataSB.aspx.cs" Inherits="Admin_frmImportBankDataSB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
     <table style="width:100%;" id="combox">
            <tr>
                
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">Import Bank Data From Central &nbsp; </span>
                        </font>
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
                      <table class="t11" style="width: 100%;">
                        <tr id="tr_ser" runat="server" align="right" >
                        <td style="width:40px;"></td>
                            <td align="left" style="height: 16px; width: 150px;" colspan="3">
                              <strong>Secured Sold Form No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong>
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2" 
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Form No." ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                    
                              
                            </td>
                        </tr>
                      
                        <tr id="tr1" runat="server" align="right" >
                        <td></td>
                            <td align="left" style="height: 16px; width: 150px;" colspan="3">
                              <strong>Cerpac Nos.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong>
                              
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txt_cerpac_no" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2" 
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        </span>
                                    
                                
                            </td>
                        </tr>
                      
                       <tr id="tr2" runat="server" >
                       
                            <td align="center" style="height: 16px; width: 150px;" colspan="4">
                            <br />
                              <asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" />
                            </td>
                            </tr>
                        <tr>
                            <td align="left" style="height: 16px;" colspan="4">

                            </td>
                        </tr>
                        </table>

                      <table class="t11" style="width: 100%;" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>

<div id="divSearchResult" runat="server" align="center" style="width:90%; display:none;" >
 <table width="560" cellpadding="5" class="GridBaseStyle" style="margin: 0px auto;">
            <tbody>

<tr  >
    <td colspan="4" style="visibility:hidden;"><asp:Label ID="lblZonename" runat="server" ></asp:Label></td>
</tr>
<tr >
<td align= "left"  ><strong>Request Form</strong> </td>
<td align= "left"  ><strong>Available in Database</strong> </td>
<td align= "left"  ><strong>Already Used Form</strong></td>
<td align= "left"  ><strong>Unused Form</strong></td>

</tr>
<tr >
<td align="center" ><asp:Label ID="lblTotalRequest" runat="server"></asp:Label></td>
<td align="center" ><asp:Label ID="lblFoundinDatabae" runat="server"></asp:Label></td>
<td align="center" ><asp:Label ID="lblAlreadyUsedForm" runat="server"></asp:Label></td>
<td align="center" ><asp:Label ID="lblFreeForm" runat="server"></asp:Label></td>

</tr>
<tr >
<td align= "left" ></td>
<td align= "left" ></td>
<td align= "left" ></td>
<td align= "left" ></td>

</tr>
</tbody>
</table>
</div>

    <div id="div_grd" style="overflow:scroll; width:750px; display:none;" runat="server">
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="false"  
        AllowPaging="true" PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging"  >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>
<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

<asp:BoundField DataField="Date1" HeaderText="Date" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="true" >

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

<br />

<div id="div_cerpac" style="overflow:scroll; width:750px; display:none;" runat="server">
<asp:GridView ID="grd_cerpac" runat="server"  AutoGenerateColumns="false"  
        AllowPaging="true" PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging"  >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>

<asp:BoundField DataField="forename" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="middle_name" HeaderText="Middle Name" SortExpression="MiddleName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="surname" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="sex" HeaderText="Sex" SortExpression="sex" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="cerpac_no" HeaderText="Cerpac No." SortExpression="cerpac_no" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="cerpac_file_no" HeaderText="Form No." SortExpression="cerpac_file_no" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>


<asp:BoundField DataField="cerpac_receipt_date" HeaderText="Cerpac Receipt Date" SortExpression="cerpac_receipt_date" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="cerpac_expiry_date" HeaderText="Cerpac Expiry Date" SortExpression="cerpac_expiry_date" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="passport_no" HeaderText="Passport No." SortExpression="passport_no" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="nationality" HeaderText="Nationality" SortExpression="nationality" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

</Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>

</div>
   <%-- </ContentTemplate></asp:UpdatePanel>--%>

</td>
    
</tr>
                    
                    </table>
                    <table class="t11" style="width: 22%;" >
                    <tr id="tr45" runat="server" style="display:none;">
<td valign="top" align="right" style="width: 100%; text-align: right;">
<br />
<asp:Button ID="btn_import" runat="server"  Text="Import" class="adminbutton" 
        ValidationGroup="a" onclick="btn_import_Click" />
<asp:Button ID="btn_cancel" runat="server"  Text="Cancel" class="adminbutton" ValidationGroup="a" />

</td></tr>
         </table>
                    </td>
                    </tr>
         </table>
         </div>
</asp:Content>

