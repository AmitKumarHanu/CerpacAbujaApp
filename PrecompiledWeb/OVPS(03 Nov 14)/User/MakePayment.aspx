<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="User_Default, App_Web_makepayment.aspx.6cc23264" title="User Master Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table class="bcolour" cellpadding="5" cellspacing="0" style="width: 95%; height: 470px;">
            <tr align="center">
                <td style="width: 80%; height: 100%;">
                    <div class="box">
                        <table width="100%" border="0" cellspacing="2" cellpadding="7">
                            <tr>
                                <td width="45%">
                                    <span class="txt-label">Visa Fee </span>
                                </td>
                                <td width="55%">
                                    <span class="txt-label1">
                                        <asp:Label ID="lblVisaFee" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                            <tr id="trEmove" runat="server"  >
                                <td width="45%">
                                    <span class="txt-label">eMove Card</span>
                                </td>
                                <td>
                                    <span class="txt-label1">
                                        <asp:Label ID="lblEmove" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                            <tr id="trFastTrack" runat ="server" >
                                <td width="45%">
                                    <span class="txt-label">Fast Track Charges</span>
                                </td>
                                <td>
                                    <span class="txt-label1">
                                        <asp:Label ID="lblFastTrack" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td width="45%">
                                    <span class="txt-label">Facility Charges</span>
                                </td>
                                <td>
                                    <span class="txt-label1">
                                        <asp:Label ID="lblFacities" runat="server"></asp:Label></span>
                                </td>
                            </tr>
          
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                
                    <td width="45%">
                        <span class="txt-total">TOTAL:</span>
                    </td>
                    <td>
                        <span class="txt-total"><asp:Label ID="lblToal" runat="server"></asp:Label></span>
                    </td>
                
                </tr> 
        </table>
        <asp:ImageButton ID="btmMakePayment" runat="server" OnClick="btmMakePayment_Click"
            ImageUrl="../images/pay.png"  PostBackUrl="FrmPayment.aspx" />
        </div> 
        </td> 
        </tr> 
        </table> 
    </center>
</asp:Content>
