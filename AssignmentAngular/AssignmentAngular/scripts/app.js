(function () {
    var app = angular.module('assignment', []);
    app.controller('StoreController', function () {
        this.products = gems;
    });

    var gems = [
        {
            name: 'Dodecahedron',
            price: 2.95,
            description: 'this is a gem, bla bla bla',
            canPurchase: true,
            soldOut: false,
            images: [
                {
                    full: 'full_img.jpg',
                    thumb: 'thumb_img.jpg'
                },

            ],
        },
        {
            name: 'Pentagonal gem',
            price: 5,
            description: 'this is another gem...',
            canPurchase: false,
            soldOut: false,
        }
    ];



    app.controller('PanelController', function () {
        this.tab = 1;
        this.selectTab = function (setTab) {
            this.tab = setTab;
        };
        this.isSelected = function (checkTab) {
            return this.tab === checkTab;

        }

    });

})();


//(function () {
//    var app = angular.module('gemStore', []);

//    app.controller('StoreController', function () {
//        this.products = gems;
//    });

//    app.controller('TabController', function () {
//        this.tab = 1;

//        this.setTab = function (tab) {
//            this.tab = tab;
//        };

//        this.isSet = function (tab) {
//            return (this.tab === tab);
//        };
//    });

//    app.controller('GalleryController', function () {
//        this.current = 0;

//        this.setCurrent = function (index) {
//            this.current = index;
//        };
//    });

//    app.controller('ReviewController', function () {
//        this.review = {};

//        this.addReview = function (product) {
//            product.reviews.push(this.review);

//            this.review = {};
//        };
//    });

//    var gems = [{
//        name: 'Azurite',
//        description: "Some gems have hidden qualities beyond their luster, beyond their shine... Azurite is one of those gems.",
//        shine: 8,
//        price: 110.50,
//        rarity: 7,
//        color: '#CCC',
//        faces: 14,
//        images: [
//          "images/gem-02.gif",
//          "images/gem-05.gif",
//          "images/gem-09.gif"
//        ],
//        reviews: [{
//            stars: 5,
//            body: "I love this gem!",
//            author: "joe@example.org",
//            createdOn: 1397490980837
//        }, {
//            stars: 1,
//            body: "This gem sucks.",
//            author: "tim@example.org",
//            createdOn: 1397490980837
//        }]
//    }, {
//        name: 'Bloodstone',
//        description: "Origin of the Bloodstone is unknown, hence its low value. It has a very high shine and 12 sides, however.",
//        shine: 9,
//        price: 22.90,
//        rarity: 6,
//        color: '#EEE',
//        faces: 12,
//        images: [
//          "images/gem-01.gif",
//          "images/gem-03.gif",
//          "images/gem-04.gif",
//        ],
//        reviews: [{
//            stars: 3,
//            body: "I think this gem was just OK, could honestly use more shine, IMO.",
//            author: "JimmyDean@example.org",
//            createdOn: 1397490980837
//        }, {
//            stars: 4,
//            body: "Any gem with 12 faces is for me!",
//            author: "gemsRock@example.org",
//            createdOn: 1397490980837
//        }]
//    }, {
//        name: 'Zircon',
//        description: "Zircon is our most coveted and sought after gem. You will pay much to be the proud owner of this gorgeous and high shine gem.",
//        shine: 70,
//        price: 1100,
//        rarity: 2,
//        color: '#000',
//        faces: 6,
//        images: [
//          "images/gem-06.gif",
//          "images/gem-07.gif",
//          "images/gem-08.gif"
//        ],
//        reviews: [{
//            stars: 1,
//            body: "This gem is WAY too expensive for its rarity value.",
//            author: "turtleguyy@example.org",
//            createdOn: 1397490980837
//        }, {
//            stars: 1,
//            body: "BBW: High Shine != High Quality.",
//            author: "LouisW407@example.org",
//            createdOn: 1397490980837
//        }, {
//            stars: 1,
//            body: "Don't waste your rubles!",
//            author: "nat@example.org",
//            createdOn: 1397490980837
//        }]
//    }];
//})();



///////////////////////////////////////////////////
(function () {
    var app = angular.module('gemStore', ['store-directives']);

    app.controller('StoreController', function () {
        this.products = gems;
    });

    app.controller('ReviewController', function () {
        this.review = {};

        this.addReview = function (product) {
            product.reviews.push(this.review);

            this.review = {};
        };
    });


    var gems = [{
        name: 'Azurite',
        description: "Some gems have hidden qualities beyond their luster, beyond their shine... Azurite is one of those gems.",
        shine: 8,
        price: 110.50,
        rarity: 7,
        color: '#CCC',
        faces: 14,
        images: [
          "images/gem-02.gif",
          "images/gem-05.gif",
          "images/gem-09.gif"
        ],
        reviews: []
    }, {
        name: 'Bloodstone',
        description: "Origin of the Bloodstone is unknown, hence its low value. It has a very high shine and 12 sides, however.",
        shine: 9,
        price: 22.90,
        rarity: 6,
        color: '#EEE',
        faces: 12,
        images: [
          "images/gem-01.gif",
          "images/gem-03.gif",
          "images/gem-04.gif",
        ],
        reviews: []
    }, {
        name: 'Zircon',
        description: "Zircon is our most coveted and sought after gem. You will pay much to be the proud owner of this gorgeous and high shine gem.",
        shine: 70,
        price: 1100,
        rarity: 2,
        color: '#000',
        faces: 6,
        images: [
          "images/gem-06.gif",
          "images/gem-07.gif",
          "images/gem-08.gif"
        ],
        reviews: []
    }];
})();



