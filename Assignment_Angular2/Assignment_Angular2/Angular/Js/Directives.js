(function () {
    "use strict";
    var app = angular.module('app', []);

    //returns an object
    app.directive("homePage", function () {
        return {
            restrict: 'AE',
            ////scope, element, attribute
            //link: function (s, e, a) {
            //    s.title = a.title;
            //    s.path = a.title;
            //},
        templateUrl: "../../Angular/Templates/home-page.html"
           


        };


    });






})();