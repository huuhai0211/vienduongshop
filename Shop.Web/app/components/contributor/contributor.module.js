(function () {
    angular.module('shop.contributor', ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('contributors', {
            url: "/contributors",
            parent: 'base',
            templateUrl: "/app/components/contributor/contributorListView.html",
            controller: "contributorListController"
        }).state('add_contributor', {
            url: "/add_contributor",
            parent: 'base',
            templateUrl: "/app/components/contributor/contributorAddView.html",
            controller: "contributorAddController"
        }).state('edit_contributor', {
            url: "/edit_contributor/:id",
            parent: 'base',
            templateUrl: "/app/components/contributor/contributorEditView.html",
            controller: "contributorEditController"
        });
    }
})();