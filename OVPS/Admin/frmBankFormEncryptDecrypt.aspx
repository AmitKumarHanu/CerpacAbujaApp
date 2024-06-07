<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmBankFormEncryptDecrypt.aspx.cs" Inherits="Admin_frmBankFormEncryptDecrypt" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

        
        .confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
	align:center;
    font-size: 18px;
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
}

        .style3
        {
            height: 5px;
        }

    </style>
   

     <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 60%"  id="combox" >
            <tr>
                <td colspan="3" class="style3">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Bank Form File Encrypt & Decrypt &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                      <table class="t11" style="width: 100%;" >                          

                        <tr id="tr_ser" runat="server" >
                            <td align="left" class="style2">
                            <strong> Form No.</strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtFormNo" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            <td class="style1">&nbsp;</td>
                        </tr>
                    </table>
 <table class="t11" style="width: 100%;" >
 <tr>
<td  colspan="3" valign="top" align="center" style="width: 100%; text-align: left;">
    
<asp:FileUpload ID="FileUpload1"  runat="server" />
<hr />
<asp:Button ID = "btnEncrypt" class="adminbutton" Text="Encrypt File" runat="server" OnClick = "EncryptFile" />
<asp:Button ID = "btnDecrypt"  class="adminbutton" Text="Decrypt File" runat="server" OnClick = "DecryptFile" />
 
</td>    
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" />
    </td>
<td><asp:Button ID = "btnImage1" class="adminbutton" Text="Image to Base64" 
        runat="server" onclick="btnImage1_Click"  /></td>
<td><asp:Button ID = "BtnImage2" class="adminbutton" Text="Base64 to Image" 
        runat="server" onclick="BtnImage2_Click"   /></td>
<td><asp:Button ID = "btnUpdateImage" class="adminbutton" Text="UpdateImage" 
        runat="server" onclick="btnUpdateImage_Click"  /></td>
        <td><asp:Button ID = "btnSaveImage" class="adminbutton" Text="Save Image on Server" 
        runat="server" onclick="btnSaveImage_Click"   /></td>
        <td><asp:Button ID = "btnSaveTemp" class="adminbutton" Text="Save File Temp" 
        runat="server" onclick="btnSaveTemp_Click"    /></td>
</tr>
                    
</table>                 

                       
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

