(function (servosaCore, undefined) {
	var _allConstantColumns = [];

	servosaCore.AddConstantVehicleColumn = function (iColumn) {
		_allConstantColumns.push(iColumn);
	}

	servosaCore.GetConstantVehicleColumns = function () {
		return _allConstantColumns;
	}

})(window.SERVOSACORE = window.SERVOSACORE || {});