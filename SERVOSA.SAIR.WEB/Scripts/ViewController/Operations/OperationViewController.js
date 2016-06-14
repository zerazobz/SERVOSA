(function (operationNamespace, $, undefined) {


    $("#operationsTable").jtable({
        title: 'Operaciones',
        actions: {
            listAction: '/Operations/ListOperations',
            createAction: '/Operations/CreateOperation'
        },
        fields: {
            OperationId: { key: true },
            OperationName: { title: 'Operacion' }
        }
    });

    $("#operationsTable").jtable('load');

})(window.OperationsVC = window.OperationsVC || {}, jQuery);