﻿<%@ page language="C#" autoeventwireup="true" inherits="Admin_StickerPrintDetail, App_Web_stickerprintdetail.aspx.fdf7a39c" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function printwin()
        {
            window.print();
            window.close();
        }
    </script>
</head>
<body onload="return printwin();">
    <form id="form1" runat="server">
    <div>
    <table class="t11" style="width: 100%;display:block;" runat="server" id="sticker" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
    
     <asp:Image ID="ImgPhoto" style="position:absolute; top: 105px; width: 120px; height: 133px; left: 150px;" runat="server" ImageUrl="Saurabh.jpg" />
     <asp:Image ID="imgbarcode" style="position:absolute; width: 240px; height: 80px;top: 350px;left: 30px; " runat="server" />
    <div style="background-image: url('../Images/image004.jpg'); height:578px; width:413px;" id="div_grd" runat="server">
        <!--sticker goes here -->
        <span style="position:absolute; left: 80px; top: 102px;">
            
       <asp:Label ID="issued"  runat="server" Font-Bold="true" font-size="X-Small" ForeColor="Black"></asp:Label>
  <asp:Label ID="at" style="position:absolute; top: 25px;left: -1px;" font-size="X-Small" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
           
             <asp:Label ID="expires" style="position:absolute; top: 45px; left: -1px;" font-size="X-Small" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
             <asp:Label ID="audit" style="position:absolute; top:65px; left:-1px;" font-size="X-Small" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="state" style="position:absolute; top:85px; left:-1px;" font-size="X-Small" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="passportno" font-size="X-Small" style="position:absolute; top:105px; left:-1px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="dob" font-size="X-Small" style="position:absolute; top:125px; left:-1px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="name" font-size="X-Small" style="position:absolute; top:145px; left:-1px;" runat="server" Width="200px" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="address" font-size="X-Small" style="position:absolute; top:165px; left:-1px;" runat="server" Width="500px" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="address1" font-size="X-Small" style="position:absolute; top:185px; left:-1px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:Label ID="address2" font-size="X-Small" style="position:absolute; top:205px; left:-1px;" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
        </span>
        <!--till here -->
       
</div>
   </td></tr>
      </table>
    </div>
    </form>
</body>
</html>
