// JScript File

function checkTextAreaMaxLength(textBox,e, length)
{
    
        var mLen = textBox["MaxLength"];
        if(null==mLen)
            mLen=length;
        
        var maxLength = parseInt(mLen);
        if(!checkSpecialKeys(e))
        {
         if(textBox.value.length > maxLength-1)
         {
            if(window.event)//IE
              e.returnValue = false;
            else//Firefox
                e.preventDefault();
                alert("Maximum Limit is "  +length + " characters");  
         }
    }     
}

function check() {
    var objchkAgree = document.getElementById("ctl00_ContentPlaceHolder1_chkAgree").checked   
    if (objchkAgree == false) {
        alert("Please,Accept terms and conditions");
    }        
}

function LenCount(textBox,length)
   {
     if(document.getElementById(textBox.id).value.length>length)
     {
     //alert(length);
       alert("TextCharacter cannot be more than " + length);
       var txtvalue= document.getElementById(textBox.id).value;
       if(txtvalue>length)
       {
        var Finaltxtvalue = txtvalue.substring(0,length);
        document.getElementById(textBox.id).value=Finaltxtvalue;
       } 
     }
   }
   
   
function checkSpecialKeys(e)
{
    if(e.keyCode !=8 && e.keyCode!=46 && e.keyCode!=37 && e.keyCode!=38 && e.keyCode!=39 && e.keyCode!=40)
        return false;
    else
        return true;
}

function deletePromt()
    {
      //alert("hi");         
      if(confirm('Do you really want to delete this record'))      
            return true;      
       else       
            return false;    
     }  

function updatePromt()
    {
      if(confirm('Do you really want to Update this record'))      
            return true;      
       else       
            return false;    
     }       
     
function DecimalCheck(FieldId, DigitsAfterDecimal)    
{  
var field=document.getElementById(FieldId);
if(!field.value =='')
{

	if(isNaN(field.value))           
	{                
		alert("Please enter valid numeric value");    
		field.focus();      
		return false;           
	}           
	else           
	{                
		var val = field.value;                
		if(val.indexOf(".") > -1)                
		{                                        
			if(val.length - (val.indexOf(".")+1) > DigitsAfterDecimal)                    
			{                        
				alert("Please enter valid numeric value. Only " + DigitsAfterDecimal + " digits are allowed after decimal.");
				field.focus();
				return false;                    
			}                    
			else                    
			{                      
				return true;                    
			}                
		}                
		else                
		{                    
			if(parseFloat(val) > 0)                    
			{                        
				return true;                    
			}                    
			else                    
			{                  
				return false;                     
			}                
		}           
	}        
}    
}


function bondvalueCheck(FieldId, DigitsAfterDecimal)    
{  
var field=document.getElementById(FieldId);
if(!field.value =='')
{

	if(isNaN(field.value))           
	{                
		alert("Please enter valid numeric value");    
		field.focus();      
		return false;           
	}           
	else           
	{                
		var val = field.value;                
		if(val.indexOf(".") > -1)                
		{                                        
			if(val.length - (val.indexOf(".")+1) > DigitsAfterDecimal)                    
			{                        
				alert("Please enter valid numeric value. Only " + DigitsAfterDecimal + " digits are allowed after decimal.");
				field.focus();
				return false;                    
			}                    
			else                    
			{                      
				return true;                    
			}                
		}                
		else                
		{                    
			if(parseFloat(val) > 0)                    
			{   
			    alert("please enter value with "+DigitsAfterDecimal+" decimal places");
			    field.focus();                     
				return false;                    
			}                    
			else                    
			{                  
				return false;                     
			}                
		}           
	}        
}    
}

function EnableDisable_ReasonBox(objCheckBox, ObjTextBox)
{    
    if(document.getElementById(objCheckBox).checked==true)
    {
       // alert(document.getElementById(objCheckBox).checked);
       document.getElementById(ObjTextBox).disabled=false;
    }
    else 
    {
        document.getElementById(ObjTextBox).value="";
        document.getElementById(ObjTextBox).disabled=true;
    }
}

function CheckBoxChecked(objCheckBox, ObjTextBox)
{
var field=document.getElementById(ObjTextBox);
    if(field.value=='')
    {
        alert("Please Enter The Date First");
        document.getElementById(objCheckBox).checked=false;
        document.getElementById(ObjTextBox).value="";
        return false;
    }
    else
    {
        //this.Submit();
        // document.getElementById(objCheckBox).checked=true;
    }
    if(document.getElementById(objCheckBox).checked==false)
    {
         document.getElementById(ObjTextBox).value="";
         return false;
    }
    
}

// this function allow only money data
function OnlyNum(t){

var cod = ".0123456789";
var v = cod
var w = "";
for (var i=0; i < t.value.length; i++) {
x = t.value.charAt(i);
if (v.indexOf(x,0) != -1)
w += x;
}
t.value = w;
} 

