var desativarValidacao = false;

jQuery(document).ready(function () {
    if (desativarValidacao == false) {
        tratarObrigatoriedadeCampos(false);
        jQuery('#main').bootstrapValidator();
    }
});

function validar(exibirAlerta) {
    return validarSpecific(exibirAlerta, '#main');
}

function validarSpecific(exibirAlerta, divToValidate) {
    jQuery(divToValidate).data('bootstrapValidator').validate();
    if (jQuery(divToValidate).data('bootstrapValidator').isValid()) {
        return true;
    } else {
        if (exibirAlerta) {
            bootbox.alert("Existem campos não preenchidos na tela de cadastro");
        }
        return false;
    }
}

function tratarObrigatoriedadeCampos(useDestroy) {
    return tratarObrigatoriedadeCamposSpecific(useDestroy, '#main');
}

function tratarObrigatoriedadeCamposSpecific(useDestroy, divToValidate) {
    jQuery('.notEmptyField').attr('data-bv-notempty', 'true');
    jQuery('.notEmptyField').each(function (ind, campoObrigatorio) {
        if (jQuery(campoObrigatorio).attr('data-bv-notempty-message') == undefined)
            jQuery(campoObrigatorio).attr('data-bv-notempty-message', msgCampoObrigatorio);
    });

    jQuery('.emptyField').removeAttr('data-bv-notempty');
    jQuery('.emptyField').removeAttr('data-bv-notempty-message');

    if (useDestroy && jQuery(divToValidate).data('bootstrapValidator') != undefined) {
        jQuery(divToValidate).data('bootstrapValidator').destroy();
        jQuery(divToValidate).bootstrapValidator();
    }
}