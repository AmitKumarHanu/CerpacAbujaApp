<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Bank_UploadBankData, App_Web_uploadbankdata.aspx.fc41e3a" %>








<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
<link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $('#<%=fileuploadExcel.ClientID %>').change(function () {
            var fileExtension = ['xls', 'xlsx'];
            if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                alert("Only '.xls','.xlsx' formats are allowed.");
            }
        })
    })
    $(function () {
        //event handler to the checkbox selection change event
        $(this).find('[id$= cbHeaderSelect]').change(function () {
            if ($(this).attr("checked")) {
                $("#gvProducts input[id*='cbSelCerpacrec']:checkbox").attr('checked', true);
            }
            else
                $("#gvProducts input[id*='cbSelCerpacrec']:checkbox").attr('checked', false);
        });
    });
</script>


<div style="text-align: center" class="b11" id="combox">
<b>Please Select Excel File: </b>
<asp:FileUpload ID="fileuploadExcel" runat="server" CssClass="button1" />&nbsp;&nbsp;


<asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click"  class="adminbutton"/>
    
<br />

<%--<asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>--%><br />

<asp:UpdatePanel ID="up1" runat="server"><ContentTemplate>
    <div style="overflow:scroll;" id="upload_div" runat="server">
<asp:GridView ID="gvProducts" PageSize="5" AllowPaging="false" AutoGenerateColumns="false"  BorderColor="White" BorderStyle="Ridge" CellSpacing="1" CellPadding="7" GridLines="None" BackColor="White" BorderWidth="2px" EmptyDataText="No Data Avialable " DataKeyNames="RecordNo" OnPageIndexChanging="gvProducts_PageIndexChanging" runat="server" CssClass="GridBaseStyle" PagerStyle-CssClass="pgr">
     

        <Columns>

    <asp:TemplateField Visible="false">
        <HeaderStyle HorizontalAlign="Center" />
     <HeaderTemplate>                                   
        <asp:CheckBox ID="cbHeaderSelect" runat="server" AutoPostBack="false" Checked="true"/>           
    </HeaderTemplate>

        <ItemTemplate>
            <asp:CheckBox ID="cbSelCerpacrec" runat="server" AutoPostBack="true" Checked="true"
                oncheckedchanged="cbSelCerpacrec_CheckedChanged"/>
        </ItemTemplate>
    </asp:TemplateField>
    <%--<asp:TemplateField>    
<ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
</asp:TemplateField>

--%>

    <asp:TemplateField headertext="RecNO">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblRecordNo"
                       text='<%#Eval("RecordNo")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField headertext="Date">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblDate"
                       text='<%#Eval("Date","{0:dd-MM-yyyy}")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField headertext="Branch">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblBranch" text='<%#Eval("Branch")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField headertext="RequisitionNo" Visible="false">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="Left" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblReqNo" text='<%#Eval("RequisitionNo")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField headertext="PassportNo">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblpassportNo" text='<%#Eval("passportNo")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="FirstName">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblFirstName" text='<%#Eval("firstname")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="MiddleName" >
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblMiddleName" text='<%#Eval("middlename")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField headertext="LastName">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblLastName" text='<%#Eval("LastName")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="Company">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblCompany" text='<%#Eval("Company")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="Nationality">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblNationality" text='<%#Eval("Nationality")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="CerpacNo">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblCerpacNo" text='<%#Eval("CerpacNo")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="StrVisa No.">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblStrVisaNo" text='<%#Eval("StrVisaNo")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="FormNO">
        <HeaderStyle HorizontalAlign="Left" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblFormNO" text='<%#Eval("FormNO")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField headertext="TellerNO">
        <HeaderStyle HorizontalAlign="center" Width="200px" />
        <ItemStyle HorizontalAlign="center" Width="200px"/>
        <ItemTemplate>
            <asp:Label ID="lblTellerNO" text='<%#Eval("TellerNO")%>' runat="server"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField headertext="Amount">
        <HeaderStyle HorizontalAlign="center" Width="80" />
        <ItemStyle HorizontalAlign="center" Width="80" />
         <ItemTemplate>
           <%-- <asp:Label ID="lblAmount" text='<%#Eval("Amount","{0:c}")%>' runat="server"/>--%>

            <asp:Label ID="lblAmount" text='<%#Eval("Amount")%>' runat="server"/>
         </ItemTemplate>
    </asp:TemplateField>
</Columns>
<PagerTemplate>
    <table>
    <tr>
  <td><asp:LinkButton ID="FirstButton" CommandName="Page"
        CommandArgument="First" Text="First" RunAt="server"/></td>
  <td><asp:LinkButton ID="PrevButton"  CommandName="Page"
        CommandArgument="Prev"  Text="Previous"  RunAt="server"/></td>
  <td><asp:LinkButton ID="NextButton"  CommandName="Page"
        CommandArgument="Next"  Text="Next"  RunAt="server"/></td>
  <td><asp:LinkButton ID="LastButton"  CommandName="Page"
        CommandArgument="Last"  Text="Last" RunAt="server"/></td>
    </tr>
</table>
</PagerTemplate>

</asp:GridView>

       </div>
<%--<i id="pageno" runat="server" visible="false">You are viewing page
<%=gvProducts.PageIndex + 1%>
of
<%=gvProducts.PageCount%>
</i>--%>

    <br />

<asp:Button ID="btnCopy" runat="server" Text="Upload As Temporary" OnClick="Copy" Enabled="true" Visible="true"  class="adminbutton"/>
</ContentTemplate></asp:UpdatePanel>
&nbsp;<asp:Button ID="btnCheckAll"  runat="server" Text="Check All" OnClick="CheckAll" Visible="false" class="adminbutton"/>
&nbsp;<asp:Button ID="btnUnCheckAll" runat="server"  Text="UnCheck All"  OnClick="UnCheckAll" Visible="false" class="adminbutton"/>
<br />

<i style="display:none;"><asp:Label ID="lblMessage" runat="server"></asp:Label></i>
</div>


<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<table>
 <tr><td align="center"><div class="confirmation-box"  style="width:274% !important; display:none;" id="confirm" runat="server"><p style="color:#006600"><strong>File Upload Sucessfully</strong></p></div></td></tr>
        <tr><td><div class="warning-box"  style="display:none;" id="warn"  runat="server"><p style="color:Gray"><strong></strong></p></div></td></tr>

</table>
        </ContentTemplate></asp:UpdatePanel>
</div>
</asp:Content>

