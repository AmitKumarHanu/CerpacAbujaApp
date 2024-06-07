<%@ page language="C#" autoeventwireup="true" inherits="Admin_FrmVisaApplicationSubmit, App_Web_frmvisaapplicationsubmit.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visa Application Info</title>
    


      <script type="text/javascript" language="javascript">
       
        function Printwin()
        {           
           document.getElementById("BtnPrint").style.display = 'none';
           document.getElementById("BtnCancle").style.display = 'none';
           window.print();
           return false;
         }  
     
     function Closewin()
     {
     
     window.close();
     return false;
     }
     
      
     
    </script>
    
    <style type="text/css">
body 
    
    .b12
{
	font-size:12px;
	font-family:Arial;
	font-weight:bold;
}
.t12
{
	font-size:12px;
	font-family:Arial;	
}
.b15
{
	font-size:15px;
	font-family:Arial;
	font-weight:bold;
}
.PageNameHeadingCSS_1
{
	background-color:#C1D3FB;	
	color:#384467; 	
	border-style:none;
	font-size:14px;
	font-family:Arial;
	font-weight:bold;
	text-decoration:none;
}
.PageNameHeadingCSS_2
{
	background-color:#C1D3FB;	
	color:#384467; 	
	border-style:none;
	font-size:16px;
	font-family:Arial;
	font-weight:bold;
	text-decoration:none;
	
}
.button
 {	
	color:#63659C;
	font-weight:bold;
	cursor:hand;
}	


</style>
    
</head>
<%--<body onload="window.print()">--%>
<body>
    <form id="form1" runat="server">
    
     <div id="container" align="center">
	<div id="logo"><img src="../Images/nijeria_hdng.png" /></div>
	    <br />
</div>
    
    <div style="text-align:center">      
        <center>
            
     <table cellpadding="5" cellspacing="2" style="border:3px solid #dddddd; width:75% ">
     
   <%-- <tr style="background-color:#FFFFCC;">
        <td align="center"  class="PageNameHeadingCSS_2">Online VISA Application</td>
    </tr>--%>
    <tr style="background-color:#FFFFCC;">
        <td colspan="2"  class="PageNameHeadingCSS_1" align="center">Application Information </td>
    </tr>
    
     <tr style="background-color:#FFFFCC;">
        <td style="height: 15px"  colspan ="4"></td>
    </tr> 
       
   
           
      <tr> 
        <td align="center" colspan ="2" >
        <center>        
        
        <table id="tbl1"  cellspacing="2" width ="100%">
        
         <tr   style="background-color:#FFFFCC;" class="b12" >       
        <td align="left" colspan="4" >Application ID :<asp:Label ID="LblAppId" runat="server"></asp:Label></td>        
         </tr>
          
          <tr style="background-color:#FFFFCC;">
                  <td style="height:  15px" colspan ="4"   ></td>
                </tr>  
          
         <tr  style="background-color:#FFFFCC;" >                     
                    <td align="left" style="width: 120px"  class="b12"   >Name :</td>
                    <td align="left" style="width: auto" class="t12" >                     
                     <asp:Label ID="lblName" runat="server"></asp:Label>
                       </td>
                      
                   <td align="left" style="width: 120px"  class="b12">Nationality :</td>
                   <td align="left" style="width: auto"  class="t12" >
                    <asp:Label ID="LblNationality" runat="server"></asp:Label>
                   </td>                  
                 </tr>            
                 
                <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                 
         <tr  style="background-color:#FFFFCC;">                    
                    <td align="left" style="width: 120px" class="b12" >Passport&nbsp; No :</td>
                    <td align="left" style="width: auto" class="t12">
                     <asp:Label ID="LblPassportNo" runat="server"></asp:Label>
                    </td>
                  
                    <td align="left" style="width: 120px" class="b12" >Passport Type :</td>
                    <td align="left" style="width: auto" class="t12" >
                     <asp:Label ID="LblPassportType" runat="server"></asp:Label>
                        </td>
                 </tr>
                               
                 <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                
         <tr  style="background-color:#FFFFCC;">                  
                 <td align="left" style="width: 120px" class="b12">Date of Issue :</td>
                 <td align="left" style="width: auto" class="t12" >
                  <asp:Label ID="LblDoissue" runat="server"></asp:Label> </td>
                  
                  <td align="left" style="width: 120px" class="b12">Date of Expiry :</td>
                    <td align="left" style="width: auto" class="t12" >
                     <asp:Label ID="LblDoExp" runat="server"></asp:Label>
                      
                    </td>
                 </tr>
                
                <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                
         <tr  style="background-color:#FFFFCC;">                  
                 <td align="left" style="width: 120px" class="b12" >ArrivalDate :</td>                 
                 <td align="left" style="width: auto" class="t12" >
                  <asp:Label ID="LblArivalDate" runat="server"></asp:Label>
                    </td>
                   
                    <td align="left" style="width: 120px" class="b12" >DepartureDate :</td>
            <td align="left" style="width: auto"  class="t12">
             <asp:Label ID="LblDepDate" runat="server"></asp:Label>
            </td>
                 </tr>
              
                 <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
            
         <tr style="background-color:#FFFFCC;">                
             <td align="left" style="width: 120px" class="b12" >Visa Type :</td>
            <td  style="text-align: left; width: 250px;" class="t12">
             <asp:Label ID="LblVisaType" runat="server"></asp:Label>
            </td>
           
            <td align="left" style="width: 120px" class="b12">Entry Type :</td>             
         <td align="left" style="width: auto" class="t12" >
          <asp:Label ID="LblEntryType" runat="server"></asp:Label>
          </td>
         </tr> 
                  
              <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
         
         <tr  style="background-color:#FFFFCC;">        
         <td align="left" style="width: 120px" class="b12" >Duration : </td>
         <td align="left" style="width: auto" class="t12">     
          <asp:Label ID="LblDuration" runat="server" CssClas="t12"></asp:Label>
            </td>
             <td align="left" style="width: 120px"  class="b12" >Amount :</td>  
             <td align="left" style="width: auto" class="t12">            
          <asp:Label ID="LblAmount" runat="server" CssClas="t12"></asp:Label>
            </td>         
         </tr>
         
          <%--<tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
         
         <tr  style="background-color:#FFFFCC;">         
         
         </tr>--%>
         
           <tr style="background-color:#FFFFCC;">
                <td style="height:  20px" colspan ="4"  ></td>
              </tr>
         </table>   
         
 </center>
         </td>
       </tr>
       
     </table> 
            
     <table id="tbl2" style="font-style:normal" width ="100%">
     
      <tr>
                <td style="height:  20px" colspan ="4"  ></td>
              </tr>
            
      <tr class="button">
                <td align="center" >
                 
                  <asp:Button ID="BtnPrint" CssClass="button" runat="server" Text="Print" 
                        OnClientClick="Printwin();" Font-Bold="True" Width="75px" />                 
                  <asp:Button ID="BtnCancle" CssClass="button" runat="server" Text="Cancel" 
                         Font-Bold="True" Width="75px" OnClientClick="Closewin();" 
                        onclick="BtnCancle_Click"  />
                </td>
            </tr> 
      </table> 
</center>
</div>

    </form>
</body>
</html>
