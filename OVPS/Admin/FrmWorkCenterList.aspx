<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="Admin_WorkCenterList, App_Web_frmworkcenterlist.aspx.fdf7a39c" title="Work Center List" %>

<%@ OutputCache NoStore="true" Location="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 95%" id="combox">
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font size: 16px; color:White">&nbsp;Work Center List </span>
                        </font>
                    </div>
                </td>
            </tr>
            <td colspan="2" style="height: 5px">
            </td>
            </tr>
            <tr>
                <td valign="top" style="width: 100%; text-align: left;">
                    <asp:GridView ID="GridViewWorkCenterList" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" OnRowEditing="GridViewWorkCenterList_RowEditing" OnRowDeleting="GridViewWorkCenterList_RowDeleting" OnRowCommand="GridViewWorkCenterList_RowCommand"
                        AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="WorkCenter"
                        OnPageIndexChanging="GridViewWorkCenterList_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Work Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkCenter" runat="server" Text='<%# Bind("WorkCenter") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            
                            <asp:CommandField HeaderText="View" ShowSelectButton="true" ButtonType="Image" SelectImageUrl="~/Images/view.PNG">
                                <ControlStyle CssClass="button" />
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="Update" ShowEditButton="True" ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG">
                                <ControlStyle CssClass="button" />
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <HeaderStyle  HorizontalAlign="Center" Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" OnClientClick='return confirm("Do you want to delete this record ?");'
                                        runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Images/Delete.PNG"
                                        Text="Delete" />
                                
                                </ItemTemplate>

<ControlStyle CssClass="button"></ControlStyle>

<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            </asp:TemplateField>
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
            <tr>
                <td align="center" valign="top" style="width: 100%;">
                    <asp:ImageButton ID="btnAdd" runat="server" CssClass="button" Text="Add City" ValidationGroup="a"
                        TabIndex="6" ImageUrl="~/Images/AddButton.PNG" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
