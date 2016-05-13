(function (SERVOSANamespace, $, undefined) {
    var arrayEvents = [];

    SERVOSANamespace.addEvent = function (newEvent) {
        arrayEvents.push(newEvent);
    };

    SERVOSANamespace.registerEvents = function () {
        $.each(arrayEvents, function (i, element) {
            element();
        });
    };

    SERVOSANamespace.cleanEvents = function () {
        arrayEvents = [];
    };

    SERVOSANamespace.CreateSubmitForm = function (idSubmitForm) {
        var url = $(idSubmitForm).attr('url');
        $.post(url, $(idSubmitForm).serialize(), function (data) {
            console.log('Post message receivedf');
            $(idSubmitForm).empty();
            $(idSubmitForm).html(data);
            SERVOSANamespace.registerEvents();
        }).fail(function () {
            console.debug('Fail in post call');

        }).complete(function () {
            console.debug('Complete post call');
        });
    };

    $(function () {
        function ProccessAlertMessage(htmlTemplate, message, $divContainer) {
            var handleTemplate = Handlebars.compile(htmlTemplate);
            var data = { message: message };
            var htmlGenerated = handleTemplate(data);
            $divContainer.html(htmlGenerated);
            $divContainer.fadeIn(450, function () { $divContainer.fadeOut(450, function () { $divContainer.fadeIn(450, function () { }) }) });
        }

        $.fn.extend({
            SERVOSAErrorNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationError.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            },
            SERVOSAWarningNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationWarning.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            },
            SERVOSAInfoNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationInfo.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            },
            SERVOSASuccessNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationSuccess.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            }
        });

        $(document).on("click", ".createUpdateData", null, function () {
            var $buttonContext = $(this);
            var tableName = $buttonContext.data("tablename");
            var vehicleId = $buttonContext.data("vehicleid");

            $.get("/VehicleData/DatosVariableVehiculo", { vehicleCode: vehicleId, variableName: tableName }, function (dataResult) {
                $("#createUpdateTableDataModal").modal('show');
                $("#createUpdateTableDataModal").find(".modal-body").html(dataResult);
            }).complete(function (e) {
                console.log("Se termino de procesar la carga de Datos de Variable de Vehiculo.");
            }).fail(function (e) {
                console.log("Ocurrio un error al intentar cargar los datos del vehiculo");
                console.debug(e);
            });
        });

        $(document).on("submit", "#postVariableData", null, function (e) {
            e.preventDefault();
            var $modalContext = $(this);
            console.log("Manejando el submit");
            //console.log(JSON.stringify($modalContext.serialize()));

            $.ajax({
                url: $modalContext.data("posturl"),
                data: $modalContext.serialize(),
                traditional: true,
                type: 'POST',
                success: function (dataResult) {
                    $("#createUpdateTableDataModal").find(".modal-body").html(dataResult);
                    var isSuccessful = $("#createUpdateTableDataModal .modal-body").find("[name='IsSuccessful']").val();
                    var message = $("#createUpdateTableDataModal .modal-body").find("[name='Message']").val();
                    if (isSuccessful.toLowerCase() == "true") {
                        $("#createUpdateTableDataModal .modal-body").find(".messagePanel").SERVOSASuccessNotification(message);
                        $("[name='submitDatosVariables']").prop("disabled", true);
                    }
                    else {
                        $("#createUpdateTableDataModal .modal-body").find(".messagePanel").SERVOSAErrorNotification(message);
                    }
                    console.log("Se termino de procesar el reemplazo de la vista.");
                },
                error: function () {
                    console.log("Ocurrio un error al intentar Crear/Actualizar la informacion de la tabla.");
                    console.debug(e);
                }
            });

            //$.post($modalContext.data("posturl"), { model: decodeURI($modalContext.serialize()) }, function (dataResult) {
            //    $("#createUpdateTableDataModal").find(".modal-body").html(dataResult);
            //    console.log("Se termino de procesar el reemplazo de la vista.");
            //}).complete(function () {
            //    console.log("Se completado la acci'on de Crear/Actualizar la informacion de la tabla.");
            //}).fail(function (e) {
            //    console.log("Ocurrio un error al intentar Crear/Actualizar la informacion de la tabla.");
            //    console.debug(e);
            //});

        });
    });

})(window.SERVOSA = window.SERVOSA || {}, jQuery);