<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmSetAlert.aspx.cs" Inherits="User_FrmSetAlert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Set Alert</title>
    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div align="center">
     <asp:Label ID="LabelMessage" runat="server" text=""></asp:Label></div>
    <fieldset style="width:90%;height:150px">
   <legend class="h14">Set Alert</legend>
    <table style="font-style:normal; width: 100%;"> 
       <tr class="t11">   
        <td align="left" valign="top" style="width:50px;">
            Alert&nbsp;Type</td>
        <td style="width:1px ">:</td>
        
        <td align="left" style="width:30%">
         <asp:TextBox ID="txtAlertType" runat="server" CssClass="textbox-medium"></asp:TextBox>
         <asp:RequiredFieldValidator ID="reqAT" runat=server ControlToValidate="txtAlertType" ErrorMessage="*" ValidationGroup="VAlert">*</asp:RequiredFieldValidator>
        </td>
        <td align="left" valign="top" style="width: 50px"> Action&nbsp;Date</td><td style="width:1px">:</td>
        <td align="left" style="width: 40%" > <input type="text" runat="server" id="TextActionDate" style="width:80px" Class="textbox-medium" /><a id="ActionDate" runat="server" href="javascript:NewCal('TextActionDate','DDMMMYYYY')">
                                            <img src="../Images/cal.jpg" border="0" alt="Pick a date" />
                                        </a>
                                        <asp:RequiredFieldValidator ID="reqVAT" runat="server" ControlToValidate="TextActionDate" ErrorMessage="*" ValidationGroup="VAlert">*</asp:RequiredFieldValidator>
                                        </td>
    </tr>
   <tr class="t11">  
    <td></td>       
    <td colspan="2" style="text-align: left;">
        <asp:CheckBox ID="CheckBoxEmailAlert" runat="server" Text="Enable Email Alert" Checked="True" />
    </td>
    <td align="left" valign="top" style="width: 80px">
                                    Notifications&nbsp;Days</td><td>:</td>
                                    <td align="left" style="width: 40%" > <asp:DropDownList
             ID="ddlNDays" runat="server" CssClass="textbox-medium">
             <asp:ListItem>7</asp:ListItem>
             <asp:ListItem>15</asp:ListItem>
             <asp:ListItem>21</asp:ListItem>
             <asp:ListItem>30</asp:ListItem>
             <asp:ListItem>45</asp:ListItem>
             <asp:ListItem>60</asp:ListItem>
         </asp:DropDownList></td>
    </tr>
   
    <tr class="t11">   
                                <td align="left" valign="top"  style="width:20%">
                                    Description</td><td>:</td>
                                <td colspan="4" align="left" ><asp:TextBox ID="TextBoxAlertDesc" runat="server" MaxLength="200" CssClass="textbox" TextMode="MultiLine" Height="50px" width="80%"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RqDesc" runat="server" ControlToValidate="TextBoxAlertDesc" ErrorMessage="*" ValidationGroup="VAlert">*</asp:RequiredFieldValidator>
                                </td>
                                
                 </tr>
      <tr>
      <td colspan="6" align="center"><asp:Button runat="server" Text="submit" ID="BtnAlertSet" CssClass="button" OnClick="BtnAlertSet_Click" ValidationGroup="VAlert" /></td>
      </tr>
    </table>
   </fieldset>
    
    </div>
    </form>
</body>
</html>
