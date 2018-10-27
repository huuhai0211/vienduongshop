
(function (app) {
    app.controller('warehouseAddController', warehouseAddController);

    warehouseAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function warehouseAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.warehouses = {
            Status: true
        }
        $scope.AddWarehouse = AddWarehouse;

        function AddWarehouse() {
            apiService.post('api/warehouse/create', $scope.warehouses,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('warehouse');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });

        }
        //$scope.parentWare = [];
        //function loadparentWare() {
        //    apiService.get('api/warehouse/getallparents', null, function (result) {
        //        $scope.parentWare = result.data;
        //    }, function (error) {
        //        console.log('Cannot get list parent');
        //    });
        //}
        //loadparentWare();

        //$scope.GetSeoTitle = GetSeoTitle;

        
        //function GetSeoTitle() {
        //    $scope.warehouse.Alias = commonService.getSeoTitle($scope.warehouse.Name);
        //}
        
    }
})(angular.module('shop.warehouse'));