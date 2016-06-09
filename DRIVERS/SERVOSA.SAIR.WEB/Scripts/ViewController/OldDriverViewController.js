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
                CodigoVehiculo: { title: "Unidad a Cargo", options: '/Driver/GetVehiculos' },
                CodigoPuesto: { title: 'Puesto', options: { 0: 'Auxiliar', 1: 'Conductor' } }
            }
        });
        $(document).on("click", "#modal-file #modal-submit-ok", null, function () {
            var fileName = $('[name="excelFile"]').val().trim();
            var pos = fileName.lastIndexOf('.');
            var extension = (pos <= 0) ? '' : fileName.substring(pos);
            if (extension != '.xlsx') {
                alert('Please browse a correct excel file to upload');
                return;
            }
            $('form').submit();
        }
        );
      
        $("#btnBuscar").click(function () {
            driverNamespace.CargarTablaDrivers();
        });
    });
    driverNamespace.CargarTablaDrivers();

})(window.driverNamespace = window.driverNamespace || {}, jQuery);