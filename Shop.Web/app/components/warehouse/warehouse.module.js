/// <reference path="../../../assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('shop.warehouse', ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('warehouse', {
            url: "/warehouse",
            parent: 'base',
            templateUrl: "/app/components/warehouse/warehouseListView.html",
            controller: "warehouseListController"
        }).state('add_warehouse', {
            url: "/add_warehouse",
            parent: 'base',
            templateUrl: "/app/components/warehouse/warehouseAddView.html",
            controller: "warehouseAddController"
        }).state('edit_warehouse', {
            url: "/edit_warehouse/:id",
            parent: 'base',
            templateUrl: "/app/components/warehouse/warehouseEditView.html",
            controller: "warehouseEditController"
        });
    }
})();