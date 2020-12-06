// Just for Remembering
// Events are : click - dblclick 
// mouseenter : The function is executed when the mouse pointer enters the HTML element
// mouseleave : The function is executed when the mouse pointer leaves the HTML element
// mousedown : The function is executed, when the left mouse button is pressed down, while the mouse is over the HTML element
// mouseup : The function is executed, when the left mouse button is released, while the mouse is over the HTML element
// keydown - keypress - focus - focusout
// blur : The function is executed when the form field loses focus
// Hover : take two function as parameters : func1 : execute when mouse above element , func2 : when mouse leave
// ===================================================================================================================//

                                            // ###########################################################//
                                                // Designed By Eng : Mohammad Khir Alsaid - Syria
                                            // ###########################################################//

// ###########################Build Html Markup ########################//

// 1 - Build Dynamic Html 
// my little html string builder
BuildHTML = function (tag, html, attrs) {
    // you can skip html param
    if (typeof (html) != 'string') {
        attrs = html;
        html = null;
    }
    var h = '<' + tag;
    for (attr in attrs) {
        if (attrs[attr] === false) continue;
        h += ' ' + attr + '="' + attrs[attr] + '"';
    }
    return h += html ? ">" + html + "</" + tag + ">" : "/>";
}

// buildHTML("a", "Marc Grabanski", { id: "mylink", href: "https://google.com"});
// outputs: <a id="mylink" href="https://google.com">Marc Grabanski</a>

// or leave out the html
// buildHTML("input", {id: "myinput", type: "text", value: "myvalue"});
// outputs: <input id="myinput" type="text" value="myvalue" />
// ########################### End Html Markup ########################//



//--------------------------------------------------//
// Call click Event for Element
//--------------------------------------------------//
function CallClick(ID)
{
    $('#' + ID).trigger('click');
}

//--------------------------------------------------//
// Make input Focusable
//--------------------------------------------------//
function Focus(ID) {
    $('#' + ID).focus();
}


//--------------------------------------------------//
// Return true if checkbox is checked
//--------------------------------------------------//
function IsChecked(ID) {
    var chk = $("#" + ID);
    var res = chk.is(":checked");
    return res;
}


//--------------------------------------------------//
// Set new Image 
//--------------------------------------------------//
function SetImage(ID, _src) {
   $("#" + ID).attr('src', _src);
}

//--------------------------------------------------//
// Get src Image 
//--------------------------------------------------//
function GetImage(ID) {
    return $("#" + ID).attr('src'); 
}

//--------------------------------------------------//
// Submit form 
//--------------------------------------------------//
function SubmitForm(FormName) {
    $('#' + FormName).submit();
}


// Check if input is empty or not
function IsEmpty(ID)
{
    var _value = $("#" + ID).val();
    if (_value.length > 0)
        return false;
    else return true;
}



//--------------------------------------------------//
// Fade out element in jquery
//--------------------------------------------------//
function FadeOut(ID, IsSlow) {
    if (!IsSlow)
        $('#' + ID).css("opacity", 0.3).delay(300).fadeOut();
    else
        $('#' + ID).css("opacity", 0.3).delay(300).fadeOut("slow");
}


//--------------------------------------------------//
// Fade in element in jquery
//--------------------------------------------------//
function FadeIn(ID, IsSlow) {
    if (!IsSlow)
        $('#' + ID).css("opacity", 0.3).delay(300).fadeIn();
    else
        $('#' + ID).css("opacity", 0.3).delay(300).fadeIn("slow");
}


//--------------------------------------------------//
// Fade toggle in element in jquery
//--------------------------------------------------//
function FadeToggle(ID, IsSlow) {
    if (!IsSlow)
        $('#' + ID).css("opacity", 0.3).delay(300).fadeToggle();
    else
        $('#' + ID).css("opacity", 0.3).delay(300).fadeToggle("slow");
}


//--------------------------------------------------//
// Show element in jquery
//--------------------------------------------------//
function Show(ID) {
    $('#' + ID).show();
}

//--------------------------------------------------//
// Hide element in jquery
//--------------------------------------------------//
function Hide(ID) {
    $('#' + ID).hide();
}

//--------------------------------------------------//
// Slide element Down
//--------------------------------------------------//
function SlideDown(ID) {
    $('#' + ID).slideDown();
}

//--------------------------------------------------//
// Slide element up
//--------------------------------------------------//
function SlideUp(ID) {
    $('#' + ID).slideUp();
}

//--------------------------------------------------//
// Slide element Toggle
//--------------------------------------------------//
function SlideToggle(ID) {
    $('#' + ID).slideToggle();
}


//--------------------------------------------------//
// Remove element 
//--------------------------------------------------//
function Remove(ID) {
    $('#' + ID).remove();
}

