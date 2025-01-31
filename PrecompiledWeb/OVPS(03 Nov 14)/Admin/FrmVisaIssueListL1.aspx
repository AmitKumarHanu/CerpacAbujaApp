﻿<%@ page language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_FrmVisaIssueListL1, App_Web_frmvisaissuelistl1.aspx.fdf7a39c" title="Visa issue List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div  align="center">

    <table cellpadding="2" cellspacing="10" style="border:1px solid #dddddd; width:95%">
      <tr>
        <td colspan="2" class="PageNameHeadingCSS_2" align="center"> Visa issue List L1 </td>
       </tr>
    
     <tr class="t13">   
         <td align="left" valign="top" style="height: 26px" ></td>
       </tr>
    
    <tr>
        <td valign="top" align="center" style="width: 100%; height:150px; text-align: left;">

	       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ApplicationId" AllowPaging="True" Width="95%"                
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
                BorderWidth="1px" GridLines="Horizontal" CellSpacing="1" 
                CssClass="GridBaseStyle" onpageindexchanging="GridView1_PageIndexChanging" 
                onrowediting="GridView1_RowEditing" 
                onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="Application Id" >
                    <ItemTemplate>
                        <asp:Label ID="lblApplicationId" Width="15%" runat="server" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" 
                            Width="13%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="13%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Passport No" >
                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="13%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPassportNumber" Width="15%" runat="server" Text='<%# Bind("PassportNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             
               <asp:TemplateField HeaderText="Name">
                   <HeaderStyle HorizontalAlign="Center" Width="20%" />
               <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" 
                       Width="20%" />
                    <ItemTemplate>                    
                        <asp:Label ID="LblName" Width="40%" Text='<%# Bind("Name") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FatherName" HeaderText="FatherName">
                        <HeaderStyle HorizontalAlign="Center" Width="15%" />
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="PaperVisaIssuedYN" HeaderText="Paper Visa Status" >
                        <HeaderStyle HorizontalAlign="Center" Width="16%" />
                        <ItemStyle HorizontalAlign="Center" Width="16%" />
                    </asp:BoundField>
                    
                   <%-- <asp:BoundField DataField="Approver1Status" HeaderText="Final Status">
                        <HeaderStyle HorizontalAlign="Center" Width="13%" />
                        <ItemStyle HorizontalAlign="Center" Width="13%" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText ="select">
                 <ItemStyle Width="13%" HorizontalAlign="Center" />
                <ItemTemplate>                
                <asp:ImageButton ID="ImgButton" runat="server" ImageUrl="~/Images/EditButton.jpg" CssClass="button" /> 
                </ItemTemplate>                
                </asp:TemplateField>   

                     
                </Columns>
                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Top" />
            <HeaderStyle CssClass="Grid_Header" />
            <RowStyle CssClass="Grid_Item"/>
            <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
            <SelectedRowStyle CssClass="Grid_Selected" />
            <FooterStyle CssClass="Grid_Footer" />
            </asp:GridView>

            </td>
         </tr>
      </table>
    </div>
</asp:Content>
