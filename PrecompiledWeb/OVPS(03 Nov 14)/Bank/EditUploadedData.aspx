<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Bank_EditUploadedData, App_Web_edituploadeddata.aspx.fc41e3a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="combox">
<div align="center" class="bcolour" id="zone_contain">
        <table cellpadding="2" cellspacing="10" style="width: 98%"  >
            <tr>
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Edit Uploaded Data &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr><td height="15"><asp:Label ID="lbl_issue" runat="server"></asp:Label></td></tr>

            </table>


             <div id="authtable" runat="server" >
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id=detailtable runat=server>
                            <tr class="b77">
                                <td colspan="4" align="left" class="b77">
                                    <strong>Candidate Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Secured Sold Form No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtSecuredSoldFormNoR" runat="server" CssClass="b99" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtSecuredSoldFormNo" runat="server" CssClass="b99"></asp:TextBox>
                                </td>
                            </tr>

                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    First Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtFirstNameR" runat="server" CssClass="b99" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtFirstName" runat="server" CssClass="b99"></asp:TextBox>
                                </td>
                            </tr>
                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Last Name
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtLastNameR" runat="server" CssClass="b99" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtLastName" runat="server" CssClass="b99"></asp:TextBox>
                                </td>
                            </tr>

                            <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Tel. No.</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtTelNoR" runat="server" CssClass="b99" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtTellerNo" runat="server" CssClass="b99"></asp:TextBox>
                                </td>
                            </tr>


                                  <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Nationality
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtNationalityR" runat="server" CssClass="b99" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtNationality" runat="server" CssClass="b99"></asp:TextBox>
                                      </td>
                            </tr>
                                  <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    Company
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtCompanyR" runat="server" CssClass="b99" Width="198px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtCompany" runat="server" CssClass="b99" Width="198px"></asp:TextBox>
                                      </td>
                            </tr>
                                  <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    &nbsp;Amount</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtAmountR" runat="server" CssClass="b99" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtAmount" runat="server" CssClass="b99"></asp:TextBox>
                                      </td>
                            </tr>
                                  <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                            </tr>
                                  <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                            </tr>
                                  <tr >
                                <td align="left" style="width: 150px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                                <td align="left" style="width: 14px;" class="b55">
                                    &nbsp;</td>
                                <td align="left" style="width: 190px;">
                                    &nbsp;</td>
                            </tr>
                                 
            <tr class="b11">
                <td align="center" colspan="1">
                   
                    
                </td>
                <td align="center" colspan="1">
                  
                     <asp:Button ID="btnupdate" runat="server" class="adminbutton" Text="Save"  
                        Width="140px" onclick="btnupdate_Click" />
                </td>
                 <td align="center" colspan="1" style="width: 14px">
                   
                </td>
                <td align="center" colspan="1">
                     <asp:Button ID="btncancel" runat="server" class="adminbutton" 
                         Text="Cancel" onclick="btncancel_Click"/>
                    
                    
                </td>
            </tr>

                            </table></div>

                            </div>
</div>
</asp:Content>

