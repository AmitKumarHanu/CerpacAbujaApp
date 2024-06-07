<%@ page language="C#" autoeventwireup="true" inherits="Details, App_Web_details.aspx.fdf7a39c" enablesessionstate="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <h1 align=center >Applicant Details</h1>
    <table border=0 cellpadding=0 cellspacing=0 align=center>
    <tr>
    <td>
    <asp:Label ID=lbl1 runat=server Text="Frist Name"></asp:Label>
    </td>
    <td width=15></td>
    <td>
     <asp:Label ID=Lblfirstname runat=server></asp:Label>
    </td>
    <td width=200></td><td><asp:Label ID=lblfndb runat=server></asp:Label></td><td width=12></td><td>
        <asp:Image ID=imgtickfn ImageUrl="~/Images/tick_64.png" runat=server 
            Height="17px" Visible=false /><asp:Image ID=imgcrossfn ImageUrl="~/Images/Delete.png" runat=server 
            Height="17px" Visible=false /></td>
    </tr>
    <tr><td height=15></td></tr>
    <tr>
    <td>
    <asp:Label ID=Label1 runat=server Text="Last Name"></asp:Label>
    </td>
    <td width=15></td>
    <td>
     <asp:Label ID=lbllastname runat=server></asp:Label>
    </td>
    <td width=200></td><td><asp:Label ID=lbllndb runat=server></asp:Label></td><td width=12></td><td>
        <asp:Image ID=imgtickfnln ImageUrl="~/Images/tick_64.png" Visible=false runat=server 
            Height="17px" /><asp:Image ID=imgcrossln ImageUrl="~/Images/Delete.png" Visible=false runat=server 
            Height="17px" /></td>
    </tr>
    <tr><td height=15></td></tr>
    <tr>
    <td>
    <asp:Label ID=Label2 runat=server Text="Date of Birth"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lbldatebirth runat=server></asp:Label>
    </td>
    <td width=200></td><td><asp:Label ID=lbldobdb runat=server></asp:Label></td><td width=12></td><td>
        <asp:Image ID=imgtickdob ImageUrl="~/Images/tick_64.png" Visible=false runat=server 
            Height="17px" /><asp:Image ID=imgcrossdob ImageUrl="~/Images/Delete.png" Visible=false runat=server 
            Height="17px" /></td>
    </tr>
    <tr><td height=15></td></tr>
    <tr>
    <td>
    <asp:Label ID=Label3 runat=server Text="Passport Number"></asp:Label>
    </td>
    <td width=15></td>
    <td>
    <asp:Label ID=lblpassport runat=server></asp:Label>
    </td>
    <td width=200></td><td><asp:Label ID=lblpassdb runat=server></asp:Label></td><td width=12></td><td>
        <asp:Image ID=imgtickpass ImageUrl="~/Images/tick_64.png" runat=server Visible=false 
            Height="17px" /><asp:Image ID=imgcrosspass ImageUrl="~/Images/Delete.png" Visible=false runat=server 
            Height="17px" /></td>
    </tr>
    <tr><td height=15></td></tr>
     <tr><td colspan=7 align=center><asp:Button ID=btnverify runat=server Text="Verify" 
             onclick="btnverify_Click" /></td></tr>  
    </table>
    </div>
    
    </form>
</body>
</html>
