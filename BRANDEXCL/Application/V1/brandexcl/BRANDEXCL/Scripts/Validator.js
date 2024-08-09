// JScript File
//======================Declaration of patterns for different Regular Expression================================
var PatternsDict = new Object()
//--------------------------------------------------------------------------------------------------------------

// mathes USA telephone no.
PatternsDict.telpat = /^(\d{10}|(\d{3}-\d{3}-\d{4}))?$/
// example:-325-672-6433

// mathes telephone Indian no.
PatternsDict.telpatIND = /^((\+){1}[1-9]{1}[0-9]{0,1}[0-9]{0,1}(\s){1}[\(]{1}[1-9]{1}[0-9]{1,5}[\)]{1}[\s]{1})[1-9]{1}[0-9]{4,9}$/
// example:+91 (22) 24440444

//PatternsDict.telpatUNI  = /^((\+){1}[1-9]{1}[0-9]{0,1}[0-9]{0,1}[\-]{1}[1-9]{1}[0-9]{1,5}[\-]{1})[1-9]{1}[0-9]{5,6}$/
PatternsDict.telpatUNI = /^([1-9]{1}[0-9]{0,1}[0-9]{0,1}[\-]{1}[1-9]{1}[0-9]{1,5}[\-]{1})[1-9]{1}[0-9]{5,6}$/
// example:+91-674-2495452

// matches numeric
PatternsDict.numericpat = "^\d*$" // Any number is allowed, but are optional

// matches white space
PatternsDict.whitespacepat = /\s+/

// matches zip code
PatternsDict.zippat = /^(\d{5}|\d{9}|(\d{5}-\d{4}))?$/
//example:-78731
//PatternsDict.zippat = "^(\d{5}|\d{9}|(\d{5}-\d{4}))?$"F

// matches IP address
PatternsDict.IPpat = /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/

// matches hex number
PatternsDict.hexpat = "^([a-fA-F0-9]+)?$"

// matches any alphanumeric character,hyphen(-) or an underscore(_)
// including white space
PatternsDict.validpat = "^[a-zA-Z0-9-_\._\ ]+$"

// matches required field
PatternsDict.requiredpat = "^((/\s+)|'')?$"

// matches character
PatternsDict.charpat = /^[a-zA-Z ]+$/

//matches Date
// PatternsDict.datepat=/^([1-9]|0[1-9]|[12][1-9]|3[01])\D([1-9]|0[1-9]|1[012])\D(19[0-9][0-9]|20[0-9][0-9])$/
PatternsDict.datepat = /^([1-9]|0[1-9]|[12][0-9]|3[01])\D([1-9]|0[1-9]|1[012])\D(19[0-9][0-9]|20[0-9][0-9])$/

//PatternsDict.urlpat="(?<protocol>http(s)?|ftp)://(?<server>([A-Za-z0-9-]+\.)*(?<basedomain>[A-Za-z0-9-]+\.[A-Za-z0-9]+))+((/?)(?<path>(?<dir>[A-Za-z0-9\._\-]+)(/){0,1}[A-Za-z0-9.-/]*)){0,1}"
//PatternsDict.urlpat="http(s)?://([\w-]+\.)+[\w-]+(/[\w-].[/?%&=]*?.[/?%&=]*)"
//PatternsDict.urlpat="/http(s)?://([\w-]+\.)+([\w-]+\.)/"
//PatternsDict.urlpatwww  = /^[www\.]+[A-Za-z0-9\-\.]+\.+[com]$/
//PatternsDict.urlpatwww="([\w-]+\.)+[\w-]+(/[\w-].[/?%&=]*)?"
//PatternsDict.urlpatwww="([\w-]+\.)+[\w-]+[\w-]+(/[\w-].[/?%&=]*)?"
PatternsDict.urlpat = "http(s)?://([\w-]+\.)+[\w-]+(/[\w-].[/?%&=]*)?"
PatternsDict.wwwurlpat = /^[w]+[w]+[w]+\.+[A-Za-z0-9\-\.]+\.+[A-Za-z]{2,10}$/
PatternsDict.httpdomnurlpat = /^[h]+[t]+[t]+[p]+[:]+[/]+[/]+[A-Za-z0-9\-]+\.+[A-Za-z\-\.]{2,10}$/

// mathes email
var emailpat = /^[A-Za-z0-9\-_\.]+@+[A-Za-z0-9\-\.]+\.+[A-Za-z]{2,10}$/

// matches unsigned float
var ufloatpat = /^((\d+(\.\d*)?)|((\d*\.)?\d+))$/

// matches signed float
var sfloatpat = /^(((\+|\-)?\d+(\.\d*)?)|((\+|\-)?(\d*\.)?\d+))$/

// PatternsDict.datepat=/^([1-9]|0[1-9]|[12][1-9]|3[01])\D([1-9]|0[1-9]|1[012])\D(19[0-9][0-9]|20[0-9][0-9])$/

//var decipat="^(\\+|-)?[0-9][0-9]*(\\.[0-9]*)?$"
var decipat = /^\s*(\+|-)?((\d+(\.\d+)?)|(\.\d+))\s*$/

//----------------------------------------End of pattern declaration----------------------------------------
//======================================Create Finctions Using Pattern======================================



//==========================================On KeyPress Event===================================================
//----------------------------------------- Checks a character type field---------------------------------------
function ValidateChar(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8 || charCode == 32 || charCode == 9)
            return true;
        else
            alert("Please enter only char");
        e.preventDefault();
        return false;
    }
    catch (err) {
        alert(err.Description);
    }
};
//----------------------------------------- Checks a numeric type field---------------------------------------
function ValidateNum(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            alert("Please enter only number");
            e.preventDefault();
            return false;
        }
        return true;
    }
    catch (err) {
        alert(err.Description);
    }
};
//----------------------------------------- Checks a decimal type field---------------------------------------
function ValidateDec(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode != 46 || $(t).val().indexOf('.') != -1) && (charCode < 48 || charCode > 57)) {
            alert("Please enter only decimal");
            e.preventDefault();
            return false;
        }
        return true;
    }
    catch (err) {
        alert(err.Description);
    }
};

function ValidateAlphaNum(e, t) {
    try {
        //var charCode;
        if (window.event) {
            var charCode = window.event.keyCode;
            //else if (event) {keycode = event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 47 && charCode <= 57) || (charCode >= 65 && charCode <= 90) || (charCode >= 95 && charCode <= 122)) {
            return true;
        }
        else {
            alert("Please do not use special characters")
            e.preventDefault();
            return false;
        }
        return true;
    }
    catch (err) {
        alert(err.Description);
    };
}





//------------------------------------Check for valid email format------------------------------------------

function isEmail(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = emailpat

    if (objregExp.test(strInput)) {
        return true

    }
    alert("Please Enter A valide Email Address. ")
    Object.focus()
    return false

}
//------------------------------------Check for valid Decimal Number------------------------------------------

function isValidDecimalNo(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = decipat

    if (objregExp.test(strInput)) {
        return true

    }
    alert(msg)
    Object.focus()
    return false

}

//------------------------------------Check for valid Decimal Number with Comma ------------------------------------------
//Added by Saswati
function str_replace(haystack, needle, replacement) {
    var temp = haystack.split(needle);
    return temp.join(replacement);
}
function isValidDecimalNo1(Object, msg) {

    var strInput = new String(Object.value)

    strInput = str_replace(strInput, ',', '')

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = decipat

    if (objregExp.test(strInput)) {
        return true

    }
    alert(msg)
    Object.focus()
    return false

}



//----------------------------------------- Checks a character type field---------------------------------------

function isChar(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.charpat)

    if (objregExp.test(strInput)) {

        return true

    }

    alert(msg)
    Object.focus()
    return false

}

//----------------------Check if field contains any character along with alplanumeric and (-/_)---------------
// including white space

function isValid(Object, msg) {

    var strInput = new String(Object.value)
    var objregExp = new RegExp(PatternsDict.validpat)


    if (objregExp.test(strInput)) {

        return true

    }

    alert(msg)
    Object.focus()
    return false

}

//--------------------------------------- Checks mandatory field---------------------------------------------

function isRequired(Object, msg) {
    var strInput = trim(new String(Object.value))
    var objregExp = new RegExp(PatternsDict.requiredpat)


    if (objregExp.test(strInput)) {
        var i = 0;
        alert(msg)
        if (Object.disabled == true) {
            i = 1;
            Object.disabled = false;
        }
        Object.focus()
        if (i == 1) {
            Object.disabled = true;
        }
        else {
            Object.disabled = false;
        }
        return false

    }

    return true

}
//---------------------------------Check Box Validation------------------------------------------------------- 
function isCheckBoxValidation(Object, msg) {
    if (Object.checked == true) {
        return true;
    }
    if (Object.checked == false) {
        alert(msg);
        return false;
    }
}



//---------------------------------RadioButton Validation------------------------------------------------------- 

function isRadBtnValidation(Object, msg) {
    if (Object.checked == true) {
        return true;
    }
    if (Object.checked == false) {
        alert(msg);
        return false;
    }
}



//----------------------------------- Checks valid hexa decimal number-----------------------------------------

function isHex(Object, msg) {
    var strInput = new String(Object.value)
    if (trim(strInput) == "") {
        return true
    }
    var objregExp = new RegExp(PatternsDict.hexpat)
    if (objregExp.test(strInput)) {
        return true
    }
    alert(msg)
    Object.focus()
    return false
}

//-------------------------------------Checks valid IP address------------------------------------------------

function isValidIP(Object, msg) {
    var ipaddr = new String(Object.value)

    if (trim(ipaddr) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.IPpat)

    if (objregExp.test(ipaddr)) {
        var parts = ipaddr.split(".");
        if (parseInt(parseFloat(parts[0])) == 0) {
            alert(msg);
            return false;
        }
        for (var i = 0; i < parts.length; i++) {
            if (parseInt(parseFloat(parts[i])) > 255) {
                alert(msg);
                return false;
            }
        }
        return true

    }
    else {
        alert(msg)
        Object.focus()
        return false

    }
}

//----------------------------------------- Checks for valid zip no.----------------------------------------------
function isUSAZip(Object, msg) {
    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.zippat)


    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}

//------------------------------------------ Checks for white space in first place ------------------------------

function isWhitespace1st(Object, msg) {
    var strInput = new String(Object.value)
    var objregExp = new RegExp(PatternsDict.whitespacepat)
    if (objregExp.test(strInput)) {
        if (strInput.charAt(0) == " ") {
            if (msg != null)
                alert(msg);
            Object.focus()
            return false
        }
    }
    return true

}



//----------------------------- Checks for white space every where or at any place ------------------------

function isWhitespace(Object, msg) {
    var strInput = new String(Object.value)
    var objregExp = new RegExp(PatternsDict.whitespacepat)
    if (objregExp.test(strInput)) {
        if (msg != null)
            alert(msg);
        Object.focus()
        return false
    }
    return true

}

//--------------------------------- Checks for numeric input ----------------------------------------------------

/*
function isNumeric(Object,msg)

 {
   var strInput   = new String(Object.value)
   var objregExp  = new RegExp(PatternsDict.numericpat)

   if(objregExp.test(strInput))

     {
       return true

     }

     alert(msg)
     Object.focus()
     return false

 }

*/

//------------------------------- Checks for USA telephone number -----------------------------------------------

function isUSATel(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.telpat)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}

//------------------------------------ Checks for INDIAN telephone number --------------------------------------

function isINDTel(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.telpatIND)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}
//------------------------------------ Checks for UNIVERSAL telephone number --------------------------------------

function isUNITel(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.telpatUNI)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}

//--------------------------------- Checks partial phone number ------------------------------------------------

function isFilled(Object, msg) {
    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.telpat)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false
}

//---------------------- This function is used to change any text to Uppercase text -----------------------------

function UpperCase(toconvert) {
    text = new String(toconvert);
    toconvert = text.toUpperCase();

    return toconvert;
}


//------------------------------------------- Check for numeric field -------------------------------------------

function isNumeric(Object, length, msg) {
    var strInput = new String(Object.value)

    if (strInput.length > 0) {
        if (strInput.length > length) {
            alert("Maximum length of the field should be " + length + " characters long")
            Object.focus()
            return false
        }

        for (i = 0; i < strInput.length; i++) {
            if (strInput.charAt(i) < '0' || strInput.charAt(i) > '9') {
                alert(msg)
                Object.focus()
                return false
            }
        }
    }
    return true
}



//------------------------------ Check whether Passwords are matched ----------------------------------------

function isPwdMatch(pwd, cpwd, msg) {

    if (pwd.value != cpwd.value) {
        alert(msg);
        cpwd.focus()
        return false
    }
    else
        return true
}

//-------------------------------- Check if the field is of min length -------------------------------------

function isMinlen(Object, len, msg) {
    strInput = trim(new String(Object.value))
    sLength = strInput.length
    if (sLength < len) {
        alert(msg)
        Object.focus()
        return false
    }
    return true
}

