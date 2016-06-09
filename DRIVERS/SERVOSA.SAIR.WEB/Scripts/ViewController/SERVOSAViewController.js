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

    SERVOSANamespace.LoadShowModal = function (parameters, getUrl, modalId, onSuccessCallback) {

        $.get(getUrl, parameters, function (htmlResult) {
            $(modalId).modal('show');
            $(modalId).find('.modal-content').html(htmlResult);
            onSuccessCallback();
        }).complete(function (e) {
            console.debug("Se termino de procesar la carga del Modal con ID: " + modalId);
        }).fail(function (e) {
            console.debug("Ocurrio un error al intentar cargar el Modal con ID: " + modalId);
            console.debug(e);
        });

    }

    SERVOSANamespace.PostFormModal = function (parameters, postUrl, containerId, onSuccessCallback, onErrorCallback) {
        $.post(postUrl, parameters, function (htmlResult, textStatus, jqXHR) {
            $(containerId).find(".modal-content").html(htmlResult);
            var isSuccessful = $(containerId + " .modal-body").find("[name='IsSuccessful']").val();
            var message = $(containerId + " .modal-body").find("[name='Message']").val();
            if (isSuccessful.toLowerCase() == "true") {
                $(containerId + " .modal-body").find(".messagePanel").SERVOSASuccessNotification(message);
                onSuccessCallback();
            }
            else {
                $(containerId + " .modal-body").find(".messagePanel").SERVOSAErrorNotification(message);
                onErrorCallback();
            }
        }).complete(function (e) {
            console.debug("Se completo el procesamiento post del Modal con Id: " + containerId);
        }).fail(function (e) {
            onErrorCallback();
            console.debug("Ocurrio un error al postear datos del Modal con Id: " + containerId);
            console.debug(e);
        });
    }

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
            var parametersForModal = { driverCode: $buttonContext.data("driverid"), variableName: tableName };
            var modalId = "#createUpdateTableDataModal";

            SERVOSANamespace.LoadShowModal(parametersForModal, "/DriverData/DatosVariableVehiculo", modalId, function () {
                $(modalId).find(".modal-content input[name='submitDatosVariables']").prop("tablename", tableName);
            });
        });

        $("#containerforalltables").on("click", ".insertRemoveFile", null, function () {
            var $buttonContext = $(this);
            var tableToLoad = $buttonContext.data("tablename");
            var driverId = $buttonContext.data("driverid");
            var modalParameters = { tableName: tableToLoad, driverCode: driverId };
            var modalId = "#createRemoveFilesForTableDataModal";

            SERVOSANamespace.LoadShowModal(modalParameters, "/DriverData/GetFileModalManager", modalId, function () {

                var containerFileTableToLoad = "#" + $(modalId).find(".innerfilestable div").attr("id");
                console.log("El contenedor de archivos a cargar es: " + containerFileTableToLoad);
                window.DriverDataViewController.SetupJtableContainer(containerFileTableToLoad, tableToLoad, driverId);
                window.DriverDataViewController.LoadJTableContainer(containerFileTableToLoad);
            });
        });

        $(document).on("submit", "#postVariableData", null, function (e) {
            e.preventDefault();
            var $formContext = $(this);
            var containerId = $(this).parent().data("containerid");

            SERVOSANamespace.PostFormModal($formContext.serialize(), $formContext.data("posturl"), containerId, function () {
                $("[name='submitDatosVariables']").prop("disabled", true);
                var currentTableName = $formContext.find("input[name='submitDatosVariables']").prop('tablename');
                var $tableContext = $("table[data-tablename='" + currentTableName + "']");
                window.DriverNamespace.LoadTableData($tableContext, currentTableName);
            }, function () {

            });
        });
    });

})(window.SERVOSA = window.SERVOSA || {}, jQuery);