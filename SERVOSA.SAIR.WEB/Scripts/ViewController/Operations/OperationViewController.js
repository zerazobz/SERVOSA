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
            DataBaseName: { title: 'Base de Datos', create: false },
            Usuario: {
                title: 'Usuario',
                create: false,
                display: function (data) {
                    return '<p> ' + data.record.DataBaseName + '_user</p>'
                }
            },
            Cambiar: {
                title: 'Ver Operación',
                create: false,
                display: function (data) {
                    return '<a href="#" class="changeOperation" data-operationid=' + data.record.OperationId + ' data-databasename=' + data.record.DataBaseName + ' > <span class="glyphicon glyphicon-log-in"></span> </a>';
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

})(window.OperationsVC = window.OperationsVC || {}, jQuery);