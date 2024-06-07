<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_frmViewAppHistory, App_Web_frmviewapphistory.aspx.fdf7a39c" enableeventvalidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

        
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

    </style>
    <script type="text/javascript">
        
         function PlnameAllowAlphabet() {
             var Forename = document.getElementById("<%=txtForename.ClientID%>").value;
             var Fore = document.getElementById("<%=txtForename.ClientID%>");
             if (!Fore.value.match(/^[a-z A-Z]+$/) && Fore.value != "") {
                 Fore.value = "";
                 Fore.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }

         function AllowAlphabet() {
             var Surname = document.getElementById("<%=txtSurname.ClientID%>").value;
             var Sur = document.getElementById("<%=txtSurname.ClientID%>");
             if (!Sur.value.match(/^[a-z A-Z]+$/) && Sur.value != "") {
                 Sur.value = "";
                 Sur.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
         </script>

     <div align="center" class="bcolour">
        <table cellpadding="2" cellspacing="10" style="width: 95%"  id="combox" >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Applicant History &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td height="15"></td></tr>
           
            <tr><td height="10px"></td></tr>
            <tr>
                <td align="center">
                      <table class="t11" style="width: 100%;" >


                           <tr id="tr1" runat="server" >
                            <td align="left" style="height: 16px; width: 150px;">
                              <strong> SurName</strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtSurname" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" onkeyup="AllowAlphabet()" onkeydown="AllowAlphabet()"  CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                              
                              
                            </td>


                                <td align="left" style="height: 16px; width: 150px;">
                              <strong> ForeName</strong> &nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtForename" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2" onkeyup="PlnameAllowAlphabet()" onkeydown="PlnameAllowAlphabet()"
                                    Height="20px"></asp:TextBox>
                              
                              
                            </td>
                        </tr>

                        <tr id="tr_ser" runat="server" >
                            <td align="left" style="height: 16px; width: 150px;">
                              <strong> 

                                <asp:DropDownList ID="dropdown_SearchOption" runat="server" Height="25px"  BackColor="#bcc7d8" ForeColor="#333333"
                                    Width="149px" Font-Bold="true">
                                    <asp:ListItem Value="Cerpac_No">Cerpac No.</asp:ListItem>
                                    <asp:ListItem Value="cerpac_file_no">Secured Form No.</asp:ListItem>
                                    <asp:ListItem>Company</asp:ListItem>
                                    <asp:ListItem>Nationality</asp:ListItem>
                                </asp:DropDownList></strong> 
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>
                               
                                
                            </td>
                            <td><asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" /></td>
                        </tr>
                      
                          <tr id="tr_ser1" runat="server">
                            <td align="left" style="height: 16px;" colspan="2">
                                 <strong> Search Criteria</strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:RadioButton ID="Rd1Match" runat="server" Text="Match Field" GroupName="a" Checked="true"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="Rd2Start" runat="server" Text="Start Of Field" GroupName="a"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="Rd3Any" runat="server" Text="Any Part Of Field" GroupName="a"/>
                            </td>

                             
                        </tr>

                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">

                            </td>
                        </tr>
                       
                    </table>
                    <table class="t11" style="width: 100%;" >
                    <tr>
<td valign="top" align="center" style="width: 100%; text-align: left;">


    <div id="div_grd" runat="server">
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="False"  
        AllowPaging="True" PageSize="10"  CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7"
        Width="100%" onpageindexchanging="grd_display_data_PageIndexChanging" 
            onrowcreated="grd_display_data_RowCreated" onselectedindexchanged="grd_display_data_SelectedIndexChanged"
        >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>


    <asp:BoundField DataField="forename" HeaderText="First Name" SortExpression="forename" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

   <%-- <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" SortExpression="MiddleName" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>--%>

    <asp:BoundField DataField="surname" HeaderText="Last Name" SortExpression="surname" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="Company" HeaderText="Company Name" SortExpression="Company" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

  

    <asp:BoundField DataField="cerpac_no" HeaderText="Cerpac No." SortExpression="cerpac_no" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

    <asp:BoundField DataField="cerpac_file_no" HeaderText="FRN No." SortExpression="cerpac_file_no" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

  
    <asp:BoundField DataField="passport_no" HeaderText="Passport No." SortExpression="passport_no" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

   <%-- <asp:BoundField DataField="StrVisaNo" HeaderText="Str Visa No." SortExpression="StrVisaNo" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

     

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>--%>

       <asp:BoundField DataField="cerpac_receipt_date"  
        HeaderText="Cerpac Issue Date" SortExpression="cerpac_receipt_date" 
        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" 
        DataFormatString="{0:d}">

     

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>


      <asp:BoundField DataField="cerpac_expiry_date" HeaderText="Cerpac Expiary Date" SortExpression="cerpac_expiry_date" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" Visible="false">

     

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
    </asp:BoundField>

  

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>

</div>
   

</td>
    
</tr>
                    
                    </table>

                  

                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="detailtable" runat="server" style="display:none;">

                             <tr class="b11">
                                <td align="center" style="width: 10%; vertical-align: middle; text-align: center;
                                    background-repeat: no-repeat;" colspan="4">
                                    <asp:Image runat="server" ID="ImgPhoto" Width="100px" Height="120px" ImageUrl="~/Images/Logo/default_logo.gif" />
                                </td>
                            </tr>

                            <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Passport Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55" >
                                    Passport No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtPassportNo" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Nationality
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtNationality" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 150px;" class="b55">
                                    Passport Issue By
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtPassportType" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Date Of Issue
                                </td>
                                <td align="left" style="width: 190px">
                                    <asp:Label ID="TxtDateOfIssue" runat="server" class="b99"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                             <td align="left" style="width: 150px;" class="b55">
                             Date of Expiry
                                </td>
                                <td align="left" style="width: 150px;">
                                <asp:Label ID="txtdoe" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Place of Issue
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtPlaceOfIssue" runat="server" class="b99"></asp:Label>
                                </td>
                               
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <<tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Personal Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 150px;" class="b55">
                                    First Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtFirstName" runat="server" class="b99"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px;" class="b55">
                                    Last Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtLastName" runat="server" class="b99"></asp:Label>
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
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Cerpac Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr >
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
                            <tr >
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
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                              <tr class="b77">
                                <td colspan="4" align="left" class="t55">
                                    <strong>Company Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="3" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                                <td align="left" runat="server" id="oldcompanyname"></td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Code
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
                            <tr >
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
                            <tr >
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
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Company Fax No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtfaxno" runat="server" class="b99"></asp:Label>
                                </td>
                                
                            </tr>
                             
            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                </td>
            </tr>
            <tr class="b11">
                <td align="center" colspan="4">

                     <asp:Button ID="btn_back" runat="server" class="adminbutton" 
                        Text="Back" OnClick="btn_back_Click"/>&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnapphis" runat="server" CssClass="adminbutton" Text="Applicant History" OnClick="btnapphis_Click"/>
                    
                </td>
            </tr>
            <tr><td height="25px"></td></tr>
        </table>
         <tr><td align=center><div class="confirmation-box" height="10px" style="display:none;" id="confirm"  runat="server"><p style="color:#006600"><strong> Updated Sucessfully</strong></p></div></td></tr>
        <tr><td align=center><div class="warning-box" height="10px" style="display:none;" id="warn"  runat="server"><p style="color:#A0522D"><strong>Cerpac Number has not been verified or not exist.</strong></p></div></td></tr>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

