(function (vehicleNamespace, $, undefined) {

    vehicleNamespace.LoadVehicleTable = function () {
        $("#vehicleTable").jtable('load');
    };

    vehicleNamespace.LoadTableHeadDetails = function (nameTable) {

    };

    vehicleNamespace.LoadTableData = function (containerContext, tableName) {
        $.post("/Vehicle/LoadTablaData", {
            tableName: tableName
        }, function (dataResult) {
            var $container = $(containerContext);
            var resultHtml = [];
            $.each(dataResult, function (i, element) {

                //var $row = $("<td>");
                var columnList = "<tr>";

                for (i = 0; i < element.Values.Count; i++) {
                    var column = $("<td>").attr("data-vehiclecode", element.vehiclecode).attr("data-tablename", element.tablename).text(element.Values[i]).prop("outerHTML");
                    columnList += column;
                }
                columnList += "</tr>"
                
                resultHtml.push(columnList);
            });

        }).fail(function () {
            console.debug("No se pudo cargar los datos de la tabla: " + $(containerContext).attr("tableName"));
        }).complete(function () {
            console.debug("Culmino el procesamiento de la tabla: " + $(containerContext).attr("tableName"));
        });
    };

    vehicleNamespace.LoadDataForTablesYetLoaded = function () {
        var allTables = $(".containerdatatable>table");
        $.each(allTables, function (i, element) {
            var $tableName = $(element).data('tablename');
            vehicleNamespace.LoadTableData(element, $tableName);
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

        $(document).on("click", ".addNewColumnToVariable", null, function (e) {
            var $currentButton = $(this);
            var normalizedTableName = $currentButton.data('normalizedtablename');
            var tableName = $currentButton.data('tablename');

            $.get("/VariableTasks/CreateColumn", function (dataResult) {
                $("#createColumnModal").modal("show");
                $("#createColumnModal .modal-content").empty();
                $("#createColumnModal .modal-content").append(dataResult);
                $("#createColumnModal .modal-content").find("input[name='TableName']").val(tableName);
                $("#createColumnModal .modal-content").find("input[name='TableNormalizedName']").val(normalizedTableName);
            });
        });

        $(document).on("click", "#createColumnSubmit", null, function (e) {
            var resultValidation = $("#createColumnForm").validationEngine('validate');
            if (resultValidation == true) {
                $.post("/VariableTasks/CreateColumn", $("#createColumnForm").serialize(), function (dataResult) {
                    $("#createColumnModal .modal-content").empty();
                    $("#createColumnModal .modal-content").html(dataResult);
                    var isSuccessfull = $("#createColumnForm ").find("input[name='IsSuccessful']").val();
                    var message = $("#createColumnForm ").find("input[name='Message']").val();

                    if (isSuccessfull.toLowerCase() == "true") {
                        $("#createColumnModal").find(".messagePanel").SERVOSASuccessNotification(message);
                        $("#createColumnSubmit").prop("disabled", true);
                        
                        var tableName = $("#createColumnModal").find("input[name='TableNormalizedName']").val();
                        var columnName = $("#createColumnModal").find("input[name='ColumnName']").val();
                        var columnNormalizedName = $("#createColumnModal ").find("input[name='ColumnNormalizedName']").val();

                        var $currentTable = $("table[data-tablename = '" + tableName + "']");
                        $currentTable.find("thead tr:eq(1)").append("<th>" + columnNormalizedName + "</th>");
                        $currentTable.find("tr:gt(1)").append("<td></td>");
                        var oldColSpan = parseInt($currentTable.find("thead tr:first-child th").attr("colspan"));
                        $currentTable.find("thead tr:first-child th").attr("colspan", oldColSpan + 1);
                        //$.get("/templates/vehicletabletemplate.html", function (data) {

                        //    var handletemplate = Handlebars.compile($(data).html());
                        //    var data = {
                        //        tableName: tableName,
                        //        normalizedTableName: normalizedTableName
                        //    };
                        //    var htmlgenerated = handletemplate(data);
                        //    $("#containerforalltables").append(htmlgenerated);
                        //});
                    }
                    else {
                        $("#createColumnModal ").find(".messagePanel").SERVOSAErrorNotification(message);
                    }
                }).fail(function (e) {
                    console.info('Error en la consulta Ajax Post');
                }).complete(function (e) {
                    console.info('Finalizo el Ajax Post');
                });
            }
            else {
                $("#createColumnModal .modal-body").find(".messagepanel").SERVOSAErrorNotification("Por favor ingrese/seleccione los campos requeridos.");
            }
        });

        vehicleNamespace.LoadVehicleTable();
        vehicleNamespace.LoadDataForTablesYetLoaded();
    });

})(window.VehicleNamespace = window.VehicleNamespace || {}, jQuery);