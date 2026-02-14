var dataTable;

$(document).ready(function () {
    cargarDataCarrito();
});

function cargarDataCarrito() {
    dataTable = $("#tblCompra").DataTable({
        "ajax": {
            "url": "/AdminUser/Compra/ObtenerCompras",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "fechaCompra", "width": "15%" },
            { "data": "total", "width": "15%" },
            { "data": "cantidadPaquetes", "width": "15%" },
            { "data": "detalles",
                "render": function (data) {
                    if (!data || data.length == 0) {
                        return 'Sin detalles'
                    } else {
                        return data.map(d => {
                           return `Paquete: ${d.paquete}-Cantidad:${d.cantidad}-$${d.precio}`
                        }).join("<br>");
                    }
                }
            , "width": "40%" },
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


