<!--

function HideMillitery() {
    var objpnl = document.getElementById(objpnlMillitery);
    objpnl.style.display = 'none';   
}

function DisplayMillitery() {
    var objpnl = document.getElementById(objpnlMillitery);
    objpnl.style.display = '';
}

function HideEmplSp() {
    var objpnl = document.getElementById(objpnlEmplSp);
    objpnl.style.display = 'none';
}

function DisplayEmplSp() {
    var objpnl = document.getElementById(objpnlEmplSp);
    objpnl.style.display = '';
}

function HideEmpl() {
    var objpnl = document.getElementById(objpnlEmpl);
    objpnl.style.display = 'none';
}

function DisplayEmpl() {
    var objpnl = document.getElementById(objpnlEmpl);
    objpnl.style.display = '';
}

//permanent address
function DisplayPermanentAddress() {
    var objpnl = document.getElementById(objpnlPermaneneAddress);
    objpnl.style.display = '';
}

function HidePermanentAddress() {
    var objpnl = document.getElementById(objpnlPermaneneAddress);
    objpnl.style.display = 'none';
}

//old passport details
function DisplayFreshPassport() {
    var objpnl = document.getElementById(objpnlOldPassport);
    objpnl.style.display = '';
}

function HideFreshPassport() {
    var objpnl = document.getElementById(objpnlOldPassport);
    objpnl.style.display = 'none';
}

//last vivit to nigeria and address
function DisplayVisit() {
    var objpnl = document.getElementById(objpnlPrevVisit1);
    objpnl.style.display = '';
    count = 1;
}

function HideVisit() {
    var objpnl = document.getElementById(objpnlPrevVisit1);
    objpnl.style.display = 'none';
    var objpnl2 = document.getElementById(objpnlPrevVisit2);
    objpnl2.style.display = 'none';
    var objpnl3 = document.getElementById(objpnlPrevVisit3);
    objpnl3.style.display = 'none';
    count = 1;
}

function openLastVisit() {
    if (count == 1) {
        var objpnl = document.getElementById(objpnlPrevVisit2);
        objpnl.style.display = '';
        count = parseInt(count) + 1;
        }
       else if(count == 2) {
           var objpnl = document.getElementById(objpnlPrevVisit3);
           objpnl.style.display = '';
       }
   
    }

    function closeLastVisit1() {
      
            var objpnl = document.getElementById(objpnlPrevVisit2);
            objpnl.style.display = 'none';
            count = 1;
        }

    function closeLastVisit2() {
        var objpnl = document.getElementById(objpnlPrevVisit3);
        objpnl.style.display = 'none';
        count = 2;
    }



    //last visit to nigeria
function DisplayLastVisitCountries() {
    var objpnl = document.getElementById(objpnlLastVisitCountries1);
    objpnl.style.display = '';
    Countrycount = 1;
}

function HideLastVisitCountries() {
    var objpnl = document.getElementById(objpnlLastVisitCountries1);
    objpnl.style.display = 'none';
    var objpnl2 = document.getElementById(objpnlLastVisitCountries2);
    objpnl2.style.display = 'none';
    var objpnl3 = document.getElementById(objpnlLastVisitCountries3);
    objpnl3.style.display = 'none';
    Countrycount = 1;
}

function openLastVisitCountries() {
    if (Countrycount == 1) {
        var objpnl = document.getElementById(objpnlLastVisitCountries2);
        objpnl.style.display = '';
        Countrycount = parseInt(Countrycount) + 1;
        }
       else if(Countrycount == 2) {
           var objpnl = document.getElementById(objpnlLastVisitCountries3);
           objpnl.style.display = '';
       }   
    }

    function closeLastVisitCountries1() {
      
            var objpnl = document.getElementById(objpnlLastVisitCountries2);
            objpnl.style.display = 'none';
            Countrycount = 1;
        }

    function closeLastVisitCountries2() {
        var objpnl = document.getElementById(objpnlLastVisitCountries3);
        objpnl.style.display = 'none';
        Countrycount = 2;
    }


//last lived to countries
function DisplayLastLived() {
    var objpnl = document.getElementById(objpnlLastLived1);
    objpnl.style.display = '';
    LastLivedcount = 1;
}

function HideLastLived() {
    var objpnl = document.getElementById(objpnlLastLived1);
    objpnl.style.display = 'none';
    var objpnl2 = document.getElementById(objpnlLastLived2);
    objpnl2.style.display = 'none';
    var objpnl3 = document.getElementById(objpnlLastLived3);
    objpnl3.style.display = 'none';
    LastLivedcount = 1;
}

