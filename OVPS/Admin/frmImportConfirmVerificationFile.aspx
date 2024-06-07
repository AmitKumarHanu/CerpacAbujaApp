<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmImportConfirmVerificationFile.aspx.cs" Inherits="Admin_frmImportConfirmVerificationFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="" style="width:95%;">
     <table  id="combox" style="width:100%;">
            <tr  >
                
                <td colspan="2" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">Import Confirm Eligibility Encrypted File &nbsp; </span>
                        </font>
                    </div>
                </td>


            </tr>
            <tr>
            <td colspan="3" style="height: 5px" align="center">
                    <div id="div_File"  runat="server" style="text-align: center; width: 100%; ">
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
            <tr>
            <td colspan="3" style="height: 5px" align="center">
                    <div id="div_SeachDetails" runat="server" align="center" style="width:90%;" >
<table>
<tr >
    <td colspan="4" style="border: 2px dashed #000;" align="center" class="t55 mb-lt"><asp:Label ID="lblZonename" runat="server"></asp:Label></td>
</tr>
<tr >
<td align= "left"  style="border-right: 2px dashed #000; border-left: 2px dashed #000;"><strong>Total Response Form</strong> </td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>Confirmed </strong> </td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>Rejected</strong></td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>Deny</strong></td>

</tr>
<tr class="b77">
<td align="center" style="border: 2px dashed #000; " class="b55 b-lt "><asp:Label ID="lblTotalResponse" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblConfirmed" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblRejected" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblDenny" runat="server"></asp:Label></td>

</tr>
<tr>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>

</tr>

</table>
</div>
            </td>
            </tr>
            <tr>
            <td colspan="3" style="height: 5px" align="center">
                  <div id="div_grd" runat="server" align="center" style="overflow: scroll; height:auto; width:90%;" >
                   <table style="width: 100%; "  >
                    <tr >
                  <td><asp:Label ID="lblConfirm" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                  <td><asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="False"  
        AllowPaging="True" PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging" Width="100%"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>
<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>

     

    <%--<asp:TemplateField HeaderText="Row Inserted">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>

<asp:BoundField DataField="CerpacNo" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="FirstName" HeaderText="First Name" 
        SortExpression="FirstName">

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>

    <asp:BoundField DataField="LastName" HeaderText="Last Name" 
        SortExpression="LastName">

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView></td>
                  </tr>
                 </table> 
                 </div>
            </td>
            </tr>

              <tr>
            <td colspan="3" style="height: 5px" align="center">
                  <div id="div_rejected_Data" runat="server" align="center" style="overflow: scroll; height:auto; width:90%;" >
                   <table style="width: 100%; "  >
                    <tr >
                  <td><asp:Label ID="lblReject" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                  <td><asp:GridView ID="grd_display_Rejecteddata" runat="server"  AutoGenerateColumns="False"  
        AllowPaging="True" PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging" Width="100%"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>
<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>

     

    <%--<asp:TemplateField HeaderText="Row Inserted">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>

<asp:BoundField DataField="CerpacNo" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="FirstName" HeaderText="First Name" 
        SortExpression="FirstName">

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>

    <asp:BoundField DataField="LastName" HeaderText="Last Name" 
        SortExpression="LastName">

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView></td>
                  </tr>
                 </table> 
                 </div>
            </td>
            </tr>

              <tr>
            <td colspan="3" style="height: 5px" align="center">
                  <div id="div_Deny_Data" runat="server" align="center" style="overflow: scroll; height:auto; width:90%;" >
                   <table style="width: 100%; "  >
                    <tr >
                  <td><asp:Label ID="lblDenyComp" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                  <td><asp:GridView ID="grd_deny_Data" runat="server"  AutoGenerateColumns="False"  
        AllowPaging="True" PageSize="5"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        onpageindexchanging="grd_display_data_PageIndexChanging" 
        onrowcreated="grd_display_data_RowCreated" 
        onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging" Width="100%"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>
<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>

     

    <%--<asp:TemplateField HeaderText="Row Inserted">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>

<asp:BoundField DataField="CerpacNo" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

    <asp:BoundField DataField="FirstName" HeaderText="First Name" 
        SortExpression="FirstName">

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>

    <asp:BoundField DataField="LastName" HeaderText="Last Name" 
        SortExpression="LastName">

    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView></td>
                  </tr>
                 </table> 
                 </div>
            </td>
            </tr>

            <tr>

            <td colspan="3" style="height: 5px" align="center">
            <div id="div_Save" runat="server" style="width:95%;">
                    <table class="t11" style="width: 80%;" >
                    <tr id="tr45" runat="server" style="display:block;" align="right" >
<td valign="top" align="right" style="width: 100%; text-align: right;">
<asp:Button ID="btnSave" runat="server"  Text="Save" class="adminbutton" 
        ValidationGroup="a" onclick="btnSave_Click"   />
<asp:Button ID="btn_cancel" runat="server"  Text="Cancel" class="adminbutton" 
        ValidationGroup="a" onclick="btn_cancel_Click" />

</td></tr>
         </table>
            </div>
            </td>
            </tr>
        
            <tr>
                <td align="center">
                      

                      <table class="t11" style="width: 100%;" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">

<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>
    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>

</td>
    
</tr>
                    
                    </table>
                    
                    </td>
                    </tr>
         </table>
         </div>
</asp:Content>

