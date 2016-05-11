(function (driverNamespace, $, undefined) {
    var driversTable = "#tabledataDrivers";
    driverNamespace.CargarTablaDrivers = function () {
        $(driversTable).jtable('load');
    };

    $(function () {
        $(driversTable).jtable({
            title: 'Operarios',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/Driver/ListDrivers',
                deleteAction: '/Driver/DeleteDriver',
                updateAction: '/Driver/UpdateDriver',
                createAction: '/Driver/CreateDriver'
            },
            fields: {
                CodigoOperario: { key: true, title: 'Codigo', create: false, edit: false },
                ApellidoPaternoOperario: { title: 'Apellido Paterno' },
                ApellidoMaternoOperario: { title: 'Apellido Materno' },
                NombreOperario: { title: 'Nombre' },
                CodigoVehiculo: { title: "Unidad a Cargo", options: '/Vehicle/GetVehiculos' },
                CodigoPuesto: { title: 'Puesto', options: { 0: 'Auxiliar', 1: 'Conductor' } }
            }
        });
        $("#btnBuscar").click(function () {
            driverNamespace.CargarTablaDrivers();
        });
    });
    driverNamespace.CargarTablaDrivers();

})(window.driverNamespace = window.driverNamespace || {}, jQuery);