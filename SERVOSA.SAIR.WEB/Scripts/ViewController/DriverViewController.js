(function (driverNamespace, $, undefined) {

    var driverTemplate = "";

    var jTableFieldOptions = {
        Codigo: { key: true, title: 'Codigo', width: '5%' },
        Placa: { title: 'Nombre y Apellidos' },
        BirthDate: { title: 'Fecha de Nacimiento', type: 'date', displayFormat: 'dd/mm/yy' },
        Address: { title: 'Dirección' },
        Company: { title: 'Compañía' }
    };

    driverNamespace.LoadDriverAutoCompleteTemplate = function () {
        $.get("/Templates/AutoComplete/Driver/DriverRowAutoComplete.html", function (htmlTemplate) {
            driverTemplate = htmlTemplate;
        });
    };

    driverNamespace.GetDriverAutoCompleteTemplate = function () {
        return driverTemplate;
    };

    driverNamespace.LoadDriverTable = function () {
        $("#driverTable").jtable('load');
    };

    driverNamespace.SetupJTable = function (isAdmin) {
        var jTableActions = {};
        if (isAdmin) {
            jTableActions = {
                listAction: '/Driver/ListDrivers'
            };
        }
        else {
            jTableActions = {
                listAction: '/Driver/ListDrivers',
                deleteAction: '/Driver/DeleteDriver',
                updateAction: '/Driver/UpdateDriver',
                createAction: '/Driver/CreateDriver'
            }
        }

        $("#driverTable").jtable({
            title: 'Listado de Conductores',
            paging: true,
            pageSize: 10,
            actions: jTableActions,
            fields: jTableFieldOptions
        });
    };

    driverNamespace.LoadTableHeadDetails = function (nameTable) {

    };

    driverNamespace.LoadTableData = function (containerContext, tableName) {
        $.post("/Driver/LoadTablaData", {
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
                    columnList = "<td data-tablename='Tareas'><span class='glyphicon glyphicon-edit createUpdateData' data-driverid='" + element.DriverId + "' data-tablename='" + element.TableName + "' ></span></td>";
                }
                else {
                    columnList = "<td data-tablename='Tareas'><span class='glyphicon glyphicon-edit createUpdateData' data-driverid='" + element.DriverId + "' data-tablename='" + element.TableName + "' ></span> <span class='glyphicon glyphicon-file insertRemoveFile' data-driverid='" + element.DriverId + "' data-tablename='" + element.TableName + "'></span></td>";
                }

                var constantNotAllowedDriverColumns = DRIVERSERVOSACORE.GetNotAllowedConstantColumn();
                //for (i = 2; i < element.DataForRow.length - 3; i++) {
                for (i = 2; i < element.DataForRow.length; i++) {
                    if (constantNotAllowedDriverColumns.indexOf(element.DataForRow[i].ColumnName) == -1 && element.DataForRow[i].ColumnName !== "") {
                        var column = $("<td>").attr("data-drivercode", element.DriverId).attr("data-tablename", element.TableName).attr("data-columnname", element.DataForRow[i].ColumnName).text(element.DataForRow[i].Value).prop("outerHTML");
                        columnList += column;
                    }
                }

                var $tableRow = $("<tr></tr>").attr("data-drivercode", element.DriverId).attr("data-tablename", element.TableName);
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

    driverNamespace.LoadDataForTablesYetLoaded = function () {
        var allTables = $(".containerdatatable>table");
        $.each(allTables, function (i, tableContext) {
            var $tableName = $(tableContext).data('tablename');
            driverNamespace.LoadTableData(tableContext, $tableName);
            console.debug('Cargando datos de la tabla: ' + $tableName);
        });
    };

    $(function () {

        driverNamespace.LoadDriverAutoCompleteTemplate();

        $("#driverTable").jtable({
            title: 'Listado de Conductores',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/Driver/ListDrivers',
                deleteAction: '/Driver/DeleteDriver',
                updateAction: '/Driver/UpdateDriver',
                createAction: '/Driver/CreateDriver'
            },
            fields: {
                Codigo: { key: true, title: 'Codigo', width: '5%' },
                Placa: { title: 'Nombre y Apellidos' },
                BirthDate: { title: 'Fecha de Nacimiento', type: 'date', displayFormat: 'dd/mm/yy' },
                Address: { title: 'Dirección'}
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

        $(document).off("click", "#createVariableSubmit").on("click", "#createVariableSubmit", null, function (e) {
            var resultValidation = $("#createTableForm").validationEngine('validate');
            if (resultValidation == true) {
                $.post("/DriverVariableTasks/DriverCreateTable", $("#createTableForm").serialize(), function (data) {
                    $("#createTableModal .modal-content").empty();
                    $("#createTableModal .modal-content").html(data);
                    var isSuccessfull = $("#createTableModal .modal-body").find("input[name='IsSuccessful']").val();
                    var message = $("#createTableModal .modal-body").find("input[name='Message']").val();

                    if (isSuccessfull.toLowerCase() == "true") {
                        $("#createTableModal .modal-body").find(".mesagepanel").SERVOSASuccessNotification(message);
                        $("#createVariableSubmit").prop("disabled", true);
                        
                        var tableName = $("#createTableModal .modal-body").find("input[name='TableName']").val()
                        var normalizedTableName = $("#createTableModal .modal-body").find("input[name='TableNormalizedName']").val()

                        $.get("/templates/drivertabletemplate.html", function (data) {

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
            $("#createTableModal .modal-content").load("/DriverVariableTasks/DriverCreateTable");
        });

        $(document).on("click", ".addNewColumnToVariable", null, function (e) {
            var $currentButton = $(this);
            var normalizedTableName = $currentButton.data('normalizedtablename');
            var tableName = $currentButton.data('tablename');

            $.get("/DriverVariableTasks/DriverCreateColumn", function (dataResult) {
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
                $.post("/DriverVariableTasks/DriverCreateColumn", $("#createColumnForm").serialize(), function (dataResult) {
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
                        var totalHeadColumns = $currentTable.find("thead tr:eq(1) th").length;
                        $currentTable.find("thead tr:eq(1)").find("th:nth(" + (totalHeadColumns - 1) + ")").before("<th data-columnname='" + columnNormalizedName + "'>" + columnNormalizedName + "</th>");
                        //$currentTable.find("thead tr:eq(1)").append("<th>" + columnNormalizedName + "</th>");

                        var totalInnerColumns = $currentTable.find("tr:eq(2) td").length;
                        $currentTable.find("tr:gt(1)").find("td:nth(" + (totalInnerColumns - 1) +")").before("<td data-columnname='" + columnNormalizedName + "'></td>");
                        //$currentTable.find("tr:gt(1)").append("<td></td>");
                        var oldColSpan = parseInt($currentTable.find("thead tr:first-child th").attr("colspan"));
                        $currentTable.find("thead tr:first-child th").attr("colspan", oldColSpan + 1);

                        driverNamespace.LoadTableData($currentTable, tableName);
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
            window.location = "/DriverData/DownloadVariable?tableName=" + tableName
        });

        $("#driverAutoComplete").autocomplete({
            minLength: 3,
            source: function (request, response) {
                $.post("/Driver/SearchDriverForAutoComplete", { searchText : request.term, maxResults : 10 }, function (data, textStatus, jqXHR) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Placa + "-" + item.Address,
                            value: item.Placa || "" + "-" + item.Address || "",
                            data: item,
                            id: item.Codigo
                        }
                    }));
                }).fail(function(e) {
                });
            },
            select: function (event, ui) {
                var elem = $(event.originalEvent.toElement);
                if (elem.hasClass('downloaddriverdata')) {
                    var driverId = elem.data("driverid");
                    window.location = "/DriverData/DownloadDriverData?driverId=" + driverId
                }
            }
        })
        .data("ui-autocomplete")
        ._renderItem = function (ul, item) {
            var htmlTemplate = driverNamespace.GetDriverAutoCompleteTemplate();
            var handleTemplate = Handlebars.compile(htmlTemplate);
            var data = {
                //DriverPlate: item.data.Placa,
                //DriverBrand: item.data.Marca,
                DriverId: item.data.Codigo,
                Name: item.data.Placa
            };
            var htmlGenerated = handleTemplate(data);
            return $(htmlGenerated).appendTo(ul);
        };

        driverNamespace.LoadDriverTable();
        driverNamespace.LoadDataForTablesYetLoaded();

        $(".body-content").off("click", ".editdrivertablename").on("click", ".editdrivertablename", null, function (e) {
            $("#changeDriverTableNameModal").modal("show");
            $("#changeDriverTableNameModal").find("input[name='oldTableName']").val($(this).data("normalizedtablename"));
        });

        $(".body-content").off("click", "#changeTableName").on("click", "#changeTableName", null, function (e) {
            $.post("/DriverDashboard/ChangeTableName", {
                oldTableName: $("#changeDriverTableNameModal").find("input[name='oldTableName']").val(),
                newTableName: $("#changeDriverTableNameModal").find("input[name='newTableName']").val()
            }, function (data, textStatus, jqXHR) {
                $(document).find("button[data-normalizedtablename='" + $("#changeDriverTableNameModal")
                   .find("input[name='oldTableName']").val() + "']").parent().find("p")
                   .text($("#changeDriverTableNameModal").find("input[name='newTableName']").val());
                $("#changeDriverTableNameModal").modal("hide");
            });
        });

        $(".body-content").off("click", ".removedrivertable").on("click", ".removedrivertable", null, function (e) {
            var confirmationResult = confirm("Al eliminar la tabla, todos los datos serán eliminados.");
            var tableNormalizedName = $(this).data("normalizedtablename");
            if (confirmationResult) {
                $.post("/DriverDashboard/RemoveTable", { tableName: tableNormalizedName }, function (data, textStatus, jqXHR) {
                    $("table[data-tablename='" + tableNormalizedName + "']").remove()
                });
            }
        });

    });

})(window.DriverNamespace = window.DriverNamespace || {}, jQuery);