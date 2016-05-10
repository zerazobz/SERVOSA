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
            var vehicleId = $buttonContext.data("vehiclecode");

            $.post("/VehicleData/DatosVariableVehiculo", { vehicleCode: vehicleId, variableName: tableName }, function (dataResult) {

            }).complete(function (e) {

            }).fail(function (e) {

            });
        });
    });

})(window.SERVOSA = window.SERVOSA || {}, jQuery);