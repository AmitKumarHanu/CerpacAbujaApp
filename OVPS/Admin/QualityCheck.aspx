<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="QualityCheck.aspx.cs" Inherits="Admin_QualityCheck" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../css/country.css" rel=Stylesheet type="text/css" /> 
    <script type="text/javascript" language="javascript">

        function flashit() {

            var myexample = document.getElementById('my');
            if (myexample.style.borderColor == "blue")
                myexample.style.borderColor = "red";
            else
                myexample.style.borderColor = "blue";


        }
        setInterval('flashit()', 500);

    </script><script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script><script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script><link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" /><link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" /><link href="../css/scanpage.css" rel=Stylesheet type="text/css" /><link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /><link href="../css/style.css" rel=Stylesheet type="text/css" /><style type="text/css">
    .abc
    {text-decoration:blink;
        }
    </style><style type="text/css"> 
<!-- 
.popup { 
      background-color: #DDD; 
      height: 300px; width: 500px; 
      border: 5px solid #666; 
      position: absolute; visibility: hidden; 
      font-family: Verdana, Geneva, sans-serif; 
      font-size: small; text-align: justify; 
      padding: 5px; overflow: auto; 
      z-index: 2; 
} 
.popup_bg { 
      position: absolute; 
      visibility: hidden; 
      height: 200%; width: 100%; 
      left: 0px; top: 0px; 
      filter: alpha(opacity=70); /* for IE */ 
      opacity: 0.7; /* CSS3 standard */ 
      background-color: #999; 
      z-index: 1; 
} 
       .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .information-box, .confirmation-box, .error-box, .warning-box {
	padding: 0.833em 0.833em 0.833em 3em; /* 10/12 36/12 */
	margin-bottom: 0.833em; /* 20/12 */ }

.confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
	align:center;
    font-size: 18px;
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #b28a0b;
}
.close_button { 
      font-family: Verdana, Geneva, sans-serif; 
      font-size: small; font-weight: bold; 
      float: right; color: #666; 
      display: block; text-decoration: none; 
      border: 2px solid #666; 
      padding: 0px 3px 0px 3px; 
} 
body { margin: 0px; } 
    .auto-style2 {
        width: 190px;
        height: 18px;
    }
--> 
</style><script language="javascript">
    function openpopup(id) {
        //Calculate Page width and height 
        var pageWidth = window.innerWidth;
        var pageHeight = window.innerHeight;
        if (typeof pageWidth != "number") {
            if (document.compatMode == "CSS1Compat") {
                pageWidth = document.documentElement.clientWidth;
                pageHeight = document.documentElement.clientHeight;
            } else {
                pageWidth = document.body.clientWidth;
                pageHeight = document.body.clientHeight;
            }
        }
        //Make the background div tag visible... 
        var divbg = document.getElementById('bg');
        divbg.style.visibility = "visible";

        var divobj = document.getElementById(id);
        divobj.style.visibility = "visible";
        if (navigator.appName == "Microsoft Internet Explorer")
            computedStyle = divobj.currentStyle;
        else computedStyle = document.defaultView.getComputedStyle(divobj, null);
        //Get Div width and height from StyleSheet 
        var divWidth = computedStyle.width.replace('px', '');
        var divHeight = computedStyle.height.replace('px', '');
        var divLeft = (pageWidth - divWidth) / 2;
        var divTop = (pageHeight - divHeight) / 2 + 500;
        //Set Left and top coordinates for the div tag 
        divobj.style.left = divLeft + "px";
        divobj.style.top = divTop + "px";
        //Put a Close button for closing the popped up Div tag 
        if (divobj.innerHTML.indexOf("closepopup('" + id + "')") < 0)
            divobj.innerHTML = "<a href=\"#\" onclick=\"closepopup('" + id + "')\"><span class=\"close_button\">X</span></a>" + divobj.innerHTML;
    }
    function closepopup(id) {
        var divbg = document.getElementById('bg');
        divbg.style.visibility = "hidden";
        var divobj = document.getElementById(id);
        divobj.style.visibility = "hidden";
    } 