//--------------------------------- Check if the maximum length of the field -------------------------------

function isMaxlen(Object, len, msg) {
    strInput = trim(new String(Object.value))
    sLength = strInput.length
    if (sLength > len) {
        alert(msg)
        Object.focus()
        return false
    }
    return true
}

//---------------------------------- Check if the field is of fixed length --------------------------------

function isReslen(Object, len, msg) {
    strInput = trim(new String(Object.value))
    sLength = strInput.length
    if (sLength != len) {
        alert(msg)
        Object.focus()
        return false
    }
    return true
}

//----------------------------------- Check if two fields are indentical ----------------------------------

function isSimilar(Object1, Object2, msg) {
    strInput1 = new String(Object1.value)
    strInput2 = new String(Object2.value)

    if (strInput1.valueOf() == strInput2.valueOf()) {
        alert(msg)
        Object2.focus()
        return false
    }

    return true
}

//---------------------------------- Check if two or more email ids are indentical -------------------------

function isEmailSimilar(str1, str2, str3, str4, str5, msg) {

    strInput1 = new String(str1.value)
    strInput2 = new String(str2.value)
    strInput3 = new String(str3.value)
    strInput4 = new String(str4.value)
    strInput5 = new String(str5.value)


    var fstr, sstr;
    for (i = 1; i <= 5; i++) {
        fstr = new String(eval("strInput" + i))

        for (j = i + 1; j <= 5; j++) {

            sstr = new String(eval("strInput" + j))

            if (fstr.valueOf() != "" && sstr.valueOf() != "") {

                if (fstr.valueOf() == sstr.valueOf()) {
                    alert(msg)
                    if (j == 1)
                        str1.focus()
                    else if (j == 2)
                        str2.focus()
                    else if (j == 3)
                        str3.focus()
                    else if (j == 4)
                        str4.focus()
                    else if (j == 5)
                        str5.focus()

                    return false
                }
            }
        }
    }
    return true
}


//-----------------------------Check whether Pwd Question & Ans. are entered.-----------------------------------

function isValidQA(Object1, Object2, msg1, msg2) {
    var str1 = new String(Object1.value)
    var str2 = new String(Object2.value)
    if (str1.length == 0) {
        alert(msg1)
        Object1.focus()
        return false
    }
    else if (str2.length == 0) {
        alert(msg2)
        Object2.focus()
        return false
    }
    else
        return true
}

//-------------------------------------Function to Trim a String--------------------------------------------

function trim(strString) {
    var strCopy = new String(strString)
    strCopy = strCopy.replace(/^\s+/, "")
    strCopy = strCopy.replace(/\s+$/, "")
    return strCopy.toString()
}

//----------checks number of days in a month, and leap year related validations. in DD-MM-YYYY format----------

function isDate(Object, Day, Mon, Yr, msg) {

    var strInput = new String(Object.value)
    if (trim(strInput) == "") {
        return true
    }
    var objregExp = new RegExp(PatternsDict.datepat)
    if (objregExp.test(strInput)) {

        if (Day, Mon, Yr) {
            var rem;
            var dateOk = true;

            if (Day.length != 2) {
                alert("Please Check! The Day you entered is Invalid.It should be in 'DD' format")

                dateOk = false;
                Object.focus()
                return;
            }

            if (Yr.length != 4) {
                alert("Please Check! The Year you entered is Invalid.It should be in 'YYYY' format")
                Object.focus()
                dateOk = false;
            }

            if (Day > 31) {
                alert("Please Check! The Day you entered is Invalid.")
                Object.focus()
                dateOk = false;
            }

            if (Mon.length != 2) {
                alert("Please Check! The Month you entered is Invalid.It should be in 'MM' format")
                Object.focus()
                dateOk = false;
            }

            if (Mon > 12 || Mon < 01) {
                alert("Please Check! The Month you entered is Invalid.")
                Object.focus()
                dateOk = false;
            }

            else {
                if (Day == 31) {
                    if ((Mon == "02") || (Mon == "04") || (Mon == "06") || (Mon == "09") || (Mon == "11")) {
                        dateOk = false;
                        alert("Please Check! The month you entered doesn't have 31 days.")
                        Object.focus()
                    }
                }
                else {
                    if ((Day > 29) && (Mon == "02")) {
                        dateOk = false;
                        alert("Please Check! The month you entered doesn't have " + Day + " days.")
                        Object.focus()
                    }

                    else {
                        if ((Day == 29) && (Mon == "02")) {
                            rem = Yr % 400;
                            if (rem == 0)
                                dateOk = true;

                            else {
                                rem = Yr % 100;
                                if (rem == 0)
                                    dateOk = true;

                                else {
                                    rem = Yr % 4;
                                    if (rem == 0)
                                        dateOk = true;

                                    else {
                                        dateOk = false;
                                        alert("February can have 29 days in a leap year only. Please select a leap year")
                                        Object.focus()
                                    }
                                }
                            }
                        }
                    }
                }
                return dateOk
            }
        }

    }
    alert(msg);
    Object.focus()
    Object.value = ""
    return false

}

//--------checks number of days in a month, and leap year related validations. in DD-MMM-YYYY format------------------



function isDateinMMM(day, month, year) {

    var isValid = true;

    var enteredDate = new Date(day + " " + month + " " + year);

    if (enteredDate.getDate() != day) {

        isValid = false;

    }
    //if (enteredDate.getMonth() != month)

    //  {

    //    isValid = false;

    //  }
    if (enteredDate.getYear() != year) {

        isValid = false;

    }
    return isValid;

}


//-------------------------------- Check for valid signed float format --------------------------------------

function isSignedFloat(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = sfloatpat

    if (objregExp.test(strInput)) {
        return true

    }
    alert(msg)
    Object.focus()
    return false

}

//--------------------------------- Check for valid unsigned float format -------------------------------------

function isUnSignedFloat(Object, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = ufloatpat

    if (objregExp.test(strInput)) {
        return true

    }
    alert(msg)
    Object.focus()
    return false

}

//--------------------------Function to replace a string with another string ---------------------------
function Replace(str1, str2, str3) {
    str1 = str1.replace(new RegExp(str2), str3);
    return str1
}
//-------------------------------Function specifying  Number in range----------------------------------
function isNumInRange(Object, low, high, msg) {

    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    strInput = parseFloat(strInput);

    Object.value = strInput

    if (isNaN(strInput)) {
        Object.value = 0

    }

    if (isNaN(high) && !isNaN(strInput)) {

        if ((high.toUpperCase() == "LT") || (high == "<"))
            Operator = "<"
        if ((high.toUpperCase() == "LE") || (high == "<="))
            Operator = "<="
        if ((high.toUpperCase() == "GT") || (high == ">"))
            Operator = ">"
        if ((high.toUpperCase() == "GE") || (high == ">="))
            Operator = ">="
        else if ((high.toUpperCase() == "EQ") || (high == "="))
            Operator = "=="

        if (!eval(strInput + " " + Operator + " " + low)) {
            alert(msg + " i.e. in between " + "" + low + "" + "-" + "" + high + "")
            Object.focus()
            return false
        }

        return true

    }


    if (isNaN(strInput) || (strInput < low) || (strInput > high)) {
        alert(msg + " i.e. in between " + "" + low + "" + "-" + "" + high + "")

        Object.focus()
        return false

    }

    return true
}

//-------------------------------Function specifying Integer in range----------------------------------
function isIntInRange(Object, low, high, msg)

    // Results: alert if textBox does not contain an integer in range & clears
{
    var strInput = new String(Object.value)
    var Operator

    if (trim(strInput) == "") {
        return true
    }


    strInput = parseInt(strInput, 10);

    Object.value = strInput

    if (isNaN(strInput)) {
        Object.value = 0
    }



    if (isNaN(high) && !isNaN(strInput)) {

        if ((high.toUpperCase() == "LT") || (high == "<"))
            Operator = "<"
        if ((high.toUpperCase() == "LE") || (high == "<="))
            Operator = "<="
        if ((high.toUpperCase() == "GT") || (high == ">"))
            Operator = ">"
        if ((high.toUpperCase() == "GE") || (high == ">="))
            Operator = ">="
        else if ((high.toUpperCase() == "EQ") || (high == "="))
            Operator = "=="

        if (!eval(strInput + " " + Operator + " " + low)) {
            alert(msg + " i.e. in between " + "" + low + "" + "-" + "" + high + "")
            Object.focus()
            return false
        }


        return true

    }

    if (isNaN(strInput) || (strInput % 1 != 0) || (strInput < low) || (strInput > high)) {
        alert(msg + " i.e. in between " + "" + low + "" + "-" + "" + high + "")

        Object.focus()
        return false

    }

    return true
}

//----------------------------------Checks for multiple checked checkboxes-------------------------------------

function isMultipleChecked(Object, MsgOption, msg) {
    var intNoOfLines = 0;
    var NumChecked;

    NumChecked = 0;

    if (Object) {
        intNoOfLines = Object.length;
    }

    if (isNaN(intNoOfLines)) {
        intNoOfLines = 1;

    }

    if (intNoOfLines == 1) {
        if (Object.checked) {
            NumChecked++;
        }
    }
    else {
        for (i = 0; i < intNoOfLines; i++) {

            if (Object[i].checked) {

                NumChecked++;

            }
        }
    }

    if (NumChecked > 1) {
        if (MsgOption) {

            if (trim(msg) != "" || isMultipleChecked.arguments.length > 2)
                alert(msg);
        }

        return true;
    }

    if (!MsgOption) {

        if (trim(msg) != "" && isMultipleChecked.arguments.length > 2)
            alert(msg);
    }

    return false;

}
//--------------------------Checks at lease one checkbox/radio button has been checked or not----------------

function isAtleastOneChecked(Object, msg) {

    var intNoOfLines = 0;
    var boolChecked = false;

    if (Object) {
        intNoOfLines = Object.length;
    }

    if (isNaN(intNoOfLines)) {
        intNoOfLines = 1;

    }


    if (intNoOfLines == 1) {
        if (Object.checked) {
            boolChecked = true;
        }
    }
    else {
        for (i = 0; i < intNoOfLines; i++) {

            if (Object[i].checked) {

                boolChecked = true;
                break;

            }
        }
    }

    if (boolChecked) {

        return true;
    }

    alert(msg);
    return false;
}

//----------------------------------- Checks and unchecks all the check boxes ----------------------------

function selectsAll(Object1, Object2) {

    var intNoOfItems = 0;

    if (Object2) {
        intNoOfItems = Object2.length;
    }

    if (isNaN(intNoOfItems)) {
        intNoOfItems = 1;

    }

    if (Object1.checked) {
        if (intNoOfItems == 1) {
            Object2.checked = true;
        }
        else {
            for (i = 0; i < intNoOfItems; i++) {
                Object2[i].checked = true;
            }
        }

        Object1.checked = true;



    }
    else {
        if (intNoOfItems == 1) {
            Object2.checked = false;
        }
        else {
            for (i = 0; i < intNoOfItems; i++) {
                Object2[i].checked = false;
            }
        }

        Object1.checked = false;



    }
}
//----------------------------------- Checks all the check boxes ----------------------------

function chkAllCheckBoxes(Object1, Object2) {

    var TB = TO = 0;
    var intNoOfItems = 0;

    if (Object2) {
        intNoOfItems = Object2.length;
    }

    if (isNaN(intNoOfItems)) {
        intNoOfItems = 1;

    }

    for (var i = 0; i < intNoOfItems; i++) {
        TB++;

        if (intNoOfItems == 1) {
            if (Object2.checked)
                TO++;
        }
        else {
            if (Object2[i].checked)
                TO++;
        }
    }

    if (TO == TB)
        Object1.checked = true;
    else
        Object1.checked = false;
}
//--------------------------- check dropdown is selected or not ------------------------------------
function isSelectDropDown(Object, msg) {
    if (Object == false || Object.selectedIndex == 0) {
        var i = 0;
        alert(msg)
        if (Object.disabled == true) {
            i = 1;
            Object.disabled = false;
        }
        Object.focus()
        if (i == 1) {
            Object.disabled = true;
        }
        else {
            Object.disabled = false;
        }
        return false
    }
    return true
}

//----------------------------------- check Listbox is selected or not ---------------------------
function isSelectListBox(Object, msg) {
    if (Object == false || Object.value == 0) {
        alert(msg)
        Object.focus()
        return false
    }
    return true
}
//--------------------------------- checks Single Quote -----------------------------------------
function isSingleQuote(Object, msg) {
    var str1 = trim(new String(Object.value))
    for (var i = 0; i < str1.length; i++) {
        var ch = str1.substring(i, i + 1);
        if (ch == "'") {
            alert(msg);
            Object.focus();
            return false;
        }
    }
    return true;
}

