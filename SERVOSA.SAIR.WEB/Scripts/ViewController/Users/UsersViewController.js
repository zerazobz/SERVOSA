(function (usersManagementVC, $) {
    var tableIdForUserManagement = "#userManagementTable";

    usersManagementVC.LoadTableUsers = function () {
        $(tableIdForUserManagement).jtable('load');
    };

    usersManagementVC.CleanModalUpdatePassword = function () {
        $("confirmationNewPassword").val("");
        $("newPassword").val("");
        $("currentPassword").val("");
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
                },
                ChangeUserPasword: {
                    title: 'Cambiar Contraseña',
                    edit: false,
                    display: function (data) {
                        return '<button type="button" data-userid=' + data.record.Id + ' class="btn btn-default changepassword" >Cambiar Contraseña</button>';
                    }
                }
            }
        });

        $(".body-content").off("click", ".changepassword").on("click", ".changepassword", null, function (data) {
            var userid = $(this).data("userid");

            $("#changeUserPasswordModal").find("#changeUserPasswordAction").data("userid", userid);

            $("#changeUserPasswordModal").modal("show");
        });

        $(".body-content").off("click", "#changeUserPasswordAction").on("click", "#changeUserPasswordAction", null, function (data) {
            var userId = $(this).data("userid");
            var newPassword = $("#changeUserPasswordModal #newPassword").val();
            var passwordValidity = document.getElementById("confirmationNewPassword").checkValidity();
            if (passwordValidity) {
                $.post("/Users/UpdateUserPassword", {
                    userId: userId,
                    newPassword: newPassword
                }, function (dataResult) {
                    if (dataResult.Result == "OK") {
                        $(".messagePanel").SERVOSASuccessNotification("Se actualizo correctamente la contraseña.");
                        //$("#changeUserPasswordModal").modal("hide");
                    }
                    else {
                        $(".messagePanel").SERVOSAErrorNotification(dataResult.Message);
                    }
                    usersManagementVC.CleanModalUpdatePassword();
                });
            }
            else
                document.getElementById("confirmationNewPassword").reportValidity();
        });

        usersManagementVC.LoadTableUsers();
    });

    function validatePassword() {
        var pass2 = document.getElementById("confirmationNewPassword").value;
        var pass1 = document.getElementById("newPassword").value;
        if (pass1 != pass2)
            document.getElementById("confirmationNewPassword").setCustomValidity("Las contraseñas no coinciden.");
        else
            document.getElementById("confirmationNewPassword").setCustomValidity('');
        document.getElementById("confirmationNewPassword").reportValidity();
    }

    window.onload = function () {
        document.getElementById("newPassword").onchange = validatePassword;
        document.getElementById("confirmationNewPassword").onchange = validatePassword;
    };

})(window.UsersManagement = window.UsersManagement || {}, jQuery);