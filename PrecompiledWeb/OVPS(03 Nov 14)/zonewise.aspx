<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="zonewise, App_Web_zonewise.aspx.cdcab7d2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
		
<link rel="shortcut icon" type="images/ico" href="images/favi-icon.png" />
<link href="css/minicart.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="css/product-ensemble-styles.jsp" type="text/css" media="all"/>
<link href="css/left_sty.css" rel="stylesheet" type="text/css" />	

<link rel="stylesheet" type="text/css" href="css/ims_motif_styles.jsp" />
<link rel="stylesheet" href='css/global.css' type="text/css" media="all"/>

<link rel="stylesheet" href="css/countryPrint.css" type="text/css" media="print"/>
<link media="all" type="text/css" href="css/video.css" rel="stylesheet">
	

<link type="text/css" media="screen" href="css/autosuggest.css" rel="stylesheet">

<link media="all" type="text/css" href="css/quickview.css" rel="stylesheet">

<link rel="stylesheet" href="css/country.css" type="text/css" media="all"/>

<link rel="stylesheet" type="text/css" href="engine1/style.css" />
    <link href="ddmenu/ddmenu.css" rel="stylesheet" type="text/css" />
    <script src="ddmenu/ddmenu.js" type="text/javascript"></script>

<script type="text/javascript" src="engine1/jquery.js"></script>
<script type="text/javascript" src="js/scrolltopcontrol.js"></script>


  <!-- include Cycle plugin -->

<script type="text/javascript" src="http://cloud.github.com/downloads/malsup/cycle/jquery.cycle.all.latest.js"></script>

<script type="text/javascript">

    $(document).ready(function () {

        $('#testimonials1')

        .before('<div id="nav">')

        .cycle({

            fx: 'fade', // choose your transition type, ex: fade, scrollUp, scrollRight, shuffle

            // pager:  '#nav',

            timeout: 1000

        });



        $('#testimonials2')

      .after('<div id="nav2">')

      .cycle({

          fx: 'scrollRight', // choose your transition type, ex: fade, scrollUp, scrollRight, shuffle

          //	pager:  '#nav2'

      });

    });

</script>

  <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>
<script src="SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
<link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css">
<link href="SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css"><strong></strong>


    
	<div id="wrapper">

			<div id="templateHeader">
				<div id="headerWrapper">
            <div id="branding">
        		<div id="logo">
        
                  <img src="img/hm_banner.png" align="left" />
         
	        </div>
				<!-- /logo -->

	<div id="headerContentArea">

	</div>



				<br class="clear"/>
        	</div><!-- /branding -->
         	

<!-- /search -->
        	<div id="ideas"></div>
             <!-- /ideas -->
			
        </div>
		  </div><!-- /templateHeader -->


			<div id="caregry_page">
<div id="left_cat">

<div class="leftcol">
    <div class="left_heading">
   
    
    </div>

    
    
    <!--space -->
    
    
    <div class="dg">
    
    <!--
        <img src="img/nigerian-flag.jpg" width="186" height="160" />
        -->
    </div>
    
     <!--space end -->
	 <div class="clear"></div>
	
     



</div>

</div>
<div id="mid_all" align="center">



<h1>Zone Specific Details</h1>

<br />
<br />


<div id="Accordion1" class="Accordion" tabindex="0">
                     
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">Application
                            Awaiting Approvals
                        <b class="ico-arrow-up"> </b>
                        </div>
                       
                        <div class="AccordionPanelContent">
                            <asp:GridView ID="GridViewVerify" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" >
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("forename") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerpac No">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FRN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrnno" runat="server" Text='<%# Bind("cerpac_file_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Passport No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassportno" runat="server" Text='<%# Bind("passport_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                            <asp:Label Text="No such applications" runat="server" ID="lblmsgverified" Visible="false"></asp:Label>
</div>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">Application
                            Awaiting Production
                            <b class="ico-arrow-up"> </b>
                            </div>
                        <div class="AccordionPanelContent">
                            <asp:GridView ID="GridViewAuth" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" >
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("forename") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerpac No">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FRN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrnno" runat="server" Text='<%# Bind("cerpac_file_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Passport No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassportno" runat="server" Text='<%# Bind("passport_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                            <asp:Label Text="No such applications" runat="server" ID="lblmsgauth" Visible="false"></asp:Label>
  &nbsp;</div>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">Application Awaiting Quality Check
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">
                        <asp:GridView ID="GridViewProd" PagerStyle-CssClass="pgr" 
                        runat="server" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" CellSpacing="1" CssClass="GridBaseStyle" >
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("forename") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerpac No">
                                <ItemTemplate>
                                    <asp:Label ID="lblcerpacno" runat="server" Text='<%# Bind("cerpac_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FRN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrnno" runat="server" Text='<%# Bind("cerpac_file_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Passport No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassportno" runat="server" Text='<%# Bind("passport_no") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                            </asp:TemplateField>
                            </Columns>
                        <HeaderStyle CssClass="Grid_Header" />

<PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" />
                        <SelectedRowStyle CssClass="Grid_Selected" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
</div><asp:Label Text="No such applications" runat="server" ID="lblmsgprod" Visible="false"></asp:Label>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">List Of Spoiled Cards
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">

</div>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">List Of Users
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">
                      
 
                        </div>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">Lost Card Printing
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">
                      
 
                        </div>
                      </div>
                      <div class="AccordionPanel">
                        <div class="AccordionPanelTab">User Handling
                        <b class="ico-arrow-up"> </b>
                        </div>
                        <div class="AccordionPanelContent">
                      
 
                        </div>
                      </div>
                      </div>
<p style="float:right;">
  
  <br />

</p>
<p>
</p>
</div>



</div>
<!-- /centerContent -->

			<!-- /templateFooter -->

			<div id="partner">
				<ul>
<li class="label">OUR PARTNER SITES:</li>
<li><a href="#">Swiss Colony</a></li>
<li><a href="#">Seventh Avenue</a></li>
<li><a href="#">Ginny's</a></li>
<li><a href="#">Monroe and Main</a></li>
<li><a href="#">Midnight Velvet</a></li>
<li class="last"><a href="#">The Tender Filet</a></li>
</ul></div><!-- /partner -->
			
			

		</div><!-- /wrapper -->
	<!-- Start Epsilon Tag -->


	<!-- End Epsilon Tag -->
<script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
    <SCRIPT>
        $("#accordion > li > div").click(function () {

            if (false == $(this).next().is(':visible')) {
                $('#accordion ul').slideUp(300);
            }
            $(this).next().slideToggle(300);
        });

        $('#accordion ul:eq(0)').show();

</SCRIPT>
<script type="text/javascript">
    var Accordion1 = new Spry.Widget.Accordion("Accordion1", { enableAnimation: true, useFixedPanelHeights: false, defaultPanel: -1 });


    </script>
</asp:Content>

