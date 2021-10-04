
$(function () {

    initHijrDatePicker();

    initHijrDatePickerDefault();

    $('.disable-date').hijriDatePicker({

        //minDate: "1950-01-01",
        //maxDate: "2041-01-01",
        viewMode: "years",
        hijri: false,
        debug: true
    });

});

function initHijrDatePicker() {

    $(".hijri-date-input").hijriDatePicker({
        locale: "ar-sa",
        format: "MM-DD-YYYY",
        hijriFormat: "iYYYY-iMM-iDD",
        dayViewHeaderFormat: "MMMM YYYY",
        hijriDayViewHeaderFormat: "iMMMM iYYYY",
        showSwitcher: true,
        allowInputToggle: true,
        showTodayButton: false,
        useCurrent: true,
        isRTL: false,
        viewMode: 'months',
        keepOpen: false,
        hijri: false,
        debug: true,
        showClear: true,
        showTodayButton: true,
        showClose: true
    });
}

function initHijrDatePickerDefault() {

    $(".hijri-date-default").hijriDatePicker();
}
function alert(msg) {
    swal({
        title: msg,
        icon: "success",
        button: "إغلاق",
    });
}
function warningAlert(msg) {
    swal({
        title: msg,
        icon: "warning",
        button: "إغلاق",
    });
}
function confirmAlert(msg, func, id) {
    debugger;
    swal({
        title: "هل انت متأكد؟",
        text: msg,
        icon: "warning",
        buttons: [ "لا", "نعم"],
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                func(id);
            } else {

            }
        });
}

function isNumber(evt) {
    debugger;
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

$(document).ready(function () {
    $('.summernote').summernote({
        height: 170,
        tabsize: 2
    });
});