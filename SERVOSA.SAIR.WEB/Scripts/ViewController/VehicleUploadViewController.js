(function (vehicleUploadService, $, undefined) {
    vehicleUploadService.UploadFiles = function (fileInputId, postUrl) {

        var fileCollection = document.getElementById(fileInputId.substr(1));
        var fileData = new FormData();

        for (var i = 0; i < fileCollection.files.length; i++) {
            fileData.append(fileCollection.files[i].name, fileCollection.files[i]);
        }
        var ajaxUploadService = new XMLHttpRequest();
        ajaxUploadService.open("POST", postUrl);
        ajaxUploadService.send(fileData);
        ajaxUploadService.onload = function () {
            if(ajaxUploadService.readyState == 4 && ajaxUploadService.status == 200) {
                console.debug("Se guardo correctamente los archivos");
            }
        };

        ajaxUploadService.onerror = function() {
            console.debug("Ocurrio un error al intentar guardar los archivos");
        }
    };

    $(function () {
        $(".body-content").on("click", "#uploadVehicleFile", null, function (e) {
            var $buttonContext = $(this);

            vehicleUploadService.UploadFiles($buttonContext.data("fileinputid"), $buttonContext.data("posturl"));
        });
    });

})(window.VehicleUploadService || {}, jQuery);