(function () {

    var app = angular.module('app', ['ngRoute']);

    //configure routes
    app.config(function ($routeProvider) {
        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: '/Angular/Templates/home.html',
                controller: 'mainController'
            })

            // route for the register page
            .when('/register', {
                templateUrl: '/Angular/Templates/register.html',
                controller: 'registerController'
            })

            // route for the log in page
            .when('/logIn', {
                templateUrl: '/Angular/Templates/login.html',
                controller: 'loginController'
            });
    });

    //  main controller with $scope injected
    app.controller('mainController', function ($scope) {
        $scope.message = 'This is the main page';
    });

    //controller for handling registration
    app.controller('registerController', function ($scope) {
        $scope.message = 'This is the register page!';
    });

    app.controller('loginController', function ($scope) {
        $scope.message = 'This is the log in page';
    });
})()