(function($){
    $.fn.validationEngineLanguage = function(){
    };
    $.validationEngineLanguage = {
        newLang: function(){
            $.validationEngineLanguage.allRules = {
                "required": { // Add your regex rules here, you can take telephone as an example
                    "regex": "none",
                    "alertText": "* " + veFieldRequired,
                    "alertTextCheckboxMultiple": "* " + veSelectOption,
                    "alertTextCheckboxe": "* " + veChkRequired,
                    "alertTextDateRange": "* " + veDateRangeRequired
                },
                "allrequired": {    			// Add your regex rules here, you can take telephone as an example
                    "regex": "none",
                    "alertText": "* " + veFieldRequired,
                    "alertTextCheckboxMultiple": "* " + veSelectOption,
                    "alertTextCheckboxe": "* " + veChkRequired
                },
                "requiredInFunction": { 
                    "func": function(field, rules, i, options){
                        return (field.val() == "test") ? true : false;
                    },
                    "alertText": "* " + veFieldEqualTest
                },
                "dateRange": {
                    "regex": "none",
                    "alertText": "* " + veInvalid,
                    "alertText2": veDateRange
                },
                "dateTimeRange": {
                    "regex": "none",
                    "alertText": "* " + veInvalid,
                    "alertText2": veDateTimeRange
                },
                "minSize": {
                    "regex": "none",
                    "alertText": "* " + veMinimum,
                    "alertText2": " " + veCharsRequired
                },
                "maxSize": {
                    "regex": "none",
                    "alertText": "* " + veMaximum,
                    "alertText2": " " + veCharsAllowed
                },
		        "groupRequired": {
                    "regex": "none",
                    "alertText": "* " + veFillOneFields,
                    "alertTextCheckboxMultiple": "* " + veSelectOption,
                    "alertTextCheckboxe": "* " + veChkRequired
                },
                "min": {
                    "regex": "none",
                    "alertText": "* " + veMimimumValue + " "
                },
                "max": {
                    "regex": "none",
                    "alertText": "* " + veMaximumValue + " "
                },
                "past": {
                    "regex": "none",
                    "alertText": "* " + veDatePrior + " "
                },
                "future": {
                    "regex": "none",
                    "alertText": "* " + veDatePast + " "
                },	
                "maxCheckbox": {
                    "regex": "none",
                    "alertText": "* " + veMaximum + " ",
                    "alertText2": " " + veOptionsAllowed
                },
                "minCheckbox": {
                    "regex": "none",
                    "alertText": "* " + veSelectSelect + " ",
                    "alertText2": " " + veOptions
                },
                "equals": {
                    "regex": "none",
                    "alertText": "* " + veFieldsDontMatch
                },
                "creditCard": {
                    "regex": "none",
                    "alertText": "* " + veInvalidCCard
                },
                "phone": {
                    // credit: jquery.h5validate.js / orefalo
                    "regex": /^([\+][0-9]{1,3}([ \.\-])?)?([\(][0-9]{1,6}[\)])?([0-9 \.\-]{1,32})(([A-Za-z \:]{1,11})?[0-9]{1,4}?)$/,
                    "alertText": "* " + veInvalidPhone
                },
                "mobile": {
                    // credit: jquery.h5validate.js / orefalo
                    "regex": /^([\+][0-9]{1,3}([ \.\-])?)?([\(][0-9]{1,6}[\)])?([0-9 \.\-]{1,32})(([A-Za-z \:]{1,11})?[0-9]{1,4}?)$/,
                    "alertText": "* " + veInvalidMobile
                },
                "fax": {
                    // credit: jquery.h5validate.js / orefalo
                    "regex": /[\+? *[1-9]+]?[0-9 ]+/,
                    "alertText": "* " + veInvalidFax
                },
                "email": {
                    // HTML5 compatible email regex ( http://www.whatwg.org/specs/web-apps/current-work/multipage/states-of-the-type-attribute.html#    e-mail-state-%28type=email%29 )
                    "regex": /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                    "alertText": "* " + veInvalidEmail
                },
                "fullname": {
                    "regex":/^([a-zA-Z]+[\'\,\.\-]?[a-zA-Z ]*)+[ ]([a-zA-Z]+[\'\,\.\-]?[a-zA-Z ]+)+$/,
                    "alertText": "* " + veMustBeFirst
                },
                "zip": {
                    "regex":/^\d{5}$|^\d{5}-\d{4}$/,
                    "alertText": "* " + veInvalidZip
                },
                "integer": {
                    "regex": /^[\-\+]?\d+$/,
                    "alertText": "* " + veNotValidInteger
                },
                "number": {
                    // Number, including positive, negative, and floating decimal. credit: orefalo
                    "regex": /^[\-\+]?((([0-9]{1,3})([,][0-9]{3})*)|([0-9]+))?([\.]([0-9]+))?$/,
                    "alertText": "* " + veInvalidDecimal
                },
                "date": {                    
                    //	Check if date is valid by leap year
			"func": function (field) {
					var pattern = new RegExp(/^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/);
					var match = pattern.exec(field.val());
					if (match == null)
					   return false;
	
					var year = match[1];
					var month = match[2]*1;
					var day = match[3]*1;					
					var date = new Date(year, month - 1, day); // because months starts from 0.
	
					return (date.getFullYear() == year && date.getMonth() == (month - 1) && date.getDate() == day);
				},                		
			"alertText": "* " + veDateFormat + " YYYY-MM-DD " + veDateFormat2
                },
                "ipv4": {
                    "regex": /^((([01]?[0-9]{1,2})|(2[0-4][0-9])|(25[0-5]))[.]){3}(([0-1]?[0-9]{1,2})|(2[0-4][0-9])|(25[0-5]))$/,
                    "alertText": "* " + veInvalidIP
                },
                "url": {
                    "regex": /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i,
                    "alertText": "* " + veInvalidURL
                },
                "onlyNumberSp": {
                    "regex": /^[0-9\ ]+$/,
                    "alertText": "* " + veNumbersOnly
                },
                "onlyLetterSp": {
                    "regex": /^[a-zA-Z\ \ ']+$/,
                    "alertText": "* " + veLettersOnly
                },
                "onlyLetterandothers": {
                    "regex": /^[a-zA-Z\ \U+00D1\U+00F1\*\u00C0-\u017F\ ']+$/,
                    "alertText": "* " + veLettersOnly
                },
                "onlyLetterNumberandothers": {
                    "regex": /^[0-9a-zA-Z\ \'\-\U+00D1\U+00F1\*\u00C0-\u017F\ ']+$/,
                    "alertText": "* " + veNoSpecialCharsAllowed
                },
				"onlyLetterAccentSp":{
                    "regex": /^[a-z\u00C0-\u017F\ ]+$/i,
                    "alertText": "* " + veLettersOnly
                },
                "onlyLetterNumber": {
                    "regex": /^[0-9a-zA-Z]+$/,
                    "alertText": "* " + veNoSpecialCharsAllowed
                },
                // --- CUSTOM RULES -- Those are specific to the demos, they can be removed or changed to your likings
                "ajaxUserCall": {
                    "url": "ajaxValidateFieldUser",
                    // you may want to pass extra data on the ajax call
                    "extraData": "name=eric",
                    "alertText": "* " + veUserTaken,
                    "alertTextLoad": "* " + veValidatingWait
                },
				"ajaxUserCallPhp": {
                    "url": "phpajax/ajaxValidateFieldUser.php",
                    // you may want to pass extra data on the ajax call
                    "extraData": "name=eric",
                    // if you provide an "alertTextOk", it will show as a green prompt when the field validates
                    "alertTextOk": "* " + veUsernameAvailable,
                    "alertText": "* " + veUserTaken,
                    "alertTextLoad": "* " + veValidatingWait
                },
                "ajaxNameCall": {
                    // remote json service location
                    "url": "ajaxValidateFieldName",
                    // error
                    "alertText": "* " + veNameTaken,
                    // if you provide an "alertTextOk", it will show as a green prompt when the field validates
                    "alertTextOk": "* " + veNameAvailable,
                    // speaks by itself
                    "alertTextLoad": "* " + veValidatingWait
                },
				 "ajaxNameCallPhp": {
	                    // remote json service location
	                    "url": "phpajax/ajaxValidateFieldName.php",
	                    // error
	                    "alertText": "* " + veNameTaken,
	                    // speaks by itself
	                    "alertTextLoad": "* " + veValidatingWait
	                },
                "validate2fields": {
                    "alertText": "* Please input HELLO"
                },
	            //tls warning:homegrown not fielded 
                "dateFormat":{
                    "regex": /^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])$|^(?:(?:(?:0?[13578]|1[02])(\/|-)31)|(?:(?:0?[1,3-9]|1[0-2])(\/|-)(?:29|30)))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:0?[1-9]|1[0-2])(\/|-)(?:0?[1-9]|1\d|2[0-8]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(0?2(\/|-)29)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$/,
                    "alertText": "* " + veInvalidDate
                },
                //tls warning:homegrown not fielded 
				"dateTimeFormat": {
	                "regex": /^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])\s+(1[012]|0?[1-9]){1}:(0?[1-5]|[0-6][0-9]){1}:(0?[0-6]|[0-6][0-9]){1}\s+(am|pm|AM|PM){1}$|^(?:(?:(?:0?[13578]|1[02])(\/|-)31)|(?:(?:0?[1,3-9]|1[0-2])(\/|-)(?:29|30)))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^((1[012]|0?[1-9]){1}\/(0?[1-9]|[12][0-9]|3[01]){1}\/\d{2,4}\s+(1[012]|0?[1-9]){1}:(0?[1-5]|[0-6][0-9]){1}:(0?[0-6]|[0-6][0-9]){1}\s+(am|pm|AM|PM){1})$/,
	                "alertText": "* " + veInvalidDateOrFormat,
	                "alertText2": veExpectedFormat + ": ",
	                "alertText3": "mm/dd/yyyy hh:mm:ss AM|PM " + veOR + " ", 
                    "alertText4": "yyyy-mm-dd hh:mm:ss AM|PM"
	            }
            };
            
        }
    };

    $.validationEngineLanguage.newLang();
    
})(jQuery);
