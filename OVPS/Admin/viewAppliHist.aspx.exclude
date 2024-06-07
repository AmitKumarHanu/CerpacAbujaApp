<%@ page language="C#" autoeventwireup="true" inherits="Admin_viewAppliHist, App_Web_viewapplihist.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Visa Processing System</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <link href="../App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/view.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../App_theme/css/color.css" />
    <link rel="stylesheet" type="text/css" href="../App_theme/css/country.css" />
    <link rel="Stylesheet" type="text/css" href="../css/scanpage.css" />
    <link href="icon.css" type="text/css"  rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/checkFileExt.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/cj.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/jquery.min1.js"></script>
    <script language="javascript" type="text/javascript">   
    </script>
    <script type="text/javascript">
        function prnt()
        {
            var html = "<html>";
            html += document.getElementById("first_step").innerHTML;
            html += "</html>";

            var printWin = window.open('', '', 'location=no,width=10,height=10,left=50,top=50,toolbar=no,scrollbars=no,status=0,titlebar=no');

            printWin.document.write(html);
            printWin.document.close();
            printWin.focus();
            printWin.print();
            printWin.close();
                    
        }
        
    </script>
    <style type="text/css" media="screen">
        
        .Adminshortcuts {
  text-align: center;
}
.Adminshortcuts .Adminshortcut {
  background-position: 0% 0%;
    width: 168px;
    display: inline-block;
    padding: 10px 0;
    margin: 0 5px 1em;
    vertical-align: top;
    text-decoration: none;
    background-repeat: repeat-x;
    border: 2px solid #ddd;
    box-sizing: border-box;
    border-radius: 4px;
    background-image: linear-gradient(to bottom, #ffffff 0%, #eeeeee 100%);
    background-color: #F3F3F3;
    background-attachment: scroll;
}
.Adminshortcuts .Adminshortcut .Adminshortcut-icon {
  width: 100%;
  margin-top: .25em;
  margin-bottom: .35em;
  font-size: 32px;
  color: #555;
}
.Adminshortcuts {
	
    z-index:99;
 
    background-repeat: repeat-x;
    /*background-image: linear-gradient(to bottom, #fafafa 0%, #e1e1e1 100%);
    background-color: #E8E8E8;*/
    background-attachment: scroll;
}

.Adminshortcut:hover {
	background-position: 0% 0%;
   /* animation: changeColor 3s infinite, changeSize 2s ease-in 1s infinite;*/	

    z-index:99;
 
    background-repeat: repeat-x;
    background-image: linear-gradient(to bottom, #fafafa 0%, #e1e1e1 100%);
    background-color: #E8E8E8;
    background-attachment: scroll;
}
@keyframes changeColor {
	0% {
		background-color: red;
		border-color: #6666FF;
	}
	100% {
		background-color: green;
		border-color: #FF3333;
	}
}
@keyframes changeSize {
	0% {transform: scale(1)}
	65% {transform: scale(1.2)}
	100% {transform: scale(1.4)}
}

.Adminshortcuts .Adminshortcut:active {
  box-shadow: inset 0 3px 5px rgba(0, 0, 0, 0.125);
}
.Adminshortcuts .Adminshortcut:hover .Adminshortcut-icon {
  color: #666;
}
.Adminshortcuts .Adminshortcut-label {
  display: block;
  margin-top: .75em;
  font-weight: 400;
  font-size: 18px;
}

    </style>
</head>
<body>
    <form id="frmView" runat="server">
        
    <div>
       
        <%--   <link rel="stylesheet" type="text/css" href="../JS/style.css" media="all" />   --%>
        <div id="first_step" align="center">
            <h1>Applicant History</h1>
            <br /><br />
            
                       <% if (objDs.Tables.Count > 0)
               { 
                   if (objDs.Tables[0].Rows.Count > 0)
                   { %>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Cerpac Number
                    </td>
                    <td width="15" align="center"></td>
                    <td>
                        <asp:Label ID="lblcerpacno" runat="server"></asp:Label>
                    </td>
                    <td width="60"></td>
                </tr>
            </table>
            <br /><br />
            <table class="GridBaseStyle" cellspacing="1" border="1" style="width: 100%;" rules="all">
                <tr class="Grid_Header">
                    <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Cerpac File No.
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Fore Name
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                       Last Name.
                    </th>
                    <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Nationality
                    </th>
                    <th valign="middle" align="left" style="white-space: nowrap;display:none;" scope="col">
                        Date of birth
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Place of Issue
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Place of Birth
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Card Issue Date
                    </th>
                    <th valign="middle" align="left" scope="col">
                        Recipt Date
                    </th>
                    <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                       Expiry Date
                    </th>
                    <th align="left" style="width: 10%;" scope="col">
                        Passport Number
                    </th>
                    <th align="left" style="width: 10%; display:none;" scope="col">
                        Company Name
                    </th>
                    <th align="left" style="width: 10%;" scope="col">
                        Designation
                    </th>
                                    
                </tr>
                <%for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                  {%>
                <tr class="Grid_Item_Alternaterow">
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["cerpac_file_no"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["forename"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["surname"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["nationality"])%>
                    </td>
                     <td valign="middle" align="left" style="display:none;">
                        <%=Convert.ToString(string.Format("{0:dd/MM/yy}",objDs.Tables[0].Rows[i]["date_of_birth"]))%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["passport_issue_loc"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["place_of_birth"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(string.Format("{0:dd/MM/yy}",objDs.Tables[0].Rows[i]["date_issued"]))%>
                        </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(string.Format("{0:dd/MM/yy}",objDs.Tables[0].Rows[i]["cerpac_receipt_date"]))%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(string.Format("{0:dd/MM/yy}",objDs.Tables[0].Rows[i]["cerpac_expiry_date"]))%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["passport_no"])%>
                    </td>
                     <td valign="middle" align="left" style="display:none">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["company"])%>
                    </td>
                     <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["designation"])%>
                    </td>
                  </tr>
                <%} %>

                 
            </table>
            <%}
                   else
                   {
                       lblerrmsg.Visible = true;
                   }
               }
                          else
                          {
                              lblerrmsg.Visible = true;
                          }
              %>
           <asp:Label ID="lblerrmsg" runat="server" CssClass="warning-box" Text="No History Found" Font-Size="Small" Width="666px" Visible="false"></asp:Label> <br /><br />
            </div>
            <div class="Adminshortcuts" style="height:40px;"> 
            <label class="Adminshortcut" onclick="return prnt();" style="width:40px;" id="lblprnt"> 
                 <i class="shortcut-icon icon-print"></i>
             </label>
                </div>
        
        <!-- edit start for first floating div GRV-->
        <div class="clear">
        </div>
        <!-- /clearfix -->
       
    </div>
    </form>
</body>
</html>
