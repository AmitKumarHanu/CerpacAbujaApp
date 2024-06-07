<%@ page language="C#" autoeventwireup="true" inherits="Admin_view, App_Web_viewcc.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Visa Processing System</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <link href="../App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/view.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/checkFileExt.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
    <script language="javascript" type="text/javascript">   
    </script>
</head>
<body>
    <form id="frmView" runat="server">
    <div class="wraper_app">
        <%--   <link rel="stylesheet" type="text/css" href="../JS/style.css" media="all" />   --%>
        <div id="first_step" class="scroll">
            <img src="../Images/review.jpg" />
            <% if (dt.Rows.Count > 0)
               { %>
            <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                <tbody>
                    <tr>
                        <td align="left" class="t11" colspan="3">
                            Your Details
                        </td>
                        <td width="181">
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="b11">
                        <td width="192" align="left" class="style3">
                            First Name
                        </td>
                        <td width="119">
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["FirstName"])%></span>
                        </td>
                         <td >
                            Primary Email
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["EmailID"])%></span>
                        </td>
                         
                    </tr>
                    <tr class="b11">
                        <td class="style3">
                            Middle Name
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["MiddleName"])%></span>
                        </td>
                        
                        <td>
                            Alternate Email
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["AternativeEmailId"])%></span>
                        </td>
                       
                    </tr>
                    <tr class="b11">
                        <td align="left" class="style3">
                           Last Name
                        </td>
                        <td class="b11">
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["LastName"])%>
                            </span>
                        </td>
                       <td width="199">
                            Color Of Eyes 
                        </td>
                        <td class="b11">
                            <span class="lview">
                              <%=Convert.ToString(dt.Rows[0]["ColorEye"])%></span>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" class="style3">
                            <span style="width: 150px;"> Date of Birth</span>
                        </td>
                        <td class="b11">
                            <span class="lview">
                               <%=Convert.ToString(dt.Rows[0]["DateOfBirth"])%>
                                </span>
                        </td>
                        <td>
                            <span class="style3">Color Of Hair </span>
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["ColorHair"])%></span>
                        </td>
                    </tr>
                    <tr class="b11">
                      <td align="left" class="style3">
                            Place of Birth
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["PlaceOfBirth"])%></span>
                        </td>
                      
                        <td>
                            Marital Status
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["MaritalStatus"])%></span>
                        </td>
                    </tr>
                    <tr class="b11">
                      <td align="left" class="style3">
                            Spouse's Name
                        </td>
                        <td>
                            <span class="lview">
                            <%=Convert.ToString(dt.Rows[0]["SpouseName"])%>
                               </span>
                        </td>
                   
                        <td>
                            <span class="style3">Identification Marks </span>
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["IndentityMark"])%></span>
                        </td>
                    </tr>
                    <tr class="b11">
                        <td align="left" class="style3">
                            <span class="style4">Height(in cm) </span>
                        </td>
                        <td class="b11">
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["Height"])%></span>
                        </td>
                       <td>
                            Gender
                        </td>
                        <td>
                            <span class="lview">
                                <%=Convert.ToString(dt.Rows[0]["sex"])%></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="divpersonaldetails2">
                                <img src="../Images/steps_1.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2"
                                    style="display: table; overflow: visible; padding-top: 0px; padding-bottom: 0px;"
                                    role="tabpanel">
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span class="t11">Your Family Details(Father) </span>
                                        </td>
                                        <td width="170">
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            First Name
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FatherName"])%></span>
                                        </td>
                                        <td width="182" align="left">
                                            <span class="style3">Nationality </span>
                                        </td>
                                        <td width="125">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FatherNationality"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                    <td width="198">
                                            <span class="style3">Last Name </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FatherLastName"])%></span>
                                        </td>
                                        
                                        <td align="left">
                                            Place & Country of Birth
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FatherAddress"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td width="182" align="left">
                                            <span class="style3">Date Of Birth </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FatherDateOfBirth"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span class="t11">Your Family Details(Mother) </span>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            Mother's Name
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MotherName"])%></span>
                                        </td>
                                          <td width="182" align="left">
                                            <span class="style3">Nationality </span>
                                        </td>
                                        <td width="125">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MotherNationality"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                     <td>
                                            <span class="style3">Last Name </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MotherLastName"])%></span>
                                        </td>
                                     
                                        <td align="left">
                                            Place & Country of Birth
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MotherAddress"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td width="182" align="left">
                                            <span class="style3">Date Of Birth </span>
                                        </td>
                                        <td width="125">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MotherDateOfBirth"])%></span>
                                        </td>
                                    </tr>
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <!-- #passport details -->
                            <div id="divpassport">
                                <img src="../Images/steps_2.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                                    <tr>
                                        <td width="179">
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span class="t11">Current Passport Details</span>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 15%">Passport Or Travel
                                                <br />
                                                Document Number </span>
                                        </td>
                                        <td width="123">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PassportNumber"])%></span>
                                        </td>
                                        <td width="201">
                                            <span style="width: 12%">Nationality </span>
                                        </td>
                                        <td width="172">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CountryName1"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 15%">Passport Type </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PassportType"])%></span>
                                        </td>
                                        <td>
                                            Date of Issue
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["DateOfIssue"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Issuing Authority
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IssuingAuthority"])%></span>
                                        </td>
                                        <td>
                                            <span style="height: 37px">Date of Expiry </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["DateOfExpiry"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Place of Issue
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PlaceOfIssue"])%></span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagFreshPassport1"]).Trim() == "N")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span class="t11">Old Passport Details</span>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="4">
                                            <div>
                                                <table width="700px">
                                                    <tr>
                                                        <td colspan="4" align="left">
                                                            Old Passport Details
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td width="180" align="left" class="style3">
                                                            Passport Or Travel<br />
                                                            Document Number
                                                        </td>
                                                        <td width="135" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["oldPassportNumber"])%></span>
                                                        </td>
                                                        <td width="209">
                                                            <span style="width: 150px;">Issue Date </span>
                                                        </td>
                                                        <td width="156">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["OldPaasportIssueDate"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Place Of Issue</span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PlaceIssueOldPassport"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!-- #diccontect -->
                            <div id="divcontact">
                                <img src="../Images/steps_3.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                                    <tr>
                                        <td colspan="3" align="left" class="t11">
                                            Current Contact Details
                                        </td>
                                        <td width="158">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td width="176" align="left" class="style3">
                                            Address1
                                        </td>
                                        <td width="128" align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CurrentAddress"])%></span>
                                        </td>
                                        <td width="213">
                                            <span style="width: 150px;">City </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["City"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 150px;">Address2 </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["Address2"])%></span>
                                        </td>
                                        <td>
                                            <span class="style3">State </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["State"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 150px;">Postcode </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PostCode"])%></span>
                                        </td>
                                        <td>
                                            <span style="width: 150px;">District </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["District"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 15%">Mobile Number </span>
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MobileNumber"])%></span>
                                        </td>
                                        <td>
                                            <span style="width: 150px;">Country </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CountryName2"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            LandLine Number
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LandlinePhone"])%></span>
                                        </td>
                                        <td>
                                            <span style="width: 150px;">How Long you lived in this address ? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LivedInCurrentAdd"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagCuurContactDetails1"]).Trim() == "N")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="700px">
                                                    <tr>
                                                        <td colspan="3" align="left" class="t11">
                                                            Alternate Contact Details
                                                        </td>
                                                        <td width="145">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td width="179" align="left" class="style3">
                                                            Address1
                                                        </td>
                                                        <td width="138" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PermanentAddress"])%></span>
                                                        </td>
                                                        <td width="218">
                                                            <span style="width: 150px;">City </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["perCity"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Address2 </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["perAddress2"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">State </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["perState"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Postcode </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["perPostCode"])%></span>
                                                        </td>
                                                        <td>
                                                            <span style="width: 150px;">District </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["perDistrict"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 15%">Country </span>
                                                        </td>
                                                        <td align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CountryName3"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!--#divvisa1-->
                            <div id="divvisa1">
                                <img src="../Images/steps_4.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                                    <tr class="b11">
                                        <td width="177" align="left">
                                            <span style="width: 150px;">Mode of travel </span>
                                        </td>
                                        <td width="132" align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["ModeOfTravel"])%></span>
                                        </td>
                                        <td width="206" align="left">
                                            Type of VISA
                                        </td>
                                        <td width="160" align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["VisaTypeName"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            Entry Type
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["EntryTypeName"])%></span>
                                        </td>
                                        <td align="left">
                                            <span style="width: 162px">Period Type </span>
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["DurationTypeName"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            Duration
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["Duration"])%></span>
                                        </td>
                                        <td align="left">
                                            Rate
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["Rate"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            Arrival Date
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["ArrivalDate"])%></span>
                                        </td>
                                        <td align="left">
                                            Departure Date
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["DepartureDate"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 162px">Border Entry Point </span>
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["BorderEntryPoint"])%></span>
                                        </td>
                                        <td align="left">
                                            Border Exit Point
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["BorderExitPoint"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="t11">
                                        </td>
                                        <td align="left" class="t11">
                                        </td>
                                        <td align="left" class="t11">
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 15%">Current Location</span>
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CountryName4"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="t11">
                                        </td>
                                        <td align="left" class="t11">
                                        </td>
                                        <td align="left" class="t11">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!--#divvisa2-->
                            <div id="divvisa2">
                                <img src="../Images/steps_4.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                                    <tr class="b11">
                                        <td colspan="3">
                                            Do you hold, or have you ever held, any other nationality or nationalities?
                                        </td>
                                        <td colspan="1" align="left"  >
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagOtherNationality"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagOtherNationality1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="2">
                                            Other Nationality Details
                                        </td>
                                        <td colspan="2" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["OtherNationalityDetails"])%></span>
                                        </td>
                                    </tr>
                                    <% }%>
                                    <tr class="b11">
                                        <td align="left"  colspan="3" style="width: 150;" colspan="1">
                                            Do you plan to make several journeys?
                                        </td>
                                        <td align="left" colspan="1">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["SeveralJourneyYN"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11" valign="top">
                                        <td align="left" colspan="3">
                                            Do you have a return ticket?
                                        </td>
                                        <td align="left" colspan="1">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["HasReturnTicketYN"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" colspan="3">
                                            <span style="width: 150px;">Money do you have for this trip(USD). </span>
                                        </td>
                                        <td align="left" colspan="1">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["MoneyForTravellUSD"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11" valign="top">
                                        <td align="left" colspan="3">
                                            <span style="width: 162px">Present Occupation </span>
                                        </td>
                                        <td align="left" colspan="3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["ApplicantStatus"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11" valign="top">
                                        <td align="left" valign="top" colspan="3">
                                           Purpose of Journey To Nigeria
                                        </td>
                                        <td align="left" colspan="1">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PurposeOfStayinTravellingCountry"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagInMillitary1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="3" align="left" class="t11">
                                            If you have served in militery, please state
                                        </td>
                                        <td width="156">
                                            <%=Convert.ToString(dt.Rows[0]["flagInMillitary"])%>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td width="180" align="left">
                                            <span class="style3">From Date </span>
                                        </td>
                                        <td width="133">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FromDate"])%></span>
                                        </td>
                                        <td width="206" align="left">
                                            IN
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["InMilitary"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td width="180" align="left">
                                            To Date
                                        </td>
                                        <td width="133">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["ToDate"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11" valign="top" >
                                        <td align="left" colspan="3" >
                                            Do you wish to avail fast processing of application?
                                        </td>
                                        <td align="left" colspan="1">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagFastTrack"])%></span>
                                        </td>
                                    </tr>
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!-- #second_step -->
                            <div id="second_step">
                                <img src="../Images/steps_4.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2"
                                    style="display: table; overflow: visible; padding-top: 0px; padding-bottom: 0px;"
                                    role="tabpanel">
                                    <tr class="b11">
                                        <td colspan="3" class="t11">
                                            Intended Address in Nigeria
                                        </td>
                                        <td width="154">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td width="181" align="left" class="style3">
                                            Address1
                                        </td>
                                        <td width="131">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IntedAddress1"])%></span>
                                        </td>
                                        <td width="209">
                                            <span style="width: 150px;">City </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IntedCity"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 150px;">Address2 </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IntedAddress2"])%></span>
                                        </td>
                                        <td>
                                            <span class="style3">State </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IntedState"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left">
                                            <span style="width: 150px;">Postcode </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IntedPostcode"])%></span>
                                        </td>
                                        <td>
                                            <span style="width: 150px;">District </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["IntedDistrict"])%></span>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>&nbsp;</td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            If the purpose of your journey to Nigeria is for employement?
                                        </td>
                                        <td align="left">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagEmployement"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagEmployement1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="700px">
                                                    <tr class="b11">
                                                        <td colspan="4">
                                                            Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                    <td>&nbsp;</td>
                                    </tr>
                                                    <tr class="b11">
                                                        <td  align="left" colspan="2">
                                                            <span class="style3">Name Of Employer </span>
                                                        </td>
                                                        <td colspan="2" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["EmployerName"])%></span>
                                                        </td>
                                                     
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" colspan="2">
                                                            <span >Full Description Of Job</span>
                                                        </td>
                                                        <td align="left" colspan="2">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["JobDesc"])%></span>
                                                        </td>
                                                       
                                                    </tr> 
                                                    <tr>
                                                       <td colspan="2" align="left">
                                                            <span style="width: 150px;">Position to be occupied </span>
                                                        </td>
                                                        <td colspan="2" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["OcuPossition"])%></span>
                                                        </td>
                                                    </tr>                                                 
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                      <tr>
                                    <td>&nbsp;</td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            Give particulars of the employement of parents/spouse in Nigeria(If Applicable)
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagEmplDt"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagEmplDt1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="700px">                                                   
                                                    <tr>
                                                        <td colspan="4">
                                                            <div>
                                                                <table width="700px">
                                                                    <tr class="b11">
                                                                        <td colspan="4">
                                                                            Details
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="b11">
                                                                        <td colspan="2" align="left" class="t11">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="211" align="left" class="t11">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="152" align="left" class="t11">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="b11">
                                                                        <td width="150" align="left" class="style3">
                                                                            Name Of Employer
                                                                        </td>
                                                                        <td width="200">
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["EmpName"])%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span style="width: 150px;">Phone Number </span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["EmpPhoneNo"])%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="b11">
                                                                        <td align="left" width="150" class="style3">
                                                                            Address1
                                                                        </td>
                                                                        <td>
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["empAddress1"])%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span style="width: 150px;">City </span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["EmpCity"])%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="b11">
                                                                        <td width="150" align="left">
                                                                            <span style="width: 150px;">Address2 </span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["empAddress2"])%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="style3">State </span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["EmpState"])%></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="b11">
                                                                        <td align="left">
                                                                            <span style="width: 150px;">Postcode </span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["EmpPostCode"])%></span>
                                                                        </td>
                                                                    </tr>                                                                   
                                                                    <tr class="b11">
                                                                        <td align="left" colspan="3">
                                                                            <span style="width: 150px;">How long your parents/spouse been in Nigeria(In Months)
                                                                            </span>
                                                                        </td>
                                                                        <td colspan="1">
                                                                            <span class="lview">
                                                                                <%=Convert.ToString(dt.Rows[0]["EmpLivedFrom"])%></span>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <!-- edit grv second slide start-->
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!-- #third_step -->
                            <div id="third_step">
                                <img src="../Images/steps_5.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2"
                                    style="display: table; overflow: visible; padding-top: 0px; padding-bottom: 0px;"
                                    role="tabpanel">
                                    <!--edit end for grv second slide -->
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            Have You Ever applied for Nigerian Visa?
                                        </td>
                                        <td width="154" colspan="2">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagPrevApplied"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagPrevApplied1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11" id="trPrevApplied">
                                        <td colspan="2" align="left" class="style3">
                                            Previous applivation Details
                                        </td>
                                        <td colspan="2" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PrevAppliedVisaPlace"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            <span style="width: 150px;">Have You Ever Visited Nigerian ? </span>
                                        </td>
                                        <td colspan="2">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagPrevVisit"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagPrevVisit1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11" id="trVisit">
                                        <td colspan="2" align="left" class="style3">
                                            Previous Visit Details
                                        </td>
                                        <td colspan="3" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["PrevVisitReason"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            <span style="width: 150px;">Have You Ever Been Refused Visa For Nigerian ? </span>
                                        </td>
                                        <td colspan="2">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagVisaGranted"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagVisaGranted1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="745px">
                                                    <tr class="b11">
                                                        <td colspan="4" align="left">
                                                            Details for rejection
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td width="204" align="left" class="style3">
                                                            Where were you refused ?
                                                        </td>
                                                        <td width="114" align="left">
                                                            <span class="lview"  style="width: 250px;">
                                                                <%=Convert.ToString(dt.Rows[0]["PrevVisaRejReason"])%></span>
                                                        </td>
                                                        <td width="211">
                                                            <span style="width: 150px;">When did you applied ? </span>
                                                        </td>
                                                        <td width="137">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DateRejected"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">What type fo visa did you applied for? </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview" style="width: 250px;">
                                                                <%=Convert.ToString(dt.Rows[0]["LastRejectedVisaType"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">Did you appeal the decision? </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["flagRejeAppeal"])%></span>
                                                        </td>
                                                    </tr>                                                   
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">How does this application differ? </span>
                                                        </td>
                                                        <td colspan="2">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["RejectedAppDiffer"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td width="10">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>
                                    &nbsp;
                                    </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            <span style="width: 150px;">Have You Ever been refused visa for any country? </span>
                                        </td>
                                        <td colspan="2">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagRefusedAnyCountry"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagRefusedAnyCountry1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            Details for rejection
                                        </td>
                                        <td colspan="3" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["RefusedAnyCountryDetails"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            <span style="width: 150px;">Have You Ever been refused entry on arrival to the Nigeria?
                                            </span>
                                        </td>
                                        <td colspan="2">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagRefuseEntryOnArrival"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagRefuseEntryOnArrival1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="745px">
                                                    <tr class="b11">
                                                        <td colspan="4" align="left">
                                                            Specify the details for refused visa on arrival
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td width="201" align="left" class="style3">
                                                            Where did this happen ?
                                                        </td>
                                                        <td width="116" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["RefusedVisaOnArrivalPlace"])%></span>
                                                        </td>
                                                        <td width="210">
                                                            <span style="width: 150px;">When did this happen ? </span>
                                                        </td>
                                                        <td width="136">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["RefusedVisaOnArrivalDate"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Did yopu appeal the decesion? </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["flagRefusedVisArriAppeal"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">If you appealed what was the outcome </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["RefusedVisArriAppOutcome"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Why did this happen? </span>
                                                        </td>
                                                        <td colspan="2">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["RefusedVisaOnArrivalReason"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td width="13">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <!-- replace second grv-->
                                    <!--edit slide 3 by grv -->
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!-- #fourth step -->
                            <div id="fourth_step">
                                <img src="../Images/steps_6.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2"
                                    style="display: table; overflow: visible; padding-top: 0px; padding-bottom: 0px;"
                                    role="tabpanel">
                                    <!-- end edit for fourth -->
                                    <tr>
                                        <td colspan="3" align="left" class="b11">
                                            <span class="style3">How long have you lived in the country from where you are applying
                                                for visa(In Years) ? </span>
                                        </td>
                                        <td width="155">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["ApplyCountryYears"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td colspan="3" align="left" class="style3">
                                            <span style="width: 150px;">Have you ever been infected by any contagious disease(e.g
                                                Turbeculosis) or suffered serious mental illness ? </span>
                                        </td>
                                        <td colspan="2">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FlagSeriousDisease"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["FlagSeriousDisease1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="3" align="left" class="style3">
                                            Disease Details
                                        </td>
                                        <td colspan="3" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["Disease"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="3" align="left" class="style3">
                                            <span style="width: 150px;">Have you ever been arrested or convicated for an offence(even
                                                though subject to pardon)in Nigeria? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FlagCrimeRecord"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["FlagCrimeRecord1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="740px">
                                                    <tr class="b11">
                                                        <td colspan="4" align="left">
                                                            Details for convication
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td width="199" align="left" class="style3">
                                                            What was the conviction for?
                                                        </td>
                                                        <td width="121" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CrimeRecord"])%></span>
                                                        </td>
                                                        <td width="208">
                                                            <span style="width: 150px;">Please, give the date of conviction? </span>
                                                        </td>
                                                        <td width="152">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["ConvictionDate"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Where were you convicted? </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["ConvictedPlace"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">What was the sentence? </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["Sentence"])%></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="3" align="left" class="style3">
                                            <span style="width: 150px;">Have you ever been arrested or convicated for an offence(even
                                                though subject to pardon)in Other Country? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagConvictionInOtherCountry"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagConvictionInOtherCountry1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            Conviction Details
                                        </td>
                                        <td colspan="2" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["ConvictionInOtherCountry"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span class="style3">Have you ever been involved in narcotic activity? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FlagDrugReport"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["FlagDrugReport1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            Narcotic activity details
                                        </td>
                                        <td colspan="2" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["DrugReport"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="3" align="left" class="style3">
                                            <span style="width: 150px;">Have you ever been deported to Nigeria? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FlagDeported"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["FlagDeported1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="700px">
                                                    <tr class="b11">
                                                        <td colspan="4" align="left">
                                                            Details for Deported visa
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td width="199" align="left" class="style3">
                                                            When was the notice served on you?
                                                        </td>
                                                        <td width="122" align="left">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DeportedNoticeDate"])%></span>
                                                        </td>
                                                        <td width="206">
                                                            <span style="width: 150px;">What type of notice was it ? </span>
                                                        </td>
                                                        <td width="153">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DeportedNoticeType"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span style="width: 150px;">Where were you required to leave? </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DeportedLeave"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">If you appealed please give the details </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DeportedAppealeddetails"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span class="style3">Have you ever been deported to other country? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagDeportedOtherCountry"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagDeportedOtherCountry1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            Details for Deported visa
                                        </td>
                                        <td colspan="2" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["DeportedOtherCountry"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                            <span style="width: 150px;">Have you sought to obtain visa by mis-represantation or
                                                fraud? </span>
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FlagFraudRecord"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["FlagFraudRecord1"]).Trim() == "Y")
                                       { %>
                                    <tr class="b11">
                                        <td colspan="2" align="left" class="style3">
                                            Details for visa mis-represantation or fraud
                                        </td>
                                        <td colspan="2" align="left" class="style3">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["FraudRecord"])%></span>
                                        </td>
                                    </tr>
                                    <%} %>
                                </table>
                                <div class="clear">
                                </div>
                                <!-- /clearfix -->
                            </div>
                            <!-- #fifth_step-->
                            <div id="fifth_step">
                                <img src="../Images/steps_7.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2"
                                    style="display: table; overflow: visible; padding-top: 0px; padding-bottom: 0px;"
                                    role="tabpanel">
                                    <tr>
                                        <td width="548" align="left">
                                            State the period of previous visits to Nigeria and address at which you stayed<br />
                                            (If Applicable)
                                        </td>
                                        <td width="153">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagLastVisit"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagLastVisit1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="714">
                                                    <tr class="b11">
                                                        <td width="183" align="left" class="style3">
                                                            <span class="head5">Period1 </span>
                                                        </td>
                                                        <td width="143">
                                                            &nbsp;
                                                        </td>
                                                        <td width="219">
                                                            &nbsp;
                                                        </td>
                                                        <td width="149">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            From Date 
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1FromDate"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">To Date </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1ToDate"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Address 1
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1Addr1"])%></span>
                                                        </td>
                                                        <td>
                                                            Address 2
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1Addr2"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            City
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1City"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">State</span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1State1"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            <span class="style3">District</span>
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1District"])%></span>
                                                        </td>
                                                        <td>
                                                            Postcode
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit1Postcode"])%></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="694">
                                                    <tr class="b11">
                                                        <td width="187" align="left" class="style3">
                                                            <span class="head5">Period2</span>
                                                        </td>
                                                        <td width="142">
                                                            &nbsp;
                                                        </td>
                                                        <td width="204">
                                                            &nbsp;
                                                        </td>
                                                        <td width="141">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            From Date
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2FromDate"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">To Date </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2ToDate"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Address 1
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2Addr1"])%></span>
                                                        </td>
                                                        <td>
                                                            Address 2
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2Addr2"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            City
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2City"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">State</span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2State"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span class="style3">District</span>
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2District"])%></span>
                                                        </td>
                                                        <td>
                                                            Postcode
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit2Postcode"])%></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="700">
                                                    <tr>
                                                        <td width="190" align="left" class="b11">
                                                            <span class="head5">Period3</span>
                                                        </td>
                                                        <td width="138" class="b11">
                                                            &nbsp;
                                                        </td>
                                                        <td width="205">
                                                            &nbsp;
                                                        </td>
                                                        <td width="147">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            From Date
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3FromDate"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">To Date </span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3ToDate"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Address 1
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3Addr1"])%></span>
                                                        </td>
                                                        <td>
                                                            Address 2
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3Addr2"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            City
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3City"])%></span>
                                                        </td>
                                                        <td>
                                                            <span class="style3">State</span>
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3State1"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left">
                                                            <span class="style3">District</span>
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3District"])%></span>
                                                        </td>
                                                        <td>
                                                            Postcode
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["PreVisit3Postcode"])%></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </table>
                            </div>
                            <!-- #sixth_step -->
                            <div id="sixth_step">
                                <img src="../Images/steps_7.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                                    <tr class="b11">
                                        <td width="542" align="left" class="style3">
                                            Give a list of the countries you have visited in the last five(5) years(If applicable)
                                           
                                        </td>
                                        <td width="159">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagLastVisitCountries"])%></span>
                                        </td>
                                    </tr>
                                    <% if (Convert.ToString(dt.Rows[0]["flagLastVisitCountries1"]).Trim() == "Y")
                                       { %>
                                    <tr>
                                        <td colspan="4">
                                            <div id="ctl00_ContentPlaceHolder1_pnlLastVisitCountries1">
                                                <table width="708">
                                                    <tr class="b11">
                                                        <td width="195" align="left" class="style3">
                                                            <span class="head5">Period1 </span>
                                                        </td>
                                                        <td width="144" class="b11">
                                                            &nbsp;
                                                        </td>
                                                        <td width="197">
                                                            &nbsp;
                                                        </td>
                                                        <td width="152">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Country
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CountryName5"])%></span>
                                                        </td>
                                                        <td>
                                                            City
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CityName1"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Date Of Departure
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DepartureDate1"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="650px">
                                                    <tr class="b11">
                                                        <td width="199" align="left" class="style3">
                                                            <span class="head5">Period2 </span>
                                                        </td>
                                                        <td width="122" class="b11">
                                                            &nbsp;
                                                        </td>
                                                        <td width="208">
                                                            &nbsp;
                                                        </td>
                                                        <td width="101">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Country
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CountryName6"])%></span>
                                                        </td>
                                                        <td>
                                                            City
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CityName2"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Date Of Departure
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DepartureDate2"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            &nbsp;
                                                        </td>
                                                        <td class="b11">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <table width="650px">
                                                    <tr class="b11">
                                                        <td width="199" align="left" class="style3">
                                                            <span class="head5">Period3 </span>
                                                        </td>
                                                        <td width="124" class="b11">
                                                            &nbsp;
                                                        </td>
                                                        <td width="210">
                                                            &nbsp;
                                                        </td>
                                                        <td width="97">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Country
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CountryName7"])%></span>
                                                        </td>
                                                        <td>
                                                            City
                                                        </td>
                                                        <td>
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["CityName3"])%></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            Date Of Departure
                                                        </td>
                                                        <td class="b11">
                                                            <span class="lview">
                                                                <%=Convert.ToString(dt.Rows[0]["DepartureDate3"])%></span>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr class="b11">
                                                        <td align="left" class="style3">
                                                            &nbsp;
                                                        </td>
                                                        <td class="b11">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </table>
                            </div>
                            <!-- #seventh_step -->
                            <div id="seventh_step">
                                <img src="../Images/steps_7.jpg" />
                                <table width="730" cellspacing="3" cellpadding="5" border="0" class="BackGround2">
                                    <tr class="b11">
                                        <td colspan="3" align="left">
                                           Give a list of the countries you have lived for more then one year(If Applicable)
                                           
                                        </td>
                                        <td width="156">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["flagLastLived"])%></span>
                                    </tr>
                                </table>
                        </td>
                    </tr>
                    <% if (Convert.ToString(dt.Rows[0]["flagLastLived1"]).Trim() == "Y")
                       { %>
                    <tr>
                        <td colspan="4">
                            <div id="ctl00_ContentPlaceHolder1_pnlLastLived1">
                                <table width="728">
                                    <tr class="b11">
                                        <td width="217" align="left" class="style3">
                                            <span class="head5">Period1 </span>
                                        </td>
                                        <td width="144" class="b11">
                                            &nbsp;
                                        </td>
                                        <td width="181">
                                            &nbsp;
                                        </td>
                                        <td width="166">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Country
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CountryName8"])%></span>
                                        </td>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LastLivedCityName1"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Date Of Departure
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LastLivedDepartureDate1"])%></span>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div>
                                <table width="729">
                                    <tr class="b11">
                                        <td width="221" align="left" class="style3">
                                            <span class="head5">Period2 </span>
                                        </td>
                                        <td width="144" class="b11">
                                            &nbsp;
                                        </td>
                                        <td width="179">
                                            &nbsp;
                                        </td>
                                        <td width="165">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Country
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CountryName9"])%></span>
                                        </td>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LastLivedCityName2"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Date Of Departure
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LastLivedDepartureDate2"])%></span>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div>
                                <table width="650px">
                                    <tr class="b11">
                                        <td width="225" align="left" class="style3">
                                            <span class="head5">Period3 </span>
                                        </td>
                                        <td width="143" class="b11">
                                            &nbsp;
                                        </td>
                                        <td width="178">
                                            &nbsp;
                                        </td>
                                        <td width="84">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Country
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["CountryName10"])%></span>
                                        </td>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LastLivedCityName3"])%></span>
                                        </td>
                                    </tr>
                                    <tr class="b11">
                                        <td align="left" class="style3">
                                            Date Of Departure
                                        </td>
                                        <td class="b11">
                                            <span class="lview">
                                                <%=Convert.ToString(dt.Rows[0]["LastLivedDepartureDate3"])%></span>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <%--<asp:Button ID="btnConfirm" runat="server" CssClass="open1 nextbutton" Text="Confirm & Make Payment"
                                OnClick="btnConfirm_Click" ValidationGroup="a" />--%>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="open1 nextbutton" Text="Update"
                                OnClick="btnUpdate_Click" ValidationGroup="a" Visible=false />
                        </td>
                        <td>
                        </td>
                    </tr>
            </table>
            <%} %>
        </div>
        <!-- edit start for first floating div GRV-->
        <div class="clear">
        </div>
        <!-- /clearfix -->
    </div>
    </form>
</body>
</html>
