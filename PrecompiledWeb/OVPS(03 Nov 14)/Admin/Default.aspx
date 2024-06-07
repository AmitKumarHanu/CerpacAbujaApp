<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="User_Default, App_Web_default.aspx.fdf7a39c" title="User Master Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table class="bcolour" cellpadding="5" cellspacing="0" style="width:85%; height: 100%;" >
    <tr>
        <td class="b12" style="width: 80%; height: 100%;">
            <img src=stickynote.png  style="position:absolute; z-index:-1111; top:180px;left:560px;"/>
            <div style="position:absolute; z-index:-1111; top:290px;left:620px; font-family:'Comic Sans MS';font-size:large; width: 270px; height: 370px;" runat="server" id="divmsg">

           
            <asp:Label ID="lbllastlogin" runat="server" ></asp:Label>
                 </div>
        </td>
   </tr>



<tr><td style="width: 736px; height: 478px; background-image:url('../images/contbg_app1.png')" valign="top" align="center">

<tr><td style="width: 736px; height: 100%;" valign="top" align="center">


<%--<asp:Image ImageAlign="Middle" runat="server" ID="WelcomeLogo" ImageUrl="~/Images/Welcome.jpg" Width="598px" Height="539px"/>--%>


</td></tr>
</td></tr>
</table>
</asp:Content>

