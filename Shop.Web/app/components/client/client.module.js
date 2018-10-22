(function () {
    angular.module('shop.client', ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('client', {
            url: "/client",
            parent: 'base',
            templateUrl: "/app/components/client/clientListView.html",
            controller: "clientListController"
        }).state('add_client', {
            url: "/add_client",
            parent: 'base',
            templateUrl: "/app/components/client/clientAddView.html",
            controller: "clientAddController"
        }).state('edit_client', {
            url: "/edit_client/:id",
            parent: 'base',
            templateUrl: "/app/components/client/clientEditView.html",
            controller: "clientEditController"
        });
    }
})();