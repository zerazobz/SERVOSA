(function (driverDataService, $, undefined) {

    driverDataService.SetupJtableContainer = function (jtableContainerId, tableName, driverId) {
        $(jtableContainerId).jtable({
            title: 'Listado de Vehiculos',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/DriverData/ListFilesByTableAndDriver?tableName=' + tableName + "&driverCode=" + driverId,
                deleteAction: '/DriverData/DeleteFile'
            },
            fields: {
                ComposedPrimaryKey: { key: 'true', list: false },
                Identity: { title: 'Identity', list: false },
                DriverId: { title: 'DriverId', list: false },
                TableName: { title: 'Nombre de Tabla', list: true },
                //DataFile: { title: 'DataFile', list: false },
                FileName: { title: 'Nombre de Archivo', list: true },
                //FileContentType: { title: 'FileContentType', list: true },
                //FileLocationStored: { title: 'FileLocationStored', list: true },
                DateCreated: { title: 'DateCreated', type : 'date', displayFormat: 'dd/mm/yy', list: false }
            }
        });
    };

    driverDataService.LoadJTableContainer = function (jtableContainerId) {
        $(jtableContainerId).jtable('load');
    }

    $(function () {
        var allTabTables = $("div[class='tab-pane']").map(function (i, el) { return $(el).attr("id"); });
        var driverId = $("[name='CurrentDriverId']").val();
        $.each(allTabTables, function (i, element) {
            console.debug("El elemento es: " + element);
            var tableToLoad = element;
            var elementToLoad = "#" + element;

            $.get("/DriverData/DatosVariableVehiculo?driverCode=" + driverId + "&variableName=" + tableToLoad, function (htmlResult) {
                console.log("La tabla a revisar es: " + elementToLoad);
                $(elementToLoad).find(".innercontenttab").empty();
                $(elementToLoad).find(".innercontenttab").html(htmlResult);
            }).fail(function() {
                console.debug("No se pudo cargar la data");
            });

            var containerFileTableToLoad = "#" + $(elementToLoad).find(".innerfilestable div").attr("id");
            console.log("El contenedor de archivos a cargar es: " + containerFileTableToLoad);
            driverDataService.SetupJtableContainer(containerFileTableToLoad, tableToLoad, driverId);
            driverDataService.LoadJTableContainer(containerFileTableToLoad);
        });
    });

})(window.DriverDataViewController = window.DriverDataViewController || {}, jQuery);