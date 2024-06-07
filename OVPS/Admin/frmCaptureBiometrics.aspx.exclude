<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_frmCaptureBiometrics, App_Web_frmcapturebiometrics.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script language="JavaScript" type="text/javascript">  
       
         MyObject = new ActiveXObject( "WScript.Shell" )  
         function RunExe()   
         {
             MyObject.Run("file:///C:/Program Files/CENT SI/BioVisa/BioVisaClient.exe");
         }
         function openbiovisa() {
             var objShell = new ActiveXObject("shell.application");
             objShell.ShellExecute("cmd.exe", "cd C: C:\\cd C:\\Program Files\\CENT SI\\BioVisa\\BioVisaClient.exe", "C:\\WINDOWS\\system32", "open", 1);
         }

         function openfile() {
             window.location.href = "C:\\Program Files\\CENT SI\\BioVisa\\BioVisaClient.exe";
             
         } 

    </script> 
      
    

 <div align="center" class="bcolour" id="auth_contain" runat="server">
        <table cellpadding="2" cellspacing="10" style="width: 95%" >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Applications For BioMetric Capture &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            
            <tr><td class="auto-style1"></td></tr>
            <tr>
                <td align="center">
                    <table class="t11" style="width: 100%;" >
                       <tr>
                            <td align="left" style="height: 16px;" colspan="3">
                             <asp:GridView ID="GridViewBioMetric" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="cerpac_no"
                        OnPageIndexChanging="GridViewBioMetric_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="Cerpac_No" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>
                            <asp:TemplateField HeaderText="Cerpac No" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FRN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassportno" runat="server" Text='<%# Bind("FORMNO") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                            </td>
                        </tr>
                       
                    </table>
                     &nbsp;&nbsp;&nbsp;
                    </td>
            </tr>

             <tr class="b11">
                <td align="center" colspan="4">
                    <asp:Button ID="btnCardGen" runat="server" class="adminbutton" 
                        Text="Capture Biometrics"   onclick="btnCardGen_Click"/>

                   </td>
            </tr>
        </table>
    </div>





</asp:Content>

