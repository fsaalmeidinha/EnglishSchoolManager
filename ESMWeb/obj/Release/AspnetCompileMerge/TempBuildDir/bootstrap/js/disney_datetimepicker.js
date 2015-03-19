var dateTimeFormat = 'd/m/Y';

$(document).ready(function () {
    ativarDateTimePickers();
});

function ativarDateTimePickers() {
    $('.datetimepicker').datetimepicker({
        lang: 'pt-BR',
        datepicker: true,
        timepicker: false,
        /*theme:'dark',*/
        format: dateTimeFormat
    });
}