(function (app) {
    app.controller('warehouseListController', warehouseListController);

    warehouseListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function warehouseListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.warehouse = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getWarehouse = getWarehouse;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteWarehouse = deleteWarehouse;

        $scope.$watch("warehouse", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.selectAll = selectAll;

        $scope.isAll = false;

        $scope.deleteMultiple = deleteMultiple;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.warehouse, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.warehouse, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedWarehouse: JSON.stringify(listId)
                }
            }
            apiService.del('api/warehouse/deletemulti', config, function (result) {
                search();
            }, function (error) {

            });
        }

        function deleteWarehouse(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/warehouse/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            getWarehouse();
        }

        function getWarehouse(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10,
                }
            }
            apiService.get('api/warehouse/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
                }
                $scope.warehouse = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load warehouse failed.');
            });
        }

        $scope.getWarehouse();
    }
})(angular.module('shop.warehouse'));