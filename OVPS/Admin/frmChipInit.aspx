<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_frmChipInit, App_Web_frmchipinit.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    function BeginRequestHandler(sender, args) {
       
        args.get_postBackElement().disabled = true;

        document.getElementById('<%= btn_Init.ClientID %>').innerText = "Processing";
        document.getElementById('<%=btn_Init.ClientID %>').disabled = true;

        document.getElementById('<%=btn_exit.ClientID %>').disabled = true;

        
    }
</script>--%>
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

    <div id="load" class="loading" align="center">
    Chip Initializing. Please wait...<br />
    <br />
    <img src="../Images/loading.gif" alt="" />
</div>

    <div id="main" runat="server">

        <table cellpadding="2" cellspacing="5" class="bcolour" style="width: 95%" id="combox">
             <tr>
                
                <td style="height: 5px" colspan="2">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Card Initialization Process &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
            <tr align="center">

                <td colspan="2" ></td>
            </tr>

            <tr align="center" id="tr_start" runat="server">

                <td colspan="2" style="color:brown; font-weight:normal;">
                    <br />
                    <br />
                    <br />
                   
                    Please Put the Card on SCM Reader SD1011 & Click Start Initialization Button.
                     <br />
                    <br />
                    <br />
                    <br />
                    <br />
                   
                </td>
            </tr>
             <tr id="tr_over" align="center" style="display:none;" runat="server">

                <td colspan="2" style="color:brown; font-weight:normal;">
                    <br />
                    <br />
                    <br />
                   
                    Chip Initialization process over. Please Put new Card on SCM Reader SD1011 & Click on Start Initialization Button for next Card Initialization.
                     <br />
                    <br />
                    <br />
                    <br />
                    <br />
                   
                </td>
            </tr>

             <tr id="tr_notover" align="center" style="display:none;" runat="server">

                <td colspan="2" style="color:brown; font-weight:normal;">
                    <br />
                    <br />
                    <br />
                   
                    Chip Initialization process failed. Please remove the card & put it again on SCM Reader SD1011 & Click Start Initialization Button.
                     <br />
                    <br />
                    <br />
                    <br />
                    <br />
                   
                </td>
            </tr>

            <tr align="center">

                <td>
                    <asp:Button ID="btn_Init" runat="server"  Text="Start Initialization" Width="140px" OnClick="btn_Init_Click" OnClientClick="ShowProgress();" />
                </td>
                <td>
                    <asp:Button ID="btn_exit" runat="server"  Text="Exit" Width="140px" OnClick="btn_exit_Click"  />

                </td>
            </tr>

        </table>
    </div>


 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
 <div class="confirmation-box" height="10px" style="display:none;" id="confirm" width="650px" runat="server"><p style="color:#006600"><strong></strong></p></div>
 </ContentTemplate></asp:UpdatePanel>
 
            
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>
            <div class="confirmation-box" width="100%" height="10px" style="display:none;" id="warn"  runat="server"><p style="color:#A0522D"><strong>Initialization Process Over.<br /><br /><a href="../Admin/frmChipInit.aspx" style="font-size:11px;">Click Here to Continue</a> </strong> </p></div>
    </ContentTemplate></asp:UpdatePanel>
    
      <%-- <div id="loadingDiv" style="top:300px;left:650px; position:absolute;border:solid; background-color:lightgray; display:none;" runat="server">

                 <asp:UpdateProgress ID="updProgress" 
        AssociatedUpdatePanelID="UpdatePanel1"
        runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="../Images/loading.gif"/>
               Card Initialization In Process........          
             </ProgressTemplate>
       </asp:UpdateProgress>
              </div>--%>
</asp:Content>

