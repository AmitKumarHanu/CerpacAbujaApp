<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_scanpage.aspx.fdf7a39c" enablesessionstate="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CERPAC- NIS</title>

       <link href="../App_theme/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/StyleSheet_Sugar.css" rel="stylesheet" type="text/css" />
    <link href="../App_theme/css/color.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
        #ScanBtn {
            width: 388px;
            height: 41px;
        }
        #UpldBtn
        {
            width: 242px;
        }
        #ScanBtn0 {
            width: 388px;
            height: 41px;
        }
        </style>
</head>
<script language="javascript" type="text/javascript">

    function page_redirect() {
        //window.location.href = "http://localhost:1452/WebSite5/ResultPage.aspx";
        window.navigate("http://192.168.1.10/Admin/ResultPage.aspx?fp=false&id=<%=lblid.Text%>");
        //response.sendRedirect("http://localhost:1452/WebSite5/ResultPage.aspx");
    }

    function uploadimg() {
        //httpuploadctrl.UploadImagePOST("http://192.168.1.100/WebSite5/ResultPage.aspx?fp=true", "c:\\region1.bmp");
        //redirects the web page after 4 secongs ;)
        httpuploadctrl.UploadCropBWRotatePOST("http://192.168.1.10/Admin/ResultPage.aspx?fp=true", "c:\\region1.bmp", 2, 2, 200, 1380, 1, 90);
        window.setTimeout(page_redirect, 4000);
        //window.navigate("http://localhost:1452/WebSite5/ResultPage.aspx?fp=false");
    }

    function scan() {
        //twainctrl.config(600, 600, 2, 1, 1, "c:/", "61EC4ECB-81B6-4309-B7B5-8F7755830EEF", 0, 0);
        //twainctrl.scanRegions("c:/", "0,0,800,302,region1.jpg,0,100,371712", 0, "param4", 0);
        //twainctrl.scan();
        twainctrl.SelectSource(); // you must uncomment this line atleast once, so you can select your scanner
        twainctrl.OpenScanner(0); //initialize the scanning device
        twainctrl.FileType = 0;        //0---bmp; 1---tiff; 2---jpg
        twainctrl.FileName = "c:\\region1"; // local file path for saving the scanned image. IT MUST BE A PARAMETER FOR EACH
        // machine using the web application


        twainctrl.Resolution = 300; //sets the scanning rezolution. the selected scanners support scanning resolution in range 50-600 dpi
        //twainctrl.Threshold = 128;  //sets the threshold for black and white image
        twainctrl.PaperSize = 3;    //sets the paper size (refer to the ActiveX control manual)
        twainctrl.ScanCount = -1;   //Scan all page on scanner
        twainctrl.PixelType = 2;    //defines the type of the image: black and white, grayscale, color
        twainctrl.RegionLeft = 0.157480; //inches  //those commands are defining the scaning area we need to accqire 
        twainctrl.RegionTop = 0.157480; //inches   //we do not need the whole passport page, but only the MRZ lines
        twainctrl.RegionLength = 4.645669; //inches  //even thow, for some reason, it's not working for now ... 
        twainctrl.RegionWidth = 1.02362; //inches //the activex control manual must be read detailed to solve it
        twainctrl.ShowUI = 0;       //show UI - we do not need it ;)
        twainctrl.ScanTo = 0;   //defines how the image will be transfered - 0=SaveToFile
        //twainctrl.Rotation = 3; //defines roration of 270 degrece clockwise
        twainctrl.StartScan();

    }

    function scan_v19(id) {
        //Object123.TwainSelectSource();
        Object123.AcquireImageBWCropRotatePOST(
            "http://192.168.1.10/Admin/ResultPage.aspx?fp=true&id=id", //the page to receive the image 
            "c:\\region1.bmp", //local file name to save the image
           600, 600, //scanning x and y resolutions
           48, //x strart point coordinate
           48, //y start point coordinate
           480,//width
           2824,//height
           90 //rotation angle
           );
        window.setTimeout(page_redirect, 12000);
    }

    function scan_ghost(id) {
        //Object123.TwainSelectSource();
        Object123.AcquireImageCropPOST("http://192.168.1.10/Admin/ResultPage.aspx?fp=true&id=id", //the page to receive the image
            "c:\\region1.bmp", //local file name to save the image
            600, 600,   //scanning x and y resolutions
            940, //513, //x strart point coordinate
            3030, //1255, //y start point coordinate
            1014,   //width  1000
            250 //height
            );
        window.setTimeout(page_redirect, 12000);
    }

   

    function selectsource() {
        Object123.TwainSelectSource();
    }

    function getid() {

        document.getElementById('txtid').value = location.search;
    }
