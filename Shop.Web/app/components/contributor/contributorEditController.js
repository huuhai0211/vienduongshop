
(function (app) {
    app.controller('contributorEditController', contributorEditController);

    contributorEditController.$inject = ['apiService', '$scope', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController(apiService, $scope, $state, $stateParams, commonService) {
        $scope.contributor = {

        }

        $scope.UpdateContributor = UpdateContributor;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.contributor.Alias = commonService.getSeoTitle($scope.contributor.Name);
        }

        function loadContributorDetail() {
            apiService.get('api/contributor/getbyid/' + $stateParams.id, null, function (result) {
                $scope.contributor = result.data;
            }, function (error) {

            });
        }

        function UpdateContributor() {
            apiService.put('api/contributor/update', $scope.contributor, function (result) {
                $state.go('contributor');
            }, function (error) {
                console.log('Cập nhật không thành công');
            });
        }

        //$scope.parentCategories = [];
        //function loadParentCategory() {
        //    apiService.get('api/productcategory/getallparents', null, function (result) {
        //        $scope.parentCategories = result.data;
        //    }, function (error) {
        //        console.log('Cannot get list parent');
        //    });
        //}
        //loadParentCategory();
        //loadProductCategoryDetail();
    }
})(angular.module('shop.contributor'));