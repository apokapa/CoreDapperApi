(function(){
	
	var dataSrvc=function($http){
	    var domain = "http://coredapperapi.azurewebsites.net"

	var getCustomers=function(){
	    return $http.get(domain+"/api/customers/getall")
		.then(function(response){
			return response.data;		
		});	
	};


	var getCustomer=function(id){
	    return $http.get(domain + "/api/customers/getfull/" + id)
		.then(function(response){
			return response.data;		
		});	
	};
	

	var deleteCustomer = function (id) {
	    return $http.delete(domain + "/api/Customers/DeleteCustomer/"+id).then(function (status) {
		return status.data;
		});
	};


	var insertCustomer = function (customer) {
	    return $http.post(domain + "/api/Customers/CreateCustomer", customer).then(function (results) {
	return results;
	});
	};

 
	var updateCustomer = function (customer) {
	    return $http.put(domain + "/api/customers/UpdateCustomer", customer).then(function (status) {
	return status.data;
	});
	};

 
	var getOccupation=function(){
	    return $http.get(domain + "/api/occupation")
		.then(function(response){
			return response.data;		
		});	
	};



	return{
	    getCustomers: getCustomers,
	    getCustomer: getCustomer,
	    deleteCustomer: deleteCustomer,
	    insertCustomer: insertCustomer,
	    updateCustomer: updateCustomer,
	    getOccupation: getOccupation

	};

	};
	
	
	var module = angular.module("myApp");
	module.factory("dataSrvc", dataSrvc);
	
}());