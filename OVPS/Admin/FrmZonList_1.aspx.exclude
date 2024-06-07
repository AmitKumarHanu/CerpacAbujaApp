<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="Admin_FrmZonList, App_Web_frmzonlist_1.aspx.fdf7a39c" title="Registered Zone List" %>
<%@ OutputCache NoStore="true" Location="None"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div align="center" class="bcolour">

<table cellpadding="2" cellspacing="10" style="border:1px; width:95%">
    <tr>
        <td colspan="2" align="center" class="PageNameHeadingCSS_2" style="height: 16px"> Registered Zone List
        </td>
    </tr>
    <tr>
        <td colspan="2" style="height: 9px"> 
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 100%; text-align: left; height: 315px;">
        <asp:GridView ID="GridViewZonList"  runat="server"  Width="100%" 
                AutoGenerateColumns="False" OnRowEditing="GridViewZonList_RowEditing" 
                OnRowDeleting="GridViewZonList_RowDeleting" AllowPaging="True" CellSpacing="1" 
                CssClass="GridBaseStyle" DataKeyNames="ZoneName"
                OnPageIndexChanging="GridViewZonList_PageIndexChanging" 
                onselectedindexchanged="GridViewZonList_SelectedIndexChanged"  >
            <Columns>
                 <asp:TemplateField HeaderText="ZonCode" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblZonCode" runat="server" Text='<%# Bind("ZoneName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>               
                <asp:BoundField DataField="ZoneName" HeaderText="Zone Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:BoundField>
               
               <asp:TemplateField HeaderText="ZonCode" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblCityName" runat="server" Text='<%# Bind("CityName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>               
                <asp:BoundField DataField="CityName" HeaderText="City Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:BoundField>
                         
                <asp:CommandField  HeaderText="Update"   ShowEditButton="True" 
                    ButtonType="Image" EditImageUrl="~/Images/EditButton.jpg" >
                    <ControlStyle CssClass="button" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                </asp:CommandField>
               
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
           
                            <asp:ImageButton ID="btnAdd" runat="server" CssClass="button" Text="Add City" Width="36px"
                                ValidationGroup="a"  TabIndex="6" Height="36px" 
                                ImageUrl="~/Images/AddButton.jpg" onclick="btnAdd_Click"/>
                        </td>
        
    </tr>
     
</table>
</div>



</asp:Content>

