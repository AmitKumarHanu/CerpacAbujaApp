<%@ page language="C#" autoeventwireup="true" inherits="Admin_CompanyPopUp, App_Web_compmasterpopup.aspx.fdf7a39c" enableeventvalidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="../SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
    <link href="../SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css">
    <link href="../css/scanpage.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/animate-custom.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/country.css" rel=Stylesheet type="text/css" /> 
    <link href="../css/companypopup.css" rel="Stylesheet" type="text/css" />
    <link href="admin.css" type="text/css"  rel="stylesheet"/>
    <link href="icon.css" type="text/css"  rel="stylesheet"/>
    <title></title>
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById('TextBoxName').value = null) {
                document.getElementById('TextBoxName').className = 'txtboxerror';
               
                return false;

            }
            else {
                document.getElementById('TextBoxName').className = 'txtbox'
               
                return true;
            }
        }
        function AllowAlphabet() {
           
            var desig = document.getElementById("<%=TextBoxName.ClientID%>");
            if (!desig.value.match(/^[a-z A-Z_\.\-\/|-]+$/) && desig.value != "") {
                 desig.value = "";
                 desig.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
    </script>
    <script language="javascript" type="text/javascript">
       


        var para = window.dialogArguments;
        if (!((para == undefined || para == null) ? true : false))
            $("#TextBoxName").val(para);
        function ReturnParentPage(msg) {
            window.returnValue = msg;
            this.close();
        }





        function CheckOne(CheckboxListClientId) {
            var CheckboxList = document.getElementById(CheckboxListClientId);

            if (CheckboxList != null) {
                var CheckBoxInputs = CheckboxList.getElementsByTagName("input");
                for (var i = 0; i < CheckBoxInputs.length; i++) {
                    var CurrentIndex;
                    if (CheckBoxInputs[i].checked) {
                        CurrentIndex = i;
                    }
                    if (CheckBoxInputs[i].checked) {
                        CheckBoxInputs[i].checked = false;
                    }
                    CheckBoxInputs[parseInt(CurrentIndex)].checked = true;
                }
            }
        }

        function CheckOne(obj, chk) {
            alert(obj.parentNode.parentNode);
            var grid = obj.parentNode.parentNode;
           
            alert(chk);
            var inputs = grid.getElementsByTagName("input");

            alert(inputs.length);
            for (var i = 0; i < inputs.length; i++) {
                alert('for');
                alert(chk[i].type);
                if (chk[i].type == "checkbox") {
                    alert('chk');
                    if (chk.checked && chk[i] != obj && chk[i].checked) {
                        chk[i].checked = false;
                    }
                }
            }
        }

</script>
    <style type="text/css">
        .GridBaseStyle {}
    </style>
</head>
<body>
    <form id="form1"  runat="server">
    <div>
    <table style=" width:435px; height:100px;" >
        <tr><td colspan="3" height="15"></td></tr>
     <tr> <td align="center" colspan="3"><h3><span class="information-box">Fill Company Name</span></h3></td></tr>
     <tr><td height="5" colspan="3">&nbsp;</td></tr>
        <tr>
     <td align="center">
         <asp:Label ID="Label1" runat="server" Text="Company Name " Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>  
     </td>
     <td align="center">
       <asp:TextBox ID="TextBoxName" runat="server" Width="171px" CssClass="txtbox" Height="26px" Visible="False"></asp:TextBox>
     </td> 
     <td align="left">
         <div class="Adminshortcuts" style="height:40px;">
       
    <asp:LinkButton ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click" CssClass="Adminshortcut" Width="40px" Visible="False"></asp:LinkButton>
             </div>
     </td>
     </tr>
        


        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridBaseStyle" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="416px" OnRowEditing="GridView1_RowEditing" >
                    <Columns>
                     <asp:TemplateField HeaderText="Select"  ControlStyle-ForeColor="Black" Visible="false">
                                    <ItemTemplate >
                                        <asp:CheckBox ID="CheckBox1" runat="server" ToolTip='<%# Bind("regno") %>'/>
                                       <%-- <input type="checkbox" id="CheckBox1" runat="server" />--%>
                                    </ItemTemplate>
                                   <%-- <HeaderTemplate><asp:CheckBox ID="chkselectall" runat="server" Text="Select"
                                             OnCheckedChanged="chkAccessAll_CheckedChanged" AutoPostBack="true" /></HeaderTemplate>--%>

<ControlStyle ForeColor="Black"></ControlStyle>

                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" />
                                </asp:TemplateField>


                        <asp:BoundField DataField="regno" HeaderText="Reg No." SortExpression="regno" HeaderStyle-Width="70px" />
                        <asp:BoundField DataField="company" HeaderText="Company Name" SortExpression="company" />


                        </Columns>
                    <HeaderStyle CssClass="Grid_Header" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />

<PagerStyle CssClass="pgr" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" BackColor="#F7F7DE" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" BackColor="White" />
                        <SelectedRowStyle CssClass="Grid_Selected" BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <FooterStyle CssClass="Grid_Footer" BackColor="#CCCC99" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </td>

            <td></td>
        </tr>

        <tr>

            <td colspan="3" align="center">
                 <div class="Adminshortcuts" style="height:40px;">
                 <asp:LinkButton ID="btn_prev" runat="server" Text="Previous" OnClick="btn_prev_Click" CssClass="Adminshortcut" Width="40px">
                      <center> <i class="shortcut-icon icon-backward"></i></center>
                 </asp:LinkButton>&nbsp;


                <asp:LinkButton ID="btn_next" runat="server" Text="Next" OnClick="btn_next_Click" CssClass="Adminshortcut" Width="40px">
                     <center> <i class="shortcut-icon icon-forward"></i></center>
                </asp:LinkButton>

                </div>

            </td>
            
            
        </tr>
</table>

    </div>
    </form>
</body>
</html>
