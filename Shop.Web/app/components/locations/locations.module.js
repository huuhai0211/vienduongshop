/// <reference path="../../../assets/admin/libs/angular-1.7.2/angular.js" />
(function () {
    angular.module('shop.locations', ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('locations', {
            url: "/locations",
            parent: 'base',
            templateUrl: "/app/components/locations/locationListView.html",
            controller: "locationListController"
        }).state('add_location', {
            url: "/add_location",
            parent: 'base',
            templateUrl: "/app/components/locations/locationAddView.html",
            controller: "locationAddController"
        }).state('edit_location', {
            url: "/edit_location/:id",
            parent: 'base',
            templateUrl: "/app/components/locations/locationEditView.html",
            controller: "locationEditController"
        });
    }
})();