var dataTable;

$(document).ready(function () {
    cargarDataSlider();
});
function cargarDataSlider() {
    dataTable = $("#tblSlider").DataTable({
        "ajax": {
            "url": "/AdminUser/Slider/ObtenerTodosLosSliders",
            "type": "GET",
            "dataSrc": function (json) {
                console.log("Datos recibidos:", json);
                return json.data;
            }
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "20%" },
            {
                "data": "estado",
                "render": function (estadoActual) {
                    if (estadoActual == true) {
                        return "Activo"
                    } else {
                        return "Inactivo"
                    }
                }, "width": "20%"
            },
            {
                "data": "url",
                "render": function (imagen) {
                    return `<img src="/${imagen}" width="150" />`
                }, "width": "30%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/AdminUser/Slider/Edit/${data}" class="btn btn-success text-white" style="width:100px;">
                                <i class="fa-regular fa-pen-to-square"></i>
                                Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/AdminUser/Slider/Delete/${data}") class="btn btn-danger text-white" style="width:100px;">
                                <i class="fa-solid fa-trash"></i>
                                Eliminar
                                </a>
                            </div>

                    `;
                },
                "width": "30%"
            }
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
function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}
