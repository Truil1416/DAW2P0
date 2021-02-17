function desloguear() {
    Swal.fire({
        title: "¿Esta seguro de que desea desloguear?",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonText: "SI",
    }).then(function (result) {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Home/LogOut/",
                dataType: "json",
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.mensaje);
                        setTimeout(function () {
                            window.location.href = "/Home/Login";
                        }, 1000);
                    }
                    else {
                        toastr.error("No se ha podido cerrar sesión", data.mensaje);
                    }
                },
                error: function (data) {
                    toastr.error('Ha ocurrido un error raro');
                }
            });
        }
    })
}