</script><strong></strong><div id="popup1" class="popup" >
			<table  id="tab1" width="100%">
				<tr>
					<td colspan="5" style="text-align: center">
						<%--<asp:Label ID="lbl_heading" runat="server" Text="Reason of Re-Print" Font-Bold="true"></asp:Label>--%>

                         <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Rejection Reason &nbsp; </span>
                        </font>
                    </div>
					</td>

                    

                   
				</tr>
				<tr>
					<td>
						
						<%--<a href="#" onclick="hide('popDiv')">Close</a>--%>


					</td>

                    <td></td>
                    <td></td>
                    <td></td>

                    <td></td>
				</tr>

                <%-- <tr>
                 <td></td>
                <td >
                    
                 <asp:Label ID="lbl_reprint_card_serial_no" runat="server" Text="Cerpac Card Serial No." Font-Bold="true"></asp:Label>

                 
                </td>
                   <td style="font-weight:bold;">:</td>
<td><asp:Label ID="txt_reprint_card_serial_no" runat="server"></asp:Label></td>
<td></td>
                </tr>--%>

                <tr>
                <td></td>
                <td valign="top"><asp:Label ID="lbl_reason" runat="server" Text="Rejection Reason" Font-Bold="true"></asp:Label></td>

                <td style="font-weight:bold;"></td>

                <td>

                <%--<asp:TextBox ID="txt_reason" runat="server" TextMode="MultiLine" Height="66px" 
                        Width="305px"></asp:TextBox>
--%>
                    <asp:RadioButton ID="Rd1" runat="server" GroupName="AB" Text="Printing Error" Checked="true"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd2" runat="server" GroupName="AB" Text="Chip Encoding Error"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd3" runat="server" GroupName="AB" Text="Lamination Error"/>
                    <br />
                    <br />

                    <asp:RadioButton ID="Rd4" runat="server" GroupName="AB" Text="Others"/>
                
                
                        
                        </td>

                <td></td>
                <td></td>
                </tr>

                <tr>
					<td></td>

                    <td></td>
                    <td></td>
                    <td colspan="2">
                    
                    <asp:Button ID="btn_Reason_Print" runat="server"  
                        Text="Ok" class="adminbutton" onclick="btn_Reason_Print_Click" TabIndex="9" UseSubmitBehavior="false"/>
                       <%-- <input type="button" id="btn_Reason_Print" runat="server"  value="Ok" class="adminbutton" onclick="btn_Reason_Print_Click"/>--%>
                        &nbsp;&nbsp;&nbsp;

                        <%--<asp:Button ID="btn_cancel" runat="server"  
                        Text="Cancel" class="adminbutton" />
--%>
                        
                        <input type="button" id="btn_cancel" runat="server"  value="Cancel" class="adminbutton" onclick="closepopup('popup1')"/>

                    </td>
                    <td></td>

                    <td></td>
				</tr>

			</table>
		</div>

        <div id="bg" class="popup_bg" style="left: 5px; top: 258px;"></div>



    <div align="center" class="bcolour" id="combox">
        <table cellpadding="2" cellspacing="10" style="width: 95%" >
            <tr>
                <td colspan="6" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Quality Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td height="15"></td></tr>
            <tr id="tr_msg" runat="server"><td align="center" style="visibility:hidden">
            <asp:Label ID="lblmsg" runat="server" CssClass="information-box abc" Text = "Please Enter CERPAC No./Secured Sold Form No. of the applicant" Font-Size="Small" ></asp:Label>
            </td>
            </tr>
            <%--<tr><td height="10px"></td></tr>--%>
            <tr>
                <td align="center" >

                    <table class="t11" style="width: 100%;"  id="tblsearch" runat="server">
                        <tr>
                            <td align="center" style="height: 16px; width: 150px;">
                              <strong>  CERPAC No/Secured Sold Form No.</strong> &nbsp;&nbsp;
                               
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px" TabIndex="1"></asp:TextBox>
    
   
    &nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" TabIndex="2" />

    
                                </td>
                        </tr>
                      
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">

                            </td>
                        </tr>
                       
                    </table>
                    <table class="t11" style="width: 100%;" id="tblgrdview" runat="server" >
                    <tr>
<td colspan="3">

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="false" AllowPaging="true" PageSize="5"  CssClass="GridBaseStyle" PagerStyle-CssClass="pgr"
 DataKeyNames="CerpacNo" OnPageIndexChanging="grd_display_data_PageIndexChanging"  OnRowEditing="grd_display_data_RowEditing" OnRowCreated="grd_display_data_RowCreated" OnSelectedIndexChanged="grd_display_data_SelectedIndexChanged"      >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>
