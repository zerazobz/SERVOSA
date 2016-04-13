(function (SERVOSANamespace, $, undefined) {
    var arrayEvents = [];

    SERVOSANamespace.addEvent = function (newEvent) {
        arrayEvents.push(newEvent);
    };

    SERVOSANamespace.registerEvents = function () {
        $.each(arrayEvents, function (i, element) {
            element();
        });
    };

    SERVOSANamespace.cleanEvents = function () {
        arrayEvents = [];
    };

    SERVOSANamespace.CreateSubmitForm = function (idSubmitForm) {
        var url = $(idSubmitForm).attr('url');
        $.post(url, $(idSubmitForm).serialize(), function (data) {
            console.log('Post message receivedf');
            $(idSubmitForm).empty();
            $(idSubmitForm).append(data);
            SERVOSANamespace.registerEvents();
        }).fail(function () {
            console.debug('Fail in post call');

        }).complete(function () {
            console.debug('Complete post call');
        });
    };

    $(function () {

    });

})(window.SERVOSA = window.SERVOSA || {}, jQuery);