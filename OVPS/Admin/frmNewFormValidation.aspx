<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="frmNewFormValidation.aspx.cs" Inherits="Admin_frmNewFormValidation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Import Namespace="System.Data" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link rel="Stylesheet" type="text/css" href="../css/animate-custom.css" />
    <link href="Scripts/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-latest.js" type="text/javascript"></script>
    <script src="Scripts/thickbox.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.autocomplete.pack.js" type="text/javascript"></script>
    <script src="Scripts/jquery.autocomplete.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.autocomplete.js" type="text/javascript"></script>




    <%--    --loader CSS-----%>
    <style type="text/css">
        .LockOn {
            display: block;
            visibility: visible;
            position: absolute;
            z-index: 999;
            top: 0px;
            left: 0px;
            width: 105%;
            height: 105%;
            background-color: white;
            vertical-align: bottom;
            padding-top: 20%;
            filter: alpha(opacity=75);
            opacity: 0.75;
            font-size: large;
            color: blue;
            font-style: italic;
            font-weight: 400;
            background-image: url("../images/loading.gif");
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-position: center;
        }
    </style>

    <script type="text/javascript">

        $(function () {
            $(document).ready(function () {



                var today = new Date();

                $("[id$=txtDOB]").datepicker({
                    dateFormat: 'yy-mm-dd',
                    changeMonth: true,
                    changeYear: true,
                    autoclose: true,
                    endDate: "today",
                    maxDate: today,
                    yearRange: '-115:+10',
                    beforeShow: function () {
                        setTimeout(function () {
                            $('.ui-datepicker').css('z-index', 99999999999999);

                        }, 0);
                    },
                    onSelect: function (selected, evnt) {
                        $("[id$=hdnDOB]").val(selected);
                    }
                }).on('changeDate', function (ev) {
                    $(this).datepicker('hide');

                });

                $("[id$=txtDOB]").keyup(function () {
                    if (this.value.match(/[^0-9]/g)) {
                        this.value = this.value.replace(/[^0-9^-]/g, '');
                    }

                });
            });
        }
    </script>


    <script type="text/javascript">

        $(function () {
            $(document).ready(function () {



                var today = new Date();

                $("[id$=txtADate]").datepicker({
                    dateFormat: 'yy-mm-dd',
                    changeMonth: true,
                    changeYear: true,
                    autoclose: true,
                    endDate: "today",
                    maxDate: today,
                    yearRange: '-115:+10',
                    beforeShow: function () {
                        setTimeout(function () {
                            $('.ui-datepicker').css('z-index', 99999999999999);

                        }, 0);
                    },
                    onSelect: function (selected, evnt) {
                        $("[id$=hdnADate]").val(selected);
                    }
                }).on('changeDate', function (ev) {
                    $(this).datepicker('hide');

                });

                $("[id$=txtADate]").keyup(function () {
                    if (this.value.match(/[^0-9]/g)) {
                        this.value = this.value.replace(/[^0-9^-]/g, '');
                    }

                });
            });
        }
    </script>


    <script type="text/javascript">

        $(function () {
            $(document).ready(function () {



                var today = new Date();

                $("[id$=txtDDate]").datepicker({
                    dateFormat: 'yy-mm-dd',
                    changeMonth: true,
                    changeYear: true,
                    autoclose: true,
                    endDate: "today",
                    maxDate: today,
                    yearRange: '-115:+10',
                    beforeShow: function () {
                        setTimeout(function () {
                            $('.ui-datepicker').css('z-index', 99999999999999);

                        }, 0);
                    },
                    onSelect: function (selected, evnt) {
                        $("[id$=hdnDDate]").val(selected);
                    }
                }).on('changeDate', function (ev) {
                    $(this).datepicker('hide');

                });

                $("[id$=txtDDate]").keyup(function () {
                    if (this.value.match(/[^0-9]/g)) {
                        this.value = this.value.replace(/[^0-9^-]/g, '');
                    }

                });
            });
        }
    </script>

    
<script type="text/javascript">

         function ShowImage(input) {
                if (input.files && input.files[0]) {

                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=imgVISA.ClientID%>').prop('src', e.target.result)
                            .width(125)
                            .height(160);
                    };
                    reader.readAsDataURL(input.files[0]);

                }
            }
</script>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <div id="coverScreen" class="LockOn"></div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <Triggers>

            <asp:PostBackTrigger ControlID="GridNDetails" />
            <asp:PostBackTrigger ControlID="Proceed" />
            <asp:PostBackTrigger ControlID="btnSubmit" />
         
  
        </Triggers>
        <ContentTemplate>


            <%--<div align="center" class="bcolour" id="combox" style="margin: 2px, 2px; padding: 2px; width: 98%; overflow-y: hidden; overflow-x: auto; font-size: small;">--%>
            <div align="center" class="bcolour" id="combox" style="margin: 2px, 2px; padding: 2px; width: 98%; overflow-y: hidden; overflow-x: hidden; font-size: small;">
                <panel id="pnlHeader" runat="server">
                    <table cellpadding="2" cellspacing="10" style="width: 95%">
                        <tr>
                            <td colspan="3" style="height: 5px">
                                <div class="PageNameHeadingCSS" style="text-align: center">
                                    <font class="b12"><span style="font-size: 16px; color: White;">&nbsp;Application Process &nbsp; </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="5px"></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="lblmsg" runat="server" CssClass="information-box abc" Text="Please Enter Sold Bank Form Number." Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="5px"></td>
                        </tr>

                    </table>
                </panel>


                <panel id="pnlStep1" runat="server" style="display: none;">
                    <table cellpadding="2" cellspacing="10" style="width: 95%">
                        <tr>
                            <td></td>
                            <td align="left">BANK FORM Number</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtFormNo" runat="server" AutoComplete="Off" Width="196px" CssClass="textbox2" Height="26px" onkeyup="claschnge()" MaxLength="8" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" height="5px"></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Go" runat="server" Text="Search" class="adminbutton" ValidationGroup="a" OnClick="Go_Click" OnClientClick="return change()" />
                            </td>
                        </tr>
                    </table>
                </panel>

                <panel id="pnlStep2" runat="server" style="display: none;">
                    <table cellpadding="2" cellspacing="10" style="width: 95%">

                        <tr>
                            <td></td>
                            <td align="left" class="auto-style1">BANK FORM Number</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtRFormNo" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" MaxLength="8" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">First Name </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtFirstName" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Last Name </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtLastName" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>


                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Passport No. </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtPassportNo" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Country </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtCountry" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Nationality </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtNationality" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Company Name </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtCompanyName" runat="server" AutoComplete="Off" Width="196px" ReadOnly="true" TabIndex="-1" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Enter Date of Birth </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="textbox2" Width="128px" Height="18px" onkeyup="dtval(this,event)" AutoComplete="Off" Enabled="false" placeholder="DD-MM-YYYY" Text=""></asp:TextBox>
                                <a id="A4" runat="server" href="javascript:NewCal('txtDOB','DDMMMYYYY')">
                                    <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                <asp:HiddenField ID="hdnDOB" runat="server" Value="" />
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td height="30" colspan="3"></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center"></td>

                        </tr>

                    </table>
                </panel>

                <panel id="pnlStep3" runat="server" style="display: none;">
                    <table cellpadding="2" cellspacing="10" style="width: 90%">
                        <tr>
                            <td align="left" style="height: 16px;" colspan="4">
                                <asp:GridView ID="GridNDetails" PagerStyle-CssClass="pgr" runat="server" Width="95%" Font-Size="Small" AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" DataKeyNames="cerpac_no" >
                                    <Columns>
                                         <asp:TemplateField HeaderText="Forename" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblforename" runat="server" Text='<%# Bind("forename") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Forename" DataField="forename">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>


                                                <asp:TemplateField HeaderText="Surname" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsurname" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Surname" DataField="surname">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Cerpac No" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Cerpac No." DataField="cerpac_no">
                                                    <ItemStyle Width="150px" />
                                                    <HeaderStyle Width="200px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Expiry Date" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCerpac_expiry_date" runat="server" Text='<%# Bind("Cerpac_expiry_date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Expiry Date" DataField="Cerpac_expiry_date">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>


                                                <asp:TemplateField HeaderText="Nationality" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblnationality" runat="server" Text='<%# Bind("nationality") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Nationality" DataField="nationality">
                                                    <ItemStyle Width="160px" />
                                                    <HeaderStyle Width="200px" />
                                                </asp:BoundField>


                                                <asp:TemplateField HeaderText="Passport No." Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPassportNo" runat="server" Text='<%# Bind("Passport_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Passport No." DataField="Passport_No">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>

                                              <%--  <asp:TemplateField HeaderText="DOB" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="DOB" DataField="DOB">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>--%>

                                                <asp:TemplateField HeaderText="Company Name" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcompany" runat="server" Text='<%# Bind("company") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Company Name" DataField="company">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Designation" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Designation" DataField="Designation" Visible="false">
                                                    <ItemStyle Width="200px" />
                                                    <HeaderStyle Width="250px" />
                                                </asp:BoundField>

                                    </Columns>
                                    <HeaderStyle CssClass="Grid_Header" />

                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                    <RowStyle CssClass="Grid_Item" />
                                    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                                    <SelectedRowStyle CssClass="Grid_Selected" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="lblmsg1" runat="server" CssClass="information-box abc" Text="" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </panel>



                <panel id="pnlStep4" runat="server" style="display: none;">
                    <table cellpadding="2" cellspacing="10" style="width: 95%">
                        <tr>
                            <td></td>
                            <td align="left" class="auto-style1">Port of Arrival</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtAProd" runat="server" AutoComplete="Off" TabIndex="0" Width="196px" CssClass="textbox2" Height="26px" onkeyup="claschnge()" MaxLength="8" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Date of Arrival </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtADate" runat="server" CssClass="textbox2" Width="128px" TabIndex="1" Height="18px" onkeyup="dtval(this,event)" AutoComplete="Off" Enabled="false" placeholder="DD-MM-YYYY" Text=""></asp:TextBox>
                                <a id="A1" runat="server" href="javascript:NewCal('txtADate','DDMMMYYYY')">
                                    <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                <asp:HiddenField ID="hdnADate" runat="server" Value="" />
                            </td>
                            <td></td>
                        </tr>


                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Port of Departrue</td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtDPort" runat="server" AutoComplete="Off" Width="196px" TabIndex="2" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">Date of Departure </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtDDate" runat="server" CssClass="textbox2" Width="128px" TabIndex="3" Height="18px" onkeyup="dtval(this,event)" AutoComplete="Off" Enabled="false" placeholder="DD-MM-YYYY" Text=""></asp:TextBox>
                                <a id="A2" runat="server" href="javascript:NewCal('txtDDate','DDMMMYYYY')">
                                    <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                <asp:HiddenField ID="hdnDDate" runat="server" Value="" />
                            </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style3"></td>
                            <td align="left" class="auto-style1">STR Visa Number </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtSTRVisa" runat="server" AutoComplete="Off" Width="196px" TabIndex="4" CssClass="textbox2" Height="26px" onkeyup="claschnge()" Text=""></asp:TextBox>&nbsp; 
                            </td>
                            <td></td>
                        </tr>



                    </table>
                </panel>

                <panel id="pnlStep5" runat="server" style="display: none;">
                    <table cellpadding="2" cellspacing="10" style="width: 95%">
                        <tr>
                            <td align="left" style="height: 16px;" colspan="3">
                                <asp:GridView ID="grdMovement" PagerStyle-CssClass="pgr" runat="server" Width="200px" AutoGenerateColumns="False" AllowPaging="false" CellSpacing="1" CssClass="GridBaseStyle" OnRowDataBound="grdMovement_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arrival Port">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArrival_Port" runat="server" Text='<%# Bind("Arrival_Port") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Arrival Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArrival_Date" runat="server" Text='<%# Bind("Arrival_Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Departure Port">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeparture_Port" runat="server" Text='<%# Bind("Departure_Port") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Departure Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeparture_Date" runat="server" Text='<%# Bind("Departure_Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="STR_Visa No" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblSTR_Visa_Bo" runat="server" Text='<%# Bind("STR_Visa_Bo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle CssClass="Grid_Header" />

                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                    <RowStyle CssClass="Grid_Item" />
                                    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                                    <SelectedRowStyle CssClass="Grid_Selected" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMsg2" runat="server" CssClass="information-box abc" Text="" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>

                    </table>
                </panel>

                    <panel id="pnlStep6" runat="server" style="display: none;">
                         <table cellpadding="2" cellspacing="10" style="width: 95%" >                            
                             <tr>
                              <td style="width:40%;" align="left">Attach STR Visa scan copy </td>
                              <td  align="left">
                               <label class="btn btn-info btn-lg" >
                                <i class="fas fa-folder-open"></i> <asp:FileUpload ID="FileUpload1" runat="server"  class="textbox2" onchange="ShowImage(this);" />        </label>                           
                              </td>
                              <td >&nbsp; <asp:RegularExpressionValidator ID="ValidateEx" runat="server"   ForeColor="Red"  ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.png|.PNG|.jpeg|.JPEG)$" ControlToValidate="FileUpload1" ValidationGroup="File" ErrorMessage="Please select a Photo Jpegs,  png, and Gifs only"></asp:RegularExpressionValidator> </td>
                            </tr>
                             <tr>
                                    <td colspan="2" align="center">
                                        <img id="imgVISA" visible="false" src="" runat="server" alt="" style="margin-bottom: 11px; border-radius: 12px; width: 400px; height: 300px;" />
                           
                                    </td>
                             </tr>

                             </table>
                    </panel>
                <panel id="pnlSubmit" runat="server">
                    <table cellpadding="2" cellspacing="10" style="width: 95%">

                       

                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" class="adminbutton" ValidationGroup="a" Visible="false" OnClick="btnSearch_Click" OnClientClick="return change()" />
                            </td>

                            <td align="center">
                                <asp:Button ID="Proceed" runat="server" Visible="false" Text="Proceed" class="adminbutton" ValidationGroup="a" OnClick="Proceed_Click" OnClientClick="return change()" />
                            </td>
                            <td align="center">
                                <asp:Button ID="BtnSaveMovement" runat="server" Text="Save Movement" class="adminbutton" ValidationGroup="a" Visible="false" OnClick="BtnSaveMovement_Click" OnClientClick="return change()" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnAddMovement" runat="server" Text="Arrival/Departure Details" Width="250px" class="adminbutton" ValidationGroup="a" Visible="false" OnClick="btnAddMovement_Click" OnClientClick="return change()" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSubmit" runat="server" Visible="false" Text="Initiate Verification Request" class="adminbutton" ValidationGroup="a" OnClick="btnSubmit_Click" OnClientClick="return change()" />
                            </td>
                        </tr>
                    </table>
                </panel>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

