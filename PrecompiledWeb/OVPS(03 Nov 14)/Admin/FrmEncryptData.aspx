<%@ page language="C#" autoeventwireup="true" inherits="EncryptedImagePrint.FrmEncryptData, App_Web_frmencryptdata.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            height: 288px;
            width: 231px;
        }
        .style3
        {
            height: 288px;
            width: 227px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
<asp:Label ID="Label1" runat="server" Text="Enter Record ID: "></asp:Label>

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table id="tbl1" style="width: 58%;" >
            <tr>
                <td id="cell1" class="style2">
                    <img id="img1" alt="" src="" runat="server"/></td>
                <td id="cell2" class="style2">
                    <img id="img2" alt="" src="" runat="server"/></td>
                <td id="cell3" class="style2">
                    <img id="img3" alt="" src="" runat="server"/><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Logo/Barcode/Barcode/AO170173BCCode.bmp" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
