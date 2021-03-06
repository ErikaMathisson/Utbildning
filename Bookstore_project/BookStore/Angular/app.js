﻿(function () {
    "use strict";
    // for cache issues
    //  var version = "0.01";

    var app = angular.module('app', ['ngRoute']);

    //configure routes
    app.config(function ($routeProvider) {
        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: '/Angular/Templates/home.html',
                // two different ways to handle cache issue
                // templateUrl: '/Angular/Templates/home.html?' + new Date(),
                // templateUrl: '/Angular/Templates/home.html?' + version,

                controller: 'mainController'
            })

            // route for the register page
            .when('/register', {
                templateUrl: '/Angular/Templates/register.html',
                controller: 'registerController'
            })            
            //route for the cart page
            .when('/cart', {
                templateUrl: '/Angular/Templates/cart.html',
                controller: 'cartController'
            })          

            // route for the log in page
            .when('/logIn', {
                templateUrl: '/Angular/Templates/login.html',
                controller: 'loginController'
            })       
        ;
    });   

    //factory for the bookstore
    app.factory('bookFactory', function ($http, $window, $rootScope, $timeout) {

        var bookFactory = {};
        // for setting message to pages
        bookFactory.message = "";       
        // for added books
        bookFactory.books = [];        
        // if user is logged in
        bookFactory.isAuthorized = false;
        // what role the user has
        bookFactory.userRole = null;
        // what user name the user has
        bookFactory.userName = null;
        // for items in cart
        bookFactory.cart = [];
        // total amount in cart
        bookFactory.totalAmount = 0;

        // for checking if user is logged in, what role the user has and what username the user has
        $http.post("/Person/IsLoggedIn").then(function (response) {
            if (response.data.status === true) {
                bookFactory.isAuthorized = true;
                //setting what type of role the user has
                bookFactory.userRole = response.data.role;
                console.log(bookFactory.userRole);
                //setting the username for the user
                bookFactory.userName = response.data.userName;
            }
        });

        //function for register a person
        bookFactory.registerPerson = function (person) {
            return $http.post('/Person/RegisterPerson', person)
                .success(function (data) {
                    //check if error message is returned, in that case sent it to the controller               
                    if (data === "EmailExists") {
                        bookFactory.message = "Email already exist, please re enter your information!";
                    }
                    else if (data === "Empty") {
                        bookFactory.message = "No data has been submitted, enter required information!";
                    }
                    else if (data === "UserNameExists") {
                        bookFactory.message = "User name already exist, please re enter your information!";
                    }
                        //person is saved to database
                    else if (data === "Success") {
                        bookFactory.message = "Success";
                    }
                    else {
                        // model isn't valid set the error message/messages
                        bookFactory.message = data;
                    }
                })
        .error(function () {
            console.log("Error");
        });

        };

        //function for logging in a person
        bookFactory.logInPerson = function (logInPerson) {
            return $http.post('/Person/LogInPerson', logInPerson)
                .success(function (data) {
                    //check if error message is returned, in that case sent it to the controller               
                    if (data.status === "Failure") {
                        bookFactory.message = "No data has been submitted, something went wrong!";
                    }
                        //person is logged in ok
                    else if (data.status === "Success") {
                        bookFactory.message = "Person logged in ok";
                        //$timeout(function () {
                        // the user is logged in ok setting isAuthorized and what role the user has
                        bookFactory.isAuthorized = true;
                        bookFactory.userRole = data.role;
                        bookFactory.userName = data.userName;
                        //});
                        // todo: redirect??
                        $window.location.href = "#/";
                    }
                    else {
                        // model isn't valid set the error message/messages            
                        bookFactory.message = data;
                    }
                })
            .error(function () {
                console.log("Error");
            });
        };

        //function for getting books from database
        bookFactory.getBooks = function () {
            return $http.get('/Book/GetBooks')
            .success(function (data) {
                //books fetched ok, set the returned data to the array
                bookFactory.books = data;
            })
            .error(function () {
                // setting error message
                bookFactory.message = "Something went wrong when fetching books...";
            });
        };

        //function for adding a book
        bookFactory.addBook = function (book) {
            return $http.post('/Book/AddBook', book)
                .success(function (data) {
                    //book is saved to database
                    if (data.status === "Success") {
                        bookFactory.message = "Success";
                        // add the book to the book array
                        bookFactory.books.push(data.addedBook);
                    }
                    else if (data.status === "ISBNExist") {
                        bookFactory.message = "Entered ISBN already exist";
                    }
                    else if (data.status === "DBFailure") {
                        bookFactory.message = "Something went wrong when saving the new book, try again.";                       
                    }
                    else {
                        // model from MVC isn't valid set the error message/messages
                        bookFactory.message = data;
                    }
                })
                .error(function () {
                    console.log("Error");
                });

        };

        //function for getting a specific book from book array and returning it
        bookFactory.getBook = function (Id) {
            for (var i in bookFactory.books) {
                if (bookFactory.books[i].Id === Id) {
                    return bookFactory.books[i];
                }
            }
        };

        //function for editing an existing book
        bookFactory.editBook = function (book) {
            return $http.post('/Book/EditBook', book)
            .success(function (data) {
                //book is updated to database
                if (data.status === "Success") {
                    bookFactory.message = "Success";
                    //find the book in array using Id and update it
                    for (var i in bookFactory.books) {
                        if (bookFactory.books[i].Id == book.Id) {
                            bookFactory.books[i] = book;
                        }
                    }
                }
                else if (data.status === "ISBNExist") {
                    bookFactory.message = "Entered ISBN already exist";
                }
                else if (data.status === "DBFailure") {
                    bookFactory.message = "Something went wrong when saving the new book, try again.";                   
                }
                else {
                    // model isn't valid set the error message/messages
                    bookFactory.message = data;
                }
            })
            .error(function () {
                console.log("Error");
            });
        };       

        //function for getting cart
        // need to use session in order to keep the cart if page is refreshed
        bookFactory.getCart = function () {
            // get cart session
            var cartSession = JSON.parse(sessionStorage.getItem('cart'));
            // check if session is null in that case it first time used and needs to be fetched from bookfactory cart
            if (cartSession === null) {
                sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
            }
            // set session to bookFactory cart otherwise cart will be empty if page is refreshed
            bookFactory.cart = JSON.parse(sessionStorage.getItem('cart'));
            return bookFactory.cart;
        };

        // function for getting the total amount in cart
        bookFactory.getTotalAmount = function () {
            var currentAmount = 0;
            // loop through the cart and add items and prices together
            for (var j in bookFactory.cart) {
                currentAmount = currentAmount + bookFactory.cart[j].Price * bookFactory.cart[j].NoOfItem;
            }
            // setting the current amount to bookfactory
            bookFactory.totalAmount = currentAmount;            
            return bookFactory.totalAmount;
        };     

        // function for adding selected book to the cart
        bookFactory.addBookToCart = function (Id) {           
            // variable for checking if item exist in cart
            var exist = false;
            // loop through the cart and check if added book already exist in cart
            for (var j in bookFactory.cart) {
                if (bookFactory.cart[j].Id === Id) {                    
                    //the added book already exist in cart
                    exist = true;
                    //check is NoOfItem is undefined                   
                    if (bookFactory.cart[j].NoOfItem === undefined) {
                        var bookToAdd = bookFactory.cart[j];
                        // add the parameter NoOfItem to the book who should be added to cart, 
                        // set the parameter to value 1 since it's the first added book of that type
                        bookToAdd.NoOfItem = 1;
                        // add the book to the cart
                        bookFactory.cart.push(bookToAdd);
                        // set the cart to the session so it doesn't disapear if page is refreshed
                        sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
                    }
                    else {
                        // the added book already exist in cart update parameter NoOfItem and set the cart to session                       
                        var noOfItem = bookFactory.cart[j].NoOfItem;
                        noOfItem = parseInt(noOfItem);
                        noOfItem = noOfItem + 1;
                        bookFactory.cart[j].NoOfItem = noOfItem;
                        sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
                    }
                }
            }
           
            // the book doesn't exist in cart
            if (exist === false) {
                // loop through the list of books to find the book who should be added to cart
                for (var i in bookFactory.books) {
                    if (bookFactory.books[i].Id === Id) {
                        var bookToAdd = bookFactory.books[i];
                        // add the parameter NoOfItem to the book and set value to 1 since it's first book of that kind to be added 
                        bookToAdd.NoOfItem = 1;
                        // add the book to cart
                        bookFactory.cart.push(bookToAdd);
                        // set the cart to session so it doesn't disapear if page is refreshed
                        sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
                    }
                }
            }          
        };

        // function for removing a book from a cart
        bookFactory.removeBookFromCart = function (Id) {
            var currentCart = JSON.parse(sessionStorage.getItem('cart'));
            // loop through the cart for finding the book whom should be removed
            for (var i in bookFactory.cart) {
                if (bookFactory.cart[i].Id === Id) {
                    // update the total amount in cart based on removed book
                    var removeFromTotal = bookFactory.cart[i].Price * bookFactory.cart[i].NoOfItem;
                    var newTotalAmount = bookFactory.totalAmount - removeFromTotal;
                    // set the new total amount to factory amount
                    bookFactory.totalAmount = newTotalAmount;
                    //remove the book from cart
                    bookFactory.cart.splice(i, 1);
                    //set cart and totalamount to session
                    sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
                    sessionStorage.setItem('totalAmount', JSON.stringify(bookFactory.totalAmount));
                }
            }
        };

        //function for updating a cart
        bookFactory.updateCart = function (book) {
            // fetch current cart
            var currentCart = JSON.parse(sessionStorage.getItem('cart'));
            // loop through the cart to find book who should be updated
            for (var i in bookFactory.cart) {
                if (bookFactory.cart[i].Id === book.Id) {
                    // update the total amount based on updated book in cart
                    var oldSum = bookFactory.cart[i].Price * bookFactory.cart[i].NoOfItem;
                    bookFactory.cart[i] = book;
                    var newSum = bookFactory.cart[i].Price * bookFactory.cart[i].NoOfItem;
                    bookFactory.totalAmount = bookFactory.totalAmount - oldSum + newSum;
                    //updated session with updated cart
                    sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
                }
            }
        };

        return bookFactory;
    });

    //  main controller with $scope injected
    app.controller('mainController', function ($scope, $rootScope, bookFactory, $location, $window) {
       // $scope.message = 'This is the main page';

        $scope.message = 'Welcome to the bookstore!';

        //setting books
        $scope.books = bookFactory.books;
        // book from ng-model
        $scope.addbook = {};

        // checking and setting if user is logged in and what role the user has 
        $rootScope.$watch(function () {
            return bookFactory.isAuthorized;
        }, function (n, o) {
            if (n === true) {
                //setting loggedIn and role to the user
                $scope.isLoggedIn = true;
                $scope.role = bookFactory.userRole;
                $scope.userName = bookFactory.userName;
            }
        });
        // for setting the location to load
        $scope.go = function (path) {
            $location.path(path);
        };

        //function for setting the array of books to the scope
        bookFactory.getBooks().then(function () {
            $scope.books = bookFactory.books;            
        });

        //function for adding or edit a book
        this.saveBook = function () {
            // getting addbook from scope
            var addbook = $scope.addbook;
            //check if the book already exist (should be edited) or not (should be added)
            if (addbook.Id == null) {
                //book doesn't exist, call the addBook function in factory
                bookFactory
                .addBook($scope.addbook)
                .then(function () {
                    //check if a message is returned from factory and not "Success" in that case print the message on the page                   
                    if (bookFactory.message !== "Success") {
                        $scope.statusMessage = bookFactory.message;
                    }
                    else {
                        $scope.books = bookFactory.books;
                        $scope.addbook = {};
                        $scope.statusMessage = "";
                    }
                });
            }
            else {
                //the book already exists and should be edited                  
                bookFactory.editBook(addbook)
               .then(function () {
                   //check if any message is returned and set it to the status scope
                   if (bookFactory.message != "Success") {
                       $scope.statusMessage = bookFactory.message;
                   }
                   else {
                       $scope.books = bookFactory.books;
                       $scope.addbook = {};
                       $scope.statusMessage = "";
                   }
               });
            }
        };

        //function for copying information about a specific book and paste the information to the form 
        this.edit = function (Id) {           
            $scope.addbook = angular.copy(bookFactory.getBook(Id));
        };

        //function for adding a book to the cart
        this.addBookToCart = function (Id) {
            bookFactory.addBookToCart(Id);
            $scope.cart = JSON.parse(sessionStorage.getItem('cart'));
            $window.alert("Book added to cart!");
        };
    });

    //controller for handling registration
    app.controller('registerController', function ($scope, $window, bookFactory) {
        // message for the page
        $scope.message = 'Please enter stated information in order to register!';
        // person from ng-model
        $scope.person = {};

        //function for register a person
        this.registerPerson = function () {
            //call the registerPerson function in factory
            bookFactory
            .registerPerson($scope.person)
            .then(function () {
                //check if a message is returned from factory in that case print the message on the page
                if (bookFactory.message.length !== 0) {
                    $scope.statusMessage = bookFactory.message;
                }
                //   $window.location.href = "#/";
            });
        };
    });  

    // controller for handling log in
    app.controller('loginController', function ($scope, $window, bookFactory, $rootScope, $timeout) {
        //message for log in page
        $scope.message = 'Please enter username and password in order to log in';
        // person who will log in from ng-model
        var logInPerson = $scope.login;

        //function for logging in a user
        this.logInPerson = function () {
            //call the log in function in factory
            bookFactory.logInPerson($scope.login)
            .then(function () {
                // checking if the user is logged in 
                if (bookFactory.isAuthorized) {
                    $timeout(function () {
                        // setting that user is logged in
                        $rootScope.isAuthorized = true;
                        // setting what role the user has
                        $rootScope.userRole = bookFactory.userRole;
                        $rootScope.$apply();
                    }, 0);
                }
                //check if message is returned from factory in that case print the message on the page
                if (bookFactory.message.length !== 0) {
                    if (bookFactory.message === "Success") {
                        $window.location.href = "#/";
                    }
                    else {
                        $scope.statusMessage = bookFactory.message;
                    }
                }
            });
        };

        //function for cancelling the form input and setting the fields to empty
        this.reset = function () {
            $scope.login = {};
            $scope.statusMessage = "";
        }
    });

    // controller for the cart
    app.controller('cartController', function ($scope, bookFactory, $window, $timeout, $location) {

        //message for cart page
        $scope.message = 'Please choose checkout in order to make an order';
        //setting cart
        $scope.cart = bookFactory.cart;

        // for watching the totalamount value and update it if changed
        $scope.$watch(function () {
            return bookFactory.totalAmount;
        }, function (newValue, oldValue) {
            if (newValue !== oldValue) {
                $scope.totalAmount = bookFactory.totalAmount;
            }
        });

        //function for getting cart
        bookFactory.getCart()
        {
            $scope.cart = bookFactory.cart;
            // check if any items exist in cart, in that case show information and buttons regarding checkout, on cart page
            if (bookFactory.cart.length !== 0) {
                $scope.showCheckout = true;
            }
            else {
                $scope.showCheckout = false;
            }
        };

        //function for getting the total amount
        bookFactory.getTotalAmount()
        {
            $scope.totalAmount = bookFactory.totalAmount;
        };

        //function for deleting book from cart
        this.deleteFromCart = function (Id) {
            bookFactory.removeBookFromCart(Id);
            $scope.totalAmount = bookFactory.totalAmount;
        };

        //function for updateing a book in cart
        this.updateCart = function (book) {
            bookFactory.updateCart(book);
            bookFactory.getTotalAmount()
            {
                $scope.totalAmount = bookFactory.totalAmount;
            };
            $scope.totalAmount = bookFactory.totalAmount;
        };

        // function for clearing the cart
        this.clearCart = function () {
            bookFactory.cart = [];
            $scope.cart = bookFactory.cart;
            sessionStorage.setItem('cart', JSON.stringify(bookFactory.cart));
            $location.path('/');
        };
    });
})();