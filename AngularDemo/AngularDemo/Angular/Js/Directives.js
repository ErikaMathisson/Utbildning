(function () {
    "use strict";
    var app = angular.module('myApp');

    //returns an object
    app.directive("myDirective", function () {
        return {
            //scope, element, attribute
            link: function (s,e,a) {
                s.title = a.title;
                s.path = a.title;             

    
            },
            templateUrl: "~/Angular/Templates/DisplayFilmDirective.html?" + new Date().getTime()
            //template: " <label>{{film.name}}</label>" +
            //    " <img ng-src=\"/Angular/Img{{film.image}}\" alt=\"{{film.name}}\" class=\"img-responsive col-xs-2 col-lg-4\" />"
                 
       
             };


        });

})();