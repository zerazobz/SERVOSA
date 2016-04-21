(function (vehicleNamespace, $, undefined) {

    vehicleNamespace.LoadVehicleTable = function () {
        $("#vehicleTable").jtable('load');
    };

    vehicleNamespace.LoadTableHeadDetails = function (nameTable) {

    };

    vehicleNamespace.LoadDataForTablesYetLoaded = function () {
        var allTables = $(".containerdatatable>table");
        $.each(allTables, function (i, element) {
            var $tableName = $(element).data('tablename');

            console.debug('Cargando datos de la tabla: ' + $tableName);
        });
    };

    $(function () {
        $("#vehicleTable").jtable({
            title: 'Listado de Vehiculos',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/Vehicle/ListVehicles',
                deleteAction: '/Vehicle/DeleteVehicle',
                updateAction: '/Vehicle/UpdateVehicle',
                createAction: '/Vehicle/CreateVehicle'
            },
            fields: {
                Item: { title: 'Item', create: false, edit: false },
                Codigo: { key: true, title: 'Codigo' },
                PlacaTracto: { title: 'PlacaTracto' },
                PlacaTolva: { title: 'PlacaTolva' },
                CodigoMarca: { title: 'CodigoMarca', options: { 0: 'Toyota', 1: 'Hyundai', 2 : 'Mercedes Benz' } },
                CodigoEstado: { title: 'CodigoEstado', options: { 0: 'Observado', 1: 'Revisar', 2: 'Conforme' } }
            }
        });

        $("#containerforalltables").on('load', ".containerdatatable>table", null, function (eventObject) {
            var tableName = $(this).data('tablename');
            console.debug('La tabla cargada es: ' + tableName);
            console.debug('Cargando columnas y datos');
        });

        $(".containerdatatable>table").load(function () {
            var tableName = $(this).data('tablename');
            console.debug('La tabla cargada es: ' + tableName);
            console.debug('Cargando columnas y datos');
        });

        $(document).on("click", "#createVariableSubmit", null, function (e) {
            //e.preventDefault();
            var resultValidation = $("#createTableForm").validationEngine('validate');
            if (resultValidation == true) {
                $.post("/VariableTasks/CreateTable", $("#createTableForm").serialize(), function (data) {
                    $("#createTableModal .modal-content").empty();
                    $("#createTableModal .modal-content").html(data);
                    var isSuccessfull = $("#createTableModal .modal-body").find("input[name='IsSuccessful']").val();
                    var message = $("#createTableModal .modal-body").find("input[name='Message']").val();

                    if (isSuccessfull.toLowerCase() == "true") {
                        $("#createTableModal .modal-body").find(".mesagepanel").SERVOSASuccessNotification(message);
                        $("#createVariableSubmit").prop("disabled", true);
                        
                        var tableName = $("#createTableModal .modal-body").find("input[name='TableName']").val()
                        var normalizedTableName = $("#createTableModal .modal-body").find("input[name='TableNormalizedName']").val()

                        //var currentDate = new Date();
                        //var tableName = $.datepicker.formatDate("yymmdd@", currentDate);

                        $.get("/templates/vehicletabletemplate.html", function (data) {

                            var handletemplate = Handlebars.compile($(data).html());
                            var data = {
                                tableName: tableName,
                                normalizedTableName: normalizedTableName
                            };
                            var htmlgenerated = handletemplate(data);
                            $("#containerforalltables").append(htmlgenerated);
                        });
                    }
                    else
                        $("#createTableModal .modal-body").find(".mesagepanel").SERVOSAErrorNotification(message);

                }).fail(function () {
                    console.info('Error en la consulta Ajax Post');
                }).complete(function () {
                    console.info('Finalizo el Ajax Post');
                });
            }
            else {
                $("#createTableModal .modal-body").find(".mesagepanel").SERVOSAErrorNotification("Por favor llene los campos requeridos");
            }
        });

        $("#createTableModal").on("hidden.bs.modal", function (e) {
            $("#createTableModal .modal-content").load("/VariableTasks/CreateTable");
        });

        $("#addNewTable").click(function () {
            
        });

        vehicleNamespace.LoadVehicleTable();
        vehicleNamespace.LoadDataForTablesYetLoaded();
    });

})(window.VehicleNamespace = window.VehicleNamespace || {}, jQuery);