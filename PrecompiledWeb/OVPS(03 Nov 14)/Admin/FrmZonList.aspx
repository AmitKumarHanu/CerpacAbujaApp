<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="Admin_FrmZonList, App_Web_frmzonlist.aspx.fdf7a39c" title="Registered Zone List" %>
<%@ OutputCache NoStore="true" Location="None"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div align="center" class="bcolour">

<table cellpadding="2" cellspacing="10" style="border:1px; width:95%" id="combox">
   <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><font class="b12"><span style="font size:16px ; color:White">&nbsp; Registered Zone List  &nbsp; </span></font>
                        </div>
                    </td>
                </tr>
    <tr>
        <td colspan="2" style="height: 9px"> 
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 100%; text-align: left;">
        <asp:GridView ID="GridViewZonList" PagerStyle-CssClass="pgr" runat="server"  Width="100%" 
                AutoGenerateColumns="False" OnRowEditing="GridViewZonList_RowEditing" 
                OnRowDeleting="GridViewZonList_RowDeleting"  OnRowCommand="GridViewZonList_RowCommand" AllowPaging="True" CellSpacing="1" 
                CssClass="GridBaseStyle" DataKeyNames="ZoneName"
                OnPageIndexChanging="GridViewZonList_PageIndexChanging" 
                onselectedindexchanged="GridViewZonList_SelectedIndexChanged"  >
            <Columns>
                 <asp:TemplateField HeaderText="ZonCode" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblZonCode" runat="server" Text='<%# Bind("ZoneName") %>'></asp:Label>
                    </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
                <asp:CommandField HeaderText="View" ShowSelectButton="true" ButtonType="Image" selectImageUrl="~/Images/view.PNG">
                                <ControlStyle CssClass="button" />
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:CommandField>
                         
                <asp:CommandField  HeaderText="Update"   ShowEditButton="True" 
                    ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG" >
                    <ControlStyle CssClass="button" />
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
           
                            <asp:ImageButton ID="btnAdd" runat="server" CssClass="button" Text="Add City" 
                                ValidationGroup="a"  TabIndex="6"
                                ImageUrl="~/Images/AddButton.PNG" onclick="btnAdd_Click"/>
                        </td>
        
    </tr>
     
</table>
</div>



</asp:Content>

