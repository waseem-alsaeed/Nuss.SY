var Error = ["Please Write Title", "Please Enter Content", "Please Choose Department"]

function AddNews() {
    try {
        var ID = GetValue('ID');
        var Title = GetValue('Title');
        var Content = GetValue('Content');
        var VideoUrl = GetValue('VideoUrl');
        var Image = $('#image1').attr('src');
        var DID = $('#Department').val();
        var clickCheckbox = document.querySelector('.js-switch');
        var IsMain = clickCheckbox.checked;
        if (IsMain == true) {
            IsMain = 1;
        }
        else { IsMain = 0; }

        if (IsEmpty('Title')) {
            ErrorNotification(Error[0]);
        }
        else if (IsEmpty('Content')) {
            ErrorNotification(Error[1]);
        }
        else if (DID == 0) {
            ErrorNotification(Error[2]);
        }
        else {
            var JsonData = {
                ID: ID,
                Title: Title,
                Content: Content,
                VideoUrl: VideoUrl,
                Image: Image,
                DID: DID,
                IsMain: IsMain
            };

            testHoldon('sk-circle');
            ExecuteNews(JsonData, 'CPanel', 'ExecuteNews');

        }
        return false;
    }
    catch (err) {
        ErrorNotification(err.message);
    }
}



function DeleteNews(_id) {
    Delete(_id, 'CPanel', 'DeleteNews');
    return false;
}

//--------------------------------------------------//
// Execute Add , Update 
//--------------------------------------------------//
function ExecuteNews(obj, controller, action) {
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
                    location.href = '/CPanel/News'
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