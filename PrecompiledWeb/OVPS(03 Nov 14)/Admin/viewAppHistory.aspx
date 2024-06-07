<%@ page language="C#" autoeventwireup="true" inherits="Admin_view, App_Web_viewapphistory.aspx.fdf7a39c" %>

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
    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/checkFileExt.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/cj.js"></script>
    <script language="javascript" type="text/javascript">   
    </script>
</head>
<body>
    <form id="frmView" runat="server">
    <div class="wraper_app" style="width: 800px;">
        <%--   <link rel="stylesheet" type="text/css" href="../JS/style.css" media="all" />   --%>
        <div id="first_step" align="center"  class="scroll">
            <img src="../Images/applicationhistory.jpg" />
            <br /><br />
            <% if (objDs.Tables.Count > 0)
               {
                   if (objDs.Tables[0].Rows.Count > 0)
                   { %>
            <table class="GridBaseStyle" cellspacing="1" border="1" style="width: 90%;" rules="all">
                <tr class="Grid_Header">
                    <th valign="middle" align="center" style="white-space: nowrap;" scope="col">
                        Step No
                    </th>
                    <th valign="middle" align="center" scope="col">
                        Work Center
                    </th>
                    <th valign="middle" align="center" style="white-space: nowrap;" scope="col">
                        User Name
                    </th>
                    <th align="center" style="width: 10%;" scope="col">
                        Activity
                    </th>
                    <th align="center" style="width: 10%;" scope="col">
                        On
                    </th>
                    <th align="center" style="width: 10%;" scope="col">
                        Comments
                    </th>                    
                </tr>
                <%for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                  {%>
                <tr class="Grid_Item_Alternaterow">
                    <td valign="middle" align="center">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["StepId"])%>
                    </td>
                    <td valign="middle" align="center">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["WorkCenter"])%>
                    </td>
                    <td valign="middle" align="center">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["UserName"])%>
                    </td>
                    <td valign="middle" align="center">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["ActivityDisplayName"])%>
                    </td>
                    <td valign="middle" align="center">
                        <%=Convert.ToString(objDs.Tables[0].Rows[i]["ActivityDate"])%>
                    </td>                   
                    <td valign="middle" align="center">
                       <a id="A1"  title='<%=Convert.ToString(objDs.Tables[0].Rows[i]["Comments"])%>' href="javascript:">
                            <%=Convert.ToString(objDs.Tables[0].Rows[i]["Comments"])%>
                        </a>
                    </td>
                </tr>
                <%} %>
            </table>
            <%}
               } %>
        </div>
        <!-- edit start for first floating div GRV-->
        <div class="clear">
        </div>
        <!-- /clearfix -->
    </div>
    </form>
</body>
</html>
