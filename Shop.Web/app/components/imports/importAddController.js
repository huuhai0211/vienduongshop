    
(function (app) {
    app.controller('importAddController', importAddController);

    importAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function importAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.import = {
            //Status: true
        }
        $scope.importDetail = {
        }
        $scope.product = [];
        $scope.warehouses = [];
        $scope.importDetails = [];
        
        $scope.AddImport = AddImport;
        //$scope.GetSeoTitle = GetSeoTitle;

        //function GetSeoTitle() {
        //    $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        //}

        function loadProduct() {
            apiService.get('api/product/getallparents', null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }
        loadProduct();

        function loadWarehouse() {
            apiService.get('api/warehouse/getallparents', null, function (result) {
                $scope.warehouses = result.data;
            }, function (error) {
                console.log('Cannot get list parent');
            });
        }
        loadWarehouse();

        function AddImport() {
            var config = {
                params: {
                    importDetailViewModels: JSON.stringify($scope.importDetails)
                }
            }
            apiService.post('api/importProduct/create', $scope.import, function (result) {
                //$state.go('imports');
            }, function (error) {
                console.log('Thêm mới không thành công');
            });
            apiService.get('api/importProduct/createdetail', config, function () {
                $state.go('imports');
            }, function (error) {
                console.log('Thêm mới không thành công');
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

        $('#btnsubmit').click(function (e) {
            e.preventDefault();
            //var product = $("#product").val();
            //var quantity = $("#quantity").val();
            //var price = $("#price").val();
            //var warehouse = $("#warehouse").val();
            //var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + product + "</td><td>" + quantity + "</td><td>" + price + "</td><td>" + warehouse + "</td></tr>";
            //$("table tbody").append(markup);
            $scope.importDetail = {
                ImportID: $("#importID").val(),
                ProductID: $scope.importDetail.ProductID,
                Quantity: $("#quantity").val(),
                Price: $("#price").val(),
                WarehouseId: $scope.importDetail.WarehouseId
            }
            $scope.$apply(function () {
                $scope.importDetails.push($scope.importDetail);
            })
          
        });
        function GetImportDetails() {

        }
    }
})(angular.module('shop.imports'));