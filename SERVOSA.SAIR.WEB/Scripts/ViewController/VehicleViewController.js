(function (vehicleNamespace, $, undefined) {

    vehicleNamespace.LoadVehicleTable = function () {
        $("#vehicleTable").jtable('load');
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

        vehicleNamespace.LoadVehicleTable();
    });


})(window.VehicleNamespace = window.VehicleNamespace || {}, jQuery);