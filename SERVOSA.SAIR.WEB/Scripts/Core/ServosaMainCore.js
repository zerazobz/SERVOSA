(function (servosaMainCore, $) {

    $(function () {
        function ProccessAlertMessage(htmlTemplate, message, $divContainer) {
            var handleTemplate = Handlebars.compile(htmlTemplate);
            var data = { message: message };
            var htmlGenerated = handleTemplate(data);
            $divContainer.html(htmlGenerated);
            $divContainer.fadeIn(450, function () { $divContainer.fadeOut(450, function () { $divContainer.fadeIn(450, function () { }) }) });
        }

        $.fn.extend({
            SERVOSAErrorNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationError.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            },
            SERVOSAWarningNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationWarning.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            },
            SERVOSAInfoNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationInfo.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            },
            SERVOSASuccessNotification: function (message) {
                var $divContainer = $(this);
                $.get("/Templates/Notifications/NotificationSuccess.html", function (htmlTemplate) {
                    ProccessAlertMessage(htmlTemplate, message, $divContainer);
                });
            }
        });

        var selectedOption = localStorage.getItem("selectedoption");

        var $selectedListItem = $("ul[class*='nav'] li").filter(function (i, item) {
            //return this.innerHTML.indexOf(selectedOption) == 0;
            return $(this).find("a").text() == selectedOption;
        });

        $(document).find("ul[class*='nav']:not(.loginnav) li").removeClass("active");

        if ($selectedListItem)
            $selectedListItem.addClass("active");

        $(document).off("click", "ul[class*='nav']:not(.loginnav) li").on("click", "ul[class*='nav']:not(.loginnav) li", null, function (e) {
            console.debug("Handling click in list item of navbar");
            $(document).find("ul[class*='nav']:not(.loginnav) li").removeClass("active");
            var $currentLi = $(this);
            $currentLi.addClass("active");
            var newLinkSelected = $currentLi.find("a").text();
            localStorage.setItem("selectedoption", newLinkSelected);
        });
    });

})(window.SERVOSAMAINCORE = window.SERVOSAMAINCORE || {}, jQuery)