
//***************function for email-id validation*********************
function valid_email(eml)
{
	return (/^([a-zA-Z0-9]+([\.+_-][a-zA-Z0-9]+)*)@(([a-zA-Z0-9]+((\.|[-]{1,2})[a-zA-Z0-9]+)*)\.[a-zA-Z]{2,6})$/).test(eml);
}
//////////////////////////////////////////////////////////////////////////

//***************function for email-id validation*********************
/*function valid_email(eml)
{
    
    Hexillion_valid_email(eml);
    if (fetchResult()== false)
    {
        return false;
    }
    
    return (/^([a-zA-Z0-9]+([\.+_-][a-zA-Z0-9]+)*)@(([a-zA-Z0-9]+((\.|[-]{1,2})[a-zA-Z0-9]+)*)\.[a-zA-Z]{2,6})$/).test(eml);
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////
*/
////////// Validate email ID using Hexillion component ///////////////////////////////////////////////////
function Hexillion_valid_email(val)
{
    ajaxinstance_email = createAjaxObj();
    xmlindicator = (arguments.length>0)? 1 : 0;
	ajaxinstance_email.onreadystatechange = fetchResult;
	if (checkBlankField(val) != false)						
	{					
		ajaxinstance_email.open('GET', "Ajax/Hexillion_Valid_Email.aspx?emailid="+val+"&for=validemail", false);
		ajaxinstance_email.send(null)
	}
}

