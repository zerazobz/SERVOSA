(function (driverServosaCore, undefined) {
    var _allConstantColumns = [];
    var _notAllowedConstantVehicleColumns = [];

    driverServosaCore.AddNotAllowedConstantColumn = function (iColumn) {
        _notAllowedConstantVehicleColumns.push(iColumn);
    };

    driverServosaCore.GetNotAllowedConstantColumn = function () {
        return _notAllowedConstantVehicleColumns;
    };

    driverServosaCore.AddConstantDriverColumn = function (iColumn) {
        _allConstantColumns.push(iColumn);
    }

    driverServosaCore.GetConstantDriverColumns = function () {
        return _allConstantColumns;
    }

})(window.DRIVERSERVOSACORE = window.DRIVERSERVOSACORE || {});