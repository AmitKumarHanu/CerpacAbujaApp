<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageCompany.master" autoeventwireup="true" inherits="FrmVisaTypeMaster, App_Web_frmvisatypemaster.aspx.fdf7a39c" title="CERPAC Type Master Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../JS/validation.js" type="text/javascript"></script>
   <style type="text/css">
   .grdv_txt
   {
       border:1px solid #1d1d1c;
       padding:2px;
  background:#ebebeb;
width:150px;
border-radius:5px;
       }
   </style>
   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {

        $(".slidingDiv").hide();
        $(".show_hide").show();

        $('.show_hide').click(function () {
            $(".slidingDiv").slideToggle();
        });

    });
 
</script>
    <script type="text/javascript">
        function openLastVisit(pnlid, hidnid) {
            var objpnl = document.getElementById(pnlid);
            objpnl.style.display = '';
            document.getElementById(hidnid).value = 'y';

        }
        function closeLastVisit(pnlid, hidnid) {
            var objpnl = document.getElementById(pnlid);
            objpnl.style.display = 'none';
            document.getElementById(hidnid).value = 'n';

        }
    </script>
   

<div align="center">
        
   <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%> 
    <asp:UpdatePanel ID="FrmVisaTypeMasterUpdatePanel" runat="server" >
       <ContentTemplate>  
            
     <table cellpadding="2" cellspacing="10" 
               style="border:1px solid #dddddd; width:95%; height: 623px;" id="combox">
    
   
 <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><fontclass="b12">
                            <span style="fontsize:16px; color:White">&nbsp;CERPAC Type Master Form &nbsp; </span></font>
                        </div>
                    </td>
                </tr>   
    <tr>
        <td style="height: 18px" > 
        </td>
    </tr>        
      <tr> 
        <td align="center" colspan ="2" style="height: 589px" >
            <table style="font-style:normal; height: 592px;" width ="55%"> 
            <tr align="center" valign="top">
                                    <td style="height: 153px">
                                    <fieldset>
                                    
                                     <table style="font-style:normal" width ="100%">   
                 <tr>
                 <td colspan="2" style="height: 5px" ></td>
                 </tr>
                                         
                <tr class="b11">
                    <td align="left" valign="top" style="width: 141px">CERPAC Type Code:</td>
                    <td align="left" style="width: 237px" >
                       <%--<asp:TextBox ID="txtVisaTypecode" runat="server"  CssClass="textbox" 
                            MaxLength="4" Width="111px" onkeyup="OnlyNumber(this);" onblur="checkzero(this);" ></asp:TextBox>--%>
                             <asp:TextBox ID="txtVisaTypecode" runat="server" class="textbox2" ValidationGroup="a" AutoComplete="Off"
                                MaxLength="4" onkeyup="OnlyNumber(this);" onblur="checkzero(this);" TabIndex="1" 
                                ToolTip="Enter CERPACType code"></asp:TextBox>
                             <span style="color:  red; text-align: center; font-size: medium;">*</span></td>
                            <asp:RequiredFieldValidator ID="rfvVisaTypecode" runat="server" ControlToValidate="txtVisaTypecode"
                                Display="None" ErrorMessage="Enter CERPACType Code" ValidationGroup="a" 
                            SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        </td>
                </tr>
                 <tr>
                 <td colspan="2" style="height: 5px" ></td>
                 </tr>
                 <tr class="b11">
                    <td align="left" valign="top" style="width: 141px">CERPAC Type Name:</td>
                    <td align="left" style="width: 237px" >
                    
                            <asp:TextBox ID="Txtsvisaname"  onkeyup="AlfaNum3(this);" runat="server" class="textbox2" ValidationGroup="a" AutoComplete="Off"
                                MaxLength="40"  onblur="checkonlySpace(this);" TabIndex="2" ToolTip="Enter CERPAC Type Name "></asp:TextBox>
                               <%-- onkeyup="AlfaNum3(this);" Comment by dilip 11 January 2012--%>
                             <span style="color:  red; text-align: center; font-size: medium;">*</span></td>
                            <asp:RequiredFieldValidator ID="Rfvsvisaname" runat="server" ControlToValidate="Txtsvisaname"
                                Display="None" ErrorMessage="Enter CERPAC Type Name" 
                                ValidationGroup="a" SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>                       
                        
                    </td>                        
                </tr>  
                
                <tr>
                 <td colspan="2" style="height: 5px" ></td>
                 </tr>                
                <tr class="b11">
                    <td align="left" valign="top" style="width: 141px">CERPAC Type Description:</td>
                    <td align="left" style="width: 237px" >
                    
                            <asp:TextBox ID="txtVisaTypeName" runat="server" class="textbox2" ValidationGroup="a" AutoComplete="Off"
                                MaxLength="40"  onblur="checkonlySpace(this);" TabIndex="3" ToolTip="Enter CERPAC Type Name "></asp:TextBox>
                               <%-- onkeyup="AlfaNum3(this);" Comment by dilip 11 January 2012--%>
                             <span style="color:  red; text-align: center; font-size: medium;">*</span></td>
                            <asp:RequiredFieldValidator ID="rfvVisaTypeName" runat="server" ControlToValidate="txtVisaTypeName"
                                Display="None" ErrorMessage="Enter CERPAC Type Name" ValidationGroup="a" 
                                SetFocusOnError="True" ForeColor="#9EC550"></asp:RequiredFieldValidator>
                        
                        
                    </td>
                        
                </tr> 
                <tr>
                 <td colspan="2" style="height: 5px" ></td>
                 </tr>                
               
               <tr>
                 <td style="height: 5px; width: 141px;" >
                     </td>
                 <td style="height: 5px" >
                     </td>
                 </tr>
                 <tr class="b11" style="display:none">
        
     
    <td align="left" valign="top"  style="width: 141px;" >
        Status:</td>
    <td style="text-align: left;">
        <asp:CheckBox ID="chkactive" runat="server" Checked="True" />
    </td>
     </tr>
     <tr>
     <td colspan="2" height="15">
     </td>
     </tr>
                 
               
    <tr>
     <td colspan="2" height="20">
     </td>
     </tr>
                 
                                     </table> 
                                </fieldset>
                                </td>
    </tr>
     <tr>
            
        <td align="center" colspan="4" height="50">
        
            <asp:GridView ID="GridViewDocs" runat="server" AutoGenerateColumns="False"
                AllowPaging="True"
                CssClass="GridBaseStyle" CellPadding="1" CellSpacing="1"
                DataKeyNames="DocCode" Width="649px">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document Code" Visible="true">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />

                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblDocCode" runat="server" Text='<%# Bind("DocCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document Name">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />

                        <ItemTemplate>
                            <asp:Label ID="lblDocName" runat="server" Text='<%# Bind("DocName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document Description">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />

                        <ItemTemplate>
                            <asp:Label ID="lblDocDesc" runat="server" Text='<%# Bind("DocDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mandatory">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_mand" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                </Columns>
                <HeaderStyle CssClass="Grid_Header" />
                <RowStyle CssClass="Grid_Item" />
                <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                <SelectedRowStyle CssClass="Grid_Selected" />
                <FooterStyle CssClass="Grid_Footer" />

            </asp:GridView>
        </td></tr>
         <tr>
         <td align="center" colspan="4">
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
                                Visible="False" />
                            <asp:Button ID="btnSave" runat="server" class="adminbutton" Text="Save" Width="76px"
                                ValidationGroup="a"  TabIndex="6" onclick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" runat="server" class="adminbutton" Text="Update" Width="76px"
                                ValidationGroup="a"  TabIndex="9" onclick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" class="adminbutton" Text="Cancel" Width="76px"
                                 TabIndex="10" onclick="btnCancel_Click" />
                            <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" 
                                CssClass="t11" /></td>
        
    </tr>
        </table>
    </td>
               </tr>
       
    </table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    
 </div>
</asp:Content>

