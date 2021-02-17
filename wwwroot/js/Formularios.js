
var dataTable;

$(document).ready(function () {
    cargarDatatableFormularios();
});
function cargarDatatableFormularios() {
    dataTable = $('#table').DataTable({
        "processing": false,
        "serverSide": false,
        "searching": true,
        "paging": true,
        "ajax": {
            "url": "/Home/GetFormularios",
            "type": "POST",
            "contentType": "application/json",
            "data": function (d) {
                return JSON.stringify(d);
            }
        },
        stateSave: true,
        "lengthMenu": [15, 20, 25, 50, 100],
        "order": [[0, "desc"]], //or asc 
        "columns": [
            {
                "data": "nombre",
                "width": "20%"
            },
            {
                "data": "primerApellido",
                "width": "20%"
            },
            {
                "data": "segundoApellido",
                "width": "20%"
            },
            {
                "data": "opinion",
                "width": "40%"
            },
        ],
        columnDefs: [

        ],
        "language": {
            "url": "/lib/datatables/languages/Spanish.json"
        },
        "oLanguage": {
            "sEmptyTable": 'No hay registros'
        },
        "width": "100%"
    });
}
