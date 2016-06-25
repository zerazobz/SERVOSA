(function (servosaMainCore, $) {

    $(function () {
        var selectedOption = localStorage.getItem("selectedoption");

        var $selectedListItem = $("ul[class*='nav'] li").filter(function (i, item) {
            return this.innerHTML.indexOf(selectedOption) == 0;
        });

        if ($selectedListItem)
            $selectedListItem.addClass("selected");

        $(document).find("ul[class*='nav']:not(.loginnav) li").removeClass("active");

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