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
            }
        }
    });

    $("#operationsTable").jtable('load');

})(window.OperationsVC = window.OperationsVC || {}, jQuery);