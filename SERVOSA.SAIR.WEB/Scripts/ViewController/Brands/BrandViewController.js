(function (brandsController, $, undefined) {

    brandsController.LoadBrands = function () {
        $("#brandsContainer").jtable('load');
    };

    $(function () {

        $("#brandsContainer").jtable({
            title: 'Mantenimiento de Marcas',
            paging: true,
            pageSize: 10,
            sorting: false,
            defaultSorting: 'TypeCode ASC',
            actions: {
                listAction: 'Brands/ListBrands',
                updateAction: 'Brands/UpdateBrand',
                createAction: 'Brands/CreateBrand'
            },
            fields: {
                ConcatenatedCode: {
                    key: true,
                    list: false,
                    edit: false,
                    create: false
                },
                TableCode: {
                    list: false,
                    type: 'hidden'
                },
                TypeCode: {
                    title: 'Código',
                    list: true,
                    create: false,
                    edit: false
                },
                Description: {
                    title: 'Descripción'
                },
                Notes: {
                    title: 'Notas'
                }
            }
        });

        brandsController.LoadBrands();
    });

})(window.BrandsController = window.BrandsController || {}, jQuery);