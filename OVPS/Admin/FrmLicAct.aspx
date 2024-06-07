<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmLicAct.aspx.cs" Inherits="Admin_FrmLicAct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 40%"  id="combox" >
            <tr>
                <td colspan="2" class="style3">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        License Activation File &nbsp;
                    </div>
                </td>
            </tr>
 
            <tr>
                <td colspan="2" class="style3" style="text-align:left;">
                    Import Activation File
                </td>
            </tr>
            <tr>
                <td align="center" class="style4">
                      <table class="t11" style="width: 100%;" >                         

                         <tr>
                        <td  valign="top" style=  "text-align:left; width: 80%;" >
                            <asp:FileUpload ID="FileUpload1"  runat="server" />
                            <hr />
                        </td>
                        </tr>
                        <tr>
                        <td  valign="top" style=  "text-align:center; width: 20%;" >
                            <asp:Button ID = "btnUpload" style="text-align: center;"  class="adminbutton" Text="Upload File" runat="server" OnClick="btnUpload_Click"  /> 
                        </td> 
                        </tr>
                          <tr>
                              <td align="center" style="border: 2px dashed #000; " class="b55 b-lt "><asp:Label ID="lblmessage" runat="server"></asp:Label></td>

                          </tr>
                    
 </table>  
                </td>
                
            </tr>
        </table>
    
        
    </div>
    </div>
    </form>
</body>
</html>
