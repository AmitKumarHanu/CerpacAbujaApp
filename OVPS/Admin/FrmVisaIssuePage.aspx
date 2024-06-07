<%@ page language="C#" autoeventwireup="true" inherits="Admin_FrmVisaIssuePage, App_Web_frmvisaissuepage.aspx.fdf7a39c" title="Print Paper Visa" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    


      <script type="text/javascript" language="javascript">
       
        function Print()
        {
           document.getElementById("BtnIssuePaperVisa").style.display = 'none';
             
         window.print();

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
<body>
    <form id="form1" runat="server">
    
       <div>
    <div id="container" align="center">
	<div id="logo"><img src="../Images/text.png" align="middle" /></div>
	    <br />
</div>



<div id="footer" style="padding-top:10px; left: 2px;"><br /></div>
            <br />
    </div>
    </div>       
        
        <table id="tbl1" cellpadding="4" cellspacing="2" border="1" style="font-style:normal" width ="100%">
        
         <tr class ="t11">
            <td>
                &nbsp;</td>
        </tr>
        <tr class="t11">
            <td class="PageNameHeadingCSS_2" align="center">Print Paper Visa 
        </td>
        </tr>
        <tr class="t11">
            <td>
                &nbsp;</td>
        </tr>
        <%--<tr class="t11">
            <td align="center">
                <asp:Image ID="Image1" runat="server" Height="367px" 
                    ImageUrl="~/Images/visa.jpg" Width="771px" />
            </td>
        </tr>--%>
        <tr class="t11">
            <td>
            
                </td>
        </tr>
        <tr class="t11">
            <td>
             <table id="Table1" runat="server"  cellpadding="4" cellspacing="2" style="font-style:normal" width ="771px" align="center">
        
         <tr  class="b12" style="background-color:#FFFFCC;">       
        <td align="left" >Application ID :</td><td colspan="3"><asp:Label ID="LblAppId" runat="server"></asp:Label></td> 
             
         </tr>
          
          <tr style="background-color:#FFFFCC;">
                  <td style="height:  15px" colspan ="4"   ></td>
                </tr>  
          
         <tr class="b12" style="background-color:#FFFFCC;" >                     
                    <td align="left" style="width: 120px; height: 19px;"    >Name :</td>
                    <td align="left" style="width: auto; height: 19px;"  >                     
                     <asp:Label ID="lblName" runat="server"></asp:Label>
                       </td>
                      
                   <td align="left" style="width: 120px; height: 19px;" >Nationality :</td>
                   <td align="left" style="width: auto; height: 19px;"  >
                    <asp:Label ID="LblNationality" runat="server"></asp:Label>
                   </td>                  
                 </tr>            
                 
                <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                 
         <tr class="b12" style="background-color:#FFFFCC;">                    
                    <td align="left" style="width: 120px" >Passport No :</td>
                    <td align="left" style="width: auto" >
                     <asp:Label ID="LblPassportNo" runat="server"></asp:Label>
                    </td>
                  
                    <td align="left" style="width: 120px" >Passport Type :</td>
                    <td align="left" style="width: auto" >
                     <asp:Label ID="LblPassportType" runat="server"></asp:Label>
                        </td>
                 </tr>
                               
                 <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                
         <tr class="b12" style="background-color:#FFFFCC;">                  
                 <td align="left" style="width: 120px" >Date of Birth :</td>
                 <td align="left" style="width: auto" >
                  <asp:Label ID="LblDoB" runat="server"></asp:Label> </td>
                  
                  <td align="left" style="width: 120px" >Sex :</td>
                    <td align="left" style="width: auto" >
                     <asp:Label ID="LblSex" runat="server"></asp:Label>
                      
                    </td>
                 </tr>
                
                <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                <tr class="b12" style="background-color:#FFFFCC;">                  
                 <td align="left" style="width: 120px" >Father Name :</td>                 
                 <td align="left" style="width: auto" >
                  <asp:Label ID="FatherName" runat="server"></asp:Label>
                    </td>
                   
                    <td align="left" style="width: 120px"  >E-Mail Id :</td>
            <td align="left" style="width: auto" >
             <asp:Label ID="LblEmail" runat="server"></asp:Label>
            </td>
                 </tr>
                
                 <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                
                 
                 
               <%--  <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>--%>
                
         <tr class="b12" style="background-color:#FFFFCC;">                  
                 <td align="left" style="width: 120px" >Duration :</td>                 
                 <td align="left" style="width: auto" >
                  <asp:Label ID="LblDuration" runat="server"></asp:Label>
                    </td>
                   
                    <td align="left" style="width: 120px"  >Duriation Type :</td>
            <td align="left" style="width: auto" >
             <asp:Label ID="LblDurationType" runat="server"></asp:Label>
            </td>
                 </tr>
              
                 <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
                
                 <tr class="b12" style="background-color:#FFFFCC;">                
             <td align="left" style="width: 120px" >Visa Type :</td>
            <td  style="text-align: left; width: 250px;">
             <asp:Label ID="LblVisaType" runat="server"></asp:Label>
            </td>
           
            <td align="left" style="width: 120px" >Entry Type :</td>             
         <td align="left" style="width: auto" >
          <asp:Label ID="LblEntryType" runat="server"></asp:Label>
          </td>
         </tr> 
              
               <%--  <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>--%>
            
         
                  
              <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>
         
     <%--    <tr class="b12" style="background-color:#FFFFCC;">        
         <td align="left" colspan="4" >Visa Valid From :       
          <asp:Label ID="LblDuration" runat="server"></asp:Label>
            </td>        
         </tr>--%>
         
         <%-- <tr style="background-color:#FFFFCC;">
                  <td style="height:  5px" colspan ="4"  ></td>
                </tr>--%>
         
         <%--<tr class="b12" style="background-color:#FFFFCC;">         
          <td align="left" >Amount :</td>
          <td>     
          <asp:Label ID="LblAmount" runat="server"></asp:Label>
            </td> 
             <td align="left" >Currency:</td>
          <td>     
          <asp:Label ID="LblCurrency" runat="server"></asp:Label>
            </td>
            
         </tr>--%>
         
           <%--<tr style="background-color:#FFFFCC;">
                <td style="height:  20px" colspan ="4"  ></td>
              </tr>--%>
         </table>   
         
 
         </td>
       </tr>
       
     </table> 
            
     <table id="tbl2" style="font-style:normal" width ="100%">
     
      <tr>
                <td style="height:  20px" colspan ="4"  ></td>
              </tr>
            
     <%-- <tr class="t11">
            <td align=center>
                <asp:Button ID="BtnIssuePaperVisa" runat="server" CssClass="button" 
                    Text="Print Paper Visa" />
                 <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    Text="Back To Visa list" onclick="BtnBack_Click"  />   
            </td>
            
        </tr>--%>
      </table> 

</div>
    </form>
</body>
</html>--%>




