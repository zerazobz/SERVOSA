(function (vehicleNamespace, $, undefined) {

    var vehicleTemplate = "";

    var vehicleJTableFields = {
        Item: { title: 'Item', create: false, edit: false, width: '5%' },
        Codigo: { key: true, title: 'Codigo', width: '5%' },
        CodigoTipoUnidad: { title: 'Tipo de Unidad', options: '/Vehicle/GetVehiclesUnitTypes' },
        Placa: { title: 'Placa' },
        MarcaConcatenada: {
            title: 'Codigo Marca',
            options: '/Vehicle/GetVehicleBrands'
        },
        EstadoConcatenado: {
            title: 'Codigo Estado',
            options: '/Vehicle/GetVehicleStates'
        },
        Companhia: {
            title: 'Compañía Pertenencia'
        }
    };

    vehicleNamespace.LoadVehicleAutoCompleteTemplate = function () {
        $.get("/Templates/AutoComplete/Vehicle/VehicleRowAutoComplete.html", function (htmlTemplate) {
            vehicleTemplate = htmlTemplate;
        });
    };

    vehicleNamespace.GetVehicleAutoCompleteTemplate = function () {
        return vehicleTemplate;
    };

    vehicleNamespace.SetupVehicleJTable = function (forAdmin) {
        console.log("Is for admin: " + forAdmin);
        var jtableActions = {};
        if (forAdmin) {
            jtableActions = {
                listAction: '/Vehicle/ListVehicles'
            };
        }
        else {
            jtableActions = {
                listAction: '/Vehicle/ListVehicles',
                deleteAction: '/Vehicle/DeleteVehicle',
                updateAction: '/Vehicle/UpdateVehicle',
                createAction: '/Vehicle/CreateVehicle'
            };
        }
        $("#vehicleTable").jtable({
            title: 'Listado de Vehiculos',
            paging: true,
            pageSize: 10,
            actions: jtableActions,
            fields: vehicleJTableFields
        });
    };

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
                var columnList = '';
                if (identityValue === '') {
                    columnList = "<td data-tablename='Tareas'><span class='glyphicon glyphicon-edit createUpdateData' data-vehicleid='" + element.VehicleId + "' data-tablename='" + element.TableName + "' ></span></td>";
                }
                else {
                    columnList = "<td data-tablename='Tareas'><span class='glyphicon glyphicon-edit createUpdateData' data-vehicleid='" + element.VehicleId + "' data-tablename='" + element.TableName + "' ></span> <span class='glyphicon glyphicon-file insertRemoveFile' data-vehicleid='" + element.VehicleId + "' data-tablename='" + element.TableName + "'></span></td>";
                }

                var constantNotAllowedVehicleColumns = SERVOSACORE.GetNotAllowedConstantColumn();
                //for (i = 2; i < element.DataForRow.length - 3; i++) {
                for (i = 2; i < element.DataForRow.length; i++) {
                    if (constantNotAllowedVehicleColumns.indexOf(element.DataForRow[i].ColumnName) === -1 && element.DataForRow[i].ColumnName !== "") {
                        var textToRender = element.DataForRow[i].Value;
                        //var momentDate = moment(textToRender);
                        //if (momentDate.isValid())
                        //    textToRender = momentDate.format("dd/MM/yyyy");

                        var column = $("<td>").attr("data-vehiclecode", element.VehicleId).attr("data-tablename", element.TableName).attr("data-columnname", element.DataForRow[i].ColumnName).text(textToRender).prop("outerHTML");
                        columnList += column;
                    }
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

        vehicleNamespace.LoadVehicleAutoCompleteTemplate();

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

        $(document).off("click", "#createVariableSubmit").on("click", "#createVariableSubmit", null, function (e) {
            var resultValidation = $("#createTableForm").validationEngine('validate');
            if (resultValidation === true) {
                $.post("/VariableTasks/CreateTable", $("#createTableForm").serialize(), function (data) {
                    $("#createTableModal .modal-content").empty();
                    $("#createTableModal .modal-content").html(data);
                    var isSuccessfull = $("#createTableModal .modal-body").find("input[name='IsSuccessful']").val();
                    var message = $("#createTableModal .modal-body").find("input[name='Message']").val();

                    if (isSuccessfull.toLowerCase() === "true") {
                        $("#createTableModal .modal-body").find(".mesagepanel").SERVOSASuccessNotification(message);
                        $("#createVariableSubmit").prop("disabled", true);
                        
                        var tableName = $("#createTableModal .modal-body").find("input[name='TableName']").val()
                        var normalizedTableName = $("#createTableModal .modal-body").find("input[name='TableNormalizedName']").val()

                        $.get("/templates/vehicletabletemplate.html", function (data) {

                            var handletemplate = Handlebars.compile($(data).html());
                            data = {
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
            if (resultValidation === true) {
                $.post("/VariableTasks/CreateColumn", $("#createColumnForm").serialize(), function (dataResult) {
                    $("#createColumnModal .modal-content").empty();
                    $("#createColumnModal .modal-content").html(dataResult);
                    var isSuccessfull = $("#createColumnForm ").find("input[name='IsSuccessful']").val();
                    var message = $("#createColumnForm ").find("input[name='Message']").val();

                    if (isSuccessfull.toLowerCase() === "true") {
                        $("#createColumnModal").find(".messagePanel").SERVOSASuccessNotification(message);
                        $("#createColumnSubmit").prop("disabled", true);
                        
                        var tableName = $("#createColumnModal").find("input[name='TableNormalizedName']").val();
                        var columnName = $("#createColumnModal").find("input[name='ColumnName']").val();
                        var columnNormalizedName = $("#createColumnModal ").find("input[name='ColumnNormalizedName']").val();

                        var $currentTable = $("table[data-tablename = '" + tableName + "']");
                        var totalHeadColumns = $currentTable.find("thead tr:eq(1) th").length;
                        $currentTable.find("thead tr:eq(1)").find("th:nth(" + (totalHeadColumns - 1) + ")").before("<th data-columnname='" + columnNormalizedName + "'>" + columnNormalizedName + "</th>");

                        var totalInnerColumns = $currentTable.find("tr:eq(2) td").length;
                        $currentTable.find("tr:gt(1)").find("td:nth(" + (totalInnerColumns - 1) +")").before("<td data-columnname='" + columnNormalizedName + "'></td>");
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

        $(document).on("click", ".downloadFileForVariable", null, function (e) {
            var tableName = $(this).data("normalizedtablename");
            console.debug("Download File for: " + tableName);
            window.location = "/VehicleData/DownloadVariable?tableName=" + tableName
        });

        $(document).off("click", ".editvehicletablename").on("click", ".editvehicletablename", null, function (e) {
            $("#changeVehicleTableNameModal").modal("show");
            $("#changeVehicleTableNameModal").find("input[name='oldTableName']").val($(this).data("normalizedtablename"));
        });

        $(".body-content").off("click", "#changeTableName").on("click", "#changeTableName", null, function (e) {
            $.post("/Home/ChangeTableName", {
                oldTableName: $("#changeVehicleTableNameModal").find("input[name='oldTableName']").val(),
                newTableName: $("#changeVehicleTableNameModal").find("input[name='newTableName']").val()
            }, function (data, textStatus, jqXHR) {
                $(document).find("button[data-normalizedtablename='" + $("#changeVehicleTableNameModal")
                   .find("input[name='oldTableName']").val() + "']").parent().find("p")
                   .text($("#changeVehicleTableNameModal").find("input[name='newTableName']").val());
                $("#changeVehicleTableNameModal").modal("hide");
            });
        });

        $(".body-content").off("click", ".removevehicletable").on("click", ".removevehicletable", null, function (e) {
            var confirmationResult = confirm("Al eliminar la tabla, todos los datos serán eliminados.");
            var tableNormalizedName = $(this).data("normalizedtablename");
            if (confirmationResult) {
                $.post("/Home/RemoveTable", { tableName: tableNormalizedName }, function (data, textStatus, jqXHR) {
                    $("table[data-tablename='" + tableNormalizedName + "']").remove()
                });
            }
        });

        $("#vehicleAutoComplete").autocomplete({
            minLength: 3,
            source: function (request, response) {
                $.post("/Vehicle/SearchVehicleForAutoComplete", { searchText : request.term, maxResults : 10 }, function (data, textStatus, jqXHR) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Placa + "-" + item.DescripcionTipoUnidad,
                            value: item.Placa || "" + "-" + item.DescripcionTipoUnidad || "",
                            data: item,
                            id: item.Codigo
                        }
                    }));
                }).fail(function(e) {
                });
            },
            select: function (event, ui) {
                var elem = $(event.originalEvent.toElement);
                if (elem.hasClass('downloadvehicledata')) {
                    var vehicleId = elem.data("vehicleid");
                    window.location = "/VehicleData/DownloadVehicleData?vehicleId=" + vehicleId
                }
            }
        })
        .data("ui-autocomplete")
        ._renderItem = function (ul, item) {
            var htmlTemplate = vehicleNamespace.GetVehicleAutoCompleteTemplate();
            var handleTemplate = Handlebars.compile(htmlTemplate);
            var data = {
                VehiclePlate: item.data.Placa,
                VehicleBrand: item.data.Marca,
                VehicleId: item.data.Codigo
            };
            var htmlGenerated = handleTemplate(data);
            return $(htmlGenerated).appendTo(ul);
        };

        vehicleNamespace.LoadVehicleTable();
        vehicleNamespace.LoadDataForTablesYetLoaded();
    });

})(window.VehicleNamespace = window.VehicleNamespace || {}, jQuery);