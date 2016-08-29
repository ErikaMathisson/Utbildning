(function () {

    var app = angular.module('app', []);

    //app.controller('ListPersonController', function () {
    //    this.peoples = person;
    //});

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
                    vm.error = "Use another email, already exists in database.";

                } else if (response.data === "Empty") {

                    vm.error = "No data has been submitted, enter required information";
                }


            });

        };
        

    });









    ///////////////////////////////////// ews





    app.controller('PanelController', function () {
        //  this.tab = 1;
        this.tab = {};
        this.selectTab = function (setTab) {
            this.tab = setTab;
        };
        this.isSelected = function (checkTab) {
            return this.tab === checkTab;
        };
    });

    app.controller('EditController', ['$http', function ($http) {
        this.edit = {};

        this.editPerson = function () {
            console.log("edit person function");
            $http.post("Home/EditPerson", EditCtrl.edit).then(function(response){
                if (response.data ==="Success") {

    
                }


            });

        };
  






    //    vm.AddPerson = function () {
    //        $http.post("/Home/AddPerson", vm.person).then(function (response) {
    //            if (response.data === "Success") {
    //                vm.person.Id = Repository.people.length + 1;
    //                Repository.people.push(vm.person);
    //                Repository.newPerson = false;
    //                vm.person = {};

    //            }
    //            else if (response.data === "EmailExist") {
    //                vm.error = "Use another emal, already exists in database.";

    //            } else if (response.data === "Empty") {

    //                vm.error = "No data has been submitted, enter required information";
    //            }


    //        });

    //    };
        

    //});












    }]);

    //app.controller('EditController', function () {
    //    this.edit = {};
    //    this.editPerson = function () {
    //        people.edit.push(this.edit);
    //        this.edit = {};

    //    };

    //});


    //   app.controller('GetPeople', ['$http', function ($http) {
    app.controller('ListPersonController', ['$http', function ($http) {

        var app = this;
        app.peoples = [];

        $http.get('/Home/GetPeople').success(function (data) {
            app.peoples = data;

        });
    }

    ]);



    //var person = [{
    //    firstName: 'Kalle',
    //    lastName: 'Persson',
    //    email: 'kalle.persson@test.se',
    //    phoneNumber: '070-1111111',
    //    country: 'Sverige',
    //    img: 'logo.jpg',
    //    canEdit: true,
    //    editMode: false
    //},
    //{
    //    firstName: 'Stina',
    //    lastName: 'Karlsson',
    //    email: 'stina.karlsson@test.se',
    //    phoneNumber: '070-2111111',
    //    country: 'Norge',
    //    img: '2.jpg',
    //    canEdit: true,
    //    editMode: true
    //},

    // {
    //     firstName: 'Anna',
    //     lastName: 'Larsson',
    //     email: 'anna.larsson@test.se',
    //     phoneNumber: '070-3111111',
    //     country: 'Danmark',
    //     img: '3.jpg',
    //     canEdit: true,
    //     editMode: false
    // }
    //];



})();