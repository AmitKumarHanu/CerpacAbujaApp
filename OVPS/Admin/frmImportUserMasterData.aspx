<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmImportUserMasterData.aspx.cs" Inherits="Admin_frmImportUserMasterData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="" style="width:95%;">
     <table  id="combox" style="width:100%;">
            <tr>
                
                <td style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">Import Login User Details &nbsp; </span>
                        </font>
                    </div>
                </td>


            </tr>
            <tr>
            <td style="height: 5px" align="center">
                    <div id ="DivDecrypt" class="11" runat="server" style="text-align: center; width: 100%; ">
                        <table style="width: 100%; " >
                        <tr>
                        <td  valign="top" style=  "text-align:left; width: 80%;" >
                            <asp:FileUpload ID="FileUpload1"  runat="server" />
                            <hr />
                        </td>
                        </tr>
                        <tr>
                        <td  valign="top" style=  "text-align:center; width: 20%;" >
                            <asp:Button ID = "btnDecrypt" style="text-align: center;"  class="adminbutton" Text="Decrypt File" runat="server" OnClick = "DecryptFile" /> 
                        </td> 
                        </tr>
                        </table>
                    </div>
                </td>
            </tr>
         <tr>
         <td height="15"></td></tr>
            <tr id="tr_msg" runat="server"><td align="center" style="visibility:hidden">
                <%--<asp:Label ID="lblmsg" runat="server" CssClass="information-box abc" Text = "Please Enter CERPAC No./Secured Sold Form No. of the applicant" Font-Size="Small" Width="620px"></asp:Label>--%>

            <asp:Label ID="lblmsg" runat="server"  CssClass="information-box abc" Text = "Please Select Secured Sold Form No. of the applicant" Font-Size="Small" ></asp:Label>
            </td>
            </tr>
            <tr>
                <td align="center">
                      

                      <table class="t11" style="width: 100%;" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>

    <div id="divgrd" class="t11" runat="server" align="center" style="overflow: scroll; height:auto; width:750px;  " >
<asp:GridView ID="grdUserList" runat="server" PagerStyle-CssClass="pgr" DataKeyNames="LoginId" 
                Width="100%" AutoGenerateColumns="False" 
        CellSpacing="1" CssClass="GridBaseStyle">
            <Columns>
                <asp:TemplateField HeaderText="Login ID"  >
                    <ItemStyle Width="20%" HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:Label ID="lblLoginId" runat="server" Text='<%# Bind("LoginId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name">
                    <ItemStyle Width="25%" HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="User Type" Visible="true" >
                    <ItemStyle Width="15%" HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:Label ID="lblUserType" runat="server" Text='<%# Bind("UserType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Valid From" Visible="true">
                 <ItemStyle Width="15%" HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:Label ID="lblvalidfrom" runat="server" Text='<%# Bind("UserActiveFromDate") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Valid Till" Visible="true">
                 <ItemStyle Width="15%" HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:Label ID="lblvalidTill" runat="server" Text='<%# Bind("UserActiveToDate") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                </Columns>
            <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

            <RowStyle CssClass="Grid_Item"/>
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
            <SelectedRowStyle CssClass="Grid_Selected" />
            <FooterStyle CssClass="Grid_Footer" />
        </asp:GridView>  

    </div>
    
    <div id="DivImport" class="t11" runat="server" align="center">
    <table class="t11" style="width: 80%;" >
                    <tr id="tr45" runat="server" style="display:block;" align="right" >
<td valign="top" align="right" style="width: 100%; text-align: right;">
<asp:Button ID="btnEncrypt" runat="server"  Text="Import" class="adminbutton" 
        ValidationGroup="a" onclick="btnEncrypt_Click"  />
<asp:Button ID="btn_cancel" runat="server"  Text="Cancel" class="adminbutton" 
        ValidationGroup="a" onclick="btn_cancel_Click" />

</td></tr>
         </table>
    </div>
</td>
    
</tr>
                    
                    </table>
                    
                    </td>
                    </tr>
         </table>
         </div>
</asp:Content>

