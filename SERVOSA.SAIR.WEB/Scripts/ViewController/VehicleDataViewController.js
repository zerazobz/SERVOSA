(function (vehicleDataService, $, undefined) {

    vehicleDataService.SetupJtableContainer = function (jtableContainerId, tableName, vehicleId) {
        $(jtableContainerId).jtable({
            title: 'Listado de Vehiculos',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/VehicleData/ListFilesByTableAndVehicle?tableName=' + tableName + "&vehicleCode=" + vehicleId,
                createAction: '/VehicleData/DeleteFile'
            },
            fields: {
                ComposedPrimaryKey: { key: 'true'},
                Identity: { title: 'Identity', list: false },
                VehicleId: { title: 'VehicleId', list: false },
                TableName: { title: 'TableName', list: true },
                //DataFile: { title: 'DataFile', list: false },
                FileName: { title: 'FileName', list: true },
                FileContentType: { title: 'FileContentType', list: true },
                //FileLocationStored: { title: 'FileLocationStored', list: true },
                DateCreated: { title: 'DateCreated', type : 'date', displayFormat: 'dd/mm/yy', list: true }
            }
        });
    };

    vehicleDataService.LoadJTableContainer = function (jtableContainerId) {
        $(jtableContainerId).jtable('load');
    }

    $(function () {
        var allTabTables = $("div[class='tab-pane']").map(function (i, el) { return $(el).attr("id"); });
        var vehicleId = $("[name='CurrentVehicleId']").val();
        $.each(allTabTables, function (i, element) {
            console.debug("El elemento es: " + element);
            var tableToLoad = element;
            var elementToLoad = "#" + element;

            $.get("/VehicleData/DatosVariableVehiculo?vehicleCode=" + vehicleId + "&variableName=" + tableToLoad, function (htmlResult) {
                console.log("La tabla a revisar es: " + elementToLoad);
                $(elementToLoad).find(".innercontenttab").empty();
                $(elementToLoad).find(".innercontenttab").html(htmlResult);
            }).fail(function() {
                console.debug("No se pudo cargar la data");
            });

            var containerFileTableToLoad = "#" + $(elementToLoad).find(".innerfilestable div").attr("id");
            console.log("El contenedor de archivos a cargar es: " + containerFileTableToLoad);
            vehicleDataService.SetupJtableContainer(containerFileTableToLoad, tableToLoad, vehicleId);
            vehicleDataService.LoadJTableContainer(containerFileTableToLoad);
        });
    });

})(window.VehicleDataViewController = window.VehicleDataViewController || {}, jQuery);