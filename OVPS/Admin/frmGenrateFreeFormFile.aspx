<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="frmGenrateFreeFormFile.aspx.cs" Inherits="Admin_frmGenrateFreeFormFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

    function CallConfirmBox() {
     var confirm_value = document.getElementById('<%=txtfilename.ClientID%>').value
     if (confirm("Request file successfull created on desktop :" + confirm_value + "")) {
         //OK – Do your stuff or call any callback method here..
            //alert("You pressed OK!");
            window.location.href = "frmGenrateConsolidateEncryptfile.aspx";
            
        } else {
            //CANCEL – Do your stuff or call any callback method here..
            alert("You pressed Cancel!");
        }
    }
</script>

 <div id="Main" style="width:750px;" runat="server" >
     <table  id="combox" style="width:100%;" >
            
 <tr>                
                <td colspan="3" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                         <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Encrypt File For Free Bank Form &nbsp; </span>
                        </font>
                    </div>
                </td>
            </tr>
 <tr>
<td style="height: 5px; width: 750px; text-align: left;"  >

 
<div id="divSearchResult" runat="server" align="center" style="width:750px; display:block "  >
<table class="t11">
<tr >
    <td colspan="3" style="border: 2px dashed #000;" align="center" class="t55 mb-lt"><asp:Label ID="lblZonename" runat="server"></asp:Label></td>
</tr>
<tr >

<td align= "left"  style="border-right: 2px dashed #000;"><strong>AO CerpacNo</strong> </td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>AR CerpacNo</strong></td>
<td align= "left"  style="border-right: 2px dashed #000;"><strong>CR CerpacNo</strong></td>


</tr>
<tr class="b77">

<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblAOCerpacNo" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblARCerpacNo" runat="server"></asp:Label></td>
<td align="center" style="border: 2px dashed #000;" class="b55 b-lt "><asp:Label ID="lblCRCerpacNo" runat="server"></asp:Label></td>

</tr>
<tr>

<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>
<td align= "left" class="t55 mb-lt"></td>

</tr>
</table>
</div>
<div id="divgrd" class="t11" runat="server" align="center" style=" height:auto; width:745px;  " >
<asp:GridView ID="grd_display_data" runat="server"  AutoGenerateColumns="False" 
              CssClass="GridBaseStyle" 
        PagerStyle-CssClass="pgr"  CellSpacing="1" CellPadding="7" Width="250px" >
    <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
<Columns>


    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"/>

    <asp:BoundField DataField="Date1" HeaderText="Date" SortExpression="Date1"/>
--%>

<asp:BoundField DataField="Formno" HeaderText="Free Bank Form No." 
        SortExpression="Formno" HeaderStyle-HorizontalAlign="left" 
        ItemStyle-HorizontalAlign="left" >

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:BoundField>


    

    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>  

    </div>
<div id="divCrefile" runat="server"  >
    <table class="t11" style="width: 100%;" >
                    <tr id="tr45" runat="server" style="display:block;" align="right" >
<td valign="top" align="right" style="width: 100%; text-align: right;">
<asp:Button ID="btnEncrypt" runat="server"  Text="Encrypt & Download" class="adminbutton" 
        ValidationGroup="a" onclick="btnEncrypt_Click"    />       

</td>
<td>
 
    <input id="txtfilename" type="text" runat="server" style="display:none;" />
    
</td>
</tr>
         </table>
         </div>
    </td>
    </tr>
    
  </table>                 
            
 </div>
</asp:Content>

