﻿(function (vehicleNamespace, $, undefined) {

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
                var withAlert = element.WithAlert;
                var identityValue = element.DataForRow[0].Value;
                //console.log('Identity Value: ' + identityValue + '.');
                var columnList = '';
                if (identityValue == '') {
                    columnList = "<td><span class='glyphicon glyphicon-edit createUpdateData' data-vehicleid='" + element.VehicleId + "' data-tablename='" + element.TableName + "' ></span></td>";
                }
                else {
                    columnList = "<td><span class='glyphicon glyphicon-edit createUpdateData' data-vehicleid='" + element.VehicleId + "' data-tablename='" + element.TableName + "' ></span> <span class='glyphicon glyphicon-file insertRemoveFile' data-vehicleid='" + element.VehicleId + "' data-tablename='" + element.TableName + "'></span></td>";
                }

                for (i = 4; i < element.DataForRow.length; i++) {
                    var column = $("<td>").attr("data-vehiclecode", element.VehicleId).attr("data-tablename", element.TableName).text(element.DataForRow[i].Value).prop("outerHTML");
                    columnList += column;
                }

                var $tableRow = $("<tr></tr>").attr("data-vehiclecode", element.VehicleId).attr("data-tablename", element.TableName);
                if (withAlert)
                    $tableRow.addClass("withAlert").css("background-color", "red").css("color", "#FFFFFF");
                $tableRow.html(columnList);
                resultHtml.push($tableRow.prop("outerHTML"));
            });

            $container.find("tbody").html(resultHtml.join(''));
        }).fail(function () {
            console.debug("No se pudo cargar los datos de la tabla: " + $(containerContext).attr("data-tableName"));
        }).complete(function () {
            console.debug("Culmino el procesamiento de la tabla: " + $(containerContext).attr("data-tableName"));
        });
    };

    vehicleNamespace.LoadDataForTablesYetLoaded = function () {
        var allTables = $(".containerdatatable>table");
        $.each(allTables, function (i, tableContext) {
            var $tableName = $(tableContext).data('tablename');
            vehicleNamespace.LoadTableData(tableContext, $tableName);
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
                Item: { title: 'Item', create: false, edit: false, width: '5%' },
                Codigo: { key: true, title: 'Codigo', width: '5%' },
                CodigoTipoUnidad: { title: 'Tipo de Unidad', options: '/Vehicle/GetVehiclesUnitTypes' },
                Placa: { title: 'Placa' },
                //PlacaTracto: { title: 'Placa Tracto' },
                //PlacaTolva: { title: 'Placa Tolva' },
                MarcaConcatenada: {
                    title: 'Codigo Marca',
                    options: '/Vehicle/GetVehicleBrands'
                },
                EstadoConcatenado: {
                    title: 'Codigo Estado',
                    options: '/Vehicle/GetVehicleStates'
                }
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

                        vehicleNamespace.LoadTableData($currentTable, tableName);
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