//-------------------------------------checks valid URL----------------------------------------------
//function isValidURL(Object,msg)
//  {
//    var str1 = trim(new String(Object.value))
//     //if ((str2.value == "") ||(str2.value.indexOf("www.") == -1) ||(str2.value.indexOf(".") == -1)) 
//    if ((str1 == "") ||(str1.indexOf("www.") == -1) ||(str1.indexOf(".") == -1)||(str1.LastindexOf(".com"))) 
//        {
//        alert(msg);
//        Object.focus();
//        return false;
//        }
// return true;

//}

//---------------------------------------checks valid URL i http format---------------------------------

function isValidURL(Object, msg) {
    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.urlpat)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}

//---------------------------------------checks valid URL in www format---------------------------------

function isValidwwwURL(Object, msg) {
    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.wwwurlpat)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}



//---------------------------------------checks valid URL in http://<domain name>.com format---------------------------------

function isValidURLinHTTPDomain(Object, msg) {
    var strInput = new String(Object.value)

    if (trim(strInput) == "") {
        return true
    }

    var objregExp = new RegExp(PatternsDict.httpdomnurlpat)

    if (objregExp.test(strInput)) {
        return true

    }

    alert(msg)
    Object.focus()
    return false

}


//-----------------------------selects or checks all checkboxes in a grid-------------------------------
function isSelectAll(CheckBoxControl, GridId, Formname) {
    var FormNM = document.getElementById(Formname)

    if (CheckBoxControl.checked == true) {
        var i;
        for (i = 0; i < FormNM.elements.length; i++) {
            if ((FormNM.elements[i].type == 'checkbox') && (FormNM.elements[i].name.indexOf(GridId) > -1)) {
                if (FormNM.elements[i].disabled == false)//--------Added By Pratik On 20-Feb-2009===========
                    FormNM.elements[i].checked = true;
            }
        }
    }
    else {
        var i;
        for (i = 0; i < FormNM.elements.length; i++) {
            if ((FormNM.elements[i].type == 'checkbox') && (FormNM.elements[i].name.indexOf(GridId) > -1)) {
                FormNM.elements[i].checked = false;
            }
        }
    }
}
//---------------------------------Checks Selected in Datagrid-----------------------------------------
function isChecked(Form, msg) {
    var FormName = document.getElementById(Form)

    for (var i = 0; i < FormName.elements.length; i++) {
        if (FormName.elements[i].type == 'checkbox')
            if (FormName.elements[i].checked == true)
                return true;
    }
    //alert("No record is selected !");
    alert(msg);
    return false;
}

//---------------------------------------------Confirm Delete-----------------------------------
function isDelete(Form, msg) {
    if (isChecked(Form, msg) == false)
        return false;

    if (confirm("Are you sure you want to delete ?")) {
        return true;
    }
    else {
        return false;
    }
}
//---------------------------------------------Confirm Group Save-----------------------------------
function isSave(Form, msg) {
    if (isChecked(Form, msg) == false)
        return false;

    if (confirm("Are you sure you want to save ?")) {
        return true;
    }
    else {
        return false;
    }
}

//---------------------------------------------Confirm Activate-----------------------------------
function isActivate(Form, msg) {
    if (isChecked(Form, msg) == false)
        return false;

    if (confirm("Are you sure you want to activate ?")) {
        return true;
    }
    else {
        return false;
    }
}
//---------------------------------------------Confirm DeActivate-----------------------------------
function isDeActivate(Form, msg) {
    if (isChecked(Form, msg) == false)
        return false;

    if (confirm("Are you sure you want to deactivate ?")) {
        return true;
    }
    else {
        return false;
    }
}

//------------------------------------------------------Confirm Time-----------------------------------------

// Checks if time is in HH:MM:SS AM/PM format.

// The seconds and AM/PM are optional.

function isValidTime(Object) {
    var timeStr = trim(new String(Object.value))

    if (timeStr != "") {

        var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/;


        var matchArray = timeStr.match(timePat);

        if (matchArray == null) {

            alert("Time is not in a valid format.");

            //Object.value="";

            Object.focus();

            return false;

        }

        hour = matchArray[1];

        minute = matchArray[2];

        second = matchArray[4];

        ampm = matchArray[6];



        if (second == "") { second = null; }

        if (ampm == "") { ampm = null }



        if (hour < 0 || hour > 23) {

            alert("Hour must be between 1 and 12. (or 0 and 23 for military time)");

            //Object.value="";

            Object.focus();

            return false;

        }

        if (hour <= 12 && ampm == null) {

            if (confirm("Please indicate which time format you are using.  OK = Standard Time, CANCEL = Military Time")) {

                alert("You must specify AM or PM.");
                Object.focus();
                return false;

            }

        }

        if (hour > 12 && ampm != null) {

            alert("You can't specify AM or PM for military time.");

            //Object.value="";

            Object.focus();

            return false;

        }

        if (minute < 0 || minute > 59) {

            alert("Minute must be between 0 and 59.");

            //Object.value="";

            Object.focus();

            return false;

        }

        if (second != null && (second < 0 || second > 59)) {

            alert("Second must be between 0 and 59.");

            //Object.value="";

            Object.focus();

            return false;

        }

        return true;

    }

}

//--------------------------------------------------Phone Validator----------------------------------------------

function checkPhoneValidator(Object) {
    var checkOK = "0123456789-()";

    var checkStr = trim(new String(Object.value))

    var allValid = true;

    var decPoints = 0;

    var allNum = "";

    for (i = 0; i < checkStr.length; i++) {

        ch = checkStr.charAt(i);

        for (j = 0; j < checkOK.length; j++)

            if (ch == checkOK.charAt(j))

                break;

        if (j == checkOK.length) {

            allValid = false;

            break;

        }

        allNum += ch;

    }

    if (!allValid) {

        alert("Please enter only digit characters in the \"Phone Number ( 2039874125 )\" field.");

        Object.focus();

        return (false);

    }

    if (Object.value.length !== 0 && Object.value.length < 10) {

        alert("Incorrect number of characters.");

        Object.focus();

        return (false);

    }

    if (Object.value.length > 10) {
        alert("Entry consists of more that 10 Chars.");

        Object.focus();

        return (false);
    }

    else {
        return true;

    }

}
//--------------------------------------------------Upload File Validation---------------------------------------
function isSelectFile(Object, msg) {
    var SelFile = trim(new String(Object.value))
    if (SelFile == "") {
        alert(msg);
        Object.focus();
        return false;
    }
    else {
        return true
    }
}
//-------------------------------------------Compare Two Dates Inputted By TextBoxes-----------------------------------
function isDateCompare(Object1, Object2, msg) {
    var fromDate = Object1.value
    var toDate = Object2.value

    if (Date.parse(fromDate) > Date.parse(toDate)) {
        alert(msg);
        Object1.focus();
        return false;
    }

    return true
}
//-------------------------------------Compare Dates in Calendar Format(in dd-MMM-yyyy Format)-----------------------
function isDateCompareinCalendar(day1, mon1, yr1, day2, mon2, yr2, object1, object2, msg) {
    var fromDate = new Date(day1 + " " + mon1 + " " + yr1);
    var toDate = new Date(day2 + " " + mon2 + " " + yr2);

    var date1 = fromDate.getMonth() + "/" + fromDate.getDate() + "/" + fromDate.getYear();
    var date2 = toDate.getMonth() + "/" + toDate.getDate() + "/" + toDate.getYear();

    if (Date.parse(date1) > Date.parse(date2)) {
        //        alert("Invalid Date range!As EndDate cannot before StartDate!");
        //        document.getElementById("TextBox1").focus();
        alert(msg);
        object1.focus();
        return false;
    }
    else

        return true
}
//------------------------------Compare Time Inputted By Two TextBoxes------------------------------------------------
function isTimeCompare(Object1, Object2, msg) {
    var str1 = new String(Object1.value)
    var str2 = new String(Object2.value)
    if (trim(str1) == "") {
        return true
    }
    if (trim(str2) == "") {
        return true
    }

    var curDate = new Date();
    var start = new Date();
    var end = new Date();
    var diff1 = new Date();
    var diff2 = new Date();

    var date = curDate.getMonth() + "/" + curDate.getDate() + "/" + curDate.getYear();
    var startTime = new Date(date + " " + str1);
    var endTime = new Date(date + " " + str2);

    diff1.setTime(endTime.getTime() - startTime.getTime());
    var timediff1 = new Number(diff1.getTime());

    if (timediff1 < 0) {
        alert(msg);
        Object2.focus();
        return false;
    }
    else
        return true;
}
//=======================END OF INPUT VALIDATION SERVICE==============================

// JScript File

var strSizeMinAlert = "<Field> can not be less than <n> characters"
var strSizeMinResAlert = "<Field> must contain <n> characters"
var strSizeMaxAlert = "<Field> can not be more than <n> characters long"
var strSizeMaxResAlert = "<Field> should be maximum <n> characters long"
var strResAllowAlert1 = "Invalid characters entered in <Field>. Allows only <\"_\",\"-\",\"/\" > as special characters"
var strResAllowAlert2 = "<Field> allows only  <\"_\",\"-\",\"/\" >characters"
var strResAllowAlert3 = "Special characters \"-,_\" are only allowed"
var strResNotAllowAlert1 = "Invalid characters entered in <Field>. Characters <\"-\",\"&\",\"$\">, are not allowed"
var strResNotAllowAlert2 = "<Field> can not contain <\"-\",\"&\",\"$\"> character"
var strResNotAllowAlert3 = "<Field> does not accepts space(s)"
var strNumericAlert = "<Field> accepts only numeric values"
var strAlphabeticAlert1 = "<Field> should be alphabetic"
var strAlphabeticAlert2 = "<Field> accepts only alphabetic values"
var strMandatoryAlert1 = "<Field> is mandatory"
var strMandatoryAlert2 = "<Field> can not be left blank"
var strMandatoryAlert3 = "<Field> is a required filed"
var strPositiveAllowAlert = "<Field> accepts positive values only"
var strNegetiveAllowAlert = "<Field> accepts negative values only"
var strInvalidFomatAlert = "Invalid format. Please enter <Field> as <AA-BB#CCC@DD>"
var strNotAllowSimilarAlert = "<Field1> and <Field2> must not be same"
var strDoNotMatchAlert = "Information mismatched in <Field1>. Please re-enter <Field1>"
var strInvalidSignedFloatAlert = "<Field> should be a floating point (real) number. (Integers also OK.)"
var strInvalidUnSignedFloatAlert = "<Field> should be an unsigned floating point (real) number. (Integers also OK.)"

//MESSAGES FOR DATE SERVICE//
var strValidDate = "Valid date";
var strInvalidDateFormat = "Invalid date format";
var strInvalidMonth = "Invalid month!";
var strInvalidFebDays = "February cannot have 29 days other than a leap year";
var strInvalidMonthDays = "Invalid number of days in the specified month";
var strInvalidYear = "Invalid year";
var strInvalidParameter = "Invalid parameter";
var strFormatMismatch = "Format mismatch";
var strInternalError = "Internal error";
var strSimilarEmail = "Email Id should be unique"
var strinvalidDate = "Invalid date.Please renter the date"
var strCompareDate = "Invalid Date Range!<Field1> cannot be after <Field2>"
var strCompareTime = "<Field1> cannot be greater than <Field2>"
//------------------Message added by Pramod-------------------------------------------------
var strEmail = "Invalid Email_Id";
var strHex = "Invalid Entry.HexaDecimalNos. only contains a-f,A-F,0-9 characters"
var strIp = "Invalid IP address"
var strZip = "Invalid ZipCode"
var strWhiteSpace = "White space(s) not allowed"
var strWhiteSpace1st = "White space(s) not allowed in first place"
var strTelNo = "Invalid telephone number"
var strFilled = "Partial phone number not filled properly"
var strAllowSimilarAlert = "<Field1> and <Field2> must be same.Please Re_enter <Field2>"
var strNuminRange = "<Field> must be with in specified range"
var strSelecteDropDown = "Please select <Field>"
var strSingleQuote = "Single Quote not allowed"
var strValidURL = "Enter URL in Website Format.Ex-: http://www.google.com"
var strValidwwwURL = "Enter URL in Website Format.Ex-: www.google.com"
var strURLinHTTPDomain = "Enter URL in Website Format.Ex-:http://google.com/.co.in"
var strChecked = "No record is selected"
var strSelectFile = "Please Select A <Field> To Upload"
var strSplChar = "Special Character is not Allowed"
var strFstchar = "First character should be an Alphabet"
var strchkboxchecked = "Please Select <Field>"
var strrbtchecked = "Please Select <Field>"
var strDecimal = "Invalid Entry!Please enter a valid  "
//=========================================END OF  STANDRD ERROR ALERT==========================================
function InputValidator() {
    this.isEmailSimilar = isEmailSimilar
    this.isChar = isChar;
    this.isValid = isValid;
    this.isRequired = isRequired;
    this.isHex = isHex;
    this.isValidIP = isValidIP;
    this.isUSAZip = isUSAZip;
    this.isWhitespace = isWhitespace;
    this.isNumeric = isNumeric;
    this.isUSATel = isUSATel;
    this.isPwdMatch = isPwdMatch;
    this.isMinlen = isMinlen;
    this.isReslen = isReslen;
    this.isMaxlen = isMaxlen;
    this.isSimilar = isSimilar;
    this.isDate = isDate;
    this.UpperCase = UpperCase;
    this.isValidQA = isValidQA;
    this.trim = trim;
    this.Replace = Replace;
    this.isSignedFloat = isSignedFloat;
    this.isUnSignedFloat = isUnSignedFloat;
    this.isNumInRange = isNumInRange;
    this.isIntInRange = isIntInRange;
    this.isAtleastOneChecked = isAtleastOneChecked;
    this.selectsAll = selectsAll;
    //Added By Pramod Kumar Pradhan
    this.isEmail = isEmail;
    this.isWhitespace1st = isWhitespace1st;
    this.isINDTel = isINDTel;
    this.isUNITel = isUNITel;
    this.isFilled = isFilled;//Added By Pramod Kumar Pradhan on 6th jan'07
    this.isDateinMMM = isDateinMMM;
    this.chkAllCheckBoxes = chkAllCheckBoxes;
    this.isMultipleChecked = isMultipleChecked;
    this.isSelectDropDown = isSelectDropDown;
    this.isSingleQuote = isSingleQuote;
    this.isValidURL = isValidURL;
    this.isValidwwwURL = isValidwwwURL;
    this.isValidURLinHTTPDomain = isValidURLinHTTPDomain;
    this.isSelectAll = isSelectAll;
    this.isSelectListBox = isSelectListBox;
    this.isChecked = isChecked;
    this.isDelete = isDelete;
    this.isSave = isSave;
    this.isActivate = isActivate;
    this.isDeActivate = isDeActivate;
    this.isValidTime = isValidTime;
    this.checkPhoneValidator = checkPhoneValidator;
    this.isSelectFile = isSelectFile;
    this.isDateCompare = isDateCompare;
    this.isTimeCompare = isTimeCompare;
    this.isDateCompareinCalendar = isDateCompareinCalendar;
    this.isCheckBoxValidation = isCheckBoxValidation;
    this.isRadBtnValidation = isRadBtnValidation;
    this.isValidDecimalNo = isValidDecimalNo;
    this.isValidDecimalNo1 = isValidDecimalNo1;
}

