<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_resultpage.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<style type="text/css">
    .abc
    {
    display:none;
    }
    .bcd
    {
    display:block;
    }
        </style>--%>
</head>
<body> 
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <img id="img1" runat="server" alt="" src=""/>
        <br />
        <asp:Button ID="OCRBtn" runat="server" onclick="OCRBtn_Click" Text="OCR" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="DecryptBtn" runat="server" 
            Text="Decrypt" onclick="DecryptBtn_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnshow" runat="server" 
            Text="Show Details" Visible="false" onclick="btnshow_Click"/>
          <br />
          <asp:Label ID="lbldoc" runat="server" Text="document" EnableViewState="true"></asp:Label>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <div id="div1" runat="server"></div>

            </ContentTemplate>
        </asp:UpdatePanel>
        
       

    </form>
</body>
</html>
