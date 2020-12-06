var Error = ["Please Write Department Name"]

function AddDepartment() {
    try {
        var DID = GetValue('DID');
        var Name = GetValue('Name');
        var Image = $('#image1').attr('src');
        var clickCheckbox = document.querySelector('.js-switch');
        var IsMain = clickCheckbox.checked;
        if (IsMain == true) {
            IsMain = 1;
        }
        else { IsMain = 0; }

        if (IsEmpty('Name')) {
            ErrorNotification(Error[0]);
        }
        else {
            var JsonData = {
                DID: DID,
                Name: Name,
                Image: Image,
                IsMain: IsMain,
                CssName: IsMain == true ? 'studio' : 'landscape'
            };

            testHoldon('sk-circle');
            ExecuteDepartment(JsonData, 'CPanel', 'ExecuteDepartment');

        }
        return false;
    }
    catch (err) {
        ErrorNotification(err.message);
    }
}



function DeleteDepartment(_id) {
    Delete(_id, 'CPanel', 'DeleteDepartment');
    return false;
}

//--------------------------------------------------//
// Execute Add , Update 
//--------------------------------------------------//
function ExecuteDepartment(obj, controller, action) {
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
                    location.href = '/CPanel/Departments'
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