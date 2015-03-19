var dateTimeFormat = 'd/m/Y';

$(document).ready(function () {
    ativarDateTimePickers();
    aplicarMascaras();
});

function ativarDateTimePickers() {
    jQuery('.datetimepicker').datetimepicker({
        lang: 'pt-BR',
        datepicker: true,
        timepicker: false,
        scrollMonth: false,
        scrollTime: false,
        scrollInput: false,
        /*theme:'dark',*/
        format: dateTimeFormat
    });
}

function aplicarMascaras() {
    //$('.decimal-mask').inputmask("decimal", { allowMinus: false, digits: 2, radixPoint: "," });
    //$('.integer-mask').inputmask("integer", { allowMinus: false });
    $('.date-mask').inputmask("d/m/y", { "placeholder": "dd/mm/yyyy" });
}