(function (operationNamespace, $, undefined) {


    $("#operationsTable").jtable({
        title: 'Operaciones',
        actions: {
            listAction: '/Operations/ListOperations',
            createAction: '/Operations/CreateOperation'
        },
        fields: {
            OperationId: { key: true, list: false },
            OperationName: { title: 'Operacion' },
            DataBaseName: { title: 'Base de Datos', list: false, create: false },
            UserName: {
                title: 'Usuario',
                create: false
            },
            Cambiar: {
                title: 'Ver Operación',
                create: false,
                display: function (data) {
                    return '<a href="#" class="changeOperation" data-operationid=' + data.record.OperationId + ' data-databasename=' + data.record.DataBaseName + ' data-operationname="' + data.record.OperationName + '" > <span class="glyphicon glyphicon-log-in"></span> </a>';
                }
            },
            CambiarNombreOperacion: {
                title: 'Cambiar Nombre',
                create: false,
                display: function (data) {
                    return '<a href="#" class="changeOperationName" data-operationid=' + data.record.OperationId + ' data-databasename=' + data.record.DataBaseName + ' data-operationname="' + data.record.OperationName + '" > <span class="glyphicon glyphicon-edit"></span> </a>';
                }
            },
            EliminarOperacion: {
                title: 'Eliminar Operación',
                create: false,
                display: function (data) {
                    return '<a href="#" class="removeOperation" data-operationid=' + data.record.OperationId + ' data-databasename=' + data.record.DataBaseName + ' > <span class="glyphicon glyphicon-trash"></span> </a>';
                }
            }
        }
    });

    $("#operationsTable").jtable('load');

    $("#operationsContainer").off("click", ".changeOperation").on("click", ".changeOperation", null, function (e) {
        var $linkContext = $(this);
        var dataBaseName = $linkContext.data("databasename");
        var operationId = $linkContext.data("operationid");
        if (typeof dataBaseName !== "undefined" && dataBaseName !== "") {
            window.location = "/Operations/LoadOperation?operationName=" + dataBaseName + "&operationId=" + operationId;
        }
    });

    $("#operationsContainer").off("click", ".removeOperation").on("click", ".removeOperation", null, function (e) {
        var $linkContext = $(this);
        var dataBaseName = $linkContext.data("databasename");
        var operationId = $linkContext.data("operationid");
        var confirmationResult = confirm("Al eliminar la operación, desapareceran todos los datos existentes dentro de la operación.");
        if (confirmationResult == true) {
            if (typeof dataBaseName !== "undefined" && dataBaseName !== "") {
                $.post("/Operations/DeleteOperation", { operationId: operationId, databaseName: dataBaseName }, function (dataResult) {
                    if (dataResult.Result == "OK") {
                        var $closestTr = $linkContext.closest("tr");
                        console.debug("Closest TR: " + $closestTr);
                        $closestTr.remove();
                        $("#messagePanel").SERVOSASuccessNotification("Se elimino correctamente la operación.");
                    }
                    else {
                        $("#messagePanel").SERVOSAErrorNotification("No se pudo eliminar la operación.");
                    }
                });
            }
        }
    });

    $("#operationsContainer").off("click", ".changeOperationName").on("click", ".changeOperationName", null, function (e) {
        var $linkContext = $(this);
        var dataBaseName = $linkContext.data("operationname");
        var operationId = $linkContext.data("operationid");
        if (typeof dataBaseName !== "undefined" && dataBaseName !== "") {
            $("#newOperationName").val("");
            $("#changeOperationNameModal").modal('show');
            $("#changeOperationNameModal").find("[id='changeOperationNameButton']").data("operationId", operationId);
            $("#changeOperationNameModal").find("input[id='currentOperationName']").val(dataBaseName);
        }
    });
    $("#changeOperationNameButton").click(function (e) {
        //e.preventDefault();
        var operationId = $(this).data("operationId");
        var newOperationName = $("#newOperationName").val();
        $.post("/Operations/ChangeOperationName", { operationId: operationId, newOperationName: newOperationName },
            function (data, textStatus, jqXHR) {
                console.debug("El resultado de la ejecución es: " + data.Result);
                if (data.Result == "OK") {
                    $("#messagePanel").SERVOSASuccessNotification("Se cambio correctamente el nombre de la operación.");
                    $("#operationsTable").jtable('reload');
                }
                else {
                    $("#messagePanel").SERVOSAErrorNotification("No se pudo cambiar el nombre de la operación.");
                }
            }).fail(function (e) {
                $("#messagePanel").SERVOSAWarningNotification("No se pudo conectar con el servidor.");
            }).complete(function () {
                $("#changeOperationNameModal").modal('hide');
            });
    });

})(window.OperationsVC = window.OperationsVC || {}, jQuery);