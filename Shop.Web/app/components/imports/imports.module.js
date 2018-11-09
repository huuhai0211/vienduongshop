/// <reference path="../../../assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('shop.imports', ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('imports', {
            url: "/imports",
            parent: 'base',
            templateUrl: "/app/components/imports/importListView.html",
            controller: "importListController"
        }).state('add_import', {
            url: "/add_import",
            parent: 'base',
            templateUrl: "/app/components/imports/importAddView.html",
            controller: "importAddController"
        }).state('edit_import', {
            url: "/edit_import/:id",
            parent: 'base',
            templateUrl: "/app/components/imports/importEditView.html",
            controller: "importEditController"
        });
    }
})();