function Comparevalues(objfieldname,TextBoxid)
{

    var fieldval=objfieldname.value
    var textval= document.getElementById(TextBoxid).value
    
    //alert(fieldval);
    //alert(textval);
    if(parseFloat(fieldval)>parseFloat(textval))
        {        
            alert(" Requested Vessel qty can not be greater than balance vessel qty");
            objfieldname.value="";
            objfieldname.focus();
            return false;
        }
    else
        {
            return true;
        }    
}

function Fun_checkDecimals(fieldName,DigitsAfterDecimal,totalDigitLength) 
{
	var Count=0;
	var digitcount=0;
	var MVal;
	MVal = fieldName.value;
	for (var i=0; i < fieldName.value.length; i++) 
	{
	      if (MVal.substring(i, i+1) == ".")		
		{
			Count= Count+1;	
		}
	      if(Count>=2)
		{

			alert("Only single decimal allowed");
			fieldName.value=MVal.substring(0, i);
			return false;
		}
		digitcount= digitcount +1;
		if( digitcount > totalDigitLength)
		{
		    alert("Please enter valid numeric value. Only " + totalDigitLength + " digits are allowed including Decimal point.");
		    fieldName.value=MVal.substring(0, totalDigitLength);
		    return false; 
		}
	}
	
	if(MVal.indexOf(".") > -1)                
		{                                        
			if(MVal.length - (MVal.indexOf(".")+1) > DigitsAfterDecimal)                    
			{                        
				alert("Please enter valid numeric value. Only " + DigitsAfterDecimal + " digits are allowed after decimal.");
				fieldName.value=MVal.substring(0, MVal.length -1);
				return false;                    
			}                    
			else                    
			{                      
				return true;                    
			}                
		}         

 
}

/// round of the number 
function formatNumber(myNum, numOfDec)
{
    var decimal = 1
    for(i=1; i<=numOfDec;i++)
    decimal = decimal *10

    var myFormattedNum = (Math.round(myNum * decimal)/decimal).toFixed(numOfDec)
    return(myFormattedNum)
}

//To call this function, use

//Alert(formatNumber(23244.4325, 2))


// check zero and zero combination

function checkzero(t)
{
var val = t.value;
if(parseInt(val)  == 0)
{
t.value = '';
t.focus();
}
}

function checkonlySpace(t)
    { 	 
    var val   = t.value.replace(/^\s+|\s+$/, ''); 
      // alert(t.value.length);
    if (val.length == 0) 
    {   
            t.value = ''; 
            //t.focus();
    } 
   }
   
    function OnlyNumber(t)
    {
    var cod = "0123456789";
    var v = cod
    var w = "";
    for (var i=0; i < t.value.length; i++) {
    x = t.value.charAt(i);
    if (v.indexOf(x,0) != -1)
    w += x;
    }
    t.value = w;
    }  
   
  

function AlfaNum3(t){
var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz";
var v = cod
var w = "";
for (var i=0; i < t.value.length; i++) {
x = t.value.charAt(i);
if (v.indexOf(x,0) != -1)
w += x;
}
t.value = w;
}


function OnlyAlfaOne(t){
var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
var v = cod
var w = "";
for (var i=0; i < t.value.length; i++) {
x = t.value.charAt(i);
if (v.indexOf(x,0) != -1)
w += x;
}
t.value = w;
}


// code for password validation

