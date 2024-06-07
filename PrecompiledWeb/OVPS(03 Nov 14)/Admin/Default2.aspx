<%@ page language="C#" autoeventwireup="true" inherits="Default2, App_Web_default2.aspx.fdf7a39c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<style type="text/css">
   
  .Initial
  {
    display: block;
    padding: 4px 18px 4px 18px;
    float: left;
    background: url("~/Images/InitialImage.png") no-repeat right top;
    color: Black;
    font-weight: bold;
  }
  .Initial:hover
  {
    color: White;
    background: url("~/Images/SelectedButton.png") no-repeat right top;
  }
  .Clicked
  {
    float: left;
    display: block;
    background: url("~/Images/SelectedButton.png") no-repeat right top;
    padding: 4px 18px 4px 18px;
    color: Black;
    font-weight: bold;
    color: White;
  }
  </style>--%>

   
    <style type="text/css">
        .style4
        {
            width: 308px;
        }
        .style7
        {
            width: 146px;
        }
        .style8
        {
        }
        .style9
        {
            width: 116px;
        }
        .style10
        {
            width: 766px;
        }
        .style11
        {
            width: 100%;
        }
        .style12
        {
            width: 148px;
        }
    </style>

   
</head>
<body style="font-family: tahoma">
  <form id="form1" runat="server" >
    <table align="center" style="width: 106% ; position:fixed; ">
      <tr>
        <td>
          <asp:Button Text="personal details" BorderStyle="None"  ID="Tab1"  runat="server"
              OnClick="Tab1_Click" Height="18px" Width="260px" />
          <asp:Button Text="photo" BorderStyle="None" ID="Tab2"  runat="server"
              OnClick="Tab2_Click" Height="18px" Width="260px" />
          <asp:Button Text="Finger Print" BorderStyle="None" ID="fingerPrint"  runat="server"
              OnClick="fingerPrint_Click" Height="18px" Width="260px" />
          <asp:Button Text="signature" BorderStyle="None" ID="BTNsignature"  runat="server"
              OnClick="signature_Click" Height="18px" Width="260px" />
          <asp:Button Text="Document" BorderStyle="None" ID="BTNdocument"  runat="server"
              OnClick="document_Click" Height="18px" Width="260px" />
          
          <asp:MultiView ID="MainView" runat="server">
            <asp:View ID="View1" runat="server">
            <div id="test2" runat="server" style="top: 100px; right: 100px">
              <table style="border: 1px solid #666; width: 46%; float:left; margin-top: 24px;" >

    <tr><td class="style7"> Applicantid</td><td class="style8">
        <asp:TextBox ID="appid" runat="server" Text=1003 Height="16px" Width="87px"></asp:TextBox>
        &nbsp;<asp:Button ID="GetAllDetials" runat="server" onclick="GetAllDetials_Click" 
            Text="getdetials" />
        </td></tr>
    <tr>
        <td class="style7">
            Applicationid</td>
        <td class="style8">
            <asp:TextBox ID="appid1" runat="server" Height="16px" Width="87px"></asp:TextBox>

        </td>
        <td class="style9">
              &nbsp;</td>
        <td class="style10">
              &nbsp;</td>
        </tr>
    <tr>
        <td class="style7">
            PersonalDetails&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td class="style8">
              First Name</td>
        <td class="style9">
              Middle Name</td>
        <td class="style10">
              Last Name</td>
    </tr>
    <tr>
        <td class="style7">
            Name</td>
        <td class="style8">
            <asp:TextBox ID="fname" runat="server" Height="16px" Width="87px"></asp:TextBox>
        </td>
        <td class="style9">
            <asp:TextBox ID="mname" runat="server" Height="16px" Width="87px"></asp:TextBox>
        </td>
        <td class="style10">
            <asp:TextBox ID="Lname" runat="server" Height="16px" Width="87px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            DateofBirth&nbsp;</td>
        <td class="style8">
            <asp:TextBox ID="dob" runat="server" Height="16px" Width="87px"></asp:TextBox>
        </td>
        <td class="style9">
            Place of Birth</td>
        <td class="style10">
            <asp:TextBox ID="pob" runat="server" Height="16px" Width="87px"></asp:TextBox>
        </td>
    </tr>
                  <tr>
                      <td class="style7">
                          Passport No</td>
                      <td class="style8">
                          <asp:TextBox ID="passportno" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style10">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style7">
                          &nbsp;</td>
                      <td class="style8">
                          &nbsp;</td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style10">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style7">
                          Family Detials</td>
                      <td class="style8">
                          First Name</td>
                      <td class="style9">
                          Middle Name</td>
                      <td class="style10">
                          Last Name</td>
                  </tr>
                  <tr>
                      <td class="style7">
                          &nbsp;</td>
                      <td class="style8">
                          &nbsp;</td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style10">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style7">
                          Father&#39;s Name</td>
                      <td class="style8">
                          <asp:TextBox ID="FFname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style9">
                          <asp:TextBox ID="Fmname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style10">
                          <asp:TextBox ID="Flname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="style7">
                          Mother&#39;s name</td>
                      <td class="style8">
                          <asp:TextBox ID="Mfname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style9">
                          <asp:TextBox ID="MMname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style10">
                          <asp:TextBox ID="MLname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="style7">
                          Spouse&#39;s name</td>
                      <td class="style8">
                          <asp:TextBox ID="sfristname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style9">
                          <asp:TextBox ID="Smname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style10">
                          <asp:TextBox ID="Slastname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="style7">
                          &nbsp;</td>
                      <td class="style8">
                          &nbsp;</td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style10">
                          &nbsp;</td>
                  </tr>
    <tr>
        <td class="style4" colspan="4">
            Communication&nbsp; Detials</td>
    </tr>
                  <tr>
                      <td class="style7">
                          Telephone no</td>
                      <td class="style8">
                          <asp:TextBox ID="telephoneno" runat="server" Height="16px" Width="87px"></asp:TextBox>
                      </td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style10">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style7">
                          Identification Marks</td>
                      <td class="style8" colspan="3">
                          <asp:TextBox ID="Identificationmarks" runat="server" Height="18px" 
                              Width="313px"></asp:TextBox>
                      </td>
                  </tr>
              </table>
              </div>
              <div id="test" visible="false" runat="server" style="right: 50px;  top: 10px; margin-left: 525px;"> 
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;
                  <asp:Image ID="fphoto" runat="server" Height="166px" Width="146px" />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Image ID="ffinger" runat="server" Height="153px" Width="129px" />
                 <asp:Image ID="ffinger1" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf1" runat="server" BackColor="#FFCCFF"></asp:Label>

                 <asp:Image ID="ffinger2" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf2" runat="server" BackColor="#FFCCFF"></asp:Label>

                 <asp:Image ID="ffinger3" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf3" runat="server" BackColor="#FFCCFF"></asp:Label>

                 <asp:Image ID="ffinger4" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf4" runat="server" BackColor="#FFCCFF"></asp:Label>

                 <asp:Image ID="ffinger5" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf5" runat="server" BackColor="#FFCCFF"></asp:Label>

                 <asp:Image ID="ffinger6" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf6" runat="server" BackColor="#FFCCFF"></asp:Label>

                 <asp:Image ID="ffinger7" runat="server" Height="153px" Width="129px" />
                <asp:Label ID="Labelf7" runat="server" BackColor="#FFCCFF"></asp:Label>
  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="Label1" runat="server" BackColor="#FFCCFF" 
                      Text="        Photo        "></asp:Label>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" BackColor="#FF99CC" Text="Finger Print"></asp:Label>
                  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Image ID="fsignature" runat="server" Height="37px" Width="212px" />
                  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="Label3" runat="server" BackColor="#FFCCFF" Text="signature"></asp:Label>
                  <br />
                  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Image ID="fdocument" runat="server" Height="252px" Width="344px" />
                  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="Label4" runat="server" BackColor="#FF99CC" Text="Document"></asp:Label>
                  <br />
                  <br />
                  <br />
                </div>

            </asp:View>
            <asp:View ID="View2" runat="server" >

             <div id="Div3" runat="server" style="top: 100px; right: 100px">
              <table style="border: 1px solid #666; width: 46%; float:left; margin-top: 24px;" >
                <tr>
                  <td>
                      <table class="style11">
                          <tr>
                              <td class="style12">
                                  Application id</td>
                              <td>
                                  <asp:TextBox ID="pAppid" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  First Name</td>
                              <td>
                                  <asp:TextBox ID="pfname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Middle Name</td>
                              <td>
                                  <asp:TextBox ID="PmiddleName" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Last Name</td>
                              <td>
                                  <asp:TextBox ID="plname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Passport No</td>
                              <td>
                                  <asp:TextBox ID="ppassportno" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  date Of Birth</td>
                              <td>
                                  <asp:TextBox ID="Pdob" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                      </table>
                  </td>
                </tr>
              </table>
              </div>
              <div id="Div1" runat="server" style="right: 50px; top: 20px; margin-left: 525px;">
                  <asp:Image ID="pphoto" runat="server" Height="169px" Width="172px" 
                      Visible="False" />
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
             <div id="Div4" runat="server" style="top: 100px; right: 100px">

              <table style="border: 1px solid #666; width: 46%; float:left; margin-top: 24px;">
                 
                          <tr>
                              <td class="style12">
                                  Application id</td>
                              <td>
                                  <asp:TextBox ID="fAppid" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td> 
                          </tr>
                          <tr>
                              <td class="style12">
                                  First Name</td>
                              <td>
                                  <asp:TextBox ID="fingerfname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Middle Name</td>
                              <td>
                                  <asp:TextBox ID="fingerfname0" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Last Name</td>
                              <td>
                                  <asp:TextBox ID="fingerlname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Passport No</td>
                              <td>
                                  <asp:TextBox ID="fpassportno" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  date Of Birth</td>
                              <td>
                                  <asp:TextBox ID="fdob" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                      
              </table>
              </div>
              <div id="Div2" runat="server" style="right: 50px; top: 20px; margin-left: 525px;">
                  <asp:Image ID="finger" runat="server" Height="147px" Width="138px" 
                      Visible="False" />
                </div>
            </asp:View>
                        <asp:View ID="VWsignature" runat="server">
                        <div id="Div5" runat="server" style="top: 100px; right: 100px">

              <table style="border: 1px solid #666; width: 46%; float:left; margin-top: 24px;">
                 
                          <tr>
                              <td class="style12">
                                  Application id</td>
                              <td>
                                  <asp:TextBox ID="sAppid" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  First Name</td>
                              <td>
                                  <asp:TextBox ID="SFname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Middle Name</td>
                              <td>
                                  <asp:TextBox ID="Smiddlename" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Last Name</td>
                              <td>
                                  <asp:TextBox ID="SLname" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  Passport No</td>
                              <td>
                                  <asp:TextBox ID="Spassportno" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  date Of Birth</td>
                              <td>
                                  <asp:TextBox ID="Sdob" runat="server" Height="16px" Width="87px"></asp:TextBox>
                              </td>
                          </tr>
                      
              </table>
              </div>
              <div id="Div6" runat="server" style="right: 50px; top: 20px; margin-left: 525px;">
                  <asp:Image ID="IMGsignature" runat="server" Height="147px" Width="138px" 
                      Visible="False" />
                </div>
            

                        </asp:View>
      <asp:View ID="VMdocument" runat="server">
      
                        <div id="Div7" runat="server" style="top: 100px; right: 100px">
                        documents
                        </div>
      
</asp:View>
          </asp:MultiView>
        </td>
      </tr>
    </table>
  </form>
</body></html>
