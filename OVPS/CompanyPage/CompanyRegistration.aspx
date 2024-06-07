<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompany.master" AutoEventWireup="true" CodeFile="CompanyRegistration.aspx.cs" Inherits="CompanyPage_CompanyRegistration" Title="Company Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div align="center">
                        
        
        
               
       <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
    <tr>
        <td colspan="2"  class="PageNameHeadingCSS_2" align="center"> Company Registration Form
        </td>
    </tr>
         
    <tr>
        <td rowspan="1" style="width: 10%; vertical-align: middle; text-align:center; background-repeat: no-repeat;"> <asp:Image runat="server" ID="ImgLogo" /></td>     
    </tr> 
     
    <tr> 
        <td align="center" colspan ="2" >
            <table  width ="70%">      
                         
                <tr class="t11">   
                                <td align="left" valign="top" style="width: 107px">
                                    Company&nbsp;Name:</td>
                                <td align="left" style="width: 84px;" ><asp:TextBox ID="txtcompanyname" runat="server" MaxLength="100" Width="200px" CssClass="textbox" ></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidatorCompanyName" runat="server" ErrorMessage="Please Enter Company Name" ControlToValidate="txtcompanyname" SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator></td>
                                
                 </tr>
                 <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
                <tr class="t11">
                    <td align="left" valign="top"  style="width:107px" >Address&nbsp;Line1:</td>
                    <td align="left" style="width: 237px;" >
                        <asp:TextBox ID="txtaddressline1" runat="server" MaxLength="100" Width="200px" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddressLine1" runat="server"
                            ControlToValidate="txtaddressline1" ErrorMessage="Please enter the company address in address line 1"
                            SetFocusOnError="True" ValidationGroup="Submit" Width="1px">*</asp:RequiredFieldValidator></td>
                </tr> 
                <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>                             
                <tr class="t11">
                    <td align="left" valign="top" style="width: 107px">Address&nbsp;Line2: </td>
                    <td align="left" style="width: 237px" >
                        <asp:TextBox ID="txtaddressline2" runat="server" MaxLength="100" Width="200px" CssClass="textbox"></asp:TextBox></td>
                </tr> 
                <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>                
                <tr class="t11">
                    <td align="left" valign="top" style="width: 107px">Address&nbsp;Line3:</td>
                    <td align="left" style="width: 237px" >
                        <asp:TextBox ID="txtaddressline3" runat="server" MaxLength="100" Width="200px" CssClass="textbox"></asp:TextBox></td>
                </tr> 
                <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr> 
                <tr class="t11">
                        <td align="left" valign="top"  style="width: 107px" >Zip Code: </td>
                        <td align="left" style="width: 237px;">
                           <asp:TextBox ID="txtzipcode" runat="server" MaxLength="6" Width="100px" 
                                CssClass="textbox"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtzipcode"
                                ErrorMessage="Enter Correct Format of Zip Code" SetFocusOnError="True" ValidationExpression="\d{6}"></asp:RegularExpressionValidator></td>
                   </tr>
                   <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>  
                <tr class="t11">
                        <td align="left" valign="top"  style="width: 107px" >First Phone No.</td>
                        <td align="left" style="width: 237px;" >
                        <asp:TextBox ID="txtphoneno1" runat="server" MaxLength="20" Width="100px" 
                                CssClass="textbox"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNo1" runat="server" ErrorMessage="Please Enter the Company Phone No. in First Phone No."
                                SetFocusOnError="True" ValidationGroup="Submit" ControlToValidate="txtphoneno1">*</asp:RequiredFieldValidator>
                        </td>
                   </tr>
                   <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
                <tr class="t11">
                        <td align="left" valign="top"  style="width: 107px" >Second Phone&nbsp;&nbsp;&nbsp; No.</td>
                        <td align="left" style="width: 250px" >
                        <asp:TextBox ID="txtphoneno2" runat="server" MaxLength="20" Width="100px" 
                                CssClass="textbox"></asp:TextBox>
                        </td>
                   </tr>
                   <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr>
                <tr class="t11">
                        <td align="left" valign="top"  style="width: 107px" >Third Phone No.</td>
                        <td align="left" style="width: 237px; height: 22px;" >
                        <asp:TextBox ID="txtphoneno3" runat="server" MaxLength="20" Width="100px" 
                                CssClass="textbox"></asp:TextBox>
                        </td>
                   </tr>
                   <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr> 
                <tr class="t11">
                        <td align="left" valign="top" style="width: 107px ">Fax No.</td>
                        <td align="left" style="width: 237px; height: 22px;" >
                        <asp:TextBox ID="txtfaxno" runat="server" MaxLength="20" Width="100px" 
                                CssClass="textbox"></asp:TextBox>
                        </td>
                   </tr>
                   <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr> 
                <tr class="t11">
		                <td align="left" valign="top" style="width: 107px"  >Web Site:&nbsp;</td>
		                <td align="left" style="width: 237px" >
		                <asp:TextBox ID="txtwebsite" runat="server" Width="200px" MaxLength="30" CssClass="textbox"></asp:TextBox>
                            &nbsp;
		                </td>
		            </tr> 
		            <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr> 
		        <tr class="t11">   
                        <td align="left" valign="top"  style="width: 107px" >Email Id:&nbsp; </td>
                        <td align="left" style="width: 237px">
                        <asp:TextBox ID="txtEmailId" runat="server" MaxLength="20" Width="200px" CssClass="textbox"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailId"
                                ErrorMessage="Enter Correct format of Email Address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
		            </tr>
		            <tr>
                 <td colspan="4" style="height: 5px" ></td>
                 </tr> 
		        <tr class="t11">
		            <td align="left" valign="top"  style="width: 107px;" >
                        Logo:&nbsp;
                    </td>

                    <td style="width: 237px;"><asp:FileUpload ID="logobrowse" runat="server" Width="270px" CssClass="textbox" /></td>
                    
		            </tr>
                <tr>
                 <td class="t11"colspan="2" style="height: 30px; color: maroon; " valign="top" align="left"><span style="color: red">*</span>
                 
                     Dimension of logo is always within (200 * 60)</td>
                  
                  
                  
                  
                 </tr>
                 
                <tr>
            
        <td colspan="2" style="text-align: center">
        <asp:Button ID="BtnReset" runat="server" Text="Reset"   OnClick="ButtonReset_Click" CssClass="button" />
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" ValidationGroup="Submit" CssClass="button" />
            <asp:Button ID="BtnUpdate" runat="server" OnClick="ButtonUpdate_Click" CssClass="button" Text="Update" /></td>
        
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

