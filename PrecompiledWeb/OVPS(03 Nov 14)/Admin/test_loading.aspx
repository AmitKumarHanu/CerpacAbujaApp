﻿<%@ page language="C#" autoeventwireup="true" inherits="Admin_test_loading, App_Web_test_loading.aspx.fdf7a39c" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     
            <style type="text/css">
      

.popup { 
      background-color: #DDD; 
      height: 300px; width: 500px; 
      border: 5px solid #666; 
      position: absolute; visibility: hidden; 
      font-family: Verdana, Geneva, sans-serif; 
      font-size: small; text-align: justify; 
      padding: 5px; overflow: auto; 
      z-index: 2; 
} 
.popup_bg { 
      position: absolute; 
      visibility: hidden; 
      height: 100%; width: 100%; 
      left: 0px; top: 0px; 
      filter: alpha(opacity=70); /* for IE */ 
      opacity: 0.7; /* CSS3 standard */ 
      background-color: #999; 
      z-index: 1; 
} 
       .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
      </style>  

</head>
<body>
   <%-- <form id="form1" runat="server">
<asp:ScriptManager ID="sc" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    function BeginRequestHandler(sender, args) {
        document.getElementById('<%= lblMessage.ClientID %>').innerText = "Processing...";
    document.getElementById('<%= btnSubmit.ClientID %>').innerText = "Processing";
        args.get_postBackElement().disabled = true;

        document.getElementById('<%= Button1.ClientID %>').disabled = true;

        document.getElementById('<%=loading.ClientID %>').style.display = '';

        document.getElementById('<%=Table1.ClientID %>').disabled = true;
}
</script>
<asp:UpdatePanel ID="updpnlSubmit" runat="server">
<ContentTemplate>

   
     <div id="div2" style="top:200px; left:500px; z-index=2">
         <table cellpadding="5" cellspacing="2" border="0" width="750px" id="loading" style="display:none; top:200px; left:500px;" runat="server" >
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Fetching data.Please Wait. . . . .</td></tr>
                        </table>

         </div>
   
    <div id="div1">
        

        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="Table1"  runat="server">
            <tr><td>
<asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />

<asp:Button ID="Button1" Text="Submit1" runat="server" />

<asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                </tr>
                </table>
        </div>
</ContentTemplate>
</asp:UpdatePanel>
</form>--%>
                
            
          <form id="form1" runat="server">
              <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
              <div style="top:300px;left:650px; position:absolute;" >

                   <asp:UpdateProgress ID="updProgress"
        AssociatedUpdatePanelID="UpdatePanel1"
        runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/loading.gif"/>
               Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>
              </div>
    <div >
        
       
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="btnInvoke" runat="server" Text="Click"
                    onclick="btnInvoke_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>        
    </div>
    </form>
          
</body>
</html>
