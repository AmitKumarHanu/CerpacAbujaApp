<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="Admin_FrmZoneList" CodeFile="~/Admin/FrmZoneList.aspx.cs" title="Registered Zone List" %>
<%@ OutputCache NoStore="true" Location="None"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div align="center" class="bcolour">

<table cellpadding="2" cellspacing="10" style="border:1px; width:95%" id="combox">
    
 <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><fontclass="b12"><span style="fontsize:16px; color:White">&nbsp;Registered Zone List  &nbsp; </span></font>
                        </div>
                    </td>
                </tr>
    <tr>
        <td colspan="2" style="height: 5px"> 
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 100%; text-align: left;">
        <asp:GridView ID="GridViewZoneList" PagerStyle-CssClass="pgr" runat="server"  Width="100%" 
                AutoGenerateColumns="False" OnRowEditing="GridViewZoneList_RowEditing" 
                OnRowDeleting="GridViewZoneList_RowDeleting" OnRowCommand="GridViewZoneList_RowCommand" AllowPaging="True" CellSpacing="1" 
                CssClass="GridBaseStyle" DataKeyNames="ZoneCode"
                OnPageIndexChanging="GridViewZoneList_PageIndexChanging" 
                onselectedindexchanged="GridViewZoneList_SelectedIndexChanged"  >
            <Columns>
                 <asp:TemplateField HeaderText="ZoneName" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblZoneName" runat="server" Text='<%# Bind("ZoneCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>               
                <asp:BoundField DataField="ZoneName" HeaderText="Zone Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="Zone Code" >
                    <ItemTemplate>
                        <asp:Label ID="lblZoneCode" runat="server" Text='<%# Bind("ZoneCode") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:CommandField HeaderText="View" ShowSelectButton="true" ButtonType="Image" SelectImageUrl="~/Images/view.PNG">
                                <ControlStyle CssClass="button" />
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:CommandField>
                         
                 <asp:CommandField  HeaderText="Update"   ShowEditButton="True" 
                    ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG" >
                    <ControlStyle CssClass="button" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                </asp:CommandField>
                 <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                     <ItemTemplate>
                         <asp:ImageButton ID="btnDelete" OnClientClick='return confirm("Do you want to delete this record ?");' runat="server" CausesValidation="False" 
                             CommandName="Delete" ImageUrl="~/Images/Delete.PNG" Text="Delete" />
                     </ItemTemplate>
                     <ControlStyle CssClass="button" />
                     <ItemStyle HorizontalAlign="Center" Width="10%" />
                 </asp:TemplateField>
               
            </Columns>
            <HeaderStyle CssClass="Grid_Header" />
            <RowStyle CssClass="Grid_Item"/>
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
            <SelectedRowStyle CssClass="Grid_Selected" />
            <FooterStyle CssClass="Grid_Footer" />
            
        </asp:GridView>
        </td>
        </tr>
        <tr>
        <td align="center" valign="top" style="width: 100%;">
           
                            <asp:ImageButton ID="btnAdd" runat="server" CssClass="button" Text="Add Zone"
                                ValidationGroup="a"  TabIndex="6"
                                ImageUrl="~/Images/AddButton.PNG" onclick="btnAdd_Click"/>
                        </td>
        
    </tr>
     
</table>
</div>



</asp:Content>

