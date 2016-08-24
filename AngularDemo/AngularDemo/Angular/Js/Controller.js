(function () {
    "use strict";
    var app = angular.module('myApp');

    app.controller("MainController", function ($scope) {
        $scope.films = [
            {
                id: 1, name: "Me before you", image: "1.jpg" 
            },
            {
                id: 2, name: "Bastille day", image: "2.jpg"
            },
            {
                id: 3, name: "X-men", image: "3.jpg"
            }
        ]
    });

   

})();