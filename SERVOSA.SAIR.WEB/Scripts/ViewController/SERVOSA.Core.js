(function (servosaCore, undefined) {
    var _allConstantColumns = [];
    var _notAllowedConstantVehicleColumns = [];

    servosaCore.AddNotAllowedConstantColumn = function (iColumn) {
        _notAllowedConstantVehicleColumns.push(iColumn);
    };

    servosaCore.GetNotAllowedConstantColumn = function () {
        return _notAllowedConstantVehicleColumns;
    };

    servosaCore.AddConstantVehicleColumn = function (iColumn) {
        _allConstantColumns.push(iColumn);
    }

    servosaCore.GetConstantVehicleColumns = function () {
        return _allConstantColumns;
    }

})(window.SERVOSACORE = window.SERVOSACORE || {});