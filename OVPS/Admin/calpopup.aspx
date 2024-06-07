<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calpopup.aspx.cs" Inherits="Admin_calpopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ReturnParentPage(msg) {
            window.returnValue = msg;
            this.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updt" runat="server">
            <ContentTemplate>
        <asp:DropDownList ID="drpmonth" runat="server" Width="113px" OnSelectedIndexChanged="drpmonth_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="1">Jan</asp:ListItem>
            <asp:ListItem Value="2">Feb</asp:ListItem>
            <asp:ListItem Value="3">Mar</asp:ListItem>
            <asp:ListItem Value="4">Apr</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">Jun</asp:ListItem>
            <asp:ListItem Value="7">Jul</asp:ListItem>
            <asp:ListItem Value="8">Aug</asp:ListItem>
            <asp:ListItem Value="9">Sep</asp:ListItem>
            <asp:ListItem Value="10">Oct</asp:ListItem>
            <asp:ListItem Value="11">Nov</asp:ListItem>
            <asp:ListItem Value="12">Dec</asp:ListItem>

        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="drpyear" runat="server" Width="122px" OnSelectedIndexChanged="drpyear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        &nbsp;
        <br />
    <asp:Calendar ID="calexp" runat="server" style="position:relative;" OnSelectionChanged="calexp_SelectionChanged" OnDayRender="calexp_DayRender" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" Width="330px" CssClass="calexp" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth">
                                             <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                             <DayStyle BackColor="#CCCCCC" />
                                             <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                             <OtherMonthDayStyle ForeColor="#999999" />
                                             <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                             <TitleStyle BackColor="#333399" Font-Bold="True" BorderStyle="Solid" Font-Size="12pt" ForeColor="White" Height="12pt" />
                                             <TodayDayStyle BackColor="#999999" ForeColor="White" />
                                        </asp:Calendar>
                </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
