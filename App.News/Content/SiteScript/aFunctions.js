/* ################################################## ADO Exec ################################################*/

//--------------------------------------------------//
// Delete row from table
//--------------------------------------------------//
function Delete(ID, controller, action) {

    swal({
        title: "Are you sure?",
        text: "You will delete this row!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes!",
        cancelButtonText: "No!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
    function (isConfirm) {
        if (isConfirm) {
            var actionURL = '/' + controller + '/' + action;
            $.ajax({
                type: "POST",
                traditional: true,
                url: actionURL,
                async: false,
                data: { ID: ID },
                dataType: "json",
                success: function (data) {
                    if (data.State == true) {
                        swal("Success!", "Row was deleted.", "success");
                        FadeOut(ID, true);
                    }
                    else {
                        swal("Error!", data.ErrorMessage, "error");
                    }
                }
            });
        }
        else {
            swal("Cancel", "Row wasn't deleted.", "error", false, "#DD6B55" , "Continue!");
        }
    });

}

//--------------------------------------------------//
// Execute Add , Update 
//--------------------------------------------------//
function Execute(obj, controller, action) {
    var actionURL = '/' + controller + '/' + action;
    $.ajax({
        url: actionURL,
        type: 'POST',
        dataType: 'json',
        traditional: true,
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.State == true)
            {
                SuccessNotification();
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


//--------------------------------------------------//
// Execute Add , Update for Parameters
//--------------------------------------------------//
function ExecuteParameters(_data, controller, action) {
    var actionURL = '/' + controller + '/' + action;
    $.ajax({
        type: "POST",
        traditional: true,
        url: actionURL,
        async: false,
        data: _data,
        dataType: "json",
        success: function (data) {
            if (data.State == true)
            {
                SuccessNotification();
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



//--------------------------------------------------//
// Execute Add , Update for JSonData  after ms time
//--------------------------------------------------//
function ExecuteJsonAfterTime(obj, controller, action, time) {
    var func = function () {
        Execute(obj, controller, action);
    }

    setTimeout(func, time);
}

//--------------------------------------------------//
// Execute Add , Update for Parameters  after ms time
//--------------------------------------------------//
function ExecutePaamsAfterTime(obj, controller, action, time) {
    var func = function () {
        ExecuteParameters(obj, controller, action);
    }

    setTimeout(func, time);
}




/* ###############################################  Reload #################################################*/

//--------------------------------------------------//
// Redirect to page afer ms time
//--------------------------------------------------//
function GoToPageAfterTime(controller, action, time) {
    window.setTimeout(function () {
        window.location.href = '/' + controller + '/' + action;
    }, time);
}

//--------------------------------------------------//
// Reload or refresh
//--------------------------------------------------//
function GoToPage(controller, action) {
    location.href = '/' + controller + '/' + action;
}




/* ############################################# Notification ############################################*/

//--------------------------------------------------//
// Error with your operation
//--------------------------------------------------//
function ErrorNotification(message) {
    $('.error').notifyMe('top', 'error', 'Error !', message, 200, 4000);
}

//--------------------------------------------------//
// Successfully inserted or updated
//--------------------------------------------------//
function SuccessNotification() {
    $('.success').notifyMe('top', 'success', 'Success ..!', 'Successfully Completed..', 200, 4000);
}

function SuccessNotificationMessage(_message) {
    $('.success').notifyMe('top', 'success', 'Success ..!', _message, 200, 4000);
}


function InfoNotification(message) {
    $('.info').notifyMe('top', 'info', 'Information !', message, 200, 4000);
}

/* #######################################################################################################*/





