<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankCheck.aspx.cs" Inherits="Admin_BankCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Patua+One|Open+Sans);

* { 
  -moz-box-sizing: border-box; 
  -webkit-box-sizing: border-box; 
	box-sizing: border-box; 
}

body {
  background:#353a40;
}

table {
  border-collapse: separate;
  background:#fff;
  border-radius:5px;
  margin:50px auto;
  box-shadow:0px 0px 5px rgba(0,0,0,0.3);
}

thead {
  border-radius :5px;
}

 thead td {
            font-family: 'Patua One', cursive;
            font-size: 16px;
            font-weight: 400;
            color: #fff;
            text-shadow: 1px 1px 0px rgba(0,0,0,0.5);
            text-align: left;
            padding: 20px;
            background-image: linear-gradient(#646f7f, #4a5564);
            border-top: 1px solid #858d99;
        }
 
tbody tr td 
    {
  font-family: 'Open Sans', sans-serif;
  font-weight:400;
  color:#5f6062;
  font-size:13px;
  padding:20px 20px 20px 20px;
  border-bottom:1px solid #e0e0e0;
  
}

tbody tr:nth-child(2n) {
  background:#f0f3f5;
}

tbody tr:last-child td {
  border-bottom:none;
 
}

tbody:hover > tr td {
 opacity:0.5;
  
  /* uncomment for blur effect */
  /* color:transparent;
  @include text-shadow(0px 0px 2px rgba(0,0,0,0.8));*/
}

tbody:hover > tr:hover td {
  text-shadow:none;
  color:#2d2d2d;
  opacity:1.0;
}
    </style>
</head>
<body>
    <center>
    <h1 style="color:white;">Bank Details</h1>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnlforms" runat="server">
       
    </asp:Panel>
    </div>
    </form>
        </center>
</body>
</html>
