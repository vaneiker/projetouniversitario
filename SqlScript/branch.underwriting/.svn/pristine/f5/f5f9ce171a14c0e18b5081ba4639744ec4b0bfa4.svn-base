/*
    Library Name: JSDateTools
    Author: Ing. Jose Mejia
    Version: 1.0
*/

// Extension method to Convert a 'String' to a 'Valid Date Object', based on a provided format
String.prototype.ToDate = function (pFormat) {
    return GetValidDate(this, pFormat);
};

// Extension method that validate if a 'String' is a valid date, based on a provided format
String.prototype.IsDate = function (pFormat) {
    return IsDate(this, pFormat);

};

// Extension method that validate if a Year of a Date is a 'Leap Year'
String.prototype.IsLeap = function (pFormat) {
    return IsLeapYear(this, true, pFormat);
};

// Extension method that return the Days interval between two dates
String.prototype.DayDiff = function (pFormat) {
    return DateDiff(this, '', true, pFormat, 'd');
};

String.prototype.DayDiff = function (pDateDiff, pFormat) {
    return DateDiff(this, pDateDiff, true, pFormat, 'd');
};

// Extension method that return the Months interval between two dates
String.prototype.MonthDiff = function (pFormat) {
    return DateDiff(this, '', true, pFormat, 'm');
};

String.prototype.MonthDiff = function (pDateDiff, pFormat) {
    return DateDiff(this, pDateDiff, true, pFormat, 'm');
};

// Extension method that return the Years interval between two dates
String.prototype.YearDiff = function (pFormat) {
    return DateDiff(this, '', true, pFormat, 'y');
};

String.prototype.YearDiff = function (pDateDiff, pFormat) {
    return DateDiff(this, pDateDiff, true, pFormat, 'y');
};

// Extension method to Convert a 'Date Object' to a 'Formatted String', based on a provided format
Date.prototype.ToFormatedString = function (pFormat) {
    return FormatDate(this, pFormat);
};

// Extension method that validate if a Year of a Date is a 'Leap Year'
Date.prototype.IsLeap = function () {
    return IsLeapYear(this, false);
};

// Extension method that return the Days interval between two dates
Date.prototype.DayDiff = function () {
    return DateDiff(this, '', false, '', 'd');
};

Date.prototype.DayDiff = function (pDateDiff) {
    return DateDiff(this, pDateDiff, false, '', 'd');
};

// Extension method that return the Months interval between two dates
Date.prototype.MonthDiff = function () {
    return DateDiff(this, '', false, '', 'm');
};

Date.prototype.MonthDiff = function (pDateDiff) {
    return DateDiff(this, pDateDiff, false, '', 'm');
};

// Extension method that return the Years interval between two dates
Date.prototype.YearDiff = function () {
    return DateDiff(this, '', false, '', 'y');
};

Date.prototype.YearDiff = function (pDateDiff) {
    return DateDiff(this, pDateDiff, false, '', 'y');
};

// Validate that a date is valid based on a provided 'Date Format'
// Returns 'False' when is not a valid date
function IsDate(pDate, pFormat) {

    // Declare Date Parts
    var dateParts = GetDateParts(pDate, pFormat);

    if (dateParts === false)
        return false;

    // Get Date parts
    var dtDay = dateParts['Day'];
    var dtMonth = dateParts['Month'];
    var dtYear = dateParts['Year'];

    //Year Validation 
    if (!$.isNumeric(dtYear))
        return false;

    //Month Validation 
    if (!$.isNumeric(dtMonth))
        return false;

    //Days Validation 
    if (!$.isNumeric(dtDay))
        return false;

    // Year Length validation
    if (dtYear.length != 4 && dtYear.length != 2)
        return false;

    // Month Length validation
    if (dtMonth.length < 1 || dtMonth.length > 2)
        return false;

    // Days Length validation
    if (dtDay.length < 1 || dtDay.length > 2)
        return false;

    // Month validation
    if (dtMonth < 1 || dtMonth > 12)
        return false;

        // Days validation	 
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        // Leap-year day validation
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }

    return true;
}

// Returns a valid 'Date' object based in a provided 'Date Format'
function GetValidDate(pDate, pFormat) {
    // Declare new date
    var resultDate = new Date();

    // Declare Date Parts
    var dateParts = GetDateParts(pDate, pFormat);

    // Get Date parts
    var dtDay = dateParts['Day'];
    var dtMonth = dateParts['Month'] - 1; // Months are Zero based
    var dtYear = dateParts['Year'];

    resultDate = new Date(dtYear, dtMonth, dtDay);

    return resultDate;
}

