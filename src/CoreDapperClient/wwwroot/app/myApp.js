(function () {
    "use strict";
    var app = angular.module("myApp", ["ngRoute","simpleControls"])
 
    

    app.config(function ($routeProvider) {

        $routeProvider
        .when("/main/", {
            templateUrl: "app/views/main.html",
            controller: "mainController"
        }).otherwise({ redirectTo: "/main" })
        .when("/customers/", {
            templateUrl: "app/views/customers/customers.html",
            controller: "customersController"
        }).when('/edit-customer/:id', {
		    title: 'Edit Customers',
		    templateUrl: 'app/views/customers/edit-customer.html',
			controller: 'customersEditController'
		})
        .otherwise({ redirectTo: "/customers" });

    });

}());
