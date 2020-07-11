(function () {
    var app = angular.module("ShoppingDirectory", ["ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/main", {
                templateUrl: "main.html",
                controller: "MainController"
            })
            .when("/stores/list/:categoryid",
                {
                    templateUrl: "storelist.html",
                    controller: "StoreController"
                })
            .when("/stores/edit/:storeid",
                {
                    templateUrl: "storedetails.html",
                    controller: "StoreController"
                })
            .otherwise({
                redirectTo: "/main"
            })
    });

});