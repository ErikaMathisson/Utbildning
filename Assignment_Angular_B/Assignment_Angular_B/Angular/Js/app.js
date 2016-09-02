(function () {

    var app = angular.module('app', []);

    app.factory('PeopleFactory', function PeopleFactory($location, $http) {

        PeopleFactory.people = [];
        PeopleFactory.message = "";
        //  $scope.status = "";
        // var person;

        PeopleFactory.getPeople = function () {
            return $http.get('/Home/GetPeople')
            .success(function (data) {
                PeopleFactory.people = data;
                //    console.log(data);
            })
            .error(function () {
                console.log("Error");
                // NotificationFactory.showError();
            });
        };

        PeopleFactory.savePerson = function (person) {
            return $http.post('/Home/AddPerson', person)
            .success(function (data) {
                console.log(PeopleFactory.message);
                console.log(PeopleFactory.message.length);

                if (data === "EmailExists") {

                    console.log("Email exists");
                    PeopleFactory.message = "Email already exist, please re enter your information!";
                    console.log(PeopleFactory.message);


                }
                else if (data === "Empty") {

                    console.log("Empty");
                    PeopleFactory.message = "No data has been submitted, enter required information!";



                }
                else if (data === "NonValid") {

                    console.log("NonValid");
                    PeopleFactory.message = "All required information not entered or in wrong format, try again!";
                }


                else {
                    console.log(data);
                    console.log(PeopleFactory.people);
                    PeopleFactory.people.push(data);
                    console.log(PeopleFactory.people);

                }

            })
            .error(function () {
                console.log("Error");
                // NotificationFactory.showError();
            });
        };


        //  Repository.people.splice(i,1) 1 betyder ta bort
        //Repository.people.splice(i,0, vm.person) 0 betyder lägg till


        PeopleFactory.editPerson = function (person) {
            return $http.post('/Home/EditPerson', person)
            .success(function (data) {
                console.log(PeopleFactory.message);
                console.log(PeopleFactory.message.length);

                if (data === "EmailExists") {

                    console.log("Email exists");
                    PeopleFactory.message = "Email already exist, please re enter your information!";
                    console.log(PeopleFactory.message);


                }
                else if (data === "Empty") {

                    console.log("Empty");
                    PeopleFactory.message = "No data has been submitted, enter required information!";



                }
                else if (data === "NonValid") {

                    console.log("NonValid");
                    PeopleFactory.message = "All required information not entered or in wrong format, try again!";
                }


                else {
                    console.log(data);
                    console.log(PeopleFactory.people);

                    //for existing contact, find this contact using id
                    //            //and update it.
                    for (var i in PeopleFactory.people) {

                        console.log(PeopleFactory.people[i]);
                        console.log(PeopleFactory.people[i].id);
                        console.log(person.id);

                        if (PeopleFactory.people[i].id == person.id) {
                            PeopleFactory.people[i] = person;
                        }
                    }




                    console.log(PeopleFactory.people);

                }

            })
            .error(function () {
                console.log("Error");
                // NotificationFactory.showError();
            });
        };


        //todo: check this function

        PeopleFactory.deletePerson = function (person) {
            return $http.post('/Home/DeletePerson', person)
            .success(function (data) {
                console.log(PeopleFactory.message);
                console.log(PeopleFactory.message.length);

                if (data === "Error") {

                    console.log("Error");
                    PeopleFactory.message = "Something went wrong, nothing is deleted";
                    console.log(PeopleFactory.message);


                } else {
                    console.log(data);
                    console.log(PeopleFactory.people);

                    for (var i in PeopleFactory.people) {
                        if (PeopleFactory.people[i].id == id) {
                            PeopleFactory.people.splice(i, 1);
                        }
                    }

                    console.log(PeopleFactory.people);

                }

            })
            .error(function () {
                console.log("Error");
                // NotificationFactory.showError();
            });
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
        //            vm.error = "Use another email, already exists in database.";

        //        } else if (response.data === "Empty") {

        //            vm.error = "No data has been submitted, enter required information";
        //        }


        //    });

        //};

        PeopleFactory.get = function (id) {
            console.log(PeopleFactory.people);
            for (var i in PeopleFactory.people) {
                if (PeopleFactory.people[i].id == id) {

                    console.log(PeopleFactory.people[i]);
                    return PeopleFactory.people[i];
                }
            }

        };


       









        return PeopleFactory;

    });

    app.controller('DeletePersonController', function DeletePersonController($scope, $http, PeopleFactory) {

        $scope.people = PeopleFactory.people;

        this.delete = function (id) {
            PeopleFactory
            .deletePerson(id)
            .then(function () {

                if (PeopleFactory.message.length != 0) {
                    $scope.status = PeopleFactory.message;
                }
                else {
                    $scope.newperson = {};
                    $scope.status = "";
                    console.log("Clear status");
                    $scope.people = PeopleFactory.people;
                    console.log(PeopleFactory.message);
                }
            });






            PeopleFactory
                .getPeople()
            .then(function () {
                $scope.people = PeopleFactory.people;
            });

        };





    });


    app.controller('MainController', function MainController($scope, $http, PeopleFactory) {

        $scope.people = PeopleFactory.people;

        this.edit = function (id) {
            console.log("edit och get");
            console.log(PeopleFactory.get(id));
            $scope.newperson = angular.copy(PeopleFactory.get(id));
        }


        PeopleFactory
            .getPeople()
        .then(function () {
            $scope.people = PeopleFactory.people;
        });

    });


    app.controller('AddPersonController', function ($http, PeopleFactory, $scope) {

        //$scope.people = PeopleFactory.people;
        //var person = $scope.newperson;
        //console.log(person);

        //   addPerson(person);
        console.log("Addpersoncontroller");

        this.cancel = function () {
            $scope.newperson = {};
            $scope.status = "";
        }




        this.savePerson = function savePerson(person) {
            var person = $scope.newperson;
            console.log(person);

            if (person.id == null) {

                PeopleFactory
                .savePerson(person)
                .then(function () {

                    if (PeopleFactory.message.length != 0) {
                        $scope.status = PeopleFactory.message;
                    }
                    else {
                        $scope.newperson = {};
                        $scope.status = "";
                        console.log("Clear status");
                        $scope.people = PeopleFactory.people;
                        console.log(PeopleFactory.message);
                    }
                });
            }
            else {


                console.log("edit");


                PeopleFactory
               .editPerson(person)
               .then(function () {

                   if (PeopleFactory.message.length != 0) {
                       $scope.status = PeopleFactory.message;
                   }
                   else {
                       $scope.newperson = {};
                       $scope.status = "";
                       console.log("Clear status");
                       $scope.people = PeopleFactory.people;
                       console.log(PeopleFactory.message);
                   }
               });














            }












        }




        //this.savePerson = function savePerson(person) {
        //    var person = $scope.newperson;
        //    console.log(person);
        //    if (person.id == null && person != undefined) {
        //        console.log(person);
        //        StudentService.addPerson(person)

        //       .success(function (response) {

        //           //    $scope.people = people;
        //           console.log(response);

        //           //    console.log($scope.people);

        //       })

        //       .error(function (error) {

        //           $scope.status = 'Unable to load customer data: ' + error.message;

        //           console.log($scope.status);

        //       });






        //    }
        //    else {
        //        // edit existing person to database


        //    }


        //};






    });



    //var vm = this;
    //vm.person = {};

    //$scope.$watch(function () {
    //    return Repository.newPerson;
    //}, function (n, o) {
    //    vm.newPerson = Repository.newPerson;
    //});

    //vm.changeFormValue = function (val) {
    //    Repository.newPerson = val;


    //};

    //for edit change change name on function call /Home/EditPerson same prinicpal
    // in order to remove the original post and add the changed post
    // Repository.people.splice(i,1) 1 betyder ta bort
    //Repository.people.splice(i,0, vm.person) 0 betyder lägg till
    // you could also set value by value for loop and then update the correct "i"
    //    vm.AddPerson = function () {
    //        $http.post("/Home/AddPerson", vm.person).then(function (response) {
    //            if (response.data === "Success") {
    //                vm.person.Id = Repository.people.length + 1;
    //                Repository.people.push(vm.person);
    //                Repository.newPerson = false;
    //                vm.person = {};

    //            }
    //            else if (response.data === "EmailExist") {
    //                vm.error = "Use another email, already exists in database.";

    //            } else if (response.data === "Empty") {

    //                vm.error = "No data has been submitted, enter required information";
    //            }


    //        });

    //    };


    //});










    //   app.factory('StudentService', function StudentService($location, NotificationFactory) {










    //   app.factory('NotificationFactory')





    //app.controller('ContactController', function ($scope, StudentService) {

    //    getStudents();

    //    function getStudents() {

    //        StudentService.getStudents()

    //            .success(function (people) {
    //                console.log(people);

    //                $scope.people = people;

    //                console.log($scope.people);

    //            })

    //            .error(function (error) {

    //                $scope.status = 'Unable to load customer data: ' + error.message;

    //                console.log($scope.status);

    //            });

    //    }

    //});



    //app.controller("AddPersonController", function ($http, $window, Repository, $scope) {
    //    var vm = this;
    //    vm.person = {};

    //    $scope.$watch(function () {
    //        return Repository.newPerson;
    //    }, function (n, o) {
    //        vm.newPerson = Repository.newPerson;
    //    });

    //    vm.changeFormValue = function (val) {
    //        Repository.newPerson = val;


    //    };

    //    //for edit change change name on function call /Home/EditPerson same prinicpal
    //    // in order to remove the original post and add the changed post
    //    // Repository.people.splice(i,1) 1 betyder ta bort
    //    //Repository.people.splice(i,0, vm.person) 0 betyder lägg till
    //    // you could also set value by value for loop and then update the correct "i"
    //    vm.AddPerson = function () {
    //        $http.post("/Home/AddPerson", vm.person).then(function (response) {
    //            if (response.data === "Success") {
    //                vm.person.Id = Repository.people.length + 1;
    //                Repository.people.push(vm.person);
    //                Repository.newPerson = false;
    //                vm.person = {};

    //            }
    //            else if (response.data === "EmailExist") {
    //                vm.error = "Use another email, already exists in database.";

    //            } else if (response.data === "Empty") {

    //                vm.error = "No data has been submitted, enter required information";
    //            }


    //        });

    //    };


    //});






    //    app.controller('AddPersonController', function ($scope, StudentService) {

    //    var person = $scope.newperson;
    //    //   addPerson(person);
    //    console.log("Addpersoncontroller");

    //    this.savePerson = function savePerson(person) {
    //        var person = $scope.newperson;
    //        console.log(person);
    //        if (person.id == null && person != undefined) {
    //            console.log(person);
    //            StudentService.addPerson(person)

    //           .success(function (response) {

    //               //    $scope.people = people;
    //               console.log(response);

    //               //    console.log($scope.people);

    //           })

    //           .error(function (error) {

    //               $scope.status = 'Unable to load customer data: ' + error.message;

    //               console.log($scope.status);

    //           });






    //        }
    //        else {
    //            // edit existing person to database


    //        }


    //    };






    //});

    //app.factory('StudentService', ['$http', function ($http) {

    //    var StudentService = {};
    //    StudentService.people = [];
    // //   var people = [];      

    //    StudentService.getStudents = function () {
    //        $http.get('/Home/GetPeople').then(function (response) {
    //            StudentService.people = response.data;
    //            console.log(StudentService.people);
    //            return StudentService.people;
    //        });

    //    //   return $http.get('/Home/GetPeople');           
    //    };

    //    StudentService.addPerson = function (person) {
    //        return $http.post('/Home/AddPerson', person);           
    //    };

    //    return StudentService;
    //}]);



    //var vm = {};
    //vm.people = [];
    //$http.get('/Home/GetPeople').then(function (response) {
    //    vm.people = response.data;

    //});
    //vm.newPerson = false;
    //return vm;



    //app.factory('StudentService', ['$http', function ($http) {


    //    var StudentService = {};

    //    StudentService.people = [];

    //    StudentService.getStudents = function () {
    //        return $http.get('/Home/GetPeople');
    //    };

    //    StudentService.addPerson = function (person) {
    //        return $http.post('/Home/AddPerson', person);
    //    };

    //    return StudentService;
    //}]);






    //var app = angular.module('app', []);

    //app.service('ContactService', function () {
    //    //to create unique contact id
    //    var uid = 1;

    //    var people = [];

    //  //  vm.people = [];
    //    $http.get('/Home/GetPeople').then(function (response) {
    //        people = response.data;


    //    });

    //    //contacts array to hold list of all contacts
    //    //var people = [{
    //    //    id: 0,
    //    //    'name': 'Viral',
    //    //    'email': 'hello@gmail.com',
    //    //    'phone': '123-2343-44'
    //    //}];

    //    //save method create a new contact if not already exists
    //    //else update the existing object
    //    this.save = function (person) {
    //        var person = $scope.newperson;
    //        if (person.id == null) {
    //            //if this is new contact, add it in contacts array
    //            person.id = uid++;
    //            people.push(person);
    //        } else {
    //            //for existing contact, find this contact using id
    //            //and update it.
    //            for (i in people) {
    //                if (people[i].id == person.id) {
    //                    people[i] = person;
    //                }
    //            }
    //        }

    //    }

    //    //simply search contacts list for given id
    //    //and returns the contact object if found
    //    this.get = function (id) {
    //        for (i in people) {
    //            if (people[i].id == id) {
    //                return people[i];
    //            }
    //        }

    //    }

    //    //iterate through contacts list and delete 
    //    //contact if found
    //    this.delete = function (id) {
    //        for (i in people) {
    //            if (people[i].id == id) {
    //                people.splice(i, 1);
    //            }
    //        }
    //    }

    //    //simply returns the contacts list
    //    this.list = function () {
    //        return people;
    //    }
    //});

    //app.controller('ContactController', function ($scope, ContactService) {

    //    $scope.people = ContactService.list();

    //    $scope.savePerson = function () {
    //        ContactService.save($scope.newperson);
    //        $scope.newperson = {};
    //    }


    //    $scope.delete = function (id) {

    //        ContactService.delete(id);
    //        if ($scope.newperson.id == id) $scope.newperson = {};
    //    }


    //    $scope.edit = function (id) {
    //        $scope.newperson = angular.copy(ContactService.get(id));
    //    }
    //})

















    // var app = angular.module('app', []);

    // app.factory('ContactService', function ($http) {

    //     var ContactService = {};
    //     ContactService.people = [];

    //     return {

    //         getData: function () {
    //             var people = this.people;
    //             return $http.get('/Home/GetPeople').then(function (response) {
    //                 people = response.data;
    //              //   console.log(response.data);
    //              //   console.log(people);
    //                 return people;
    //             });
    //         }
    //     };
    //     return ContactService;
    // });

    // app.controller('AddPersonController', function ($scope, $http, ContactService) {

    ////     console.log("Addpersoncontroller");

    //     //  var person = $scope.newperson;

    //     this.cancel = function () {
    //         $scope.newperson = {};
    //     }

    //     this.savePerson = function (person) {
    //         var person = $scope.newperson;
    //    //     $scope.status = {};

    //         if (person === undefined) {
    //             $scope.status = "Enter information, please";
    //         } else {
    //             console.log(person);
    //             if (person.id == null) {
    //                 $http.post("/Home/AddPerson", person).then(function (response) {
    //                     console.log(response.data);
    //                     //  if (response.data.id != null) {
    //                     if (response.data === "Success")
    //                     {
    //                         console.log("add Person3");

    //                         console.log(response.data.id);
    //                         console.log(person);
    //                         person = response.data;
    //                         console.log(person);
    //                         //ContactService.people
    //                         //ContactService.people().then(function (data) {
    //                         //    console.log(data);
    //                         //    $scope.people = data;
    //                         //    console.log($scope.people);
    //                         //});

    //                         //        $scope.people = ContactService.people;


    //                         console.log(ContactService.people);


    //                         $scope.people.push(person);


    //                         //    ContactService.people.push(person);
    //                         console.log(ContactService.people);
    //                         //    ContactService.newPerson = false;
    //                         $scope.newperson = {};
    //                         $scope.people = ContactService.getData().then(function (data) {
    //                             console.log(data);
    //                             $scope.people = {};
    //                             console.log($scope.people);
    //                             $scope.people = data;
    //                             console.log($scope.people);

    //                         });


    //                     }
    //                     else if (response.data === "EmailExist") {
    //                         //     vm.error = "Use another emal, already exists in database.";
    //                         $scope.status = "Use another email, entered email already exist";
    //                         console.log($scope.status);

    //                     } else if (response.data === "Empty") {
    //                         $scope.status = "No data has been submitted, enter required information";
    //                         console.log($scope.status);

    //                         //     vm.error = "No data has been submitted, enter required information";
    //                     }


    //              //       console.log($scope.status);
    //                 });
    //                 //   };















    //                 //if this is new contact, add it in contacts array
    //                 //        person.id = uid++;
    //                 //        people.push(person);
    //             } else {

    //                 console.log("person exist");
    //                 //for existing contact, find this contact using id
    //                 //and update it.
    //                 for (i in people) {
    //                     if (people[i].id == person.id) {
    //                         people[i] = person;
    //                     }
    //                 }
    //             }




    //         }







    //     };





    //     /////////////////////////////////////////////


    //     ////save method create a new contact if not already exists
    //     ////else update the existing object
    //     //this.save = function (contact) {
    //     //    if (contact.id == null) {
    //     //        //if this is new contact, add it in contacts array
    //     //        contact.id = uid++;
    //     //        contacts.push(contact);
    //     //    } else {
    //     //        //for existing contact, find this contact using id
    //     //        //and update it.
    //     //        for (i in contacts) {
    //     //            if (contacts[i].id == contact.id) {
    //     //                contacts[i] = contact;
    //     //            }
    //     //        }
    //     //    }

    //     //}

    //     ////simply search contacts list for given id
    //     ////and returns the contact object if found
    //     //this.get = function (id) {
    //     //    for (i in contacts) {
    //     //        if (contacts[i].id == id) {
    //     //            return contacts[i];
    //     //        }
    //     //    }

    //     //}


















    //     /////////////////////////////////////////////////////////////









    //     //vm.AddPerson = function () {
    //     //    $http.post("/Home/AddPerson", vm.person).then(function (response) {
    //     //        if (response.data === "Success") {
    //     //            vm.person.Id = Repository.people.length + 1;
    //     //            Repository.people.push(vm.person);
    //     //            Repository.newPerson = false;
    //     //            vm.person = {};

    //     //        }
    //     //        else if (response.data === "EmailExist") {
    //     //            vm.error = "Use another emal, already exists in database.";

    //     //        } else if (response.data === "Empty") {

    //     //            vm.error = "No data has been submitted, enter required information";
    //     //        }


    //     //    });
    //     //};





    // });




    // app.controller('ContactController', function ($scope, $http, ContactService) {

    //     $scope.people = ContactService.getData().then(function (data) {
    //      //   console.log(data);
    //         $scope.people = data;
    //      //   console.log($scope.people);
    //     });

    //     //$scope.savePerson = function () {
    //     //    console.log($scope.newperson);
    //     //    ContactService.save($scope.newperson);
    //     //    $scope.newperson = {};
    //     //}

    // });


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