/////////////////////////////////////////////////////////////

(function () {
    var app = angular.module('store-directives', []);

    app.directive("productDescription", function () {
        return {
            restrict: 'E',
            templateUrl: "product-description.html"
        };
    });

    app.directive("productReviews", function () {
        return {
            restrict: 'E',
            templateUrl: "product-reviews.html"
        };
    });

    app.directive("productSpecs", function () {
        return {
            restrict: "A",
            templateUrl: "product-specs.html"
        };
    });

    app.directive("productTabs", function () {
        return {
            restrict: "E",
            templateUrl: "product-tabs.html",
            controller: function () {
                this.tab = 1;

                this.isSet = function (checkTab) {
                    return this.tab === checkTab;
                };

                this.setTab = function (activeTab) {
                    this.tab = activeTab;
                };
            },
            controllerAs: "tab"
        };
    });

    app.directive("productGallery", function () {
        return {
            restrict: "E",
            templateUrl: "product-gallery.html",
            controller: function () {
                this.current = 0;
                this.setCurrent = function (imageNumber) {
                    this.current = imageNumber || 0;
                };
            },
            controllerAs: "gallery"
        };
    });


})();
//////////////////////////////////////////////  last////////////////////////////////////

// app.js
(function () {
    var app = angular.module('gemStore', ['store-directives']);

    app.controller('StoreController', ['$http', function ($http) {
        var store = this;
        store.products = [];

        $http.get('/store-products.json').success(function (data) {
            store.products = data;
        });
    }]);

    app.controller('ReviewController', function () {
        this.review = {};

        this.addReview = function (product) {
            product.reviews.push(this.review);

            this.review = {};
        };
    });
})();
///////////////////////////////////////////////////////////////////////

// store-products.json

[
  {
      "name": "Azurite",
      "description": "Some gems have hidden qualities beyond their luster, beyond their shine... Azurite is one of those gems.",
      "shine": 8,
      "price": 110.50,
      "rarity": 7,
      "color": "#CCC",
      "faces": 14,
      "images": [
        "images/gem-02.gif",
        "images/gem-05.gif",
        "images/gem-09.gif"
      ],
      "reviews": []
  },
  {
      "name": "Bloodstone",
      "description": "Origin of the Bloodstone is unknown, hence its low value. It has a very high shine and 12 sides, however.",
      "shine": 9,
      "price": 22.90,
      "rarity": 6,
      "color": "#EEE",
      "faces": 12,
      "images": [
        "images/gem-01.gif",
        "images/gem-03.gif",
        "images/gem-04.gif"
      ],
      "reviews": []
  },
  {
      "name": "Zircon",
      "description": "Zircon is our most coveted and sought after gem. You will pay much to be the proud owner of this gorgeous and high shine gem.",
      "shine": 70,
      "price": 1100,
      "rarity": 2,
      "color": "#000",
      "faces": 6,
      "images": [
        "images/gem-06.gif",
        "images/gem-07.gif",
        "images/gem-08.gif"
      ],
      "reviews": []
  }
]


///////////////////////////////////////////////

// products.js
(function () {
    var app = angular.module('store-directives', []);

    app.directive("productDescription", function () {
        return {
            restrict: 'E',
            templateUrl: "product-description.html"
        };
    });

    app.directive("productReviews", function () {
        return {
            restrict: 'E',
            templateUrl: "product-reviews.html"
        };
    });

    app.directive("productSpecs", function () {
        return {
            restrict: "A",
            templateUrl: "product-specs.html"
        };
    });

    app.directive("productTabs", function () {
        return {
            restrict: "E",
            templateUrl: "product-tabs.html",
            controller: function () {
                this.tab = 1;

                this.isSet = function (checkTab) {
                    return this.tab === checkTab;
                };

                this.setTab = function (activeTab) {
                    this.tab = activeTab;
                };
            },
            controllerAs: "tab"
        };
    });

    app.directive("productGallery", function () {
        return {
            restrict: "E",
            templateUrl: "product-gallery.html",
            controller: function () {
                this.current = 0;
                this.setCurrent = function (imageNumber) {
                    this.current = imageNumber || 0;
                };
            },
            controllerAs: "gallery"
        };
    });
})();


//////////////////////////////////////////////////////////////////////

