(function () {

    var app = angular.module('app', []);

    //app.controller('ListPersonController', function () {
    //    this.peoples = person;
    //});

    app.controller('PanelController', function () {
        this.tab = 1;
        this.selectTab = function(setTab){
            this.tab = setTab;
        };
        this.isSelected = function (checkTab) {
            return this.tab === checkTab;
        };
    });

    app.controller('EditController', function () {
        this.edit = {};
        this.editPerson = function () {
            people.edit.push(this.edit);
            this.edit = {};

        };

    });


    //   app.controller('GetPeople', ['$http', function ($http) {
    app.controller('ListPersonController', ['$http', function ($http) {

        var app = this;
        app.peoples = [];

        $http.get('/Home/GetPeople').success(function (data) {
            app.peoples = data;    
        
        });
    }

    ]);



    var person = [{
        firstName: 'Kalle',
        lastName: 'Persson',
        email: 'kalle.persson@test.se',
        phoneNumber: '070-1111111',
        country: 'Sverige',
        img: 'logo.jpg',
        canEdit: true,
        editMode: false
    },
    {
        firstName: 'Stina',
        lastName: 'Karlsson',
        email: 'stina.karlsson@test.se',
        phoneNumber: '070-2111111',
        country: 'Norge',
        img: '2.jpg',
        canEdit: true,
        editMode: true
    },

     {
         firstName: 'Anna',
         lastName: 'Larsson',
         email: 'anna.larsson@test.se',
         phoneNumber: '070-3111111',
         country: 'Danmark',
         img: '3.jpg',
         canEdit: true,
         editMode: false
     }
    ];

 

})();