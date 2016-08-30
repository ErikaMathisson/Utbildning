(function () {

    var app = angular.module('app', []);

    //app.factory('ContactService', function ($http) {
    //    //var vm = {};
    //    //vm.people = [];
    //    var people = [];
    //    $http.get('/Home/GetPeople').then(function (response) {
    //        //    vm.people = response.data;
    //        people = response.data;
    //        console.log(people);

    //    });


    // //   var people = ["Peter", "Daniel", "Nina"];
    // //   console.log(people);

    //    return {
    //        all: function () {
    //            console.log(people);
    //            return people;
    //        },
    //        first: function () {
    //            return people[0];
    //        }
    //    };

    //    //simply returns the contacts list
    //    //vm.list = function () {
    //    //    console.log(vm.people);
    //    //        return vm.people;
    //    //    };

    //    //  vm.newPerson = false;




    //});



    //  var app = angular.module("MyApp", []);

    //  app.factory("UserService", function () {
    //      var users = ["Peter", "Daniel", "Nina"];

    //      return {
    //          all: function () {
    //              return users;
    //          },
    //          first: function () {
    //              return users[0];
    //          }
    //      };
    //  });

    //app.controller("MyCtrl", function ($scope, UserService) {
    //    $scope.users = UserService.all();
    //});



    //  app.controller("AnotherCtrl", ["$scope", "UserService",
    //function ($scope, UserService) {
    //    $scope.firstUser = UserService.first();
    //}
    //  ]);



    ////////////////////////////////////********************************


    //    //var vm = {};
    //    //vm.people = [];
    //    var people = [];
    //    $http.get('/Home/GetPeople').then(function (response) {
    //        //    vm.people = response.data;
    //        people = response.data;
    //        console.log(people);

    //    });



    //app.factory('ContactService', function ($http) {

    //*   app.service('ContactService', function () {
    app.service('ContactService', function($http){
        //to create unique contact id
        var uid = 1;

        //contacts array to hold list of all contacts
        //var people = [{
        //    id: 0,
        //    'name': 'Viral',
        //    'email': 'hello@gmail.com',
        //    'phone': '123-2343-44',
        //    'country': 'Sverige'
        //}];

       

        //var people = [];

        //$http.get('/Home/GetPeople').then(function (response) {
        //    people = response.data;
        //    console.log(people);

        //    console.log(people[0].country);
                 

        //        });


        //console.log(people);




        //   save method create a new contact if not already exists
        //   else update the existing object
        this.save = function (person) {
            if (person.id == null) {
                //if this is new contact, add it in contacts array
                person.id = uid++;
                people.push(person);
            } else {
                //for existing contact, find this contact using id
                //and update it.
                for (i in people) {
                    if (people[i].id == person.id) {
                        people[i] = person;
                    }
                }
            }

        };

        //simply search contacts list for given id
        //and returns the contact object if found
        this.get = function (id) {
            for (i in people) {
                if (people[i].id == id) {
                    return people[i];
                }
            }

        };

        //iterate through contacts list and delete 
        //contact if found
        this.delete = function (id) {
            for (i in people) {
                if (people[i].id == id) {
                    people.splice(i, 1);
                }
            }
        };

        //simply returns the contacts list
        this.list = function () {

            var vm = {};
            vm.people = [];

            $http.get('/Home/GetPeople').then(function (response) {
                vm.people = response.data;
                console.log(vm.people);

                //console.log(people[0].country);
                //console.log(people);
                //return people;


            });
            return vm.people;
           
        };
    });


    app.controller('ContactController', function ($scope, ContactService) {

        $scope.people = ContactService.list();
        console.log(ContactService.list());

        console.log($scope.people)

        $scope.savePerson = function () {
            ContactService.save($scope.newperson);
            $scope.newperson = {};
        }


        $scope.delete = function (id) {

            ContactService.delete(id);
            if ($scope.newperson.id == id) $scope.newperson = {};
        }


        $scope.edit = function (id) {
            $scope.newperson = angular.copy(ContactService.get(id));
        }
    })

    ////////////////////////////////////////////////////////////

    













})();