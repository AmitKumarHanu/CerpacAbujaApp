<%@ page language="C#" autoeventwireup="true" inherits="FrmRecoverLoginid, App_Web_frmrecoverloginid.aspx.cdcab7d2" %>
<%@ OutputCache NoStore="true" Location="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" cssclass="textbox" runat="server">
    <title>Recover Login Details</title>   
     <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
   <link href="App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
     <link href="App_theme/css/style.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
body {
	margin:0;
	background-color: #F9F9F9;
	font-family:Verdana, Arial, Helvetica, sans-serif;
	font-size:13px;
	color:#8E8F8F;
}
.style1
        {
            width: 80%;
        }
#container{}

#a{
	background:url(images/globe.png) no-repeat;
	margin-left:200px;
	 margin-top:100px;
	 margin-right:100px;	
	}	

#plane{
	background:url(images/plane.png) no-repeat;
	margin-left:600px;
	margin-top:-20px;
	height:109px;
	width:400px; 
	z-index:-10px;}	

a {color:#FFFFFF;}	

</style>
</head>

<body>
<center>
  <form id="form1"  runat="server"> 
  <div class="header_tp">
		<div class="emblem_icon">
					<a href="#"><img src="./images/emblem.jpg" alt="emblem"/></a>
		</div>
				<div class="nijeria_hdng">
					<img src="./images/nijeria_hdng.png" alt="nijeria hdng"/>
				</div>
				<div class="flag_icon">
					<a href="#"><img src="./images/flag.jpg" alt="flag"/></a>
				</div>
	</div>
    <table>
      <%--<tr>
        <td><img src="Images/Logo/flag.png"alt="" /></td>
        <td align="center" style="font-size: 40px; font-weight: bold; display: inline" class="style1">Online Visa Application</td>
        <td  style="text-align:center width:60%; vertical-align:text-top" valign="top">
           <asp:Label ID="LabelSysDate" Font-Size="Smaller" runat="Server" CssClass="lbl"></asp:Label>&nbsp;
        </td>
        <td align="right"><img src="Images/Logo/logo.png" alt="" height="60" width="70" /></td>
      </tr>--%>
     </table>       
    <div>    
    <center>
        <fieldset style="width:50%; height:auto;">
           <legend>
             <div class="PageNameHeadingCSSHeader" >Recover Login Detail
               <asp:Label ID="LabelSysDate" Font-Size="Smaller" runat="Server" CssClass="lbl"></asp:Label>&nbsp;
               </div>
              </legend>                
                  <table cellpadding="5" cellspacing="2" border="0" width="70%">
            
                    <tr>
                     <td colspan="2"  align="center">
                         <asp:Label ID="lblError" runat="server" Visible="true" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                     </tr>
                
                    <tr >
                        <td colspan="2"  align="center" >
                            <asp:RadioButtonList ID="Rbl"  runat="server" RepeatDirection="Horizontal" 
                                onselectedindexchanged="Rbl_SelectedIndexChanged" Width="250px" AutoPostBack="true" 
                                Height="17px"  >
                                 <asp:ListItem Value="1" >Login ID</asp:ListItem> 
                                <asp:ListItem Value="2">Email ID</asp:ListItem>
                                                              
                            </asp:RadioButtonList>
                        </td>
                          </tr>  
                    
                     <tr><td  colspan="2" align="center" style="height:10;"></td></tr>
                    
                    <tr class="b11">
                        <td align="right" style="width:120px">Login ID :</td>
                        <td align="left">
                            <asp:TextBox ID="txtLoginId" Autocomplete="off" ReadOnly="true" runat="server"  CssClass="textbox" MaxLength="25"></asp:TextBox>
                         </td>
                      </tr>
                     
                    <tr>
                         <td align="right" style="width:120px"></td>
                        <td align="left">
                           or
                         </td>
                      </tr>
                      
                    <tr class="b11">
                        <td  style="width:120px" align="right">E-mail ID :</td>
                       <td align="left">
                            <asp:TextBox ID="txtEmailId" Autocomplete="off" ReadOnly="true" CssClass="textbox" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        
                    <tr><td  colspan="2" align="center" style="height: 15px;"></td></tr>
                    
                    <tr >
                        <td colspan="4" align="center" style="height: 2px;">
                        <asp:Button ID="Submit" CssClass="subbtn1" runat="server" Text="Submit" 
                               onclick="Submit_Click" /> 
                         &nbsp;<asp:Button ID="BtnCancel" CssClass="subbtn1" runat="server" Text="Cancel" 
                                onclick="BtnCancel_Click" />                                                 
                        </td>
                    </tr> 
                    
                    <tr><td  colspan="2" align="center" style="height: 10px;"></td></tr>           
            </table>
        </fieldset>
       </center>
     </div>
       <%-- <table style="width:100%; height:20%">
    <tr >
    <td style="height:60%; width:100%; background-color:Red" >
    Powered by <a href="http://www.contecglobal.com/" target="_blank">Contech Global</a>
    </td>
    
       <%--<div id="Div1" style="padding-top:10px; left: 0px; background-color:Red;"><br />Powered by <a href="http://www.contecglobal.com/" target="_blank">Contech Global</a></div>--%>
      <%--</tr>      
    </table>--%>  
    </form>  
    </center> 
  </body>
</html>
