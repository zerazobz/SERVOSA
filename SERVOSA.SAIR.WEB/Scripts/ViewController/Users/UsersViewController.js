(function (usersManagementVC, $) {
    var tableIdForUserManagement = "#userManagementTable";

    usersManagementVC.LoadTableUsers = function () {
        $(tableIdForUserManagement).jtable('load');
    };

    $(function () {
        $(tableIdForUserManagement).jtable({
            title: 'Listado de Conductores',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: '/Users/ListAllUsers',
                updateAction: '/Users/UpdateUser',
            },
            fields: {
                Id: {
                    key: true,
                    list: false,
                    edit: false
                },
                UserName: {
                    title: 'Nombre de Usuario',
                    list: true,
                    edit: true
                },
                Email: {
                    title: 'Correo Electrónico',
                    list: true,
                    edit: true
                },
                OperationId: {
                    list: false,
                    edit: true,
                    type: 'hidden'
                },
                PasswordHash: {
                    title: 'Hash',
                    list: false,
                    edit: true,
                    type: 'hidden'
                },
                SecurityStamp: {
                    list: false,
                    edit: true,
                    type: 'hidden'
                }
            }
        });

        usersManagementVC.LoadTableUsers();
    });

})(window.UsersManagement = window.UsersManagement || {}, jQuery);