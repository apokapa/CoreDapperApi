(function () {

    var module = angular.module("myApp");

    var customersController = function ($scope, dataSrvc) {

        $scope.isBusy = true;

        var onCustomers = function (data) {

            $scope.customers = data;

        };

        var onError = function (reason) {
            $scope.error = reason;

        };

        dataSrvc.getCustomers()
		.then(onCustomers, onError)
        .finally(function () {
            $scope.isBusy = false;
        });
	  
	
    };
    module.controller("customersController", customersController);

}());