(function (driverUploadService, $, undefined) {
    driverUploadService.UploadFiles = function (fileInputId, postUrl, formId, modalId) {

        var fileCollection = document.getElementById(fileInputId.substr(1));
        var fileData = new FormData();

        for (var i = 0; i < fileCollection.files.length; i++) {
            fileData.append(fileCollection.files[i].name, fileCollection.files[i]);
        }

        var dataSerialized = $(formId).serializeArray();
        $.each(dataSerialized, function (i, element) {
            fileData.append(element.name, element.value);
        });

        var ajaxUploadService = new XMLHttpRequest();
        ajaxUploadService.open("POST", postUrl);
        ajaxUploadService.send(fileData);
        ajaxUploadService.onload = function () {
            if (ajaxUploadService.readyState == 4 && ajaxUploadService.status == 200) {
                console.debug("Se guardo correctamente los archivos");
                var responseText = ajaxUploadService.response;
                var htmlResult = this.responseText;
                $(modalId).find(".modal-content").html(htmlResult);

                var tableToLoad = $(modalId).find("[name='TableName']").val();
                var driverId = $(modalId).find("[name='Codigo']").val();
                var containerFileTableToLoad = $(modalId).find(".innerfilestable div").attr("id");

                window.DriverDataViewController.SetupJtableContainer(containerFileTableToLoad, tableToLoad, driverId);
                window.DriverDataViewController.LoadJTableContainer(containerFileTableToLoad);
            }
        };

        ajaxUploadService.onerror = function () {
            console.debug("Ocurrio un error al intentar guardar los archivos");
        }
    };

    $(function () {
        $(".body-content").on("click", "#uploadDriverFile", null, function (e) {
            var $buttonContext = $(this);

            driverUploadService.UploadFiles($buttonContext.data("fileinputid"), $buttonContext.data("posturl"), $buttonContext.data("formid"), $buttonContext.data("modalid"));
        });
    });

})(window.DriverUploadService || {}, jQuery);