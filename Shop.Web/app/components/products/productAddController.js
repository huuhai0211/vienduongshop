
(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function productAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.product = {
            Status: true
        }
        $scope.AddProduct = AddProduct;

        function AddProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });

        }
        //$scope.parentProduct = [];
        //function loadparentProduct() {
        //    apiService.get('api/product/getallparents', null, function (result) {
        //        $scope.parentProduct = result.data;
        //    }, function (error) {
        //        console.log('Cannot get list parent');
        //    });
        //}
        //loadparentProduct();

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
        loadProductCategories();
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }


        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
    }
})(angular.module('shop.products'));   