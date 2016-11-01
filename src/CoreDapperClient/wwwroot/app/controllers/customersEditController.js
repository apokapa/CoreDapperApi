(function () {

    var module = angular.module("myApp");

    var customersEditController = function ($window,$scope,$route,$location,dataSrvc) 
    {
	 
	 var id = $route.current.params.id;
	 $scope.customerID = id;
	 $scope.isBusy = true;

	 $scope.title = (id> 0) ? 'Edit Customer' : 'Add Customer';
	 $scope.buttonText = (id > 0) ? 'Update Customer' : 'Add New Customer';

	  	var onCustomers = function (data) {
	  	    $scope.customer = data;
	  	};

        var onError = function (reason) {
            $scope.error = reason;
        };

        dataSrvc.getCustomer(id)
		.then(onCustomers, onError)
        .finally(function () {
            $scope.isBusy = false;
        });


		$scope.deleteCustomer = function(customer) {
		if(confirm("Are you sure to delete customer number: "+ id)==true)
		    dataSrvc.deleteCustomer(id);
            $window.location.href = "/";
		};

	  	$scope.saveCustomer = function(customer){
		if (id <= 0) {
		    dataSrvc.insertCustomer(customer);   
		}
		else {
		    dataSrvc.updateCustomer(customer);
		}
		$window.location.href = "/";
		};
	
    };
    module.controller("customersEditController", customersEditController);


}());