(function () {

    var app = angular.module('app', []);

   
    ///////////////////////////////////// ws

    app.factory("Repository", function ($http) {
        var vm = {};
        vm.people = [];
        $http.get('/Home/GetPeople').then(function (response) {
            vm.people = response.data;

        });
        vm.newPerson = false;
        return vm;

    });




    app.controller('MainController', function ($window, $http, $location, $scope, Repository) {
        $window.document.title = "Main page";
        var vm = this;
        vm.details = false;
        $scope.$watch(function () {

            return Repository.people;
        }, function (n, o) {
            if (n.length > 0) {
                vm.peopleList = Repository.people;
            }
        });

        $scope.$watch(function () {
            return Repository.newPerson;
        }, function (n, o) {
            vm.newPerson = Repository.newPerson;
        });

        $scope.$watch(function () {
            return Repository.details;
        }, function (n, o) {
            vm.details = Repository.details;
        });

        vm.changeFormValue = function (val) {
            Repository.newPerson = val;
        };

        vm.changeDetailsFunc = function (val, p) {
            Repository.details = val;
            Repository.selectPerson(p);
        };

    });

    app.controller("AddPersonController", function ($http, $window, Repository, $scope) {
        var vm = this;
        vm.person = {};

        $scope.$watch(function () {
            return Repository.newPerson;
        }, function (n, o) {
            vm.newPerson = Repository.newPerson;
        });

        vm.changeFormValue = function (val) {
            Repository.newPerson = val;


        };

        //for edit change change name on function call /Home/EditPerson same prinicpal
        // in order to remove the original post and add the changed post
        // Repository.people.splice(i,1) 1 betyder ta bort
        //Repository.people.splice(i,0, vm.person) 0 betyder lägg till
        // you could also set value by value for loop and then update the correct "i"
        vm.AddPerson = function () {
            $http.post("/Home/AddPerson", vm.person).then(function (response) {
                if (response.data === "Success") {
                    vm.person.Id = Repository.people.length + 1;
                    Repository.people.push(vm.person);
                    Repository.newPerson = false;
                    vm.person = {};

                }
                else if (response.data === "EmailExist") {
                    vm.error = "Use another emal, already exists in database.";

                } else if (response.data === "Empty") {

                    vm.error = "No data has been submitted, enter required information";
                }


            });

        };


    });









    ///////////////////////////////////// ews






})();