//--------------------------------------------------//
// Clear content for element 
//--------------------------------------------------//
function Clear(ID) {
    $('#' + ID).empty();
}


//--------------------------------------------------//
// Get Value for Element
//--------------------------------------------------//
function GetValue(ID) {
      return  $('#' + ID).val();
}

//--------------------------------------------------//
// Get Text for Element
//--------------------------------------------------//
function GetText(ID) {
    return $('#' + ID).text();
}

//--------------------------------------------------//
// Get Html for Element
//--------------------------------------------------//
function GetHtml(ID) {
    return $('#' + ID).html();
}


//--------------------------------------------------//
// Set Value for Element
//--------------------------------------------------//
function SetValue(ID, data) {
    $('#' + ID).val(data);
}

//--------------------------------------------------//
// Get Text for Element
//--------------------------------------------------//
function SetText(ID, data) {
    $('#' + ID).text(data);
}

//--------------------------------------------------//
// Get Html for Element
//--------------------------------------------------//
function SetHtml(ID, data) {
    $('#' + ID).html(data);
}


//--------------------------------------------------//
// The jQuery append() method inserts content AT THE END of the selected HTML elements
//--------------------------------------------------//
function AppendContent(ID, data) {
    $('#' + ID).append(data);
}

//--------------------------------------------------//
// The jQuery append() method inserts content AT THE begining of the selected HTML elements
//--------------------------------------------------//
function AppendContent(ID, data) {
    $('#' + ID).prepend(data);
}



//--------------------------------------------------//
// The jQuery after() method inserts content AFTER the selected HTML elements.
// The jQuery before() method inserts content BEFORE the selected HTML elements.
//--------------------------------------------------//
function InsertAfter(ID, _html) {
    $('#' + ID).after(_html);
}
function InsertBefore(ID, _html) {
    $('#' + ID).before(_html);
}
//--------------------------------------------------//


//--------------------------------------------------//
// Add class style to element
//--------------------------------------------------//
function AddClass(ID, _class) {
    $('#' + ID).addClass(_class);
}


//--------------------------------------------------//
// Remove class style to element
//--------------------------------------------------//
function RemoveClass(ID, _class) {
    $('#' + ID).removeClass(_class);
}

//--------------------------------------------------//
// Remove class style to element
//--------------------------------------------------//
function ToogleClass(ID, _class) {
    $('#' + ID).toggleClass(_class);
}


//--------------------------------------------------//
// Change Color for Row or input
//--------------------------------------------------//
function ChangeColor(ID, color) {
    $('#' + ID).css("background-color", color);
}

//--------------------------------------------------//
// Round number 2.3 = 2   && 2.6 = 3
function Round(Number) {
    return Math.round(Number);
}

//--------------------------------------------------//
// Floor number 2.3 = 2   && 2.6 = 2
function Floor(Number) {
    return Math.floor(Number);
}

//--------------------------------------------------//
// Floor number 2.3 = 3   && 2.6 = 3
function Ceil(Number) {
    return Math.ceil(Number);
}

// The indexOf() method returns the index of (the position of) the first occurrence of a specified text in a string
// mosaeed = str1 , ee = str2 ==> func will return 4 the first index for ee in str1
function IndexOf(str1, str2) {
    return str1.indexOf(str2);
}

//--------------------------------------------------//
// The lastIndexOf() method returns the index of the last occurrence of a specified text in a string
function LastIndexOf(str1, str2) {
    return str1.lastIndexOf(str2);
}

//--------------------------------------------------//
// Contain as c#
function Contain(str1, str2) {
    return str1.indexOf(str2) > -1;
}



// The lastIndexOf() method returns the index of the last occurrence of a specified text in a string
// var str = "Apple, Banana, Kiwi";
// var res = str.slice(7, 13);        ==> return Banana
function Slice(str, start, end) {
    return str.Slice(start, end);
}

// Replace string with string
function Replace(str1, str2) {
    return str1.Replace(str2);
}


// Upper string 
function Upper(str) {
    return str1.toUpperCase();
}

// Lower string
function Lower(str) {
    return str1.toLowerCase();
}


// Add two  strings
function Concat(str1, str2) {
    return str1.concat(str1, str2);
}



// Split String to array
function Split(str1, str2) {
    return str1.split(str2);
}


// Convert 2 to 2.00   - 9.656 to 9.66
function Fixed(Number) {
    return Number.toFixed(2);
}



// Convert to Int
function ToInt(str) {
    return parseInt(str);
}


// Convert to Double
function ToDouble(str) {
    return parseFloat(str);
}


// Convert to String
function ToString(Number) {
    return Number.toString();
}


// Return true if param is array
function IsArray(array) {
    return array.constructor.toString().indexOf("Array") > -1;
}



// Return true if param is array
function IsDate(_date) {
    return _date.constructor.toString().indexOf("Date") > -1;
}



/* ###################################################################################################################*/