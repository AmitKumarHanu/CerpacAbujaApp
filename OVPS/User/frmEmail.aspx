<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeFile="frmEmail.aspx.cs" Inherits="User_frmEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <title>EmailDocument</title>
    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd;">
<tr><td colspan="1" class="PageNameHeadingCSS_2" align="center" style="height: 16px" > Email Document</td></tr>
<tr>
<td valign="top" >
<table cellpadding="5" cellspacing="5" style="border:1px solid #dddddd">
           
             <tr class="t11">
            <td  >
               
                <div style="float:left; padding-left:41px; font-size:small;">Email To:
                    </div>
                <div style="float:left; padding-left:24px; font-size:small;">
                <asp:TextBox ID="txtEmailTo" runat="server"></asp:TextBox></div>
                <div style="float:right; padding-top:0px; "><asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailTo" runat="server" ControlToValidate="txtEmailTo"
                    ErrorMessage=" Enter correct format of email address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailTo"
                    Display="Dynamic" ErrorMessage="Please Enter Email Address" SetFocusOnError="True"
                    ValidationGroup="Mail">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr class="t11">
            <td  >
               
                <div style="float:left; padding-left:48px; font-size:small;">Subject:
                    </div>
                <div style="float:left; padding-left:24px; font-size:small;">
                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></div>
                <div style="float:right; padding-top:0px; "></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                    Display="Dynamic" ErrorMessage="Please Enter Subject" SetFocusOnError="True"
                    ValidationGroup="Mail">*</asp:RequiredFieldValidator></td>
            </tr>
              <tr class="t11">
            <td  >
               
                <div style="float:left; padding-left:12px; font-size:small;">
                    Attached Doc:
                    </div>
                <div style="float:left; padding-left:24px; font-size:small;">
                <asp:Image ID="Imgattach" runat="server" ImageUrl="~/Images/attach.gif" Height="17px" />
                </div>
                <div style="float:left; padding-left:5px; font-size:small;">
                <asp:Label ID="lblDocName" runat="server" Font-Names="Arial" ForeColor="#000040"></asp:Label></div>
                <div style="float:right; padding-top:0px; "></div>
                </td>
            </tr>
            <tr class="t11">
            <td  >
                <div style="float:left; padding-left:5px;font-size:small">Message Body:</div>
                <div style="float:left; padding-left:24px; font-size:small;">
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="119px" Width="235px" ></asp:TextBox> </div></td>
            </tr>
           
            <tr>
            <td align="center" >&nbsp;<asp:Label ID="lblMailMsg" runat="server" ></asp:Label>
                </td></tr>
            
            <tr>
            
                <td align="center" ><asp:Button Text="Mail" CssClass="button" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click1" ValidationGroup="Mail" Width="56px"/>&nbsp;
                    </td>
            </tr>
</table>
    <asp:ValidationSummary ID="ValidationSummaryMail"  runat="server" ValidationGroup="Mail" CssClass="t11" ShowMessageBox="True" ShowSummary="False" />
</td>
<td>

</td>
</tr>
</table>

    </form>
</body>
</html>
