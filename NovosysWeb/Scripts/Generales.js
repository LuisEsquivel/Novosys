


/*variables*/
var CorreoEnviado = "¡Correo Enviado!";
var CorreoNoEnviado = "¡Correo No Enviado!";




function Add(url) {

    var form = document.getElementById("form");
    add(url, form);

}



var add = async function (url, form,) {


    form.onsubmit = async (e) => {
        e.preventDefault();

        let response = await fetch(url, {
            method: 'POST',
            processData: false,
            contentType: false,
            body: new FormData(form)
        });

        let result = await response.json();


        if (result.message == "Correo Enviado") {
            swal(CorreoEnviado, "", "success");
            LimpiarFormulario();

        }
        if (result.message == "Problema al enviar correo") {
            swal(CorreoNoEnviado, "¡Algo salió mal... Intentalo nuevamente! ", "error");

        }



    }

}


function LimpiarFormulario() {
    $("#form").trigger('reset');
}



jQuery(document).ready(function () {
    jQuery('.soloNumeros').keypress(function (tecla) {
        if (tecla.charCode < 48 || tecla.charCode > 57) return false;
    });
});
