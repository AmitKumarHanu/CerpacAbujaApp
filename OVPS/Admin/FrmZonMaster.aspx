<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="FrmZonMaster" CodeFile="~/Admin/FrmZoneMaster.aspx.cs" title="Zon Master" %>
<%@ OutputCache NoStore="true" Location="None"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script> 

   <div align="center" class="bcolour">      
      <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>  
    
    <asp:UpdatePanel ID="FrmZonMasterUpdatePanel" runat="server" >
       <ContentTemplate>  
            
     <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%" id="combox">
   
    <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><fontclass="b12"><span style="fontsize:16px; color:White">&nbsp;Zone City Master Form  &nbsp; </span></font>
                        </div>
                    </td>
                </tr>   
    <tr>
        <td style="height: 18px"  align="center"> 
            &nbsp;&nbsp;
            <asp:Label ID="Labelerrormessage" runat="server" ForeColor="Red" Text="Label" 
                Visible="False"></asp:Label>
        </td>
    </tr>        
      <tr> 
        <td align="center" >
        <center>
            <%--<fieldset style="width: 90%; height: auto;">--%>
                <%--<legend>
                    <div class="PageNameHeadingCSSHeader" >
                        <img src="../Images/DocumentHeader.gif" width="20px" height="20px" style="background-position: center;
                            vertical-align: middle" alt="" />
                        <asp:Label ID="LabelTitle" runat="server" Visible="true"></asp:Label>
                    </div>
                </legend>--%>
                <table cellpadding="5" cellspacing="2" border="0" width="680px">
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 10px;">
                        </td>
                    </tr>
                    <tr class="t11">
                        <td colspan="4" align="center">
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 308px;">
                            Country Name 
                        </td>
                        <td align="left" style="width: 237px;">
                          
                           <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="dropdown3" 
                       ValidationGroup="a" ToolTip="Nigeria">
                       </asp:DropDownList>
                       <span style="color:  red; text-align: center; font-size: medium;">*</span>     
                            <asp:RequiredFieldValidator ID="rfvCountryname" runat="server" ControlToValidate="ddlCountryName"
                                Display="None" ErrorMessage="Select Country Name" ValidationGroup="a" 
                                SetFocusOnError="True" InitialValue="0" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" style="width: 150px;">
                            Zone Name
                        </td>
                        <td align="left" style="width: 200px;">
                            <asp:DropDownList ID="ddlZoneName" runat="server" AutoPostBack="True" CssClass="dropdown3" 
                                onselectedindexchanged="ddlZoneName_SelectedIndexChanged" >
                                 <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblZoneName" runat="server" Text="Label" BackColor="Silver" 
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Width="70px"></asp:Label>
                            <span style="color: red;text-align: center; font-size: medium;">*</span>
                            <asp:RequiredFieldValidator ID="rfvZonCode" runat="server" ControlToValidate="txtZonCode"
                                Display="None" ErrorMessage="Enter Zon Code" ValidationGroup="a" 
                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                     <tr class="b11">
                        <td colspan="4" align="left" style="height: 5px">
                            </td>
                    </tr>
                    <tr class="b11">
                    <td style="width:308px;"> Zone Code
                    </td><td style="width: 237px"> 
                            <asp:TextBox ID="txtZonCode" runat="server" Width="138px" Enabled="False" CssClass="textbox2"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                        <td> &nbsp;</td>
                        <td> 
                            &nbsp;</td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                    <tr><td colspan="4">
                        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"                  
                 AllowPaging="True" 
                CssClass="GridBaseStyle" CellPadding="1" CellSpacing="1" 
                 DataKeyNames="CityCode" Width="649px" >
            <Columns>
              <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_select" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
              <asp:TemplateField HeaderText="City Code" Visible="true" >
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
             
              <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblCityCode" runat="server" Text='<%# Bind("CityCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="City Name">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Label ID="lblCityName" runat="server" Text='<%# Bind("CityName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
               
            </Columns>
            <HeaderStyle CssClass="Grid_Header" />
            <RowStyle CssClass="Grid_Item"/>
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
            <SelectedRowStyle CssClass="Grid_Selected" />
            <FooterStyle CssClass="Grid_Footer" />
            
        </asp:GridView>
                        </td></tr>
                        <tr><td colspan="4">
                            <asp:GridView ID="GridView2"  runat="server" AutoGenerateColumns="False"                  
                 AllowPaging="True" 
                CssClass="GridBaseStyle" CellPadding="1" CellSpacing="1" 
                 DataKeyNames="CityCode" Width="649px" >
            <Columns>
              <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
              <asp:TemplateField HeaderText="City Code" Visible="true" >
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
             
              <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblCityCode" runat="server" Text='<%# Bind("CityCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="City Name">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Label ID="lblCityName" runat="server" Text='<%# Bind("CityName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
               
            </Columns>
            <HeaderStyle CssClass="Grid_Header" />
            <RowStyle CssClass="Grid_Item"/>
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
            <SelectedRowStyle CssClass="Grid_Selected" />
            <FooterStyle CssClass="Grid_Footer" />
            
        </asp:GridView>
                            </td></tr>
                    <tr class="b11">
                        
                                <td align="center" colspan ="4">
                            <asp:Button ID="btnSave" runat="server" class="adminbutton" Text="Save" 
                                ValidationGroup="a"  TabIndex="6" onclick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" runat="server" class="adminbutton" Text="Update" 
                                ValidationGroup="a"  TabIndex="9" onclick="btnUpdate_Click" />
                                <asp:Button ID="btnCancel" runat="server" class="adminbutton" Text="Cancel" 
                                 TabIndex="10" onclick="btnCancel_Click" /></td>
                              
                    </tr>
                    <tr class="b11">
                        <td colspan="4" align="left" style="height: 10px;">
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="center" colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" 
                                ForeColor="#9EC550" />
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left"  colspan="4" style="height:20px;">
                            &nbsp;</td>
                    </tr>
                    <tr class="b11">
                        <td colspan="4" style="height: 10px">
                            &nbsp;</td>
                    </tr>
                </table>
            <%--</fieldset>--%>
       
 </center>
            </td>
            </tr>
            </table>
      </ContentTemplate>
    </asp:UpdatePanel>  
    </div>
</asp:Content>

