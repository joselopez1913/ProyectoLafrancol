$('#btnGuardarProveedor').on('click', function (e) {
    e.preventDefault();
    var url = '/api/ApiProveedor/guardarProveedor';
    var method = 'post';
   
    var proveedor = {};
    
    $.each($(this).closest('form').serializeArray(), function () {
        if (this.name !== 'Id' || (this.name === 'Id' && this.value !== '')) {
            proveedor[this.name] = this.value || '';
        }
    });
    proveedor.estado = true;
    $.ajax({
        type: method,
        url: url,
        data: JSON.stringify(proveedor),
        contentType: 'application/json'
    }).done(function () {
        notificar();
     
    });
});

function notificar() {
    alertify.success("El proveedor fue guardado exitosamente.");
}
