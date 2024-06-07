<%@ page language="C#" autoeventwireup="true" inherits="test1, App_Web_test1.aspx.cdcab7d2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="bill_print" style="display:block;">

    <table style="font-family: Verdana; left: 20px; position: relative; top: 38px;";>
      
    <tr>
    <td  rowspan="6" valign="middle" align="left">
        <img id="ImgPhoto2" alt="Img" src="Saurabh.jpg" runat="server" style="height: 95px; width: 88px; left: -6px; position: relative; top: -48px;" /><br />
       </td>
    <td class="style11" valign="top">
        
     <asp:Label ID="Label1" runat="server" Text="Passport No." Font-Size="X-Small"></asp:Label>
        <br />
        <asp:Label ID="txt_pass_no" runat="server" Text="J284455" Font-Size="X-Small"></asp:Label>
    
    </td>
    
    </tr>

    
<tr>
    <td class="style11" valign="top" >
       
     <asp:Label ID="Label5" runat="server" Text="Name"  Font-Size="X-Small"></asp:Label>
    <br />
        <asp:Label ID="txt_name_1" runat="server" Text="Saurabh Bansal" Font-Size="X-Small"></asp:Label>
    </td>
    <%--<td class="style12" valign="top">
     
    
    </td>--%>
    </tr>

<tr style="display:none;">
    <td class="style11" valign="top">
       
     <asp:Label ID="Label7" runat="server" Text="DOB" ></asp:Label>
    <br />
         <asp:Label ID="txt_dob_2" runat="server" Text="25 Dec 82" ></asp:Label>
    </td>
    
    </tr>

<tr>
    <td class="style11">
     
     <asp:Label ID="Label9" runat="server" Text="Designation" valign="top"  Font-Size="X-Small"></asp:Label>
    <br />
        <asp:Label ID="txt_desig_3" runat="server" Text="Software Engineer" Font-Size="X-Small"></asp:Label>
    </td>
  
    </tr>

<tr>
    <td class="style11" valign="top">
      
     <asp:Label ID="Label11" runat="server" Text="Nationality" Font-Size="X-Small"></asp:Label>
    <br />
        <asp:Label ID="txt_nationality_4" runat="server" Text="Indian" Font-Size="X-Small"></asp:Label>
    </td>
   
    </tr>    

<%--<tr>
    <td class="style2" colspan="2" valign="top">
      
     <asp:Label ID="Label14" runat="server" Text="Signature" ></asp:Label>
    
    </td>
    </tr>--%>
       

    <tr>
    <td class="style11">
        <br />
        <br /><br />
        </td>
  
    
    </tr>
    <tr>
    <td colspan="2" align="left">
                                      
                                  
                                  </td>
                                  
                                 
                                  </tr>
                                  
                                  <tr>
                                 
                                  <td style="text-align: left; font-size:small;" colspan="2" class="auto-style1" valign="top">
                                Authorized Signatory     
                                      <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>


                                  <tr>
                                 
                                  <td style="text-align: left" colspan="2" class="auto-style1">
                                
                                      <br />
                                
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                       
                                   <td  valign="top" style="font-size:X-Small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cerpac No.</td>
                                  <td style="text-align: left" align="left" class="style12" valign="top" style="font-size:small;">
&nbsp;&nbsp;<asp:Label ID="txt_cer_no_5" runat="server" Text="AO455877" Font-Size="X-Small"></asp:Label>
                                  
                                  </td>
                                 
                                  </tr>
                                  
                                  
                                   <tr>
                                       
                                   <td valign="top" style="font-size:X-Small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date Of Issue</td>
                                  <td style="text-align: left" align="left" class="style12" style="font-size:small;">
                                 &nbsp;&nbsp;<asp:Label ID="txt_date_of_issue_6" runat="server" Text="9 Jul 13" Font-Size="X-Small"></asp:Label>
                                  </td>
                                 
                                  </tr>
                                  
                                  

                                   <tr>
                                       
                                   <td  valign="top" style="font-size:X-Small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Place Of Issue</td>
                                  <td style="text-align: left;font-size:small;" align="left" class="style12" valign="top" >
                                  &nbsp;&nbsp;<asp:Label ID="txt_place_of_issue_7" runat="server" Text="Abuja" Font-Size="X-Small"></asp:Label>
                                  </td>
                                 
                                  </tr>
                                  
                                      
                                  

                                  <tr>
                                      
                                  <td valign="top" style="font-size:X-Small;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Date Of Expiry</td>
                                  <td style="text-align: left;font-size:small;" align="left" class="style12" >
                                   &nbsp;&nbsp;<asp:Label ID="txt_date_of_exp_8" runat="server" Text="1 Nov 13" Font-Size="X-Small"></asp:Label>
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>


    </table>
 </div>
    </form>
</body>
</html>
