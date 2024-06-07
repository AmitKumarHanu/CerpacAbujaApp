<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmViewApprovedVisaCommandCenter, App_Web_frmviewapprovedvisacommandcenter.aspx.fdf7a39c" title="Applicant Status Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div  align="center" class="bcolour">

<table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
     <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><font class="b12"><span style="font-size: 16px">&nbsp; Approved Visas  &nbsp; </span></font>
                        </div>
                    </td>
                </tr>
    
    
     <tr>
    
    
     <td align="center">
                            <table style="width:100%;">
                                <tr>
                                    <td  align="left" style="height: 16px; width:200px;">
                                        &nbsp;</td>
                                    <td  align="left" style="height: 16px; width:250px;">
                                        <asp:TextBox ID="TextAppId" runat="server" ValidationGroup="a"  Width="150px" 
                                            CssClass="textbox" Height="20px" Visible="False"></asp:TextBox>
                                         &nbsp;<asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                             Display="None"  ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True" 
                                            ForeColor="#9EC550"></asp:RequiredFieldValidator> 
                                    </td>
                                    <td  align="left" style="height: 16px;">
                                        <asp:Button ID="Go" runat="server" Width="43px" Text="Go" ValidationGroup="a" 
                                            onclick="Go_Click" Visible="False"  />
                                    </td>
                                </tr>
                                 <tr class="b11">
                                 <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vsapplicantid" runat="server" ValidationGroup="a" ShowMessageBox="True"
								ShowSummary="False" ForeColor="" /> </td>
                                 </tr> 
                                
                                <tr>
                                    <td  align="left" style="height: 16px;" colspan="3">
                                        &nbsp;</td>
                                    </tr>
                                <tr>
                                    <td  align="left" style="height: 16px;" colspan="3">
   <asp:GridView ID="GridViewApplicantStatusList"  runat="server"  Width="99%" AutoGenerateColumns="False" 
                                            OnRowEditing="GridViewApplicantStatusList_RowEditing"  
                                            OnRowCommand="GridViewApplicantStatusList_RowCommand" 
                                             AllowPaging="True" 
                                               PagerStyle-CssClass="pgr"
                                            CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="ApplicationId"
                                            OnPageIndexChanging="GridViewApplicantStatusList_PageIndexChanging" >
            <Columns>
               <%-- <asp:TemplateField HeaderText="Select">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Application ID" >
                    <ItemTemplate>
                        <asp:Label ID="lblApplicationNo" runat="server" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Applicant Name">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("ApplicantName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             
                <asp:TemplateField HeaderText="Applicant Email">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblApplicantEmail" runat="server" Text='<%# Bind("ApplicantEmail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Status">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Remark">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Date">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                         
                <asp:CommandField  HeaderText=""   ShowEditButton="false" 
                    ButtonType="Image" EditImageUrl="~/Images/EditButton.jpg" >
                    <ControlStyle CssClass="button" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                </asp:CommandField>
                <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" 
                    ButtonType="Image" DeleteImageUrl="~/Images/DeleteButton.jpg" >
                    <ControlStyle CssClass="button" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                </asp:CommandField>--%>
               
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
                                    <td  align="left" style="height: 16px;" colspan="3">
                                        &nbsp;</td>
                                    </tr>
                                </table>
                        </td>
    
    </tr>
    
    
     <td align="center">
                            <%--<asp:Button ID="btnApprove" runat="server" CssClass="button" Text="View" Width="76px"
                                ValidationGroup="a"  TabIndex="6" onclick="btnApprove_Click" />--%>
                        </td>
    
    </table>

</div>
</asp:Content>

