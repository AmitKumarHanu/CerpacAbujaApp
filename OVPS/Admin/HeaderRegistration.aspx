<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_HeaderRegistration" CodeFile="~/Admin/HeaderRegistration.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
                        
        
        
               
       <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
   
 <tr>
                    <td colspan="3" style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><fontclass="b12"><spanstyle="fontsize:16px">&nbsp;Company Registration Form &nbsp; </span></font>
                        </div>
                    </td>
                </tr>
         
    <tr>
        <td rowspan="1" style="width: 10%; vertical-align: middle; text-align:center; background-repeat: no-repeat;"> <asp:Image runat="server" ID="ImgLogo" /></td>     
    </tr> 
     
    <tr> 
        <td align="center" colspan ="2" style="height: 249px" >
            <table  width ="70%">      
                         
                <tr class="t11">   
                                <td align="left" valign="top" style="width: 107px">
                                    Company&nbsp;Name:</td>
                                <td align="left" style="width: 84px;" ><asp:TextBox ID="txtcompanyname" runat="server" MaxLength="100" Width="200px" CssClass="textbox2" ></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidatorCompanyName" runat="server" ErrorMessage="Please Enter Company Name" ControlToValidate="txtcompanyname" SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator></td>
                                
                 </tr>
                 <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
                <tr class="t11">
                    <td align="left" valign="top"  style="width:107px" >Company Id&nbsp;</td>
                    <td align="left" style="width: 237px;" >
                        <asp:TextBox ID="txtaddressline1" runat="server" MaxLength="100" Width="200px" CssClass="textbox2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddressLine1" runat="server"
                            ControlToValidate="txtaddressline1" ErrorMessage="Please enter the company address in address line 1"
                            SetFocusOnError="True" ValidationGroup="Submit" Width="1px">*</asp:RequiredFieldValidator></td>
                </tr> 
                <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>                             
                <tr class="t11">
                    <td align="left" valign="top" style="width: 107px">Company Description&nbsp; </td>
                    <td align="left" style="width: 237px" >
                        <asp:TextBox ID="txtaddressline2" runat="server" MaxLength="100" Width="200px" CssClass="textbox2"></asp:TextBox></td>
                </tr> 
                <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>                
                 
               <tr>
            
        <td colspan="2" style="text-align: center">
        <asp:Button ID="BtnReset" runat="server" Text="Reset"   OnClick="ButtonReset_Click" class="adminbutton" />
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" ValidationGroup="Submit" class="adminbutton" />
            <asp:Button ID="BtnUpdate" runat="server" OnClick="ButtonUpdate_Click" class="adminbutton" Text="Update" /></td>
        
    </tr> 
                 
                
        </table>
       
            &nbsp;
                        <asp:ValidationSummary ID="ValidationSummarySubmit" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Submit" />
    </td>
        
      </tr>
     
     
       
    </table>
    
 </div>
</asp:Content>

