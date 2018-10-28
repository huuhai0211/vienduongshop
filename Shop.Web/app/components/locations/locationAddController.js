
(function (app) {
    app.controller('locationAddController', locationAddController);

    locationAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function locationAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.location = {
            Status: true
        }


        $scope.AddLocation = AddLocation;
       // $scope.GetSeoTitle = GetSeoTitle;

        //function GetSeoTitle() {
        //    $scope.location.Alias = commonService.getSeoTitle($scope.location.Name);
        //}

        function AddLocation() {
            apiService.post('api/location/create', $scope.location, function (result) {
                $state.go('locations');
            }, function (error) {
                console.log('Thêm mới không thành công');
            });
        }
        function loadWarehouse() {
            apiService.get('api/warehouse/getallparents', null, function (result) {
                $scope.warehouses = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }
        loadWarehouse();

        function loadProduct() {
            apiService.get('api/product/getallparents', null, function (result) {
                $scope.products = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }
        loadProduct();

    }
})(angular.module('shop.locations'));