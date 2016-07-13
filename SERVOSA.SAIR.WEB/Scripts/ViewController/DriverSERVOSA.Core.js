(function (driverServosaCore, undefined) {
    var _allConstantColumns = [];
    var _notAllowedConstantVehicleColumns = [];

    servosaCore.AddNotAllowedConstantColumn = function (iColumn) {
        _notAllowedConstantVehicleColumns.push(iColumn);
    };

    servosaCore.GetNotAllowedConstantColumn = function () {
        return _notAllowedConstantVehicleColumns;
    };

    driverServosaCore.AddConstantDriverColumn = function (iColumn) {
        _allConstantColumns.push(iColumn);
    }

    driverServosaCore.GetConstantDriverColumns = function () {
        return _allConstantColumns;
    }

})(window.DRIVERSERVOSACORE = window.DRIVERSERVOSACORE || {});