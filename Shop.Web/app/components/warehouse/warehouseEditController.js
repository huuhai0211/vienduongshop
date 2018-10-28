
(function (app) {
    app.controller('warehouseEditController', warehouseEditController);

    warehouseEditController.$inject = ['apiService', '$scope', '$state', '$stateParams', 'commonService'];

    function warehouseEditController(apiService, $scope, $state, $stateParams, commonService) {
        $scope.warehouse = {

        }

        $scope.UpdateWarehouse = UpdateWarehouse;

        function loadWarehouseDetail() {
            apiService.get('api/warehouse/getbyid/' + $stateParams.id, null, function (result) {
                $scope.warehouse = result.data;
            }, function (error) {

            });
        }

        function UpdateWarehouse() {
            apiService.put('api/warehouse/update', $scope.warehouse, function (result) {
                $state.go('warehouse');
            }, function (error) {
                console.log('Cập nhật không thành công');
            });
        }
        loadWarehouseDetail();
    }
})(angular.module('shop.warehouse'));