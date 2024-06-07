<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmVisaApplicationSearchL1, App_Web_frmvisaapplicationsearchl1.aspx.fdf7a39c" title="Search Detail L1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">

    function dtval(d, e) {
        var pK = e ? e.which : window.event.keyCode;
        if (pK == 8) { d.value = substr(0, d.value.length - 1); return; }
        var dt = d.value;
        var da = dt.split('-');
        for (var a = 0; a < da.length; a++) { if (da[a] != +da[a]) da[a] = da[a].substr(0, da[a].length - 1); }
        if (da[0] > 31) { da[1] = da[0].substr(da[0].length - 1, 1); da[0] = '0' + da[0].substr(0, da[0].length - 1); }
        if (da[1] > 12) { da[2] = da[1].substr(da[1].length - 1, 1); da[1] = '0' + da[1].substr(0, da[1].length - 1); }
        if (da[2] > 9999) da[1] = da[2].substr(0, da[2].length - 1);
        dt = da.join('-');
        if (dt.length == 2 || dt.length == 5) dt += '-';
        d.value = dt;
    }
</script>

<div  align="center">
        <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
    <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align: center"><font class="b12"><span style="font-size: 16px">&nbsp;Visa Application Search L1 &nbsp; </span></font>
                        </div>
                    </td>
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
            <%--<fieldset style="width: 90%; height: auto;">
                <legend>
                    <div class="PageNameHeadingCSSHeader">
                        <img src="../Images/DocumentHeader.gif" width="20px" height="20px" style="background-position: center;
                            vertical-align: middle" alt="" />
                        <asp:Label ID="LabelTitle" Text="Passport Entry Form" runat="server" Visible="true"></asp:Label>
                    </div>
                </legend>--%>
                <asp:UpdatePanel ID="upL1" runat="server">
                 <ContentTemplate>
                <table cellpadding="5" cellspacing="2" border="0" width="90%">
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 5px;">
                        </td>
                    </tr>
                    <tr class="b11">
                       <%-- <td align="left" style="width : 147px; ">
                            Search By ApplicationId&nbsp; :</td>
                        <td align="left" style="width : 178px; ">
                            <asp:CheckBox ID="CheckReg" runat="server" />
                                                    </td>--%>
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
                            <%--<span style="color: Red; text-align: center; font-size: medium;">*</span>--%>
                            
                        </td>
                        <td align="left" style="width: 161px;">
                            Country :
                        </td>
                        <td align="left" style="width: 190px;">
                            <asp:DropDownList ID="ddlCountry" runat="server" Height="21px" Width="123px" 
                                CssClass="dropdown">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                           <%-- <span style="color: Red; text-align: center; font-size: medium;">*</span>--%>
                            
                        </td>
                    </tr>
                    <tr class="t11">
                        <td colspan="4" align="center" style="height: 2px;">
                        </td>
                    </tr>
                    <%--<tr class="b11">
                        <td align="left" style="width: 147px; height: 16px;">
                            Dates :</td>
                        <td align="left" style="width: 178px; height: 16px;" id="Alldates" 
                            title="All Dates">
                            </td>
                        <td align="left" style="width: 161px; height: 16px;">
                            </td>
                        <td align="left" style="height: 16px">
                            </td>
                    </tr>--%>
                   <%-- <tr class="t11">
                        <td align="center" style="height: 2px; width: 147px;" rowspan="4">
                        </td>
                        <td align="left" style="height: 2px;" rowspan="4">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="122px">
                                <asp:ListItem>All Dates</asp:ListItem>
                                <asp:ListItem>Last 7 Days</asp:ListItem>
                                <asp:ListItem>Last 30 Days</asp:ListItem>
                                <asp:ListItem>Date Range</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="center" style="height: 2px;" colspan="2">
                        </td>
                    </tr>--%>
                    
                   <%-- <tr class="t11">
                        <td align="center" style="height: 2px;" colspan="2">
                        </td>
                    </tr>--%>
                    
                    <tr class="t11">
                        <td align="left" style="height: 2px;">
                            From Date :</td>
                        <td align="left" style="height: 2px;">
                            <input runat="server" id="TextFromDate" class="textbox" readonly="readonly"  />
                            <a id="FromDate" runat="server" href="javascript:NewCal('TextFromDate','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a></td>
                    <%--</tr>
                    
                    <tr class="t11">--%>
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
                    
                    <%--<tr class="t11">
                        <td align="left" style="height: 18px; width: 147px;">
                            Status :</td>
                        <td align="left" style="width: 178px; height: 18px;">
                            </td>
                        <td colspan="2" align="center" style="height: 18px;">
                            </td>
                    </tr>--%>
                    
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
                                 class="adminbutton" onclick="Search_Click" /></td>
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
                
                <asp:TemplateField HeaderText="L1 Status " >
                    <ItemTemplate>
                        <asp:Label ID="lblStatusL2" runat="server" 
                            Text='<%# Bind("Approver1Status") %>'></asp:Label>
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
                    
                    <%--insert here--%>
                    
                </table></ContentTemplate></asp:UpdatePanel>
            <%--</fieldset>--%>
        
 </center>
            </td>
            </tr>
            </table>
    </div>

</asp:Content>

