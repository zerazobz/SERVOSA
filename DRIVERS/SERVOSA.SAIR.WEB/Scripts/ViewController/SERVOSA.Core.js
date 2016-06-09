(function (servosaCore, undefined) {
	var _allConstantColumns = [];

	servosaCore.AddConstantDriverColumn = function (iColumn) {
		_allConstantColumns.push(iColumn);
	}

	servosaCore.GetConstantDriverColumns = function () {
		return _allConstantColumns;
	}

})(window.SERVOSACORE = window.SERVOSACORE || {});