//Codigo entero del que use en el trabajo
$(function () {
    $("#AjaxForm").submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: "/Home/Login", // Url
            data: {
                user: $("#user").val(), // Parámetros
                password: $("#password").val(),
                // ...
            },
            type: "post",  // Verbo HTTP
            beforeSend: function () {
                $("#AjaxForm").css('display', 'none');
                $("#proceso").css('display', 'block');
            }
        })
            // Se ejecuta si todo fue bien.
            .done(function (result) {
                if (result != null) {
                }
                else {
                }
            })
            // Hacer algo siempre, haya sido exitosa o no.
            .done(function (data) {
                if (data.param1 == '200') {
                    window.location.replace('/Home/Index');
                }
                else {
                    $("#error").css("display", "block");
                    $("#error").html(data.param2);
                    $("#proceso").css('display', 'none');
                    $("#AjaxForm").css('display', 'block');
                    $('#password').val('');
                    $("#password").focus();
                }
            });
    });
});