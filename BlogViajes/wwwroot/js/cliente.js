var dataTable;

$(document).ready(function () {
    cargarDataCliente();
});

function cargarDataCliente() {
    dataTable = $("#tblCliente").DataTable({
        "ajax": {
            "url": "/AdminUser/Cliente/ObtenerTodosLosClientes",
            "type": "GET",
            "dataSrc": "data"
        },
        "rowId": false,
        "destroy": true, 
        "columns": [
            { "data": "nombre", "width": "50%" },
            { "data": "apellido", "width": "50%" },
            { "data": "usuario", "width": "50%" },
            { "data": "telefono", "width": "20%" },
            { "data": "email", "width": "50%" },
           
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    })
};
