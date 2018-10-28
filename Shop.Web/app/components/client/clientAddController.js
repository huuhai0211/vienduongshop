
(function (app) {
    app.controller('clientAddController', clientAddController);

    clientAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function clientAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.client = {
            Status: true
        }
        $scope.AddClient = AddClient;

        function AddClient() {
            apiService.post('api/client/create', $scope.client,
                function (result) {
                    $state.go('client');
                }, function (error) {
                    console.log('Thêm mới không thành công');
                });

        }

    }
})(angular.module('shop.client'));