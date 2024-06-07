//Javascript name: File extention Check
//Date created: 18-Aug-2009 
//Scripter:Harshit Gupta(Rensol Systems Pvt Ltd)

function checkFileExt(ctrl) 
{

    //set the name of our form
    var form = document.form1;
    alert(form);

    //retrieve our control
    var file = DOMCall(ctrl).value;
    alert(file);
    var type = "";

    //create an array of acceptable files
    var validExtensions = new Array(".csv", ".ldif",".txt",".doc");
    var allowSubmit = false;

    //if our control contains no file then alert the user
    if (file.indexOf("\\") == -1)
    {
        alert("You must select a file before hitting the Upload button");
        return false;;
    }
    else
    {
        //get the file type
        type = file.slice(file.indexOf("\\") + 1);
        var ext = file.slice(file.lastIndexOf(".")).toLowerCase();

        //loop through our array of extensions
        for (var i = 0; i < validExtensions.length; i++) 
        {
            //check to see if it's the proper extension
            if (validExtensions[i] == ext) 
            { 
                //it's the proper extension
                allowSubmit = true; 
                alert(ext);
            }
        }
    }

    //now check the final bool value
    if (allowSubmit == false)
    {
    alert("false");
        //let the user know they selected a wrong file extension
        alert("Only files with extensions " + (extArray.join("  ").toUpperCase()) + " are allowed");
        return false;
    }
    else
    {
        return true
    }       
    return allowSubmit;
}

//Sample Usage in C#
//Button1.Attributes.Add("onclick","return checkFileExt('name of file upload control'); return false;");

//Sample Usage in VB.Net
//Button1.Attributes.Add("onclick","return checkFileExt('name of file upload control'); return false;")