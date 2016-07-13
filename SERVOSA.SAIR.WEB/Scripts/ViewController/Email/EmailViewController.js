(function (emailManagement, $) {
    emailManagement.LoadEmailTable = function () {
        $("#emailTable").jtable('load');
    };

    $(function () {
        $("#emailTable").jtable({
            title: 'Listado de Destinatarios',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/Email/ListAllEmail',
                createAction: '/Email/CreateEmail',
                deleteAction: '/Email/DeleteEmail'
            },
            fields: {
                Id: {
                    title: '',
                    key: true,
                    create: false,
                    list: false
                },
                Email: {
                    title: 'Destinatario',
                    inputClass: 'validate[required,custom[email]]'
                }
            },
            formCreated: function (event, data) {
                data.form.validationEngine();
            },
            formSubmitting: function (event, data) {
                return data.form.validationEngine('validate');
            },
            formClosed: function (event, data) {
                data.form.validationEngine('hide');
                data.form.validationEngine('detach');
            }
        });

        emailManagement.LoadEmailTable();
    });

})(window.EmailManagement = window.EmailManagement || {}, jQuery);