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

    app.factory('bookFactory', function ($http, $window) {

        var bookFactory = {};

        bookFactory.message = "";

        //function for register a person
        bookFactory.registerPerson = function (person) {
            console.log("RegisterPerson function factory");
            return $http.post('/Person/RegisterPerson', person)
                .success(function (data) {
                    //check if error message is returned, in that case sent it to the controller               
                    if (data === "EmailExists") {
                        bookFactory.message = "Email already exist, please re enter your information!";
                    }
                    else if (data === "Empty") {
                        bookFactory.message = "No data has been submitted, enter required information!";
                    }
                    else if (data === "NonValid") {
                        bookFactory.message = "All required information not entered or in wrong format, try again!";
                    }
                        //person is saved to database, push the data to the array
                    else if (data === "Success") {
                        bookFactory.message = "Person registered ok";
                        $window.location.href = "#/";
                    }
                    else {
                        console.log(data);
                        bookFactory.message = data;                     
                    }
                })
        .error(function () {
            console.log("Error");
        });

        };
        return bookFactory;
    });

    //  main controller with $scope injected
    app.controller('mainController', function ($scope) {
        $scope.message = 'This is the main page';
    });

    //controller for handling registration
    app.controller('registerController', function ($scope, $window, bookFactory) {

        $scope.message = 'This is the register page!';

        var person = $scope.person;

        //function for register a person
        this.registerPerson = function () {

            console.log("RegisterPerson function");

            //call the registerPerson function in factory
            bookFactory
            .registerPerson($scope.person)
            .then(function () {

                console.log(bookFactory.message.length);
                //check if a message is returned from factory in that case print the message
                if (bookFactory.message.length !== 0) {                   
                    $scope.statusMessage = bookFactory.message;
                }
                console.log($scope.statusMessage);
             //   $window.location.href = "#/";

            });
        };
    });





    app.controller('loginController', function ($scope) {
        $scope.message = 'This is the log in page';
    });
})();