<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmVisaStickerPrintingList" CodeFile="~/Admin/FrmVisaStickerPrintingList.aspx.cs" title="Visa Sticker List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <table cellpadding="2" cellspacing="10" style="width: 95%">
            <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><font class="b12"><span style="fontsize:16px; color:white;">&nbsp;Visa Sticker List &nbsp; </span></font>
                        </div>
                    </td>
                </tr>
            <tr>
                <td align="center">
                    <table class="t11" style="width: 100%;">
                        <tr>
                            <td align="left" style="height: 5px;" colspan="3">
                            </td>
                            </tr>
                            
                            <tr class="b13">
                                    <td  align="center"style="height: 16px;  ">Application ID&nbsp;                                   
                                        <asp:TextBox ID="TextAppId" runat="server" ValidationGroup="a" AutoComplete="Off"  Width="150px" 
                                            CssClass="textbox2" Height="20px"></asp:TextBox>
                                         <span style="color:red; text-align: center; font-size: medium;">*</span>
                        <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                             Display="None"  ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True" 
                                            ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        <asp:Button ID="Go" runat="server" Width="100px" class="adminbutton" Text="Search" 
                                            ValidationGroup="a" onclick="Go_Click"  />
                                 </td>
                                </tr>
                                 <tr>
                            <td align="left" style="height: 15px;" colspan="3">
                            </td>
                            </tr>
       
      <tr class="b11">
                                 <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vsapplicantid" runat="server" ValidationGroup="a" ShowMessageBox="True"
								ShowSummary="False" ForeColor="#9EC550" /> </td>
                                 </tr>
                            <tr>
                                <td align="center" style="height: 16px;" colspan="3">
                                    <asp:GridView ID="GridViewVisaStickerList" PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False"
                                        GridLines="Horizontal" CellSpacing="1" CssClass="GridBaseStyle" AllowPaging="True"
                                        DataKeyNames="ApplicationId" OnPageIndexChanging="GridViewVisaStickerList_PageIndexChanging"
                                        OnRowEditing="GridViewVisaStickerList_RowEditing">
                                        <HeaderStyle CssClass="Grid_Header" />
                                        <RowStyle CssClass="Grid_Item" />
                                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                                        <SelectedRowStyle CssClass="Grid_Selected" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Application Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApplicationId" runat="server" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            </asp:TemplateField>                                           
                                            <asp:BoundField HeaderText="Passport No" DataField="PassportNumber">
                                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Applicant Name" DataField="ApplicantName">
                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField HeaderText="Immigranation Verified" DataField="ImmigranationVerifedYN">
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>                                           
                                           
                                            <asp:BoundField HeaderText="Receipt No" DataField="PaymentReceiptNo">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Visa Valid For" DataField="CountryName">
                                                <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>                                           
                                            <asp:CommandField HeaderText="Select" ShowEditButton="True" ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG"
                                                InsertText="Select" SelectText="Select">
                                                <ControlStyle CssClass="button" />
                                                  <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:CommandField>
                                        </Columns>
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Top" />
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
                                </td>
                            </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
