﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageUser.master" AutoEventWireup="true" CodeFile="~/Admin/frmApplicationDetailsUpdate_bkup.aspx.cs" Inherits="Admin_frmApplicationDetailsUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
  <link rel=Stylesheet type="text/css" href="../css/animate-custom.css" />

     <link href="Scripts/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

  <script src="Scripts/jquery-latest.js" type="text/javascript"></script>

    <script src="Scripts/thickbox.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery.autocomplete.pack.js" type="text/javascript"></script>

    <script src="Scripts/jquery.autocomplete.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery.autocomplete.js" type="text/javascript"></script> 

  <script type="text/javascript">

      $(document).ready(function () {
          $("#<%=txtcompname.ClientID%>").autocomplete('AutoComplete.ashx');
      });

      $(document).ready(function () {
          $("#<%=TxtNationality.ClientID%>").autocomplete('AutoCompleteNationality.ashx');
      });

    </script>

     <script language="javascript" type="text/javascript">

         var minYear = 1908;
         var maxYear = 2200;
   </script>

    <script type="text/javascript">
        function dtval(d, e) {
            var pK = e ? e.which : window.event.keyCode;
            if (pK == 8) { d.value = substr(0, d.value.length - 1); return; }
            var dt = d.value;
            var da = dt.split('-');
            for (var a = 0; a < da.length; a++) { if (da[a] != +da[a]) da[a] = da[a].substr(0, da[a].length - 1); }
            if (da[0] > 31) { da[1] = da[0].substr(da[0].length - 1, 1); da[0] = '0' + da[0].substr(0, da[0].length - 1); }
            if (da[1] > 12) { da[2] = da[1].substr(da[1].length - 1, 1); da[1] = '0' + da[1].substr(0, da[1].length - 1); }
            if (da[2] > 9999) da[1] = da[2].substr(0, da[2].length - 1);
            dt = da.join('-');
            if (dt.length == 2 || dt.length == 5) dt += '-';
            d.value = dt;
        }
        function NumNSign(t) {

            var cod = "+-0123456789";
            var v = cod
            var w = "";
            for (var i = 0; i < t.value.length; i++) {
                x = t.value.charAt(i);
                if (v.indexOf(x, 0) != -1)
                    w += x;
            }
            t.value = w;
        }
        function ValidatePassportNumber() {
            var PassportNumber = (document.getElementById('<%=TxtPassportNo.ClientID%>'))
            if (PassportNumber.value.length == 0) {
                alert("Please enter Passport Number");
                return false;
            }
            else {
                return true;
            }
        }
        function Validatecompadd1() {
            var compadd = (document.getElementById('<%=txtcompadd1.ClientID%>'))
            if (compadd.value.length == 0) {
                compadd.style.borderColor = 'red';
                //alert("Please enter Company Name");
                return false;
            }
            else {
                return true;
            }
        }

        function ValidateNationality() {
            var PassportNumber = (document.getElementById('<%=TxtNationality.ClientID%>'))
            if (PassportNumber.value.length == 0) {
                alert("Please enter Nationality");
                return false;
            }
            else {
                return true;
            }
        }
        function ValidatePassportIssue() {
            var PassportNumber = (document.getElementById('<%=TxtPassportType.ClientID%>'))
            if (PassportNumber.value.length == 0) {
                alert("Please enter Passport Issue by");
                return false;
            }
            else {
                return true;
            }
        }
        function validateDOB(txtDate) {

            var currVal = document.getElementById("<%=TxtDob.ClientID%>").value;
            var DOB = document.getElementById("<%=TxtDob.ClientID%>");
            if (currVal == "") {
                alert("Please enter date of birth ");
                return false;
            }

            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?

            if (dtArray == null) {
                alert("Please enter valid Date of Birth");
                DOB.value = "";
                return false;
            }

            var today = new Date();

            //Checks for mm/dd/yyyy format.
            dtDay = dtArray[1];
            dtMonth = dtArray[3];
            dtYear = dtArray[5];
            if (process(currVal) >= today) {
                alert("Date of birth should be less than today's date");
                DOB.value = "";
                return false;
            }

            if (dtMonth < 1 || dtMonth > 12) {
                alert("Please enter valid month for Date of Birth");
                DOB.value = "";
                return false;
            }
            else if (dtDay < 1 || dtDay > 31) {
                alert("Please enter valid day for Date of Birth");
                DOB.value = "";
                return false;
            }
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                alert("Please enter valid day for Date of Birth");
                DOB.value = "";
                return false;
            }
            else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
                alert("Please enter a valid 4 digit year between " + minYear + " and " + today);
                DOB.value = "";
                return false;
            }
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                    alert("Please enter valid Date of Birth");
                    DOB.value = "";
                    return false;
                }
            }


            return true;
        }
        function ValidatePlaceOfIssue() {
            var PassportNumber = (document.getElementById('<%=TxtPlaceOfIssue.ClientID%>'))
            if (PassportNumber.value.length == 0) {
                alert("Please enter Place Of Issue");
                return false;
            }
            else {
                return true;
            }
        }
        function Validatedesig() {
            var desig = (document.getElementById('<%=txtdesig.ClientID%>'))
            if (desig.value.length == 0) {
                alert("Please enter  Designation");
                return false;
            }
            else {
                return true;
            }
        }
        function ValidateFirstName() {
            var PassportNumber = (document.getElementById('<%=TxtFirstName.ClientID%>'))
            if (PassportNumber.value.length == 0) {
                alert("Please enter First Name");
                return false;
            }
            else {
                return true;
            }
        }
        function Validatecompname() {
            var compname = (document.getElementById('<%=txtcompname.ClientID%>'))
            if (compname.value.length == 0) {
                alert("Please enter Company Name");
                return false;
            }
            else {
                return true;
            }
        }
        function Validateaddrnigeria1() {
            var addrnigeria1 = (document.getElementById('<%=txtaddrnigeria1.ClientID%>'))
            if (addrnigeria1.value.length == 0) {
                alert("Please enter Address in Nigeria");
                return false;
            }
            else {
                return true;
            }
        }

        function ValidatePlaceOfBirth() {
            var PlaceOfBirth = (document.getElementById('<%=txtpob.ClientID%>'))
            if (PlaceOfBirth.value.length == 0) {
                alert("Please enter Place Of Birth");
                return false;
            }
            else {
                return true;
            }
        }

        function ValidateLastName() {
            var PassportNumber = (document.getElementById('<%=TxtLastName.ClientID%>'))
            if (PassportNumber.value.length == 0) {
                alert("Please enter Last Name");
                return false;
            }
            else {
                return true;
            }
        }
        function ValidateFileNo() {
            var phyfileno = (document.getElementById('<%=txtphyfileno.ClientID%>'))
            if (phyfileno.value.length == 0) {
                alert("Please enter File Name");
                return false;
            }
            else {
                return true;
            }
        }
        function Validateaddrabroad1() {
            var addrabroad1 = (document.getElementById('<%=txtaddrabroad1.ClientID%>'))
            if (addrabroad1.value.length == 0) {
                alert("Please enter Address in Abroad");
                return false;
            }
            else {
                return true;
            }
        }
        function validateemployement() {

            var currVal = document.getElementById("<%=txtdtemploymnt.ClientID%>").value;
            var DOI = document.getElementById("<%=txtdtemploymnt.ClientID%>");
            if (currVal == "") {
                alert("Please enter date of employement ");
                return false;
            }

            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?

            if (dtArray == null) {
                DOI.value = "";
                alert("Please enter valid date of employement");
                return false;
            }

            var today = new Date();

            //Checks for mm/dd/yyyy format.
            dtDay = dtArray[1];
            dtMonth = dtArray[3];
            dtYear = dtArray[5];

            if (dtMonth < 1 || dtMonth > 12) {
                DOI.value = "";
                alert("Please enter valid month for date of employement");
                return false;
            }
            else if (dtDay < 1 || dtDay > 31) {
                DOI.value = "";
                alert("Please enter valid day for date of employement");
                return false;
            }
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                DOI.value = "";
                alert("Please enter valid day for date of employement");
                return false;
            }
            else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
                DOI.value = "";
                alert("Please enter a valid 4 digit year between " + minYear + " and " + today);
                return false;
            }
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                    DOI.value = "";
                    alert("Please enter valid date of employement");
                    return false;
                }
            }

            if (process(currVal) > today) {
                alert("Date of employement should be less than today's date");
                DOI.value = "";
                return false;
            }

            return true;
        }

      

        function process(date) {
            var parts = date.split("-");
            return new Date(parts[2], parts[1] - 1, parts[0]);
        }
      
        function validateIssueDate() {

            var currVal = document.getElementById("<%=TxtIssueDate.ClientID%>").value;
            var DOI = document.getElementById("<%=TxtIssueDate.ClientID%>");
            if (currVal == "") {
                alert("Please enter Cerpac Issue Date ");
                return false;
            }

            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?

            if (dtArray == null) {
                DOI.value = "";
                alert("Please enter valid Cerpac Issue Date");
                return false;
            }

            var today = new Date();

            //Checks for mm/dd/yyyy format.
            dtDay = dtArray[1];
            dtMonth = dtArray[3];
            dtYear = dtArray[5];

            if (dtMonth < 1 || dtMonth > 12) {
                DOI.value = "";
                alert("Please enter valid month for Cerpac Issue Date");
                return false;
            }
            else if (dtDay < 1 || dtDay > 31) {
                DOI.value = "";
                alert("Please enter valid day for Cerpac Issue Date");
                return false;
            }
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                DOI.value = "";
                alert("Please enter valid day for Cerpac Issue Date");
                return false;
            }
            else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
                DOI.value = "";
                alert("Please enter a valid 4 digit year between " + minYear + " and " + today);
                return false;
            }
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                    DOI.value = "";
                    alert("Please enter valid Cerpac Issue Date");
                    return false;
                }
            }

            if (process(currVal) > today) {
                alert("Cerpac Issue Date should be less than today's date");
                DOI.value = "";
                return false;
            }

            return true;
        }

        function process(date) {
            var parts = date.split("-");
            return new Date(parts[2], parts[1] - 1, parts[0]);
        }
      
        function checkEmail() {

            var email = document.getElementById('<%=txtemailprsn.ClientID%>');
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            if (!filter.test(email.value)) {
                alert('Please provide a valid email address');
                email.focus;
                email.value = "";
                return false;
            }
        }

    </script>

  <script type="text/javascript">
      function buttonchange() {


          var blnFalg = true;
          var blnDoiFalg = true;
          var blnDoeFalg = true;

          var msg = "You have not filled the following mandatory filled \n";
          var PassportType = (document.getElementById('<%=TxtPassportType.ClientID%>'))
          if (PassportType.value.length == 0) {
              blnFalg = false;
              msg += "Passport Issue By  \n";
          }
          var PlaceOfIssue = (document.getElementById('<%=TxtPlaceOfIssue.ClientID%>'))
          if (PlaceOfIssue.value.length == 0) {
              blnFalg = false;
              msg += "Place Of Issue  \n";
          }
          var compadd1 = (document.getElementById('<%=txtcompadd1.ClientID%>'))
          if (compadd1.value.length == 0) {
              blnFalg = false;
              msg += "Company Address  \n";
          }

          var FirstName = (document.getElementById('<%=TxtFirstName.ClientID%>'))
          if (FirstName.value.length == 0) {
              blnFalg = false;
              msg += "First Name  \n";
          }
          var addrnigeria1 = (document.getElementById('<%=txtaddrnigeria1.ClientID%>'))
          if (addrnigeria1.value.length == 0) {
              blnFalg = false;
              msg += "Address in Nigeria  \n";
          }
          var addrabroad1 = (document.getElementById('<%=txtaddrabroad1.ClientID%>'))
          if (addrabroad1.value.length == 0) {
              blnFalg = false;
              msg += "Address in Abroad  \n";
          }
          var phyfile = (document.getElementById('<%=txtphyfileno.ClientID%>'))
          if (phyfile.value.length == 0) {
              blnFalg = false;
              msg += "Physical File No  \n";
          }
          var LastName = (document.getElementById('<%=TxtLastName.ClientID%>'))
          if (LastName.value.length == 0) {
              blnFalg = false;
              msg += "Last Name  \n";
          }
          var compname = (document.getElementById('<%=txtcompname.ClientID%>'))
          if (compname.value.length == 0) {
              blnFalg = false;
              msg += "Company Name  \n";
          }
          var desig = (document.getElementById('<%=txtdesig.ClientID%>'))
          if (desig.value.length == 0) {
              blnFalg = false;
              msg += "Designation  \n";
          }
          var PassportNo = (document.getElementById('<%=TxtPassportNo.ClientID%>'))
          if (PassportNo.value.length == 0) {
              blnFalg = false;
              msg += "Passport No \n";
          }
          //-------------------------------------nationality correction-------------------------------------------
          var Nationality = (document.getElementById('<%=TxtNationality.ClientID%>'))
          if (Nationality.options[Nationality.selectedIndex].value == 0) {
              blnFalg = false;
              msg += "Nationality \n";
          }
          //-------------------------------------------here-----------------------------------------------------
          var pob = (document.getElementById('<%=txtpob.ClientID%>'))
          if (pob.value.length == 0) {
              blnFalg = false;
              msg += "Place Of Birth \n";
          }
          var cal = document.getElementById('<%=TxtDob.ClientID%>').value;
          var DOB = document.getElementById('<%=TxtDob.ClientID%>');
          if (cal == "") {
              blnFalg = false;
              msg += "Date of Birth \n";
          }
          else {
              //Declare Regex 
              var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
              var dtArray = cal.match(rxDatePattern); // is format OK?

              if (dtArray == null) {
                  blnFalg = false;
                  DOB.value = "";
                  msg += "Please enter valid Date Of Birth \n";
              }
              else {
                  var today = new Date();

                  //Checks for mm/dd/yyyy format.
                  dtDay = dtArray[1];
                  dtMonth = dtArray[3];
                  dtYear = dtArray[5];

                  if (dtMonth < 1 || dtMonth > 12) {
                      blnFalg = false;
                      DOB.value = "";
                      msg += "Please enter valid month for Date Of Birth \n";
                  }
                  else if (dtDay < 1 || dtDay > 31) {
                      blnFalg = false;
                      DOB.value = "";
                      msg += "Please enter valid day for Date Of Birth \n";
                  }
                  else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                      blnFalg = false;
                      DOB.value = "";
                      msg += "Please enter valid day for Date Of Birth \n";
                  }
                  else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
                      DOB.value = "";
                      alert("Please enter a valid 4 digit year between " + minYear + " and " + today);
                      return false;
                  }
                  else if (dtMonth == 2) {
                      var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                      if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                          blnFalg = false;
                          DOB.value = "";
                          msg += "Please enter valid Date Of Birth \n";
                      }
                  }
                  if (process(cal) >= today) {
                      msg += "Date of birth should be less than today's date";
                      DOB.value = "";
                      blnFalg = false;
                  }
              }
          }

          var doi = document.getElementById('<%=txtdtemploymnt.ClientID%>').value;
          var objdoi = document.getElementById('<%=txtdtemploymnt.ClientID%>');
          if (doi == "") {
              blnFalg = false;
              blnDoiFalg = false;
              msg += " Date of Employement \n";
          }
          else {
              //Declare Regex 
              var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
              var dtArray = doi.match(rxDatePattern); // is format OK?

              if (dtArray == null) {
                  blnFalg = false;
                  blnDoiFalg = false;
                  objdoi.value = "";
                  msg += "Please enter valid  Date of Employement\n";
              }
              else {
                  var today = new Date();

                  //Checks for mm/dd/yyyy format.
                  dtDay = dtArray[1];
                  dtMonth = dtArray[3];
                  dtYear = dtArray[5];

                  if (dtMonth < 1 || dtMonth > 12) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter valid month for  Date of Employement \n";
                  }
                  else if (dtDay < 1 || dtDay > 31) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter valid day for  Date of Employement \n";
                  }
                  else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter valid day for  Date of Employement \n";
                  }
                  else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter a valid 4 digit year between " + minYear + " and " + today;
                      return false;
                  }
                  else if (dtMonth == 2) {
                      var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                      if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                          blnFalg = false;
                          blnDoiFalg = false;
                          objdoi.value = "";
                          msg += "Please enter valid Cerpac Date of Issue \n";
                      }
                  }
                  if (process(doi) > today) {
                      msg += " Date of Issue should be less than today's date \n";
                      objdoi.value = "";
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                  }
              }
          }



          var doi = document.getElementById('<%=TxtIssueDate.ClientID%>').value;
          var objdoi = document.getElementById('<%=TxtIssueDate.ClientID%>');
          if (doi == "") {
              blnFalg = false;
              blnDoiFalg = false;
              msg += "Cerpac Date of Issue \n";
          }
          else {
              //Declare Regex 
              var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
              var dtArray = doi.match(rxDatePattern); // is format OK?

              if (dtArray == null) {
                  blnFalg = false;
                  blnDoiFalg = false;
                  objdoi.value = "";
                  msg += "Please enter valid Cerpac Date of Issue\n";
              }
              else {
                  var today = new Date();

                  //Checks for mm/dd/yyyy format.
                  dtDay = dtArray[1];
                  dtMonth = dtArray[3];
                  dtYear = dtArray[5];

                  if (dtMonth < 1 || dtMonth > 12) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter valid month for Cerpac Date of Issue \n";
                  }
                  else if (dtDay < 1 || dtDay > 31) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter valid day for Cerpac Date of Issue \n";
                  }
                  else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter valid day for Cerpac Date of Issue \n";
                  }
                  else if (dtYear == 0 || dtYear < minYear || dtYear > today) {
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                      msg += "Please enter a valid 4 digit year between " + minYear + " and " + today;
                      return false;
                  }
                  else if (dtMonth == 2) {
                      var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                      if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                          blnFalg = false;
                          blnDoiFalg = false;
                          objdoi.value = "";
                          msg += "Please enter valid Cerpac Date of Issue \n";
                      }
                  }
                  if (process(doi) > today) {
                      msg += "Cerpac Date of Issue should be less than today's date \n";
                      objdoi.value = "";
                      blnFalg = false;
                      blnDoiFalg = false;
                      objdoi.value = "";
                  }
              }
          }

      


              }


          



          
      

    </script>  
    
     <script type="text/javascript">
         function AllowAlphabetpp() {
             var Tdirector = document.getElementById("<%=TxtPassportNo.ClientID%>").value;
             var director = document.getElementById("<%=TxtPassportNo.ClientID%>");
             if (!director.value.match(/^[a-zA-Z0-9]+$/) && director.value != "") {
                 director.value = "";
                 director.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
         function AllowAlphabet() {
             var firstname = document.getElementById("<%=TxtFirstName.ClientID%>").value;
             var fname = document.getElementById("<%=TxtFirstName.ClientID%>");
             if (!fname.value.match(/^[a-z A-Z]+$/) && fname.value != "") {
                 fname.value = "";
                 fname.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
         function lnameAllowAlphabet() {
             var LastName = document.getElementById("<%=TxtLastName.ClientID%>").value;
             var lname = document.getElementById("<%=TxtLastName.ClientID%>");
             if (!lname.value.match(/^[a-z A-Z]+$/) && lname.value != "") {
                 lname.value = "";
                 lname.focus();
                 alert("Please Enter only Alphabet value.");
             }

         }
         function PlBnameAllowAlphabet() {
             var placeofbirth = document.getElementById("<%=txtpob.ClientID%>").value;
             var pob = document.getElementById("<%=txtpob.ClientID%>");
             if (!pob.value.match(/^[a-z A-Z]+$/) && pob.value != "") {
                 pob.value = "";
                 pob.focus();
                 alert("Please Enter only Alphabet value.");
             }

         }
         function NnameAllowAlphabet() {
             var Nationality = document.getElementById("<%=TxtNationality.ClientID%>").value;
             var Nation = document.getElementById("<%=TxtNationality.ClientID%>");
             if (!Nation.value.match(/^[a-z A-Z]+$/) && Nation.value != "") {
                 Nation.value = "";
                 Nation.focus();
                 alert("Please Enter only Alphabet value.");
             }

         }
         function MnameAllowAlphabet() {
             var MiddleName = document.getElementById("<%=TxtMiddleName.ClientID%>").value;
             var Name = document.getElementById("<%=TxtMiddleName.ClientID%>");
             if (!Name.value.match(/^[a-z A-Z]+$/) && Name.value != "") {
                 Name.value = "";
                 Name.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
         function InameAllowAlphabet() {
             var PassportType = document.getElementById("<%=TxtPassportType.ClientID%>").value;
             var Type = document.getElementById("<%=TxtPassportType.ClientID%>");
             if (!Type.value.match(/^[a-z A-Z]+$/) && Type.value != "") {
                 Type.value = "";
                 Type.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
         function designameAllowAlphabet() {
             var desig = document.getElementById("<%=txtdesig.ClientID%>").value;
             var desig = document.getElementById("<%=txtdesig.ClientID%>");
             if (!desig.value.match(/^[a-z A-Z@/_-]+$/) && desig.value != "") {
                 desig.value = "";
                 desig.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }
         function PlnameAllowAlphabet() {
             var PlaceOfIssue = document.getElementById("<%=TxtPlaceOfIssue.ClientID%>").value;
             var Issue = document.getElementById("<%=TxtPlaceOfIssue.ClientID%>");
             if (!Issue.value.match(/^[a-zA-Z]+$/) && Issue.value != "") {
                 Issue.value = "";
                 Issue.focus();
                 alert("Please Enter only Alphabet value.");
             }
         }

         function ShowPopUp(e) {
             var lbl = document.getElementById('<%=TxtCerpacNo.ClientID%>');
              //alert(lbl.value);
              var ReturnValue = window.showModalDialog("CompanyPopUp.aspx?val=" + document.getElementById("<%=txtcompname.ClientID%>").value + "&no=" + lbl.value, e.paras, "dialogWidth=450px;dialogHeight=500px;scroll:no; status:no;")

              var value = ReturnValue.split(',');
              document.getElementById("<%=txtcompid.ClientID%>").value = value[0];
                 document.getElementById("<%=txtcompname.ClientID%>").value = value[1];


          }

         // function for returning company name to tool tip
         function compnyname() {
             var desig = document.getElementById("<%=txtcompname.ClientID%>").value;
               document.getElementById('comptool').title = desig;
           }
           // ends here
         </script>

         
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .information-box, .confirmation-box, .error-box, .warning-box {
	padding: 0.833em 0.833em 0.833em 3em; /* 10/12 36/12 */
	margin-bottom: 0.833em; /* 20/12 */ }

.confirmation-box {
	background: #99FF99 url('../Images/icons/confirmation.png') no-repeat 0.833em center;
	border: 2px solid #b7cbb6;
	color: #006600;
	width : 55%;
    font-size: 18px;
}
.warning-box {
	background: #fdf7e4 url('../Images/icons/warning.png') no-repeat 0.833em center;
	border: 1px solid #e5d9b2;
	color: #A0522D;
    width :55%;
}
        .auto-style1 {
            height: 2px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            width: 150px;
        }
        .auto-style4 {
            height: 2px;
            width: 150px;
        }
        .auto-style5 {
            height: 20px;
            width: 150px;
        }
        .auto-style7 {
            font-size: 15px;
            font-family: verdana;
            font-weight : bold;
            color: #000099;
            width: 150px;
        }
        .auto-style8 {
            height: 2px;
            width: 175px;
        }
        .auto-style9 {
            width: 175px;
        }
    </style>
    <div id="Div_ContentPlaceHolder" align="center" class="bcolour">
        <table cellpadding="2" cellspacing="5" class="bcolour" style="width: 95%" id="combox">
            <tr>
                <td colspan="2" style="height: 5px">
                    <div class="PageNameHeadingCSS" style="text-align: center">
                        <font class="b12"><span style="font-size: 16px; color:White;">&nbsp; Modify Applicant Data Section&nbsp;
                        </span></font>
                    </div>
                </td>
            </tr>
            <tr class="t11">
                <td align="center" colspan="2">
                    <asp:Label ID="reviewmsg" runat="server" ForeColor="#990000"></asp:Label>
                    <asp:Label ID="msg" runat="server" ForeColor="#339933"></asp:Label>
                </td>
            </tr>

             <tr id="tr_cerpac" runat="server">
                            <td align="center" style="height: 16px; width: 150px;">
                              <strong>  Enter Cerpac Form No.</strong> &nbsp;&nbsp;
                                <asp:TextBox ID="TextAppId" runat="server" AutoComplete="Off" ValidationGroup="a" Width="150px" CssClass="textbox2"
                                    Height="20px"></asp:TextBox>&nbsp; <span style="color: red; text-align: center; font-size: medium;">
                                        *</span>
                                <asp:RequiredFieldValidator ID="rfvAppId" runat="server" ControlToValidate="TextAppId"
                                    Display="None" ErrorMessage="Application ID" ValidationGroup="a" SetFocusOnError="True"
                                    ForeColor="#9EC550"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Button ID="Go" runat="server"  Text="Search" class="adminbutton" ValidationGroup="a"
                                    OnClick="Go_Click" />
                            </td>
                        </tr>

            <tr>
                <td align="center" colspan="2">
                    <center>
                        <table id="tbl1" cellpadding="5" cellspacing="2" border="0" width="750px" runat="server">
                            <tr class="b11">
                                <td align="center" style="width: 10%; vertical-align: middle; text-align: center;
                                    background-repeat: no-repeat;">
                                    <div class="imgbck" runat="server" id="imgbak">
                                        <div id="container" style="position:relative;">
     <a href="../icao.pdf" target="_blank" class="tooltip" title=" Click to view ICAO Photo Recommendations.">
          
           <img src="../img/img.png" id="fimg" name="fimg" class="fimg" alt="" style=" height:164px; top: 3%; left: 39%; position:absolute; width:164px; border-radius: 6px; z-index: 9999; border: 2px solid #000;">
      
                                    <asp:Image runat="server" ID="ImgPhoto" ImageUrl="~/Images/Logo/default_logo.gif" style="height:164px; margin-left:8px; margin-top:9px; width:164px; border-width:0px;" />
                                    </a>
                                    </div>
                                    <br /><br />
                                    <label class="file-upload">
                                     <asp:FileUpload ID="logobrowse" name="uploadfile" runat="server" 
                           CssClass="" Width="28%" ForeColor="Black" />
                           </label>&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUploadPhoto"  runat="server" CssClass="nextbutton" 
                           Text="Upload Photo" onclick="btnUploadPhoto_Click" style="Height:25px  ;" /> 
                     <asp:Button ID="btnUploadCancel" runat="server" CssClass="nextbutton" style="Height:25px;" Text="Cancel" onclick="btnUploadCancel_Click" UseSubmitBehavior="false" Visible="False" />  
 </div>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="5" cellspacing="2" border="0" width="750px" id="loading" runat="server" style="display:none">
                        <tr><td align=center><img src="../Images/loading.gif" /></td></tr>
                        <tr><td height=10></td></tr>
                        <tr><td align=center>Updation in progress.Please Wait. . . . .</td></tr>
                         </table>
                        <br />
                        <table border="0" style="border-style:none; border-width:1px; width: 745px;" cellpadding="7" cellspacing="7" id="gridtable" runat="server">


<tr class="b77">
                                <td colspan="4" align="left">
                                    <strong>Personal Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" style="height: 2px;">
                                    Title
                                </td>
                                <td align="left" style="height:2px;"><asp:DropDownList ID="drptitle" runat="server" CssClass="textbox2" Height="20px" Width="131px" Enabled="true"></asp:DropDownList></td>
                                <td align="left" style="height:2px;">Place of Birth</td>
                                <td align="left" style="height:2px;">
                                <asp:TextBox ID="txtpob" runat="server" CssClass="textbox2" onkeyup="PlBnameAllowAlphabet()" onblur="ValidatePlaceOfBirth()" AutoComplete="Off" onkeydown="PlAllowSpecialChar" Enabled="true"></asp:TextBox>
                                 <span class="star">*                           
                            </span>
                                </td>
                            </tr>

                            <tr class="b55"><td  class="b55" align="left" >First Name</td><td align="left">
                                    <asp:TextBox ID="TxtFirstName" runat="server" CssClass="textbox2" onblur="ValidateFirstName()" AutoComplete="Off" onkeyup="AllowAlphabet()" onkeydown="AllowSpecialChar"></asp:TextBox>
                                </td>
                                    <td  class="b55" align="left">Last Name</td>
                               
    <td align="left">
                                <asp:TextBox ID="TxtLastName" runat="server" CssClass="textbox2"  onblur="ValidateLastName()" AutoComplete="Off" onkeyup="lnameAllowAlphabet()" onkeydown="lAllowSpecialChar"></asp:TextBox>    
                                
    </td></tr>
<tr class="b55"><td  class="b55" align="left">Middle Name</td><td align="left">
                                    <asp:TextBox ID="TxtMiddleName" runat="server" CssClass="textbox2"  AutoComplete="Off" onkeyup="MnameAllowAlphabet()" onkeydown="MAllowSpecialChar"></asp:TextBox>
                                </td><td  class="b55" align="left" >
                                    Nationality
                                </td><td align="left">
                                    
                               <asp:DropDownList ID="TxtNationality" runat="server" CssClass="textbox2"  Height="20px" Width="140px" Enabled="true"></asp:DropDownList>
                                     </td></tr>
                            <tr class="b55">
                                <td align="left" style="width: 150px;">
                                    Date of Birth</td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtDob" runat="server" CssClass="textbox2" Width="128px" Height="18px" onkeyup="dtval(this,event)"  AutoComplete="Off"  placeholder="DD-MM-YYYY" ></asp:TextBox>
                                     <a id="A4" runat="server" href="javascript:NewCal('TxtDob','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                     <span class="star">*                           
                            </span>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Sex
                                </td>
                                <td align="left" style="width: 190px;">
                                   <asp:RadioButtonList ID="radsex" runat="server" RepeatColumns="2" Width="130px">
                                       <asp:ListItem Text="Male" Value="M" Selected="True"></asp:ListItem>
                                       <asp:ListItem Text="Female" Value="F" ></asp:ListItem>
                                   </asp:RadioButtonList>
                                    
                                    
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" style="width: 150px;">
                                    Email Id
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtemailprsn" runat="server" CssClass="textbox2" AutoComplete="Off" onblur="checkEmail()" Enabled="true" ></asp:TextBox>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Contact Number
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtcntcnoprsn" runat="server" CssClass="textbox2" AutoComplete="Off" onkeyup="NumNSign(this)" MaxLength="14" Enabled="true"></asp:TextBox>
                                </td>
                            </tr>

                             <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>

                            


</table>
                        <table border="0" style="border-style:none; border-width:1px; width: 745px;" cellpadding="7" cellspacing="7" id="detailtable" runat="server">
                            <tr class="b77">
                                <td colspan="4" align="left">
                                    <strong>Passport Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style3">
                                    Passport No.
                                </td>
                                <td align="left" style="width: 190px;" >
                                    <asp:TextBox ID="TxtPassportNo" runat="server" CssClass="textbox2" MaxLength="12" onblur="ValidatePassportNumber()" onkeyup="AllowAlphabetpp()" AutoComplete="Off" Enabled="true"></asp:TextBox>
                                <span class="star">*                           
                            </span>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Place of Issue
                                </td>
                                <td align="left" style="width: 190px;">

                                    <asp:TextBox ID="TxtPlaceOfIssue" runat="server" CssClass="textbox2" AutoComplete="Off" onkeyup="PlnameAllowAlphabet()" onblur="ValidatePlaceOfIssue()" onkeydown="PlAllowSpecialChar" Enabled="true"></asp:TextBox>
                                 <span class="star">*</span>
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style3">
                                    Passport Issue By
                                </td>
                                <td align="left"  style="width: 190px;">
                                    <asp:TextBox ID="TxtPassportType" runat="server" CssClass="textbox2" AutoComplete="Off" onblur="ValidatePassportIssue()" onkeyup="InameAllowAlphabet()" onkeydown="IAllowSpecialChar" Enabled="true"></asp:TextBox>
                                <span class="star">*</span> 
                                </td>
                                <td></td>
                                <td></td>
                               
                            </tr>
                           
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <tr class="t11">
                                <td colspan="4" align="center" class="auto-style1">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="b77">
                                <td colspan="4" align="left">
                                    <strong>Cerpac Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr  class="b55" >
                                <td align="left" class="auto-style3" >
                                    Cerpac Number
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="TxtCerpacNo" runat="server" CssClass="textbox2" Width="130px" Height="18px" ForeColor="#666666" BackColor="#9999ff"></asp:Label>
                                </td>
                               
                           
                                <td align="left" style="width: 150px;">
                                    Cerpac Issue Date
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="TxtIssueDate" runat="server" CssClass="textbox2" Width="130px" Height="18px" onkeyup="dtval(this,event)" AutoComplete="Off"  onkeypress="return false" placeholder="DD-MM-YYYY"></asp:TextBox>
                                <span class="star">*                           
                            </span>
                                     <a id="A2" runat="server" href="javascript:NewCal('TxtIssueDate','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                </td>
                            </tr>
                           
                            <tr  class="b55" >
                                <td align="left" class="auto-style3" >
                                    Cerpac Expiry Date
                                </td>
                                <td align="left" style="width: 190px;" >
                                   
                                    <asp:TextBox ID="TxtExpDate" runat="server" CssClass="textbox2" Style="float:left;" Width="130px" Height="18px" AutoComplete="Off" onkeypress="return false"  onkeyup="dtval(this,event)" placeholder="DD-MM-YYYY"></asp:TextBox>
                                <span class="star">*                           
                            </span>

                                        <asp:UpdatePanel style="width:25px; height:25px;  margin-top: -5px; margin-left:5px;  float:left;" ID="UpdatePanel3" runat="server"><ContentTemplate >
                                         &nbsp; &nbsp; 
                                    <a id="A3" runat="server" href="javascript:NewCal('TxtExpDate','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                        </ContentTemplate></asp:UpdatePanel>
                                     </td>
                                 <td align="left" style="width: 150px;" class="b55">
                                    &nbsp;FRN No.

                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:Label ID="txtfileno" runat="server" CssClass="textbox2" Width="130px" Height="18px" ForeColor="#666666" BackColor="#9999ff" ></asp:Label>
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style4">
                                    Zone Code
                                </td>
                                <td align="left" class="auto-style1"><asp:TextBox ID="txtZoneCode" runat="server" CssClass="textbox2" AutoComplete="Off" ReadOnly="true"></asp:TextBox>
                                     <span class="star">                           
                            </span>
                                </td>
                                <td align="left" class="auto-style1">File No.</td><td align="left" class="auto-style1"><asp:TextBox ID="txtphyfileno" runat="server" CssClass="textbox2" AutoComplete="Off" ReadOnly="false" onblur="ValidateFileNo()" ></asp:TextBox>
                                     <span class="star">*                           
                            </span>
                                                                                  </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;</td>
                            </tr>
                             <tr class="b77">
                                <td colspan="4" align="left" class="auto-style2">
                                    <strong>Company Details</strong>
                                </td>
                            </tr>
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style3">
                                    Company RC
                                </td>
                                <td align="left" style="width: 190px;">
                                   
                                    <asp:TextBox ID="txtcompid" runat="server" CssClass="textbox2"  onkeypress="return false"></asp:TextBox>
                                       
                                </td>
                                <td align="left" style="width: 150px;">
                                    Company Name
                                </td>
                                <td align="left" style="width: 190px;" valign="bottom">
                                    <a title="abcde" id="comptool" onmouseover="return compnyname();">
                                    <asp:TextBox ID="txtcompname" runat="server" CssClass="textbox2" AutoComplete="Off" Enabled="false" OnTextChanged="txtcompname_TextChanged"></asp:TextBox> </a>
                                 <span class="star">*  
                                    
                                     <asp:ImageButton ID="Button1" runat="server" Text="Search" ImageUrl="~/Images/search-button-without-text-md.png" OnClientClick="ShowPopUp(this);return false;" CssClass="Adminshortcut" Height="25px" Width="25px"  />                         
                            
                                    </span>
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style3">
                                    Company Address 1
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtcompadd1" runat="server" CssClass="textbox2" AutoComplete="Off" TextMode="MultiLine" onblur="Validatecompadd1()"></asp:TextBox>
                                <span class="star">*                           
                            </span>
                                     </td>
                                <td align="left" style="width: 150px;">
                                    Company Address 2
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtcompadd2" runat="server" CssClass="textbox2" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style3">
                                    Designation
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtdesig" runat="server" CssClass="textbox2" AutoComplete="Off" onblur="Validatedesig()" onkeyup="designameAllowAlphabet()"></asp:TextBox>
                                 <span class="star">*                           
                            </span>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Company Telephone No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtphno" runat="server" CssClass="textbox2" AutoComplete="Off" onkeyup="NumNSign(this)" MaxLength="14"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="b55">
                                <td align="left" class="auto-style3">
                                    Company Fax No.
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtfaxno" runat="server" CssClass="textbox2" AutoComplete="Off" onkeyup="NumNSign(this)" MaxLength="14"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 150px;">
                                    Date of Employment
                                </td>
                                <td align="left" style="width: 190px;">
                                    <asp:TextBox ID="txtdtemploymnt" runat="server" CssClass="textbox2" Width="130px" Height="18px" onkeyup="dtval(this,event)" AutoComplete="Off" Enabled="false" placeholder="DD-MM-YYYY"></asp:TextBox>
                                     <a id="A5" runat="server" href="javascript:NewCal('txtdtemploymnt','DDMMMYYYY')">
                                <img alt="Pick a date" src="../Images/cal.jpg" style="border: 0" /></a>
                                     <span class="star">*                           
                            </span>
                                </td>
                            </tr>
                             
            <tr class="b11">
                <td colspan="4" align="left" style="height: 20px;">
                    &nbsp;</td>

            </tr>
                            <tr class="b77">
                <td colspan="4" align="left" style="height: 20px;">
                    Address in Nigeria</td>

            </tr>
                            <tr class="b11"><td colspan="4"></td></tr>
                            <tr class="b55"><td align="left" class="auto-style5">Address 1</td><td align="left">
                                    <asp:TextBox ID="txtaddrnigeria1" runat="server" CssClass="textbox2" AutoComplete="Off" TextMode="MultiLine" onblur="Validateaddrnigeria1()"></asp:TextBox>
                                 <span class="star">*                           
                            </span>
                            </td>

                        <td align="left" style="height: 20px;">Address 2</td><td align="left">
                                    <asp:TextBox ID="txtaddrnigeria2" runat="server" CssClass="textbox2" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td colspan="4"></td></tr>
                            <tr class="b77">
                <td colspan="4" align="left" style="height: 20px;">
                    Address Abraod</td>

            </tr>
                            <tr class="b11"><td colspan="4"></td></tr>
                            <tr class="b55"><td align="left" class="auto-style5">Address 1</td><td align="left">
                                    <asp:TextBox ID="txtaddrabroad1" runat="server" CssClass="textbox2" AutoComplete="Off" TextMode="MultiLine" onblur="Validateaddrabroad1()"></asp:TextBox>
                                 <span class="star">*                           
                            </span>
                            </td>

                        <td align="left" style="height: 20px;">Address 2</td><td align="left">
                                    <asp:TextBox ID="txtaddrabroad2" runat="server" CssClass="textbox2" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td colspan="4"></td></tr>
                             </table>

                        <table border="0" style="border-style:none; border-width:1px; width: 745px;" cellpadding="7" cellspacing="7" id="Dependent" runat="server">
                            <tr class="b77">
                                <td colspan="4" align="left" style="height: 20px;">
                    Depandent Relation</td>
                            </tr>

                            <tr class="b55">
                                <td align="left" style="height: 2px;">
                                <asp:Label runat="server" ID="lblpsnty" Text="Person Type  "> </asp:Label>
                                </td>
                                <td align="left" style="height:2px;">
                                     <asp:RadioButtonList ID="radtype" runat="server" RepeatColumns="1" AutoPostBack="True" OnSelectedIndexChanged="radtype_SelectedIndexChange" Width="154px">

                                     <asp:ListItem Text="Individual" Value="0" Selected="True"></asp:ListItem>
                                     <asp:ListItem Text="Dependent" Value="1"></asp:ListItem>
                                                              </asp:RadioButtonList>
                                </td>
                                <td align="left" class="auto-style8">
                                    <asp:Label ID="lbl_dept_name" runat="server" Text=" Name" Visible="true"></asp:Label>

                                </td>
                                <td align="left" class="auto-style8">
                                    <asp:Label ID="txt_dept_name" runat="server" Text="" Visible="true" Width="200px"></asp:Label>


                                </td>
                            </tr>

                            <tr class="b55"><td  class="b55" align="left" >
                  <asp:Label ID="lbldpndty" runat="server" Text=" Dependent on" Visible="true"></asp:Label></td><td align="left">
                                     <asp:TextBox ID="txt_dpndt" runat="server" CssClass="textbox2" placeholder="Cerpac No." OnTextChanged="txt_dpndt_TextChanged" AutoPostBack="true" Visible="true"></asp:TextBox>

                                 </td>
                                    <td  class="b55" align="left" colspan="2"><asp:DropDownList ID="drpdpndt" runat="server" CssClass="textbox2" Visible="False"></asp:DropDownList>
                                     </td>
                               
                            </tr>
<tr class="b55" ><td  class="b55" align="left">
                    <asp:Label ID="lbldeprel" runat="server" Text="Dependence Relation" Visible="true"></asp:Label></td><td align="left">
                                    <asp:DropDownList ID="drprltn" runat="server" CssClass="textbox2" Visible="true"></asp:DropDownList></td><td  class="b55" align="left" >
                                 <asp:TextBox ID="txt_depnt_peopleid" runat="server" Visible="false"></asp:TextBox>
                                </td><td align="left" class="auto-style9">
                                   </td>

</tr>
                            <tr class="b55"  >
                               <td align="left" class="auto-style7"><strong>Notice</strong> </td>                               
                                <td class="b55" align="left"  colspan="3">
                                     <asp:TextBox ID="txtnotes"  runat="server" CssClass="textbox2"  Visible="true" TextMode="MultiLine" Width="533px"></asp:TextBox>

                                 </td>

                            </tr>
                            <tr class="b55" style="display:none">
                                <td align="left" class="auto-style7"><strong>Documents Attached</strong> </td>
                                <td align="left" style="width: 190px;">
                    <asp:CheckBoxList ID="chkbdoc" runat="server" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                                </td>
                                <td align="left" style="width: 150px;">
                                    &nbsp;</td>
                                <td align="left" class="auto-style9">
                                    &nbsp;</td>
                            </tr>

                             <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <tr class="t11">
                                <td colspan="4" align="center" style="height: 2px;">
                                    <asp:Button ID="btnverify" runat="server" class="adminbutton" onclick="btnverify_Click" Text="Update Applicant History" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>

                            


</table>

        <tr><td align="center"><div class="confirmation-box" height=10px style="display:none;"  id=confirm runat=server> <p style="color:#006600" id="p" runat=server><strong>Data Updated Sucessfully</strong></p>

           
            <br />
           

                             </div></td></tr>
        <tr><td align="center"><div class="warning-box" height=10px style="display:none;" id=warn  runat=server><p style="color:#A0522D"><strong>Cerpac Number has been verified</strong> </p></div></td></tr>
        </center> </td> </tr> </table>
    </div>
</asp:Content>
