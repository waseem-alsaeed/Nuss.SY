var Error = ["Please Write Title", "Please Write Content"]

function AddSlider() {
    try {
        var ID = GetValue('ID');
        var Title = GetValue('Title');
        var Content = GetValue('Content');
        var Image = $('#image1').attr('src');

        if (IsEmpty('Title')) {
            ErrorNotification(Error[0]);
        }
        else if (IsEmpty('Content')) {
            ErrorNotification(Error[0]);
        }
        else {
            var JsonData = {
                ID: ID,
                Title: Title,
                Image: Image,
                Content: Content
            };

            testHoldon('sk-circle');
            ExecuteSlider(JsonData, 'CPanel', 'ExecuteSlider');

        }
        return false;
    }
    catch (err) {
        ErrorNotification(err.message);
    }
}



function DeleteSlider(_id) {
    Delete(_id, 'CPanel', 'DeleteSlider');
    return false;
}

//--------------------------------------------------//
// Execute Add , Update 
//--------------------------------------------------//
function ExecuteSlider(obj, controller, action) {
    var actionURL = '/' + controller + '/' + action;
    $.ajax({
        url: actionURL,
        type: 'POST',
        dataType: 'json',
        traditional: true,
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.State == true) {
                SuccessNotification();
                setTimeout(
                function () {
                    location.href = '/CPanel/Sliders'
                }, 4000);
            }
            else {
                ErrorNotification(data.ErrorMessage + 'Error : happend in row = ' + data.RowID);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            ErrorNotification(xhr.status + ' ' + thrownError);
        }
    });
}



function testHoldon(themeName) {
    HoldOn.open({
        theme: themeName,
        message: "<h3>" + " Please wait ...</h4>"
    });

    setTimeout(function () {
        HoldOn.close();
    }, 2000);
}