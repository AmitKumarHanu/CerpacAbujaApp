﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/MasterPageUser.master" autoeventwireup="true" inherits="Admin_NewAdmin, App_Web_newadmin.aspx.fdf7a39c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="admin.css" type="text/css"  rel="stylesheet"/>
<link href="icon.css" type="text/css"  rel="stylesheet"/>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js"></script>
    <link href="../App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/color.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/country.css" rel="stylesheet" type="text/css" />  
    <link href="../App_theme/css/global.css" rel="stylesheet" type="text/css" />  

    <script language="javascript" type="text/javascript" src="../JS/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/checkFileExt.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/validation.js"></script>
    <script language="javascript" type="text/javascript">   
    </script>    

 
    <div class="wraper_app">
<!--.........................................................header start................................................-->
	<div class="header_app">	
		<div class="flag_app"></div>
		<div class="hdtxt_app"><img src="../img/hm_banner.png" alt="hdtxt_app"/></div>
		
        <div style="display:none;"> <asp:Label ID="lbl_id" runat="Server"></asp:Label></div>

	</div>	
<!--.........................................................header end................................................-->
<div id="caregry_page">
<div id="combox" align="center">





<p style="float:right;">

<br />

</p>
<p>
  <strong>CERPAC DASHBOARD</strong>
    <br />
    <br />
    <div class="col-md-6" style="width:600px;">	
      		
      		<div class="widget stacked">
					
				<div class="widget-header">
					<i class=""></i>
					<h3><strong>ZONAL OFFICES</strong></h3>
				</div> <!-- /widget-header -->
				
				<div class="widget-content">
					
					<div class="shortcuts" id="nav">
						<a href="../zonewise.aspx?id=222" class="shortcut">
                        <audio id="beep-two" style="display:none;" controls preload="auto">
            <source src="beep.mp3" controls></source>
            <source src="beep.ogg" controls></source>
            </audio>
      		
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>ABUJA</strong> </span>
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>LAGOS</strong> </span>								
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>BAUCHI</strong> </span>	
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600" ><strong>BENIN</strong> </span>								
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>OWERRI</strong> </span>
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>IBADAN</strong> </span>	
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>MAKURDI</strong> </span>	
						</a>
						
						<a href="../zonewise.aspx" class="shortcut">
							<i class="shortcut-icon icon-user"></i>
							<span class="shortcut-label" style="color:#CC6600"><strong>KADUNA</strong></span>
						</a>				
				
                    </div> <!-- /shortcuts -->	
                   

                 <script>                     $("#nav a")
  .each(function (i) {
      if (i != 0) {
          $("#beep-two")
        .clone()
        .attr("id", "beep-two" + i)
        .appendTo($(this).parent());
      }
      $(this).data("beeper", i);
  })
  .mouseenter(function () {
      $("#beep-two" + $(this).data("beeper"))[0].play();
  });
                     $("#beep-two").attr("id", "beep-two0");</script>
                    
				</div> <!-- /widget-content -->
				
			</div> <!-- /widget --><!-- /widget --><!-- /widget -->
								
	      </div></p>

          <div class="col-md-6" style="width:600px;">	
      		
      		
      		<div class="widget stacked">
					
				<div class="widget-header">
					<i class="" ></i>
					<h3><strong>Admin Tasks</strong></h3>
				</div> <!-- /widget-header -->
				
				<div class="widget-content">
					
					<div class="Adminshortcuts">
                    <a href="../Bank/UploadBankData.aspx" class="Adminshortcut">
						
							<i class="Adminshortcut-icon icon-key"></i>
							<span class="Adminshortcut-label" style="color:#3333FF"><strong>Renew Licence </strong> </span>
						</a>
						
						<a href="" class="Adminshortcut">
							<i class="Adminshortcut-icon icon-search"></i>
							<span class="Adminshortcut-label" style="color:#3333FF"><strong>Reports</strong> </span>								
						</a>
						
						<asp:LinkButton CssClass="Adminshortcut" runat="server" ID="lnklogout" OnClick="lnklogout_Click">
							<i class="Adminshortcut-icon icon-power-off"></i>
							<span class="Adminshortcut-label" style="color:#3333FF"><strong> Exit</strong> </span>	
						</asp:LinkButton>
						
						
                    </div> <!-- /shortcuts -->	
                    
				
				</div> <!-- /widget-content -->
				
			</div> <!-- /widget --><!-- /widget --><!-- /widget -->
								
	      </div>
          </p>
</div>



</div>
<!--.........................................................content start................................................-->
	  </div>
	  
 <!--.........................................................content end................................................-->

</asp:Content>

