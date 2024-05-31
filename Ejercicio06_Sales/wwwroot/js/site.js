// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    // ****** Crear y definir propiedades de tabla '.tabla-indice' ********
    
    $('.tabla-indice').DataTable({
        ordering:false,
        search: {
            return: false
        },
        language: {
            lengthMenu: 'Mostrar _MENU_ entradas por página',
            emptyTable: 'No hay datos disponibles',
            info: 'Mostrando _START_ a _END_ de _TOTAL_ entradas',
            infoEmpty: 'Mostrando 0 a 0 de 0 entradas',
            infoFiltered: '(filtradas de _MAX_ entradas totales)',
            search: '',
            searchPlaceholder: 'Filtrar entradas por...',
            zeroRecords: 'No se encontraron entradas coincidentes.',
        },
        layout: {
            topStart: 'search',
            topEnd: 'pageLength',
            bottomStart: {
                paging: {
                    type: 'full_numbers'
                }
            },
            bottomEnd: 'info',
        },
        colReorder: true,
    });
});