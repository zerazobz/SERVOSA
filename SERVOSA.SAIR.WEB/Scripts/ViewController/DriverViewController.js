(function (driverNamespace, $, undefined) {

    var driversTable = "#tabledataDrivers";
  
    driverNamespace.CargarTablaDrivers = function () {
        $(driversTable).jtable('load', {
          
        });
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
                CodigoOperario: {key: true, title: 'Codigo',list:false },
                ApellidoPaternoOperario: { title: 'Apellido Paterno' },
                ApellidoMaternoOperario: { title: 'Apellido Materno' },
                NombreOperario: { title: 'Nombre' },
                CodigoVehiculo:{title:"CodigoVehiculo",list:false},
                DescripcionVehiculo: { title: 'Unidad a Cargo' },
                PuestoVehiculo: { title: 'Puesto' }
            }
        });
        $("#btnBuscar").click(function () {
            driverNamespace.CargarTablaDrivers();
        });
    });


})(window.driverNamespace = window.driverNamespace || {}, jQuery);