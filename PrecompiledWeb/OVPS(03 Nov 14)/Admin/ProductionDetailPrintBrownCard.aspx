<%@ page language="C#" autoeventwireup="true" inherits="Admin_ProductionDetailPrintBrownCard, App_Web_productiondetailprintbrowncard.aspx.fdf7a39c" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80px;
        }
    </style>
    <script type="text/javascript">
        function prin()
        {
            window.print();
            window.close();
        }
    </script>
</head>
<body onload="return prin();">
    <form id="form1" runat="server">
    <div>
     <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="750px" 
                            style="height: 355px">
                            
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/frontbrown.png'); height: 350px; width: 564px; background-repeat:no-repeat;" align="right">
                               <asp:Image ID="ImgPhoto" runat="server" Style="position:absolute;top: 74px;left: 50px;height: 163px;width: 149px;" />

<table style="width: 53%;">
                              
    <br /><br /><br />  
                                      
                                  <tr>
                                  <td style="width: 128px;">&nbsp;
                                       </td>
                                  <td style="text-align: left; text-decoration-color:maroon;">
                                  <asp:Label ID="lblpas" runat="server" Text="Passport No." Font-Size="Medium"></asp:Label>
                                  </td>
                                   </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s;">
                                  <asp:Label ID="lbl_passport" runat="server" Text="745698213" style="color: #FFFFFF" Font-Size="Medium">

                                  </asp:Label>
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  NATIONALITY
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; animation-name:blink; animation-duration:.5s; border-width:thin;">
                                  <asp:Label ID="lbl_nationality" runat="server" Text="UTOPIA" style="color: #FFFFFF"></asp:Label>
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      REGISTRATION AREA</td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      <asp:Label runat="server" ID="lbl_place_of_issue" style="color: #FFFFFF"></asp:Label></td>
                                  </tr>

                                   <tr>
                                   <td style="width: 128px">&nbsp;</td>
                                  <td style="text-align: left">
                                  DESIGNATION
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   <asp:Label ID="lbl_desig" runat="server" Text="56982145" style="color: #FFFFFF"></asp:Label>
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      &nbsp;</td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left;">
                                  <asp:Label ID="lbl_name" runat="server" Text="PIA ANGELA" Width="300px" Font-Size="Large" style="color: #FFFFFF"></asp:Label>
                                   
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                      &nbsp;</td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   
                                  
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  </table>

                                  </div>
                                </td>
                            </tr>
                        </table><table id="Table1" cellpadding="5" cellspacing="2" border="0" width="750px" 
                            style="height: 355px">
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/backbrown.png'); height: 350px; width: 564px;  background-repeat:no-repeat;" align="center">
                                      <br />
                                     <br />
                                 <br /><br /><br /><br />
                                  <table style="width: 54%;">
                                   <tr>
                                   <td align="left" style="width:auto;"><asp:Label runat="server" ID="lblcer" Text="Cerpac No" Font-Bold="true" Font-Size="Small"></asp:Label></td>
                                  <td style="text-align: left" align="left">
<asp:Label ID="lbl_cerpac_no" runat="server" Text="" style="color: #FFFFFF" Font-Size="Small"></asp:Label>
                                  
                                  </td>
<td></td>
                                 <td style="width:auto;" align="left"><asp:Label runat="server" ID="lblex" Text="Expiry" Font-Bold="true" Font-Size="Small"></asp:Label></td>
                                  <td style="text-align: left" align="left">
                                   <asp:Label ID="lbl_expiry_date" runat="server" Text="" style="color: #FFFFFF" Font-Size="Small"></asp:Label>
                                    
                                      </td>
                                  </tr>
                                 </table>
                                      <br /><br />
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image runat="server" ID="imgbarcode" Height="100px" Width="323px" />
                                  </div>
                                </td>
                            </tr>
                        </table>

    </div>
    </form>
</body>
</html>
