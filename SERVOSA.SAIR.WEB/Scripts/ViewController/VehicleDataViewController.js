(function (vehicelDataService, $, undefined) {

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
        });
    });

})(window.VehicleDataViewController = window.VehicleDataViewController || {}, jQuery);