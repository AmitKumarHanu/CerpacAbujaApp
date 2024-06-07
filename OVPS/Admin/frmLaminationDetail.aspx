<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmLaminationDetail.aspx.cs" Inherits="Admin_frmLaminationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script type="text/javascript">
     var specialKeys = new Array();
     specialKeys.push(8); //Backspace
     $(function () {
         $(".numeric").bind("keypress", function (e) {
             var keyCode = e.which ? e.which : e.keyCode
             var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
             $(".error").css("display", ret ? "none" : "inline");
             return ret;
         });
         $(".numeric").bind("paste", function (e) {
             return false;
         });
         $(".numeric").bind("drop", function (e) {
             return false;
         });
     });
    </script>

<div id="Div1" align="center" runat="server">
    <table cellpadding="4" cellspacing="4" style="width:100%; " border="0" id="combox">
    <tr>   
    <td align="center" >
        &nbsp;</td> 
    <td colspan="6"  align="center" >
    <div class="PageNameHeadingCSS" style="text-align: center"><font class="b12"><span style="font-size:16px; color:Black;">Lamination Role Stock </span></font>
    </div>
    </td> 
   
    </tr>     
   
   

 </table>
 </div>
 <div>
 <table  style="width:100%; ">
 <tr>
   <td colspan="6"></td>
  
   </tr>
   
   <tr>
   <td></td>
   <td colspan="4" align="center">
       <asp:RadioButton ID="rd_front" Text="Front Lamination" runat="server" GroupName="g" Checked="true"  />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:RadioButton ID="rd_back" Text="Back Lamination" runat="server" GroupName="g"/>
       </td>
       <td></td>
   </tr>
   <tr>
   <td colspan="6"></td>
  
   </tr>

    <tr>

   <td></td>
   <td><asp:Label ID="lbl_location" Text="Select Location" runat="server" 
           Font-Size="12px"></asp:Label></td>
   <td valign="middle">
       
      
       
       <asp:DropDownList ID="ddl_location" runat="server">
           <asp:ListItem Value="192.168.1.26">Abuja</asp:ListItem>
            <asp:ListItem Value="192.168.2.26">Lagos</asp:ListItem>
             <asp:ListItem Value="192.168.3.26">Bauchi</asp:ListItem>
              <asp:ListItem Value="192.168.4.26">Kaduna</asp:ListItem>
               <asp:ListItem Value="192.168.5.26">Makaudi</asp:ListItem>
                <asp:ListItem Value="192.168.6.26">Owerri</asp:ListItem>
                 <asp:ListItem Value="192.168.7.26">Ibadan</asp:ListItem>
                  <asp:ListItem Value="192.168.8.26">Benin</asp:ListItem>
       </asp:DropDownList>
       </td>
   <td></td>
   <td></td>
   <td></td>
   </tr>

   <tr>
   <td colspan="6"></td>
  
   </tr>
   <tr>

   <td></td>
   <td><asp:Label ID="Label1" Text="Lamination Role Prefix" runat="server" 
           Font-Size="12px"></asp:Label></td>
   <td valign="middle">
       <asp:TextBox ID="txt_prefix" runat="server" Width="53px" CssClass="textbox2" AutoPostBack="true"
           ontextchanged="txt_prefix_TextChanged"></asp:TextBox>
      
       

       </td>
   <td></td>
   <td></td>
   <td></td>
   </tr>
   <tr>
   <td colspan="6"></td>
  
   </tr>

   <tr>

   <td></td>
   <td><asp:Label ID="lbl_front_lam" Text="Lamination No. (Start)" runat="server" 
           Font-Size="12px"></asp:Label></td>
   <td valign="middle">
       
     
       <asp:TextBox ID="txt_lam_s" runat="server"  CssClass="numeric"></asp:TextBox>

       </td>
   <td></td>
   <td></td>
   <td></td>
   </tr>

    <tr>
   <td colspan="6"></td>
   
   </tr>
   <tr>

   <td></td>
   <td><asp:Label ID="lbl_back" Text="Lamination No. (End)" runat="server" 
           Font-Size="12px"></asp:Label></td>
   <td valign="middle">
       
       
       <asp:TextBox ID="txt_lam_e" runat="server" CssClass="textbox2"></asp:TextBox>

       </td>
   <td></td>
   <td></td>
   <td></td>
   </tr>

    <tr>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   </tr>

   <tr>
   <td></td>
   
   <td colspan="4" align="center"> <asp:Button ID="btn_submit" runat="server" CssClass="adminbutton"
           Text="Submit" onclick="btn_submit_Click" /></td>
   <td></td>
   </tr>
     
 </table>
 
 </div>
</asp:Content>

