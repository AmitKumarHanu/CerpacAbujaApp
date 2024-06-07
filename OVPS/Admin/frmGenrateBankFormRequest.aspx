<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmGenrateBankFormRequest.aspx.cs" Inherits="Admin_frmGenrateBankFormRequest" EnableEventValidation="false" %>

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

       

        .style1
        {
            width: 269px;
        }

       

    </style>
   

     <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 80%"  id="combox" >
            <tr>
                <td colspan="2" class="style3">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Create Bank Form Request File &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr>
<td  valign="top" align="center" style="width: 100%; text-align: right;">


</td> 
  
</tr>
            <tr>
                <td colspan="2" class="style3" style="text-align:left;">
                    <strong> New Case.</strong>
                </td>
            </tr>
            <tr>
                <td align="center" class="style4">
                      <table class="t11" style="width: 100%;" >                          

                        <tr id="tr_ser" runat="server" >
                        <td align="left" class="style1" ><strong> Form No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong></td>
                            <td align="left" >
                                <asp:TextBox ID="txtFormNo" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="250px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            
                        </tr>
                    
 </table>  
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <table cellpadding="2" cellspacing="10" style="width: 80%"  id="combox" >           
            
            <tr>
                <td   style="text-align:left;">
                    <strong> Renewal Case.</strong>
                </td>
            </tr>
            <tr>
                <td align="center">
                <table class="t11" style="width: 100%;" >  
                        <tr id="tr1" runat="server" >
                        <td align="left" ><strong> Form No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong></td>
                            <td align="left" >
                                <asp:TextBox ID="txtFormNo1" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="250px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            
                        </tr>
                        <tr id="tr2" align="left" runat="server" >
                            <td ><strong>Cerpac No.</strong><strong style="font-size:12px; color:green;">(seperated by comma(,))</strong></td>
                            <td align="left" >
                                <asp:TextBox ID="txtCerpacno" runat="server" AutoComplete="Off" 
                                    ValidationGroup="a" Width="250px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            
                        </tr>
                    </table>
                <table class="t11" style="width: 100%;" >
 <tr>
<td  valign="top" align="center" style="width: 100%; text-align: right;">
    
<hr />
 <asp:Button ID = "btnEncrypt" class="adminbutton" Text="Create File" runat="server"  OnClick = "EncryptFile" />

</td> 
<td>
 
    &nbsp;</td>   
</tr>
                    
</table>  
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

