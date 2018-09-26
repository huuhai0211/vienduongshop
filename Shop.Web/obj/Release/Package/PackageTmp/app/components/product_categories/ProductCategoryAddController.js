
(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function productCategoryAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.productCategory = {
            Status: true
        }

        $scope.AddProductCategory = AddProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function AddProductCategory() {
            apiService.post('api/productcategory/create', $scope.productCategory, function (result) {
                $state.go('product_categories');
            }, function (error) {
                console.log('Thêm mới không thành công');
            });
        }

        $scope.parentCategories = [];
        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }
        loadParentCategory();
    }
})(angular.module('shop.product_categories'));   