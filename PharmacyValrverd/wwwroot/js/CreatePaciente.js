
$(document).ready(function () {

    $("#Provincias").change(function () {

        $("#Cantones").empty();
        $("#Cantones").attr("disabled", false);

        $.getJSON('/Paciente/ObtenerCantones', { provincia: $('#Provincias').val() },
            function (data) {

                $.each(data, function () {
                    $("#Cantones").append('<option value=' + this.CodigoCanton + '>' + this.NombreCanton + '</option>');
                });
            });
    });

    $("#Cantones").change(function () {

        $("#Distritos").empty();
        $("#Distritos").attr("disabled", false);
        $.getJSON('/Paciente/ObtenerDistritos', { canton: $('#Cantones').val() },
            function (data) {

                $.each(data, function () {
                    $("#Distritos").append('<option value=' + this.CodigoDistrito + '>' + this.NombreDistrito + '</option>');
                });
            });
    });

});