function ErrorAlert() {
    this.SizeMinAlert = strSizeMinAlert;
    this.SizeMinResAlert = strSizeMinResAlert;
    this.SizeMaxAlert = strSizeMaxAlert;
    this.SizeMaxResAlert = strSizeMaxResAlert;
    this.ResAllowAlert1 = strResAllowAlert1;
    this.ResAllowAlert2 = strResAllowAlert2;
    this.ResAllowAlert3 = strResAllowAlert3;
    this.ResNotAllowAlert1 = strResNotAllowAlert1;
    this.ResNotAllowAlert2 = strResNotAllowAlert2;
    this.ResNotAllowAlert3 = strResNotAllowAlert3;
    this.NumericAlert = strNumericAlert;
    this.AlphabeticAlert1 = strAlphabeticAlert1;
    this.AlphabeticAlert2 = strAlphabeticAlert2;
    this.MandatoryAlert1 = strMandatoryAlert1;
    this.MandatoryAlert2 = strMandatoryAlert2;
    this.MandatoryAlert3 = strMandatoryAlert3;
    this.PositiveAllowAlert = strPositiveAllowAlert;
    this.NegetiveAllowAlert = strNegetiveAllowAlert;
    this.InvalidFomatAlert = strInvalidFomatAlert;
    this.NotAllowSimilarAlert = strNotAllowSimilarAlert;
    this.DoNotMatchAlert = strDoNotMatchAlert;
    this.InvalidSignedFloatAlert = strInvalidSignedFloatAlert;
    this.InvalidUnSignedFloatAlert = strInvalidUnSignedFloatAlert;
    //---------------------Added By Pramod-------------------------------------------------------
    this.validEmail = strEmail;
    this.validHex = strHex;
    this.validIP = strIp;
    this.validZIP = strZip;
    this.whitespace = strWhiteSpace;
    this.whitespace1st = strWhiteSpace1st;
    this.validPhoneNo = strTelNo;
    this.validFill = strFilled;
    this.matchpwd = strAllowSimilarAlert;
    this.similarEmailalert = strSimilarEmail;
    this.numinRangealert = strNuminRange;
    this.strSelecteDropDown = strSelecteDropDown;
    this.strSingleQuote = strSingleQuote;
    this.strValidURL = strValidURL;
    this.strValidwwwURL = strValidwwwURL;
    this.strURLinHTTPDomain = strURLinHTTPDomain;
    this.strChecked = strChecked;
    this.strSelectFile = strSelectFile;
    this.invalidDate = strinvalidDate;
    this.strCompareDate = strCompareDate;
    this.strCompareTime = strCompareTime;
    this.strSplChar = strSplChar;
    this.strFstchar = strFstchar;
    this.strchkboxchecked = strchkboxchecked;
    this.strrbtchecked = strrbtchecked;
    this.strDecimal = strDecimal;
}
//====================================END OF TEST PAGE=======================================
//============1.Function checking blank field for textboxes/areas==============================
function blankFieldValidation(Controlname, Fieldname) {

    // alert(document.getElementById(Controlname));
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
        objValidator.isRequired(objfrm, objValidator.Replace(objError.MandatoryAlert2, "<Field>", objFieldname))

     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//============2.Function checking maximum length of a field ==============================
function MaxlengthValidation(Controlname, Fieldname, maxlen) {
    //var objform=document.getElementById(Formname);
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var objmaxlen = maxlen

    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isMaxlen(objfrm, objmaxlen, objValidator.Replace(objValidator.Replace(objError.SizeMaxAlert, "<Field>", objFieldname), "<n>", objmaxlen))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//============3.Function checking minimum length of a field ==============================

function MinlengthValidation(Controlname, Fieldname, minlen) {
    //var objform=document.getElementById(Formname);
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var objminlen = minlen

    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isMinlen(objfrm, objminlen, objValidator.Replace(objValidator.Replace(objError.SizeMinAlert, "<Field>", objFieldname), "<n>", objminlen))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//============4.Function checking Restricted length of a field ==============================

function ReslengthValidation(Controlname, Fieldname, reslen) {
    //var objform=document.getElementById(Formname);
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var objminlen = reslen

    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isReslen(objfrm, objminlen, objValidator.Replace(objValidator.Replace(objError.SizeMinResAlert, "<Field>", objFieldname), "<n>", objminlen))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//============5.Function checking EmailValidation of a field ==============================
function EmailValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
       objValidator.isEmail(objfrm, objError.validEmail)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}


//====================6.Function Checks a character type field==============================
function CharValidation(Controlname, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
      objValidator.isChar(objfrm, objValidator.Replace(objError.AlphabeticAlert2, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//====================7.Function checking isValid Characters (Check if field contains any character except alplanumeric and -/_.including white space)==============================
function isValidCharValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    //var objFieldname=Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
        //objValidator.isValid(objfrm, objValidator.Replace(objError.ResAllowAlert3,"<Field>",objFieldname))
 objValidator.isValid(objfrm, objError.ResAllowAlert3)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//====================8.Function checking HexaDecimal no's ==============================
function HexaValidation(Controlname) {

    var objfrm = document.getElementById(Controlname);

    //var objFieldname=Fieldname;

    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();


    if
            (

       objValidator.isHex(objfrm, objError.validHex)

     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//====================9.Function checking valid IP adress ==============================
function IPValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isValidIP(objfrm, objError.validIP)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}


//====================10.Function checking USA ZIP CODE ==============================
function USAZIPCodeValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isUSAZip(objfrm, objError.validZIP)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//====================11.Function checking WhiteSpaces ==============================
function WhiteSpaceValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
            objValidator.isWhitespace(objfrm, objError.whitespace)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}


//====================12.Function checking USA TELEPHONE Number ==============================
function USATelNoValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();

    if
            (
   objValidator.isUSATel(objfrm, objError.validPhoneNo)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}


//====================13.Function checking IND TELEPHONE Number ==============================
function INDTelNoValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isINDTel(objfrm, objError.validPhoneNo)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}
//====================14.Function checking  isFilled (Checks partial phone number)==============================
//function isFilled_Validation(Controlname,Fieldname)
//  {
//    var objfrm=document.getElementById(Controlname);
//    var objFieldname=Fieldname;
//	var flag;
//	flag=false;
//	var objValidator = new InputValidator();
//	var objError 	 = new ErrorAlert();
//   if
//    (
//  objValidator.isFilled(objfrm,objValidator.Replace(objError.validFill,"<Field>",objFieldname))
//    )
//        {
//	  	objError = null
//		objValidator = null
//		alert ("Form has been validated successfully.")
//		flag=true
//        }
//	objError = null
//	objValidator = null
//	return flag
//  }

//====================15.Function for toUpperCase ==============================
function toUpperValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var msg = objfrm.value
    var objValidator = new InputValidator();
    var str = objValidator.UpperCase(msg)
    alert(str)
}

//====================16.Function to check numeric values ==============================
function NumericValidation(Controlname, Fieldname, length) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var objlen = length


    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isNumeric(objfrm, objlen, objValidator.Replace(objError.NumericAlert, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//====================17.Function for to check match password ==============================
function PasswordValidation(Controlname1, Controlname2, Fieldname1, Fieldname2) {
    var objfrm1 = document.getElementById(Controlname1);
    var objfrm2 = document.getElementById(Controlname2);
    var objFieldname1 = Fieldname1;
    var objFieldname2 = Fieldname2;


    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isPwdMatch(objfrm1, objfrm2, objValidator.Replace(objValidator.Replace(objValidator.Replace(objError.matchpwd, "<Field2>", objFieldname2), "<Field2>", objFieldname2), "<Field1>", objFieldname1))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//====================18.Function for to not allow similar fields ==============================
function DisSimilarValidation(Controlname1, Controlname2, Fieldname1, Fieldname2) {
    var objfrm1 = document.getElementById(Controlname1);
    var objfrm2 = document.getElementById(Controlname2);
    var objFieldname1 = Fieldname1;
    var objFieldname2 = Fieldname2;


    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isSimilar(objfrm1, objfrm2, objValidator.Replace(objValidator.Replace(objError.NotAllowSimilarAlert, "<Field2>", objFieldname2), "<Field1>", objFieldname1))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//====================19.Function for checking unique values in different fields ==============================
function chkSimilarID(Controlname1, Controlname2, Controlname3, Controlname4, Controlname5) {
    var objfrm1 = document.getElementById(Controlname1);
    var objfrm2 = document.getElementById(Controlname2);
    var objfrm3 = document.getElementById(Controlname3);
    var objfrm4 = document.getElementById(Controlname4);
    var objfrm5 = document.getElementById(Controlname5);

    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
     objValidator.isEmailSimilar(objfrm1, objfrm2, objfrm3, objfrm4, objfrm5, objError.similarEmailalert)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//====================20.Function for checking whether Pwd Question & Ans. are entered.(i.e two fields simultaneously are filled)==============================
function isValidQAValidation(Controlname1, Controlname2, Fieldname1, Fieldname2) {
    var objfrm1 = document.getElementById(Controlname1);
    var objfrm2 = document.getElementById(Controlname2);
    var objFieldname1 = Fieldname1;
    var objFieldname2 = Fieldname2;


    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (

     objValidator.isValidQA(objfrm1, objfrm2, objValidator.Replace(objError.MandatoryAlert2, "<Field>", objFieldname1), objValidator.Replace(objError.MandatoryAlert2, "<Field>", objFieldname2))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//====================21.Function for checking valid date in dd-MMM-YYYY format==============================
function isValidDateValidation(Controlname1) {
    var objfrm1 = document.getElementById(Controlname1);
    var strdate = objfrm1.value
    var dt = strdate.split("/")
    var flag = false;

    var objValidator = new InputValidator();
    if
            (
    strdate != dt
    ) {
        flag = objValidator.isDateinMMM(dt[0], dt[1], dt[2])
    }
    else {
        dt = strdate.split("-")
        flag = objValidator.isDateinMMM(dt[0], dt[1], dt[2])
    }
    if (flag == true)
    { }
        //alert("Valid Date")
    else
        alert("invalid Date")
    objfrm1.focus()
    flag == false
    //	  	objValidator = null
    //		alert ("Form has been validated successfully.")
    //		flag=true
    //        }
    //	objValidator = null
    return flag
}

//====================22.Function for checking valid date in dd-MM-YYYY format==============================
function isValidDateValidation1(Controlname1) {
    var objfrm1 = document.getElementById(Controlname1);
    var strdate = objfrm1.value
    var dt = strdate.split("/")
    var flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
    strdate != dt
    ) {
        flag = objValidator.isDate(objfrm1, dt[0], dt[1], dt[2], objError.invalidDate)
    }
    else {
        dt = strdate.split("-")
        flag = objValidator.isDate(objfrm1, dt[0], dt[1], dt[2], objError.invalidDate)
    }
    return flag
}



//====================23.Function checking  Signed Float value==============================
function isSignedFloatValidation(Controlname, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isSignedFloat(objfrm, objValidator.Replace(objError.InvalidSignedFloatAlert, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}


//====================24.Function checking  Unsigned Float value==============================
function isUnSignedFloatValidation(Controlname, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isUnSignedFloat(objfrm, objValidator.Replace(objError.InvalidUnSignedFloatAlert, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//====================25.Function specifying Number with in a particular range==============================
function isNumInRangeValidation(Controlname, Low, High, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isNumInRange(objfrm, Low, High, objValidator.Replace(objError.numinRangealert, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}


//====================26.Function specifying An integer with in a particular range==============================
function isIntInRangeValidation(Controlname, Low, High, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isIntInRange(objfrm, Low, High, objValidator.Replace(objError.numinRangealert, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}
//============27.Function checking select dropdown==============================

function DropDownValidation(Controlname, Fieldname) {

    var objfrm = document.getElementById(Controlname);

    var objFieldname = Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
         objValidator.isSelectDropDown(objfrm, objValidator.Replace(objError.strSelecteDropDown, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//============28.Function checking Single Quote==============================
function chkSingleQuote(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
        objValidator.isSingleQuote(objfrm, objError.strSingleQuote)

     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//============29.Function checking valid URL==============================
function chkURL(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
        objValidator.isValidURL(objfrm, objError.strValidURL)

     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//============30.Function to check/select all checkboxes==============================

function SelectAll(chkboxControlname, GridID, FormName) {
    var objValidator = new InputValidator();
    objValidator.isSelectAll(chkboxControlname, GridID, FormName)
}
//====================31.Function checking WhiteSpaces in first place==============================
function WhiteSpaceValidation1st(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
            objValidator.isWhitespace1st(objfrm, objError.whitespace1st)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//============32.Function checking select ListBox==============================

function ListBoxValidation(Controlname, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
         objValidator.isSelectListBox(objfrm, objValidator.Replace(objError.strSelecteDropDown, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//===========================33.Function checking checkbox checked or not=====================

function ConfirmCheck(FormName) {
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    var flag;
    flag = false;

    if
            (
            objValidator.isChecked(FormName, objError.strChecked)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//===========================34.Function checking checkbox checked or not=====================
function ConfirmDelete(FormName) {
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    var flag;
    flag = false;

    if
            (
            objValidator.isDelete(FormName, objError.strChecked)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//===========================34.Function checking checkbox checked or not=====================
function ConfirmGrpSave(FormName) {
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    var flag;
    flag = false;

    if
            (
            objValidator.isSave(FormName, objError.strChecked)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}
//===========================34.Function to Activate the Items=====================
function ConfirmActivate(FormName) {
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    var flag;
    flag = false;

    if
            (
            objValidator.isActivate(FormName, objError.strChecked)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}
//===========================34.Function to Activate the Items=====================
function ConfirmDeActivate(FormName) {
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    var flag;
    flag = false;

    if
            (
            objValidator.isDeActivate(FormName, objError.strChecked)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}



//=====================35.Valid Time==========================================================
function ValidTime(Controlname1) {
    var objfrm1 = document.getElementById(Controlname1);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    //	var objError 	 = new ErrorAlert();
    if
            (

     objValidator.isValidTime(objfrm1)
     ) {
        //objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    //objError = null
    objValidator = null
    return flag
}
//=======================36.Phone Validator==================================================

function ValidPhoneNo(Controlname1) {
    var objfrm1 = document.getElementById(Controlname1);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    if
            (

     objValidator.checkPhoneValidator(objfrm1)
     ) {
        objValidator = null
        flag = true
    }
    objValidator = null
    return flag
}
//============================37.Select File to Upload=======================================
function selFileToUpload(Controlname1, FieldName1) {
    var objfrm1 = document.getElementById(Controlname1);
    var objFieldname = FieldName1;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
             (
      objValidator.isSelectFile(objfrm1, objValidator.Replace(objError.strSelectFile, "<Field>", objFieldname))
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//====================38.Function checking UNIVERSAL TELEPHONE Number ==============================
function UNIVERSALTelValidation(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isUNITel(objfrm, objError.validPhoneNo)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}
// Added By Priyabrat Routray 
function UNIVERSALTelValidationWithMsg(Controlname, Message) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
   objValidator.isUNITel(objfrm, Message)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }
    objError = null
    objValidator = null
    return flag
}

//=====================39.Compare Date===============================================
function CompareDate(Controlname1, Controlname2, Fieldname1, Fieldname2) {
    var objfrm1 = document.getElementById(Controlname1);
    var objfrm2 = document.getElementById(Controlname2);
    var objFieldname1 = Fieldname1;
    var objFieldname2 = Fieldname2;

    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (

     objValidator.isDateCompare(objfrm1, objfrm2, objValidator.Replace(objValidator.Replace(objError.strCompareDate, "<Field2>", objFieldname2), "<Field1>", objFieldname1))
     ) {
        objError = null
        objValidator = null
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//=============================40.Compare date in all format============================
function checkdateBeforeCompare(objName) {
    var datefield = document.getElementById(objName);
    if (chkdate(objName) == false) {
        datefield.select();
        alert("That date is invalid.  Please try again.");
        datefield.focus();
        return false;
    }
    else {
        return true;
    }
}

function chkdate(Controlname) {
    objName = document.getElementById(Controlname);

    //var strDatestyle = "US"; //United States date style
    var strDatestyle = "EU";  //European date style
    var strDate;
    var strDateArray;
    var strDay;
    var strMonth;
    var strYear;
    var intday;
    var intMonth;
    var intYear;
    var booFound = false;
    var datefield = objName;
    var strSeparatorArray = new Array("-", " ", "/", ".");
    var intElementNr;
    var err = 0;
    var strMonthArray = new Array(12);
    strMonthArray[0] = "Jan";
    strMonthArray[1] = "Feb";
    strMonthArray[2] = "Mar";
    strMonthArray[3] = "Apr";
    strMonthArray[4] = "May";
    strMonthArray[5] = "Jun";
    strMonthArray[6] = "Jul";
    strMonthArray[7] = "Aug";
    strMonthArray[8] = "Sep";
    strMonthArray[9] = "Oct";
    strMonthArray[10] = "Nov";
    strMonthArray[11] = "Dec";

    strDate = datefield.value;

    if (strDate.length < 1) {
        return true;
    }
    for (intElementNr = 0; intElementNr < strSeparatorArray.length; intElementNr++) {
        if (strDate.indexOf(strSeparatorArray[intElementNr]) != -1) {
            strDateArray = strDate.split(strSeparatorArray[intElementNr]);
            if (strDateArray.length != 3) {
                err = 1;
                return false;
            }
            else {
                strDay = strDateArray[0];
                strMonth = strDateArray[1];
                strYear = strDateArray[2];
            }
            booFound = true;
        }
    }
    if (booFound == false) {
        if (strDate.length > 5) {
            strDay = strDate.substr(0, 2);
            strMonth = strDate.substr(2, 2);
            strYear = strDate.substr(4);
        }
    }
    if (strYear.length == 2) {
        strYear = '20' + strYear;
    }
    // US style
    if (strDatestyle == "US") {
        strTemp = strDay;
        strDay = strMonth;
        strMonth = strTemp;
    }
    intday = parseInt(strDay, 10);
    if (isNaN(intday)) {
        err = 2;
        return false;
    }
    intMonth = parseInt(strMonth, 10);
    if (isNaN(intMonth)) {
        for (i = 0; i < 12; i++) {
            if (strMonth.toUpperCase() == strMonthArray[i].toUpperCase()) {
                intMonth = i + 1;
                strMonth = strMonthArray[i];
                i = 12;
            }
        }
        if (isNaN(intMonth)) {
            err = 3;
            return false;
        }
    }
    intYear = parseInt(strYear, 10);
    if (isNaN(intYear)) {
        err = 4;
        return false;
    }
    if (intMonth > 12 || intMonth < 1) {
        err = 5;
        return false;
    }
    if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31 || intday < 1)) {
        err = 6;
        return false;
    }
    if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30 || intday < 1)) {
        err = 7;
        return false;
    }
    if (intMonth == 2) {
        if (intday < 1) {
            err = 8;
            return false;
        }
        if (LeapYear(intYear) == true) {
            if (intday > 29) {
                err = 9;
                return false;
            }
        }
        else {
            if (intday > 28) {
                err = 10;
                return false;
            }
        }
    }
    if (strDatestyle == "US") {
        datefield.value = strMonthArray[intMonth - 1] + " " + intday + " " + strYear
    }
    else {
        datefield.value = intday + " " + strMonthArray[intMonth - 1] + " " + strYear
    }
    return true;
}
function LeapYear(intYear) {
    if (intYear % 100 == 0) {
        if (intYear % 400 == 0) { return true; }
    }
    else {
        if ((intYear % 4) == 0) { return true; }
    }
    return false;
}

//=======================================41.TEXTBOX VALIDATION IN DATAGRID=========================================
function DatagridValidation(DataGridID, TextBoxID, msg, len) {

    var MyDataGrid1 = document.getElementById(DataGridID).id
    var RowCount = len
    var rows;
    for (var i = 0; i < RowCount; i++) {
        if (i + 2 < 10) {
            rows = "0" + (i + 2);
        }
        else {
            rows = i + 2;
        }

        //            if(document.getElementById("MyDataGrid_ctl"+rows+"_cbItem").checked==true)
        //            { 
        //            alert("Entered")
        if (!blankFieldValidation(MyDataGrid1 + "_ctl" + rows + "_" + TextBoxID, msg)) {
            return false;
        }
        if (!WhiteSpaceValidation1st(MyDataGrid1 + "_ctl" + rows + "_" + TextBoxID)) {
            return false;
        }

        //            } 

        //        row=parseInt(row)+1;  
    }

}
//================================42.CompareTime=========================================

function CompareTime(Controlname1, Controlname2, Fieldname1, Fieldname2) {
    var objfrm1 = document.getElementById(Controlname1);
    var objfrm2 = document.getElementById(Controlname2);
    var objFieldname1 = Fieldname1;
    var objFieldname2 = Fieldname2;

    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (

     objValidator.isTimeCompare(objfrm1, objfrm2, objValidator.Replace(objValidator.Replace(objError.strCompareTime, "<Field2>", objFieldname2), "<Field1>", objFieldname1))
     ) {
        objError = null
        objValidator = null
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//===============================43.Compare Date in Calendar Format===============================

function compareDateinCalendarFormat(Controlname1, Controlname2, Fieldname1, Fieldname2) {
    //var fromDate=document.getElementById("TextBox1").value;
    //var toDate=document.getElementById("TextBox2").value;
    var obj1 = document.getElementById(Controlname1);
    var obj2 = document.getElementById(Controlname2);
    var objFieldname1 = Fieldname1;
    var objFieldname2 = Fieldname2;
    var fromDate = obj1.value;
    // alert(fromDate);

    var toDate = obj2.value;
    // alert(toDate);
    var dt1 = fromDate.split("/")
    var dt2 = toDate.split("/")
    var flag = false;
    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
    fromDate != dt1 && toDate != dt2
    ) {
        flag = objValidator.isDateCompareinCalendar(dt1[0], dt1[1], dt1[2], dt2[0], dt2[1], dt2[2], obj1, obj2, objValidator.Replace(objValidator.Replace(objError.strCompareDate, "<Field2>", objFieldname2), "<Field1>", objFieldname1))

    }
    else {
        dt1 = fromDate.split("-")
        dt2 = toDate.split("-")
        flag = objValidator.isDateCompareinCalendar(dt1[0], dt1[1], dt1[2], dt2[0], dt2[1], dt2[2], obj1, obj2, objValidator.Replace(objValidator.Replace(objError.strCompareDate, "<Field2>", objFieldname2), "<Field1>", objFieldname1))
    }
    return flag;
}
//====================44.Function TO CHECK Special Characters ==============================
function SpecialChar(Controlname) {

    var objError = new ErrorAlert();
    var msg = objError.strSplChar
    //var ValidChars = " '^&#%~`@$!\"/\<>:;?|]}[{";
    var str2 = document.getElementById(Controlname);
    var str1 = str2.value;
    var ValidChars = "-'^&#%~`@$!\"/\<>:;?|]}[{";
    var IsNumber = true;
    var Char;

    var position;

    for (i = 0; i < str1.length && IsNumber == true; i++) {
        Char = str1.charAt(i);
        position = ValidChars.indexOf(Char);
        //alert(position);
        if (position > -1) {

            IsNumber = false;
        }
    }
    //alert(IsNumber);
    if (IsNumber == false) {
        str1.IsValid = false;
        //				alert("Special Character is not Allowed !")
        alert(msg)
        str2.focus();
        return false;
    }
    else {
        str1.IsValid = true;
        return true;
    }
}

//================================== 45.Function to Check char in first place ==================================

function isCharfirst(Controlname) {
    var objError = new ErrorAlert();
    var msg = objError.strFstchar
    var str2 = document.getElementById(Controlname);
    var strInput = new String(str2.value);

    for (var i = 0; i < strInput.length; i++) {
        var str = strInput.charAt(0)
        if (!isNaN(str)) {
            alert(msg)
            str2.focus()
            return false;
        }
        else {
            return true;
        }
    }


}


//=========================46.Function for CheckBox Validation==============================
function CheckBoxValidation(Controlname, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
                (

        objValidator.isCheckBoxValidation(objfrm, objValidator.Replace(objError.strchkboxchecked, "<Field>", objFieldname))

        ) {
        objError = null
        objValidator = null
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//=========================47.Function for RadioButton Validation==============================
function RadioButtonValidation(Controlname, Fieldname) {
    var objfrm = document.getElementById(Controlname);
    var objFieldname = Fieldname;
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
                (
        objValidator.isRadBtnValidation(objfrm, objValidator.Replace(objError.strrbtchecked, "<Field>", objFieldname))

        ) {
        objError = null
        objValidator = null
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//=========================48.Function for Decimal Number Validation============================== 
function isValidDecimal(Controlname, msg) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
       objValidator.isValidDecimalNo(objfrm, objError.strDecimal + msg)
        //objValidator.isValidDecimalNo(objfrm,msg)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//============49.Function checking valid URL in www.google.com format ==============================
function chkURLinWWW(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
        objValidator.isValidwwwURL(objfrm, objError.strValidwwwURL)

     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//============50.Function checking valid URL in http://google.com format ==============================
function chkURLinHTTPDomain(Controlname) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
        objValidator.isValidURLinHTTPDomain(objfrm, objError.strURLinHTTPDomain)

     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}
//============51.Function checking for SpecialChar(input source as formID,sText control Name ==============================
//Commented By Nihar On 15-02-09 Due to Duplicate fuction.
//---------------------------------------------------------
//  function SpecialChar(source,sText)

//{

//   //var ValidChars = " '^&#%~`@$!\"/\<>:;?|]}[{";
//   var str2           =          eval("document."+source+"."+sText);
//            var str1  =          str2.value;
//   var ValidChars ="'^#%~`@";
//   var IsNumber=true;
//   var Char;
//   var  position;
//   for (i = 0; i < str1.length && IsNumber == true; i++) 
//      { 
//      Char = str1.charAt(i); 
//      position = ValidChars.indexOf(Char);
//      if (position > -1) 
//         {
//                IsNumber = false;
//         }
//      }

//                       if(IsNumber==false)
//                                    {
//                                                str1.IsValid = false;
//                                                alert("Special Character is not Allowed !")
//                                                str2.focus();
//                                                return false;
//                                    }
//                        else
//                                    {
//                                                str1.IsValid =true;
//                                                return true;
//                                    }
// }

//============================================FUNCTION TO GET DATE VALIDATION WHETHER GREATER THAN CURRENT DATE OR NOT============================

//Commented By Biswaprem On 12-JAN-08

//function DigiDate()  //Function to get Digital Date 
//    { 
//        if (navigator.appName == "Microsoft Internet Explorer")
//        {
//            var DigiDate = new Date()
//            var year = DigiDate.getYear()
//            var month = DigiDate.getMonth()
//            var day = DigiDate.getDay()
//            var dayNo = DigiDate.getDate()
//            var date;
//            var DayNoType;

//            if ((dayNo == "1") || (dayNo == "21") || (dayNo == "31")){ DayNoType = "st" }

//            else if ((dayNo == "2") || (dayNo == "22")){ DayNoType = "nd" }

//            else if ((dayNo == "3") || (dayNo == "23")){ DayNoType = "rd" }

//            else (DayNoType = "th")

//             

//            if (day == "1"){ day = "Mon" }

//            else if (day == "2"){ day = "Tue" }

//            else if (day == "3"){ day = "Wed" }

//            else if (day == "4"){ day = "Thu" }

//            else if (day == "5"){ day = "Fri" }

//            else if (day == "6"){ day = "Sat" }

//            else if (day == "0"){ day = "Sun" }

//             

//            if (month == "0"){ month = "Jan" }

//            else if (month == "1"){ month = "Feb" }

//            else if (month == "2"){ month = "Mar" }

//            else if (month == "3"){ month = "Apr" }

//            else if (month == "4"){ month = "May" }

//            else if (month == "5"){ month = "Jun" }

//            else if (month == "6"){ month = "Jul" }

//            else if (month == "7"){ month = "Aug" }

//            else if (month == "8"){ month = "Sep" }

//            else if (month == "9"){ month = "Oct" }

//            else if (month == "10"){ month = "Nov" }

//            else if (month == "11"){ month = "Dec" }

//             date =  dayNo + "-"  + month + "-" + year

//            return date;

//            setTimeout('DigiDate()',1000)
//        }
//    }

//    function formatDate(dt)   //To get Correct Date Format for Calculation
//    {
//        var	strTemp="";
//        var	strChar;
//        var	date1 = new Array(3);
//        var	j=0;
//        var strDateTo=dt;
//        var todatelen=strDateTo.length;

//        for(var i=0;i<=todatelen;i++)
//        {
//            strChar=strDateTo.charAt(i);
//            if (strChar=='-' || i==todatelen)
//            {
//                date1[j]=strTemp;
//                strTemp="";
//                j=j+1;
//            }
//            else
//            {
//                strTemp=strTemp+strChar;
//            }

//            if (strChar==" ")
//                break;
//        }

//        switch(date1[1])
//        {
//            case	'Jan'	:	
//             case	'January'	:	date1[1]=01;
//            break;
//            case	'Feb'	:	
//             case	'Februry'	:	date1[1]=02;
//            break;
//            case	'Mar'	:	
//             case	'March'	:	    date1[1]=03;
//            break;
//            case	'Apr'	:	date1[1]=04;
//            case	'April'	:	date1[1]=04;
//            break;
//            case	'May'	:	date1[1]=05;
//            break;
//            case	'Jun'	:	
//              case	'June'	:	date1[1]=06;
//            break;
//            case	'Jul'	:	
//             case	'July'	:	date1[1]=07;
//            break;
//            case	'Aug'	:	
//            case	'August':	date1[1]=08;
//            break;
//          case	    'Sep'	:	
//             case	'Septmber':	date1[1]=09;
//            break;
//           case	   'Oct'	:	
//            case	'October':	date1[1]=10;
//            break;
//            case	'Nov'	:	
//             case	'November'	:	date1[1]=11;
//            break;
//            case	'Dec'	:	
//            case	'December'	:	date1[1]=12;
//            break;
//        }
//        
//        if (date1[0] < 10)
//            date1[0] = '0'+date1[0].toString().substring(0);

////        if (date1[1] < 10)
////            date1[1] = '0'+date1[1].toString().substring(0);

//        var	conDate = date1[1]+"/"+date1[0]+"/"+date1[2];
//        return(conDate);

//    }
//    
//    function CheckDate(date1, date2)  //Function to Check two Date whether greater or smaller
//    {
//    
//        if (date1.toString().substring(6,10) <=date2.toString().substring(6,10))
//        {
//            if (date1.toString().substring(0,2) > date2.toString().substring(0,2))
//            {
//                    return true;
//            }
//            else if (date1.toString().substring(0,2) <= date2.toString().substring(0,2))
//            {
//          
//                if (date1.toString().substring(3,5) >= date2.toString().substring(3,5))
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                return false;
//            }
//        }
//        else if (date1.toString().substring(6,10) > date2.toString().substring(6,10))
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//    
//        function CurrentDateValidator(objCtl,objCtl1,Message)

//    {

//        var StartDate=formatDate(document.getElementById(objCtl).value);
//         var EndDate=formatDate(document.getElementById(objCtl1).value);

//    
//        if (!CheckDate(StartDate,EndDate))
//        {
//           alert(Message + " Can't Be Greater than Todate");
//            return false;
//        }
//        return true;
//    }

function AddRows(objddl, CountTotRows, row, objgridview) {
    document.getElementById(objgridview).style.display = "";
    var st = 1;

    if (document.getElementById(objddl).value == 0) {
        document.getElementById(objgridview).style.display = "none";
    }
    var current = document.getElementById(objddl).value;
    for (var i = st; i < CountTotRows + 1; i++) {
        document.getElementById(row + i).style.display = "none";
    }
    for (var i = st; i < current; i++) {
        document.getElementById(row + i).style.display = "";
    }
    return false;
}


function remove(objgrdview) {
    document.getElementById(objgrdview).style.display = "none";
}

//===========================================
//    function CurrentDateLessValidator(objCtl, Message)//Function to validate current Date Should be Greater than given date
//    {
//        var StartDate=formatDate(document.getElementById(objCtl).value);
//        var Curdate=formatDate(DigiDate());

//        if (!CheckDate(Curdate,StartDate))
//        {
//            alert(Message + " Can't Be Greater than Current Date");
//            return false;
//        }
//        return true;
//    }

//    function CurrentDateGreaterValidator(objCtl, Message)//Function to validate current Date Should not be Greater than given date
//    {
//        var StartDate=formatDate(document.getElementById(objCtl).value);
//        var Curdate=formatDate(DigiDate());

//        if (!CheckDate(StartDate,Curdate))
//        {
//            alert(Message + " can't be before Current Date");
//            return false;
//        }
//        return true;
//    }
//========================================================Added By Aroop==============


function CheckListEmpty(thecontrol, strMessage) {

    var objForm1 = document.frm;

    var Lstbox = document.getElementById(thecontrol)//eval("document."+frm+"."+thecontrol);
    if (Lstbox.length == 0) {
        alert('Select ' + strMessage);
        Lstbox.focus();
        return false;
    }
    else {
        return true;
    }
}



//Added By Biswaprem On 12-JAN-08 To Validate A Date Against Current Date

function DigiDate()  //Function to get Digital Date 
{
    //        if (navigator.appName == "Microsoft Internet Explorer")
    //        {
    var DigiDate = new Date()
    var year = DigiDate.getFullYear()
    var month = DigiDate.getMonth()
    var day = DigiDate.getDay()
    var dayNo = DigiDate.getDate()
    //           alert(dayNo.toString.length);
    var date;
    var DayNoType;
    if (dayNo.toString().length == 1) { dayNo = '0' + dayNo.toString(); }// Modified by Amrut.           
    if ((dayNo == "1") || (dayNo == "21") || (dayNo == "31")) { DayNoType = "st" }

    else if ((dayNo == "2") || (dayNo == "22")) { DayNoType = "nd" }

    else if ((dayNo == "3") || (dayNo == "23")) { DayNoType = "rd" }

    else (DayNoType = "th")



    if (day == "1") { day = "Mon" }

    else if (day == "2") { day = "Tue" }

    else if (day == "3") { day = "Wed" }

    else if (day == "4") { day = "Thu" }

    else if (day == "5") { day = "Fri" }

    else if (day == "6") { day = "Sat" }

    else if (day == "0") { day = "Sun" }



    if (month == "0") { month = "Jan" }

    else if (month == "1") { month = "Feb" }

    else if (month == "2") { month = "Mar" }

    else if (month == "3") { month = "Apr" }

    else if (month == "4") { month = "May" }

    else if (month == "5") { month = "Jun" }

    else if (month == "6") { month = "Jul" }

    else if (month == "7") { month = "Aug" }

    else if (month == "8") { month = "Sep" }

    else if (month == "9") { month = "Oct" }

    else if (month == "10") { month = "Nov" }

    else if (month == "11") { month = "Dec" }


    date = dayNo + "-" + month + "-" + year

    return date;

    setTimeout('DigiDate()', 1000)
    //        }
}

function formatDate(dt) {
    var strTemp = "";
    var strChar;
    var date1 = new Array(3);
    var j = 0;
    var strDateTo = dt;
    var todatelen = strDateTo.length;

    for (var i = 0; i <= todatelen; i++) {
        strChar = strDateTo.charAt(i);
        if (strChar == '-' || i == todatelen) {
            date1[j] = strTemp;
            strTemp = "";
            j = j + 1;
        }
        else {
            strTemp = strTemp + strChar;
        }

        if (strChar == " ")
            break;
    }

    switch (date1[1]) {
        case 'Jan': date1[1] = 01;
            break;
        case 'January': date1[1] = 01;
            break;
        case 'Feb': date1[1] = 02;
            break;
        case 'February': date1[1] = 02;
            break;
        case 'Mar': date1[1] = 03;
            break;
        case 'March': date1[1] = 03;
            break;
        case 'Apr': date1[1] = 04;
            break;
        case 'April': date1[1] = 04;
            break;
        case 'May': date1[1] = 05;
            break;
        case 'Jun': date1[1] = 06;
            break;
        case 'June': date1[1] = 06;
            break;
        case 'Jul': date1[1] = 07;
            break;
        case 'July': date1[1] = 07;
            break;
        case 'Aug': date1[1] = 08;
            break;
        case 'August': date1[1] = 08;
            break;
        case 'Sep': date1[1] = 09;
            break;
        case 'September': date1[1] = 09;
            break;
        case 'Oct': date1[1] = 10;
            break;
        case 'October': date1[1] = 10;
            break;
        case 'Nov': date1[1] = 11;
            break;
        case 'November': date1[1] = 11;
            break;
        case 'Dec': date1[1] = 12;
            break;
        case 'December': date1[1] = 12;
            break;
    }

    if (date1[0] < 10)
        date1[0] = date1[0].toString().substring(0);

    if (date1[1] < 10)
        date1[1] = '0' + date1[1].toString().substring(0);

    var conDate = date1[1] + "/" + date1[0] + "/" + date1[2];
    //        alert(conDate);
    //        return false;
    return (conDate);

}

function CheckDate(date1, date2)  //Function to Check two Date whether greater or smaller
{
    if (date1.toString().substring(6, 10) <= date2.toString().substring(6, 10)) {
        if (date1.toString().substring(0, 2) > date2.toString().substring(0, 2)) {
            return false;
        }
        else if (date1.toString().substring(0, 2) == date2.toString().substring(0, 2)) {
            if (date1.toString().substring(3, 5) <= date2.toString().substring(3, 5)) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
    else if (date1.toString().substring(6, 10) > date2.toString().substring(6, 10)) {
        return false;
    }
    else {
        return false;
    }
}
function CurrentDateValidator(objCtl, Message) {
    var StartDate = formatDate(document.getElementById(objCtl).value);
    var Curdate = formatDate(DigiDate());

    if (!CheckDate(Curdate, StartDate)) {
        alert(Message + " Can't Be Greater or Less than Current Date");

        return false;
    }
    return true;
}

function CurrentDateGreaterValidator(objCtl, Message) {
    var StartDate = formatDate(document.getElementById(objCtl).value);
    var Curdate = formatDate(DigiDate());
    if (!CheckDate(StartDate, Curdate)) {
        alert(Message + " can't be before Current Date");
        return false;
    }
    return true;
}

//============51.Function checking for Negative Value(input source as formID,sText control Name ==============================
//Added By Swetapadma Swain on 06-Feb-2009 
function NegativeValue(source, sText) {

    //var ValidChars = " '^&#%~`@$!\"/\<>:;?|]}[{";
    var str2 = eval("document." + source + "." + sText);

    var str1 = str2.value;

    var ValidChars = "-";
    var IsNumber = true;
    var Char;
    var position;
    for (i = 0; i < str1.length && IsNumber == true; i++) {
        Char = str1.charAt(i);
        position = ValidChars.indexOf(Char);
        if (position > -1) {
            IsNumber = false;
        }
    }

    if (IsNumber == false) {
        str1.IsValid = false;
        alert("Negative Value is not Allowed !");
        str2.focus();
        return false;
    }
    else {
        str1.IsValid = true;
        return true;
    }
}



//============52.Function checking for Start date and End date validation(End Date cannot be less then Start date) ==============================
//Added By Satyajit Shadangi on 12-Feb-2009 


function CompareDateValidator(objCtl, objCtl1, Message, Message1) {

    var StartDate = formatDate1(document.getElementById(objCtl).value);
    var EndDate = formatDate1(document.getElementById(objCtl1).value);

    // var Curdate=formatDate(DigiDate());

    if (!CheckDate1(StartDate, EndDate) == false) {
        // alert(Message + " Can't Be Greater than " +Message1);
        alert(Message1 + " Can't Be Earlier than " + Message);
        return false;
    }
    return true;
}

function CheckDate1(date1, date2) {

    if (date1.toString().substring(6, 10) == date2.toString().substring(6, 10)) {
        if (date1.toString().substring(0, 2) > date2.toString().substring(0, 2)) {
            return true;
        }
        else if (date1.toString().substring(0, 2) == date2.toString().substring(0, 2)) {
            // alert('ho');
            if (date1.toString().substring(3, 5) > date2.toString().substring(3, 5)) {
                // alert('ho1');
                return true;
            }
            else {
                // alert('ho2')
                return false;
            }
        }
        else if (date1.toString().substring(0, 2) < date2.toString().substring(0, 2)) {

            return false;
        }
        else {
            return false;
        }
    }
    else if (date1.toString().substring(6, 10) > date2.toString().substring(6, 10)) {
        return true;
    }
    else if (date1.toString().substring(6, 10) < date2.toString().substring(6, 10)) {
        return false;
    }
    else {
        return false;

    }
}



function formatDate1(dt) {

    var strTemp = "";

    var strChar;

    var date1 = new Array(3);

    var j = 0;

    var strDateTo = dt;

    var todatelen = strDateTo.length;



    for (var i = 0; i <= todatelen; i++) {

        strChar = strDateTo.charAt(i);

        if (strChar == '-' || i == todatelen) {

            date1[j] = strTemp;

            strTemp = "";

            j = j + 1;

        }

        else {

            strTemp = strTemp + strChar;

        }



        if (strChar == " ")

            break;

    }



    switch (date1[1]) {

        case 'Jan':     //date1[1]=01;

            // break;
        case 'jan':
        case 'january':
        case 'January': date1[1] = 01;

            break;

        case 'Feb':     //date1[1]=02;
        case 'feb':

        case 'february':
        case 'February': date1[1] = 02;

            break;

        case 'Mar':     //date1[1]=03;
        case 'mar':
            //break;
        case 'march':
        case 'March': date1[1] = 03;

            break;

        case 'Apr':     //date1[1]=04;
        case 'apr':
            //break;
        case 'april':
        case 'April': date1[1] = 04;

            // break;
        case 'may':
        case 'May': date1[1] = 05;


            break;

        case 'Jun':     //date1[1]=06;
        case 'jun':
            //break;
        case 'june':
        case 'June': date1[1] = 06;

            break;

        case 'Jul':     //date1[1]=07;
        case 'jul':
            //break;
        case 'july':
        case 'July': date1[1] = 07;

            break;

        case 'Aug':     //date1[1]=08;
        case 'aug':
            //break;
        case 'august':
        case 'August': date1[1] = 08;

            break;

        case 'Sep':     //date1[1]=09;
        case 'sep':
            //break;
        case 'september':
        case 'September': date1[1] = 09;

            break;

        case 'Oct':     //date1[1]=10;
        case 'oct':
            // break;
        case 'october':
        case 'October': date1[1] = 10;

            break;

        case 'Nov':     //date1[1]=11;
        case 'Nov':
            // break;
        case 'november':
        case 'November': date1[1] = 11;

            break;

        case 'Dec':     //date1[1]=12;
        case 'dec':
            // break;
        case 'december':
        case 'December': date1[1] = 12;

            break;

    }



    if (date1[0] < 10)

        date1[0] = date1[0].toString().substring(0);



    if (date1[1] < 10)

        date1[1] = '0' + date1[1].toString().substring(0);



    var conDate = date1[1] + "/" + date1[0] + "/" + date1[2];

    //        alert(conDate);

    //        return false;

    return (conDate);



}

//Added By Biswaprem On 16-FEB-09

function IsSpecialCharacter(Object, msg) {
    var Arr = new Array();
    var k;
    Arr = Object.split(',');
    for (k = 0; k < Arr.length; k++) {
        var str1 = trim(new String(document.getElementById(Arr[k]).value))
        for (var i = 0; i < str1.length; i++) {
            var ch = str1.substring(i, i + 1);
            if (ch == "'" || ch == ">" || ch == "<" || ch == "!" || ch == "^" || ch == "%" || ch == "?" || ch == "~") {
                alert(msg);
                document.getElementById(Arr[k]).focus();
                return false;
            }
        }
    }
    return true;
}

//Added By Bodhisattwa On 17-FEB-09
function TextCounter(ctlTxtName, lblCouter, numTextSize) {
    var txtName = document.getElementById(ctlTxtName).value;
    var txtNameLength = txtName.length;
    if (parseInt(txtNameLength) > parseInt(numTextSize)) {
        var txtMaxTextSize = txtName.substr(0, numTextSize)
        document.getElementById(ctlTxtName).innerHTML = txtMaxTextSize;
        alert("Entered Text Exceeds '" + numTextSize + "' Characters.");
        document.getElementById(lblCouter).innerHTML = 0;
        return false;
    }
    else {
        document.getElementById(lblCouter).innerHTML = parseInt(numTextSize) - parseInt(txtNameLength);
        return true;
    }
}

///////////////////////////////////////////////////Mithun////////////////////////////////////////

// JScript File

function formatDate_Multiple(dt) {

    var strTemp = "";

    var strChar;

    var date1 = new Array(3);

    var j = 0;

    var strDateTo = dt;

    var todatelen = strDateTo.length;
    for (var i = 0; i <= todatelen; i++) {

        strChar = strDateTo.charAt(i);

        if (strChar == '-' || i == todatelen) {

            date1[j] = strTemp;

            strTemp = "";

            j = j + 1;

        }

        else {

            strTemp = strTemp + strChar;

        }



        if (strChar == " ")

            break;

    }



    switch (date1[1]) {

        case 'Jan':     //date1[1]=01;

            // break;
        case 'jan':
        case 'january':
        case 'January': date1[1] = 01;

            break;

        case 'Feb':     //date1[1]=02;
        case 'feb':

        case 'february':
        case 'February': date1[1] = 02;

            break;

        case 'Mar':     //date1[1]=03;
        case 'mar':
            //break;
        case 'march':
        case 'March': date1[1] = 03;

            break;

        case 'Apr':     //date1[1]=04;
        case 'apr':
            //break;
        case 'april':
        case 'April': date1[1] = 04;

            // break;
        case 'may':
        case 'May': date1[1] = 05;


            break;

        case 'Jun':     //date1[1]=06;
        case 'jun':
            //break;
        case 'june':
        case 'June': date1[1] = 06;

            break;

        case 'Jul':     //date1[1]=07;
        case 'jul':
            //break;
        case 'july':
        case 'July': date1[1] = 07;

            break;

        case 'Aug':     //date1[1]=08;
        case 'aug':
            //break;
        case 'august':
        case 'August': date1[1] = 08;

            break;

        case 'Sep':     //date1[1]=09;
        case 'sep':
            //break;
        case 'september':
        case 'September': date1[1] = 09;

            break;

        case 'Oct':     //date1[1]=10;
        case 'oct':
            // break;
        case 'october':
        case 'October': date1[1] = 10;

            break;

        case 'Nov':     //date1[1]=11;
        case 'Nov':
            // break;
        case 'november':
        case 'November': date1[1] = 11;

            break;

        case 'Dec':     //date1[1]=12;
        case 'dec':
            // break;
        case 'december':
        case 'December': date1[1] = 12;

            break;

    }



    if (date1[0] < 10)

        date1[0] = date1[0].toString().substring(0);



    if (date1[1] < 10)

        date1[1] = '0' + date1[1].toString().substring(0);



    var conDate = date1[1] + "/" + date1[0] + "/" + date1[2];

    //        alert(conDate);

    //        return false;

    return (conDate);

}



function CheckDate_Multiple(date1, date2) {

    if (date1.toString().substring(6, 10) == date2.toString().substring(6, 10)) {
        if (date1.toString().substring(0, 2) > date2.toString().substring(0, 2)) {
            return true;
        }
        else if (date1.toString().substring(0, 2) == date2.toString().substring(0, 2)) {
            // alert('ho');
            if (date1.toString().substring(3, 5) > date2.toString().substring(3, 5)) {
                // alert('ho1');
                return true;
            }
            else {
                // alert('ho2')
                return false;
            }
        }
        else if (date1.toString().substring(0, 2) < date2.toString().substring(0, 2)) {

            return false;
        }
        else {
            return false;
        }
    }
    else if (date1.toString().substring(6, 10) > date2.toString().substring(6, 10)) {
        return true;
    }
    else if (date1.toString().substring(6, 10) < date2.toString().substring(6, 10)) {
        return false;
    }
    else {
        return false;

    }
}


function CompareDate_Multiple(objCtl, objCtl1, Message) {

    var StartDate = formatDate_Multiple(document.getElementById(objCtl).value);

    var EndDate = formatDate_Multiple(document.getElementById(objCtl1).value);

    // var Curdate=formatDate_Multiple(DigiDate());

    if (!CheckDate_Multiple(StartDate, EndDate) == false) {

        alert(Message + " Can't Be Greater than End Date");
        return false;
    }
    return true;
}
//To show and hide the date by checking the ckeck box
//===============Added By subrat==================


function CompareDate_today(objCtl, objCtl1, Message) {
    var StartDate = formatDate_Multiple(document.getElementById(objCtl).innerText);

    var EndDate = formatDate_Multiple(document.getElementById(objCtl1).value);

    // var Curdate=formatDate_Multiple(DigiDate());

    if (!CheckDate_Multiple(StartDate, EndDate) == false) {

        alert(Message + " Can't Be Greater than Todate");
        return false;
    }
    return true;
}

//=========================================================================
//Added By Pratik On 20-FEB-09  
function deSelectHeader(ChkID, GridId, Formname) {
    var FormId = document.getElementById(Formname);
    var i, j, k;
    j = 0;
    k = 0
    for (i = 0; i < FormId.elements.length; i++) {
        if ((FormId.elements[i].type == 'checkbox') && (FormId.elements[i].name.indexOf(GridId) > -1) && (FormId.elements[i].disabled == false)) {
            k = k + 1;
            if (FormId.elements[i].checked == false) {
                ChkID.checked = false;
            }
            else {
                j = parseInt(j) + 1;
            }
        }
    }
    if (j == k)
        ChkID.checked = true;
    return true;
}
//==========================================================================


function CalculateMonth(month) {

    if (month == "January" || month == "Jan") { month = "1" }



    else if (month == "February" || month == "Feb") { month = "2" }

    else if (month == "March" || month == "Mar") { month = "3" }

    else if (month == "April" || month == "Apr") { month = "4" }

    else if (month == "May") { month = "5" }

    else if (month == "June" || month == "Jun") { month = "6" }

    else if (month == "July" || month == "Jul") { month = "7" }

    else if (month == "August" || month == "Aug") { month = "8" }

    else if (month == "September" || month == "Sep") { month = "9" }

    else if (month == "October" || month == "Oct") { month = "10" }

    else if (month == "November" || month == "Nov") { month = "11" }

    else if (month == "December" || month == "Dec") { month = "12" }

    return month;



}





function showtime(dateform, timefrom) {



    //  document.getElementById(timeresult).value=" ";





    dateform = document.getElementById(dateform).value;

    // dateto=document.getElementById(dateto).value;

    timefrom = document.getElementById(timefrom).value;



    //timeto=document.getElementById(timeto).value;

    var hrwithminfrom = timefrom.split(" ");

    hrwithminfrom = hrwithminfrom[0];

    var tf = timefrom.split(":");

    var hf = tf[0];

    var minfwithampm = tf[1].split(" ");

    var minf = minfwithampm[0];

    var check = minfwithampm[1]

    hrwithminfrom = hf + "." + minf

    //alert(hrwithminfrom);

    if (check == "AM") {

        var totalminsfrom = (parseInt(hf) * 60) + (parseInt(minf));

    }

    else {

        var totalminsfrom = ((parseInt(hf) + 12) * 60) + (parseInt(minf));



    }





    var A = dateform.split("-");

    var month = A[1];

    var p = CalculateMonth(month)







    //Total time for one day

    var one_day = 1000 * 60 * 60 * 24;



    var x = dateform.split("-");



    x[1] = p;





    var date1 = new Date(x[2], (x[1] - 1), x[0]);





    var month1 = x[1] - 1;



    var cur_dat = new Date();

    var curyear = cur_dat.getYear();

    var curmonth = cur_dat.getMonth();

    var curdate = cur_dat.getDate();





    var currendate = new Date(curyear, curmonth, curdate);

    var _Diff = 1;



    if (date1 < currendate) {

        alert("Date Should be greater than current date");

        return false;

    }



    if (currendate = date1)//when from date and to date will be the  same date

    {





        var d = new Date();

        var curr_hour = d.getHours();



        var curr_min = d.getMinutes();

        var totalcurrentmins = (curr_hour * 60) + (curr_min)





        if (totalminsfrom < totalcurrentmins) {

            alert("From Time Should be More Than Current Time");

            return false;



        }



    }



}

function CompareTwoDates(objCtl, objCtl1, Message) {
    var StartDate = formatDate_Multiple(document.getElementById(objCtl).value);
    var EndDate = formatDate_Multiple(document.getElementById(objCtl1).value);

    if (!CheckDate_Multiple(StartDate, EndDate) == false) {
        alert(Message);
        return false;
    }
    return true;
}


//==========Added By Pratik On 31-Mar-2009======================
function WhiteSpaceLast(objCtl) {
    var val = document.getElementById(objCtl).value;
    var llen = document.getElementById(objCtl).value.length;
    var x = parseInt(llen) - 1;
    if (val.charAt(x) == " ") {
        alert('Whitespace Not Allowed in the Last Place');
        document.getElementById(objCtl).focus();
        return false;
    }
    return true;
}


//=========================48.Function for Decimal Number with Comma Separator Validation============================== 
function isValidDecimalwithComma(Controlname, msg) {
    var objfrm = document.getElementById(Controlname);
    var flag;
    flag = false;

    var objValidator = new InputValidator();
    var objError = new ErrorAlert();
    if
            (
       objValidator.isValidDecimalNo1(objfrm, objError.strDecimal + msg)
        //objValidator.isValidDecimalNo(objfrm,msg)
     ) {
        objError = null
        objValidator = null
        //alert ("Form has been validated successfully.")
        flag = true
    }

    objError = null
    objValidator = null
    return flag
}

//Added By Prabhu Prasad Mishra On 12th-Jan-2011 To Block the Special charecters Entry at first position 

function blockspecialchar_first(e) {
    var str;
    str = e.value;

    switch (str.charCodeAt(0)) {
        case 44:
            {

                alert(", Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;

            }
        case 45:
            {

                alert("- Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;

            }
        case 47:
            {
                alert("/ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;

            }
        case 58:
            {
                alert(": Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 46:
            {
                alert(". Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 35:
            {
                alert("# Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 38:
            {
                alert("& Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 39:
            {
                alert("Single Quote Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 32:
            {
                alert("White Space Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 33:
            {
                alert("! Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 34:
            {
                alert(" Double Quotes is Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 36:
            {
                alert("$ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 37:
            {
                alert("% Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 40:
            {
                alert("( Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 41:
            {
                alert(") Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 42:
            {
                alert("* Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 43:
            {
                alert("+ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }


        case 59:
            {
                alert("; Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 61:
            {
                alert("= Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 60:
            {
                alert("< Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 62:
            {
                alert("> Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 64:
            {
                alert("@ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 91:
            {
                alert("[ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 92:
            {
                alert("\ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 93:
            {
                alert("] Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 94:
            {
                alert("^ Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 95:
            {
                alert("_ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;

            }
        case 96:
            {
                alert("' Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 123:
            {
                alert("{ Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 124:
            {
                alert("| Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 125:
            {
                alert("} Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 126:
            {
                alert("~ Not allowed in 1st Place!!!");
                //e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
        case 63:
            {
                alert("? Not allowed in 1st Place!!!");
                // e.value = "";
                str = str.substring(1, str.length);
                e.value = str;
                e.focus();
                return false;
            }
    }
}
/*To check the max length of a textbox and so the remaining text in the label*/
/*Created by surendra mahapatra on 14th Mar 2011*/
function TextCounterval(ctlTxtName, lblCouter, numTextSize) {
    var txtName = document.getElementById(ctlTxtName).value;
    var txtNameLength = txtName.length;
    if (parseInt(txtNameLength) > parseInt(numTextSize)) {
        var txtMaxTextSize = txtName.substr(0, numTextSize)
        document.getElementById(ctlTxtName).innerHTML = txtMaxTextSize;
        alert("Entered Text Exceeds '" + numTextSize + "' Characters.");
        document.getElementById(lblCouter).innerHTML = 0;
        return false;
    }
    else {
        document.getElementById(lblCouter).innerHTML = parseInt(numTextSize) - parseInt(txtNameLength);
        return true;
    }
}
/*Created by Debashree Ray on 24th May 2011*/
/*Special character Validation*/
function IsSpecialChars(myStringID) {
    var strToSearch = document.getElementById(myStringID).value;
    var bool = false;
    if (strToSearch == "") {
        alert("Blankspace is  not allowed.");
        return false;
    }
    else {
        var str = "";
        var illegalChars = "!@#$%^&*()+=[]\\\';,/{}|\":<>?";

        for (var i = 0; i < strToSearch.length; i++) {
            if (illegalChars.indexOf(strToSearch.charAt(i)) != -1) {
                str += strToSearch.charAt(i);
            }
        }

        for (var i = 0; i < strToSearch.length; i++) {
            if (illegalChars.indexOf(strToSearch.charAt(i)) != -1)
                bool = true;
            else
                bool = false;

        }
        if (bool == true) {
            alert("The special characters " + str + " is  not allowed.");

            return false;
        }
        else
            return true;
    }

}

/* ----------------------------------------------------- Upload Photograps as file system ------------------------------------------- */
function OpenUpload() {
    window.open("UploadPopUp.aspx", "Photograph Upload", "left=400,top=300,width=520,height=350,menubar=0,resizable=0,scrollbars=0,addressbar=0");
}
/* -------------------------------------------- Capture Photo by Web cam and Uploda Photograps ----------------------------------------   */
function OpenCapture() {

    window.open("ImageConversions.aspx", "", "left=400,top=300,width=520,height=320,menubar=0,resizable=0,scrollbars=0,addressbar=0");

}

/* ------------------------Upload Signature from Camera system-----------------------------*/
function OpenSignCapture() {

    window.open("SImageConversions.aspx", "", "left=400,top=300,width=520,height=320,menubar=0,resizable=0,scrollbars=0,addressbar=0");

}

/* ----------------------------Upload Signature from File system--------------------------*/
function OpenSignUpload() {
    window.open("UploadSignature.aspx", "Signature Upload", "left=400,top=300,width=520,height=265,menubar=0,resizable=0,scrollbars=0,addressbar=0");
}

/* -------------------------------------------------------------------------------------*/

function CurrentDateGreaterValidator(objCtl, Message)//Function to validate current Date Should not be Greater than given date
{
    var StartDate = formatDate(document.getElementById(objCtl).value);
    var Curdate = formatDate(DigiDate());

    if (!CheckDate(StartDate, Curdate)) {
        if (StartDate.toString().substring(3, 5) == Curdate.toString().substring(3, 5)) {
            return true;
        }
        else {
            alert(Message + " can't be Greater than Current Date");
            return false;
        }

    }
    return true;
}
function DateGreater(objCtl, Message)//Function to validate current Date Should be Greater than given date
{

    var StartDate = formatDate(document.getElementById(objCtl).value);
    var Curdate = formatDate(DigiDate());
    if (!CheckDateGreater(Curdate, StartDate)) {
        alert(Message + " Cannot Be Greater than Current Date");
        return false;
    }
    return true;
}
function CheckDateGreater(date1, date2)  //Function to Check two Date whether greater or smaller
{
    if (date1.toString().substring(6, 10) == date2.toString().substring(6, 10))// CHeck Year
    {

        if (date1.toString().substring(0, 2) == date2.toString().substring(0, 2))// CHeck Month
        {
            if (date1.toString().substring(3, 5) >= date2.toString().substring(3, 5)) {
                return true;
            }
            else {
                return false;
            }
        }
        else if (date1.toString().substring(0, 2) > date2.toString().substring(0, 2)) {
            return true;
        }
        else {
            return false;
        }
    }
    else if (date1.toString().substring(6, 10) > date2.toString().substring(6, 10)) {
        return true;
    }
    else {
        return false;
    }
}

function CurrentDateLessValidatorNew(objCtl, Message)//Function to validate current Date Should be Greater than given date
{
    var StartDate = formatDate(document.getElementById(objCtl).value);
    var Curdate = formatDate(DigiDate());
    if (!CheckDategReater(StartDate, Curdate)) {
        alert(Message + " Cannot Be Less than Current Date");
        return false;
    }
    return true;
}
function CurrentDateLessValidatorMonthYear(objCtl, Message)//Function to validate current Date Should be Greater than given date
{

    var Curdate = formatDate(DigiDate());
    if (!CheckDategReater(objCtl, Curdate)) {
        alert(Message);
        return false;
    }
    return true;
}
function CheckDategReater(date1, date2)  //Function to Check two Date whether greater or smaller
{
    //    alert(date1);
    //    alert(date2);
    //    alert(date1.toString().substring(6,10));
    //    alert(date2.toString().substring(6,10));
    //    alert(date1.toString().substring(0,2));
    //    alert(date2.toString().substring(0,2));
    //    alert(date1.toString().substring(3,5));
    //    alert(date2.toString().substring(3,5));
    if (date1.toString().substring(6, 10) <= date2.toString().substring(6, 10)) {
        if (date1.toString().substring(0, 2) > date2.toString().substring(0, 2)) {
            return true;
        }
        else if (date1.toString().substring(0, 2) < date2.toString().substring(0, 2)) {
            return false;

        }
        else {
            if (date1.toString().substring(3, 5) >= date2.toString().substring(3, 5)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    else if (date1.toString().substring(6, 10) > date2.toString().substring(6, 10)) {
        return true;
    }
    else {
        return false;
    }
}
function convertToDate(sender) {
    var DateParts = sender.val().split("-");
    var ReturnValue = new Date(DateParts[2], getMonthInteger(DateParts[1]), DateParts[0]);

    return ReturnValue;
}
