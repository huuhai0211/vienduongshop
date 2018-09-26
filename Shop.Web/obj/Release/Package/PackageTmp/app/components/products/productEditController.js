
(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService', '$stateParams'];

    function productEditController(apiService, $scope, $state, commonService, notificationService, $stateParams) {
        $scope.moreImages = [];
        $scope.UpdateProduct = UpdateProduct;

        function LoadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImage); 
            }, function (error) {
                //console.log('Cannot get list parent');
            });
        }
        LoadProductDetail();
        function UpdateProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);
            apiService.put('api/product/update/', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });

        }

        $scope.GetSeoTitle = GetSeoTitle;

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        loadProductCategories();

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    if ($scope.moreImages != null) {
                        $scope.moreImages.push(fileUrl);
                    }
                    else {
                        $scope.moreImages = [];
                        $scope.moreImages.push(fileUrl);
                    }
                    
                })
            }
            finder.popup();
        }
    }
})(angular.module('shop.products'));   