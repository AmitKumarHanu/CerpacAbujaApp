<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompany.master" AutoEventWireup="true" CodeFile="FrmFormMasterList.aspx.cs" Inherits="FrmFormMasterList" Title="List of Forms" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" class="bcolour" id="combox">

<table cellpadding="2" cellspacing="10" style="border:1px; width:95%" >
    <tr>
        <td colspan="2" align="center" class="PageNameHeadingCSS" style="height: 16px"> Forms List
        </td>
    </tr>
    <tr>
        <td colspan="2" style="height: 5px"> 
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 100%; text-align: left; height: 315px;">
        <asp:GridView ID="GridViewFormList"  runat="server" DataKeyNames="FormId" 
                Width="100%" AutoGenerateColumns="False"  PagerStyle-CssClass="pgr" 
                OnRowCommand="GridViewFormList_RowCommand" 
                OnRowDeleting="GridViewFormList_RowDeleting" AllowPaging="True" 
                CellSpacing="1" CssClass="GridBaseStyle" 
                OnPageIndexChanging="GridViewFormList_PageIndexChanging" PageSize="50" >
            <Columns>
                <asp:TemplateField HeaderText="Form Id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyID" runat="server" Text='<%# Bind("FormId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Form Name">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("FormName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             
               <asp:TemplateField HeaderText="Form URL">
               <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>                    
                        <asp:Label ID="LabelAddress" Text='<%# Eval("FormURL") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>           
                <asp:CommandField  HeaderText="Update"   ShowEditButton="True" 
                    ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG" >
                    <ControlStyle CssClass="button" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" 
                    ButtonType="Image" DeleteImageUrl="~/Images/Delete.PNG" >
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
            <br />
            <table style="font-style:normal" width ="55%" align="center"> 
                                
                <tr>
            
        <td align="center">
                            <asp:ImageButton ID="btnAdd" runat="server" CssClass="button" Text="Add Form" Width="36px"
                                ValidationGroup="a"  TabIndex="6" onclick="btnAdd_Click" Height="36px" 
                                ImageUrl="~/Images/AddButton.PNG" />
                        </td>
        
    </tr>
        </table>
        </td>
    </tr>
</table>
</div>


</asp:Content>

