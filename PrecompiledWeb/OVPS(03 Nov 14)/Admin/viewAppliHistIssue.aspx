<%@ page language="C#" autoeventwireup="true" inherits="Admin_viewAppliHistIssue, App_Web_viewapplihistissue.aspx.fdf7a39c" %>

<!DOCTYPE html>

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
    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/checkFileExt.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/cj.js"></script>
    <script language="javascript" type="text/javascript">   
    </script>
</head>
<body>
    <form id="frmView" runat="server">
    <div>
        <%--   <link rel="stylesheet" type="text/css" href="../JS/style.css" media="all" />   --%>
        <div id="first_step" align="center" style="overflow-x:scroll; height:640px;">
            <h1>Applicant History</h1>
            <br /><br />
                       <% if (objDs.Tables.Count > 0)
               {
                   if (objDs.Tables[0].Rows.Count > 0)
                   { %>
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
                        Sex
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Nationality
                    </th>
                    <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Date of birth
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Place of Issue
                    </th>
                     <th valign="middle" align="left" style="white-space: nowrap;" scope="col">
                        Place of Birth
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
                    <th align="left" style="width: 10%;" scope="col">
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
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["sex"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["nationality_id"])%>
                    </td>
                     <td valign="middle" align="left">
                        <%=Convert.ToString(string.Format("{0:dd/MM/yy}",objDs.Tables[0].Rows[i]["date_of_birth"]))%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["passport_issue_loc"])%>
                    </td>
                    <td valign="middle" align="left">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["place_of_birth"])%>
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
                     <td valign="middle" align="left">
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
           <asp:Label ID="lblerrmsg" runat="server" CssClass="warning-box" Text="No History Found" Font-Size="Small" Width="666px" Visible="false"></asp:Label> 
        </div>
        <!-- edit start for first floating div GRV-->
        <div class="clear">
        </div>
        <!-- /clearfix -->
    </div>
    </form>
</body>
</html>
