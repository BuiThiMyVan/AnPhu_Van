/// <reference path="../jquery-1.11.0.min.js" />
/// <reference path="../toastr.js" />

var SERVER_ERROR_MESSAGE = "Đã có lỗi xảy ra trong quá trình xử lý dữ liệu";

//BUTTON BEHAVIOR
function loadButton($button) {
    let spinnerClass = 'fa-spinner';
    if (!$button.hasClass(spinnerClass)) {
        $button.addClass(spinnerClass).attr('disabled','disabled');
    }
}

function unloadButton($button){
    let spinnerClass = 'fa-spinner';
    if ($button.hasClass(spinnerClass)) {
        $button.removeClass(spinnerClass).removeAttr('disabled');
    }
}

//MESSAGE
toastr.options.closeButton  = true;
function showSuccessMessage(message, title){
    toastr.success(message,title);
}

function showErrorMessage(message,title){
    toastr.error(message,title);
}

//AJAX RESPONSE
function executeOnSuccess(data){
    var message = data.message;
    if(data.success){
        if(message!=undefined){
            showSuccessMessage(message);
        }
    }else{
        var log = data.log;
        if(message!=undefined){
            showErrorMessage(message);
        }
        if(log!=undefined)
            console.log(log);
    }
}

function executeOnFailure(error){
    showErrorMessage(SERVER_ERROR_MESSAGE);
}