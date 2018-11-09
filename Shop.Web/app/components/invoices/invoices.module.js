/// <reference path="../../../assets/admin/libs/angular-1.7.2/angular.js" />
(function () {
    angular.module('shop.invoices', ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('invoices', {
            url: "/invoices",
            //parent: 'base',
            templateUrl: "/app/components/invoices/invoiceListView.html",
            controller: "invoiceListController"
        });
    }
})();