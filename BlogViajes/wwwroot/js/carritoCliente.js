var dataTable;

$(document).ready(function () {
    cargarDataCarritoCliente();
});

function cargarDataCarritoCliente() {
    dataTable = $("#tblAgregarAlCarrito").DataTable({
        "ajax": {
            "url": "/RegularUser/Carrito/ObtenerCarrito",
            "type": "GET",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "nombre", "width": "15%" },
            {
                "data": "precio",
                "render": function (data) {
                    return '$' + data;
                }
                , "width": "5%"
            },
            {
                "data": "cantidad",
                //"render": function (data, type, row) {
                //    return `<input type="number" min="1" value="${data}" class="form-control d-inline w-50 cantidad-input" data-id="${row.id}" />
                //        <button class="btn btn-sm btn-info actualizarCantidad" data-id="${row.id}">Actualizar</button>
                //   `;
                //},
                "width": "10"
            },
            {
                "data": "total",
                "render": function (data) {
                    return '$' + data;
                },
                "width": "15%"
            },
              
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

//$(document).on('click', '.actualizarCantidad', function () {
//    const $btn = $(this);
//    const id = $btn.data('id');
//    const cantidad = $btn.siblings('.cantidad-input').val();

//    $.post('/RegularUser/Carrito/ActualizarCantidad', {
//        id: id,
//        cantidad: cantidad
//    })
//        .done(function (response) {
//            if (response.success) {
//                const fila = $btn.closest('tr');
//                const precioTexto = fila.find('td:eq(1)').text().replace('$', '');
//                const precio = parseFloat(precioTexto);

//                const nuevoTotal = (cantidad * precio).toFixed(2);
//                fila.find('td:eq(3)').text('$' + nuevoTotal);

//                toastr.success('Cantidad actualizada.');
//            } else {
//                toastr.error('Error al actualizar.');
//            }
//        });
//});


