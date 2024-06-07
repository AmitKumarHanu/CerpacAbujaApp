<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Bank_VerifyUploadBankData, App_Web_verifyuploadbankdata.aspx.fc41e3a" enableeventvalidation="false" %>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">--%>
<%--</asp:ScriptManager>--%>
   
     <style type="text/css">
.confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
	
}



.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #A0522D;
    width :65%;
   
}
</style>

<style type="text/css">
    .modal
    {
         position: fixed;
        top: 0;
        left: 0;
        background-color: lightgray;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>

 <script type="text/javascript" src="../JS/jquery.min.js"></script>
<script type="text/javascript">

    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });

    
</script>



                       
                        <%--  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>--%>
                        <div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
    <img src="../Images/loading.gif" alt="" />
</div>
<%--</ContentTemplate></asp:UpdatePanel>--%>
<div align="center" class="bcolour" id="VerifiedData">
    
    

<table width="100%" id="combox">
<tr>
                
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="width:749px; text-align: center;">
                        <font class="b12"><span style="font-size: 16px; color:White;" id="spn" runat="server">&nbsp;Verify Uploaded Data &nbsp; </span>
                        </font>
                    </div>
                </td>

</tr>
             
<tr>
<td>
     
   
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">

    
        <contenttemplate>--%>
            <div style="overflow-y:scroll !important;" >
    <div style="text-align: center; width:500px !important;">

        <asp:GridView ID="grd_display_data" runat="server" AutoGenerateColumns="false" 
            CssClass="GridBaseStyle" PagerStyle-CssClass="pgr"  
             CellSpacing="1" CellPadding="3" GridLines="None" 
            EmptyDataText="No Data Avialable For Manual Correction"
            OnRowDataBound="grd_display_data_RowDataBound" AllowPaging="true" 
            PageSize="10" OnPageIndexChanging="grd_display_data_PageIndexChanging" 
            onrowcreated="grd_display_data_RowCreated" style="font-size: 12px;"
            onselectedindexchanged="grd_display_data_SelectedIndexChanged" 
            onselectedindexchanging="grd_display_data_SelectedIndexChanging">
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="true" Checked='<%#Convert.ToBoolean(Eval("Exist")) %>' />

                    </ItemTemplate>

                </asp:TemplateField>


                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" Visible="false" ItemStyle-HorizontalAlign="Left">

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="RequisitionNo" HeaderText="ReqNo." SortExpression="RequisitionNo" Visible="false" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="FormNo" HeaderText="FrmNo." SortExpression="FormNo" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="CerpacNo" HeaderText="CerpacNo." SortExpression="CerpacNo" ItemStyle-HorizontalAlign="Left" Visible="false">

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="TellerNo" HeaderText="TellerNo" SortExpression="TellerNo" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" ItemStyle-HorizontalAlign="Left" >

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"  Visible="false" ItemStyle-HorizontalAlign="Left">

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-HorizontalAlign="Left">

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="PassportNo" HeaderText="PassportNo." SortExpression="PassportNo"  Visible="false" ItemStyle-HorizontalAlign="Left">

                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="StrVisaNo" HeaderText="StrVisa No." SortExpression="StrVisaNo"  Visible="false" ItemStyle-HorizontalAlign="Left">



                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>



                <asp:TemplateField HeaderText="Status">
                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />

                    <ItemTemplate>
                        <asp:Label ID="lbl_status" runat="server"></asp:Label>
                        <asp:Image ID="Image1" runat="server" Width="38px" Height="38px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Exist" HeaderText="Exist" SortExpression="Exist" />



            </Columns>
            <PagerStyle CssClass="pgr" />
        </asp:GridView>

<input type="hidden" id ="hid" runat="server" value="0"/>
    </div>
                </div>
   <%-- </contenttemplate>
        
        </asp:UpdatePanel>--%>
        
</td>
    
</tr>
<tr>
<td align="center">
    <br />
   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>--%>
<asp:Button ID="btn_verify" runat="server" Text="Validation Process" OnClientClick="ShowProgress();"
        class="adminbutton" onclick="btn_verify_Click" />
<asp:Button ID="btn_submit" runat="server" Text="Upload in Database" class="adminbutton" Enabled="true" Visible="false" onclick="btn_submit_Click"/>

<asp:Button ID="btnA0AO" runat="server" Text="Auto-Correct" class="adminbutton" 
        Enabled="true" Visible="false" onclick="btnA0AO_Click"/>

<asp:Button ID="btnMannual" runat="server" Text="Continue For Next Process" class="adminbutton" 
        Enabled="true" Visible="false" onclick="btnMannual_Click"/>

    <asp:Button ID="btnCorrectLater" runat="server" Text="Correct Later" class="adminbutton" 
        Enabled="true" Visible="false" OnClick="btnCorrectLater_Click"/>
<%--</ContentTemplate></asp:UpdatePanel>--%>
    <br />
</td>
</tr>

   

 <tr><td align="center">
<%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>--%>
 <div class="confirmation-box" height="10px" style="display:none;" id="confirm" width="650px" runat="server"><p style="color:#006600"><strong></strong></p></div>
 <%--</ContentTemplate></asp:UpdatePanel>--%>
 </td></tr>
        <tr><td align="center">
            
         <%--   <asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>
         --%>   <div class="confirmation-box" height="10px" style="display:none;" id="warn"  runat="server"><p style="color:#A0522D"><strong>Data Uploading Process Over.<br /><br /><a href="../Admin/Default.aspx" style="font-size:11px;">Click to Continue</a> </strong> </p></div>
    <%--</ContentTemplate></asp:UpdatePanel>--%>
    </td></tr>
</table>
</div>


    
</asp:Content>

