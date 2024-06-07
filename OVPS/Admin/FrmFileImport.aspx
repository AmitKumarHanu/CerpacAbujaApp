<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="FrmFileImport.aspx.cs" Inherits="Admin_FrmFileImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Button Text="Import Bank File" ID="btnImportBankFile" runat="server" 
        onclick="btnImportBankFile_Click" />

        <asp:Button ID="btnImportAfterQC" runat="server" 
        Text="Import After QC File" onclick="btnImportAfterQC_Click" />
</asp:Content>

