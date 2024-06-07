<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true"
    CodeFile="ApplicationProcess.aspx.cs" Inherits="Admin_ApplicationProcess"
    Title="Applicant Status Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 95%">
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px">&nbsp;Application Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table class="t11" style="width: 100%;">
                        <tr>
                            <td align="center" style="height: 16px; width: 150px;">
                                Application ID &nbsp;&nbsp;
                                 <asp:TextBox ID="TextAppId" runat="server" ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>&nbsp;
                                <span style="color: red; text-align: center; font-size: medium;">*</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                     <asp:Button ID="Go" runat="server" Width="43px" Text="Go" class="adminbutton" ValidationGroup="a" onclick="Go_Click"  />
                            </td>                          
                        </tr>
                        <tr class="b11">
                            <td align="center" colspan="4">
                                <asp:ValidationSummary ID="vsapplicantid" runat="server" ValidationGroup="a" ShowMessageBox="True"
                                    ShowSummary="False" ForeColor="" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">
                                <asp:GridView ID="GridViewApplicantStatusList" runat="server" Width="99%" AutoGenerateColumns="False"
                                    OnRowEditing="GridViewApplicantStatusList_RowEditing" onrowdatabound="GridViewApplicantStatusList_RowDatabound" 
                                    AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="ApplicationId"
                                    OnPageIndexChanging="GridViewApplicantStatusList_PageIndexChanging">
                                    <Columns>  
                                        <asp:BoundField HeaderText="StepID" DataField="currStep" Visible ="false" />                                 
                                        <asp:TemplateField HeaderText="Application ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplicationNo" runat="server" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Applicant Name">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Applicant Email">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplicantEmail" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemStyle HorizontalAlign="Center"  />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("AppliedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField HeaderText="Update" ShowEditButton="True" ButtonType="Image" EditImageUrl="~/Images/Edit-icon.png">
                                            <ControlStyle CssClass="button" />
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:CommandField>
                                       
                                    </Columns>
                                    <HeaderStyle CssClass="Grid_Header" />
                                    <RowStyle CssClass="Grid_Item" />
                                    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                                    <SelectedRowStyle CssClass="Grid_Selected" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>           
        </table>
    </div>
</asp:Content>
