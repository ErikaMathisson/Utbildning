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

