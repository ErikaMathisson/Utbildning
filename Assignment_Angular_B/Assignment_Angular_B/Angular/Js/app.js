(function () {

    var app = angular.module('app', []);


    //app.factory("ContactService", function ($http) {
    //    var vm = this;
    //    vm.people = [];
    //     $http.get('/Home/GetPeople').then(function (response) {
    //        vm.people = response.data;
    //        console.log(vm.people);


    //    });
    //    //     vm.newPerson = false;
    //    console.log(vm);
    //    console.log(vm.people);
    //    return vm;

    //});







    app.factory('ContactService', function ($http) {
        return {


            people: [],

            //   getData: function () {
            getData: function () {
                var people = this.people;
                return $http.get('/Home/GetPeople').then(function (response) {

                    people = response.data;
                    console.log(response.data);

                    //    people.push({data});

                    console.log(people);

                    //    console.log(response.data);
                    //      return response.data;
                    return people;
                });
            }
        };
    });







    app.controller('AddPersonController', function ($scope, $http, ContactService) {

        console.log("Addpersoncontroller");
        var vm = this;
        vm.people = ContactService.people;
        console.log(vm.people);



        //var app = angular.module('myApp', []);
        //app.controller('myCtrl', function ($scope, $http) {
        //    $http.get("welcome.htm")
        //    .then(function (response) {
        //        $scope.myWelcome = response.data;
        //    });
        //});




        ////   app.controller('GetPeople', ['$http', function ($http) {
        //app.controller('ListPersonController', ['$http', function ($http) {

        //    var app = this;
        //    app.peoples = [];

        //    $http.get('/Home/GetPeople').success(function (data) {
        //        app.peoples = data;

        //    });
        //}

        //]);

        var person = $scope.newperson;

        this.savePerson = function (person) {
            person = $scope.newperson;
            console.log(person);
            if (person.id == null) {
                console.log("add Person");
                //  savePerson = function () {
                console.log("add Person2");
                $http.post("/Home/AddPerson", person).then(function (response) {
                    console.log(response.data);
                    if (response.data.id != null) {
                        console.log("add Person3");

                        //      person.id = ContactService.people.length + 1;

                        console.log(response.data.id);
                        console.log(ContactService.people);
                        console.log(person);
                        person = response.data;
                        console.log(person);
                        //ContactService.people
                        //ContactService.people().then(function (data) {
                        //    console.log(data);
                        //    $scope.people = data;
                        //    console.log($scope.people);
                        //});

                        //        $scope.people = ContactService.people;


                        console.log(ContactService.people);



                        ContactService.people.push(person);
                        console.log(ContactService.people);
                        //    ContactService.newPerson = false;
                        newperson = {};

                    }
                    else if (response.data === "EmailExist") {
                        //     vm.error = "Use another emal, already exists in database.";

                    } else if (response.data === "Empty") {

                        //     vm.error = "No data has been submitted, enter required information";
                    }


                });
                //   };









                //if this is new contact, add it in contacts array
                //        person.id = uid++;
                //        people.push(person);
            } else {

                console.log("person exist");
                //for existing contact, find this contact using id
                //and update it.
                for (i in people) {
                    if (people[i].id == person.id) {
                        people[i] = person;
                    }
                }
            }

        };

        //vm.AddPerson = function () {
        //    $http.post("/Home/AddPerson", vm.person).then(function (response) {
        //        if (response.data === "Success") {
        //            vm.person.Id = Repository.people.length + 1;
        //            Repository.people.push(vm.person);
        //            Repository.newPerson = false;
        //            vm.person = {};

        //        }
        //        else if (response.data === "EmailExist") {
        //            vm.error = "Use another emal, already exists in database.";

        //        } else if (response.data === "Empty") {

        //            vm.error = "No data has been submitted, enter required information";
        //        }


        //    });
        //};





    });




    app.controller('ContactController', function ($scope, $http, ContactService) {

        console.log("ContactController");
        var vm = this;
        vm.people = [];

        //   $scope.people = vm.people;
        console.log(vm.people);

        ContactService.getData().then(function (data) {

            console.log(data);
            $scope.people = data;
            console.log($scope.people);
        });
        
        //$scope.savePerson = function () {
        //    console.log($scope.newperson);
        //    ContactService.save($scope.newperson);
        //    $scope.newperson = {};
        //}

    });


})();






//vm.people = [{
//    name: 'Kalle Persson',
//    email: 'kalle.persson@test.se',
//    phone: '070-1111111',
//    country: 'Sverige'

//},
//   {
//       name: 'Stina Karlsson',
//       email: 'stina.karlsson@test.se',
//       phone: '070-2111111',
//       country: 'Norge'
//   },

//    {
//        name: 'Anna Larsson',
//        email: 'anna.larsson@test.se',
//        phone: '070-3111111',
//        country: 'Danmark'

//    }
//];
