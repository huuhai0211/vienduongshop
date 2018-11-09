(function (app) {
    app.controller('invoiceListController', invoiceListController);

    invoiceListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function invoiceListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.invoices = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        //$scope.getProducts = getProducts;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProduct = deleteProduct;

        //$scope.$watch("invoices", function (n, o) {
        //    var checked = $filter("filter")(n, { checked: true });
        //    if (checked.length) {
        //        $scope.selected = checked;
        //        $('#btnDelete').removeAttr('disabled');
        //    } else {
        //        $('#btnDelete').attr('disabled', 'disabled');
        //    }
        //}, true);

        //$scope.selectAll = selectAll;

        //$scope.isAll = false;

        //$scope.deleteMultiple = deleteMultiple;

        //function selectAll() {
        //    if ($scope.isAll === false) {
        //        angular.forEach($scope.invoices, function (item) {
        //            item.checked = true;
        //        });
        //        $scope.isAll = true;
        //    } else {
        //        angular.forEach($scope.invoices, function (item) {
        //            item.checked = false;
        //        });
        //        $scope.isAll = false;
        //    }
        //}

        //function deleteMultiple() {
        //    var listId = [];
        //    $.each($scope.selected, function (i, item) {
        //        listId.push(item.ID);
        //    });
        //    var config = {
        //        params: {
        //            checkedProducts: JSON.stringify(listId)
        //        }
        //    }
        //    apiService.del('api/invoice/deletemulti', config, function (result) {
        //        search();
        //    }, function (error) {

        //    });
        //}

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/invoice/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            getProducts();
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10,
                }
            }
            apiService.get('api/invoice/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
                }
                $scope.invoices = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load invoice failed.');
            });
        }
        $scope.getProducts();
    }
})(angular.module('shop.invoices'));