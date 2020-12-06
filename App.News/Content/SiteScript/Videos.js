var Error = ["Please Write Department Name"]
var DID = 0
function AddVideo() {
    try {
        var VideoUrl = GetValue('VideoUrl');
        if (IsEmpty('VideoUrl')) {
            ErrorNotification(Error[0]);
        }
        else {
            var JsonData = {
                VID: DID,
                VideoUrl: VideoUrl
            };

            testHoldon('sk-circle');
            ExecuteVideo(JsonData, 'CPanel', 'AddVideo');

        }
        return false;
    }
    catch (err) {
        ErrorNotification(err.message);
    }
}

function ShowPanelDepartment(State) {
    if (State == 0) {
        $('#PanelDepartment').show();
        DID = 0;
        $('#department').val('');
    }
    else if (State == -1) {
        $('#PanelDepartment').hide();
        DID = 0;
        $('#department').val('');
    }
    else {
        $('#PanelDepartment').show();
        DID = State;
        $('#department').val($('#name_' + State).html());
        $('#department').focus();
    }
}

function DeleteVideo(_id) {
    Delete(_id, 'CPanel', 'DeleteVideo');
    return false;
}

//--------------------------------------------------//
// Execute Add , Update 
//--------------------------------------------------//
function ExecuteVideo(obj, controller, action) {
    var actionURL = '/' + controller + '/' + action;
    $.ajax({
        url: actionURL,
        type: 'POST',
        dataType: 'json',
        traditional: true,
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.Returned.State == true) {
                SuccessNotification();
                RefreshTable(DID, data.Model);
                ShowPanelDepartment(-1, '');
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

function RefreshTable(did, model) {

    if (did == 0) {
        $('#datTableDepartment').append(
            "<tr id='" + model.VID + "'>" +
                " <td>" + model.VID + "</td>" +
                 "<td id='name_" + model.VID + "' class='center'>" + model.VideoUrl + "</td>" +
                    " <td class='menu-action'>" +
                        "<a href='javascript::void(0)' onclick='ShowPanelDepartment(" + model.VID + ")' data-original-title='edit' data-toggle='tooltip' data-placement='top' class='btn menu-icon vd_bg-yellow'>" +
                            "<i class='fa fa-pencil'></i>" +
                        " </a>" +
                        "<a href='javascript::void(0)' onclick='DeleteVideo( " + model.VID + ")' data-original-title='delete' data-toggle='tooltip' data-placement='top' class='btn menu-icon vd_bg-red'>" +
                      "  <i class='fa fa-times'></i>" +
                     " </a>" +
                  "</td>" +
                "</tr>"
         );
    }
    else {
        $('#name_' + did).html($('#VideoUrl').val());
    }
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