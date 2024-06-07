<%@ Page Language="C#" AutoEventWireup="true" CodeFile="openbiovisa.aspx.cs" Inherits="openbiovisa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language=javascript>
        function openbiovisa() {
            var objShell = new ActiveXObject("shell.application");
            objShell.ShellExecute("cmd.exe", "cd C: C:\\cd C:\\Program Files\\CENT SI\\BioVisa\\BioVisaClient.exe", "C:\\WINDOWS\\system32", "open", 1);
        }
    </script>
</head>
<body onload="openbiovisa();">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
