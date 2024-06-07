<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="Admin_FrmVisaTypeList" CodeFile="~/Admin/FrmVisaTypeList.aspx.cs" title="Registered CERPAC Type List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language=javascript>
    function viewwork(id) {
        window.open('ViewWorkFlow.aspx?visacode=' + id + '', 'PaperVisa', 'menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');
        return false;
    }
</script>
    <div align="center">

<table cellpadding="2" cellspacing="10" style="width:95%" id="combox">
     <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><fontclass="b12"><span style="fontsize:16px; color:White">&nbsp; Registered 
                        CERPAC Type List  &nbsp; </span></font>
                        </div>
                    </td>
                </tr>
    <tr>
        <td colspan="2" style="height: 5px"> 
        </td>
    </tr>
    <tr>
        <td valign="top"  align="center" style="width: 100%; text-align: center;">
        <asp:GridView ID="GridViewVisaTypeList" PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False"  OnRowEditing="GridViewVisaTypeList_RowEditing"                
                OnRowDeleting="GridViewVisaTypeList_RowDeleting" AllowPaging="True" 
                CssClass="GridBaseStyle" CellPadding="1" CellSpacing="1" 
                OnPageIndexChanging="GridViewVisaTypeList_PageIndexChanging" DataKeyNames="VisaTypeCode" onrowdatabound="GridApplicantPrintVisa_RowDataBound" >
            <Columns>
              <asp:TemplateField HeaderText="CERPAC Type Code" Visible="true" >
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
              <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblVisaTypeCode" runat="server" Text='<%# Bind("VisaTypeCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CERPAC Type Name">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Label ID="lblSVisaTypeName" runat="server" Text='<%# Bind("SVisaTypeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CERPAC Type Description">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Label ID="lblVisaTypeName" runat="server" Text='<%# Bind("VisaTypeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  
          
             
                         
                <asp:CommandField  HeaderText="Update"   ShowEditButton="True" 
                    ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG" >
                    
                    <ControlStyle CssClass="button" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="btndelete" OnClientClick='return confirm("Do you want to delete this record ?");' runat="server" CausesValidation="False" 
                            CommandName="Delete" ImageUrl="~/Images/Delete.PNG" Text="Delete" />
                    </ItemTemplate>
                    <ControlStyle CssClass="button" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnView"
                                        runat="server" CausesValidation="False" CommandName="Print" ImageUrl="~/Images/view.png"
                                        Text="View" />
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
                                    
     <tr align ="center">            
        <td align="center">
                            <asp:ImageButton ID="btnAdd" runat="server" CssClass="button" 
                                Text="Add VisaType" 
                                ValidationGroup="a"  TabIndex="6" onclick="btnAdd_Click" 
                                ImageUrl="~/Images/AddButton.PNG" />
         </td>
        
    </tr>
        
</table>
</div>
</asp:Content>

