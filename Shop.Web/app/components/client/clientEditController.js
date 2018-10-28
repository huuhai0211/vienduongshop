
(function (app) {
    app.controller('clientEditController', clientEditController);

    clientEditController.$inject = ['apiService', '$scope', '$state', '$stateParams', 'commonService'];

    function clientEditController(apiService, $scope, $state, $stateParams, commonService) {
        $scope.client = {

        }

        $scope.UpdateClient = UpdateClient;

        function loadClientDetail() {
            apiService.get('api/client/getbyid/' + $stateParams.id, null, function (result) {
                $scope.client = result.data;
            }, function (error) {

            });
        }

        function UpdateClient() {
            apiService.put('api/client/update', $scope.client, function (result) {
                $state.go('client');
            }, function (error) {
                console.log('Cập nhật không thành công');
            });
        }
        loadClientDetail();
    }
})(angular.module('shop.client'));