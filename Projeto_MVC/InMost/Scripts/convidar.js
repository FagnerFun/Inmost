$(document).ready(function () {

    $("#FormConvidar").validate({
        rules: {
            email: { required: true, minlength: 6 , maxlength : 254},
          
        },

        messages: {

            email: { required: "Digite um e-mail a ser convidado", minlength: "E-mail não valido, verifique", maxlength :"E-mail maior que o normal, verifique" },
            

        }
    });
});