<%--<asp:TemplateField>
 <ItemTemplate>
            <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>'/>

        </ItemTemplate>

    </asp:TemplateField>
   --%>

    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" SortExpression="MiddleName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="Company" Visible="false" HeaderText="Company Name" SortExpression="Company" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="CerpacNo" HeaderText="Cerpac No." SortExpression="CerpacNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="FormNo" HeaderText="FRN No." SortExpression="FormNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <%--<asp:BoundField DataField="TellerNo" HeaderText="Teller No" SortExpression="TellerNo"/>

    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"/>

    <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>
    <asp:BoundField DataField="PassportNo" HeaderText="Passport No." SortExpression="PassportNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:TemplateField HeaderText=""  ControlStyle-ForeColor="Black">
                                    <ItemTemplate >
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                    <HeaderTemplate><asp:CheckBox ID="chkselectall" runat="server" Text=""
                                             OnCheckedChanged="chkAccessAll_CheckedChanged" AutoPostBack="true" /></HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" />
                                </asp:TemplateField>
    <asp:CommandField HeaderText="View" ShowEditButton="True" ButtonType="Image" EditImageUrl="~/Images/Edit-icon.PNG" Visible="false">
                                <ControlStyle CssClass="button" />
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <HeaderStyle  HorizontalAlign="Center" Width="10%" />
                            </asp:CommandField>

     

    <%--<asp:TemplateField HeaderText="Row Inserted">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>


   <%-- </ContentTemplate></asp:UpdatePanel>--%>

</td>
    
