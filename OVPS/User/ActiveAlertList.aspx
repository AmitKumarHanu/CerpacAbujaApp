<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="ActiveAlertList.aspx.cs" Inherits="User_ActiveAlertList" Title="Active Alert List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
    <tr>
        <td colspan="2" class="PageNameHeadingCSS_2" align="center" style="height: 16px"> Active Document Alert List : Need your attention
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center"> 
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 100%; text-align: left;">
        <asp:GridView ID="GridViewFilesList" runat="server" DataKeyNames="DocId" Width="100%" CellSpacing="1" AutoGenerateColumns="False" OnRowCommand="GridViewFilesList_RowCommand" CssClass="GridBaseStyle"  AllowPaging="True" OnPageIndexChanging="GridViewFilesList_PageIndexChanging" >
            <Columns>
            <asp:BoundField DataField="DocId" HeaderText="Doc No" Visible="False"/>
                <asp:TemplateField HeaderText="Doc Name">
                    <ItemStyle Width="10%" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="lblDocName" runat="server" Text='<%# Bind("DocName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="AlertType" HeaderText="Type" >
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:BoundField DataField="AlertDesc" HeaderText="Alert Description" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
                </asp:BoundField>
               
               <asp:TemplateField HeaderText="Action Date">
                    
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("ActionDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>       
                
             
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" ButtonType="Button" >
                <ControlStyle CssClass="button" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
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
</table>
</asp:Content>