function fetchResult()
{
	var mstr_text = new String();
	if (ajaxinstance_email.readyState==4)
	{ 
		//if request of file completed
		mstr_text = (ajaxinstance_email.responseText);
		if(mstr_text != 3 )
		{
			return false;
		}
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

// ******** CREATE AJAX INSTANCE *************************************
function createAjaxObj()
{
	var httprequest = false
	
	if (window.XMLHttpRequest)
	{ // if Mozilla, Safari etc  Non-IE browsers
		httprequest=new XMLHttpRequest()
		
		if (httprequest.overrideMimeType)
			httprequest.overrideMimeType('text/text')
	} 
	else if (window.ActiveXObject)
	{ // if IE
		try 
		{
			httprequest=new ActiveXObject("Msxml2.XMLHTTP");
		} 
		catch (e)
		{
			try
			{
				httprequest=new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch (e){}
		}
	}
	return httprequest
}	
///////////////////////////////////////////////////////////////////////////////////










	//declare the required variables
	//This function is commented By Amit Srivastava since it is unable to validate email: 'ams@yy'
//	var mint_len;
//	var mstr_eml = eml;
//	var mint_at = 0;
//	var mint_atnum = 0;
//	var mint_dot = 0;
//	var mint_firstdot = 0;
//	var mint_dotnum = 0;
//	
//	mint_len=eml.length; //takes the length of the email address entered
//	
//	//checking for the symbol single quote. If found replace it with its html code
//	if (mstr_eml.indexOf("'")!=-1)
//	{
//		mstr_eml=mstr_eml.replace("'","&#39;");
//	}
//	
//	//checking for the (@) & (.) symbol
//	for(var iloop=0;iloop<mint_len;iloop++)
//	{
//		if(mstr_eml.charAt(iloop)=="@")
//		{
//			mint_at=iloop+1;
//			mint_atnum=mint_atnum+1;
//		}
//		if(mstr_eml.charAt(iloop)==".")
//		{
//			if (mint_dot-(iloop+1))
//			{
//				if((iloop+1-mint_dot)==1)
//				{
//					return false;
//				}
//			}
//			mint_dot=iloop+1;
//			if ((mint_at!=0)&&(mint_firstdot==0))
//			{
//				mint_firstdot = iloop + 1;
//			}
//			mint_dotnum=mint_dotnum+1;
//		}
//	}
//	//if nothing entered in the field
//	if (mstr_eml=="")
//	{
//		return false
//	}
//	
//	//if @ entered more than once & dot (.) entered more than 4 times
//	else if((mint_atnum!=1)||(mint_dotnum>4)||(Math.abs(mint_firstdot-mint_at)<2)||((mint_len-mint_dot)<2)||(mint_at<3))
//	{
//		return false;
//	}
//	
//	//if any blank space is entered in the email address
//	else if (mstr_eml.indexOf(" ")!=-1)
//	{
//		return false;
//	}
//    var pattern=;
//    return pattern.test(eml);
//}
//////////////////////////////////////////////////////////////////////////

/***********fuction for date validation****************** commented By neha - dd/mm/yyyy format required

function valid_date(datevalue)
{
	var input_date=new String(datevalue);
	var dat;
	var count=0;
	
	for (var m=0;m<input_date.length;m++)
	{
		if ((input_date.charAt(m)=="/"))
		{
			count=count+1;
		}
	}
	if ((input_date.indexOf(" ")!=-1)||(count!=2))
	{
		return false;
	}
	if (input_date.indexOf("/")!=-1)
	{
		dat=input_date.split("/");
	}
			
	/////validations for month
	
	if (isNaN(dat[0]))
	{
		return false;
	}
	else if ((dat[0]<1)||(dat[0])>12)
	{
		return false;
	}
		
	//validations for days
	
	if (isNaN(dat[1]))
	{
		return false;
	}
	else if (dat[1]<1)
	{
		return false;
	}	
	else if ((Math.abs(dat[0])=="1")||(Math.abs(dat[0])=="3")||(Math.abs(dat[0])=="5")||(Math.abs(dat[0])=="7")||(Math.abs(dat[0])=="8")||(Math.abs(dat[0])=="10")||(Math.abs(dat[0])=="12"))
	{
		if ((Math.abs(dat[1])<1)||(Math.abs(dat[1])>31))
		{
		return false;
		}
	}	
	else if ((Math.abs(dat[0])=="4")||(Math.abs(dat[0])=="6")||(Math.abs(dat[0])=="9")||(Math.abs(dat[0])=="11"))
	{
		if ((Math.abs(dat[1])<1)||(Math.abs(dat[1])>30))
		{
			return false;
		}
	}
	else if (Math.abs(dat[0])==2)
	{
			
		if ((Math.abs(dat[2]) % 4)==0)
		{
			if ((Math.abs(dat[1])<1)||(Math.abs(dat[1])>29))
			{
			return false;
			}
		}
		else
		{
			if((Math.abs(dat[1])<1)||(Math.abs(dat[1])>28))
			{
				return false;
			}
		}	
	}
	
	
	//validation for year
	
	if (isNaN(dat[2]))
	{
		return false;
	}
	else if ((dat[2].length!=2)&&(dat[2].length!=4))
	{
		return false;
	}
}
*********************************************************/

//***********fuction for date validation******************

function valid_date(datevalue)
{
	var input_date=new String(datevalue);
	input_date = input_date.replace("/0","/");
	var dat;
	var count=0;
	
	for (var m=0;m<input_date.length;m++)
	{
		if (input_date.charAt(m)=="/")
		{
			count=count+1;
		}
	}
	if ((input_date.indexOf(" ")!=-1)||(count!=2))
	{
		return false;
	}
	if (input_date.indexOf("/")!=-1)
	{
		dat=input_date.split("/");
	}
	
		
	/////validations for month
	
	if (isNaN(dat[0]))
	{
		return false;
	}
	else if ((dat[0]<1)||(dat[0])>12)
	{
		return false;
	}
		
	//validations for days
	
	if (isNaN(dat[1]))
	{
		return false;
	}
	else if ((dat[0]=="1")||(dat[0]=="3")||(dat[0]=="5")||(dat[0]=="7")||(dat[0]=="8")||(dat[0]=="10")||(dat[0]=="12"))
	{
		if ((dat[1]<1)||(dat[1]>31))
		{
			return false;
			}
	}	
	else if ((dat[0]=="4")||(dat[0]=="6")||(dat[0]=="9")||(dat[0]=="11"))
		{
			if ((dat[1]<1)||(dat[1]>30))
				{
				return false;
				}
		}
	else if (dat[0]==2)
		{
			
			if ((dat[2] % 4)==0)
				{
				if ((dat[1]<1)||(dat[1]>29))
					{
					return false;
					}
				}
			else
				if((dat[1]<1)||(dat[1]>28))
					{
					return false;
					}
		}
	
	//validation for year
	
	if (isNaN(dat[2]))
	{
		return false;
	}
	if ((dat[2].length!=2)&&(dat[2].length!=4))
	{
		return false;
	}
	if(parseInt(dat[2])<1753)
	{
		return false;
	}
}



//*****************function for checking blank field*******************
function checkBlankField(txt)
{
	var mint_txt=txt.length; //Takes the total length of the value entered
	var mstr_txt=txt;
	var mint_count=0;
	
	//checking with each character for space
	for(var iloop=0;iloop<mint_txt;iloop++)
	{
		if(mstr_txt.charAt(iloop)==" ")
		{
			mint_count=mint_count+1;
		}
	}
	
	//if nothing entered in the field
	if (txt=="")
	{
		return false;
	}
	
	//if only spaces are entered
	else if (mint_count==mint_txt)
	{
		return false;
	}
}

//************/////////Compare two dates(2nd Date not more than 1st Date)/////////********************************
/* commented by neha
function compareDates(date1,date2)
{
	//date1 < date2
	// Ex. 12/1/2001 - 1/1/2001
	var input_date1=new String(date1);
	var input_date2=new String(date2);
	var dat1;
	var dat2;
	var count1=0;
	var count2=0;
	var dates1=new Date(date1);
	var dates2=new Date(date2);
	var year1=dates1.getFullYear();
	var year2=dates2.getFullYear();
	
	
	//split date1
	for (var m=0;m<input_date1.length;m++)
	{
		if ((input_date1.charAt(m)=="/")||(input_date1.charAt(m)=="."))
		{
			count1=count1+1;
		}
	}
	if ((input_date1.indexOf(" ")!=-1)||(count1!=2))
	{
		return false;
	}
	if (input_date1.indexOf("/")!=-1)
	{
		dat1=input_date1.split("/");
	}
	else if (input_date1.indexOf(".")!=-1)
	{
		dat1=input_date1.split(".");
	}
	
	//split date2
	for (var m=0;m<input_date2.length;m++)
	{
		if ((input_date2.charAt(m)=="/")||(input_date2.charAt(m)=="."))
		{
			count2=count2+1;
		}
	}
	if ((input_date2.indexOf(" ")!=-1)||(count2!=2))
	{
		return false;
	}
	if (input_date2.indexOf("/")!=-1)
	{
		dat2=input_date2.split("/");
	}
	else if (input_date2.indexOf(".")!=-1)
	{
		dat2=input_date2.split(".");
	}
	
	
	////compare years
	
	//if (parseInt(dat2[2])>parseInt(dat1[2]))
	if (parseInt(Math.abs(year2))>parseInt(Math.abs(year1)))
	{		
		return false;
	}
	if 	(parseInt(dat2[2])==parseInt(dat1[2]))
	{
		if (parseInt(Math.abs(dat2[0]))>parseInt(Math.abs(dat1[0])))
		{
			return false;
		}
	}
	if 	((parseInt(Math.abs(dat2[2]))==parseInt(Math.abs(dat1[2])))&& (parseInt(Math.abs(dat2[0]))==parseInt(Math.abs(dat1[0]))))
	{
	 	if (parseInt(Math.abs(dat2[1]))>parseInt(Math.abs(dat1[1])))
		{
			return false;
		}
	}			
}		
*/

//************/////////Compare two dates(2nd Date not more than 1st Date)/////////********************************

function compareDates(date1,date2)
{
	var dat1;
	var dat2;
	var count1=0;
	var count2=0;
	var mint_day1;
	var mint_day2;
	
	//date1 < date2
	// Ex. 12/1/2001 - 1/1/2001
	var input_date1=new String(date1);
	var input_date2=new String(date2);
	input_date1 = input_date1.replace("/0","/");
	input_date2 = input_date2.replace("/0","/");
	//split date1
	dat1=input_date1.split("/");
			
	//split date2
	dat2=input_date2.split("/");
	
	////
	if(parseInt(dat1[0])<10)
	{
		mint_day1 = new String(dat1[0]);
		mint_day1 = mint_day1.replace("0","");
	}
	else
	{
		mint_day1 = parseInt(dat1[0])
	}
	
	if(parseInt(dat2[0])<10)
	{
		mint_day2 = new String(dat2[0]);
		mint_day2 = mint_day2.replace("0","");
	}
	else
	{
		mint_day2 = parseInt(dat2[0])
	}
	
	var dates1=new Date(parseInt(dat1[1])+"/"+parseInt(mint_day1)+"/"+parseInt(dat1[2]));
	var dates2=new Date(parseInt(dat2[1])+"/"+parseInt(mint_day2)+"/"+parseInt(dat2[2]));
	
	//alert(dates1+dates2)
	var year1=dates1.getFullYear();
	var year2=dates2.getFullYear();
	
	////compare years
	
	//if ((dat2[2])>(dat1[2]))
	if (parseInt(year2)>parseInt(year1))
	{
		//alert("year2 > year1")
		return false;
	}
	if 	(parseInt(dat2[2])==parseInt(dat1[2]))
	{
		if (parseInt(dat2[1])>parseInt(dat1[1]))
		{
			//alert("same year and month1 > month2")
			return false;
		}
	}
	if 	((parseInt(dat2[2])==parseInt(dat1[2]))&& (parseInt(dat2[1])==parseInt(dat1[1])))
	 {
	 	if (mint_day2>mint_day1)
		{
			return false;
		}
		
	}		
}		


//***********///////////validations for Date not more than current date/////////*******************
// this takes system date as current date	
function checkCurrentDate(datevalue)
{
	var input_date=new String(datevalue);
	var dat;
	var count=0;
	
	for (var m=0;m<input_date.length;m++)
		{
		if ((input_date.charAt(m)=="/")||(input_date.charAt(m)=="."))
			{
			count=count+1;
			}
		}
	if ((input_date.indexOf(" ")!=-1)||(count!=2))
		{
		return false;
		}
	if (input_date.indexOf("/")!=-1)
		{
		dat=input_date.split("/");
		}
	else if (input_date.indexOf(".")!=-1)
		{
		dat=input_date.split(".");
		}
	
		
	/////validations for month
	
	if (isNaN(dat[0]))
		{
		return false;
		}
	else if ((dat[0]<1)||(dat[0])>12)
		{
		return false;
		}
		
	//validations for days
	
	if (isNaN(dat[1]))
		{
		return false;
		}
	else if ((dat[0]=="1")||(dat[0]=="3")||(dat[0]=="5")||(dat[0]=="7")||(dat[0]=="8")||(dat[0]=="10")||(dat[0]=="12"))
		{
		
			if ((parseInt(Math.abs(dat[1]))<1)||(parseInt(Math.abs(dat[1]))>31))
				{
				return false;
				}
		}	
	else if ((dat[0]=="4")||(dat[0]=="6")||(dat[0]=="9")||(dat[0]=="11"))
		{
			if ((parseInt(Math.abs(dat[1]))<1)||(parseInt(Math.abs(dat[1]))>30))
				{
				return false;
				}
		}
	else if (dat[0]==2)
		{
			
			if ((dat[2] % 4)==0)
				{
				if ((parseInt(Math.abs(dat[1]))<1)||(parseInt(Math.abs(dat[1]))>29))
					{
					return false;
					}
				}
			else
				if((parseInt(Math.abs(dat[1]))<1)||(parseInt(Math.abs(dat[1]))>28))
					{
					return false;
					}
		}
		
	//validation for year
	
	var cur_date=new Date();
	
	if (isNaN(dat[2]))
		{
			return false;
		}
	else if ((dat[2].length!=2)&&(dat[2].length!=4))
		{
			return false;
		}
	else if (parseInt(Math.abs(dat[2]))>parseInt(Math.abs(cur_date.getFullYear())))
		{
			return false;
		}
	else if ((parseInt(Math.abs(dat[2]))==parseInt(Math.abs(cur_date.getFullYear()))) || (parseInt(Math.abs(dat[2]))==parseInt(Math.abs(cur_date.getYear()))))
		{
			if (parseInt(Math.abs(dat[0]))==(parseInt(Math.abs(cur_date.getMonth()))+1))
				{
					if(parseInt(Math.abs(dat[1]))>parseInt(Math.abs(cur_date.getDate())))
						{
							return false;
						}
				}
			else if (parseInt(Math.abs(dat[0]))>parseInt(Math.abs(cur_date.getMonth())))
				{
					return false;
				}	
		}
	
}

//******************////////////////validations for PhoneNumber fields //////////******************
function checkPhoneNumber(num)
{
	var mint_num=num;
	var mint_len=num.length;
	var mstr_ph;
	var mint_nm=0;
	
	for (var m=0;m<mint_len;m++)
	{
		mstr_ph=mint_num.charAt(m)
		if(mstr_ph==" ")
			{
			mint_nm=mint_nm+1;
			}
		if (isNaN(mstr_ph))
			{
			if ((mstr_ph!="+")&&(mstr_ph!="-")&&(mstr_ph!=",")&&(mstr_ph!="(")&&(mstr_ph!=")"))
				{			
				mint_nm=mint_nm+1;
				}
					
			}
	}
	//if((mint_num=="")||(mint_nm!=0)||(mint_len<=5))
	//Changed by raj to check for 10 digit 
	if((mint_num=="")||(mint_nm!=0)||(mint_len<=7))
	{
		return false;
	}
}

function checkMobileNumber(num)
{
	var mint_num=num;
	var mint_len=num.length;
	var mstr_ph;
	var mint_nm=0;
	
	for (var m=0;m<mint_len;m++)
	{
		mstr_ph=mint_num.charAt(m)
		if(mstr_ph==" ")
			{
			mint_nm=mint_nm+1;
			}
		if (isNaN(mstr_ph))
			{
			if ((mstr_ph!="+")&&(mstr_ph!="-")&&(mstr_ph!=",")&&(mstr_ph!="(")&&(mstr_ph!=")"))
				{			
				mint_nm=mint_nm+1;
				}
					
			}
	}
	//if((mint_num=="")||(mint_nm!=0)||(mint_len<=5))
	//Changed by Raj to check for mobile no as 10 digit
	if((mint_num=="")||(mint_nm!=0)||(mint_len<=9))
	{
		return false;
	}
}	

//***************////////////validations for ZipCode fields ////////////**************************
	
function checkZip(num)
{
	var mint_zip=num;
	var mint_len=num.length;
	var mstr_zip;
	var mstr_zipcode
	
	for (var m=0;m<mint_len;m++)
	{
		mstr_zip=mint_zip.charAt(m)
		if ((isNaN(mstr_zip))||(mstr_zip==" "))
		{
			mstr_zipcode="invalid" 					
		}
	}
	if ((mstr_zipcode=="invalid")||(mint_zip=="")||(mint_len!=6))
	{
		return false;
	}
}

//***************************************Validations for Check Box**************************

function checkCheckbox(chbx)
{
	var mint_len= chbx.length;
	var mstr_txt=0;
	
	if((chbx.checked)==true)
	{
		return true;
	}
	for(var iloop=0;iloop<mint_len;iloop++)
	{
		if (chbx[iloop].checked)
		{
			mstr_txt=mstr_txt+1 ;
		}
	}
	if (mstr_txt==0)
	{
		return false;
	}	
}

//**************************Function to check Positive Integer****************************
function checkPositiveInteger(val)
{
	if (isNaN(val)==true)
    {
		return false;
    }
    var mystring=new String(val)
	var x=mystring.indexOf(".")
	if (x!="-1")
    {
		return false;
    }
    if(mystring.indexOf("e")!="-1" || mystring.indexOf("E")!="-1")
    {
		return false;
    }
    if (val<=0)
    {
		return false;
    }    
	
}
//********************** Function to Check Difference between Two Dates in no. of. DAYS*********
// will return date1-date2

function dateDifference(date1,date2)
{
	var dates1=new Date(date1);
	var dates2=new Date(date2);
	
	if (((dates1-dates2)/86400000)<31)
	{
		return false;
	}
		
}

//********************** Function to Return Difference between Two Dates in no. of. DAYS*********
// will return date1-date2

function dateDiff(date1,date2)
{
	var d1=date1.split("/");
	var d2=date2.split("/");
	var dates1=new Date(d1[1]+"/"+d1[0]+"/"+d1[2]);
	var dates2=new Date(d2[1]+"/"+d2[0]+"/"+d2[2]);
	
	return ((dates1-dates2)/86400000);
}



//********************** Function to Get Difference between Two Dates in no. of. DAYS*********
// will return date1-date2

function GetDays(date1,date2)
{
	var dates1=new Date(date1);
	var dates2=new Date(date2);
		
	return  ((dates1-dates2)/86400000)
		
}

//********************** Function to Check VALID URL *********

// *********** ALPHA-Numeric check ***************************
function checkAlphaNumeric(val)
{    
    var mystring=new String(val)
    
    if(mystring.search(/[0-9]+/)==-1) // Check at-leat one number
    {
        return false;
    }
    if(mystring.search(/[A-Z]+/)==-1 && mystring.search(/[a-z]+/)==-1) // Check at-leat one character
    {
        return false;
    }
}
/*
	Password Validator 0.1
	(c) 2007 Steven Levithan <stevenlevithan.com>
	MIT License
*/
function validatePassword (pw, options) {
	//default options (allows any password)
	var o = {
		lower:    0,
		upper:    0,
		alpha:    0, /* lower + upper */
		numeric:  0,
		special:  0,
		length:   [0, Infinity],
		custom:   [ /* regexes and/or functions */ ],
		badWords: [],
		badSequenceLength: 0,
		noQwertySequences: false,
		noSequential:      false
	};

	for (var property in options)
		o[property] = options[property];

	var	re = {
			lower:   /[a-z]/g,
			upper:   /[A-Z]/g,
			alpha:   /[A-Z]/gi,
			numeric: /[0-9]/g,
			special: /[\W_]/g
		},
		rule, i;

    var	re_special = {			
			special_rule: /[\W_]/g
		}, rule_special;
		
	// enforce min/max length
	if (pw.length < o.length[0] || pw.length > o.length[1])
		return false;

	// enforce lower/upper/alpha/numeric/special rules
	for (rule in re) {
		if ((pw.match(re[rule]) || []).length < o[rule])
			return false;
	}
	
	// enforce special rules
	for (rule_special in re_special) {
		if (pw.match(re_special[rule_special]))
			return false;
	}

	// enforce word ban (case insensitive)
	for (i = 0; i < o.badWords.length; i++) {
		if (pw.toLowerCase().indexOf(o.badWords[i].toLowerCase()) > -1)
			return false;
	}

	// enforce the no sequential, identical characters rule
	if (o.noSequential && /([\S\s])\1/.test(pw))
		return false;

	// enforce alphanumeric/qwerty sequence ban rules
	if (o.badSequenceLength) {
		var	lower   = "abcdefghijklmnopqrstuvwxyz",
			upper   = lower.toUpperCase(),
			numbers = "0123456789",
			qwerty  = "qwertyuiopasdfghjklzxcvbnm",
			start   = o.badSequenceLength - 1,
			seq     = "_" + pw.slice(0, start);
		for (i = start; i < pw.length; i++) {
			seq = seq.slice(1) + pw.charAt(i);
			if (
				lower.indexOf(seq)   > -1 ||
				upper.indexOf(seq)   > -1 ||
				numbers.indexOf(seq) > -1 ||
				(o.noQwertySequences && qwerty.indexOf(seq) > -1)
			) {
				return false;
			}
		}
	}

	// enforce custom regex/function rules
	for (i = 0; i < o.custom.length; i++) {
		rule = o.custom[i];
		if (rule instanceof RegExp) {
			if (!rule.test(pw))
				return false;
		} else if (rule instanceof Function) {
			if (!rule(pw))
				return false;
		}
	}
	// great success!
	return true;
}
// *********************************************************//

function validURL(url)
{	
	var len, mint_dot
	mint_dot=0;
	//url=document.frm_insert.txt_url.value;
	len=url.length;
	if (url!='')
	{
		if(len<=10)
		{
			//alert("URL cannot be less than 10 characters");
			return false;
		}
		if ((url.charAt(0)!='h' || url.charAt(1)!='t' || url.charAt(2)!='t' || url.charAt(3)!='p' || url.charAt(4)!=':' || url.charAt(5)!='/' || url.charAt(6)!='/') && (url.charAt(0)!='h' || url.charAt(1)!='t' || url.charAt(2)!='t' || url.charAt(3)!='p' || url.charAt(4)!='s' || url.charAt(5)!=':' || url.charAt(6)!='/' || url.charAt(7)!='/'))
		{
			//alert('URL should start with http://');
			//document.frm_insert.txt_url.focus();
			//document.frm_insert.txt_url.select();
			return false;
		}
			
		if(url.charAt(len-1)=='.')
		{
			//alert("Dot cannot be a last character");
			//document.frm_insert.txt_url.focus();
			//document.frm_insert.txt_url.select();
			return false;
		}
			
		for(var mint_i=0;mint_i<=len;mint_i++)		
		{
			if (url.charAt(mint_i)=='.')
			{
				mint_dot=mint_dot+1;
				mint_n=mint_i+1
			}
		}
			
		if (url.indexOf("..")!=-1)
		{
			//alert("You cannot enter dots like this (..)");
			//document.frm_insert.txt_url.focus();
			//document.frm_insert.txt_url.select();
			return false;
		}
					
		if (mint_dot<1)
		{
			//alert("URL should include atleast one dot");
			//document.frm_insert.txt_url.focus();
			//document.frm_insert.txt_url.select();
			return false;
		}
			
		var mint_no=len-mint_n
		if (mint_no<2)
		{
			//alert("There should be atleast 2 characters after the dot");
			//document.frm_insert.txt_url.focus();
			//document.frm_insert.txt_url.select();
			return false;
		}
	}
}
//********************** Function to check Valid ISBN10 *********
function checkISBN10(isbn)
{
	//alert("ISBN:"+isbn);
	if (isbn.length!=10)
	{
		return false;
	}
	else
	{
		for(var iloop=0;iloop<=8;iloop++)
		{
			if (isNaN(isbn.charAt(iloop)))
			{
				return false;
			}
		}
		if (isNaN(isbn.charAt(9)))
		{
			if ((isbn.charAt(9)).toUpperCase() != "X")
			{	
				return false;
			}
		}
	}
}	

//********************** Function to check Valid ISBN13 *********
function checkISBN(isbn)
{
	if (isbn.length!=13)
	{
		return false;
	}
	else
	{
		for(var iloop=0;iloop<=12;iloop++)
		{
			if (isNaN(isbn.charAt(iloop)))
			{
				return false;
			}
		}
	}
}	

//********************** 

///Function to trap tab key
function fn_Tab()
{
	
	var a=window.event.keyCode

	if (a!="9")
	{
		return false;
	}
	
}

function rightclick()
{
	if(event.button==2)
	{
		alert("Right Click not allowed");
		return false;
	}
}


//***********fuction for time validation******************
function valid_time(timevalue)
{
	var input_time=new String(timevalue);
	input_time = input_time.replace(":0",":");
	var tim;
	var count=0;
	
	for (var m=0;m<input_time.length;m++)
	{
		if (input_time.charAt(m)==":")
		{
			count=count+1;
		}
	}
	if ((input_time.indexOf(" ")!=-1)||(count!=1))
	{
		return false;
	}
	if (input_time.indexOf(":")!=-1)
	{
		tim=input_time.split(":");
	}
	
		
	/////validations for minutes
	
	if (isNaN(tim[1]))
	{
		return false;
	}
	else if ((tim[1]<0)||(tim[1])>59)
	{
		return false;
	}
		
	//validations for hours
	
	if (isNaN(tim[0]))
	{
		return false;
	}
	if ((tim[0]<0)||(tim[0]>24))
	{
		return false;
	}
	if ((tim[0]==0)&&(tim[1]==0))
	{
		return false;
	}
	
	
}

//---Function To Compare Time.
function compareTime(time1,time2)
{
	var t1 = time1;
	var t2 = time2;
	var t1_str = t1.split(":")
	var t2_str = t2.split(":")
	if(t1_str[0].length==1)
		t1 = "0" + t1;
	if(t2_str[0].length==1)
		t2 = "0" + t2;
	t1 = t1.replace(":","");
	t2 = t2.replace(":","");
	return (t1>=t2);
}

function checkValidImage(imageurl)
{   
    if ((imageurl.indexOf(".gif")==-1) && (imageurl.indexOf(".GIF")==-1) && (imageurl.indexOf(".jpg")==-1) && (imageurl.indexOf(".JPG")==-1) && (imageurl.indexOf(".png")==-1) && (imageurl.indexOf(".PNG")==-1))
    {
        return false;
    }
}

function checkValidFile(imageurl)
{   
    if ((imageurl.indexOf(".doc")==-1) && (imageurl.indexOf(".DOC")==-1) && (imageurl.indexOf(".xls")==-1) && (imageurl.indexOf(".XLS")==-1) && (imageurl.indexOf(".pdf")==-1) && (imageurl.indexOf(".PDF")==-1))
    {
        return false;
    }
}

function checkPrice(num)
{
	var mint_dot = 0;
	var mstr_char = new String(num);
	mint_position = 0;
	for(var mint_char=0;mint_char<mstr_char.length;mint_char++)
	{
		//if not digits
		if(mstr_char.charAt(mint_char)!="0" && mstr_char.charAt(mint_char)!="1" && mstr_char.charAt(mint_char)!="2" && mstr_char.charAt(mint_char)!="3" && mstr_char.charAt(mint_char)!="4" && mstr_char.charAt(mint_char)!="5" && mstr_char.charAt(mint_char)!="6" && mstr_char.charAt(mint_char)!="7" && mstr_char.charAt(mint_char)!="8" && mstr_char.charAt(mint_char)!="9" && mstr_char.charAt(mint_char)!=".")
		{
			return false;
		}
		if(mstr_char.charAt(mint_char)==".")
		{
			mint_dot = mint_dot + 1
			mint_position = mstr_char.indexOf(".");
		}
	}
	//if number of dots is more than one
	if(mint_dot>1)
	{
		return false;
	}
	//check no. of characters after dot mark
	if(mint_dot != 0)
	{
		if((parseInt(mstr_char.length)-1)-parseInt(mint_position)>2)
		{
			return false;
		}
	}
}


//***********fuction for date validation (mm/dd)******************

function valid_date_mmdd(datevalue)
{
	var input_date=new String(datevalue);
	var dat;
	var count=0;
	
	for (var m=0;m<input_date.length;m++)
	{
		if ((input_date.charAt(m)=="/"))
		{
			count=count+1;
		}
	}
	if ((input_date.indexOf(" ")!=-1)||(count!=1))
	{
		return false;
	}
	if (input_date.indexOf("/")!=-1)
	{
		dat=input_date.split("/");
	}
			
	/////validations for month
	
	if (isNaN(dat[0]))
	{
		return false;
	}
	else if ((dat[0]<1)||(dat[0])>12)
	{
		return false;
	}
		
	//validations for days
	
	if (isNaN(dat[1]))
	{
		return false;
	}
	else if (dat[1]<1)
	{
		return false;
	}	
	else if ((Math.abs(dat[0])=="1")||(Math.abs(dat[0])=="3")||(Math.abs(dat[0])=="5")||(Math.abs(dat[0])=="7")||(Math.abs(dat[0])=="8")||(Math.abs(dat[0])=="10")||(Math.abs(dat[0])=="12"))
	{
		if ((Math.abs(dat[1])<1)||(Math.abs(dat[1])>31))
		{
		return false;
		}
	}	
	else if ((Math.abs(dat[0])=="4")||(Math.abs(dat[0])=="6")||(Math.abs(dat[0])=="9")||(Math.abs(dat[0])=="11"))
	{
		if ((Math.abs(dat[1])<1)||(Math.abs(dat[1])>30))
		{
			return false;
		}
	}
	else if (Math.abs(dat[0])==2)
	{
			
		if ((Math.abs(dat[2]) % 4)==0)
		{
			if ((Math.abs(dat[1])<1)||(Math.abs(dat[1])>29))
			{
			return false;
			}
		}
		else
		{
			if((Math.abs(dat[1])<1)||(Math.abs(dat[1])>28))
			{
				return false;
			}
		}	
	}
}
//***************function for check bad characters*********************
function validString(str)
{
	//declare the required variables
	var mint_len;
	var mstr_str = new String();
	mstr_str = str;
	mstr_str = mstr_str.toUpperCase();
	
	mint_len=str.length; //takes the length of the string entered
	
	//checking for the bad characters
	for(var iloop=0;iloop<mint_len;iloop++)
	{
		// Check "<" 
		if(mstr_str.charAt(iloop)=="<")
		{
			return false
		}
		// Check ">" 
		else if(mstr_str.charAt(iloop)==">")
		{
			return false
		}
		// Check "&lt;" 
		else if((mstr_str.charAt(iloop)=="&") && (mstr_str.charAt(iloop+1)=="L") && (mstr_str.charAt(iloop+2)=="T") && (mstr_str.charAt(iloop+3)==";"))
		{
			return false
		}
		// Check "&gt;" 
		else if((mstr_str.charAt(iloop)=="&") && (mstr_str.charAt(iloop+1)=="G") && (mstr_str.charAt(iloop+2)=="T") && (mstr_str.charAt(iloop+3)==";"))
		{
			return false
		}
		// Check "&#60;" 
		else if((mstr_str.charAt(iloop)=="&") && (mstr_str.charAt(iloop+1)=="#") && (mstr_str.charAt(iloop+2)=="6") && (mstr_str.charAt(iloop+3)=="0")&& (mstr_str.charAt(iloop+4)==";"))
		{
			return false
		}
		// Check "&#62;"
		else if((mstr_str.charAt(iloop)=="&") && (mstr_str.charAt(iloop+1)=="#") && (mstr_str.charAt(iloop+2)=="6") && (mstr_str.charAt(iloop+3)=="2")&& (mstr_str.charAt(iloop+4)==";"))
		{
			return false
		}
		// Check "&rsquo;"
		else if((mstr_str.charAt(iloop)=="&") && (mstr_str.charAt(iloop+1)=="R") && (mstr_str.charAt(iloop+2)=="S") && (mstr_str.charAt(iloop+3)=="Q") && (mstr_str.charAt(iloop+4)=="U")&& (mstr_str.charAt(iloop+5)=="O") && (mstr_str.charAt(iloop+6)==";"))
		{
			return false
		}
		// Check "^*"
		else if((mstr_str.charAt(iloop)=="^") && (mstr_str.charAt(iloop+1)=="*"))
		{
			return false
		}
		
	}
}
//////////////////////////////////////////////////////////////////////////

//Added by Neena for header search on 8/4/2011
    function clearText(field)
    {
        if (field.defaultValue == field.value) field.value = '';
        else if (field.value == '') field.value = field.defaultValue;
    }
    function div_close()
    {
       if(document.getElementById("signin_menu"))
        document.getElementById("signin_menu").style.display = 'none'; 
    }
    function divopen(txt_emaillogin)
    {
        if(document.getElementById("signin_menu").style.display != 'block')
        {
            document.getElementById("signin_menu").style.display = 'block';
            txt_emaillogin.focus();
        }
        else 
        {
           document.getElementById("signin_menu").style.display = 'none';
        }    
    }
     
    function copyEmail(txt_email)
    { 
         debugger;
        //fn_checkEmail();
        document.getElementById("hid_email").value = document.getElementById(txt_email).value;
        //return false;
    }
    
    //**************
    
    function fn_checkEmail()
    {
        var xmlhttp;
        var url= "ajax/ajax.aspx?emailer=abc"
        xmlhttp =  createAjaxObj();
        xmlhttp.open("GET",url,true);
        xmlhttp.send(null);
        xmlhttp.onreadystatechange = function()
        {
            if(xmlhttp.readyState == 4)
            {
                //alert(xmlhttp.responseText);
            }
        }
        
    }
    
    
    //***********************
    function copySearch(txt_quicksearch)
    {
       
        document.getElementById("hid_quicksearch").value = txt_quicksearch.value;        
    }
    
    function checkKeyMaster(key,from,imgbtn_emailer,imgbtn_search)
    {
        if(key==13)
        {
            if(from==0)
            {
                document.getElementById(imgbtn_emailer).click();
                // Added by Maneesh on 14-June-2010
                event.returnValue = false;
                event.cancel = true;
            }
            if(from==1)
            {
                document.getElementById(imgbtn_emailer).disabled=true;
                document.getElementById(imgbtn_search).click();
                event.returnValue=false;
                event.cancel = true;
            }            
            /*            
            var e;
            e = window.event;
	        e.cancelBubble = true;
	        if (e.stopPropagation) e.stopPropagation();
	        */
	        //Not working for Mozilla
	        if (event.bubbles == undefined) {  // Internet Exlorer
                    // always cancel bubbling
                event.cancelBubble = true;
                //alert("The propagation of the IE event is stopped.");
            }
            else {// Firefox, Opera, Safari
                if (event.bubbles) {
                    event.stopPropagation();
                    //alert("The propagation of the MOZILLA event is stopped.");
                }
                else {
                    //alert("The -- event cannot propagate up the DOM hierarchy.");
                }
            }	        
        }        
    }
    function clearText(field)
    {
        if (field.defaultValue == field.value) field.value = '';
        else if (field.value == '') field.value = field.defaultValue;
    }
    function checkMandatoryQuickSearch(txt_quicksearch)
    {
       
       
        if((document.getElementById(txt_quicksearch).value =="Enter author, title, or ISBN" ) )
        {
        
       // alert('Please specify atleast one search criteria ');
        alert('Please specify search criteria');
        return false;
        }
        
         if((document.getElementById(txt_quicksearch).value.trim() !="Enter author, title, or ISBN" ) )
        {
        
             var str=document.getElementById(txt_quicksearch).value.trim()
            if( str != "")
            {
                if(str.length < 3)
                {
                    alert("Please specify atleast 3 characters");
                    return false;
                 }
            }
            else
            {
             alert('Please specify atleast one search criteria');
             return false;
            }
        }
    }
    