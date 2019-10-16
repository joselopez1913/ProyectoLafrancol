$(document).ready(function () {
    leerProveedores();
});
function leerProveedores(){
    $.ajax({
        type: "GET",
        url: "/api/ApiProveedor/leerProveedores",
        data: JSON.stringify(),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var tr;
            $.each(data, function (i, v) {
                tr = $('<tr/>');
                tr.append("<td>" + v.idProveedor + "</td>");
                tr.append("<td>" + v.nit + "</td>");
                tr.append("<td>" + v.razonSocial + "</td>");
                tr.append("<td>" + v.direccion + "</td>");
                $('#tablaProveedores').append(tr);  

            });
           

        }

    });
}