function openLastLived() {
    if (LastLivedcount == 1) {
        var objpnl = document.getElementById(objpnlLastLived2);
        objpnl.style.display = '';
        LastLivedcount = parseInt(LastLivedcount) + 1;
        }
       else if(LastLivedcount == 2) {
           var objpnl = document.getElementById(objpnlLastLived3);
           objpnl.style.display = '';
       }   
    }

    function closeLastLived1() {
      
            var objpnl = document.getElementById(objpnlLastLived2);
            objpnl.style.display = 'none';
            LastLivedcount = 1;
        }

    function closeLastLived2() {
        var objpnl = document.getElementById(objpnlLastLived3);
        objpnl.style.display = 'none';
        LastLivedcount = 2;
    }

    //immegration

     function DisplayPrevApplied() {
        var objpnl = document.getElementById(objPrevApplied);
        objpnl.style.display = '';
    }

    function HidePrevApplied() {
        var objpnl = document.getElementById(objPrevApplied);
        objpnl.style.display = 'none';
    }

   function DisplayPrevVisit() {
        var objpnl = document.getElementById(objVisit);
        objpnl.style.display = '';
    }

    function HidePrevVisit() {
        var objpnl = document.getElementById(objVisit);
        objpnl.style.display = 'none';
    }

    function DisplayVisaGranted() {
        var objpnl = document.getElementById(objpnlVisaRejected);
        objpnl.style.display = '';
    }

    function HideVisaGranted() {
        var objpnl = document.getElementById(objpnlVisaRejected);
        objpnl.style.display = 'none';
    }

     function DisplayRefusedAnyCountry() {
        var objpnl = document.getElementById(objRefusedAnyCountry);
        objpnl.style.display = '';
    }

    function HideRefusedAnyCountry() {
        var objpnl = document.getElementById(objRefusedAnyCountry);
        objpnl.style.display = 'none';
    }

   function DisplayRefusedOnArrival() {
        var objpnl = document.getElementById(objpnlRefusedOnArrival);
        objpnl.style.display = '';
    }

    function HideRefusedOnArrival() {
        var objpnl = document.getElementById(objpnlRefusedOnArrival);
        objpnl.style.display = 'none';
    }

    function DisplayConvictionInOtherCountry() {
        var objpnl = document.getElementById(objConvictionInOtherCountry);
        objpnl.style.display = '';
    }

    function HideConvictionInOtherCountry() {
        var objpnl = document.getElementById(objConvictionInOtherCountry);
        objpnl.style.display = 'none';
    }
//travell details

    function DisplayCrimeReport() {
        var objpnl = document.getElementById(objpnlCrimeRecord);
        objpnl.style.display = '';
    }

    function HideCrimeReport() {
        var objpnl = document.getElementById(objpnlCrimeRecord);
        objpnl.style.display = 'none';
    }

    function DisplayDisease() {
        var objpnl = document.getElementById(objDisease);
        objpnl.style.display = '';
    }

    function HideDisease() {
        var objpnl = document.getElementById(objDisease);
        objpnl.style.display = 'none';
    }

    function DisplayDrugReport() {
        var objpnl = document.getElementById(objDrugReport);
        objpnl.style.display = '';
    }

    function HideDrugReport() {
        var objpnl = document.getElementById(objDrugReport);
        objpnl.style.display = 'none';
    }

    function DisplayDeported() {
        var objpnl = document.getElementById(objpnlDeported);
        objpnl.style.display = '';
    }

    function HideDeported() {
        var objpnl = document.getElementById(objpnlDeported);
        objpnl.style.display = 'none';
    }

    function DisplayFraudRecord() {
        var objpnl = document.getElementById(objFraudRecord);
        objpnl.style.display = '';
    }

    function HideFraudRecord() {
        var objpnl = document.getElementById(objFraudRecord);
        objpnl.style.display = 'none';
    }

     function DisplayOtherNationality() {
        var objpnl = document.getElementById(objOtherNationality);
        objpnl.style.display = '';
    }

    function HideOtherNationality() {
        var objpnl = document.getElementById(objOtherNationality);
        objpnl.style.display = 'none';
    }

     function DisplayDeportedOtherCountry() {
        var objpnl = document.getElementById(objDeportedOtherCountry);
        objpnl.style.display = '';
    }

    function HideDeportedOtherCountry() {
        var objpnl = document.getElementById(objDeportedOtherCountry);
        objpnl.style.display = 'none';
    }