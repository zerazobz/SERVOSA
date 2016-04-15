(function (vehicleNamespace, $, undefined) {

    vehicleNamespace.LoadVehicleTable = function () {
        $("#vehicleTable").jtable('load');
    };

    vehicleNamespace.LoadTableHeadDetails = function (nameTable) {

    };

    vehicleNamespace.LoadDataForTablesYetLoaded = function () {
        var allTables = $(".containerdatatable>table");
        $.each(allTables, function (i, element) {
            var $tableName = $(element).data('tablename');

            console.debug('Cargando datos de la tabla: ' + $tableName);
        });
    };

    $(function () {
        $("#vehicleTable").jtable({
            title: 'Listado de Vehiculos',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/Vehicle/ListVehicles',
                deleteAction: '/Vehicle/DeleteVehicle',
                updateAction: '/Vehicle/UpdateVehicle',
                createAction: '/Vehicle/CreateVehicle'
            },
            fields: {
                Item: { title: 'Item', create: false, edit: false },
                Codigo: { key: true, title: 'Codigo' },
                PlacaTracto: { title: 'PlacaTracto' },
                PlacaTolva: { title: 'PlacaTolva' },
                CodigoMarca: { title: 'CodigoMarca', options: { 0: 'Toyota', 1: 'Hyundai', 2 : 'Mercedes Benz' } },
                CodigoEstado: { title: 'CodigoEstado', options: { 0: 'Observado', 1: 'Revisar', 2: 'Conforme' } }
            }
        });

        $("#containerforalltables").on('load', ".containerdatatable>table", null, function (eventObject) {
            var tableName = $(this).data('tablename');
            console.debug('La tabla cargada es: ' + tableName);
            console.debug('Cargando columnas y datos');
        });

        $(".containerdatatable>table").load(function () {
            var tableName = $(this).data('tablename');
            console.debug('La tabla cargada es: ' + tableName);
            console.debug('Cargando columnas y datos');
        });

        $("#addNewTable").click(function () {
            var currentDate = new Date();
            var tableName = $.datepicker.formatDate("yymmdd@", currentDate);

            $.get("/Templates/VehicleTableTemplate.html", function (data) {

                var handleTemplate = Handlebars.compile($(data).html());
                var data = { tableName: tableName };
                var htmlGenerated = handleTemplate(data);
                $("#containerforalltables").append(htmlGenerated);
            });
        });

        vehicleNamespace.LoadVehicleTable();
        vehicleNamespace.LoadDataForTablesYetLoaded();
    });

})(window.VehicleNamespace = window.VehicleNamespace || {}, jQuery);