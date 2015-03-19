$(document).ready(function () {
    aplicarMascaras();
});

function aplicarMascaras() {
    $('.decimal-mask').inputmask("decimal", { allowMinus: false, digits: 2, radixPoint: "," });
    $('.integer-mask').inputmask("integer", { allowMinus: false });
    $('.date-mask').inputmask("d/m/y", { "placeholder": "dd/mm/yyyy" });
}