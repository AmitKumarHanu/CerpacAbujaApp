﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Bank_VerifyUploadBankData, App_Web_verifyuploadbankdata.aspx.fc41e3a" %>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
     <style type="text/css">
.confirmation-box {
	background: #99FF99 url('../img/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
	align:center;
}
</style>

<div>
    
    

<table width="100%">
<tr>
                
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="width:749px; text-align: center;">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp;Verify Uploaded Data &nbsp; </span>
                        </font>
                    </div>
                </td>

</tr>
             
<tr>
<td>
     <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
   
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

    
        <contenttemplate>
            <div style="overflow-y:scroll !important;" id="combox">
    <div style="text-align: center; width:500px !important;">

        <asp:GridView ID="grd_display_data" runat="server" AutoGenerateColumns="false" CssClass="GridBaseStyle" PagerStyle-CssClass="pgr" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" CellPadding="3" GridLines="None" BackColor="White" BorderWidth="2px" EmptyDataText="No Data Avialable "
            OnRowDataBound="grd_display_data_RowDataBound">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="false" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>' />

                    </ItemTemplate>

                </asp:TemplateField>


                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />

                <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />

                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />

                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />

                <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />

                <asp:BoundField DataField="RequisitionNo" HeaderText="ReqNo." SortExpression="RequisitionNo" Visible="false" />

                <asp:BoundField DataField="FormNo" HeaderText="FormNo." SortExpression="FormNo" />

                <asp:BoundField DataField="CerpacNo" HeaderText="CerpacNo." SortExpression="CerpacNo" />

                <asp:BoundField DataField="TellerNo" HeaderText="TellerNo" SortExpression="TellerNo" />

                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />

                <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />

                <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1" DataFormatString="{0:dd-MM-yyyy}"/>

                <asp:BoundField DataField="PassportNo" HeaderText="PassportNo." SortExpression="PassportNo" />

                <asp:BoundField DataField="StrVisaNo" HeaderText="StrVisa No." SortExpression="StrVisaNo" />



                <asp:TemplateField HeaderText="Status">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />

                    <ItemTemplate>
                        <asp:Label ID="lbl_status" runat="server"></asp:Label>
                        <asp:Image ID="Image1" runat="server" Width="38px" Height="38px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Exist" HeaderText="Exist" SortExpression="Exist" />



            </Columns>
        </asp:GridView>

    </div>
                </div>
    </contenttemplate>
        
        </asp:UpdatePanel>
        
</td>
    
</tr>
<tr>
<td align="center">
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:Button ID="btn_verify" runat="server" Text="Check For Duplicacy" 
        class="adminbutton" onclick="btn_verify_Click"/>
<asp:Button ID="btn_submit" runat="server" Text="Upload in Database" class="adminbutton" Enabled="false" Visible="false" onclick="btn_submit_Click"/>

</ContentTemplate></asp:UpdatePanel>
    <br />
</td>
</tr>

 <tr><td align="center">
 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
 <div class="confirmation-box" height="10px" style="display:none;" id="confirm" width="650px" runat="server"><p style="color:#006600"><strong>hhh</strong></p></div>
 </ContentTemplate></asp:UpdatePanel>
 </td></tr>
        <tr><td><div class="warning-box" height="10px" style="display:none;" id="warn" width="650px" runat="server"><p style="color:Gray"><strong></strong></p></div></td></tr>
</table>
</div>
</asp:Content>