function disableCtrlKeyCombination(e)
 {
        //list all CTRL + key combinations you want to disable
        var forbiddenKeys = new Array('a', 'n', 'c', 'x', 'v', 'j');
        var key;
        var isCtrl;

        if(window.event)
        {
                key = window.event.keyCode;     //IE
                if(window.event.ctrlKey)
                        isCtrl = true;
                else
                        isCtrl = false;
        }
        else
        {
                key = e.which;     //firefox
                if(e.ctrlKey)
                        isCtrl = true;
                else
                        isCtrl = false;
        }

        //if ctrl is pressed check if other key is in forbidenKeys array
        if(isCtrl)
        {
                for(i=0; i<forbiddenkeys .length; i++)
                {
                        //case-insensitive comparation
                        if(forbiddenKeys[i].toLowerCase() == String.fromCharCode(key).toLowerCase())
                        {
                                alert('Key combination CTRL + '
                                        +String.fromCharCode(key)
                                        +' has been disabled.');
                                return false;
                        }
                }
        }
        return true;
}
	
	
	function validateConfPass(e, confPassword)
	 {
		keychar = getCharacterPressed(e);		
		var pass=document.getElementById('<%=txtPassword.ClientID%>');		
		if (keychar != "-1") {
			if (keychar == "backspace") {
				lenOfConf = confPassword.value.length - 1;
				if (confPassword.value.substr(0, lenOfConf) != pass.value.substr(0, lenOfConf))
					confPassword.style.background = "#FFBBBB";
				else
					confPassword.style.background = "#FFFFFF";
			}
			else {
				lenOfConf = confPassword.value.length + 1;
				if (confPassword.value + keychar != pass.value.substr(0, lenOfConf))
					confPassword.style.background = "#FFBBBB";
				else
					confPassword.style.background = "#FFFFFF";
			}
		}
		
		
	}
 
	function getCharacterPressed(e)
	 {
		code = getKeyCode(e);
		keychar = "-1";
		if (pressedPrintableChar(code))
			keychar = String.fromCharCode(code);
		if (code == 8)
			keychar = "backspace";
		return keychar;
	}
 
	function getKeyCode(e) 
	{
		code = -1;
		if (window.event)
			code = e.keyCode;
		else if (e.which)
			code = e.which;
		return code;
	}
 
	function pressedPrintableChar(code)
	 {
		if (code != 8 && code != 13 && code + "" != "undefined")
			return true;
		return false;
	}
	
	
	//Added by wasim 27-Dec-2010
  function pwd(action)
  {       
    var pwd1=document.getElementById('<%=txtPassword.ClientID%>');
    var pwd2=document.getElementById('<%=txtConfirmPassword.ClientID%>');
    var userid=document.getElementById('<%=txtuserid.ClientID%>');
    var username=document.getElementById('<%=txtUsername.ClientID%>');
    if(checkForm(username,userid,pwd1,pwd2)==true)
    {
                var userid=userid.value;
                 var username=username.value;
                    //userid=RSPLReplace(userid);
                //alert(userid);                
                var New=pwd1.value;
                
                var Confirm=pwd2.value;
                              
                                
                //var hexNew=hex_md5(New);
                //var hexConfirm=hex_md5(Confirm);
                
                //pwd.value=hexCurrent;
                //pwd1.value=hexNew;
                //pwd2.value=hexConfirm;
                
                //hexCurrent=RSPLReplace(hexCurrent);               
                //hexNew=RSPLReplace(hexNew);
                //hexConfirm=RSPLReplace(hexConfirm);
                if(!confirm('Do you want to '+action +' this record ?')) return false;
                else        
                return true;           
      }
      else
      {
        //alert('test');
        return false;
      }   
     
  }
	function checkForm(username,userid,pwd1,pwd2)
  {    
    re = /^\w+$/;
    if(!re.test(pwd1.value)) 
    {
    //alert('2');
      alert("Pasword must contain only letters, numbers and underscores!");
      pwd1.focus();
      return false;
    }
      if(pwd1.value == username.value || pwd1.value == userid.value)
       {
       
        alert("Password must be different from User Name and User ID!");
        pwd1.focus();
        return false;
      }
      
      re = /[0-9]/;
      if(!re.test(pwd1.value)) 
      {
       //alert('6');
        alert("password must contain at least one number (0-9)!");
        pwd1.focus();
        return false;
      }
       re = /^.*[a-zA-Z]+.*$/;
      if(!re.test(pwd1.value)) 
      {
      //alert('7');
        alert("password must contain at least one letter !");
        pwd1.focus();
        return false;
      }
     if(!re.test(pwd2.value))
      {
      // alert('3');
      alert("Confirm Password must contain only letters, numbers and underscores!");
      pwd2.focus();
      return false;
    }

    if(pwd1.value != "" && pwd1.value == pwd2.value) 
    {
      if(pwd1.value.length < 8)
       {
       //alert('4');
        alert("Password must contain at least 8 characters!");
        pwd1.focus();
        return false;
      }
    
      /*
      re = /[A-Z]/;
      if(!re.test(pwd1.value)) 
      {
       // alert('8');
        alert("Error: password must contain at least one uppercase letter (A-Z)!");
        pwd1.focus();
        return false;
      }*/
    } 
    else 
    {
      //alert('9');
      alert("Please check that you've entered and confirmed your password!");
      pwd1.focus();
      return false;
    }

    //alert("You entered a valid password: " + form.pwd1.value);
    return true;
  }
function AlfaNum2(t){
var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz0123456789";
var v = cod
var w = "";
for (var i=0; i < t.value.length; i++) {
x = t.value.charAt(i);
if (v.indexOf(x,0) != -1)
w += x;
}
t.value = w;
}

function AlfaNum3(t) {
    var cod = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz";
    var v = cod
    var w = "";
    if (event.keyCode >= 37 && event.keyCode <= 40) {
    }
    else {
        for (var i = 0; i < t.value.length; i++) {
            x = t.value.charAt(i);
            if (v.indexOf(x, 0) != -1)
                w += x;
        }
        t.value = w;
    } 
}