// Get interval between two dates
// Returns 'False' when is not a valid date
function DateDiff(pFirstDate, pSecondDate, isString, pFormat, pDatePart) {

    if (typeof pSecondDate === "undefined" || pSecondDate == '')
        pSecondDate = (new Date().getMonth() + 1) + '/' + new Date().getDate() + '/' + new Date().getFullYear();

    if (isString === true) {
        // Validate Format parameter was provided
        if (typeof pFormat === "undefined")
            return false;

        //FirstDate validation
        if (!IsDate(pFirstDate, pFormat))
            return false;

        pFirstDate = GetValidDate(pFirstDate, pFormat);

        //SecondDate validation
        if (!IsDate(pSecondDate, pFormat))
            return false;

        pSecondDate = GetValidDate(pSecondDate, pFormat);
    }

    var result = 0;

    var diff = Math.floor(pSecondDate.getTime() - pFirstDate.getTime());
    var Days = Math.floor(diff / (1000 * 60 * 60 * 24));
    var Months = Math.floor(Days / 12);
    var Years = Math.floor(Days / 365.25);

    // Years
    if (pDatePart.toLowerCase().indexOf('y') > -1) {
        if (pSecondDate.getFullYear() != pFirstDate.getFullYear())
            if (pSecondDate.getDate() == pFirstDate.getDate())
                if (pSecondDate.getMonth() == pFirstDate.getMonth())
                    Years += 1;

        result = Years;
    }
        // Months
    else if (pDatePart.toLowerCase().indexOf('m') > -1)
        result = Months;
        // Days
    else if (pDatePart.toLowerCase().indexOf('d') > -1)
        result = Days;
        // Wrong Datepart
    else
        return false;

    return result;
}

// Returns a String representation of a date based in the format provided
// Actually it only support the formats below
// ['dd/mm/yyyy', 'dd/mm/yy', 'dd.mm.yyyy', 'dd.mm.yy', 'dd-mm-yyyy', 'dd-mm-yy', 'd/m/yyyy', 'd/m/yy', 'd.m.yyyy', 'd.m.yy', 'd-m-yyyy', 'd-m-yy' ]
// ['mm/dd/yyyy', 'mm/dd/yy', 'mm.dd.yyyy', 'mm.dd.yy', 'mm-dd-yyyy', 'mm-dd-yy', 'm/d/yyyy', 'm/d/yy', 'm.d.yyyy', 'm.d.yy', 'm-d-yyyy', 'm-d-yy' ]
function FormatDate(pDate, pFormat) {
    var resultDate = '';

    // Get date parts
    var pDay = pDate.getDate().toString();
    var pMonth = (pDate.getMonth() + 1).toString();
    var pYear = pDate.getFullYear().toString();

    // Two Digits date parts
    var pTDDay = pDay.length === 1 ? '0' + pDay : pDay; F
    var pTDMonth = pMonth.length === 1 ? '0' + pMonth : pMonth;
    var pTDYear = pYear.substring(2, 4);

    // Get Format parts
    var rxFormatPattern = ['-', '/', '\\\.'];
    var formatArray = pFormat.split(new RegExp(rxFormatPattern.join('|'), 'g'));

    if (formatArray.length < 3) {
        alert('The provided date format is not supported.');
        return false;
    }

    for (i = 0; i < formatArray.length; i++) {
        resultDate += (formatArray[i].length > 3 ? pYear : (formatArray[i].length > 1 ? (formatArray[i].indexOf('mm') < 0 ? (formatArray[i].indexOf('dd') < 0 ? pTDYear : pTDDay) : pTDMonth) : (formatArray[i].indexOf('m') < 0 ? (formatArray[i].indexOf('d') < 0 ? pYear : pDay) : pMonth)));

        if ((formatArray.length - 1) != i) {
            resultDate += (pFormat.indexOf('.') < 0 ? (pFormat.indexOf('-') < 0 ? '/' : '-') : '.')
        }
    }

    return resultDate;
}

// Get the Date parts of a String based on the format
function GetDateParts(pDate, pFormat) {
    var dateParts = new Array();

    // Get Date parts
    var rxDatePattern = ['-', '/', '\\\.'];
    var dateArray = pDate.split(new RegExp(rxDatePattern.join('|'), 'g'));

    // Get Format parts
    var formatArray = pFormat.split(new RegExp(rxDatePattern.join('|'), 'g'));

    if (dateArray == null || dateArray.length < 3 || formatArray.length < 3)
        return false;

    // Get Date parts based on the format
    dateParts['Day'] = formatArray[0].length > 1 ? (formatArray[0].toLowerCase().indexOf('dd') < 0 ? dateArray[1] : dateArray[0]) : (formatArray[0].toLowerCase().indexOf('d') < 0 ? dateArray[1] : dateArray[0]);
    dateParts['Month'] = formatArray[0].length > 1 ? (formatArray[0].toLowerCase().indexOf('mm') < 0 ? dateArray[1] : dateArray[0]) : (formatArray[0].toLowerCase().indexOf('m') < 0 ? dateArray[1] : dateArray[0]);
    dateParts['Year'] = dateArray[2];

    return dateParts;
}

// Validate if a year is a 'Leap Year'
function IsLeapYear(pDate, isString, pFormat) {
    var validDate;

    // If pDate is a String then convert it to a Date
    if (isString) {
        if (IsDate(pDate, pFormat))
            validDate = pDate.ToDate(pFormat);
        else
            return 'Invalid provided date'
    }
    else
        validDate = pDate;

    // Get Year of the provided date
    var dtYear = validDate.getFullYear();

    // Calculate Leap Year
    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));

    return isleap;
}