</script>
<body onload="return getid();">
    <object classid="clsid:62EC313A-21DF-4750-888C-C7EDB025F12E" id="twainctrl" width="0" height="0">
    </object>
    <object classid="clsid:8995FB69-EF41-4DBB-B517-ACDAFCB89950" id="httpuploadctrl" width="0" height="0">
    </object>
    <object classid="clsid:DD342D52-8D19-439D-AEE3-229572AAF92B" id="Object123" width="0" height="0">
    </object>
    <form id="form1" runat="server">
    
        <div class="wraper_app">
<!--.........................................................header start................................................-->
	<div class="header_app">	
		<div class="flag_app"></div>
		<div class="hdtxt_app"><img src="../img/hm_banner.png" alt="hdtxt_app"/></div>
		
		
	    <div class="hdtext2_app">
      
           <br/>
            <br/>
           &nbsp;&nbsp;                
		  <asp:Label ID="LabelSysDate" Font-Size="Smaller" runat="Server" CssClass="lbl"></asp:Label>
	</div>
		<div class="hdlogo_app">
			&nbsp;</div>
        <br />		
	</div>	
           &nbsp;&nbsp;  
<!--.........................................................header end................................................-->

<!--.........................................................content start................................................-->
	
            <div  id="combox"  style="width: 500px ! important; margin-left: 300px; height:400px;" >
	
        
       
    <td style="height:5px"><div class="PageNameHeadingCSS" style="text-align:center"><font class="b12"><span style="fontsize:16px; color:White">&nbsp;Web Page For Scanning &nbsp; </span></font>
                        </div>
                    </td>
                <br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                <span style="top:205px; position:absolute; left:508px; width: 182px;" >
                <strong>Cerpac No : </strong>  <asp:Label ID=lblid runat=server Font-Bold="true" ></asp:Label> </span>  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;   &nbsp;  &nbsp;  &nbsp;  &nbsp;
    <input type=text id=txtid name=id Class="textbox2" style="display:none;"  /><br /><br />
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <input type="button"  value="Select Source"  onclick="selectsource()" id="ScanBtn0" class="adminbutton"  style="position:absolute; top:251px; left:509px;"
        name="ScanBtn0" /><br />
   <br />
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <input type="button" value="Scan Passport and Post" onclick="scan_v19('<%=lblid.Text%>')" id="ScanBtn"
        class="adminbutton" name="ScanBtn" style="position:absolute; margin-top:30px; left:509px; top:335px; margin-top:10px;" />
    <br />
    <br /><br />
                &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <input type="button" value="Scan Ghost image and Post" class="adminbutton" 
        onclick="return scan_ghost('<%=lblid.Text%>')" id="UpldBtn" 
        name="UpldBtn" style="display:none;" />
    <br /><br /><br />
              <asp:Label ID="Label2" runat="server" Text="File name for OCR:" Visible="false" Font-Bold="true"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Visible="false" Class="textbox2"></asp:TextBox>
               
    <asp:Button ID="OCRBtn" runat="server" onclick="Do_OCR" Text="OCR" class="adminbutton"  
        PostBackUrl="~/Admin/ScanPage.aspx" Visible="false" />
    <br />
    <asp:Label ID="Label1" runat="server" Visible="false" Font-Bold="true"></asp:Label>

                 </div>
    </form>
    </body>
</html>
