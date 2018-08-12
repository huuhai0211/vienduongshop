
(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController(apiService, $scope, $state, $stateParams, commonService) {
        $scope.productCategory = {

        }

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id,null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {

            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                $state.go('product_categories');
            }, function (error) {
                console.log('Cập nhật không thành công');
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
        loadProductCategoryDetail();
    }
})(angular.module('shop.product_categories'));   