(function (driverServosaCore, undefined) {
	var _allConstantColumns = [];

	driverServosaCore.AddConstantDriverColumn = function (iColumn) {
		_allConstantColumns.push(iColumn);
	}

	driverServosaCore.GetConstantDriverColumns = function () {
		return _allConstantColumns;
	}

})(window.DRIVERSERVOSACORE = window.DRIVERSERVOSACORE || {});