(function () {
    //defining the angular module
    var app = angular.module('app', []);
    // creating a factory
    app.factory('PeopleFactory', function PeopleFactory($location, $http) {
        var PeopleFactory = {};
        //defining people array
        PeopleFactory.people = [];
        // defining message
        PeopleFactory.message = "";

        //function for getting people from database
        PeopleFactory.getPeople = function () {
            return $http.get('/Home/GetPeople')
            .success(function (data) {
                //people fetched ok set the returned data to the array
                PeopleFactory.people = data;
            })
            .error(function () {
                // setting error message
                PeopleFactory.message = "Something went wrong...";
            });
        };

        //function for saving a new person to the database
        PeopleFactory.savePerson = function (person) {
            return $http.post('/Home/AddPerson', person)
            .success(function (data) {
                //check if error message is returned, in that case sent it to the controller               
                if (data === "EmailExists") {
                    PeopleFactory.message = "Email already exist, please re enter your information!";
                }
                else if (data === "Empty") {
                    PeopleFactory.message = "No data has been submitted, enter required information!";
                }
                else if (data === "NonValid") {
                    PeopleFactory.message = "All required information not entered or in wrong format, try again!";
                }
                    //person is saved to database, push the data to the array
                else {
                    PeopleFactory.people.push(data);
                }
            })
            .error(function () {
                console.log("Error");
            });
        };

        //function for editing an existing person
        PeopleFactory.editPerson = function (person) {
            return $http.post('/Home/EditPerson', person)
            .success(function (data) {
                //check if error message is returned, set it to the message property
                if (data === "EmailExists") {
                    PeopleFactory.message = "Email already exist, please re enter your information!";
                }
                else if (data === "Empty") {
                    PeopleFactory.message = "No data has been submitted, enter required information!";
                }
                else if (data === "NonValid") {
                    PeopleFactory.message = "All required information not entered or in wrong format, try again!";
                }
                else {
                    //find the person using id and update it
                    for (var i in PeopleFactory.people) {
                        if (PeopleFactory.people[i].id == person.id) {
                            PeopleFactory.people[i] = person;
                        }
                    }
                }
            })
            .error(function () {
                console.log("Error");
            });
        };

        //function for deleting a person from database
        PeopleFactory.deletePerson = function (person) {
            return $http.post('/Home/DeletePerson', person)
            .success(function (data) {
                //check if error code is returned, in that case set message property with correct message
                if (data === "Error") {
                    PeopleFactory.message = "Something went wrong, nothing is deleted";
                }
                else {
                    //go through the array of people and remove the person that is removed from database
                    for (var i in PeopleFactory.people) {
                        if (PeopleFactory.people[i].id == person.id) {
                            PeopleFactory.people.splice(i, 1);
                        }
                    }
                }

            })
            .error(function () {
                console.log("Error");
            });
        };

        //function for getting a person with a specific id and returning it
        PeopleFactory.get = function (id) {
            for (var i in PeopleFactory.people) {
                if (PeopleFactory.people[i].id == id) {
                    return PeopleFactory.people[i];
                }
            }
        };
        return PeopleFactory;
    });

    //main controller
    app.controller('MainController', function MainController($scope, $http, PeopleFactory) {
        //setting people
        $scope.people = PeopleFactory.people;

        //function for setting the array of people to the scope
        PeopleFactory
            .getPeople()
        .then(function () {
            $scope.people = PeopleFactory.people;
        });  

        //function for copying information about a specific person and paste the information to the form 
        this.edit = function (id) {
            $scope.newperson = angular.copy(PeopleFactory.get(id));
        }       

        //function for deleting a person
        this.delete = function (id) {
            //call deletePerson function in factory 
            PeopleFactory
            .deletePerson(PeopleFactory.get(id))
            .then(function () {
                //a message is returned from the factory, print it to the status scope
                if (PeopleFactory.message.length != 0) {
                    $scope.status = PeopleFactory.message;
                }
            });
        };

    });


    //controller for adding and editing a person
    app.controller('AddPersonController', function ($http, PeopleFactory, $scope) {

        $scope.people = PeopleFactory.people;
        var person = $scope.newperson;

        //function for cancelling the form input and setting the fields to empty
        this.cancel = function () {
            $scope.newperson = {};
            $scope.status = "";
        }

        //function for saving a person, either if it's a new person to be added or a person whom should be edited
        this.savePerson = function savePerson(person) {
            //getting newperson from scope
            var person = $scope.newperson;
            //if the person id is null, a new person should be added otherwise an existing person should be edited
            if (person.id == null) {
                //call the savePerson function in factory
                PeopleFactory
                .savePerson(person)
                .then(function () {
                    //check if a message is returned from factory in that case print set it to the status scope
                    if (PeopleFactory.message.length != 0) {
                        $scope.status = PeopleFactory.message;
                    }
                    else {
                        // set the list of people from factory to the people scope 
                        $scope.people = PeopleFactory.people;
                        // set the newperson form to be empty
                        //    $scope.newperson = {};
                        //set the status scope to be empty
                        $scope.status = "";

                    }
                });
            }
            else {
                //the person already exists and should be edited                
                PeopleFactory
               .editPerson(person)
               .then(function () {
                   //check if any message is returned and set it to the status scope
                   if (PeopleFactory.message.length != 0) {
                       $scope.status = PeopleFactory.message;
                   }
                   else {
                       $scope.people = PeopleFactory.people;
                       //   $scope.newperson = {};
                       //    $scope.status = "";

                       console.log(PeopleFactory.message);
                   }
               });
            }         
        }
    });
})();