</tr>
                        <tr><td colspan="3"><asp:Button ID="btnok" runat="server" Text="Card Ok" CssClass="adminbutton" OnClick="btnok_Click" />&nbsp;&nbsp;&nbsp;

                            
                    </td></tr>
                    </table>

                    

                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="detailtable" runat="server">
                            <tr class="b77"  style="display:none;">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Passport Details</strong>
                                </td>
                            </tr>
                            <tr class="t11"  style="display:none;">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr class="b55"  style="display:none;">
                                <td align="left" style="width: 150px;">
                                    Passport Issue By
                                </td>
                                <td align="left" style="width: 190px;" class="b99">
                                    <asp:Label ID="TxtPassportType" runat="server"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Date Of Issue
                                </td>
                                <td align="left" style="width: 190px" class="b99">
                                    <asp:Label ID="TxtDateOfIssue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="b55"  style="display:none;">
                             <td align="left" style="width: 150px;">
                             Date of Expiry
                                </td>
                                <td align="left" style="width: 150px;" class="b99">
                                <asp:Label ID="txtdoe" runat="server"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Place of Issue
                                </td>
                                <td align="left" style="width: 190px;" class="b99">
                                    <asp:Label ID="TxtPlaceOfIssue" runat="server"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <<tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Personalize Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    First Name
                                </td>
                                <td align="left" style="width: 190px;" class="b99">
                                    <asp:Label ID="TxtFirstName" runat="server"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Last Name
                                </td>
                                <td align="left" style="width: 190px;" class="b99">
                                    <asp:Label ID="TxtLastName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Middle Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtMiddleName" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Sex
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtSex" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Email Id
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtemailprsn" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Contact Number
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcntcnoprsn" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                             <tr >
                                <td align="left" class="b55"  >
                                    Passport No.
                                </td>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="TxtPassportNo" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" class="b55">
                                    Nationality
                                </td>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="TxtNationality" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                              <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Bank Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    First Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtbankfname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Last Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtbanklname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Middle Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtbankmname" runat="server" CssClass="b99"></asp:Label>
                                </td>
                                
                            </tr>
                             <tr class="b77"><td height="5" colspan="4"></td></tr>
                            <tr class="b77"  style="display:none;">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Cerpac Details</strong>
                                </td>
                            </tr>
                            <tr class="t11"  style="display:none;">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr   style="display:none;">
                                <td align="left" style="width: 150px;" class="b55">
                                    Cerpac Number
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtCerpacNo" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Cerpac Issue Date
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtIssueDate" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr   style="display:none;">
                                <td align="left" style="width: 150px;" class="b55">
                                    Cerpac Expiry Date
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtExpDate" runat="server" class="b99"></asp:Label>
                                </td>
                                 <td align="left" style="width: 150px;" class="b55">
                                    Cerpac File No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtfileno" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr class="t11"  style="display:none;">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                              <tr class="b77"  style="display:none;">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Company Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr  style="display:none;">
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Id
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompid" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompname" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr  style="display:none;">
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Address 1
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompadd1" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Address 2
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtcompadd2" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr   style="display:none;">
                                <td align="left" style="width: 150px;" class="b55">
                                    Designation
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtdesig" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Telephone No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtphno" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr  style="display:none;">
                                <td align="left" class="b55" style="width: 150px;">
                                    Company Fax No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtfaxno" runat="server" class="b99"></asp:Label>
                                </td>
                                
                            </tr>

                            <tr>

                                <td colspan="4">
                                    <center>
                        <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="100px" 
                            style="height: 355px">
                            <tr class="b11" align="center">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;" >
                                  
                                  <div style="background-image: url('../Images/front1.png'); height: 350px; width: 564px; border: 1px solid black; background-repeat:no-repeat;" align="right">
                                      <br />
                                      <br />
                                      <br />
                                      <br />
                                    <br />
                                 
                                  <table style="width: 71%;">
                                     
                                     <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left;color:darkgreen; ">
                                  Name
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left; width:700px;">
                                <span class="blkn" style="width:400px;">  <asp:Label ID="lbl_name" runat="server"  Text="PIA ANGELA"></asp:Label>

                                    </span>
                                      </td>
                                 
                                  
                                 
                                  </tr> 
                                  <tr>
                                  <td style="width: 128px;">&nbsp;
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       </td>
                                  <td style="text-align: left; margin-right:440px; color:darkgreen;">
                                  Passport No.
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td align="left">
                                <span class="blkn" style="width:400px;">  <asp:Label ID="lbl_passport" runat="server" Text="745698213" >

                                  </asp:Label>
                                    </span>  
                                    </td>
                                 
                                  
                                 
                                  </tr>

                                  
                                   <tr style="display:none;">
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  DOB
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr style="display:none;">
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                    <span class="blkn" style="width:400px;">   <asp:Label ID="lbl_dob" runat="server" Text="05.07.1978" style="color: #FFFFFF"></asp:Label></span>
                                      </td>
                                 
                                  
                                 
                                  </tr>


                                        <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left;color:darkgreen;">
                                  Nationality
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                   <span class="blkn" style="width:400px;">  <asp:Label ID="lbl_nationality" runat="server" Text="UTOPIA"></asp:Label>
                                   </span>
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                        <tr>
          <td style="width: 128px"></td>
     <td style="text-align: left;color:darkgreen;">
                                  Company
                                  </td>
  
    </tr>
    <tr>

         <td style="width: 128px"></td>

         <td style="text-align: left">

              <asp:Label ID="txt_comps" runat="server" Text=""  Font-Bold="true"></asp:Label>
         </td>
    </tr>
                                   <tr>
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left;color:darkgreen;">
                                  Designation
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                 <span class="blkn" style="width:400px;">     <asp:Label ID="lbl_desig" runat="server" CssClass="blkn" Text="56982145"></asp:Label>
                                    </span>
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                 
                                   <tr style="display:none;">
                                   <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  SIGNATURE
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr style="display:none;">
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">

                                      <span class="blkn" style="width:400px;">
                                   <asp:Label ID="lbl_sig" runat="server" Text="" style="color: #FFFFFF"></asp:Label>
                                          </span>
                                  
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                  </table>
                                  
                                  </div>
                                </td>
                            </tr>
                        </table>
                        </center>

                                </td>
                            </tr>


                            <tr>

                                <td colspan="4">

                                    <center>
                        <table id="Table1" cellpadding="5" cellspacing="2" border="0" width="100px" 
                            style="height: 355px">
                            <tr class="b11">
                                <td align="right" style="width: 10%; vertical-align: middle; text-align: center;">
                                  
                                  <div style="background-image: url('../Images/back1.png'); height: 350px; width: 564px; border: 1px solid black; background-repeat:no-repeat;" align="center">
                                     <div id="container" style="position:relative;">
                                        <asp:Image ID="ImgPhoto" runat="server" Style="position:absolute; top: -270px;left: 112px; height: 163px; width: 149px;" />
                                         </div>
                                        <br />
                                      <br />
                                      <br />
                                      <br />
                                    <br />
                                 
                                  <table style="width: 53%;">
                                     
                                     
                                  <tr>
                                  <td style="width: 228px;" colspan="2" align="left">Authorized Signatory     
                                  </td>
                                  
                                 
                                  </tr>
                                  
                                  <tr>
                                 
                                  <td style="text-align: center" colspan="2" class="auto-style1">
                               <br />
                                      <asp:Image ID="img_sign" runat="server" Height="37px" Width="174px"/>
                                 <br />
                                      <br />
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                       <tr>
                                 
                                  <td style="text-align: left" colspan="2" class="auto-style1">
                                 <asp:Label ID="Label4" runat="server" Text="For Comptroller-General, Nigeria Immigration Service" Font-Size="XX-Small"></asp:Label>
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px" align="left">Cerpac No.</td>
                                  <td style="text-align: left" align="left">
                                      <span class="blkn">
