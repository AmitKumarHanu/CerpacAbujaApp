<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmVisaApplicationSearchL2, App_Web_frmvisaapplicationsearchl2.aspx.fdf7a39c" title="Search Visa Detail L2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div  align="center">
        <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
    <tr>
        <td colspan="2"  class="PageNameHeadingCSS_2" align="center">Visa Application Search L2</td>
    </tr>     
    <tr>
        <td style="height: 18px" > 
        <asp:ScriptManager 
                ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
    </tr>        
      <tr> 
        <td align="center" colspan ="2" >
        <center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table cellpadding="5" cellspacing="2" border="0" width="90%">
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 5px;">
                        </td>
                    </tr>
                    <tr class="b11">
                       
                        <td  align="left" style="width : 161px; ">
                            Application Id :</td>
                        <td align="left"  colspan="3" style="width : 150px; ">
                            <asp:TextBox ID="txtapplicationid" runat="server" CssClass="textbox" 
                                onkeyup="OnlyNumber(this);" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 2px;">
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" style="width: 147px;">
                            Visa Type :
                        </td>
                        <td align="left" style="width: 178px;">
                            <asp:DropDownList ID="ddlVisaType" runat="server" Height="18px" Width="126px" 
                                CssClass="dropdown">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                           
                            
                        </td>
                        <td align="left" style="width: 161px;">
                            Country :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:DropDownList ID="ddlCountry" runat="server" Height="21px" Width="123px" 
                                CssClass="dropdown">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                           
                            
                        </td>
                    </tr>
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 2px;">
                        </td>
                    </tr>
                   
                    
                    <tr class="t11">
                        <td align="left" style="height: 2px;">
                            From Date :</td>
                        <td align="left" style="height: 2px;">
                            <input runat="server" id="TextFromDate" class="textbox" readonly="readonly"  />
                            <a id="FromDate" runat="server" href="javascript:NewCal('TextFromDate','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a></td>
                    
                        <td align="left" style="height: 2px;">
                            To Date :</td>
                        <td align="left"  style="height: 2px;">
                            <input runat="server" id="TextToDate" class="textbox" readonly="readonly"  />
                            <a id="Todate" runat="server" href="javascript:NewCal('TextToDate','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a></td>
                    </tr>
                    
                    <tr class="t11">
                        <td align="center" colspan="4" style="height: 2px; width: 147px;">
                            &nbsp;</td>
                       
                    </tr>
                    
                   
                    
                    <tr class="t11">
                        <td align="left" style="height: 18px; width: 147px;">
                            Status :</td>
                        <td align="left" style="width: 178px; height: 18px;">
                            <asp:RadioButtonList ID="rblstatus" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="A">Approved</asp:ListItem>
                                <asp:ListItem Value="R">Rejected</asp:ListItem>
                                <asp:ListItem Value="P">Pending</asp:ListItem>
                                <asp:ListItem Value="F">Forwarded</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="left" style="height: 18px;">
                            &nbsp;</td>
                        <td align="left" style="height: 18px;">
                            &nbsp;</td>
                    </tr>
                    
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 2px;">
                            &nbsp;</td>
                    </tr>
                    
                    <tr class="b11">
                        <td align="center" colspan="4">
                            &nbsp;<asp:Button ID="Search" runat="server" Text="Search" Width="120px" 
                                 CssClass="button" onclick="Search_Click"  /></td>
                    </tr>
                    
                     <tr class="t11">
                        <td colspan="4" align="center" style="height: 2px;">
                            &nbsp;</td>
                    </tr>
                    <%--insert here--%>
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 2px;">
                           <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" AllowPaging="True"  GridLines="Horizontal" 
               CellPadding="1"  CellSpacing="1" CssClass="GridBaseStyle" 
                DataKeyNames="ApplicationId" onpageindexchanging="GridView1_PageIndexChanging">
        
        <Columns>
            <asp:TemplateField HeaderText="Application Id" >
                    <ItemTemplate>
                        <asp:Label ID="lblApplicationId" runat="server" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Passport No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>
                        <asp:Label ID="lblPassportNumber" runat="server" Text='<%# Bind("PassportNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Applicant Name">
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="LblName" Text='<%# Bind("APPNAME") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOB">
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="LblName1" Text='<%# Bind("DOB") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MaritalStatus">
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="LblDesig" Text='<%# Bind("MaritalStatus") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Father Name">
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="LblReview1" Text='<%# Bind("FatherName") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Nationality">
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="LblName2" Text='<%# Bind("Nationality") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Visa Type">
                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="Lbl2Desig" Text='<%# Bind("VisaType") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Duration">
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemTemplate>                    
                        <asp:Label ID="Lbl2Review" Text='<%# Bind("Duration") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Duration Type" >
                    <ItemTemplate>
                        <asp:Label ID="lblStatusL1" runat="server" Text='<%# Bind("DurationType") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Visa For" >
                    <ItemTemplate>
                        <asp:Label ID="lblStatusL2" runat="server" Text='<%# Bind("VisaValidFor") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="L2 Status " >
                    <ItemTemplate>
                        <asp:Label ID="lblStatusL2" runat="server" 
                            Text='<%# Bind("Approver2Status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paper Visa " >
                    <ItemTemplate>
                        <asp:Label ID="lblStatusL2" runat="server" 
                            Text='<%# Bind("PaperVisaIssuedYN") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:TemplateField>
                
                              
        
               
            </Columns>
            <HeaderStyle CssClass="Grid_Header" />
            <RowStyle CssClass="Grid_Item" />
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />          
            <SelectedRowStyle CssClass="Grid_Selected" />
            <FooterStyle CssClass="Grid_Footer" />
</asp:GridView>
                           </td>
                    </tr>
                    
                    
                    
                </table>
    </ContentTemplate>
</asp:UpdatePanel>
</center>
            </td>
            </tr>
            </table>
    </div>
</asp:Content>


