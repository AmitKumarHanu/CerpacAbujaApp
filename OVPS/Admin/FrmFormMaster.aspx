<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompany.master" AutoEventWireup="true" CodeFile="FrmFormMaster.aspx.cs" Inherits="Admin_FrmFormMaster" Title="From Master Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div  align="center" class="bcolour">
<table cellpadding="2" cellspacing="10" 
        style="border:1px solid #dddddd; width:67%; height: 215px;">

<tr><td></td></tr>
    <tr>
        <td colspan="2"  class="PageNameHeadingCSS" align="center">From Master Form
        </td>
    </tr>     
        
    <!--  UI Inerface Start Here -->
    <tr>
    <td align="center" colspan ="2">
    <table style="font-style:normal" width ="80%">
    
    <tr class="t11">   
     <td align="left" valign="top"  style="width: 237px;">
         Form Name :</td>  
      <td align="left" style="width: 237px;" >
     <asp:TextBox ID="TxtFormName" runat="server" CssClass="textbox"  TabIndex="3" ToolTip="Enter Form Name"></asp:TextBox>
       <span style="color:  #9EC550;text-align: center; font-size: medium;">*</span> 
       </td>                           
    </tr>
    <tr class="t11">
        <td colspan="2" align="center" style="height: 2px;">
         </td>
      </tr>
    <tr class="t11">
    <td align="left" valign="top"  style="width: 237px; height: 22px;" >
        Form URL :</td>
        <td align="left" style="width: 237px; height: 22px;" >
        <asp:TextBox ID="TxtDirectoryPath" runat="server" CssClass="textbox"  TabIndex="4" 
                ToolTip="Enter  Directory Path" Width="301px"></asp:TextBox>
            
       <span style="color:  #9EC550; text-align: center; font-size: medium;">*</span></td>
    </tr>
    <tr class="t11">
        <td colspan="2" align="center" style="height: 2px;">
         </td>
      </tr>
    <tr class="t11">
        
     
    <td align="left" valign="top"  style="width: 237px;" >
        Status:</td>
    <td style="text-align: left;">
        <asp:CheckBox ID="CheckBoxStatus" runat="server" Text="Active" Checked="True" />
    </td>
    </tr>
    </table>
    </td>
    </tr>
    <!--  UI Inerface end  Here -->
    
  
    <!--  Button -->
    <tr><td id="Td1" align="center"  runat="server">
    <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" ValidationGroup="Submit" CssClass="button" />
            <asp:Button ID="BtnUpdate" runat="server" OnClick="ButtonUpdate_Click" CssClass="button" Text="Update" />
             <asp:Button ID="BtnList" runat="server" OnClick="ButtonList_Click" CssClass="button" Text="Go To Form List" /></td>
    </tr>
    
    <!--  Buttom End-->
    
    
     
    
</table>
</div>
</asp:Content>