<asp:Label ID="lbl_cerpac_no" runat="server" Text="" ></asp:Label>
</span>                                  
                                  </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                  
                                      </td>
                                 
                                  
                                 
                                  </tr>
                                   <tr>
                                   <td style="width: 128px" align="left">Date Of Issue</td>
                                  <td style="text-align: left" align="left">
                                      <span class="blkn">
                                  <asp:Label ID="lbl_date_of_issue" runat="server" Text="" ></asp:Label>
                                 
                                          </span> </td>
                                 
                                  </tr>
                                  
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                   <tr>
                                   <td style="width: 128px" align="left">Place Of Issue</td>
                                  <td style="text-align: left" align="left">
                                         <span class="blkn">
                                  <asp:Label ID="lbl_place_of_issue" runat="server"></asp:Label>
                                                </span>
                                  </td>
                                 
                                  </tr>
                                  
                                      
                                  <tr>
                                  <td style="width: 128px"></td>
                                  <td style="text-align: left">
                                    
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                  <tr>
                                  <td style="width: 128px" align="left">Date Of Expiry</td>
                                  <td style="text-align: left" align="left">
                                         <span class="blkn">
                                   <asp:Label ID="lbl_expiry_date" runat="server" Text=""></asp:Label>
                                    </span>
                                      </td>
                                 
                                  
                                 
                                  </tr>

                                  
                                  
                                  </table>
                                  
                                  </div>
                                </td>
                            </tr>
                        </table>
                        </center>
                                </td>
                            </tr>
                             
            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                </td>
            </tr>
            <tr class="b11">
                <td align="center" colspan="4">
                    <asp:Button ID="btnCardOk" runat="server" class="adminbutton" Text="Card OK"  
                        Width="140px" onclick="btnCardOk_Click" TabIndex="3" />
                    
                    <%--<asp:Button ID="btnCardReject" runat="server" class="adminbutton" Text="Card Reject" Width="140px"  OnClick="openpopup('popup1')" />--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCardReject" runat="server"  value="Card Reject" class="adminbutton" onclick="openpopup('popup1')" tabindex="4" />
                   

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:Button ID="btn_read" runat="server" Text="Read Chip" CssClass="adminbutton" OnClick="btn_read_Click" />

                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btn_back" runat="server" class="adminbutton" 
                        Text="Back" OnClick="btn_back_Click" />
                </td>
            </tr>
            <tr><td height="25px" colspan="4"></td></tr>
        </table>
        
         <tr><td align="center"><div class="confirmation-box" height="10px" style="display:none;" id="confirm"  runat="server"><p style="color:#006600"><strong>Verified</strong> </p></div></td></tr>
        <tr><td align="center"><div class="warning-box" height="10px" style="display:none;" id="warn"  runat="server"><p style="color:#A0522D"><strong> Cerpac Number has not been produced or not exist.</strong> </p></div></td></tr>
                </td>
            </tr>
        </table>
    </div>
       <script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
    <SCRIPT>
        $("#accordion > li > div").click(function () {

            if (false == $(this).next().is(':visible')) {
                $('#accordion ul').slideUp(300);
            }
            $(this).next().slideToggle(300);
        });

        $('#accordion ul:eq(0)').show();

</SCRIPT>
<script type="text/javascript">
    var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: 0 });


    </script>

</asp:Content>